using IKYonetimSistemi.BSTOperations;
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
    public partial class IsBasvuru : Form
    {
        public IsBasvuru()
        {
            InitializeComponent();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            isCikarBtn.PerformClick();
            egitimCikarBtn.PerformClick();
        }
        private void kayitEkleBtn_Click(object sender, EventArgs e)
        {
            if (adTxt.Text.Length < 2 || adresTxt.Text.Length < 2 || telTxt.Text.Length < 2 || mailTxt.Text.Length < 2)
            {
                MessageBox.Show("Lütfen tüm alanları iletişim bilgilerinizi eksiksiz doldurunuz.");
                return;
            }
            BSTNode model = new BSTNode();
            model.Data = new NodeModel();
            model.Data.Ad = adTxt.Text.Trim();
            model.Data.Adres = adresTxt.Text.Trim();
            model.Data.Telefon = telTxt.Text.Trim();
            model.Data.Eposta = mailTxt.Text.Trim();
            //Şifre satırı
            model.Data.DogumTarihi = dogumDtp.Value;
            for (int i = 0; i <= dt; i++)
            {
                TextBox txtBox = flowLayoutPanel5.Controls.Find("dilTxt" + i, true).FirstOrDefault() as TextBox;
                if (txtBox.Text.Trim().Length > 0)
                {
                    model.Data.Diller += txtBox.Text.Trim() + ",";
                }
            }
            if (model.Data.Diller != null)
            {
                if (model.Data.Diller.Substring(model.Data.Diller.Length - 1) == ",")
                {
                    model.Data.Diller = model.Data.Diller.Remove(model.Data.Diller.Length - 1);
                }
            }


            for (int i = 0; i <= et; i++)
            {
                TextBox textBox = flowLayoutPanel6.Controls.Find("ehliyetTxt" + i, true).FirstOrDefault() as TextBox;
                if (textBox.Text.Trim().Length > 0)
                {
                    model.Data.Ehliyet += textBox.Text.Trim() + ",";
                }
            }
            if (model.Data.Ehliyet != null)
            {
                if (model.Data.Ehliyet.Substring(model.Data.Ehliyet.Length - 1) == ",")
                {
                    model.Data.Ehliyet = model.Data.Ehliyet.Remove(model.Data.Ehliyet.Length - 1);
                }
            }

            if (ott >= 0)
            {
                CollegeModel collegeModel = new CollegeModel();
                for (int i = 0; i <= ot; i++)
                {
                    TextBox adText = flowLayoutPanel7.Controls.Find("okulTxt" + i, true).FirstOrDefault() as TextBox;
                    TextBox turText = flowLayoutPanel7.Controls.Find("okulTurTxt" + i, true).FirstOrDefault() as TextBox;
                    TextBox bolumText = flowLayoutPanel7.Controls.Find("okulBolumTxt" + i, true).FirstOrDefault() as TextBox;
                    DateTimePicker baslangicText = flowLayoutPanel7.Controls.Find("okulBaslangicDtp" + i, true).FirstOrDefault() as DateTimePicker;
                    DateTimePicker bitisText = flowLayoutPanel7.Controls.Find("okulBitisDtp" + i, true).FirstOrDefault() as DateTimePicker;
                    TextBox notText = flowLayoutPanel7.Controls.Find("okulNotTxt" + i, true).FirstOrDefault() as TextBox;

                    if (adText.Text.Trim().Length < 1 || turText.Text.Trim().Length < 1 || bolumText.Text.Trim().Length < 1 || notText.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Eğitim bilgilerinizi lütfen eksiksiz giriniz");
                        return;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(collegeModel.OkulAdi))
                        {
                            collegeModel.OkulAdi = adText.Text.Trim();
                            collegeModel.BaslangicTarihi = baslangicText.Value;
                            collegeModel.BitisTarihi = bitisText.Value;
                            collegeModel.Bolum = bolumText.Text.Trim();
                            collegeModel.NotOrtalama = Convert.ToInt32(notText.Text.Trim());
                            collegeModel.Tur = turText.Text.Trim();
                        }
                        else
                        {
                            CollegeModel loopModel = new CollegeModel { OkulAdi = adText.Text.Trim(), BaslangicTarihi = baslangicText.Value, BitisTarihi = bitisText.Value, Bolum = bolumText.Text.Trim(), NotOrtalama = Convert.ToInt32(notText.Text.Trim()), Tur = turText.Text.Trim() };
                            CollegeModel circModel = collegeModel;
                            while (circModel.OkulEkle != null)
                            {
                                circModel = circModel.OkulEkle;
                            }

                            circModel.OkulEkle = new CollegeModel(loopModel);
                        }

                    }
                }
                model.Data.Okullar = collegeModel;
            }

            if (it >= 0)
            {
                BusinessModel businessModel = new BusinessModel();
                for (int i = 0; i <= it; i++)
                {
                    TextBox isAdText = flowLayoutPanel8.Controls.Find("isTxt" + i, true).FirstOrDefault() as TextBox;
                    TextBox isAdresText = flowLayoutPanel8.Controls.Find("isAdresTxt" + i, true).FirstOrDefault() as TextBox;
                    TextBox isPozisyonText = flowLayoutPanel8.Controls.Find("isPozisyonTxt" + i, true).FirstOrDefault() as TextBox;
                    TextBox isYilText = flowLayoutPanel8.Controls.Find("isTecrubeTxt" + i, true).FirstOrDefault() as TextBox;

                    if (isAdText.Text.Trim().Length < 1 || isAdresText.Text.Trim().Length < 1 || isPozisyonText.Text.Trim().Length < 1 || isYilText.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Deneyim bilgilerinizi lütfen eksiksiz giriniz");
                        return;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(businessModel.CalistigiYer))
                        {
                            businessModel.CalistigiYer = isAdText.Text.Trim();
                            businessModel.Adres = isAdresText.Text.Trim();
                            businessModel.Pozisyon = isPozisyonText.Text.Trim();
                            businessModel.CalismaSuresi = Convert.ToDouble(isYilText.Text.Trim());

                        }
                        else
                        {
                            BusinessModel loopModel = new BusinessModel { CalistigiYer = isAdText.Text.Trim(), Adres = isAdresText.Text.Trim(), Pozisyon = isPozisyonText.Text.Trim(), CalismaSuresi = Convert.ToDouble(isYilText.Text.Trim()) };
                            BusinessModel circModel = businessModel;
                            while (circModel.IsEkle != null)
                            {
                                circModel = circModel.IsEkle;
                            }

                            circModel.IsEkle = new BusinessModel(loopModel);
                        }

                    }
                }
                model.Data.IsDeneyimleri = businessModel;
            }

            BSTMethods.AddNode(model);
            BSTMethods.ClearFile();
            BSTMethods.PreOrderWF(BuildData.node);
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
            fileText += "mcss" + mailTxt.Text.Trim() + "??" + sifreTxt.Text.Trim() + "ssmc";
            using (StreamWriter file = new StreamWriter(@"prpw.ssmc", false))
            {
                fileText = Security.Encrypt(fileText);
                file.Write(fileText);
            }
            DialogResult sonuc;
            sonuc = MessageBox.Show("Başvurunuz kaydınız başarıyla oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (sonuc == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        public int dt = 0;
        private void dilEkleBtn_Click(object sender, EventArgs e)
        {
            ++dt;
            TextBox tb = new TextBox();
            tb.Width = dilTxt0.Width;
            tb.Name = "dilTxt" + dt;
            flowLayoutPanel5.Controls.Add(tb);
            if (dt > -1)
            {
                dilCikarBtn.Enabled = true;
            }

        }
        public int et = 0;
        private void ehliyetEkleBtn_Click(object sender, EventArgs e)
        {
            ++et;
            TextBox tb = new TextBox();
            tb.Width = ehliyetTxt0.Width;
            tb.Name = "ehliyetTxt" + et;
            flowLayoutPanel6.Controls.Add(tb);
            if (et > -1)
            {
                ehliyetCikarBtn.Enabled = true;
            }

        }
        private void dilCikarBtn_Click(object sender, EventArgs e)
        {
            if (dt == 0)
            {
                dilCikarBtn.Enabled = false;
            }
            TextBox tb = flowLayoutPanel5.Controls.Find("dilTxt" + dt, true).FirstOrDefault() as TextBox;
            flowLayoutPanel5.Controls.Remove(tb);
            --dt;
        }
        private void ehliyetCikarBtn_Click(object sender, EventArgs e)
        {
            if (et == 0)
            {
                ehliyetCikarBtn.Enabled = false;
            }
            TextBox tb = flowLayoutPanel6.Controls.Find("ehliyetTxt" + et, true).FirstOrDefault() as TextBox;
            flowLayoutPanel6.Controls.Remove(tb);
            --et;
        }
        public int ot = 0, ott = 0, obt = 0, obtt = 0, obitt = 0, onot = 0;

        private void sifreTxt_Leave(object sender, EventArgs e)
        {
            if (sifreTxt.Text.Length > 6)
            {
                kayitEkleBtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen minimum 7 karakterli bir şifre giriniz");
                kayitEkleBtn.Enabled = false;
                sifreTxt.Focus();
            }
        }

        private void isTecrubeTxt0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(e.KeyChar == ','))
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void egitimEkleBtn_Click(object sender, EventArgs e)
        {
            ++ot; ++ott; ++obt; ++obtt; ++obitt; ++onot;
            TextBox otn = new TextBox(); otn.Width = okulTxt0.Width; otn.Name = "okulTxt" + ot; flowLayoutPanel7.Controls.Add(otn);
            TextBox ottn = new TextBox(); ottn.Width = okulTurTxt0.Width; ottn.Name = "okulTurTxt" + ott; flowLayoutPanel7.Controls.Add(ottn);
            TextBox obtn = new TextBox(); obtn.Width = okulBolumTxt0.Width; obtn.Name = "okulBolumTxt" + obt; flowLayoutPanel7.Controls.Add(obtn);
            DateTimePicker obttn = new DateTimePicker(); obttn.Width = okulBaslangicDtp0.Width; obttn.Name = "okulBaslangicDtp" + obtt; flowLayoutPanel7.Controls.Add(obttn);
            DateTimePicker obittn = new DateTimePicker(); obittn.Width = okulBitisDtp0.Width; obittn.Name = "okulBitisDtp" + obitt; flowLayoutPanel7.Controls.Add(obittn);
            TextBox onotn = new TextBox(); onotn.Width = okulNotTxt0.Width; onotn.Name = "okulNotTxt" + onot; flowLayoutPanel7.Controls.Add(onotn);
            if (ott > -1)
            {
                egitimCikarBtn.Enabled = true;
            }
        }

        private void egitimCikarBtn_Click(object sender, EventArgs e)
        {
            if (ott == 0)
            {
                egitimCikarBtn.Enabled = false;
            }
            TextBox otn = flowLayoutPanel7.Controls.Find("okulTxt" + ot, true).FirstOrDefault() as TextBox;
            flowLayoutPanel7.Controls.Remove(otn);
            --ot;
            TextBox ottn = flowLayoutPanel7.Controls.Find("okulTurTxt" + ott, true).FirstOrDefault() as TextBox;
            flowLayoutPanel7.Controls.Remove(ottn);
            --ott;
            TextBox obtn = flowLayoutPanel7.Controls.Find("okulBolumTxt" + obt, true).FirstOrDefault() as TextBox;
            flowLayoutPanel7.Controls.Remove(obtn);
            --obt;
            DateTimePicker obttn = flowLayoutPanel7.Controls.Find("okulBaslangicDtp" + obtt, true).FirstOrDefault() as DateTimePicker;
            flowLayoutPanel7.Controls.Remove(obttn);
            --obtt;
            DateTimePicker obittn = flowLayoutPanel7.Controls.Find("okulBitisDtp" + obitt, true).FirstOrDefault() as DateTimePicker;
            flowLayoutPanel7.Controls.Remove(obittn);
            --obitt;
            TextBox onotn = flowLayoutPanel7.Controls.Find("OkulNotTxt" + onot, true).FirstOrDefault() as TextBox;
            flowLayoutPanel7.Controls.Remove(onotn);
            --onot;
        }
        public int it = 0, iat = 0, ipt = 0, itt = 0;
        private void isEkleBtn_Click(object sender, EventArgs e)
        {
            ++it; ++iat; ++ipt; ++itt;
            TextBox itn = new TextBox(); itn.Width = isTxt0.Width; itn.Name = "isTxt" + it; flowLayoutPanel8.Controls.Add(itn);
            TextBox iatn = new TextBox(); iatn.Width = isAdresTxt0.Width; iatn.Name = "isAdresTxt" + iat; flowLayoutPanel8.Controls.Add(iatn);
            TextBox iptn = new TextBox(); iptn.Width = isPozisyonTxt0.Width; iptn.Name = "isPozisyonTxt" + ipt; flowLayoutPanel8.Controls.Add(iptn);
            TextBox ittn = new TextBox(); ittn.Width = isTecrubeTxt0.Width; ittn.Name = "isTecrubeTxt" + itt; ittn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.isTecrubeTxt0_KeyPress); flowLayoutPanel8.Controls.Add(ittn);
            if (it > -1)
            {
                isCikarBtn.Enabled = true;
            }
        }
        private void isCikarBtn_Click(object sender, EventArgs e)
        {
            if (it == 0)
            {
                isCikarBtn.Enabled = false;
            }
            TextBox itn = flowLayoutPanel8.Controls.Find("isTxt" + it, true).FirstOrDefault() as TextBox;
            flowLayoutPanel8.Controls.Remove(itn);
            --it;
            TextBox iatn = flowLayoutPanel8.Controls.Find("isAdresTxt" + iat, true).FirstOrDefault() as TextBox;
            flowLayoutPanel8.Controls.Remove(iatn);
            --iat;
            TextBox iptn = flowLayoutPanel8.Controls.Find("isPozisyonTxt" + ipt, true).FirstOrDefault() as TextBox;
            flowLayoutPanel8.Controls.Remove(iptn);
            --ipt;
            TextBox ittn = flowLayoutPanel8.Controls.Find("isTecrubeTxt" + itt, true).FirstOrDefault() as TextBox;
            flowLayoutPanel8.Controls.Remove(ittn);
            --itt;
        }
    }
}
