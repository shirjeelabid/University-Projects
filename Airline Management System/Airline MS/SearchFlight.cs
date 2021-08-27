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
    public partial class SearchFlight : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr; 
        public SearchFlight()
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter Depature");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Arrival");
            }
            else
            {
                cmd = new SqlCommand("Select FS.FlightID as [Filght ID], FS.Flight_Date, FS.Departure,FS.DepartureTime, FS.Arrival,FS.ArrivalTime,R.Airport,AF.AircraftID from [FLIGHT SCHEDULE] FS, AIRFARE A, ROUTE R, AIRCRAFT AF where FS.AirfareID=A.AirfareID and A.RouteID=R.RouteID and FS.AircraftID=AF.AircraftID and FS.Arrival='" + textBox2.Text + "' and FS.Departure='" + textBox1.Text + "'", cn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                sda.Fill(dataset);
                BindingSource bs = new BindingSource();
                bs.DataSource = dataset;
                dataGridView1.DataSource = bs;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Flight Date");
            }
            else
            {
                cmd = new SqlCommand("Select FS.FlightID as [Filght ID], FS.Flight_Date, FS.Departure,FS.DepartureTime, FS.Arrival,FS.ArrivalTime,R.Airport,AF.AircraftID from [FLIGHT SCHEDULE] FS, AIRFARE A, ROUTE R, AIRCRAFT AF where FS.AirfareID=A.AirfareID and A.RouteID=R.RouteID and FS.AircraftID=AF.AircraftID and fs.Flight_Date='" + textBox4.Text.ToString() + "'", cn);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dataset = new DataTable();
                sda.Fill(dataset);
                BindingSource bs = new BindingSource();
                bs.DataSource = dataset;
                dataGridView1.DataSource = bs;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
