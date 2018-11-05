using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class ActivityAutomation : UserControl
    {
        private DateTime m_SchduledTo;

        public ActivityAutomation()
        {

            InitializeComponent();
            initializePickTimeCumboBoxes();
        }

        private void initializePickTimeCumboBoxes()
        {
            for(int i=0;i<60;i++)
            {
                if (i < 24)
                {
                    if (i < 10)
                    {
                        m_ComboBoxPickHour.Items.Add(string.Format("0{0}", i));
                        m_ComboBoxPickMinute.Items.Add(string.Format("0{0}", i));
                    }
                    else
                    {
                        m_ComboBoxPickHour.Items.Add(i);
                        m_ComboBoxPickMinute.Items.Add(i);
                    }

                }
                else
                {
                    m_ComboBoxPickMinute.Items.Add(i);
                }
            }

            m_ComboBoxPickMinute.SelectedIndex = 0;
            m_ComboBoxPickHour.SelectedIndex = 0;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            m_SchduledTo = e.Start;
        }

        private void m_ComboBoxPickHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_SchduledTo != null && m_ComboBoxPickHour != null)
            {
                m_SchduledTo.AddHours((int)(m_ComboBoxPickHour.SelectedValue) - m_SchduledTo.Hour);
            }
        }
    }
}
