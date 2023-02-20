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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void btnKayitYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (hastaAd,hastaSoyad,hastaTC,hastaTelefon,hastaSifre,hastaCinsiyet) values (@1,@2,@3,@4,@5,@6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@1", txtAd.Text);
            komut.Parameters.AddWithValue("@2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@3", mskTC.Text);
            komut.Parameters.AddWithValue("@4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@5", txtSifre.Text);
            komut.Parameters.AddWithValue("@6", cmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Oluşturuldu Şifreniz:" + txtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
