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
    public partial class ViewCategory : Form
    {
        public ViewCategory(string categoryId,string name)
        {
            InitializeComponent();
            txtCategoryId.Text = categoryId;
            txtCategoryName.Text = name;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
