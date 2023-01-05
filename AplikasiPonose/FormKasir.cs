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
using System.Globalization;
using System.Text.RegularExpressions;

namespace AplikasiPonose
{
    public partial class FormKasir : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota = "";
        string All;

        public FormKasir(string terima) : this()
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

         //buat cek apakah sudah pernah beli atau belum
        
        public FormKasir()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if(IDNota != "")
            {
                sqlConnect.Open();
                sqlQuery = "delete from DETAIL_SALES where ID_NOTA = '" + IDNota + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                sqlConnect.Open();
                sqlQuery = "delete from SALES where ID_NOTA = '" + IDNota + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();
            }
            All = All.Substring(0, 3);
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void MemberButton_Click(object sender, EventArgs e)
        {
            FormDataCust dataCust = new FormDataCust(All);
            dataCust.Show();
            this.Hide();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (cara == "2")
            {
                MessageBox.Show("Dine-In / Takeaway?");
            }
            else
            {
                DataTable dtNota = new DataTable();
                sqlQuery = "select ID_NOTA, sum(POTONGAN_PRODUK), sum(SUBTOTAL_PRODUK) from DETAIL_SALES where ID_NOTA = '" + IDNota + "' group by ID_NOTA;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtNota); // sampai sini

                int Potongan = Convert.ToInt32(dtNota.Rows[0][1].ToString());
                int Total = Convert.ToInt32(dtNota.Rows[0][2].ToString());

                sqlConnect.Open();
                sqlQuery = "update SALES set TOTAL_POTONGAN = " + Potongan + ", TOTAL_PAJAK = " + Total + " * " + Taxx + " / 100 , TOTAL_HARGA = " + Total + " + TOTAL_PAJAK where ID_NOTA = '" + IDNota + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlCommand.ExecuteNonQuery();
                sqlConnect.Close();

                All = All + cara;
                FormCheckout checkout = new FormCheckout(All);
                checkout.Show();
                this.Hide();
            }
        }

        private void PromoButton_Click(object sender, EventArgs e)
        {
            FormPotongan potongan = new FormPotongan(All);
            potongan.Show();
            this.Hide();
        }


        private void AllButton_Click(object sender, EventArgs e)
        {
            DataTable dtAll = new DataTable();
            sqlQuery = "select NAMA_PRODUK as 'PRODUCT NAME', ID_PRODUK as 'PRODUCT ID', concat('RP. ' , HARGA_JUAL) as 'PRICE' from DATA_PRODUK;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAll); // sampai sini
            DatGridMenu.DataSource = dtAll;
        }

        private void CoffeeButton_Click(object sender, EventArgs e)
        {
            DataTable dtAll = new DataTable();
            sqlQuery = "select NAMA_PRODUK as 'PRODUCT NAME', ID_PRODUK as 'PRODUCT ID', concat('RP. ' , HARGA_JUAL) as 'PRICE' from DATA_PRODUK where substring(ID_PRODUK, 1, 1) like 'C%'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAll); // sampai sini
            DatGridMenu.DataSource = dtAll;
        }

        private void NonCoffeeButton_Click(object sender, EventArgs e)
        {
            DataTable dtAll = new DataTable();
            sqlQuery = "select NAMA_PRODUK as 'PRODUCT NAME', ID_PRODUK as 'PRODUCT ID', concat('RP. ' , HARGA_JUAL) as 'PRICE' from DATA_PRODUK where substring(ID_PRODUK, 1, 2) like 'NC%'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAll); // sampai sini
            DatGridMenu.DataSource = dtAll;
        }
        string Tax;
        double Taxx;
        private void FormKasir_Load(object sender, EventArgs e)
        {
            cara = "2";
            DataTable dtTax = new DataTable();
            sqlQuery = "select PERCENTAGE from TAX;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTax);
            Tax = dtTax.Rows[0][0].ToString();
            Taxx = Convert.ToInt32(Tax);
            LabelTanggal.Text = DateTime.Now.ToString("D");
            if (IDNota != "")
            {
                DataTable dtBills = new DataTable();
                sqlQuery = "select DATA_PRODUK.NAMA_PRODUK as 'PRODUCT NAME', DETAIL_SALES.JML_PRODUK AS 'QTY', DETAIL_SALES.SUBTOTAL_PRODUK AS 'PRICE' from DATA_PRODUK, DETAIL_SALES where ID_NOTA = '" + IDNota + "' and DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtBills); // sampai sini
                DataGridBills.DataSource = dtBills;

                DataTable dtMember = new DataTable(); //buat cek apakah sudah pernah beli atau belum
                sqlQuery = "select NAMA from CUSTOMER where ID_CUST = '" + IDCustomer + "'; ";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtMember);
                MemberButton.Text = dtMember.Rows[0][0].ToString();

                DataTable dtNota = new DataTable();
                sqlQuery = "select ID_NOTA, CEILING(sum(POTONGAN_PRODUK)), CEILING(sum(SUBTOTAL_PRODUK) + sum(SUBTOTAL_PRODUK) * 50/ 100) , CEILING(sum(SUBTOTAL_PRODUK) * 50/ 100) from DETAIL_SALES where ID_NOTA = '" + IDNota + "' group by ID_NOTA;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtNota); // sampai sini

                if (dtNota.Rows.Count != 1) //kalo belum insert
                {
                    PotonganFinalLabel.Text = "";
                    PPNLabel.Text = "";
                    TotalLabel.Text = "";
                }
                else // kalo sudah update
                {                    
                    PotonganFinalLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][1].ToString())));
                    PPNLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][3].ToString())));
                    TotalLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][2].ToString())));
                }
            }
            else
            {
                PotonganFinalLabel.Text = "";
                PPNLabel.Text = "";
                TotalLabel.Text = "";
            }
            DataTable dtAll = new DataTable();
            sqlQuery = "select NAMA_PRODUK as 'PRODUCT NAME', ID_PRODUK as 'PRODUCT ID', concat('RP. ' , HARGA_JUAL) as 'PRICE' from DATA_PRODUK;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAll); // sampai sini
            DatGridMenu.DataSource = dtAll;

            DataTable dtAdmin = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select FIRST_NAME, LAST_NAME, POSITION from ADMIN where STATUS_DELETE = 0 and ID_ADMIN = '" + IDAdmin + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAdmin);
            LabelNama.Text = dtAdmin.Rows[0][0].ToString() + " " + dtAdmin.Rows[0][1].ToString();
            PosisiLabel.Text = "I'm a " + dtAdmin.Rows[0][2].ToString();
        }

        private void ButtonAdd_Click_1(object sender, EventArgs e)
        {
            if (NumericMenu.Value == 0)
            {
                MessageBox.Show("Masukkan Jumlah");
            }
            else if(IDNota == "")
            {
                MessageBox.Show("Masukkan Data Customer");
            }
            else
            {
                int selectedrowindex = DatGridMenu.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
                DataGridViewRow selectedRow = DatGridMenu.Rows[selectedrowindex];
                string IDProduct = Convert.ToString(selectedRow.Cells["PRODUCT ID"].Value);
                string Harga = Convert.ToString(selectedRow.Cells["PRICE"].Value);

                DataTable dtCekTrans = new DataTable(); //buat cek apakah sudah pernah beli atau belum
                sqlQuery = "select ID_PRODUK from DETAIL_SALES where STATUS_DELETE = 0 and ID_PRODUK like '%" + IDProduct + "%' and ID_NOTA like '%" + IDNota + "%'; ";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtCekTrans);

                if (dtCekTrans.Rows.Count != 1) //kalo belum insert
                {
                    sqlConnect.Open();
                    sqlQuery = "insert into DETAIL_SALES values ('" + IDNota + "', '" + IDProduct + "', " + NumericMenu.Value + ", 0, 0, 0, 0);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                }
                else // kalo sudah update
                {
                    sqlConnect.Open();
                    sqlQuery = "update DETAIL_SALES set JML_PRODUK = JML_PRODUK + " + NumericMenu.Value + ", SUBTOTAL_PRODUK = HARGA_PRODUK*JML_PRODUK where STATUS_DELETE = 0 and ID_NOTA = '" + IDNota + "' and ID_PRODUK = '" + IDProduct + "';";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                }

                DataTable dtBills = new DataTable();
                sqlQuery = "select DATA_PRODUK.NAMA_PRODUK as 'PRODUCT NAME', DETAIL_SALES.JML_PRODUK AS 'QTY', DETAIL_SALES.SUBTOTAL_PRODUK AS 'PRICE' from DATA_PRODUK, DETAIL_SALES where ID_NOTA = '" + IDNota + "' and DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtBills); // sampai sini
                DataGridBills.DataSource = dtBills;

                DataTable dtNota = new DataTable();
                sqlQuery = "select ID_NOTA, CEILING(sum(POTONGAN_PRODUK)), CEILING(sum(SUBTOTAL_PRODUK) + sum(SUBTOTAL_PRODUK) * 50/ 100) , CEILING(sum(SUBTOTAL_PRODUK) * 50/ 100) from DETAIL_SALES where ID_NOTA = '" + IDNota + "' group by ID_NOTA;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtNota); // sampai sini

                PotonganFinalLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][1].ToString())));
                PPNLabel.Text = (String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][3].ToString()))).ToString();
                TotalLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][2].ToString())));
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int selectedrowindex = DataGridBills.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
            DataGridViewRow selectedRow = DataGridBills.Rows[selectedrowindex];
            string NamaProduk = Convert.ToString(selectedRow.Cells["PRODUCT NAME"].Value);

            DataTable dtHapus = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select ID_PRODUK from DATA_PRODUK where NAMA_PRODUK = '" + NamaProduk + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtHapus);
            string dihapus = dtHapus.Rows[0][0].ToString();

            sqlConnect.Open();
            sqlQuery = "delete from DETAIL_SALES where ID_PRODUK = '" + dihapus + "' and ID_NOTA = '"+ IDNota +"';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            DataTable dtBills = new DataTable();
            sqlQuery = "select DATA_PRODUK.NAMA_PRODUK as 'PRODUCT NAME', DETAIL_SALES.JML_PRODUK AS 'QTY', DETAIL_SALES.SUBTOTAL_PRODUK AS 'PRICE' from DATA_PRODUK, DETAIL_SALES where ID_NOTA = '" + IDNota + "' and DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtBills); // sampai sini
            DataGridBills.DataSource = dtBills;

            DataTable dtNota = new DataTable();
            sqlQuery = "select ID_NOTA, CEILING(sum(POTONGAN_PRODUK)), CEILING(sum(SUBTOTAL_PRODUK) + sum(SUBTOTAL_PRODUK) * 50/ 100) , CEILING(sum(SUBTOTAL_PRODUK) * 50/ 100) from DETAIL_SALES where ID_NOTA = '" + IDNota + "' group by ID_NOTA;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtNota); // sampai sini

            if (dtNota.Rows.Count < 1) //kalo belum insert
            {
                PotonganFinalLabel.Text = "";
                PPNLabel.Text = "";
                TotalLabel.Text = "";
            }
            else // kalo sudah update
            {
                PotonganFinalLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][1].ToString())));
                PPNLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][3].ToString())));
                TotalLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][2].ToString())));
            }
            
        }

        string cara;
        private void DineInButton_Click(object sender, EventArgs e)
        {
            cara = "1";
        }

        private void TakeAwayButton_Click(object sender, EventArgs e)
        {
            cara = "0";
        }
    }
}
