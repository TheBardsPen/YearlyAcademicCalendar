using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YearlyAcademicCalendar
{
    public partial class frmAddCourse : Form
    {
        private Course currCourse;

        public frmAddCourse()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                currCourse = new Course();
                currCourse.Name = txtNewCourseName.Text;
                currCourse.Credits = int.Parse(txtCredits.Text);
                currCourse.Status = (Status)Enum.Parse(typeof(Status), txtStatus.Text.ToUpper());
                currCourse.PrecedingCourseName = txtPrecedingCourseName.Text;
                currCourse.FollowingCourseName = txtFollowingCourseName.Text;
            }
            this.Close();
        }

        public Course GetNewCourse()
        {
            this.ShowDialog();
            return currCourse;
        }

        private bool ValidateData()
        {
            bool success = true;
            string msg = "";
            
            msg += Validator.IsPresent(txtNewCourseName.Text, lblNewCourseName.Tag.ToString());
            msg += Validator.IsCourseCreditsValid(txtCredits.Text, lblCredits.Tag.ToString());
            msg += Validator.IsStatusValid(txtStatus.Text, lblStatus.Tag.ToString());

            if (msg != "")
            {
                success = false;
                MessageBox.Show(msg, "Entry Error");
            }
            return success;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
