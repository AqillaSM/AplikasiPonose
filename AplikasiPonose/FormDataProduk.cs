using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AplikasiPonose
{
    public partial class FormDataProduk : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormDataProduk(string terima) : this()
        {
            if (terima.Length == 3)
            {
                IDAdmin = terima;
            }
            else if (terima.Length == 7)
            {
                IDAdmin = terima.Substring(0, 3);
                IDCustomer = terima.Substring(3);
            }
            else if (terima.Length == 16)
            {
                IDAdmin = terima.Substring(0, 3);
                IDNota = terima.Substring(3);
            }
            else
            {
                IDAdmin = terima.Substring(0, 3);
                IDCustomer = terima.Substring(3, 4);
                IDNota = terima.Substring(7);
            }
            All = terima;
        }

        public FormDataProduk()
        {
            InitializeComponent();
        }
        DataTable dtProduk = new DataTable();
        private void FotoDataProduk_Load(object sender, EventArgs e)
        {
            
            sqlQuery = "select ID_PRODUK as 'ID_PRODUCT', NAMA_PRODUK as 'PRODUCTNAME', KATEGORI_PRODUK AS 'CATEGORY', HARGA_JUAL AS 'HARGA JUAL', HARGA_POKOK AS 'HARGA POKOK' FROM DATA_PRODUK;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtProduk); // sampai sini
            DataGridProduk.DataSource = dtProduk;
        }

        private void TambahButton_Click(object sender, EventArgs e)
        {
            FormTambahProduk tambahProduk = new FormTambahProduk(All);
            tambahProduk.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtProduk.DefaultView;
            dv.RowFilter = "PRODUCTNAME LIKE '%" + SearchTextBox.Text + "%'";
            DataGridProduk.DataSource = dv;
        }
    }
}
