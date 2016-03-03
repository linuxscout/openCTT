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
	/// Summary description for ClearTimetableCmd.
	/// </summary>
	public class ClearTimetableCmd:AbstractCommand
	{
		EduProgram _ep;
		
		ArrayList _epAndLviForUndoRedoList;

		int _numOfUnallocatedLessonsUndoRedoCounter;

		public ClearTimetableCmd(EduProgram ep)
		{
			_ep=ep;
		}

		public override void doit()
		{
			_numOfUnallocatedLessonsUndoRedoCounter=0;			
			_epAndLviForUndoRedoList=new ArrayList();

			ArrayList [,] mytt = _ep.getTimetable();
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					ArrayList lessonsInOneTimeSlot = mytt[j,k];
					if(lessonsInOneTimeSlot!=null)
					{
						for(int step=0;step<lessonsInOneTimeSlot.Count;)
						{
							IEnumerator enumerator=lessonsInOneTimeSlot.GetEnumerator();
							enumerator.MoveNext();
							Object [] courseAndRoomPair=(Object [])enumerator.Current;								
							Course course = (Course)courseAndRoomPair[0];
							lessonsInOneTimeSlot.Remove(courseAndRoomPair);

							AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);	
							_numOfUnallocatedLessonsUndoRedoCounter++;
							
							ListViewItem lvi = new ListViewItem();
							lvi.Tag=course;
							_ep.getUnallocatedLessonsList().Add(lvi);

							//prepare for redo
                            Object [] onePair=new Object[4];
							onePair[0]=_ep;
							onePair[1]=lvi;
							onePair[2]=lessonsInOneTimeSlot;
							onePair[3]=courseAndRoomPair;

							_epAndLviForUndoRedoList.Add(onePair);
                            							

							if(course.getCoursesToHoldTogetherList().Count>0)
							{
								foreach(Course courseHT in course.getCoursesToHoldTogetherList())
								{
									EduProgram epHT = (EduProgram)courseHT.Parent;
									ArrayList [,] myttHT = epHT.getTimetable();
									ArrayList lessonsInOneTimeSlotHT = myttHT[j,k];
									IEnumerator enumeratorIP=lessonsInOneTimeSlotHT.GetEnumerator();
									foreach(Object [] courseAndRoomPairHT in lessonsInOneTimeSlotHT)
									{
										enumeratorIP.MoveNext();											
										Course courseFromListHT = (Course)courseAndRoomPairHT[0];
										if(courseFromListHT==courseHT)
										{
											break;
										}
									}									
									
									Object [] courseAndRoomPairHTForDel=(Object [])enumeratorIP.Current;
									lessonsInOneTimeSlotHT.Remove(courseAndRoomPairHTForDel);								
									
									ListViewItem lviNew=new ListViewItem();

									lviNew.Tag=courseHT;
									epHT.getUnallocatedLessonsList().Add(lviNew);

									//prepare for redo
									Object [] onePairIP=new Object[4];
									onePairIP[0]=epHT;
									onePairIP[1]=lviNew;
									onePairIP[2]=lessonsInOneTimeSlotHT;
									onePairIP[3]=courseAndRoomPairHTForDel;
									_epAndLviForUndoRedoList.Add(onePairIP);
									

								}
							}

						}
					}
				}
			}

			
			foreach(TimeSlotPanel tsp in AppForm.getAppForm().getMainTimetablePanel().Controls)
			{
				tsp.Controls.Clear();
				tsp.getAllSubLabels().Clear();
				tsp.putLabelsOnThePanel();

				AppForm.getAppForm().getUnallocatedLessonsListView().BeginUpdate();
				AppForm.getAppForm().getUnallocatedLessonsListView().Items.Clear();

				foreach(ListViewItem lvi in _ep.getUnallocatedLessonsList()) 
				{
					Course courseTag = (Course)lvi.Tag;
					Teacher teacher=courseTag.getTeacher();
					string [] courseAndTeacher= new string[2];
					courseAndTeacher[0]=courseTag.getFullName();
					courseAndTeacher[1]=teacher.getLastName()+" "+teacher.getName();
					ListViewItem newLvi= new ListViewItem(courseAndTeacher);
					newLvi.Tag=courseTag;
					AppForm.getAppForm().getUnallocatedLessonsListView().Items.Add(newLvi);
				}

				AppForm.getAppForm().getUnallocatedLessonsListView().EndUpdate();

			}

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

		}

		public override void undo()
		{			

			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(_numOfUnallocatedLessonsUndoRedoCounter);

			foreach(Object [] onePair in _epAndLviForUndoRedoList)
			{
				EduProgram ep = (EduProgram)onePair[0];
				ListViewItem lvi = (ListViewItem)onePair[1];
				ArrayList lessonsInOneTimeSlot=(ArrayList)onePair[2];				
				Object [] courseAndRoomPair=(Object [])onePair[3];

				ep.getUnallocatedLessonsList().Remove(lvi);
				lessonsInOneTimeSlot.Add(courseAndRoomPair);
			}
						
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_ep;

			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=0)
			{				
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			}
			else
			{				
				AppForm.getAppForm().updateTimeSlotPanel(1,_ep,false);
				
				AppForm.getAppForm().getUnallocatedLessonsListView().BeginUpdate();
				AppForm.getAppForm().getUnallocatedLessonsListView().Items.Clear();				

				foreach(ListViewItem lvi in _ep.getUnallocatedLessonsList())
				{
					Course courseTag = (Course)lvi.Tag;
					string [] courseAndTeacher= new string[2];
					courseAndTeacher[0]=courseTag.getFullName();
												
					string teacherStr=courseTag.getTeacher().getLastName()+" "+courseTag.getTeacher().getName();
					courseAndTeacher[1]=teacherStr;
					ListViewItem newLvi= new ListViewItem(courseAndTeacher);
					newLvi.Tag=courseTag;
					AppForm.getAppForm().getUnallocatedLessonsListView().Items.Add(newLvi);
				}
				AppForm.getAppForm().getUnallocatedLessonsListView().EndUpdate();
			}

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
			
		}

		public override void redo()
		{
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_ep;
			if(AppForm.getAppForm().getTreeTabControl().SelectedIndex!=0)
			{				
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;

			}
			doit();			
		}
	}
}
