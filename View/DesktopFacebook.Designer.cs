namespace View
{
    partial class DesktopFacebook
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
            this.m_TabPageMyAlbums = new System.Windows.Forms.TabPage();
            this.m_ComboBoxAlbums = new System.Windows.Forms.ComboBox();
            this.m_TabsControl = new System.Windows.Forms.TabControl();
            this.m_MainWindowTab = new System.Windows.Forms.TabPage();
            this.m_PostTextBox = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.m_ButtonPostStatus = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.m_Button_MyAlbums = new System.Windows.Forms.Button();
            this.m_Button_LogOut = new System.Windows.Forms.Button();
            this.m_PictureBox_ProfilePicture = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.m_ButtonNextPage = new System.Windows.Forms.Button();
            this.m_ButtonPreviousPage = new System.Windows.Forms.Button();
            this.m_TabPageMyAlbums.SuspendLayout();
            this.m_TabsControl.SuspendLayout();
            this.m_MainWindowTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox_ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // m_TabPageMyAlbums
            // 
            this.m_TabPageMyAlbums.CausesValidation = false;
            this.m_TabPageMyAlbums.Controls.Add(this.m_ButtonPreviousPage);
            this.m_TabPageMyAlbums.Controls.Add(this.m_ButtonNextPage);
            this.m_TabPageMyAlbums.Controls.Add(this.m_ComboBoxAlbums);
            this.m_TabPageMyAlbums.Location = new System.Drawing.Point(4, 29);
            this.m_TabPageMyAlbums.Name = "m_TabPageMyAlbums";
            this.m_TabPageMyAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.m_TabPageMyAlbums.Size = new System.Drawing.Size(945, 605);
            this.m_TabPageMyAlbums.TabIndex = 1;
            this.m_TabPageMyAlbums.Text = "tabPage2";
            this.m_TabPageMyAlbums.UseVisualStyleBackColor = true;
            // 
            // m_ComboBoxAlbums
            // 
            this.m_ComboBoxAlbums.FormattingEnabled = true;
            this.m_ComboBoxAlbums.Location = new System.Drawing.Point(35, 27);
            this.m_ComboBoxAlbums.Name = "m_ComboBoxAlbums";
            this.m_ComboBoxAlbums.Size = new System.Drawing.Size(316, 28);
            this.m_ComboBoxAlbums.TabIndex = 2;
            this.m_ComboBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.m_ComboBoxAlbums_SelectedIndexChanged);
            // 
            // m_TabsControl
            // 
            this.m_TabsControl.Controls.Add(this.m_MainWindowTab);
            this.m_TabsControl.Controls.Add(this.m_TabPageMyAlbums);
            this.m_TabsControl.Location = new System.Drawing.Point(3, 3);
            this.m_TabsControl.Name = "m_TabsControl";
            this.m_TabsControl.SelectedIndex = 0;
            this.m_TabsControl.Size = new System.Drawing.Size(953, 638);
            this.m_TabsControl.TabIndex = 2;
            // 
            // m_MainWindowTab
            // 
            this.m_MainWindowTab.Controls.Add(this.m_PostTextBox);
            this.m_MainWindowTab.Controls.Add(this.button4);
            this.m_MainWindowTab.Controls.Add(this.button3);
            this.m_MainWindowTab.Controls.Add(this.m_ButtonPostStatus);
            this.m_MainWindowTab.Controls.Add(this.button6);
            this.m_MainWindowTab.Controls.Add(this.button5);
            this.m_MainWindowTab.Controls.Add(this.m_Button_MyAlbums);
            this.m_MainWindowTab.Controls.Add(this.m_Button_LogOut);
            this.m_MainWindowTab.Controls.Add(this.m_PictureBox_ProfilePicture);
            this.m_MainWindowTab.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_MainWindowTab.Location = new System.Drawing.Point(4, 29);
            this.m_MainWindowTab.Name = "m_MainWindowTab";
            this.m_MainWindowTab.Padding = new System.Windows.Forms.Padding(3);
            this.m_MainWindowTab.Size = new System.Drawing.Size(945, 605);
            this.m_MainWindowTab.TabIndex = 0;
            this.m_MainWindowTab.Text = "tabPage1";
            this.m_MainWindowTab.UseVisualStyleBackColor = true;
            // 
            // m_PostTextBox
            // 
            this.m_PostTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_PostTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_PostTextBox.Location = new System.Drawing.Point(184, 387);
            this.m_PostTextBox.Name = "m_PostTextBox";
            this.m_PostTextBox.Size = new System.Drawing.Size(477, 26);
            this.m_PostTextBox.TabIndex = 20;
            this.m_PostTextBox.Text = "Anything on your mind?";
            this.m_PostTextBox.Click += new System.EventHandler(this.TextBox_click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(667, 217);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 36);
            this.button4.TabIndex = 13;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(667, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 36);
            this.button3.TabIndex = 14;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // m_ButtonPostStatus
            // 
            this.m_ButtonPostStatus.Location = new System.Drawing.Point(667, 384);
            this.m_ButtonPostStatus.Name = "m_ButtonPostStatus";
            this.m_ButtonPostStatus.Size = new System.Drawing.Size(46, 47);
            this.m_ButtonPostStatus.TabIndex = 15;
            this.m_ButtonPostStatus.UseVisualStyleBackColor = true;
            this.m_ButtonPostStatus.Click += new System.EventHandler(this.m_ButtonPostStatus_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(667, 309);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 36);
            this.button6.TabIndex = 16;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(513, 309);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 36);
            this.button5.TabIndex = 17;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // m_Button_MyAlbums
            // 
            this.m_Button_MyAlbums.Location = new System.Drawing.Point(488, 217);
            this.m_Button_MyAlbums.Name = "m_Button_MyAlbums";
            this.m_Button_MyAlbums.Size = new System.Drawing.Size(94, 36);
            this.m_Button_MyAlbums.TabIndex = 18;
            this.m_Button_MyAlbums.Text = "My Albums";
            this.m_Button_MyAlbums.UseVisualStyleBackColor = true;
            this.m_Button_MyAlbums.Click += new System.EventHandler(this.m_Button_MyAlbums_Click);
            // 
            // m_Button_LogOut
            // 
            this.m_Button_LogOut.Location = new System.Drawing.Point(488, 99);
            this.m_Button_LogOut.Name = "m_Button_LogOut";
            this.m_Button_LogOut.Size = new System.Drawing.Size(88, 88);
            this.m_Button_LogOut.TabIndex = 19;
            this.m_Button_LogOut.Text = "Log Out";
            this.m_Button_LogOut.UseVisualStyleBackColor = true;
            // 
            // m_PictureBox_ProfilePicture
            // 
            this.m_PictureBox_ProfilePicture.Location = new System.Drawing.Point(184, 99);
            this.m_PictureBox_ProfilePicture.Name = "m_PictureBox_ProfilePicture";
            this.m_PictureBox_ProfilePicture.Size = new System.Drawing.Size(252, 264);
            this.m_PictureBox_ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_PictureBox_ProfilePicture.TabIndex = 12;
            this.m_PictureBox_ProfilePicture.TabStop = false;
            // 
            // m_ButtonNextPage
            // 
            this.m_ButtonNextPage.Location = new System.Drawing.Point(491, 407);
            this.m_ButtonNextPage.Name = "m_ButtonNextPage";
            this.m_ButtonNextPage.Size = new System.Drawing.Size(119, 34);
            this.m_ButtonNextPage.TabIndex = 3;
            this.m_ButtonNextPage.Text = "Next Page";
            this.m_ButtonNextPage.UseVisualStyleBackColor = true;
            this.m_ButtonNextPage.Click += new System.EventHandler(this.m_ButtonNextPage_Click);
            // 
            // m_ButtonPreviousPage
            // 
            this.m_ButtonPreviousPage.Location = new System.Drawing.Point(347, 407);
            this.m_ButtonPreviousPage.Name = "m_ButtonPreviousPage";
            this.m_ButtonPreviousPage.Size = new System.Drawing.Size(121, 34);
            this.m_ButtonPreviousPage.TabIndex = 3;
            this.m_ButtonPreviousPage.Text = "Previous Page";
            this.m_ButtonPreviousPage.UseVisualStyleBackColor = true;
            this.m_ButtonPreviousPage.Click += new System.EventHandler(this.m_ButtonPreviousPage_Click);
            // 
            // DesktopFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 643);
            this.Controls.Add(this.m_TabsControl);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "DesktopFacebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.DesktopFacebook_Shown);
            this.m_TabPageMyAlbums.ResumeLayout(false);
            this.m_TabsControl.ResumeLayout(false);
            this.m_MainWindowTab.ResumeLayout(false);
            this.m_MainWindowTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox_ProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl m_TabsControl;
        private System.Windows.Forms.TabPage m_MainWindowTab;
        private System.Windows.Forms.TextBox m_PostTextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button m_ButtonPostStatus;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button m_Button_MyAlbums;
        private System.Windows.Forms.Button m_Button_LogOut;
        private System.Windows.Forms.PictureBox m_PictureBox_ProfilePicture;
        private System.Windows.Forms.TabPage m_TabPageMyAlbums;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox m_ComboBoxAlbums;
        private System.Windows.Forms.Button m_ButtonPreviousPage;
        private System.Windows.Forms.Button m_ButtonNextPage;
    }
}

