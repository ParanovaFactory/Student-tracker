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
    public partial class FrmSınav : Form
    {
        public FrmSınav()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-DU4I803;Initial Catalog=Okul;Integrated Security=True");


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.tblnotlarTableAdapter ds = new DataSet1TableAdapters.tblnotlarTableAdapter();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Sınavnot(int.Parse(TxtId.Text));
        }

        private void FrmSınav_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From tbldersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "Dersad";
            CmbDers.ValueMember = "Dersid";
            CmbDers.DataSource = dt;
            baglanti.Close();
        }
        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int s1, s2, s3, prj;
        double ort;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
           
            s1 = Convert.ToInt32(TxtSınav1.Text);
            s2 = Convert.ToInt32(TxtSınav2.Text);
            s3 = Convert.ToInt32(TxtSınav3.Text);
            prj = Convert.ToInt32(TxtProje.Text);

            ort = (s1 + s2 + s3 + prj) / 4;
            TxtOrt.Text = ort.ToString();

            if (ort >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtDurum.Clear();
            TxtId.Clear();
            TxtOrt.Clear();
            TxtProje.Clear();
            TxtSınav1.Clear();
            TxtSınav2.Clear();
            TxtSınav3.Clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtId.Text), byte.Parse(s1.ToString()), byte.Parse(s2.ToString()), byte.Parse(s3.ToString()), byte.Parse(prj.ToString()), decimal.Parse(ort.ToString()), bool.Parse(TxtDurum.Text), notid);
            MessageBox.Show("Veriler Güncellendi");
        }
    }
}
