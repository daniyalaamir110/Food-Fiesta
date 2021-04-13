using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace FoodOrderingApp
{
    public partial class Form2 : Form
    {
        Form1 frmLogin;

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");

        public Form2()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        { 
            errMessage.Clear();

            OleDbDataAdapter adap = new OleDbDataAdapter("Select * from UsersTable where Username='" + txtUsername1.Text + "'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            if (DS.Tables["UsersTable"].Rows.Count.Equals(0))
            {
                bool canProced = true;
                TextBox[] TB = new TextBox[7] { txtFirstName, txtLastName, txtEmail, txtUsername1, txtPassword1, txtConfirmPassword, txtPhone };
                for(int i = 0; i < TB.Length; i++)
                {
                    if (TB[i].Text.Equals(string.Empty))
                    {
                        canProced = false;
                        errMessage.SetError(TB[i], "Required");
                    }
                }
                if (!txtPassword1.Text.Equals(txtConfirmPassword.Text))
                {
                    canProced = false;
                    errMessage.SetError(txtConfirmPassword, "Passwords don't match!");
                }
                if (canProced)
                {
                    OleDbCommand com = new OleDbCommand("insert into UsersTable([Username],[FirstName],[LastName],[Email],[Password],[Phone],[Cart]) values('" + txtUsername1.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtEmail.Text + "','" + txtPassword1.Text + "','" + txtPhone.Text + "', '');", conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    conn.Close();
                    this.Hide();
                    frmLogin = new Form1();
                    frmLogin.Show();
                }
            }
            else
            {
                errMessage.SetError(txtUsername1, "Already Exists.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

        }

        private void txtFirstName_MouseHover(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin = new Form1();
            frmLogin.Show();
        }
    }
}
