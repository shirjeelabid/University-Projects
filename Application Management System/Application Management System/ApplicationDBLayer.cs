using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Management_System
{
    class ApplicationDBLayer
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance(); 
        public Application1 app;

        public ApplicationDBLayer()
        {
            app = new Application1();
            obj.assign();
            con = obj.con;
        }

        public void getApplicationData(String appName)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "Select a.*,p.name as 'PName',d.capacity,d.OS from Device d, Application a left join Person p on a.developerID=p.id where a.name='" + appName + "' and a.deviceID=d.id";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                decimal c;
                app = new Application1();
                while (reader.Read())
                {
                    app.setName(reader["name"].ToString());
                    app.setDescription( reader["description"].ToString());
                    app.setVersion(reader["version1"].ToString());
                    app.setCategory(reader["category"].ToString());
                    app.setRating(reader["rating"].ToString());
                    app.setdevName(reader["PName"].ToString());
                    app.setPrice(Convert.ToDecimal(reader["price"].ToString()));
                    app.dev.setOS(reader["OS"].ToString());
                    c = Convert.ToDecimal(reader["capacity"].ToString()) / 1024;
                    app.dev.setCapacity((decimal)System.Math.Round(c, 2));
                }
                reader.Close();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public DataTable LoadInstalledData(int pID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select distinct(a.name) As 'Apps',a.version1 As 'Version' from Application a join Install i on a.id=i.appID where i.CusID=" + pID + " and i.status='installed'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                //DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                //return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public bool CheckInstalled(String app,int pID)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select a.name As 'Apps',a.version1 As 'Version' from Application a join Install i on a.id=i.appID where i.CusID=" + pID + " and a.name='" + app + "' and i.status='installed'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    c++;
                }
                if (c > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable LoadUpdateData(int pID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select distinct(a.name) As 'Apps',a.version1 As 'Version' from Application a where a.Ustatus='Yes' and ID in(Select appID from Install where CusID=" + pID + " and status='installed')";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
               
                sda.Fill(dt);
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable LoadRecommendedApps(int pID)
        {
            DataTable dt = new DataTable();
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select a.name as 'Application Name', category, rating, p.name as 'Developer Name', price from Application a left join Person p on p.id=developerID where category in(select category from Application where id in(select appID from Install where cusID=" + pID + "))";
                //SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable LoadGrid(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                //shirjeelkhattak@gmail.com
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select a.name as 'Application Name', category, rating, p.name as 'Developer Name', price from Application a left join Person p on p.id=developerID where a.id in(Select appID from  Upload where Approved='Yes') and( a.name like '%" + name + "%' or  category=(select category from Application p where p.name='" + name + "'))";
                
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                //DataTable dt = new DataTable();
                sda.Fill(dt);
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public int LoadReviews(string appName)
        {
            int reviews = 0;
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select Count(*) as 'count' from feedback where aId=(select id from application where name='" + appName + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                //int reviews = 0;
                while (reader.Read())
                {
                    if (reader["count"] != DBNull.Value)
                        reviews = Convert.ToInt32(reader["count"].ToString());
                }
                reader.Close();
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return reviews;
        }

        public void LoadSearchBox(ComboBox cmbSearchApp)
        {
            try
            {
                cmbSearchApp.Items.Clear();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select name from Application where id iN(Select appID from  Upload where Approved='Yes')";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["name"] != DBNull.Value)
                        cmbSearchApp.Items.Add(reader["name"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string LoadNoOfDownloads(string AppName)
        {
            string downloads = " ";
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                SqlDataReader reader;
                cmd.CommandText = "select count(distinct(cusID)) as 'Count' from Install where appID=(select id from Application where name='" + AppName + "') and status='installed'";
                reader = cmd.ExecuteReader();
                //string downloads = " ";
                while (reader.Read())
                {
                    downloads = reader["Count"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return downloads;
        }

        public DataTable LoadUnInstalledData(int pID)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select distinct(a.name) As 'Apps',i.status As 'Status' from Application a join Install i on a.id=i.appID where i.CusID=" + pID;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                
                sda.Fill(dt);
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
    }

}
