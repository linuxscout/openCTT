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
	/// Summary description for ULLVTeachersDragDropCmd.
	/// </summary>
	public class ULLVTeachersDragDropCmd:AbstractCommand
	{
		ListViewItem _lviDroped;
		ListView _ullv;

		private TreeNode _selectedNode;

		public ULLVTeachersDragDropCmd(ListViewItem lviDroped, ListView ullv)
		{
			_lviDroped=lviDroped;
			_ullv=ullv;

			_selectedNode=AppForm.getAppForm().getTeachersTreeView().SelectedNode;
		}

		public override void doit()
		{
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);
			Course course = (Course)_lviDroped.Tag;
			EduProgram eduProg = (EduProgram)course.Parent;
						
			string [] ulsEPSem= new string[3];
			ulsEPSem[0]=course.getFullName();
			string epText="";
			if(eduProg.getCode()!=null)
			{
				epText=eduProg.getCode()+", ";
			}
			epText+=eduProg.getName();
			ulsEPSem[1]=epText;
			ulsEPSem[2]=eduProg.getSemester();						
			ListViewItem newLvi= new ListViewItem(ulsEPSem);			
			newLvi.Tag=course;
			_ullv.Items.Add(newLvi);
			_ullv.EnsureVisible(_ullv.Items.IndexOf(newLvi));
			
			eduProg.getUnallocatedLessonsList().Add(_lviDroped);
			if(course.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in course.getCoursesToHoldTogetherList())
				{					
					EduProgram epHT = (EduProgram)courseHT.Parent;
				
					ListViewItem lviNew=new ListViewItem();
					lviNew.Tag=courseHT;

					epHT.getUnallocatedLessonsList().Add(lviNew);

					//add in ListView
					string [] ulsEPSemHT= new string[3];
					ulsEPSemHT[0]=courseHT.getFullName();		
					string epTextHT="";
					if(epHT.getCode()!=null)
					{
						epTextHT=epHT.getCode()+", ";
					}
					epTextHT+=epHT.getName();
					ulsEPSemHT[1]=epTextHT;
					ulsEPSemHT[2]=epHT.getSemester();						
					ListViewItem newLviHT= new ListViewItem(ulsEPSemHT);					
					newLviHT.Tag=courseHT;
					_ullv.Items.Add(newLviHT);
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

		public override void redo()
		{
			doit();
		}
	}
}
