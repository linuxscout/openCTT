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
using System.Windows.Forms;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for SetAllowedRoomsCmd.
	/// </summary>
	public class SetAllowedRoomsCmd:AbstractCommand
	{
		private Course _course;
        private Teacher _teacher;
		private ArrayList _oldAllowedRoomsList;
		private ArrayList _newAllowedRoomsList;
        
		public SetAllowedRoomsCmd(Course course,Teacher teacher, ArrayList newList)
		{
			_course=course;
			_teacher=teacher;
            _newAllowedRoomsList=newList;

			_oldAllowedRoomsList=new ArrayList();
			if(_course!=null)//course
			{
				if(_course.getAllowedRoomsList()!=null)
				{
					foreach(Room roomEd in _course.getAllowedRoomsList())
					{
                        _oldAllowedRoomsList.Add(roomEd);
					}
				}
				else
				{
					_oldAllowedRoomsList=null;                    
				}

			}
			else//teacher
			{
				if(_teacher.getAllowedRoomsList()!=null)
				{
					foreach(Room roomEd in _teacher.getAllowedRoomsList())
					{
						_oldAllowedRoomsList.Add(roomEd);
					}
				}
				else
				{
					_oldAllowedRoomsList=null;                    
				}

			}
			

		}

		public override void doit()
		{			
			if(_course!=null)
			{
				_course.setAllowedRoomsList(_newAllowedRoomsList);
				
			}
			else
			{
				_teacher.setAllowedRoomsList(_newAllowedRoomsList);                
			}
		}

		public override void undo()
		{
			if(_course!=null)
			{
				_course.setAllowedRoomsList(_oldAllowedRoomsList);

                AppForm.getAppForm().getCoursesTreeView().SelectedNode=_course;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			}
			else
			{
				_teacher.setAllowedRoomsList(_oldAllowedRoomsList);
				AppForm.getAppForm().getTeachersTreeView().SelectedNode=_teacher;				
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
			}
			
		}

		public override void redo()
		{
			doit();

			if(_course!=null)
			{
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=_course;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;				
			}
			else
			{
				AppForm.getAppForm().getTeachersTreeView().SelectedNode=_teacher;
                AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;                
			}
		}
	}
}
