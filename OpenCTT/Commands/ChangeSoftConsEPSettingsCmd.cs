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
    public class ChangeSoftConsEPSettingsCmd : AbstractCommand
    {
        EduProgram _ep;

        int _newMaxHContinuously;
        int _newMaxHDaily;
        int _newMaxDaysPerWeek;
        int _newGapIndicator;
        int _newPreferredStartTimePeriod;

        int _oldMaxHContinuously;
        int _oldMaxHDaily;
        int _oldMaxDaysPerWeek;
        int _oldGapIndicator;
        int _oldPreferredStartTimePeriod;


        public ChangeSoftConsEPSettingsCmd(EduProgram ep, int newMaxHContinuously, int newMaxHDaily, int newMaxDaysPerWeek, int newGapIndicator, int newPreferredStartTimePeriod)
        {
            _ep = ep;

            _newMaxHContinuously = newMaxHContinuously;
            _newMaxHDaily = newMaxHDaily;
            _newMaxDaysPerWeek = newMaxDaysPerWeek;
            _newGapIndicator = newGapIndicator;
            _newPreferredStartTimePeriod = newPreferredStartTimePeriod;

            _oldMaxHContinuously = _ep.SCStudentMaxHoursContinuously;
            _oldMaxHDaily = _ep.SCStudentMaxHoursDaily;
            _oldMaxDaysPerWeek = _ep.SCStudentMaxDaysPerWeek;
            _oldGapIndicator = _ep.SCStudentNoGapsGapIndicator;
            _oldPreferredStartTimePeriod = _ep.SCStudentPreferredStartTimePeriod;
        }

        public override void doit()
        {
            _ep.SCStudentMaxHoursContinuously = _newMaxHContinuously;
            _ep.SCStudentMaxHoursDaily = _newMaxHDaily;
            _ep.SCStudentMaxDaysPerWeek = _newMaxDaysPerWeek;
            _ep.SCStudentNoGapsGapIndicator = _newGapIndicator;
            _ep.SCStudentPreferredStartTimePeriod = _newPreferredStartTimePeriod;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 0;
            AppForm.getAppForm().getCoursesTreeView().SelectedNode = _ep;

        }

        public override void undo()
        {
            _ep.SCStudentMaxHoursContinuously = _oldMaxHContinuously;
            _ep.SCStudentMaxHoursDaily = _oldMaxHDaily;
            _ep.SCStudentMaxDaysPerWeek = _oldMaxDaysPerWeek;
            _ep.SCStudentNoGapsGapIndicator = _oldGapIndicator;
            _ep.SCStudentPreferredStartTimePeriod = _oldPreferredStartTimePeriod;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 0;
            AppForm.getAppForm().getCoursesTreeView().SelectedNode = _ep;

        }

        public override void redo()
        {
            doit();
        }

    }
}
