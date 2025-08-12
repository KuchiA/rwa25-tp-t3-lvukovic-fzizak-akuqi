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
            this.btnIspraziPolja = new System.Windows.Forms.Button();
            this.btnSpremiEvidenciju = new System.Windows.Forms.Button();
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
            this.btnPrikaziEvidenciju.Location = new System.Drawing.Point(476, 119);
            this.btnPrikaziEvidenciju.Name = "btnPrikaziEvidenciju";
            this.btnPrikaziEvidenciju.Size = new System.Drawing.Size(213, 34);
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
            this.lblCaption.Location = new System.Drawing.Point(183, 26);
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
            this.btnGenerirajMjesecniIzvjestaj.Location = new System.Drawing.Point(490, 392);
            this.btnGenerirajMjesecniIzvjestaj.Name = "btnGenerirajMjesecniIzvjestaj";
            this.btnGenerirajMjesecniIzvjestaj.Size = new System.Drawing.Size(199, 32);
            this.btnGenerirajMjesecniIzvjestaj.TabIndex = 29;
            this.btnGenerirajMjesecniIzvjestaj.Text = "Generiraj mjesečni izvještaj";
            this.btnGenerirajMjesecniIzvjestaj.UseVisualStyleBackColor = false;
            this.btnGenerirajMjesecniIzvjestaj.Click += new System.EventHandler(this.btnGenerirajMjesecniIzvjestaj_Click);
            // 
            // btnIspraziPolja
            // 
            this.btnIspraziPolja.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnIspraziPolja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIspraziPolja.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnIspraziPolja.Location = new System.Drawing.Point(310, 392);
            this.btnIspraziPolja.Name = "btnIspraziPolja";
            this.btnIspraziPolja.Size = new System.Drawing.Size(150, 32);
            this.btnIspraziPolja.TabIndex = 28;
            this.btnIspraziPolja.Text = "Isprazni polja";
            this.btnIspraziPolja.UseVisualStyleBackColor = false;
            this.btnIspraziPolja.Click += new System.EventHandler(this.btnIspraziPolja_Click);
            // 
            // btnSpremiEvidenciju
            // 
            this.btnSpremiEvidenciju.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSpremiEvidenciju.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpremiEvidenciju.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSpremiEvidenciju.Location = new System.Drawing.Point(115, 393);
            this.btnSpremiEvidenciju.Name = "btnSpremiEvidenciju";
            this.btnSpremiEvidenciju.Size = new System.Drawing.Size(142, 31);
            this.btnSpremiEvidenciju.TabIndex = 27;
            this.btnSpremiEvidenciju.Text = "Spremi evidenciju";
            this.btnSpremiEvidenciju.UseVisualStyleBackColor = false;
            this.btnSpremiEvidenciju.Click += new System.EventHandler(this.btnSpremiEvidenciju_Click);
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEvidencija);
            this.Controls.Add(this.comboBoxGrupa);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.btnPrikaziEvidenciju);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimePickerDatum);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnGenerirajMjesecniIzvjestaj);
            this.Controls.Add(this.btnIspraziPolja);
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
        private System.Windows.Forms.Button btnIspraziPolja;
        private System.Windows.Forms.Button btnSpremiEvidenciju;
    }
}