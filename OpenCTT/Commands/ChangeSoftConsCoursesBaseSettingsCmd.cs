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
using System.Collections;


namespace OpenCTT
{
    /// <summary>
    /// Summary description for ChangeTeacherDataCmd.
    /// </summary>
    public class ChangeSoftConsCoursesBaseSettingsCmd : AbstractCommand
    {
        Hashtable _newHT;
        Hashtable _oldHT;
        
        public ChangeSoftConsCoursesBaseSettingsCmd(Hashtable ht)
        {
            _newHT = ht;
            _oldHT = SCBaseSettings.COURSE_LESSON_BLOCKS;            
        }

        public override void doit()
        {
            SCBaseSettings.COURSE_LESSON_BLOCKS = _newHT;                        
            
            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 0;
            AppForm.getAppForm().getCoursesTreeView().SelectedNode = AppForm.getAppForm().getCoursesTreeView().Nodes[0];

        }

        public override void undo()
        {
            SCBaseSettings.COURSE_LESSON_BLOCKS = _oldHT;

            AppForm.getAppForm().getTreeTabControl().SelectedIndex = 0;
            AppForm.getAppForm().getCoursesTreeView().SelectedNode = AppForm.getAppForm().getCoursesTreeView().Nodes[0];

        }

        public override void redo()
        {
            doit();
        }       

    }
}
