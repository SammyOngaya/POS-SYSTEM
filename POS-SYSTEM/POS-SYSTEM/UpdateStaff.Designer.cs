﻿namespace POS_SYSTEM
{
    partial class UpdateStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateStaff));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.searchStaffUpdate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.staffStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.default_pfno = new System.Windows.Forms.Label();
            this.updateStaffpfno = new System.Windows.Forms.TextBox();
            this.updateStaffPassword = new System.Windows.Forms.TextBox();
            this.addstaffDob = new System.Windows.Forms.DateTimePicker();
            this.updateStafflastname = new System.Windows.Forms.TextBox();
            this.updateStafffirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteStaffbButton = new System.Windows.Forms.Button();
            this.rowCountLabel = new System.Windows.Forms.Label();
            this.imagePathTextBox = new System.Windows.Forms.TextBox();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updateStaffCategory = new System.Windows.Forms.ComboBox();
            this.updateStaffLocation = new System.Windows.Forms.TextBox();
            this.updateStaffCounty = new System.Windows.Forms.TextBox();
            this.updateStaffEmail = new System.Windows.Forms.TextBox();
            this.updateStaffPhone = new System.Windows.Forms.TextBox();
            this.updateStaffNationalid = new System.Windows.Forms.TextBox();
            this.addstaffDoe = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.updateStaffdataGridView = new System.Windows.Forms.DataGridView();
            this.loadImagePictureBox = new System.Windows.Forms.PictureBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStaffdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.searchStaffUpdate);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(81, 316);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 49);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "search by staff pfno";
            // 
            // searchStaffUpdate
            // 
            this.searchStaffUpdate.Location = new System.Drawing.Point(198, 20);
            this.searchStaffUpdate.Name = "searchStaffUpdate";
            this.searchStaffUpdate.Size = new System.Drawing.Size(217, 20);
            this.searchStaffUpdate.TabIndex = 21;
            this.searchStaffUpdate.TextChanged += new System.EventHandler(this.searchStaffUpdate_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(44, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 24);
            this.label14.TabIndex = 20;
            this.label14.Text = "search by pfno";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(631, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.staffStatusComboBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.genderComboBox);
            this.groupBox1.Controls.Add(this.default_pfno);
            this.groupBox1.Controls.Add(this.updateStaffpfno);
            this.groupBox1.Controls.Add(this.updateStaffPassword);
            this.groupBox1.Controls.Add(this.addstaffDob);
            this.groupBox1.Controls.Add(this.updateStafflastname);
            this.groupBox1.Controls.Add(this.updateStafffirstname);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(81, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 285);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Data";
            // 
            // staffStatusComboBox
            // 
            this.staffStatusComboBox.FormattingEnabled = true;
            this.staffStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "Disabled"});
            this.staffStatusComboBox.Location = new System.Drawing.Point(129, 246);
            this.staffStatusComboBox.Name = "staffStatusComboBox";
            this.staffStatusComboBox.Size = new System.Drawing.Size(234, 28);
            this.staffStatusComboBox.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(10, 249);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 20);
            this.label15.TabIndex = 19;
            this.label15.Text = "Status";
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderComboBox.Location = new System.Drawing.Point(129, 174);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(231, 28);
            this.genderComboBox.TabIndex = 15;
            // 
            // default_pfno
            // 
            this.default_pfno.AutoSize = true;
            this.default_pfno.Location = new System.Drawing.Point(231, 4);
            this.default_pfno.Name = "default_pfno";
            this.default_pfno.Size = new System.Drawing.Size(111, 20);
            this.default_pfno.TabIndex = 14;
            this.default_pfno.Text = "default_pfno";
            this.default_pfno.Visible = false;
            // 
            // updateStaffpfno
            // 
            this.updateStaffpfno.Enabled = false;
            this.updateStaffpfno.Location = new System.Drawing.Point(129, 25);
            this.updateStaffpfno.MaxLength = 50;
            this.updateStaffpfno.Name = "updateStaffpfno";
            this.updateStaffpfno.Size = new System.Drawing.Size(236, 26);
            this.updateStaffpfno.TabIndex = 13;
            this.updateStaffpfno.TextChanged += new System.EventHandler(this.updateStaffpfno_TextChanged_1);
            // 
            // updateStaffPassword
            // 
            this.updateStaffPassword.Location = new System.Drawing.Point(129, 214);
            this.updateStaffPassword.MaxLength = 100;
            this.updateStaffPassword.Name = "updateStaffPassword";
            this.updateStaffPassword.Size = new System.Drawing.Size(236, 26);
            this.updateStaffPassword.TabIndex = 10;
            // 
            // addstaffDob
            // 
            this.addstaffDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.addstaffDob.Location = new System.Drawing.Point(129, 141);
            this.addstaffDob.Name = "addstaffDob";
            this.addstaffDob.Size = new System.Drawing.Size(234, 26);
            this.addstaffDob.TabIndex = 9;
            // 
            // updateStafflastname
            // 
            this.updateStafflastname.Location = new System.Drawing.Point(129, 100);
            this.updateStafflastname.MaxLength = 50;
            this.updateStafflastname.Name = "updateStafflastname";
            this.updateStafflastname.Size = new System.Drawing.Size(236, 26);
            this.updateStafflastname.TabIndex = 7;
            // 
            // updateStafffirstname
            // 
            this.updateStafffirstname.Location = new System.Drawing.Point(129, 65);
            this.updateStafffirstname.MaxLength = 150;
            this.updateStafffirstname.Name = "updateStafffirstname";
            this.updateStafffirstname.Size = new System.Drawing.Size(235, 26);
            this.updateStafffirstname.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(13, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(15, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(16, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "DoB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PFNO";
            // 
            // deleteStaffbButton
            // 
            this.deleteStaffbButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.deleteStaffbButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteStaffbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStaffbButton.ForeColor = System.Drawing.Color.White;
            this.deleteStaffbButton.Location = new System.Drawing.Point(831, 332);
            this.deleteStaffbButton.Name = "deleteStaffbButton";
            this.deleteStaffbButton.Size = new System.Drawing.Size(176, 35);
            this.deleteStaffbButton.TabIndex = 30;
            this.deleteStaffbButton.Text = "delete";
            this.deleteStaffbButton.UseVisualStyleBackColor = false;
            this.deleteStaffbButton.Visible = false;
            this.deleteStaffbButton.Click += new System.EventHandler(this.deleteStaffbButton_Click);
            // 
            // rowCountLabel
            // 
            this.rowCountLabel.AutoSize = true;
            this.rowCountLabel.Location = new System.Drawing.Point(1042, 343);
            this.rowCountLabel.Name = "rowCountLabel";
            this.rowCountLabel.Size = new System.Drawing.Size(0, 13);
            this.rowCountLabel.TabIndex = 33;
            // 
            // imagePathTextBox
            // 
            this.imagePathTextBox.Location = new System.Drawing.Point(939, 249);
            this.imagePathTextBox.Name = "imagePathTextBox";
            this.imagePathTextBox.Size = new System.Drawing.Size(220, 20);
            this.imagePathTextBox.TabIndex = 35;
            this.imagePathTextBox.Visible = false;
            this.imagePathTextBox.TextChanged += new System.EventHandler(this.imagePathTextBox_TextChanged);
            // 
            // loadImageButton
            // 
            this.loadImageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadImageButton.ForeColor = System.Drawing.Color.LimeGreen;
            this.loadImageButton.Location = new System.Drawing.Point(983, 275);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(127, 32);
            this.loadImageButton.TabIndex = 34;
            this.loadImageButton.Text = "Load Image";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Visible = false;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updateStaffCategory);
            this.groupBox2.Controls.Add(this.updateStaffLocation);
            this.groupBox2.Controls.Add(this.updateStaffCounty);
            this.groupBox2.Controls.Add(this.updateStaffEmail);
            this.groupBox2.Controls.Add(this.updateStaffPhone);
            this.groupBox2.Controls.Add(this.updateStaffNationalid);
            this.groupBox2.Controls.Add(this.addstaffDoe);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Location = new System.Drawing.Point(507, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 277);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Physical Details";
            // 
            // updateStaffCategory
            // 
            this.updateStaffCategory.FormattingEnabled = true;
            this.updateStaffCategory.Items.AddRange(new object[] {
            "Manager",
            "Supervisor",
            "Cashier"});
            this.updateStaffCategory.Location = new System.Drawing.Point(138, 235);
            this.updateStaffCategory.Name = "updateStaffCategory";
            this.updateStaffCategory.Size = new System.Drawing.Size(200, 28);
            this.updateStaffCategory.TabIndex = 15;
            // 
            // updateStaffLocation
            // 
            this.updateStaffLocation.Location = new System.Drawing.Point(138, 157);
            this.updateStaffLocation.MaxLength = 150;
            this.updateStaffLocation.Name = "updateStaffLocation";
            this.updateStaffLocation.Size = new System.Drawing.Size(200, 26);
            this.updateStaffLocation.TabIndex = 13;
            // 
            // updateStaffCounty
            // 
            this.updateStaffCounty.Location = new System.Drawing.Point(138, 122);
            this.updateStaffCounty.MaxLength = 150;
            this.updateStaffCounty.Name = "updateStaffCounty";
            this.updateStaffCounty.Size = new System.Drawing.Size(200, 26);
            this.updateStaffCounty.TabIndex = 12;
            // 
            // updateStaffEmail
            // 
            this.updateStaffEmail.Location = new System.Drawing.Point(138, 92);
            this.updateStaffEmail.MaxLength = 150;
            this.updateStaffEmail.Name = "updateStaffEmail";
            this.updateStaffEmail.Size = new System.Drawing.Size(200, 26);
            this.updateStaffEmail.TabIndex = 11;
            // 
            // updateStaffPhone
            // 
            this.updateStaffPhone.Location = new System.Drawing.Point(138, 62);
            this.updateStaffPhone.MaxLength = 30;
            this.updateStaffPhone.Name = "updateStaffPhone";
            this.updateStaffPhone.Size = new System.Drawing.Size(200, 26);
            this.updateStaffPhone.TabIndex = 10;
            // 
            // updateStaffNationalid
            // 
            this.updateStaffNationalid.Location = new System.Drawing.Point(138, 29);
            this.updateStaffNationalid.MaxLength = 10;
            this.updateStaffNationalid.Name = "updateStaffNationalid";
            this.updateStaffNationalid.Size = new System.Drawing.Size(200, 26);
            this.updateStaffNationalid.TabIndex = 9;
            this.updateStaffNationalid.TextChanged += new System.EventHandler(this.updateStaffNationalid_TextChanged);
            // 
            // addstaffDoe
            // 
            this.addstaffDoe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.addstaffDoe.Location = new System.Drawing.Point(138, 193);
            this.addstaffDoe.Name = "addstaffDoe";
            this.addstaffDoe.Size = new System.Drawing.Size(200, 26);
            this.addstaffDoe.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(7, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Category";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(7, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "DoE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(7, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Location";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(7, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "County";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(7, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(7, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(7, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "National ID";
            // 
            // updateStaffdataGridView
            // 
            this.updateStaffdataGridView.AllowUserToOrderColumns = true;
            this.updateStaffdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.updateStaffdataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.updateStaffdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updateStaffdataGridView.Location = new System.Drawing.Point(50, 386);
            this.updateStaffdataGridView.Name = "updateStaffdataGridView";
            this.updateStaffdataGridView.Size = new System.Drawing.Size(1204, 252);
            this.updateStaffdataGridView.TabIndex = 31;
            // 
            // loadImagePictureBox
            // 
            this.loadImagePictureBox.Location = new System.Drawing.Point(935, 36);
            this.loadImagePictureBox.Name = "loadImagePictureBox";
            this.loadImagePictureBox.Size = new System.Drawing.Size(224, 207);
            this.loadImagePictureBox.TabIndex = 32;
            this.loadImagePictureBox.TabStop = false;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(935, -1);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 97;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // UpdateStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 650);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.deleteStaffbButton);
            this.Controls.Add(this.rowCountLabel);
            this.Controls.Add(this.imagePathTextBox);
            this.Controls.Add(this.loadImageButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.updateStaffdataGridView);
            this.Controls.Add(this.loadImagePictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODIFY STAFF DETAILS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UpdateStaff_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateStaffdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox searchStaffUpdate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox staffStatusComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Label default_pfno;
        private System.Windows.Forms.TextBox updateStaffpfno;
        private System.Windows.Forms.TextBox updateStaffPassword;
        private System.Windows.Forms.DateTimePicker addstaffDob;
        private System.Windows.Forms.TextBox updateStafflastname;
        private System.Windows.Forms.TextBox updateStafffirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteStaffbButton;
        private System.Windows.Forms.Label rowCountLabel;
        private System.Windows.Forms.TextBox imagePathTextBox;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox updateStaffCategory;
        private System.Windows.Forms.TextBox updateStaffLocation;
        private System.Windows.Forms.TextBox updateStaffCounty;
        private System.Windows.Forms.TextBox updateStaffEmail;
        private System.Windows.Forms.TextBox updateStaffPhone;
        private System.Windows.Forms.TextBox updateStaffNationalid;
        private System.Windows.Forms.DateTimePicker addstaffDoe;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView updateStaffdataGridView;
        private System.Windows.Forms.PictureBox loadImagePictureBox;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
    }
}