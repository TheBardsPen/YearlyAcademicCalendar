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

        public frmDeleteCourse()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                currCourse = txtCourseName.Text;
            }
            this.Close();
        }

        public string GetDeletionCourseName()
        {
            this.ShowDialog();
            return currCourse;
        }

        private bool ValidateData()
        {
            bool success = true;
            string msg = "";

            msg += Validator.IsPresent(txtCourseName.Text, lblCourseName.Tag.ToString());

            if (msg != "")
            {
                success = false;
                MessageBox.Show(msg, "Entry Error");
            }
            return success;
        }
    }
}
