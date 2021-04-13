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
using Microsoft.VisualBasic;

namespace FoodOrderingApp
    
{
    public partial class Form4 : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");
        string username, firstName, lastName, email, phone, password;
        Form3 appWindow;

        private void btnChangeEmail_Click(object sender, EventArgs e)
        {
            string em = Interaction.InputBox("Choose a different Email:", "Email");
            
            if (em.Equals(string.Empty))
            {
                MessageBox.Show("Error", "Email can't be empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (em.Equals(email))
                return;
            email = em;

            OleDbCommand com = new OleDbCommand("update UsersTable set Email='" + email + "' where Username='" + username + "'", conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            lblEmail.Text = email;
        }

        private void btnChangePhone_Click(object sender, EventArgs e)
        {
            string ph = Interaction.InputBox("Choose a different Phone:", "Phone");

            if (ph.Equals(string.Empty))
            {
                MessageBox.Show("Error", "Phone number missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ph.Equals(phone))
                return;
            
            phone = ph;

            OleDbCommand com = new OleDbCommand("update UsersTable set Phone='" + phone + "' where Username='" + username + "'", conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            lblPhone.Text = phone;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p1 = Interaction.InputBox("Choose a different password:", "Password");
            if (p1.Equals(string.Empty))
            {
                MessageBox.Show("Error", "Password can't be empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!p1.Equals(password))
            {
                string p2 = Interaction.InputBox("Please confirm your password:", "Confirm Password");
                if (p2.Equals(p1))
                {
                    password = p1;
                    OleDbCommand com = new OleDbCommand("update UsersTable set [Password]='" + password + "' where Username='" + username + "'", conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Error", "Passwords don't match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error", "This password is already set.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            appWindow = new Form3(username);
            appWindow.Show();
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            string fn = Interaction.InputBox("Choose a First Name:", "First Name");
            if (fn.Equals(string.Empty))
            {
                MessageBox.Show("Error", "First name can't be empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ln = Interaction.InputBox("Choose a Last Name:", "Last Name");
            if (ln.Equals(string.Empty))
            {
                MessageBox.Show("Error", "Last name can't be empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fn.Equals(firstName) && ln.Equals(lastName))
                return;
            firstName = fn;
            lastName = ln;

            OleDbCommand com = new OleDbCommand("update UsersTable set FirstName='"+firstName+"', LastName='"+lastName+"' where Username='"+username+"'", conn);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            lblName.Text = firstName + " " + lastName;
        }

        public Form4(string user)
        {
            InitializeComponent();
            username = user;
            OleDbDataAdapter adap = new OleDbDataAdapter("select * from UsersTable where Username='" + user + "'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            firstName = DS.Tables["UsersTable"].Rows[0]["FirstName"].ToString();
            lastName = DS.Tables["UsersTable"].Rows[0]["LastName"].ToString();
            email = DS.Tables["UsersTable"].Rows[0]["Email"].ToString();
            phone = DS.Tables["UsersTable"].Rows[0]["Phone"].ToString();
            password = DS.Tables["UsersTable"].Rows[0]["Password"].ToString();
            lblName.Text = firstName + " " + lastName;
            lblEmail.Text = email;
            lblPhone.Text = phone;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            appWindow = new Form3(username);
            appWindow.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
