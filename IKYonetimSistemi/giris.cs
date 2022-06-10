using IKYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKYonetimSistemi
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            string path = @"prpw.ssmc";
            string fileText = "";
            if (File.Exists(path))
            {
                fileText = File.ReadAllText(path);
                if (fileText.Trim().Length > 0)
                {
                    fileText = Security.Decrypt(fileText);
                }
            }
            if(fileText.Contains("mcss" + mailText.Text.Trim() + "??" + sifreText.Text.Trim() + "ssmc"))
            {
                this.Close();
                BasvuruGuncelle form = new BasvuruGuncelle { Mail = mailText.Text.Trim() };
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("E-Posta veya Şifre Yanlış \nLütfen Bilgileriniz Kontrol Ediniz");
            }
            
        }
    }
}
