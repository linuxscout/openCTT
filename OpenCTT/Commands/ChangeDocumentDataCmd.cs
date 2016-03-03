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
	/// Summary description for ChangeDocumentDataCmd.
	/// </summary>
	public class ChangeDocumentDataCmd:AbstractCommand
	{
		private string _oldEduInstitutionName;
		private string _oldSchoolYear;
		private int _oldDocType;

		private string _newEduInstitutionName;
		private string _newSchoolYear;
		private int _newDocType;

		public ChangeDocumentDataCmd(int oldDocType,string oldEduInstitutionName,string oldSchoolYear, int newDocType,string newEduInstitutionName, string newSchoolYear)
		{
			_oldDocType=oldDocType;
			_oldEduInstitutionName=oldEduInstitutionName;
			_oldSchoolYear=oldSchoolYear;

			_newDocType=newDocType;
			_newEduInstitutionName=newEduInstitutionName;
			_newSchoolYear=newSchoolYear;
		}

		public override void doit()
		{
			AppForm.CURR_OCTT_DOC.EduInstitutionName=_newEduInstitutionName;
			AppForm.CURR_OCTT_DOC.SchoolYear=_newSchoolYear;
			AppForm.CURR_OCTT_DOC.DocumentType=_newDocType;

			AppForm.CURR_OCTT_DOC.refreshTreeRootText();		

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.CoursesRootNode;

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;

			AppForm.setResourceManager();
			AppForm.getAppForm().updateFormRelatedStrings();
			AppForm.getAppForm().updateOpenDocumentRelatedStrings();
			
		}

		public override void undo()
		{
			AppForm.CURR_OCTT_DOC.EduInstitutionName=_oldEduInstitutionName;
			AppForm.CURR_OCTT_DOC.SchoolYear=_oldSchoolYear;
			AppForm.CURR_OCTT_DOC.DocumentType=_oldDocType;

			AppForm.CURR_OCTT_DOC.refreshTreeRootText();			

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.CoursesRootNode;			

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;

			AppForm.setResourceManager();
			AppForm.getAppForm().updateFormRelatedStrings();
			AppForm.getAppForm().updateOpenDocumentRelatedStrings();
		}

		public override void redo()
		{
			doit();			
		}
	}
}
