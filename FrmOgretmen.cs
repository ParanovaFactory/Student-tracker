using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖğrenciTakipSİS
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler fd = new FrmDersler();
            fd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup fk = new FrmKulup();
            fk.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSınav fs = new FrmSınav();
            fs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci fo = new FrmOgrenci();
            fo.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
