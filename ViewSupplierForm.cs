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
    public partial class ViewSupplierForm : Form
    {
        public ViewSupplierForm(string supplierId,string suppliername,string address, string phone)
        {
            InitializeComponent();
            // Assign the values to controls on the form

            txtSname.Text = suppliername;
            txtSid.Text = supplierId;
            txtSadd.Text = address;
            txtSphone.Text = phone;

        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
