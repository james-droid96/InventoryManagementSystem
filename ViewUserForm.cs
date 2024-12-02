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
    public partial class ViewUserForm : Form
    {
        public ViewUserForm( string username, string fullname, string password, string phone)
        {
            InitializeComponent();
            // Assign the values to controls on the form

            txtUname.Text = username;
            txtFname.Text = fullname;
            txtPass.Text = password;
            txtPhone.Text = phone;
            
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
