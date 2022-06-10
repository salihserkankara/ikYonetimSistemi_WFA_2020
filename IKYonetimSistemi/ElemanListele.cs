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
    public partial class ElemanListele : Form
    {
        public ElemanListele()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\salihserkankara\Desktop\YazGel-I\sifreil.txt";
            string readText = File.ReadAllText(path);
            readText = Security.Decrypt(readText);
            label1.Text = readText;
        }
    }
}
