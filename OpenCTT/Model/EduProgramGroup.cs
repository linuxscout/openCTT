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
	/// Summary description for EduProgramGroup.
	/// </summary>
	public class EduProgramGroup: System.Windows.Forms.TreeNode
	{

		private string _name;		
		private string _extID;
		private bool[,] _allowedTimeSlots;

		public EduProgramGroup(string name, string extID)
		{
			_name=name;			
			_extID=extID;

			_allowedTimeSlots = new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					_allowedTimeSlots[j,k]=true;
				}
			}

			this.Text=_name;
			this.ImageIndex=1;
			this.SelectedImageIndex=1;
		}

		public string ExtID
		{
			get
			{
				return _extID;
			}
			set
			{
				_extID=value;
			}
		}

		public string getName() 
		{
			return _name;
		}

		public void setName(string name) 
		{
			_name=name;
			this.Text=_name;
		}

		public bool [,] getAllowedTimeSlots() 
		{
			return _allowedTimeSlots;
		}

		public void setAllowedTimeSlots(bool [,] allowedTimeSlots)
		{
			_allowedTimeSlots=allowedTimeSlots;
		}

		public static bool checkNewName(string newName)
		{			
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
			{
				if(epg.getName().ToUpper()==newName.ToUpper()) return false;
			}
			return true;
		}

	}
}
