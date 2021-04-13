using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace FoodOrderingApp
{
    public partial class ucItem : UserControl
    {
        string username;
        string ItemName;
        int ItemPrice;
        
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");


        public ucItem(string user, string item, int price, string des, string img)
        {
            InitializeComponent();
            username = user;
            ItemName = item;
            ItemPrice = price;
            lblItem.Text = item;
            lblDescription.Text = des;
            lblPrice.Text += price.ToString();
            ptbItem.Image = System.Drawing.Image.FromFile(img);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void ucItem_Load(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select Cart from UsersTable where Username='"+username+"'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            string cart = DS.Tables["UsersTable"].Rows[0]["Cart"].ToString();
            if (!cart.Contains(ItemName))
            {
                cart += "," + ItemName;
                cart = cart.Trim(',');
                OleDbCommand com = new OleDbCommand("update UsersTable set Cart='" + cart + "' where Username='" + username + "'", conn);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
