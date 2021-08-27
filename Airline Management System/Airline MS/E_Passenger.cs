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
    public partial class E_Passenger : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public E_Passenger()
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int Sid = 0, Cid = 0;

            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();

            if (textBox1.Text != "")
            {
                cmd = new SqlCommand("Select * from PASSENGER where PassengerID=" + textBox1.Text, cn);     //displaying passenger data
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = (dr["PassengerID"].ToString());
                    textBox3.Text = (dr["Name"].ToString());
                    textBox4.Text = (dr["Password"].ToString());
                    textBox5.Text = (dr["Age"].ToString());
                    textBox7.Text = (dr["Email"].ToString());
                    textBox9.Text = (dr["Cell"].ToString());
                    textBox10.Text = (dr["Tel"].ToString());
                    textBox11.Text = (dr["Address"].ToString());
                    Sid = Convert.ToInt32(dr["StateID"].ToString());
                    Cid = Convert.ToInt32(dr["CountryID"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select * from STATE where StateID=" + Sid, cn);     //displaying state name
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox12.Text = (dr["Name"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Select * from COUNTRY where CountryID=" + Cid, cn);     //displaying country name
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox13.Text = (dr["Name"].ToString());
                }
                dr.Close();

                if (textBox3.Text == "")
                {
                    MessageBox.Show("Record Not Available!");
                }
            }
            else
            {
                MessageBox.Show("Enter Passenger ID");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            View pg = new View("PASSENGERS");
            pg.ShowDialog();
            this.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {

                    int Sid = 0, Cid = 0;
                    cmd = new SqlCommand("Select * from State where Name='" + textBox12.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Sid = Convert.ToInt32(dr["StateID"].ToString());
                    }
                    dr.Close();

                    cmd = new SqlCommand("Select * from Country where Name='" + textBox13.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cid = Convert.ToInt32(dr["CountryID"].ToString());
                    }
                    dr.Close();

                    cmd = new SqlCommand("UPDATE Passenger set Name='" + textBox3.Text + "', Password='" + textBox4.Text + "', Age='" + textBox5.Text + "', Email='" + textBox7.Text + "', Cell='" + textBox9.Text + "', Tel='" + textBox10.Text + "', Address='" + textBox11.Text + "', CountryID=" + Cid + ", StateID=" + Sid + " where PassengerID='" + textBox1.Text + "'", cn);     //displaying passenger data
                    dr = cmd.ExecuteReader();
                    dr.Close();

                    MessageBox.Show("Record Updated");
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Check Entered data!\n May be State Or Country Does Not Exist");
                }
            }
            else
            {
                MessageBox.Show("Enter Passenger ID");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                cmd = new SqlCommand("Delete from Passenger where PassengerID=" + textBox1.Text, cn);
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Recored Deleted");

                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
            }
            else
            {
                MessageBox.Show("Enter Passenger ID");
            }
        }

        private void E_Passenger_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
