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
    public partial class FormGrafik : Form
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
        string Tahun;
        string Tanggal;
        

        public FormGrafik(string terima) : this()
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

        public FormGrafik()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            
        }

        private void FormGrafik_Load(object sender, EventArgs e)
        {
            PanelMingguan.Hide();
            PanelPerbulan.Hide();
            PanelTopProduct.Hide();
            
            var Date = DateTime.Now;
            Bulan = Date.ToString("MM");
            Tahun = Date.ToString("yyyy");
            TahunComboBox.SelectedItem = Tahun;

            DataTable dtAtas = new DataTable();
            sqlQuery = "select sum(TOTAL_HARGA), count(ID_CUST)  from SALES where substring(SALES.ID_NOTA, 5,2) = '"+ Bulan + "' and substring(SALES.ID_NOTA, 1,4) = '" + Tahun + "'   group by substring(SALES.ID_NOTA, 5,2);";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAtas); // sampai sini

            DataTable dtAtasS = new DataTable();
            sqlQuery = "select sum(JML_PRODUK)  from DETAIL_SALES where substring(ID_NOTA, 5,2) = '" + Bulan + "' and substring(ID_NOTA, 1,4) = '" + Tahun + "'   group by substring(ID_NOTA, 5,2);";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtAtasS); // sampai sini

            TotalCustomer.Text = dtAtas.Rows[0][1].ToString(); 
            TotalProducts.Text = dtAtasS.Rows[0][0].ToString();
            TotalSales.Text = Convert.ToString(String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N}", Convert.ToInt64(dtAtas.Rows[0][0].ToString())));

            ComboBox();


        }

        private void PilihGrafikComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox();
            if (PilihGrafikComboBox.SelectedItem == "Penjualan Harian/ 1 Bulan")
            {
                PanelMingguan.Hide();
                PanelPerbulan.Show();
                PanelTopProduct.Hide();
            }
            else if (PilihGrafikComboBox.SelectedItem == "Penjualan / Tahun")
            {
                PanelMingguan.Show();
                PanelPerbulan.Hide();
                PanelTopProduct.Hide();
            }
            else
            {
                PanelMingguan.Hide();
                PanelPerbulan.Hide();
                PanelTopProduct.Show();
            }
        }

        private void ChartTopProduct_Click(object sender, EventArgs e)
        {

        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void BulanComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox();
            
        }

        private void TahunComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox();
        }

        private void ComboBox()
        {
            if (PilihGrafikComboBox.SelectedItem == "Penjualan Harian/ 1 Bulan")

            {
                PanelPerbulan.Show();
                BulanComboBox.Show();
                ChartPenjualanHarian.Series["Series1"].Points.Clear();

                if (BulanComboBox.SelectedItem == "Januari")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '01' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini
                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Februari")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '02' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Maret")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '03' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "April")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '04' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Mei")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '05' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Juni")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '06' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Juli")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '07' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Agustus")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '08' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "September")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '09' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Oktober")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '10' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "November")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '11' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Desember")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 7,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "' and substring(SALES.ID_NOTA, 5,2) = '12' group by substring(SALES.ID_NOTA, 7,2);";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartPenjualanHarian.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
            }
            else if (PilihGrafikComboBox.SelectedItem == "Top Product")
            {
                BulanComboBox.Show();
                PanelTopProduct.Show();
                ChartTopProduct.Series["Series1"].Points.Clear();
                if (BulanComboBox.SelectedItem == "Januari")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '01' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Februari")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '02 and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Maret")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '03' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "April")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '04' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Mei")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '05' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Juni")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '06' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Juli")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '07' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Agustus")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '08' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "September")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '09' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Oktober")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '10' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "November")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '11' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }
                else if (BulanComboBox.SelectedItem == "Desember")
                {
                    DataTable dtTopProduct = new DataTable();
                    sqlQuery = "select count(DETAIL_SALES.ID_PRODUK) as 'Jumlah', DATA_PRODUK.NAMA_PRODUK as 'Nama' from DETAIL_SALES, DATA_PRODUK where DETAIL_SALES.ID_PRODUK = DATA_PRODUK.ID_PRODUK and substring(DETAIL_SALES.ID_NOTA, 5, 2) = '12' and substring(DETAIL_SALES.ID_NOTA, 1, 4) = '" + TahunComboBox.SelectedItem.ToString() + "' group by DETAIL_SALES.ID_PRODUK order by 1 desc limit 5;";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtTopProduct); // sampai sini

                    for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                    {
                        ChartTopProduct.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt16(dtTopProduct.Rows[i][0].ToString()));
                    }
                }

                ChartTopProduct.Series["Series1"].IsValueShownAsLabel = true;
            }
            else if (PilihGrafikComboBox.SelectedItem == "Penjualan / Tahun")
            {
                PanelMingguan.Show();
                BulanComboBox.Hide();
                ChartMingguan.Series["Series1"].Points.Clear();                
                DataTable dtTopProduct = new DataTable();
                sqlQuery = "select sum(TOTAL_HARGA), substring(SALES.ID_NOTA, 5,2) from SALES where substring(SALES.ID_NOTA, 1,4) = '" + TahunComboBox.SelectedItem.ToString() + "'  group by substring(SALES.ID_NOTA, 5,2) limit 5;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTopProduct); // sampai sini

                for (int i = 0; i < dtTopProduct.Rows.Count; i++)
                {
                    ChartMingguan.Series["Series1"].Points.AddXY(dtTopProduct.Rows[i][1].ToString(), Convert.ToInt64(dtTopProduct.Rows[i][0].ToString()));
                }
            }
        }
    }
}
