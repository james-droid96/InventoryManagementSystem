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
    public partial class OrderForm : Form
    {
        //Sql connection localhost
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\OneDrive\Documents\dbMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public OrderForm()
        {
            InitializeComponent();
            LoadOrder();
        }

        public void LoadOrder()
        {
            double total = 0;
            int i = 0;
            dgvOrder.Rows.Clear();

            cm = new SqlCommand("SELECT orderid,odate, O.pid,P.pname, O.cid,C.cname, qty,price, total FROM tbOrder AS O JOIN tbCustomer AS C ON O.cid=C.cid JOIN tbProduct AS P ON O.pid=P.pid WHERE CONCAT (orderid,odate,O.pid,P.pname,O.cid, C.cname, qty, price) LIKE '%" + txtSearch.Text + "%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), 
                    Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), 
                    dr[2].ToString(),dr[3].ToString(),dr[4].ToString(), 
                    dr[5].ToString(), dr[6].ToString(), 
                    dr[7].ToString(), dr[8].ToString());

                total += Convert.ToInt32(dr[8].ToString());
            }
            dr.Close();
            con.Close();
            lbQty.Text = i.ToString();
            lblTotal.Text = total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            moduleForm.ShowDialog();
            LoadOrder();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;

            if (colName == "Delete")
            {
              if(MessageBox.Show("Are you sure want to delete this order?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbOrder WHERE orderid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Record has been successfully deleted!.");

                    cm = new SqlCommand("UPDATE tbProduct SET pqty=(pqty+@pqty) WHERE pid LIKE '" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "'", con);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadOrder();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dgvOrder.SelectedRows[0];

                // Retrieve data from the selected row
                string odrderid = selectedRow.Cells[1].Value.ToString();
                string orderdate = selectedRow.Cells[2].Value.ToString();
                string productid = selectedRow.Cells[3].Value.ToString();
                string productname = selectedRow.Cells[4].Value.ToString();
                string customerid = selectedRow.Cells[5].Value.ToString();
                string customername = selectedRow.Cells[6].Value.ToString();
                string quantity = selectedRow.Cells[7].Value.ToString();
                string price = selectedRow.Cells[8].Value.ToString();
                string totalamount = selectedRow.Cells[9].Value.ToString();

                // Pass the data to the new form
                ViewOrderForm orderForm = new ViewOrderForm(odrderid, orderdate, productid, productname, customerid, customername, quantity, price, totalamount);
                orderForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row to view.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
