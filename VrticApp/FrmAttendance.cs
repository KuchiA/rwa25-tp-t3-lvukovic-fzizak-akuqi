using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using VrticApp.Models;
using VrticApp.Services;
using System.Configuration;

namespace VrticApp
{
    public partial class FrmAttendance : Form
    {
        private readonly DolazakService _dolazakService;
        private readonly Korisnik _prijavljeniKorisnik;

        private List<Dijete> _currentDjecaList;
        private List<Dolazak> _currentDolazakList;
        private bool _sortAscending = true;

        public FrmAttendance(Korisnik korisnik)
        {
            InitializeComponent();
            _dolazakService = new DolazakService();
            _prijavljeniKorisnik = korisnik;

            this.dgvEvidencija.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvEvidencija_ColumnHeaderMouseClick);
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

                    _currentDolazakList = _dolazakService.GetDolazak(groupId, date);
                    _currentDjecaList = null;

                    if (_currentDolazakList == null || _currentDolazakList.Count == 0)
                    {
                        MessageBox.Show("Nema podataka za odabranu grupu i datum.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvEvidencija.DataSource = null;
                        return;
                    }

                    dgvEvidencija.DataSource = _currentDolazakList;
                    ApplyDataGridViewSettings("dolazak");
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

                int grupaId = Convert.ToInt32(cmbGrupa.SelectedValue);

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

        private void btnPopis_Click(object sender, EventArgs e)
        {
            try
            {
                _currentDjecaList = _dolazakService.GetAllChildren();
                _currentDolazakList = null;

                if (_currentDjecaList == null || _currentDjecaList.Count == 0)
                {
                    MessageBox.Show("Nema podataka o djeci.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvEvidencija.DataSource = null;
                    return;
                }

                dgvEvidencija.DataSource = _currentDjecaList;
                ApplyDataGridViewSettings("dijete");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri prikazu popisa djece: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEvidencija_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvEvidencija.Columns[e.ColumnIndex].Name;

            if (_currentDjecaList != null && dgvEvidencija.DataSource == _currentDjecaList)
            {
                if (columnName == "Prezime")
                {
                    _currentDjecaList = _sortAscending ? _currentDjecaList.OrderBy(d => d.Prezime).ToList() : _currentDjecaList.OrderByDescending(d => d.Prezime).ToList();
                }
                else if (columnName == "NazivGrupe")
                {
                    _currentDjecaList = _sortAscending ? _currentDjecaList.OrderBy(d => d.NazivGrupe).ToList() : _currentDjecaList.OrderByDescending(d => d.NazivGrupe).ToList();
                }
                else
                {
                    return; // Ne radi ništa ako stupac nije predviđen za sortiranje
                }

                dgvEvidencija.DataSource = null;
                dgvEvidencija.DataSource = _currentDjecaList;
                ApplyDataGridViewSettings("dijete");
            }
            else if (_currentDolazakList != null && dgvEvidencija.DataSource == _currentDolazakList)
            {
                if (columnName == "prezime")
                {
                    _currentDolazakList = _sortAscending ? _currentDolazakList.OrderBy(d => d.Prezime).ToList() : _currentDolazakList.OrderByDescending(d => d.Prezime).ToList();
                }
                else if (columnName == "datum")
                {
                    _currentDolazakList = _sortAscending ? _currentDolazakList.OrderBy(d => d.Datum).ToList() : _currentDolazakList.OrderByDescending(d => d.Datum).ToList();
                }
                else
                {
                    return;
                }

                dgvEvidencija.DataSource = null;
                dgvEvidencija.DataSource = _currentDolazakList;
                ApplyDataGridViewSettings("dolazak");
            }

            _sortAscending = !_sortAscending;
        }

        private void ApplyDataGridViewSettings(string type)
        {
            if (type == "dijete")
            {
                dgvEvidencija.Columns["DijeteId"].HeaderText = "ID djeteta";
                dgvEvidencija.Columns["Ime"].HeaderText = "Ime";
                dgvEvidencija.Columns["Prezime"].HeaderText = "Prezime ↓";
                dgvEvidencija.Columns["DatumRodenja"].HeaderText = "Datum rođenja";
                dgvEvidencija.Columns["EmailRoditelja"].HeaderText = "Email roditelja";
                dgvEvidencija.Columns["NazivGrupe"].HeaderText = "Grupa ↓";

                dgvEvidencija.Columns["GrupaId"].Visible = false;
                dgvEvidencija.Columns["ImePrezime"].Visible = false;
            }
            else if (type == "dolazak")
            {
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
        }

        private void btnPosaljiEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxGrupa.SelectedValue == null || string.IsNullOrEmpty(comboBoxGrupa.SelectedValue.ToString()))
                {
                    MessageBox.Show("Odaberite grupu za koju želite provjeriti izostanke.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int groupId = Convert.ToInt32(comboBoxGrupa.SelectedValue);
                DateTime date = dateTimePickerDatum.Value.Date;

                var noShowChildren = _dolazakService.GetNoShowChildren(groupId, date);

                if (noShowChildren == null || noShowChildren.Count == 0)
                {
                    MessageBox.Show("Sva djeca iz odabrane grupe su prisutna ili nema podataka o djeci. Nije potrebno slati e-mailove.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult potvrda = MessageBox.Show(
                    $"Pronađeno je {noShowChildren.Count} djece koja su izostala. Želite li poslati obavijesti roditeljima?",
                    "Potvrda slanja e-mailova",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (potvrda == DialogResult.Yes)
                {
                    int sentEmails = 0;
                    foreach (var dijete in noShowChildren)
                    {
                        if (!string.IsNullOrEmpty(dijete.EmailRoditelja))
                        {
                            bool success = PosaljiEmail(dijete.EmailRoditelja, $"Obavijest o izostanku djeteta {dijete.Ime} {dijete.Prezime}",
                                $"Poštovani roditelju,\n\n" +
                                $"Ovime Vas obavještavamo da Vaše dijete {dijete.Ime} {dijete.Prezime} nije evidentirano u vrtiću na datum {date.ToShortDateString()}.\n\n" +
                                $"Molimo Vas da nas obavijestite o razlogu izostanka.\n\n" +
                                $"S poštovanjem,\n" +
                                $"Vaš Vrtić");

                            if (success)
                            {
                                sentEmails++;
                            }
                        }
                    }
                    MessageBox.Show($"Završeno slanje. Uspješno poslano {sentEmails} e-mailova.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri slanju e-mailova: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool PosaljiEmail(string toEmail, string subject, string body)
        {
            string smtpServer = "smtp.sendgrid.net";
            int port = 587;
            string username = "apikey";
            string password = ConfigurationManager.AppSettings["SendGridApiKey"]; // Ako ne bude radilo na obrani onda trebam novoga napraviti jer je mozda obrisan iz sigurnosnih razloga
            string fromEmail = "vukovicluka0101@gmail.com";

            try
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpServer, port))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(username, password);

                    using (MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body))
                    {
                        mail.IsBodyHtml = false;
                        smtpClient.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri slanju e-maila na adresu {toEmail}:\n{ex.Message}", "Greška pri slanju", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void OsvjeziDgvDolazaka()
        {
            if (comboBoxGrupa.SelectedValue != null && comboBoxGrupa.SelectedValue.ToString() != "")
            {
                int groupId = Convert.ToInt32(comboBoxGrupa.SelectedValue);
                DateTime date = dateTimePickerDatum.Value.Date;

                _currentDolazakList = _dolazakService.GetDolazak(groupId, date);
                _currentDjecaList = null;

                dgvEvidencija.DataSource = _currentDolazakList;
                ApplyDataGridViewSettings("dolazak");
            }
            else
            {
                dgvEvidencija.DataSource = null;
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvEvidencija.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Jeste li sigurni da želite obrisati odabrani unos?",
                    "Potvrda brisanja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int dolazakId = Convert.ToInt32(dgvEvidencija.SelectedRows[0].Cells["DolazakId"].Value);

                        _dolazakService.DeleteDolazak(dolazakId);

                        MessageBox.Show("Unos je uspješno obrisan.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        OsvjeziDgvDolazaka();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Greška pri brisanju unosa: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Molimo odaberite unos za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}