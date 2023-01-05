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
    public partial class FormMenu : Form
    {

        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;

        public FormMenu(string terima) : this()
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

        public FormMenu()
        {
            InitializeComponent();
            PanelAccount.Hide();
            PosisiPanel.Show();
            DashboardPanel.Show();
            SettingsPanel.Hide();
        }

        string posisi;

        private void FormMenu_Load(object sender, EventArgs e)
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

            AccNamaLabel.Text = dtAdmin.Rows[0][0].ToString() + " " + dtAdmin.Rows[0][1].ToString();
            AccPosisiLabel.Text = "I'm a " + dtAdmin.Rows[0][2].ToString();
            AccPccLabel.Text = dtAdmin.Rows[0][2].ToString();
            if(dtAdmin.Rows[0][2].ToString() == "Owner")
            {
                AccLevelLabel.Text = "2";
            }
            else
            {
                AccLevelLabel.Text = "1";
            }

            if(posisi != "Owner")
            {
                AccountButton.Enabled = false;
                SettingsButton.Enabled = false;
            }
            
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            if (posisi == "Cashier")
            {
                MessageBox.Show("Hanya owner yang dapat membuka");
            }
            else
            {
                PosisiPanel.Hide();
                SettingsPanel.Hide();
                DashboardPanel.Hide();
                PanelAccount.Show();
                DataTable dtAdmin = new DataTable();
                sqlQuery = "select ID_ADMIN as ID, USERNAME from ADMIN;";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtAdmin); // sampai sini
                DataGridAdmin.DataSource = dtAdmin;
            }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            PanelAccount.Hide();
            PosisiPanel.Show();
            DashboardPanel.Show();
            SettingsPanel.Hide();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if(posisi == "Cashier")
            {
                MessageBox.Show("Hanya owner yang dapat membuka");
            }
            else
            {
                PanelAccount.Hide();
                PosisiPanel.Show();
                DashboardPanel.Hide();
                SettingsPanel.Show();
                Settings();
            }
            
        }

        private void DataPenjualanButton_Click(object sender, EventArgs e)
        {
            DataPenjualan dataPenjualan = new DataPenjualan(All);
            dataPenjualan.Show();
            this.Hide();
        }

        private void KasirButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormKasir kasir = new FormKasir(All);
            kasir.Show();
            this.Hide();
        }

        private void LaporanPenjualanButton_Click(object sender, EventArgs e)
        {
            FormLaporanPenjualan laporanPenjualan = new FormLaporanPenjualan(All);
            laporanPenjualan.Show();
            this.Hide();
        }

        private void GrafikButton_Click(object sender, EventArgs e)
        {
            FormGrafik grafik = new FormGrafik(All);
            grafik.Show();
            this.Hide();
        }

        private void DataProdukButton_Click(object sender, EventArgs e)
        {
            FormDataProduk dataProduk = new FormDataProduk(All);
            dataProduk.Show();
            this.Hide();
        }

        private void DataCustomerButton_Click(object sender, EventArgs e)
        {
            FormDataCustomer dataCustomer = new FormDataCustomer(All);
            dataCustomer.Show();
            this.Hide();
        }

        private void EditAdminButton_Click(object sender, EventArgs e)
        {
            int selectedrowindex = DataGridAdmin.SelectedCells[0].RowIndex; // code mindah selected datagrid ke string
            DataGridViewRow selectedRow = DataGridAdmin.Rows[selectedrowindex];
            string Kode = Convert.ToString(selectedRow.Cells["ID"].Value);

            All = IDAdmin + Kode;
            FormEditUser edituser = new FormEditUser(All);
            edituser.Show();
            this.Hide();
        }

        private void TambahAdminButton_Click(object sender, EventArgs e)
        {
            FormAddAdmin addAdmin = new FormAddAdmin(All);
            addAdmin.Show();
            this.Hide();
        }

        private void SettingsPanel_Paint(object sender, PaintEventArgs e)
        {
            
           
        }

        public void Settings()
        {
            DataTable dtProfil = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select * from PROFIL limit 1; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtProfil);

            SettingsPanel.Controls.Clear();
            SettingsPanel.AutoScroll = false;
            SettingsPanel.VerticalScroll.Enabled = true;
            SettingsPanel.VerticalScroll.Visible = true;

            SettingsPanel.AutoScroll = true;

            Label ProfilToko = new Label();
            ProfilToko.Text = "Profil Toko";
            ProfilToko.Location = new Point(40, 40);
            ProfilToko.Size = new Size(300, 50);
            ProfilToko.Font = new Font("montserrat", 30, FontStyle.Bold);
            ProfilToko.TextAlign = ContentAlignment.TopCenter;
            ProfilToko.BackColor = Color.Transparent;
            ProfilToko.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(ProfilToko);

            Label NamaToko = new Label();
            NamaToko.Text = "Nama Toko";
            NamaToko.Size = new Size(300, 50);
            NamaToko.Font = new Font("montserrat", 20, FontStyle.Regular);
            NamaToko.TextAlign = ContentAlignment.TopLeft;
            NamaToko.BackColor = Color.Transparent;
            NamaToko.ForeColor = Color.Black;
            NamaToko.Location = new Point(125, 150);
            SettingsPanel.Controls.Add(NamaToko);

            Nama.Text = dtProfil.Rows[0][1].ToString();
            Nama.Location = new Point(150, 200);
            Nama.Size = new Size(500, 100);
            Nama.Font = new Font("montserrat", 20, FontStyle.Regular);
            Nama.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Nama);

            Label Alamat = new Label();
            Alamat.Text = "Alamat";
            Alamat.Size = new Size(300, 50);
            Alamat.Font = new Font("montserrat", 20, FontStyle.Regular);
            Alamat.TextAlign = ContentAlignment.TopLeft;
            Alamat.BackColor = Color.Transparent;
            Alamat.ForeColor = Color.Black;
            Alamat.Location = new Point(125, 250);
            SettingsPanel.Controls.Add(Alamat);

            Address.Text = dtProfil.Rows[0][3].ToString();
            Address.Location = new Point(150, 300);
            Address.Size = new Size(500, 100);
            Address.Font = new Font("montserrat", 20, FontStyle.Regular);
            Address.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Address);


            Label NPWP = new Label();
            NPWP.Text = "NPWP";
            NPWP.Location = new Point(125, 350);
            NPWP.Size = new Size(300, 50);
            NPWP.Font = new Font("montserrat", 20, FontStyle.Regular);
            NPWP.TextAlign = ContentAlignment.TopLeft;
            NPWP.BackColor = Color.Transparent;
            NPWP.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(NPWP);

            NoNPWP.Text = dtProfil.Rows[0][2].ToString();
            NoNPWP.Location = new Point(150, 400);
            NoNPWP.Size = new Size(500, 100);
            NoNPWP.Font = new Font("montserrat", 20, FontStyle.Regular);
            NoNPWP.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(NoNPWP);


            Label Email = new Label();
            Email.Text = "Email";
            Email.Location = new Point(125, 450);
            Email.Size = new Size(300, 50);
            Email.Font = new Font("montserrat", 20, FontStyle.Regular);
            Email.TextAlign = ContentAlignment.TopLeft;
            Email.BackColor = Color.Transparent;
            Email.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Email);

            AlamatEmail.Text = dtProfil.Rows[0][5].ToString();
            AlamatEmail.Location = new Point(150, 500);
            AlamatEmail.Size = new Size(500, 100);
            AlamatEmail.Font = new Font("montserrat", 20, FontStyle.Regular);
            AlamatEmail.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(AlamatEmail);


            Label Telf1 = new Label();
            Telf1.Text = "No. Telp";
            Telf1.Location = new Point(125, 550);
            Telf1.Size = new Size(300, 50);
            Telf1.Font = new Font("montserrat", 20, FontStyle.Regular);
            Telf1.TextAlign = ContentAlignment.TopLeft;
            Telf1.BackColor = Color.Transparent;
            Telf1.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Telf1);

            NoTelf1.Text = dtProfil.Rows[0][4].ToString();
            NoTelf1.Location = new Point(150, 600);
            NoTelf1.Size = new Size(500, 100);
            NoTelf1.Font = new Font("montserrat", 20, FontStyle.Regular);
            NoTelf1.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(NoTelf1);

            Label RekeningBank = new Label();
            RekeningBank.Text = "Rekening Bank 1";
            RekeningBank.Location = new Point(125, 650);
            RekeningBank.Size = new Size(300, 50);
            RekeningBank.Font = new Font("montserrat", 20, FontStyle.Regular);
            RekeningBank.TextAlign = ContentAlignment.TopLeft;
            RekeningBank.BackColor = Color.Transparent;
            RekeningBank.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(RekeningBank);

            Rekening.Text = dtProfil.Rows[0][6].ToString();
            Rekening.Location = new Point(150, 700);
            Rekening.Size = new Size(500, 100);
            Rekening.Font = new Font("montserrat", 20, FontStyle.Regular);
            Rekening.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Rekening);

            Label NamaBank = new Label();
            NamaBank.Text = "Nama Bank 1";
            NamaBank.Location = new Point(125, 750);
            NamaBank.Size = new Size(300, 50);
            NamaBank.Font = new Font("montserrat", 20, FontStyle.Regular);
            NamaBank.TextAlign = ContentAlignment.TopLeft;
            NamaBank.BackColor = Color.Transparent;
            NamaBank.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(NamaBank);

            NamaRekening.Text = dtProfil.Rows[0][7].ToString();
            NamaRekening.Location = new Point(150, 800);
            NamaRekening.Size = new Size(500, 100);
            NamaRekening.Font = new Font("montserrat", 20, FontStyle.Regular);
            NamaRekening.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(NamaRekening);

            Button OpenBranch = new Button();
            OpenBranch.Location = new Point(150, 850);
            OpenBranch.Height = 50;
            OpenBranch.Width = 300;
            OpenBranch.BackColor = Color.FromArgb(211, 121, 71);
            OpenBranch.ForeColor = Color.Black;
            OpenBranch.Text = "Open Branch";
            OpenBranch.Name = "OpenBranch";
            OpenBranch.Font = new Font("Montserrat", 20, FontStyle.Regular);
            OpenBranch.Click += new EventHandler(OpenBranch_Click);
            SettingsPanel.Controls.Add(OpenBranch);

            Button Save = new Button();
            Save.Location = new Point(500, 850);
            Save.Height = 50;
            Save.Width = 300;
            Save.BackColor = Color.FromArgb(211, 121, 71);
            Save.ForeColor = Color.Black;
            Save.Text = "Save";
            Save.Name = "Save";
            Save.Font = new Font("Montserrat", 20, FontStyle.Regular);
            Save.Click += new EventHandler(Save_Click);
            SettingsPanel.Controls.Add(Save);

            Label Pajak = new Label();
            Pajak.Text = "Pajak";
            Pajak.Location = new Point(125, 950);
            Pajak.Size = new Size(300, 50);
            Pajak.Font = new Font("montserrat", 30, FontStyle.Bold);
            Pajak.TextAlign = ContentAlignment.TopLeft;
            Pajak.BackColor = Color.Transparent;
            Pajak.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Pajak);

            DataTable dtTax = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select PERCENTAGE from TAX;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTax);
            string Tax = dtTax.Rows[0][0].ToString();

            TextBox Presentase = new TextBox();
            Presentase.Text = "Persentase : "+Tax+"%";
            Presentase.Location = new Point(150, 1010);
            Presentase.Size = new Size(500, 100);
            Presentase.Font = new Font("montserrat", 20, FontStyle.Regular);
            Presentase.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(Presentase);

            Presentase.ReadOnly = true;

            Button Change = new Button();
            Change.Location = new Point(150, 1060);
            Change.Height = 50;
            Change.Width = 300;
            Change.BackColor = Color.FromArgb(211, 121, 71);
            Change.ForeColor = Color.Black;
            Change.Text = "Change";
            Change.Name = "Change";
            Change.Font = new Font("Montserrat", 20, FontStyle.Regular);
            Change.Click += new EventHandler(Change_Click);
            Change.Margin = new Padding(5, 5, 5, 5);
            SettingsPanel.Controls.Add(Change);

            Label kosong = new Label();
            kosong.Text = "Pajak";
            kosong.Location = new Point(40, 1110);
            kosong.Size = new Size(300, 50);
            kosong.Font = new Font("montserrat", 30, FontStyle.Bold);
            kosong.TextAlign = ContentAlignment.TopCenter;
            kosong.BackColor = Color.Transparent;
            kosong.ForeColor = Color.FromArgb(255, 245, 218);
            SettingsPanel.Controls.Add(kosong);
        }

        TextBox Nama = new TextBox();
        TextBox Address = new TextBox();
        TextBox NoNPWP = new TextBox();
        TextBox AlamatEmail = new TextBox();
        TextBox NoTelf1 = new TextBox();
        TextBox Rekening = new TextBox();
        TextBox NamaRekening = new TextBox();

        private void OpenBranch_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormOpenBranch openBranch = new FormOpenBranch(All);
            openBranch.Show();
            this.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlQuery = "update PROFIL set STORE_NAME = '"+ Nama.Text + "', STORE_NPWP = '"+ NoNPWP.Text + "', STORE_ADDRESS = '"+ Address.Text + "', PHONE_NUMBER = '"+ NoTelf1.Text + "', EMAIL = '"+ AlamatEmail.Text + "', BANK_ACCOUNT = '"+ Rekening.Text + "', BANK_NAME = '"+ NamaRekening.Text + "' where NO_STORE = 'S001'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            MessageBox.Show("Data Tersimpan");
            
        }

        private void Change_Click(object sender, EventArgs e)
        {
            FormInputTax inputTax = new FormInputTax(All);
            inputTax.Show();
            this.Hide();
        }
    }
}
