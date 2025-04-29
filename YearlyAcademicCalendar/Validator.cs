using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YearlyAcademicCalendar
{
    public static class Validator
    {
        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg += name + " is a required field.\n";
            }
            return msg;
        }

        public static string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg += name + " must be a valid int value.\n";
            }
            return msg;
        }

        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a valid decimal value.\n";
            }
            return msg;
        }

        public static string IsCourseCreditsValid(string value, string name)
        {
            string msg = "";
            msg += IsPresent(value, name);
            msg += IsInt32(value, name);

            int credits = int.Parse(value);
            if (credits < 1 || credits > 5)
                msg += "Credits should be between 1 and 5.";

            return msg;
        }

        public static string IsStatusValid(string value, string name)
        {
            string msg = "";
            msg += IsPresent(value, name);

            if (!Enum.IsDefined(typeof(Status), value.ToUpper()))
            {
                msg += "Must be NotStarted, InProgress, Passed, or Failed";
            }

            return msg;
        }
    }
}
