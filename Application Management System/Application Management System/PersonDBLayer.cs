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
    class PersonDBLayer
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();

        public Person perObj;
        public PersonDBLayer()
        {
            perObj = new Person();
            obj.assign();
            con = obj.con;
        }
        public void LoadPersonData(int pID)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select * from person where id=" + pID;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    c++;
                    perObj.setId(pID);
                    perObj.setEmail(reader["email"].ToString());
                    perObj.setName(reader["name"].ToString());
                    perObj.setPswd(reader["pswd"].ToString());
                    perObj.setGender(reader["gender"].ToString());
                    perObj.setCountry(reader["country"].ToString());
                }
                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
