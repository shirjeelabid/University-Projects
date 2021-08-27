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
    public partial class Branch : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Branch()
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int State=0,Country=0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("Select * from Branch where BranchID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = (dr["Address"].ToString());
                    State=Convert.ToInt32(dr["StateID"].ToString());
                    textBox6.Text = (dr["Name"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select * from State where StateID=" + State, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Country = Convert.ToInt32(dr["CountryID"].ToString());
                    textBox4.Text = (dr["Name"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select * from Country where CountryID=" + Country, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox5.Text = (dr["Name"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select Count(*) from EMPLOYEE where BranchID="+textBox1.Text+" group by BranchID", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox3.Text = (dr.GetValue(0).ToString());
                }
                dr.Close();

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Record Not Available!");
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("delete from Branch where BranchID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Recored Deleted");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Address");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Enter State");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Enter Name");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Country");
                }
                else
                {
                    int B_ID = 0, S_ID = 0, C_ID = 0;
                    SqlDataAdapter sda;
                    DataTable dataset;
                    cmd = new SqlCommand("Select * from Country where Name='" + textBox5.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        C_ID = Convert.ToInt32(dr["CountryID"].ToString());
                    }
                    dr.Close();
                    if (C_ID == 0)
                    {
                        sda = new SqlDataAdapter("select isNULL(max(cast(CountryID as int )),0)+1 from Country", cn);
                        dataset = new DataTable();
                        sda.Fill(dataset);
                        C_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                        cmd = new SqlCommand("Insert into Country Values (" + C_ID + ",'" + textBox5.Text + "')", cn);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        dr.Close();
                    }

                    cmd = new SqlCommand("Select * from State where Name='" + textBox4.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        S_ID = Convert.ToInt32(dr["StateID"].ToString());
                    }
                    dr.Close();

                    if (S_ID == 0)
                    {
                        sda = new SqlDataAdapter("select isNULL(max(cast(StateID as int )),0)+1 from State", cn);
                        dataset = new DataTable();
                        sda.Fill(dataset);
                        S_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                        cmd = new SqlCommand("Insert into State Values (" + S_ID + ",'" + textBox4.Text + "'," + C_ID + ")", cn);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        dr.Close();
                    }

                    sda = new SqlDataAdapter("select isNULL(max(cast(BranchID as int )),0)+1 from Branch", cn);
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    B_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                    cmd = new SqlCommand("Insert into Branch Values (" + B_ID + ",'" + textBox6.Text + "','" + textBox2.Text + "'," + S_ID + ")", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();

                    MessageBox.Show("Record Entered And ID is " + B_ID.ToString());
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("Branches");
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

        private void label18_Click(object sender, EventArgs e)
        {
            try
            {
                int S_ID = 0, C_ID = 0;
                SqlDataAdapter sda;
                DataTable dataset;
                cmd = new SqlCommand("Select * from Country where Name='" + textBox5.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    C_ID = Convert.ToInt32(dr["CountryID"].ToString());
                }
                dr.Close();

                if (C_ID == 0)
                {
                    sda = new SqlDataAdapter("select isNULL(max(cast(CountryID as int )),0)+1 from Country", cn);
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    C_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                    cmd = new SqlCommand("Insert into Country Values (" + C_ID + ",'" + textBox5.Text + "')", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();
                }

                cmd = new SqlCommand("Select * from State where Name='" + textBox4.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    S_ID = Convert.ToInt32(dr["StateID"].ToString());
                }
                dr.Close();

                if (S_ID == 0)
                {
                    sda = new SqlDataAdapter("select isNULL(max(cast(StateID as int )),0)+1 from State", cn);
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    S_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                    cmd = new SqlCommand("Insert into State Values (" + S_ID + ",'" + textBox4.Text + "'," + C_ID + ")", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();
                }

                cmd = new SqlCommand("Update Branch set Name='" + textBox6.Text + "', Address='" + textBox2.Text + "', StateID=" + S_ID + " where BranchID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                dr.Close();

                MessageBox.Show("Record Updated");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }
    }
}
