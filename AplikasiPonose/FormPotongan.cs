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
    public partial class FormPotongan : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormPotongan(string terima) : this()
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
        public FormPotongan()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }

        private void FormPotongan_Load(object sender, EventArgs e)
        {
            DataTable dtBills = new DataTable();
            sqlQuery = "select DATA_PRODUK.NAMA_PRODUK AS 'Nama', DETAIL_SALES.ID_PRODUK as 'ID' from DATA_PRODUK, DETAIL_SALES where ID_NOTA = '" + IDNota + "' and DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtBills); // sampai sini
            ProdukComboBox.DataSource = dtBills;
            ProdukComboBox.DisplayMember = "Nama";
            ProdukComboBox.ValueMember = "ID";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (PotonganRP.Text == "")
            {
                sqlConnect.Open();
                sqlQuery = "update DETAIL_SALES set POTONGAN_PRODUK = HARGA_PRODUK * " + PotonganPersen.Text + " / 100, SUBTOTAL_PRODUK = SUBTOTAL_PRODUK - POTONGAN_PRODUK where STATUS_DELETE = 0 and ID_NOTA = '" + IDNota + "' and ID_PRODUK = '" + ProdukComboBox.SelectedValue.ToString() + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
            else
            {
                sqlConnect.Open();
                sqlQuery = "update DETAIL_SALES set POTONGAN_PRODUK = " + PotonganRP.Text + ", SUBTOTAL_PRODUK = SUBTOTAL_PRODUK - POTONGAN_PRODUK where STATUS_DELETE = 0 and ID_NOTA = '" + IDNota + "' and ID_PRODUK = '" + ProdukComboBox.SelectedValue.ToString() + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }

            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }

        private void PotonganPersen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void PotonganRP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
