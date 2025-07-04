﻿using System;
using System.Windows.Forms;

namespace YearlyAcademicCalendar
{
    public partial class frmYearlyAcademicCalendar : Form
    {
        public frmYearlyAcademicCalendar()
        {
            InitializeComponent();

            courses.Changed += Courses_Changed; // Event wiring for course changes
        }

        private static readonly int MAX_NUMBER_OF_COURSES = 9;

        private CourseList courses = new CourseList();
        private int totalCredits = 0;
        private int totalCreditsCompleted = 0;

        #region Event Handlers

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDeleteCourse frmDeleteCourse = new frmDeleteCourse();
            string courseToDelete = frmDeleteCourse.GetDeletionCourseName(courses); // returns the course name to delete

            // Check if the user selected a course to delete
            if (!string.IsNullOrEmpty(courseToDelete))
            {
                int deleteIndex = -1;
                for (int i = 0; i < courses.Count; i++)
                {
                    // Check if the course name matches the one to delete
                    if (courses[i].Name.Equals(courseToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        deleteIndex = i;
                        break;
                    }
                }

                if (deleteIndex != -1)
                {
                    courses -= courses[deleteIndex]; // triggers Changed event
                }
                else
                {
                    MessageBox.Show($"Course {courseToDelete} does not exist.", "Error");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (courses.Count == MAX_NUMBER_OF_COURSES)
            {
                MessageBox.Show($"The academic plan is full. Please delete courses to add new ones.", "Plan Full Error");
            }
            else
            {
                frmAddCourse addCourseForm = new frmAddCourse();
                Course newCourse = addCourseForm.GetNewCourse();

                if (addCourseForm.DialogResult == DialogResult.OK)
                    addCourseToList(newCourse);
            }

            UpdateForm();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            string msg = "";
            for (int i = 0; i < courses.Count; i++)
            {
                msg += courses[i].ToString();
            }

            MessageBox.Show(msg, "Academic Plan");
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllForm();
        }

        #endregion

        #region Methods

        // Courses_Changed is called when a course is added or removed
        private void Courses_Changed(Course course, bool add)
        {
            if (add)
            {
                totalCredits += course.Credits;

                if (course.Status == Status.PASSED)
                {
                    totalCreditsCompleted += course.Credits;
                }
            }
            else
            {
                // If a course is removed, we need to update the total credits
                totalCredits -= course.Credits;

                if (course.Status == Status.PASSED)
                {
                    totalCreditsCompleted -= course.Credits;
                }
            }

            UpdateForm();

            UpdateCourseProperties();
        }

        private void UpdateForm()
        {
            // Update the total credits and completed credits text boxes
            txtTotalCredits.Text = totalCredits.ToString();
            txtTotalCreditsCompleted.Text = totalCreditsCompleted.ToString();

            TextBox[] txtBoxes = { textBox1, textBox2, textBox3, textBox4,
                textBox5, textBox6, textBox7, textBox8, textBox9};

            for (int i = 0; i < txtBoxes.Length; i++)
            {
                if (i < courses.Count)
                    txtBoxes[i].Text = courses[i].Name;
                else
                    txtBoxes[i].Text = "";
            }
        }

        private void UpdateCourseProperties()
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (i == 0)
                {
                    var course = courses[i];
                    course.PrecedingCourseName = null;
                    if (courses.Count > 1)
                        course.FollowingCourseName = courses[i + 1].Name;
                    courses[i] = course;
                }
                else if (i < courses.Count - 1)
                {
                    var course = courses[i];
                    course.PrecedingCourseName = courses[i - 1].Name;
                    course.FollowingCourseName = courses[i + 1].Name;
                    courses[i] = course;
                }
                else if (i == courses.Count - 1)
                {
                    var course = courses[i];
                    if (courses.Count > 1)
                        course.PrecedingCourseName = courses[i - 1].Name;
                    course.FollowingCourseName = null;
                    courses[i] = course;
                }
            }
        }

        private void addCourseToList(Course newCourse)
        {
            try
            {
                int addIndex = getAddIndex(newCourse);

                //If there are no elements in the array
                if (addIndex == 0 && courses.Count == 0)
                {
                    newCourse.PrecedingCourseName = null;
                    newCourse.FollowingCourseName = null;
                    courses += newCourse;
                }
                else
                {
                    courses.Add(newCourse, addIndex);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private int getAddIndex(Course addCourse)
        {
            int index = 0;

            // Check if the course is the first one
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name == addCourse.PrecedingCourseName)
                {
                    index = i + 1;

                    break;
                }
                else if (courses[i].Name == addCourse.FollowingCourseName)
                {
                    index = i;

                    break;
                }

                if (courses[i].Name == addCourse.Name)
                    throw new Exception($"Course {addCourse.Name} already exists.");
            }

            return index;
        }

        // ClearAllForm clears all the text boxes and resets the course list
        private void ClearAllForm()
        {
            txtTotalCredits.Clear();
            txtTotalCreditsCompleted.Clear();

            TextBox[] txtBoxes = { textBox1, textBox2, textBox3, textBox4,
                textBox5, textBox6, textBox7, textBox8, textBox9};

            foreach (TextBox txtBox in txtBoxes)
            {
                txtBox.Clear();
            }

            courses.Clear();
            totalCredits = 0;
            totalCreditsCompleted = 0;
        }

        #endregion
    }
}