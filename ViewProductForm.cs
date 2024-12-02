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
    public partial class ViewProductForm : Form
    {
        public ViewProductForm(string productId, string name, string qty, string price, string description,string category)
        {
            InitializeComponent();

            // Assign the values to controls on the form
            txtProductId.Text = productId;
            txtPname.Text = name;
            txtQuantity.Text = qty;
            txtPrice.Text = price;
            txtCategory.Text = category;
            txtDescription.Text = description;
          
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
