using IKYonetimSistemi.BSTOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKYonetimSistemi.Models
{
    public class FilterModel
    {
        private bool LisansUstu { get; set; }
        private bool Ingilizce { get; set; }
        private bool YabanciDil { get; set; }
        private bool Deneyimsiz { get; set; }
        private int MinDeneyim { get; set; }
        private int MaxYas { get; set; }
        private string EhliyetTipi { get; set; }

        public FilterModel(bool lisansUstuMu, bool ingilizceBilsin, bool birdenFazlaYD, bool deneyimsiz, int minDeneyim, int yasSinir, string ehliyet)
        {
            LisansUstu = lisansUstuMu;
            Ingilizce = ingilizceBilsin;
            YabanciDil = birdenFazlaYD;
            this.Deneyimsiz = deneyimsiz;
            this.MinDeneyim = minDeneyim;
            MaxYas = yasSinir;
            EhliyetTipi = ehliyet;
        }

        public bool UygunSartlar(NodeModel model)
        {
            bool sonuc = true;

            if (LisansUstu)
            {
                bool lisans = false;
                CollegeModel collegeModel = model.Okullar;

                while(collegeModel != null)
                {
                    if(collegeModel.Tur == null)
                    {
                        break;
                    }
                    if(collegeModel.Tur.ToLower().Contains("lisans"))
                    {
                        lisans = true;
                        break;
                    }
                    collegeModel = collegeModel.OkulEkle;
                }

                if(lisans == false)
                {
                    return false;
                }
            }

            if(Ingilizce)
            {
                if(model.Diller == null)
                {
                    return false;
                }
                if(!model.Diller.ToLower().Contains("ingilizce"))
                {
                    return false;
                }
            }

            if(YabanciDil)
            {
                if (model.Diller == null)
                {
                    return false;
                }
                if (!model.Diller.Contains(","))
                {
                    return false;
                }
            }

            if(Deneyimsiz)
            {
                if(model.IsDeneyimleri != null)
                {
                    if(!string.IsNullOrEmpty(model.IsDeneyimleri.CalistigiYer))
                    {
                        return false;
                    }
                }
                
            }

            if(!Deneyimsiz && MinDeneyim > 0)
            {
                if(MinDeneyim > BSTMethods.TecrubeHesapla(new BSTNode(model)))
                {
                    return false;
                }
            }

            int yas = DateTime.Now.Year - model.DogumTarihi.Year;

            if(yas > MaxYas)
            {
                return false;
            }

            if(!EhliyetTipi.Contains("art"))
            {
                if(model.Ehliyet == null)
                {
                    return false;
                }
                if(!model.Ehliyet.ToLower().Contains(EhliyetTipi.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
