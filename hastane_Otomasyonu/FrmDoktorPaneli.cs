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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            //Doktorları Listeye Aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // bransları combobox a ekleme

            SqlCommand komut = new SqlCommand("select bransAd from Tbl_Branslar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbBrans.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

            ////////////////////////////
            
            ////////////////////////////
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("insert into Tbl_Doktorlar (doktorAd,doktorSoyad,doktorTC,doktorSifre,doktorBrans) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtAd.Text);
            komut.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", mskTC.Text);
            komut.Parameters.AddWithValue("@d4", txtSifre.Text);
            komut.Parameters.AddWithValue("@d5", cmbBrans.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Delete from Tbl_Doktorlar where doktorTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", mskTC.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Doktorlar set doktorAd=@d1,doktorSoyad=@d2,doktorSifre=@d4," +
                "doktorBrans=@d5 where doktorTC=@d3",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", txtAd.Text);
            komut.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", mskTC.Text);
            komut.Parameters.AddWithValue("@d4", txtSifre.Text);
            komut.Parameters.AddWithValue("@d5", cmbBrans.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
