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
    public partial class SignUp : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public SignUp()
        {
            Connection c = new Connection();
            InitializeComponent();
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            try
            {

                int Pid, Cid = 0, Sid = 0;
                SqlDataAdapter sda;
                DataTable dataset;
                //////////////////////////////Geting last Cid from Passenger table /////////////////////
                sda = new SqlDataAdapter("select isNULL(max(cast(PassengerID as int )),0)+1 from PASSENGER", cn);
                dataset = new DataTable();
                sda.Fill(dataset);
                Pid = Convert.ToInt32(dataset.Rows[0][0].ToString());

                //////////////////////////////Geting Sid from State table according to StateName/////////////////////
                cmd = new SqlCommand("select StateID from STATE where Name='" + comboBox1.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Sid = dr.GetInt32(0);
                }
                dr.Close();

                cmd = new SqlCommand("select * from Country where Name='" + comboBox2.Text + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cid = Convert.ToInt32(dr["CountryID"].ToString());
                }
                dr.Close();

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                if (textBox7.Text != textBox9.Text)
                {
                    MessageBox.Show("Check both Passwords and enter equal Password");
                }
                else if (comboBox1.Text == "")
                {
                    MessageBox.Show("Select State");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Name");
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Enter Age");
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Select Country");
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Enter Email");
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Enter Address");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Cell");
                }
                else
                {
                    /////////////////////Geting Data for passenger and writing it to passenger table//////////////
                    cmd = new SqlCommand("insert into PASSENGER values (" + Pid + ",'" + textBox1.Text + "','" + textBox7.Text + "'," + textBox3.Text + ",'" + textBox6.Text + "','" + textBox5.Text + "','" + textBox10.Text + "','" + textBox6.Text + "'," + Cid + "," + Sid + ")", cn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dr.Close();

                    textBox1.Clear();
                    textBox3.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    MessageBox.Show("Your ID is : " + Pid.ToString());

                    dr.Close();
                    cn.Close();
                    this.Close();
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered Data");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            int Cid = 0,c=0;
            comboBox1.Items.Clear();
            cmd = new SqlCommand("select * from Country where Name='" + comboBox2.Text + "'", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cid = Convert.ToInt32(dr["CountryID"].ToString());
            }
            dr.Close();
            cmd = new SqlCommand("select Name from STATE where CountryID=" + Cid, cn);
            dr = cmd.ExecuteReader();
            c = 0;
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
                c++;
            }
            dr.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            cmd = new SqlCommand("select Name from Country", cn);
            dr = cmd.ExecuteReader();
            int c = 0;
            while (dr.Read())
            {
                comboBox2.Items.Add(dr.GetString(0));
                c++;
            }
            dr.Close();
        }
    }
}
