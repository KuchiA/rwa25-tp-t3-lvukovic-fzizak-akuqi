using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RWA
{
    partial class planerAktivnosti
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Linija = new System.Windows.Forms.TextBox();
            this.rasporedPregled = new System.Windows.Forms.Button();
            this.OpisTXT = new System.Windows.Forms.TextBox();
            this.datumAktivnosti = new System.Windows.Forms.DateTimePicker();
            this.DodajBTN = new System.Windows.Forms.Button();
            this.labelAktivnost = new System.Windows.Forms.Label();
            this.imeAktivnosti = new System.Windows.Forms.TextBox();
            this.labelGrupa = new System.Windows.Forms.Label();
            this.labelOpis = new System.Windows.Forms.Label();
            this.cmbGrupa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.otvoriPregled = new System.Windows.Forms.Button();
            this.naslovnaButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gridDjeca = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDjeca)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.MaximumSize = new System.Drawing.Size(201, 35);
            this.label1.MinimumSize = new System.Drawing.Size(201, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Planer Aktivnosti";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Linija
            // 
            this.Linija.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Linija.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Linija.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Linija.Location = new System.Drawing.Point(-7, 87);
            this.Linija.MaximumSize = new System.Drawing.Size(873, 10);
            this.Linija.MinimumSize = new System.Drawing.Size(873, 10);
            this.Linija.Name = "Linija";
            this.Linija.Size = new System.Drawing.Size(873, 13);
            this.Linija.TabIndex = 1;
            // 
            // rasporedPregled
            // 
            this.rasporedPregled.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.rasporedPregled.FlatAppearance.BorderSize = 0;
            this.rasporedPregled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rasporedPregled.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rasporedPregled.ForeColor = System.Drawing.SystemColors.Control;
            this.rasporedPregled.Location = new System.Drawing.Point(38, 106);
            this.rasporedPregled.MaximumSize = new System.Drawing.Size(150, 30);
            this.rasporedPregled.MinimumSize = new System.Drawing.Size(150, 30);
            this.rasporedPregled.Name = "rasporedPregled";
            this.rasporedPregled.Size = new System.Drawing.Size(150, 30);
            this.rasporedPregled.TabIndex = 4;
            this.rasporedPregled.Text = "Raspored";
            this.rasporedPregled.UseVisualStyleBackColor = false;
            this.rasporedPregled.Click += new System.EventHandler(this.PregledRaspored);
            // 
            // OpisTXT
            // 
            this.OpisTXT.Location = new System.Drawing.Point(469, 215);
            this.OpisTXT.Multiline = true;
            this.OpisTXT.Name = "OpisTXT";
            this.OpisTXT.ShortcutsEnabled = false;
            this.OpisTXT.Size = new System.Drawing.Size(350, 150);
            this.OpisTXT.TabIndex = 8;
            // 
            // datumAktivnosti
            // 
            this.datumAktivnosti.CustomFormat = "dd.MM.yyyy";
            this.datumAktivnosti.Location = new System.Drawing.Point(469, 415);
            this.datumAktivnosti.Name = "datumAktivnosti";
            this.datumAktivnosti.Size = new System.Drawing.Size(350, 20);
            this.datumAktivnosti.TabIndex = 19;
            // 
            // DodajBTN
            // 
            this.DodajBTN.Location = new System.Drawing.Point(690, 496);
            this.DodajBTN.MaximumSize = new System.Drawing.Size(129, 26);
            this.DodajBTN.MinimumSize = new System.Drawing.Size(129, 26);
            this.DodajBTN.Name = "DodajBTN";
            this.DodajBTN.Size = new System.Drawing.Size(129, 26);
            this.DodajBTN.TabIndex = 20;
            this.DodajBTN.Text = "Dodaj Aktivnost";
            this.DodajBTN.UseVisualStyleBackColor = true;
            this.DodajBTN.Click += new System.EventHandler(this.DodajBTN_Click);
            // 
            // labelAktivnost
            // 
            this.labelAktivnost.AutoSize = true;
            this.labelAktivnost.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelAktivnost.Location = new System.Drawing.Point(33, 191);
            this.labelAktivnost.Name = "labelAktivnost";
            this.labelAktivnost.Size = new System.Drawing.Size(97, 19);
            this.labelAktivnost.TabIndex = 22;
            this.labelAktivnost.Text = "Ime Aktivnosti";
            // 
            // imeAktivnosti
            // 
            this.imeAktivnosti.Location = new System.Drawing.Point(37, 215);
            this.imeAktivnosti.Name = "imeAktivnosti";
            this.imeAktivnosti.Size = new System.Drawing.Size(350, 20);
            this.imeAktivnosti.TabIndex = 23;
            // 
            // labelGrupa
            // 
            this.labelGrupa.AutoSize = true;
            this.labelGrupa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelGrupa.Location = new System.Drawing.Point(33, 249);
            this.labelGrupa.Name = "labelGrupa";
            this.labelGrupa.Size = new System.Drawing.Size(101, 19);
            this.labelGrupa.TabIndex = 24;
            this.labelGrupa.Text = "Odaberi Grupu";
            // 
            // labelOpis
            // 
            this.labelOpis.AutoSize = true;
            this.labelOpis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelOpis.Location = new System.Drawing.Point(465, 191);
            this.labelOpis.Name = "labelOpis";
            this.labelOpis.Size = new System.Drawing.Size(102, 19);
            this.labelOpis.TabIndex = 25;
            this.labelOpis.Text = "Opis Aktivnosti";
            // 
            // cmbGrupa
            // 
            this.cmbGrupa.FormattingEnabled = true;
            this.cmbGrupa.Location = new System.Drawing.Point(37, 271);
            this.cmbGrupa.Name = "cmbGrupa";
            this.cmbGrupa.Size = new System.Drawing.Size(350, 21);
            this.cmbGrupa.TabIndex = 26;
            this.cmbGrupa.SelectedIndexChanged += new System.EventHandler(this.OznaciDjecu);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(465, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Datum Aktivnosti";
            // 
            // otvoriPregled
            // 
            this.otvoriPregled.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.otvoriPregled.FlatAppearance.BorderSize = 0;
            this.otvoriPregled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otvoriPregled.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.otvoriPregled.ForeColor = System.Drawing.SystemColors.Control;
            this.otvoriPregled.Location = new System.Drawing.Point(237, 106);
            this.otvoriPregled.MaximumSize = new System.Drawing.Size(150, 30);
            this.otvoriPregled.MinimumSize = new System.Drawing.Size(150, 30);
            this.otvoriPregled.Name = "otvoriPregled";
            this.otvoriPregled.Size = new System.Drawing.Size(150, 30);
            this.otvoriPregled.TabIndex = 30;
            this.otvoriPregled.Text = "Pregled";
            this.otvoriPregled.UseVisualStyleBackColor = false;
            this.otvoriPregled.Click += new System.EventHandler(this.Pregled);
            // 
            // naslovnaButton
            // 
            this.naslovnaButton.Location = new System.Drawing.Point(37, 496);
            this.naslovnaButton.MaximumSize = new System.Drawing.Size(129, 26);
            this.naslovnaButton.MinimumSize = new System.Drawing.Size(129, 26);
            this.naslovnaButton.Name = "naslovnaButton";
            this.naslovnaButton.Size = new System.Drawing.Size(129, 26);
            this.naslovnaButton.TabIndex = 31;
            this.naslovnaButton.Text = "Naslovna Stranica";
            this.naslovnaButton.UseVisualStyleBackColor = true;
            this.naslovnaButton.Click += new System.EventHandler(this.naslovnaBtn);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(34, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "Odaberi Djecu";
            // 
            // gridDjeca
            // 
            this.gridDjeca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDjeca.Location = new System.Drawing.Point(37, 326);
            this.gridDjeca.Name = "gridDjeca";
            this.gridDjeca.Size = new System.Drawing.Size(350, 109);
            this.gridDjeca.TabIndex = 33;
            // 
            // planerAktivnosti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(857, 547);
            this.Controls.Add(this.gridDjeca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.naslovnaButton);
            this.Controls.Add(this.otvoriPregled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbGrupa);
            this.Controls.Add(this.labelOpis);
            this.Controls.Add(this.labelGrupa);
            this.Controls.Add(this.imeAktivnosti);
            this.Controls.Add(this.labelAktivnost);
            this.Controls.Add(this.DodajBTN);
            this.Controls.Add(this.datumAktivnosti);
            this.Controls.Add(this.OpisTXT);
            this.Controls.Add(this.rasporedPregled);
            this.Controls.Add(this.Linija);
            this.Controls.Add(this.label1);
            this.Name = "planerAktivnosti";
            this.Text = "Planer Aktivnosti";
            this.Load += new System.EventHandler(this.planerAktivnosti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDjeca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox Linija;
        private Button rasporedPregled;
        private TextBox OpisTXT;
        private DateTimePicker datumAktivnosti;
        private Button DodajBTN;
        private Label labelAktivnost;
        private TextBox imeAktivnosti;
        private Label labelGrupa;
        private Label labelOpis;
        private ComboBox cmbGrupa;
        private Label label3;
        private Button otvoriPregled;
        private Button naslovnaButton;
        private Label label2;
        private DataGridView gridDjeca;
    }
}
