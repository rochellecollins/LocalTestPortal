
namespace LocalTestPortal
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTestGridInfo = new System.Windows.Forms.Label();
            this.gridTests = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTestDllFileNames = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPlaySound = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTestProjectPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSQLServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAcuPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAcuUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.chkHeadless = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrowserPath = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.chkDeleteLogs = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtScreenshotPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.cSettings = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.loadSettingsButton = new System.Windows.Forms.Button();
            this.unselectAllButton = new System.Windows.Forms.Button();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TestName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogFile = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Pics = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TestDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTests)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1380, 609);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblTestGridInfo);
            this.tabPage1.Controls.Add(this.gridTests);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1372, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tests";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTestGridInfo
            // 
            this.lblTestGridInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestGridInfo.AutoSize = true;
            this.lblTestGridInfo.Location = new System.Drawing.Point(3, 567);
            this.lblTestGridInfo.Name = "lblTestGridInfo";
            this.lblTestGridInfo.Size = new System.Drawing.Size(109, 13);
            this.lblTestGridInfo.TabIndex = 1;
            this.lblTestGridInfo.Text = "Grid Results: Pending";
            // 
            // gridTests
            // 
            this.gridTests.AllowUserToAddRows = false;
            this.gridTests.AllowUserToDeleteRows = false;
            this.gridTests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.TestName,
            this.TestModule,
            this.Result,
            this.LogFile,
            this.Pics,
            this.TestDescription});
            this.gridTests.Location = new System.Drawing.Point(6, 6);
            this.gridTests.Name = "gridTests";
            this.gridTests.Size = new System.Drawing.Size(1360, 558);
            this.gridTests.TabIndex = 0;
            this.gridTests.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTests_CellContentClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.txtTestDllFileNames);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.txtPlaySound);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.txtTestProjectPath);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1133, 583);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "General";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(157, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(276, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Default example sound: C:\\Windows\\Media\\Ring01.wav";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(157, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(489, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "List of all test dll file names. Not required to inlclude .dll and can include mu" +
    "ltiple seperated by a comma";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(157, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(247, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Location of TestProject.exe and related test dll files";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Test dll File Names:";
            // 
            // txtTestDllFileNames
            // 
            this.txtTestDllFileNames.Location = new System.Drawing.Point(160, 76);
            this.txtTestDllFileNames.Name = "txtTestDllFileNames";
            this.txtTestDllFileNames.Size = new System.Drawing.Size(593, 20);
            this.txtTestDllFileNames.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Play Sound on Completion:";
            // 
            // txtPlaySound
            // 
            this.txtPlaySound.Location = new System.Drawing.Point(160, 131);
            this.txtPlaySound.Name = "txtPlaySound";
            this.txtPlaySound.Size = new System.Drawing.Size(593, 20);
            this.txtPlaySound.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "TestProject Path:";
            // 
            // txtTestProjectPath
            // 
            this.txtTestProjectPath.Location = new System.Drawing.Point(160, 25);
            this.txtTestProjectPath.Name = "txtTestProjectPath";
            this.txtTestProjectPath.Size = new System.Drawing.Size(593, 20);
            this.txtTestProjectPath.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtSQLServer);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtBackupFile);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtDBName);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1133, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SQL Server:";
            // 
            // txtSQLServer
            // 
            this.txtSQLServer.Location = new System.Drawing.Point(123, 19);
            this.txtSQLServer.Name = "txtSQLServer";
            this.txtSQLServer.Size = new System.Drawing.Size(235, 20);
            this.txtSQLServer.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Backup File:";
            // 
            // txtBackupFile
            // 
            this.txtBackupFile.Location = new System.Drawing.Point(123, 94);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.Size = new System.Drawing.Size(612, 20);
            this.txtBackupFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DB Name:";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(123, 58);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(235, 20);
            this.txtDBName.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtAcuPassword);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtAcuUser);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtURL);
            this.tabPage3.Controls.Add(this.chkHeadless);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txtBrowserPath);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1133, 583);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Browser";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Acumatica Password:";
            // 
            // txtAcuPassword
            // 
            this.txtAcuPassword.Location = new System.Drawing.Point(142, 181);
            this.txtAcuPassword.Name = "txtAcuPassword";
            this.txtAcuPassword.Size = new System.Drawing.Size(235, 20);
            this.txtAcuPassword.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Acumatica Username:";
            // 
            // txtAcuUser
            // 
            this.txtAcuUser.Location = new System.Drawing.Point(142, 141);
            this.txtAcuUser.Name = "txtAcuUser";
            this.txtAcuUser.Size = new System.Drawing.Size(235, 20);
            this.txtAcuUser.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(142, 94);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(600, 20);
            this.txtURL.TabIndex = 5;
            // 
            // chkHeadless
            // 
            this.chkHeadless.AutoSize = true;
            this.chkHeadless.Location = new System.Drawing.Point(28, 60);
            this.chkHeadless.Name = "chkHeadless";
            this.chkHeadless.Size = new System.Drawing.Size(93, 17);
            this.chkHeadless.TabIndex = 4;
            this.chkHeadless.Text = "Run Headless";
            this.chkHeadless.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Browser Path:";
            // 
            // txtBrowserPath
            // 
            this.txtBrowserPath.Location = new System.Drawing.Point(142, 24);
            this.txtBrowserPath.Name = "txtBrowserPath";
            this.txtBrowserPath.Size = new System.Drawing.Size(600, 20);
            this.txtBrowserPath.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.chkDeleteLogs);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.txtScreenshotPath);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.txtOutputPath);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1133, 583);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Logging";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // chkDeleteLogs
            // 
            this.chkDeleteLogs.AutoSize = true;
            this.chkDeleteLogs.Location = new System.Drawing.Point(33, 103);
            this.chkDeleteLogs.Name = "chkDeleteLogs";
            this.chkDeleteLogs.Size = new System.Drawing.Size(139, 17);
            this.chkDeleteLogs.TabIndex = 6;
            this.chkDeleteLogs.Text = "Delete Old Logs at Start";
            this.chkDeleteLogs.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Screenshot Folder:";
            // 
            // txtScreenshotPath
            // 
            this.txtScreenshotPath.Location = new System.Drawing.Point(132, 62);
            this.txtScreenshotPath.Name = "txtScreenshotPath";
            this.txtScreenshotPath.Size = new System.Drawing.Size(235, 20);
            this.txtScreenshotPath.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Output Folder:";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(132, 26);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(235, 20);
            this.txtOutputPath.TabIndex = 2;
            // 
            // cSettings
            // 
            this.cSettings.FormattingEnabled = true;
            this.cSettings.Location = new System.Drawing.Point(16, 12);
            this.cSettings.Name = "cSettings";
            this.cSettings.Size = new System.Drawing.Size(221, 21);
            this.cSettings.TabIndex = 1;
            this.cSettings.SelectedIndexChanged += new System.EventHandler(this.cSettings_SelectedIndexChanged);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(254, 12);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(87, 23);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnRunTests
            // 
            this.btnRunTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTests.Location = new System.Drawing.Point(1263, 12);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(119, 33);
            this.btnRunTests.TabIndex = 3;
            this.btnRunTests.Text = "Run Tests";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // loadSettingsButton
            // 
            this.loadSettingsButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.loadSettingsButton.Location = new System.Drawing.Point(358, 12);
            this.loadSettingsButton.Name = "loadSettingsButton";
            this.loadSettingsButton.Size = new System.Drawing.Size(87, 23);
            this.loadSettingsButton.TabIndex = 4;
            this.loadSettingsButton.Text = "Load Settings";
            this.loadSettingsButton.UseVisualStyleBackColor = true;
            this.loadSettingsButton.Click += new System.EventHandler(this.loadSettingsButton_Click);
            // 
            // unselectAllButton
            // 
            this.unselectAllButton.Location = new System.Drawing.Point(464, 12);
            this.unselectAllButton.Name = "unselectAllButton";
            this.unselectAllButton.Size = new System.Drawing.Size(112, 23);
            this.unselectAllButton.TabIndex = 5;
            this.unselectAllButton.Text = "Unselect All Tests";
            this.unselectAllButton.UseVisualStyleBackColor = true;
            this.unselectAllButton.Click += new System.EventHandler(this.unselectAllButton_Click);
            // 
            // Selected
            // 
            this.Selected.HeaderText = "Selected";
            this.Selected.Name = "Selected";
            // 
            // TestName
            // 
            this.TestName.HeaderText = "Test Name";
            this.TestName.Name = "TestName";
            this.TestName.ReadOnly = true;
            this.TestName.Width = 200;
            // 
            // TestModule
            // 
            this.TestModule.HeaderText = "Module";
            this.TestModule.Name = "TestModule";
            this.TestModule.Width = 125;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // LogFile
            // 
            this.LogFile.HeaderText = "Log File";
            this.LogFile.Name = "LogFile";
            this.LogFile.ReadOnly = true;
            this.LogFile.Width = 310;
            // 
            // Pics
            // 
            this.Pics.HeaderText = "Pics Folder";
            this.Pics.Name = "Pics";
            this.Pics.ReadOnly = true;
            this.Pics.Width = 310;
            // 
            // TestDescription
            // 
            this.TestDescription.HeaderText = "Description";
            this.TestDescription.Name = "TestDescription";
            this.TestDescription.Width = 400;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 672);
            this.Controls.Add(this.unselectAllButton);
            this.Controls.Add(this.loadSettingsButton);
            this.Controls.Add(this.btnRunTests);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.cSettings);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Local Test Portal";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTests)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.DataGridView gridTests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackupFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSQLServer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrowserPath;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPlaySound;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTestProjectPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAcuPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAcuUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkHeadless;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox chkDeleteLogs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtScreenshotPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button loadSettingsButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTestDllFileNames;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTestGridInfo;
        private System.Windows.Forms.Button unselectAllButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewLinkColumn LogFile;
        private System.Windows.Forms.DataGridViewLinkColumn Pics;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestDescription;
    }
}

