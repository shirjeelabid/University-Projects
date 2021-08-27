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
using System.Net.Mail;
using System.Net;
namespace Airline_MS
{
    public partial class Login : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Login()
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            bool ch1 = false, ch2 = false;
            string Desg="";
            /////////////Checking Login For Passenger////////////////
            cmd = new SqlCommand("select * from PASSENGER", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
              if (dr["PassengerID"].ToString() == textBox1.Text && dr["password"].ToString() == textBox2.Text)
                {
                    ch1 = true;
                    break;
                }
            }
            dr.Close();

           ///////////////////Check Login For Employee////////////////
            cmd = new SqlCommand("select * from EMPLOYEE", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Emp_ID"].ToString() == textBox1.Text && dr["password"].ToString() == textBox2.Text)
                {
                    Desg = dr["Designation"].ToString();
                    ch2 = true;
                    break;
                }
            }
            dr.Close();

            if (ch1 == true)
            {
                Passenger ps = new Passenger(textBox1.Text);
                MessageBox.Show("Login Successful");
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
                ps.ShowDialog();
                this.Show();
            }
            else if (ch2 == true)
            {
                Options en = new Options(textBox1.Text,Desg);
                MessageBox.Show("Login Successful");
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
                en.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SignUp su = new SignUp();
            this.Hide();
            su.ShowDialog();
            this.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
