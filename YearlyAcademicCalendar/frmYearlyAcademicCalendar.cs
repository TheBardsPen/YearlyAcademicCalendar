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
    public partial class frmYearlyAcademicCalendar : Form
    {

        public frmYearlyAcademicCalendar()
        {
            InitializeComponent();
        }
        
        private static readonly int MAX_NUMBER_OF_COURSES = 9;

        private CourseList courses = new CourseList();
        private int totalCredits = 0;
        private int totalCreditsCompleted = 0;

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            ClearAllForm();
        }

        private void ClearAllForm()
        {
            txtTotalCredits.Text = "";
            txtTotalCreditsCompleted.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            courses = new CourseList();
            totalCredits = 0;
            totalCreditsCompleted = 0;
            //coursesArraySize = 0;
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
                    //addCourseToArray(newCourse);
            }

            UpdateForm();
        }

        private int getAddIndexAndUpdateTotalCredits(Course addCourse)
        {
            int index = 0;
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name == addCourse.PrecedingCourseName)
                {
                    index = i + 1;

                    break;
                }
                else if (courses[i].Name == addCourse.PrecedingCourseName)
                {
                    index = i - 1;

                    break;
                }

                if (courses[i].Name == addCourse.Name)
                    throw new Exception($"Course {addCourse.Name} already exists.");
            }
                        
            //foreach(Course c in courses)
            //{
            //    if(c.Name == addCourse.Name)
            //        throw new Exception($"Course {addCourse.Name} already exists.");
            //}

            totalCredits += addCourse.Credits;

            if (addCourse.Status == Status.PASSED)
            {
                totalCreditsCompleted += addCourse.Credits;
            }

            return index;
        }

        //private int getDeleteIndexAndUpdateTotalCredits(string deleteCourse)
        //{
        //    int index = -1;
        //    for (int i = 0; i < courses.Length; i++)
        //    {
        //        if (courses[i].Name == deleteCourse)
        //        {
        //            index = i;
        //            totalCredits -= courses[i].Credits;

        //            if (courses[i].Status == Status.PASSED)
        //            {
        //                totalCreditsCompleted -= courses[i].Credits;
        //            }
        //            break;
        //        }
        //    }

        //    if (index == -1)
        //        throw new Exception($"Course {deleteCourse} does not exist.");

        //    return index;
        //}

        private void addCourseToList(Course newCourse)
        {
            try
            {
                int addIndex = getAddIndexAndUpdateTotalCredits(newCourse);

                //If there are no elements in the array
                if (addIndex == 0 && courses.Count == 0)
                {
                    newCourse.PrecedingCourseName = null;
                    newCourse.FollowingCourseName = null;
                    courses += newCourse;
                }
                else                    //There are more than 1 elements in the array
                {
                    courses.Add(newCourse, addIndex);

                    courses.UpdatePropertiesAfterAdd(addIndex);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        //Delete and move elements to the left
        //private void deleteCourseFromArray(string deletionCourseName)
        //{
        //    try
        //    {
        //        int deleteIndex = getDeleteIndexAndUpdateTotalCredits(deletionCourseName);

        //        //Decerement counter
        //        coursesArraySize--;

        //        //If only 1 element in array then just clear the whole array to default
        //        if (coursesArraySize == 0 && deleteIndex == 0)
        //        {
        //            Array.Clear(courses, 0, courses.Length);
        //            ClearAllForm();
        //        }
        //        else            //More than 1 element in the array
        //        {
        //            //Move elements to the left to delete from deletIndex
        //            for (int i = deleteIndex; i < coursesArraySize; i++)
        //            {
        //                courses[i] = courses[i + 1];
        //            }

        //            //Update last element's following course to null
        //            courses[coursesArraySize].FollowingCourseName = null;

        //            //If first element deleted
        //            if (deleteIndex == 0)
        //            {
        //                courses[0].PrecedingCourseName = null;
        //            }
        //            //If element in middle was deleted
        //            else if (deleteIndex < coursesArraySize)
        //            {
        //                courses[deleteIndex - 1].FollowingCourseName = courses[deleteIndex].Name;
        //                courses[deleteIndex].PrecedingCourseName = courses[deleteIndex - 1].Name;
        //                courses[deleteIndex].FollowingCourseName = courses[deleteIndex + 1].Name;
        //            }

        //            //Make empty courses after counter to be null
        //            if (coursesArraySize > 0 && coursesArraySize < courses.Length - 1)
        //            {
        //                for (int i = coursesArraySize; i < courses.Length; i++)
        //                {
        //                    courses[i] = new Course(null);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Error");
        //    }
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDeleteCourse frmDeleteCourse = new frmDeleteCourse();
            string courseToDelete = frmDeleteCourse.GetDeletionCourseName(courses);

            if (!string.IsNullOrEmpty(courseToDelete))
            {

                int deleteIndex = -1;
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i].Name.Equals(courseToDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        deleteIndex = i;
                        break;
                    }
                }

                if (deleteIndex != -1)
                {
                    courses.Remove(deleteIndex);
                }
                else
                {
                    MessageBox.Show($"Course {courseToDelete} does not exist.", "Error");
                }
            }

            UpdateForm();
        }

        private void UpdateForm()
        {
            txtTotalCredits.Text = totalCredits.ToString();
            txtTotalCreditsCompleted.Text = totalCreditsCompleted.ToString();

            TextBox[] txtBoxes = { textBox1, textBox2, textBox3, textBox4, 
                textBox5, textBox6, textBox7, textBox8, textBox9};

            for(int i = 0; i < txtBoxes.Length; i++)
            {
                if (i < courses.Count)
                    txtBoxes[i].Text = courses[i].Name;
                else
                    txtBoxes[i].Text = "";
            }
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
    }
}
