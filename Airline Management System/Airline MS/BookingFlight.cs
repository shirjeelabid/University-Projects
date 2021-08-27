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
    public partial class BookingFlight : Form
    {
        int ID, charges = 0, chargesID = 0,n=0;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr; 
        public BookingFlight(string n)
        {
            Connection c=new Connection();
            InitializeComponent();
            ID = Convert.ToInt32(n);
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void BookingFlight_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox2.Text=="")
                {
                    MessageBox.Show("Check Flight ID");
                }
                else if (charges == 0)
                {
                    MessageBox.Show("Check Charges ID");
                }
                else
                {
                    int Tid;
                    ///////////////Getting Last Tr_ID/////////////////
                    SqlDataAdapter sda;
                    DataTable dataset;
                    sda = new SqlDataAdapter("select isNULL(max(cast(TransactionID as int )),0)+1 from TRANSACTIONS", cn);
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    Tid = Convert.ToInt32(dataset.Rows[0][0].ToString());

                    int Fid = Convert.ToInt32(textBox8.Text);
                    cmd = new SqlCommand("insert into TRANSACTIONS values(" + Tid + ",'" + DateTime.Now.ToString() + "','" + textBox9.Text.ToString() + "'," + ID + "," + Fid + "," + n + ",'Not Confirmed',NULL," + chargesID + ")", cn);
                    dr = cmd.ExecuteReader();

                    MessageBox.Show("You Booked Ticket!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter ChargesID");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Enter FlightID");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Enter No. of tickets");
            }
            else
            {
                int f1=0,f2=0;
                cmd = new SqlCommand("select * from [FLIGHT SCHEDULE] where FlightID=" + textBox8.Text, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = dr["Departure"].ToString();
                    textBox3.Text = dr["Arrival"].ToString();
                    textBox4.Text = dr["ArrivalTime"].ToString();
                    textBox5.Text = dr["DepartureTime"].ToString();
                    textBox9.Text = dr["Flight_Date"].ToString();
                    f1 = Convert.ToInt32(dr["FlightID"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("select * from CHARGES where ChargesID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    charges = Convert.ToInt32(dr["Amount"].ToString());
                     f2= Convert.ToInt32(dr["FlightID"].ToString());
                }
                dr.Close();
                textBox6.Text = charges.ToString();
                n = Convert.ToInt32(textBox10.Text);
                chargesID = Convert.ToInt32(textBox1.Text);
                charges = charges * n;
                textBox7.Text = charges.ToString();
                if(f1!=f2)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    MessageBox.Show("Check Flight ID and Charges ID by viewing the All charges");
                }
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("Booking");
            pg.ShowDialog();
            this.Show();
        }
    }
}
