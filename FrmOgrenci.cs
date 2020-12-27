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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.tblogrencilerTableAdapter ds = new DataSet1TableAdapters.tblogrencilerTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-DU4I803;Initial Catalog=Okul;Integrated Security=True");
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.tblOgrenciler();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tblkulup", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulüp.DisplayMember = "KulüpAd";
            CmbKulüp.ValueMember = "kulupid";
            CmbKulüp.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtOgrId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulüp.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.tblOgrenciler();
        }
        string cinsiyet = "";

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrAd.Text, TxtOgrSoyad.Text, byte.Parse(CmbKulüp.SelectedValue.ToString()), cinsiyet, int.Parse (TxtOgrId.Text));
            MessageBox.Show("Bilgiler Güncellendi");
        }
        
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciKayıt(TxtOgrAd.Text,TxtOgrSoyad.Text, byte.Parse(CmbKulüp.SelectedValue.ToString()), cinsiyet);
            MessageBox.Show("Öğrenci Eklendi");

        }

        private void CmbKulüp_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtOgrId.Text = CmbKulüp.SelectedValue.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrId.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cinsiyet = "Kız";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                cinsiyet = "Erkek";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = ds.Ogrenciara(Txtara.Text);
        }
    }
}
