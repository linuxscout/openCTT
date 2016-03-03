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

namespace OpenCTT
{
	/// <summary>
	/// Summary description for DeleteTeacherCmd.
	/// </summary>
	public class DeleteTeacherCmd:AbstractCommand
	{
		private Teacher _teacher;

		public DeleteTeacherCmd(Teacher teacher)
		{
            _teacher=teacher;
		}

		public override void doit()
		{
			AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Remove(_teacher);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.TeachersRootNode;
			AppForm.getAppForm().getTeachersTreeView().SelectedNode.EnsureVisible();			

			if(HardConstraintChecks.checkIfTitleOfTeacherIsFreeForDelete(_teacher))
			{
				AppForm.CURR_OCTT_DOC.TeacherTitlesList.Remove(_teacher.getTitle());			
			}

			if(HardConstraintChecks.checkIfEduRankOfTeacherIsFreeForDelete(_teacher))
			{
				AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Remove(_teacher.getEduRank());
			}

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
		}


		public override void undo()
		{
			AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Add(_teacher);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=_teacher;
			AppForm.getAppForm().getTeachersTreeView().SelectedNode.EnsureVisible();
			AppForm.CURR_OCTT_DOC.TeachersRootNode.Expand();

			if(!AppForm.CURR_OCTT_DOC.TeacherTitlesList.Contains(_teacher.getTitle()))
			{
				AppForm.CURR_OCTT_DOC.TeacherTitlesList.Add(_teacher.getTitle());
				AppForm.CURR_OCTT_DOC.TeacherTitlesList.Sort();
			}

			if(!AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Contains(_teacher.getEduRank()))
			{
				AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Add(_teacher.getEduRank());
				AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Sort();
			}

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
		}

		public override void redo()
		{
			doit();			
		}
	}
}
