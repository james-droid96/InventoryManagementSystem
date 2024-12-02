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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Method to reveal all hidden columns in a DataGridView
        private void RevealAllColumns(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Visible = true;
            }
        }
        //To show subform from in mainform
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            //Openning a other form to perform it
            openChildForm(new UserForm());

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            //Openning a other form to perform it 
            openChildForm(new CustomerForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            //Openning a other form to perform it 
            openChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            //Openning a other form to perform it 
            openChildForm(new ProductForm());
        }

        private void cbHome_Click(object sender, EventArgs e)
        {
            //Openning a other form to perform it 
            openChildForm(new MainForm());
        }

        private void cbLogout_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // If user clicked "Yes," close the application
                Application.Exit();
            }
        }


        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new SupplierForm());
        }
    }
}

