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

namespace MESAJTEST
{
    public partial class Form2 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BC3LOP2\SQLEXPRESS;Initial Catalog=mesajapp;Integrated Security=True;");

        public Form2()
        {
            InitializeComponent();
        }

        public string numara;


        void gelenKutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From TBL_MESAJLAR WHERE ALICI="+numara,conn);
            DataTable dt = new DataTable();
            da2.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void gidenKutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From TBL_MESAJLAR WHERE GONDEREN=" + numara, conn);
            DataTable dt = new DataTable();
            da2.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;

            gelenKutusu();
            gidenKutusu();


            conn.Open();
            SqlCommand komut = new SqlCommand("Select AD,SOYAD FROM TBL_KISILER where NUMARA=" + numara, conn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + ""+dr[1];

            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_MESAJLAR (GONDEREN,ALICI,BASLIK,ICERIK) values (@p1,@p2,@p3,@p4)",conn);

            komut.Parameters.AddWithValue("@p1", numara);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.Parameters.AddWithValue("@p4", richTextBox1.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Mesajınız iletildi");
            gidenKutusu();


        }
    }
}
