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
	/// Summary description for Constants.
	/// </summary>
	public class Constants
	{
		static public int OCTT_DOC_TYPE_SCHOOL=1;
        static public int OCTT_DOC_TYPE_UNIVERSITY=2;

		static public int DAY_HOUR_LABEL_OFFSET=0;	
		static public int DAY_HOUR_PANEL_OFFSET_Y=0;
		static public int DAY_HOUR_PANEL_WIDTH=60;
		static public int DAY_HOUR_PANEL_HEIGHT=25;		

		//ATSF - AllowedTimeSlotsForm
		public static int ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP=1;
		public static int ATSF_TIME_SLOT_TYPE_EDU_PROGRAM=2;
		public static int ATSF_TIME_SLOT_TYPE_TEACHER=3;
		public static int ATSF_TIME_SLOT_TYPE_ROOM=4;

		
	}
}
