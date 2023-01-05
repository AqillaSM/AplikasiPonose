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
    public partial class FormEditUser : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormEditUser(string terima) : this()
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
                IDCustomer = terima.Substring(3, 3);

            }
            All = terima;
        }
        public FormEditUser()
        {
            InitializeComponent();
        }

        private void FormEditUser_Load(object sender, EventArgs e)
        {
            DataTable dtAdmin = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select concat(FIRST_NAME, ' ', LAST_NAME), ALAMAT_ADMIN, PHONE_NUMBER, ID_ADMIN, POSITION, `PASSWORD` FROM ADMIN WHERE ID_ADMIN = '" + IDCustomer + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAdmin);
            NamaTextBox.Text = dtAdmin.Rows[0][0].ToString();
            AlamatTextBox.Text = dtAdmin.Rows[0][1].ToString();
            TelfTextBox.Text = dtAdmin.Rows[0][2].ToString();
            IDTextBox.Text = dtAdmin.Rows[0][3].ToString();
            PosisiTextBox.Text = dtAdmin.Rows[0][4].ToString();
            PasswordTextBox.Text = dtAdmin.Rows[0][5].ToString();

            PasswordTextBox.PasswordChar = '*';
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void EditPosisiButton_Click(object sender, EventArgs e)
        {
            All = All + "6";
            FormEditInput editinput = new FormEditInput(All);
            editinput.Show();
            this.Hide();
        }

        private void EditPasswordButton_Click(object sender, EventArgs e)
        {
            All = All + "5";
            FormEditInput editinput = new FormEditInput(All);
            editinput.Show();
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = '*';
        }
    }
}
