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
	/// Summary description for AddTermCmd.
	/// </summary>
	public class AddTermCmd:AbstractCommand
	{
		private int _index;
		int[] _termData;

		private TreeNode _workingNode;
		private int _tabIndex;
		private bool _calledFromMainForm;

		public AddTermCmd(int index, int [] termData)
		{
			_index=index;
			_termData=termData;
			_calledFromMainForm=false;

			_tabIndex=AppForm.getAppForm().getTreeTabControl().SelectedIndex;
			

			if(_tabIndex==0)
			{
				_workingNode=AppForm.getAppForm().getCoursesTreeView().SelectedNode;
			}
			else if(_tabIndex==1)
			{
				_workingNode=AppForm.getAppForm().getTeachersTreeView().SelectedNode;
			}
			else if(_tabIndex==2)
			{
				_workingNode=AppForm.getAppForm().getRoomsTreeView().SelectedNode;
			}			
		}

		public AddTermCmd(int index, int [] termData, bool calledFromMainForm):this(index, termData)
		{
			_calledFromMainForm=calledFromMainForm;
		}

		public override void doit()
		{
			ModelOperations.addTermInModel(_index);
			AppForm.CURR_OCTT_DOC.IncludedTerms.Insert(_index,_termData);

			AppForm.getAppForm().refreshGUIAfterDaysTermsChange(true);
		}

		public override void undo()
		{
			AppForm.CURR_OCTT_DOC.IncludedTerms.RemoveAt(_index);	
			ArrayList [] undoRedoLists;
			ModelOperations.delTermInModel(_index, out undoRedoLists);

			AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=_tabIndex;
			AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			
			//AppForm.getAppForm().refreshGUIAfterDaysTermsChange(false);
			AppForm.getAppForm().refreshGUIAfterDaysTermsChange(_calledFromMainForm);
						
			if(_tabIndex==0)
			{
				AppForm.CURR_OCTT_DOC.CTVSelectedNode=_workingNode;
				AppForm.getAppForm().ctvRefreshTimetablePanel(_workingNode,true,true);
				
				AppForm.getAppForm().getCoursesTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=_workingNode;
				AppForm.getAppForm().getCoursesTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
			}
			else if(_tabIndex==1)
			{			
				
				AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
				AppForm.getAppForm().getTeachersTreeView().SelectedNode=_workingNode;
				AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);

				AppForm.CURR_OCTT_DOC.TTVSelectedNode=_workingNode;
				AppForm.getAppForm().ttvRefreshTimetablePanel(_workingNode,true);
				
			}
			else if(_tabIndex==2)
			{				
				AppForm.getAppForm().getRoomsTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().roomsTreeView_AfterSelect);
				AppForm.getAppForm().getRoomsTreeView().SelectedNode=_workingNode;
				AppForm.getAppForm().getRoomsTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().roomsTreeView_AfterSelect);

				AppForm.CURR_OCTT_DOC.RTVSelectedNode=_workingNode;
				AppForm.getAppForm().rtvRefreshTimetablePanel(_workingNode,true);
			}
			
		}

		public override void redo()
		{

			ModelOperations.addTermInModel(_index);
			AppForm.CURR_OCTT_DOC.IncludedTerms.Insert(_index,_termData);			
			
			AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged -=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=_tabIndex;
			AppForm.getAppForm().getTreeTabControl().SelectedIndexChanged +=new System.EventHandler(AppForm.getAppForm().treeTabControl_SelectedIndexChanged);
			
			//AppForm.getAppForm().refreshGUIAfterDaysTermsChange(false);
			AppForm.getAppForm().refreshGUIAfterDaysTermsChange(_calledFromMainForm);			
						
			if(_tabIndex==0)
			{
				AppForm.CURR_OCTT_DOC.CTVSelectedNode=_workingNode;
				AppForm.getAppForm().ctvRefreshTimetablePanel(_workingNode,true,true);
				
				AppForm.getAppForm().getCoursesTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=_workingNode;
				AppForm.getAppForm().getCoursesTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
			}
			else if(_tabIndex==1)
			{	
				AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
				AppForm.getAppForm().getTeachersTreeView().SelectedNode=_workingNode;
				AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);

				AppForm.CURR_OCTT_DOC.TTVSelectedNode=_workingNode;
				AppForm.getAppForm().ttvRefreshTimetablePanel(_workingNode,true);
				
			}
			else if(_tabIndex==2)
			{
				AppForm.getAppForm().getRoomsTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().roomsTreeView_AfterSelect);
				AppForm.getAppForm().getRoomsTreeView().SelectedNode=_workingNode;
				AppForm.getAppForm().getRoomsTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().roomsTreeView_AfterSelect);

				AppForm.CURR_OCTT_DOC.RTVSelectedNode=_workingNode;
				AppForm.getAppForm().rtvRefreshTimetablePanel(_workingNode,true);				
			}
		}



	}
}
