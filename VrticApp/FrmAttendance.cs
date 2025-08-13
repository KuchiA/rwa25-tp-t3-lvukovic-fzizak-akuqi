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
            try
            {
                if (_prijavljeniKorisnik != null)
                {
                    lblPrijavljen.Text = $"Prijavljeni ste kao: {_prijavljeniKorisnik.Uloga}";
                }

                var grupe = _dolazakService.GetGroups();

                if (grupe != null && grupe.Any())
                {
                    comboBoxGrupa.DataSource = new List<Grupa>(grupe);
                    comboBoxGrupa.DisplayMember = "Naziv";
                    comboBoxGrupa.ValueMember = "GrupaId";
                    comboBoxGrupa.SelectedIndex = -1;

                    cmbGrupa.DataSource = new List<Grupa>(grupe);
                    cmbGrupa.DisplayMember = "Naziv";
                    cmbGrupa.ValueMember = "GrupaId";
                    cmbGrupa.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Nije moguće učitati grupe.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dateTimePickerDatum.Value = DateTime.Today;
                dtpDatum.Value = DateTime.Today;

                dtpDolazak.Format = DateTimePickerFormat.Time;
                dtpDolazak.ShowUpDown = true;
                dtpDolazak.Value = DateTime.Today.Date + DateTime.Now.TimeOfDay;

                dtpOdlazak.Format = DateTimePickerFormat.Time;
                dtpOdlazak.ShowUpDown = true;
                dtpOdlazak.Value = DateTime.Today.Date + DateTime.Now.TimeOfDay;

                // Tu se automatski popunjava txtDolazakId
                // Vidljiv je, ali je ReadOnly na true u dizajneru
                txtDolazakId.Text = _dolazakService.GetNextDolazakId().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška u FrmAttendance_Load_1: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrikaziEvidenciju_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri prikazu evidencije: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Podaci su uspješno spremljeni.", "Uspjeh", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Došlo je do pogreške prilikom spremanja.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerirajMjesecniIzvjestaj_Click(object sender, EventArgs e)
        {

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

        private void btnSpremiNoviDolazak_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbGrupa.SelectedValue == null)
                {
                    MessageBox.Show("Morate odabrati grupu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtDijeteId.Text, out int dijeteId))
                {
                    MessageBox.Show("Dijete ID mora biti brojčana vrijednost.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int grupaId = Convert.ToInt32(cmbGrupa.SelectedValue); // Dohvaća se ID odabrane grupe

                if (!_dolazakService.IsDijeteInGroup(dijeteId, grupaId))
                {
                    MessageBox.Show("Dijete s unesenim ID-om ne pripada odabranoj grupi.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime datum = dtpDatum.Value.Date;
                TimeSpan vrijemeDolaska = dtpDolazak.Value.TimeOfDay;
                TimeSpan vrijemeOdlaska = dtpOdlazak.Value.TimeOfDay;

                if (vrijemeDolaska > vrijemeOdlaska)
                {
                    MessageBox.Show("Vrijeme dolaska ne može biti poslije vremena odlaska.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_dolazakService.ProvjeriPostojeciDolazak(dijeteId, datum))
                {
                    MessageBox.Show("Za ovo dijete je već evidentiran dolazak na odabrani datum.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int dolazakId = Convert.ToInt32(txtDolazakId.Text);
                bool uspjeh = _dolazakService.InsertNewDolazak(dolazakId, dijeteId, datum, vrijemeDolaska, vrijemeOdlaska);

                if (uspjeh)
                {
                    MessageBox.Show("Novi dolazak uspješno spremljen.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (comboBoxGrupa.SelectedValue != null && Convert.ToInt32(comboBoxGrupa.SelectedValue) == grupaId)
                    {
                        btnPrikaziEvidenciju_Click(sender, e);
                    }

                    txtDolazakId.Text = _dolazakService.GetNextDolazakId().ToString();
                    cmbGrupa.SelectedIndex = -1;
                    txtDijeteId.Clear();
                    dtpDatum.Value = DateTime.Today;
                    dtpDolazak.Value = DateTime.Today.Date + DateTime.Now.TimeOfDay;
                    dtpOdlazak.Value = DateTime.Today.Date + DateTime.Now.TimeOfDay;
                }
                else
                {
                    MessageBox.Show("Došlo je do pogreške prilikom spremanja dolaska.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
