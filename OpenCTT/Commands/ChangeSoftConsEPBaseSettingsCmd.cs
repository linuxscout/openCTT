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

namespace OpenCTT
{
    /// <summary>
    /// Summary description for ChangeTeacherDataCmd.
    /// </summary>
    public class ChangeSoftConsEPBaseSettingsCmd : AbstractCommand
    {
        int _newMaxHContinuously;
        int _newMaxHDaily;
        int _newMaxDaysPerWeek;
        int _newNoGapsGapIndicator;
        int _newPreferredStartTimePeriod;

        int _oldMaxHContinuously;
        int _oldMaxHDaily;
        int _oldMaxDaysPerWeek;
        int _oldNoGapsGapIndicator;
        int _oldPreferredStartTimePeriod;

        public ChangeSoftConsEPBaseSettingsCmd(int newMaxHContinuously, int newMaxHDaily, int newMaxDaysPerWeek, int newNoGapsGapIndicator, int preferredStartTimePeriod)
        {
            _newMaxHContinuously = newMaxHContinuously;
            _newMaxHDaily = newMaxHDaily;
            _newMaxDaysPerWeek = newMaxDaysPerWeek;
            _newNoGapsGapIndicator = newNoGapsGapIndicator;
            _newPreferredStartTimePeriod = preferredStartTimePeriod;

            _oldMaxHContinuously = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY;
            _oldMaxHDaily = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY;
            _oldMaxDaysPerWeek = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK;
            _oldNoGapsGapIndicator = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR;
            _oldPreferredStartTimePeriod = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD;
        }

        public override void doit()
        {
            SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY = _newMaxHContinuously;
            SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY = _newMaxHDaily;
            SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK = _newMaxDaysPerWeek;
            SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR = _newNoGapsGapIndicator;
            SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD = _newPreferredStartTimePeriod;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 0;
            AppForm.getAppForm().getCoursesTreeView().SelectedNode = AppForm.getAppForm().getCoursesTreeView().Nodes[0];

        }

        public override void undo()
        {
            SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY = _oldMaxHContinuously;
            SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY = _oldMaxHDaily;
            SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK = _oldMaxDaysPerWeek;
            SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR = _oldNoGapsGapIndicator;
            SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD = _oldPreferredStartTimePeriod;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 0;
            AppForm.getAppForm().getCoursesTreeView().SelectedNode = AppForm.getAppForm().getCoursesTreeView().Nodes[0];

        }

        public override void redo()
        {
            doit();
        }

    }
}
