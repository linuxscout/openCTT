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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for ModelOperations.
	/// </summary>
	public class ModelOperations
	{
		private static ResourceManager RES_MANAGER;	

		static ModelOperations()
		{
			RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.ModelOperations",typeof (ModelOperations).Assembly);
		}


		public static bool checkIfDayIsEmpty(int dayIndex)
		{
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{				
				foreach(EduProgram ep in epg.Nodes)
				{
					ArrayList [,] eptt = ep.getTimetable();

					for(int termCounter=0;termCounter<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;termCounter++)					
					{					
						ArrayList lessonsInOneTimeSlot = eptt[termCounter,dayIndex];
						if(lessonsInOneTimeSlot!=null) 
						{
							if(lessonsInOneTimeSlot.Count>0)
							{
								return false;
							}							
						}
						
					}
				}

			}

			return true;

		}


		public static void delDayInModel(int dayIndex, out ArrayList[] undoRedoLists)
		{
			undoRedoLists= new ArrayList[4];
			ArrayList eduProgramGroupsURList = new ArrayList();
			ArrayList eduProgramsURList = new ArrayList();
			ArrayList teachersURList = new ArrayList();
			ArrayList roomsURList = new ArrayList();
			undoRedoLists[0]= eduProgramGroupsURList;
			undoRedoLists[1]= eduProgramsURList;
			undoRedoLists[2]= teachersURList;
			undoRedoLists[3]= roomsURList;

			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{	
				bool [,] colAllowedTimeSlotsUR=new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,1];
				for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
				{
					colAllowedTimeSlotsUR[j,0]=epg.getAllowedTimeSlots()[j,dayIndex];					
				}

				object [] oneItemCol=new object[2];
				oneItemCol[0]=epg;
                oneItemCol[1]=colAllowedTimeSlotsUR;
                eduProgramGroupsURList.Add(oneItemCol);
				//

				epg.setAllowedTimeSlots(delDayInAllowedTimeSlots(epg.getAllowedTimeSlots(),dayIndex));

				foreach(EduProgram ep in epg.Nodes)
				{
					bool [,] epAllowedTimeSlotsUR=new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,1];
					for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
					{
						epAllowedTimeSlotsUR[j,0]=ep.getAllowedTimeSlots()[j,dayIndex];						
					}

					object [] oneItemEG=new object[2];
					oneItemEG[0]=ep;
					oneItemEG[1]=epAllowedTimeSlotsUR;
					eduProgramsURList.Add(oneItemEG);
					//

					ep.setAllowedTimeSlots(delDayInAllowedTimeSlots(ep.getAllowedTimeSlots(),dayIndex));

					ArrayList [,] newtt;
					ArrayList [,] eptt = ep.getTimetable();			

					newtt= new ArrayList[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,eptt.GetUpperBound(1)];

					for(int j=0;j<=eptt.GetUpperBound(0);j++)
					{
						for(int k=0;k<dayIndex;k++)
						{
							newtt[j,k]=eptt[j,k];
						}
					}

					for(int j=0;j<=eptt.GetUpperBound(0);j++)
					{
						for(int k=dayIndex+1;k<=eptt.GetUpperBound(1);k++)
						{
							newtt[j,k-1]=eptt[j,k];
						}
					}
					
					ep.setTimetable(newtt);
				}

			}

			//
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes) 
			{
				bool [,] roomAllowedTimeSlotsUR=new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,1];
				for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
				{
					roomAllowedTimeSlotsUR[j,0]=room.getAllowedTimeSlots()[j,dayIndex];
				}

				object [] oneItemRoom=new object[2];
				oneItemRoom[0]=room;
				oneItemRoom[1]=roomAllowedTimeSlotsUR;
				roomsURList.Add(oneItemRoom);
				//

                room.setAllowedTimeSlots(delDayInAllowedTimeSlots(room.getAllowedTimeSlots(),dayIndex));
			}

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes) 
			{
				bool [,] teacherAllowedTimeSlotsUR=new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,1];
				for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
				{
					teacherAllowedTimeSlotsUR[j,0]=teacher.getAllowedTimeSlots()[j,dayIndex];
				}

				object [] oneItemTeacher=new object[2];
				oneItemTeacher[0]=teacher;
				oneItemTeacher[1]=teacherAllowedTimeSlotsUR;
				teachersURList.Add(oneItemTeacher);
				//

				teacher.setAllowedTimeSlots(delDayInAllowedTimeSlots(teacher.getAllowedTimeSlots(),dayIndex));
			}

		}

		private static bool[,] delDayInAllowedTimeSlots(bool [,] allowedTimeSlots, int dayIndex)
		{			

			bool [,] newAllowedTimeSlots=new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,allowedTimeSlots.GetUpperBound(1)];

			for(int j=0;j<=allowedTimeSlots.GetUpperBound(0);j++)
			{
				for(int k=0;k<dayIndex;k++)
				{
					newAllowedTimeSlots[j,k]=allowedTimeSlots[j,k];
				}
			}

			for(int j=0;j<=allowedTimeSlots.GetUpperBound(0);j++)
			{
				for(int k=dayIndex+1;k<=allowedTimeSlots.GetUpperBound(1);k++)
				{
					newAllowedTimeSlots[j,k-1]=allowedTimeSlots[j,k];
				}
			}
					
			return newAllowedTimeSlots;

		}

		public static bool checkIfTermIsEmpty(int termIndex)
		{
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{				
				foreach(EduProgram ep in epg.Nodes)
				{
					ArrayList [,] eptt = ep.getTimetable();

					for(int dayCounter=0;dayCounter<AppForm.CURR_OCTT_DOC.getNumberOfDays();dayCounter++)
					{					
						ArrayList lessonsInOneTimeSlot = eptt[termIndex,dayCounter];
						if(lessonsInOneTimeSlot!=null) 
						{
							if(lessonsInOneTimeSlot.Count>0)
							{
								return false;
							}							
						}
						
					}
				}

			}

			return true;

		}

		public static void delTermInModel(int termIndex, out ArrayList[] undoRedoLists)
		{
			undoRedoLists= new ArrayList[4];
			ArrayList eduProgramGroupsURList = new ArrayList();
			ArrayList eduProgramsURList = new ArrayList();
			ArrayList teachersURList = new ArrayList();
			ArrayList roomsURList = new ArrayList();
			undoRedoLists[0]= eduProgramGroupsURList;
			undoRedoLists[1]= eduProgramsURList;
			undoRedoLists[2]= teachersURList;
			undoRedoLists[3]= roomsURList;

			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{
				//
				bool [,] colAllowedTimeSlotsUR=new bool[1,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
				for(int j=0;j<AppForm.CURR_OCTT_DOC.getNumberOfDays();j++)
				{
					colAllowedTimeSlotsUR[0,j]=epg.getAllowedTimeSlots()[termIndex,j];
				}

				object [] oneItemCol=new object[2];
				oneItemCol[0]=epg;
				oneItemCol[1]=colAllowedTimeSlotsUR;
				eduProgramGroupsURList.Add(oneItemCol);
				//

				epg.setAllowedTimeSlots(delTermInAllowedTimeSlots(epg.getAllowedTimeSlots(),termIndex));

				foreach(EduProgram ep in epg.Nodes)
				{
					bool [,] epAllowedTimeSlotsUR=new bool[1,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
					for(int j=0;j<AppForm.CURR_OCTT_DOC.getNumberOfDays();j++)
					{
						epAllowedTimeSlotsUR[0,j]=ep.getAllowedTimeSlots()[termIndex,j];
					}

					object [] oneItemEG=new object[2];
					oneItemEG[0]=ep;
					oneItemEG[1]=epAllowedTimeSlotsUR;
					eduProgramsURList.Add(oneItemEG);

					//
					ep.setAllowedTimeSlots(delTermInAllowedTimeSlots(ep.getAllowedTimeSlots(),termIndex));

					ArrayList [,] newtt;
					ArrayList [,] eptt = ep.getTimetable();					

					newtt= new ArrayList[eptt.GetUpperBound(0),eptt.GetUpperBound(1)+1];

					for(int j=0;j<termIndex;j++)
					{
						for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
						{
							newtt[j,k]=eptt[j,k];
						}
					}

					for(int j=termIndex+1;j<=eptt.GetUpperBound(0);j++)
					{
						for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
						{
							newtt[j-1,k]=eptt[j,k];
						}
					}
					
					ep.setTimetable(newtt);
				}

			}

			
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes) 
			{	
				bool [,] roomAllowedTimeSlotsUR=new bool[1,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
				for(int j=0;j<AppForm.CURR_OCTT_DOC.getNumberOfDays();j++)
				{
					roomAllowedTimeSlotsUR[0,j]=room.getAllowedTimeSlots()[termIndex,j];
				}

				object [] oneItemRoom=new object[2];
				oneItemRoom[0]=room;
				oneItemRoom[1]=roomAllowedTimeSlotsUR;
				roomsURList.Add(oneItemRoom);
				

				room.setAllowedTimeSlots(delTermInAllowedTimeSlots(room.getAllowedTimeSlots(),termIndex));
			}

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes) 
			{				
				bool [,] teacherAllowedTimeSlotsUR=new bool[1,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
				for(int j=0;j<AppForm.CURR_OCTT_DOC.getNumberOfDays();j++)
				{
					teacherAllowedTimeSlotsUR[0,j]=teacher.getAllowedTimeSlots()[termIndex,j];
				}

				object [] oneItemTeacher=new object[2];
				oneItemTeacher[0]=teacher;
				oneItemTeacher[1]=teacherAllowedTimeSlotsUR;
				teachersURList.Add(oneItemTeacher);
				
				teacher.setAllowedTimeSlots(delTermInAllowedTimeSlots(teacher.getAllowedTimeSlots(),termIndex));
			}

		}

		private static bool[,] delTermInAllowedTimeSlots(bool [,] allowedTimeSlots, int termIndex)
		{
			bool [,] newAllowedTimeSlots=new bool[allowedTimeSlots.GetUpperBound(0),allowedTimeSlots.GetUpperBound(1)+1];			

			for(int j=0;j<termIndex;j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					newAllowedTimeSlots[j,k]=allowedTimeSlots[j,k];
				}
			}

			for(int j=termIndex+1;j<=allowedTimeSlots.GetUpperBound(0);j++)
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					newAllowedTimeSlots[j-1,k]=allowedTimeSlots[j,k];
				}
			}
			//
			
					
			return newAllowedTimeSlots;

		}

		public static void addDayInModel(int dayIndex)
		{
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{
				epg.setAllowedTimeSlots(addDayInAllowedTimeSlots(epg.getAllowedTimeSlots(),dayIndex));

				foreach(EduProgram ep in epg.Nodes)
				{
					ep.setAllowedTimeSlots(addDayInAllowedTimeSlots(ep.getAllowedTimeSlots(),dayIndex));

					ArrayList [,] newtt;
					ArrayList [,] eptt = ep.getTimetable();					

					newtt= new ArrayList[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,eptt.GetUpperBound(1)+2];

					for(int j=0;j<=eptt.GetUpperBound(0);j++)
					{
						for(int k=0;k<dayIndex;k++)
						{
							newtt[j,k]=eptt[j,k];
						}
					}

					for(int j=0;j<=eptt.GetUpperBound(0);j++)
					{
						newtt[j,dayIndex]=null;
					}

					for(int j=0;j<=eptt.GetUpperBound(0);j++)
					{
						for(int k=dayIndex+1;k<=eptt.GetUpperBound(1)+1;k++)
						{
							newtt[j,k]=eptt[j,k-1];
						}
					}
					
					ep.setTimetable(newtt);
				}

			}

			//
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes) 
			{
				room.setAllowedTimeSlots(addDayInAllowedTimeSlots(room.getAllowedTimeSlots(),dayIndex));
			}

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes) 
			{
				teacher.setAllowedTimeSlots(addDayInAllowedTimeSlots(teacher.getAllowedTimeSlots(),dayIndex));
			}

		}

		private static bool[,] addDayInAllowedTimeSlots(bool [,] allowedTimeSlots, int dayIndex)
		{
			bool [,] newAllowedTimeSlots=new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,allowedTimeSlots.GetUpperBound(1)+2];
			
			for(int j=0;j<=allowedTimeSlots.GetUpperBound(0);j++)
			{
				for(int k=0;k<dayIndex;k++)
				{
					newAllowedTimeSlots[j,k]=allowedTimeSlots[j,k];
				}
			}

			for(int j=0;j<=allowedTimeSlots.GetUpperBound(0);j++)
			{
				newAllowedTimeSlots[j,dayIndex]=true;
			}

			for(int j=0;j<=allowedTimeSlots.GetUpperBound(0);j++)
			{
				for(int k=dayIndex+1;k<=allowedTimeSlots.GetUpperBound(1)+1;k++)
				{
					newAllowedTimeSlots[j,k]=allowedTimeSlots[j,k-1];
				}
			}
					
			return newAllowedTimeSlots;

		}

		public static void addTermInModel(int termIndex)
		{
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{
				epg.setAllowedTimeSlots(addTermInAllowedTimeSlots(epg.getAllowedTimeSlots(),termIndex));

				foreach(EduProgram ep in epg.Nodes)
				{
					ep.setAllowedTimeSlots(addTermInAllowedTimeSlots(ep.getAllowedTimeSlots(),termIndex));

					ArrayList [,] newtt;
					ArrayList [,] eptt = ep.getTimetable();					

					newtt= new ArrayList[eptt.GetUpperBound(0)+2,eptt.GetUpperBound(1)+1];

					for(int j=0;j<termIndex;j++)
					{
						for(int k=0;k<eptt.GetUpperBound(1)+1;k++)
						{
							newtt[j,k]=eptt[j,k];
						}
					}

					for(int k=0;k<eptt.GetUpperBound(1)+1;k++)
					{
						newtt[termIndex,k]=null;
					}

					for(int j=termIndex+1;j<eptt.GetUpperBound(0)+2;j++)
					{
						for(int k=0;k<eptt.GetUpperBound(1)+1;k++)
						{
							newtt[j,k]=eptt[j-1,k];
						}
					}
					
					ep.setTimetable(newtt);
				}

			}

			//
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes) 
			{
				room.setAllowedTimeSlots(addTermInAllowedTimeSlots(room.getAllowedTimeSlots(),termIndex));
			}

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes) 
			{
				teacher.setAllowedTimeSlots(addTermInAllowedTimeSlots(teacher.getAllowedTimeSlots(),termIndex));
			}

		}

		private static bool[,] addTermInAllowedTimeSlots(bool [,] allowedTimeSlots, int termIndex)
		{
			bool [,] newAllowedTimeSlots=new bool[allowedTimeSlots.GetUpperBound(0)+2,allowedTimeSlots.GetUpperBound(1)+1];
			
			for(int j=0;j<termIndex;j++)
			{
				for(int k=0;k<allowedTimeSlots.GetUpperBound(1)+1;k++)
				{
					newAllowedTimeSlots[j,k]=allowedTimeSlots[j,k];
				}
			}

			for(int k=0;k<allowedTimeSlots.GetUpperBound(1)+1;k++)
			{
				newAllowedTimeSlots[termIndex,k]=true;
			}

			for(int j=termIndex+1;j<allowedTimeSlots.GetUpperBound(0)+2;j++)
			{
				for(int k=0;k<allowedTimeSlots.GetUpperBound(1)+1;k++)
				{
					newAllowedTimeSlots[j,k]=allowedTimeSlots[j-1,k];
				}
			}
					
			return newAllowedTimeSlots;

		}

		public static ArrayList[,] cloneMyTimetable(ArrayList [,] ttForCopy)
		{
			ArrayList [,] newTimetable=new ArrayList[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];
			
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{
					ArrayList lessonsInOneTimeSlot = ttForCopy[j,k];
					if(lessonsInOneTimeSlot!=null && lessonsInOneTimeSlot.Count>0)
					{
						ArrayList newTerm=new ArrayList();

						for(int step=0;step<lessonsInOneTimeSlot.Count;step++)
						{
							IEnumerator enumerator=lessonsInOneTimeSlot.GetEnumerator();
							enumerator.MoveNext();
							Object [] courseAndRoomPair=(Object [])enumerator.Current;								
							Course edu_program_group = (Course)courseAndRoomPair[0];
							Room room = (Room)courseAndRoomPair[1];

							Object [] newCourseAndRoomPair=new Object[2];
							newCourseAndRoomPair[0]=edu_program_group;
							newCourseAndRoomPair[1]=room;
							newTerm.Add(newCourseAndRoomPair);
						}

						newTimetable[j,k]=newTerm;
					}
				}
			}

			return newTimetable;

		}

		public static void searchForStringInDocument(string searchFor,System.Windows.Forms.ListView resultsListView,int typeFor)
		{
			resultsListView.Items.Clear();
			try
			{

				Regex r = new Regex(searchFor);

				if(typeFor==0)
				{

					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
					{				
						Match m = r.Match(epg.getName()); 						

						if (m.Success)
						{					
							TreeNode tn=(TreeNode) epg;							

                            ListViewItem lvi;							
							if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
							{				
								lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.epg.university.name.text")+" "+epg.getName());

							}
							else
							{			
								lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.epg.school.name.text")+" "+epg.getName());
							}
							
							lvi.Tag=tn;
							lvi.ImageIndex=1;
							resultsListView.Items.Add(lvi);
						}

						foreach(EduProgram ep in epg.Nodes)
						{
							///
							m = r.Match(ep.getName()); 

							if (m.Success)
							{					
								TreeNode tn=(TreeNode) ep;
								
								ListViewItem lvi;							
								if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
								{				
									lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.ep.university.name.text")+" "+ep.Text);

								}
								else
								{			
									lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.ep.school.name.text")+" "+ep.Text);
								}
								
								lvi.Tag=tn; 
								lvi.ImageIndex=2;
								resultsListView.Items.Add(lvi);
							}
							///
					
							if(ep.getCode()!=null)
							{
								m = r.Match(ep.getCode()); 

								if (m.Success)
								{					
									TreeNode tn=(TreeNode) ep;									

									ListViewItem lvi;							
									if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
									{				
										lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.ep.university.code.text")+" "+ep.Text);

									}
									else
									{			
										lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.ep.school.code.text")+" "+ep.Text);
									}
								
									lvi.Tag=tn;
									lvi.ImageIndex=2;
									resultsListView.Items.Add(lvi);
								}
							}

							///
					
							m = r.Match(ep.getSemester()); 

							if (m.Success)
							{					
								TreeNode tn=(TreeNode) ep;
								
								ListViewItem lvi;							
								if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
								{				
									lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.ep.university.semester.text")+" "+ep.Text);

								}
								else
								{			
									lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.ep.school.semester.text")+" "+ep.Text);
								}
								
								lvi.Tag=tn;
								lvi.ImageIndex=2;
								resultsListView.Items.Add(lvi);
							}

							///
							foreach(Course edu_program_group in ep.Nodes)
							{
								m = r.Match(edu_program_group.getName()); 

								if (m.Success)
								{					
									TreeNode tn=(TreeNode) edu_program_group;									
									ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.course.name.text")+" "+edu_program_group.getFullName());
									lvi.Tag=tn;
									lvi.ImageIndex=3;
									resultsListView.Items.Add(lvi);
								}
								//
								m = r.Match(edu_program_group.getShortName()); 

								if (m.Success)
								{					
									TreeNode tn=(TreeNode) edu_program_group;									
									ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.course.shortname.text")+" "+edu_program_group.getFullName());
									lvi.Tag=tn;
									lvi.ImageIndex=3;
									resultsListView.Items.Add(lvi);
								}
								//
								m = r.Match(System.Convert.ToString(edu_program_group.getNumberOfLessonsPerWeek())); 

								if (m.Success)
								{					
									TreeNode tn=(TreeNode) edu_program_group;									
									ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.course.numoflessperweek.text")+" "+edu_program_group.getFullName());
									lvi.Tag=tn;
									lvi.ImageIndex=3;
									resultsListView.Items.Add(lvi);
								}
								//
								m = r.Match(System.Convert.ToString(edu_program_group.getNumberOfEnrolledStudents())); 

								if (m.Success)
								{					
									TreeNode tn=(TreeNode) edu_program_group;									
									ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.course.numofenrolledstud.text")+" "+edu_program_group.getFullName());
									lvi.Tag=tn;
									lvi.ImageIndex=3;
									resultsListView.Items.Add(lvi);
								}
								//
								m = r.Match(edu_program_group.getGroupName()); 

								if (m.Success)
								{					
									TreeNode tn=(TreeNode) edu_program_group;									
									ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.course.groupname.text")+" "+edu_program_group.getFullName());
									lvi.Tag=tn;
									lvi.ImageIndex=3;
									resultsListView.Items.Add(lvi);
								}


							}


						}


					}
				}
				else if(typeFor==1)
				{
					
					foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
					{		
						
						Match m = r.Match(teacher.getName()); 

						if (m.Success)
						{					
							TreeNode tn=(TreeNode) teacher;							
							ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.teacher.name.text")+" "+teacher.Text);
							lvi.Tag=tn;
							lvi.ImageIndex=6;
							resultsListView.Items.Add(lvi);
						}

						//
						m = r.Match(teacher.getLastName()); 

						if (m.Success)
						{					
							TreeNode tn=(TreeNode) teacher;							
							ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.teacher.lastname.text")+" "+teacher.Text);
							lvi.Tag=tn;
							lvi.ImageIndex=6;
							resultsListView.Items.Add(lvi);
						}
						//
						if(teacher.getTitle()!=null)
						{
							m = r.Match(teacher.getTitle()); 

							if (m.Success)
							{					
								TreeNode tn=(TreeNode) teacher;								
								ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.teacher.title.text")+" "+teacher.Text);
								lvi.Tag=tn;
								lvi.ImageIndex=6;
								resultsListView.Items.Add(lvi);
							}
						}
						//
						if(teacher.getEduRank()!=null)
						{
							m = r.Match(teacher.getEduRank()); 

							if (m.Success)
							{					
								TreeNode tn=(TreeNode) teacher;								
								ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.teacher.edurank.text")+" "+teacher.Text);
								lvi.Tag=tn;
								lvi.ImageIndex=6;
								resultsListView.Items.Add(lvi);
							}
						}
					}

				}
				else if(typeFor==2)
				{
					foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
					{				
						Match m = r.Match(room.getName()); 

						if (m.Success)
						{					
							TreeNode tn=(TreeNode) room;							
							ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.room.name.text")+" "+room.TextForList);
							lvi.Tag=tn;
							lvi.ImageIndex=4;
							resultsListView.Items.Add(lvi);
						}

						//
						m = r.Match(System.Convert.ToString(room.getRoomCapacity())); 

						if (m.Success)
						{					
							TreeNode tn=(TreeNode) room;							
							ListViewItem lvi=new ListViewItem(RES_MANAGER.GetString("searchfor.room.capacity.text")+" "+room.TextForList);
							lvi.Tag=tn;
							lvi.ImageIndex=4;
							resultsListView.Items.Add(lvi);
						}					
					}

				}
			}
			catch
			{

			}
			
		}

		

		public static ArrayList getPdfSharpReportDataTablesList(ArrayList listForPrint, int reportType)
		{
			Cursor.Current=Cursors.WaitCursor;

            ArrayList reportTablesList = new ArrayList();			

			///
			int rowCount=AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
			
			int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();
			

			foreach(Object obj in listForPrint)
			{
				Object [] reportGroupAndTable = new object[2];

				DataTable gdt = new DataTable();				
				for(int dd=0;dd<columnCount;dd++)
				{
					gdt.Columns.Add("Day"+(dd+1));
				}
				
                
				ArrayList [,] mytt=null;
				Teacher teacher=null;
				Room room = null;
				string grName=null;

				if(obj is EduProgram)
				{
					EduProgram ep = (EduProgram)obj;
					mytt = ep.getTimetable();					
					grName= ep.getReportTitle();
				}
				else if(obj is Teacher)
				{
					teacher = (Teacher)obj;
					grName= teacher.getReportTitle();					
				}
				else if(obj is Room)
				{
					room = (Room)obj;					
					grName=room.getReportTitle();
				}

				reportGroupAndTable[0]=grName;	

				int foundInOneTSForTeacherAndRoom;

				for(int j=0;j<rowCount;j++) 
				{	
			        DataRow dr=gdt.NewRow();				

					for(int k=0;k<columnCount;k++) 
					{	
						string timeSlotText="";
						dr["Day"+(k+1)]=timeSlotText;

						foundInOneTSForTeacherAndRoom=1;
				
						if(reportType==1)
						{
							ArrayList lessonsInOneTimeSlot = mytt[j,k];
							if(lessonsInOneTimeSlot!=null && lessonsInOneTimeSlot.Count!=0) 
							{
								int helpCounter=1;
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{							
									Room room11 = (Room)courseAndRoomPair[1];
									
									Course course=(Course)courseAndRoomPair[0];
                                    Teacher tcr = course.getTeacher();
                                    string teacherText = tcr.getName().Substring(0,1)+ ". " + tcr.getLastName();
									
                                    //string courseName=course.getReportName();

                                    string courseName;
                                    if (Settings.TTREP_COURSE_FORMAT == 1)
                                    {
                                        courseName = course.getFullName();
                                    }
                                    else
                                    {
                                        courseName = course.getReportName();
                                    }

									string roomName=room11.getName();

									if(helpCounter==1)
									{
										timeSlotText+=courseName+" @ "+roomName;
								
									}							
									else
									{
										timeSlotText+="\n"+courseName+" @ "+roomName;
									}

                                    if (Settings.TTREP_PRINT_TEACHER_IN_TS == 1)
                                    {
                                        timeSlotText += " (" + teacherText + ")";
                                    }

									helpCounter++;
								}

								dr["Day"+(k+1)]=timeSlotText;			
						
							}							
						}
						else if(reportType==2)
						{
							string lastUsedCourseName2=null;

							foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
							{
								foreach(EduProgram ep in epg.Nodes)
								{
									ArrayList [,] myttT = ep.getTimetable();
									ArrayList lessonsInOneTimeSlot = myttT[j,k];
									if(lessonsInOneTimeSlot!=null && lessonsInOneTimeSlot.Count!=0)
									{										
										foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
										{	
											Course course = (Course)courseAndRoomPair[0];
											Teacher teacherFromModel=course.getTeacher();	
											if(teacherFromModel==teacher)
											{										
												Room room2 = (Room)courseAndRoomPair[1];
												//string courseName=course.getReportName();
                                                string courseName;
                                                if (Settings.TTREP_COURSE_FORMAT == 1)
                                                {
                                                    courseName = course.getFullName();
                                                }
                                                else
                                                {
                                                    courseName = course.getReportName();
                                                }


												string roomName=room2.getName();

												if(foundInOneTSForTeacherAndRoom==1)
												{
													timeSlotText+=courseName+" @ "+roomName;								
												}							
												else
												{
													if(courseName!=lastUsedCourseName2)
													{
														timeSlotText+="\n"+courseName+" @ "+roomName;
													}													
												}

												lastUsedCourseName2=courseName;

												foundInOneTSForTeacherAndRoom++;
											}
										}

										dr["Day"+(k+1)]=timeSlotText;
									}									
								}
							}
							
						}
						else if(reportType==3)
						{
							string lastUsedCourseName3=null;

							foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
							{
								foreach(EduProgram ep in epg.Nodes)
								{
									ArrayList [,] myttR = ep.getTimetable();
									ArrayList lessonsInOneTimeSlot = myttR[j,k];
									if(lessonsInOneTimeSlot!=null && lessonsInOneTimeSlot.Count!=0)
									{	
										foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
										{	
	
											Room roomFromModel = (Room)courseAndRoomPair[1];
											
											if(roomFromModel==room)
											{
												Course course = (Course)courseAndRoomPair[0];
                                                Teacher tcr = course.getTeacher();                                                
                                                string teacherText = tcr.getName().Substring(0, 1) + ". " + tcr.getLastName();

												EduProgram ep3=(EduProgram)course.Parent;
												string codeAndSem=ep3.getCode()+"/"+ep3.getSemester();
												
												//string courseName=course.getReportName();												
                                                string courseName;
                                                if (Settings.TTREP_COURSE_FORMAT == 1)
                                                {
                                                    courseName = course.getFullName();
                                                }
                                                else
                                                {
                                                    courseName = course.getReportName();
                                                }

												if(foundInOneTSForTeacherAndRoom==1)
												{
													timeSlotText+=courseName+" @ "+codeAndSem;
												}						
												else
												{
													if(courseName==lastUsedCourseName3)
													{
														timeSlotText+=", "+codeAndSem;
													}
													else
													{
														timeSlotText+="\n"+courseName+" @ "+codeAndSem;
													}
												}

                                                if (Settings.TTREP_PRINT_TEACHER_IN_TS == 1)
                                                {
                                                    timeSlotText += " (" + teacherText + ")";
                                                }

												lastUsedCourseName3=courseName;

												foundInOneTSForTeacherAndRoom++;
												
											}
										}

										dr["Day"+(k+1)]=timeSlotText;
									}									
								}
							}
							
						}
					}	
		
					gdt.Rows.Add(dr);

				}

				reportGroupAndTable[1]=gdt;

				reportTablesList.Add(reportGroupAndTable);
			}


            return reportTablesList;

		}


        public static DataTable getPdfSharpMasterTimetableDataTable()
        {
            DataTable gdt = new DataTable();

            int timePeriodsCount=AppForm.CURR_OCTT_DOC.IncludedTerms.Count;			
			int daysCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();
            int totalColumnNumber = timePeriodsCount * daysCount;

            gdt.Columns.Add("Col_0");
                        
            for (int dd = 0; dd < totalColumnNumber; dd++)
            {   
                gdt.Columns.Add("Col_" + (dd+1));
            }


            foreach (EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
            {
                foreach (EduProgram ep in epg.Nodes)
                {
                    DataRow dr = gdt.NewRow();
                    dr[0] = ep.getName();
                    if (ep.getCode() != null && ep.getCode() != "")
                    {
                        dr[0] += " (" + ep.getCode()+"/"+ep.getSemester()+")";
                    }
                    else
                    {
                        dr[0] += " (" + ep.getSemester() + ")";
                    }
                    
                    
                    //

                    int drColIndex = 0;


                    for (int k = 0; k < daysCount; k++)
                    {
                        for (int j = 0; j < timePeriodsCount; j++)
                        {
                            drColIndex++;
                            string drColText = "";
                            dr[drColIndex] = drColText;
                            
                            ArrayList[,] mytt = ep.getTimetable();
                            ArrayList lessonsInOneTimeSlot = mytt[j, k];
                            if(lessonsInOneTimeSlot!=null && lessonsInOneTimeSlot.Count!=0) 
							{
								int helpCounter=1;
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{							
									Room room11 = (Room)courseAndRoomPair[1];
									
									Course course=(Course)courseAndRoomPair[0];
                                    Teacher tcr = course.getTeacher();
                                    string teacherText = tcr.getName().Substring(0,1)+ ". " + tcr.getLastName();
									
                                    //string courseName=course.getReportName();

                                    string courseName;
                                    if (Settings.TTREP_COURSE_FORMAT == 1)
                                    {
                                        courseName = course.getFullName();
                                    }
                                    else
                                    {
                                        courseName = course.getReportName();
                                    }

									string roomName=room11.getName();

									if(helpCounter==1)
									{
                                        drColText += courseName + " @ " + roomName;
								
									}							
									else
									{
                                        drColText += "\n" + courseName + " @ " + roomName;
									}

                                    if (Settings.TTREP_PRINT_TEACHER_IN_TS == 1)
                                    {
                                        drColText += " (" + teacherText + ")";
                                    }

									helpCounter++;
								}

                                dr[drColIndex] = drColText;
                            }
                        }
                    }                  

                    ///

                    gdt.Rows.Add(dr);
                }
            }

            return gdt;
        }

	}
}
