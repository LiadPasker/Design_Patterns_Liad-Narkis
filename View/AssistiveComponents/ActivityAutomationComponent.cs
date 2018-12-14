using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class ActivityAutomationComponent : UserControl, IAppComponent
    {
        private DateTime m_SchduledTo;
        private Model.AppFacade m_AppControl;
        private System.Threading.Timer m_PostTimer;
        private TabPage m_TabController = null;

        public ActivityAutomationComponent()
        {
            InitializeComponent();
        }

        public void Initialize(TabPage i_TabPage)
        {
            i_TabPage.Controls.Add(this);
            BackColor = Color.PowderBlue;
            this.Location = new Point((i_TabPage.ClientSize.Width - this.ClientSize.Width) / 2, (i_TabPage.ClientSize.Height - this.ClientSize.Height) / 2);
            this.TabIndex = 0;
            m_TabControlAutomationActivity.SelectTab(m_TabPagePickTime);
        }

        public void Populate(Model.AppFacade i_AppControl, TabPage i_TabPage)
        {
            m_TabController = i_TabPage;
            Initialize(m_TabController);
            m_AppControl = i_AppControl;
            m_SchduledTo = DateTime.Now;
            new Thread(initializePickTimeCumboBoxes).Start();
            if (m_PostTimer == null)
            {
                m_PostTimer = new System.Threading.Timer(HandlePost);
                SetScheduledStatus(false);
            }
        }

        private void HandlePost(object state)
        {
            try
            {
                postData();
            }
            catch (Exception)
            {
                DesktopFacebook.showFacebookServerErrorMessege();
            }
            finally
            {
                m_ButtonAbort.Enabled = false;
                m_ButtonSummaryPagePost.Enabled = true;
                ButtonAbort_Click(null, null);
            }
        }

        private void postData()
        {
            if (m_CheckBoxSchedulePost.Checked && m_CheckBoxScheduleCheckIn.Checked)
            {
                FacebookAuthentication.FAuthInstance.LoggedInUser.PostStatus(m_TextBoxSummaryPost.Text, m_TextBoxSummaryCheckIn.Text);
            }
            else if (m_CheckBoxSchedulePost.Checked)
            {
                FacebookAuthentication.FAuthInstance.LoggedInUser.PostStatus(m_TextBoxSummaryPost.Text);
            }
            else
            {
                FacebookAuthentication.FAuthInstance.LoggedInUser.Checkin(m_TextBoxSummaryCheckIn.Text);
            }
        }

        private void initializePickTimeCumboBoxes()
        {
            for (int i = 0; i < 60; i++)
            {
                if (i < 24)
                {
                    if (i < 10)
                    {
                        m_ComboBoxPickHour.Invoke(new Action(() => { m_ComboBoxPickHour.Items.Add(string.Format("0{0}", i)); }));
                        m_ComboBoxPickMinute.Invoke(new Action(() => { m_ComboBoxPickMinute.Items.Add(string.Format("0{0}", i)); }));
                    }
                    else
                    {
                        m_ComboBoxPickHour.Invoke(new Action(() => { m_ComboBoxPickHour.Items.Add(i); }));
                        m_ComboBoxPickMinute.Invoke(new Action(() => { m_ComboBoxPickMinute.Items.Add(i); }));
                    }
                }
                else
                {
                    m_ComboBoxPickMinute.Invoke(new Action(() => { m_ComboBoxPickMinute.Items.Add(i); }));
                }
            }

            m_ComboBoxPickMinute.Invoke(new Action(() => { m_ComboBoxPickMinute.SelectedIndex = 0; }));
            m_ComboBoxPickHour.Invoke(new Action(() => { m_ComboBoxPickHour.SelectedIndex = 0; }));
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Day < DateTime.Now.Day)
            {
                MessageBox.Show("Invalid Day. Picked Day Will Be Set For Today!");
                m_SchduledTo = DateTime.Today;
            }
            else
            {
                m_SchduledTo = e.Start;
            }
        }

        private void ButtonGoToActionsTabPage_Click(object sender, EventArgs e)
        {
            m_ComboBoxPickHour_TextChanged(null, null);
            m_ComboBoxPickMinute_TextChanged(null, null);
            m_TextBoxScheduledTime.Text = m_SchduledTo.ToString();
            m_TabControlAutomationActivity.SelectTab(m_TabPageActions);
        }

        private void handleButtonCheckBoxTextBoxRelationship(Button i_Button, TextBox i_TextBox, CheckBox i_CheckBox1, CheckBox i_CheckBox2 = null)
        {
            i_TextBox.Enabled = i_CheckBox1.Checked;
            i_Button.Enabled = i_CheckBox1.Checked || i_CheckBox2.Checked;
            if (i_TextBox.Enabled == true)
            {
                i_TextBox.Text = string.Empty;
            }
            else
            {
                i_TextBox.Text = (string)i_TextBox.Tag;
            }
        }

        private void CheckBoxActionPagePost_CheckedChanged(object sender, EventArgs e)
        {
            handleButtonCheckBoxTextBoxRelationship(m_ButtonGoToSummaryTabPage, m_TextBoxActionPagePost, m_CheckBoxActionPagePost, m_CheckBoxActionPageCheckIn);
        }

        private void CheckBoxActionPageCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            handleButtonCheckBoxTextBoxRelationship(m_ButtonGoToSummaryTabPage, m_TextBoxActionPageCheckIn, m_CheckBoxActionPageCheckIn, m_CheckBoxActionPagePost);
        }

        private void ButtonGoToSummaryTabPage_Click(object sender, EventArgs e)
        {
            m_CheckBoxScheduleCheckIn.Checked = m_CheckBoxActionPageCheckIn.Checked && m_TextBoxActionPageCheckIn.Text != string.Empty;
            m_CheckBoxSchedulePost.Checked = m_CheckBoxActionPagePost.Checked && m_TextBoxActionPagePost.Text != string.Empty;

            if (!m_CheckBoxScheduleCheckIn.Checked && !m_CheckBoxSchedulePost.Checked)
            {
                MessageBox.Show("Please make sure that posting empty status/check-in is prohibited\nPlease try again");
            }
            else
            {
                m_TabControlAutomationActivity.SelectTab(m_TabPageSummary);
                new Thread(initializeSummaryTab).Start();
            }
        }

        private void initializeSummaryTab()
        {
            initializeSummaryPageImages();
            m_TextBoxSummaryPost.Invoke(new Action(() => { m_TextBoxSummaryPost.Text = m_CheckBoxSchedulePost.Checked == true ? m_TextBoxActionPagePost.Text : string.Empty; }));
            m_TextBoxSummaryCheckIn.Invoke(new Action(() => { m_TextBoxSummaryCheckIn.Text = m_CheckBoxScheduleCheckIn.Checked == true ? m_TextBoxActionPageCheckIn.Text : string.Empty; }));
            m_ButtonSummaryPagePost.Invoke(new Action(() => { m_ButtonSummaryPagePost.Enabled = m_CheckBoxScheduleCheckIn.Checked || m_CheckBoxSchedulePost.Checked; }));
        }

        private void initializeSummaryPageImages()
        {
            m_ButtonSummaryPagePost.BackgroundImage = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.postStatus.png", 40, 40);
            m_PictureBoxCheckIn.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.checkin.png", 50, 50);
            m_PictureBoxPost.Image = Model.UserAlbumsManager.GetCustomedImageFromEmbeddedResource("Model.pictureSources.postImage.png");
        }

        private void SetScheduledStatus(bool i_IsScheduled = false)
        {
            if (i_IsScheduled)
            {
                m_TextBoxScheduleStatus.Text = "SCHEDULED";
                m_TextBoxScheduleStatus.BackColor = Color.Green;
            }
            else
            {
                m_TextBoxScheduleStatus.Text = "NOT-SCHEDULED";
                m_TextBoxScheduleStatus.BackColor = Color.Red;
            }
        }

        private void ButtonSummaryPagePost_Click(object sender, EventArgs e)
        {
            StartTimerAccordingToUserChoice();
            MessageBox.Show("Automatic Activity Timer Is On!");
            m_ButtonSummaryPagePost.Enabled = false;
            SetScheduledStatus(true);
            m_ButtonAbort.Enabled = true;
        }

        private void StartTimerAccordingToUserChoice()
        {
            // if the due-hour  past, automatic scheduled to the next day
            if (DateTime.Now > m_SchduledTo) 
            {
                m_SchduledTo = m_SchduledTo.AddDays(1);
                MessageBox.Show("Notice That The Time Your Picked Is For Tommorow!");
            }

            int TimeToExecuteInMilliSeconds = (int)(m_SchduledTo - DateTime.Now).TotalMilliseconds;

            try
            {
                m_PostTimer.Change(TimeToExecuteInMilliSeconds, System.Threading.Timeout.Infinite); // Set the timer to elapse only once
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't Set Timer");
            }
        }

        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            try
            {
                m_PostTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                MessageBox.Show("Automatic Activity Timer Stopped");
                zeroizeControllers();
                Populate(m_AppControl, m_TabController);
            }
            catch (Exception)
            {
                MessageBox.Show("Stopping Activity Timer Failed");
            }
        }

        private void zeroizeControllers()
        {
            m_CheckBoxActionPagePost.Checked = m_CheckBoxScheduleCheckIn.Checked = m_CheckBoxSchedulePost.Checked = m_ButtonAbort.Enabled = false;
            m_ButtonSummaryPagePost.Enabled = m_ButtonGoToSummaryTabPage.Enabled = false;
            m_TextBoxScheduledTime.Text = m_TextBoxSummaryPost.Text = string.Empty;
            m_TextBoxActionPagePost.Text = m_TextBoxActionPagePost.Tag.ToString();
            SetScheduledStatus(false);
            m_PostTimer = null;
        }

        private void m_ComboBoxPickHour_TextChanged(object sender, EventArgs e)
        {
            if (m_AppControl.isValidHour(m_ComboBoxPickHour.Text))
            {
                m_SchduledTo = m_SchduledTo.AddHours(m_ComboBoxPickHour.SelectedIndex - m_SchduledTo.Hour);
            }
            else
            {
                MessageBox.Show("Invalid Hour");
                m_ComboBoxPickHour.SelectedIndex = 0;
            }
        }

        private void m_ComboBoxPickMinute_TextChanged(object sender, EventArgs e)
        {
            if (m_AppControl.isValidMinute(m_ComboBoxPickMinute.Text))
            {
                m_SchduledTo = m_SchduledTo.AddMinutes(m_ComboBoxPickMinute.SelectedIndex - m_SchduledTo.Minute);
            }
            else
            {
                MessageBox.Show("Invalid Minute");
                m_ComboBoxPickMinute.SelectedIndex = 0;
            }
        }
    }
}