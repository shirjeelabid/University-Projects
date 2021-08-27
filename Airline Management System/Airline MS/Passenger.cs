using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_MS
{
    public partial class Passenger : Form
    {
        int USER_ID;
        public Passenger(string n)
        {
            InitializeComponent();
            USER_ID = Convert.ToInt32(n);
        }

        private void Passenger_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchFlight sf = new SearchFlight();
            sf.ShowDialog();
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingFlight bk = new BookingFlight(USER_ID.ToString());
            bk.ShowDialog();
            this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View(USER_ID.ToString());
            pg.ShowDialog();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("FS");
            pg.ShowDialog();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            PassengerProfile pg = new PassengerProfile(USER_ID.ToString());
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
