using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VrticApp.Models;
using VrticApp.Services;

namespace VrticApp
{
    public partial class FrmStatistics : Form
    {
        private readonly StatistikaService _statistikaService;
        private readonly Korisnik _prijavljeniKorisnik;

        public FrmStatistics(Korisnik korisnik)
        {
            InitializeComponent();
            _statistikaService = new StatistikaService();
            _prijavljeniKorisnik = korisnik;
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Pocetna pocetnaForma = Application.OpenForms.OfType<Pocetna>().FirstOrDefault();

            if (pocetnaForma != null)
            {
                pocetnaForma.Show();
            }

            this.Close();
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            if (_prijavljeniKorisnik != null)
            {
                lblPrijavljen.Text = $"Prijavljeni ste kao: {_prijavljeniKorisnik.Uloga}";
            }

            cmbGroup.DataSource = _statistikaService.UcitajGrupe();
            cmbGroup.DisplayMember = "naziv";
            cmbGroup.ValueMember = "grupa_id";

            cmbFilter.Items.AddRange(new[] { "Zadnji dan", "Zadnji tjedan", "Zadnji mjesec" });
            cmbFilter.SelectedIndex = 0;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedValue == null)
            {
                MessageBox.Show("Molimo odaberite grupu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int grupaId = Convert.ToInt32(cmbGroup.SelectedValue);
            DateTime startDate = DateTime.Now;

            switch (cmbFilter.SelectedItem.ToString())
            {
                case "Zadnji dan": startDate = DateTime.Now.AddDays(-1); break;
                case "Zadnji tjedan": startDate = DateTime.Now.AddDays(-7); break;
                case "Zadnji mjesec": startDate = DateTime.Now.AddMonths(-1); break;
            }

            DataTable dtDolazak = _statistikaService.DohvatiDolazke(grupaId, startDate);
            dgvDetails.DataSource = dtDolazak;

            dgvDetails.AutoGenerateColumns = true;
            dgvDetails.Columns["dolazak_id"].HeaderText = "ID Dolaska";
            dgvDetails.Columns["dijete_id"].HeaderText = "ID Djeteta";
            dgvDetails.Columns["datum"].HeaderText = "Datum";

            PrikaziGraf(dtDolazak);
        }

        private void PrikaziGraf(DataTable dt)
        {
            chartGraf.Series.Clear();
            Series series = new Series("Dolazaka")
            {
                ChartType = SeriesChartType.Column
            };

            var grupirano = _statistikaService.GrupirajDolazkePoDatumu(dt);

            foreach (var item in grupirano)
            {
                series.Points.AddXY(item.Datum.ToString("dd.MM."), item.BrojDolazaka);
            }

            chartGraf.Series.Add(series);

            // Omogući prikaz labele na Y-osi za brojeve
            chartGraf.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            // Omogući prikaz labele na X-osi za datume
            chartGraf.ChartAreas[0].AxisX.LabelStyle.Enabled = true;

            // Postavi naslov za X i Y os
            chartGraf.ChartAreas[0].AxisX.Title = "Datum";
            chartGraf.ChartAreas[0].AxisY.Title = "Broj dolazaka";
        }
    }
}