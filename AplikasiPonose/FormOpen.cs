using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AplikasiPonose
{
    public partial class FormOpen : Form
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
        string tempat;

        public FormOpen(string terima) : this()
        {
            IDAdmin = terima.Substring(0,3);
            All = terima;
        }

        public FormOpen()
        {
            InitializeComponent();
        }

        private void FormOpen_Load(object sender, EventArgs e)
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

            if(All.Substring(3,1) == "1")
            {
                Settings();
            }
            else
            {
                SettingsAdd();
            }
            
        }

        public void Settings()
        {
            DataTable dtProfil = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select * from PROFIL where STORE_NAME = '"+ All.Substring(4) +"' limit 1; ";
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

            TextBox Nama = new TextBox();
            Nama.Text = dtProfil.Rows[0][1].ToString();
            Nama.Location = new Point(150, 200);
            Nama.Size = new Size(500, 100);
            Nama.Font = new Font("montserrat", 20, FontStyle.Regular);
            Nama.ForeColor = Color.Black;
            Nama.ReadOnly = true;
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

            TextBox Address = new TextBox();
            Address.Text = dtProfil.Rows[0][3].ToString();
            Address.Location = new Point(150, 300);
            Address.Size = new Size(500, 100);
            Address.Font = new Font("montserrat", 20, FontStyle.Regular);
            Address.ForeColor = Color.Black;
            Address.ReadOnly = true;
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

            TextBox NoNPWP = new TextBox();
            NoNPWP.Text = dtProfil.Rows[0][2].ToString();
            NoNPWP.Location = new Point(150, 400);
            NoNPWP.Size = new Size(500, 100);
            NoNPWP.Font = new Font("montserrat", 20, FontStyle.Regular);
            NoNPWP.ForeColor = Color.Black;
            NoNPWP.ReadOnly = true;
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

            TextBox AlamatEmail = new TextBox();
            AlamatEmail.Text = dtProfil.Rows[0][5].ToString();
            AlamatEmail.Location = new Point(150, 500);
            AlamatEmail.Size = new Size(500, 100);
            AlamatEmail.Font = new Font("montserrat", 20, FontStyle.Regular);
            AlamatEmail.ForeColor = Color.Black;
            AlamatEmail.ReadOnly = true;
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

            TextBox NoTelf1 = new TextBox();
            NoTelf1.Text = dtProfil.Rows[0][4].ToString();
            NoTelf1.Location = new Point(150, 600);
            NoTelf1.Size = new Size(500, 100);
            NoTelf1.Font = new Font("montserrat", 20, FontStyle.Regular);
            NoTelf1.ForeColor = Color.Black;
            NoTelf1.ReadOnly = true;
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

            TextBox Rekening = new TextBox();
            Rekening.Text = dtProfil.Rows[0][6].ToString();
            Rekening.Location = new Point(150, 700);
            Rekening.Size = new Size(500, 100);
            Rekening.Font = new Font("montserrat", 20, FontStyle.Regular);
            Rekening.ForeColor = Color.Black;
            Rekening.ReadOnly = true;
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

            TextBox NamaRekening = new TextBox();
            NamaRekening.Text = dtProfil.Rows[0][7].ToString();
            NamaRekening.Location = new Point(150, 800);
            NamaRekening.Size = new Size(500, 100);
            NamaRekening.Font = new Font("montserrat", 20, FontStyle.Regular);
            NamaRekening.ForeColor = Color.Black;
            NamaRekening.ReadOnly = true;
            SettingsPanel.Controls.Add(NamaRekening);

            Label kosong = new Label();
            kosong.Text = "Pajak";
            kosong.Location = new Point(40, 850);
            kosong.Size = new Size(300, 50);
            kosong.Font = new Font("montserrat", 30, FontStyle.Bold);
            kosong.TextAlign = ContentAlignment.TopCenter;
            kosong.BackColor = Color.Transparent;
            kosong.ForeColor = Color.FromArgb(255, 245, 218);
            SettingsPanel.Controls.Add(kosong);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            All = IDAdmin;
            FormOpenBranch open = new FormOpenBranch(All);
            open.Show();
            this.Hide();
        }

        private void SettingsAdd()
        {
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


            Nama.Text = "";
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


            Address.Text = "";
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

            NoNPWP.Text = "";
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

            AlamatEmail.Text = "";
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


            NoTelf1.Text = "";
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


            Rekening.Text = "";
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


            NamaRekening.Text = "";
            NamaRekening.Location = new Point(150, 800);
            NamaRekening.Size = new Size(500, 100);
            NamaRekening.Font = new Font("montserrat", 20, FontStyle.Regular);
            NamaRekening.ForeColor = Color.Black;
            SettingsPanel.Controls.Add(NamaRekening);

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

            Label kosong = new Label();
            kosong.Text = "Pajak";
            kosong.Location = new Point(40, 900);
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
        private void Save_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlQuery = "insert into PROFIL (STORE_NAME, STORE_NPWP, STORE_ADDRESS, PHONE_NUMBER, EMAIL, BANK_ACCOUNT, BANK_NAME, STATUS_DELETE) values ('"+ Nama.Text + "', '" + NoNPWP.Text + "', '" + Address.Text + "', '" + NoTelf1.Text + "', '" + AlamatEmail.Text + "', '" + Rekening.Text + "', '" + NamaRekening.Text + "', 0); ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            All = IDAdmin;
            FormMenu menu = new FormMenu(All);
            menu.Show();
            this.Hide();
        }

        private void SettingsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
