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
    public partial class FormAddAdmin : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormAddAdmin(string terima) : this()
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

        public FormAddAdmin()
        {
            InitializeComponent();
        }

        private void FormAddAdmin_Load(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DataTable dtCekUsername = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select USERNAME from ADMIN where STATUS_DELETE = 0 and USERNAME = '" + UsernameTextbox.Text + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtCekUsername);
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Password salah");
            }
            else if (dtCekUsername.Rows.Count != 1) //kalo belum insert
            {
                sqlConnect.Open();
                sqlQuery = "INSERT INTO ADMIN (USERNAME, `PASSWORD`, FIRST_NAME, LAST_NAME, POSITION, PHONE_NUMBER, ALAMAT_ADMIN, ACCESS_LEVEL, STATUS_DELETE ) VALUES ('" + UsernameTextbox.Text + "', '" + PasswordTextBox.Text + "', '" + FirstNamaTextBox.Text + "', '" + LastNamaTextBox.Text + "', '" + PositionTextBox.Text + "', '" + TelfTextBox.Text + "', '" + AlamatTextBox.Text + "', 1 , 0);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                FormMenu menu = new FormMenu(All);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username sudah ada");
            }

            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = '*';
        }

        private void ConfirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            ConfirmPasswordTextBox.PasswordChar = '*';
        }

        private void TelfTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TelfTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
