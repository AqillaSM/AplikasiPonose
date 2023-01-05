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
    public partial class FormEditInput : Form
    {
        MySqlConnection sqlConnect = new MySqlConnection("server=139.255.11.84;uid=student;pwd=isbmantap;database=SAD_Ponose"); // sebagai data koneksi ke DBMSnya, memasukkan IP Address, localhost, user, password
        MySqlCommand sqlCommand = new MySqlCommand("query kita"); // memindahkan query dari VS ke database
        MySqlDataAdapter sqlAdapter; // hasil query akan disimpan olehnya atau menjadi penampung
        string sqlQuery;
        int posisi = 0;
        string IDAdmin;
        string IDCustomer;
        string IDNota;
        string All;
        string baruni;

        public FormEditInput(string terima) : this()
        {
            if (terima.Length == 3)
            {
                IDAdmin = terima;
            }
            else if (terima.Length == 7)
            {
                IDAdmin = terima.Substring(0, 3);
                IDCustomer = terima.Substring(3, 3);
                baruni = terima.Substring(6);
            }
            else if (terima.Length == 16)
            {
                IDAdmin = terima.Substring(0, 3);
                IDNota = terima.Substring(3);
            }
            else
            {
                IDAdmin = terima.Substring(0, 3);
                IDCustomer = terima.Substring(3, 3);
                baruni = terima.Substring(6);
            }
            All = terima;
        }

        public FormEditInput()
        {
            posisi = 0;
            InitializeComponent();
            PasswordPanel.Show();
            PanelChange.Hide();
        }

        private void FormEditInput_Load(object sender, EventArgs e)
        {
            InputPasswordTextBox.PasswordChar = '*';
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DataTable dtCekPassword = new DataTable(); //buat cek apakah sudah pernah beli atau belum
            sqlQuery = "select `PASSWORD` from ADMIN where ID_ADMIN = '" + IDCustomer + "' and `PASSWORD` = '"+ InputPasswordTextBox.Text +"'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtCekPassword);

            if (dtCekPassword.Rows.Count != 1) //kalo belum insert
            {
                MessageBox.Show("Password salah");
            }
            else // kalo sudah update
            {
                if(baruni == "6")
                {
                    ChangeLabel.Text = "Change Position";
                }
                else
                {
                    ChangeLabel.Text = "Change Password";
                    PrevTextBox.PasswordChar = '*';
                    NewTextBox.PasswordChar = '*';
                }
                PasswordPanel.Hide();
                PanelChange.Show();
                posisi = 1;
            }
            
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (posisi == 0)
            {
                All = All.Substring(0, 6);
                FormEditUser edituser = new FormEditUser(All);
                edituser.Show();
                this.Hide();
            }
            else
            {
                PasswordPanel.Show();
                PanelChange.Hide();
                posisi = 0;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            

            if (baruni == "6")
            {
                DataTable dtCekPassword = new DataTable(); //buat cek apakah sudah pernah beli atau belum
                sqlQuery = "select `POSITION` from ADMIN where ID_ADMIN = '" + IDCustomer + "' and `POSITION` = '" + PrevTextBox.Text + "'; ";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtCekPassword);
                if (dtCekPassword.Rows.Count != 1) //kalo belum insert
                {
                    MessageBox.Show("Posisi salah");
                }
                else // kalo sudah update
                {
                    sqlConnect.Open();
                    sqlQuery = "update ADMIN set `POSITION` = '" + NewTextBox.Text + "' where ID_ADMIN =  '" + IDCustomer + "';";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();

                    All = All.Substring(0, 6);
                    FormEditUser edituser = new FormEditUser(All);
                    edituser.Show();
                    this.Hide();
                }
            }
            else
            {
                DataTable dtCekPassword = new DataTable(); //buat cek apakah sudah pernah beli atau belum
                sqlQuery = "select `PASSWORD` from ADMIN where ID_ADMIN = '" + IDCustomer + "' and `PASSWORD` = '" + PrevTextBox.Text + "'; ";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtCekPassword);
                if (dtCekPassword.Rows.Count != 1) //kalo belum insert
                {
                    MessageBox.Show("Password salah");
                }
                else // kalo sudah update
                {
                    sqlConnect.Open();
                    sqlQuery = "update ADMIN set `PASSWORD` = '" + NewTextBox.Text + "' where ID_ADMIN =  '" + IDCustomer + "';";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();

                    All = All.Substring(0, 6);
                    FormEditUser edituser = new FormEditUser(All);
                    edituser.Show();
                    this.Hide();
                }
            }
        }
    }
}
