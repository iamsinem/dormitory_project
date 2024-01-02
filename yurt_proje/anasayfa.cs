using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yurt_proje
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

       

        private void buttonogrgor_Click(object sender, EventArgs e)
        {
            ogrenci ogr=new ogrenci();
            ogr.Show();
            this.Hide();
          
        }

        private void buttonodalar_Click(object sender, EventArgs e)
        {
            btndoluoda oda = new btndoluoda();
            oda.Show();
            this.Hide();
        }

        private void buttongiris_Click(object sender, EventArgs e)
        {
            giriss gir = new giriss();
            gir.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            duyuruyap duyuru=new duyuruyap();
            duyuru.Show();
            this.Hide();
        }
    }
}
