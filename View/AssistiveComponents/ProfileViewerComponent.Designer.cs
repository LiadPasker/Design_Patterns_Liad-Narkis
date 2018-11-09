namespace View
{
    public partial class ProfileViewerComponent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_ComponentTextBoxFeedAge = new System.Windows.Forms.TextBox();
            this.m_ComponentDataGridViewRecentFeed = new System.Windows.Forms.DataGridView();
            this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ComponentBindingSourceFeed = new System.Windows.Forms.BindingSource(this.components);
            this.m_ComponentDataGridViewUpcomingEvents = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkToFacebookDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_ComponentBindingSourceUpcomingEvents = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_ComponentButtonPostOnWall = new System.Windows.Forms.Button();
            this.m_ComponentTextBoxPostOnWall = new System.Windows.Forms.TextBox();
            this.m_ComponentTextBoxUserInfo = new System.Windows.Forms.TextBox();
            this.m_ComponentPictureBoxProfilePic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentDataGridViewRecentFeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentBindingSourceFeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentDataGridViewUpcomingEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentBindingSourceUpcomingEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentPictureBoxProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ComponentTextBoxFeedAge
            // 
            this.m_ComponentTextBoxFeedAge.Enabled = false;
            this.m_ComponentTextBoxFeedAge.Location = new System.Drawing.Point(768, 5);
            this.m_ComponentTextBoxFeedAge.Name = "m_ComponentTextBoxFeedAge";
            this.m_ComponentTextBoxFeedAge.Size = new System.Drawing.Size(38, 26);
            this.m_ComponentTextBoxFeedAge.TabIndex = 19;
            this.m_ComponentTextBoxFeedAge.Click += new System.EventHandler(this.TextBoxFeedAge_TextChanged);
            this.m_ComponentTextBoxFeedAge.TextChanged += new System.EventHandler(this.TextBoxFeedAge_TextChanged);
            // 
            // m_ComponentDataGridViewRecentFeed
            // 
            this.m_ComponentDataGridViewRecentFeed.AllowUserToAddRows = false;
            this.m_ComponentDataGridViewRecentFeed.AllowUserToDeleteRows = false;
            this.m_ComponentDataGridViewRecentFeed.AutoGenerateColumns = false;
            this.m_ComponentDataGridViewRecentFeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_ComponentDataGridViewRecentFeed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messageDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.placeDataGridViewTextBoxColumn,
            this.fromDataGridViewTextBoxColumn,
            this.createdTimeDataGridViewTextBoxColumn});
            this.m_ComponentDataGridViewRecentFeed.DataSource = this.m_ComponentBindingSourceFeed;
            this.m_ComponentDataGridViewRecentFeed.Location = new System.Drawing.Point(496, 38);
            this.m_ComponentDataGridViewRecentFeed.Name = "m_ComponentDataGridViewRecentFeed";
            this.m_ComponentDataGridViewRecentFeed.ReadOnly = true;
            this.m_ComponentDataGridViewRecentFeed.RowTemplate.Height = 28;
            this.m_ComponentDataGridViewRecentFeed.Size = new System.Drawing.Size(368, 216);
            this.m_ComponentDataGridViewRecentFeed.TabIndex = 18;
            // 
            // messageDataGridViewTextBoxColumn
            // 
            this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
            this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
            this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
            this.messageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // placeDataGridViewTextBoxColumn
            // 
            this.placeDataGridViewTextBoxColumn.DataPropertyName = "Place";
            this.placeDataGridViewTextBoxColumn.HeaderText = "Place";
            this.placeDataGridViewTextBoxColumn.Name = "placeDataGridViewTextBoxColumn";
            this.placeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromDataGridViewTextBoxColumn
            // 
            this.fromDataGridViewTextBoxColumn.DataPropertyName = "From";
            this.fromDataGridViewTextBoxColumn.HeaderText = "From";
            this.fromDataGridViewTextBoxColumn.Name = "fromDataGridViewTextBoxColumn";
            this.fromDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdTimeDataGridViewTextBoxColumn
            // 
            this.createdTimeDataGridViewTextBoxColumn.DataPropertyName = "CreatedTime";
            this.createdTimeDataGridViewTextBoxColumn.HeaderText = "CreatedTime";
            this.createdTimeDataGridViewTextBoxColumn.Name = "createdTimeDataGridViewTextBoxColumn";
            this.createdTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // m_ComponentBindingSourceFeed
            // 
            this.m_ComponentBindingSourceFeed.DataSource = typeof(FacebookWrapper.ObjectModel.Post);
            // 
            // m_ComponentDataGridViewUpcomingEvents
            // 
            this.m_ComponentDataGridViewUpcomingEvents.AllowUserToAddRows = false;
            this.m_ComponentDataGridViewUpcomingEvents.AllowUserToDeleteRows = false;
            this.m_ComponentDataGridViewUpcomingEvents.AutoGenerateColumns = false;
            this.m_ComponentDataGridViewUpcomingEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_ComponentDataGridViewUpcomingEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.linkToFacebookDataGridViewTextBoxColumn,
            this.timeStringDataGridViewTextBoxColumn});
            this.m_ComponentDataGridViewUpcomingEvents.DataSource = this.m_ComponentBindingSourceUpcomingEvents;
            this.m_ComponentDataGridViewUpcomingEvents.Location = new System.Drawing.Point(252, 296);
            this.m_ComponentDataGridViewUpcomingEvents.Name = "m_ComponentDataGridViewUpcomingEvents";
            this.m_ComponentDataGridViewUpcomingEvents.ReadOnly = true;
            this.m_ComponentDataGridViewUpcomingEvents.RowTemplate.Height = 28;
            this.m_ComponentDataGridViewUpcomingEvents.Size = new System.Drawing.Size(612, 172);
            this.m_ComponentDataGridViewUpcomingEvents.TabIndex = 17;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "Start Time";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "End Time";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // linkToFacebookDataGridViewTextBoxColumn
            // 
            this.linkToFacebookDataGridViewTextBoxColumn.DataPropertyName = "LinkToFacebook";
            this.linkToFacebookDataGridViewTextBoxColumn.HeaderText = "Link To Facebook";
            this.linkToFacebookDataGridViewTextBoxColumn.Name = "linkToFacebookDataGridViewTextBoxColumn";
            this.linkToFacebookDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeStringDataGridViewTextBoxColumn
            // 
            this.timeStringDataGridViewTextBoxColumn.DataPropertyName = "TimeString";
            this.timeStringDataGridViewTextBoxColumn.HeaderText = "TimeString";
            this.timeStringDataGridViewTextBoxColumn.Name = "timeStringDataGridViewTextBoxColumn";
            this.timeStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // m_ComponentBindingSourceUpcomingEvents
            // 
            this.m_ComponentBindingSourceUpcomingEvents.DataSource = typeof(FacebookWrapper.ObjectModel.Event);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(247, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Upcoming Events:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(491, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Recent Feed (in months):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(247, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Basic Information:";
            // 
            // m_ComponentButtonPostOnWall
            // 
            this.m_ComponentButtonPostOnWall.BackColor = System.Drawing.Color.DarkBlue;
            this.m_ComponentButtonPostOnWall.Enabled = false;
            this.m_ComponentButtonPostOnWall.ForeColor = System.Drawing.Color.White;
            this.m_ComponentButtonPostOnWall.Location = new System.Drawing.Point(2, 436);
            this.m_ComponentButtonPostOnWall.Name = "m_ComponentButtonPostOnWall";
            this.m_ComponentButtonPostOnWall.Size = new System.Drawing.Size(232, 32);
            this.m_ComponentButtonPostOnWall.TabIndex = 13;
            this.m_ComponentButtonPostOnWall.Text = "Post";
            this.m_ComponentButtonPostOnWall.UseVisualStyleBackColor = false;
            this.m_ComponentButtonPostOnWall.Click += new System.EventHandler(this.ButtonPostOnWall_Click);
            // 
            // m_ComponentTextBoxPostOnWall
            // 
            this.m_ComponentTextBoxPostOnWall.BackColor = System.Drawing.Color.AliceBlue;
            this.m_ComponentTextBoxPostOnWall.Enabled = false;
            this.m_ComponentTextBoxPostOnWall.Location = new System.Drawing.Point(2, 296);
            this.m_ComponentTextBoxPostOnWall.Multiline = true;
            this.m_ComponentTextBoxPostOnWall.Name = "m_ComponentTextBoxPostOnWall";
            this.m_ComponentTextBoxPostOnWall.Size = new System.Drawing.Size(232, 134);
            this.m_ComponentTextBoxPostOnWall.TabIndex = 12;
            this.m_ComponentTextBoxPostOnWall.Tag = "Don\'t you want to say anything?";
            this.m_ComponentTextBoxPostOnWall.Text = "Don\'t you want to say anything?";
            this.m_ComponentTextBoxPostOnWall.Click += new System.EventHandler(this.TextBoxPostOnWall_Click);
            // 
            // m_ComponentTextBoxUserInfo
            // 
            this.m_ComponentTextBoxUserInfo.Enabled = false;
            this.m_ComponentTextBoxUserInfo.Location = new System.Drawing.Point(252, 38);
            this.m_ComponentTextBoxUserInfo.Multiline = true;
            this.m_ComponentTextBoxUserInfo.Name = "m_ComponentTextBoxUserInfo";
            this.m_ComponentTextBoxUserInfo.ReadOnly = true;
            this.m_ComponentTextBoxUserInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_ComponentTextBoxUserInfo.Size = new System.Drawing.Size(224, 216);
            this.m_ComponentTextBoxUserInfo.TabIndex = 11;
            this.m_ComponentTextBoxUserInfo.Text = "[Friend\'s info to show]";
            // 
            // m_ComponentPictureBoxProfilePic
            // 
            this.m_ComponentPictureBoxProfilePic.Location = new System.Drawing.Point(2, 10);
            this.m_ComponentPictureBoxProfilePic.Name = "m_ComponentPictureBoxProfilePic";
            this.m_ComponentPictureBoxProfilePic.Size = new System.Drawing.Size(232, 265);
            this.m_ComponentPictureBoxProfilePic.TabIndex = 10;
            this.m_ComponentPictureBoxProfilePic.TabStop = false;
            // 
            // ProfileViewerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ComponentTextBoxFeedAge);
            this.Controls.Add(this.m_ComponentDataGridViewRecentFeed);
            this.Controls.Add(this.m_ComponentDataGridViewUpcomingEvents);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_ComponentButtonPostOnWall);
            this.Controls.Add(this.m_ComponentTextBoxPostOnWall);
            this.Controls.Add(this.m_ComponentTextBoxUserInfo);
            this.Controls.Add(this.m_ComponentPictureBoxProfilePic);
            this.Name = "ProfileViewerComponent";
            this.Size = new System.Drawing.Size(870, 473);
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentDataGridViewRecentFeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentBindingSourceFeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentDataGridViewUpcomingEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentBindingSourceUpcomingEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ComponentPictureBoxProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_ComponentTextBoxFeedAge;
        private System.Windows.Forms.DataGridView m_ComponentDataGridViewRecentFeed;
        private System.Windows.Forms.DataGridView m_ComponentDataGridViewUpcomingEvents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_ComponentButtonPostOnWall;
        private System.Windows.Forms.TextBox m_ComponentTextBoxPostOnWall;
        private System.Windows.Forms.TextBox m_ComponentTextBoxUserInfo;
        private System.Windows.Forms.PictureBox m_ComponentPictureBoxProfilePic;
        private System.Windows.Forms.BindingSource m_ComponentBindingSourceFeed;
        private System.Windows.Forms.BindingSource m_ComponentBindingSourceUpcomingEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkToFacebookDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeStringDataGridViewTextBoxColumn;
    }
}
