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
    public partial class btndoluoda : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D9GON9P\\SQLEXPRESS;Initial Catalog=yurt_proje;Integrated Security=True");
        public btndoluoda()
        {
            InitializeComponent();
        }

        private void OdaVerileriniGetir(string odaAdi)
        {
            try
            {
                con.Open();

                // Seçilen odanın verilerini getiren sorgu
                string query = "SELECT * FROM kayit WHERE odano = @odano";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@odano", odaAdi);

                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);

                dataGridView1.DataSource = dt;

                // Oda dolu mu kontrolü
                if (dt.Rows.Count > 0)
                {
                    // Oda dolu, buton arka plan rengini kırmızıya ayarla
                    Button button = GetButtonByOdaAdi(odaAdi);
                    if (button != null)
                    {
                        button.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private Button GetButtonByOdaAdi(string odaAdi)
        {
            // Oda adına göre formdaki uygun butonu bul ve döndür
            foreach (Control control in Controls)
            {
                if (control is Button && control.Name.EndsWith("button") && control.Tag != null && control.Tag.ToString() == odaAdi)
                {
                    return (Button)control;
                }
            }
            return null;
        }



        private void a101button_Click(object sender, EventArgs e)
        {
            OdaVerileriniGetir("A101");
            string odanum = "A101";
           
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
            OdaVerileriniGetir("A102");
            string odanum = "A102";
            
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
        private void a103button_Click(object sender, EventArgs e)
        {
            OdaVerileriniGetir("A103");
            string odanum = "A103";
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
        private void a104button_Click(object sender, EventArgs e)
        {
            OdaVerileriniGetir("A104");
            string odanum = "A104";
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
        private void b101button_Click(object sender, EventArgs e)
        {
            OdaVerileriniGetir("B101");
            string odanum = "B101";
           
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
            OdaVerileriniGetir("B102");
            string odanum = "B102";
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
            OdaVerileriniGetir("B103");
            string odanum = "B103";
            
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
            OdaVerileriniGetir("B104");
            string odanum = "B104";
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
            OdaVerileriniGetir("C101");
            string odanum = "C101";
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
            OdaVerileriniGetir("C103");
            string odanum = "C103";
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
            OdaVerileriniGetir("C104");
            string odanum = "C104";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();
            this.Hide();
        }
        private Color[] GenerateRandomColors(int count)
        {
            // Generate an array of random colors
            Random rand = new Random();
            Color[] colors = new Color[count];
            for (int i = 0; i < count; i++)
            {
                colors[i] = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            }
            return colors;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                int aBlokCount = GetOdaCount(con, "A%");
                int bBlokCount = GetOdaCount(con, "B%");
                int cBlokCount = GetOdaCount(con, "C%");

                // PictureBox üzerine çizim yapmak için bir Graphics nesnesi oluşturun
                using (Graphics g = pictureBox2.CreateGraphics())
                {
                    // Çizimi temizle
                    g.Clear(Color.White);

                    // Çizim için kalem ve fırça oluşturun
                    Pen pen = new Pen(Color.Black, 2);

                    // Çizim konumları
                    int startX = 50;
                    int startY = pictureBox2.Height - 50;
                    int barWidth = 80;
                    int barSpacing = 30;
                    int maxBarHeight = 150; // Maksimum sütun yüksekliği

                    // Generate random colors for each column
                    Color[] colors = GenerateRandomColors(3);

                    // A Blok
                    Brush aBlokBrush = new SolidBrush(colors[0]);
                    int aBlokHeight = (int)(aBlokCount / (double)(aBlokCount + bBlokCount + cBlokCount) * maxBarHeight);
                    g.FillRectangle(aBlokBrush, startX, startY - aBlokHeight, barWidth, aBlokHeight);
                    g.DrawRectangle(pen, startX, startY - aBlokHeight, barWidth, aBlokHeight);
                    g.DrawString("A Blok", this.Font, Brushes.Black, startX, startY + 5);
                    g.DrawString(aBlokCount.ToString(), this.Font, Brushes.Black, startX + barWidth / 2 - 10, startY - aBlokHeight - 20);
                    startX += barWidth + barSpacing;

                    // B Blok
                    Brush bBlokBrush = new SolidBrush(colors[1]);
                    int bBlokHeight = (int)(bBlokCount / (double)(aBlokCount + bBlokCount + cBlokCount) * maxBarHeight);
                    g.FillRectangle(bBlokBrush, startX, startY - bBlokHeight, barWidth, bBlokHeight);
                    g.DrawRectangle(pen, startX, startY - bBlokHeight, barWidth, bBlokHeight);
                    g.DrawString("B Blok", this.Font, Brushes.Black, startX, startY + 5);
                    g.DrawString(bBlokCount.ToString(), this.Font, Brushes.Black, startX + barWidth / 2 - 10, startY - bBlokHeight - 20);
                    startX += barWidth + barSpacing;

                    // C Blok
                    Brush cBlokBrush = new SolidBrush(colors[2]);
                    int cBlokHeight = (int)(cBlokCount / (double)(aBlokCount + bBlokCount + cBlokCount) * maxBarHeight);
                    g.FillRectangle(cBlokBrush, startX, startY - cBlokHeight, barWidth, cBlokHeight);
                    g.DrawRectangle(pen, startX, startY - cBlokHeight, barWidth, cBlokHeight);
                    g.DrawString("C Blok", this.Font, Brushes.Black, startX, startY + 5);
                    g.DrawString(cBlokCount.ToString(), this.Font, Brushes.Black, startX + barWidth / 2 - 10, startY - cBlokHeight - 20);
                }

                MessageBox.Show($"A Blok: {aBlokCount}\nB Blok: {bBlokCount}\nC Blok: {cBlokCount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        private int GetOdaCount(SqlConnection con, string odaPrefix)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM kayit WHERE odano LIKE @p1", con);
            cmd.Parameters.AddWithValue("@p1", odaPrefix);

            return (int)cmd.ExecuteScalar();
        }




        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


    }
}
