using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCTT
{
    public partial class SoftConsEPSettingsForm : Form
    {
        EduProgram _ep;

        int x1Start, x2Start, x3Start, x4Start, x5Start;
        bool x1CheckStart, x2CheckStart, x3CheckStart, x4CheckStart, x5CheckStart;

        public SoftConsEPSettingsForm(EduProgram ep)
        {
            _ep = ep;

            InitializeComponent();
        }

        private void SoftConsEPSettingsForm_Load(object sender, EventArgs e)
        {

            this.Text = AppForm.getAppForm()._scEduProgramMenuItem.Text;

            //1
            if (_ep.SCStudentMaxHoursContinuously != -1)
            {
                _maxHContinuouslyTextBox.Text = _ep.SCStudentMaxHoursContinuously.ToString();
                _overrideMaxHoursContCheckBox.Checked = true;
                _maxHContinuouslyTextBox.ReadOnly = false;

                x1Start = _ep.SCStudentMaxHoursContinuously;
                x1CheckStart = true;

            }
            else
            {
                _maxHContinuouslyTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY.ToString();
                _overrideMaxHoursContCheckBox.Checked = false;
                _maxHContinuouslyTextBox.ReadOnly = true;

                x1Start = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY;
                x1CheckStart = false;
            }

            //2

            if (_ep.SCStudentMaxHoursDaily != -1)
            {
                _maxHDailyTextBox.Text = _ep.SCStudentMaxHoursDaily.ToString();
                _overrideMaxHoursDailyCheckBox.Checked = true;
                _maxHDailyTextBox.ReadOnly = false;

                x2Start = _ep.SCStudentMaxHoursDaily;
                x2CheckStart = true;

            }
            else
            {
                _maxHDailyTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY.ToString();
                _overrideMaxHoursDailyCheckBox.Checked = false;
                _maxHDailyTextBox.ReadOnly = true;

                x2Start = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY;
                x2CheckStart = false;
            }

            //3
            if (_ep.SCStudentMaxDaysPerWeek != -1)
            {
                _maxDaysPerWeekTextBox.Text = _ep.SCStudentMaxDaysPerWeek.ToString();
                _overrideMaxDaysPerWeekCheckBox.Checked = true;
                _maxDaysPerWeekTextBox.ReadOnly = false;

                x3Start = _ep.SCStudentMaxDaysPerWeek;
                x3CheckStart = true;

            }
            else
            {
                _maxDaysPerWeekTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK.ToString();
                _overrideMaxDaysPerWeekCheckBox.Checked = false;
                _maxDaysPerWeekTextBox.ReadOnly = true;

                x3Start = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK;
                x3CheckStart = false;
            }
            //4

            if (_ep.SCStudentNoGapsGapIndicator != -1)
            {
                _gapIndicatorTextBox.Text = _ep.SCStudentNoGapsGapIndicator.ToString();
                _overrideGapIndicatorCheckBox.Checked = true;
                _gapIndicatorTextBox.ReadOnly = false;

                x4Start = _ep.SCStudentNoGapsGapIndicator;
                x4CheckStart = true;

            }
            else
            {
                _gapIndicatorTextBox.Text = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR.ToString();
                _overrideGapIndicatorCheckBox.Checked = false;
                _gapIndicatorTextBox.ReadOnly = true;

                x4Start = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR;
                x4CheckStart = false;
            }

            //5

            if (_ep.SCStudentPreferredStartTimePeriod != -1)
            {
                _preferredStartTPTextBox.Text = _ep.SCStudentPreferredStartTimePeriod.ToString();
                _overridePreferredStartTPCheckBox.Checked = true;
                _preferredStartTPTextBox.ReadOnly = false;

                x5Start = _ep.SCStudentPreferredStartTimePeriod;
                x5CheckStart = true;

            }
            else
            {
                _preferredStartTPTextBox.Text = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD.ToString();
                _overridePreferredStartTPCheckBox.Checked = false;
                _preferredStartTPTextBox.ReadOnly = true;

                x5Start = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD;
                x5CheckStart = false;
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
                _maxHContinuouslyTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY.ToString();
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
                _maxHDailyTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY.ToString();
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
                _maxDaysPerWeekTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK.ToString();
            }

            checkValAndChanges();

        }

        private void _overrideGapIndicatorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                _gapIndicatorTextBox.ReadOnly = false;

            }
            else
            {
                _gapIndicatorTextBox.ReadOnly = true;
                _gapIndicatorTextBox.Text = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR.ToString();
            }

            checkValAndChanges();
        }

        private void _overridePreferredStartTPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                _preferredStartTPTextBox.ReadOnly = false;

            }
            else
            {
                _preferredStartTPTextBox.ReadOnly = true;
                _preferredStartTPTextBox.Text = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD.ToString();
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
                bool x4Check = _overrideGapIndicatorCheckBox.Checked;
                bool x5Check = _overridePreferredStartTPCheckBox.Checked;

                int x1 = Int32.Parse(_maxHContinuouslyTextBox.Text);
                int x2 = Int32.Parse(_maxHDailyTextBox.Text);
                int x3 = Int32.Parse(_maxDaysPerWeekTextBox.Text);
                int x4 = Int32.Parse(_gapIndicatorTextBox.Text);
                int x5 = Int32.Parse(_preferredStartTPTextBox.Text);                

                if (x1 > 0 && x2 > 0 && x3 > 0 && x4 > 0 && x5>0)
                {
                    if (x1 != x1Start || x1Check != x1CheckStart || x2 != x2Start || x2Check != x2CheckStart || x3 != x3Start || x3Check != x3CheckStart || x4 != x4Start || x4Check != x4CheckStart || x5 != x5Start || x5Check != x5CheckStart)
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


        public int SCGapIndicatorNewVal
        {
            get
            {
                if (_overrideGapIndicatorCheckBox.Checked)
                {
                    return System.Convert.ToInt32(_gapIndicatorTextBox.Text);

                }
                else
                {
                    return -1;
                }

            }
        }


        public int SCPreferredStartTimePeriod
        {
            get
            {
                if (_overridePreferredStartTPCheckBox.Checked)
                {
                    return System.Convert.ToInt32(_preferredStartTPTextBox.Text);
                }
                else
                {
                    return -1;
                }

            }
        }

        
    }
}