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
	/// Summary description for SetCoursesToHoldTogetherCmd.
	/// </summary>
	public class SetCoursesToHoldTogetherCmd:AbstractCommand
	{
		private Course _course;
		private ArrayList _newCoursesToHoldTogetherList;

		private ArrayList _forUndoRedoList;

		private int _incrUnallocatedLessons;
		private int _decrUnallocatedLessons;

		public SetCoursesToHoldTogetherCmd(Course course,ArrayList newCoursesToHoldTogetherList)
		{
			_course=course;
			_newCoursesToHoldTogetherList=newCoursesToHoldTogetherList;

			_incrUnallocatedLessons=_course.getNumberOfLessonsPerWeek()*_course.getCoursesToHoldTogetherList().Count;
			_decrUnallocatedLessons=_course.getNumberOfLessonsPerWeek()*_newCoursesToHoldTogetherList.Count;

		}

		public override void doit()
		{			
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(_incrUnallocatedLessons);
			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(_decrUnallocatedLessons);
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
		
			_forUndoRedoList = new ArrayList();

			foreach(Course oldCourse in _course.getCoursesToHoldTogetherList())
			{
                ArrayList oldList=(ArrayList)oldCourse.getCoursesToHoldTogetherList().Clone();
                ArrayList newList = new ArrayList();
				Object [] oneItem= new Object[3];
				oneItem[0]=oldCourse;
                oneItem[1]=oldList;
                oneItem[2]=newList;
				_forUndoRedoList.Add(oneItem);
				
				oldCourse.setCoursesToHoldTogetherList(new ArrayList());
			}
			
			ArrayList oldList2=(ArrayList)_course.getCoursesToHoldTogetherList().Clone();
			ArrayList newList2 = (ArrayList)_newCoursesToHoldTogetherList.Clone();
			Object [] oneItem2= new Object[3];
			oneItem2[0]=_course;
			oneItem2[1]=oldList2;
			oneItem2[2]=newList2;
			_forUndoRedoList.Add(oneItem2);
			
			_course.setCoursesToHoldTogetherList(_newCoursesToHoldTogetherList);
			//
			foreach(Course courseFromList in _course.getCoursesToHoldTogetherList())
			{
				foreach(Course deepCourse in courseFromList.getCoursesToHoldTogetherList())
				{
					ArrayList oldList3=(ArrayList)deepCourse.getCoursesToHoldTogetherList().Clone();
					ArrayList newList3 = new ArrayList();
					Object [] oneItem3= new Object[3];
					oneItem3[0]=deepCourse;
					oneItem3[1]=oldList3;
					oneItem3[2]=newList3;
					_forUndoRedoList.Add(oneItem3);
					
					deepCourse.setCoursesToHoldTogetherList(new ArrayList());
				}

				ArrayList thisCourseList = new ArrayList();
				thisCourseList.Add(_course);

				foreach(Course courseInList22 in _course.getCoursesToHoldTogetherList())
				{
					if(courseInList22!=courseFromList)thisCourseList.Add(courseInList22);
				}

				ArrayList oldList4=(ArrayList)courseFromList.getCoursesToHoldTogetherList().Clone();
				ArrayList newList4 = (ArrayList)thisCourseList.Clone();
				Object [] oneItem4= new Object[3];
				oneItem4[0]=courseFromList;
				oneItem4[1]=oldList4;
				oneItem4[2]=newList4;
				_forUndoRedoList.Add(oneItem4);
				
				courseFromList.setCoursesToHoldTogetherList(thisCourseList);
			}
		}

		public override void undo()
		{			
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(_decrUnallocatedLessons);
			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(_incrUnallocatedLessons);
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
		
			int count=_forUndoRedoList.Count;

			for(int n=0;n<count;n++)
			{
				Object [] oneItem = (Object [])_forUndoRedoList[count-1-n];
				
				Course course=(Course)oneItem[0];				
				ArrayList oldList = (ArrayList)oneItem[1];
				course.setCoursesToHoldTogetherList(oldList);
			}

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_course;
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
		}

		public override void redo()
		{			
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(_incrUnallocatedLessons);
			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(_decrUnallocatedLessons);
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
		
			foreach(Object [] oneItem in _forUndoRedoList)
			{
				Course course=(Course)oneItem[0];
				ArrayList newList = (ArrayList)oneItem[2];
				course.setCoursesToHoldTogetherList(newList);
			}

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_course;
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
		}
		
	}
}
