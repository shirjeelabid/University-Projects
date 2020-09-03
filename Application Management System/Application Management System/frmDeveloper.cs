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

namespace Application_Management_System
{
    public partial class frmDeveloper : Form
    {
        SqlConnection con;
        SQLConn obj = SQLConn.getInstance();
        string query;
        SqlCommand cmd;
        SqlDataReader reader;
        AppDBLayer ADB;
        int id;

        void LoadData()
        {
            fillCBs();

            if (con.State == ConnectionState.Closed)
                con.Open();

            try
            {
                query = "select id,name,email from person where id = " + Convert.ToString(id);

                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DeveloperID_lbl.Text = reader["id"].ToString();
                    Name_lbl.Text = reader["name"].ToString();
                    Email_lbl.Text = reader["email"].ToString();
                }
                reader.Close();
                updateCount();
                updateAverageRating();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillCBs()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                query = "select name from Application where developerID = " + Convert.ToString(id);

                cmd = new SqlCommand(query, con);
                var readTable = cmd.ExecuteReader();
                if (RemoveAppCB.Items.Count > 0)
                    RemoveAppCB.Items.Clear();
                if (UpdateAppCB.Items.Count > 0)
                    UpdateAppCB.Items.Clear();
                while (readTable.Read())
                {
                    RemoveAppCB.Items.Add(Convert.ToString(readTable["name"]));
                    UpdateAppCB.Items.Add(Convert.ToString(readTable["name"]));
                }

                readTable.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string getCount()
        {
            try
            {
                string n = "";
                query = "Select count(*) as X from Application where developerID = " + Convert.ToString(id);
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    n = reader["X"].ToString();
                }
                reader.Close();
                return n;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        void updateCount()
        {

            AppsDeveloped_lbl.Text = getCount();
        }
        void updateAverageRating()
        {

            try
            {
                double apps_developed = Convert.ToDouble(getCount());

                if (apps_developed == 0)
                {
                    AverageRating_lbl.Text = "0.0";
                    return;
                }

                double rating = 0.0;
                query = "select rating from Application where developerID = " + Convert.ToString(id);
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rating += Convert.ToDouble(reader["rating"].ToString());
                }
                reader.Close();

                rating /= apps_developed;

                AverageRating_lbl.Text = Convert.ToString(rating);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void fillsearchGrid(string query)
        {
            GridSearchResults.DataSource = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;
                DataTable DT1 = new DataTable();
                SDA.Fill(DT1);
                GridSearchResults.DataSource = DT1;
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        decimal toKBs(string n)
        {
            decimal size = Convert.ToDecimal(n);
            if (NewSizeUnitCB.Text == "TB")
                size *= 1024 * 1024 * 1024;

            else if (NewSizeUnitCB.Text == "GB")
                size *= 1024 * 1024;

            else if (NewSizeUnitCB.Text == "MB")
                size *= 1024;

            return size;
        }
        bool correctUnit(string n)
        {

            if (n == "KB" || n == "MB" || n == "GB" || n == "TB")
                return true;

            return false;
        }
        bool CheckEmpty(GroupBox g)
        {
            foreach (Control c in g.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(RichTextBox) || c.GetType() == typeof(ComboBox))
                    if (c.Text == "")
                        return true;
            }
            foreach (Control c in g.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    if (c.Text == "")
                        return true;
            }
            return false;
        }
        void IntializeBoxes(GroupBox g)
        {
            foreach (Control c in g.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(RichTextBox) || c.GetType() == typeof(ComboBox))
                    c.Text = "";
            }
            foreach (Control c in g.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    c.Text = "";
            }

            FreeRB.Checked = false;
            PaidRB.Checked = false;
            AppCostTB.Text = "";
        }

        public frmDeveloper(int id)
        {
            InitializeComponent();
            obj.assign();
            con = obj.con;
            con.Open();

            this.id = id;
            LoadData();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Cost_lbl.Visible = true;
            AppCostTB.Visible = true;
            FreeRB.Checked = false;
        }
        private void FreeRB_CheckedChanged(object sender, EventArgs e)
        {
            Cost_lbl.Visible = false;
            AppCostTB.Visible = false;
            PaidRB.Checked = false;
        }
        private void RemoveTab_Click(object sender, EventArgs e)
        {

        }
        private void UploadBTN_Click(object sender, EventArgs e)
        {
            if (CheckEmpty(groupBox1))
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else if(!FreeRB.Checked&&!PaidRB.Checked)
            {
                MessageBox.Show("Select Free/Paid Option");
            }
            else if (!correctUnit(AppSizeCB.Text))
            {
                MessageBox.Show("Size Unit not correct!");
            }

            else if (!correctUnit(RAMCB.Text))
            {
                MessageBox.Show("RAM unit not correct!");

            }
            else if(PaidRB.Checked&&AppCostTB.Text=="")
            {
                MessageBox.Show("Please enter cost");
            }
            /*Application1 app = new Application1();
            app.setName(AppNameTB.Text);
            app.setCategory(CategoryCB.Text);
            app.setDescription(AppDescriptonTB.Text);
            app.setVersion(VersionTB.Text);
            app.setRating("0.0");
            app.dev.setOS(OSCB.Text);
            */
            else
            {
                Device dev = new Device();
                decimal size = dev.ConvertToKB(Convert.ToDecimal(AppSizeTB.Text), AppSizeCB.Text);

                toKBs(AppSizeTB.Text);
                decimal ram = dev.ConvertToKB(Convert.ToDecimal(RAMTB.Text), RAMCB.Text);


                String price = "0.0";
                if (PaidRB.Checked)
                    price = AppCostTB.Text;

                ADB = new AppDBLayer();

                ADB.developer.app.dev.setCapacity(size);
                ADB.developer.app.dev.setRam(ram);
                ADB.developer.app.dev.setOS(OSCB.Text);
                ADB.developer.app.setName(AppNameTB.Text);
                ADB.developer.app.setCategory(CategoryCB.Text);
                ADB.developer.app.setDescription(AppDescriptonTB.Text);
                ADB.developer.app.setVersion(VersionTB.Text);
                ADB.developer.app.setRating("0.0");
                ADB.developer.app.setPrice(Convert.ToDecimal(price));

                //if (con.State == ConnectionState.Closed)
                //    con.Open();

                //query = "insert into device (OS,RAM,capacity) values('" + OSCB.Text + "',"+Convert.ToString(ram)+"," + Convert.ToString(size) + ")";
                //cmd.CommandText = query;
                //cmd.ExecuteNonQuery();

                //String DevID = "";
                //int c = 0;

                //query = "select max(id) as X from Device";
                //cmd = new SqlCommand(query, con);
                //reader = cmd.ExecuteReader();

                // while (reader.Read())
                // {
                //     c++;
                //     DevID = reader["X"].ToString();
                // }
                // reader.Close();



                //query = "Insert into Application Values('" + AppNameTB.Text + "','" + AppDescriptonTB.Text + "','" + VersionTB.Text + "','" + CategoryCB.Text + "','0.0'," + Convert.ToString(id) + "," + price + "," +DevID+",'Yes')";
                //cmd.CommandText = query;
                //cmd.ExecuteNonQuery();

                if (ADB.UploadApp(id))
                {
                    MessageBox.Show("App Uploaded Successfully");
                    updateCount();
                    fillCBs();
                    IntializeBoxes(groupBox1);
                }
                else
                {
                    MessageBox.Show("App Upload Failed");
                }
            }
        }
        private void RemoveAppBTN_Click(object sender, EventArgs e)
        {
            ADB = new AppDBLayer();

            if (RemoveAppCB.Text == "")
                MessageBox.Show("Please enter App Name!");
            else if(RemoveAppCB.Text=="App Name")
            {

            }

            else
            {
                try
                {
                    ADB.developer.app.setName(RemoveAppCB.Text);
                    if (ADB.RemoveApp())
                    {
                        MessageBox.Show("App removed Successfully!");
                        RemoveAppCB.Text = "";
                        RemoveAppCB.Items.Clear();
                        AppNamelbl.Text = "";
                        AppVlbl.Text = "";
                        AppCatlbl.Text = "";
                        AppOSlbl.Text = "";
                        updateCount();
                        fillCBs();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RemoveAppCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String appname = RemoveAppCB.Text;

                if (con.State == ConnectionState.Closed)
                    con.Open();

                query = "select d.OS,a.name,version1,category from Application a,Device d where a.name = '" + appname + "' and a.deviceID = d.id";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AppNamelbl.Text = reader["name"].ToString();
                    AppCatlbl.Text = reader["category"].ToString();
                    AppVlbl.Text = reader["version1"].ToString();
                    AppOSlbl.Text = reader["OS"].ToString();
                }
                reader.Close();
                grpAppInfo.Visible = true;
            }
            catch(Exception ex)
            {
                
            }

        }
        private void ShowAppsBTN_Click(object sender, EventArgs e)
        {
            GridSearchResults.DataSource = null;
            ADB = new AppDBLayer();
            GridSearchResults.DataSource = ADB.viewApps(id);
        }
        private void GridSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GridSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void GridSearchResults_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ViewThenRemoveBTN.Visible = true;
            ViewThenUpdateBTN.Visible = true;
            FeedbackBTN.Visible = true;
        }
        private void ViewThenRemoveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveAppCB.Text = GridSearchResults.SelectedRows[0].Cells[1].Value.ToString();
                GridSearchResults.DataSource = null;
                DeveloperTabs.SelectTab(ManageAppTab);
                ManageAppSubTabs.SelectTab(RemoveTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*
            developer = new Developer();
            try
            {
                if (developer.RemoveApp())
                {
                    MessageBox.Show("App removed Successfully!");
                    updateCount();
                    fillsearchGrid();
                    fillCBs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
        private void ViewThenUpdateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateAppCB.Text = GridSearchResults.SelectedRows[0].Cells[1].Value.ToString();
                GridSearchResults.DataSource = null;
                DeveloperTabs.SelectTab(ManageAppTab);
                ManageAppSubTabs.SelectTab(UpdateAppTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateBTN_Click(object sender, EventArgs e)
        {
            if (CheckEmpty(groupBox2) || UpdateAppCB.Text == "")
            {
                MessageBox.Show("Fields cannot be left blank");
            }

            else if (!correctUnit(NewSizeUnitCB.Text))
            {
                MessageBox.Show("Size Unit not correct!");
            }

            else if (!correctUnit(NewRAMUnitCB.Text))
            {
                MessageBox.Show("RAM unit not correct!");

            }
            else
            {
                decimal size = toKBs(NewSizeTB.Text);
                decimal ram = toKBs(NewRAMTB.Text);

                ADB = new AppDBLayer();
                ADB.developer.app.setName(UpdateAppCB.Text);
                ADB.developer.app.dev.setCapacity(size);
                ADB.developer.app.dev.setRam(ram);
                ADB.developer.app.setDescription(NewDescriptionTB.Text);
                ADB.developer.app.setVersion(UpdatedVersionTB.Text);
                ADB.developer.app.dev.setOS(UpdateOSCB.Text);

                if (ADB.UpdateApp())
                {
                    MessageBox.Show("App Updated Successfully!");
                    IntializeBoxes(groupBox2);
                    UpdateAppCB.Text = "";
                }
                else
                {
                    MessageBox.Show("App update Failed!");
                }
            }
        }
        private void AppSizeTB_TextChanged(object sender, EventArgs e)
        {

        }
        private void UpdateAppCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                string query = "select capacity,RAM,OS from Device where id = (select deviceID from Application where name = '" + UpdateAppCB.Text + "')";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NewRAMTB.Text = reader["RAM"].ToString();
                    NewSizeTB.Text = reader["capacity"].ToString();
                    UpdateOSCB.Text = reader["OS"].ToString();
                }

                query = "select description,version1 from Application where name = '" + UpdateAppCB.Text + "'";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NewDescriptionTB.Text = reader["description"].ToString();
                    UpdatedVersionTB.Text = reader["version1"].ToString();
                }
                NewSizeUnitCB.Text = "KB";
                NewRAMUnitCB.Text = "KB";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateAppTab_Paint(object sender, PaintEventArgs e)
        {
            //fillCBs();
        }
        private void RemoveTab_Paint(object sender, PaintEventArgs e)
        {
            //fillCBs();
        }
        

        private void VersionTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateOSCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                ADB = new AppDBLayer();
                string name = GridSearchResults.SelectedRows[0].Cells[1].Value.ToString();
                ADB.developer.app.setName(name);
                GridSearchResults.DataSource = null;
                GridSearchResults.DataSource = ADB.viewFeedback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AppSizeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private void RAMTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void NewSizeTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void NewSizeTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void NewRAMTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void DeveloperTabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = DeveloperTabs.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = DeveloperTabs.GetTabRect(e.Index);

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

        private void frmDeveloper_Load(object sender, EventArgs e)
        {

        }
        
        private void tabPage1_Enter(object sender, EventArgs e)
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

        private void frmDeveloper_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.L)
                {
                    tabPage1_Enter(sender, e); ;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void AppCostTB_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ManageAppSubTabs_Click(object sender, EventArgs e)
        {
            grpAppInfo.Visible = false;
            RemoveAppCB.Text = "App Name";
            UpdateAppCB.Text = "App Name";
        }

        private void DeveloperTabs_Click(object sender, EventArgs e)
        {
            grpAppInfo.Visible = false;
        }

        private void RemoveAppCB_Enter(object sender, EventArgs e)
        {
            RemoveAppCB.Text = "";
            
        }

        private void RemoveAppCB_Leave(object sender, EventArgs e)
        {
            if (RemoveAppCB.Text == "")
                RemoveAppCB.Text = "App Name";
        }

        private void UpdateAppTab_Click(object sender, EventArgs e)
        {
            RemoveAppCB.Text = "App Name";
        }

        private void UpdateAppCB_Enter(object sender, EventArgs e)
        {
            UpdateAppCB.Text = "";
        }

        private void UpdateAppCB_Leave(object sender, EventArgs e)
        {
            UpdateAppCB.Text = "App Name";
        }
    }
}
