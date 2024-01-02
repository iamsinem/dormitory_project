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
    public partial class ogrenci : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");
        public ogrenci()
        {
            InitializeComponent();
            OdalariKontrolEt();
        }

        public void verilerigor()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT *FROM kayit" ,con);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btngor_Click(object sender, EventArgs e)
        {
            verilerigor();
        }
        private bool OdaDoluMu(string odaAdi)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@odano", con);
                cmd.Parameters.AddWithValue("@odano", odaAdi);

                int odaKayitSayisi = (int)cmd.ExecuteScalar();

                return odaKayitSayisi > 0;
            }
        }

        private bool TcNoKullanildiMi(string tcNo)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE tcno=@tcno", con);
                cmd.Parameters.AddWithValue("@tcno", tcNo);

                int kayitSayisi = (int)cmd.ExecuteScalar();

                return kayitSayisi > 0;
            }
        }
        private void kayıtbutton_Click(object sender, EventArgs e)
        {
            con.Open();

            string odaAdi = txtodano.Text;
            if (TcNoKullanildiMi(txttcno.Text))
            {
                MessageBox.Show("Bu TC Kimlik Numarası zaten kullanılmış. Lütfen farklı bir TC Kimlik Numarası seçiniz.");
            }
            else
            {
                // Oda dolu mu kontrolü
                if (OdaDoluMu(odaAdi))
                {
                    MessageBox.Show("Bu oda zaten dolu. Başka bir oda seçiniz.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO kayit (adi, soyadi, telno, mail, tcno, odano, sifre, rol, odemeayi) VALUES (@adi, @soyadi, @telno, @mail, @tcno, @odano, @sifre, @rol, @odemeayi)", con);

                    cmd.Parameters.AddWithValue("@adi", txtadi.Text);
                    cmd.Parameters.AddWithValue("@soyadi", txtsoyadi.Text);
                    cmd.Parameters.AddWithValue("@telno", txttelno.Text);
                    cmd.Parameters.AddWithValue("@mail", txtmail.Text);
                    cmd.Parameters.AddWithValue("@tcno", txttcno.Text);
                    cmd.Parameters.AddWithValue("@odano", txtodano.Text);
                    cmd.Parameters.AddWithValue("@sifre", txtsifre.Text);
                    cmd.Parameters.AddWithValue("@rol", txtrol.Text);
                    cmd.Parameters.AddWithValue("@odemeayi", txtodemeayi.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Yeni Kayıt Yapıldı");

                    if (txtodano.Text == "A102")
                    {
                        a102button.Enabled = false;
                        a102button.BackColor = Color.Red;
                    }

                    txtadi.Clear();
                    txtsoyadi.Clear();
                    txttelno.Clear();
                    txtmail.Clear();
                    txttcno.Clear();
                    txtodano.Clear();
                    txtsifre.Clear();
                    txtrol.Clear();

                    con.Close();

                }
            
            }
        }
        private void OdalariKontrolEt()
        {
            try
            {
                // Tüm odaların butonlarını kontrol et
                foreach (Control control in Controls)
                {
                    if (control is Button && control.Name.EndsWith("button"))
                    {
                        string odaAdi = control.Tag?.ToString();

                        if (!string.IsNullOrEmpty(odaAdi) && OdaDoluMu(odaAdi))
                        {
                            // Oda dolu, buton arka plan rengini kırmızıya ayarla
                            control.BackColor = Color.Red;
                        }
                        else
                        {
                            // Oda boş, buton arka plan rengini eski rengine döndür
                            control.BackColor = Color.Khaki;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();
            this.Hide();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM kayit WHERE tcno=@p1", con);
            cmd.Parameters.AddWithValue("@p1",txttcno.Text);
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
            verilerigor();
        }

        private void btnanasayfa_Click_1(object sender, EventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtadi.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtsoyadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txttelno.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttcno.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtodano.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtsifre.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtrol.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtodemeayi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
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

            // Dolu odaları kontrol et ve renkleri ayarla
            OdalariKontrolEt();
        }

        private void a101button_Click_1(object sender, EventArgs e)
        {
            string odanum = "A101";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                a101button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                a101button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void a102button_Click_1(object sender, EventArgs e)
        {
            string odanum = "A102";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                a102button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                a102button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void a103button_Click_1(object sender, EventArgs e)
        {
            string odanum = "A103";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                a103button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                a103button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void a104button_Click_1(object sender, EventArgs e)
        {
            string odanum = "A104";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                a104button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                a104button.BackColor = Color.Khaki;
            }

            con.Close();

        }
        private void b101button_Click_1(object sender, EventArgs e)
        {
            string odanum = "B101";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                b101button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                b101button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void b102button_Click(object sender, EventArgs e)
        {
            string odanum = "B102";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                b102button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                b102button.BackColor = Color.Khaki;
            }

            con.Close();

        }

        private void b103button_Click(object sender, EventArgs e)
        {
            string odanum = "B103";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                b103button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                b103button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void b104button_Click(object sender, EventArgs e)
        {
            string odanum = "B104";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                b104button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                b104button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void c101button_Click(object sender, EventArgs e)
        {
            string odanum = "C101";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                c101button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                c101button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void c102button_Click(object sender, EventArgs e)
        {
            string odanum = "C102";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                c102button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                c102button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void c103button_Click(object sender, EventArgs e)
        {
            string odanum = "C103";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                c103button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                c103button.BackColor = Color.Khaki;
            }

            con.Close();
        }

        private void c104button_Click(object sender, EventArgs e)
        {
            string odanum = "C104";
            txtodano.Text = odanum; // Odanın numarasını TextBox'a set et
            con.Open();

            // Kayıt kontrolü yap
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano=@p1", con);
            cmd.Parameters.AddWithValue("@p1", odanum);

            int odaKayitSayisi = (int)cmd.ExecuteScalar();

            if (odaKayitSayisi > 0)
            {
                // Eğer odada kayıt varsa, odayı kırmızıya boyayabilirsiniz
                c104button.BackColor = Color.Red;
            }
            else
            {
                // Eğer odada kayıt yoksa, odayı orijinal rengine döndürebilirsiniz
                c104button.BackColor = Color.Khaki;
            }

            con.Close();
        }
    }
}
