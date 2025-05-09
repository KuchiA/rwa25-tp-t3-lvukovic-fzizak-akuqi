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
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            button4 = new Button();
            opisAktivnostiTXTBox = new TextBox();
            button5 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            button6 = new Button();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            button7 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 18F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(43, 31);
            label1.MaximumSize = new Size(100, 40);
            label1.MinimumSize = new Size(200, 40);
            label1.Name = "label1";
            label1.Size = new Size(200, 40);
            label1.TabIndex = 0;
            label1.Text = "Planer Aktivnosti";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkCyan;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(-106, 100);
            textBox1.MaximumSize = new Size(2000, 70);
            textBox1.MinimumSize = new Size(2000, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(2000, 70);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(782, 31);
            label2.MaximumSize = new Size(200, 40);
            label2.MinimumSize = new Size(200, 40);
            label2.Name = "label2";
            label2.Size = new Size(200, 40);
            label2.TabIndex = 2;
            label2.Text = "Ardijan Kuqi";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(43, 121);
            button1.MaximumSize = new Size(120, 30);
            button1.MinimumSize = new Size(120, 30);
            button1.Name = "button1";
            button1.Size = new Size(120, 30);
            button1.TabIndex = 3;
            button1.Text = "Dodaj Aktivnost";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkCyan;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(169, 121);
            button2.MaximumSize = new Size(120, 30);
            button2.MinimumSize = new Size(120, 30);
            button2.Name = "button2";
            button2.Size = new Size(120, 30);
            button2.TabIndex = 4;
            button2.Text = "Raspored";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(224, 224, 224);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 10F);
            button3.Location = new Point(43, 212);
            button3.MaximumSize = new Size(120, 30);
            button3.MinimumSize = new Size(120, 30);
            button3.Name = "button3";
            button3.Size = new Size(120, 30);
            button3.TabIndex = 5;
            button3.Text = "Ime Aktivnosti";
            button3.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(43, 248);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(278, 23);
            textBox2.TabIndex = 6;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(224, 224, 224);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F);
            button4.Location = new Point(434, 212);
            button4.MaximumSize = new Size(160, 30);
            button4.MinimumSize = new Size(160, 30);
            button4.Name = "button4";
            button4.Size = new Size(160, 30);
            button4.TabIndex = 7;
            button4.Text = "Opis Aktivnosti";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            // 
            // opisAktivnostiTXTBox
            // 
            opisAktivnostiTXTBox.Location = new Point(434, 248);
            opisAktivnostiTXTBox.MaximumSize = new Size(278, 200);
            opisAktivnostiTXTBox.MinimumSize = new Size(300, 200);
            opisAktivnostiTXTBox.Name = "opisAktivnostiTXTBox";
            opisAktivnostiTXTBox.Size = new Size(300, 200);
            opisAktivnostiTXTBox.TabIndex = 8;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(224, 224, 224);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F);
            button5.Location = new Point(43, 294);
            button5.MaximumSize = new Size(120, 30);
            button5.MinimumSize = new Size(120, 30);
            button5.Name = "button5";
            button5.Size = new Size(120, 30);
            button5.TabIndex = 9;
            button5.Text = "Grupe";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(95, 330);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(58, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Nema";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(43, 330);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(46, 19);
            checkBox2.TabIndex = 11;
            checkBox2.Text = "Ima";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(224, 224, 224);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 10F);
            button6.Location = new Point(43, 372);
            button6.MaximumSize = new Size(120, 30);
            button6.MinimumSize = new Size(120, 30);
            button6.Name = "button6";
            button6.Size = new Size(120, 30);
            button6.TabIndex = 12;
            button6.Text = "Broj Grupa";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(43, 408);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(32, 19);
            checkBox3.TabIndex = 13;
            checkBox3.Text = "1";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(81, 433);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(32, 19);
            checkBox4.TabIndex = 14;
            checkBox4.Text = "5";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(43, 433);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(32, 19);
            checkBox5.TabIndex = 15;
            checkBox5.Text = "4";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(119, 408);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(32, 19);
            checkBox6.TabIndex = 16;
            checkBox6.Text = "3";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(81, 408);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(32, 19);
            checkBox7.TabIndex = 17;
            checkBox7.Text = "2";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(119, 433);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(32, 19);
            checkBox8.TabIndex = 18;
            checkBox8.Text = "6";
            checkBox8.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Location = new Point(43, 471);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 23);
            dateTimePicker1.TabIndex = 19;
            // 
            // button7
            // 
            button7.Location = new Point(805, 572);
            button7.MaximumSize = new Size(150, 30);
            button7.MinimumSize = new Size(150, 30);
            button7.Name = "button7";
            button7.Size = new Size(150, 30);
            button7.TabIndex = 20;
            button7.Text = "Dodaj Aktivnost";
            button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(967, 614);
            Controls.Add(button7);
            Controls.Add(dateTimePicker1);
            Controls.Add(checkBox8);
            Controls.Add(checkBox7);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(button6);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button5);
            Controls.Add(opisAktivnostiTXTBox);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Planer Aktivnosti";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox2;
        private Button button4;
        private TextBox opisAktivnostiTXTBox;
        private Button button5;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button button6;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private DateTimePicker dateTimePicker1;
        private Button button7;
    }
}
