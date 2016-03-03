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
    public class SCCourseLessonBlocks:AbstractSoftConstraint
    {

        public SCCourseLessonBlocks(object theObj, object[] myArgs, object[] relObjects)
            : base(theObj, myArgs, relObjects)
        {
            _scName = "Course - Lessons Blocks";
        }


        public override double evaluateSC()
        {
            ACourse ac = (ACourse)_theObj;
            int[] mySC_LessonBlocks = (int[])_myArgs[0];
            double myWeight =(double)_myArgs[1];

            int minBlockSize=(int)mySC_LessonBlocks[0];
            int minNumOfBlocks=(int)mySC_LessonBlocks[1];
            int maxNumOfBlocks=(int)mySC_LessonBlocks[2];            
            ///
            
            int numOfIncludedDaysPerWeek = AGlobal.NUM_OF_INCLUDED_DAYS_PER_WEEK;
            int numOfTermsPerDay = AGlobal.NUM_OF_INCLUDED_TERMS_PER_DAY;
            int numOfSlotsPerRoom = numOfIncludedDaysPerWeek * numOfTermsPerDay;

            int totalNumOfMyLessons = 0;
                       
            bool[,] occupTSBool = new bool[numOfTermsPerDay, numOfIncludedDaysPerWeek];
            int[,] occupRooms = new int[numOfTermsPerDay, numOfIncludedDaysPerWeek];

            if (ac.MyFixedLessonNodes != null)
            {
                foreach (ALessonNode aln in ac.MyFixedLessonNodes)
                {
                    totalNumOfMyLessons++;
                    int tsIndex = aln.CurrPosition;
                    if (tsIndex > 0)
                    {
                        int indexRow = (tsIndex - 1) % numOfTermsPerDay;
                        int indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % numOfSlotsPerRoom) / numOfTermsPerDay);
                        occupTSBool[indexRow, indexCol] = true;

                        int roomIndex = (int)Math.Floor((decimal)(tsIndex - 1) / numOfSlotsPerRoom);
                        occupRooms[indexRow, indexCol] = roomIndex;

                    }
                }
            }

            if (ac.MyAllLessonNodesForAllocation != null)
            {
                foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                {
                    totalNumOfMyLessons++;
                    int tsIndex = aln.CurrPosition;
                    if (tsIndex > 0)
                    {
                        int indexRow = (tsIndex - 1) % numOfTermsPerDay;
                        int indexCol = (int)Math.Floor((decimal)((tsIndex - 1) % numOfSlotsPerRoom) / numOfTermsPerDay);
                        occupTSBool[indexRow, indexCol] = true;

                        int roomIndex = (int)Math.Floor((decimal)(tsIndex - 1) / numOfSlotsPerRoom);
                        occupRooms[indexRow, indexCol] = roomIndex;
                    }
                }                
            }


            int currNumOfBlocks = 0;
            for (int j = 0; j < numOfIncludedDaysPerWeek; j++)
            {
                bool columnFinished = false;
                bool blockCheckStarted = false;
                int lastRowIndex = 0;
                int blockSize = 0;

                int lastRoomIndex = 0;

                for (int k = 0; k < numOfTermsPerDay; k++)
                {
                    if (occupTSBool[k, j] == true)
                    {
                        if (!blockCheckStarted)
                        {
                            blockCheckStarted = true;
                            blockSize++;
                            lastRowIndex = k;

                            lastRoomIndex = occupRooms[k, j];
                        }
                        else
                        {
                            if ((k - lastRowIndex) != 1)
                            {
                                return myWeight;
                            }
                            else
                            {
                                blockSize++;
                                lastRowIndex = k;

                                if (occupRooms[k, j] != lastRoomIndex) return myWeight;
                            }

                        }

                        if (k == numOfTermsPerDay - 1)
                        {
                            if (blockSize >= minBlockSize)
                            {
                                currNumOfBlocks++;
                                blockSize = 0;
                            }
                            else
                            {
                                return myWeight;
                            }
                        }

                    }
                    else
                    {
                        if (blockCheckStarted && !columnFinished)
                        {
                            if (blockSize >= minBlockSize)
                            {
                                currNumOfBlocks++;
                                columnFinished = true;
                                blockSize = 0;
                            }
                            else
                            {
                                return myWeight;
                            }
                        }

                    }


                }
            }

            if (currNumOfBlocks <= maxNumOfBlocks && currNumOfBlocks >= minNumOfBlocks)
            {                
                return 0;
            }
            else
            {             
                return myWeight;
            }
        }

    }
}
