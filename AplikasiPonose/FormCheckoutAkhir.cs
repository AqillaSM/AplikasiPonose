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
    public partial class FormCheckoutAkhir : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;
        string Uang;
        string cara;
        string bayar;

        public FormCheckoutAkhir(string terima) : this()
        {
            IDAdmin = terima.Substring(0, 3);
            IDCustomer = terima.Substring(3, 4);
            IDNota = terima.Substring(7, 13);
            cara = terima.Substring(20, 1);
            bayar = terima.Substring(21, 1);
            Uang = terima.Substring(22);
            All = terima;
        }
        public FormCheckoutAkhir()
        {
            InitializeComponent();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void NewSalesButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }

        private void FormCheckoutAkhir_Load(object sender, EventArgs e)
        {
            KembalianLabel.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Uang)); ;
            tanggal = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            DataTable dtNama = new DataTable();
            sqlQuery = "select FIRST_NAME  from ADMIN where ID_ADMIN = '" + IDAdmin + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtNama); // sampai sini
            NamaAdmin = dtNama.Rows[0][0].ToString();

            
            sqlQuery = "select DATA_PRODUK.NAMA_PRODUK, DATA_PRODUK.HARGA_JUAL, DETAIL_SALES.JML_PRODUK, DETAIL_SALES.JML_PRODUK * DATA_PRODUK.HARGA_JUAL from DATA_PRODUK, DETAIL_SALES where DATA_PRODUK.ID_PRODUK = DETAIL_SALES.ID_PRODUK and DETAIL_SALES.ID_NOTA = '" + IDNota + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtMinuman); // sampai sini

            NamaMinuman = dtMinuman.Rows[0][0].ToString();
            Harga = dtMinuman.Rows[0][1].ToString() + " x " + dtMinuman.Rows[0][2].ToString();
            qtyharga = dtMinuman.Rows[0][3].ToString();

            sqlQuery = "select sum(JML_PRODUK * HARGA_PRODUK) from DETAIL_SALES where ID_NOTA = '" + IDNota + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtSubtotal); // sampai sini
            Subtotal = dtSubtotal.Rows[0][0].ToString();

            sqlQuery = "select TOTAL_POTONGAN,TOTAL_PAJAK, TOTAL_HARGA from SALES where ID_NOTA = '" + IDNota + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtSales); // sampai sini
            Potongan = dtSales.Rows[0][0].ToString();
            PPN = dtSales.Rows[0][1].ToString();
            GrandTotal = dtSales.Rows[0][2].ToString();

        }
        string tanggal;
        string NamaAdmin;
        string NamaMinuman;
        string Harga;
        string qtyharga;
        string Subtotal;
        string Potongan;
        string PPN;
        string GrandTotal;
        DataTable dtMinuman = new DataTable();
        DataTable dtSubtotal = new DataTable();
        DataTable dtSales = new DataTable();
        private void PrintButton_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Ponose Coffee", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(350, 50));
            e.Graphics.DrawString("Soho Natura BS 09", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(330, 80));
            e.Graphics.DrawString("Surabaya Kota, Jawa Timur", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(300, 110));
            e.Graphics.DrawString("Indonesia", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(380, 140));

            e.Graphics.DrawString("Waktu Penjualan", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, 250));
            e.Graphics.DrawString(tanggal, new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(580, 250));
            e.Graphics.DrawString("No. Nota", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, 280));
            e.Graphics.DrawString(IDNota, new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, 280));
            e.Graphics.DrawString("Kasir", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, 310));
            e.Graphics.DrawString(NamaAdmin, new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(750, 310));

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(0, 350));
            if(cara == "1")
            {
                e.Graphics.DrawString("DINE-IN", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(380, 380));
            }
            else
            {
                e.Graphics.DrawString("TAKE AWAY", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(380, 380));
            }

            int tinggi = 450;

            for(int i = 0; i < dtMinuman.Rows.Count; i++)
            {
                e.Graphics.DrawString(dtMinuman.Rows[i][0].ToString(), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                tinggi = tinggi + 20;
                e.Graphics.DrawString( Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtMinuman.Rows[i][1].ToString()))) + " x " + dtMinuman.Rows[i][2].ToString(), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(100, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtMinuman.Rows[i][3].ToString()))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
                tinggi = tinggi + 50;
            }
            tinggi = tinggi + 40;

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(0, tinggi));

            tinggi = tinggi + 30;
            e.Graphics.DrawString("Subtotal", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
            e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(Subtotal))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            tinggi = tinggi + 30;
            e.Graphics.DrawString("Disc", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
            e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(Potongan))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            tinggi = tinggi + 30;
            e.Graphics.DrawString("PPN", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
            e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(PPN))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));

            tinggi = tinggi + 40;
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(0, tinggi));

            tinggi = tinggi + 30;
            e.Graphics.DrawString("Grand Total", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
            e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(GrandTotal))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            tinggi = tinggi + 30;
            if(bayar == "0")
            {
                e.Graphics.DrawString("Cash", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", (Convert.ToInt64(Uang) + Convert.ToInt64(GrandTotal)))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
                tinggi = tinggi + 30;
                e.Graphics.DrawString("Kembalian", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(Uang))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            }
            else if (bayar == "1")
            {
                e.Graphics.DrawString("SHOPEEPAY", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", (Convert.ToInt64(Uang) + Convert.ToInt64(GrandTotal)))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
                tinggi = tinggi + 30;
                e.Graphics.DrawString("Kembalian", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString("Rp. 0", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            }
            else if (bayar == "2")
            {
                e.Graphics.DrawString("GOPAY", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", (Convert.ToInt64(Uang) + Convert.ToInt64(GrandTotal)))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
                tinggi = tinggi + 30;
                e.Graphics.DrawString("Kembalian", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString("Rp. 0", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            }
            else if (bayar == "3")
            {
                e.Graphics.DrawString("DANA", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", (Convert.ToInt64(Uang) + Convert.ToInt64(GrandTotal)))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(730, tinggi));
                tinggi = tinggi + 30;
                e.Graphics.DrawString("Kembalian", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString("Rp. 0", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));

            }
            else if (bayar == "4")
            {
                e.Graphics.DrawString("OVO", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", (Convert.ToInt64(Uang) + Convert.ToInt64(GrandTotal)))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
                tinggi = tinggi + 30;
                e.Graphics.DrawString("Kembalian", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString("Rp. 0", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            }
            else
            {
                e.Graphics.DrawString("BANK LAIN", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString(Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", (Convert.ToInt64(Uang) + Convert.ToInt64(GrandTotal)))), new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
                tinggi = tinggi + 30;
                e.Graphics.DrawString("Kembalian", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(10, tinggi));
                e.Graphics.DrawString("Rp. 0", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(700, tinggi));
            }
            
            

            tinggi = tinggi + 40;
            e.Graphics.DrawString("TERIMA KASIH", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(350, tinggi));
            tinggi = tinggi + 30;
            e.Graphics.DrawString("ATAS KUNJUNGAN ANDA", new Font("Montserrat", 14, FontStyle.Bold), Brushes.Black, new Point(300, tinggi));
        }
    }
}
