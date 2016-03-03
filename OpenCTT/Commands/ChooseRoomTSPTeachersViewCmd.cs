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
using System.Windows.Forms;
using System.Collections;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for ChooseRoomTSPCoursesViewCmd.
	/// </summary>
	public class ChooseRoomTSPTeachersViewCmd:AbstractCommand
	{
		Object [] _courseAndRoomPair;
		private Course _course;
		private Room _oldRoom;
		private Room _newRoom;
		private Label _roomLabel;
		private int _indexRow;
		private int _indexCol;	
	
		private TreeNode _selectedNode;
		
		public ChooseRoomTSPTeachersViewCmd(Object [] courseAndRoomPair,Course course, Room oldRoom,Room newRoom, Label roomLabel,int indexRow, int indexCol)
		{
			_courseAndRoomPair=courseAndRoomPair;
			_course=course;
			_oldRoom=oldRoom;
			_newRoom=newRoom;
			_roomLabel=roomLabel;
			_indexRow=indexRow;
			_indexCol=indexCol;
	
			_selectedNode=AppForm.getAppForm().getTeachersTreeView().SelectedNode;
		}

		public override void doit()
		{
			_roomLabel.Text=_newRoom.getName();
			_roomLabel.Tag=_newRoom;
			_courseAndRoomPair[1]=_newRoom;
			
			if(_course.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in _course.getCoursesToHoldTogetherList())
				{						
					EduProgram epHT=(EduProgram)courseHT.Parent;
					ArrayList [,] myttHT = epHT.getTimetable();
					ArrayList lessonsInOneTimeSlotHT = myttHT[_indexRow,_indexCol];
					foreach(Object [] courseAndRoomPairHT in lessonsInOneTimeSlotHT)
					{							
						Course courseFromModelHT=(Course)courseAndRoomPairHT[0];
						if(courseFromModelHT==courseHT)
						{								
							courseAndRoomPairHT[1]=_newRoom;
							break;
						}
					}
				}
			}
		}

		public override void undo()
		{
			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=1)
			{
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			}
			
			AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=_selectedNode;
			AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
						
			_courseAndRoomPair[1]=_oldRoom;

			if(_course.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in _course.getCoursesToHoldTogetherList())
				{						
					EduProgram epHT=(EduProgram)courseHT.Parent;
					ArrayList [,] myttHT = epHT.getTimetable();
					ArrayList lessonsInOneTimeSlotHT = myttHT[_indexRow,_indexCol];
					foreach(Object [] courseAndRoomPairHT in lessonsInOneTimeSlotHT)
					{							
						Course courseFromModelHT=(Course)courseAndRoomPairHT[0];
						if(courseFromModelHT==courseHT)
						{								
							courseAndRoomPairHT[1]=_oldRoom;
							break;
						}
					}
				}
			}
			
			AppForm.getAppForm().ttvRefreshTimetablePanel(_selectedNode,false);


		}

		public override void redo()
		{
			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=1)
			{
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			}
			
			AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=_selectedNode;
			AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
						
			_courseAndRoomPair[1]=_newRoom;
			
			if(_course.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in _course.getCoursesToHoldTogetherList())
				{						
					EduProgram epHT=(EduProgram)courseHT.Parent;
					ArrayList [,] myttHT = epHT.getTimetable();
					ArrayList lessonsInOneTimeSlotHT = myttHT[_indexRow,_indexCol];
					foreach(Object [] courseAndRoomPairHT in lessonsInOneTimeSlotHT)
					{							
						Course courseFromModelHT=(Course)courseAndRoomPairHT[0];
						if(courseFromModelHT==courseHT)
						{								
							courseAndRoomPairHT[1]=_newRoom;
							break;
						}
					}
				}
			}

			AppForm.getAppForm().ttvRefreshTimetablePanel(_selectedNode,false);

		}

	}
}
