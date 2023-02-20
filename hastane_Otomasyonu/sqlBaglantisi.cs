using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hastane_Otomasyonu
{
     class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-864OGI4\\SQLEXPRESS;Initial Catalog=hastaneOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
