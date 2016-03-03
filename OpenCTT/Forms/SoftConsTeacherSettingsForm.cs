using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCTT
{
    public partial class SoftConsTeacherSettingsForm : Form
    {
        Teacher _teacher;

        int x1Start, x2Start, x3Start;
        bool x1CheckStart, x2CheckStart, x3CheckStart;

        public SoftConsTeacherSettingsForm(Teacher teacher)
        {
            _teacher = teacher;            

            InitializeComponent();
        }

        private void SoftConsTeacherSettingsForm_Load(object sender, EventArgs e)
        {
            if (_teacher.SCMaxHoursContinously != -1)
            {
                _maxHContinuouslyTextBox.Text = _teacher.SCMaxHoursContinously.ToString();
                _overrideMaxHoursContCheckBox.Checked = true;
                _maxHContinuouslyTextBox.ReadOnly = false;

                x1Start = _teacher.SCMaxHoursContinously;
                x1CheckStart = true;

            }
            else
            {
                _maxHContinuouslyTextBox.Text = SCBaseSettings.TEACHER_MAX_HOURS_CONTINUOUSLY.ToString();
                _overrideMaxHoursContCheckBox.Checked = false;
                _maxHContinuouslyTextBox.ReadOnly = true;

                x1Start = SCBaseSettings.TEACHER_MAX_HOURS_CONTINUOUSLY;
                x1CheckStart = false;
            }


            if (_teacher.SCMaxHoursDaily != -1)
            {
                _maxHDailyTextBox.Text = _teacher.SCMaxHoursDaily.ToString();
                _overrideMaxHoursDailyCheckBox.Checked = true;
                _maxHDailyTextBox.ReadOnly = false;

                x2Start = _teacher.SCMaxHoursDaily;
                x2CheckStart = true;

            }
            else
            {
                _maxHDailyTextBox.Text = SCBaseSettings.TEACHER_MAX_HOURS_DAILY.ToString();
                _overrideMaxHoursDailyCheckBox.Checked = false;
                _maxHDailyTextBox.ReadOnly = true;

                x2Start = SCBaseSettings.TEACHER_MAX_HOURS_DAILY;
                x2CheckStart = false;
            }

            //
            if (_teacher.SCMaxDaysPerWeek != -1)
            {
                _maxDaysPerWeekTextBox.Text = _teacher.SCMaxDaysPerWeek.ToString();
                _overrideMaxDaysPerWeekCheckBox.Checked = true;
                _maxDaysPerWeekTextBox.ReadOnly = false;

                x3Start = _teacher.SCMaxDaysPerWeek;
                x3CheckStart = true;

            }
            else
            {
                _maxDaysPerWeekTextBox.Text = SCBaseSettings.TEACHER_MAX_DAYS_PER_WEEK.ToString();
                _overrideMaxDaysPerWeekCheckBox.Checked = false;
                _maxDaysPerWeekTextBox.ReadOnly = true;

                x3Start = SCBaseSettings.TEACHER_MAX_DAYS_PER_WEEK;
                x3CheckStart = false;
            }            

            _okButton.Enabled = false;

        }

        private void _overrideMaxHoursContCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                _maxHContinuouslyTextBox.ReadOnly = false;

            }
            else
            {
                _maxHContinuouslyTextBox.ReadOnly = true;
                _maxHContinuouslyTextBox.Text = SCBaseSettings.TEACHER_MAX_HOURS_CONTINUOUSLY.ToString();
            }

            checkValAndChanges();
        }

        private void _overrideMaxHoursDailyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                _maxHDailyTextBox.ReadOnly = false;

            }
            else
            {
                _maxHDailyTextBox.ReadOnly = true;
                _maxHDailyTextBox.Text = SCBaseSettings.TEACHER_MAX_HOURS_DAILY.ToString();
            }

            checkValAndChanges();
        }

        private void _overrideMaxDaysPerWeekCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                _maxDaysPerWeekTextBox.ReadOnly = false;

            }
            else
            {
                _maxDaysPerWeekTextBox.ReadOnly = true;
                _maxDaysPerWeekTextBox.Text = SCBaseSettings.TEACHER_MAX_DAYS_PER_WEEK.ToString();
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
                bool x1Check = _overrideMaxHoursContCheckBox.Checked;
                bool x2Check = _overrideMaxHoursDailyCheckBox.Checked;
                bool x3Check = _overrideMaxDaysPerWeekCheckBox.Checked;

                int x1 = Int32.Parse(_maxHContinuouslyTextBox.Text);
                int x2 = Int32.Parse(_maxHDailyTextBox.Text);
                int x3 = Int32.Parse(_maxDaysPerWeekTextBox.Text);

                if (x1 > 0 && x2 > 0 && x3 > 0)
                {
                    if (x1 != x1Start || x1Check != x1CheckStart || x2 != x2Start || x2Check != x2CheckStart || x3 != x3Start || x3Check != x3CheckStart)
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


        public int SCMaxHoursContinouslyNewVal
        {
            get
            {
                if (_overrideMaxHoursContCheckBox.Checked)
                {
                    return System.Convert.ToInt32(_maxHContinuouslyTextBox.Text);

                }
                else
                {
                    return -1;
                }

            }
        }


        public int SCMaxHoursDailyNewVal
        {
            get
            {
                if (_overrideMaxHoursDailyCheckBox.Checked)
                {
                    return System.Convert.ToInt32(_maxHDailyTextBox.Text);

                }
                else
                {
                    return -1;
                }

            }
        }

        public int SCMaxDaysPerWeekNewVal
        {
            get
            {
                if (_overrideMaxDaysPerWeekCheckBox.Checked)
                {
                    return System.Convert.ToInt32(_maxDaysPerWeekTextBox.Text);

                }
                else
                {
                    return -1;
                }

            }
        }
    }
}