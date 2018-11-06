namespace View
{
    partial class BirthdayViewerComponent
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
            this.m_PictureBoxProfilePicture = new System.Windows.Forms.PictureBox();
            this.m_DataGridViewBirthdays = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_BindingSourceBirthday = new System.Windows.Forms.BindingSource(this.components);
            this.m_TextBoxPost = new System.Windows.Forms.TextBox();
            this.m_ButtonPost = new System.Windows.Forms.Button();
            this.m_ButtonGenerateWish = new System.Windows.Forms.Button();
            this.m_CheckBoxRemoveFriendsThatHadBirthday = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewBirthdays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BindingSourceBirthday)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PictureBoxProfilePicture
            // 
            this.m_PictureBoxProfilePicture.Location = new System.Drawing.Point(2, 3);
            this.m_PictureBoxProfilePicture.Name = "m_PictureBoxProfilePicture";
            this.m_PictureBoxProfilePicture.Size = new System.Drawing.Size(219, 247);
            this.m_PictureBoxProfilePicture.TabIndex = 0;
            this.m_PictureBoxProfilePicture.TabStop = false;
            // 
            // m_DataGridViewBirthdays
            // 
            this.m_DataGridViewBirthdays.AllowUserToAddRows = false;
            this.m_DataGridViewBirthdays.AllowUserToDeleteRows = false;
            this.m_DataGridViewBirthdays.AutoGenerateColumns = false;
            this.m_DataGridViewBirthdays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_DataGridViewBirthdays.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.birthdayDataGridViewTextBoxColumn});
            this.m_DataGridViewBirthdays.DataSource = this.m_BindingSourceBirthday;
            this.m_DataGridViewBirthdays.Location = new System.Drawing.Point(227, 3);
            this.m_DataGridViewBirthdays.MultiSelect = false;
            this.m_DataGridViewBirthdays.Name = "m_DataGridViewBirthdays";
            this.m_DataGridViewBirthdays.ReadOnly = true;
            this.m_DataGridViewBirthdays.RowTemplate.Height = 28;
            this.m_DataGridViewBirthdays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_DataGridViewBirthdays.Size = new System.Drawing.Size(350, 221);
            this.m_DataGridViewBirthdays.TabIndex = 1;
            this.m_DataGridViewBirthdays.SelectionChanged += new System.EventHandler(this.m_DataGridViewBirthdays_SelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.birthdayDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // m_BindingSourceBirthday
            // 
            this.m_BindingSourceBirthday.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // m_TextBoxPost
            // 
            this.m_TextBoxPost.Location = new System.Drawing.Point(3, 255);
            this.m_TextBoxPost.Multiline = true;
            this.m_TextBoxPost.Name = "m_TextBoxPost";
            this.m_TextBoxPost.Size = new System.Drawing.Size(423, 116);
            this.m_TextBoxPost.TabIndex = 2;
            this.m_TextBoxPost.Tag = "[generate birthday wish]";
            this.m_TextBoxPost.Click += new System.EventHandler(this.m_TextBoxPost_Click);
            // 
            // m_ButtonPost
            // 
            this.m_ButtonPost.Location = new System.Drawing.Point(432, 256);
            this.m_ButtonPost.Name = "m_ButtonPost";
            this.m_ButtonPost.Size = new System.Drawing.Size(145, 54);
            this.m_ButtonPost.TabIndex = 3;
            this.m_ButtonPost.Text = "Post";
            this.m_ButtonPost.UseVisualStyleBackColor = true;
            this.m_ButtonPost.Click += new System.EventHandler(this.m_ButtonPost_Click);
            // 
            // m_ButtonGenerateWish
            // 
            this.m_ButtonGenerateWish.Enabled = false;
            this.m_ButtonGenerateWish.Location = new System.Drawing.Point(432, 316);
            this.m_ButtonGenerateWish.Name = "m_ButtonGenerateWish";
            this.m_ButtonGenerateWish.Size = new System.Drawing.Size(145, 55);
            this.m_ButtonGenerateWish.TabIndex = 5;
            this.m_ButtonGenerateWish.Text = "Generate a wish";
            this.m_ButtonGenerateWish.UseVisualStyleBackColor = true;
            this.m_ButtonGenerateWish.Click += new System.EventHandler(this.m_ButtonGenerateWish_Click);
            // 
            // m_CheckBoxRemoveFriendsThatHadBirthday
            // 
            this.m_CheckBoxRemoveFriendsThatHadBirthday.AutoSize = true;
            this.m_CheckBoxRemoveFriendsThatHadBirthday.Location = new System.Drawing.Point(227, 225);
            this.m_CheckBoxRemoveFriendsThatHadBirthday.Name = "m_CheckBoxRemoveFriendsThatHadBirthday";
            this.m_CheckBoxRemoveFriendsThatHadBirthday.Size = new System.Drawing.Size(345, 24);
            this.m_CheckBoxRemoveFriendsThatHadBirthday.TabIndex = 6;
            this.m_CheckBoxRemoveFriendsThatHadBirthday.Text = "Remove Friends Who Already Had Birthday ";
            this.m_CheckBoxRemoveFriendsThatHadBirthday.UseVisualStyleBackColor = true;
            this.m_CheckBoxRemoveFriendsThatHadBirthday.CheckedChanged += new System.EventHandler(this.m_CheckBoxRemoveFriendsThatHadBirthday_CheckedChanged);
            // 
            // BirthdayViewerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_CheckBoxRemoveFriendsThatHadBirthday);
            this.Controls.Add(this.m_ButtonGenerateWish);
            this.Controls.Add(this.m_ButtonPost);
            this.Controls.Add(this.m_TextBoxPost);
            this.Controls.Add(this.m_DataGridViewBirthdays);
            this.Controls.Add(this.m_PictureBoxProfilePicture);
            this.Name = "BirthdayViewerComponent";
            this.Size = new System.Drawing.Size(582, 376);
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewBirthdays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BindingSourceBirthday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_PictureBoxProfilePicture;
        private System.Windows.Forms.DataGridView m_DataGridViewBirthdays;
        private System.Windows.Forms.BindingSource m_BindingSourceBirthday;
        private System.Windows.Forms.TextBox m_TextBoxPost;
        private System.Windows.Forms.Button m_ButtonPost;
        private System.Windows.Forms.Button m_ButtonGenerateWish;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox m_CheckBoxRemoveFriendsThatHadBirthday;
    }
}
