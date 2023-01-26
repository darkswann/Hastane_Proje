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
    public partial class FrmBilgiDuzenle : Form // Dark Swana'a Aittir // Dark Swana'a Aittir // Dark Swana'a Aittir // Dark Swana'a Aittir
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;

        Class1 bgn = new Class1();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e) // Dark Swana'a Aittir
        {
            maskHastaTC.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1",bgn.baglanti()); // Dark Swana'a Aittir
            komut.Parameters.AddWithValue("@p1",maskHastaTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                maskTelefon.Text = dr[4].ToString();
                txtHastaSifre.Text = dr[5].ToString();
                comboCinsiyet.Text = dr[6].ToString();
            }

            bgn.baglanti().Close();
        }

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar Set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6",bgn.baglanti()); // Dark Swana'a Aittir
            komut2.Parameters.AddWithValue("@p1",txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", maskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", txtHastaSifre.Text);
            komut2.Parameters.AddWithValue("@p5", comboCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", maskHastaTC.Text);
            komut2.ExecuteNonQuery();
            bgn.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
