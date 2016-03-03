#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan Æurak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan Æurak, Split, Croatia
//
// http://www.openctt.org
//
//This file is part of Open Course Timetabler.
//
//Open Course Timetabler is free software;
//you can redistribute it and/or modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2 of the License,
//or (at your option) any later version.
//
//Open Course Timetabler is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
//or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with
//Open Course Timetabler; if not, write to the Free Software Foundation, Inc., 51 Franklin St,
//Fifth Floor, Boston, MA  02110-1301  USA

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OpenCTT
{
    public partial class SoftConsEPBaseSettingsForm : Form
    {
        public SoftConsEPBaseSettingsForm()
        {
            InitializeComponent();
        }

        private void SoftConsEPBaseSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = AppForm.getAppForm()._scBaseEPMenuItem.Text;

            _maxHContinuouslyTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY.ToString();
            _maxHDailyTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY.ToString();
            _maxDaysPerWeekTextBox.Text = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK.ToString();
            _gapIndicatorTextBox.Text = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR.ToString();
            _preferredStartTPTextBox.Text = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD.ToString();

            _okButton.Enabled = false;
        }

        private void allTextBoxs_TextChanged(object sender, EventArgs e)
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
                int x1 = Int32.Parse(_maxHContinuouslyTextBox.Text);
                int x2 = Int32.Parse(_maxHDailyTextBox.Text);
                int x3 = Int32.Parse(_maxDaysPerWeekTextBox.Text);
                int x4 = Int32.Parse(_gapIndicatorTextBox.Text);
                int x5 = Int32.Parse(_preferredStartTPTextBox.Text);

                if (x1 > 0 && x2 > 0 && x3 > 0 && x4>0 && x5>0)
                {
                    if (x1 != SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY || x2 != SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY || x3 != SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK || x4 != SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR || x5 != SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD)
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


        public int MaxHContinuously
        {
            get
            {
                return System.Convert.ToInt32(_maxHContinuouslyTextBox.Text);
            }
        }

        public int MaxHDaily
        {
            get
            {
                return System.Convert.ToInt32(_maxHDailyTextBox.Text);
            }
        }

        public int MaxDaysPerWeek
        {
            get
            {
                return System.Convert.ToInt32(_maxDaysPerWeekTextBox.Text);
            }
        }

        public int NoGapsGapIndicator
        {
            get
            {
                return System.Convert.ToInt32(_gapIndicatorTextBox.Text);
            }
        }

        public int PreferredStartTimePeriod
        {
            get
            {
                return System.Convert.ToInt32(_preferredStartTPTextBox.Text);
            }
        }


    }
}