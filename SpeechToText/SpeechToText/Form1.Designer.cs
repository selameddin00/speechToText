namespace SpeechToText
{
    partial class Form1
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
            this.btnKayit = new Button();
            this.btnDurdur = new Button();
            this.txtMetin = new TextBox();
            this.lblDurum = new Label();
            this.SuspendLayout();
            // 
            // btnKayit
            // 
            this.btnKayit.BackColor = Color.Green;
            this.btnKayit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnKayit.ForeColor = Color.White;
            this.btnKayit.Location = new Point(50, 30);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new Size(120, 50);
            this.btnKayit.TabIndex = 0;
            this.btnKayit.Text = "Kayıt";
            this.btnKayit.UseVisualStyleBackColor = false;
            this.btnKayit.Click += new EventHandler(this.btnKayit_Click);
            // 
            // btnDurdur
            // 
            this.btnDurdur.BackColor = Color.Red;
            this.btnDurdur.Enabled = false;
            this.btnDurdur.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnDurdur.ForeColor = Color.White;
            this.btnDurdur.Location = new Point(200, 30);
            this.btnDurdur.Name = "btnDurdur";
            this.btnDurdur.Size = new Size(120, 50);
            this.btnDurdur.TabIndex = 1;
            this.btnDurdur.Text = "Durdur";
            this.btnDurdur.UseVisualStyleBackColor = false;
            this.btnDurdur.Click += new EventHandler(this.btnDurdur_Click);
            // 
            // txtMetin
            // 
            this.txtMetin.Font = new Font("Segoe UI", 11F);
            this.txtMetin.Location = new Point(50, 120);
            this.txtMetin.Multiline = true;
            this.txtMetin.Name = "txtMetin";
            this.txtMetin.ReadOnly = true;
            this.txtMetin.ScrollBars = ScrollBars.Vertical;
            this.txtMetin.Size = new Size(700, 300);
            this.txtMetin.TabIndex = 2;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new Font("Segoe UI", 10F);
            this.lblDurum.Location = new Point(50, 90);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new Size(100, 19);
            this.lblDurum.TabIndex = 3;
            this.lblDurum.Text = "Hazır";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.txtMetin);
            this.Controls.Add(this.btnDurdur);
            this.Controls.Add(this.btnKayit);
            this.Name = "Form1";
            this.Text = "Speech to Text Uygulaması";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button btnKayit;
        private Button btnDurdur;
        private TextBox txtMetin;
        private Label lblDurum;
    }
}
