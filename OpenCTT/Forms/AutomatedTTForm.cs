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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenCTT.Automated;
using System.Collections;

namespace OpenCTT   
{
    public partial class AutomatedTTForm : Form
    {
        private ArrayList _sortedRoomsRelCapacityList;
        private bool _isRunFromEmptySolution;
        private Hashtable _coursesMapping;

        private AGlobal _aglobal;

        private BackgroundWorker _backWorker;

        private static ArrayList ALL_POSSIBLE_TS;
        private static int NUM_OF_ROOMS;
        private static int NUM_OF_SLOTS_PER_ROOM;
        private static int[] ROOM_CAPACITIES;

        public AutomatedTTForm()
        {
            InitializeComponent();
        }
        

        private void _startButton_Click(object sender, EventArgs e)
        {
            try
            {
                _isRunFromEmptySolution = _fromStartRadioButton.Checked;

                _startButton.Enabled = false;
                _stopButton.Enabled = true;
                _bestSolutionValueLabel.Text = "Started";
                _acceptBestSolutionButton.Enabled = false;

                _backWorker = new BackgroundWorker();
                _backWorker.WorkerReportsProgress = true;
                _backWorker.WorkerSupportsCancellation = true;

                _backWorker.DoWork += new DoWorkEventHandler(_backWorker_DoWork);
                _backWorker.ProgressChanged += new ProgressChangedEventHandler(_backWorker_ProgressChanged);
                _backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backWorker_RunWorkerCompleted);

                _backWorker.RunWorkerAsync();                
            }
            catch { }
        }


        void _backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _startButton.Enabled = true;
            _stopButton.Enabled = false;
            if (_aglobal.SolutionFoundCounter > 0)
            {
                _acceptBestSolutionButton.Enabled = true;
                _bestSolutionValueLabel.Text = AGlobal.BEST_GLOBAL_SOLUTION_VALUE.ToString();
            }
            
        }

        void _backWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {   
            if (e.UserState != null)
            {
                double[] s = (double[])e.UserState;
                _numOfFoundSolutionsLabel.Text = s[0].ToString();
                _bestSolutionValueLabel.Text = s[1].ToString();
            }


        }

        void _backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _aglobal = prepareDataForAutomatedTT();

            if (_aglobal._totalNodesForAllocation > 0)
            {
                try
                {
                    _aglobal.findBestSolution(_backWorker, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Number of lessons for allocation must be greather than 0!");

            }
        }



        private void _stopButton_Click(object sender, EventArgs e)
        {
            _backWorker.CancelAsync();
            _stopButton.Enabled = false;
        }


        private AGlobal prepareDataForAutomatedTT()
        {
            _coursesMapping = new Hashtable();

            int[] buildings = new int[1]; //to do
            buildings[0] = 0; // to do

            NUM_OF_ROOMS = AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Count;
            ROOM_CAPACITIES = new int[NUM_OF_ROOMS];
            int[] roomBuildings = new int[NUM_OF_ROOMS];
            ALL_POSSIBLE_TS = new ArrayList();
                        
            NUM_OF_SLOTS_PER_ROOM = AppForm.CURR_OCTT_DOC.getNumberOfDays() * AppForm.CURR_OCTT_DOC.IncludedTerms.Count;

            //
            _sortedRoomsRelCapacityList=this.sortRoomsRelCapacity();

            int n = 0;
            foreach (Room room in _sortedRoomsRelCapacityList)
            {
                ROOM_CAPACITIES[n] = room.getRoomCapacity();
                roomBuildings[n] = buildings[0]; //to do

                int wts = 0;
                for (int k = 0; k < AppForm.CURR_OCTT_DOC.getNumberOfDays(); k++)
                {
                    for (int j = 0; j < AppForm.CURR_OCTT_DOC.IncludedTerms.Count; j++)
                    {
                        wts++;
                        if (room.getAllowedTimeSlots()[j, k] == true) ALL_POSSIBLE_TS.Add(n * NUM_OF_SLOTS_PER_ROOM + wts);
                    }
                }

                n++;
            }           

            
            //prepare educational programs and courses
            
            Hashtable tempUsedTeachers = new Hashtable();
            Hashtable tempUsedEduPrograms = new Hashtable();            

            ArrayList allACoursesList = new ArrayList();            

            foreach (EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
            {
                foreach (EduProgram ep in epg.Nodes)
                {
                    foreach (Course course in ep.Nodes)
                    {
                        if (!course.TempIsPreparedForAutomatedTT)
                        {
                            ArrayList courseTotalPossibleTS = this.getPossibleTSForCourse(course);
                                              
                            Teacher teacher = (Teacher)course.getTeacher();
                            
                            int teacherIndex = AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.IndexOf(teacher);
                            ATeacher at;
                            if (!tempUsedTeachers.Contains(teacherIndex))
                            {
                                at = new ATeacher();
                                tempUsedTeachers.Add(teacherIndex, at);

                                //1                                
                                object[] args1 = new object[2];
                                args1[1] = Settings.SC_TEACHER_MAX_HOURS_DAILY_WEIGHT;

                                if (teacher.SCMaxHoursDaily != -1)
                                {                                    
                                    args1[0]=teacher.SCMaxHoursDaily;
                                }
                                else
                                {
                                    args1[0] = SCBaseSettings.TEACHER_MAX_HOURS_DAILY;
                                }

                                SCTeacherMaxHoursDaily sctmhd = new SCTeacherMaxHoursDaily(at, args1, null);
                                at.MySoftConstraints.Add(sctmhd);                                

                                //2
                                object[] args2 = new object[2];
                                args2[1] = Settings.SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT;

                                if (teacher.SCMaxHoursContinously != -1)
                                {
                                    args2[0] = teacher.SCMaxHoursContinously;
                                }
                                else
                                {
                                    args2[0] = SCBaseSettings.TEACHER_MAX_HOURS_CONTINUOUSLY;
                                }

                                SCTeacherMaxHoursContinuously sctmhc = new SCTeacherMaxHoursContinuously(at, args2, null);
                                at.MySoftConstraints.Add(sctmhc);

                                //3
                                object[] args3 = new object[2];
                                args3[1] = Settings.SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT;

                                if (teacher.SCMaxDaysPerWeek != -1)
                                {
                                    args3[0] = teacher.SCMaxDaysPerWeek;
                                }
                                else
                                {
                                    args3[0] = SCBaseSettings.TEACHER_MAX_DAYS_PER_WEEK;
                                }

                                SCTeacherMaxDaysPerWeek sctmdpw = new SCTeacherMaxDaysPerWeek(at, args3, null);
                                at.MySoftConstraints.Add(sctmdpw);

                            }
                            else
                            {
                                at = (ATeacher)tempUsedTeachers[teacherIndex];
                            }

                            //
                            AEduProgram aep;
                            int epgIndex = AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.IndexOf(epg);
                            int epIndex = epg.Nodes.IndexOf(ep);
                            string myKey = epgIndex + "," + epIndex;

                            if (!tempUsedEduPrograms.Contains(myKey))
                            {
                                aep = new AEduProgram();
                                tempUsedEduPrograms.Add(myKey, aep);                                
                            }
                            else
                            {
                                aep = (AEduProgram)tempUsedEduPrograms[myKey];                                
                            }

                            //
                            bool[] boolPossTS = this.convertTSListToBoolArray(courseTotalPossibleTS);
                            ACourse ac = new ACourse(aep, at, course.getGroupName(), boolPossTS, course.getReportName());
                            allACoursesList.Add(ac);
                            aep.MyCourses.Add(ac);                            
                            if (course.getGroupName() != null && course.getGroupName() != "")
                            {
                                if (!aep.MyIncludedGroups.Contains(course.getGroupName()))
                                {
                                    aep.MyIncludedGroups.Add(course.getGroupName());
                                }
                            }
                                                        
                            //sc for course
                            if (course.getNumberOfLessonsPerWeek() > 1)
                            {
                                int numOfLessPerWeek = course.getNumberOfLessonsPerWeek();
                                string clKey;
                                if (numOfLessPerWeek <= 9)
                                {
                                    clKey = numOfLessPerWeek.ToString();
                                }
                                else
                                {
                                    clKey = "default";
                                }

                                int[] lessonBlocksParam;

                                if (course.SCLessonBlocksParameters != null)
                                {
                                    lessonBlocksParam = course.SCLessonBlocksParameters;                                    

                                }
                                else
                                {
                                    lessonBlocksParam = (int[])SCBaseSettings.COURSE_LESSON_BLOCKS[clKey];
                                }

                                object[] args = new object[2];

                                args[0] = lessonBlocksParam;
                                args[1] = Settings.SC_COURSE_LESSON_BLOCKS_WEIGHT;

                                SCCourseLessonBlocks scclb = new SCCourseLessonBlocks(ac, args, null);
                                ac.MySoftConstraints.Add(scclb);

                            }



                            //


                            //courses mapping
                            int courseIndex = ep.Nodes.IndexOf(course);
                            _coursesMapping.Add(epgIndex + "," + epIndex + "," + courseIndex, ac);
                            //

                            ALessonNode alnode;
                            int numOfNodesToSolve = 0;

                            if (_fromCurrentStateRadioButton.Checked)
                            {
                                numOfNodesToSolve = course.getNumberOfUnallocatedLessons();                                

                                ArrayList myFixedTSList = course.getTimeSlotsOfMyAllocatedLessons();                                

                                foreach (int fts in myFixedTSList)
                                {                                    
                                    //fixed nodes                                    
                                    alnode = new ALessonNode(ac, fts, NUM_OF_SLOTS_PER_ROOM * NUM_OF_ROOMS);
                                    alnode.PositionInGlobalBestSolution = fts;
                                    ac.MyFixedLessonNodes.Add(alnode);
                                    at.MyFixedLessonNodes.Add(alnode);
                                }

                            }
                            else if (_fromStartRadioButton.Checked)
                            {
                                numOfNodesToSolve = course.getNumberOfLessonsPerWeek();
                            }


                            for (int nnode = 0; nnode < numOfNodesToSolve; nnode++)
                            {
                                //nodes to solve
                                alnode = new ALessonNode(ac, NUM_OF_SLOTS_PER_ROOM * NUM_OF_ROOMS);
                                ac.MyAllLessonNodesForAllocation.Add(alnode);
                                at.MyTempAllocatedLessonNodes.Add(alnode);
                            }

                            if (course.getCoursesToHoldTogetherList().Count > 0)
                            {
                                foreach(Course htCourse in course.getCoursesToHoldTogetherList())
                                {
                                    prepareDataForHTCourse(htCourse, at, ac, tempUsedEduPrograms, allACoursesList);
                                }
                            }                            

                            course.TempIsPreparedForAutomatedTT = true;
                        }

                    }//end of course loop
                }
            }//end epg loop
            

            //reset values for course.TempIsPreparedForAutomatedTT to false
            foreach (EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
            {
                foreach (EduProgram ep in epg.Nodes)
                {
                    foreach (Course course in ep.Nodes)
                    {
                        course.TempIsPreparedForAutomatedTT = false;
                    }
                }
            }

            ArrayList allATeachersList = new ArrayList();

            foreach (ATeacher ateacher in tempUsedTeachers.Values)
            {   
                allATeachersList.Add(ateacher);                
            }

            ArrayList allAEduProgramsList = new ArrayList();

            foreach (AEduProgram aEduProg in tempUsedEduPrograms.Values)
            {                
                allAEduProgramsList.Add(aEduProg);
            }

            //sc for ep
            foreach (string thisKey in tempUsedEduPrograms.Keys)
            {                
                AEduProgram aep = (AEduProgram)tempUsedEduPrograms[thisKey];

                char[] separator = new char[1];
                separator[0] = ',';

                string[] parts = thisKey.Split(separator, 2);             
                int epgIndex=Int32.Parse(parts[0]);
                int epIndex=Int32.Parse(parts[1]);
                                
                EduProgramGroup epg = (EduProgramGroup)AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes[epgIndex];
                EduProgram ep = (EduProgram)epg.Nodes[epIndex];   
             
                //
                if (aep.MyIncludedGroups.Count > 0)
                {
                    foreach (string groupName in aep.MyIncludedGroups)
                    {

                        //1                                
                        object[] args1 = new object[3];
                        args1[2] = Settings.SC_STUDENT_MAX_HOURS_DAILY_WEIGHT;
                        args1[1] = groupName;

                        if (ep.SCStudentMaxHoursDaily!= -1)
                        {
                            args1[0] = ep.SCStudentMaxHoursDaily;
                        }
                        else
                        {
                            args1[0] = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY;
                        }

                        SCStudentMaxHoursDaily scsmhd = new SCStudentMaxHoursDaily(aep, args1, null);
                        aep.MySoftConstraints.Add(scsmhd);

                        //2
                        object[] args2 = new object[3];
                        args2[2] = Settings.SC_STUDENT_NO_GAPS_WEIGHT;
                        args2[1] = groupName;

                        if (ep.SCStudentNoGapsGapIndicator != -1)
                        {
                            args2[0] = ep.SCStudentNoGapsGapIndicator;
                        }
                        else
                        {
                            args2[0] = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR;
                        }

                        SCStudentNoGaps scsng = new SCStudentNoGaps(aep,args2,null);
                        aep.MySoftConstraints.Add(scsng);

                        //3                                
                        object[] args3 = new object[3];
                        args3[2] = Settings.SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT;
                        args3[1] = groupName;

                        if (ep.SCStudentMaxHoursContinuously != -1)
                        {
                            args3[0] = ep.SCStudentMaxHoursContinuously;
                        }
                        else
                        {
                            args3[0] = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY;
                        }

                        SCStudentMaxHoursContinuously scsmhc = new SCStudentMaxHoursContinuously(aep, args3, null);
                        aep.MySoftConstraints.Add(scsmhc);

                        //4                                
                        object[] args4 = new object[3];
                        args4[2] = Settings.SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT;
                        args4[1] = groupName;

                        if (ep.SCStudentMaxDaysPerWeek != -1)
                        {
                            args4[0] = ep.SCStudentMaxDaysPerWeek;
                        }
                        else
                        {
                            args4[0] = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK;
                        }

                        SCStudentMaxDaysPerWeek scsmdpw = new SCStudentMaxDaysPerWeek(aep, args4, null);
                        aep.MySoftConstraints.Add(scsmdpw);

                        //5                                
                        object[] args5 = new object[3];
                        args5[2] = Settings.SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT;
                        args5[1] = groupName;

                        if (ep.SCStudentPreferredStartTimePeriod != -1)
                        {
                            args5[0] = ep.SCStudentPreferredStartTimePeriod;
                        }
                        else
                        {
                            args5[0] = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD;
                        }

                        SCStudentPreferredStartTimePeriod scspstp = new SCStudentPreferredStartTimePeriod(aep, args5, null);
                        aep.MySoftConstraints.Add(scspstp);
                        

                    }

                }
                else
                {
                    //1                                
                    object[] args1 = new object[3];
                    args1[2] = Settings.SC_STUDENT_MAX_HOURS_DAILY_WEIGHT;
                    args1[1] = null;

                    if (ep.SCStudentMaxHoursDaily != -1)
                    {
                        args1[0] = ep.SCStudentMaxHoursDaily;
                    }
                    else
                    {
                        args1[0] = SCBaseSettings.EP_STUDENT_MAX_HOURS_DAILY;
                    }

                    SCStudentMaxHoursDaily scsmhd = new SCStudentMaxHoursDaily(aep, args1, null);
                    aep.MySoftConstraints.Add(scsmhd);

                    //2
                    object[] args2 = new object[3];
                    args2[2] = Settings.SC_STUDENT_NO_GAPS_WEIGHT;
                    args2[1] = null;

                    if (ep.SCStudentNoGapsGapIndicator != -1)
                    {
                        args2[0] = ep.SCStudentNoGapsGapIndicator;
                    }
                    else
                    {
                        args2[0] = SCBaseSettings.EP_STUDENT_NO_GAPS_GAP_INDICATOR;
                    }

                    SCStudentNoGaps scsng = new SCStudentNoGaps(aep, args2, null);
                    aep.MySoftConstraints.Add(scsng);

                    //3                                
                    object[] args3 = new object[3];
                    args3[2] = Settings.SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT;
                    args3[1] = null;

                    if (ep.SCStudentMaxHoursContinuously != -1)
                    {
                        args3[0] = ep.SCStudentMaxHoursContinuously;
                    }
                    else
                    {
                        args3[0] = SCBaseSettings.EP_STUDENT_MAX_HOURS_CONTINUOUSLY;
                    }

                    SCStudentMaxHoursContinuously scsmhc = new SCStudentMaxHoursContinuously(aep, args3, null);
                    aep.MySoftConstraints.Add(scsmhc);

                    //4                                
                    object[] args4 = new object[3];
                    args4[2] = Settings.SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT;
                    args4[1] = null;

                    if (ep.SCStudentMaxDaysPerWeek != -1)
                    {
                        args4[0] = ep.SCStudentMaxDaysPerWeek;
                    }
                    else
                    {
                        args4[0] = SCBaseSettings.EP_STUDENT_MAX_DAYS_PER_WEEK;
                    }

                    SCStudentMaxDaysPerWeek scsmdpw = new SCStudentMaxDaysPerWeek(aep, args4, null);
                    aep.MySoftConstraints.Add(scsmdpw);

                    //5                                
                    object[] args5 = new object[3];
                    args5[2] = Settings.SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT;
                    args5[1] = null;

                    if (ep.SCStudentPreferredStartTimePeriod != -1)
                    {
                        args5[0] = ep.SCStudentPreferredStartTimePeriod;
                    }
                    else
                    {
                        args5[0] = SCBaseSettings.EP_STUDENT_PREFERRED_START_TIME_PERIOD;
                    }

                    SCStudentPreferredStartTimePeriod scspstp = new SCStudentPreferredStartTimePeriod(aep, args5, null);
                    aep.MySoftConstraints.Add(scspstp);
                    
                }
                                

            }



            Control.CheckForIllegalCrossThreadCalls = false;
            //Console.WriteLine(allATeachersList.Count);
            //Console.WriteLine(allAEduProgramsList.Count);
            
            AGlobal ag = new AGlobal(AppForm.CURR_OCTT_DOC.getNumberOfDays(), AppForm.CURR_OCTT_DOC.IncludedTerms.Count, NUM_OF_ROOMS, ROOM_CAPACITIES, roomBuildings, buildings, allACoursesList, allATeachersList, allAEduProgramsList);

            return ag;
        }


        private void prepareDataForHTCourse(Course htCourse, ATeacher at, ACourse startACourse, Hashtable tempUsedEduPrograms, ArrayList allACoursesList)
        {
            if (!htCourse.TempIsPreparedForAutomatedTT)
            {
                ArrayList courseTotalPossibleTS = this.getPossibleTSForCourse(htCourse);

                EduProgram ep = (EduProgram)htCourse.Parent;
                EduProgramGroup epg = (EduProgramGroup)ep.Parent;
                //
                AEduProgram aep;
                int epgIndex = AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.IndexOf(epg);
                int epIndex = epg.Nodes.IndexOf(ep);
                string myKey = epgIndex + "," + epIndex;

                if (!tempUsedEduPrograms.Contains(myKey))
                {
                    aep = new AEduProgram();
                    tempUsedEduPrograms.Add(myKey, aep);
                }
                else
                {
                    aep = (AEduProgram)tempUsedEduPrograms[myKey];                    
                }

                //

                bool[] boolPossTS = this.convertTSListToBoolArray(courseTotalPossibleTS);
                ACourse ac = new ACourse(aep, at, htCourse.getGroupName(), /*courseTotalPossibleTS,*/ boolPossTS, htCourse.getReportName());
                ac.IsHTCourse = true;
                allACoursesList.Add(ac);
                aep.MyCourses.Add(ac);
                startACourse.ACoursesHT.Add(ac);//add HT course

                //courses mapping
                int courseIndex = ep.Nodes.IndexOf(htCourse);
                _coursesMapping.Add(epgIndex + "," + epIndex + "," + courseIndex, ac);
                //

                ALessonNode alnode;
                int numOfNodesToSolve = 0;

                if (_fromCurrentStateRadioButton.Checked)
                {
                    numOfNodesToSolve = htCourse.getNumberOfUnallocatedLessons();

                    ArrayList myFixedTSList = htCourse.getTimeSlotsOfMyAllocatedLessons();

                    foreach (int fts in myFixedTSList)
                    {
                        //fixed nodes                        
                        alnode = new ALessonNode(ac, fts, NUM_OF_SLOTS_PER_ROOM * NUM_OF_ROOMS);
                        alnode.PositionInGlobalBestSolution = fts;
                        ac.MyFixedLessonNodes.Add(alnode);
                        at.MyFixedLessonNodes.Add(alnode);
                    }

                }
                else if (_fromStartRadioButton.Checked)
                {
                    numOfNodesToSolve = htCourse.getNumberOfLessonsPerWeek();
                }

                for (int nnode = 0; nnode < numOfNodesToSolve; nnode++)
                {
                    //nodes to solve
                    alnode = new ALessonNode(ac, NUM_OF_SLOTS_PER_ROOM * NUM_OF_ROOMS);
                    ac.MyAllLessonNodesForAllocation.Add(alnode);
                    at.MyTempAllocatedLessonNodes.Add(alnode);
                }

                htCourse.TempIsPreparedForAutomatedTT = true;
            }
        }


        private ArrayList getUnallowedTSForEpg(EduProgramGroup epg)
        {
            ArrayList epgUnallowedTS = new ArrayList();            

            int wtuts = 0;
            for (int k = 0; k < AppForm.CURR_OCTT_DOC.getNumberOfDays(); k++)
            {
                for (int j = 0; j < AppForm.CURR_OCTT_DOC.IncludedTerms.Count; j++)
                {
                    wtuts++;
                    if (epg.getAllowedTimeSlots()[j, k] == false)
                    {
                        for (int qq = 0; qq < NUM_OF_ROOMS; qq++)
                        {
                            epgUnallowedTS.Add(qq * NUM_OF_SLOTS_PER_ROOM + wtuts);
                        }
                    }
                }
            }


            return epgUnallowedTS;
        }


        private ArrayList getUnallowedTSForEp(EduProgram ep)
        {
            ArrayList epUnallowedTS = new ArrayList();            

            int wtutsEp = 0;
            for (int k = 0; k < AppForm.CURR_OCTT_DOC.getNumberOfDays(); k++)
            {
                for (int j = 0; j < AppForm.CURR_OCTT_DOC.IncludedTerms.Count; j++)
                {
                    wtutsEp++;
                    if (ep.getAllowedTimeSlots()[j, k] == false)
                    {
                        for (int qq = 0; qq < NUM_OF_ROOMS; qq++)
                        {
                            epUnallowedTS.Add(qq * NUM_OF_SLOTS_PER_ROOM + wtutsEp);
                        }
                    }
                }
            }

            return epUnallowedTS;
        }

        private ArrayList getPossibleTSForCourse(Course course)
        {
            EduProgram ep = (EduProgram)course.Parent;
            EduProgramGroup epg = (EduProgramGroup)ep.Parent;

            ArrayList epgUnallowedTS = this.getUnallowedTSForEpg(epg);
            ArrayList epUnallowedTS = this.getUnallowedTSForEp(ep);

            ArrayList courseTeacherUnallowedTS = this.getUnallowedTSForTeacher(course.getTeacher());
            //Console.WriteLine("Course: " + course.getName() + " TeacherTotalUnallowedTS: " + courseTeacherUnallowedTS.Count);

            ArrayList courseUnallowedTS = new ArrayList();            

            ArrayList crrList = course.getAllowedRoomsList();
            ArrayList crrIntList = new ArrayList();
            if (crrList != null && crrList.Count > 0)
            {
                foreach (Room room in crrList)
                {
                    int roomIndex = _sortedRoomsRelCapacityList.IndexOf(room);
                    crrIntList.Add(roomIndex);
                }
            }

            if (crrIntList.Count > 0)
            {
                for (int rsroom = 0; rsroom < NUM_OF_ROOMS; rsroom++)
                {
                    if (!crrIntList.Contains(rsroom))
                    {
                        for (int rs = 0; rs < NUM_OF_SLOTS_PER_ROOM; rs++)
                        {
                            int newitem = rsroom * NUM_OF_SLOTS_PER_ROOM + rs + 1;
                            courseUnallowedTS.Add(newitem);
                        }
                    }

                }
            }

            //
            int numOfSeatsNeeded = course.getNumberOfEnrolledStudents();
            ArrayList allUnallowedTSHT = new ArrayList();
            if (course.getCoursesToHoldTogetherList() != null && course.getCoursesToHoldTogetherList().Count > 0)
            {
                //Console.WriteLine(course.getCoursesToHoldTogetherList().Count);
                foreach (Course htCourse in course.getCoursesToHoldTogetherList())
                {
                    numOfSeatsNeeded += htCourse.getNumberOfEnrolledStudents();

                    ArrayList oneHtTS = this.getUnallowedTSForCourseHT(htCourse);

                    foreach (int ts in oneHtTS)
                    {
                        if (!allUnallowedTSHT.Contains(ts)) allUnallowedTSHT.Add(ts);
                    }
                }

            }            

            ArrayList totalPossibleTSList = new ArrayList();
            foreach (int ts in ALL_POSSIBLE_TS)
            {
                int roomIndex = (int)(ts-1) / NUM_OF_SLOTS_PER_ROOM;
                //Console.WriteLine(ts+" "+roomIndex);
                if (numOfSeatsNeeded <= ROOM_CAPACITIES[roomIndex])
                {
                    if (!epgUnallowedTS.Contains(ts) && !epUnallowedTS.Contains(ts) && !courseTeacherUnallowedTS.Contains(ts) && !courseUnallowedTS.Contains(ts) && !allUnallowedTSHT.Contains(ts))
                    {
                        totalPossibleTSList.Add(ts);
                    }
                }

            }
            
            //Console.WriteLine(totalPossibleTSList.Count);
            return totalPossibleTSList;
        }


        private ArrayList getUnallowedTSForCourseHT(Course course)
        {
            EduProgram ep = (EduProgram)course.Parent;
            EduProgramGroup epg = (EduProgramGroup)ep.Parent;

            ArrayList epgUnallowedTS = this.getUnallowedTSForEpg(epg);
            ArrayList epUnallowedTS = this.getUnallowedTSForEp(ep);

            ArrayList courseTeacherUnallowedTS = this.getUnallowedTSForTeacher(course.getTeacher());            

            ArrayList courseUnallowedTS = new ArrayList();

            ArrayList crrList = course.getAllowedRoomsList();
            ArrayList crrIntList = new ArrayList();
            if (crrList != null && crrList.Count > 0)
            {
                foreach (Room room in crrList)
                {
                    int roomIndex = _sortedRoomsRelCapacityList.IndexOf(room);
                    crrIntList.Add(roomIndex);
                }
            }

            if (crrIntList.Count > 0)
            {
                for (int rsroom = 0; rsroom < NUM_OF_ROOMS; rsroom++)
                {
                    if (!crrIntList.Contains(rsroom))
                    {
                        for (int rs = 0; rs < NUM_OF_SLOTS_PER_ROOM; rs++)
                        {
                            int newitem = rsroom * NUM_OF_SLOTS_PER_ROOM + rs + 1;
                            courseUnallowedTS.Add(newitem);
                        }
                    }

                }
            }


            ArrayList totalUnallowedTSList = new ArrayList();
            foreach (int ts in epgUnallowedTS)
            {
                if (!totalUnallowedTSList.Contains(ts)) totalUnallowedTSList.Add(ts);                
            }

            foreach (int ts in epUnallowedTS)
            {
                if (!totalUnallowedTSList.Contains(ts)) totalUnallowedTSList.Add(ts);
            }

            foreach (int ts in courseTeacherUnallowedTS)
            {
                if (!totalUnallowedTSList.Contains(ts)) totalUnallowedTSList.Add(ts);
            }

            foreach (int ts in courseUnallowedTS)
            {
                if (!totalUnallowedTSList.Contains(ts)) totalUnallowedTSList.Add(ts);
            }

            return totalUnallowedTSList;
        }


        private ArrayList getUnallowedTSForTeacher(Teacher teacher)
        {
            ArrayList teacherUnallowedTS = new ArrayList();
            
            int[] roomRestrictions = null;
            ArrayList rr = teacher.getAllowedRoomsList();
            if (rr != null && rr.Count > 0)
            {
                roomRestrictions = new int[rr.Count];
                int rri = 0;
                foreach (Room room in rr)
                {
                    int roomIndex = _sortedRoomsRelCapacityList.IndexOf(room);
                    roomRestrictions[rri] = roomIndex;
                    rri++;
                }
            }


            ArrayList tempUnallowedTSList = new ArrayList();
            int wtuts = 0;
            for (int k = 0; k < AppForm.CURR_OCTT_DOC.getNumberOfDays(); k++)
            {
                for (int j = 0; j < AppForm.CURR_OCTT_DOC.IncludedTerms.Count; j++)
                {
                    wtuts++;
                    if (teacher.getAllowedTimeSlots()[j, k] == false)
                    {
                        for (int qq = 0; qq < NUM_OF_ROOMS; qq++)
                        {
                            tempUnallowedTSList.Add(qq * NUM_OF_SLOTS_PER_ROOM + wtuts);
                        }
                    }
                }
            }

            //Console.WriteLine(tempUnallowedTSList.Count);

            int[] unallowedTS = new int[tempUnallowedTSList.Count];
            int tss = 0;
            //Console.WriteLine("New teacher");
            foreach (int tsindex in tempUnallowedTSList)
            {
                unallowedTS[tss] = tsindex;
                tss++;                
            }
           
            foreach (int unallTS in unallowedTS)
            {
                teacherUnallowedTS.Add(unallTS);
            }

            if (roomRestrictions != null && roomRestrictions.GetLength(0) > 0)
            {
                ArrayList rrList = new ArrayList();
                foreach (int rrcc in roomRestrictions)
                {
                    rrList.Add(rrcc);
                }

                for (int rsroom = 0; rsroom < NUM_OF_ROOMS; rsroom++)
                {
                    if (!rrList.Contains(rsroom))
                    {
                        for (int rs = 0; rs < NUM_OF_SLOTS_PER_ROOM; rs++)
                        {
                            int newitem = rsroom * NUM_OF_SLOTS_PER_ROOM + rs + 1;
                            if (!teacherUnallowedTS.Contains(newitem)) teacherUnallowedTS.Add(newitem);
                        }
                    }

                }
            }
            //

            return teacherUnallowedTS;
        }

        private bool[] convertTSListToBoolArray(ArrayList al)
        {
            bool[] myBoolTS = new bool[NUM_OF_SLOTS_PER_ROOM*NUM_OF_ROOMS];
            foreach (int n in al)
            {
                myBoolTS[n-1]=true;
            }

            return myBoolTS;
        }

        private void _acceptSolutionButton_Click(object sender, EventArgs e)
        {
            acceptTheBestSolution();

        }
        

        private  void acceptTheBestSolution()
        {
            /*foreach (ACourse ac in _aglobal._allACourses)
            {
                Console.WriteLine("------------");
                Console.WriteLine(ac.Name);
                foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                {
                    Console.WriteLine(aln.PositionInGlobalBestSolution);
                }

            }*/

            if (_isRunFromEmptySolution)
            {
                foreach (EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
                {
                    foreach (EduProgram ep in epg.Nodes)
                    {
                        ep.setTimetable(new ArrayList[AppForm.CURR_OCTT_DOC.IncludedTerms.Count, AppForm.CURR_OCTT_DOC.getNumberOfDays()]);
                                                
                        AppForm.CURR_OCTT_DOC.TotalNumberOfUnallocatedLessons = 0;
                        ep.setUnallocatedLessonsList(new ArrayList());
                    }
                }
            }


            foreach (EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
            {
                foreach (EduProgram ep in epg.Nodes)
                {
                    foreach (Course course in ep.Nodes)
                    {
                        int epgIndex = AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.IndexOf(epg);
                        int epIndex = epg.Nodes.IndexOf(ep);
                        int courseIndex = ep.Nodes.IndexOf(course);                    

                        ACourse ac = (ACourse)_coursesMapping[epgIndex + "," + epIndex + "," + courseIndex];
                        if (ac != null && !ac.IsHTCourse)
                        {
                            foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                            {                                
                                //Console.WriteLine(aln.PositionInBestSolution);
                                int indexRow, indexCol, roomIndex;
                                this.convertNumberOfTimeSlotToRowColumnAndRoom(aln.PositionInGlobalBestSolution,out indexRow,out indexCol,out roomIndex);
                                Room room = (Room)_sortedRoomsRelCapacityList[roomIndex];

                                ArrayList[,] mytt = ep.getTimetable();
                                ArrayList lessonsInOneTimeSlot;
                                if (mytt[indexRow, indexCol] == null)
                                {
                                    lessonsInOneTimeSlot = new ArrayList();
                                }
                                else
                                {
                                    lessonsInOneTimeSlot = mytt[indexRow, indexCol];
                                }


                                Object[] courseAndRoomPair = new Object[2];
                                courseAndRoomPair[0] = course;
                                courseAndRoomPair[1] = room;

                                lessonsInOneTimeSlot.Add(courseAndRoomPair);
                                mytt[indexRow, indexCol] = lessonsInOneTimeSlot;

                                //
                                if (!_isRunFromEmptySolution)
                                {
                                    ep.removeOneLessonFromUnallocatedLessonsModel(course);
                                    AppForm.CURR_OCTT_DOC.decrUnallocatedLessonsCounter(1);
                                }
                                //

                                if (course.getCoursesToHoldTogetherList().Count > 0)
                                {
                                    foreach (Course courseHT in course.getCoursesToHoldTogetherList())
                                    {
                                        EduProgram epHT = (EduProgram)courseHT.Parent;
                                        ArrayList[,] myttHT = epHT.getTimetable();

                                        ArrayList lessonsInOneTimeSlotHT;
                                        if (myttHT[indexRow, indexCol] == null)
                                        {
                                            lessonsInOneTimeSlotHT = new ArrayList();
                                        }
                                        else
                                        {
                                            lessonsInOneTimeSlotHT = myttHT[indexRow, indexCol];
                                        }

                                        Object[] courseAndRoomPairHT = new Object[2];

                                        courseAndRoomPairHT[0] = courseHT;
                                        courseAndRoomPairHT[1] = room;

                                        lessonsInOneTimeSlotHT.Add(courseAndRoomPairHT);
                                        myttHT[indexRow, indexCol] = lessonsInOneTimeSlotHT;

                                        //
                                        if (!_isRunFromEmptySolution)
                                        {
                                            epHT.removeOneLessonFromUnallocatedLessonsModel(courseHT);
                                        }
                                        //

                                    }
                                }



                            }

                        }                        
                    }
                }
            }

            //

            _acceptBestSolutionButton.Enabled = false;
            AppForm.getAppForm().getStatusBarPanel2().Text = AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
            AppForm.getAppForm().getCommandProcessor().emptyAllStacks();
            AppForm.getAppForm().getCommandProcessor().setUnReButtonState();

            int tabIndex = AppForm.getAppForm().getTreeTabControl().SelectedIndex;
            TreeNode workingNode=null;

            if (tabIndex == 0)
            {
                workingNode = AppForm.getAppForm().getCoursesTreeView().SelectedNode;
                if (workingNode == null) workingNode = AppForm.CURR_OCTT_DOC.CoursesRootNode;
                AppForm.CURR_OCTT_DOC.CTVSelectedNode = workingNode;
                AppForm.getAppForm().ctvRefreshTimetablePanel(workingNode, true, true);

                AppForm.getAppForm().getCoursesTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
                AppForm.getAppForm().getCoursesTreeView().SelectedNode = workingNode;
                AppForm.getAppForm().getCoursesTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().coursesTreeView_AfterSelect);
            }
            else if (tabIndex == 1)
            {
                workingNode = AppForm.getAppForm().getTeachersTreeView().SelectedNode;
                if (workingNode == null) workingNode = AppForm.CURR_OCTT_DOC.TeachersRootNode;
                AppForm.getAppForm().getTeachersTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);
                AppForm.getAppForm().getTeachersTreeView().SelectedNode = workingNode;
                AppForm.getAppForm().getTeachersTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().teachersTreeView_AfterSelect);

                AppForm.CURR_OCTT_DOC.TTVSelectedNode = workingNode;
                AppForm.getAppForm().ttvRefreshTimetablePanel(workingNode, true);

            }
            else if (tabIndex == 2)
            {
                workingNode = AppForm.getAppForm().getRoomsTreeView().SelectedNode;
                if (workingNode == null) workingNode = AppForm.CURR_OCTT_DOC.RoomsRootNode;
                AppForm.getAppForm().getRoomsTreeView().AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().roomsTreeView_AfterSelect);
                AppForm.getAppForm().getRoomsTreeView().SelectedNode = workingNode;
                AppForm.getAppForm().getRoomsTreeView().AfterSelect += new System.Windows.Forms.TreeViewEventHandler(AppForm.getAppForm().roomsTreeView_AfterSelect);

                AppForm.CURR_OCTT_DOC.RTVSelectedNode = workingNode;
                AppForm.getAppForm().rtvRefreshTimetablePanel(workingNode, true);
            }


        }


        private void convertNumberOfTimeSlotToRowColumnAndRoom(int tsIndex,out int indexRow,out int indexCol,out int roomIndex)
        {
            indexRow = (tsIndex - 1) % AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
            indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % NUM_OF_SLOTS_PER_ROOM ) / AppForm.CURR_OCTT_DOC.IncludedTerms.Count);
            roomIndex = (int)Math.Floor((decimal)(tsIndex - 1) / NUM_OF_SLOTS_PER_ROOM);
            //Console.WriteLine(tsIndex+ " " + indexRow + "  " + indexCol + "  " + roomIndex);
        }


        private ArrayList sortRoomsRelCapacity()
        {

            ArrayList tempList = new ArrayList();

            foreach (Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
            {
                bool needAdd = true;
                foreach (Room roomTemp in tempList)
                {
                    if (room.getRoomCapacity() <= roomTemp.getRoomCapacity())
                    {
                        tempList.Insert(tempList.IndexOf(roomTemp), room);
                        needAdd = false;
                        break;
                    }

                }

                if (needAdd) tempList.Add(room);
            }


            return tempList;            
        }
        
    }


}