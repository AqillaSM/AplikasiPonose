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
    public partial class FormDataCust : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormDataCust(string terima) : this()
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

        public FormDataCust()
        {
            InitializeComponent();
        }
        DataTable dtMember = new DataTable();
        private void FormDataCust_Load(object sender, EventArgs e)
        {
            
            sqlQuery = "select ID_CUST, NAMA as NAME, ALAMAT as ADDRESS, NO_TELP from CUSTOMER;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtMember); // sampai sini
            DataGridMember.DataSource = dtMember;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            All = "1" + All;
            FormAddCust addCust = new FormAddCust(All);
            addCust.Show();
            this.Hide();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            DataTable dtIDNOTA = new DataTable();
            sqlQuery = "select fIDNota();";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtIDNOTA); // sampai sini
            IDNota = dtIDNOTA.Rows[0][0].ToString();


            int selectedrowindex = DataGridMember.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
            DataGridViewRow selectedRow = DataGridMember.Rows[selectedrowindex];
            string Kode = Convert.ToString(selectedRow.Cells["ID_CUST"].Value);
            sqlConnect.Open();
            sqlQuery = "insert into SALES (ID_CUST, ID_ADMIN, TOTAL_HARGA, PRINT_STATUS,STATUS_DELETE,TOTAL_POTONGAN, TOTAL_PAJAK ) values('"+Kode+"', '"+IDAdmin+"', 0, 0,0, 0, 0);";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            All = IDAdmin + Kode + IDNota;
            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtMember.DefaultView;
            dv.RowFilter = "Name LIKE '%" + SearchTextBox.Text + "%'";
            DataGridMember.DataSource = dv;
        }

        private void DataGridMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
