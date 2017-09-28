namespace POS_SYSTEM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.login = new System.Windows.Forms.Button();
            this.loginpassword = new System.Windows.Forms.TextBox();
            this.loginusername = new System.Windows.Forms.TextBox();
            this.loginp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.userCategory = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverConnectionTextBox = new System.Windows.Forms.TextBox();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.copyrightDetailsTextBox = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.loginpassword);
            this.groupBox1.Controls.Add(this.loginusername);
            this.groupBox1.Controls.Add(this.loginp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(344, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.Color.White;
            this.login.Location = new System.Drawing.Point(172, 137);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(165, 41);
            this.login.TabIndex = 4;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // loginpassword
            // 
            this.loginpassword.Location = new System.Drawing.Point(157, 94);
            this.loginpassword.Name = "loginpassword";
            this.loginpassword.PasswordChar = '*';
            this.loginpassword.Size = new System.Drawing.Size(226, 29);
            this.loginpassword.TabIndex = 3;
            // 
            // loginusername
            // 
            this.loginusername.Location = new System.Drawing.Point(157, 39);
            this.loginusername.MaxLength = 50;
            this.loginusername.Name = "loginusername";
            this.loginusername.Size = new System.Drawing.Size(226, 29);
            this.loginusername.TabIndex = 2;
            // 
            // loginp
            // 
            this.loginp.AutoSize = true;
            this.loginp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.loginp.Location = new System.Drawing.Point(21, 97);
            this.loginp.Name = "loginp";
            this.loginp.Size = new System.Drawing.Size(100, 24);
            this.loginp.TabIndex = 1;
            this.loginp.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(444, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "POS SYSTEM";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Location = new System.Drawing.Point(532, 104);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.lastNameTextBox.TabIndex = 11;
            this.lastNameTextBox.Visible = false;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Enabled = false;
            this.firstNameTextBox.Location = new System.Drawing.Point(276, 104);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(214, 20);
            this.firstNameTextBox.TabIndex = 10;
            this.firstNameTextBox.Visible = false;
            // 
            // userCategory
            // 
            this.userCategory.Enabled = false;
            this.userCategory.Location = new System.Drawing.Point(786, 104);
            this.userCategory.Name = "userCategory";
            this.userCategory.Size = new System.Drawing.Size(214, 20);
            this.userCategory.TabIndex = 9;
            this.userCategory.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::POS_SYSTEM.Properties.Resources.faith2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::POS_SYSTEM.Properties.Resources.faith21;
            this.pictureBox1.Location = new System.Drawing.Point(153, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(901, 154);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(481, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 37);
            this.label4.TabIndex = 80;
            this.label4.Text = "TRIAL COPY";
            this.label4.Visible = false;
            // 
            // serverConnectionTextBox
            // 
            this.serverConnectionTextBox.Enabled = false;
            this.serverConnectionTextBox.Location = new System.Drawing.Point(609, 295);
            this.serverConnectionTextBox.Name = "serverConnectionTextBox";
            this.serverConnectionTextBox.Size = new System.Drawing.Size(265, 20);
            this.serverConnectionTextBox.TabIndex = 84;
            this.serverConnectionTextBox.Visible = false;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Enabled = false;
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(332, 291);
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(214, 20);
            this.databaseConnectionStringTextBox.TabIndex = 83;
            this.databaseConnectionStringTextBox.Visible = false;
            // 
            // copyrightDetailsTextBox
            // 
            this.copyrightDetailsTextBox.AutoSize = true;
            this.copyrightDetailsTextBox.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightDetailsTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.copyrightDetailsTextBox.Location = new System.Drawing.Point(435, 561);
            this.copyrightDetailsTextBox.Name = "copyrightDetailsTextBox";
            this.copyrightDetailsTextBox.Size = new System.Drawing.Size(292, 18);
            this.copyrightDetailsTextBox.TabIndex = 98;
            this.copyrightDetailsTextBox.Text = "@POS. All rights resrved . Support 0725 470 477";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 607);
            this.Controls.Add(this.copyrightDetailsTextBox);
            this.Controls.Add(this.serverConnectionTextBox);
            this.Controls.Add(this.databaseConnectionStringTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.userCategory);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox loginpassword;
        private System.Windows.Forms.TextBox loginusername;
        private System.Windows.Forms.Label loginp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox userCategory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverConnectionTextBox;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
        private System.Windows.Forms.Label copyrightDetailsTextBox;
    }
}

