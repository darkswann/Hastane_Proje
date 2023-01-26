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

namespace Proje_Hastane
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        Class1 bgl = new Class1();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTc=@h1 and DoktorSifre=@h2", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", maskDoktorTC.Text);
            komut.Parameters.AddWithValue("@h2", txtDoktorSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
               FrmDoktorDetay hstdty = new FrmDoktorDetay();
                hstdty.TC = maskDoktorTC.Text;
                hstdty.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC Kimlik veya Şifre");
            }
            bgl.baglanti().Close();
        }

    }
}
