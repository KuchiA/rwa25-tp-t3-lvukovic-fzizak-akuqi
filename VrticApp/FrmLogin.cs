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
    public partial class FrmLogin : Form
    {
        private readonly KorisnikService _korisnikService;
        public FrmLogin()
        {
            InitializeComponent();
            _korisnikService = new KorisnikService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string korisnickoIme = txtBoxUsername.Text.Trim();
            string lozinka = txtBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(korisnickoIme) || string.IsNullOrEmpty(lozinka))
            {
                MessageBox.Show("Niste unijeli podatke!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Korisnik korisnik = _korisnikService.PrijaviKorisnika(korisnickoIme, lozinka);

            if (korisnik != null)
            {
                MessageBox.Show($"Uspješno ste se prijavili kao {korisnik.Uloga}!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Pocetna pocetna = new Pocetna(korisnik);
                this.Hide();
                pocetna.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Pogrešan unos!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
