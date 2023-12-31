﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SifreliVeriler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BJO2DGU\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * FROM TBLVERILER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = txAd.Text;
            byte[] addizi = ASCIIEncoding.ASCII.GetBytes(ad);
            string adsifre = Convert.ToBase64String(addizi);

            string soyad = txSoyad.Text;
            byte[] soyaddizi = ASCIIEncoding.ASCII.GetBytes(soyad);
            string soyadsifre = Convert.ToBase64String(soyaddizi);

            string mail = txMail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = txSifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = txHesapNo.Text;
            byte[] hesapdizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapsifre = Convert.ToBase64String(hesapdizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLVERILER (AD,SOYAD,MAIL,SIFRE,HESAPNO) values (@P1,@P2,@P3,@P4,@P5)",baglanti);
            komut.Parameters.AddWithValue("@P1", adsifre);
            komut.Parameters.AddWithValue("@P2", soyadsifre);
            komut.Parameters.AddWithValue("@P3", mailsifre);
            komut.Parameters.AddWithValue("@P4", sifresifre);
            komut.Parameters.AddWithValue("@P5", hesapsifre);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veriler Eklendi");
            listele();

        }

        private void txMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string txcozum = textBox1.Text;
            byte[] txcozumdizi = Convert.FromBase64String(txcozum);
            string txverisi = ASCIIEncoding.ASCII.GetString(txcozumdizi);
            label6.Text = txverisi;
        }
    }
}
