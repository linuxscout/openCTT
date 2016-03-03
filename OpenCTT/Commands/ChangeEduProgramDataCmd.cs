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
	/// Summary description for ChangeEduProgramDataCmd.
	/// </summary>
	public class ChangeEduProgramDataCmd:AbstractCommand
	{
		private EduProgram _ep;

		private string _oldName;
		private string _oldCode;
		private string _oldSemester;
		private string _oldExtID;

		private string _newName;
		private string _newCode;
		private string _newSemester;
		private string _newExtID;

		public ChangeEduProgramDataCmd(EduProgram ep, string newName, string newCode, string newSemester,string newExtID)
		{
			_ep=ep;
			_oldName=_ep.getName();
			_oldCode=_ep.getCode();
			_oldSemester=_ep.getSemester();
			_oldExtID=_ep.ExtID;
			
			_newName=newName;
			_newCode=newCode;
			_newSemester=newSemester;
			_newExtID=newExtID;
		}

		public override void doit()
		{
			_ep.setCode(_newCode);			
			_ep.setSemester(_newSemester);
			_ep.setName(_newName);
			_ep.ExtID=_newExtID;

			sortIt();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
		}

		public override void undo()
		{
			_ep.setCode(_oldCode);
			_ep.setSemester(_oldSemester);
			_ep.setName(_oldName);
			_ep.ExtID=_oldExtID;

			sortIt();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			
		}

		public override void redo()
		{
			doit();			
		}

		private void sortIt()
		{			
			EduProgramGroup myEPG=(EduProgramGroup)_ep.Parent;			
			myEPG.Nodes.Remove(_ep);
			myEPG.Nodes.Add(_ep);	
			AppForm.getAppForm().getCoursesTreeView().SelectedNode.EnsureVisible();			
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_ep;

		}
	}
}
