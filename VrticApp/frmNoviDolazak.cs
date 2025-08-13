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
using VrticApp.Models;
using VrticApp.Services;

namespace VrticApp
{
    public partial class frmNoviDolazak : Form
    {
        private readonly int _grupaId;
        private readonly DateTime _datum;
        private readonly DolazakService _dolazakService;

        public frmNoviDolazak(int grupaId, DateTime datum)
        {
            InitializeComponent();
            _grupaId = grupaId;
            _datum = datum;
            _dolazakService = new DolazakService();
        }

        private void frmNoviDolazak_Load(object sender, EventArgs e)
        {
            // Učitavanje djece iz odabrane grupe
            using (SqlConnection conn = new SqlConnection("Data Source=31.147.206.65;Initial Catalog=RWA2514_DB;User ID=RWA2514_User;Password=.dhKxJs8"))
            {
                conn.Open();
                string query = "SELECT dijete_id, ime + ' ' + prezime AS ImePrezime FROM Dijete WHERE grupa_id = @grupaId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@grupaId", _grupaId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbDijete.Items.Add(new { Id = reader.GetInt32(0), ImePrezime = reader.GetString(1) });
                        }
                    }
                }
            }

            cmbDijete.DisplayMember = "ImePrezime";
            cmbDijete.ValueMember = "Id";
        }

    }
}

