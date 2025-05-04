using System;
using System.Windows.Forms;

namespace YearlyAcademicCalendar
{
    /// <summary>
    /// Class <c>Validation</c> contains methods that check for various types of user input to prevent errors.
    /// </summary>
    public static class Validation
    {
        private static string requiredInt = " should be a valid integer value.";
        private static string requiredIntRange = " should be a valid integer value between ";
        private static string requiredDecimal = " should be a valid decimal value.";
        private static string requiredDecimalRange = " should be a valid decimal value between ";
        private static string requiredString = " is a required field.";
        private static string requiredComboField = " is a required field. Please make a selection.";

        #region Text Box

        /// <summary>
        /// Used to verify a textbox is not empty.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <returns>True if textbox is not empty, false and an error message if it is empty.</returns>
        public static bool IsTextboxString(string name, TextBox box)
        {
            if (box.Text == "")
            {
                MessageBox.Show(name + requiredString, "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to verify if a textbox can be converted to an integer.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <returns>True if textbox can be converted to an integer, false and an error message if not.</returns>
        public static bool IsTextboxInt(string name, TextBox box)
        {
            if (!int.TryParse(box.Text, out _))
            {
                MessageBox.Show(name + requiredInt, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to verify if a textbox can be converted to an integer and is in a specified range.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <param name="floor">The minimum value</param>
        /// <param name="cieling">The maximum value</param>
        /// <returns>True if textbox can be converted to an integer, false and an error message if not.</returns>
        public static bool IsTextboxInt(string name, TextBox box, int floor, int cieling)
        {
            if (!int.TryParse(box.Text, out _) || Convert.ToInt32(box.Text) < floor || Convert.ToInt32(box.Text) > cieling)
            {
                MessageBox.Show(name + requiredIntRange + $"{floor} and {cieling}.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to verify if a textbox can be converted to a decimal.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <returns>True if textbox can be converted to an decimal, false and an error message if not.</returns>
        public static bool IsTextboxDecimal(string name, TextBox box, bool checkRange)
        {
            if (!Decimal.TryParse(box.Text, out _))
            {
                MessageBox.Show(name + requiredDecimal, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Used to verify if a textbox can be converted to a decimal and is in a specified range.
        /// </summary>
        /// <param name="name">The name of the text field</param>
        /// <param name="box">The textbox that is selected</param>
        /// <param name="floor">The minimum value</param>
        /// <param name="cieling">The maximum value</param>
        /// <returns>True if textbox can be converted to an integer, false and an error message if not.</returns>
        public static bool IsTextboxDecimal(string name, TextBox box, decimal floor, decimal cieling)
        {
            if (!Decimal.TryParse(box.Text, out _) || Convert.ToDecimal(box.Text) < floor || Convert.ToDecimal(box.Text) > cieling)
            {
                MessageBox.Show(name + requiredDecimalRange + $"{floor} and {cieling}.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Combo Box

        /// <summary>
        /// Used to verify if a non-typeable dropdown has a selected value.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="box"></param>
        /// <returns>True if drowpdown has been selected, false and an error message if it is left unselected.</returns>
        public static bool IsComboSelected(string name, ComboBox box)
        {
            if (box.SelectedItem == null)
            {
                MessageBox.Show(name + requiredComboField, "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                box.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
}