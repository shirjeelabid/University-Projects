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
    public partial class FlightSchedule : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public FlightSchedule()
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
            textBox6.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox8.Clear();
            textBox2.Clear();

            if (textBox1.Text != "")
            {
                int fare = 0;
                cmd = new SqlCommand("Select * from [FLIGHT SCHEDULE] where FlightID="+textBox1.Text, cn);     //displaying flight schedule data
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox2.Text = (dr["AircraftID"].ToString());
                    textBox3.Text = (dr["flight_date"].ToString());
                    textBox4.Text = (dr["departure"].ToString());
                    textBox5.Text = (dr["arrival"].ToString());
                    textBox6.Text = (dr["arrivaltime"].ToString());
                    textBox7.Text = (dr["departuretime"].ToString());
                    fare = Convert.ToInt32(dr["AirfareID"].ToString());
                }
                dr.Close();
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Record Not Available!");
                }
                else
                {
                    int Route = 0;
                    cmd = new SqlCommand("Select * from airfare where AirfareID=" + fare, cn);     //displaying flight schedule combo box data
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox9.Text = (dr["service_charges"].ToString());
                        textBox10.Text = (dr["fule_charges"].ToString());
                        Route = Convert.ToInt32(dr["RouteID"].ToString());
                    }
                    dr.Close();

                    cmd = new SqlCommand("Select * from Route where RouteID=" + Route, cn);     //displaying flight schedule combo box data
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBox8.Text = (dr["Airport"].ToString());
                        textBox11.Text = (dr["Destination"].ToString());
                    }
                    dr.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                try
                {
                    cmd = new SqlCommand("UPDATE [FLIGHT SCHEDULE] set flight_date='" + textBox3.Text.ToString() + "', departure='" + textBox4.Text + "', arrival='" + textBox5.Text + "', arrivaltime='" + textBox6.Text + "', departuretime='" + textBox7.Text + "', AircraftID=" + textBox2.Text + " where FlightID=" + textBox1.Text, cn);
                    dr = cmd.ExecuteReader();
                    dr.Close();

                    cmd = new SqlCommand("UPDATE airfare set Service_charges=" + textBox9.Text + ", Fule_Charges=" + textBox10.Text + " from airfare A , [FLIGHT SCHEDULE] FS where A.AirfareID = FS.AirfareID", cn);
                    dr = cmd.ExecuteReader();
                    dr.Close();

                    cmd = new SqlCommand("UPDATE Route set Airport='" + textBox8.Text + "', Destination='" + textBox11.Text + "' from airfare A , Route R where A.RouteID = R.RouteID", cn);
                    dr = cmd.ExecuteReader();
                    dr.Close();

                    MessageBox.Show("Record Updated");
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Check Entered data!\n May be Aircraft Does Not Exist");
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
                int fare = 0, Route = 0;
                cmd = new SqlCommand("Select * from [FLIGHT SCHEDULE] where FlightID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fare = Convert.ToInt32(dr["AirfareID"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select * from Airfare where AirfareID=" + fare, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Route = Convert.ToInt32(dr["RouteID"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("delete from Route where RouteID=" + Route, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                cmd = new SqlCommand("delete from AIRFARE where AirfareID=" + fare, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                cmd = new SqlCommand("delete from [FLIGHT SCHEDULE] where FlightID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Recored Deleted");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox11.Clear();
                textBox8.Clear();
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Enter ID");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Aircraft");
            }
            else if(textBox3.Text == "")
            {
                MessageBox.Show("Enter Flight Date");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Departure");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Arrival");
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Enter Airport");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Enter Departure Time");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Arrival Time");
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("Enter Service Charges");
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Enter Fuel Charges");
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("Enter Destination");
            }
            else
            {
                int Fare_ID = 0, F_ID = 0, Route = 0;
                SqlDataAdapter sda;
                DataTable dataset;

                //////////////////////////////Geting last Flight Schedule ID /////////////////////
                sda = new SqlDataAdapter("select isNULL(max(cast(FlightID as int )),0)+1 from [FLIGHT SCHEDULE]", cn);
                dataset = new DataTable();
                sda.Fill(dataset);
                F_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                //////////////////////////////Geting last Airfare ID  /////////////////////
                sda = new SqlDataAdapter("select isNULL(max(cast(AirfareID as int )),0)+1 from AIRFARE", cn);
                dataset = new DataTable();
                sda.Fill(dataset);
                Fare_ID = Convert.ToInt32(dataset.Rows[0][0].ToString());

                //////////////////////////////Geting last Route ID  /////////////////////
                sda = new SqlDataAdapter("select isNULL(max(cast(RouteID as int )),0)+1 from Route", cn);
                dataset = new DataTable();
                sda.Fill(dataset);
                Route = Convert.ToInt32(dataset.Rows[0][0].ToString());

                try
                {
                    cmd = new SqlCommand("Insert into route Values (" + Route + ",'" + textBox8.Text + "','" + textBox11.Text + "')", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();

                    cmd = new SqlCommand("Insert into airfare Values (" + Fare_ID + "," + Route + "," + textBox9.Text + "," + textBox10.Text + ")", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();

                    cmd = new SqlCommand("Insert into [FLIGHT SCHEDULE] Values (" + F_ID + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'," + textBox2.Text + "," + Fare_ID + ")", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();
                    MessageBox.Show("Record Entered And ID is " + F_ID.ToString());
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox10.Clear();
                    textBox9.Clear();
                    textBox11.Clear();
                    textBox8.Clear();
                    textBox2.Clear();
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Check Entered data!\n May be Aircraft Does Not Exist");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("[FLIGHT SCHEDULE]");
            pg.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
