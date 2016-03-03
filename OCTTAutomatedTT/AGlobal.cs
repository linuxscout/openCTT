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
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;

namespace OpenCTT.Automated
{
    public class AGlobal
    {
        private static int BGSV_CHANGE_COUNTER;
        private static double LS_END_COUNTER;

        //for ant colony optimisation
        public static int PHEROMONE_UPDATE_STEP=3;
        private double _gama = 0.70; //(0-GLOBAL; 1-LOCAL)

        public static int NUM_OF_INCLUDED_DAYS_PER_WEEK;
        public static int NUM_OF_INCLUDED_TERMS_PER_DAY;        
      
        private int _fixedTSCount;
        public static double BEST_GLOBAL_SOLUTION_VALUE;
        private int _solutionFoundTotalCounter;

        private Random _randomObj;
                
        private int _numOfTimeSlotsPerRoom;
        private int _numOfRooms;
        private int[] _roomCapacities;
        private int[] _roomBuildings;
        private int[] _buildings;


        private ArrayList _allACourses;
        private ArrayList _allATeachers;
        private ArrayList _allAEduPrograms;
                
        private ArrayList _allFixedTS;

        public int _totalNodesForAllocation;


        public AGlobal(int numOfIncludedDaysPerWeek, int numOfIncludedTermsPerDay, int numOfRooms, int[] roomCapacities, int[] roomBuildings, int[] buildings, ArrayList allACourses, ArrayList allATeachers, ArrayList allAEduPrograms)
        {
            LS_END_COUNTER = 5.0;
            BGSV_CHANGE_COUNTER = 0;

            NUM_OF_INCLUDED_DAYS_PER_WEEK = numOfIncludedDaysPerWeek;
            NUM_OF_INCLUDED_TERMS_PER_DAY = numOfIncludedTermsPerDay;

            _numOfTimeSlotsPerRoom = NUM_OF_INCLUDED_DAYS_PER_WEEK * NUM_OF_INCLUDED_TERMS_PER_DAY;
            
            _solutionFoundTotalCounter = 0;
            _randomObj = new Random();

            _numOfRooms = numOfRooms;
            _roomCapacities = roomCapacities;
            _roomBuildings = roomBuildings;
            _buildings = buildings;

            _allACourses = allACourses;
            _allATeachers = allATeachers;
            _allAEduPrograms = allAEduPrograms;            

            _allACourses=this.sortAllACoursesList(_allACourses);

            _allFixedTS = new ArrayList();

            _totalNodesForAllocation = 0;

            bool addFixed = true;
            for (int n = 0; n < 2; n++)
            {
                if (n == 1) addFixed = false;

                foreach (ACourse ac in _allACourses)
                {
                    if(addFixed) ac.NumOfLessonNodesForAllocation = ac.MyAllLessonNodesForAllocation.Count;

                    if (!ac.IsHTCourse)
                    {
                        if (!addFixed)
                        {
                            if (ac.NumOfLessonNodesForAllocation > 0)
                            {
                                _totalNodesForAllocation += ac.NumOfLessonNodesForAllocation;
                                                                
                                foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                                {                                
                                    aln.createConflictTable(_allACourses, _allFixedTS);
                                }
                            }
                        }else
                        {                            
                            foreach (ALessonNode aln in ac.MyFixedLessonNodes)
                            {
                                _allFixedTS.Add(aln);
                            }
                        }
                    }
                }
            }
            
            //Console.WriteLine(_totalNodesForAllocation);
            //Console.WriteLine("Total fixed nodes: "+_allFixedTS.Count);
            
        }


        public void findBestSolution(BackgroundWorker worker, DoWorkEventArgs e)
        {

            BEST_GLOBAL_SOLUTION_VALUE = 1000000;
            
            double bestLocalValue = 1000000;

            DateTime startTime = DateTime.Now;
            //Console.WriteLine(startTime);
            //Console.WriteLine(startTime.Add(new TimeSpan(0, _timeSpanMin,0)));
            
            ArrayList partialSolution = _allFixedTS;
            
            _fixedTSCount = partialSolution.Count;          

            _solutionFoundTotalCounter = 0;            
            int pheromoneUpdateStepCounter = 0;                  

            for (int kk = 0; kk < 500000;kk++ )
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;                    
                }
                else
                {   
                    /*if(DateTime.Now>startTime.Add(new TimeSpan(0, 0, _timeSpanMin))){
                        break;
                    }*/                 
                                        
                    foreach (ACourse ac in _allACourses)
                    {                        
                        if (!ac.IsHTCourse)
                        {
                            if (ac.NumOfLessonNodesForAllocation > 0)
                            {
                                bool[] acMyBoolPossTSTemp = (bool[])ac.MyBoolPosTS.Clone();
                                this.filterMeRegardingCurrentPartialSolution(ac, partialSolution, acMyBoolPossTSTemp);
                                
                                foreach (ALessonNode aln in ac.MyAllLessonNodesForAllocation)
                                {
                                    if (getNumOfPossTS(acMyBoolPossTSTemp) > 0)
                                    {                                        

                                        int newNodePos = aln.selectNewTimeSlot(partialSolution, acMyBoolPossTSTemp, _randomObj);
                                     
                                        aln.CurrPosition = newNodePos;                                       
                                        partialSolution.Add(aln);
                                        
                                        this.removeUnpossibleWholeTSFromACourse(aln, acMyBoolPossTSTemp);                                        
                                    }
                                    else
                                    {                                        
                                        this.resetPartialSolution(partialSolution);
                                        goto exitloop;

                                    }
                                }
                                
                            }
                        }
                    }//end of _allCourses loop
                    
                                        
                    _solutionFoundTotalCounter++;
                    pheromoneUpdateStepCounter++;                    

                    double currSolutionValue = this.calculateCurrentSolutionValue(partialSolution);
                    if (currSolutionValue < bestLocalValue)
                    {   
                        bestLocalValue = currSolutionValue;                        
                        this.setNewLocalBestSolution(partialSolution);

                    }

                    //
                }

                ////
                exitloop:

                if (pheromoneUpdateStepCounter == PHEROMONE_UPDATE_STEP)
                {
                                  
                    //local search
                    //Console.WriteLine("Local best BEFORE locale search: " + bestLocalValue);
                    
                    double lsBestLocalValue = this.doLocalSearch(worker, e,  bestLocalValue, partialSolution);

                    //Console.WriteLine("Local best AFTER locale search: " + lsBestLocalValue);                    
                    //if (bestLocalValue != lsBestLocalValue) Console.WriteLine("Optimised - improved for: " + (bestLocalValue-lsBestLocalValue));
                    
                    bestLocalValue = lsBestLocalValue;///!!!
                    //if (bestLocalValue!=100) Console.WriteLine("Local best AFTER locale search: " + bestLocalValue);
                    //

                    
                    //choose how to make pheromone update
                    double probabilityForUpdateWithLocalBest = _gama * (System.Convert.ToDouble(bestLocalValue) / System.Convert.ToDouble(BEST_GLOBAL_SOLUTION_VALUE));
                    double randValue = _randomObj.Next(0, 1000);
                    randValue = randValue / 1000;
                    //Console.WriteLine(probabilityForUpdateWithLocalBest);        
                    

                    if (randValue < probabilityForUpdateWithLocalBest)
                    {
                        //Console.WriteLine("GLOBAL best=" + BEST_GLOBAL_SOLUTION_VALUE + "  LOCAL best" + bestLocalValue + " Update with best LOCAL: probForLocal=" + probabilityForUpdateWithLocalBest + " random=" + randValue);
                        //update pheromone tables with local best solution
                        //Console.WriteLine("update LOCAL BEST");
                        for (int pos = _fixedTSCount; pos < partialSolution.Count; pos++)
                        {
                            ALessonNode aln = (ALessonNode)partialSolution[pos];
                            //aln.updatePheromoneTable(aln.PositionInLocalBestSolution,false,(double) (100 / bestLocalValue));
                            double updVal = Math.Abs(50 * (1.2 - (bestLocalValue / BEST_GLOBAL_SOLUTION_VALUE)));
                            aln.updatePheromoneTable(aln.PositionInLocalBestSolution, false, updVal);
                        }

                    }
                    else
                    {
                        //Console.WriteLine("GLOBAL best=" + BEST_GLOBAL_SOLUTION_VALUE + "  LOCAL best" + bestLocalValue + " Update with best GLOBAL: probForLocal=" + probabilityForUpdateWithLocalBest + " random=" + randValue);
                        //update pheromone tables with GLOBAL BEST solution
                        //Console.WriteLine("update GLOBAL BEST");                        
                        for (int pos = _fixedTSCount; pos < partialSolution.Count; pos++)
                        {
                            ALessonNode aln = (ALessonNode)partialSolution[pos];                            
                            //aln.updatePheromoneTable(aln.PositionInGlobalBestSolution, true, (double)(100 / BEST_GLOBAL_SOLUTION_VALUE));
                            double updVal = Math.Abs(50 * (1.2 - (bestLocalValue / BEST_GLOBAL_SOLUTION_VALUE)));
                            aln.updatePheromoneTable(aln.PositionInGlobalBestSolution, true, updVal);
                        }

                    }

                    //Console.WriteLine(bestLocalValue + "   " + BEST_GLOBAL_SOLUTION_VALUE);

                    if (bestLocalValue < BEST_GLOBAL_SOLUTION_VALUE)
                    {                        
                        this.setNewGlobalBestSolution(bestLocalValue, partialSolution);
                        BGSV_CHANGE_COUNTER = 0;
                    }
                    else
                    {
                        BGSV_CHANGE_COUNTER++;
                    }                   

                    pheromoneUpdateStepCounter = 0;
                    bestLocalValue = 1000000;


                    double[] s = new double[2];
                    s[0] = _solutionFoundTotalCounter;
                    s[1] = BEST_GLOBAL_SOLUTION_VALUE;
                    worker.ReportProgress(10, s);

                    if(BEST_GLOBAL_SOLUTION_VALUE==0) break;

                    //Console.WriteLine(BEST_GLOBAL_SOLUTION_VALUE);
                }

                this.resetPartialSolution(partialSolution);
                
            }

            if (_solutionFoundTotalCounter == 0)
            {
                MessageBox.Show("Sorry, but no feasable solution found");
            }
            else
            {
                //MessageBox.Show("At least one feasible solution found");
            }
            
        }        

        private void removeUnpossibleWholeTSFromACourse(ALessonNode afixedln, bool[] acMyBoolPossTSTemp)
        {
            int tsBaseIndex = (afixedln.CurrPosition-1) % _numOfTimeSlotsPerRoom + 1;
                        
            for (int k = 0; k < _numOfRooms; k++)
            {
                int tsToRemove = k * _numOfTimeSlotsPerRoom + tsBaseIndex;            
                acMyBoolPossTSTemp[tsToRemove-1]=false;                
            }
        }       


        public static int getNumOfPossTS(bool[] boolTS)
        {
            int qq=0;
            for (int n = 0; n < boolTS.GetLength(0);n++ )
            {
                if (boolTS[n] == true) qq++;
            }

            return qq;
        }
                

        private ArrayList sortAllACoursesList(ArrayList allACoursesList)
        {
            ArrayList tempList = new ArrayList();
                       
            foreach (ACourse ac in allACoursesList)
            {
                bool needAdd = true;
                foreach (ACourse acTemp in tempList)
                {
                    if(ac.NumOfPossTSAtStart<=acTemp.NumOfPossTSAtStart)
                    {
                        tempList.Insert(tempList.IndexOf(acTemp), ac);
                        needAdd = false;
                        break;
                    }                    

                }
                
                if(needAdd)  tempList.Add(ac);
                                
            }

            return tempList;
        }



        private double calculateCurrentSolutionValue(ArrayList partialSolution)
        {
            double currSolutionValue = 0;
            foreach (ATeacher at in _allATeachers)
            {
                foreach (AbstractSoftConstraint sc in at.MySoftConstraints)
                {
                    currSolutionValue = currSolutionValue+sc.evaluateSC();
                }
            }
            
            foreach (ACourse ac in _allACourses)
            {
                if (!ac.IsHTCourse)
                {                    

                    foreach (AbstractSoftConstraint sc in ac.MySoftConstraints)
                    {
                        currSolutionValue = currSolutionValue + sc.evaluateSC();
                    }

                }
            }

            foreach(AEduProgram aep in _allAEduPrograms)
            {
                foreach (AbstractSoftConstraint sc in aep.MySoftConstraints)
                {
                    currSolutionValue = currSolutionValue + sc.evaluateSC();
                }
                
            }

            return currSolutionValue;

        }

        private void setNewGlobalBestSolution(double bestLocalValue, ArrayList partialSolution)
        {
            BEST_GLOBAL_SOLUTION_VALUE = bestLocalValue;            

            for (int pos = _fixedTSCount; pos < partialSolution.Count; pos++)
            {
                ALessonNode aln = (ALessonNode)partialSolution[pos];               
                aln.PositionInGlobalBestSolution = aln.PositionInLocalBestSolution;
                //aln.MyPredecessorInGlobalBestSolution = aln.MyPredecessorInLocalBestSolution;                
            }            
        }


        private void setNewLocalBestSolution(ArrayList partialSolution)
        {
            for (int pos = _fixedTSCount; pos < partialSolution.Count; pos++)
            {
                ALessonNode aln = (ALessonNode)partialSolution[pos];
                aln.PositionInLocalBestSolution = aln.CurrPosition;
                //aln.MyPredecessorInLocalBestSolution = aln.MyCurrentPredecessor;
            }
        }


        public int SolutionFoundCounter
        {
            get { return _solutionFoundTotalCounter; }
        }

        private void resetPartialSolution(ArrayList partialSolution)
        {
            int partialSolutionCount = partialSolution.Count;
            for (int pos = _fixedTSCount; pos < partialSolutionCount; pos++)
            {
                ALessonNode alnreset = (ALessonNode)partialSolution[pos];
                alnreset.CurrPosition = 0;
            }

            int removeCount = partialSolution.Count - _fixedTSCount;
            partialSolution.RemoveRange(_fixedTSCount, removeCount);
        }


        private void filterMeRegardingCurrentPartialSolution(ACourse ac, ArrayList partialSolution, bool[] acMyBoolPossTSTemp)
        {
            bool[] myConflictTable = ((ALessonNode)ac.MyAllLessonNodesForAllocation[0]).MyConflictTable;
                        
            foreach (ALessonNode aln in partialSolution)
            {                
                int posInCT = aln.MyPosInConflictTable;                
                if (myConflictTable[posInCT])
                {
                    acMyBoolPossTSTemp[aln.CurrPosition - 1] = false;                    
                }
                else
                {                    
                    this.removeUnpossibleWholeTSFromACourse(aln, acMyBoolPossTSTemp);
                }

            }

        }

        private double doLocalSearch(BackgroundWorker worker, DoWorkEventArgs e,  double bestLocalValue, ArrayList theSolution)
        {            
            int theSolutionCount = theSolution.Count;
            int repeatCounter = 0;
            double lastLV = bestLocalValue;            

            while (true)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }

                bestLocalValue = doPartialOptmisation(bestLocalValue, theSolution, theSolutionCount);
                //Console.WriteLine("Best local value after LS: " + bestLocalValue);
                if (bestLocalValue == lastLV)
                {
                    repeatCounter++;
                    if (repeatCounter >= LS_END_COUNTER)
                    {                        
                        return bestLocalValue;
                    }
                }
                else
                {
                    lastLV = bestLocalValue;
                    repeatCounter = 0;                   

                    if (BGSV_CHANGE_COUNTER >= 1)
                    {
                        BGSV_CHANGE_COUNTER = 0;
                        LS_END_COUNTER = LS_END_COUNTER * 1.2;                        
                        if (LS_END_COUNTER > 500) LS_END_COUNTER = LS_END_COUNTER / 1.2;
                    }
                }

            }
            
        }

        private double doPartialOptmisation(double bestLocalValue, ArrayList theSolution, int theSolutionCount)
        {            
            try
            {
                ArrayList theSolutionCopy = new ArrayList();
                foreach (ALessonNode aln in theSolution)
                {
                    aln.CurrPosition = aln.PositionInLocalBestSolution;
                    theSolutionCopy.Add(aln);                    
                }

                ArrayList coursesForLSOptimisationList = new ArrayList();
                //int randNumOfCourses = (int)_randomObj.Next(1, 3);
                int randNumOfCourses = 1; //temp
                //Console.WriteLine("BROJ PREDMETA: "+randNumOfCourses);
                int cNumTotal = randNumOfCourses;//!?
                int cNum = 0;

                //double rand = _randomObj.Next(0, 1000);
                //rand = rand / 1000;
                //if (rand < 0.5)
                { 
                    while (true)
                    {
                        int m = theSolutionCount - _fixedTSCount;
                        int randValue = (int)_randomObj.Next(0, m);
                        int alnIndexForMove = _fixedTSCount + randValue;
                        ALessonNode alnInMove = (ALessonNode)theSolutionCopy[alnIndexForMove];
                        ACourse aCourse = (ACourse)alnInMove.MyACourse;

                        if (!coursesForLSOptimisationList.Contains(aCourse))
                        {
                            coursesForLSOptimisationList.Add(aCourse);
                            cNum++;
                            if (cNum == cNumTotal) break;
                        }
                    }

                }
                /*else
                {
                    ArrayList testCList = new ArrayList();
                    double maxLSVal = 0;
                    ACourse maxCourse = null;
                    foreach (ACourse testCourse in _allACourses)
                    {
                        testCList.Clear();
                        testCList.Add(testCourse);
                        double testLSSolutionValue = this.calculateLSLocalSolutionValue(testCList);
                        if (testLSSolutionValue >= maxLSVal)
                        {
                            maxLSVal = testLSSolutionValue;
                            maxCourse = testCourse;
                        }

                    }

                    coursesForLSOptimisationList.Add(maxCourse);
                }*/
                

                double startLSLocalSolutionValue = this.calculateLSLocalSolutionValue(coursesForLSOptimisationList);
                double bestLSLocalSolutionValue = startLSLocalSolutionValue;
                
                if (bestLSLocalSolutionValue > 0)
                {
                    int coursesInOptCount = coursesForLSOptimisationList.Count;
                    object[] boolCoursePossTSAtStart = new object[coursesInOptCount];

                    foreach (ACourse aCourseInLS in coursesForLSOptimisationList)
                    {
                        foreach (ALessonNode alnor in aCourseInLS.MyAllLessonNodesForAllocation)
                        {                            
                            theSolutionCopy.Remove(alnor);
                        }
                    }

                    int currCourseIndex = 0;
                    bool[] acMyBoolPossTSAtStart=null;
                    foreach (ACourse aCourseInLS in coursesForLSOptimisationList)
                    {
                        acMyBoolPossTSAtStart = (bool[])aCourseInLS.MyBoolPosTS.Clone();
                        
                        this.filterMeRegardingCurrentPartialSolution(aCourseInLS, theSolutionCopy, acMyBoolPossTSAtStart);
                        boolCoursePossTSAtStart[currCourseIndex] = acMyBoolPossTSAtStart;
                        currCourseIndex++;
                    }

                    currCourseIndex = 0;
                    ArrayList smallPartSolution = new ArrayList();
                                        
                    ArrayList freeTSListCourseFirstVisit = new ArrayList();
                    ArrayList[] courseFreeTSList = new ArrayList[coursesInOptCount];

                    bool isCourseBacktracking = false;

                    while (true)//START of BIG loop
                    {
                        ACourse aCourseInLS = (ACourse)coursesForLSOptimisationList[currCourseIndex];

                        ArrayList nodesForOptimisationOfOneCourse = new ArrayList();

                        foreach (ALessonNode alno in aCourseInLS.MyAllLessonNodesForAllocation)
                        {
                            nodesForOptimisationOfOneCourse.Add(alno);
                        }

                        ArrayList freeTSListForCourse;
                        int nodesForOptimisationOfOneCourseCount = nodesForOptimisationOfOneCourse.Count;                        

                        int freeTSListForCourseCount;
                        int workingNodeForCombination;

                        if (isCourseBacktracking)
                        {
                            workingNodeForCombination = nodesForOptimisationOfOneCourseCount - 1;
                            freeTSListForCourse = courseFreeTSList[currCourseIndex];                            
                            isCourseBacktracking = false;
                        }
                        else
                        {
                            //CLONE()???                                                
                            bool[] acMyBoolPossTSTempTT2 = (bool[])boolCoursePossTSAtStart[currCourseIndex];//????
                            bool[] acMyBoolPossTSTemp = new bool[acMyBoolPossTSTempTT2.GetLength(0)];
                            int q = 0;
                            foreach (bool bl in acMyBoolPossTSTempTT2)
                            {
                                acMyBoolPossTSTemp[q] = bl;
                                q++;
                            }

                            if (currCourseIndex > 0)
                            {
                                this.filterMeRegardingCurrentPartialSolution(aCourseInLS, smallPartSolution, acMyBoolPossTSTemp);
                            }

                            freeTSListForCourse = new ArrayList();
                            int ts = 1;                            
                            foreach (bool possTS in acMyBoolPossTSTemp)
                            {
                                if (possTS)
                                {                                    
                                    freeTSListForCourse.Add(ts);
                                }
                                
                                ts++;
                                
                            }

                            this.resetLSCourseNodesPositions(aCourseInLS);

                            courseFreeTSList[currCourseIndex] = freeTSListForCourse;

                            workingNodeForCombination = 0;
                        }

                        freeTSListForCourseCount = freeTSListForCourse.Count;

                        while (true)//start of SMALL lop (inside nodes of one course)
                        {
                            ALessonNode alno = (ALessonNode)nodesForOptimisationOfOneCourse[workingNodeForCombination];
                            alno.MyLSPos++;

                            if (alno.MyLSPos > (freeTSListForCourseCount - 1))//exit from list of possible TS
                            {
                                if (workingNodeForCombination > 0)//backtracking
                                {
                                    workingNodeForCombination--;
                                }
                                else//prvi node od predmeta
                                {
                                    if (currCourseIndex == 0)
                                    {
                                        //calculateCurrentFULLSolutionValue
                                        //return from COMPLETE method                                        

                                        foreach (ACourse theC in coursesForLSOptimisationList)
                                        {
                                            foreach (ALessonNode aln in theC.MyAllLessonNodesForAllocation)
                                            {
                                                aln.CurrPosition = aln.PositionInLocalBestSolution;
                                                //aln.PositionInLocalBestSolution = aln.CurrPosition;
                                                theSolutionCopy.Add(aln);
                                            }
                                        }

                                        double currSolutionValue = this.calculateCurrentSolutionValue(theSolutionCopy);
                                        if (currSolutionValue < bestLocalValue)
                                        {
                                            bestLocalValue = currSolutionValue;
                                        }                                        
                                        
                                        return bestLocalValue;
                                        
                                    }
                                    else
                                    {
                                        currCourseIndex--;
                                        isCourseBacktracking = true;
                                        break;
                                    }                                    
                                }
                            }
                            else//ok
                            {
                                if (isLocalSearchNodeStateOK(nodesForOptimisationOfOneCourse, workingNodeForCombination, alno.MyLSPos, freeTSListForCourse))
                                {
                                    if (workingNodeForCombination == nodesForOptimisationOfOneCourseCount - 1)//ZADNJI NODE
                                    {
                                        foreach (ALessonNode aln5 in nodesForOptimisationOfOneCourse)                                        
                                        {
                                            smallPartSolution.Add(aln5);                                            
                                        }

                                        if (currCourseIndex == (coursesInOptCount - 1))//last course
                                        {
                                            //have new combination
                                            //check ls solution value
                                                                                        
                                            double lsSolutionValue = this.calculateLSLocalSolutionValue(coursesForLSOptimisationList);

                                            if (lsSolutionValue < bestLSLocalSolutionValue)
                                            {
                                                bestLSLocalSolutionValue = lsSolutionValue;                                                

                                                foreach (ACourse theC in coursesForLSOptimisationList)
                                                {                                                    
                                                    foreach (ALessonNode aln in theC.MyAllLessonNodesForAllocation)
                                                    {
                                                        aln.PositionInLocalBestSolution = aln.CurrPosition;                                                        
                                                    }                                                    
                                                }


                                                if (lsSolutionValue == 0)
                                                {
                                                    foreach (ALessonNode aln1 in smallPartSolution)
                                                    {
                                                        theSolutionCopy.Add(aln1);
                                                    }                                                    

                                                    foreach (ALessonNode aln2 in smallPartSolution)
                                                    {
                                                        theSolutionCopy.Remove(aln2);
                                                    }

                                                    smallPartSolution.Clear();                                                    
                                                    return (bestLocalValue - (startLSLocalSolutionValue - bestLSLocalSolutionValue));
                                                }

                                            }
                                            else
                                            {
                                                smallPartSolution.Clear();
                                            }

                                        }
                                        else
                                        {
                                            currCourseIndex++;
                                            break;
                                        }

                                    }
                                    else//not last node
                                    {
                                        ALessonNode alnoNext = (ALessonNode)nodesForOptimisationOfOneCourse[workingNodeForCombination + 1];
                                        alnoNext.MyLSPos = alno.MyLSPos;
                                        workingNodeForCombination++;
                                    }
                                }
                            }


                        }//end of small loop

                    }//END of BIG loop

                }
                else
                {
                    //Console.WriteLine("It's already zero");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.Source+ "\n" + ex.StackTrace);

            }


            return bestLocalValue;

        }


        private bool isLocalSearchNodeStateOK(ArrayList nodesForOptimisationOfOneCourse, int workingNodeForCombination, int nodeLSLastPos, ArrayList freeTSListForCourse)
        {
            try
            {
                int newTestPos = (int)freeTSListForCourse[nodeLSLastPos];

                for (int n = 0; n < workingNodeForCombination; n++)
                {                    
                    ALessonNode alnoPrev = (ALessonNode)nodesForOptimisationOfOneCourse[n];
                    int previousPos = (int)freeTSListForCourse[alnoPrev.MyLSPos];
                    int numOfTS = NUM_OF_INCLUDED_DAYS_PER_WEEK * NUM_OF_INCLUDED_TERMS_PER_DAY;
                    if ((previousPos % numOfTS) == (newTestPos % numOfTS))
                    {                        
                        return false;
                    }                    
                }

                ALessonNode alno = (ALessonNode)nodesForOptimisationOfOneCourse[workingNodeForCombination];
                alno.CurrPosition = newTestPos;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + workingNodeForCombination + "\n" + nodeLSLastPos);
            }


            return true;
        }

        private double calculateLSLocalSolutionValue(ArrayList acList)
        {
            double lsSolutionValue = 0;

            foreach (ACourse ac in acList)
            {
                ATeacher at = ac.MyATeacher;                

                foreach (AbstractSoftConstraint sc in at.MySoftConstraints)
                {
                    lsSolutionValue = lsSolutionValue + sc.evaluateSC();
                }


                if (!ac.IsHTCourse)//?? check this for AEP soft constraints
                {                    
                    foreach (AbstractSoftConstraint sc in ac.MySoftConstraints)
                    {
                        lsSolutionValue = lsSolutionValue + sc.evaluateSC();
                    }
                    
                    AEduProgram aep = (AEduProgram)ac.MyAEduProgram;

                    foreach (AbstractSoftConstraint sc in aep.MySoftConstraints)
                    {
                        lsSolutionValue = lsSolutionValue + sc.evaluateSC();
                    }                    
                }
            }

            return lsSolutionValue;
        }


        private void resetLSCourseNodesPositions(ACourse ac)
        {
            int kk = -1;
            foreach (ALessonNode alnor in ac.MyAllLessonNodesForAllocation)
            {
                alnor.MyLSPos = kk;
                kk++;
            }

        }        

    }


}