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

namespace hastane_Otomasyonu
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("select * from Tbl_Sekreter where sekreterTc=@p1 and sekreterSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.TCnumara = mskTC.Text;
                //frs.sifretxt= txtSifre.Text;
                frs.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre");
            }
            bgl.baglanti().Close();
        }
    }
}
