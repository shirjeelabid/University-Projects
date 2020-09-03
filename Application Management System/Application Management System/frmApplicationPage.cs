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
    public partial class frmApplicationPage : Form
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();

        CustomerDBLayer cdb;
        ApplicationDBLayer adb;
        PersonDBLayer pdb;
        int pID;
        int rating;
        decimal size = 0;

        bool CheckEmpty()
        {
            foreach (Control c in grpUserInfo.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    if (c.Text == "")
                        return true;
            }
            foreach (Control c in grpDevice.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    if (c.Text == "")
                        return true;
            }
            return false;
        }

        void IntializeBoxes()
        {
            foreach (Control c in grpUserInfo.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    c.Text = "";
            }
            foreach (Control c in grpDevice.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    c.Text = "";
            }
        }

        void LoadSearchBox()
        {
            try
            {
                adb = new ApplicationDBLayer();
                adb.LoadSearchBox(cmbSearchApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadPersonData()
        {
            try
            {
                pdb = new PersonDBLayer();
                pdb.LoadPersonData(pID);
                txtEmailAcc.Text = pdb.perObj.getEmail();
                txtNameAcc.Text = pdb.perObj.getName();
                txtPasswordAcc.Text = pdb.perObj.getPswd();
                txtCountryAcc.Text = pdb.perObj.getCountry();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool correctUnit(string n)
        {

            if (n == "KB" || n == "MB" || n == "GB" || n == "TB")
                return true;

            return false;
        }
        void AdjustLblPosition(Label lblChange, Label textLbl)
        {
            var loc = lblChange.Location;
            loc.X = textLbl.Location.X + textLbl.Text.Length + 10;
            lblChange.Location = loc;
        }

        void LoadAppData(string AppName)
        {
            txtFeedback.Visible = btnSubmit.Visible = false;
            btnInstall.Visible = true;
            btnUninstall.Visible = true;
            adb = new ApplicationDBLayer();
            adb.getApplicationData(AppName);
            lblAppName.Text = AppName;
            lblDevName.Text = "Developer: " + adb.app.getdevName();
            lblRating.Text = adb.app.getRating() + " * ";
            txtDescription.Text = adb.app.getDescription();
            size = Convert.ToDecimal(adb.app.dev.getCapacity());
            lblSize.Text = Convert.ToString(adb.app.dev.getCapacity()) + " MB";
            lblReviews.Text = adb.LoadReviews(AppName).ToString();
            //var loc = lblReviews.Location;
            //loc.X = lblReviews.Location.X + lblReviews.Text.Length + 10;
            //lblReviewsText.Location = loc;
            AdjustLblPosition(lblReviewsText, lblReviews);
            //AdjustLblPosition(lblDownloadText, lblDownloads);
            //lblReviewsText.Location.X = lblReviews.Text.Length + lblReviewsText.Location.X;
            lblOS.Text = adb.app.dev.getOS();
            decimal p = adb.app.getPrice();
            if ((int)p == 0)
            {
                lblPrice.Text = "Free";
                lblDollar.Visible = false;
            }
            else
            {
                lblPrice.Text = adb.app.getPrice().ToString();
                lblDollar.Visible = true;
            }
            lblDownloads.Text = adb.LoadNoOfDownloads(AppName);
            AdjustLblPosition(lblDownloadText, lblDownloads);
            //tabUserMenu.SelectedTab = this.tabPage10;

            if (adb.CheckInstalled(AppName, pID))
                btnInstall.Visible = false;
            else
                btnUninstall.Visible = false;
            circularProgressBar1.Visible = false;
            circularProgressBar1.Value = 0;
            lblReviewsText.Visible = true;
        }

        void LoadDeviceInfo()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select * from device where ID=(Select DeviceID from Customer where CusID=" + pID + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    c++;
                    txtNameS.Text = reader["name"].ToString();
                    txtOperatingS.Text = reader["OS"].ToString();
                    txtRAMS.Text = (Convert.ToDecimal(reader["RAM"].ToString()) / (1024 * 1024)).ToString() + " GB";
                    txtStorageS.Text = (Convert.ToDecimal(reader["capacity"].ToString()) / (1024 * 1024)).ToString() + " GB";
                }
                reader.Close();
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public frmApplicationPage(int id)
        {
            InitializeComponent();
            timer1.Start();
            tabUserMenu.Hide();
            obj.assign();
            con = obj.con;
            pID = id;
            LoadSearchBox();
            LoadPersonData();
            pictureMain.Focus();
            txtFeedback.Visible = btnSubmit.Visible = false;
            txtFeedback.Text = "Descrbe Your Experience(optional) Upto 100 characters allowed";
            LoadDeviceInfo();
            lblLimit.Visible = false;
            txtBalance.Visible = false;
            grpAppDesc.Visible = false;
            lblReviewsText.Visible = false;
            circularProgressBar1.Visible = false;

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabUserMenu.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabUserMenu.GetTabRect(e.Index);

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

        private void pictureMain_Click(object sender, EventArgs e)
        {
            if (tabUserMenu.Visible)
            {
                tabUserMenu.Hide();
                //pictureMain.Visible = false;
            }
            else
            {
                tabUserMenu.Show();
                //pictureMain.Visible = false;
            }
        }

        private void cmbSearchApp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSearchApp.Text != "Search for apps & games")
                {
                    tabUserMenu.Visible = true;
                    tabUserMenu.SelectedTab = this.tabSearchResults;
                    tabControl5.SelectTab(tabPage9);

                    adb = new ApplicationDBLayer();
                    GridSearchResults.DataSource = adb.LoadGrid(cmbSearchApp.Text);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void picBox1_Click(object sender, EventArgs e)
        {
            picBox1.Image = Properties.Resources.gold_star_png;
            picBox2.Image = Properties.Resources.star_shape_blank;
            picBox3.Image = Properties.Resources.star_shape_blank;
            picBox4.Image = Properties.Resources.star_shape_blank;
            picBox5.Image = Properties.Resources.star_shape_blank;
            rating = 1;
            txtFeedback.Visible = true;
            btnSubmit.Visible = true;
        }

        private void picBox2_Click(object sender, EventArgs e)
        {
            picBox1.Image = Properties.Resources.gold_star_png;
            picBox2.Image = Properties.Resources.gold_star_png;
            picBox3.Image = Properties.Resources.star_shape_blank;
            picBox4.Image = Properties.Resources.star_shape_blank;
            picBox5.Image = Properties.Resources.star_shape_blank;
            rating = 2;
            txtFeedback.Visible = true;
            btnSubmit.Visible = true;
        }

        private void picBox3_Click(object sender, EventArgs e)
        {
            picBox1.Image = Properties.Resources.gold_star_png;
            picBox2.Image = Properties.Resources.gold_star_png;
            picBox3.Image = Properties.Resources.gold_star_png;
            picBox4.Image = Properties.Resources.star_shape_blank;
            picBox5.Image = Properties.Resources.star_shape_blank;
            rating = 3;
            txtFeedback.Visible = true;
            btnSubmit.Visible = true;
        }

        private void picBox4_Click(object sender, EventArgs e)
        {
            picBox1.Image = Properties.Resources.gold_star_png;
            picBox2.Image = Properties.Resources.gold_star_png;
            picBox3.Image = Properties.Resources.gold_star_png;
            picBox4.Image = Properties.Resources.gold_star_png;
            picBox5.Image = Properties.Resources.star_shape_blank;
            rating = 4;
            txtFeedback.Visible = true;
            btnSubmit.Visible = true;
        }

        private void picBox5_Click(object sender, EventArgs e)
        {
            picBox1.Image = Properties.Resources.gold_star_png;
            picBox2.Image = Properties.Resources.gold_star_png;
            picBox3.Image = Properties.Resources.gold_star_png;
            picBox4.Image = Properties.Resources.gold_star_png;
            picBox5.Image = Properties.Resources.gold_star_png;
            rating = 5;
            txtFeedback.Visible = true;
            btnSubmit.Visible = true;
        }

        private void GridSearchResults_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                grpSelectCard.Visible = false;
                int selectedRowCount = GridSearchResults.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {

                    string AppName = GridSearchResults.SelectedRows[0].Cells[0].Value.ToString();
                    LoadAppData(AppName);
                    grpAppDesc.Visible = true;
                    tabControl5.SelectTab(tabPage10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {

                cdb = new CustomerDBLayer();
                if (lblPrice.Text == "Free")
                {

                    decimal size1 = size / 2;



                    if (cdb.InstallApp(lblAppName.Text, pID))
                    {
                        circularProgressBar1.Visible = true;
                        for (int i = 0; i < 100; i++)
                        {
                            int a = (int)size1 / 100;
                            System.Threading.Thread.Sleep(a * 10);
                            circularProgressBar1.Value = i;
                            circularProgressBar1.Text = i.ToString() + " %";
                        }
                        MessageBox.Show("App Installed Successfully");
                        circularProgressBar1.Visible = false;
                        circularProgressBar1.Value = 0;
                        btnInstall.Visible = false;
                        btnUninstall.Visible = true;
                        adb = new ApplicationDBLayer();
                        lblDownloads.Text = adb.LoadNoOfDownloads(lblAppName.Text);
                        LoadDeviceInfo();
                    }
                    else
                        MessageBox.Show("App Installation Unsuccessful");
                }
                else
                {
                    tabControl5.SelectTab(tabPage11);
                    txtPayment.Text = lblPrice.Text;
                    grpSelectCard.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPasswordCreate.Text == txtConfirmCreate.Text)
                {
                    if (!CheckEmpty())
                    {
                        if (txtPasswordCreate.TextLength < 8)
                        {
                            MessageBox.Show("Password show be of atLeast 8 Characters");
                            return;
                        }
                        string input = txtPasswordCreate.Text;
                        bool isDigitPresent = input.Any(a => char.IsDigit(a));
                        if (!isDigitPresent)
                        {
                            MessageBox.Show("Password show contain atLeast 1 digit");
                            return;
                        }
                        if (!correctUnit(cmbUnitRam.Text))
                        {
                            MessageBox.Show("Invlalid Ram Unit");
                            return;
                        }
                        if (!correctUnit(cmbUnitStr.Text))
                        {
                            MessageBox.Show("Invlalid Capacity Unit");
                            return;
                        }

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        string query = "select * from Person where email='" + txtEmailCreate.Text + "'";
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

                            query = "insert into Person values('" + txtName.Text + "','" + txtEmailCreate.Text + "','" + cmbGender.Text + "','" + txtPasswordCreate.Text + "','" + cmbCountry.Text + "','Active','Customer'" + ")";
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();
                            decimal Ram = 1, Storage = 1;
                            if (cmbUnitStr.Text == "TB")
                                Storage = Convert.ToDecimal(txtStorage.Text) * 1024 * 1024 * 1024;
                            else if (cmbUnitStr.Text == "GB")
                                Storage = Convert.ToDecimal(txtStorage.Text) * 1024 * 1024;
                            else if (cmbUnitStr.Text == "MB")
                                Storage = Convert.ToDecimal(txtStorage.Text) * 1024;
                            else if (cmbUnitStr.Text == "KB")
                                Storage = Convert.ToDecimal(txtStorage.Text) * 1;
                            else
                            {
                                MessageBox.Show("Invalid Storage Capacity Unit");
                                return;
                            }
                            if (cmbUnitRam.Text == "TB")
                                Ram = Convert.ToDecimal(txtRAM.Text) * 1024 * 1024 * 1024;
                            else if (cmbUnitRam.Text == "GB")
                                Ram = Convert.ToDecimal(txtRAM.Text) * 1024 * 1024;
                            else if (cmbUnitRam.Text == "MB")
                                Ram = Convert.ToDecimal(txtRAM.Text) * 1024;
                            else if (cmbUnitRam.Text == "KB")
                                Ram = Convert.ToDecimal(txtRAM.Text) * 1;
                            else
                            {
                                MessageBox.Show("Invalid RAM Unit");
                                return;
                            }
                            cmd.CommandText = "insert into Device values('" + txtDevName.Text + "','" + txtOS.Text + "'," + Ram + "," + Storage + ")";
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

                            MessageBox.Show("Account created successfully");
                            IntializeBoxes();
                        }
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
        private void tabPage4_Paint(object sender, PaintEventArgs e)
        {
            adb = new ApplicationDBLayer();
            GridInstalled.DataSource = adb.LoadInstalledData(pID);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                cdb = new CustomerDBLayer();
                if (cdb.UninstallApp(lblAppName.Text, pID))
                {
                    MessageBox.Show("App Uninstalled Successfully");
                    btnInstall.Visible = true;
                    btnUninstall.Visible = false;
                    adb = new ApplicationDBLayer();
                    adb.LoadNoOfDownloads(lblAppName.Text);
                    LoadDeviceInfo();
                }
                else
                    MessageBox.Show("App Uninstall Unsuccessful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            adb = new ApplicationDBLayer();
            GridLibrary.DataSource = adb.LoadUnInstalledData(pID);
        }

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
            adb = new ApplicationDBLayer();
            GridUpdates.DataSource = adb.LoadUpdateData(pID);
        }

        private void GridUpdates_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                grpSelectCard.Visible = false;
                grpAppDesc.Visible = false;
                int selectedRowCount = GridUpdates.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    grpAppDesc.Visible = true;
                    string AppName = GridUpdates.SelectedRows[0].Cells[0].Value.ToString();
                    LoadAppData(AppName);
                    tabUserMenu.SelectTab(tabSearchResults);
                    tabControl5.SelectTab(tabPage10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridInstalled_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                grpSelectCard.Visible = false;
                grpAppDesc.Visible = false;
                int selectedRowCount = GridInstalled.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    grpAppDesc.Visible = true;
                    string AppName = GridInstalled.SelectedRows[0].Cells[0].Value.ToString();
                    LoadAppData(AppName);
                    tabUserMenu.SelectTab(tabSearchResults);
                    tabControl5.SelectTab(tabPage10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridLibrary_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                grpSelectCard.Visible = false;
                grpAppDesc.Visible = false;
                int selectedRowCount = GridLibrary.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    grpAppDesc.Visible = true;
                    string AppName = GridLibrary.SelectedRows[0].Cells[0].Value.ToString();
                    LoadAppData(AppName);
                    tabUserMenu.SelectTab(tabSearchResults);
                    tabControl5.SelectTab(tabPage10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            adb = new ApplicationDBLayer();
            GridRecommended.DataSource = adb.LoadRecommendedApps(pID);
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "select name as 'Categories' from Category";
                //SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridCategories.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridCategories_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = GridCategories.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {

                    string cName = GridCategories.SelectedRows[0].Cells[0].Value.ToString();

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select a.name as 'Application Name', category, rating, p.name as 'Developer Name', price from Application a left join Person p on p.id=developerID where category='" + cName + "'";
                    //SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridSearchResults.DataSource = dt;
                    con.Close();

                    tabUserMenu.SelectTab(tabSearchResults);
                    tabControl5.SelectTab(tabPage9);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridRecommended_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                grpSelectCard.Visible = false;
                int selectedRowCount = GridRecommended.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {

                    string cName = GridRecommended.SelectedRows[0].Cells[0].Value.ToString();
                    grpAppDesc.Visible = true;
                    LoadAppData(cName);
                    tabUserMenu.SelectTab(tabSearchResults);
                    tabControl5.SelectTab(tabPage10);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFeedback_Enter(object sender, EventArgs e)
        {
            txtFeedback.Text = "";
        }

        private void txtFeedback_Leave(object sender, EventArgs e)
        {
            if (txtFeedback.Text != "Descrbe Your Experience(optional) Upto 100 characters allowed")
            {
                if (txtFeedback.Text == "")
                    txtFeedback.Text = "Descrbe Your Experience(optional) Upto 100 characters allowed";
            }
        }

        private void cmbSearchApp_Enter(object sender, EventArgs e)
        {
            cmbSearchApp.Text = "";
            adb.LoadSearchBox(cmbSearchApp);
        }

        private void cmbSearchApp_Leave(object sender, EventArgs e)
        {
            if (cmbSearchApp.Text != "Search for apps & games")
            {
                if (cmbSearchApp.Text == "")
                    cmbSearchApp.Text = "Search for apps & games";
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                String x;
                if (txtFeedback.Text == "Descrbe Your Experience(optional) Upto 100 characters allowed")
                    x = " ";
                else
                    x = x = txtFeedback.Text;
                string query = "select id from Application where name='" + lblAppName.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                string id = "";
                int c = 0;
                while (reader.Read())
                {
                    if (reader["id"] != DBNull.Value)
                        id = reader["id"].ToString();
                    c++;
                }
                reader.Close();
                if (c != 0)
                {
                    query = "insert into Feedback values(" + id + ",'" + x + "'," + rating + ")";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    reader.Close();
                    query = "select CAST(avg(rating) As dec(3,2)) as 'avg' from Feedback where aid=" + id;
                    cmd.CommandText = query;
                    reader = cmd.ExecuteReader();
                    string z = "0";
                    while (reader.Read())
                    {
                        if (reader["avg"] != DBNull.Value)
                            z = reader["avg"].ToString();
                    }
                    reader.Close();
                    query = "update Application set rating=" + z + " where id=" + id;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Feedback Submitted Successfully");
                    adb = new ApplicationDBLayer();
                    lblReviews.Text = adb.LoadReviews(lblAppName.Text).ToString();
                    adb = new ApplicationDBLayer();
                    GridSearchResults.DataSource = adb.LoadGrid("");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtConfirmPasswd.TextLength < 8)
                {
                    MessageBox.Show("Password must be of atLeast 8 Characters");
                    return;
                }
                string input = txtConfirmPasswd.Text;
                bool isDigitPresent = input.Any(a => char.IsDigit(a));
                if (!isDigitPresent)
                {
                    MessageBox.Show("Password must contain atLeast 1 digit");
                    return;
                }
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "update Person set pswd='" + txtConfirmPasswd.Text + "' where id=" + pID;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password changed successfully");
                con.Close();
                txtNewPassword.Text = txtConfirmPasswd.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStorage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCardType.Text == "Credit")
            {
                lblLimit.Visible = true;
                txtBalance.Visible = true;
                lblDol.Visible = true;
                lblLimit.Text = "Limit";
            }
            else if (cmbCardType.Text == "Debit")
            {
                lblLimit.Visible = true;
                txtBalance.Visible = true;
                lblDol.Visible = true;
                lblLimit.Text = "Balance";
            }
            else
            {
                lblLimit.Visible = false;
                txtBalance.Visible = false;
                lblDol.Visible = false;
            }

        }

        private void tabPage6_Paint(object sender, PaintEventArgs e)
        {
            //lblLimit.Visible = false;
            //txtBalance.Visible = false;
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            cdb = new CustomerDBLayer();
            if (cdb.AddCard(txtCardNo.Text, pID, cmbCardType.Text, Convert.ToDecimal(txtBalance.Text)))
            {
                MessageBox.Show("Card Added Successfully");
                txtCardNo.Text = cmbCardType.Text = txtBalance.Text = "";
            }
            else
            {
                MessageBox.Show("Card Adding Unsuccessful");
            }

        }

        private void txtCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.')
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void btnProceed_Click(object sender, EventArgs e)
        {

            cdb = new CustomerDBLayer();
            int cID = cdb.MakePayment(txtSelectCardNo.Text, pID, cmbSelectCardType.Text, Convert.ToDecimal(txtPayment.Text));

            if (cID != 0)
            {
                decimal size1 = size / 2;
                MessageBox.Show("Payment Successful");
                if (cdb.InstallApp(lblAppName.Text, pID))
                {
                    circularProgressBar1.Visible = true;
                    for (int i = 0; i < 100; i++)
                    {
                        int a = (int)size1 / 100;
                        System.Threading.Thread.Sleep(a * 10);
                        circularProgressBar1.Value = i;
                        circularProgressBar1.Text = i.ToString() + " %";
                    }
                    MessageBox.Show("App Installed Successfully");
                    btnInstall.Visible = false;
                    btnUninstall.Visible = true;
                    adb = new ApplicationDBLayer();
                    adb.LoadNoOfDownloads(lblAppName.Text);
                }
                else
                {
                    //Rollback payment is called

                    MessageBox.Show("App Installation Unsuccessful");
                    if (cdb.RollbackPayment(cID, cmbSelectCardType.Text, Convert.ToDecimal(txtPayment.Text)))
                        MessageBox.Show("Payment Rollback Successfully");
                    else
                        MessageBox.Show("Payment Rollback Unsuccessful");
                }

            }
            else
            {
                MessageBox.Show("Payment Unsuccessful");

            }
        }

        private void frmApplicationPage_Load(object sender, EventArgs e)
        {

        }

        private void tabPage12_Click(object sender, EventArgs e)
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

        private void frmApplicationPage_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.L)
                {
                    tabPage12_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lblTime.Text = dt.ToShortTimeString();
            lblDate.Text = dt.ToLongDateString();
        }

    }
}