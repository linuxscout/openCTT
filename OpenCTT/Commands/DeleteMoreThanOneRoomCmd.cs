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
	/// Summary description for DeleteMoreThanOneRoomCmd.
	/// </summary>
	public class DeleteMoreThanOneRoomCmd:AbstractCommand
	{
		private ArrayList _roomList;
		private ArrayList [,] _undoRedoCoursesTeachersLists;

		public DeleteMoreThanOneRoomCmd(ArrayList roomList)
		{
			_roomList=roomList;			
		}
		
		public override void doit()
		{
			_undoRedoCoursesTeachersLists = new ArrayList[_roomList.Count,2];			

			int n=0;
			foreach(Room room in _roomList)
			{
				AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Remove(room);

                //for undo/redo
				ArrayList undoRedoCoursesList= new ArrayList();
				ArrayList undoRedoTeachersList= new ArrayList();
				_undoRedoCoursesTeachersLists[n,0]= undoRedoCoursesList;
                _undoRedoCoursesTeachersLists[n,1]= undoRedoTeachersList;

				foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
				{				
					foreach(EduProgram ep in epg.Nodes)
					{
						foreach(Course course in ep.Nodes)
						{
							if(course.getAllowedRoomsList()!=null)
							{
								if(course.getAllowedRoomsList().Contains(room))
								{
									course.getAllowedRoomsList().Remove(room);
									undoRedoCoursesList.Add(course);
								}
							}
						}
					}
				}

				foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes) 
				{
					if(teacher.getAllowedRoomsList()!=null)
					{
						if(teacher.getAllowedRoomsList().Contains(room))
						{
							teacher.getAllowedRoomsList().Remove(room);
							undoRedoTeachersList.Add(teacher);
						}
					}
				}

				n++;

			}
			
			AppForm.getAppForm().getRoomsTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.RoomsRootNode;
			AppForm.getAppForm().getRoomsTreeView().SelectedNode.EnsureVisible();
			
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;			
		}

		public override void undo()
		{
			int n=0;

			foreach(Room room in _roomList)
			{
				AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Add(room);
                
				ArrayList undoRedoCoursesList = _undoRedoCoursesTeachersLists[n,0];
				ArrayList undoRedoTeachersList= _undoRedoCoursesTeachersLists[n,1];

				foreach(Course course in undoRedoCoursesList)
				{
					course.getAllowedRoomsList().Add(room);
				}

				foreach(Teacher teacher in undoRedoTeachersList)
				{
					teacher.getAllowedRoomsList().Add(room);
				}

				n++;

			}
			
			AppForm.getAppForm().getRoomsTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.RoomsRootNode;
			AppForm.getAppForm().getRoomsTreeView().SelectedNode.EnsureVisible();
			AppForm.CURR_OCTT_DOC.RoomsRootNode.Expand();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
		}

		public override void redo()
		{
			doit();			
		}
	}
}
