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
    public partial class duyuruyap : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");
        public duyuruyap()
        {
            InitializeComponent();
        }

        private void buttongiris_Click(object sender, EventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txtduyuru_TextChanged(object sender, EventArgs e)
        {

        }

        public void verilerigor()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM duyurular", con);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnduyuruyap_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO duyurular (Duyuru,Tarihi) values (@duyuru, @tarihi)", con);

            cmd.Parameters.AddWithValue("@duyuru", txtduyuru.Text);
            cmd.Parameters.AddWithValue("@tarihi", dateTimePicker1.Value);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Yeni Duyuru Yapıldı");

            con.Close();
            txtıd.Clear();
            txtduyuru.Clear();

        }
         private void btnduyurugör_Click(object sender, EventArgs e)
          {
            verilerigor();
          }

        private void btnduyuruguncelle_Click(object sender, EventArgs e)
        {
           
             con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE duyurular SET  Duyuru=@p2 WHERE Id=@p1", con);

            cmd.Parameters.AddWithValue("@p1", txtıd.Text);
            cmd.Parameters.AddWithValue("@p2", txtduyuru.Text);
                    

            cmd.ExecuteNonQuery();
            txtıd.Clear();
            txtduyuru.Clear();
            con.Close();
            MessageBox.Show("Duyuru güncellendi.");
            verilerigor();
        }

        private void btnduyurusil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM duyurular WHERE Id=@p1", con);
            cmd.Parameters.AddWithValue("@p1", txtıd.Text);
            cmd.ExecuteNonQuery();
            txtıd.Clear();
            txtduyuru.Clear();
            con.Close();
            verilerigor();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtıd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtduyuru.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value);

        }
    }
}
