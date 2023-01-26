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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }
        Class1 bgl = new Class1();
        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            FrmHastaKayit frmky = new FrmHastaKayit();
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar(HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@h1,@h2,@h3,@h4,@h5,@h6)",bgl.baglanti());
            komut.Parameters.AddWithValue("@h1",txtAd.Text);
            komut.Parameters.AddWithValue("@h2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@h3", maskHastaTC.Text);
            komut.Parameters.AddWithValue("@h4", maskTelefon.Text);
            komut.Parameters.AddWithValue("@h5", txtHastaSifre.Text);
            komut.Parameters.AddWithValue("@h6", comboCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz :" + txtHastaSifre.Text , "Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
           if (dr == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
}
