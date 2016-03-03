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
	/// Summary description for TSPTeachersViewDragDropSuccessfullCmd.
	/// </summary>
	public class TSPTeachersViewDragDropSuccessfullCmd:AbstractCommand
	{		
		private Course _dragedCourse;
		private TimeSlotPanel _tsp;
		private ArrayList _lessonsInOneTimeSlot;
		private Object [] _courseAndRoomPair;
		
		private TreeNode _selectedNode;
		private int _indexRow;
		private int _indexCol;
		private ArrayList _forUndoRedoList;

		public TSPTeachersViewDragDropSuccessfullCmd(Course dragedCourse,TimeSlotPanel tsp,ArrayList lessonsInOneTimeSlot, Object [] courseAndRoomPair)
		{
			_dragedCourse=dragedCourse;
			_tsp=tsp;
			_lessonsInOneTimeSlot=lessonsInOneTimeSlot;
			_courseAndRoomPair=courseAndRoomPair;
			
			_indexRow=_tsp.getIndexRow();
			_indexCol=_tsp.getIndexCol();
			_selectedNode=AppForm.getAppForm().getTeachersTreeView().SelectedNode;			
		}

		public override void doit()
		{
			_forUndoRedoList= new ArrayList();

			_lessonsInOneTimeSlot.Remove(_courseAndRoomPair);	
			
			_forUndoRedoList.Add(_courseAndRoomPair);
			
			_tsp.Controls.Clear();
			_tsp.getAllSubLabels().Clear();
			
			_tsp.putLabelsOnThePanel();

			if(_dragedCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in _dragedCourse.getCoursesToHoldTogetherList())
				{
					EduProgram epHT = (EduProgram)courseHT.Parent;
					ArrayList [,] myttHT=epHT.getTimetable();
					ArrayList lessonsInOneTimeSlotHT=myttHT[_indexRow, _indexCol];
					if(lessonsInOneTimeSlotHT!=null)
					{
						Object[] courseAndRoomPairForDel=null;
						foreach(Object[] courseAndRoomPairHT in lessonsInOneTimeSlotHT)
						{								
							Course courseToCheck=(Course)courseAndRoomPairHT[0];
							if(courseToCheck==courseHT)
							{
								courseAndRoomPairForDel=courseAndRoomPairHT;
								break;
							}
						}
						if(courseAndRoomPairForDel!=null)
						{
							lessonsInOneTimeSlotHT.Remove(courseAndRoomPairForDel);
							
							_forUndoRedoList.Add(courseAndRoomPairForDel);
							
						}
					}
				}
			}
		}

		public override void undo()
		{
			foreach(Object [] oneItem in _forUndoRedoList)
			{
				Course course=(Course)oneItem[0];

				EduProgram thisEP=(EduProgram)course.Parent;
				ArrayList [,] mytt=thisEP.getTimetable();				
				ArrayList lessonsInOneTimeSlot;
				if(mytt[_indexRow,_indexCol]==null) 
				{
					lessonsInOneTimeSlot = new ArrayList();                
				}
				else
				{
					lessonsInOneTimeSlot=mytt[_indexRow,_indexCol];
				}

				lessonsInOneTimeSlot.Add(oneItem);
				mytt[_indexRow,_indexCol]=lessonsInOneTimeSlot;
				
			}
		}

		public override void redo()
		{
			foreach(Object [] oneItem in _forUndoRedoList)
			{
				Course course=(Course)oneItem[0];

				EduProgram thisEP=(EduProgram)course.Parent;
				ArrayList [,] mytt=thisEP.getTimetable();			
				ArrayList lessonsInOneTimeSlot=mytt[_indexRow,_indexCol];
				lessonsInOneTimeSlot.Remove(oneItem);
				mytt[_indexRow,_indexCol]=lessonsInOneTimeSlot;
				
			}
		
			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=1)
			{
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			}
			
			AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=_selectedNode;
			AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);

			AppForm.getAppForm().ttvRefreshTimetablePanel(_selectedNode,false);
		}
	}
}
