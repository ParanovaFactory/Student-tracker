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

namespace ÖğrenciTakipSİS
{
    public partial class Frmogrnotlar : Form
    {
        public Frmogrnotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-DU4I803;Initial Catalog=Okul;Integrated Security=True");
        public string numara;
        public string adsoyad;
        private void Frmogrnotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select Sınav1,Sınav2,Sınav3,Proje,Ortalama,Durum,Dersad from tblnotlar INNER JOIN tbldersler ON tblnotlar.Dersid = tbldersler.Dersid where Ogrid = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        //    ad soyad çekme
        //    SqlCommand komut2 = new SqlCommand("select ograd + ogrsoyad from tblogrenciler where ogrid = @p2", baglanti);
        //    komut2.Parameters.AddWithValue("@p2", numara);
        //    SqlDataAdapter da2 = new SqlDataAdapter(komut2);
        //    DataTable dt2 = new DataTable();
        //    da2.Fill(dt2);
        //    label1.Text = dt2;
        //    this.Text = label1.Text.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
