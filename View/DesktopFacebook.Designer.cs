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
            this.m_PictureBox_ProfilePicture = new System.Windows.Forms.PictureBox();
            this.m_Button_LogOut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.m_PostTextBox = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox_ProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PictureBox_ProfilePicture
            // 
            this.m_PictureBox_ProfilePicture.Location = new System.Drawing.Point(195, 109);
            this.m_PictureBox_ProfilePicture.Name = "m_PictureBox_ProfilePicture";
            this.m_PictureBox_ProfilePicture.Size = new System.Drawing.Size(252, 264);
            this.m_PictureBox_ProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_PictureBox_ProfilePicture.TabIndex = 0;
            this.m_PictureBox_ProfilePicture.TabStop = false;
            // 
            // m_Button_LogOut
            // 
            this.m_Button_LogOut.Location = new System.Drawing.Point(499, 109);
            this.m_Button_LogOut.Name = "m_Button_LogOut";
            this.m_Button_LogOut.Size = new System.Drawing.Size(88, 88);
            this.m_Button_LogOut.TabIndex = 1;
            this.m_Button_LogOut.Text = "Log Out";
            this.m_Button_LogOut.UseVisualStyleBackColor = true;
            this.m_Button_LogOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(524, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(678, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 36);
            this.button3.TabIndex = 1;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(678, 227);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 36);
            this.button4.TabIndex = 1;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(524, 319);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(94, 36);
            this.button5.TabIndex = 1;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(678, 319);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 36);
            this.button6.TabIndex = 1;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // m_PostTextBox
            // 
            this.m_PostTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_PostTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_PostTextBox.Location = new System.Drawing.Point(195, 397);
            this.m_PostTextBox.Name = "m_PostTextBox";
            this.m_PostTextBox.Size = new System.Drawing.Size(477, 26);
            this.m_PostTextBox.TabIndex = 2;
            this.m_PostTextBox.Text = "Anything on your mind?";
            this.m_PostTextBox.Click += new System.EventHandler(this.TextBox_click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(678, 394);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 36);
            this.button7.TabIndex = 1;
            this.button7.Text = "Post";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // DesktopFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 568);
            this.Controls.Add(this.m_PostTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.m_Button_LogOut);
            this.Controls.Add(this.m_PictureBox_ProfilePicture);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "DesktopFacebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.DesktopFacebook_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBox_ProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_PictureBox_ProfilePicture;
        private System.Windows.Forms.Button m_Button_LogOut;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox m_PostTextBox;
        private System.Windows.Forms.Button button7;
    }
}

