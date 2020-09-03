using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Application_Management_System
{
    class AppDBLayer
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();
        public Developer developer;

        public AppDBLayer() 
        {
            developer = new Developer();
            obj.assign();
            con = obj.con;
        }

        public bool CreateDeveloper()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select * from Person where email='" + developer.getEmail() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    c++;
                    break;
                }
                reader.Close();
                if (c > 0)
                {
                    MessageBox.Show("Account with this email already exists");
                }
                else
                {
                    query = "insert into Person values('" + developer.getName() + "','" + developer.getEmail() + "','" + developer.getGender() + "','" + developer.getPswd() + "','" + developer.getCountry() + "','Active','Developer'" + ")";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool UploadApp(int DeveloperID)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = "select * from Application where name = '" + developer.app.getName() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int x = 0;

                while (reader.Read())
                    x++;

                if (x == 0)
                {
                    query = "insert into device (OS,RAM,capacity) values('" + developer.app.dev.getOS() + "'," + developer.app.dev.getRam() + "," + developer.app.dev.getCapacity() + ")";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    String DevID = "";

                    query = "select max(id) as X from Device";
                    cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DevID = reader["X"].ToString();
                    }
                    reader.Close();

                    query = "Insert into Application Values('" + developer.app.getName() + "','" + developer.app.getDescription() + "','" + developer.app.getVersion() + "','" + developer.app.getCategory() + "','" + developer.app.getRating() + "'," + DeveloperID + "," + developer.app.getPrice() + "," + DevID + ",'No')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    string App_id = "";

                    query = "select max(id) as X from Application";
                    cmd = new SqlCommand(query, con);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        App_id = reader["X"].ToString();
                    }
                    reader.Close();

                    query = "insert into Upload Values('" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToString("HH:mm:ss") + "'," + App_id + ",'No')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    return true;
                }
                else { MessageBox.Show("App already exist"); }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;

        }
        public bool RemoveApp()
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            try
            {
                string query = "Delete from Device where id = ";
                query += "(select deviceID from Application where name = '" + developer.app.getName() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                query = "Delete from Upload where appID = ";
                query += "(select id from Application where name = '" + developer.app.getName() + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                query = "Delete from Application where name = '" + developer.app.getName() + "'";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool UpdateApp()
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            try
            {
                string query = "Update Application set description = '" + developer.app.getDescription() + "',version1='" + developer.app.getVersion() + "',UStatus = 'Yes' where name = '" + developer.app.getName() + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                query = "Update Device set OS = '" + developer.app.dev.getOS() + "',RAM = " + developer.app.dev.getRam() + ",capacity=" + developer.app.dev.getCapacity() + " where id = (select deviceID from Application where name = '" + developer.app.getName() + "')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public DataTable viewFeedback(){

            try
            {
                string query = "select * from feedback where aID = (select id from Application where name = '" + developer.app.getName() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                DataTable DT1 = new DataTable();
                SDA.Fill(DT1);
                return DT1;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public DataTable viewApps(int id) {
            try
            {
                string query = "select a.*,d.OS from Application a,Device d where developerID = " + Convert.ToString(id) + " and d.id = a.deviceID";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                DataTable DT1 = new DataTable();
                SDA.Fill(DT1);
                return DT1;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }



    }
}
