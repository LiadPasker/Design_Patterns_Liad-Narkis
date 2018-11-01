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
            this.m_BindingSourceBirthday = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_TextBoxPost = new System.Windows.Forms.TextBox();
            this.m_ButtonPost = new System.Windows.Forms.Button();
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
            this.m_DataGridViewBirthdays.Name = "m_DataGridViewBirthdays";
            this.m_DataGridViewBirthdays.ReadOnly = true;
            this.m_DataGridViewBirthdays.RowTemplate.Height = 28;
            this.m_DataGridViewBirthdays.Size = new System.Drawing.Size(350, 247);
            this.m_DataGridViewBirthdays.TabIndex = 1;
            // 
            // m_BindingSourceBirthday
            // 
            this.m_BindingSourceBirthday.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            this.birthdayDataGridViewTextBoxColumn.DataPropertyName = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            this.birthdayDataGridViewTextBoxColumn.ReadOnly = true;
            this.birthdayDataGridViewTextBoxColumn.Width = 150;
            // 
            // m_TextBoxPost
            // 
            this.m_TextBoxPost.Location = new System.Drawing.Point(72, 255);
            this.m_TextBoxPost.Multiline = true;
            this.m_TextBoxPost.Name = "m_TextBoxPost";
            this.m_TextBoxPost.Size = new System.Drawing.Size(379, 107);
            this.m_TextBoxPost.TabIndex = 2;
            // 
            // m_ButtonPost
            // 
            this.m_ButtonPost.Location = new System.Drawing.Point(457, 284);
            this.m_ButtonPost.Name = "m_ButtonPost";
            this.m_ButtonPost.Size = new System.Drawing.Size(60, 54);
            this.m_ButtonPost.TabIndex = 3;
            this.m_ButtonPost.Text = "Post";
            this.m_ButtonPost.UseVisualStyleBackColor = true;
            // 
            // BirthdayViewerComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ButtonPost);
            this.Controls.Add(this.m_TextBoxPost);
            this.Controls.Add(this.m_DataGridViewBirthdays);
            this.Controls.Add(this.m_PictureBoxProfilePicture);
            this.Name = "BirthdayViewerComponent";
            this.Size = new System.Drawing.Size(580, 367);
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataGridViewBirthdays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_BindingSourceBirthday)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_PictureBoxProfilePicture;
        private System.Windows.Forms.DataGridView m_DataGridViewBirthdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource m_BindingSourceBirthday;
        private System.Windows.Forms.TextBox m_TextBoxPost;
        private System.Windows.Forms.Button m_ButtonPost;
    }
}
