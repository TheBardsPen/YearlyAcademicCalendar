using System;
using System.Windows.Forms;

namespace YearlyAcademicCalendar
{
    public partial class frmDeleteCourse : Form
    {
        private string currCourse;
        private CourseList courseList;

        public frmDeleteCourse()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                currCourse = cboCourse.Text;
                DialogResult = DialogResult.OK;
            }
        }

        public string GetDeletionCourseName(CourseList courses)
        {
            this.courseList = courses;

            cboCourse.Items.Clear();

            // Populate the combo box with course names
            for (int i = 0; i < courseList.Count; i++)
            {
                cboCourse.Items.Add(courseList[i].Name);
            }

            this.ShowDialog();
            return currCourse;
        }

        private bool IsValid()
        {
            return Validation.IsComboSelected(cboCourse.Tag.ToString(), cboCourse);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}