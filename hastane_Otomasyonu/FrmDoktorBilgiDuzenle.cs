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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        private void btnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set doktorAd=@p1,doktorSoyad=@p2,doktorSifre=@p3,doktorBrans=@p4 where doktorTC=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",txtSifre.Text);
            komut.Parameters.AddWithValue("@p4", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");
        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        public string TC;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TC;
            SqlCommand komut=new SqlCommand("select * from Tbl_Doktorlar where doktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            SqlDataReader dr=komut.ExecuteReader();
            if (dr.Read())
            {
                txtAd.Text= dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                txtSifre.Text = dr[4].ToString();
                cmbBrans.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
