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
    public class AEduProgram
    {
        private ArrayList _mySoftConstraints;

        private ArrayList _myCourses;

        private ArrayList _myIncludedGroups;

        public AEduProgram()
        {
            _myCourses = new ArrayList();
            _myIncludedGroups = new ArrayList();

            _mySoftConstraints = new ArrayList();
        }
        
        public ArrayList MySoftConstraints
        {
            get { return _mySoftConstraints; }
        }

        public ArrayList MyCourses
        {
            get{return _myCourses;}
        }

        public ArrayList MyIncludedGroups
        {
            get { return _myIncludedGroups; }
        }

    }
}
