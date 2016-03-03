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
using System.Text;
using System.Collections;

namespace OpenCTT.Automated
{
    public class ACourse
    {
        private ArrayList _mySoftConstraints;

        private string _name;

        private ATeacher _myATeacher;
        private AEduProgram _myAEduProgram;
        private string _groupName;

        private ArrayList _myFixedLessonNodes;
        private ArrayList _myAllLessonNodesForAllocation;
        private int _numOfLessonNodesForAllocation;// this field exists only to increase speed of calculation
        private int _numOfPossTSAtStart; // this field exists only to increase speed of calculation - for sorting
        private bool _isHTCourse;

        private ArrayList _aCoursesHT;        
        private bool[] _myBoolPosTS;

        

        public ACourse(AEduProgram myAEduProgram, ATeacher myATeacher, string groupName, bool[] myBoolPosTS, string name)
        {
            _name=name;
            _myAEduProgram = myAEduProgram;
            _myATeacher = myATeacher;
            _groupName = groupName;
            _myAllLessonNodesForAllocation = new ArrayList();            
            _myBoolPosTS = myBoolPosTS;
            
            _numOfPossTSAtStart = AGlobal.getNumOfPossTS(_myBoolPosTS);

            _mySoftConstraints = new ArrayList();
        }

        public ArrayList MySoftConstraints
        {
            get { return _mySoftConstraints; }
        }


        public string Name
        {
            get { return _name; }
        }

        public int NumOfPossTSAtStart
        {
            get { return _numOfPossTSAtStart; }            
        }

        


        public ArrayList MyAllLessonNodesForAllocation
        {
            get { return _myAllLessonNodesForAllocation; }
        }

        public int NumOfLessonNodesForAllocation
        {
            get { return _numOfLessonNodesForAllocation; }
            set { _numOfLessonNodesForAllocation = value; }
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        public ATeacher MyATeacher
        {
            get { return _myATeacher; }
        }

        public AEduProgram MyAEduProgram
        {
            get { return _myAEduProgram; }
        }

        public bool IsHTCourse
        {
            get { return _isHTCourse; }
            set { _isHTCourse = value; }
        }

        public ArrayList MyFixedLessonNodes
        {
            get
            {
                if (_myFixedLessonNodes != null)
                {
                    return _myFixedLessonNodes;
                }
                else
                {
                    _myFixedLessonNodes = new ArrayList();
                    return _myFixedLessonNodes;
                }
            }
        }

       

        public bool[] MyBoolPosTS
        {
            get { return _myBoolPosTS; }
        }

        public ArrayList ACoursesHT
        {
            get {
                if (_aCoursesHT != null)
                {
                    return _aCoursesHT;
                }
                else
                {
                    _aCoursesHT = new ArrayList();
                    return _aCoursesHT;
                }
            }
        }

    }
}
