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
using System.Data.Common;

namespace hastane_Otomasyonu
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string Tc;

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = Tc;
            //Ad Soyad Çekme Bölümü

            SqlCommand komut = new SqlCommand("Select hastaAd,hastaSoyad From Tbl_Hastalar Where hastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();



            // Randevu Geçmişi

            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where hastaTC=" + Tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource= dt;


            //veritabanından branş çekme

            SqlCommand komut2 = new SqlCommand("select bransAd from Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();


            //Doktorları çekme

           

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorAd,doktorSoyad from Tbl_Doktorlar where doktorBrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3= komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0]+" " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where randevuBrans='" +cmbBrans.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource= dt;
        }

        private void lnkBilgileriDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCno = lblTC.Text;
            fr.Show();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Randevular set randevuDurum=1,randevuTC=@p1,hastaSikayet=@p2 where randevuID=@p3",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            komut.Parameters.AddWithValue("@p2", rchSikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }
    }
}
