using IKYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IKYonetimSistemi.BSTOperations
{
    public class BSTMethods
    {
        public BSTMethods()
        {
            
        }
        public static void AddNode(BSTNode node)
        {
            BSTNode tempNode = new BSTNode();
            BSTNode circulatingNode = BuildData.node;

            while(circulatingNode != null)
            {
                tempNode = circulatingNode;

                if(node.Data.Ad.CompareTo(circulatingNode.Data.Ad) == -1)
                {
                    circulatingNode = circulatingNode.Left;
                }
                else
                {
                    circulatingNode = circulatingNode.Right;
                }
            }

            if(BuildData.node == null)
            {
                BuildData.node = node;
            }
            else if(node.Data.Ad.CompareTo(tempNode.Data.Ad) == -1)
            {
                tempNode.Left = node;
            }
            else
            {
                tempNode.Right = node;
            }
        }

        public static void WriteFile(string textSt)
        {
            using (StreamWriter file = new StreamWriter(@"data.ssmc", true))
            {
                file.WriteLine(textSt);
            }
        }

        public static void ClearFile()
        {
            using (StreamWriter file = new StreamWriter(@"data.ssmc", false))
            {
                file.Write("[");
            }
        }

        public static void PreOrderWF(BSTNode node)
        {
            if(node == null)
            {
                return;
            }
            WriteFile(BuildData.NodeToText(node));
            PreOrderWF(node.Left);
            PreOrderWF(node.Right);
        }
        private static List<ApplicantsModel> dataGridModel;
        public static void ClearData()
        {
            dataGridModel = new List<ApplicantsModel>();
        }

        public static List<ApplicantsModel> GetApplicantsData()
        {
            return dataGridModel;
        }
        public static void InOrderFilter(BSTNode node, FilterModel filters)
        {
            if (node == null)
            {
                return;
            }

            InOrderFilter(node.Left, filters);
            if(filters.UygunSartlar(node.Data))
            {
                dataGridModel.Add(new ApplicantsModel()
                {
                    Ad = node.Data.Ad,
                    Adres = node.Data.Adres,
                    Diller = node.Data.Diller,
                    Yas = DateTime.Now.Year - node.Data.DogumTarihi.Year,
                    Telefon = node.Data.Telefon,
                    Tecrube = TecrubeHesapla(node),
                    Mail = node.Data.Eposta
                });
            }
            InOrderFilter(node.Right, filters);
        }
        private static NodeModel tempModel;
        public static void InOrderFind(BSTNode node, string mail)
        {
            if (node == null)
            {
                return;
            }

            InOrderFind(node.Left, mail);
            if (node.Data.Eposta.Equals(mail))
            {
                tempModel = node.Data;
            }
            InOrderFind(node.Right, mail);
        }

        public static NodeModel GetTempModel()
        {
            return tempModel;
        }
        public static List<ApplicantsModel> SearchNode(string ad)
        {
            List<ApplicantsModel> model = new List<ApplicantsModel>();
            ad = ad.ToLower();
            BSTNode circ = BuildData.node;

            while(circ != null)
            {
                if(circ.Data.Ad.ToLower().Contains(ad))
                {
                    model.Add(new ApplicantsModel()
                    {
                        Ad = circ.Data.Ad,
                        Adres = circ.Data.Adres,
                        Diller = circ.Data.Diller,
                        Telefon = circ.Data.Telefon,
                        Yas = DateTime.Now.Year - circ.Data.DogumTarihi.Year,
                        Tecrube = TecrubeHesapla(circ),
                        Mail = circ.Data.Eposta
                    });

                }
                if(ad.CompareTo(circ.Data.Ad.ToLower()) < 0)
                {
                    circ = circ.Left;
                }
                else
                {
                    circ = circ.Right;
                }
            }

            return model;
        }

        public static NodeModel SearchNode(string ad, string mail)
        {
            BSTNode circ = BuildData.node;

            while (circ != null)
            {
                if(circ.Data.Eposta.Equals(mail) && circ.Data.Ad.Equals(ad))
                {
                    return circ.Data;
                }

                if(ad.CompareTo(circ.Data.Ad) < 0)
                {
                    circ = circ.Left;
                }
                else
                {
                    circ = circ.Right;
                }
            }

            return null;
        }

        public static double TecrubeHesapla(BSTNode node)
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

        public static int NodeCount(BSTNode node)
        {
            int count = 0;

            if (node != null)
            {
                count = 1;
                count += NodeCount(node.Left);
                count += NodeCount(node.Right);
            }

            return count;
        }

        public static int Depth(BSTNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = Depth(node.Left);
                int rightHeight = Depth(node.Right);
                if (leftHeight > rightHeight)
                {
                    leftHeight += 1;
                    return leftHeight;
                }
                else
                {
                    rightHeight += 1;
                    return rightHeight;
                }
            }

        }

        public static BSTNode MinValue(BSTNode node)
        {
            BSTNode minNode = node;

            while(minNode.Left != null)
            {
                minNode = minNode.Left;
            }
            return minNode;
        }

        public static void DeleteNode(string mail)
        {
            InorderDelete(BuildData.node, mail);
            BSTNode fNode = silinecekDugum;
            BSTNode usdugum = ustDugum;
            if(fNode.Left == null && fNode.Right == null)
            {
                if (ustDugum == null)
                {
                    BuildData.node = null;
                }
                else
                {
                    if (ustDugum.Left != null)
                    {
                        if (ustDugum.Left.Data.Eposta.Equals(mail))
                        {
                            ustDugum.Left = null;
                        }
                    }
                    if (ustDugum.Right != null)
                    {
                        ustDugum.Right = null;
                    }
                }
                
                
            }
            else if (fNode.Left != null && fNode.Right != null)
            {
                BSTNode successorNode = MinValue(fNode.Right);
                NodeModel dataModel = successorNode.Data;
                DeleteNode(successorNode.Data.Eposta);
                fNode.Data = dataModel;
            }
            else
            {
                if(ustDugum == null)
                {
                    BSTNode altDugumler = fNode.Left != null ? fNode.Left : fNode.Right;
                    BuildData.node = altDugumler;
                }
                else
                {
                    BSTNode altDugumler = fNode.Left != null ? fNode.Left : fNode.Right;
                    if (ustDugum.Left != null)
                    {
                        if (ustDugum.Left.Data.Eposta.Equals(mail))
                        {
                            ustDugum.Left = altDugumler;
                        }
                    }
                    if(ustDugum.Right != null)
                    {
                        if (ustDugum.Right.Data.Eposta.Equals(mail))
                        {
                            ustDugum.Right = altDugumler;
                        }
                    }
                }
            }
        }
        public static BSTNode silinecekDugum;
        public static BSTNode ustDugum;
        public static void InorderDelete(BSTNode node, string mail)
        {
            if (node == null)
            {
                return;
            }

            InorderDelete(node.Left, mail);
            if (node.Data.Eposta.Equals(mail))
            {
                silinecekDugum = node;
            }
            if(node.Left != null)
            {
                if(node.Left.Data.Eposta.Equals(mail))
                {
                    ustDugum = node;
                }
            }
            if (node.Right != null)
            {
                if (node.Right.Data.Eposta.Equals(mail))
                {
                    ustDugum = node;
                }
            }
            InorderDelete(node.Right, mail);
        }

    }
}
