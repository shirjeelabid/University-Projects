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
    public partial class frmCreateAccount : Form
    {
        SqlConnection con = new SqlConnection();
        SQLConn obj = SQLConn.getInstance();
        CustomerDBLayer customerObj;
        AppDBLayer developerObj;

        bool CheckEmpty()
        {
            foreach (Control c in grpUserInfo.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                    if (c.Text == "")
                        return true;
            }
            if (cmbUserType.Text == "Customer")
            {
                foreach (Control c in grpDevice.Controls)
                {
                    if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                        if (c.Text == "")
                            return true;
                }
            }
            return false;
        }
        //iss ko yaad se daal dena
        bool correctUnit(string n)
        {

            if (n == "KB" || n == "MB" || n == "GB" || n == "TB")
                return true;

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

        public frmCreateAccount()
        {
            InitializeComponent();
            grpDevice.Visible = false;
            cmbUserType.Focus();
            obj.assign();
            con = obj.con;
            grpUserInfo.Visible = grpDevice.Visible = label8.Visible = false;
        }
        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpUserInfo.Visible = grpDevice.Visible = label8.Visible = false;

            if (cmbUserType.Text == "Customer")
            {
                grpUserInfo.Visible = label8.Visible = true;
                grpDevice.Visible = true;
            }
            else if (cmbUserType.Text == "Developer")
            {
                grpUserInfo.Visible = label8.Visible = true;
                grpDevice.Visible = false;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (txtPasswordCreate.Text == txtConfirmCreate.Text)
                {
                    if (!CheckEmpty())
                    {
                        if (txtPasswordCreate.TextLength < 8)
                        {
                            MessageBox.Show("Password must be of atLeast 8 Characters");
                            return;
                        }
                        string input = txtPasswordCreate.Text;
                        bool isDigitPresent = input.Any(a => char.IsDigit(a));
                        if (!isDigitPresent)
                        {
                            MessageBox.Show("Password must contain atLeast 1 digit");
                            return;
                        }
                        if (cmbUserType.Text == "Customer")
                        {
                            if(!correctUnit(cmbUnitRam.Text))
                            {
                                MessageBox.Show("Invlalid Ram Unit");
                                return;
                            }
                            if (!correctUnit(cmbUnitStr.Text))
                            {
                                MessageBox.Show("Invlalid Capacity Unit");
                                return;
                            }
                            customerObj = new CustomerDBLayer();
                            customerObj.cusObj.setEmail(txtEmailCreate.Text);
                            customerObj.cusObj.setName(txtName.Text);
                            customerObj.cusObj.setGender(cmbGender.Text);
                            customerObj.cusObj.setPswd(txtPasswordCreate.Text);
                            customerObj.cusObj.setCountry(cmbCountry.Text);

                            customerObj.cusObj.device.setName(txtDevName.Text);
                            customerObj.cusObj.device.setOS(txtOS.Text);
                            customerObj.cusObj.device.setRam(Convert.ToDecimal(txtRAM.Text));
                            customerObj.cusObj.device.setCapacity(Convert.ToDecimal(txtStorage.Text));

                            result = customerObj.CreateCustomer(cmbUnitRam.Text, cmbUnitStr.Text);

                        }

                        else if (cmbUserType.Text == "Developer")
                        {
                            developerObj = new AppDBLayer();
                            developerObj.developer.setEmail(txtEmailCreate.Text);
                            developerObj.developer.setName(txtName.Text);
                            developerObj.developer.setGender(cmbGender.Text);
                            developerObj.developer.setPswd(txtPasswordCreate.Text);
                            developerObj.developer.setCountry(cmbCountry.Text);


                            result = developerObj.CreateDeveloper();

                        }
                        if (result)
                        {
                            MessageBox.Show("Account created successfully");
                            IntializeBoxes();
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

        private void grpDevice_Enter(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo);
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

        private void txtRAM_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmCreateAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.E)
                {
                    btnBack_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
