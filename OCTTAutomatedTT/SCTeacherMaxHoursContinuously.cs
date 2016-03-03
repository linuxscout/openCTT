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
    public class SCTeacherMaxHoursContinuously:AbstractSoftConstraint
    {

        public SCTeacherMaxHoursContinuously(Object theObj, Object[] myArgs, Object[] relObjects)
            : base(theObj, myArgs, relObjects)
        {
            _scName = "Teacher - Maximum hours continuously";
        }


        public override double evaluateSC()
        {
            ATeacher at = (ATeacher)_theObj;
            int mySC_MaxHoursContinuously = (int)_myArgs[0];
            double myWeight =(double)_myArgs[1];
                        

            int numOfIncludedDaysPerWeek = AGlobal.NUM_OF_INCLUDED_DAYS_PER_WEEK;
            int numOfTermsPerDay = AGlobal.NUM_OF_INCLUDED_TERMS_PER_DAY;
            int numOfSlotsPerRoom = numOfIncludedDaysPerWeek * numOfTermsPerDay;

            bool[,] occupTSBool = new bool[numOfTermsPerDay, numOfIncludedDaysPerWeek];

            if (at.MyFixedLessonNodes != null)
            {
                foreach (ALessonNode aln in at.MyFixedLessonNodes)
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

            if (at.MyTempAllocatedLessonNodes != null)
            {
                foreach (ALessonNode aln in at.MyTempAllocatedLessonNodes)
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



            for (int j = 0; j < occupTSBool.GetLength(1); j++)
            {
                int hoursCont = 0;

                bool blockCheckStarted = false;
                int lastRowIndex = 0;

                for (int k = 0; k < occupTSBool.GetLength(0); k++)
                {
                    if (occupTSBool[k, j] == true)
                    {
                        if (!blockCheckStarted)
                        {
                            blockCheckStarted = true;
                            lastRowIndex = k;
                            hoursCont = 1;
                        }
                        else
                        {
                            lastRowIndex = k;
                            hoursCont++;
                        }

                    }
                    else
                    {
                        if (blockCheckStarted)
                        {
                            if (hoursCont > mySC_MaxHoursContinuously) return myWeight;
                            hoursCont = 0;
                        }

                    }
                }

                //end of column
                if (hoursCont > mySC_MaxHoursContinuously) return myWeight;

            }

            return 0;
            
        }  

    }
}
