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
	/// Summary description for Course.
	/// </summary>	
	public class Course: System.Windows.Forms.TreeNode
	{
        private bool _tempIsPreparedForAutomatedTT=false;

		private static ResourceManager RES_MANAGER;	

		private int _tempID;
		private ArrayList _tempCoursesToHoldTogetherList=null;
		private int _tempNumberOfUnallocatedLessons;

		private string _name;
		private string _shortName;
		private string _courseType;
		private int _numberOfLessonsPerWeek;
		private int _numberOfEnrolledStudents;
		private Teacher _teacher;
		private bool _isGroup;
		private string _groupName;

		private ArrayList _coursesToHoldTogetherList;
		private ArrayList _allowedRoomsList;
		
		private string _extID;

		private System.Drawing.Color _color;


        private int[] _scLessonBlocksParameters = null;


		public Course(string name,string shortName, Teacher teacher,int numberOfLessonsPerWeek, int numberOfEnrolledStudents, bool isGroup, string groupName, string extID, string courseType)
		{
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.Course",this.GetType().Assembly);
			}

			_name=name;
			_shortName=shortName;
			_courseType=courseType;
			_teacher=teacher;
			_numberOfLessonsPerWeek=numberOfLessonsPerWeek;
			_numberOfEnrolledStudents=numberOfEnrolledStudents;

			_isGroup=isGroup;
			_groupName=groupName;		
			_extID=extID;
			_allowedRoomsList=null;
			_coursesToHoldTogetherList=new ArrayList();

			this.setTreeText();	
			this.ImageIndex=3;
			this.SelectedImageIndex=3;

			_color=CourseGUIColorFactory.getNextCourseGUIColor();			
			
		}

		public System.Drawing.Color MyGUIColor
		{
			get
			{
				return _color;
			}
			set
			{
				_color=value;
			}
		}

		public string CourseType
		{
			get
			{
				return _courseType;
			}
			set
			{
				_courseType=value;
				this.setTreeText();
			}
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

		public int TempNumberOfUnallocatedLessons
		{
			get
			{
				return _tempNumberOfUnallocatedLessons;
			}
			set
			{
				_tempNumberOfUnallocatedLessons=value;
			}
		}


		public string getName() 
		{
			return _name;
		}

		public string getShortName() 
		{
			return _shortName;
		}

		public Teacher getTeacher() 
		{
			return _teacher;
		}
		

		public int getNumberOfLessonsPerWeek()
		{
			return _numberOfLessonsPerWeek;
		}

		public int getNumberOfEnrolledStudents() 
		{
			return _numberOfEnrolledStudents;
		}

		public bool getIsGroup() 
		{
			return _isGroup;
		}

		public string getGroupName() 
		{
			return _groupName;		
		}

		public void setName(string name) 
		{
			_name=name;
			this.setTreeText();
		}

		public void setShortName (string shortName) 
		{
			_shortName=shortName;
		}

		public void setTeacher(Teacher teacher) 
		{
			_teacher=teacher;			
		}

		public void setNumberOfLessonsPerWeek(int numberOfLessonsPerWeek) 
		{
			_numberOfLessonsPerWeek=numberOfLessonsPerWeek;

		}

		public void setNumberOfEnrolledStudents(int numberOfEnrolledStudents) 
		{
			_numberOfEnrolledStudents=numberOfEnrolledStudents;

		}

		public void setIsGroup(bool isGroup) 
		{
			_isGroup=isGroup;
		}

		public void setGroupName(string groupName) 
		{
			_groupName=groupName;
			this.setTreeText();
		}

		public void setTreeText()
		{
			this.Text=_name;
			if(_courseType!="") this.Text+="-"+_courseType;

			if(_isGroup) 
			{				
				this.Text+=" "+RES_MANAGER.GetString("setTreeText.group.text")+" "+_groupName;
			} 
			

		}

		public ArrayList getCoursesToHoldTogetherList()
		{
			return _coursesToHoldTogetherList;
		}

		public void setCoursesToHoldTogetherList(ArrayList ar)
		{
			_coursesToHoldTogetherList=ar;
			if(_coursesToHoldTogetherList.Count>0)
			{
				this.ImageIndex=5;
				this.SelectedImageIndex=5;
			}
			else
			{
				this.ImageIndex=3;
				this.SelectedImageIndex=3;
			}
		}

		public ArrayList getAllowedRoomsList() 
		{
			return _allowedRoomsList;
		}

		public void setAllowedRoomsList(ArrayList al)
		{
			_allowedRoomsList=al;
		}

		public string getFullName()
		{
			string fullName;
			fullName=this.getName();

			if(_courseType!="") fullName+="-"+_courseType;

			if(this.getIsGroup())
			{	
				fullName+=" "+RES_MANAGER.GetString("setTreeText.group.text")+" "+_groupName;
			}
			return fullName;
		}

		public string getReportName()
		{
			string repName;
			repName=this.getShortName();

			if(_courseType!="") repName+="-"+_courseType;

			if(this.getIsGroup())
			{	
				repName+=" "+RES_MANAGER.GetString("setTreeText.group.text")+" "+_groupName;
				
			}
			return repName;
		}

		public string getTSPCoursesTextForStatusBar()
		{			
			string textForStatusBar=this.getFullName()+", ";			
			textForStatusBar+=_numberOfEnrolledStudents.ToString()+" "+RES_MANAGER.GetString("getTSPCoursesTextForStatusBar.enrolled_students.text")+", "+_teacher.getLastName()+" "+_teacher.getName();

			return textForStatusBar;

		}

		public string getTSPTeachersAndRoomsTextForStatusBar()
		{			
			string textForStatusBar=this.getFullName();
			EduProgram ep = (EduProgram)this.Parent;			

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{
				textForStatusBar+=", "+ep.getName()+" "+ep.getCode()+"/"+ep.getSemester()+RES_MANAGER.GetString("getTSPTeachersAndRoomsTextForStatusBar.semester.university.text");

			}
			else
			{
				textForStatusBar+=", "+ep.getName()+" "+ep.getCode()+"/"+ep.getSemester()+RES_MANAGER.GetString("getTSPTeachersAndRoomsTextForStatusBar.semester.school.text");
			}
			
			

			return textForStatusBar;

		}

		public static bool getIsCourseDataOK(Course currCourse,string fullName, string shortName,string courseType, string groupName, bool isCurrCourseGroup)
		{
			EduProgram ep;
			if(currCourse==null)
			{
				ep=(EduProgram)AppForm.CURR_OCTT_DOC.CTVSelectedNode;
			}
			else
			{
				ep=(EduProgram)currCourse.Parent;

			}

			foreach(Course edu_program_group in ep.Nodes)
			{				
				if(edu_program_group!=currCourse)
				{	
					if(edu_program_group.CourseType==courseType)
					{
						if(isCurrCourseGroup)
						{
							if(edu_program_group.getIsGroup())
							{								
								if(edu_program_group.getName().ToUpper()==fullName.ToUpper() || edu_program_group.getShortName().ToUpper()==shortName.ToUpper())
								{
									if(edu_program_group.getGroupName().ToUpper()==groupName.ToUpper())
									{
										return false;
									}
								}
							}
							else
							{
								if(edu_program_group.getName().ToUpper()==fullName.ToUpper() || edu_program_group.getShortName().ToUpper()==shortName.ToUpper())
								{
									return false;
								}
							}

						}
						else
						{
							if(edu_program_group.getName().ToUpper()==fullName.ToUpper() || edu_program_group.getShortName().ToUpper()==shortName.ToUpper())
							{
								return false;
							}
						}					
						
					}
					
				}
			}
			
			return true;
		}

		public int getTempID()
		{
			return _tempID;
		}

		public void setTempID(int id)
		{
			_tempID=id;
		}

        public bool TempIsPreparedForAutomatedTT
        {
            get
            {
                return _tempIsPreparedForAutomatedTT;
            }
            set
            {
                _tempIsPreparedForAutomatedTT = value;
            }
        }

		public ArrayList getTempCoursesToHoldTogetherList()
		{
			return _tempCoursesToHoldTogetherList;
		}

		public void setTempCoursesToHoldTogetherList(ArrayList tempCoursesToHoldTogetherList)
		{
			_tempCoursesToHoldTogetherList=tempCoursesToHoldTogetherList;
		}

		public int getNumberOfUnallocatedLessons()
		{
			int myCounter=0;
			EduProgram ep = (EduProgram)this.Parent;

			foreach(ListViewItem lvi in ep.getUnallocatedLessonsList())
			{
				Course course = (Course)lvi.Tag;
                if (course == this) myCounter++;
			}

			return myCounter;

		}


        public ArrayList getTimeSlotsOfMyAllocatedLessons()
        {
            ArrayList atsList = new ArrayList();

            EduProgram ep = (EduProgram)this.Parent;

            int numOfAlreadyAllocatedLessons = this.getNumberOfLessonsPerWeek() - this.getNumberOfUnallocatedLessons();
            //if (this.getReportName() == "MATEMATIKA 2 - gr. 1") Console.WriteLine("MAT FIXED " + numOfAlreadyAllocatedLessons);

            ArrayList[,] epTimetable = ep.getTimetable();
            int foundCounter = 0;

            int numOfSlotsPerRoom = AppForm.CURR_OCTT_DOC.getNumberOfDays() * AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
            int wtutsEp = 0;

            for (int k = 0; k < AppForm.CURR_OCTT_DOC.getNumberOfDays(); k++)            
            {
                for (int j = 0; j < AppForm.CURR_OCTT_DOC.IncludedTerms.Count; j++)                
                {
                    wtutsEp++;

                    ArrayList lessonsInOneTimeSlot = epTimetable[j, k];

                    if (lessonsInOneTimeSlot != null && lessonsInOneTimeSlot.Count > 0)
                    {
                        IEnumerator enumerator = lessonsInOneTimeSlot.GetEnumerator();

                        for (int step = 0; step < lessonsInOneTimeSlot.Count; step++)
                        {                            
                            enumerator.MoveNext();
                            Object[] courseAndRoomPair = (Object[])enumerator.Current;
                            Course course = (Course)courseAndRoomPair[0];
                            if (course == this)
                            {
                                foundCounter++;
                                Room room = (Room)courseAndRoomPair[1];
                                int roomIndex = AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.IndexOf(room);
                                int cts = roomIndex * numOfSlotsPerRoom + wtutsEp;
                                atsList.Add(cts);
                                //if (this.getReportName() == "MATEMATIKA 2 - gr. 1") Console.WriteLine("FOUND " + cts);
                                
                                if (foundCounter == numOfAlreadyAllocatedLessons) break;
                            }

                        }                        
                    }
                }
            }
           

            return atsList;
        }

        public int[] SCLessonBlocksParameters
        {
            get
            {
                return _scLessonBlocksParameters;
            }
            set
            {
                _scLessonBlocksParameters = value;
            }
        }

	}
}
