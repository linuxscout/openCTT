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
using System.Collections;
using System.Text;

namespace OpenCTT
{
    public class SCBaseSettings
    {
        public static int TEACHER_MAX_DAYS_PER_WEEK;
        public static int TEACHER_MAX_HOURS_DAILY;
        public static int TEACHER_MAX_HOURS_CONTINUOUSLY;

        public static int EP_STUDENT_MAX_HOURS_CONTINUOUSLY;
        public static int EP_STUDENT_MAX_HOURS_DAILY;
        public static int EP_STUDENT_MAX_DAYS_PER_WEEK;
        public static int EP_STUDENT_NO_GAPS_GAP_INDICATOR;
        public static int EP_STUDENT_PREFERRED_START_TIME_PERIOD;        

        public static Hashtable COURSE_LESSON_BLOCKS;

        static SCBaseSettings()
        {
            setSettings();
        }


        public static void setSettings()
        {
            TEACHER_MAX_DAYS_PER_WEEK = 1;
            TEACHER_MAX_HOURS_DAILY = 4;
            TEACHER_MAX_HOURS_CONTINUOUSLY = 4;
                        
            EP_STUDENT_MAX_HOURS_CONTINUOUSLY = 6;
            EP_STUDENT_MAX_HOURS_DAILY = 7;            
            EP_STUDENT_MAX_DAYS_PER_WEEK = 6;
            EP_STUDENT_NO_GAPS_GAP_INDICATOR = 4;
            EP_STUDENT_PREFERRED_START_TIME_PERIOD = 1;


            COURSE_LESSON_BLOCKS = new Hashtable();
            int[] lesson2 = new int[3];
            lesson2[0] = 2;//minBlockSize
            lesson2[1] = 1;//minNumOfBlocks
            lesson2[2] = 1;//maxNumOfBlocks
            COURSE_LESSON_BLOCKS.Add("2", lesson2);

            int[] lesson3 = new int[3];
            lesson3[0] = 3;
            lesson3[1] = 1;
            lesson3[2] = 1;
            COURSE_LESSON_BLOCKS.Add("3", lesson3);

            int[] lesson4 = new int[3];
            lesson4[0] = 2;
            lesson4[1] = 1;
            lesson4[2] = 2;
            COURSE_LESSON_BLOCKS.Add("4", lesson4);

            int[] lesson5 = new int[3];
            lesson5[0] = 2;
            lesson5[1] = 2;
            lesson5[2] = 2;
            COURSE_LESSON_BLOCKS.Add("5", lesson5);

            int[] lesson6 = new int[3];
            lesson6[0] = 2;
            lesson6[1] = 2;
            lesson6[2] = 3;
            COURSE_LESSON_BLOCKS.Add("6", lesson6);

            int[] lesson7 = new int[3];
            lesson7[0] = 2;
            lesson7[1] = 2;
            lesson7[2] = 3;
            COURSE_LESSON_BLOCKS.Add("7", lesson7);

            int[] lesson8 = new int[3];
            lesson8[0] = 2;
            lesson8[1] = 2;
            lesson8[2] = 4;
            COURSE_LESSON_BLOCKS.Add("8", lesson8);

            int[] lesson9 = new int[3];
            lesson9[0] = 2;
            lesson9[1] = 2;
            lesson9[2] = 4;
            COURSE_LESSON_BLOCKS.Add("9", lesson9);

            int[] lesson_default = new int[3];
            lesson_default[0] = 2;
            lesson_default[1] = 3;
            lesson_default[2] = 5;
            COURSE_LESSON_BLOCKS.Add("default", lesson_default);


        }
    }

    
}
