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
    public partial class ViewCustomer : Form
    {
        public ViewCustomer(string customerId,string name,string phone)
        {
            InitializeComponent();
            txtCustomerId.Text = customerId;
            txtCustomerName.Text = name;
            txtPhone.Text = phone;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
