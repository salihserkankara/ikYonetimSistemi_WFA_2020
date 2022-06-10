namespace IKYonetimSistemi
{
    partial class ElemanArama
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
            this.adAra = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deneyimNm = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ehliyetCmb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.yazdirBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lisansUstuChck = new System.Windows.Forms.CheckBox();
            this.ingilizceChck = new System.Windows.Forms.CheckBox();
            this.dilSayisiChck = new System.Windows.Forms.CheckBox();
            this.deneyimsizChck = new System.Windows.Forms.CheckBox();
            this.yasSinirNm = new System.Windows.Forms.NumericUpDown();
            this.toplamB = new System.Windows.Forms.Label();
            this.derinlik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deneyimNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yasSinirNm)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 49);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(940, 577);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // adAra
            // 
            this.adAra.Location = new System.Drawing.Point(312, 23);
            this.adAra.Name = "adAra";
            this.adAra.Size = new System.Drawing.Size(859, 20);
            this.adAra.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Minimum Deneyim Süresi :";
            // 
            // deneyimNm
            // 
            this.deneyimNm.Location = new System.Drawing.Point(167, 262);
            this.deneyimNm.Name = "deneyimNm";
            this.deneyimNm.Size = new System.Drawing.Size(120, 20);
            this.deneyimNm.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Maksimum Yaş :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ehliyet :";
            // 
            // ehliyetCmb
            // 
            this.ehliyetCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ehliyetCmb.FormattingEnabled = true;
            this.ehliyetCmb.Items.AddRange(new object[] {
            "Şart Değil",
            "M",
            "A1",
            "A2",
            "A",
            "B1",
            "BE",
            "C1",
            "C1E",
            "C",
            "CE",
            "D1",
            "D1E",
            "D",
            "DE",
            "F",
            "G"});
            this.ehliyetCmb.Location = new System.Drawing.Point(166, 324);
            this.ehliyetCmb.Name = "ehliyetCmb";
            this.ehliyetCmb.Size = new System.Drawing.Size(121, 21);
            this.ehliyetCmb.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Filtre Uygula";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yazdirBtn
            // 
            this.yazdirBtn.Location = new System.Drawing.Point(1125, 646);
            this.yazdirBtn.Name = "yazdirBtn";
            this.yazdirBtn.Size = new System.Drawing.Size(127, 23);
            this.yazdirBtn.TabIndex = 18;
            this.yazdirBtn.Text = "Yazdır/Dosyaya Kaydet";
            this.yazdirBtn.UseVisualStyleBackColor = true;
            this.yazdirBtn.Click += new System.EventHandler(this.yazdirBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1177, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Ara";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lisansUstuChck
            // 
            this.lisansUstuChck.AutoSize = true;
            this.lisansUstuChck.Location = new System.Drawing.Point(98, 166);
            this.lisansUstuChck.Name = "lisansUstuChck";
            this.lisansUstuChck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lisansUstuChck.Size = new System.Drawing.Size(189, 17);
            this.lisansUstuChck.TabIndex = 20;
            this.lisansUstuChck.Text = "Sadece Lisans ve Üstü Başvurular";
            this.lisansUstuChck.UseVisualStyleBackColor = true;
            // 
            // ingilizceChck
            // 
            this.ingilizceChck.AutoSize = true;
            this.ingilizceChck.Location = new System.Drawing.Point(184, 189);
            this.ingilizceChck.Name = "ingilizceChck";
            this.ingilizceChck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ingilizceChck.Size = new System.Drawing.Size(103, 17);
            this.ingilizceChck.TabIndex = 21;
            this.ingilizceChck.Text = "İngilizce Zorunlu";
            this.ingilizceChck.UseVisualStyleBackColor = true;
            // 
            // dilSayisiChck
            // 
            this.dilSayisiChck.AutoSize = true;
            this.dilSayisiChck.Location = new System.Drawing.Point(107, 212);
            this.dilSayisiChck.Name = "dilSayisiChck";
            this.dilSayisiChck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dilSayisiChck.Size = new System.Drawing.Size(180, 17);
            this.dilSayisiChck.TabIndex = 22;
            this.dilSayisiChck.Text = "Birden Fazla Yabancı Dil Zorunlu";
            this.dilSayisiChck.UseVisualStyleBackColor = true;
            // 
            // deneyimsizChck
            // 
            this.deneyimsizChck.AutoSize = true;
            this.deneyimsizChck.Location = new System.Drawing.Point(157, 235);
            this.deneyimsizChck.Name = "deneyimsizChck";
            this.deneyimsizChck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deneyimsizChck.Size = new System.Drawing.Size(130, 17);
            this.deneyimsizChck.TabIndex = 23;
            this.deneyimsizChck.Text = "Sadece Deneyimsizler";
            this.deneyimsizChck.UseVisualStyleBackColor = true;
            this.deneyimsizChck.CheckedChanged += new System.EventHandler(this.deneyimsizChck_CheckedChanged);
            // 
            // yasSinirNm
            // 
            this.yasSinirNm.Location = new System.Drawing.Point(167, 293);
            this.yasSinirNm.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.yasSinirNm.Name = "yasSinirNm";
            this.yasSinirNm.Size = new System.Drawing.Size(120, 20);
            this.yasSinirNm.TabIndex = 24;
            this.yasSinirNm.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // toplamB
            // 
            this.toplamB.AutoSize = true;
            this.toplamB.Location = new System.Drawing.Point(12, 613);
            this.toplamB.Name = "toplamB";
            this.toplamB.Size = new System.Drawing.Size(132, 13);
            this.toplamB.TabIndex = 25;
            this.toplamB.Text = "Toplam Başvuru Sayısı :  0";
            // 
            // derinlik
            // 
            this.derinlik.AutoSize = true;
            this.derinlik.Location = new System.Drawing.Point(12, 646);
            this.derinlik.Name = "derinlik";
            this.derinlik.Size = new System.Drawing.Size(54, 13);
            this.derinlik.TabIndex = 26;
            this.derinlik.Text = "Derinlik: 0";
            // 
            // ElemanArama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.derinlik);
            this.Controls.Add(this.toplamB);
            this.Controls.Add(this.yasSinirNm);
            this.Controls.Add(this.deneyimsizChck);
            this.Controls.Add(this.dilSayisiChck);
            this.Controls.Add(this.ingilizceChck);
            this.Controls.Add(this.lisansUstuChck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.yazdirBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ehliyetCmb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deneyimNm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.adAra);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ElemanArama";
            this.Text = "ElemanArama";
            this.Load += new System.EventHandler(this.ElemanArama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deneyimNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yasSinirNm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox adAra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown deneyimNm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ehliyetCmb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button yazdirBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox lisansUstuChck;
        private System.Windows.Forms.CheckBox ingilizceChck;
        private System.Windows.Forms.CheckBox dilSayisiChck;
        private System.Windows.Forms.CheckBox deneyimsizChck;
        private System.Windows.Forms.NumericUpDown yasSinirNm;
        private System.Windows.Forms.Label toplamB;
        private System.Windows.Forms.Label derinlik;
    }
}