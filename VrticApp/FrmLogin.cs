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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtBoxUsername.Text == "" || txtBoxPassword.Text == "")
            {
                MessageBox.Show("Niste unijeli podatke!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtBoxUsername.Text == "admin" && txtBoxPassword.Text == "password")
            {
                MessageBox.Show("Uspješno ste se prijavili!", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmAttendance frmAttendance = new FrmAttendance();
                this.Hide();
                frmAttendance.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Pogrešan unos!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }
    }
}
