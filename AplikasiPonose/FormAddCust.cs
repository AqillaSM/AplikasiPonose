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
    public partial class FormAddCust : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormAddCust(string terima) : this()
        {
            if (terima.Length == 4)
            {
                IDAdmin = terima;
            }
            else if (terima.Length == 8)
            {
                IDAdmin = terima.Substring(1, 3);
                IDCustomer = terima.Substring(4);
            }
            else if (terima.Length == 17)
            {
                IDAdmin = terima.Substring(1, 3);
                IDNota = terima.Substring(4);
            }
            else
            {
                IDAdmin = terima.Substring(1, 3);
                IDCustomer = terima.Substring(4, 4);
                IDNota = terima.Substring(8);
            }
            All = terima;
        }

        public FormAddCust()
        {
            InitializeComponent();
        }

        string kode;


        private void BackButton_Click(object sender, EventArgs e)
        {
            if (All.Substring(0,1) == "1")
            {
                All = All.Substring(1);
                FormDataCust datacust = new FormDataCust(All);
                datacust.Show();
                this.Hide();
            }
            else
            {
                All = All.Substring(1);
                FormDataCustomer datacustomer = new FormDataCustomer(All);
                datacustomer.Show();
                this.Hide();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DataTable dtCekCust = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select NAMA, ALAMAT, NO_TELP from CUSTOMER where STATUS_DELETE = 0 and NAMA = '" + NameTextBox.Text + "' and ALAMAT = '" + AddressTextBox.Text + "' and NO_TELP = '" + NumberTextBox.Text + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtCekCust);

            if (dtCekCust.Rows.Count != 1) //kalo belum insert
            {
                sqlConnect.Open();
                sqlQuery = "INSERT INTO CUSTOMER (NAMA, ALAMAT, NO_TELP, STATUS_DELETE ) VALUES ('" + NameTextBox.Text + "', '" + AddressTextBox.Text + "', '" + NumberTextBox.Text + "', 0);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
            else // kalo sudah update
            {
                MessageBox.Show("Customer sudah ada");
            }

            if (All.Substring(0,1) == "1")
            {
                All = All.Substring(1);
                FormDataCust datacust = new FormDataCust(All);
                datacust.Show();
                this.Hide();
            }
            else
            {
                All = All.Substring(1);
                FormDataCustomer datacustomer = new FormDataCustomer(All);
                datacustomer.Show();
                this.Hide();
            }
        }

        private void FormAddCust_Load(object sender, EventArgs e)
        {
            if (All.Substring(0, 1) == "1")
            {
                PanelCust.Visible = true;
                PanelCustomer.Visible = false;
            }
            else
            {
                PanelCustomer.Visible = true;
                PanelCust.Visible = false;
            }

            DataTable dtID = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select fIDCust();";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtID);

            CustomerIDTextBox.Text = dtID.Rows[0][0].ToString();
            CustomerIDTextBox.ReadOnly = true;
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            if (All.Substring(0,1) == "1")
            {
                All = All.Substring(1);
                FormDataCust datacust = new FormDataCust(All);
                datacust.Show();
                this.Hide();
            }
            else
            {
                All = All.Substring(1);
                FormDataCustomer datacustomer = new FormDataCustomer(All);
                datacustomer.Show();
                this.Hide();
            }
        }

        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
