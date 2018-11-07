using System;

namespace View
{
    partial class ActivityAutomationComponent
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
            this.m_TabControlAutomationActivity = new System.Windows.Forms.TabControl();
            this.m_TabPagePickTime = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.m_ButtonGoToActionsTabPage = new System.Windows.Forms.Button();
            this.m_ComboBoxPickHour = new System.Windows.Forms.ComboBox();
            this.m_ComboBoxPickMinute = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_MonthCalendarScheduleDatePicker = new System.Windows.Forms.MonthCalendar();
            this.m_TabPageActions = new System.Windows.Forms.TabPage();
            this.m_ButtonGoToSummaryTabPage = new System.Windows.Forms.Button();
            this.m_TextBoxActionPageCheckIn = new System.Windows.Forms.TextBox();
            this.m_TextBoxActionPagePost = new System.Windows.Forms.TextBox();
            this.m_CheckBoxActionPageCheckIn = new System.Windows.Forms.CheckBox();
            this.m_CheckBoxActionPagePost = new System.Windows.Forms.CheckBox();
            this.m_TabPageSummary = new System.Windows.Forms.TabPage();
            this.m_PictureBoxPost = new System.Windows.Forms.PictureBox();
            this.m_PictureBoxCheckIn = new System.Windows.Forms.PictureBox();
            this.m_TextBoxSummaryCheckIn = new System.Windows.Forms.TextBox();
            this.m_TextBoxSummaryPost = new System.Windows.Forms.TextBox();
            this.m_ButtonSummaryPagePost = new System.Windows.Forms.Button();
            this.m_TextBoxScheduledTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_CheckBoxSchedulePost = new System.Windows.Forms.CheckBox();
            this.m_CheckBoxScheduleCheckIn = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_TextBoxScheduleStatus = new System.Windows.Forms.TextBox();
            this.m_ButtonAbort = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_TabControlAutomationActivity.SuspendLayout();
            this.m_TabPagePickTime.SuspendLayout();
            this.m_TabPageActions.SuspendLayout();
            this.m_TabPageSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxCheckIn)).BeginInit();
            this.SuspendLayout();
            // 
            // m_TabControlAutomationActivity
            // 
            this.m_TabControlAutomationActivity.Controls.Add(this.m_TabPagePickTime);
            this.m_TabControlAutomationActivity.Controls.Add(this.m_TabPageActions);
            this.m_TabControlAutomationActivity.Controls.Add(this.m_TabPageSummary);
            this.m_TabControlAutomationActivity.Location = new System.Drawing.Point(3, 3);
            this.m_TabControlAutomationActivity.Name = "m_TabControlAutomationActivity";
            this.m_TabControlAutomationActivity.SelectedIndex = 0;
            this.m_TabControlAutomationActivity.Size = new System.Drawing.Size(726, 508);
            this.m_TabControlAutomationActivity.TabIndex = 0;
            // 
            // m_TabPagePickTime
            // 
            this.m_TabPagePickTime.BackColor = System.Drawing.Color.AliceBlue;
            this.m_TabPagePickTime.Controls.Add(this.label5);
            this.m_TabPagePickTime.Controls.Add(this.m_ButtonGoToActionsTabPage);
            this.m_TabPagePickTime.Controls.Add(this.m_ComboBoxPickHour);
            this.m_TabPagePickTime.Controls.Add(this.m_ComboBoxPickMinute);
            this.m_TabPagePickTime.Controls.Add(this.label3);
            this.m_TabPagePickTime.Controls.Add(this.label2);
            this.m_TabPagePickTime.Controls.Add(this.m_MonthCalendarScheduleDatePicker);
            this.m_TabPagePickTime.Location = new System.Drawing.Point(4, 29);
            this.m_TabPagePickTime.Name = "m_TabPagePickTime";
            this.m_TabPagePickTime.Padding = new System.Windows.Forms.Padding(3);
            this.m_TabPagePickTime.Size = new System.Drawing.Size(718, 475);
            this.m_TabPagePickTime.TabIndex = 0;
            this.m_TabPagePickTime.Text = "Pick Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(222, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(279, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pick Time and Date";
            // 
            // m_ButtonGoToActionsTabPage
            // 
            this.m_ButtonGoToActionsTabPage.Location = new System.Drawing.Point(564, 416);
            this.m_ButtonGoToActionsTabPage.Name = "m_ButtonGoToActionsTabPage";
            this.m_ButtonGoToActionsTabPage.Size = new System.Drawing.Size(132, 40);
            this.m_ButtonGoToActionsTabPage.TabIndex = 4;
            this.m_ButtonGoToActionsTabPage.Text = "Proceed";
            this.m_ButtonGoToActionsTabPage.UseVisualStyleBackColor = true;
            this.m_ButtonGoToActionsTabPage.Click += new System.EventHandler(this.ButtonGoToActionsTabPage_Click);
            // 
            // m_ComboBoxPickHour
            // 
            this.m_ComboBoxPickHour.BackColor = System.Drawing.Color.Azure;
            this.m_ComboBoxPickHour.FormattingEnabled = true;
            this.m_ComboBoxPickHour.Location = new System.Drawing.Point(302, 345);
            this.m_ComboBoxPickHour.Name = "m_ComboBoxPickHour";
            this.m_ComboBoxPickHour.Size = new System.Drawing.Size(78, 28);
            this.m_ComboBoxPickHour.TabIndex = 3;
            this.m_ComboBoxPickHour.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPickHour_SelectedIndexChanged);
            // 
            // m_ComboBoxPickMinute
            // 
            this.m_ComboBoxPickMinute.BackColor = System.Drawing.Color.Azure;
            this.m_ComboBoxPickMinute.FormattingEnabled = true;
            this.m_ComboBoxPickMinute.Location = new System.Drawing.Point(395, 345);
            this.m_ComboBoxPickMinute.Name = "m_ComboBoxPickMinute";
            this.m_ComboBoxPickMinute.Size = new System.Drawing.Size(78, 28);
            this.m_ComboBoxPickMinute.TabIndex = 3;
            this.m_ComboBoxPickMinute.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPickMinute_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(379, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(234, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Time:";
            // 
            // m_MonthCalendarScheduleDatePicker
            // 
            this.m_MonthCalendarScheduleDatePicker.BackColor = System.Drawing.Color.Azure;
            this.m_MonthCalendarScheduleDatePicker.Location = new System.Drawing.Point(197, 83);
            this.m_MonthCalendarScheduleDatePicker.Name = "m_MonthCalendarScheduleDatePicker";
            this.m_MonthCalendarScheduleDatePicker.TabIndex = 0;
            this.m_MonthCalendarScheduleDatePicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // m_TabPageActions
            // 
            this.m_TabPageActions.BackColor = System.Drawing.Color.AliceBlue;
            this.m_TabPageActions.Controls.Add(this.m_ButtonGoToSummaryTabPage);
            this.m_TabPageActions.Controls.Add(this.m_TextBoxActionPageCheckIn);
            this.m_TabPageActions.Controls.Add(this.m_TextBoxActionPagePost);
            this.m_TabPageActions.Controls.Add(this.m_CheckBoxActionPageCheckIn);
            this.m_TabPageActions.Controls.Add(this.m_CheckBoxActionPagePost);
            this.m_TabPageActions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_TabPageActions.Location = new System.Drawing.Point(4, 29);
            this.m_TabPageActions.Name = "m_TabPageActions";
            this.m_TabPageActions.Padding = new System.Windows.Forms.Padding(3);
            this.m_TabPageActions.Size = new System.Drawing.Size(718, 475);
            this.m_TabPageActions.TabIndex = 1;
            this.m_TabPageActions.Text = "Actions";
            // 
            // m_ButtonGoToSummaryTabPage
            // 
            this.m_ButtonGoToSummaryTabPage.Enabled = false;
            this.m_ButtonGoToSummaryTabPage.Location = new System.Drawing.Point(564, 415);
            this.m_ButtonGoToSummaryTabPage.Name = "m_ButtonGoToSummaryTabPage";
            this.m_ButtonGoToSummaryTabPage.Size = new System.Drawing.Size(132, 40);
            this.m_ButtonGoToSummaryTabPage.TabIndex = 5;
            this.m_ButtonGoToSummaryTabPage.Text = "Proceed";
            this.m_ButtonGoToSummaryTabPage.UseVisualStyleBackColor = true;
            this.m_ButtonGoToSummaryTabPage.Click += new System.EventHandler(this.ButtonGoToSummaryTabPage_Click);
            // 
            // m_TextBoxActionPageCheckIn
            // 
            this.m_TextBoxActionPageCheckIn.BackColor = System.Drawing.Color.Azure;
            this.m_TextBoxActionPageCheckIn.Enabled = false;
            this.m_TextBoxActionPageCheckIn.Location = new System.Drawing.Point(175, 330);
            this.m_TextBoxActionPageCheckIn.Name = "m_TextBoxActionPageCheckIn";
            this.m_TextBoxActionPageCheckIn.Size = new System.Drawing.Size(370, 26);
            this.m_TextBoxActionPageCheckIn.TabIndex = 1;
            this.m_TextBoxActionPageCheckIn.Tag = "Where Are You?";
            this.m_TextBoxActionPageCheckIn.Text = "Where Are You?";
            // 
            // m_TextBoxActionPagePost
            // 
            this.m_TextBoxActionPagePost.BackColor = System.Drawing.Color.Azure;
            this.m_TextBoxActionPagePost.Enabled = false;
            this.m_TextBoxActionPagePost.Location = new System.Drawing.Point(175, 98);
            this.m_TextBoxActionPagePost.Multiline = true;
            this.m_TextBoxActionPagePost.Name = "m_TextBoxActionPagePost";
            this.m_TextBoxActionPagePost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_TextBoxActionPagePost.Size = new System.Drawing.Size(370, 119);
            this.m_TextBoxActionPagePost.TabIndex = 1;
            this.m_TextBoxActionPagePost.Tag = "What\'s On Your Mind?";
            this.m_TextBoxActionPagePost.Text = "What\'s On Your Mind?";
            // 
            // m_CheckBoxActionPageCheckIn
            // 
            this.m_CheckBoxActionPageCheckIn.AutoSize = true;
            this.m_CheckBoxActionPageCheckIn.Location = new System.Drawing.Point(175, 300);
            this.m_CheckBoxActionPageCheckIn.Name = "m_CheckBoxActionPageCheckIn";
            this.m_CheckBoxActionPageCheckIn.Size = new System.Drawing.Size(99, 24);
            this.m_CheckBoxActionPageCheckIn.TabIndex = 0;
            this.m_CheckBoxActionPageCheckIn.Text = "Check-In";
            this.m_CheckBoxActionPageCheckIn.UseVisualStyleBackColor = true;
            this.m_CheckBoxActionPageCheckIn.CheckedChanged += new System.EventHandler(this.CheckBoxActionPageCheckIn_CheckedChanged);
            // 
            // m_CheckBoxActionPagePost
            // 
            this.m_CheckBoxActionPagePost.AutoSize = true;
            this.m_CheckBoxActionPagePost.Location = new System.Drawing.Point(175, 68);
            this.m_CheckBoxActionPagePost.Name = "m_CheckBoxActionPagePost";
            this.m_CheckBoxActionPagePost.Size = new System.Drawing.Size(67, 24);
            this.m_CheckBoxActionPagePost.TabIndex = 0;
            this.m_CheckBoxActionPagePost.Text = "Post";
            this.m_CheckBoxActionPagePost.UseVisualStyleBackColor = true;
            this.m_CheckBoxActionPagePost.CheckedChanged += new System.EventHandler(this.CheckBoxActionPagePost_CheckedChanged);
            // 
            // m_TabPageSummary
            // 
            this.m_TabPageSummary.BackColor = System.Drawing.Color.AliceBlue;
            this.m_TabPageSummary.Controls.Add(this.label7);
            this.m_TabPageSummary.Controls.Add(this.m_PictureBoxPost);
            this.m_TabPageSummary.Controls.Add(this.m_PictureBoxCheckIn);
            this.m_TabPageSummary.Controls.Add(this.m_TextBoxSummaryCheckIn);
            this.m_TabPageSummary.Controls.Add(this.m_TextBoxSummaryPost);
            this.m_TabPageSummary.Controls.Add(this.m_ButtonSummaryPagePost);
            this.m_TabPageSummary.Location = new System.Drawing.Point(4, 29);
            this.m_TabPageSummary.Name = "m_TabPageSummary";
            this.m_TabPageSummary.Size = new System.Drawing.Size(718, 475);
            this.m_TabPageSummary.TabIndex = 2;
            this.m_TabPageSummary.Text = "Summary";
            // 
            // m_PictureBoxPost
            // 
            this.m_PictureBoxPost.Location = new System.Drawing.Point(514, 26);
            this.m_PictureBoxPost.Name = "m_PictureBoxPost";
            this.m_PictureBoxPost.Size = new System.Drawing.Size(107, 101);
            this.m_PictureBoxPost.TabIndex = 9;
            this.m_PictureBoxPost.TabStop = false;
            // 
            // m_PictureBoxCheckIn
            // 
            this.m_PictureBoxCheckIn.Location = new System.Drawing.Point(514, 194);
            this.m_PictureBoxCheckIn.Name = "m_PictureBoxCheckIn";
            this.m_PictureBoxCheckIn.Size = new System.Drawing.Size(84, 85);
            this.m_PictureBoxCheckIn.TabIndex = 9;
            this.m_PictureBoxCheckIn.TabStop = false;
            // 
            // m_TextBoxSummaryCheckIn
            // 
            this.m_TextBoxSummaryCheckIn.BackColor = System.Drawing.Color.Azure;
            this.m_TextBoxSummaryCheckIn.Location = new System.Drawing.Point(209, 253);
            this.m_TextBoxSummaryCheckIn.Name = "m_TextBoxSummaryCheckIn";
            this.m_TextBoxSummaryCheckIn.ReadOnly = true;
            this.m_TextBoxSummaryCheckIn.Size = new System.Drawing.Size(299, 26);
            this.m_TextBoxSummaryCheckIn.TabIndex = 8;
            // 
            // m_TextBoxSummaryPost
            // 
            this.m_TextBoxSummaryPost.BackColor = System.Drawing.Color.Azure;
            this.m_TextBoxSummaryPost.Location = new System.Drawing.Point(209, 90);
            this.m_TextBoxSummaryPost.Multiline = true;
            this.m_TextBoxSummaryPost.Name = "m_TextBoxSummaryPost";
            this.m_TextBoxSummaryPost.ReadOnly = true;
            this.m_TextBoxSummaryPost.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_TextBoxSummaryPost.Size = new System.Drawing.Size(299, 84);
            this.m_TextBoxSummaryPost.TabIndex = 7;
            // 
            // m_ButtonSummaryPagePost
            // 
            this.m_ButtonSummaryPagePost.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.m_ButtonSummaryPagePost.Enabled = false;
            this.m_ButtonSummaryPagePost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_ButtonSummaryPagePost.ForeColor = System.Drawing.Color.White;
            this.m_ButtonSummaryPagePost.Location = new System.Drawing.Point(337, 320);
            this.m_ButtonSummaryPagePost.Name = "m_ButtonSummaryPagePost";
            this.m_ButtonSummaryPagePost.Size = new System.Drawing.Size(60, 60);
            this.m_ButtonSummaryPagePost.TabIndex = 6;
            this.m_ButtonSummaryPagePost.UseVisualStyleBackColor = false;
            this.m_ButtonSummaryPagePost.Click += new System.EventHandler(this.ButtonSummaryPagePost_Click);
            // 
            // m_TextBoxScheduledTime
            // 
            this.m_TextBoxScheduledTime.Location = new System.Drawing.Point(7, 537);
            this.m_TextBoxScheduledTime.Name = "m_TextBoxScheduledTime";
            this.m_TextBoxScheduledTime.ReadOnly = true;
            this.m_TextBoxScheduledTime.Size = new System.Drawing.Size(164, 26);
            this.m_TextBoxScheduledTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(3, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scheduled To:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(200, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Actions:";
            // 
            // m_CheckBoxSchedulePost
            // 
            this.m_CheckBoxSchedulePost.AutoSize = true;
            this.m_CheckBoxSchedulePost.Enabled = false;
            this.m_CheckBoxSchedulePost.Location = new System.Drawing.Point(274, 517);
            this.m_CheckBoxSchedulePost.Name = "m_CheckBoxSchedulePost";
            this.m_CheckBoxSchedulePost.Size = new System.Drawing.Size(67, 24);
            this.m_CheckBoxSchedulePost.TabIndex = 3;
            this.m_CheckBoxSchedulePost.Text = "Post";
            this.m_CheckBoxSchedulePost.UseVisualStyleBackColor = true;
            // 
            // m_CheckBoxScheduleCheckIn
            // 
            this.m_CheckBoxScheduleCheckIn.AutoSize = true;
            this.m_CheckBoxScheduleCheckIn.Enabled = false;
            this.m_CheckBoxScheduleCheckIn.Location = new System.Drawing.Point(274, 542);
            this.m_CheckBoxScheduleCheckIn.Name = "m_CheckBoxScheduleCheckIn";
            this.m_CheckBoxScheduleCheckIn.Size = new System.Drawing.Size(99, 24);
            this.m_CheckBoxScheduleCheckIn.TabIndex = 4;
            this.m_CheckBoxScheduleCheckIn.Text = "Check-In";
            this.m_CheckBoxScheduleCheckIn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(404, 514);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status:";
            // 
            // m_TextBoxScheduleStatus
            // 
            this.m_TextBoxScheduleStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_TextBoxScheduleStatus.Location = new System.Drawing.Point(408, 537);
            this.m_TextBoxScheduleStatus.Name = "m_TextBoxScheduleStatus";
            this.m_TextBoxScheduleStatus.ReadOnly = true;
            this.m_TextBoxScheduleStatus.Size = new System.Drawing.Size(132, 23);
            this.m_TextBoxScheduleStatus.TabIndex = 1;
            // 
            // m_ButtonAbort
            // 
            this.m_ButtonAbort.BackColor = System.Drawing.Color.Crimson;
            this.m_ButtonAbort.Enabled = false;
            this.m_ButtonAbort.ForeColor = System.Drawing.Color.White;
            this.m_ButtonAbort.Location = new System.Drawing.Point(628, 521);
            this.m_ButtonAbort.Name = "m_ButtonAbort";
            this.m_ButtonAbort.Size = new System.Drawing.Size(75, 40);
            this.m_ButtonAbort.TabIndex = 6;
            this.m_ButtonAbort.Text = "Abort";
            this.m_ButtonAbort.UseVisualStyleBackColor = false;
            this.m_ButtonAbort.Click += new System.EventHandler(this.ButtonAbort_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(17, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(430, 60);
            this.label7.TabIndex = 10;
            this.label7.Text = "Notice:\r\nAny changes you\'ll make followed with setting another timer,\r\nwill cause" +
    " a complete loss of the old one (if was).";
            // 
            // ActivityAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.Controls.Add(this.m_ButtonAbort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_CheckBoxScheduleCheckIn);
            this.Controls.Add(this.m_CheckBoxSchedulePost);
            this.Controls.Add(this.m_TabControlAutomationActivity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_TextBoxScheduleStatus);
            this.Controls.Add(this.m_TextBoxScheduledTime);
            this.Name = "ActivityAutomation";
            this.Size = new System.Drawing.Size(729, 570);
            this.m_TabControlAutomationActivity.ResumeLayout(false);
            this.m_TabPagePickTime.ResumeLayout(false);
            this.m_TabPagePickTime.PerformLayout();
            this.m_TabPageActions.ResumeLayout(false);
            this.m_TabPageActions.PerformLayout();
            this.m_TabPageSummary.ResumeLayout(false);
            this.m_TabPageSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxCheckIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl m_TabControlAutomationActivity;
        private System.Windows.Forms.TabPage m_TabPagePickTime;
        private System.Windows.Forms.TextBox m_TextBoxScheduledTime;
        private System.Windows.Forms.MonthCalendar m_MonthCalendarScheduleDatePicker;
        private System.Windows.Forms.TabPage m_TabPageActions;
        private System.Windows.Forms.TabPage m_TabPageSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_ButtonGoToActionsTabPage;
        private System.Windows.Forms.ComboBox m_ComboBoxPickHour;
        private System.Windows.Forms.ComboBox m_ComboBoxPickMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_CheckBoxSchedulePost;
        private System.Windows.Forms.CheckBox m_CheckBoxScheduleCheckIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_TextBoxScheduleStatus;
        private System.Windows.Forms.Button m_ButtonAbort;
        private System.Windows.Forms.TextBox m_TextBoxActionPageCheckIn;
        private System.Windows.Forms.TextBox m_TextBoxActionPagePost;
        private System.Windows.Forms.CheckBox m_CheckBoxActionPageCheckIn;
        private System.Windows.Forms.CheckBox m_CheckBoxActionPagePost;
        private System.Windows.Forms.Button m_ButtonGoToSummaryTabPage;
        private System.Windows.Forms.Button m_ButtonSummaryPagePost;
        private System.Windows.Forms.PictureBox m_PictureBoxPost;
        private System.Windows.Forms.PictureBox m_PictureBoxCheckIn;
        private System.Windows.Forms.TextBox m_TextBoxSummaryCheckIn;
        private System.Windows.Forms.TextBox m_TextBoxSummaryPost;
        private System.Windows.Forms.Label label7;
    }
}
