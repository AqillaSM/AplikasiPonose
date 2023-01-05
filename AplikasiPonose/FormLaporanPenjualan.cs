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
    public partial class FormLaporanPenjualan : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;
        string Bulan;

        public FormLaporanPenjualan(string terima) : this()
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

        public FormLaporanPenjualan()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void FormLaporanPenjualan_Load(object sender, EventArgs e)
        {
            var Date = DateTime.Now;
            string Tahun = Date.ToString("yyyy");
            TahunComboBox.SelectedItem = Tahun;
            TotalProfit.Text = "";
            TotalPenjualanBersih.Text = "";
            TotalHPP.Text = "";
        }


        private void BulanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerBulan();
        }
        
        private void PerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PerComboBox.SelectedItem == "Per Bulan")
            {
                BulanComboBox.Show();
                PerBulan();
            }
            else
            {
                PerTahun();
            }
        }

        private void TahunComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PerComboBox.SelectedItem == "Per Bulan")
            {
                PerBulan();
            }
            else if (PerComboBox.SelectedItem == "Per Tahun")
            {
                PerTahun();
            }           
        }

        private void PerTahun()
        {
            BulanComboBox.Hide();
            if (TahunComboBox.SelectedItem == null)
            {
            }
            else
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 5,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
        }

        private void PerBulan()
        {
            if (BulanComboBox.SelectedItem == "Januari")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '01' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '01' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Februari")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '02' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '02' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Maret")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '03' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '03' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "April")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '04' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '04' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini

                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Mei")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '05' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '05' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Juni")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '06' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '06' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Juli")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '07' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '07' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Agustus")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '08' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '08' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "September")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '09' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '09' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }

            }
            else if (BulanComboBox.SelectedItem == "Oktober")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '10' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '10' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "November")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '11' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;

                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '11' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
            else if (BulanComboBox.SelectedItem == "Desember")
            {
                DataTable dtLaporan = new DataTable();
                sqlQuery = "select concat(substring(DETAIL_SALES.ID_NOTA, 1,4), '-', substring(DETAIL_SALES.ID_NOTA, 5,2), '-', substring(DETAIL_SALES.ID_NOTA, 7,2)) as Tanggal, sum(DETAIL_SALES.SUBTOTAL_PRODUK) as Penjualan, sum(DETAIL_SALES.POTONGAN_PRODUK) as Potongan, sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as Profit from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5,2) = '12' and substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by substring(DETAIL_SALES.ID_NOTA, 7,2);";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtLaporan); // sampai sini
                DataGridLaporan.DataSource = dtLaporan;
                
                DataTable dtTotal = new DataTable();
                sqlQuery = "select sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) as 'Penjualan Bersih', sum(DATA_PRODUK.HARGA_POKOK) as 'Harga Pokok Penjualan', sum(DETAIL_SALES.SUBTOTAL_PRODUK) + sum(DETAIL_SALES.POTONGAN_PRODUK) - sum(DATA_PRODUK.HARGA_POKOK) as 'Profit'  FROM DETAIL_SALES, DATA_PRODUK WHERE substring(DETAIL_SALES.ID_NOTA, 5,2) = '12' AND substring(DETAIL_SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' ;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTotal); // sampai sini
                if (DataGridLaporan.Rows.Count == 1)
                {
                    TotalProfit.Text = "";
                    TotalPenjualanBersih.Text = "";
                    TotalHPP.Text = "";
                }
                else
                {

                    TotalPenjualanBersih.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][0].ToString())));
                    TotalHPP.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][1].ToString())));
                    TotalProfit.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtTotal.Rows[0][2].ToString())));
                }
            }
        }
    }
}
