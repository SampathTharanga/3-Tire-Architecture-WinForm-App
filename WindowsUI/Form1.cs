using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusiinessLayer;
using System.Drawing.Drawing2D;

namespace WindowsUI
{
    public partial class Form1 : Form
    {
        ClassBL objLogics;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objLogics = new ClassBL();
            dataGridView1.DataSource = objLogics.LoadEmployee();
            dataGridView1.DataMember = "Table_Employee";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objLogics = new ClassBL();
            if (!(txtEmail.Text == "" && txtName.Text == ""))
                objLogics.AddNewEmployee(txtEmail.Text, txtName.Text);
            dataGridView1.DataSource = objLogics.LoadEmployee();
            dataGridView1.DataMember = "Table_Employee";
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            objLogics = new ClassBL();
            string email = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            objLogics.DeleteEmployee(email);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objLogics = new ClassBL();
            objLogics.UpdateEmployee(txtEmail.Text, txtName.Text);
            dataGridView1.DataSource = objLogics.LoadEmployee();
            dataGridView1.DataMember = "Table_Employee";
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells["name"].Value.ToString();

        }
    }
}
