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
    public partial class PassengerProfile : Form
    {
        int ID;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public PassengerProfile(string n)
        {
            Connection c = new Connection();
            InitializeComponent();
            ID = Convert.ToInt32(n);
            cn = new SqlConnection(c.Connect);
            cn.Open();
        }

        private void label18_Click(object sender, EventArgs e)
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

                cmd = new SqlCommand("UPDATE Passenger set Name='" + textBox3.Text + "', Password='" + textBox4.Text + "', Age='" + textBox5.Text + "', Email='" + textBox6.Text + "', Cell='"+textBox9.Text+"', Tel='"+textBox10.Text+"', Address='"+textBox11.Text+"', CountryID="+Cid+", StateID="+Sid+" where PassengerID='" + textBox1.Text + "'", cn);     //displaying passenger data
                dr = cmd.ExecuteReader();
                dr.Close();

                MessageBox.Show("Record Updated");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Check Entered\n May be State Or Country Does Not Exist");
            }
        }

        private void PassengerProfile_Load(object sender, EventArgs e)
        {
            int Sid = 0, Cid = 0;
            cmd = new SqlCommand("Select * from PASSENGER where PassengerID=" + ID, cn);     //displaying passenger data
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = (dr["PassengerID"].ToString());
                textBox3.Text = (dr["Name"].ToString());
                textBox4.Text = (dr["Password"].ToString());
                textBox5.Text = (dr["Age"].ToString());
                textBox6.Text = (dr["Email"].ToString());
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
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            this.Hide();
            ln.ShowDialog();
            this.Show();
        }
    }
}
