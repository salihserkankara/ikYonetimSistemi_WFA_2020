namespace IKYonetimSistemi
{
    partial class AcilisEkrani
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
            this.isBasvuruBtn = new System.Windows.Forms.Button();
            this.elemanAramaBtn = new System.Windows.Forms.Button();
            this.girisLbl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // isBasvuruBtn
            // 
            this.isBasvuruBtn.Location = new System.Drawing.Point(35, 45);
            this.isBasvuruBtn.Name = "isBasvuruBtn";
            this.isBasvuruBtn.Size = new System.Drawing.Size(221, 103);
            this.isBasvuruBtn.TabIndex = 0;
            this.isBasvuruBtn.Text = "İş Arama";
            this.isBasvuruBtn.UseVisualStyleBackColor = true;
            this.isBasvuruBtn.Click += new System.EventHandler(this.isBasvuruBtn_Click);
            // 
            // elemanAramaBtn
            // 
            this.elemanAramaBtn.Location = new System.Drawing.Point(359, 45);
            this.elemanAramaBtn.Name = "elemanAramaBtn";
            this.elemanAramaBtn.Size = new System.Drawing.Size(221, 103);
            this.elemanAramaBtn.TabIndex = 1;
            this.elemanAramaBtn.Text = "Eleman Arama";
            this.elemanAramaBtn.UseVisualStyleBackColor = true;
            this.elemanAramaBtn.Click += new System.EventHandler(this.elemanAramaBtn_Click);
            // 
            // girisLbl
            // 
            this.girisLbl.AutoSize = true;
            this.girisLbl.Location = new System.Drawing.Point(228, 215);
            this.girisLbl.Name = "girisLbl";
            this.girisLbl.Size = new System.Drawing.Size(155, 26);
            this.girisLbl.TabIndex = 2;
            this.girisLbl.TabStop = true;
            this.girisLbl.Text = "Başvuru Güncelleme/Silme İçin\r\nGiriş Yap";
            this.girisLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.girisLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.girisLbl_LinkClicked);
            // 
            // AcilisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.girisLbl);
            this.Controls.Add(this.elemanAramaBtn);
            this.Controls.Add(this.isBasvuruBtn);
            this.Name = "AcilisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcilisEkrani";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button isBasvuruBtn;
        private System.Windows.Forms.Button elemanAramaBtn;
        private System.Windows.Forms.LinkLabel girisLbl;
    }
}