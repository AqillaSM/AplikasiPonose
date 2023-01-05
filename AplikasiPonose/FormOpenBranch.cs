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
    public partial class FormOpenBranch : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;
        string posisi;

        public FormOpenBranch(string terima) : this()
        {
            IDAdmin = terima;
            All = terima;
        }

        public FormOpenBranch()
        {
            InitializeComponent();
        }

        private void FormOpenBranch_Load(object sender, EventArgs e)
        {
            LabelTanggal.Text = DateTime.Now.ToString("D");
            DataTable dtAdmin = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select FIRST_NAME, LAST_NAME, POSITION from ADMIN where STATUS_DELETE = 0 and ID_ADMIN = '" + IDAdmin + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAdmin);
            LabelNama.Text = dtAdmin.Rows[0][0].ToString() + " " + dtAdmin.Rows[0][1].ToString();
            LabelPosisi.Text = "I'm a " + dtAdmin.Rows[0][2].ToString();
            posisi = dtAdmin.Rows[0][2].ToString();

            DataTable dtBranch = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select STORE_NAME as 'Other Branches' from PROFIL; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtBranch);
            DataBranch.DataSource = dtBranch;

            DataBranch.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            

        }
        string NamaToko;
        private void BackButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            int selectedrowindex = DataBranch.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
            DataGridViewRow selectedRow = DataBranch.Rows[selectedrowindex];
            NamaToko = Convert.ToString(selectedRow.Cells["Other Branches"].Value);
            All = All + '1' + NamaToko;
            FormOpen open = new FormOpen(All);
            open.Show();
            this.Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            All = All + '0';
            FormOpen open = new FormOpen(All);
            open.Show();
            this.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int selectedrowindex = DataBranch.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
            DataGridViewRow selectedRow = DataBranch.Rows[selectedrowindex];
            NamaToko = Convert.ToString(selectedRow.Cells["Other Branches"].Value);

            sqlConnect.Open();
            sqlQuery = "delete from PROFIL where STORE_NAME = '" + NamaToko + "' ;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            DataTable dtBranch = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select STORE_NAME as 'Other Branches' from PROFIL; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtBranch);
            DataBranch.DataSource = dtBranch;
        }
    }
}
