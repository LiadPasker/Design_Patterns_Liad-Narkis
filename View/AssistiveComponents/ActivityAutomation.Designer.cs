using System;

namespace View
{
    partial class ActivityAutomation
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.m_TabPagePickTime = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.m_ButtonGoToActionsTabPage = new System.Windows.Forms.Button();
            this.m_ComboBoxPickHour = new System.Windows.Forms.ComboBox();
            this.m_ComboBoxPickMinute = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.m_TabPageActions = new System.Windows.Forms.TabPage();
            this.m_TabPageSummary = new System.Windows.Forms.TabPage();
            this.m_TextBoxScheduledTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_CheckBoxSchedulePost = new System.Windows.Forms.CheckBox();
            this.m_CheckBoxScheduleCheckIn = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_TextBoxScheduleStatus = new System.Windows.Forms.TextBox();
            this.m_ButtonScheduleOrAbort = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.m_TabPagePickTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.m_TabPagePickTime);
            this.tabControl1.Controls.Add(this.m_TabPageActions);
            this.tabControl1.Controls.Add(this.m_TabPageSummary);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(726, 512);
            this.tabControl1.TabIndex = 0;
            // 
            // m_TabPagePickTime
            // 
            this.m_TabPagePickTime.Controls.Add(this.label5);
            this.m_TabPagePickTime.Controls.Add(this.m_ButtonGoToActionsTabPage);
            this.m_TabPagePickTime.Controls.Add(this.m_ComboBoxPickHour);
            this.m_TabPagePickTime.Controls.Add(this.m_ComboBoxPickMinute);
            this.m_TabPagePickTime.Controls.Add(this.label3);
            this.m_TabPagePickTime.Controls.Add(this.label2);
            this.m_TabPagePickTime.Controls.Add(this.monthCalendar1);
            this.m_TabPagePickTime.Location = new System.Drawing.Point(4, 29);
            this.m_TabPagePickTime.Name = "m_TabPagePickTime";
            this.m_TabPagePickTime.Padding = new System.Windows.Forms.Padding(3);
            this.m_TabPagePickTime.Size = new System.Drawing.Size(718, 479);
            this.m_TabPagePickTime.TabIndex = 0;
            this.m_TabPagePickTime.Text = "Pick Time";
            this.m_TabPagePickTime.UseVisualStyleBackColor = true;
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
            // 
            // m_ComboBoxPickHour
            // 
            this.m_ComboBoxPickHour.FormattingEnabled = true;
            this.m_ComboBoxPickHour.Location = new System.Drawing.Point(302, 345);
            this.m_ComboBoxPickHour.Name = "m_ComboBoxPickHour";
            this.m_ComboBoxPickHour.Size = new System.Drawing.Size(78, 28);
            this.m_ComboBoxPickHour.TabIndex = 3;
            this.m_ComboBoxPickHour.SelectedIndexChanged += new System.EventHandler(this.m_ComboBoxPickHour_SelectedIndexChanged);
            // 
            // m_ComboBoxPickMinute
            // 
            this.m_ComboBoxPickMinute.FormattingEnabled = true;
            this.m_ComboBoxPickMinute.Location = new System.Drawing.Point(395, 345);
            this.m_ComboBoxPickMinute.Name = "m_ComboBoxPickMinute";
            this.m_ComboBoxPickMinute.Size = new System.Drawing.Size(78, 28);
            this.m_ComboBoxPickMinute.TabIndex = 3;
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
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(197, 83);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // m_TabPageActions
            // 
            this.m_TabPageActions.Location = new System.Drawing.Point(4, 29);
            this.m_TabPageActions.Name = "m_TabPageActions";
            this.m_TabPageActions.Padding = new System.Windows.Forms.Padding(3);
            this.m_TabPageActions.Size = new System.Drawing.Size(718, 479);
            this.m_TabPageActions.TabIndex = 1;
            this.m_TabPageActions.Text = "Actions";
            this.m_TabPageActions.UseVisualStyleBackColor = true;
            // 
            // m_TabPageSummary
            // 
            this.m_TabPageSummary.Location = new System.Drawing.Point(4, 29);
            this.m_TabPageSummary.Name = "m_TabPageSummary";
            this.m_TabPageSummary.Size = new System.Drawing.Size(718, 479);
            this.m_TabPageSummary.TabIndex = 2;
            this.m_TabPageSummary.Text = "Summary";
            this.m_TabPageSummary.UseVisualStyleBackColor = true;
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
            this.m_TextBoxScheduleStatus.Location = new System.Drawing.Point(408, 537);
            this.m_TextBoxScheduleStatus.Name = "m_TextBoxScheduleStatus";
            this.m_TextBoxScheduleStatus.ReadOnly = true;
            this.m_TextBoxScheduleStatus.Size = new System.Drawing.Size(100, 26);
            this.m_TextBoxScheduleStatus.TabIndex = 1;
            // 
            // m_ButtonScheduleOrAbort
            // 
            this.m_ButtonScheduleOrAbort.Enabled = false;
            this.m_ButtonScheduleOrAbort.Location = new System.Drawing.Point(571, 521);
            this.m_ButtonScheduleOrAbort.Name = "m_ButtonScheduleOrAbort";
            this.m_ButtonScheduleOrAbort.Size = new System.Drawing.Size(132, 40);
            this.m_ButtonScheduleOrAbort.TabIndex = 6;
            this.m_ButtonScheduleOrAbort.Text = "Schedule";
            this.m_ButtonScheduleOrAbort.UseVisualStyleBackColor = true;
            // 
            // ActivityAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.m_ButtonScheduleOrAbort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_CheckBoxScheduleCheckIn);
            this.Controls.Add(this.m_CheckBoxSchedulePost);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_TextBoxScheduleStatus);
            this.Controls.Add(this.m_TextBoxScheduledTime);
            this.Name = "ActivityAutomation";
            this.Size = new System.Drawing.Size(729, 570);
            this.tabControl1.ResumeLayout(false);
            this.m_TabPagePickTime.ResumeLayout(false);
            this.m_TabPagePickTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage m_TabPagePickTime;
        private System.Windows.Forms.TextBox m_TextBoxScheduledTime;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
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
        private System.Windows.Forms.Button m_ButtonScheduleOrAbort;
    }
}
