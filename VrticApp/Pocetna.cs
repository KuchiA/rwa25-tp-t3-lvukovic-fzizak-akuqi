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
        }

        private void dolasci_Click(object sender, EventArgs e)
        {
            var FrmTracking = new FrmTracking();
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
            var FrmStatistics = new FrmStatistics();
            Hide();
            FrmStatistics.ShowDialog();
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
    }
}
