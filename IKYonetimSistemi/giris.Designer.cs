namespace IKYonetimSistemi
{
    partial class giris
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
            this.mailText = new System.Windows.Forms.TextBox();
            this.sifreText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.girisBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mailText
            // 
            this.mailText.Location = new System.Drawing.Point(103, 12);
            this.mailText.Name = "mailText";
            this.mailText.Size = new System.Drawing.Size(244, 20);
            this.mailText.TabIndex = 0;
            // 
            // sifreText
            // 
            this.sifreText.Location = new System.Drawing.Point(103, 52);
            this.sifreText.Name = "sifreText";
            this.sifreText.PasswordChar = '*';
            this.sifreText.Size = new System.Drawing.Size(244, 20);
            this.sifreText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "E-Posta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre";
            // 
            // girisBtn
            // 
            this.girisBtn.Location = new System.Drawing.Point(171, 106);
            this.girisBtn.Name = "girisBtn";
            this.girisBtn.Size = new System.Drawing.Size(100, 23);
            this.girisBtn.TabIndex = 4;
            this.girisBtn.Text = "Giriş";
            this.girisBtn.UseVisualStyleBackColor = true;
            this.girisBtn.Click += new System.EventHandler(this.girisBtn_Click);
            // 
            // giris
            // 
            this.AcceptButton = this.girisBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 141);
            this.Controls.Add(this.girisBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifreText);
            this.Controls.Add(this.mailText);
            this.Name = "giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mailText;
        private System.Windows.Forms.TextBox sifreText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button girisBtn;
    }
}