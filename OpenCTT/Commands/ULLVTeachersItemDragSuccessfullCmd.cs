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
using System.Windows.Forms;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for ULLVTeachersItemDragSuccessfullCmd.
	/// </summary>
	public class ULLVTeachersItemDragSuccessfullCmd:AbstractCommand
	{
		ListViewItem _dragedLvi;
		ListView _unallocatedLessonsTeacherListView;

		private TreeNode _selectedNode;

		public ULLVTeachersItemDragSuccessfullCmd(ListViewItem lvi,ListView listView)
		{
			_dragedLvi=lvi;
			_unallocatedLessonsTeacherListView=listView;
		
			_selectedNode=AppForm.getAppForm().getTeachersTreeView().SelectedNode;
			
		}

		public override void doit()
		{
			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);
			_unallocatedLessonsTeacherListView.Items.Remove(_dragedLvi);
			Course dragedCourse=(Course)_dragedLvi.Tag;
				
			EduProgram epInDrag = (EduProgram)dragedCourse.Parent;
			epInDrag.removeOneLessonFromUnallocatedLessonsModel(dragedCourse);

				
			if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in dragedCourse.getCoursesToHoldTogetherList())
				{
					EduProgram epHT=(EduProgram)courseHT.Parent;
					epHT.removeOneLessonFromUnallocatedLessonsModel(courseHT);
				
					ListViewItem itemForDel=null;
					foreach(ListViewItem listViewItem in _unallocatedLessonsTeacherListView.Items)
					{							
						Course tagCourse = (Course)listViewItem.Tag;
						if(tagCourse==courseHT)
						{
							itemForDel=listViewItem;
							break;
						}
					}

					_unallocatedLessonsTeacherListView.Items.Remove(itemForDel);

				}				
			}

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
		}

		public override void undo()
		{
			_unallocatedLessonsTeacherListView.Items.Add(_dragedLvi);
			Course dragedCourse=(Course)_dragedLvi.Tag;
			EduProgram ep=(EduProgram)dragedCourse.Parent;

			ep.getUnallocatedLessonsList().Add(_dragedLvi);
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(1);
			
			if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course courseHT in dragedCourse.getCoursesToHoldTogetherList())
				{
					EduProgram epHT=(EduProgram)courseHT.Parent;
					ListViewItem lviHT=new ListViewItem();
					lviHT.Tag=courseHT;
					epHT.getUnallocatedLessonsList().Add(lviHT);					
				}
			}			

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
		}

		public override void redo()
		{
			doit();

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
