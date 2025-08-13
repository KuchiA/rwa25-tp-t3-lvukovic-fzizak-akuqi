namespace VrticApp
{
    partial class frmNoviDolazak
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
            this.cmbDijete = new System.Windows.Forms.ComboBox();
            this.dtpVrijemeDolaska = new System.Windows.Forms.DateTimePicker();
            this.dtpVrijemeOdlaska = new System.Windows.Forms.DateTimePicker();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbDijete
            // 
            this.cmbDijete.FormattingEnabled = true;
            this.cmbDijete.Location = new System.Drawing.Point(116, 12);
            this.cmbDijete.Name = "cmbDijete";
            this.cmbDijete.Size = new System.Drawing.Size(121, 21);
            this.cmbDijete.TabIndex = 0;
            // 
            // dtpVrijemeDolaska
            // 
            this.dtpVrijemeDolaska.Location = new System.Drawing.Point(116, 53);
            this.dtpVrijemeDolaska.Name = "dtpVrijemeDolaska";
            this.dtpVrijemeDolaska.Size = new System.Drawing.Size(200, 20);
            this.dtpVrijemeDolaska.TabIndex = 1;
            // 
            // dtpVrijemeOdlaska
            // 
            this.dtpVrijemeOdlaska.Location = new System.Drawing.Point(116, 92);
            this.dtpVrijemeOdlaska.Name = "dtpVrijemeOdlaska";
            this.dtpVrijemeOdlaska.Size = new System.Drawing.Size(200, 20);
            this.dtpVrijemeOdlaska.TabIndex = 2;
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(116, 140);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 3;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            // 
            // frmNoviDolazak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 222);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.dtpVrijemeOdlaska);
            this.Controls.Add(this.dtpVrijemeDolaska);
            this.Controls.Add(this.cmbDijete);
            this.Name = "frmNoviDolazak";
            this.Text = "frmNoviDolazak";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDijete;
        private System.Windows.Forms.DateTimePicker dtpVrijemeDolaska;
        private System.Windows.Forms.DateTimePicker dtpVrijemeOdlaska;
        private System.Windows.Forms.Button btnSpremi;
    }
}