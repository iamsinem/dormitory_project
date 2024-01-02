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
    public partial class giriss : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");
        public giriss()
        {
            InitializeComponent();
            txtsifre.PasswordChar = '*';
        }

        private void girisbutton_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtkullanıcıadı.Text;
            string sifre = txtsifre.Text;
            bool isAdmin = false;
            if (checkBoxadmin.Checked)
            {
                isAdmin = true;
            }

            // Kullanıcı adı ve şifre kontrolü
            if (GirisYap(kullaniciAdi, sifre, isAdmin))
            {
                if (isAdmin)
                {
                    anasayfa ana = new anasayfa();
                    ana.Show();
                    this.Hide();
                }
                else
                {
                    kullanicisayfa kullan = new kullanicisayfa(kullaniciAdi);
                    kullan.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
            }
        }

        private bool GirisYap(string kullaniciAdi, string sifre, bool isAdmin)
        {
            con.Open();

            // Veritabanında giriş bilgilerini kontrol etmek için uygun sorguyu oluştur
            string query = isAdmin ? "SELECT * FROM kayit WHERE tcno = @kullaniciAdi AND sifre = @sifre AND rol=@rol"
                                  : "SELECT * FROM kayit WHERE tcno = @kullaniciAdi AND sifre = @sifre AND rol=@rol";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            if (isAdmin)
            {
                cmd.Parameters.AddWithValue("@rol", "admin");
            }
            else
            {
                cmd.Parameters.AddWithValue("@rol","kullanıcı");
            }

            SqlDataReader reader = cmd.ExecuteReader();

            // Eğer kayıt varsa, giriş doğrulanmıştır
            bool girisBasarili = reader.HasRows;

            con.Close();

            return girisBasarili;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}