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
    public partial class AcilisEkrani : Form
    {
        public AcilisEkrani()
        {
            InitializeComponent();
        }

        private void elemanAramaBtn_Click(object sender, EventArgs e)
        {
            ElemanArama ea = new ElemanArama();
            ea.ShowDialog();
            
        }

        private void isBasvuruBtn_Click(object sender, EventArgs e)
        {
            IsBasvuru ib = new IsBasvuru();
            ib.ShowDialog();
        }

        private void girisLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            giris g = new giris();
            g.ShowDialog();
        }
    }
}
