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
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;


namespace OpenCTT
{
	/// <summary>
	/// Summary description for FileOperations.
	/// </summary>
	public class FileOperations
	{
		private static ResourceManager RES_MANAGER;	

		private const string OCTT_FILE_SCHEMA_NAME="octtfileschema.xsd";
        
		private static ArrayList COURSES_WITH_TOGETHER_LIST;
		private static Course CURR_COURSE;
		private static EduProgram CURR_EP;
		private static EduProgramGroup CURR_EDU_PROGRAM_GROUP;
		private static Hashtable HT_TEACHERS;
		private static Hashtable HT_ROOMS;
        private static Hashtable HT_COURSES;
        private static Hashtable HT_EPS;
	
		private static Hashtable HT_TERMS;
		private static string SLOT_TYPE;
		private static bool[,] ALLOWED_TIME_SLOTS_BY_LOAD=null;
		private static Object ADD_ME_ALLOWED_TIME_SLOTS=null;
		private static ArrayList TEMP_INCL_DAYS_LIST;
		private static ArrayList TEMP_INCL_TERMS_LIST;

		private static bool SKIP_READ=false;

		private const string OCTT_TAG="open_course_timetabler";
		private const string DOCUMENT_TYPE_ATTRIB="document_type";
		private const string VERSION_ATTRIB="version";
		
		private const string EDU_INSTITUTION_NAME_TAG="edu_institution_name";
		private const string SCHOOL_YEAR_TAG="school_year";
		private const string INCLUDED_DAYS_TAG="incl_days";
		private const string DAY_INDEX_TAG="day_index";
		private const string INCLUDED_TERMS_TAG="incl_terms";
		private const string TERM_TAG="term";		
		private const string TITLE_TAG="title";		
		private const string EDU_RANK_TAG="edu_rank";
		private const string TEACHERS_TAG="teachers";
		private const string TEACHER_TAG="teacher";
		private const string TEACHER_ID_TAG="teacher_id";
		private const string NAME_TAG="name";
		private const string LAST_NAME_TAG="last_name";
		private const string SPEC_SLOTS_TAG="spec_slots";
		private const string TYPE_ATTRIB="type";
		private const string SPEC_SLOT_TAG="spec_slot";
		private const string TERM_INDEX_TAG="term_index";
		private const string ALLOWED_CLASSROOMS_TAG="allowed_classrooms";		
		private const string CLASSROOMS_TAG="classrooms";
		private const string CLASSROOM_TAG="classroom";
		private const string CLASSROOM_ID_TAG="classroom_id";
		private const string CAPACITY_TAG="capacity";
		private const string EDU_PROGRAM_GROUPS_TAG="edu_program_groups";
		private const string EDU_PROGRAM_GROUP_TAG="edu_program_group";
		private const string EDU_PROGRAMS_TAG="edu_programs";
		private const string EDU_PROGRAM_TAG="edu_program";
		private const string CODE_TAG="code";
		private const string SEMESTER_TAG="semester";
		private const string COURSES_TAG="courses";
		private const string COURSE_TAG="course";
		private const string COURSE_ID_TAG="course_id";
		private const string SHORT_NAME_TAG="short_name";
		private const string LESSONS_PER_WEEK_TAG="num_of_lessons_per_week";
		private const string NUM_OF_ENROLLED_STUDENTS_TAG="num_of_enrolled_students";
		private const string GROUP_NAME_TAG="group_name";
		private const string TO_HOLD_TOGETHER_WITH_TAG="to_hold_together_with";		
		private const string ACTIVITIES_TAG="activities";
		private const string LESSONS_IN_TT_TAG="lessons_in_tt";
		private const string LESSON_IN_TT_TAG="lesson_in_tt";

		private const string EXT_ID_TAG="extid";
		private const string COURSE_TYPE_TAG="course_type";

        //
        private const string SOFT_CONSTRAINTS_TAG = "soft_constraints";
        private const string SC_EPS_TAG = "sc_eps";
        private const string SC_EP_BASE_TAG = "sc_ep_base";
        private const string SC_MAX_HOURS_CONTINUOUSLY_TAG = "max_hours_continuously";
        private const string SC_MAX_HOURS_DAILY_TAG = "max_hours_daily";
        private const string SC_MAX_DAYS_PER_WEEK_TAG = "max_days_per_week";
        private const string SC_GAP_INDICATOR_TAG = "gap_indicator";
        private const string SC_PREFERRED_START_TP_TAG = "preferred_start_time_period";

        private const string SC_EP_TAG = "sc_ep";
        private const string SC_EP_ID_ATTRIB = "sc_ep_id";

        private const string SC_COURSES_TAG = "sc_courses";
        private const string SC_COURSE_BASE_TAG = "sc_course_base";
        private const string SC_LPW_2_TAG = "lpw_2";
        private const string SC_LPW_3_TAG = "lpw_3";
        private const string SC_LPW_4_TAG = "lpw_4";
        private const string SC_LPW_5_TAG = "lpw_5";
        private const string SC_LPW_6_TAG = "lpw_6";
        private const string SC_LPW_7_TAG = "lpw_7";
        private const string SC_LPW_8_TAG = "lpw_8";
        private const string SC_LPW_9_TAG = "lpw_9";
        private const string SC_LPW_DEFAULT_TAG = "lpw_default";
        private const string SC_MIN_BLOCK_SIZE_TAG = "min_block_size";
        private const string SC_MIN_NUM_OF_BLOCKS_TAG = "min_num_of_blocks";
        private const string SC_MAX_NUM_OF_BLOCKS_TAG = "max_num_of_blocks";

        private const string SC_COURSE_TAG = "sc_course";
        private const string SC_COURSE_ID_ATTRIB = "sc_course_id";

        private const string SC_TEACHERS_TAG = "sc_teachers";
        private const string SC_TEACHER_BASE_TAG = "sc_teacher_base";
        private const string SC_TEACHER_TAG = "sc_teacher";
        private const string SC_TEACHER_ID_ATTRIB = "sc_teacher_id";


		static FileOperations()
		{
			RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.FileOperations",typeof (FileOperations).Assembly);
		}

		public static void saveToFile(string fileName)
		{
			Cursor.Current=Cursors.WaitCursor;			
			AppForm.getAppForm().getStatusBarPanel1().Text=RES_MANAGER.GetString("saveToFile.statusBar.Text");			

			int courseCounter=0;
            int epCounter = 0;

			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
			{
				foreach(EduProgram ep in epg.Nodes)
				{
                    epCounter++;
                    ep.setTempID(epCounter);

					foreach(Course course in ep.Nodes)
					{
						courseCounter++;
						course.setTempID(courseCounter);
					}
				}
			}

			int roomCounter=0;
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				roomCounter++;
				room.setTempID(roomCounter);
			}

			
			XmlDocument myXmlDocument = new XmlDocument();

			try
			{
				//parameters
				
				myXmlDocument.AppendChild(myXmlDocument.CreateXmlDeclaration("1.0","UTF-8",null));
				
				myXmlDocument.AppendChild(myXmlDocument.CreateComment(
					"Generated by Open Course Timetabler"+
					"\nCopyright Ivan Æurak - Split, Croatia,"+
					"\ne-mail: Ivan.Curak@fesb.hr"));				
                

				
				XmlElement myRootElement=myXmlDocument.CreateElement(OCTT_TAG);
				myXmlDocument.AppendChild(myRootElement);

				XmlAttribute typeAtt= myXmlDocument.CreateAttribute(DOCUMENT_TYPE_ATTRIB);
				typeAtt.Value=AppForm.CURR_OCTT_DOC.DocumentType.ToString();
				myRootElement.SetAttributeNode(typeAtt);

				XmlAttribute verAtt= myXmlDocument.CreateAttribute(VERSION_ATTRIB);
				verAtt.Value=AppForm.CURR_OCTT_DOC.DocumentVersion;
				myRootElement.SetAttributeNode(verAtt);

				XmlElement elem;
				XmlText textNode;			

				elem=myXmlDocument.CreateElement(EDU_INSTITUTION_NAME_TAG);
				myRootElement.AppendChild(elem);                				
				textNode= myXmlDocument.CreateTextNode(AppForm.CURR_OCTT_DOC.EduInstitutionName);
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(SCHOOL_YEAR_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(AppForm.CURR_OCTT_DOC.SchoolYear);
				elem.AppendChild(textNode);

				if(AppForm.CURR_OCTT_DOC.getNumberOfDays()>0)
				{
					XmlElement inclDaysElem=myXmlDocument.CreateElement(INCLUDED_DAYS_TAG);
					myRootElement.AppendChild(inclDaysElem);
                
					for(int n=0;n<7;n++)
					{
						if(AppForm.CURR_OCTT_DOC.getIsDayIncluded(n))
						{
							elem=myXmlDocument.CreateElement(DAY_INDEX_TAG);
							inclDaysElem.AppendChild(elem);
							textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(n+1));
							elem.AppendChild(textNode);

						}
					}
				}
                

				if(AppForm.CURR_OCTT_DOC.IncludedTerms.Count>0)
				{
					XmlElement inclTermsElem=myXmlDocument.CreateElement(INCLUDED_TERMS_TAG);
					myRootElement.AppendChild(inclTermsElem);

					int termIndexCounter=0;
					foreach(int[] term in AppForm.CURR_OCTT_DOC.IncludedTerms)
					{
						elem=myXmlDocument.CreateElement(TERM_TAG);
						inclTermsElem.AppendChild(elem);
					
						termIndexCounter++;
						XmlAttribute termIndexAttr= myXmlDocument.CreateAttribute("index");
						termIndexAttr.Value=System.Convert.ToString(termIndexCounter);
						elem.SetAttributeNode(termIndexAttr);
	
						string [] printTerm=new string[4];
						for(int k=0;k<4;k++)
						{
							if(term[k]<10)
							{
								printTerm[k]="0"+System.Convert.ToString(term[k]);
							}
							else
							{
								printTerm[k]=System.Convert.ToString(term[k]);
							}
						}

						string myText=printTerm[0]+":"+printTerm[1]+"-"+printTerm[2]+":"+printTerm[3];

						textNode= myXmlDocument.CreateTextNode(myText);
						elem.AppendChild(textNode);
					}
				}				

				//teachers
                ArrayList scTeacherElementsList = new ArrayList();
                
				if(AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Count>0)
				{
					XmlElement teachersListElement=myXmlDocument.CreateElement(TEACHERS_TAG);
					myRootElement.AppendChild(teachersListElement);

					int teacherCounter=0;
					foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
					{
						teacherCounter++;
						teacher.setTempID(teacherCounter);

                        //sc
                        XmlElement scTeacherElement = null;

                        if (teacher.SCMaxHoursContinously != -1)
                        {
                            scTeacherElement = myXmlDocument.CreateElement(SC_TEACHER_TAG);
                            scTeacherElementsList.Add(scTeacherElement);
                            XmlAttribute teacherIDAtt = myXmlDocument.CreateAttribute(SC_TEACHER_ID_ATTRIB);
                            teacherIDAtt.Value = teacher.getTempID().ToString();
                            scTeacherElement.SetAttributeNode(teacherIDAtt);

                            elem = myXmlDocument.CreateElement(SC_MAX_HOURS_CONTINUOUSLY_TAG);
                            scTeacherElement.AppendChild(elem);
                            textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(teacher.SCMaxHoursContinously));
                            elem.AppendChild(textNode);
                        }

                        if (teacher.SCMaxHoursDaily != -1)
                        {
                            if (scTeacherElement == null)
                            {
                                scTeacherElement = myXmlDocument.CreateElement(SC_TEACHER_TAG);
                                scTeacherElementsList.Add(scTeacherElement);
                                XmlAttribute teacherIDAtt = myXmlDocument.CreateAttribute(SC_TEACHER_ID_ATTRIB);
                                teacherIDAtt.Value = teacher.getTempID().ToString();
                                scTeacherElement.SetAttributeNode(teacherIDAtt);
                            }

                            elem = myXmlDocument.CreateElement(SC_MAX_HOURS_DAILY_TAG);
                            scTeacherElement.AppendChild(elem);
                            textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(teacher.SCMaxHoursDaily));
                            elem.AppendChild(textNode);
                        }

                        if (teacher.SCMaxDaysPerWeek != -1)
                        {
                            if (scTeacherElement == null)
                            {
                                scTeacherElement = myXmlDocument.CreateElement(SC_TEACHER_TAG);
                                scTeacherElementsList.Add(scTeacherElement);
                                XmlAttribute teacherIDAtt = myXmlDocument.CreateAttribute(SC_TEACHER_ID_ATTRIB);
                                teacherIDAtt.Value = teacher.getTempID().ToString();
                                scTeacherElement.SetAttributeNode(teacherIDAtt);
                            }

                            elem = myXmlDocument.CreateElement(SC_MAX_DAYS_PER_WEEK_TAG);
                            scTeacherElement.AppendChild(elem);
                            textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(teacher.SCMaxDaysPerWeek));
                            elem.AppendChild(textNode);
                        }


                        //

						XmlElement teacherElement=myXmlDocument.CreateElement(TEACHER_TAG);
						teachersListElement.AppendChild(teacherElement);

						XmlAttribute idAttr= myXmlDocument.CreateAttribute("id");
						idAttr.Value=System.Convert.ToString(teacherCounter);
						teacherElement.SetAttributeNode(idAttr);

						elem=myXmlDocument.CreateElement(NAME_TAG);
						teacherElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(teacher.getName());						

						elem.AppendChild(textNode);

						elem=myXmlDocument.CreateElement(LAST_NAME_TAG);
						teacherElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(teacher.getLastName());						
						elem.AppendChild(textNode);

						string title="";
						if(teacher.getTitle()!=null) title=teacher.getTitle();						
						
						elem=myXmlDocument.CreateElement(TITLE_TAG);
						teacherElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(title);
						elem.AppendChild(textNode);

						string eduRank="";
						if(teacher.getEduRank()!=null) eduRank=teacher.getEduRank();
						
						elem=myXmlDocument.CreateElement(EDU_RANK_TAG);
						teacherElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(eduRank);
						elem.AppendChild(textNode);

						elem=myXmlDocument.CreateElement(EXT_ID_TAG);
						teacherElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(teacher.ExtID);
						elem.AppendChild(textNode);
						

						//allowed time slots
						bool [,] allowedTimeSlots = teacher.getAllowedTimeSlots();
						prepareSpecSlots(myXmlDocument,teacherElement,allowedTimeSlots);
					
						//allowed rooms
						ArrayList allowedRoomsList = teacher.getAllowedRoomsList();
						if(allowedRoomsList!=null && allowedRoomsList.Count>0)
						{
							prepareAllowedRooms(myXmlDocument,teacherElement,allowedRoomsList);
						}
					}
				}

				//rooms
				if(AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Count>0)
				{
					XmlElement roomsListElement=myXmlDocument.CreateElement(CLASSROOMS_TAG);
					myRootElement.AppendChild(roomsListElement);
					
					foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
					{
						XmlElement roomElement=myXmlDocument.CreateElement(CLASSROOM_TAG);
						roomsListElement.AppendChild(roomElement);

						XmlAttribute idAttr= myXmlDocument.CreateAttribute("id");
						idAttr.Value=System.Convert.ToString(room.getTempID());
						roomElement.SetAttributeNode(idAttr);

						elem=myXmlDocument.CreateElement(NAME_TAG);
						roomElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(room.getName());
						elem.AppendChild(textNode);

						elem=myXmlDocument.CreateElement(EXT_ID_TAG);
						roomElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(room.ExtID);
						elem.AppendChild(textNode);						

						elem=myXmlDocument.CreateElement(CAPACITY_TAG);
						roomElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(room.getRoomCapacity()));
						elem.AppendChild(textNode);
					
						//allowed time slots
						bool [,] allowedTimeSlots = room.getAllowedTimeSlots();
						prepareSpecSlots(myXmlDocument,roomElement,allowedTimeSlots);

					}
				}

				//edu program groups
				ArrayList lessonsInTTList = new ArrayList();

                ArrayList scEPElementsList = new ArrayList();
                ArrayList scCourseElementsList = new ArrayList();


				if(AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Count>0)
				{
					XmlElement eduProgramGroupsListElement=myXmlDocument.CreateElement(EDU_PROGRAM_GROUPS_TAG);
					myRootElement.AppendChild(eduProgramGroupsListElement);
					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
					{
						XmlElement eduProgramGroupElement=myXmlDocument.CreateElement(EDU_PROGRAM_GROUP_TAG);
						eduProgramGroupsListElement.AppendChild(eduProgramGroupElement);

						elem=myXmlDocument.CreateElement(NAME_TAG);
						eduProgramGroupElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(epg.getName());
						elem.AppendChild(textNode);

						elem=myXmlDocument.CreateElement(EXT_ID_TAG);
						eduProgramGroupElement.AppendChild(elem);
						textNode= myXmlDocument.CreateTextNode(epg.ExtID);
						elem.AppendChild(textNode);

						//allowed time slots
						bool [,] allowedTimeSlots = epg.getAllowedTimeSlots();
						prepareSpecSlots(myXmlDocument,eduProgramGroupElement,allowedTimeSlots);

						//edu programs
						if(epg.Nodes.Count>0)
						{
							XmlElement eduProgramsListElement=myXmlDocument.CreateElement(EDU_PROGRAMS_TAG);
							eduProgramGroupElement.AppendChild(eduProgramsListElement);

							foreach(EduProgram ep in epg.Nodes)
							{
                                XmlElement scEPElement=null;

                                if (ep.SCStudentMaxHoursContinuously != -1)
                                {
                                    scEPElement = myXmlDocument.CreateElement(SC_EP_TAG);
                                    scEPElementsList.Add(scEPElement);
                                    XmlAttribute epIDAtt = myXmlDocument.CreateAttribute(SC_EP_ID_ATTRIB);
                                    epIDAtt.Value = ep.getTempID().ToString();
                                    scEPElement.SetAttributeNode(epIDAtt);


                                    elem = myXmlDocument.CreateElement(SC_MAX_HOURS_CONTINUOUSLY_TAG);
                                    scEPElement.AppendChild(elem);
                                    textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(ep.SCStudentMaxHoursContinuously));
                                    elem.AppendChild(textNode);
                                }

                                if (ep.SCStudentMaxHoursDaily != -1)
                                {
                                    if (scEPElement == null)
                                    {
                                        scEPElement = myXmlDocument.CreateElement(SC_EP_TAG);
                                        scEPElementsList.Add(scEPElement);
                                        XmlAttribute epIDAtt = myXmlDocument.CreateAttribute(SC_EP_ID_ATTRIB);
                                        epIDAtt.Value = ep.getTempID().ToString();
                                        scEPElement.SetAttributeNode(epIDAtt);
                                    }

                                    elem = myXmlDocument.CreateElement(SC_MAX_HOURS_DAILY_TAG);
                                    scEPElement.AppendChild(elem);
                                    textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(ep.SCStudentMaxHoursDaily));
                                    elem.AppendChild(textNode);
                                }

                                if (ep.SCStudentMaxDaysPerWeek != -1)
                                {
                                    if (scEPElement == null)
                                    {
                                        scEPElement = myXmlDocument.CreateElement(SC_EP_TAG);
                                        scEPElementsList.Add(scEPElement);
                                        XmlAttribute epIDAtt = myXmlDocument.CreateAttribute(SC_EP_ID_ATTRIB);
                                        epIDAtt.Value = ep.getTempID().ToString();
                                        scEPElement.SetAttributeNode(epIDAtt);
                                    }

                                    elem = myXmlDocument.CreateElement(SC_MAX_DAYS_PER_WEEK_TAG);
                                    scEPElement.AppendChild(elem);
                                    textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(ep.SCStudentMaxDaysPerWeek));
                                    elem.AppendChild(textNode);
                                }

                                if (ep.SCStudentNoGapsGapIndicator != -1)
                                {
                                    if (scEPElement == null)
                                    {
                                        scEPElement = myXmlDocument.CreateElement(SC_EP_TAG);
                                        scEPElementsList.Add(scEPElement);
                                        XmlAttribute epIDAtt = myXmlDocument.CreateAttribute(SC_EP_ID_ATTRIB);
                                        epIDAtt.Value = ep.getTempID().ToString();
                                        scEPElement.SetAttributeNode(epIDAtt);
                                    }

                                    elem = myXmlDocument.CreateElement(SC_GAP_INDICATOR_TAG);
                                    scEPElement.AppendChild(elem);
                                    textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(ep.SCStudentNoGapsGapIndicator));
                                    elem.AppendChild(textNode);
                                }                                

                                //
                                if (ep.SCStudentPreferredStartTimePeriod != -1)
                                {
                                    if (scEPElement == null)
                                    {
                                        scEPElement = myXmlDocument.CreateElement(SC_EP_TAG);
                                        scEPElementsList.Add(scEPElement);
                                        XmlAttribute epIDAtt = myXmlDocument.CreateAttribute(SC_EP_ID_ATTRIB);
                                        epIDAtt.Value = ep.getTempID().ToString();
                                        scEPElement.SetAttributeNode(epIDAtt);
                                    }

                                    elem = myXmlDocument.CreateElement(SC_PREFERRED_START_TP_TAG);
                                    scEPElement.AppendChild(elem);
                                    textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(ep.SCStudentPreferredStartTimePeriod));
                                    elem.AppendChild(textNode);
                                }    

                                //
								XmlElement epElement=myXmlDocument.CreateElement(EDU_PROGRAM_TAG);
								eduProgramsListElement.AppendChild(epElement);

                                XmlAttribute epIDAttr = myXmlDocument.CreateAttribute("id");
                                epIDAttr.Value = System.Convert.ToString(ep.getTempID());
                                epElement.SetAttributeNode(epIDAttr);

								elem=myXmlDocument.CreateElement(NAME_TAG);
								epElement.AppendChild(elem);
								textNode= myXmlDocument.CreateTextNode(ep.getName());
								elem.AppendChild(textNode);

								elem=myXmlDocument.CreateElement(CODE_TAG);
								epElement.AppendChild(elem);
								textNode= myXmlDocument.CreateTextNode(ep.getCode());
								elem.AppendChild(textNode);

								elem=myXmlDocument.CreateElement(SEMESTER_TAG);
								epElement.AppendChild(elem);
								textNode= myXmlDocument.CreateTextNode(ep.getSemester());
								elem.AppendChild(textNode);

								elem=myXmlDocument.CreateElement(EXT_ID_TAG);
								epElement.AppendChild(elem);
								textNode= myXmlDocument.CreateTextNode(ep.ExtID);
								elem.AppendChild(textNode);

								//allowed time slots
								allowedTimeSlots = ep.getAllowedTimeSlots();
								prepareSpecSlots(myXmlDocument,epElement,allowedTimeSlots);

								if(ep.Nodes.Count>0)
								{
									//courses
									XmlElement coursesListElement=myXmlDocument.CreateElement(COURSES_TAG);
									epElement.AppendChild(coursesListElement);
									
									foreach(Course course in ep.Nodes)
									{                                        
                                        int numOfLess = course.getNumberOfLessonsPerWeek();
                                        if (numOfLess > 1)
                                        {
                                            string myKey = null;
                                            if (numOfLess < 10)
                                            {
                                                myKey = numOfLess.ToString();

                                            }
                                            else myKey = "default";

                                            int[] myLessBlocks = course.SCLessonBlocksParameters;
                                            if (myLessBlocks != null)
                                            {
                                                XmlElement scCourseElement = myXmlDocument.CreateElement(SC_COURSE_TAG);
                                                scCourseElementsList.Add(scCourseElement);
                                                XmlAttribute courseIDAtt = myXmlDocument.CreateAttribute(SC_COURSE_ID_ATTRIB);
                                                courseIDAtt.Value = course.getTempID().ToString();
                                                scCourseElement.SetAttributeNode(courseIDAtt);

                                                elem = myXmlDocument.CreateElement(SC_MIN_BLOCK_SIZE_TAG);
                                                scCourseElement.AppendChild(elem);
                                                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(((int)myLessBlocks[0]).ToString()));
                                                elem.AppendChild(textNode);

                                                elem = myXmlDocument.CreateElement(SC_MIN_NUM_OF_BLOCKS_TAG);
                                                scCourseElement.AppendChild(elem);
                                                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(((int)myLessBlocks[1]).ToString()));
                                                elem.AppendChild(textNode);

                                                elem = myXmlDocument.CreateElement(SC_MAX_NUM_OF_BLOCKS_TAG);
                                                scCourseElement.AppendChild(elem);
                                                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(((int)myLessBlocks[2]).ToString()));
                                                elem.AppendChild(textNode);

                                            }
                                        }

                                        //////////////////
										XmlElement courseElement=myXmlDocument.CreateElement(COURSE_TAG);
										coursesListElement.AppendChild(courseElement);

										XmlAttribute idAttr= myXmlDocument.CreateAttribute("id");
										idAttr.Value=System.Convert.ToString(course.getTempID());
										courseElement.SetAttributeNode(idAttr);

										elem=myXmlDocument.CreateElement(NAME_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(course.getName());
										elem.AppendChild(textNode);

										elem=myXmlDocument.CreateElement(SHORT_NAME_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(course.getShortName());
										elem.AppendChild(textNode);

										elem=myXmlDocument.CreateElement(COURSE_TYPE_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(course.CourseType);
										elem.AppendChild(textNode);

										elem=myXmlDocument.CreateElement(LESSONS_PER_WEEK_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(course.getNumberOfLessonsPerWeek()));
										elem.AppendChild(textNode);

										elem=myXmlDocument.CreateElement(NUM_OF_ENROLLED_STUDENTS_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(course.getNumberOfEnrolledStudents()));
										elem.AppendChild(textNode);

                                        string groupName="";
										if(course.getIsGroup())
										{
											groupName=course.getGroupName();										
										}
										elem=myXmlDocument.CreateElement(GROUP_NAME_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(groupName);
										elem.AppendChild(textNode);

										XmlElement courseTeacherIDElement=myXmlDocument.CreateElement(TEACHER_ID_TAG);
										courseElement.AppendChild(courseTeacherIDElement);
										textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(course.getTeacher().getTempID()));
										courseTeacherIDElement.AppendChild(textNode);

										elem=myXmlDocument.CreateElement(EXT_ID_TAG);
										courseElement.AppendChild(elem);
										textNode= myXmlDocument.CreateTextNode(course.ExtID);
										elem.AppendChild(textNode);

										//allowed rooms
										ArrayList allowedRoomsList = course.getAllowedRoomsList();
										if(allowedRoomsList!=null && allowedRoomsList.Count>0)
										{
											prepareAllowedRooms(myXmlDocument,courseElement,allowedRoomsList);
										}
										

										if(course.getCoursesToHoldTogetherList()!=null && course.getCoursesToHoldTogetherList().Count>0)
										{
											XmlElement toHoldTogetherElement=myXmlDocument.CreateElement(TO_HOLD_TOGETHER_WITH_TAG);
											courseElement.AppendChild(toHoldTogetherElement);

											foreach(Course courseHT in course.getCoursesToHoldTogetherList())
											{
												elem=myXmlDocument.CreateElement(COURSE_ID_TAG);
												toHoldTogetherElement.AppendChild(elem);
												textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(courseHT.getTempID()));
												elem.AppendChild(textNode);
											}
										}										

										//lessons in timetable
										ArrayList lessonsInTimetableArrayList=getMyLessonsInTimetable(ep,course);
										if(lessonsInTimetableArrayList.Count>0)
										{											
											foreach(Object [] oneItem in lessonsInTimetableArrayList)
											{
												int dayIndex=(int)oneItem[0];
												int termIndex=(int)oneItem[1];												
												Room room = (Room)oneItem[2];

												XmlElement lessonInTTElement=myXmlDocument.CreateElement(LESSON_IN_TT_TAG);												
												lessonsInTTList.Add(lessonInTTElement);												
												
												elem=myXmlDocument.CreateElement(COURSE_ID_TAG);
												lessonInTTElement.AppendChild(elem);
												textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(course.getTempID()));
												elem.AppendChild(textNode);
												
												elem=myXmlDocument.CreateElement(DAY_INDEX_TAG);
												lessonInTTElement.AppendChild(elem);
												textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(dayIndex));
												elem.AppendChild(textNode);

												elem=myXmlDocument.CreateElement(TERM_INDEX_TAG);
												lessonInTTElement.AppendChild(elem);
												textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(termIndex));
												elem.AppendChild(textNode);

												elem=myXmlDocument.CreateElement(CLASSROOM_ID_TAG);
												lessonInTTElement.AppendChild(elem);
												textNode= myXmlDocument.CreateTextNode(System.Convert.ToString(room.getTempID()));
												elem.AppendChild(textNode);

											}

										}
									}

								}
							}
						}
					}
				}

				XmlElement activitiesElement=myXmlDocument.CreateElement(ACTIVITIES_TAG);
				myRootElement.AppendChild(activitiesElement);

				XmlElement lessonsInTTElement=myXmlDocument.CreateElement(LESSONS_IN_TT_TAG);
				activitiesElement.AppendChild(lessonsInTTElement);				

				foreach(XmlElement lessonInTTElement in lessonsInTTList)
				{
					lessonsInTTElement.AppendChild(lessonInTTElement);
				}

                //--------------------------------------
                //new in  ver. 0.8 : soft constraints

                XmlElement softConstraintsElement = myXmlDocument.CreateElement(SOFT_CONSTRAINTS_TAG);
                myRootElement.AppendChild(softConstraintsElement);
                //sc for eps
                XmlElement scEPsElement = myXmlDocument.CreateElement(SC_EPS_TAG);
                softConstraintsElement.AppendChild(scEPsElement);
                //sc for eps base
                XmlElement scEPBaseElement = myXmlDocument.CreateElement(SC_EP_BASE_TAG);
                scEPsElement.AppendChild(scEPBaseElement);

                elem = myXmlDocument.CreateElement(SC_MAX_HOURS_CONTINUOUSLY_TAG);
                scEPBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY));
                elem.AppendChild(textNode);

                elem = myXmlDocument.CreateElement(SC_MAX_HOURS_DAILY_TAG);
                scEPBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY));
                elem.AppendChild(textNode);

                elem = myXmlDocument.CreateElement(SC_MAX_DAYS_PER_WEEK_TAG);
                scEPBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK));
                elem.AppendChild(textNode);

                elem = myXmlDocument.CreateElement(SC_GAP_INDICATOR_TAG);
                scEPBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR));
                elem.AppendChild(textNode);

                elem = myXmlDocument.CreateElement(SC_PREFERRED_START_TP_TAG);
                scEPBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD));
                elem.AppendChild(textNode);
                
                //sc for ep with overriden settings
                foreach (XmlElement scEPElem in scEPElementsList)
				{
                    scEPsElement.AppendChild(scEPElem);
				}
           
                //---------------
                //
                XmlElement scCoursesElement = myXmlDocument.CreateElement(SC_COURSES_TAG);
                softConstraintsElement.AppendChild(scCoursesElement);

                //sc for courses base
                XmlElement scCourseBaseElement = myXmlDocument.CreateElement(SC_COURSE_BASE_TAG);
                scCoursesElement.AppendChild(scCourseBaseElement);
                XmlElement scLPW2Element = myXmlDocument.CreateElement(SC_LPW_2_TAG);
                scCourseBaseElement.AppendChild(scLPW2Element);

                int[] l2 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["2"];
                createXMLForSCCourseBlocks(myXmlDocument,scLPW2Element, l2);

                XmlElement scLPW3Element = myXmlDocument.CreateElement(SC_LPW_3_TAG);
                scCourseBaseElement.AppendChild(scLPW3Element);
                int[] l3 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["3"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW3Element, l3);

                XmlElement scLPW4Element = myXmlDocument.CreateElement(SC_LPW_4_TAG);
                scCourseBaseElement.AppendChild(scLPW4Element);
                int[] l4 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["4"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW4Element, l4);

                XmlElement scLPW5Element = myXmlDocument.CreateElement(SC_LPW_5_TAG);
                scCourseBaseElement.AppendChild(scLPW5Element);
                int[] l5 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["5"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW5Element, l5);

                XmlElement scLPW6Element = myXmlDocument.CreateElement(SC_LPW_6_TAG);
                scCourseBaseElement.AppendChild(scLPW6Element);
                int[] l6 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["6"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW6Element, l6);

                XmlElement scLPW7Element = myXmlDocument.CreateElement(SC_LPW_7_TAG);
                scCourseBaseElement.AppendChild(scLPW7Element);
                int[] l7 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["7"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW7Element, l7);

                XmlElement scLPW8Element = myXmlDocument.CreateElement(SC_LPW_8_TAG);
                scCourseBaseElement.AppendChild(scLPW8Element);
                int[] l8 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["8"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW8Element, l8);

                XmlElement scLPW9Element = myXmlDocument.CreateElement(SC_LPW_9_TAG);
                scCourseBaseElement.AppendChild(scLPW9Element);
                int[] l9 = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["9"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW9Element, l9);

                XmlElement scLPW10Element = myXmlDocument.CreateElement(SC_LPW_DEFAULT_TAG);
                scCourseBaseElement.AppendChild(scLPW10Element);
                int[] ldef = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS["default"];
                createXMLForSCCourseBlocks(myXmlDocument, scLPW10Element, ldef);

                //sc for courses with overriden settings
                foreach (XmlElement scCourseElem in scCourseElementsList)
                {
                    scCoursesElement.AppendChild(scCourseElem);
                }

                //---------------
                //
                //
                XmlElement scTeachersElement = myXmlDocument.CreateElement(SC_TEACHERS_TAG);
                softConstraintsElement.AppendChild(scTeachersElement);

                //sc for teachers base
                XmlElement scTeacherBaseElement = myXmlDocument.CreateElement(SC_TEACHER_BASE_TAG);
                scTeachersElement.AppendChild(scTeacherBaseElement);

                elem = myXmlDocument.CreateElement(SC_MAX_HOURS_CONTINUOUSLY_TAG);
                scTeacherBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.TEACHER_MAX_HOURS_CONTINUOUSLY));
                elem.AppendChild(textNode);

                elem = myXmlDocument.CreateElement(SC_MAX_HOURS_DAILY_TAG);
                scTeacherBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.TEACHER_MAX_HOURS_DAILY));
                elem.AppendChild(textNode);

                elem = myXmlDocument.CreateElement(SC_MAX_DAYS_PER_WEEK_TAG);
                scTeacherBaseElement.AppendChild(elem);
                textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(SCBaseSettings.TEACHER_MAX_DAYS_PER_WEEK));
                elem.AppendChild(textNode); 
     
                //sc for teachers with overriden settings
                foreach (XmlElement scTeacherElem in scTeacherElementsList)
                {
                    scTeachersElement.AppendChild(scTeacherElem);
                }

			}
			catch
			{	
                string message = RES_MANAGER.GetString("saveToFile.msb.saveerror.message");
				
				string caption = RES_MANAGER.GetString("saveToFile.msb.saveerror.caption");

				MessageBoxButtons buttons = MessageBoxButtons.OK;
				MessageBox.Show(AppForm.getAppForm(), message, caption, buttons,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				myXmlDocument.Save(fileName);

				Cursor.Current=Cursors.Default;
				AppForm.getAppForm().getStatusBarPanel1().Text="";

				CommandProcessor.getCommandProcessor().setLastSavedCmd(CommandProcessor.getCommandProcessor().getLastCmdOnStack());
			}


		}

        private static void createXMLForSCCourseBlocks(XmlDocument myXmlDocument,XmlElement scLPWElement, int[] lessSett)
        {
            XmlElement elem;
            XmlText textNode;	

            elem = myXmlDocument.CreateElement(SC_MIN_BLOCK_SIZE_TAG);
            scLPWElement.AppendChild(elem);
            textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(((int)lessSett[0]).ToString()));
            elem.AppendChild(textNode);

            elem = myXmlDocument.CreateElement(SC_MIN_NUM_OF_BLOCKS_TAG);
            scLPWElement.AppendChild(elem);
            textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(((int)lessSett[1]).ToString()));
            elem.AppendChild(textNode);

            elem = myXmlDocument.CreateElement(SC_MAX_NUM_OF_BLOCKS_TAG);
            scLPWElement.AppendChild(elem);
            textNode = myXmlDocument.CreateTextNode(System.Convert.ToString(((int)lessSett[2]).ToString()));
            elem.AppendChild(textNode);




        }


		private static void getIsThereMoreUnallowedThanAllowedTimeSlots(bool [,] allowedTimeSlots, out int poss, out int imposs)
		{	
			int p=0,i=0;

			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
			{				
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
				{
					if(allowedTimeSlots[j,k]==true)
					{
						p++;
					}
					else
					{
						i++;
					}
				}				
			}
			poss=p;
			imposs=i;			
		}

		private static void prepareSpecSlots(XmlDocument myXmlDocument, XmlElement baseElement, bool [,] allowedTimeSlots)
		{
			int totalTS=AppForm.CURR_OCTT_DOC.IncludedTerms.Count*AppForm.CURR_OCTT_DOC.getNumberOfDays();

			XmlElement elem;
			XmlElement allSlotsElement;
			int poss;
			int imposs;
			getIsThereMoreUnallowedThanAllowedTimeSlots(allowedTimeSlots,out poss,out imposs);
			if(imposs>0)
			{
				allSlotsElement=myXmlDocument.CreateElement(SPEC_SLOTS_TAG);
				baseElement.AppendChild(allSlotsElement);
				XmlAttribute attr= myXmlDocument.CreateAttribute(TYPE_ATTRIB);
				if(imposs<totalTS)
				{
					if(poss>=imposs)
					{
						attr.Value="unallowed";
					}
					else
					{
						attr.Value="allowed";
					}
				}
				else
				{
                    attr.Value="unallowed";
				}
				
				allSlotsElement.SetAttributeNode(attr);

				for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
				{				
					for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
					{
						if(poss>=imposs)
						{
							if(allowedTimeSlots[j,k]==false)
							{
								XmlElement slotElement =myXmlDocument.CreateElement(SPEC_SLOT_TAG);
								allSlotsElement.AppendChild(slotElement);

								XmlText text;
								elem = myXmlDocument.CreateElement(DAY_INDEX_TAG);
								slotElement.AppendChild(elem);
								//text = myXmlDocument.CreateTextNode(System.Convert.ToString(k+1));
                                text = myXmlDocument.CreateTextNode(System.Convert.ToString(AppForm.CURR_OCTT_DOC.getRealWeekDayIndex(k+1)));
								elem.AppendChild(text);

								elem = myXmlDocument.CreateElement(TERM_INDEX_TAG);
								slotElement.AppendChild(elem);
								text = myXmlDocument.CreateTextNode(System.Convert.ToString(j+1));
								elem.AppendChild(text);

							}						
						}
						else
						{
							if(imposs<totalTS)
							{
								if(allowedTimeSlots[j,k]==true)
								{
									XmlElement slotElement =myXmlDocument.CreateElement(SPEC_SLOT_TAG);
									allSlotsElement.AppendChild(slotElement);

									XmlText text;
									elem = myXmlDocument.CreateElement(DAY_INDEX_TAG);
									slotElement.AppendChild(elem);
									//text = myXmlDocument.CreateTextNode(System.Convert.ToString(k+1));
                                    text = myXmlDocument.CreateTextNode(System.Convert.ToString(AppForm.CURR_OCTT_DOC.getRealWeekDayIndex(k + 1)));
									elem.AppendChild(text);

									elem = myXmlDocument.CreateElement(TERM_INDEX_TAG);
									slotElement.AppendChild(elem);
									text = myXmlDocument.CreateTextNode(System.Convert.ToString(j+1));
									elem.AppendChild(text);
								}
							}
							else
							{
								if(allowedTimeSlots[j,k]==false)
								{
									XmlElement slotElement =myXmlDocument.CreateElement(SPEC_SLOT_TAG);
									allSlotsElement.AppendChild(slotElement);

									XmlText text;
									elem = myXmlDocument.CreateElement(DAY_INDEX_TAG);
									slotElement.AppendChild(elem);
									//text = myXmlDocument.CreateTextNode(System.Convert.ToString(k+1));
                                    text = myXmlDocument.CreateTextNode(System.Convert.ToString(AppForm.CURR_OCTT_DOC.getRealWeekDayIndex(k + 1)));
									elem.AppendChild(text);

									elem = myXmlDocument.CreateElement(TERM_INDEX_TAG);
									slotElement.AppendChild(elem);
									text = myXmlDocument.CreateTextNode(System.Convert.ToString(j+1));
									elem.AppendChild(text);
								}

							}
							
						}
					}				
				}
			}
		}

		private static void prepareAllowedRooms(XmlDocument myXmlDocument, XmlElement baseElement, ArrayList allowedRoomsList)
		{
			XmlElement possClassrooms=myXmlDocument.CreateElement(ALLOWED_CLASSROOMS_TAG);
			baseElement.AppendChild(possClassrooms);

			XmlElement elem;
			foreach(Room room in allowedRoomsList)
			{
				elem=myXmlDocument.CreateElement(CLASSROOM_ID_TAG);
				possClassrooms.AppendChild(elem);
				XmlText text = myXmlDocument.CreateTextNode(System.Convert.ToString(room.getTempID()));
				elem.AppendChild(text);
			}


		}

		public static ArrayList getMyLessonsInTimetable(EduProgram myEP,Course myCourse)
		{
			ArrayList al = new ArrayList();
			
			ArrayList [,] mytt = myEP.getTimetable();

			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{	
					ArrayList lessonsInOneTimeSlot = mytt[j,k];
					if(lessonsInOneTimeSlot!=null) 
					{
						foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
						{						
							Course course = (Course)courseAndRoomPair[0];
							if(course==myCourse)
							{
								Object [] oneItem = new Object[3];
								//oneItem[0]=k+1;
                                oneItem[0] = AppForm.CURR_OCTT_DOC.getRealWeekDayIndex(k + 1);
								oneItem[1]=j+1;
								Room room = (Room)courseAndRoomPair[1];								
								oneItem[2]=room;
								al.Add(oneItem);
							}
							
						}
					}					
				}
			}           

			return al;

		}

		public static void openDocFromFile(string fileName)
		{
			bool isValid;
			isValid =true;			
			
			//isValid = validateOCTFile(fileName);

			if(isValid)
			{			

				XmlTextReader reader=null;			

				try
				{
					Cursor.Current=Cursors.WaitCursor;
					AppForm.getAppForm().getStatusBarPanel1().Text="Opening document ...";

					COURSES_WITH_TOGETHER_LIST=new ArrayList();
					HT_TEACHERS= new Hashtable();
					HT_ROOMS= new Hashtable();
					HT_COURSES= new Hashtable();
                    HT_EPS = new Hashtable();

					reader= new XmlTextReader(fileName);
					reader.WhitespaceHandling = WhitespaceHandling.None;					
				
					while (!reader.EOF)
					{
						if(!SKIP_READ)
						{
							reader.Read();
						}
						else
						{
							SKIP_READ=false;
						}

						switch (reader.NodeType)
						{
							case XmlNodeType.Element:								
								doElement(reader);
								break;								
							case XmlNodeType.EndElement:								
								doEndElement(reader);
								break;                                
						}       
					}					

					if (reader!=null)reader.Close();
					
					IEnumerator enumerator = HT_COURSES.Values.GetEnumerator();
					for(int e=0;e<HT_COURSES.Values.Count;e++)
					{
						enumerator.MoveNext();
						Course course = (Course)enumerator.Current;
						EduProgram ep = (EduProgram)course.Parent;
						for(int k=0;k<course.TempNumberOfUnallocatedLessons;k++)
						{
							ListViewItem lvi=new ListViewItem();
							lvi.Tag=course;
							ep.getUnallocatedLessonsList().Add(lvi);
						}
					}



					//

					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Sort();
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Sort();
					AppForm.CURR_OCTT_DOC.CourseTypesList.Sort();
				
					Cursor.Current=Cursors.Default;
					AppForm.getAppForm().getStatusBarPanel1().Text="";

					foreach(Teacher teach in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
					{						
						if(teach.getTempAllowedRoomsList()!=null)
						{
							ArrayList newPossRoomsList= new ArrayList();
							foreach(string key in teach.getTempAllowedRoomsList())
							{
								Room room = (Room)HT_ROOMS[key];
								newPossRoomsList.Add(room);
							}

							teach.setAllowedRoomsList(newPossRoomsList);					
						}
					}

					
					ArrayList decrNumOfUnallocatedLessonsList= new ArrayList();
					

					foreach(Course course in COURSES_WITH_TOGETHER_LIST)
					{					
						course.setCoursesToHoldTogetherList(new ArrayList());
						course.ImageIndex=5;
						course.SelectedImageIndex=5;

						foreach(string stringID in course.getTempCoursesToHoldTogetherList())
						{
							Course courseHT = (Course)HT_COURSES[stringID];
							course.getCoursesToHoldTogetherList().Add(courseHT);
							
							courseHT.ImageIndex=5;
							courseHT.SelectedImageIndex=5;							
						}	
		
						
						bool notRef=true;
						foreach(Course np in course.getCoursesToHoldTogetherList())
						{
							if(decrNumOfUnallocatedLessonsList.Contains(np))
							{
								notRef=false;
								break;
							}
						}

						if(notRef) decrNumOfUnallocatedLessonsList.Add(course);
						
					
					}

					
					foreach(Course decrNumOfUnallocatedLessonsCourse in decrNumOfUnallocatedLessonsList)
					{
						AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(decrNumOfUnallocatedLessonsCourse.getNumberOfUnallocatedLessons()*decrNumOfUnallocatedLessonsCourse.getCoursesToHoldTogetherList().Count);
					}
					

				}
				catch(Exception e)
				{
					MessageBox.Show("Error"+"\n"+e.Message);

				}

				finally
				{		



				}
			}
			else
			{

			}
		}

		private static void doElement(XmlTextReader reader)
		{
			if(reader.Name==OCTT_TAG)
			{				
				string docType=reader[DOCUMENT_TYPE_ATTRIB];
				AppForm.CURR_OCTT_DOC.DocumentType=System.Convert.ToInt32(docType);

				string docVersion=reader[VERSION_ATTRIB];
				AppForm.CURR_OCTT_DOC.DocumentVersion=docVersion;

				string eduInstitutionName=reader.ReadElementString();				
				AppForm.CURR_OCTT_DOC.EduInstitutionName=eduInstitutionName;

				string schYear=reader.ReadElementString();
				AppForm.CURR_OCTT_DOC.SchoolYear=schYear;
				
				AppForm.CURR_OCTT_DOC.refreshTreeRootText();				

				SKIP_READ=true;
			}
			else if(reader.Name==INCLUDED_DAYS_TAG)
			{
				TEMP_INCL_DAYS_LIST=new ArrayList();

				while(true)
				{
					string dayIndex=reader.ReadElementString();					
					TEMP_INCL_DAYS_LIST.Add(System.Convert.ToInt32(dayIndex));
					if(reader.NodeType==XmlNodeType.EndElement)
					{
						SKIP_READ=true;
						for(int n=0;n<7;n++)
						{
							AppForm.CURR_OCTT_DOC.setIsDayIncluded(n,false);
						}

						foreach(int dayIndexFromList in TEMP_INCL_DAYS_LIST)
						{
							AppForm.CURR_OCTT_DOC.setIsDayIncluded(dayIndexFromList-1,true);
						}
						break;
					}
				}
			}			
			else if(reader.Name==INCLUDED_TERMS_TAG)
			{
				AppForm.CURR_OCTT_DOC.IncludedTerms.Clear();
				TEMP_INCL_TERMS_LIST=new ArrayList();
				HT_TERMS = new Hashtable();
			}
			else if(reader.Name==TERM_TAG)
			{
				int termIndex=System.Convert.ToInt32(reader["index"]);			
				
				string oneTerm=reader.ReadElementString();				
				int[] oneT=createOneTerm(oneTerm);
				if(termIndex>0)
				{
					TEMP_INCL_TERMS_LIST.Add(termIndex);
					string termIndexKey= System.Convert.ToString(termIndex);
					if(!HT_TERMS.ContainsKey(termIndexKey))
					{ 
						HT_TERMS.Add(termIndexKey,oneT);
					}
					else
					{	
						string message = RES_MANAGER.GetString("openDoc.msb.error_rel_terms.message");
					
						string caption = RES_MANAGER.GetString("openDoc.msb.error_rel_terms.caption");

						MessageBoxButtons buttons = MessageBoxButtons.OK;						
		
						MessageBox.Show(message, caption, buttons,
							MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

						Application.Exit();

					}					 

				}
				else
				{
					AppForm.CURR_OCTT_DOC.IncludedTerms.Add(oneT);
				}

				SKIP_READ=true;

			}			
			else if(reader.Name==TEACHER_TAG)
			{				
				string teacherID=reader["id"];
			
				string name=reader.ReadElementString();
				string lastName=reader.ReadElementString();
				string title="";
				string eduRank="";
				
				title=reader.ReadElementString();				
				eduRank=reader.ReadElementString();
								
				string extID=reader.ReadElementString();
				
				Teacher newTeacher = new Teacher(name,lastName,title,eduRank,extID);
				ADD_ME_ALLOWED_TIME_SLOTS=newTeacher;
				AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Add(newTeacher);
				
				if(!AppForm.CURR_OCTT_DOC.TeacherTitlesList.Contains(title)) AppForm.CURR_OCTT_DOC.TeacherTitlesList.Add(title);
				if(!AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Contains(eduRank)) AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Add(eduRank);

				if(!HT_TEACHERS.ContainsKey(teacherID))
				{
					HT_TEACHERS.Add(teacherID,newTeacher);
				}
				
				SKIP_READ=true;
				
			}
			else if(reader.Name==CLASSROOM_TAG)
			{
				string classroomID=reader["id"];			
				string name=reader.ReadElementString();
				string extID=reader.ReadElementString();
				string capacity=reader.ReadElementString();
								
				Room newRoom = new Room(name,System.Convert.ToInt32(capacity),extID);
				ADD_ME_ALLOWED_TIME_SLOTS=newRoom;
				AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Add(newRoom);
				if(!HT_ROOMS.ContainsKey(classroomID))
				{
					HT_ROOMS.Add(classroomID,newRoom);
				}
				
				SKIP_READ=true;			
				
			}
			else if(reader.Name==ALLOWED_CLASSROOMS_TAG)
			{
				if(ADD_ME_ALLOWED_TIME_SLOTS is Teacher)
				{
					Teacher newTeacher = (Teacher)ADD_ME_ALLOWED_TIME_SLOTS;
					if(newTeacher.getTempAllowedRoomsList()==null)
					{
						newTeacher.setTempAllowedRoomsList(new ArrayList());
					}
				
					while(true)
					{
						string clRoomID=reader.ReadElementString();
						newTeacher.getTempAllowedRoomsList().Add(clRoomID);

					
						if(reader.NodeType==XmlNodeType.EndElement)
						{	
							SKIP_READ=true;						
							break;
						}
					}
				}
				else
				{
					if(CURR_COURSE.getAllowedRoomsList()==null)
					{
						CURR_COURSE.setAllowedRoomsList(new ArrayList());
					}
				
					while(true)
					{
						string clRoomID=reader.ReadElementString();
						CURR_COURSE.getAllowedRoomsList().Add((Room)HT_ROOMS[clRoomID]);

					
						if(reader.NodeType==XmlNodeType.EndElement)
						{	
							SKIP_READ=true;						
							break;
						}
					}

				}

			}
			else if(reader.Name==SPEC_SLOT_TAG)
			{
				string dayIndex=reader.ReadElementString();
				int dayIndexInt=System.Convert.ToInt32(dayIndex);						
				string termIndex=reader.ReadElementString();
				int termIndexInt=System.Convert.ToInt32(termIndex);				

				if(SLOT_TYPE=="unallowed")
				{
					ALLOWED_TIME_SLOTS_BY_LOAD[termIndexInt-1,AppForm.CURR_OCTT_DOC.getDayIndexInModel(dayIndexInt-1)]=false;
				}
				else if(SLOT_TYPE=="allowed")
				{
					ALLOWED_TIME_SLOTS_BY_LOAD[termIndexInt-1,AppForm.CURR_OCTT_DOC.getDayIndexInModel(dayIndexInt-1)]=true;
				}

			}
			else if(reader.Name==SPEC_SLOTS_TAG)
			{
				ALLOWED_TIME_SLOTS_BY_LOAD = new bool[AppForm.CURR_OCTT_DOC.IncludedTerms.Count,AppForm.CURR_OCTT_DOC.getNumberOfDays()];

				SLOT_TYPE=reader["type"];

				if(SLOT_TYPE=="unallowed")
				{
					for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
					{
						for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
						{
							ALLOWED_TIME_SLOTS_BY_LOAD[j,k]=true;
						}
					}				
				}
				else if(SLOT_TYPE=="allowed")
				{
					for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++)
					{
						for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++)
						{
							ALLOWED_TIME_SLOTS_BY_LOAD[j,k]=false;
						}
					}				
				}
			}
			else if(reader.Name==EDU_PROGRAM_GROUP_TAG)
			{
				string name=reader.ReadElementString();				
				string extID=reader.ReadElementString();

				EduProgramGroup newEduProgramGroup = new EduProgramGroup(name,extID);
				ADD_ME_ALLOWED_TIME_SLOTS=newEduProgramGroup;
				AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Add(newEduProgramGroup);
				CURR_EDU_PROGRAM_GROUP=newEduProgramGroup;
				SKIP_READ=true;
			}
			else if(reader.Name==EDU_PROGRAM_TAG)
			{
                string epID = reader["id"];

				string name=reader.ReadElementString();
				string code=reader.ReadElementString();
				string semester=reader.ReadElementString();
				
				string extID=reader.ReadElementString();

				EduProgram newEP = new EduProgram(name,semester,code,extID);
                if(epID!=null) HT_EPS.Add(epID, newEP);

				CURR_EP=newEP;
				ADD_ME_ALLOWED_TIME_SLOTS=newEP;
				CURR_EDU_PROGRAM_GROUP.Nodes.Add(newEP);				
				SKIP_READ=true;
			}
			else if(reader.Name==COURSE_TAG)
			{
				string courseID=reader["id"];
				string name=reader.ReadElementString();
				string shortName=reader.ReadElementString();
			
				string courseType=reader.ReadElementString();
				if(!AppForm.CURR_OCTT_DOC.CourseTypesList.Contains(courseType)) AppForm.CURR_OCTT_DOC.CourseTypesList.Add(courseType);

				string numOfLessonsPerWeek=reader.ReadElementString();
				int numOfLessonsPerWeekInt=System.Convert.ToInt32(numOfLessonsPerWeek);
				AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(numOfLessonsPerWeekInt);

				string numOfEnrolledStudents=reader.ReadElementString();
				int numOfEnrolledStudentsInt=System.Convert.ToInt32(numOfEnrolledStudents);
				string groupName=reader.ReadElementString();
				bool isGroup;
				if(groupName=="")
				{
					isGroup=false;
				}
				else
				{
					isGroup=true;
				}

				string teacherID=reader.ReadElementString();
				Teacher myTeacher = (Teacher)HT_TEACHERS[teacherID];

				string extID=reader.ReadElementString();

				Course newCourse = new Course(name,shortName,myTeacher,numOfLessonsPerWeekInt,numOfEnrolledStudentsInt,isGroup,groupName,extID, courseType);
				newCourse.TempNumberOfUnallocatedLessons=numOfLessonsPerWeekInt;
				CURR_EP.Nodes.Add(newCourse);
				HT_COURSES.Add(courseID,newCourse);				

				CURR_COURSE=newCourse;
				SKIP_READ=true;
			}
			else if(reader.Name==LESSON_IN_TT_TAG)
			{				
				string courseID=reader.ReadElementString();
				Course course = (Course)HT_COURSES[courseID];
				EduProgram myEP=(EduProgram)course.Parent;
				CURR_COURSE=course;
				CURR_EP=myEP;
				
				string dayIndex=reader.ReadElementString();
				//int dayIndexInt=System.Convert.ToInt32(dayIndex)-1;
                int dayIndexInt = AppForm.CURR_OCTT_DOC.getDayIndexInModel(System.Convert.ToInt32(dayIndex)-1);
				string termIndex=reader.ReadElementString();
				int termIndexInt=System.Convert.ToInt32(termIndex)-1;
				string roomID=reader.ReadElementString();
				Room myRoom = (Room)HT_ROOMS[roomID];

				ArrayList [,] mytt=myEP.getTimetable();
				ArrayList lessonsInOneTimeSlot;
				if(mytt[termIndexInt,dayIndexInt]==null) 
				{
					lessonsInOneTimeSlot = new ArrayList();                
				}
				else
				{
					lessonsInOneTimeSlot=mytt[termIndexInt,dayIndexInt];
				}

			
				Object [] courseAndRoomPair=new Object[2];				
				courseAndRoomPair[0]=course;
				courseAndRoomPair[1]=myRoom;

				lessonsInOneTimeSlot.Add(courseAndRoomPair);
				mytt[termIndexInt, dayIndexInt]=lessonsInOneTimeSlot;
				
				SKIP_READ=true;
			}
			else if(reader.Name==TO_HOLD_TOGETHER_WITH_TAG)
			{
				CURR_COURSE.setTempCoursesToHoldTogetherList(new ArrayList());
				COURSES_WITH_TOGETHER_LIST.Add(CURR_COURSE);

				while(true)
				{
					string courseID=reader.ReadElementString();
					CURR_COURSE.getTempCoursesToHoldTogetherList().Add(courseID);
					if(reader.NodeType==XmlNodeType.EndElement)
					{
						SKIP_READ=true;
						break;
					}
				}
            }
            else if (reader.Name == SC_EP_BASE_TAG)
            {                
                int maxHoursCont = System.Int32.Parse(reader.ReadElementString());
                int maxHoursDaily = System.Int32.Parse(reader.ReadElementString());
                int maxDaysPerWeek = System.Int32.Parse(reader.ReadElementString());
                int gapIndicator = System.Int32.Parse(reader.ReadElementString());
                int preferredStartTP = System.Int32.Parse(reader.ReadElementString());

                SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY = maxHoursCont;
                SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY = maxHoursDaily;
                SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK = maxDaysPerWeek;
                SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR = gapIndicator;
                SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD = preferredStartTP;

                SKIP_READ = true;
            }
            else if (reader.Name == SC_EP_TAG)
            {
                string epID = reader["sc_ep_id"];
                EduProgram ep = (EduProgram)HT_EPS[epID];
                reader.Read();

                if (reader.Name == SC_MAX_HOURS_CONTINUOUSLY_TAG)
                {
                    ep.SCStudentMaxHoursContinuously = System.Int32.Parse(reader.ReadElementString());
                }

                if (reader.Name == SC_MAX_HOURS_DAILY_TAG)
                {
                    ep.SCStudentMaxHoursDaily = System.Int32.Parse(reader.ReadElementString());
                }

                if (reader.Name == SC_MAX_DAYS_PER_WEEK_TAG)
                {
                    ep.SCStudentMaxDaysPerWeek = System.Int32.Parse(reader.ReadElementString());
                }

                if (reader.Name == SC_GAP_INDICATOR_TAG)
                {
                    ep.SCStudentNoGapsGapIndicator = System.Int32.Parse(reader.ReadElementString());
                }

                if (reader.Name == SC_PREFERRED_START_TP_TAG)
                {
                    ep.SCStudentPreferredStartTimePeriod = System.Int32.Parse(reader.ReadElementString());
                }

                SKIP_READ = true;


            }
            else if (reader.Name == SC_TEACHER_BASE_TAG)
            {
                int maxHoursCont = System.Int32.Parse(reader.ReadElementString());
                int maxHoursDaily = System.Int32.Parse(reader.ReadElementString());
                int maxDaysPerWeek = System.Int32.Parse(reader.ReadElementString());                

                SCBaseSettings.TEACHER_MAX_HOURS_CONTINUOUSLY = maxHoursCont;
                SCBaseSettings.TEACHER_MAX_HOURS_DAILY = maxHoursDaily;
                SCBaseSettings.TEACHER_MAX_DAYS_PER_WEEK = maxDaysPerWeek;

                SKIP_READ = true;
            }
            else if (reader.Name == SC_TEACHER_TAG)
            {
                string teacherID = reader["sc_teacher_id"];
                Teacher teacher = (Teacher)HT_TEACHERS[teacherID];
                reader.Read();

                if (reader.Name == SC_MAX_HOURS_CONTINUOUSLY_TAG)
                {
                    teacher.SCMaxHoursContinously = System.Int32.Parse(reader.ReadElementString());                   
                }

                if (reader.Name == SC_MAX_HOURS_DAILY_TAG)
                {
                    teacher.SCMaxHoursDaily = System.Int32.Parse(reader.ReadElementString());                    
                }

                if (reader.Name == SC_MAX_DAYS_PER_WEEK_TAG)
                {
                    teacher.SCMaxDaysPerWeek = System.Int32.Parse(reader.ReadElementString());                    
                }

                SKIP_READ = true;
            }
            else if (reader.Name == SC_COURSE_BASE_TAG)
            {
                Hashtable courseBaseLessonBlocks = new Hashtable();
                int[] l2 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("2", l2);

                int[] l3 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("3", l3);

                int[] l4 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("4", l4);

                int[] l5 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("5", l5);

                int[] l6 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("6", l6);

                int[] l7 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("7", l7);

                int[] l8 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("8", l8);

                int[] l9 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("9", l9);

                int[] l10 = loadCourseBlocks(reader);
                courseBaseLessonBlocks.Add("default", l10);

                SCBaseSettings.COURSE_LESSON_BLOCKS = courseBaseLessonBlocks;

                SKIP_READ = true;
            }
            else if (reader.Name == SC_COURSE_TAG)
            {
                string courseID = reader["sc_course_id"];
                Course course = (Course)HT_COURSES[courseID];

                int[] courseLessonBlocks = new int[3];
                courseLessonBlocks[0] = System.Int32.Parse(reader.ReadElementString());
                courseLessonBlocks[1] = System.Int32.Parse(reader.ReadElementString());
                courseLessonBlocks[2] = System.Int32.Parse(reader.ReadElementString());
                course.SCLessonBlocksParameters = courseLessonBlocks;
            }

		}

        private static int[] loadCourseBlocks(XmlTextReader reader)
        {
            reader.Read();
            reader.Read();

            int[] cb = new int[3];
            cb[0] = System.Int32.Parse(reader.ReadElementString());
            cb[1] = System.Int32.Parse(reader.ReadElementString());
            cb[2] = System.Int32.Parse(reader.ReadElementString());
            return cb;
        }

		

		private static void doEndElement(XmlTextReader reader)
		{	
			if(reader.Name==SPEC_SLOTS_TAG)
			{

				if(ADD_ME_ALLOWED_TIME_SLOTS is Teacher)
				{
					Teacher newTeacher = (Teacher)ADD_ME_ALLOWED_TIME_SLOTS;
					newTeacher.setAllowedTimeSlots(ALLOWED_TIME_SLOTS_BY_LOAD);
				}
				else if(ADD_ME_ALLOWED_TIME_SLOTS is Room)
				{
					Room newRoom = (Room)ADD_ME_ALLOWED_TIME_SLOTS;
					newRoom.setAllowedTimeSlots(ALLOWED_TIME_SLOTS_BY_LOAD);					
				}
				else if(ADD_ME_ALLOWED_TIME_SLOTS is EduProgramGroup)
				{
					EduProgramGroup newEduProgramGroup = (EduProgramGroup)ADD_ME_ALLOWED_TIME_SLOTS;
					newEduProgramGroup.setAllowedTimeSlots(ALLOWED_TIME_SLOTS_BY_LOAD);

				}
				else if(ADD_ME_ALLOWED_TIME_SLOTS is EduProgram)
				{
					EduProgram newEP = (EduProgram)ADD_ME_ALLOWED_TIME_SLOTS;
					newEP.setAllowedTimeSlots(ALLOWED_TIME_SLOTS_BY_LOAD);
				}

			}			
			else if(reader.Name==LESSON_IN_TT_TAG)
			{				
				AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);
				CURR_COURSE.TempNumberOfUnallocatedLessons--;
			}			
			else if(reader.Name==INCLUDED_TERMS_TAG)
			{
				TEMP_INCL_TERMS_LIST.Sort();

				foreach(int termIndex in TEMP_INCL_TERMS_LIST)
				{
					string termIndexKey=System.Convert.ToString(termIndex);

                    int[] oneT = (int[])HT_TERMS[termIndexKey];
					AppForm.CURR_OCTT_DOC.IncludedTerms.Add(oneT);
				}

			}

		}

		private static int[] createOneTerm(string termStr)
		{
			int [] oneT=new int[4];
			char [] separator = new char[1];
			separator[0]='-';
			string [] twoPairs =termStr.Split(separator,2);							
			separator[0]=':';
			string [] oneTwo=twoPairs[0].Split(separator,2);
			string [] threeFour=twoPairs[1].Split(separator,2);
			string [] allStr=new string[4];
			allStr[0]=oneTwo[0];
			allStr[1]=oneTwo[1];
			allStr[2]=threeFour[0];
			allStr[3]=threeFour[1];
			for(int n=0;n<4;n++)
			{
				if(allStr[n].Substring(0,1)=="0")
				{
					if(allStr[n].Substring(1,1)=="0")
					{
						allStr[n]="0";
					}
					else
					{
                        allStr[n]=allStr[n].Substring(1,1);
					}
				}
			}

			for(int k=0;k<4;k++)
			{
				oneT[k]=System.Convert.ToInt32(allStr[k]);
			}

			return oneT;
		}		


		private static bool validateOCTFile(string fileName)
		{	
			
			XmlTextReader textReader= new XmlTextReader(fileName);
			XmlValidatingReader validReader = new XmlValidatingReader(textReader);
			XmlSchemaCollection xmlSchemaCollection = new XmlSchemaCollection();			
			xmlSchemaCollection.Add(null,Application.StartupPath+@System.IO.Path.DirectorySeparatorChar+OCTT_FILE_SCHEMA_NAME);
		
			validReader.Schemas.Add(xmlSchemaCollection);
			validReader.ValidationType=ValidationType.Schema;		

        

			try
			{	
				while(validReader.Read()){}				

			}			
			catch(XmlSchemaException e)
			{				
				string message="";
				message+=RES_MANAGER.GetString("validateOCTFile.msb.file_not_valid_rel_schema.message1");
				message+=" '"+fileName+"' ";
				message+=RES_MANAGER.GetString("validateOCTFile.msb.file_not_valid_rel_schema.message2");
				message+=" '"+OCTT_FILE_SCHEMA_NAME+"'.";
				message+= "\n\n";
				message+=RES_MANAGER.GetString("validateOCTFile.msb.file_not_valid_rel_schema.message3");
				message+= "\n"+e.Message;
			
				string caption = RES_MANAGER.GetString("validateOCTFile.msb.file_not_valid_rel_schema.caption");

				MessageBoxButtons buttons = MessageBoxButtons.OK;					
		
				MessageBox.Show(message, caption, buttons,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

				
				throw e;
				
			}

            Console.WriteLine("OCT file is OK!");
			return true;

		}

	}
}
