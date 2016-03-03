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
	/// Summary description for ULLVCoursesDragDropCmd.
	/// </summary>
	public class ULLVCoursesDragDropCmd:AbstractCommand
	{
		ListViewItem _lviDroped;
		ListView _ullv;

		private TreeNode _selectedNode;

		public ULLVCoursesDragDropCmd(ListViewItem lviDroped, ListView ullv)
		{
			_lviDroped=lviDroped;
			_ullv=ullv;

			_selectedNode=AppForm.getAppForm().getCoursesTreeView().SelectedNode;
		}

		public override void doit()
		{
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);
			Course course = (Course)_lviDroped.Tag;
			Teacher myTeacher = course.getTeacher();
			EduProgram ep = (EduProgram)course.Parent;

			string [] courseTeacher = new string[2];			
			courseTeacher[0]=course.getFullName();
			courseTeacher[1]=myTeacher.getLastName()+" "+myTeacher.getName();

			ListViewItem lviNew=new ListViewItem(courseTeacher);
			lviNew.Tag=course;

			_ullv.Items.Add(lviNew);
			_ullv.EnsureVisible(_ullv.Items.IndexOf(lviNew));
			
			ep.getUnallocatedLessonsList().Add(lviNew);

			if(course.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in course.getCoursesToHoldTogetherList())
				{
					EduProgram epHT = (EduProgram)courseHT.Parent;
					Teacher myTeacherHT = courseHT.getTeacher();
					ListViewItem lviNewHT=new ListViewItem();
					lviNewHT.Tag=courseHT;

					epHT.getUnallocatedLessonsList().Add(lviNewHT);

				}
			}

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
		}

		public override void undo()
		{
			_ullv.Items.Remove(_lviDroped);
			Course dropedCourse=(Course)_lviDroped.Tag;
			EduProgram ep=(EduProgram)dropedCourse.Parent;

			ep.removeOneLessonFromUnallocatedLessonsModel(dropedCourse);
			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);
			
			if(dropedCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in dropedCourse.getCoursesToHoldTogetherList())
				{
					EduProgram epHT=(EduProgram)courseHT.Parent;
					epHT.removeOneLessonFromUnallocatedLessonsModel(courseHT);					
				}
			}			

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

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

		public override void redo()
		{
			doit();
		}
	}
}
