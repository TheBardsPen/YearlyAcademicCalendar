namespace YearlyAcademicCalendar
{
    partial class frmAddCourse
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
            this.lblNewCourseName = new System.Windows.Forms.Label();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPrecedingCourseName = new System.Windows.Forms.Label();
            this.lblFollowingCourseName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNewCourseName = new System.Windows.Forms.TextBox();
            this.txtCredits = new System.Windows.Forms.TextBox();
            this.txtPrecedingCourseName = new System.Windows.Forms.TextBox();
            this.txtFollowingCourseName = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNewCourseName
            // 
            this.lblNewCourseName.AutoSize = true;
            this.lblNewCourseName.Location = new System.Drawing.Point(35, 24);
            this.lblNewCourseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewCourseName.Name = "lblNewCourseName";
            this.lblNewCourseName.Size = new System.Drawing.Size(99, 13);
            this.lblNewCourseName.TabIndex = 0;
            this.lblNewCourseName.Tag = "New Course Name";
            this.lblNewCourseName.Text = "New Course Name:";
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new System.Drawing.Point(35, 64);
            this.lblCredits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(42, 13);
            this.lblCredits.TabIndex = 1;
            this.lblCredits.Tag = "Credits";
            this.lblCredits.Text = "Credits:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(35, 104);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Tag = "Status";
            this.lblStatus.Text = "Status:";
            // 
            // lblPrecedingCourseName
            // 
            this.lblPrecedingCourseName.AutoSize = true;
            this.lblPrecedingCourseName.Location = new System.Drawing.Point(35, 144);
            this.lblPrecedingCourseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecedingCourseName.Name = "lblPrecedingCourseName";
            this.lblPrecedingCourseName.Size = new System.Drawing.Size(125, 13);
            this.lblPrecedingCourseName.TabIndex = 3;
            this.lblPrecedingCourseName.Tag = "Preceding Course Name";
            this.lblPrecedingCourseName.Text = "Preceding Course Name:";
            // 
            // lblFollowingCourseName
            // 
            this.lblFollowingCourseName.AutoSize = true;
            this.lblFollowingCourseName.Location = new System.Drawing.Point(35, 184);
            this.lblFollowingCourseName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFollowingCourseName.Name = "lblFollowingCourseName";
            this.lblFollowingCourseName.Size = new System.Drawing.Size(121, 13);
            this.lblFollowingCourseName.TabIndex = 4;
            this.lblFollowingCourseName.Tag = "Following Course Name";
            this.lblFollowingCourseName.Text = "Following Course Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(79, 237);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 237);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtNewCourseName
            // 
            this.txtNewCourseName.Location = new System.Drawing.Point(170, 21);
            this.txtNewCourseName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewCourseName.Name = "txtNewCourseName";
            this.txtNewCourseName.Size = new System.Drawing.Size(195, 20);
            this.txtNewCourseName.TabIndex = 7;
            this.txtNewCourseName.Tag = "New Course Name";
            // 
            // txtCredits
            // 
            this.txtCredits.Location = new System.Drawing.Point(170, 61);
            this.txtCredits.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.Size = new System.Drawing.Size(195, 20);
            this.txtCredits.TabIndex = 8;
            this.txtCredits.Tag = "Credits";
            // 
            // txtPrecedingCourseName
            // 
            this.txtPrecedingCourseName.Location = new System.Drawing.Point(170, 141);
            this.txtPrecedingCourseName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecedingCourseName.Name = "txtPrecedingCourseName";
            this.txtPrecedingCourseName.Size = new System.Drawing.Size(195, 20);
            this.txtPrecedingCourseName.TabIndex = 10;
            // 
            // txtFollowingCourseName
            // 
            this.txtFollowingCourseName.Location = new System.Drawing.Point(170, 181);
            this.txtFollowingCourseName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFollowingCourseName.Name = "txtFollowingCourseName";
            this.txtFollowingCourseName.Size = new System.Drawing.Size(195, 20);
            this.txtFollowingCourseName.TabIndex = 11;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "NotStarted",
            "InProgress",
            "Passed",
            "Failed"});
            this.cboStatus.Location = new System.Drawing.Point(170, 101);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(195, 21);
            this.cboStatus.TabIndex = 12;
            this.cboStatus.Tag = "Status";
            // 
            // frmAddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 289);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.txtFollowingCourseName);
            this.Controls.Add(this.txtPrecedingCourseName);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.txtNewCourseName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFollowingCourseName);
            this.Controls.Add(this.lblPrecedingCourseName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.lblNewCourseName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAddCourse";
            this.Text = "Add New Course";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewCourseName;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPrecedingCourseName;
        private System.Windows.Forms.Label lblFollowingCourseName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNewCourseName;
        private System.Windows.Forms.TextBox txtCredits;
        private System.Windows.Forms.TextBox txtPrecedingCourseName;
        private System.Windows.Forms.TextBox txtFollowingCourseName;
        private System.Windows.Forms.ComboBox cboStatus;
    }
}