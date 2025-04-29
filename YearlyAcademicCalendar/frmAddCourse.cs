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
            if (IsValid())
            {
                currCourse = new Course();
                currCourse.Name = txtNewCourseName.Text;
                currCourse.Credits = int.Parse(txtCredits.Text);
                currCourse.Status = (Status)Enum.Parse(typeof(Status), cboStatus.Text.ToUpper());
                currCourse.PrecedingCourseName = txtPrecedingCourseName.Text;
                currCourse.FollowingCourseName = txtFollowingCourseName.Text;

                DialogResult = DialogResult.OK;
            }
        }

        public Course GetNewCourse()
        {
            this.ShowDialog();
            return currCourse;
        }

        private bool IsValid()
        {
            if (Validation.IsTextboxString(txtNewCourseName.Tag.ToString(), txtNewCourseName) &&
                Validation.IsTextboxInt(txtCredits.Tag.ToString(), txtCredits, 1, 5) &&
                Validation.IsComboSelected(cboStatus.Tag.ToString(), cboStatus))
                return true;

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
