using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        
        Class1 bgl = new Class1();

        private void LnkUyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit kayit = new FrmHastaKayit();
            kayit.Show();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@h1 and HastaSifre=@h2", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", maskHastaTC.Text);
            komut.Parameters.AddWithValue("@h2", txtHastaSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay hstdty = new FrmHastaDetay();
                hstdty.tc = maskHastaTC.Text;
                hstdty.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC Kimlik veya Şifre");
            }
            bgl.baglanti().Close();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
