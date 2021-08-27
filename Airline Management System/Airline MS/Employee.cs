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
    public partial class Employee : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        string E_id;
        public Employee(string n)
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
            E_id = n;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int id1 = Convert.ToInt32(textBox1.Text);
            int id2 = Convert.ToInt32(E_id);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            if (textBox1.Text != "" && id1 != id2)
            {
                cmd = new SqlCommand("Select * from Employee where Emp_ID=" + textBox1.Text, cn); 
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = (dr["Designation"].ToString());
                    textBox3.Text = (dr["Name"].ToString());
                    textBox5.Text = (dr["BranchID"].ToString());
                    textBox7.Text = (dr["Password"].ToString());
                    textBox9.Text = (dr["Salary"].ToString());
                    textBox6.Text = (dr["PhoneNumber"].ToString());
                    textBox8.Text = (dr["Email"].ToString());
                    textBox4.Text = (dr["Address"].ToString());
                }
                dr.Close();

                if (textBox3.Text == "")
                {
                    MessageBox.Show("Record Not Available!");
                }
            }
            else if (id1 == id2)
            {
                MessageBox.Show("You cannot View your own data");
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    cmd = new SqlCommand("UPDATE Employee set Designation='" + textBox2.Text + "', Name='" + textBox3.Text + "', BranchID=" + textBox5.Text + ", Password='" + textBox7.Text + "', Salary=" + textBox9.Text + ", Address='" + textBox4.Text + "', PhoneNumber='"+textBox6.Text+"', Email='"+textBox8.Text+"' where Emp_ID=" + textBox1.Text, cn);
                    dr = cmd.ExecuteReader();
                    dr.Close();

                    MessageBox.Show("Record Updated");
                }
                else
                {
                    MessageBox.Show("Enter ID");
                }
            }
            catch(System.Exception)
            {
                MessageBox.Show("Check Entered data!\n May be Branch ID Not exist");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("delete from Employee where Emp_ID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Recored Deleted");
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                MessageBox.Show("Enter Designation");
            }
            else if(textBox3.Text=="")
            {
                MessageBox.Show("Enter Name");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Address");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Branch");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Phone Number");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Enter Password");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Enter Email");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Enter Salary");
            }
            else
            {
                int E_ID = 0;
                SqlDataAdapter sda;
                DataTable dataset;

                //////////////////////////////Geting last Flight Schedule ID /////////////////////
                sda = new SqlDataAdapter("select isNULL(max(cast(Emp_ID as int )),0)+1 from Employee", cn);
                dataset = new DataTable();
                sda.Fill(dataset);
                E_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                try
                {
                    cmd = new SqlCommand("Insert into Employee Values (" + E_ID + ",'" + textBox3.Text + "','" + textBox7.Text + "'," + textBox9.Text + "," + textBox5.Text + ",'" + textBox2.Text + "','" + textBox8.Text + "','" + textBox6.Text + "','" + textBox4.Text + "')", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();

                    MessageBox.Show("Record Entered And ID is " + E_ID.ToString());
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Check Branch ID");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("Employee");
            pg.ShowDialog();
            this.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
