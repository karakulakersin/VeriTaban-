using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        
       
        public Form1()  
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection
            ("server=localHost; port=5432; Database=sd; user ID=postgres; password=123123123");
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from \"YemekSirketi\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvData.DataSource = ds.Tables[0];
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into \"YemekSirketi\" (\"Adi\", \"KurulusTarihi\", \"Numarasi\",\"SirketNo\") values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", txtName.Text);
            komut1.Parameters.AddWithValue("@p2", txtYear.Text);
            komut1.Parameters.AddWithValue("@p3", txtPhone.Text);
            komut1.Parameters.AddWithValue("@p4", txtNoOfCompany.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni veriler eklendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DataTable tbl = new DataTable();
            NpgsqlDataAdapter ara = new NpgsqlDataAdapter("Select * From \"YemekSirketi\" where \"Adi\" like '%" + textBox1.Text + "%'", baglanti);
            ara.Fill(tbl);
            baglanti.Close();
            dgvData.DataSource = tbl;
        }

        private void txtMidname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete From \"YemekSirketi\" where \"SirketNo\" = @p4", baglanti);
            komut2.Parameters.AddWithValue("@p4", txtNoOfCompany.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Şirket silinmiştir.");
        }
       
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update \"YemekSirketi\" set \"Adi\" = @p1, \"KurulusTarihi\" = @p2, \"Numarasi\" = @p3 where \"SirketNo\" = @p4", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtName.Text);
            komut3.Parameters.AddWithValue("@p2", txtYear.Text);
            komut3.Parameters.AddWithValue("@p3", txtPhone.Text);
            komut3.Parameters.AddWithValue("@p4", txtNoOfCompany.Text);
            komut3.ExecuteNonQuery();
            MessageBox.Show("Şirket güncellendi.");
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
