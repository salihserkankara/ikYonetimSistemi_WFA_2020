using IKYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKYonetimSistemi.BSTOperations
{
    public class BuildData
    {
        public static BSTNode node;
        public BuildData()
        {

        }

        public static void Init()
        {
            
            string path = @"data.ssmc";
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                readText = readText.Replace('\"', '*');
                readText = readText.Replace("* ", "*");
                readText = readText.Replace(" *", "*");

                while (readText.Contains("]}"))
                {
                    NodeModel model = new NodeModel();

                    model.Ad = GetJsonValue("*Ad*:*", readText);
                    model.Adres = GetJsonValue("*Adres*:*", readText);
                    model.Telefon = GetJsonValue("*Telefon*:*", readText);
                    model.Eposta = GetJsonValue("*Eposta*:*", readText);
                    model.DogumTarihi = Convert.ToDateTime("01/01/" + GetJsonValue("*DogumTarihi*:*", readText));
                    model.Diller = GetJsonValue("*Diller*:[", readText);
                    model.Ehliyet = GetJsonValue("*Ehliyet*:[", readText);
                    model.Ehliyet = model.Ehliyet.Replace("*", string.Empty);
                    model.Diller = model.Diller.Replace("*", string.Empty);

                    CollegeModel collegeModel = new CollegeModel();
                    int okullarIndex = readText.IndexOf("*Okullar*:[") + 11;
                    if (okullarIndex != -1)
                    {
                        int okullarSonIndex = readText.IndexOf(']', okullarIndex);
                        string okullarJson = readText.Substring(okullarIndex, okullarSonIndex - okullarIndex);

                        while (okullarJson.Contains('{'))
                        {
                            CollegeModel clgModel = new CollegeModel();

                            clgModel.OkulAdi = GetJsonValue("*OkulAdi*:*", okullarJson);
                            clgModel.Tur = GetJsonValue("*Tur*:*", okullarJson);
                            clgModel.Bolum = GetJsonValue("*Bolum*:*", okullarJson);
                            clgModel.BaslangicTarihi = Convert.ToDateTime("01/01/" + GetJsonValue("*BaslangicTarihi*:*", okullarJson));
                            clgModel.BitisTarihi = Convert.ToDateTime("01/01/" + GetJsonValue("*BitisTarihi*:*", okullarJson));
                            clgModel.NotOrtalama = Convert.ToInt32(GetJsonValue("*NotOrtalama*:*", okullarJson));
                            okullarJson = okullarJson.Remove(0, okullarJson.IndexOf("}") + 1);

                            if (collegeModel.OkulAdi == null)
                            {
                                collegeModel = new CollegeModel(clgModel);
                            }
                            else
                            {

                                CollegeModel newNode = new CollegeModel(clgModel);
                                CollegeModel ittr = collegeModel;

                                while (ittr.OkulEkle != null)
                                {
                                    ittr = ittr.OkulEkle;
                                }

                                ittr.OkulEkle = newNode;
                            }
                        }
                    }

                    model.Okullar = collegeModel;

                    BusinessModel businessModel = new BusinessModel();
                    int deneyimlerIndex = readText.IndexOf("*IsDeneyimleri*:[") + 17;
                    if (deneyimlerIndex != -1)
                    {
                        int deneyimlerSonIndex = readText.IndexOf(']', deneyimlerIndex);
                        string deneyimlerJson = readText.Substring(deneyimlerIndex, deneyimlerSonIndex - deneyimlerIndex);

                        while (deneyimlerJson.Contains('{'))
                        {
                            BusinessModel bsnModel = new BusinessModel();
                            bsnModel.CalistigiYer = GetJsonValue("*CalistigiYer*:*", deneyimlerJson);
                            bsnModel.Adres = GetJsonValue("*IsAdres*:*", deneyimlerJson);
                            bsnModel.Pozisyon = GetJsonValue("*Pozisyon*:*", deneyimlerJson);
                            bsnModel.CalismaSuresi = Convert.ToDouble(GetJsonValue("*CalismaSuresi*:*", deneyimlerJson));
                            deneyimlerJson = deneyimlerJson.Remove(0, deneyimlerJson.IndexOf("}") + 1);

                            if (businessModel.CalistigiYer == null)
                            {
                                businessModel = new BusinessModel(bsnModel);
                            }
                            else
                            {

                                BusinessModel newNode = new BusinessModel(bsnModel);
                                BusinessModel ittr = businessModel;

                                while (ittr.IsEkle != null)
                                {
                                    ittr = ittr.IsEkle;
                                }

                                ittr.IsEkle = newNode;
                            }
                        }
                    }

                    model.IsDeneyimleri = businessModel;

                    readText = readText.Remove(0, readText.IndexOf("]}") + 3);

                    BSTMethods.AddNode(new BSTNode(model));
                }
                //BSTMethods.PreOrderWF(node);
                //DataEncrypted();
            }
            else
            {
                node = new BSTNode();
            }
        }

        public static string GetJsonValue(string key, string text)
        {
            string ayrac = key.Substring(key.Length - 1).Equals("*") ? "*" : "]";
            int ilkIndex = text.IndexOf(key) + key.Length;
            int sonIndex = text.IndexOf(ayrac, ilkIndex);
            return text.Substring(ilkIndex, sonIndex - ilkIndex);
        }

        public static string NodeToText(BSTNode nodeM)
        {
            string textSt = "{\"Ad\":\"" + nodeM.Data.Ad + "\",";
            textSt += "\r\n\"Adres\":\"" + nodeM.Data.Adres + "\",";
            textSt += "\r\n\"Telefon\":\"" + nodeM.Data.Telefon + "\",";
            textSt += "\r\n\"Eposta\":\"" + nodeM.Data.Eposta + "\",";
            textSt += "\r\n\"DogumTarihi\":\"" + nodeM.Data.DogumTarihi.Year.ToString() + "\",";
            textSt += "\r\n\"Diller\":[\"";
            if(nodeM.Data.Diller != null)
            {
                textSt += nodeM.Data.Diller.Replace(",", "\",\"");
            }
            textSt += "\"],";
            textSt += "\r\n\"Ehliyet\":[\"";
            if(nodeM.Data.Ehliyet != null)
            {
                textSt += nodeM.Data.Ehliyet.Replace(",", "\",\"");
            }
            textSt += "\"],";
            textSt += "\r\n\"Okullar\":[";

            CollegeModel circulatingNode = nodeM.Data.Okullar;
            while (circulatingNode != null)
            {
                textSt += "{\"OkulAdi\":\"" + circulatingNode.OkulAdi + "\",";
                textSt += "\"Tur\":\"" + circulatingNode.Tur + "\",";
                textSt += "\"Bolum\":\"" + circulatingNode.Bolum + "\",";
                textSt += "\"BaslangicTarihi\":\"" + circulatingNode.BaslangicTarihi.Year.ToString() + "\",";
                textSt += "\"BitisTarihi\":\"" + circulatingNode.BitisTarihi.Year.ToString() + "\",";
                textSt += "\"NotOrtalama\":\"" + circulatingNode.NotOrtalama + "\"},";

                circulatingNode = circulatingNode.OkulEkle;
            }
            if(textSt.Substring(textSt.Length - 1) == ",")
            {
                textSt = textSt.Remove(textSt.Length - 1);
            }

            textSt += "],\r\n\"IsDeneyimleri\":[";
            BusinessModel circBusn = nodeM.Data.IsDeneyimleri;

            while (circBusn != null)
            {
                textSt += "{\"CalistigiYer\":\"" + circBusn.CalistigiYer + "\",";
                textSt += "\"IsAdres\":\"" + circBusn.Adres + "\",";
                textSt += "\"Pozisyon\":\"" + circBusn.Pozisyon + "\",";
                textSt += "\"CalismaSuresi\":\"" + circBusn.CalismaSuresi + "\"},";

                circBusn = circBusn.IsEkle;
            }
            if (textSt.Substring(textSt.Length - 1) == ",")
            {
                textSt = textSt.Remove(textSt.Length - 1);
            }
            textSt += "]},\r\n";

            return textSt;
        }

        public static void DataEncrypted()
        {
            string path = @"data.ssmc";

            string readText = File.ReadAllText(path);
            readText = Security.Encrypt(readText);
            BSTMethods.WriteFile(readText);
        }
    }
}
