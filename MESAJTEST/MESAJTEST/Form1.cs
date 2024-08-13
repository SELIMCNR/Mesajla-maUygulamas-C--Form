using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MESAJTEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BC3LOP2\SQLEXPRESS;Initial Catalog=mesajapp;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_KISILER WHERE NUMARA=@P1 AND SIFRE=@P2", conn);
            komut.Parameters.AddWithValue("@P1", MskNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtŞifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 frm = new Form2();
                frm.numara = MskNumara.Text;
                frm.Show();

            }            
            else
            {
                MessageBox.Show("Hatalı Bilgi");
            }
            conn.Close();
        }
    }
}
