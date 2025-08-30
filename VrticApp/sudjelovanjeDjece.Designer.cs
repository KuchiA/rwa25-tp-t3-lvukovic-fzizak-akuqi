using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RWA
{
    partial class sudjelovanjeDjece
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
            this.gridSudjelovanje = new System.Windows.Forms.DataGridView();
            this.Linija = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnStaro = new System.Windows.Forms.Button();
            this.btnGrupa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridSudjelovanje)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.MaximumSize = new System.Drawing.Size(350, 35);
            this.label1.MinimumSize = new System.Drawing.Size(350, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sudjelovanje u Aktivnostima";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridSudjelovanje
            // 
            this.gridSudjelovanje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSudjelovanje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridSudjelovanje.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSudjelovanje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSudjelovanje.Location = new System.Drawing.Point(37, 202);
            this.gridSudjelovanje.Name = "gridSudjelovanje";
            this.gridSudjelovanje.Size = new System.Drawing.Size(740, 352);
            this.gridSudjelovanje.TabIndex = 3;
            // 
            // Linija
            // 
            this.Linija.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Linija.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Linija.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Linija.Location = new System.Drawing.Point(-11, 84);
            this.Linija.MaximumSize = new System.Drawing.Size(0, 10);
            this.Linija.MinimumSize = new System.Drawing.Size(839, 10);
            this.Linija.Name = "Linija";
            this.Linija.Size = new System.Drawing.Size(839, 10);
            this.Linija.TabIndex = 8;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnNovo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNovo.Location = new System.Drawing.Point(37, 160);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(152, 34);
            this.btnNovo.TabIndex = 9;
            this.btnNovo.Text = "Sortiraj: Novije";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnStaro
            // 
            this.btnStaro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaro.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStaro.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStaro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStaro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnStaro.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStaro.Location = new System.Drawing.Point(625, 160);
            this.btnStaro.Name = "btnStaro";
            this.btnStaro.Size = new System.Drawing.Size(152, 34);
            this.btnStaro.TabIndex = 10;
            this.btnStaro.Text = "Sortiraj: Starije";
            this.btnStaro.UseVisualStyleBackColor = false;
            this.btnStaro.Click += new System.EventHandler(this.btnStaro_Click);
            // 
            // btnGrupa
            // 
            this.btnGrupa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGrupa.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGrupa.FlatAppearance.BorderSize = 0;
            this.btnGrupa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrupa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnGrupa.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGrupa.Location = new System.Drawing.Point(326, 160);
            this.btnGrupa.Name = "btnGrupa";
            this.btnGrupa.Size = new System.Drawing.Size(152, 34);
            this.btnGrupa.TabIndex = 11;
            this.btnGrupa.Text = "Sortiraj: Mlađi - Starije";
            this.btnGrupa.UseVisualStyleBackColor = false;
            this.btnGrupa.Click += new System.EventHandler(this.btnGrupa_Click);
            // 
            // sudjelovanjeDjece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(823, 599);
            this.Controls.Add(this.btnGrupa);
            this.Controls.Add(this.btnStaro);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.Linija);
            this.Controls.Add(this.gridSudjelovanje);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(839, 445);
            this.Name = "sudjelovanjeDjece";
            this.Text = "Sudjelovanje u Aktivnostima";
            ((System.ComponentModel.ISupportInitialize)(this.gridSudjelovanje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView gridSudjelovanje;
        private TextBox Linija;
        private Button btnNovo;
        private Button btnStaro;
        private Button btnGrupa;
    }
}
