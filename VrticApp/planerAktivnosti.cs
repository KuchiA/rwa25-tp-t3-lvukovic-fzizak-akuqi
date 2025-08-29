using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RWA
{
    public partial class planerAktivnosti : Form
    {
        // 1) Connection string
        private readonly string _cs = "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        // Cache da ne spajamo stalno
        private DataTable _grupeDt;

        public planerAktivnosti()
        {
            InitializeComponent();
            cmbGrupa.DropDown += cmbGrupa_DropDown;
        }

        private void LoadGrupe()
        {
            using (var con = new SqlConnection("Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8"))
            using (var da = new SqlDataAdapter("SELECT grupa_id, naziv FROM dbo.Grupa ORDER BY naziv;", con))
            {
                var dt = new DataTable();
                da.Fill(dt);

                cmbGrupa.DisplayMember = "naziv";
                cmbGrupa.ValueMember = "grupa_id";
                cmbGrupa.DataSource = dt;
            }
        }

        private void cmbGrupa_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (_grupeDt == null || _grupeDt.Rows.Count == 0)
                    LoadGrupe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri uèitavanju grupa:\n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DodajBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validacija
                if (string.IsNullOrWhiteSpace(imeAktivnosti.Text))
                {
                    MessageBox.Show("Unesite ime aktivnosti.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbGrupa.SelectedValue == null)
                {
                    MessageBox.Show("Odaberite grupu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Priprema queryja
                using (var con = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(@"
                INSERT INTO dbo.Aktivnost (imeAktivnosti, grupa_id, datumAktivnosti, opisAktivnosti)
                VALUES (@ime, @grupaId, @datum, @opis);", con))
                {
                    cmd.Parameters.AddWithValue("@ime", imeAktivnosti.Text.Trim());
                    cmd.Parameters.AddWithValue("@grupaId", (int)cmbGrupa.SelectedValue);
                    cmd.Parameters.AddWithValue("@datum", datumAktivnosti.Value.Date);
                    cmd.Parameters.AddWithValue("@opis", OpisTXT.Text.Trim());

                    // 3. Izvrši
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Aktivnost uspješno dodana!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Po želji resetiraj polja
                imeAktivnosti.Clear();
                OpisTXT.Clear();
                cmbGrupa.SelectedIndex = -1;
                datumAktivnosti.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju aktivnosti:\n" + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PregledRaspored(object sender, EventArgs e)
        {
            try
            {
                //uèitavanje
                DataTable LoadTable()
                {
                    var dt = new DataTable();
                    using (var con = new SqlConnection(_cs))
                    using (var da = new SqlDataAdapter(@"
                SELECT a.IdAktivnost,
                       a.imeAktivnosti,
                       g.naziv AS NazivGrupe,
                       a.datumAktivnosti,
                       a.opisAktivnosti
                FROM dbo.Aktivnost a
                INNER JOIN dbo.Grupa g ON g.grupa_id = a.grupa_id
                ORDER BY a.datumAktivnosti DESC, a.IdAktivnost DESC;", con))
                {
                    da.Fill(dt);
                }
                    return dt;
                }

                var frm = new Form
                {
                    Text = "Raspored aktivnosti",
                    StartPosition = FormStartPosition.CenterParent,
                    Size = new Size(900, 450),
                    MinimizeBox = false,
                    MaximizeBox = true
                };

                var grid = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AutoGenerateColumns = true,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect = true
                };

                // uèitavanje bazer
                var dtData = LoadTable();
                grid.DataSource = dtData;
                if (grid.Columns.Contains("datumAktivnosti"))
                    grid.Columns["datumAktivnosti"].DefaultCellStyle.Format = "dd.MM.yyyy";
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // menu za brisanje
                var cms = new ContextMenuStrip();
                var miDelete = new ToolStripMenuItem("Obriši odabrano");
                cms.Items.Add(miDelete);
                grid.ContextMenuStrip = cms;

                // funkcija brisanja
                void DeleteSelected()
                {
                    if (grid.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Odaberi barem jednu aktivnost.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MessageBox.Show("Sigurno obrisati odabrane aktivnosti?",
                                        "Potvrda brisanja",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    // pokupi ID-eve
                    var ids = new List<int>();
                    foreach (DataGridViewRow r in grid.SelectedRows)
                    {
                        // kolona se zove "IdAktivnost" (iz SELECT-a)
                        var val = r.Cells["IdAktivnost"].Value;
                        if (val != null && int.TryParse(val.ToString(), out int id))
                            ids.Add(id);
                    }
                    if (ids.Count == 0) return;

                    // DELETE WHERE IdAktivnost IN (@p0, @p1, ...)
                    using (var con = new SqlConnection(_cs))
                    {
                        con.Open();
                        var sb = new StringBuilder("DELETE FROM dbo.Aktivnost WHERE IdAktivnost IN (");
                        for (int i = 0; i < ids.Count; i++)
                        {
                            if (i > 0) sb.Append(",");
                            sb.Append($"@p{i}");
                        }
                        sb.Append(");");

                        using (var cmd = new SqlCommand(sb.ToString(), con))
                        {
                            for (int i = 0; i < ids.Count; i++)
                                cmd.Parameters.AddWithValue($"@p{i}", ids[i]);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // refresh podataka
                    grid.DataSource = LoadTable();
                }

                // veži evente
                miDelete.Click += (s2, e2) => DeleteSelected();
                grid.KeyDown += (s3, e3) =>
                {
                    if (e3.KeyCode == Keys.Delete)
                    {
                        DeleteSelected();
                        e3.Handled = true;
                    }
                };

                frm.Controls.Add(grid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri uèitavanju/brisanja:\n" + ex.Message,"Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void planerAktivnosti_Load(object sender, EventArgs e)
        {

        }

        private void naslovnaBtn(object sender, EventArgs e)
        {
            Close();
        }
    }
}
