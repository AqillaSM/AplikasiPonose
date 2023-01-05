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
    public partial class FormInputTax : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormInputTax(string terima) : this()
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
        public FormInputTax()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlQuery = "update TAX set PERCENTAGE = " + TaxTextBox.Text + " where ID_TAX = 1;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void FormInputTax_Load(object sender, EventArgs e)
        {

        }

        private void TaxTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
