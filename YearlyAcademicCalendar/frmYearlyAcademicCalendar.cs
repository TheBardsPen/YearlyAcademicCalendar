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
        
        //private Course[] courses = new Course[MAX_NUMBER_OF_COURSES];
        private int totalCredits = 0;
        private int totalCreditsCompleted = 0;
        //private int coursesArraySize = 0;        //A counter that stores the real size of the array

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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (coursesArraySize == MAX_NUMBER_OF_COURSES)
            {
                MessageBox.Show($"The academic plan is full. Please delete courses to add new ones.", "Plan Full Error");
            }
            else
            {
                frmAddCourse addCourseForm = new frmAddCourse();
                Course newCourse = addCourseForm.GetNewCourse();

                addCourseToArray(newCourse);
            }

            UpdateForm();
        }

        private int getAddIndexAndUpdateTotalCredits(Course addCourse)
        {
            int index = 0;
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i].Name == addCourse.PrecedingCourseName)
                {
                    index = i + 1;

                    break;
                }
            }

            foreach(Course c in courses)
            {
                if(c.Name == addCourse.Name)
                    throw new Exception($"Course {addCourse.Name} already exists.");
            }

            totalCredits += addCourse.Credits;

            if (addCourse.Status == Status.PASSED)
            {
                totalCreditsCompleted += addCourse.Credits;
            }

            return index;
        }

        private int getDeleteIndexAndUpdateTotalCredits(string deleteCourse)
        {
            int index = -1;
            for (int i = 0; i < courses.Length; i++)
            {
                if (courses[i].Name == deleteCourse)
                {
                    index = i;
                    totalCredits -= courses[i].Credits;

                    if (courses[i].Status == Status.PASSED)
                    {
                        totalCreditsCompleted -= courses[i].Credits;
                    }
                    break;
                }
            }

            if (index == -1)
                throw new Exception($"Course {deleteCourse} does not exist.");

            return index;
        }

        //Make space for adding and add course
        private void addCourseToArray(Course addCourse)
        {
            try
            {
                int addIndex = getAddIndexAndUpdateTotalCredits(addCourse);

                //If there are no elements in the array
                if (addIndex == 0 && coursesArraySize == 0)
                {
                    addCourse.PrecedingCourseName = null;
                    addCourse.FollowingCourseName = null;
                    courses[0] = addCourse;
                }
                else                    //There are more than 1 elements in the array
                {
                    //Move elemetns from addIndex to the right to make a new space
                    for (int i = coursesArraySize; i > addIndex; i--)
                    {
                        courses[i] = courses[i - 1];
                    }

                    //Add the new course
                    courses[addIndex] = addCourse;

                    //Update the affected courses properties
                    if (addIndex == 0)                               //Newly added course is at the first element
                    {
                        courses[addIndex].PrecedingCourseName = null;
                        courses[addIndex + 1].PrecedingCourseName = courses[addIndex].Name;
                    }
                    else if (addIndex > 0)                           //Newly added course is not at the first element
                    {
                        courses[addIndex - 1].FollowingCourseName = addCourse.Name;
                        courses[addIndex].PrecedingCourseName = courses[addIndex - 1].Name;
                    }

                    if (addIndex < courses.Length - 1)                   //Newly added course is not at the end
                    {
                        courses[addIndex].FollowingCourseName = courses[addIndex + 1].Name;
                    }
                    else if (addIndex == coursesArraySize)             //Newly added course is the last element
                    {
                        courses[coursesArraySize].FollowingCourseName = null;
                    }

                    //Make remaining empty elements null
                    if (coursesArraySize <= 1)
                    {
                        for (int i = coursesArraySize + 1; i < courses.Length; i++)
                        {
                            courses[i] = new Course(null);
                        }
                    }
                }

                //Increment the size of the array
                coursesArraySize++;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        //Delete and move elements to the left
        private void deleteCourseFromArray(string deletionCourseName)
        {
            try
            {
                int deleteIndex = getDeleteIndexAndUpdateTotalCredits(deletionCourseName);

                //Decerement counter
                coursesArraySize--;

                //If only 1 element in array then just clear the whole array to default
                if (coursesArraySize == 0 && deleteIndex == 0)
                {
                    Array.Clear(courses, 0, courses.Length);
                    ClearAllForm();
                }
                else            //More than 1 element in the array
                {
                    //Move elements to the left to delete from deletIndex
                    for (int i = deleteIndex; i < coursesArraySize; i++)
                    {
                        courses[i] = courses[i + 1];
                    }

                    //Update last element's following course to null
                    courses[coursesArraySize].FollowingCourseName = null;

                    //If first element deleted
                    if (deleteIndex == 0)
                    {
                        courses[0].PrecedingCourseName = null;
                    }
                    //If element in middle was deleted
                    else if (deleteIndex < coursesArraySize)
                    {
                        courses[deleteIndex - 1].FollowingCourseName = courses[deleteIndex].Name;
                        courses[deleteIndex].PrecedingCourseName = courses[deleteIndex - 1].Name;
                        courses[deleteIndex].FollowingCourseName = courses[deleteIndex + 1].Name;
                    }

                    //Make empty courses after counter to be null
                    if (coursesArraySize > 0 && coursesArraySize < courses.Length - 1)
                    {
                        for (int i = coursesArraySize; i < courses.Length; i++)
                        {
                            courses[i] = new Course(null);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (coursesArraySize == 0)
            {
                MessageBox.Show($"The academic plan is empty. Please add courses.", "Plan Empty Error");
            }
            else
            {
                frmDeleteCourse deleteCourseForm = new frmDeleteCourse();
                string deleteCourse = deleteCourseForm.GetDeletionCourseName();

                deleteCourseFromArray(deleteCourse);
            }

            UpdateForm();
        }

        private void UpdateForm()
        {
            txtTotalCredits.Text = totalCredits.ToString();
            txtTotalCreditsCompleted.Text = totalCreditsCompleted.ToString();

            TextBox[] txtBoxes = { textBox1, textBox2, textBox3, textBox4, 
                textBox5, textBox6, textBox7, textBox8, textBox9};

            for(int i = 0; i < coursesArraySize; i++)
            {
                txtBoxes[i].Text = courses[i].Name;
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            string msg = "";
            for (int i = 0; i < coursesArraySize; i++)
            {
                msg += courses[i].ToString();
            }

            MessageBox.Show(msg, "Academic Plan");
        }
    }
}
