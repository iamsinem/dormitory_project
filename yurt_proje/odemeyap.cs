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
    public partial class odemeyap : Form
    {
        private string kullaniciadi;
        private string kod;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");

        public odemeyap(string kullaniciadi)
        {
            InitializeComponent();
            this.kullaniciadi = kullaniciadi;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnöde_Click(object sender, EventArgs e)
        {

            if (txtkod.Text == kod)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE kayit SET adi = @adi, soyadi = @soyadi,  odemeayi = @odemeayi WHERE tcno = @tcno", con);

                cmd.Parameters.AddWithValue("@adi", txtadi.Text);
                cmd.Parameters.AddWithValue("@soyadi", txtsoyadi.Text);
                cmd.Parameters.AddWithValue("@odemeayi", txtodemeayi.Text);
                cmd.Parameters.AddWithValue("@tcno", txttcno.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Ödeme yapıldı.");
            }
            else
            {
                MessageBox.Show("Doğrulama kodu yanlış. Lütfen tekrar deneyin.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullanicisayfa kl= new kullanicisayfa(kullaniciadi);
            kl.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Doğrulama kodu oluştur ve göster
                Random random = new Random();
                kod = random.Next(1000, 9999).ToString(); // Aralığı ihtiyaca göre ayarlayabilirsiniz
                MessageBox.Show($"Doğrulama Kodunuz: {kod}");
            }
            else
            {
                kod = null; // Checkbox işaretli değilse doğrulama kodunu sıfırla
            }
        }

        private void odemeyap_Load(object sender, EventArgs e)
        {

        }
    }
}
