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
    public partial class frmAdmin : Form
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();

        AdminDBLayer adl;
        bool CheckEmpty()
        {
            foreach (Control c in grpUserInfo.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    if (c.Text == "")
                        return true;
            }
            //foreach (Control c in grpDevice.Controls)
            //{
            //    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
            //        if (c.Text == "")
            //            return true;
            //}
            return false;
        }

        void IntializeBoxes()
        {
            foreach (Control c in grpUserInfo.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    c.Text = "";
            }
            chkappr.Checked = chkdeluser.Checked = chkdeldev.Checked = chkblkdev.Checked = false;




        }

        void LoadAdminData()
        {
            adl.LoadAdminData(id);
            Name_lbl.Text = adl.pdl.perObj.getName();
            Email_lbl.Text = adl.pdl.perObj.getEmail();
            Gender_lbl.Text = adl.pdl.perObj.getGender();
            Country_lbl.Text = adl.pdl.perObj.getCountry();
        }


        int id,modifyID;
        public frmAdmin(int id)
        {
            InitializeComponent();
            obj.assign();
            con = obj.con;
            this.id = id;
            adl = new AdminDBLayer();
            LoadAdminData();
            //GridPendingApps1.DataSource = adl.ShowApprovedApps("No");
            //GridAllApps.DataSource = adl.ShowAllApps();
            //GridApproveApps.DataSource = adl.ShowApprovedApps("Yes");
            //GridBlockAccount.DataSource = adl.ShowAllAccounts();
            //GridAllAdmins.DataSource = adl.ShowAllAdmins();
        }


        private void btnRemoveApp_Click(object sender, EventArgs e)
        {

            try
            {
                if (adl.adm.permissionObj.getApproved() == "Yes")
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int selectedRowCount = GridAllApps.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {

                        string AppName = GridAllApps.SelectedRows[0].Cells[0].Value.ToString();

                        if (adl.RemoveApp(AppName))
                        {
                            MessageBox.Show("App Removed Successfully");
                            GridApproveApps.DataSource = adl.ShowApprovedApps("Yes");
                            GridPendingApps1.DataSource = adl.ShowApprovedApps("No");
                            GridAllApps.DataSource = adl.ShowAllApps();
                        }
                        else
                            MessageBox.Show("App removal Unsuccessful");

                        GridAllApps.DataSource = adl.ShowAllApps();
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to Approve/Remove/Reject any app");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BlockButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (adl.adm.permissionObj.getBlkdev() == "Yes")
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int selectedRowCount = GridBlockAccount.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {

                        string userName = GridBlockAccount.SelectedRows[0].Cells[0].Value.ToString();
                        if (adl.BlockAccount(userName, "Block"))
                            MessageBox.Show("Account Blocked Successfully");
                        else
                            MessageBox.Show("Account Block Unsuccessful");
                        GridBlockAccount.DataSource = adl.ShowAllAccounts();
                        //remove_app_grid();
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to Block any account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (adl.adm.permissionObj.getApproved() == "Yes")
                {
                    if (chkViolence.Checked && chkExpContent.Checked && chkCopyRights.Checked)
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }


                        int selectedRowCount = GridPendingApps1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                        if (selectedRowCount > 0)
                        {

                            string Name = GridPendingApps1.SelectedRows[0].Cells[0].Value.ToString();
                            if (adl.ApproveOrReject(Name, "Yes"))
                            {
                                MessageBox.Show("App Approved Successfully");
                                GridApproveApps.DataSource = adl.ShowApprovedApps("Yes");
                                GridPendingApps1.DataSource = adl.ShowApprovedApps("No");
                                GridAllApps.DataSource = adl.ShowAllApps();
                            }
                            else
                                MessageBox.Show("App Approval Unsuccessful");
                            GridApproveApps.DataSource = adl.ShowApprovedApps("Yes");

                        }
                    }



                    else
                    {
                        MessageBox.Show("App doesnot meet the required Criterias.");
                    }

                }
                else
                {
                    MessageBox.Show("You don't have permission to Approve/Remove/Reject any app");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAdminButton_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (txtPasswordCreate.Text == txtConfirmCreate.Text)
                {
                    if (!CheckEmpty())
                    {

                        string approved = "No", deluser = "No", deldev = "No", blkdev = "No";
                        if (chkappr.Checked)
                            approved = "Yes";


                        if (chkdeluser.Checked)
                        {
                            deluser = "Yes";
                        }

                        if (chkdeldev.Checked)
                        {
                            deldev = "Yes";

                        }
                        if (chkblkdev.Checked)
                        {
                            blkdev = "Yes";
                        }

                        adl.adm.setEmail(txtEmailCreate.Text);
                        adl.adm.setName(txtName.Text);
                        adl.adm.setGender(cmbGender.Text);
                        adl.adm.setPswd(txtPasswordCreate.Text);
                        adl.adm.setCountry(cmbCountry.Text);


                        result = adl.CreateAdmin(approved, deluser, deldev, blkdev);
                        if (result)
                        {
                            MessageBox.Show("Account created successfully");
                            IntializeBoxes();
                            GridAllAdmins.DataSource = adl.ShowAllAdmins();
                        }
                        else
                            MessageBox.Show("Account creation unsuccessful");
                    }
                    else
                    {
                        MessageBox.Show("Some of the fields are empty");
                    }
                }
                else
                {
                    MessageBox.Show("Both Passwords doesn't match");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabApproveApps_Click(object sender, EventArgs e)
        {

        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (adl.adm.permissionObj.getApproved() == "Yes")
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int selectedRowCount = GridPendingApps1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {

                        string Name = GridPendingApps1.SelectedRows[0].Cells[0].Value.ToString();

                        if (adl.ApproveOrReject(Name, "Reject"))
                        {
                            MessageBox.Show("App Rejection Successful");
                            GridApproveApps.DataSource = adl.ShowApprovedApps("Yes");
                            GridPendingApps1.DataSource = adl.ShowApprovedApps("No");
                            GridAllApps.DataSource = adl.ShowAllApps();
                        }
                        else
                            MessageBox.Show("App Rejection Unsuccessful");
                        GridPendingApps1.DataSource = adl.ShowApprovedApps("No");

                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to Approve/Remove/Reject any app");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnblock_Click(object sender, EventArgs e)
        {

            try
            {
                if (adl.adm.permissionObj.getBlkdev() == "Yes")
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int selectedRowCount = GridBlockAccount.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {

                        string userName = GridBlockAccount.SelectedRows[0].Cells[0].Value.ToString();

                        if (adl.BlockAccount(userName, "Active"))
                            MessageBox.Show("Account UnBlocked Successfully");
                        else
                            MessageBox.Show("Account UnBlock Unsuccessful");
                        GridBlockAccount.DataSource = adl.ShowAllAccounts();
                        //remove_app_grid();
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to Unblock any account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridAllAdmins_Paint(object sender, PaintEventArgs e)
        {
            //try
            //{
            //    adl = new AdminDBLayer();
            //    GridAllAdmins.DataSource = adl.ShowAllAdmins();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (adl.adm.permissionObj.getDeldev() == "Yes")
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    int selectedRowCount = GridBlockAccount.Rows.GetRowCount(DataGridViewElementStates.Selected);
                    if (selectedRowCount > 0)
                    {

                        string email = GridBlockAccount.SelectedRows[0].Cells[1].Value.ToString();


                        if (adl.DeleteAccount(email))
                            MessageBox.Show("Account Deleted Successfully");
                        else
                            MessageBox.Show("Account Deletion Unsuccessful");
                        GridBlockAccount.DataSource = adl.ShowAllAccounts();
                        //remove_app_grid();
                    }
                }
                else
                {
                    MessageBox.Show("You don't have permission to Delete any account");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridAllAdmins_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = GridAllAdmins.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {

                    string email = GridAllAdmins.SelectedRows[0].Cells[1].Value.ToString();
                    int idd = adl.LoadAdminDataEmail(email);
                    modifyID = idd;
                    adl.LoadAdminData(idd);
                    txtNameModify.Text = adl.pdl.perObj.getName();
                    txtEmailModify.Text = adl.pdl.perObj.getEmail();
                    cmbGenderModify.Text = adl.pdl.perObj.getGender();
                    cmbCountryModify.Text = adl.pdl.perObj.getCountry();
                    if (adl.adm.permissionObj.getApproved() == "Yes")
                        checkappr.Checked = true;
                    else
                        checkappr.Checked = false;
                    if (adl.adm.permissionObj.getBlkdev() == "Yes")
                        checkblkdev.Checked = true;
                    else
                        checkblkdev.Checked = false;
                    if (adl.adm.permissionObj.getDeldev() == "Yes")
                        checkdeldev.Checked = true;
                    else
                        checkdeldev.Checked = false;
                    if (adl.adm.permissionObj.getDeluser() == "Yes")
                        checkdelusr.Checked = true;
                    else
                        checkdelusr.Checked = false;

                    tabControl2.SelectTab(tabModify);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                adl.adm.setName(txtNameModify.Text);
                adl.adm.setGender(cmbGenderModify.Text);
                adl.adm.setCountry(cmbCountryModify.Text);

                if (checkappr.Checked == true)
                    adl.adm.permissionObj.setApproved("Yes");
                else
                    adl.adm.permissionObj.setApproved("No");

                if (checkblkdev.Checked == true)
                    adl.adm.permissionObj.setBlkdev("Yes");
                else
                    adl.adm.permissionObj.setBlkdev("No");

                if (checkdeldev.Checked == true)
                    adl.adm.permissionObj.setDeldev("Yes");
                else
                    adl.adm.permissionObj.setDeldev("No");

                if (checkdelusr.Checked == true)
                    adl.adm.permissionObj.setDeluser("Yes");
                else
                    adl.adm.permissionObj.setDeluser("No");
                if(adl.ModifyAdminData(modifyID))
                {
                    MessageBox.Show("Admin Modified Successfully");
                    GridAllAdmins.DataSource = adl.ShowAllAdmins();
                }
                else
                {
                    MessageBox.Show("Admin Modifying Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.WhiteSmoke, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Tahoma", 16.0f, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void frmAdmin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.L)
                {
                    tabPage2_Enter(sender, e); ;
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to LogOut?", "Logout", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    frmLogin frm = new frmLogin();
                    this.Hide();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
            GridPendingApps1.DataSource = adl.ShowApprovedApps("No");
            GridAllApps.DataSource = adl.ShowAllApps();
            GridApproveApps.DataSource = adl.ShowApprovedApps("Yes");
            GridBlockAccount.DataSource = adl.ShowAllAccounts();
            GridAllAdmins.DataSource = adl.ShowAllAdmins();
        }


    }
}
