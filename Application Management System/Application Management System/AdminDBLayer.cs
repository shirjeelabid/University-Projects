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
    class AdminDBLayer
    {
        public PersonDBLayer pdl;
        public Admin adm;
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();
        public AdminDBLayer()
        {
            adm = new Admin();
            pdl = new PersonDBLayer();
            obj.assign();
            con = obj.con;
        }

        public bool CreateAdmin(string approved, string deluser, string deldev, string blkdev)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select * from Person where email='" + adm.getEmail() + "'";
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
                    query = "insert into Person values('" + adm.getName() + "','" + adm.getEmail() + "','" + adm.getGender() + "','" + adm.getPswd() + "','" + adm.getCountry() + "','Active','Admin'" + ")";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "insert into Permissions values('" + approved + "','" + deluser + "','" + deldev + "','" + blkdev + "')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select max(id) as 'max' from Person";
                    reader.Close();
                    reader = cmd.ExecuteReader();
                    int x = 0;
                    while (reader.Read())
                    {
                        if (reader["max"] != DBNull.Value)
                            x = Convert.ToInt32(reader["max"].ToString());
                    }
                    reader.Close();
                    cmd.CommandText = "select max(id) as 'max' from Permissions";
                    reader = cmd.ExecuteReader();
                    int z = 0;
                    while (reader.Read())
                    {
                        if (reader["max"] != DBNull.Value)
                            z = Convert.ToInt32(reader["max"].ToString());
                    }
                    reader.Close();
                    cmd.CommandText = "insert into Admin values(" + x + "," + z + ")";
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
        public DataTable ShowApprovedApps(string status)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select a.name as 'App Name',description,version1 As 'Version',p.name,a.price from Person p,Application a Left join Upload u on a.id=u.appID where Approved='"+status+"' and p.id=a.developerID";
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

        public void LoadAdminData(int pID)
        {
            pdl.LoadPersonData(pID);
         
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select p.* from permissions p where p.ID=(Select PID from admin where Aid="+pID+")";
;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    adm.permissionObj.setApproved(reader["Approved"].ToString());
                    adm.permissionObj.setBlkdev(reader["Block"].ToString());
                    adm.permissionObj.setDeldev(reader["D_Developer"].ToString());
                    adm.permissionObj.setDeluser(reader["D_User"].ToString());
                }
                reader.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int LoadAdminDataEmail(String email)
        {

            int id = 0;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select id from person where email='"+email+"'";
                ;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"].ToString());
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }
        public DataTable ShowAllApps()
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select a.name as 'App Name',description,version1 As 'Version',p.name,a.price,u.Approved from Person p,Application a Left join Upload u on a.id=u.appID where p.id=a.developerID";
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
        public DataTable ShowAllAccounts()
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select name As 'Name', email as 'Email', gender As 'Gender', pswd As 'Password', country, status As 'Account Status', userType As 'User Type' from Person where userType!='Admin'";
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

        public DataTable ShowAllAdmins()
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select p.name As 'Name', p.email as 'Email', p.gender As 'Gender', p.country,Approved As 'Approve Apps', D_User As 'Delete User', D_Developer As 'Delete Developer', Block As 'Block Developer' from Permissions per, Person p Left Join Admin a on p.id=a.Aid  where userType='Admin' and per.ID=a.PID";
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

        public bool BlockAccount(string name,string status)
        {
           
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "update person set status='"+status+"' where name='"+name+"'";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool RemoveApp(string name)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "delete from Application where name='" + name + "'";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public bool ApproveOrReject(string name,string status)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "update Upload set Approved='"+status+"' where appID=(Select id from Application where name='"+name+"')";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool DeleteAccount(string email)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "delete from person where email='" + email +"'";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool ModifyAdminData(int id)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "update person set name='" + adm.getName() + "',gender='" + adm.getGender() + "',country='" + adm.getCountry() + "' where id=" + id;
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

                string query1 = "update permissions set approved='" + adm.permissionObj.getApproved() + "',block='" + adm.permissionObj.getBlkdev() + "',D_User='" + adm.permissionObj.getDeluser() + "',D_Developer='" + adm.permissionObj.getDeldev() + "' where id=(Select pid from admin where aid=" + id + ")";
                cmd.CommandText = query1;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
