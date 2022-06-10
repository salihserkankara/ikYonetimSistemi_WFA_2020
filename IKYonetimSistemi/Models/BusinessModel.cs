using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKYonetimSistemi.Models
{
    public class BusinessModel
    {
        public string CalistigiYer { get; set; }
        public string Adres { get; set; }
        public string Pozisyon { get; set; }
        public double CalismaSuresi { get; set; }
        public BusinessModel IsEkle { get; set; } = null;

        public BusinessModel(BusinessModel model)
        {
            CalistigiYer = model.CalistigiYer;
            Adres = model.Adres;
            Pozisyon = model.Pozisyon;
            CalismaSuresi = model.CalismaSuresi;
        }

        public BusinessModel()
        {
                
        }
    }
}
