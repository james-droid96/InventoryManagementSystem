using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ViewOrderForm : Form
    {
        public ViewOrderForm(string orderid, string orderdate,string productid,string productname,string customerid,string customername,
            string quantity, string price, string totalamount)
        {
            InitializeComponent();
            txtOrderId.Text = orderid;
            txtOrderDate.Text = orderdate;
            txtPId.Text = productid;
            txtPname.Text = productname;
            txtCid.Text = customerid;
            txtCname.Text = customername;
            txtQty.Text = quantity;
            txtPrice.Text = price;
            txtTotalAmount.Text = totalamount;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
