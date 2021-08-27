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
    public partial class Transactions : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        string E_id;
        public Transactions(string n)
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
            E_id = n;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            if (textBox1.Text != "")
            {
                int n = 0,c=0,f=0;
                cmd = new SqlCommand("Select * from TRANSACTIONS where TransactionID=" + textBox1.Text, cn); 
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox3.Text = (dr["BookingDate"].ToString());
                    textBox4.Text = (dr["DepartureDate"].ToString());
                    textBox7.Text = (dr["Tickets"].ToString());
                    textBox2.Text = (dr["Type"].ToString());
                    textBox5.Text = (dr["PassengerID"].ToString());
                    textBox6.Text = (dr["FlightID"].ToString());
                    textBox8.Text = (dr["EmployeeID"].ToString());
                    textBox11.Text = (dr["ChargesID"].ToString());
                    c = Convert.ToInt32(dr["ChargesID"].ToString());
                    n = Convert.ToInt32(dr["Tickets"].ToString());
                    f = Convert.ToInt32(dr["FlightID"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select * from Charges where ChargesID=" + c+" and FlightID="+f, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int k;
                    textBox10.Text = (dr["Title"].ToString());
                    k = Convert.ToInt32(dr["Amount"].ToString());
                    textBox9.Text = (n * k).ToString();
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
            int C = 0;
            if (textBox1.Text != "")
            {
                try
                {
                    cmd = new SqlCommand("Select * from Charges where ChargesID=" + textBox11.Text+" and FlightID="+textBox6.Text, cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        C = (Convert.ToInt32(dr["ChargesID"].ToString()));
                    }
                    dr.Close();

                    if (textBox2.Text == "Confirmed")
                    {
                        cmd = new SqlCommand("UPDATE TRANSACTIONS set DepartureDate='" + textBox4.Text + "', Tickets=" + textBox7.Text + ", Type='" + textBox2.Text + "', EmployeeID=" + E_id + ", FlightID=" + textBox6.Text + ", ChargesID=" + C + " where TransactionID='" + textBox1.Text + "'", cn);
                        dr = cmd.ExecuteReader();
                        dr.Close();
                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE TRANSACTIONS set DepartureDate='" + textBox4.Text + "', Tickets=" + textBox7.Text + ", Type='" + textBox2.Text + "', FlightID=" + textBox6.Text + ", ChargesID=" + C + " where TransactionID='" + textBox1.Text + "'", cn);
                        dr = cmd.ExecuteReader();
                        dr.Close();
                    }
                    MessageBox.Show("Record Updated");
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Check Entered data!\n May be Check Employee ID or Flight ID or Charges ID");
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
                cmd = new SqlCommand("delete from TRANSACTIONS where TransactionID=" + textBox1.Text, cn);
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
                textBox10.Clear();
                textBox11.Clear();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("TRANSACTIONS");
            pg.ShowDialog();
            this.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
