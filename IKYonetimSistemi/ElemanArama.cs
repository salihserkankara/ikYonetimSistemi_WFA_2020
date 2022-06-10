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
    public partial class ElemanArama : Form
    {
        private List<ApplicantsModel> model;
        public ElemanArama()
        {
            InitializeComponent();
            model = new List<ApplicantsModel>();
            modelFilter = new List<NodeModel>();
        }

        private void ElemanArama_Load(object sender, EventArgs e)
        {
            ehliyetCmb.SelectedIndex = 0;
            PreOrderList(BuildData.node);
            if (model.Count > 0)
            {
                BindingSource bindSource = new BindingSource();
                bindSource.DataSource = model;
                dataGridView1.DataSource = bindSource;
                toplamB.Text = "Toplam Başvuru Sayısı: " + BSTMethods.NodeCount(BuildData.node);
                derinlik.Text = "Derinlik: " + BSTMethods.Depth(BuildData.node);
                BSTNode node = BSTMethods.MinValue(BuildData.node);
            }
        }


        public void PreOrderList(BSTNode node)
        {
            if (node == null)
            {
                return;
            }
            if (node.Data != null)
            {
                ApplicantsModel nodeModel = new ApplicantsModel { Ad = node.Data.Ad, Adres = node.Data.Adres, Diller = node.Data.Diller, Telefon = node.Data.Telefon, Mail = node.Data.Eposta };
                nodeModel.Yas = DateTime.Now.Year - node.Data.DogumTarihi.Year;
                nodeModel.Tecrube = TecrubeHesapla(node);
                model.Add(nodeModel);
            }

            PreOrderList(node.Left);
            PreOrderList(node.Right);
        }

        public double TecrubeHesapla(BSTNode node)
        {
            double exp = 0;
            BusinessModel model = node.Data.IsDeneyimleri;

            if (model != null)
            {
                BusinessModel circ = model;
                while (circ != null)
                {
                    exp += circ.CalismaSuresi;
                    circ = circ.IsEkle;
                }
            }

            return exp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindingSource bindSource = new BindingSource();
            bindSource.DataSource = BSTMethods.SearchNode(adAra.Text.Trim());
            dataGridView1.DataSource = bindSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BSTMethods.ClearData();
            BSTMethods.InOrderFilter(BuildData.node, new FilterModel(lisansUstuChck.Checked, ingilizceChck.Checked, dilSayisiChck.Checked, deneyimsizChck.Checked, Convert.ToInt32(deneyimNm.Value), Convert.ToInt32(yasSinirNm.Value), ehliyetCmb.Text.Trim()));
            BindingSource bindSource = new BindingSource();
            bindSource.DataSource = BSTMethods.GetApplicantsData();
            BSTMethods.ClearData();
            dataGridView1.DataSource = bindSource;

        }

        private void deneyimsizChck_CheckedChanged(object sender, EventArgs e)
        {
            if (deneyimsizChck.Checked)
            {
                deneyimNm.Enabled = false;
            }
            else
            {
                deneyimNm.Enabled = true;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ad = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string mail = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            Detaylar detayForm = new Detaylar();
            detayForm.AdBilgisi = ad;
            detayForm.MailBilgisi = mail;
            detayForm.Show();
        }
        List<NodeModel> modelFilter;

        private void yazdirBtn_Click(object sender, EventArgs e)
        {

            bool yaz = false;
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            string path = folder.SelectedPath;
            if(!string.IsNullOrEmpty(path))
            {
                if (File.Exists(path + "\\FiltreSonuc.txt"))
                {
                    DialogResult result = MessageBox.Show("Dosyanın üzerine yazılsın mı?", "Dosyaları Değiştir veya Atla", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        yaz = true;
                    }
                    File.Delete(path + "\\FiltreSonuc.txt");
                }


                if (yaz)
                {
                    int sutunSayisi = dataGridView1.RowCount;
                    modelFilter.Clear();
                    for (int i = 0; i < sutunSayisi; i++)
                    {
                        string mail = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        PreOrderEA(BuildData.node, mail);
                    }
                    string fileText = "";
                    foreach (NodeModel item in modelFilter)
                    {
                        fileText += "Adı: " + item.Ad + "\n";
                        fileText += "Adres: " + item.Adres + "\n";
                        fileText += "Telefon: " + item.Telefon + "\n";
                        fileText += "E-Posta: " + item.Eposta + "\n";
                        fileText += "Doğum Tarihi: " + item.DogumTarihi.Year + "\n";
                        fileText += "Diller: " + item.Diller + "\n";
                        fileText += "Ehliyet: " + item.Ehliyet + "\n";
                        fileText += "Eğitim Bilgileri: \n";
                        CollegeModel circModel = item.Okullar;
                        while (circModel != null)
                        {
                            if (circModel.NotOrtalama > 0)
                            {
                                fileText += new string('-', 5) + "(" + circModel.Tur + ")   " + circModel.OkulAdi + "       ||  Bölüm: " + circModel.Bolum + "       ||  Ortalama: " + circModel.NotOrtalama + "    (" + circModel.BaslangicTarihi.Year + " - " + circModel.BitisTarihi.Year + ")\n";
                                circModel = circModel.OkulEkle;
                            }
                            else
                            {
                                break;
                            }
                        }
                        fileText += "İş Deneyimleri: \n";
                        BusinessModel circBsn = item.IsDeneyimleri;
                        while (circBsn != null)
                        {
                            if (circBsn.CalismaSuresi > 0)
                            {
                                fileText += new string('-', 5) + circBsn.CalistigiYer + "       ||  Adres: " + circBsn.Adres + "       ||  Pozisyon: " + circBsn.Pozisyon + "    (" + circBsn.CalismaSuresi + " yıl)\n";
                                circBsn = circBsn.IsEkle;
                            }
                            else
                            {
                                break;
                            }
                        }
                        fileText += new string('*', 100) + "\n\n";
                    }
                    using (StreamWriter file = new StreamWriter(path + "\\FiltreSonuc.txt", false))
                    {
                        file.WriteLine(fileText);
                    }
                    MessageBox.Show("İşlem Başarılı");
                }
            }
            
        }
        public void PreOrderEA(BSTNode node, string mail)
        {
            if (node == null)
            {
                return;
            }
            if (node.Data.Eposta.Equals(mail))
            {
                modelFilter.Add(node.Data);
            }

            PreOrderEA(node.Left, mail);
            PreOrderEA(node.Right, mail);
        }
    }
}
