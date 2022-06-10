using IKYonetimSistemi.BSTOperations;
using IKYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKYonetimSistemi
{
    public partial class Detaylar : Form
    {
        public string AdBilgisi { get; set; }
        public string MailBilgisi { get; set; }
        public Detaylar()
        {
            InitializeComponent();
        }
        
        private void Detaylar_Load(object sender, EventArgs e)
        {
            NodeModel model = BSTMethods.SearchNode(AdBilgisi, MailBilgisi);
            adLbl.Text = model.Ad;
            adresLbl.Text = model.Adres;
            telefonLbl.Text = model.Telefon;
            epostaLbl.Text = model.Eposta;
            dTarihiLbl.Text = model.DogumTarihi.Year.ToString();
            dilLbl.Text = model.Diller;
            ehliyetLbl.Text = model.Ehliyet;

            CollegeModel circModel = model.Okullar;
            while(circModel != null)
            {
                if(circModel.NotOrtalama > 0)
                {
                    egitimLbl.Text += "(" + circModel.Tur + ")   " + circModel.OkulAdi + "       ||  Bölüm: " + circModel.Bolum + "       ||  Ortalama: " + circModel.NotOrtalama + "    (" + circModel.BaslangicTarihi.Year + " - " + circModel.BitisTarihi.Year + ")\n";
                    circModel = circModel.OkulEkle;
                }
                else
                {
                    break;
                }
            }

            BusinessModel circBsn = model.IsDeneyimleri;
            while(circBsn != null)
            {
                if(circBsn.CalismaSuresi > 0)
                {
                    tecrubeLbl.Text += circBsn.CalistigiYer + "       ||  Adres: " + circBsn.Adres + "       ||  Pozisyon: " + circBsn.Pozisyon + "    (" + circBsn.CalismaSuresi + " yıl)\n";
                    circBsn = circBsn.IsEkle;
                }
                else
                {
                    break;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    
}
