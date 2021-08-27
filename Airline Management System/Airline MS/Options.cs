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
    public partial class Options : Form
    {
        int USER_ID;
        string Designation;
        public Options(string n,string Desg)
        {
            InitializeComponent();
            USER_ID = Convert.ToInt32(n);
            Designation = Desg;
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            if(Designation=="Manager" || Designation=="manager" || Designation=="MANAGER")
            {
                panel1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            E_Passenger emp = new E_Passenger();
            emp.ShowDialog();
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FlightSchedule fs = new FlightSchedule();
            fs.ShowDialog();
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Aircraft ar = new Aircraft();
            ar.ShowDialog();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transactions et = new Transactions(USER_ID.ToString());
            et.ShowDialog();
            this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee ee = new Employee(USER_ID.ToString());
            ee.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Branch b = new Branch();
            b.ShowDialog();
            this.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeProfile pg = new EmployeeProfile(USER_ID.ToString());
            pg.ShowDialog();
            this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("B");
            pg.ShowDialog();
            this.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Charges ln = new Charges();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
