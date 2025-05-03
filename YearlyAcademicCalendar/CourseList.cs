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
            Changed?.Invoke(course, true); // Notify that a course was added
        }

        public void Clear()
        {
            courses.Clear();
        }

        public void Remove(Course course)
        {
            Course deletedCourse = course;
            courses.Remove(course);

            Changed?.Invoke(deletedCourse, false);// Notify that a course was removed
        }

        public void Remove(int index)
        {
            Course deletedCourse = courses[index];
            courses.RemoveAt(index);

            Changed?.Invoke(deletedCourse, false);// Notify that a course was removed
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

        /// This operator overload is used to add a course to the list
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

        /// This operator overload is used to remove a course from the list
        public static CourseList operator -(CourseList courses, Course course)
        {
            courses.Remove(course);
            return courses;
        }

        public void UpdateAfterChange()
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
    }
}
