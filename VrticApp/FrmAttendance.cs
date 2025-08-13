using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VrticApp.Models;
using VrticApp.Services;

namespace VrticApp
{
    public partial class FrmAttendance : Form
    {
        private readonly DolazakService _dolazakService;
        private readonly Korisnik _prijavljeniKorisnik;

        public FrmAttendance(Korisnik korisnik)
        {
            InitializeComponent();
            _dolazakService = new DolazakService();
            _prijavljeniKorisnik = korisnik;
        }


        private void FrmAttendance_Load_1(object sender, EventArgs e)
        {
            if (_prijavljeniKorisnik != null)
            {
                lblPrijavljen.Text = $"Prijavljeni ste kao: {_prijavljeniKorisnik.Uloga}";
            }

            comboBoxGrupa.DataSource = _dolazakService.GetGroups();
            comboBoxGrupa.DisplayMember = "Naziv";
            comboBoxGrupa.ValueMember = "GrupaId";
            comboBoxGrupa.SelectedIndex = -1;
        }

        private void btnPrikaziEvidenciju_Click(object sender, EventArgs e)
        {
            if (comboBoxGrupa.SelectedValue != null && comboBoxGrupa.SelectedValue.ToString() != "")
            {
                int groupId = Convert.ToInt32(comboBoxGrupa.SelectedValue);
                DateTime date = dateTimePickerDatum.Value.Date;

                var lista = _dolazakService.GetDolazak(groupId, date);
                if (lista == null || lista.Count == 0)
                {
                    MessageBox.Show("Nema podataka za odabranu grupu i datum.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvEvidencija.DataSource = null;
                    return;
                }

                dgvEvidencija.DataSource = lista;

                if (dgvEvidencija.Columns.Contains("ime"))
                    dgvEvidencija.Columns["ime"].HeaderText = "Ime";
                if (dgvEvidencija.Columns.Contains("prezime"))
                    dgvEvidencija.Columns["prezime"].HeaderText = "Prezime";
                if (dgvEvidencija.Columns.Contains("datum"))
                    dgvEvidencija.Columns["datum"].HeaderText = "Datum";
                if (dgvEvidencija.Columns.Contains("vrijeme_dolaska"))
                    dgvEvidencija.Columns["vrijeme_dolaska"].HeaderText = "Vrijeme dolaska";
                if (dgvEvidencija.Columns.Contains("vrijeme_odlaska"))
                    dgvEvidencija.Columns["vrijeme_odlaska"].HeaderText = "Vrijeme odlaska";

            }
            else
            {
                MessageBox.Show("Odaberi grupu prije prikaza!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSpremiEvidenciju_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEvidencija.DataSource == null)
                {
                    MessageBox.Show("Nema podataka za spremanje.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var listaDolazaka = dgvEvidencija.DataSource as List<Dolazak>;
                if (listaDolazaka == null)
                {
                    MessageBox.Show("Pogrešan format podataka.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool uspjeh = _dolazakService.UpdateDolazak(listaDolazaka);

                if (uspjeh)
                    MessageBox.Show("Podaci su uspješno spremljeni." , "Uspjeh", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Došlo je do pogreške prilikom spremanja.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }

        private void btnNoviDolazak_Click(object sender, EventArgs e)
        {
            if (comboBoxGrupa.SelectedItem == null)
            {
                MessageBox.Show("Odaberite grupu!");
                return;
            }

            var grupa = (Grupa)comboBoxGrupa.SelectedItem;
            DateTime odabraniDatum = dateTimePickerDatum.Value.Date;

            frmNoviDolazak forma = new frmNoviDolazak(grupa.GrupaId, odabraniDatum);
            if (forma.ShowDialog() == DialogResult.OK)
            {
                // Ponovno učitaj dolaske
                dgvEvidencija.DataSource = _dolazakService.GetDolazak(grupa.GrupaId, odabraniDatum);
            }
        }

        private void btnGenerirajMjesecniIzvjestaj_Click(object sender, EventArgs e)
        {

        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            // Pronađi otvorenu instancu Pocetna forme
            Pocetna pocetnaForma = Application.OpenForms.OfType<Pocetna>().FirstOrDefault();

            if (pocetnaForma != null)
            {
                pocetnaForma.Show(); // Prikaži postojeću Pocetna formu
            }

            this.Close(); // Zatvori trenutnu formu
        }
    }
}
