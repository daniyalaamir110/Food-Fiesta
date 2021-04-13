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
using Microsoft.VisualBasic;

namespace FoodOrderingApp
{
    public partial class ucCartItem : UserControl
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");
        string username;
        string ItemName;
        int ItemPrice;
        int qty;
        int cost;
        public ucCartItem(string user, string item, int price, string des, string img)
        {
            InitializeComponent();
            username = user;
            ItemName = item;
            ItemPrice = price;
            lblItem.Text = item;
            lblDescription.Text = des;
            lblPrice.Text += Convert.ToString(price);
            ptbItem.Image = System.Drawing.Image.FromFile(img);
            qty = 0;
            cost = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter adap = new OleDbDataAdapter("select Cart from UsersTable where Username='" + username + "'", conn);
            DataSet DS = new DataSet();
            conn.Open();
            adap.Fill(DS, "UsersTable");
            conn.Close();
            string cart = DS.Tables["UsersTable"].Rows[0]["Cart"].ToString();
            if (cart.Contains(ItemName))
            {
                cart = cart.Replace(ItemName, "");
                OleDbCommand com = new OleDbCommand("update UsersTable set Cart='" + cart + "' where Username='" + username + "'", conn);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }

            
            ucTotalBill uc = (ucTotalBill)this.Parent.Controls.Find("ucTotalBill", true)[0];
            Parent.Controls.Remove(this);
            uc.update_bill();

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            qty += 1;
            cost = ItemPrice * qty;
            txtQty.Text = qty.ToString();
            lblCost.Text = cost.ToString() + ".0 PKR";
            ucTotalBill uc = (ucTotalBill)this.Parent.Controls.Find("ucTotalBill", true)[0];
            uc.update_bill();
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (qty > 0)
            {
                qty -= 1;
                cost = ItemPrice * qty;
                txtQty.Text = qty.ToString();
                lblCost.Text = cost.ToString() + ".0 PKR";
                ucTotalBill uc = (ucTotalBill)this.Parent.Controls.Find("ucTotalBill", true)[0];
                uc.update_bill();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            
        }
        public int getCost()
        {
            return cost;
        }

        public int getQty()
        {
            return qty;
        }
        public string getItemName()
        {
            return ItemName;
        }
        private void ucCartItem_Load(object sender, EventArgs e)
        {

        }
    }
}
