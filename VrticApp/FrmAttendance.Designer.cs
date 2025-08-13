using System;
using System.Windows.Forms;

namespace VrticApp
{
    partial class FrmAttendance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvEvidencija = new System.Windows.Forms.DataGridView();
            this.comboBoxGrupa = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnPrikaziEvidenciju = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePickerDatum = new System.Windows.Forms.DateTimePicker();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnGenerirajMjesecniIzvjestaj = new System.Windows.Forms.Button();
            this.btnSpremiEvidenciju = new System.Windows.Forms.Button();
            this.lblPrijavljen = new System.Windows.Forms.Label();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.btnSpremiNoviDolazak = new System.Windows.Forms.Button();
            this.txtDijeteId = new System.Windows.Forms.TextBox();
            this.txtDolazakId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpOdlazak = new System.Windows.Forms.DateTimePicker();
            this.dtpDolazak = new System.Windows.Forms.DateTimePicker();
            this.cmbGrupa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidencija)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEvidencija
            // 
            this.dgvEvidencija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvidencija.Location = new System.Drawing.Point(35, 170);
            this.dgvEvidencija.Name = "dgvEvidencija";
            this.dgvEvidencija.Size = new System.Drawing.Size(742, 195);
            this.dgvEvidencija.TabIndex = 26;
            // 
            // comboBoxGrupa
            // 
            this.comboBoxGrupa.FormattingEnabled = true;
            this.comboBoxGrupa.Location = new System.Drawing.Point(179, 78);
            this.comboBoxGrupa.Name = "comboBoxGrupa";
            this.comboBoxGrupa.Size = new System.Drawing.Size(175, 21);
            this.comboBoxGrupa.TabIndex = 25;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(112, 81);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(47, 16);
            this.lblGroup.TabIndex = 24;
            this.lblGroup.Text = "Grupa:";
            // 
            // btnPrikaziEvidenciju
            // 
            this.btnPrikaziEvidenciju.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPrikaziEvidenciju.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikaziEvidenciju.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPrikaziEvidenciju.Location = new System.Drawing.Point(291, 123);
            this.btnPrikaziEvidenciju.Name = "btnPrikaziEvidenciju";
            this.btnPrikaziEvidenciju.Size = new System.Drawing.Size(159, 31);
            this.btnPrikaziEvidenciju.TabIndex = 23;
            this.btnPrikaziEvidenciju.Text = "Prikaži evidenciju";
            this.btnPrikaziEvidenciju.UseVisualStyleBackColor = false;
            this.btnPrikaziEvidenciju.Click += new System.EventHandler(this.btnPrikaziEvidenciju_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(426, 81);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 16);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "Datum:";
            // 
            // dateTimePickerDatum
            // 
            this.dateTimePickerDatum.Location = new System.Drawing.Point(490, 81);
            this.dateTimePickerDatum.Name = "dateTimePickerDatum";
            this.dateTimePickerDatum.Size = new System.Drawing.Size(187, 20);
            this.dateTimePickerDatum.TabIndex = 21;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(194, 9);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(432, 25);
            this.lblCaption.TabIndex = 20;
            this.lblCaption.Text = "Praćenje dolazaka i odlazaka djece iz vrtića";
            // 
            // btnGenerirajMjesecniIzvjestaj
            // 
            this.btnGenerirajMjesecniIzvjestaj.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGenerirajMjesecniIzvjestaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerirajMjesecniIzvjestaj.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerirajMjesecniIzvjestaj.Location = new System.Drawing.Point(476, 123);
            this.btnGenerirajMjesecniIzvjestaj.Name = "btnGenerirajMjesecniIzvjestaj";
            this.btnGenerirajMjesecniIzvjestaj.Size = new System.Drawing.Size(215, 31);
            this.btnGenerirajMjesecniIzvjestaj.TabIndex = 29;
            this.btnGenerirajMjesecniIzvjestaj.Text = "Generiraj mjesečni izvještaj";
            this.btnGenerirajMjesecniIzvjestaj.UseVisualStyleBackColor = false;
            this.btnGenerirajMjesecniIzvjestaj.Click += new System.EventHandler(this.btnGenerirajMjesecniIzvjestaj_Click);
            // 
            // btnSpremiEvidenciju
            // 
            this.btnSpremiEvidenciju.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSpremiEvidenciju.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpremiEvidenciju.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSpremiEvidenciju.Location = new System.Drawing.Point(115, 123);
            this.btnSpremiEvidenciju.Name = "btnSpremiEvidenciju";
            this.btnSpremiEvidenciju.Size = new System.Drawing.Size(159, 31);
            this.btnSpremiEvidenciju.TabIndex = 27;
            this.btnSpremiEvidenciju.Text = "Spremi evidenciju";
            this.btnSpremiEvidenciju.UseVisualStyleBackColor = false;
            this.btnSpremiEvidenciju.Click += new System.EventHandler(this.btnSpremiEvidenciju_Click);
            // 
            // lblPrijavljen
            // 
            this.lblPrijavljen.AutoSize = true;
            this.lblPrijavljen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrijavljen.Location = new System.Drawing.Point(12, 9);
            this.lblPrijavljen.Name = "lblPrijavljen";
            this.lblPrijavljen.Size = new System.Drawing.Size(0, 13);
            this.lblPrijavljen.TabIndex = 30;
            // 
            // btnPovratak
            // 
            this.btnPovratak.BackColor = System.Drawing.Color.Red;
            this.btnPovratak.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPovratak.Location = new System.Drawing.Point(656, 12);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(142, 31);
            this.btnPovratak.TabIndex = 31;
            this.btnPovratak.Text = "Povratak na glavni meni";
            this.btnPovratak.UseVisualStyleBackColor = false;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // btnSpremiNoviDolazak
            // 
            this.btnSpremiNoviDolazak.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSpremiNoviDolazak.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpremiNoviDolazak.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSpremiNoviDolazak.Location = new System.Drawing.Point(361, 573);
            this.btnSpremiNoviDolazak.Name = "btnSpremiNoviDolazak";
            this.btnSpremiNoviDolazak.Size = new System.Drawing.Size(164, 30);
            this.btnSpremiNoviDolazak.TabIndex = 63;
            this.btnSpremiNoviDolazak.Text = "Spremi novi dolazak";
            this.btnSpremiNoviDolazak.UseVisualStyleBackColor = false;
            this.btnSpremiNoviDolazak.Click += new System.EventHandler(this.btnSpremiNoviDolazak_Click);
            // 
            // txtDijeteId
            // 
            this.txtDijeteId.Location = new System.Drawing.Point(560, 484);
            this.txtDijeteId.Name = "txtDijeteId";
            this.txtDijeteId.Size = new System.Drawing.Size(146, 20);
            this.txtDijeteId.TabIndex = 62;
            // 
            // txtDolazakId
            // 
            this.txtDolazakId.Location = new System.Drawing.Point(291, 484);
            this.txtDolazakId.Name = "txtDolazakId";
            this.txtDolazakId.Size = new System.Drawing.Size(124, 20);
            this.txtDolazakId.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 485);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Dijete Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 25);
            this.label1.TabIndex = 59;
            this.label1.Text = "Dodavanje novog dolaska";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Dolazak Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Vrijeme odlaska:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(177, 533);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 56;
            this.label5.Text = "Vrijeme dolaska:";
            // 
            // dtpDatum
            // 
            this.dtpDatum.Location = new System.Drawing.Point(560, 440);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(146, 20);
            this.dtpDatum.TabIndex = 55;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(446, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 54;
            this.label6.Text = "Datum:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 53;
            this.label7.Text = "Grupa:";
            // 
            // dtpOdlazak
            // 
            this.dtpOdlazak.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpOdlazak.Location = new System.Drawing.Point(560, 534);
            this.dtpOdlazak.Name = "dtpOdlazak";
            this.dtpOdlazak.Size = new System.Drawing.Size(146, 20);
            this.dtpOdlazak.TabIndex = 52;
            // 
            // dtpDolazak
            // 
            this.dtpDolazak.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDolazak.Location = new System.Drawing.Point(291, 533);
            this.dtpDolazak.Name = "dtpDolazak";
            this.dtpDolazak.Size = new System.Drawing.Size(124, 20);
            this.dtpDolazak.TabIndex = 51;
            // 
            // cmbGrupa
            // 
            this.cmbGrupa.FormattingEnabled = true;
            this.cmbGrupa.Location = new System.Drawing.Point(291, 439);
            this.cmbGrupa.Name = "cmbGrupa";
            this.cmbGrupa.Size = new System.Drawing.Size(124, 21);
            this.cmbGrupa.TabIndex = 50;
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 657);
            this.Controls.Add(this.btnSpremiNoviDolazak);
            this.Controls.Add(this.txtDijeteId);
            this.Controls.Add(this.txtDolazakId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDatum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpOdlazak);
            this.Controls.Add(this.dtpDolazak);
            this.Controls.Add(this.cmbGrupa);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.lblPrijavljen);
            this.Controls.Add(this.dgvEvidencija);
            this.Controls.Add(this.comboBoxGrupa);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.btnPrikaziEvidenciju);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnGenerirajMjesecniIzvjestaj);
            this.Controls.Add(this.btnSpremiEvidenciju);
            this.Name = "FrmAttendance";
            this.Text = "FrmAttendance";
            this.Load += new System.EventHandler(this.FrmAttendance_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidencija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvEvidencija_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvidencija;
        private System.Windows.Forms.ComboBox comboBoxGrupa;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button btnPrikaziEvidenciju;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatum;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnGenerirajMjesecniIzvjestaj;
        private System.Windows.Forms.Button btnSpremiEvidenciju;
        private Label lblPrijavljen;
        private Button btnPovratak;
        private Button btnSpremiNoviDolazak;
        private TextBox txtDijeteId;
        private TextBox txtDolazakId;
        private Label label4;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label5;
        private DateTimePicker dtpDatum;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpOdlazak;
        private DateTimePicker dtpDolazak;
        private ComboBox cmbGrupa;
    }
}