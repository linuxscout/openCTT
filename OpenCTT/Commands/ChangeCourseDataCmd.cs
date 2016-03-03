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

namespace OpenCTT
{
	/// <summary>
	/// Summary description for ChangeCourseDataCmd.
	/// </summary>
	public class ChangeCourseDataCmd:AbstractCommand
	{
		Course _course;
		EduProgram _ep;

		string _oldName;
		string _oldShortName;
		string _oldGroupName;
		int _oldNumOfLessonsPerWeek;
		int _oldNumOfEnrolledStudents;
		bool _oldIsGroup;
		Teacher _oldTeacher;
		string _oldExtID;
		string _oldCourseType;

		string _newName;
		string _newShortName;
		string _newGroupName;
		int _newNumOfLessonsPerWeek;
		int _newNumOfEnrolledStudents;
		bool _newIsGroup;
		Teacher _newTeacher;
		string _newExtID;
		string _newCourseType;


		public ChangeCourseDataCmd(Course course,string newName,string newShortName,string newGroupName,int newNumOfLessonsPerWeek,int newNumOfEnrolledStudents,bool newIsGroup,Teacher newTeacher,string newExtID, string newCourseType)
		{
			_course=course;
			_ep=(EduProgram)_course.Parent;

			_oldName=_course.getName();
			_oldShortName=_course.getShortName();
			_oldGroupName=_course.getGroupName();
			_oldNumOfLessonsPerWeek=_course.getNumberOfLessonsPerWeek();
			_oldNumOfEnrolledStudents=_course.getNumberOfEnrolledStudents();
			_oldIsGroup=_course.getIsGroup();
			_oldTeacher=_course.getTeacher();
			_oldExtID=_course.ExtID;
			_oldCourseType=_course.CourseType;

			_newName=newName;
			_newShortName=newShortName;
			_newGroupName=newGroupName;
			_newNumOfLessonsPerWeek=newNumOfLessonsPerWeek;
			_newNumOfEnrolledStudents=newNumOfEnrolledStudents;
			_newIsGroup=newIsGroup;
			_newTeacher=newTeacher;
			_newExtID=newExtID;
			_newCourseType=newCourseType;
		}

		public override void doit()
		{			
			_course.setNumberOfLessonsPerWeek(_newNumOfLessonsPerWeek);
			_course.setNumberOfEnrolledStudents(_newNumOfEnrolledStudents);
			_course.setIsGroup(_newIsGroup);
			_course.setGroupName(_newGroupName);
			_course.setShortName(_newShortName);
			_course.setTeacher(_newTeacher);
			_course.ExtID=_newExtID;
			_course.CourseType=_newCourseType;

			if(_newCourseType!=_oldCourseType)
			{
				updateTSPLabels();

				if(!AppForm.CURR_OCTT_DOC.CourseTypesList.Contains(_newCourseType))
				{
					AppForm.CURR_OCTT_DOC.CourseTypesList.Add(_newCourseType);
					AppForm.CURR_OCTT_DOC.CourseTypesList.Sort();
				}

				if(HardConstraintChecks.checkIfCourseTypeIsFreeForDelete(_course))
				{
					AppForm.CURR_OCTT_DOC.CourseTypesList.Remove(_oldCourseType);
				}
			}
			
			
			if(_oldName!=_newName || _oldCourseType!=_newCourseType)
			{
				_course.setName(_newName);
				updateTSPLabels();				
			}
			
			//update of existing lessons in ListView
			updateListViewText();
			
			int diff;
			if(_oldNumOfLessonsPerWeek>_newNumOfLessonsPerWeek)
			{				
				diff=_oldNumOfLessonsPerWeek-_newNumOfLessonsPerWeek;
				for(int n=0;n<diff;n++)
				{
					_ep.removeOneLessonFromUnallocatedLessonsModelAndListView(_course,AppForm.getAppForm().getUnallocatedLessonsListView());
					AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);					
				}
			}
			else if (_newNumOfLessonsPerWeek>_oldNumOfLessonsPerWeek)
			{						
				//we have to add lessons					
				diff = _newNumOfLessonsPerWeek-_oldNumOfLessonsPerWeek;
				for(int k=0;k<diff;k++)
				{
					string [] courseTeacher = new string[2];
					courseTeacher[0]=_course.getFullName();							
					courseTeacher[1]=_course.getTeacher().getLastName()+" "+_course.getTeacher().getName();

					ListViewItem lvi=new ListViewItem(courseTeacher);
					lvi.Tag=_course;
					lvi.EnsureVisible();
					AppForm.getAppForm().getUnallocatedLessonsListView().Items.Add(lvi);

					ListViewItem lvi2=(ListViewItem)lvi.Clone();					
					_ep.getUnallocatedLessonsList().Add(lvi2);
					AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);		
				}
						
			}
			
			_course.setTreeText();
			sortIt();			
		}

		public override void undo()
		{
			_course.setNumberOfLessonsPerWeek(_oldNumOfLessonsPerWeek);
			_course.setNumberOfEnrolledStudents(_oldNumOfEnrolledStudents);
			_course.setIsGroup(_oldIsGroup);
			_course.setGroupName(_oldGroupName);
			_course.setShortName(_oldShortName);
			_course.setTeacher(_oldTeacher);
			_course.ExtID=_oldExtID;
			_course.CourseType=_oldCourseType;

			if(_newCourseType!=_oldCourseType)
			{
				updateTSPLabels();

				if(!AppForm.CURR_OCTT_DOC.CourseTypesList.Contains(_oldCourseType))
				{
					AppForm.CURR_OCTT_DOC.CourseTypesList.Add(_oldCourseType);
					AppForm.CURR_OCTT_DOC.CourseTypesList.Sort();
				}

				if(HardConstraintChecks.checkIfCourseTypeIsFreeForDelete(_course))
				{
					AppForm.CURR_OCTT_DOC.CourseTypesList.Remove(_newCourseType);
				}
			}

			
			if(_oldName!=_newName  || _oldCourseType!=_newCourseType)
			{
				_course.setName(_oldName);
				updateTSPLabels();	
			}

			//update of existing lessons in ListView
			updateListViewText();

			int diff;
			if(_newNumOfLessonsPerWeek>_oldNumOfLessonsPerWeek)
			{
				//delete lessons
				diff=_newNumOfLessonsPerWeek-_oldNumOfLessonsPerWeek;
				for(int n=0;n<diff;n++)
				{
					_ep.removeOneLessonFromUnallocatedLessonsModelAndListView(_course,AppForm.getAppForm().getUnallocatedLessonsListView());
					AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);					
				}
			}
			else if (_oldNumOfLessonsPerWeek>_newNumOfLessonsPerWeek)
			{						
				//add lessons				
				diff = _oldNumOfLessonsPerWeek-_newNumOfLessonsPerWeek;
				for(int k=0;k<diff;k++)
				{
					string [] courseTeacher = new string[2];
					courseTeacher[0]=_course.getFullName();							
					courseTeacher[1]=_course.getTeacher().getLastName()+" "+_course.getTeacher().getName();

					ListViewItem lvi=new ListViewItem(courseTeacher);
					lvi.Tag=_course;
					lvi.EnsureVisible();
					AppForm.getAppForm().getUnallocatedLessonsListView().Items.Add(lvi);

					ListViewItem lvi2=(ListViewItem)lvi.Clone();					
					_ep.getUnallocatedLessonsList().Add(lvi2);
					AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);		
				}
						
			}
            
			_course.setTreeText();
			sortIt();
		}

		public override void redo()
		{
			doit();
		}

		private void updateTSPLabels()
		{			
			foreach(TimeSlotPanel tsp in AppForm.getAppForm().getMainTimetablePanel().Controls)
			{
				foreach(Label[] oneSubLabel in tsp.getAllSubLabels())
				{
					Label courseLabel=oneSubLabel[0];
					Course thisCourse = (Course)courseLabel.Tag;
					if(thisCourse==_course)
					{
						courseLabel.Text=_course.getFullName();
					}
				}
			}		

		}

		private void updateListViewText()
		{			
			foreach(ListViewItem upLvi in AppForm.getAppForm().getUnallocatedLessonsListView().Items)
			{
				Course upCourse=(Course)upLvi.Tag;
				if(upCourse==_course)
				{
					ListViewItem.ListViewSubItem upLvsi1=upLvi.SubItems[0];
					upLvsi1.Text=_course.getFullName();
					ListViewItem.ListViewSubItem upLvsi2=upLvi.SubItems[1];
					upLvsi2.Text=_course.getTeacher().getLastName()+" "+_course.getTeacher().getName();
				}
			}
		}

		private void sortIt()
		{			
			AppForm.getAppForm().getCoursesTreeView().BeginUpdate();
			_ep.Nodes.Remove(_course);
			_ep.Nodes.Add(_course);
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_course;
			AppForm.getAppForm().getCoursesTreeView().EndUpdate();
				
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
		}

	}
}
