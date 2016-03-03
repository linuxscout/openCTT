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


namespace OpenCTT
{
	/// <summary>
	/// Summary description for Teacher.
	/// </summary>
	public class Teacher: System.Windows.Forms.TreeNode
	{
		private string _name;
		private string _lastName;
		private string _title;
		private string _eduRank;	
		private string _extID;
		private bool[,] _allowedTimeSlots;
		private ArrayList _allowedRoomsList;	

		private int _tempID;
		private ArrayList _tempAllowedRoomsList=null;

        private int _scMaxDaysPerWeek=-1;
        private int _scMaxHoursDaily = -1;
        private int _scMaxHoursContinously = -1;
        

		public Teacher(string name, string lastName, string title, string eduRank, string extID)
		{
			_name=name;
			_lastName=lastName;
			_title=title;
			_eduRank=eduRank;
			_extID=extID;
			_allowedRoomsList=null;

			_allowedTimeSlots = new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					_allowedTimeSlots[j,k]=true;
				}
			}	

			setTreeText();
			this.ImageIndex=6;
			this.SelectedImageIndex=6;

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

		private void setTreeText() 
		{
			string myText=_lastName+" "+_name;
			if(_title!=null && _title!="") myText+=", "+_title;
			if(_eduRank!=null && _eduRank!="") myText+=", "+_eduRank;
			this.Text=myText;
		}

		public void setName(string name) 
		{
			_name=name;
			setTreeText();
		}

		public void setLastName(string lastName) 
		{
			_lastName=lastName;
			setTreeText();
		}

		public void setTitle(string title) 
		{
			_title=title;
			setTreeText();
		}

		public void setEduRank(string eduRank) 
		{
			_eduRank=eduRank;
			setTreeText();
		}

		public string getName() 
		{
			return _name;
		}

		public string getLastName() 
		{
			return _lastName;
		}

		public string getTitle() 
		{
			return _title;
		}

		public string getEduRank() 
		{
			return _eduRank;
		}

		public bool [,] getAllowedTimeSlots() 
		{
			return _allowedTimeSlots;
		}

		public void setAllowedTimeSlots(bool [,] newAllowedTimeSlots)
		{
			_allowedTimeSlots=newAllowedTimeSlots;
		}

		public ArrayList getAllowedRoomsList() 
		{
			return _allowedRoomsList;
		}

		public void setAllowedRoomsList(ArrayList al)
		{
			_allowedRoomsList=al;
		}

		public string getTreeText()
		{
			return this.Text;
		}

		public string getReportTitle()
		{			
			string title= _title+" "+(_name+" "+_lastName).ToUpper();			
			
			if(_eduRank!=null && _eduRank!="")
			{
                title+=", "+_eduRank;
			}
            return title;
		}

		public ArrayList getUnallocatedLessonsList()
		{
			ArrayList alist= new ArrayList();
			foreach(EduProgramGroup eduProgramGroup in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
			{
				foreach(EduProgram ep in eduProgramGroup.Nodes)
				{
					ArrayList unallocatedLessonsList=ep.getUnallocatedLessonsList();
					foreach(ListViewItem lvi in unallocatedLessonsList)
					{
						Course edu_program_group = (Course)lvi.Tag;
						Teacher teacher = edu_program_group.getTeacher();
						if(teacher==this)
						{
							alist.Add(lvi);
						}
					}
					
				}
			}

			return alist;

		}


		public bool getIsUsedAsTeacherForAnyCourse()
		{
			foreach(EduProgramGroup eduProgramGroup in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
			{
				foreach(EduProgram ep in eduProgramGroup.Nodes)
				{
					foreach(Course edu_program_group in ep.Nodes)
					{
						if(edu_program_group.getTeacher()==this)
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		public static bool getIsTeacherDataOK(Teacher currTeacher,string name, string lastName, string title, string eduRank)
		{
			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{				
				if(teacher!=currTeacher)
				{
					if(teacher.getName().ToUpper()==name.ToUpper() && teacher.getLastName().ToUpper()==lastName.ToUpper()
						&& teacher.getTitle().ToUpper()==title.ToUpper() && teacher.getEduRank().ToUpper()==eduRank.ToUpper())
					{
						return false;
					}
				}
				
			}
			
			return true;
		}

		public void getIsThereMoreUnallowedThanAllowedTimeSlots(out int allowed, out int unallowed)
		{	
			int p=0,i=0;

			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{				
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					if(_allowedTimeSlots[j,k]==true)
					{
                        p++;
					}
					else
					{
						i++;
					}
				}				
			}
			allowed=p;
			unallowed=i;			
		}

		public int getTempID()
		{
			return _tempID;
		}

		public void setTempID(int id)
		{
			_tempID=id;
		}

		public ArrayList getTempAllowedRoomsList()
		{
			return _tempAllowedRoomsList;
		}

		public void setTempAllowedRoomsList(ArrayList tempAllowedRoomsList)
		{
			_tempAllowedRoomsList=tempAllowedRoomsList;
		}

		public static Teacher getTeacherByData(string name,string lastName,string title,string eduRank)
		{
			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{
				if(teacher.getName()==name && teacher.getLastName()==lastName && teacher.getTitle()==title && teacher.getEduRank()==eduRank)
				{
					return teacher;
				}
			}

			return null;
		}


        public int getNumberOfMyLessonsPerWeek()
        {
            ArrayList resList = new ArrayList();

            int numOfHPW = 0;
            int numOfTimePeriods = AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
            int numOfDays = AppForm.CURR_OCTT_DOC.getNumberOfDays();

            foreach (EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
            {
                foreach (EduProgram ep in epg.Nodes)
                {
                    ArrayList[,] myttT = ep.getTimetable();
                    for (int j = 0; j < numOfTimePeriods; j++)
                    {
                        for (int k = 0; k < numOfDays; k++)
                        {
                            ArrayList lessonsInOneTimeSlot = myttT[j, k];
                            if (lessonsInOneTimeSlot != null && lessonsInOneTimeSlot.Count != 0)
                            {
                                foreach (Object[] courseAndRoomPair in lessonsInOneTimeSlot)
                                {
                                    Course course = (Course)courseAndRoomPair[0];
                                    Teacher teacherFromModel = course.getTeacher();
                                    if (teacherFromModel == this)
                                    {                                        
                                        bool addMe = true;

                                        foreach (int[] ots in resList)
                                        {
                                            if(ots[0]==j && ots[1]==k)
                                            {
                                                addMe = false;
                                                break;                                                
                                            }
                                        }

                                        if (addMe)
                                        {
                                            int[] occupTS= new int[2];
                                            occupTS[0]=j;
                                            occupTS[1]=k;
                                            resList.Add(occupTS);
                                        }
                                        
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            numOfHPW = resList.Count;
            return numOfHPW;

        }



        public int SCMaxDaysPerWeek
        {
            get
            {
                return _scMaxDaysPerWeek;
            }
            set
            {
                _scMaxDaysPerWeek = value;
            }
        }


        public int SCMaxHoursDaily
        {
            get
            {
                return _scMaxHoursDaily;
            }
            set
            {
                _scMaxHoursDaily = value;
            }
        }

        public int SCMaxHoursContinously
        {
            get
            {
                return _scMaxHoursContinously;
            }
            set
            {
                _scMaxHoursContinously = value;
            }
        }


	
	
	}
}
