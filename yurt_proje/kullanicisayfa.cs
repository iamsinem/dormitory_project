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

    

    public partial class kullanicisayfa : Form
    {
        private string kullaniciadi;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");
        public kullanicisayfa(string kullaniciadi)
        {
            InitializeComponent();
            this.kullaniciadi = kullaniciadi;  
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnduyurugör_Click(object sender, EventArgs e)
        {
            duyurugor duyuru= new duyurugor(kullaniciadi);
            duyuru.Show();
            this.Hide();
        }

        private void btnodeme_Click(object sender, EventArgs e)
        {
            odemeyap odeme = new odemeyap(kullaniciadi);
            odeme.Show();
            this.Hide();
        }

        private void kayıtbutton_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE kayit SET adi = @adi, soyadi = @soyadi, telno = @telno, mail = @mail, odano = @odano, sifre = @sifre, rol = @rol, odemeayi = @odemeayi WHERE tcno = @tcno", con);

            cmd.Parameters.AddWithValue("@adi", txtadi.Text);
            cmd.Parameters.AddWithValue("@soyadi", txtsoyadi.Text);
            cmd.Parameters.AddWithValue("@telno", txttelno.Text);
            cmd.Parameters.AddWithValue("@mail", txtmail.Text);
            cmd.Parameters.AddWithValue("@odano", txtodano.Text);
            cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);
            cmd.Parameters.AddWithValue("@rol", txtrol.Text);
            cmd.Parameters.AddWithValue("@odemeayi", txtodemeayi.Text);
            cmd.Parameters.AddWithValue("@tcno", txttcno.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            txtadi.Clear();
            txtsoyadi.Clear();
            txttelno.Clear();
            txtmail.Clear();
            txttcno.Clear();
            txtodano.Clear();
            txtsifre.Clear();
            txtrol.Clear();

            MessageBox.Show("Kullanıcı güncellendi.");
        }

        private void btnbilgiler_Click(object sender, EventArgs e)
        {
            con.Open();

            // Kullanıcı adı üzerinden verileri çek
           
            SqlCommand cmd = new SqlCommand("SELECT * FROM kayit WHERE tcno = @tc", con);
            cmd.Parameters.AddWithValue("@tc", kullaniciadi);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Kullanıcının verilerini ilgili textboxlara yaz
                txtadi.Text = reader["adi"].ToString();
                txtsoyadi.Text = reader["soyadi"].ToString();
                txttelno.Text = reader["telno"].ToString();
                txtmail.Text = reader["mail"].ToString();
                txttcno.Text = reader["tcno"].ToString();
                txtodano.Text = reader["odano"].ToString();
                txtsifre.Text = reader["sifre"].ToString();
                txtrol.Text = reader["rol"].ToString();
                txtodemeayi.Text = reader["odemeayi"].ToString();
            }

            reader.Close();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            giriss giriss = new giriss();
            giriss.Show();
            this.Hide();
        }
    }
}
