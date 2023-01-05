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
    public partial class FormTambahProduk : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormTambahProduk(string terima) : this()
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

        public FormTambahProduk()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormDataProduk dataProduk = new FormDataProduk(All);
            dataProduk.Show();
            this.Hide();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            DataTable dtCekProduk = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select NAMA_PRODUK from DATA_PRODUK where STATUS_DELETE = 0 and NAMA_PRODUK = '" + ProductNameTextBox.Text + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtCekProduk);

            if (Convert.ToInt32(HargaJualTextBox.Text) < Convert.ToInt32(HargaPokokTextBox.Text))
            {
                MessageBox.Show("Harga jual tidak boleh kurang dari harga pokok");
            }
            

            else if (dtCekProduk.Rows.Count != 1) //kalo belum insert
            {
                sqlConnect.Open();
                sqlQuery = "INSERT INTO DATA_PRODUK (NAMA_PRODUK, KATEGORI_PRODUK, HARGA_JUAL, HARGA_POKOK, STATUS_DELETE ) VALUES ('" + ProductNameTextBox.Text + "', '" + CategoryComboBox.Text + "', '" + HargaJualTextBox.Text + "', '" + HargaPokokTextBox.Text + "', 0);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();


                FormDataProduk dataProduk = new FormDataProduk(All);
                dataProduk.Show();
                this.Hide();
            }
            else // kalo sudah update
            {
                MessageBox.Show("Nama Produk sudah ada");
            }            
        }

        private void FormTambahProduk_Load(object sender, EventArgs e)
        {
            CategoryComboBox.Items.Add("Coffee");
            CategoryComboBox.Items.Add("Non-Coffee");

            
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtID = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select fIDProduct('" + CategoryComboBox.SelectedItem.ToString() + "');";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtID);

            ProductIDTextBox.Text = dtID.Rows[0][0].ToString();
            ProductIDTextBox.ReadOnly = true;
        }

        private void HargaJualTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void HargaPokokTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
