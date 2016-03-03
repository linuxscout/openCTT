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
	/// Summary description for DeleteCourseCmd.
	/// </summary>
	public class DeleteCourseCmd:AbstractCommand
	{
		private Course _course;
		private EduProgram _ep;

		public DeleteCourseCmd(Course course)
		{
			_course=course;
			_ep = (EduProgram)_course.Parent;
		}

		public override void doit()
		{
			_ep.removeCourseFromUnallocatedLessonsModelAndView(_course,AppForm.getAppForm().getUnallocatedLessonsListView());
			_ep.Nodes.Remove(_course);
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_ep;
			AppForm.getAppForm().getCoursesTreeView().SelectedNode.EnsureVisible();
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
		}

		public override void undo()
		{
			_ep.Nodes.Add(_course);
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_course;
			_ep.Expand();
			AppForm.getAppForm().getCoursesTreeView().SelectedNode.EnsureVisible();
			
			foreach(Course course in _course.getCoursesToHoldTogetherList())
			{
				course.getCoursesToHoldTogetherList().Add(_course);
			}
			
			for(int k=0;k<_course.getNumberOfLessonsPerWeek();k++) 
			{
				if(_course.getCoursesToHoldTogetherList().Count==0)
				{
					AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);
				}
				
				ListViewItem lvi=new ListViewItem();
				lvi.Tag=_course;
				_ep.getUnallocatedLessonsList().Add(lvi);	
				
				string [] courseTeacher = new string[2];
				courseTeacher[0]=_course.getFullName();					
				courseTeacher[1]=_course.getTeacher().getLastName()+" "+_course.getTeacher().getName();

				ListViewItem lviGUI=new ListViewItem(courseTeacher);
				lviGUI.Tag=_course;					
				lvi.EnsureVisible();

				AppForm.getAppForm().getUnallocatedLessonsListView().Items.Add(lviGUI);
				
			}			
			
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;			
			
		}

		public override void redo()
		{
			doit();			
		}
	}
}
