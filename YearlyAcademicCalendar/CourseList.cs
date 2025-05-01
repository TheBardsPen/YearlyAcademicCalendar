using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YearlyAcademicCalendar
{
    public class CourseList
    {
        private List<Course> courses;

        public delegate void ChangeHandler(Course course, bool add);
        public event ChangeHandler Changed;

        public delegate void ClearHandler();
        public event ClearHandler Cleared;

        public CourseList() { courses = new List<Course>(); }

        public int Count => courses.Count;

        public void Add(Course course, int index)
        {
            courses.Insert(index, course);
            //Changed(course, true);
        }

        public void Clear()
        {
            courses.Clear();
            //Cleared();
        }

        public void Remove(Course course)
        {
            courses.Remove(course);
            //Changed(course, false);
        }

        public void Remove(int index)
        {
            Course deletedCourse = courses[index];
            courses.RemoveAt(index);

            //Changed(deletedCourse, false);
        }

        public Course this[int i]
        {
            get
            {
                if (i < 0 && i >= courses.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return courses[i];
            }

            set { courses[i] = value; }
        }

        public static CourseList operator +(CourseList courses, Course course)
        {
            int index = 0;
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name == course.PrecedingCourseName)
                {
                    index = i + 1;

                    break;
                }
            }
            courses.Add(course, index);
            return courses;
        }

        public static CourseList operator -(CourseList courses, Course course)
        {
            courses.Remove(course);
            return courses;
        }

        public void UpdatePropertiesAfterAdd(int index)
        {
            //Update the affected courses properties
            if (index == 0)                               //Newly added course is at the first element
            {
                var insertedCourse = courses[index];
                insertedCourse.PrecedingCourseName = null;
                courses[index] = insertedCourse;

                var secondCourse = courses[index + 1];
                secondCourse.PrecedingCourseName = courses[index].Name;
                courses[index + 1] = secondCourse;
            }
            else if (index > 0)                           //Newly added course is not at the first element
            {
                var previousCourse = courses[index - 1];
                previousCourse.FollowingCourseName = courses[index].Name;
                courses[index - 1] = previousCourse;

                var insertedCourse = courses[index];
                insertedCourse.PrecedingCourseName = courses[index - 1].Name;
                courses[index] = insertedCourse;
            }

            if (index < courses.Count - 1)                   //Newly added course is not at the end
            {
                var insertedCourse = courses[index];
                insertedCourse.FollowingCourseName = courses[index + 1].Name;
                courses[index] = insertedCourse;
            }
            else if (index == courses.Count - 1)             //Newly added course is the last element
            {
                var insertedCourse = courses[index];
                insertedCourse.FollowingCourseName = null;
                courses[index] = insertedCourse;
            }
        }
    }
}
