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

namespace Airline_MS
{
    public partial class EmployeeProfile : Form
    {
        int ID;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public EmployeeProfile(string n)
        {
            Connection c = new Connection();
            InitializeComponent();
            ID = Convert.ToInt32(n);
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void EmployeeProfile_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from Employee where Emp_ID=" + ID, cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = (dr["Emp_ID"].ToString());
                textBox2.Text = (dr["Designation"].ToString());
                textBox3.Text = (dr["Name"].ToString());
                textBox5.Text = (dr["BranchID"].ToString());
                textBox7.Text = (dr["Password"].ToString());
                textBox9.Text = (dr["Salary"].ToString());
                textBox4.Text = (dr["Address"].ToString());
                textBox6.Text = (dr["PhoneNumber"].ToString());
                textBox8.Text = (dr["Email"].ToString());
            }
            dr.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE Employee set Name='" + textBox3.Text + "', Password='" + textBox7.Text + "', Address='" + textBox4.Text + "', PhoneNumber='" + textBox6.Text + "', Email='" + textBox8.Text + "' where Emp_ID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Record Updated");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
