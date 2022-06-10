using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKYonetimSistemi.Models
{
    public class NodeModel
    {
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Diller { get; set; }
        public string Ehliyet { get; set; }
        public CollegeModel Okullar { get; set; }
        public BusinessModel IsDeneyimleri { get; set; }
    }
}
