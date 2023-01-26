using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Hastane
{
    internal class Class1
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("BLABLA");
            baglan.Open();
            return baglan;
        }
    }
}
