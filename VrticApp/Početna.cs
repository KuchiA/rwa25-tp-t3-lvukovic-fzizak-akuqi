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

namespace VrticApp
{
    public partial class Početna : Form
    {
        public Početna()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Početna_Load(object sender, EventArgs e)
        {

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
    }
}
