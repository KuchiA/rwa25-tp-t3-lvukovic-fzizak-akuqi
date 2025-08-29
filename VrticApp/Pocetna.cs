using probaa;
using RWA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VrticApp.Models;
using System.Diagnostics;

namespace VrticApp
{
    public partial class Pocetna : Form
    {
        private readonly Korisnik _trenutniKorisnik;
        public Pocetna(Korisnik korisnik)
        {
            InitializeComponent();
            _trenutniKorisnik = korisnik;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Pocetna_Load(object sender, EventArgs e)
        {
            lblUloga.Text = $"Prijavljeni ste kao: {_trenutniKorisnik.Uloga}";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void planerAktivnosti_Click(object sender, EventArgs e)
        {
            var planerAktivnosti = new planerAktivnosti();
            Hide();
            planerAktivnosti.ShowDialog();
            Show();
        }

        private void dolasci_Click(object sender, EventArgs e)
        {
            var FrmTracking = new FrmAttendance(_trenutniKorisnik);
            Hide();
            FrmTracking.ShowDialog();
        }

        private void evidencija_Click(object sender, EventArgs e)
        {
            var Evidencija = new Evidencija();
            Hide();
            Evidencija.ShowDialog();
        }

        private void upravljanjeGrupa_Click(object sender, EventArgs e)
        {
            var Upravljanje = new Upravljanje();
            Hide();
            Upravljanje.ShowDialog();
        }

        private void analiza_Click(object sender, EventArgs e)
        {
            if (_trenutniKorisnik.Uloga == "ravnateljica")
            {
                var FrmStatistics = new FrmStatistics(_trenutniKorisnik);
                Hide();
                FrmStatistics.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nije vam dozvoljeno pristupiti analizi podataka. Ova funkcija je rezervirana za ravnateljicu.", "Nedovoljna ovlast", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sudjelovanje_Click(object sender, EventArgs e)
        {
            var sudjelovanjeDjece = new sudjelovanjeDjece();
            Hide();
            sudjelovanjeDjece.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void btnOdjava_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Jeste li sigurni da se želite odjaviti?", "Potvrda odjave", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rezultat == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);

                Application.Exit();
            }
        }
    }
}
