using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yurt_proje
{
    public partial class duyurugor : Form
    {
        private string kullaniciadi;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");

        public duyurugor(string kullaniciadi)
        {
            InitializeComponent();
            this.kullaniciadi = kullaniciadi;
        }

        private void btnduyurugör_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM duyurular", con);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtıd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtduyuru.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullanicisayfa kl=new kullanicisayfa(kullaniciadi);
            kl.Show();
            this.Hide();
        }

        private void txtduyuru_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
