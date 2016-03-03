using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCTT
{    

    public partial class SoftConsCourseSettingsForm : Form
    {
        private Course _myCourse;

        int x1Start, x2Start, x3Start;
        bool xCheckStart;

        public SoftConsCourseSettingsForm(Course course)
        {
            _myCourse = course;

            InitializeComponent();
        }

        private void SoftConsCourseSettingsForm_Load(object sender, EventArgs e)
        {
            string lessCountString;
            int lessCount = _myCourse.getNumberOfLessonsPerWeek();
            if (lessCount < 10)
            {
                lessCountString = _myCourse.getNumberOfLessonsPerWeek().ToString();
            }
            else
            {
                lessCountString = "default";
            }            

            int[] lb = _myCourse.SCLessonBlocksParameters;

            if (lb != null)
            {
                _d1TextBox.Text = lb[0].ToString();
                _d2TextBox.Text = lb[1].ToString();
                _d3TextBox.Text = lb[2].ToString();

                _obsCheckBox.Checked = true;
                xCheckStart = true;
            }
            else
            {
                int[] cc2 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS[lessCountString];
                _d1TextBox.Text = cc2[0].ToString();
                _d2TextBox.Text = cc2[1].ToString();
                _d3TextBox.Text = cc2[2].ToString();

                _obsCheckBox.Checked = false;
                xCheckStart = false;

                _d1TextBox.ReadOnly = true;
                _d2TextBox.ReadOnly = true;
                _d3TextBox.ReadOnly = true;
            }

            _okButton.Enabled = false;

            this.Text = AppForm.getAppForm()._scCourseMenuItem.Text;

            x1Start = Int32.Parse(_d1TextBox.Text);
            x2Start = Int32.Parse(_d2TextBox.Text);
            x3Start = Int32.Parse(_d3TextBox.Text);
        }


        //////////
        private void _obsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                _d1TextBox.ReadOnly = false;
                _d2TextBox.ReadOnly = false;
                _d3TextBox.ReadOnly = false;

            }
            else
            {
                _d1TextBox.ReadOnly = true;
                _d2TextBox.ReadOnly = true;
                _d3TextBox.ReadOnly = true;

                string lessCountString;
                int lessCount = _myCourse.getNumberOfLessonsPerWeek();
                if (lessCount < 10)
                {
                    lessCountString = _myCourse.getNumberOfLessonsPerWeek().ToString();
                }
                else
                {
                    lessCountString = "default";
                }      
                
                int[] cc2 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS[lessCountString];
                _d1TextBox.Text = cc2[0].ToString();
                _d2TextBox.Text = cc2[1].ToString();
                _d3TextBox.Text = cc2[2].ToString();
            }

            checkValAndChanges();

        }

        private void allTextBoxs_TextChanged(object sender, EventArgs e)
        {
            checkValAndChanges();
        }

        private void checkValAndChanges()
        {
            if (isFormValuesOKAndChanged())
            {
                _okButton.Enabled = true;

            }
            else
            {

                _okButton.Enabled = false;
            }
        }

        private bool isFormValuesOKAndChanged()
        {
            try
            {
                bool xCheck = _obsCheckBox.Checked;

                int x1 = Int32.Parse(_d1TextBox.Text);
                int x2 = Int32.Parse(_d2TextBox.Text);
                int x3 = Int32.Parse(_d3TextBox.Text);

                if (x1 > 0 && x2 > 0 && x3 > 0)
                {
                    if (xCheck != xCheckStart || x1 != x1Start || x2 != x2Start || x3 != x3Start)
                    {
                        return true;
                    }
                    else return false;

                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }

            return true;

        }


        public int[] SCCourseLessonBlocksNewVal
        {
            get
            {
                if (_obsCheckBox.Checked)
                {
                    int x1 = Int32.Parse(_d1TextBox.Text);
                    int x2 = Int32.Parse(_d2TextBox.Text);
                    int x3 = Int32.Parse(_d3TextBox.Text);
                    int[] newValCLB = new int[3] {x1,x2,x3 };

                    return newValCLB;
                }
                else
                {
                    return null;
                }

            }
        }
    }
}