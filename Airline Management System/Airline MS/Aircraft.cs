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
    public partial class Aircraft : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Aircraft()
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("Select * from aircraft where AircraftID="+textBox1.Text, cn);     
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox3.Text = (dr["Capacity"].ToString());
                    textBox4.Text = (dr["ManufactureBy"].ToString());
                    textBox5.Text = (dr["ManufactureDate"].ToString());
                }
                dr.Close();
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Record Not Available!");
                }
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
                    cmd = new SqlCommand("UPDATE AIRCRAFT set Capacity=" + textBox3.Text + ", ManufactureBy='" + textBox4.Text + "', ManufactureDate='" + textBox5.Text.ToString() + "'where AircraftID=" + textBox1.Text, cn);
                    dr = cmd.ExecuteReader();
                    dr.Close();

                    MessageBox.Show("Record Updated");

                }
                else
                {
                    MessageBox.Show("Enter ID");
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("delete from Aircraft where AircraftID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Recored Deleted");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Clear();
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

                if (textBox3.Text == "")
                {
                    MessageBox.Show("Enter Capacity");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Enter Manufacture By");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Manufacture Date");
                }
                else
                {
                    int A_ID = 0;
                    SqlDataAdapter sda;
                    DataTable dataset;

                    sda = new SqlDataAdapter("select isNULL(max(cast(FlightID as int )),0)+1 from [FLIGHT SCHEDULE]", cn);
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    A_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                    cmd = new SqlCommand("Insert into aircraft Values (" + A_ID + "," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text.ToString() + "')", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();
                    MessageBox.Show("Record Entered And ID is " + A_ID.ToString());
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
            }
            catch(System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("AIRCRAFTS");
            pg.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
