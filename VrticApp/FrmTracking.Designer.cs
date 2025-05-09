namespace VrticApp
{
    partial class FrmTracking
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijemeDolaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrijemeOdlaska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImePrezime,
            this.VrijemeDolaska,
            this.VrijemeOdlaska});
            this.dataGridView1.Location = new System.Drawing.Point(152, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(343, 194);
            this.dataGridView1.TabIndex = 16;
            // 
            // ImePrezime
            // 
            this.ImePrezime.HeaderText = "ImePrezime";
            this.ImePrezime.Name = "ImePrezime";
            // 
            // VrijemeDolaska
            // 
            this.VrijemeDolaska.HeaderText = "VrijemeDolaska";
            this.VrijemeDolaska.Name = "VrijemeDolaska";
            // 
            // VrijemeOdlaska
            // 
            this.VrijemeOdlaska.HeaderText = "VrijemeOdlaska";
            this.VrijemeOdlaska.Name = "VrijemeOdlaska";
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(111, 77);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(175, 21);
            this.cbGroup.TabIndex = 15;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.Location = new System.Drawing.Point(44, 80);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(47, 16);
            this.lblGroup.TabIndex = 14;
            this.lblGroup.Text = "Grupa:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(408, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Prikaži evidenciju";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(358, 80);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 16);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Datum:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(422, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Location = new System.Drawing.Point(115, 25);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(432, 25);
            this.lblCaption.TabIndex = 10;
            this.lblCaption.Text = "Praćenje dolazaka i odlazaka djece iz vrtića";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGenerate.Location = new System.Drawing.Point(422, 391);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(199, 32);
            this.btnGenerate.TabIndex = 19;
            this.btnGenerate.Text = "Generiraj mjesečni izvještaj";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDeleteRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRecord.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteRecord.Location = new System.Drawing.Point(242, 391);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(150, 32);
            this.btnDeleteRecord.TabIndex = 18;
            this.btnDeleteRecord.Text = "Isprazni polja";
            this.btnDeleteRecord.UseVisualStyleBackColor = false;
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSaveRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRecord.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveRecord.Location = new System.Drawing.Point(47, 392);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(142, 31);
            this.btnSaveRecord.TabIndex = 17;
            this.btnSaveRecord.Text = "Spremi evidenciju";
            this.btnSaveRecord.UseVisualStyleBackColor = false;
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbGroup);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.btnSaveRecord);
            this.Name = "FrmAttendance";
            this.Text = "FrmAttendance";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijemeDolaska;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrijemeOdlaska;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnDeleteRecord;
        private System.Windows.Forms.Button btnSaveRecord;
    }
}