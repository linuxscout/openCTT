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
	/// Summary description for DeleteRoomCmd.
	/// </summary>
	public class DeleteRoomCmd:AbstractCommand
	{
		private Room _room;
		private ArrayList _undoRedoCoursesList;
        private ArrayList _undoRedoTeachersList;

		public DeleteRoomCmd(Room room)
		{
			_room=room;			
			_undoRedoCoursesList= new ArrayList();
			_undoRedoTeachersList= new ArrayList();
		}

		public override void doit()
		{
			_undoRedoCoursesList.Clear();
			_undoRedoTeachersList.Clear();

			AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Remove(_room);
			AppForm.getAppForm().getRoomsTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.RoomsRootNode;
			AppForm.getAppForm().getRoomsTreeView().SelectedNode.EnsureVisible();
			
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
			
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{				
				foreach(EduProgram ep in epg.Nodes)
				{
					foreach(Course course in ep.Nodes)
					{
						if(course.getAllowedRoomsList()!=null)
						{
							if(course.getAllowedRoomsList().Contains(_room))
							{
								course.getAllowedRoomsList().Remove(_room);
								_undoRedoCoursesList.Add(course);
							}
						}
					}
				}
			}

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes) 
			{
				if(teacher.getAllowedRoomsList()!=null)
				{
					if(teacher.getAllowedRoomsList().Contains(_room))
					{
						teacher.getAllowedRoomsList().Remove(_room);
						_undoRedoTeachersList.Add(teacher);
					}
				}
			}




		}

		public override void undo()
		{
			AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Add(_room);
			AppForm.getAppForm().getRoomsTreeView().SelectedNode=_room;
			AppForm.getAppForm().getRoomsTreeView().SelectedNode.EnsureVisible();
			AppForm.CURR_OCTT_DOC.RoomsRootNode.Expand();

			foreach(Course course in _undoRedoCoursesList)
			{
				course.getAllowedRoomsList().Add(_room);
			}

			foreach(Teacher teacher in _undoRedoTeachersList)
			{
				teacher.getAllowedRoomsList().Add(_room);
			}   

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
		}

		public override void redo()
		{
			doit();			
		}
	}
}
