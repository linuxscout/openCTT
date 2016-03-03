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
//using System.Collections;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for DeleteEduProgramGroupCmd.
	/// </summary>
	public class DeleteEduProgramGroupCmd:AbstractCommand
	{
		private EduProgramGroup _epg;
		private int _numOfUnallocatedLessonsStep;

		public DeleteEduProgramGroupCmd(EduProgramGroup epg,int numOfUnallocatedLessonsStep)
		{
			_epg=epg;
			_numOfUnallocatedLessonsStep=numOfUnallocatedLessonsStep;
		}

		public override void doit()
		{			
			_epg.Remove();

			foreach(EduProgram ep in _epg.Nodes)
			{
				foreach(Course course in ep.Nodes)
				{
					foreach(Course deepCourse in course.getCoursesToHoldTogetherList())
					{
						EduProgram deepEP=(EduProgram)deepCourse.Parent;
						EduProgramGroup deepEPG = (EduProgramGroup)deepEP.Parent;								

						if(deepEPG!=_epg)
						{
							deepCourse.getCoursesToHoldTogetherList().Remove(course);							
						}
					}
				}
			}



			AppForm.getAppForm().getCoursesTreeView().SelectedNode=AppForm.CURR_OCTT_DOC.CoursesRootNode;
			AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(_numOfUnallocatedLessonsStep);
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
		}

		public override void undo()
		{
			AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Add(_epg);

			foreach(EduProgram ep in _epg.Nodes)
			{
				foreach(Course course in ep.Nodes)
				{
					foreach(Course deepCourse in course.getCoursesToHoldTogetherList())
					{
						EduProgram deepEP=(EduProgram)deepCourse.Parent;
						EduProgramGroup deepEPG = (EduProgramGroup)deepEP.Parent;								

						if(deepEPG!=_epg)
						{
							deepCourse.getCoursesToHoldTogetherList().Add(course);							
						}
					}
				}
			}

			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_epg;
			AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(_numOfUnallocatedLessonsStep);
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;			
		}

		public override void redo()
		{
			doit();			
		}
	}
}
