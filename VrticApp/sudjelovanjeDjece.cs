using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using VrticApp.Services;

namespace RWA
{
    public partial class sudjelovanjeDjece : Form
    {
        private readonly AktivnostService _aktivnostSvc = new AktivnostService();
        private readonly DolazakAktivnostService _dolazakSvc = new DolazakAktivnostService();
        private readonly string _cs =
            "Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8";

        private Dictionary<int, string> _grupe;

        public sudjelovanjeDjece()
        {
            InitializeComponent();
            Shown += (_, __) =>
            {
                _grupe = UcitajGrupeDict();
                UcitajGrid(descending: true); //najnovije prvo
            };

            // otvaranje grid celije
            gridSudjelovanje.CellDoubleClick += GridSudjelovanje_CellDoubleClick;
        }

        // grid
        private void UcitajGrid(bool descending)
        {
            var aktivnosti = _aktivnostSvc.DohvatiSve();
            var sudjelovanja = _dolazakSvc.DohvatiSve();

            var podaci = aktivnosti
                .Select(a => new
                {
                    a.IdAktivnost,
                    a.ImeAktivnosti,
                    NazivGrupe = _grupe.ContainsKey(a.GrupaId) ? _grupe[a.GrupaId] : $"grupa {a.GrupaId}",
                    a.DatumAktivnosti,
                    BrojDjece = sudjelovanja.Count(s => s.AktivnostId == a.IdAktivnost && s.Sudjelovao)
                });

            podaci = descending
                ? podaci.OrderByDescending(x => x.DatumAktivnosti).ThenByDescending(x => x.IdAktivnost)
                : podaci.OrderBy(x => x.DatumAktivnosti).ThenBy(x => x.IdAktivnost);

            gridSudjelovanje.AutoGenerateColumns = true;
            gridSudjelovanje.ReadOnly = true;
            gridSudjelovanje.AllowUserToAddRows = false;
            gridSudjelovanje.AllowUserToDeleteRows = false;
            gridSudjelovanje.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridSudjelovanje.DataSource = podaci.ToList();

            if (gridSudjelovanje.Columns.Contains("DatumAktivnosti"))
                gridSudjelovanje.Columns["DatumAktivnosti"].DefaultCellStyle.Format = "dd.MM.yyyy";

            gridSudjelovanje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // sortitnanje po grupi
        private void SortirajPoGrupi()
        {
            var aktivnosti = _aktivnostSvc.DohvatiSve();
            var sudjelovanja = _dolazakSvc.DohvatiSve();

            var podaci = aktivnosti
                .Select(a => new
                {
                    a.IdAktivnost,
                    a.ImeAktivnosti,
                    NazivGrupe = _grupe.ContainsKey(a.GrupaId) ? _grupe[a.GrupaId] : $"grupa {a.GrupaId}",
                    a.DatumAktivnosti,
                    BrojDjece = sudjelovanja.Count(s => s.AktivnostId == a.IdAktivnost && s.Sudjelovao)
                })
                .OrderBy(x => x.NazivGrupe)
                .ThenByDescending(x => x.DatumAktivnosti)
                .ToList();

            gridSudjelovanje.DataSource = podaci;

            if (gridSudjelovanje.Columns.Contains("DatumAktivnosti"))
                gridSudjelovanje.Columns["DatumAktivnosti"].DefaultCellStyle.Format = "dd.MM.yyyy";
            gridSudjelovanje.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ispis imena umjesto id-a
        private Dictionary<int, string> UcitajGrupeDict()
        {
            var dict = new Dictionary<int, string>();
            using (var con = new SqlConnection(_cs))
            using (var cmd = new SqlCommand("SELECT grupa_id, naziv FROM dbo.Grupa;", con))
            {
                con.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        dict[r.GetInt32(0)] = r.GetString(1);
            }
            return dict;
        }

        // gumobi
        private void btnNovo_Click(object sender, EventArgs e)
        {
            UcitajGrid(descending: true);   // najnoviji prvi
        }

        private void btnStaro_Click(object sender, EventArgs e)
        {
            UcitajGrid(descending: false);  // najstariji prvi
        }

        private void btnGrupa_Click(object sender, EventArgs e)
        {
            SortirajPoGrupi();              // sortiranje po grupi
        }

        // doubleclick na red
        private void GridSudjelovanje_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gridSudjelovanje.Rows[e.RowIndex].DataBoundItem;
            if (row == null) return;

            int aktivnostId = (int)row.GetType().GetProperty("IdAktivnost").GetValue(row);

            var dt = UcitajDjecuZaAktivnost(aktivnostId);

            var dlg = new Form
            {
                Text = "Djeca na aktivnosti",
                StartPosition = FormStartPosition.CenterParent,
                Size = new System.Drawing.Size(600, 400)
            };

            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                DataSource = dt
            };

            if (grid.Columns.Contains("dijete_id"))
                grid.Columns["dijete_id"].Visible = false;

            dlg.Controls.Add(grid);
            dlg.ShowDialog(this);
        }

        private DataTable UcitajDjecuZaAktivnost(int aktivnostId)
        {
            var dt = new DataTable();
            var sql = @"
            SELECT d.dijete_id, d.ime, d.prezime
            FROM dbo.Dijete d
            INNER JOIN dbo.DolazakAktivnost da
              ON da.DijeteId = d.dijete_id
            WHERE da.AktivnostId = @aid AND da.Sudjelovao = 1
            ORDER BY d.prezime, d.ime;";

            using (var con = new SqlConnection(_cs))
            using (var da = new SqlDataAdapter(sql, con))
            {
                da.SelectCommand.Parameters.AddWithValue("@aid", aktivnostId);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
