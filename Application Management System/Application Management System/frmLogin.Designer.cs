namespace Application_Management_System
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtPasswordAcc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEmailAcc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPasswordAcc
            // 
            this.txtPasswordAcc.Font = new System.Drawing.Font("Times New Roman", 13.824F);
            this.txtPasswordAcc.Location = new System.Drawing.Point(1326, 361);
            this.txtPasswordAcc.Name = "txtPasswordAcc";
            this.txtPasswordAcc.PasswordChar = '*';
            this.txtPasswordAcc.Size = new System.Drawing.Size(357, 35);
            this.txtPasswordAcc.TabIndex = 13;
            this.txtPasswordAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAcc_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calisto MT", 13.824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(1074, 357);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 28);
            this.label12.TabIndex = 12;
            this.label12.Text = "Password";
            // 
            // txtEmailAcc
            // 
            this.txtEmailAcc.Font = new System.Drawing.Font("Times New Roman", 13.824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAcc.Location = new System.Drawing.Point(1326, 301);
            this.txtEmailAcc.Name = "txtEmailAcc";
            this.txtEmailAcc.Size = new System.Drawing.Size(357, 35);
            this.txtEmailAcc.TabIndex = 11;
            this.txtEmailAcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAcc_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calisto MT", 13.824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(1074, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(217, 28);
            this.label11.TabIndex = 10;
            this.label11.Text = "User Email Address";
            // 
            // cmbUserType
            // 
            this.cmbUserType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUserType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserType.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "Customer",
            "Developer",
            "Admin"});
            this.cmbUserType.Location = new System.Drawing.Point(1326, 419);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(357, 31);
            this.cmbUserType.TabIndex = 14;
            this.cmbUserType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAcc_KeyDown);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Calisto MT", 13.824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(1074, 416);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 28);
            this.label23.TabIndex = 15;
            this.label23.Text = "User Type";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCreate.Font = new System.Drawing.Font("Tahoma", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreate.Location = new System.Drawing.Point(1451, 485);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(232, 41);
            this.btnCreate.TabIndex = 36;
            this.btnCreate.Text = "&Login";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 10.944F);
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.linkLabel1.Location = new System.Drawing.Point(1104, 495);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(187, 24);
            this.linkLabel1.TabIndex = 37;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Create new account";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36.288F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(637, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(765, 78);
            this.label1.TabIndex = 10;
            this.label1.Text = "Application Management System";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1622, 1054);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtPasswordAcc);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEmailAcc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPasswordAcc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEmailAcc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
    }
}