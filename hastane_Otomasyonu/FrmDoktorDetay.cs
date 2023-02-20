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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl=new sqlBaglantisi();
        public string TC;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;

            // doktor Ad Soyad
            SqlCommand komut=new SqlCommand("select doktorAd,DoktorSoyad from Tbl_Doktorlar where doktorTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Randevu Listesi Getirme

            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where randevuDoktor='"+lblAdSoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource=dt;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frd = new FrmDoktorBilgiDuzenle();
            frd.TC = lblTC.Text;
            frd.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr= new FrmDuyurular();
            fr.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
