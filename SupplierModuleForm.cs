using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagementSystem
{
    public partial class SupplierModuleForm : Form
    {
        //Sql connection localhost
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();

        public SupplierModuleForm()
        {
            InitializeComponent();
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to save this supplier?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbSupplier (sname,sphone,saddress)VALUES(@sname,@sphone,@saddress)", con);
                    cm.Parameters.AddWithValue("@sname", txtSname.Text);
                    cm.Parameters.AddWithValue("@sphone", txtSPhone.Text);
                    cm.Parameters.AddWithValue("@saddress", txtSaddress.Text);
                   

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Supplier has been successfully saved.");

                }
            }
            catch (Exception ex) //Throwing an exception manualy
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Clear()
        {
            txtSname.Clear();
            txtSPhone.Clear();
            txtSaddress.Clear();
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to Update this Supplier?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbSupplier SET sname=@sname,sphone=@sphone,saddress=@saddress WHERE sid LIKE'" + lblSid.Text + "'", con);
                    cm.Parameters.AddWithValue("@sname", txtSname.Text);
                    cm.Parameters.AddWithValue("@sphone", txtSPhone.Text);
                    cm.Parameters.AddWithValue("@saddress", txtSaddress.Text);
                   
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Supplier has been successfully updated!.");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
