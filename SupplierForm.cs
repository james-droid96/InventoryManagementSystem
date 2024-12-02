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
    public partial class SupplierForm : Form
    {
        //Connection via SqL localhost
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public SupplierForm()
        {
            InitializeComponent();
            LoadSupplier();
        }
        public void LoadSupplier()
        {
            int i = 0;
            dgvSupplier.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbSupplier WHERE CONCAT(sid,sname,sphone,saddress)LIKE'%" + txtSearch.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dgvSupplier.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierModuleForm supplierForm = new SupplierModuleForm();
            supplierForm.btnSave.Enabled = true;
            supplierForm.btnUpdate.Enabled = false;
            supplierForm.ShowDialog();
            LoadSupplier();
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSupplier.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                SupplierModuleForm supplierForm = new SupplierModuleForm();
                supplierForm.lblSid.Text = dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                supplierForm.txtSname.Text = dgvSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
                supplierForm.txtSPhone.Text = dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
                supplierForm.txtSaddress.Text = dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
                

                supplierForm.btnSave.Enabled = false;
                supplierForm.btnUpdate.Enabled = true;
                supplierForm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure want to delete this Supplier?", "Deleted Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbSupplier WHERE sid LIKE '" + dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has been successfully deleted!.");
                }
            }
            LoadSupplier();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSupplier();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvSupplier.SelectedRows[0];

                // Retrieve data from the selected row
                string supplierId = selectedRow.Cells[1].Value.ToString();
                string suppliername = selectedRow.Cells[2].Value.ToString();
                string supplieraddress = selectedRow.Cells[3].Value.ToString();
                string phone = selectedRow.Cells[4].Value.ToString();
                


                // Pass the data to the new form
                ViewSupplierForm viewForm = new ViewSupplierForm(supplierId,suppliername,supplieraddress,phone);
                viewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to view.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
