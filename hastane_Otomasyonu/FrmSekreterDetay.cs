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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string TCnumara;
        //public string sifretxt;
        sqlBaglantisi bgl =new sqlBaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text= TCnumara;
            //lblAdSoyad.Text= sifretxt;
            SqlCommand komut1 = new SqlCommand("select sekreterAdSoyad from Tbl_Sekreter where sekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();
            ////////////////////////////
            //Doktorları ComboBox a ekleme formun load ından

            SqlCommand kmt = new SqlCommand("select doktorAd,doktorSoyad from Tbl_Doktorlar", bgl.baglanti());
            SqlDataReader sdr = kmt.ExecuteReader();
            while (sdr.Read())
            {
                cmbDoktor.Items.Add(sdr[0]+" "+ sdr[1]);
                
            }
            bgl.baglanti().Close();

            ////////////////////////////
            /////Branşları ComboBox a ekleme formun load ından
            SqlCommand komut = new SqlCommand("select bransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

            // Bransları DataGrid e aktarma

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            //Doktorları Listeye Aktarma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorAd+' '+doktorSoyad),doktorBrans from Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp=new FrmDoktorPaneli();
            drp.Show();
            
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            FrmBrans frb=new FrmBrans();
            frb.Show();
        }

        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frl=new FrmRandevuListesi();
            frl.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frd=new FrmDuyurular();
            frd.Show();
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
