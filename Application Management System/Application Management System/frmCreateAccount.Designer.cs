namespace Application_Management_System
{
    partial class frmCreateAccount
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
            this.label20 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.grpDevice = new System.Windows.Forms.GroupBox();
            this.cmbUnitRam = new System.Windows.Forms.ComboBox();
            this.cmbUnitStr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.txtOS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRAM = new System.Windows.Forms.TextBox();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmailCreate = new System.Windows.Forms.TextBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtPasswordCreate = new System.Windows.Forms.TextBox();
            this.txtConfirmCreate = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.grpDevice.SuspendLayout();
            this.grpUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(562, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(179, 29);
            this.label20.TabIndex = 2;
            this.label20.Text = "Create Account";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.grpDevice);
            this.panel1.Controls.Add(this.grpUserInfo);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1685, 900);
            this.panel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(254, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 23);
            this.label8.TabIndex = 36;
            this.label8.Text = "*All the fields are mandatory";
            // 
            // grpDevice
            // 
            this.grpDevice.Controls.Add(this.cmbUnitRam);
            this.grpDevice.Controls.Add(this.cmbUnitStr);
            this.grpDevice.Controls.Add(this.label2);
            this.grpDevice.Controls.Add(this.txtDevName);
            this.grpDevice.Controls.Add(this.txtOS);
            this.grpDevice.Controls.Add(this.label3);
            this.grpDevice.Controls.Add(this.label4);
            this.grpDevice.Controls.Add(this.txtRAM);
            this.grpDevice.Controls.Add(this.txtStorage);
            this.grpDevice.Controls.Add(this.label5);
            this.grpDevice.Font = new System.Drawing.Font("Calisto MT", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDevice.Location = new System.Drawing.Point(258, 277);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Size = new System.Drawing.Size(1003, 200);
            this.grpDevice.TabIndex = 29;
            this.grpDevice.TabStop = false;
            this.grpDevice.Text = "Device Information";
            this.grpDevice.Enter += new System.EventHandler(this.grpDevice_Enter);
            // 
            // cmbUnitRam
            // 
            this.cmbUnitRam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUnitRam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUnitRam.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnitRam.FormattingEnabled = true;
            this.cmbUnitRam.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB",
            "TB"});
            this.cmbUnitRam.Location = new System.Drawing.Point(755, 58);
            this.cmbUnitRam.Name = "cmbUnitRam";
            this.cmbUnitRam.Size = new System.Drawing.Size(69, 31);
            this.cmbUnitRam.TabIndex = 31;
            // 
            // cmbUnitStr
            // 
            this.cmbUnitStr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUnitStr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUnitStr.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnitStr.FormattingEnabled = true;
            this.cmbUnitStr.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB",
            "TB"});
            this.cmbUnitStr.Location = new System.Drawing.Point(755, 90);
            this.cmbUnitStr.Name = "cmbUnitStr";
            this.cmbUnitStr.Size = new System.Drawing.Size(69, 31);
            this.cmbUnitStr.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 27;
            this.label2.Text = "Name";
            // 
            // txtDevName
            // 
            this.txtDevName.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevName.Location = new System.Drawing.Point(311, 25);
            this.txtDevName.MaxLength = 29;
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.Size = new System.Drawing.Size(438, 30);
            this.txtDevName.TabIndex = 28;
            // 
            // txtOS
            // 
            this.txtOS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtOS.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOS.FormattingEnabled = true;
            this.txtOS.Items.AddRange(new object[] {
            "Android",
            "IOS"});
            this.txtOS.Location = new System.Drawing.Point(311, 127);
            this.txtOS.MaxLength = 10;
            this.txtOS.Name = "txtOS";
            this.txtOS.Size = new System.Drawing.Size(438, 31);
            this.txtOS.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 24);
            this.label3.TabIndex = 29;
            this.label3.Text = "RAM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Operating System";
            // 
            // txtRAM
            // 
            this.txtRAM.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRAM.Location = new System.Drawing.Point(311, 58);
            this.txtRAM.MaxLength = 7;
            this.txtRAM.Name = "txtRAM";
            this.txtRAM.Size = new System.Drawing.Size(438, 30);
            this.txtRAM.TabIndex = 30;
            this.txtRAM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRAM_KeyPress);
            // 
            // txtStorage
            // 
            this.txtStorage.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStorage.Location = new System.Drawing.Point(311, 91);
            this.txtStorage.MaxLength = 7;
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(438, 30);
            this.txtStorage.TabIndex = 32;
            this.txtStorage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRAM_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "Device Storage";
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.Controls.Add(this.label7);
            this.grpUserInfo.Controls.Add(this.txtName);
            this.grpUserInfo.Controls.Add(this.label1);
            this.grpUserInfo.Controls.Add(this.txtEmailCreate);
            this.grpUserInfo.Controls.Add(this.cmbGender);
            this.grpUserInfo.Controls.Add(this.cmbCountry);
            this.grpUserInfo.Controls.Add(this.label6);
            this.grpUserInfo.Controls.Add(this.label9);
            this.grpUserInfo.Controls.Add(this.label22);
            this.grpUserInfo.Controls.Add(this.label24);
            this.grpUserInfo.Controls.Add(this.txtPasswordCreate);
            this.grpUserInfo.Controls.Add(this.txtConfirmCreate);
            this.grpUserInfo.Controls.Add(this.label21);
            this.grpUserInfo.Font = new System.Drawing.Font("Calisto MT", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserInfo.Location = new System.Drawing.Point(258, 28);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Size = new System.Drawing.Size(1003, 251);
            this.grpUserInfo.TabIndex = 28;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "User Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 24);
            this.label7.TabIndex = 19;
            this.label7.Text = "Full Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(311, 28);
            this.txtName.MaxLength = 24;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(438, 30);
            this.txtName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Email Address";
            // 
            // txtEmailCreate
            // 
            this.txtEmailCreate.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailCreate.Location = new System.Drawing.Point(311, 64);
            this.txtEmailCreate.MaxLength = 25;
            this.txtEmailCreate.Name = "txtEmailCreate";
            this.txtEmailCreate.Size = new System.Drawing.Size(438, 30);
            this.txtEmailCreate.TabIndex = 20;
            // 
            // cmbGender
            // 
            this.cmbGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGender.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(311, 173);
            this.cmbGender.MaxLength = 10;
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(438, 31);
            this.cmbGender.TabIndex = 26;
            // 
            // cmbCountry
            // 
            this.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCountry.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Items.AddRange(new object[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua and Barbuda",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cabo Verde",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Central African Republic (CAR)",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo, Democratic Republic of the",
            "Congo, Republic of the",
            "Costa Rica",
            "Cote d\'Ivoire",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czechia",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Eswatini (formerly Swaziland)",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar (formerly Burma)",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "North Korea",
            "North Macedonia (formerly Macedonia)",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestine",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russia",
            "Rwanda",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Korea",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Timor-Leste",
            "Togo",
            "Tonga",
            "Trinidad and Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates (UAE)",
            "United Kingdom (UK)",
            "United States of America (USA)",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City (Holy See)",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia"});
            this.cmbCountry.Location = new System.Drawing.Point(311, 212);
            this.cmbCountry.MaxLength = 15;
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(438, 31);
            this.cmbCountry.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Gender";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.216F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(755, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "(at least 8 characters and 1 digit)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(26, 103);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 24);
            this.label22.TabIndex = 21;
            this.label22.Text = "Password";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(26, 220);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 24);
            this.label24.TabIndex = 25;
            this.label24.Text = "Country";
            // 
            // txtPasswordCreate
            // 
            this.txtPasswordCreate.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordCreate.Location = new System.Drawing.Point(311, 100);
            this.txtPasswordCreate.MaxLength = 14;
            this.txtPasswordCreate.Name = "txtPasswordCreate";
            this.txtPasswordCreate.PasswordChar = '*';
            this.txtPasswordCreate.Size = new System.Drawing.Size(438, 30);
            this.txtPasswordCreate.TabIndex = 22;
            // 
            // txtConfirmCreate
            // 
            this.txtConfirmCreate.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmCreate.Location = new System.Drawing.Point(311, 137);
            this.txtConfirmCreate.MaxLength = 14;
            this.txtConfirmCreate.Name = "txtConfirmCreate";
            this.txtConfirmCreate.PasswordChar = '*';
            this.txtConfirmCreate.Size = new System.Drawing.Size(438, 30);
            this.txtConfirmCreate.TabIndex = 24;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(26, 140);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(169, 24);
            this.label21.TabIndex = 23;
            this.label21.Text = "Confirm Password";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Green;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(1267, 299);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 36);
            this.btnBack.TabIndex = 36;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Green;
            this.btnCreate.Font = new System.Drawing.Font("Tahoma", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreate.Location = new System.Drawing.Point(1267, 248);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(92, 36);
            this.btnCreate.TabIndex = 35;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(367, 89);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 24);
            this.label23.TabIndex = 11;
            this.label23.Text = "User Type";
            // 
            // cmbUserType
            // 
            this.cmbUserType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUserType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserType.Font = new System.Drawing.Font("Tahoma", 10.944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "Customer",
            "Developer"});
            this.cmbUserType.Location = new System.Drawing.Point(495, 86);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(438, 31);
            this.cmbUserType.TabIndex = 0;
            this.cmbUserType.SelectedIndexChanged += new System.EventHandler(this.cmbUserType_SelectedIndexChanged);
            // 
            // frmCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1685, 1031);
            this.Controls.Add(this.cmbUserType);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label20);
            this.Font = new System.Drawing.Font("Calisto MT", 13.824F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmCreateAccount";
            this.Text = "Create Account(Ctrl + E to Exit)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCreateAccount_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpDevice.ResumeLayout(false);
            this.grpDevice.PerformLayout();
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtConfirmCreate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPasswordCreate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtEmailCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.ComboBox txtOS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRAM;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbUnitRam;
        private System.Windows.Forms.ComboBox cmbUnitStr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label9;
    }
}