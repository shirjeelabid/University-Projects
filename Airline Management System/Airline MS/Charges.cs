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
    public partial class Charges : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Charges()
        {
            InitializeComponent();
            Connection c = new Connection();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            if (textBox6.Text != "")
            {
                cmd = new SqlCommand("Select * from Charges where ChargesID=" + textBox6.Text, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = (dr["Amount"].ToString());
                    textBox3.Text = (dr["FlightID"].ToString());
                    textBox4.Text = (dr["Title"].ToString());
                    textBox5.Text = (dr["Description"].ToString());
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
                if (textBox6.Text != "")
                {
                    try
                    {
                        cmd = new SqlCommand("UPDATE CHARGES set Title='" + textBox4.Text + "', Description='" + textBox5.Text + "', FlightID=" + textBox3.Text + ", Amount=" + textBox2.Text + " Where ChargesID=" + textBox6.Text, cn);
                        dr = cmd.ExecuteReader();
                        dr.Close();
                        MessageBox.Show("Record Updated");
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Check Entered Data");
                    }
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
            if (textBox6.Text != "")
            {
                cmd = new SqlCommand("delete from Charges Where ChargesID=" + textBox6.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();
                MessageBox.Show("Record Deleted");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Enter ID's");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Enter FlightID");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Enter Title");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Description");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Amount");
                }
                else
                {
                    int C_ID = 0;
                    SqlDataAdapter sda;
                    DataTable dataset;

                    sda = new SqlDataAdapter("select isNULL(max(cast(ChargesID as int )),0)+1 from Charges", cn);
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    C_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                    cmd = new SqlCommand("Insert into Charges Values (" + C_ID + ",'" + textBox4.Text + "'," + textBox2.Text + ",'" + textBox5.Text + "'," + textBox3.Text + ")", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();
                    MessageBox.Show("Record Entered And ID is " + C_ID.ToString());
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox2.Clear();
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
            View pg = new View("Booking");
            pg.ShowDialog();
            this.Show();
        }
    }
}
