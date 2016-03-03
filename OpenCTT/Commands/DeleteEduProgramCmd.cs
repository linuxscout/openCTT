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
	/// Summary description for DeleteEduProgramCmd.
	/// </summary>
	public class DeleteEduProgramCmd:AbstractCommand
	{
		private EduProgram _ep;
		private EduProgramGroup _epg;

		public DeleteEduProgramCmd(EduProgram ep)
		{
			_ep=ep;
			_epg = (EduProgramGroup)_ep.Parent;
		}

		public override void doit()
		{			
			_ep.Remove();
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_epg;

			foreach(Course course in _ep.Nodes)
			{
				if(course.getCoursesToHoldTogetherList().Count==0)
				{
					AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(course.getNumberOfLessonsPerWeek());
				}
				else
				{
					foreach(Course deepCourse in course.getCoursesToHoldTogetherList())
					{
						deepCourse.getCoursesToHoldTogetherList().Remove(course);
					}

				}


			}
			
			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;

		}

		public override void undo()
		{
			_epg.Nodes.Add(_ep);	
			_epg.Expand();
			AppForm.getAppForm().getCoursesTreeView().SelectedNode=_ep;	

			foreach(Course course in _ep.Nodes)
			{
				if(course.getCoursesToHoldTogetherList().Count==0)
				{
					AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(course.getNumberOfLessonsPerWeek());
				}
				else
				{
					foreach(Course deepCourse in course.getCoursesToHoldTogetherList())
					{
						deepCourse.getCoursesToHoldTogetherList().Add(course);
					}

				}
			}

			AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
			AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			
		}

		public override void redo()
		{
			doit();			
		}


	}
}
