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
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for Room.
	/// </summary>
	public class Room: System.Windows.Forms.TreeNode
	{
		private static ResourceManager RES_MANAGER;	

		private string _name;
		private int _roomCapacity;
		
		private string _extID;

		private bool[,] _allowedTimeSlots;		

		private int _tempID;

		public Room(string name, int capacity, string extID)
		{
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.Room",this.GetType().Assembly);
			}

			_name=name;
			_roomCapacity=capacity;
	
			_extID=extID;

			_allowedTimeSlots = new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					_allowedTimeSlots[j,k]=true;

				}
			}

			setTreeText();
			this.ImageIndex=4;
			this.SelectedImageIndex=4;	
			
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

		public string TextForList
		{
			get
			{	
				return _name+", "+_roomCapacity.ToString()+" "+RES_MANAGER.GetString("seats.text");
			}
		}

		private void setTreeText() 
		{
			this.Text=_name;
		}

		public string getName() 
		{
			return _name;
		}

		public void setName(string name) 
		{
			_name=name;
			setTreeText();		
		}

		public int getRoomCapacity() 
		{
			return _roomCapacity;
		}
		

		public void setRoomCapacity(int capacity) 
		{
			_roomCapacity=capacity;
			setTreeText();
		}

		public bool [,] getAllowedTimeSlots() 
		{
			return _allowedTimeSlots;
		}

		public void setAllowedTimeSlots(bool [,] allowedTimeSlots)
		{
			_allowedTimeSlots=allowedTimeSlots;
		}

		public override string ToString()
		{	
			return _name+", "+_roomCapacity.ToString()+" "+RES_MANAGER.GetString("seats.text");
		}

		public static bool getIsNewNameOK(string newName)
		{			
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				if(room.getName().ToUpper()==newName.ToUpper()) return false;
			}
			return true;
		}

		public static bool getIsNewCapacityOK(Room room,int newCapacity)
		{
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{			
					int minReqCapacity=0;

					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
					{
						foreach(EduProgram ep in epg.Nodes)
						{
							ArrayList [,] mytt = ep.getTimetable();
							ArrayList lessonsInOneTimeSlot = mytt[j,k];
							if(lessonsInOneTimeSlot!=null) 
							{								
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{									
									Room roomFromModel = (Room)courseAndRoomPair[1];
									if(roomFromModel==room)
									{										
										Course edu_program_group = (Course)courseAndRoomPair[0];
										minReqCapacity+=edu_program_group.getNumberOfEnrolledStudents();
										
									}
								}
							}
						}
					}

					if(minReqCapacity>newCapacity) return false;
					
				}
			}

			return true;

		}


		public bool getIsInTimetable()
		{
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{				
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{
					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
					{
						foreach(EduProgram ep in epg.Nodes)
						{
							ArrayList [,] mytt = ep.getTimetable();
							ArrayList lessonsInOneTimeSlot = mytt[j,k];
							if(lessonsInOneTimeSlot!=null) 
							{								
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{									
									Room roomFromModel = (Room)courseAndRoomPair[1];
									if(roomFromModel==this)
									{
										return true;
									}
								}
							}
						}
					}
					
				}
			}

			return false;
		}

		public string getStatusText()
		{	
			return _name+", "+_roomCapacity+" "+RES_MANAGER.GetString("seats.text");
			
		}

		public int getTempID()
		{
			return _tempID;
		}

		public void setTempID(int id)
		{
			_tempID=id;
		}

		public string getReportTitle()
		{			
			return RES_MANAGER.GetString("getReportTitle.room.text")+" "+_name;
		}

		

	}
}
