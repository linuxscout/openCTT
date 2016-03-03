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
	/// Summary description for TSPCoursesViewDragDropSuccessfullCmd.
	/// </summary>
	public class TSPCoursesViewDragDropSuccessfullCmd:AbstractCommand
	{
		private Course _dragedCourse;
		private TimeSlotPanel _tsp;
		private int _subIndex;

		private TreeNode _selectedNode;
		private int _indexRow;
		private int _indexCol;
		private ArrayList _forUndoRedoList;

		public TSPCoursesViewDragDropSuccessfullCmd(Course dragedCourse, TimeSlotPanel tsp, int subIndex)
		{
			_dragedCourse=dragedCourse;
			_tsp=tsp;
			_subIndex=subIndex;

			_indexRow=_tsp.getIndexRow();
			_indexCol=_tsp.getIndexCol();
			_selectedNode=AppForm.getAppForm().getCoursesTreeView().SelectedNode;
		}

		public override void doit()
		{			
			_forUndoRedoList= new ArrayList();

			EduProgram ep = (EduProgram)_dragedCourse.Parent;
			ArrayList [,] mytt = ep.getTimetable();
			ArrayList lessonsInOneTimeSlot = mytt[_tsp.getIndexRow(),_tsp.getIndexCol()];			
			IEnumerator enumModel=lessonsInOneTimeSlot.GetEnumerator();			
				
			IEnumerator enumGUI =_tsp.getAllSubLabels().GetEnumerator();
			for(int n=0;n<=_subIndex;n++) 
			{
				enumModel.MoveNext();
				enumGUI.MoveNext();
			}

			Object [] courseAndRoomPair=(Object [])enumModel.Current;
			lessonsInOneTimeSlot.Remove(courseAndRoomPair);
			
			_forUndoRedoList.Add(courseAndRoomPair);
			
				
			Label[] oneSubLabel = (Label [])enumGUI.Current;
			Label courseLabel = oneSubLabel[0];
			Label roomLabel = oneSubLabel[1];
			_tsp.getAllSubLabels().Remove(oneSubLabel);

			courseLabel.Parent=null;
			roomLabel.Parent=null;

			_tsp.putLabelsOnThePanel();

			if(_dragedCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in _dragedCourse.getCoursesToHoldTogetherList())
				{
					EduProgram epHT = (EduProgram)courseHT.Parent;
					ArrayList [,] myttHT=epHT.getTimetable();
					ArrayList lessonsInOneTimeSlotHT=myttHT[_tsp.getIndexRow(),_tsp.getIndexCol()];
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
		
			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=0)
			{
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
				AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			}
			
			AppForm.getAppForm().getCoursesTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_selectedNode;
			AppForm.getAppForm().getCoursesTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);

			AppForm.getAppForm().ctvRefreshTimetablePanel(_selectedNode,false,true);
		}
	}
}
