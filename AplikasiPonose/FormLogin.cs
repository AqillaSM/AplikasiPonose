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
    public partial class FormLogin : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string IDAdmin;
            DataTable dtLogin = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select USERNAME, PASSWORD, ID_ADMIN from ADMIN where STATUS_DELETE = 0 and USERNAME = '" + UsernameTextBox.Text + "' and PASSWORD = '" + PasswordTextBox.Text + "' limit 1; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtLogin);
            

            if (dtLogin.Rows.Count != 1) //kalo belum insert
            {
                MessageBox.Show("User tidak ditemukan");
                UsernameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
            else // kalo sudah update
            {
                IDAdmin = dtLogin.Rows[0][2].ToString();
                FormMenu menu = new FormMenu(IDAdmin);
                menu.Show();
                this.Hide();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = '*';
        }
    }
}
