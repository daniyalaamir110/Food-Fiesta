using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace FoodOrderingApp
{
    public partial class Form3 : Form
    {
        Form1 frmLogin;
        Form4 frmProfile;
        int total_cost = 0;
        
        string username;
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");

        public Form3(string u)
        {
            InitializeComponent();
            username = u;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmProfile = new Form4(username);
            this.Hide();
            frmProfile.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlSelected.Location = new Point(btnHome.Location.X - 12, btnHome.Location.Y);
            flpHome.BringToFront();
        }

        private void UpdateCart()
        {
            flpCart.Controls.Clear();

            int totalCost = 0;
            
            OleDbDataAdapter adap = new OleDbDataAdapter("select Cart from UsersTable where Username='" + username + "'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            if (DS.Tables["UsersTable"].Rows.Count != 0)
            {
                string[] cart = DS.Tables["UsersTable"].Rows[0]["Cart"].ToString().Split(',');

                string ItemName;
                int ItemPrice;
                string ItemDescription;
                string ItemImage;
                for (int i = 0; i < cart.Length; i++)
                {
                    if (!cart[i].Equals(string.Empty))
                    {
                        DS.Clear();
                        adap = new OleDbDataAdapter("select * from ItemsTable where Item='" + cart[i] + "'", conn);
                        conn.Open();
                        adap.Fill(DS, "ItemsTable");
                        conn.Close();
                        ItemName = DS.Tables["ItemsTable"].Rows[0]["Item"].ToString();
                        ItemPrice = Convert.ToInt32(DS.Tables["ItemsTable"].Rows[0]["Price"].ToString());
                        ItemDescription = DS.Tables["ItemsTable"].Rows[0]["Description"].ToString();
                        ItemImage = DS.Tables["ItemsTable"].Rows[0]["Image"].ToString();
                        ucCartItem uc = new ucCartItem(username, ItemName, ItemPrice, ItemDescription, ItemImage);
                        flpCart.Controls.Add(uc);
                    }
                }
                
                ucTotalBill ucBill = new ucTotalBill(username);
                flpCart.Controls.Add(ucBill);
            }
        }
        private void btnCart_Click(object sender, EventArgs e)
        {
            pnlSelected.Location = new Point(btnCart.Location.X - 12, btnCart.Location.Y);

            UpdateCart();
            
            flpCart.BringToFront();

        }

       

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlSelected.Location = new Point(btnAboutUs.Location.X - 12, btnAboutUs.Location.Y);
            pnlAboutUs.BringToFront();
        }
        Form5 frmRateUs;
        private void btnRateUs_Click(object sender, EventArgs e)
        {
            pnlSelected.Location = new Point(btnRateUs.Location.X - 12, btnRateUs.Location.Y);
            frmRateUs = new Form5();
            frmRateUs.Show();
            frmRateUs.TopMost = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            pnlSelected.Location = new Point(btnLogOut.Location.X - 12, btnLogOut.Location.Y);

            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Please Confirm Your Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                this.Hide();
                frmLogin = new Form1();
                frmLogin.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select [FirstName], [LastName] from UsersTable where Username='"+username+"'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            string fn = DS.Tables["UsersTable"].Rows[0]["FirstName"].ToString();
            string ln = DS.Tables["UsersTable"].Rows[0]["LastName"].ToString();
            btnProfile.Text = fn + " " + ln;

            adap = new OleDbDataAdapter("select * from ItemsTable", conn);
            conn.Open();
            adap.Fill(DS, "ItemsTable");
            conn.Close();
            for (int i = 0; i < DS.Tables["ItemsTable"].Rows.Count; i++)
            {
                string item = DS.Tables["ItemsTable"].Rows[i]["Item"].ToString();
                int price = Convert.ToInt32(DS.Tables["ItemsTable"].Rows[i]["Price"].ToString());
                string des = DS.Tables["ItemsTable"].Rows[i]["Description"].ToString();
                string img = DS.Tables["ItemsTable"].Rows[i]["Image"].ToString();
                ucItem uc = new ucItem(username, item, price, des, img);
                flpHome.Controls.Add(uc);
            }

            flpHome.BringToFront();
        }

        private void flpCart_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void flpCart_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void pnlAboutUs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
