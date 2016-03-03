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
    public class ALessonNode
    {
        private static double THETA_MAX = 100;
        private static double THETA_MIN = 1;
        private static double THETA_START = 100;
        private static double RO = 0.1;

        private int _myPosInConflictTable;
        private int _myLSPos; //for local search

        //predecessor fields were introduced because we wanted to have two-dimensional pheromone table
        //but in that case problems with memory occured, so we reverted to one-dimensional table
        //private int _myCurrentPredecessor;
        //private int _myPredecessorInLocalBestSolution;
        //private int _myPredecessorInGlobalBestSolution;
        
        private bool[] _myConflictTable;

        private ACourse _myACourse;

        private int _currPosition;
        private int _positionInGlobalBestSolution;
        private int _posInBestLocalSolution;

        //private double[,] _pheromoneTable;
        private double[] _pheromoneTable;

        public ALessonNode(ACourse myACourse, int numOfPossTS)
        {
            _myACourse = myACourse;            
            _currPosition = 0;
            _positionInGlobalBestSolution = 0;
            _posInBestLocalSolution = 0;

            //_pheromoneTable = new double[numOfPossTS, numOfPossTS];
            _pheromoneTable = new double[numOfPossTS];

            for (int m = 0; m < numOfPossTS; m++)
            {
                /*for (int n = 0; n < numOfPossTS; n++)
                {                    
                    _pheromoneTable[m, n] = THETA_START;
                }*/
                _pheromoneTable[m] = THETA_START;
            }

        }

        public ALessonNode(ACourse myCourse, int fixedPosition, int numOfPossTS)
            : this(myCourse, numOfPossTS)
        {
            _currPosition = fixedPosition;
            _positionInGlobalBestSolution = fixedPosition;
            _posInBestLocalSolution = fixedPosition;
        }


        public ACourse MyACourse
        {
            get { return _myACourse; }
        }

        public bool[] MyConflictTable
        {
            get { return _myConflictTable; }
        }        

        public int CurrPosition
        {
            get { return _currPosition; }
            set { _currPosition = value; }
        }

        public int PositionInGlobalBestSolution
        {
            get { return _positionInGlobalBestSolution; }
            set { _positionInGlobalBestSolution = value; }
        }

        public int PositionInLocalBestSolution
        {
            get { return _posInBestLocalSolution; }
            set { _posInBestLocalSolution = value; }
        }

        /*public int MyCurrentPredecessor
        {
            get { return _myCurrentPredecessor; }
        }*/

        /*public int MyPredecessorInLocalBestSolution
        {
            get { return _myPredecessorInLocalBestSolution; }
            set { _myPredecessorInLocalBestSolution = value; }
        }*/

        /*public int MyPredecessorInGlobalBestSolution
        {
            get { return _myPredecessorInGlobalBestSolution; }
            set { _myPredecessorInGlobalBestSolution = value; }
        }*/

        public int MyLSPos
        {
            get { return _myLSPos; }
            set { _myLSPos = value; }
        }

        public int MyPosInConflictTable
        {
            get { return _myPosInConflictTable; }
            set { _myPosInConflictTable = value; }
        }

      

        public void updatePheromoneTable(int tsIndex,bool isGlobalBestUpdate, double deltaTheta)
        {            
            /*int rowForUpdate;
            if (isGlobalBestUpdate)
            {
                rowForUpdate = this.MyPredecessorInGlobalBestSolution;                
            }
            else
            {
                rowForUpdate = this.MyPredecessorInLocalBestSolution;                
            }
            
            for (int n = 0; n < _pheromoneTable.GetLength(1); n++)
            {
                if (n == tsIndex - 1)
                {
                    _pheromoneTable[rowForUpdate, n] = (double)(_pheromoneTable[rowForUpdate, n] * (1 - RO) + deltaTheta);                    
                }
                else
                {
                    _pheromoneTable[rowForUpdate, n] = (double)(_pheromoneTable[rowForUpdate, n] * (1 - RO));                    
                }

                if (_pheromoneTable[rowForUpdate, n] < THETA_MIN)
                {
                    _pheromoneTable[rowForUpdate, n] = THETA_MIN;
                }
                else if (_pheromoneTable[rowForUpdate, n] > THETA_MAX)
                {
                    _pheromoneTable[rowForUpdate, n] = THETA_MAX;
                }               

            }*/

            for (int n = 0; n < _pheromoneTable.GetLength(0); n++)
            {
                if (n == tsIndex - 1)
                {
                    _pheromoneTable[n] = (double)(_pheromoneTable[n] * (1 - RO) + deltaTheta);
                }
                else
                {
                    _pheromoneTable[n] = (double)(_pheromoneTable[n] * (1 - RO));
                }

                if (_pheromoneTable[n] < THETA_MIN)
                {
                    _pheromoneTable[n] = THETA_MIN;
                }
                else if (_pheromoneTable[n] > THETA_MAX)
                {
                    _pheromoneTable[n] = THETA_MAX;
                }

            }


        }

        

        public void createConflictTable(ArrayList allACourses, ArrayList allFixedTS)
        {
            //conflict table:
            //in fact, conflict table should be defined for courses, not for lesson nodes
            //this is TO DO item (it works now, but consumes more memory)

            //if cell== true -> only one TS (for one room - only one cell in box) is in conflict
            //if cell==false -> all TS (for all rooms and TS - whole column in box) are in conflict
                        
            ArrayList resultList = new ArrayList();

            //at first, check all fixed nodes
            //can THIS COURSE go with FIXED_ALN?            
            int p = 0;
            foreach (ALessonNode fixedaln in allFixedTS)
            {
                fixedaln.MyPosInConflictTable = p;
                //check fixedaln
                bool cg = this.checkCanGoTogether_AC_ALN(this.MyACourse, fixedaln);
                resultList.Add(cg);
                p++;
            }

            foreach (ACourse ac in allACourses)
            {               
                if (!ac.IsHTCourse)
                {
                    if (ac.NumOfLessonNodesForAllocation > 0)
                    {
                        foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                        {
                            aln.MyPosInConflictTable = p;
                            //check aln (can THIS COURSE go with ALN)
                            bool cg = this.checkCanGoTogether_AC_ALN(this.MyACourse, aln);
                            resultList.Add(cg);
                            p++;                            
                        }
                    }
                }
            }

            _myConflictTable = new bool[resultList.Count];
            int n = 0;           
            
            foreach (bool cg in resultList)
            {
                _myConflictTable[n] = cg;
                n++;                
            }            

        }


        private bool checkCanGoTogether_AC_ALN(ACourse ac, ALessonNode afixedln)
        {
            bool canGoTogether = true;
            //check teacher
            if (afixedln.MyACourse.MyATeacher == ac.MyATeacher)
            {
                canGoTogether=false;
            }
            else
            {
                if (afixedln.MyACourse.MyAEduProgram == ac.MyAEduProgram)//same edu program
                {
                    if (ac.GroupName == null || ac.GroupName == "")//ac is not group
                    {
                        canGoTogether=false;
                    }
                    else//ac is group
                    {
                        if (afixedln.MyACourse.GroupName == null || afixedln.MyACourse.GroupName == "")//afixedln is not group
                        {
                            canGoTogether=false;
                        }
                        else//afixedln is group
                        {
                            if (afixedln.MyACourse.GroupName == ac.GroupName)//the same groups
                            {
                                canGoTogether=false;
                            }
                        }
                    }
                }
            }

            if (canGoTogether)
            {               
                if (afixedln.MyACourse.ACoursesHT.Count > 0)
                {
                    foreach (ACourse ac_afixedln_ht in afixedln.MyACourse.ACoursesHT)
                    {
                        if (ac_afixedln_ht.MyAEduProgram == ac.MyAEduProgram)// the same edu program
                        {
                            if (ac.GroupName == null || ac.GroupName == "")//ac is not group
                            {
                                canGoTogether = false;
                            }
                            else//ac is group
                            {
                                if (ac_afixedln_ht.GroupName == null || ac_afixedln_ht.GroupName == "")//afixedln is not group
                                {
                                    canGoTogether = false;
                                }
                                else//afixedln is group
                                {
                                    if (ac_afixedln_ht.GroupName == ac.GroupName)
                                    {
                                        canGoTogether = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            if (canGoTogether)
            {
                if (ac.ACoursesHT.Count > 0)
                {
                    foreach (ACourse acht in ac.ACoursesHT)
                    {
                        if(!this.checkCanGoTogether_AC_HT_ALN(acht,afixedln)) return false;
                    }
                }
            }


            return canGoTogether;

        }

        private bool checkCanGoTogether_AC_HT_ALN(ACourse acht, ALessonNode afixedln)
        {
            bool canGoTogether = true;

            if (afixedln.MyACourse.MyAEduProgram == acht.MyAEduProgram)
            {
                if (acht.GroupName == null || acht.GroupName == "")//aln is not group
                {
                    canGoTogether = false;
                }
                else//aln is group
                {
                    if (afixedln.MyACourse.GroupName == null || afixedln.MyACourse.GroupName == "")//afixedln is not group
                    {
                        canGoTogether = false;
                    }
                    else//afixedln is group
                    {
                        if (afixedln.MyACourse.GroupName == acht.GroupName)
                        {
                            canGoTogether = false;
                        }
                    }
                }
            }

           
            if (canGoTogether)
            {
                if (afixedln.MyACourse.ACoursesHT.Count > 0)
                {
                    foreach (ACourse ac_afixedln_ht in afixedln.MyACourse.ACoursesHT)
                    {
                        if (ac_afixedln_ht.MyAEduProgram == acht.MyAEduProgram)// the same edu program
                        {

                            if (acht.GroupName == null || acht.GroupName == "")//ac is not group
                            {
                                canGoTogether = false;
                            }
                            else//ac is group
                            {
                                if (ac_afixedln_ht.GroupName == null || ac_afixedln_ht.GroupName == "")//afixedln is not group
                                {
                                    canGoTogether = false;
                                }
                                else//afixedln is group
                                {
                                    if (ac_afixedln_ht.GroupName == acht.GroupName)
                                    {
                                        canGoTogether = false;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            return canGoTogether;
        }



        public int selectNewTimeSlot(ArrayList partialSolution, bool[] acMyBoolPossTSTemp, Random randObj)
        {
            int totalLen = _pheromoneTable.GetLength(0);

            int myPredecessor;
            int count=partialSolution.Count;
            if (count > 0)
            {
                myPredecessor = ((ALessonNode)partialSolution[count - 1]).CurrPosition-1;                
            }
            else
            {
                myPredecessor = 0;
            }

            
            //_myCurrentPredecessor = myPredecessor;
            
            double[] totalProbabilityTable = new double[totalLen];

            double totalSumPheromoneT = 0.0;
            double totalSumTotalSquareProbT = 0.0;

            ACourse ac = this.MyACourse;
            ATeacher at = ac.MyATeacher;
            
            for (int n = 0; n < totalLen; n++)
            {
                if (acMyBoolPossTSTemp[n])
                {   
                    //totalSumPheromoneT += _pheromoneTable[myPredecessor, n];
                    totalSumPheromoneT += _pheromoneTable[n];
                }
                
            }

            for (int n = 0; n < totalLen; n++)
            {
                if (acMyBoolPossTSTemp[n])
                {                    
                    //totalProbabilityTable[n] = Math.Pow(((double)_pheromoneTable[myPredecessor, n] / (double)totalSumPheromoneT), 2.0);
                    totalProbabilityTable[n] = Math.Pow(((double)_pheromoneTable[n] / (double)totalSumPheromoneT), 2.0);
                    totalSumTotalSquareProbT += totalProbabilityTable[n];                    
                }
            }            

            double runningtotal = 0.0;
            double randValue = randObj.Next(0, 100000);
            randValue = randValue / 100000.0;

            int winningIndex = 0;

            for (int n = 0; n < totalLen; n++)
            {
                if (acMyBoolPossTSTemp[n])
                {
                    runningtotal += totalProbabilityTable[n] / totalSumTotalSquareProbT;

                    if (runningtotal > randValue)
                    {
                        winningIndex = n + 1;
                        return winningIndex;
                    }
                    
                }
            }           

            return winningIndex;
        }

    }
}
