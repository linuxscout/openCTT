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
	/// Summary description for ChangeEduProgramGroupDataCmd.
	/// </summary>
	public class ChangeEduProgramGroupDataCmd:AbstractCommand
	{
		private EduProgramGroup _epg;
		private string _oldName;
		private string _oldExtID;

		private string _newName;
		private string _newExtID;

		public ChangeEduProgramGroupDataCmd(EduProgramGroup epg, string newName, string newExtID)
		{
			_epg=epg;

			_oldName=_epg.getName();
			_newName=newName;

			_oldExtID=_epg.ExtID;
			_newExtID=newExtID;
		}

		public override void doit()
		{
			_epg.setName(_newName);
			_epg.ExtID=_newExtID;

			//this is because of sorting
			AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Remove(_epg);
			AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Add(_epg);

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_epg;

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			
		}

		public override void undo()
		{
			_epg.setName(_oldName);
			_epg.ExtID=_oldExtID;

			//this is because of sorting
			AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Remove(_epg);
			AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Add(_epg);

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_epg;

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;			
		}

		public override void redo()
		{
			doit();			
		}
	}
}
