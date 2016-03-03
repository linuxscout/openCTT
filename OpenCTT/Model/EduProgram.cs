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
	/// Summary description for EduProgram.
	/// </summary>
	public class EduProgram: System.Windows.Forms.TreeNode
	{
		private static ResourceManager RES_MANAGER;

        private int _tempID;

		private string _name;
		private string _code;
		private string _semester;
		
		private string _extID;

		private ArrayList _unallocatedLessonsList;
		private ArrayList [,] _myTimetable;	

		private bool[,] _allowedTimeSlots;


        private int _scStudentMaxHoursContinuously = -1;
        private int _scStudentMaxHoursDaily = -1;
        private int _scStudentMaxDaysPerWeek = -1;
        private int _scStudentNoGapsGapIndicator = -1;
        private int _scStudentPreferredStartTimePeriod = -1;



		public EduProgram(string name, string semester, string code, string extID)
		{
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EduProgram",this.GetType().Assembly);
			}

			_name=name;
			_semester=semester;
			if(code=="")
			{
				_code=null;
			} 
			else 
			{
				_code=code;
			}

		
			_extID=extID;
			
			_unallocatedLessonsList = new ArrayList();
			_myTimetable= new ArrayList[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];

			_allowedTimeSlots = new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					_allowedTimeSlots[j,k]=true;

				}
			}

			this.setTreeText();
			this.ImageIndex=2;
			this.SelectedImageIndex=2;
			
		}

        public int getTempID()
        {
            return _tempID;
        }

        public void setTempID(int id)
        {
            _tempID = id;
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

		public void setCode(string code) 
		{
			_code=code;
			this.setTreeText();
		}

		public void setName(string name) 
		{
			_name=name;
			this.setTreeText();			
		}

		public void setSemester(string semester) 
		{
			_semester=semester;
			this.setTreeText();
		}

		public string getName() 
		{
			return _name;
		}


		public string getCode() 
		{
			return _code;
		}

		public string getSemester() 
		{
			return _semester;
		}

		public ArrayList getUnallocatedLessonsList() 
		{
			return _unallocatedLessonsList;
		}

        public void setUnallocatedLessonsList(ArrayList al)
        {
            _unallocatedLessonsList= al;
        }



		private void setTreeText() 
		{
			string semStr="";

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{
                semStr=RES_MANAGER.GetString("setTreeText.semester.university.text");
			}
			else
			{
                semStr=RES_MANAGER.GetString("setTreeText.semester.school.text");
			}

			if(_code!=null) 
			{
				this.Text=_name+" "+_code+", "+_semester+semStr;
			} 
			else 
			{
				this.Text=_name+", "+_semester+semStr;
			}
		}


		public void removeCourseFromUnallocatedLessonsModelAndView(Course courseForDel, ListView unallocatedLessonsListView) 
		{
			//remove from model
			ArrayList tempList = new ArrayList();
			foreach(ListViewItem lvi in this.getUnallocatedLessonsList())
			{
				if(lvi.Tag==courseForDel) 
				{
					tempList.Add(lvi);
				}

			}

			foreach(ListViewItem itemForDel  in tempList) 
			{
				if(courseForDel.getCoursesToHoldTogetherList().Count==0)
				{
					AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);
				}

				this.getUnallocatedLessonsList().Remove(itemForDel);
			}

			// remove from ListView
			tempList.Clear();
			foreach(ListViewItem lvi in unallocatedLessonsListView.Items)  
			{
				if(lvi.Tag==courseForDel) 
				{
					tempList.Add(lvi);
				}
			}

			foreach(ListViewItem itemForDel  in tempList) 
			{
				unallocatedLessonsListView.Items.Remove(itemForDel);
			}
			
			//delete edu_program_group from all lists of 'edu_program_groups to hold together'
			foreach(Course edu_program_group in courseForDel.getCoursesToHoldTogetherList())
			{
				edu_program_group.getCoursesToHoldTogetherList().Remove(courseForDel);
			}

		}
		

		public void removeOneLessonFromUnallocatedLessonsModel(Course edu_program_group) 
		{			
			foreach(ListViewItem lviFromModel in this.getUnallocatedLessonsList())
			{
				if(lviFromModel.Tag==edu_program_group) 
				{					
					this.getUnallocatedLessonsList().Remove(lviFromModel);
					break;

				}
			}
		}

		public void removeOneLessonFromUnallocatedLessonsModelAndListView(Course edu_program_group, ListView unallocatedLessonsListView)
		{			
			foreach(ListViewItem lviFromModel in this.getUnallocatedLessonsList())
			{
				if(lviFromModel.Tag==edu_program_group) 
				{					
					this.getUnallocatedLessonsList().Remove(lviFromModel);
					break;
				}
			}

			foreach(ListViewItem lviFromView in unallocatedLessonsListView.Items)
			{
				if(lviFromView.Tag==edu_program_group) 
				{					
					unallocatedLessonsListView.Items.Remove(lviFromView);
					break;
				}
			}

		}

		public ArrayList [,] getTimetable() 
		{
			return _myTimetable;

		}

		public bool [,] getAllowedTimeSlots() 
		{
			return _allowedTimeSlots;
		}

		public void setAllowedTimeSlots(bool [,] allowedTimeSlots)
		{
			_allowedTimeSlots=allowedTimeSlots;
		}

		public bool getIsCourseInTimetable(Course edu_program_group)
		{
			int numOfLessonsPerWeek=edu_program_group.getNumberOfLessonsPerWeek();
			int counter=0;
			foreach(ListViewItem lvi in _unallocatedLessonsList)
			{
				Course courseFromList=(Course)lvi.Tag;
				if(courseFromList==edu_program_group) counter++;
			}

			if(counter==numOfLessonsPerWeek)
			{
				return false;

			}
			else
			{
				return true;
			}
		}


		public bool getIsTimetableEmpty()
		{
			int lengthX=_myTimetable.GetLength(0);
			int lengthY=_myTimetable.GetLength(1);

			for(int j=0;j<lengthX;j++)
			{
				for(int k=0;k<lengthY;k++)
				{
					ArrayList al=_myTimetable[j,k];
					if(al!=null)
					{
						if(al.Count>0)
						{
							return false;
						}
					}


				}

			}

			return true;

		}

		public static bool getIsEduProgramDataOK(EduProgram currEP,string epcode, string name, string semester)
		{
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
			{
				foreach(EduProgram ep in epg.Nodes)
				{
					if(ep!=currEP)
					{
						if((ep.getName()+ep.getSemester()).ToUpper()==(name+semester).ToUpper())
						{
							return false;
						}
					}
				}
			}


			return true;
		}

		public void setTimetable(ArrayList [,] myTimetable)
		{
			_myTimetable=myTimetable;
		}

		public string getReportTitle()
		{
			string reportTitle="";		
			string semStr="";

			reportTitle=_name.ToUpper();
			if(_code!=null) reportTitle+=" "+_code.ToUpper();

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{
				semStr=RES_MANAGER.GetString("setTreeText.semester.university.text");
				reportTitle+="/"+_semester.ToUpper()+semStr;
			}
			else
			{
				//
			}		

			return reportTitle;
		}

        public int SCStudentMaxHoursContinuously
        {
            get
            {
                return _scStudentMaxHoursContinuously;
            }
            set
            {
                _scStudentMaxHoursContinuously = value;
            }
        }

        public int SCStudentMaxHoursDaily
        {
            get
            {
                return _scStudentMaxHoursDaily;
            }
            set
            {
                _scStudentMaxHoursDaily = value;
            }
        }

        public int SCStudentMaxDaysPerWeek
        {
            get
            {
                return _scStudentMaxDaysPerWeek;
            }
            set
            {
                _scStudentMaxDaysPerWeek = value;
            }
        }


        public int SCStudentNoGapsGapIndicator
        {
            get
            {
                return _scStudentNoGapsGapIndicator;
            }
            set
            {
                _scStudentNoGapsGapIndicator = value;
            }
        }

        public int SCStudentPreferredStartTimePeriod
        {
            get
            {
                return _scStudentPreferredStartTimePeriod;
            }
            set
            {
                _scStudentPreferredStartTimePeriod = value;
            }
        }
		

	}
}
