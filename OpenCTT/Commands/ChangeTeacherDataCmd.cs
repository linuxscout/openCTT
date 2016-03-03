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
	/// Summary description for ChangeTeacherDataCmd.
	/// </summary>
	public class ChangeTeacherDataCmd:AbstractCommand
	{
		Teacher _teacher;

		string _oldName;
		string _oldLastName;
		string _oldTitle;
		string _oldEduRank;
		string _oldExtID;

		string _newName;
		string _newLastName;
		string _newTitle;
		string _newEduRank;
		string _newExtID;

		public ChangeTeacherDataCmd(Teacher teacher,string newName,string newLastName,string newTitle, string newEduRank, string newExtID)
		{
			_teacher=teacher;

			_oldName=_teacher.getName();
			_oldLastName=_teacher.getLastName();
			_oldTitle=_teacher.getTitle();
			_oldEduRank=_teacher.getEduRank();
			_oldExtID=_teacher.ExtID;

			_newName=newName;
			_newLastName=newLastName;
			_newTitle=newTitle;
			_newEduRank=newEduRank;
			_newExtID=newExtID;
		}

		public override void doit()
		{			

			if(_newTitle!=_oldTitle)
			{
				if(!AppForm.CURR_OCTT_DOC.TeacherTitlesList.Contains(_newTitle))
				{
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Add(_newTitle);
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Sort();
				}

				if(HardConstraintChecks.checkIfTitleOfTeacherIsFreeForDelete(_teacher))
				{
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Remove(_oldTitle);
				}
			}

			if(_newEduRank!=_oldEduRank)
			{
				if(!AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Contains(_newEduRank))
				{
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Add(_newEduRank);
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Sort();
				}

				if(HardConstraintChecks.checkIfEduRankOfTeacherIsFreeForDelete(_teacher))
				{
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Remove(_oldEduRank);
				}
			}

			_teacher.setName(_newName);
			_teacher.setLastName(_newLastName);			
			_teacher.setTitle(_newTitle);					
			_teacher.setEduRank(_newEduRank);
			_teacher.ExtID=_newExtID;

			
			sortIt();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;

		}

		public override void undo()
		{

			if(_newTitle!=_oldTitle)
			{
				if(!AppForm.CURR_OCTT_DOC.TeacherTitlesList.Contains(_oldTitle))
				{
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Add(_oldTitle);
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Sort();
				}

				if(HardConstraintChecks.checkIfTitleOfTeacherIsFreeForDelete(_teacher))
				{
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Remove(_newTitle);
				}
			}

			if(_newEduRank!=_oldEduRank)
			{
				if(!AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Contains(_oldEduRank))
				{
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Add(_oldEduRank);
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Sort();
				}

				if(HardConstraintChecks.checkIfEduRankOfTeacherIsFreeForDelete(_teacher))
				{
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Remove(_newEduRank);
				}
			}

			_teacher.setName(_oldName);
			_teacher.setLastName(_oldLastName);			
			_teacher.setTitle(_oldTitle);					
			_teacher.setEduRank(_oldEduRank);
			_teacher.ExtID=_oldExtID;

			
			sortIt();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
			
		}

		public override void redo()
		{
			doit();			
		}

		private void sortIt()
		{
			AppForm.getAppForm().getTeachersTreeView().BeginUpdate();
			AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Remove(_teacher);
			AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Add(_teacher);
			AppForm.getAppForm().getTeachersTreeView().SelectedNode=_teacher;
			AppForm.getAppForm().getTeachersTreeView().EndUpdate();
		}

	}
}
