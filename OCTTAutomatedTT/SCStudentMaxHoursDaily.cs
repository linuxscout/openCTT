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

namespace OpenCTT.Automated
{
    public class SCStudentMaxHoursDaily:AbstractSoftConstraint
    {

        public SCStudentMaxHoursDaily(object theObj, object[] myArgs, object[] relObjects)
            : base(theObj, myArgs, relObjects)
        {
            _scName = "Student - Maximum hours daily";
        }


        public override double evaluateSC()
        {
            AEduProgram aep = (AEduProgram)_theObj;
            int mySC_MaxHoursDaily = (int)_myArgs[0];
            string groupName = (string)_myArgs[1];
            double myWeight =(double)_myArgs[2];
            ///            

            int numOfIncludedDaysPerWeek = AGlobal.NUM_OF_INCLUDED_DAYS_PER_WEEK;
            int numOfTermsPerDay = AGlobal.NUM_OF_INCLUDED_TERMS_PER_DAY;
            int numOfSlotsPerRoom = numOfIncludedDaysPerWeek * numOfTermsPerDay;

            int[] lessonsDaily = new int[numOfIncludedDaysPerWeek];

            foreach (ACourse ac in aep.MyCourses)
            {
                if (ac.GroupName == groupName || ac.GroupName == "" || ac.GroupName == null)
                {
                    if (ac.MyFixedLessonNodes != null)
                    {
                        foreach (ALessonNode aln in ac.MyFixedLessonNodes)
                        {
                            int tsIndex = aln.CurrPosition;
                            if (tsIndex > 0)
                            {
                                int indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % numOfSlotsPerRoom) / numOfTermsPerDay);
                                lessonsDaily[indexCol]++;

                            }
                        }
                    }


                    if (ac.MyAllLessonNodesForAllocation != null)
                    {
                        foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                        {
                            int tsIndex = aln.CurrPosition;
                            if (tsIndex > 0)
                            {
                                int indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % numOfSlotsPerRoom) / numOfTermsPerDay);
                                lessonsDaily[indexCol]++;
                            }
                        }
                    }
                }
            }

            double res = 0;

            foreach (int n in lessonsDaily)
            {
                if (n > mySC_MaxHoursDaily) res = res + myWeight;                
            }

            return res;
        }

    }
}
