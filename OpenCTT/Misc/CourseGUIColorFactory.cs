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
using System.Drawing;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for CourseGUIColorFactory.
	/// </summary>
	public class CourseGUIColorFactory
	{		
		private static int RED=0;
		private static int GREEN=0;
		private static int BLUE=0;

		private static int TURN = 1;
		private static int STEP_R=70;
		private static int STEP_G=90;
		private static int STEP_B=110;
		
		
		public CourseGUIColorFactory()
		{
		}

		public static Color getNextCourseGUIColor()
		{
			switch(TURN)
			{
				case 1:
					GREEN+=STEP_G;
					BLUE+=STEP_B;

					if(GREEN>255) GREEN-=255;
					if(BLUE>255) BLUE-=255;

                    TURN=2;

					break;

				case 2:

					RED+=STEP_R;
					BLUE+=STEP_B;

					if(RED>255) RED-=255;
					if(BLUE>255) BLUE-=255;

					TURN=3;

					break;


				case 3:
					RED+=STEP_R;
					GREEN+=STEP_G;

					if(RED>255) RED-=255;
					if(GREEN>255) GREEN-=255;

					TURN=1;

					break;

			}


			return Color.FromArgb(120, RED, GREEN, BLUE);

		}

		
		

	}
}
