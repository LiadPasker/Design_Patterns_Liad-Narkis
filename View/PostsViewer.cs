using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/////////////// Collection of TextBoxes componnent ///////////////////
namespace View
{
    public class PostsViewer
    {
        private readonly int r_FirstTextBoxLocation_X;
        private readonly int r_FirstTextBoxLocation_Y;
        private readonly TabPage r_PostTabPage;
        private readonly int r_NumberOfTextBoxesToShow = 3;
        public FacebookObjectCollection<Post> m_RecentPosts { get; set; } = null;
        private List<TextBox> m_PostsTextBoxes;
        //private int m_CurrentPage = 0;

        public PostsViewer(TabPage i_PostTabPage)
        {
            r_PostTabPage = i_PostTabPage;
            r_FirstTextBoxLocation_X = r_PostTabPage.ClientSize.Width / 3;
            r_FirstTextBoxLocation_Y = r_PostTabPage.ClientSize.Height / 8;
            initializeComponents();
        }

        private void initializeComponents()
        {
            m_PostsTextBoxes = new List<TextBox>(r_NumberOfTextBoxesToShow);
            m_PostsTextBoxes[0] = new TextBox();
            m_PostsTextBoxes[0].Location = new System.Drawing.Point(r_FirstTextBoxLocation_X, r_FirstTextBoxLocation_Y);
            m_PostsTextBoxes[0].Size = new Size(r_PostTabPage.ClientSize.Width / 2, r_PostTabPage.ClientSize.Height / 4);
            r_PostTabPage.Controls.Add(m_PostsTextBoxes[0]);

            for(int i=0;i<m_PostsTextBoxes.Count;i++)
            {
                m_PostsTextBoxes[i] = new TextBox();
                m_PostsTextBoxes[i].Location = new System.Drawing.Point(m_PostsTextBoxes[i-1].Location.X, m_PostsTextBoxes[i-1].Location.Y+ m_PostsTextBoxes[i-1].Bottom+10);
                m_PostsTextBoxes[i].Size = new Size(m_PostsTextBoxes[i - 1].Width, m_PostsTextBoxes[i - 1].Height);
                r_PostTabPage.Controls.Add(m_PostsTextBoxes[i]);
            }
        }

        private string derivePostTextFormat(Post i_Post)
        {
            return string.Format(
@"FROM: {0}
POSTED AT:{1}
{2}\n\n", i_Post.From.Name, i_Post.CreatedTime.ToString(), i_Post.Message);
        }
        
        public void Show()
        {
            
        }
    }

}
