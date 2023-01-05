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
    public partial class DataPenjualan : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public DataPenjualan(string terima) : this()
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

        public DataPenjualan()
        {
            InitializeComponent();
        }
        DataTable dtPenjualan = new DataTable();
        private void DataPenjualan_Load(object sender, EventArgs e)
        {
            
            sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, DETAIL_SALES.ID_NOTA as 'NomorPenjualan', DATA_PRODUK.NAMA_PRODUK as 'Nama Produk', DATA_PRODUK.ID_PRODUK as 'Kode Produk', DETAIL_SALES.HARGA_PRODUK as 'Harga Produk', DETAIL_SALES.JML_PRODUK as 'QTY', DETAIL_SALES.POTONGAN_PRODUK as 'Potongan', DETAIL_SALES.SUBTOTAL_PRODUK as 'Total' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK =  DATA_PRODUK.ID_PRODUK;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPenjualan); // sampai sini
            DataGridPenjualan.DataSource = dtPenjualan;

            DataTable dtJmlSales = new DataTable();
            sqlQuery = "select * FROM DETAIL_SALES;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtJmlSales); // sampai sini

            int Angka = dtJmlSales.Rows.Count;
            LabelCount.Text = Convert.ToString(Angka) + " Sales";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtPenjualan.DefaultView;
            dv.RowFilter = "Tanggal LIKE '%" + SearchTextBox.Text + "%'";
            DataGridPenjualan.DataSource = dv;
        }
    }
}
