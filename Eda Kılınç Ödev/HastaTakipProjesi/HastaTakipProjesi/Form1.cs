using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace HastaTakipProjesi
{
    public partial class Form1 : Form
    {
        OleDbConnection con = new OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=HastaKayıtDB.accdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;

        void listele()
        {
            da = new OleDbDataAdapter("select*from Hastalar", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            temizle();
        }
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            pictureBox1.ImageLocation = "";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyaları:|*.jpg;.*png";
            dosya.ShowDialog();
            String dosyayolu = dosya.FileName;
            textBox9.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("insert into Hastalar(TC,AD,SOYAD,ADRES,TELEFON,TESHiS,ÜCRET,GTarihi,ÇTarihi,RESİM)values(@tc,@ad,@soyad,@adres,@telefon,@teshis,@ucret,@gtarihi,@ctarihi,@resim)", con);
                cmd.Parameters.AddWithValue("@tc", textBox2.Text);
                cmd.Parameters.AddWithValue("@ad", textBox3.Text);
                cmd.Parameters.AddWithValue("@soyad", textBox4.Text);
                cmd.Parameters.AddWithValue("@adres", textBox5.Text);
                cmd.Parameters.AddWithValue("@telefon", textBox6.Text);
                cmd.Parameters.AddWithValue("@teshis", textBox7.Text);
                cmd.Parameters.AddWithValue("@ucret", textBox8.Text);
                cmd.Parameters.AddWithValue("@gtarihi", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@ctarihi", dateTimePicker2.Value.ToString());
                cmd.Parameters.AddWithValue("@resim", textBox9.Text);
                if(textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
                {
                    MessageBox.Show("Lütfen Tüm  Alanları Doldurunuz");
                }
                else
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Yeni Kayıt Eklendi");
                }
               
            }
            catch(Exception)
            {
                 MessageBox.Show("Hatalı İşlem!!");
            }
            listele();




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            temizle();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
           
            textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            pictureBox1.ImageLocation = textBox9.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("delete from Hastalar where TC=@tc", con);
                cmd.Parameters.AddWithValue("@tc", textBox2.Text);
                if(textBox2.Text=="")
                {
                    MessageBox.Show("Silmek İstediğiniz Kişnin Tc'Sini  Giriniz");
                }
                else
                {
                    con.Open();
                   int sonuc= cmd.ExecuteNonQuery();
                    con.Close();
                    if (sonuc == 1)
                    MessageBox.Show("Silme İşlemi Tamam");
                    else
                        MessageBox.Show("Silmek İstediğiniz Kişnin Tc'Sini  Doğru Giriniz!");
                    listele();
                }
               
            }
            catch(Exception)
            {
                MessageBox.Show("Hatalı İşlem!!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("update Hastalar set AD='" + textBox3.Text + "' ,SOYAD='" + textBox4.Text + "' ,ADRES='" + textBox5.Text + "',TELEFON='" + textBox6.Text + "',TESHiS='" + textBox7.Text + "',ÜCRET='" + textBox8.Text + "' ,GTarihi='" + dateTimePicker1.Value.ToString() + "' ,ÇTarihi='" + dateTimePicker2.Value.ToString() + "' ,RESİM='" + textBox9.Text + "' where TC='" + textBox2.Text + "'", con);
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Lütfen Tüm  Alanları Doldurunuz");
                }
                else
                {
                    con.Open();
                    int sonuc = cmd.ExecuteNonQuery();
                    con.Close();
                    if (sonuc == 1)
                        MessageBox.Show("Güncelleme İşlemi Tamam");
                    else
                        MessageBox.Show("Güncelleme İşleminde Hata Oluştu!");
                    listele();
                }
              
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem!");
            }
        
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            da = new OleDbDataAdapter("select*from Hastalar where tc like '"+textBox10.Text+"%'", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            temizle();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1325, 644);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
