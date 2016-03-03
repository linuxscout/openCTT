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
    public class SCStudentNoGaps:AbstractSoftConstraint
    {

        public SCStudentNoGaps(object theObj, object[] myArgs, object[] relObjects)
            : base(theObj, myArgs, relObjects)
        {
            _scName = "Student - No Gaps";
        }


        public override double evaluateSC()
        {
            AEduProgram aep = (AEduProgram)_theObj;
            int mySC_GapIndicator = (int)_myArgs[0];
            string groupName = (string)_myArgs[1];
            double myWeight =(double)_myArgs[2];
            ///


            int numOfIncludedDaysPerWeek = AGlobal.NUM_OF_INCLUDED_DAYS_PER_WEEK;
            int numOfTermsPerDay = AGlobal.NUM_OF_INCLUDED_TERMS_PER_DAY;
            int numOfSlotsPerRoom = numOfIncludedDaysPerWeek * numOfTermsPerDay;

            bool[,] occupTSBool = new bool[numOfTermsPerDay, numOfIncludedDaysPerWeek];

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
                                int indexRow = (tsIndex - 1) % numOfTermsPerDay;
                                int indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % numOfSlotsPerRoom) / numOfTermsPerDay);
                                occupTSBool[indexRow, indexCol] = true;
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
                                int indexRow = (tsIndex - 1) % numOfTermsPerDay;
                                int indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % numOfSlotsPerRoom) / numOfTermsPerDay);
                                occupTSBool[indexRow, indexCol] = true;
                            }
                        }
                    }
                }
            }


            int numOfGaps = 0;
            int gapSize = 0;
            
            for (int j = 0; j < numOfIncludedDaysPerWeek; j++)
            {
                bool blockStarted = false;
                bool gapStarted = false;
                gapSize = 0;

                for (int k = 0; k < numOfTermsPerDay; k++)
                {
                    if (occupTSBool[k, j] == true)
                    {                        
                        if (!blockStarted)
                        {
                            blockStarted = true;
                        }

                        if (gapStarted)
                        {
                            //if (gapSize < 4) numOfGaps++;  //here                          
                            if (gapSize <= mySC_GapIndicator) numOfGaps++;
                            gapSize = 0;
                            gapStarted = false;
                        }

                    }
                    else
                    {
                        if (blockStarted)
                        {
                            gapStarted = true;
                            gapSize++;

                            blockStarted = false;
                        }
                        else if (gapStarted)
                        {
                            gapSize++;
                        }

                    }


                }
            }

            return numOfGaps * myWeight;
        }
    }
}
