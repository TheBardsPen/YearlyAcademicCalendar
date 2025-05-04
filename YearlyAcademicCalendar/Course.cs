namespace YearlyAcademicCalendar
{
    public struct Course
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public Status Status { get; set; }
        public string PrecedingCourseName { get; set; }
        public string FollowingCourseName { get; set; }

        public Course(string courseName)
        {
            if (courseName == null || courseName == "")
            {
                this.Name = null;
                this.Credits = 0;
                this.Status = Status.NOTSTARTED;
                this.PrecedingCourseName = null;
                this.FollowingCourseName = null;
            }
            else
            {
                this.Name = courseName;
                this.Credits = 0;
                this.Status = Status.NOTSTARTED;
                this.PrecedingCourseName = null;
                this.FollowingCourseName = null;
            }
        }

        public override string ToString()
        {
            string msg = "";
            if (Name == null)
            {
                msg += "null";
            }
            else
            {
                msg += Name;
            }
            msg += "|Credits: " + Credits.ToString() + "|Status: " + Status.ToString();

            if (PrecedingCourseName == null)
            {
                msg += "|Preceding Course: null";
            }
            else
            {
                msg += "|Preceding Course: " + PrecedingCourseName;
            }

            if (FollowingCourseName == null)
            {
                msg += "|Following Course: null";
            }
            else
            {
                msg += "|Following Course: " + FollowingCourseName;
            }

            msg += "\n";

            return msg;
        }
    }
}