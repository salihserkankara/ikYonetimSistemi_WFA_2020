using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKYonetimSistemi.Models
{
    public class CollegeModel
    {
        public string OkulAdi { get; set; }
        public string Tur { get; set; }
        public string Bolum { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int NotOrtalama { get; set; }
        public CollegeModel OkulEkle { get; set; }

        public CollegeModel(CollegeModel model)
        {
            OkulAdi = model.OkulAdi;
            Tur = model.Tur;
            Bolum = model.Bolum;
            BaslangicTarihi = model.BaslangicTarihi;
            BitisTarihi = model.BitisTarihi;
            NotOrtalama = model.NotOrtalama;
        }

        public CollegeModel()
        {
                
        }
    }
}
