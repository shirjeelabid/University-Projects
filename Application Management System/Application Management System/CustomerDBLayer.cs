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
    class CustomerDBLayer
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();
        Application1 appObj;
        public Customer cusObj;

        public CustomerDBLayer()
        {
            cusObj = new Customer();
            appObj = new Application1();
            obj.assign();
            con = obj.con;
        }
        public bool CreateCustomer(string RamUnit, string StorageUnit)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select * from Person where email='" + cusObj.getEmail() + "'";
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
                    query = "insert into Person values('" + cusObj.getName() + "','" + cusObj.getEmail() + "','" + cusObj.getGender() + "','" + cusObj.getPswd() + "','" + cusObj.getCountry() + "','Active','Customer'" + ")";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    decimal Ram = 1, Storage = 1;
                    if (StorageUnit == "TB" || StorageUnit == "GB" || StorageUnit == "MB" || StorageUnit == "KB")
                        Storage =cusObj.device.ConvertToKB(cusObj.device.getCapacity(), StorageUnit);

                    else
                    {
                        MessageBox.Show("Invalid Storage Capacity Unit");
                        return false;
                    }
                    if (RamUnit == "TB" || RamUnit == "GB" || RamUnit == "MB" || RamUnit == "KB")
                        Ram = cusObj.device.ConvertToKB(cusObj.device.getRam(), RamUnit);
                    else
                    {
                        MessageBox.Show("Invalid Storage Capacity Unit");
                        return false;
                    }

                    cmd.CommandText = "insert into Device values('" + cusObj.device.getName() + "','" + cusObj.device.getOS() + "'," + Ram + "," + Storage + ")";
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
                    cmd.CommandText = "select max(id) as 'max' from Device";
                    reader = cmd.ExecuteReader();
                    int z = 0;
                    while (reader.Read())
                    {
                        if (reader["max"] != DBNull.Value)
                            z = Convert.ToInt32(reader["max"].ToString());
                    }
                    reader.Close();
                    cmd.CommandText = "insert into Customer values(" + x + "," + z + ")";
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
        public int getApplicationData(string AppName)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select a.id as 'appID',d.* from Application a FULL outer join Device d on a.deviceID=d.id where a.name='" + AppName + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int z = 0;

                while (reader.Read())
                {
                    z = Convert.ToInt32(reader["appID"].ToString());
                    cusObj.app.dev.setOS(reader["OS"].ToString());
                    cusObj.app.dev.setRam(Convert.ToDecimal(reader["RAM"].ToString()));
                    cusObj.app.dev.setCapacity(Convert.ToDecimal(reader["capacity"].ToString()));
                }
                reader.Close();
                return z;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        void getDeviceData(int pID)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select d.* from Customer a Left join Device d on a.deviceID=d.id where a.CusID=" + pID;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cusObj.device.setID(Convert.ToInt32(reader["id"].ToString()));
                    cusObj.device.setOS(reader["OS"].ToString());
                    cusObj.device.setRam(Convert.ToDecimal(reader["Ram"].ToString()));
                    cusObj.device.setCapacity(Convert.ToDecimal(reader["capacity"].ToString()));
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool InstallApp(String name, int UserID)
        {
            try
            {
                int id = getApplicationData(name);
                getDeviceData(UserID);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //string query = "select * from device where ID=(Select DeviceID from Customer where CusID=" + UserID+")";
                SqlCommand cmd = new SqlCommand("", con);
                SqlDataReader reader;

                String str1 = "", str2 = "";
                if (cusObj.app.dev.getOS() != "")
                    str1 = cusObj.app.dev.getOS().ToLower();
                if (cusObj.device.getOS() != "")
                    str2 = cusObj.device.getOS().ToLower();
                string query;
                if (cusObj.app.dev.getCapacity() <= cusObj.device.getCapacity() && cusObj.app.dev.getRam() <= cusObj.device.getRam() && String.Compare(str1, str2) == 0)
                {
                    DateTimeOffset local_offset = new DateTimeOffset(DateTime.Now);
                    DateTimeOffset utc_offset = local_offset.ToUniversalTime();
                    //lblGmtTime.Text = utc_offset.DateTime.ToShortTimeString();
                    //lblGmtDate.Text = utc_offset.DateTime.ToShortDateString();
                    query = "select * from Install where appID=" + id + " and CusID=" + UserID;
                    cmd.CommandText = query;
                    reader = cmd.ExecuteReader();
                    int c = 0;
                    while (reader.Read())
                    {
                        c++;
                    }
                    reader.Close();
                    if (c > 0)
                        query = "update install set iDate='" + utc_offset.DateTime.ToShortDateString() + "',iTime='" + utc_offset.DateTime.ToShortTimeString() + "',status='installed' where appID=" + id + " and CusID=" + UserID;
                    else
                        query = "insert into Install values(" + UserID + "," + id + ",'" + utc_offset.DateTime.ToShortDateString() + "','" + utc_offset.DateTime.ToShortTimeString() + "','installed')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    decimal cap = cusObj.device.getCapacity() - cusObj.app.dev.getCapacity();
                    query = "update device set capacity=" + cap + " where id=" + cusObj.device.getID();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    MessageBox.Show("Insufficient Storage/RAM for this application");
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool UninstallApp(String name, int UserID)
        {
            try
            {
                int id = getApplicationData(name);
                getDeviceData(UserID);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("", con);

                string query;

                query = "update install set status='uninstalled' where appID=" + id + " and cusID=" + UserID;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                decimal cap = cusObj.device.getCapacity() + cusObj.app.dev.getCapacity();
                query = "update device set capacity=" + cap + " where id=" + cusObj.device.getID();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool AddCard(string cardNo, int userID, string cardType, decimal limit)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query;
                SqlCommand cmd = new SqlCommand(" ", con);
                SqlDataReader reader;
                int CID = 0;
                if (cardType == "Credit")
                {
                    query = "insert into Credit values(0," + limit + ")";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select max(ID) As 'max' from Credit";
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["max"] != DBNull.Value)
                            CID = Convert.ToInt32(reader["max"].ToString());
                    }
                    reader.Close();
                    cmd.CommandText = "insert into Bank values('" + cardNo + "'," + userID + "," + CID + ",'" + cardType + "')";
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else if (cardType == "Debit")
                {
                    query = "insert into Debit values(" + limit + ")";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select max(ID) As 'max' from Debit";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader["max"] != DBNull.Value)
                            CID = Convert.ToInt32(reader["max"].ToString());
                    }
                    reader.Close();
                    cmd.CommandText = "insert into Bank values('" + cardNo + "'," + userID + "," + CID + ",'" + cardType + "')";
                    cmd.ExecuteNonQuery();
                    return true;
                }


                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int MakePayment(string cardNo, int userID, string cardType, decimal payment)
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query;
                SqlCommand cmd = new SqlCommand(" ", con);
                SqlDataReader reader;
                int CID = 0, c = 0;
                query = "select * from Bank where CardNumber='" + cardNo + "' and HID=" + userID + " and cardType='" + cardType + "'";
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    if (reader["CardID"] != DBNull.Value)
                        CID = Convert.ToInt32(reader["CardID"].ToString());
                    c++;
                }
                reader.Close();
                if (c != 0)
                {
                    if (cardType == "Credit")
                    {
                        decimal spent = 0, limit = 0;
                        cmd.CommandText = "select * from Credit where id=" + CID;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            spent = Convert.ToDecimal(reader["spent"].ToString());
                            limit = Convert.ToDecimal(reader["limit"].ToString());
                        }
                        reader.Close();
                        if (spent + payment <= limit)
                        {
                            spent = spent + payment;
                            string query2 = "update Credit set spent=" + spent + " where id=" + CID;
                            cmd.CommandText = query2;
                            cmd.ExecuteNonQuery();
                            return CID;
                        }
                        else
                        {
                            MessageBox.Show("Payment greater than credit card limit");
                            return 0;
                        }
                    }
                    else if (cardType == "Debit")
                    {
                        decimal spent = 0;
                        cmd.CommandText = "select * from Debit where id=" + CID;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            spent = Convert.ToDecimal(reader["spent"].ToString());
                        }
                        reader.Close();
                        if (payment <= spent)
                        {
                            spent = spent - payment;
                            string query2 = "update Debit set spent=" + spent + " where id=" + CID;
                            cmd.CommandText = query2;
                            cmd.ExecuteNonQuery();
                            return CID;
                        }
                        else
                        {
                            MessageBox.Show("Payment greater than debit card amount");
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return 0;
        }
        //incomplete
        public bool RollbackPayment(int cID, string cardType, decimal payment)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                
                SqlCommand cmd = new SqlCommand(" ", con);
                SqlDataReader reader;
                
                if (cardType == "Credit")
                {
                    decimal spent = 0;
                    cmd.CommandText = "select * from Credit where id=" + cID;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        spent = Convert.ToDecimal(reader["spent"].ToString());

                    }
                    reader.Close();

                    spent = spent - payment;
                    string query2 = "update Credit set spent=" + spent + " where id=" + cID;
                    cmd.CommandText = query2;
                    cmd.ExecuteNonQuery();
                    return true;

                }
                else if (cardType == "Debit")
                {
                    decimal spent = 0;
                    cmd.CommandText = "select * from Debit where id=" + cID;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        spent = Convert.ToDecimal(reader["spent"].ToString());
                    }
                    reader.Close();

                    spent = spent + payment;
                    string query2 = "update Debit set spent=" + spent + " where id=" + cID;
                    cmd.CommandText = query2;
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
    }
}
