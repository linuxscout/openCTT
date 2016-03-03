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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for HardConstraintChecks.
	/// </summary>
	public class HardConstraintChecks
	{
	
		public HardConstraintChecks()
		{
		}

		public static ArrayList findAllFreeTimeSlots(Course dragedCourse)
		{
			ArrayList notPossibleTimeSlots = new ArrayList();			
			Teacher dragedTeacher = dragedCourse.getTeacher();
			
			EduProgram currEP=(EduProgram)dragedCourse.Parent;
			EduProgramGroup epg = (EduProgramGroup)currEP.Parent;

			ArrayList [,] currTimetable = currEP.getTimetable();

			ArrayList possibleRooms = HardConstraintChecks.getPossibleRoomsRelCapacity(dragedCourse);
			

			
			foreach(TimeSlotPanel tsp in AppForm.getAppForm().getMainTimetablePanel().Controls) 
			{				
				//check if time slot is possible in relation with allowed time slots for EduProgramGroup
				markNotPossibleTimeSlotsRelEduProgramGroup(epg,tsp,notPossibleTimeSlots);
				if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
				{
					foreach(Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
					{
						EduProgram epHT=(EduProgram)edu_program_group.Parent;
						EduProgramGroup epgHT = (EduProgramGroup)epHT.Parent;
						markNotPossibleTimeSlotsRelEduProgramGroup(epgHT,tsp,notPossibleTimeSlots);
					}
				}

                //check if time slot is possible in relation with allowed time slots for EduProgram
				markNotPossibleTimeSlotsRelEduProgram(currEP,tsp,notPossibleTimeSlots);
				if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
				{
					foreach(Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
					{
						EduProgram epHT=(EduProgram)edu_program_group.Parent;
						markNotPossibleTimeSlotsRelEduProgram(epHT,tsp,notPossibleTimeSlots);
					}
				}

				
				//check in relation with groups
				ArrayList lessonsInOneTimeSlot = currTimetable[tsp.getIndexRow(),tsp.getIndexCol()];
				markNotPossibleTimeSlotsRelGroup(lessonsInOneTimeSlot,tsp, dragedCourse,notPossibleTimeSlots);
				if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
				{
					foreach(Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
					{
						EduProgram epHT=(EduProgram)edu_program_group.Parent;
						ArrayList [,] myttHT = epHT.getTimetable();
						ArrayList lessonsInOneTimeSlotHT = myttHT[tsp.getIndexRow(),tsp.getIndexCol()];
						markNotPossibleTimeSlotsRelGroup(lessonsInOneTimeSlotHT,tsp, edu_program_group,notPossibleTimeSlots);
					}
				}

				
				//check if teacher is free for time slot
				markNotPossibleTimeSlotsRelTeacher(tsp, dragedTeacher,notPossibleTimeSlots);

				//check if there is any room with capacity greater than number
				//of enrolled students for draged edu_program_group, that is free for this time slot,
				// and with time slot allowed in definition of allowed time slots for room
				markNotPossibleTimeSlotsRelRoom(tsp,possibleRooms,notPossibleTimeSlots);

			}
			return notPossibleTimeSlots;
		}
	

		private static void markNotPossibleTimeSlotsRelEduProgram(EduProgram ep, TimeSlotPanel tsp,ArrayList notPossibleTimeSlots)
		{
			if(!notPossibleTimeSlots.Contains(tsp))
			{
				if(ep.getAllowedTimeSlots()[tsp.getIndexRow(),tsp.getIndexCol()]==false)
				{
					tsp.BackColor=System.Drawing.Color.DarkSalmon;
					tsp.AllowDrop=false;
					notPossibleTimeSlots.Add(tsp);
				}
			}
		}

		private static void markNotPossibleTimeSlotsRelEduProgramGroup(EduProgramGroup epg,TimeSlotPanel tsp,ArrayList notPossibleTimeSlots)
		{		
			if(epg.getAllowedTimeSlots()[tsp.getIndexRow(),tsp.getIndexCol()]==false)
			{
				tsp.BackColor=System.Drawing.Color.DarkSalmon;
				tsp.AllowDrop=false;
				notPossibleTimeSlots.Add(tsp);
			}
		}
	

		private static void markNotPossibleTimeSlotsRelGroup(ArrayList lessonsInOneTimeSlot, TimeSlotPanel tsp, Course dragedCourse, ArrayList notPossibleTimeSlots)
		{
			if(lessonsInOneTimeSlot!=null)
			{
				int n=0;
				foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
				{
					n++;					
					Course edu_program_group = (Course)courseAndRoomPair[0];
					if(!edu_program_group.getIsGroup())
					{						
						ArrayList subLabels= tsp.getAllSubLabels();
						foreach(Label [] courseRoomLabel in subLabels) 
						{
							Label courseLabel = courseRoomLabel[0];
							Label roomLabel = courseRoomLabel[1];

							if(courseLabel.Tag!=null)
							{
								if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
								{	
									courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
									roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
								}
								else
								{
									Course courseTag=(Course)courseLabel.Tag;
									if(courseTag==dragedCourse)
									{	
										courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
										roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
									}
									else
									{
										courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
										roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
									}
								}
							}
							else
							{
								if(edu_program_group!=dragedCourse)
								{
									courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
									roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
								}
								else
								{	
									courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
									roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
								}
							}
						
						
						}

						tsp.BackColor=System.Drawing.Color.DarkSalmon;
						tsp.AllowDrop=false;
						notPossibleTimeSlots.Add(tsp);
						
					} 
					else 
					{
						if(!dragedCourse.getIsGroup()) 
						{
							ArrayList subLabels= tsp.getAllSubLabels();
							foreach(Label [] courseRoomLabel in subLabels) 
							{
								Label courseLabel = courseRoomLabel[0];
								Label roomLabel = courseRoomLabel[1];

								courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
								roomLabel.BackColor=System.Drawing.Color.DarkSalmon;								

							}

							tsp.BackColor=System.Drawing.Color.DarkSalmon;
							tsp.AllowDrop=false;
							notPossibleTimeSlots.Add(tsp);

						} 
						else 
						{
							if(edu_program_group.getGroupName()==dragedCourse.getGroupName()) 
							{
								ArrayList subLabels= tsp.getAllSubLabels();
								int stepIn=0;
								foreach(Label [] courseRoomLabel in subLabels) 
								{
									stepIn++;

									Label courseLabel = courseRoomLabel[0];
									Label roomLabel = courseRoomLabel[1];

									if(courseLabel.Tag!=null)
									{
										if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
										{	
											courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
											roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
										}
										else
										{
											Course courseTag=(Course)courseLabel.Tag;
											if(courseTag==dragedCourse)
											{	
												courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
												roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
											}
											else
											{
												courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
												roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
											}
										}
									}
									else
									{
									
										if(stepIn!=n)
										{
											courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
											roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
										}
										else
										{
											if(edu_program_group!=dragedCourse)
											{
												courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
												roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
											}
											else
											{	
												courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
												roomLabel.BackColor=System.Drawing.Color.DarkSalmon;
											}

										}
									}
								}

								tsp.BackColor=System.Drawing.Color.DarkSalmon;
								tsp.AllowDrop=false;
								notPossibleTimeSlots.Add(tsp);
							}

						}

					}

				}
			}		

		}		


		private static void markNotPossibleTimeSlotsRelTeacher(TimeSlotPanel tsp,Teacher dragedTeacher,ArrayList notPossibleTimeSlots)
		{
			if(!notPossibleTimeSlots.Contains(tsp))
			{
				
				if(dragedTeacher.getAllowedTimeSlots()[tsp.getIndexRow(),tsp.getIndexCol()])				
				{					
					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
					{				
						foreach(EduProgram ep in epg.Nodes)
						{
							ArrayList [,] eptt = ep.getTimetable();
							ArrayList lessonsInOneTimeSlot = eptt[tsp.getIndexRow(),tsp.getIndexCol()];
							if(lessonsInOneTimeSlot!=null) 
							{
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{									
									Course edu_program_group = (Course)courseAndRoomPair[0];
									Teacher teacher = edu_program_group.getTeacher();							
									if(teacher==dragedTeacher)
									{
										tsp.BackColor=System.Drawing.Color.DarkSalmon;
										tsp.AllowDrop=false;
										notPossibleTimeSlots.Add(tsp);

										ArrayList subLabels= tsp.getAllSubLabels();
										foreach(Label [] courseRoomLabel in subLabels) 
										{
											Label courseLabel = courseRoomLabel[0];
											Label roomLabel = courseRoomLabel[1];

											courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
											roomLabel.BackColor=System.Drawing.Color.DarkSalmon;									
										}

										goto stop;
									}
								}
							}


						}

					}
				stop:;
			
				}
				else
				{
					tsp.BackColor=System.Drawing.Color.DarkSalmon;
					tsp.AllowDrop=false;
					notPossibleTimeSlots.Add(tsp);

					ArrayList subLabels= tsp.getAllSubLabels();
					foreach(Label [] courseRoomLabel in subLabels) 
					{
						Label courseLabel = courseRoomLabel[0];
						Label roomLabel = courseRoomLabel[1];

						courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
						roomLabel.BackColor=System.Drawing.Color.DarkSalmon;									
					}

				}
			}			

		}


		private static void markNotPossibleTimeSlotsRelRoom(TimeSlotPanel tsp,ArrayList possibleRooms,ArrayList notPossibleTimeSlots)
		{
			if(!notPossibleTimeSlots.Contains(tsp)) 
			{
				int indexRow = tsp.getIndexRow();
				int indexCol = tsp.getIndexCol();
				ArrayList possibleRoomsCopy=HardConstraintChecks.getPossibleRoomsRelTimeSlot(possibleRooms, indexRow, indexCol);
			

				//
				if(possibleRoomsCopy.Count==0) 
				{
					tsp.BackColor=System.Drawing.Color.DarkSalmon;
					tsp.AllowDrop=false;
					notPossibleTimeSlots.Add(tsp);

					ArrayList subLabels= tsp.getAllSubLabels();
					foreach(Label [] courseRoomLabel in subLabels) 
					{
						Label courseLabel = courseRoomLabel[0];
						Label roomLabel = courseRoomLabel[1];

						courseLabel.BackColor=System.Drawing.Color.DarkSalmon;
						roomLabel.BackColor=System.Drawing.Color.DarkSalmon;									
					}

				}

			}

		}


		public static ArrayList getPossibleRoomsRelCapacity(Course dragedCourse)
		{
			ArrayList possibleRooms = new ArrayList();
			Teacher dragedTeacher = (Teacher)dragedCourse.getTeacher();
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				if(dragedTeacher.getAllowedRoomsList()==null || dragedTeacher.getAllowedRoomsList().Contains(room))
				{
					if(dragedCourse.getAllowedRoomsList()==null || dragedCourse.getAllowedRoomsList().Contains(room))
					{
						bool allowed=true;
						int minCapacity=dragedCourse.getNumberOfEnrolledStudents();

						if(dragedCourse.getCoursesToHoldTogetherList().Count>0)
						{
							foreach(Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
							{
								if(!(edu_program_group.getAllowedRoomsList()==null || edu_program_group.getAllowedRoomsList().Contains(room)))
								{
                                    allowed=false;
									break;
								}

								minCapacity+=edu_program_group.getNumberOfEnrolledStudents();
							}

						}

						if(room.getRoomCapacity()>=minCapacity)
						{
							if(allowed)
							{
								possibleRooms.Add(room);
							}
						}
					}
				}
			}

			return possibleRooms;

		}


		public static ArrayList getPossibleRoomsRelTimeSlot(ArrayList possibleRooms, int indexRow,int indexCol)
		{
			ArrayList possibleRoomsCopy = (ArrayList)possibleRooms.Clone();
			foreach(Room room in possibleRooms) 
			{
				if(room.getAllowedTimeSlots()[indexRow,indexCol]==true)
				{
					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
					{				
						foreach(EduProgram ep in epg.Nodes)
						{
							ArrayList [,] eptt = ep.getTimetable();
							ArrayList lessonsInOneTimeSlot = eptt[indexRow,indexCol];
							if(lessonsInOneTimeSlot!=null) 
							{
								foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
								{
									Room roomFromModel = (Room)courseAndRoomPair[1];									
									if(roomFromModel==room)
									{
										possibleRoomsCopy.Remove(room);
										goto stop;										
										
									}
								}
							}


						}

					}

				stop:;

				}
				else
				{
					possibleRoomsCopy.Remove(room);
				}
			}

			return possibleRoomsCopy;

		}


		public static bool checkIfTitleOfTeacherIsFreeForDelete(Teacher myTeacher)
		{
			bool isFree=true;

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{
				if(teacher!=myTeacher)
				{
					if(teacher.getTitle()==myTeacher.getTitle())
					{
						isFree=false;
						break;
					}
				}
			}

			return isFree;

		}


		public static bool checkIfEduRankOfTeacherIsFreeForDelete(Teacher myTeacher)
		{
			bool isFree=true;

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{
				if(teacher!=myTeacher)
				{
					if(teacher.getEduRank()==myTeacher.getEduRank())
					{
						isFree=false;
						break;
					}
				}
			}

			return isFree;

		}


		public static bool checkIfCourseTypeIsFreeForDelete(Course myCourse)
		{
			bool isFree=true;

			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
			{
				foreach(EduProgram ep in epg.Nodes)
				{
					foreach(Course edu_program_group in ep.Nodes)
					{						
						if(edu_program_group!=myCourse)
						{
							if(edu_program_group.CourseType==myCourse.CourseType)
							{
								isFree=false;
								break;
							}
						}
						
					}
				}
			}

			return isFree;

		}

        public static ArrayList findAllFreeTimeSlotsForRoomsView(Course dragedCourse, Room currRoom)
        {
            ArrayList notPossibleTimeSlots = new ArrayList();
            Teacher dragedTeacher = dragedCourse.getTeacher();

            EduProgram currEP = (EduProgram)dragedCourse.Parent;
            EduProgramGroup epg = (EduProgramGroup)currEP.Parent;

            ArrayList[,] currTimetable = currEP.getTimetable();

            ArrayList possibleRooms = new ArrayList();
            possibleRooms.Add(currRoom);


            foreach (TimeSlotPanel tsp in AppForm.getAppForm().getMainTimetablePanel().Controls)
            {
                //check if time slot is possible in relation with allowed time slots for EduProgramGroup
                markNotPossibleTimeSlotsRelEduProgramGroup(epg, tsp, notPossibleTimeSlots);
                if (dragedCourse.getCoursesToHoldTogetherList().Count > 0)
                {
                    foreach (Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
                    {
                        EduProgram epHT = (EduProgram)edu_program_group.Parent;
                        EduProgramGroup epgHT = (EduProgramGroup)epHT.Parent;
                        markNotPossibleTimeSlotsRelEduProgramGroup(epgHT, tsp, notPossibleTimeSlots);
                    }
                }

                //check if time slot is possible in relation with allowed time slots for EduProgram
                markNotPossibleTimeSlotsRelEduProgram(currEP, tsp, notPossibleTimeSlots);
                if (dragedCourse.getCoursesToHoldTogetherList().Count > 0)
                {
                    foreach (Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
                    {
                        EduProgram epHT = (EduProgram)edu_program_group.Parent;
                        markNotPossibleTimeSlotsRelEduProgram(epHT, tsp, notPossibleTimeSlots);
                    }
                }


                //check in relation with groups
                ArrayList lessonsInOneTimeSlot = currTimetable[tsp.getIndexRow(), tsp.getIndexCol()];
                markNotPossibleTimeSlotsRelGroup(lessonsInOneTimeSlot, tsp, dragedCourse, notPossibleTimeSlots);
                if (dragedCourse.getCoursesToHoldTogetherList().Count > 0)
                {
                    foreach (Course edu_program_group in dragedCourse.getCoursesToHoldTogetherList())
                    {
                        EduProgram epHT = (EduProgram)edu_program_group.Parent;
                        ArrayList[,] myttHT = epHT.getTimetable();
                        ArrayList lessonsInOneTimeSlotHT = myttHT[tsp.getIndexRow(), tsp.getIndexCol()];
                        markNotPossibleTimeSlotsRelGroup(lessonsInOneTimeSlotHT, tsp, edu_program_group, notPossibleTimeSlots);
                    }
                }


                //check if teacher is free for time slot
                markNotPossibleTimeSlotsRelTeacher(tsp, dragedTeacher, notPossibleTimeSlots);

                //check if there is any room with capacity greater than number
                //of enrolled students for draged course, that is free for this time slot,
                // and with time slot allowed in definition of allowed time slots for room
                markNotPossibleTimeSlotsRelRoom(tsp, possibleRooms, notPossibleTimeSlots);

            }
            return notPossibleTimeSlots;
        }


		
	}
}
