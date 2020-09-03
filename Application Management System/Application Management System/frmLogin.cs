using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Management_System
{
    public partial class frmLogin : Form
    {
        SqlConnection con = new SqlConnection();
        SQLConn obj = SQLConn.getInstance();
        public frmLogin()
        {
            InitializeComponent();
            obj.assign();
            con = obj.con;
        }
        void showApprovalMessage()
        {
            string query = "";
            SqlCommand cmd;
            SqlDataReader reader;
            int c = 0;
            string name = "";
            query = "select name from Application where id IN (select  appID from Upload where Approved = 'Reject')";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                c++;
                name += reader["name"].ToString() + ",";
            }

            if (c > 0)
            {
                MessageBox.Show(name + " was removed due to rejection by admin!");


                query = "delete from Application where id IN (select  appID from Upload where Approved = 'Reject')";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                query = "Delete from Upload where Approved = 'Reject' ";
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmailAcc.Text == "")
                    MessageBox.Show("Please enter email address");
                else
                {
                    if (txtPasswordAcc.Text == "")
                        MessageBox.Show("Please enter password");
                    else
                    {
                        if (cmbUserType.Text == "")
                            MessageBox.Show("Please select user type");
                        else
                        {
                            if (con.State == ConnectionState.Closed)
                                con.Open();
                            string query = "select * from person where email='" + txtEmailAcc.Text + "' and pswd='" + txtPasswordAcc.Text + "' and userType='" + cmbUserType.Text + "'";
                            SqlCommand cmd = new SqlCommand(query, con);
                            SqlDataReader reader = cmd.ExecuteReader();
                            int c=0;
                            int id=0;
                            string status = "";
                            while(reader.Read())
                            {
                                c++;
                                id = Convert.ToInt32(reader["id"].ToString());
                                status = reader["status"].ToString();
                            }

                            reader.Close();
                            if(c==1)
                            {
                                if (status == "Active")
                                {
                                    if (cmbUserType.Text == "Customer")
                                    {
                                        frmApplicationPage frm = new frmApplicationPage(id);
                                        this.Hide();
                                        frm.Show();
                                    }

                                    else if (cmbUserType.Text == "Developer")
                                    {
                                        frmDeveloper frm = new frmDeveloper(id);
                                        this.Hide();
                                        frm.Show();
                                        showApprovalMessage();
                                    }
                                    else if (cmbUserType.Text == "Admin")
                                    {
                                        frmAdmin frm = new frmAdmin(id);
                                        this.Hide();
                                        frm.Show();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid user type selected");
                                    }
                                }
                                else
                                    MessageBox.Show("Your account has been blocked by the Admin");
  
                            }
                            else
                            {
                                MessageBox.Show("Incorrect email or password");
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCreateAccount frm = new frmCreateAccount();
            this.Hide();
            frm.Show();
        }

        private void txtEmailAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCreate_Click(sender, e);
        }
    }
}
