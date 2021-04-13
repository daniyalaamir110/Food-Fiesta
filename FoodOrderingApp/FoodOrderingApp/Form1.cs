using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FoodOrderingApp
{
    public partial class Form1 : Form
    {
        Form2 frmRegister;
        Form3 appWindow;
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errMessage.Clear();

            OleDbDataAdapter adap = new OleDbDataAdapter("SELECT Username,Password FROM UsersTable WHERE Username='" + txtUsername.Text + "'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            if (!DS.Tables["UsersTable"].Rows.Count.Equals(0))
            {
                string username = DS.Tables["UsersTable"].Rows[0]["Username"].ToString();
                string password = DS.Tables["UsersTable"].Rows[0]["Password"].ToString();

                if (txtPassword.Text.Equals(string.Empty))
                {
                    errMessage.SetError(txtPassword, "Password is required.");
                }
                else if (!txtPassword.Text.Equals(password))
                {
                    errMessage.SetError(txtPassword, "Incorrect Password");
                }
                else
                {
                    this.Hide();
                    appWindow = new Form3(username);
                    appWindow.Show();
                    
                }
            }
            else if (txtUsername.Text.Equals(string.Empty))
                errMessage.SetError(txtUsername, "Username is required.");
            else
                errMessage.SetError(txtUsername, "Username not found");
        }

            

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegisterNow_Click(object sender, EventArgs e)
        {
            frmRegister = new Form2();
            frmRegister.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }


}

