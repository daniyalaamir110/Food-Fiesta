using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.OleDb;

namespace FoodOrderingApp
{
    public partial class ucTotalBill : UserControl

    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=E:\OOP_Project\project\FoodOrderingAppDB.mdb");
        string username;
        int total_cost = 0;
        
        public ucTotalBill(string user)
        {

            InitializeComponent();
            username = user;
        }

        public void update_bill()
        {
            total_cost = 0;
            string items_list = string.Empty;
            for (int i = 0; i < this.Parent.Controls.Find("ucCartItem", true).Length; i++)
            {
                ucCartItem uc = (ucCartItem)this.Parent.Controls.Find("ucCartItem", true)[i];
                total_cost += uc.getCost();
                if (!uc.getQty().Equals(0))
                    items_list += uc.getQty() + " " + uc.getItemName() + "s ,";
            }
            items_list = items_list.Trim(',');
            this.Controls.Find("lblTotalCost", true)[0].Text = total_cost.ToString() + ".0 PKR";
            this.Controls.Find("lblCartItems", true)[0].Text = items_list;
        }

        private void ucTotalBill_Load(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            string address = string.Empty;
            if (total_cost != 0)
            {
                address = Interaction.InputBox("Where do you want your order to be delivered?", "Enter your location");
                if (address.Equals(string.Empty))
                    MessageBox.Show("Order not placed", "Address can't be empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    OleDbCommand com = new OleDbCommand("insert into OrdersTable([Username], [Order], [Address], [Time], [Cost]) values('" + username + "','" + lblCartItems.Text + "','" + address + "','" +DateTime.Now.ToString() + "', '" + total_cost + "')", conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Your order has been placed!\nPKR " + total_cost + ".0");
                }
            }
        }
    }
}
