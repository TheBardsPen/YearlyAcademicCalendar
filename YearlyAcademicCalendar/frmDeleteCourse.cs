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

        public string GetDeletionCourseName(Course[] courses, int size)
        {
            this.courses = courses;
            arraySize = size;

            for (int i = 0; i < arraySize; i++)
                cboCourse.Items.Add(courses[i].Name);

            this.ShowDialog();
            return currCourse;
        }

        private bool IsValid()
        {
            if (Validation.IsComboSelected(cboCourse.Tag.ToString(), cboCourse))
                return true;

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeleteCourse_Load(object sender, EventArgs e)
        {

        }
    }
}
