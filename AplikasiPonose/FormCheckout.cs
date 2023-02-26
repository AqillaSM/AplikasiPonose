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

namespace AplikasiPonose
{
    public partial class FormCheckout : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;
        string cara;

        public FormCheckout(string terima) : this()
        {

            IDAdmin = terima.Substring(0, 3);
            IDCustomer = terima.Substring(3, 4);
            IDNota = terima.Substring(7, 13);
            cara = terima.Substring(20);
            All = terima;
        }

        public FormCheckout()
        {
            InitializeComponent();
        }

        private void FormCheckout_Load(object sender, EventArgs e)
        {
            DataTable dtNota = new DataTable();
            sqlQuery = "select TOTAL_HARGA from SALES where ID_NOTA = '" + IDNota + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtNota); // sampai sini
            HargaLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtNota.Rows[0][0].ToString())));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }
        // 
        private void ChargeButton_Click(object sender, EventArgs e)
        {
            DataTable dtNotaa = new DataTable();
            sqlQuery = "select TOTAL_HARGA from SALES where ID_NOTA = '" + IDNota + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtNotaa); // sampai sini
            if (Convert.ToInt64(UangTextBox.Text) < Convert.ToInt64(dtNotaa.Rows[0][0].ToString()))
            {
                MessageBox.Show("Nominal uang kurang");
            }
            else
            {
                bayar = "0";
                DataTable dtNota = new DataTable();
                sqlQuery = "select TOTAL_HARGA from SALES where ID_NOTA = '" + IDNota + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtNota); // sampai sini
                string uangg = dtNota.Rows[0][0].ToString();
                int Uang = Convert.ToInt32(UangTextBox.Text) - Convert.ToInt32(uangg);
                All = All + bayar + Convert.ToString(Uang);
                FormCheckoutAkhir checkoutAkhir = new FormCheckoutAkhir(All);
                checkoutAkhir.Show();
                this.Hide();
            }
            
            
        }
        string bayar;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            UangTextBox.Text = "20000";
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            UangTextBox.Text = "50000";
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            UangTextBox.Text = "100000";
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            //shopee
            bayar = "1";
            All = All + bayar + "0";
            FormCheckoutAkhir checkoutAkhir = new FormCheckoutAkhir(All);
            checkoutAkhir.Show();
            this.Hide();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            //gopay
            bayar = "2";
            All = All + bayar + "0";
            FormCheckoutAkhir checkoutAkhir = new FormCheckoutAkhir(All);
            checkoutAkhir.Show();
            this.Hide();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            //dana
            bayar = "3";
            All = All + bayar + "0";
            FormCheckoutAkhir checkoutAkhir = new FormCheckoutAkhir(All);
            checkoutAkhir.Show();
            this.Hide();
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            //ovo
            bayar="4";
            All = All + bayar + "0";
            FormCheckoutAkhir checkoutAkhir = new FormCheckoutAkhir(All);
            checkoutAkhir.Show();
            this.Hide();
        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            //banklain
            bayar = "5";
            All = All + bayar + "0";
            FormCheckoutAkhir checkoutAkhir = new FormCheckoutAkhir(All);
            checkoutAkhir.Show();
            this.Hide();
        }

        private void UangTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UangTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}
