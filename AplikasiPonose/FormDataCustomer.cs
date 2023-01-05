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
    public partial class FormDataCustomer : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormDataCustomer(string terima) : this()
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
        string posisi;
        public FormDataCustomer()
        {
            InitializeComponent();
        }
        DataTable dtMember = new DataTable();
        private void FormDataCustomer_Load(object sender, EventArgs e)
        {
            DataTable dtAdmin = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select FIRST_NAME, LAST_NAME, POSITION from ADMIN where STATUS_DELETE = 0 and ID_ADMIN = '" + IDAdmin + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAdmin);
            posisi = dtAdmin.Rows[0][2].ToString();
            if (posisi != "Owner")
            {
                DeleteButton.Enabled = false;
            }

            sqlQuery = "select ID_CUST as ID, Nama, Alamat, NO_TELP as 'Telp 1' from CUSTOMER where STATUS_DELETE = 0;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtMember); // sampai sini
            DataGridCustomer.DataSource = dtMember;
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            All = "0" + All;
            FormAddCust addCust = new FormAddCust(All);
            addCust.Show();
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
            DataView dv = dtMember.DefaultView;
            dv.RowFilter = "Nama LIKE '%" + SearchTextBox.Text + "%'";
            DataGridCustomer.DataSource = dv;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            int selectedrowindex = DataGridCustomer.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
            DataGridViewRow selectedRow = DataGridCustomer.Rows[selectedrowindex];
            string ID = Convert.ToString(selectedRow.Cells["ID"].Value);

            sqlConnect.Open();
            sqlQuery = "update CUSTOMER set STATUS_DELETE = 1 where ID_CUST = '" + ID + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            DataTable dt = new DataTable();
            DataGridCustomer.DataSource = null;
            sqlQuery = "select ID_CUST as ID, Nama, Alamat, NO_TELP as 'Telp 1' from CUSTOMER where STATUS_DELETE = 0;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dt); // sampai sini
            DataGridCustomer.DataSource = dt;
        }
    }
}
