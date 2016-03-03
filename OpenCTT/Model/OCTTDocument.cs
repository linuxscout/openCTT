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
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;



namespace OpenCTT
{
	/// <summary>
	/// Summary description for OCTTDocument.
	/// </summary>
	public class OCTTDocument
	{
		private static ResourceManager RES_MANAGER;	

		private int _documentType; //1-school, 2-university
		private string _documentVersion;
		private string _eduInstitutionName;
		private string _schoolYear;

		private string _fileName;
		private string _fullPath;

		private ArrayList _courseTypesList;
		private ArrayList _teacherTitlesList;
		private ArrayList _teacherEduRanksList;
		
		private int _totalNumberOfUnallocatedLessons;

		private bool [] _includedDays;
		private ArrayList _includedTerms;

		private TreeNode _coursesRootNode;
		private TreeNode _teachersRootNode;
		private TreeNode _roomsRootNode;

		private EduProgram _shownEduProgram;	

		private TreeNode _ctvSelectedNode;
		private TreeNode _ttvSelectedNode;
		private TreeNode _rtvSelectedNode;


		public OCTTDocument()
		{
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.OCTTDocument",this.GetType().Assembly);
			}

			_courseTypesList= new ArrayList();
			_teacherTitlesList= new ArrayList();
			_teacherEduRanksList= new ArrayList();

			_totalNumberOfUnallocatedLessons=0;

			_includedDays=new bool[7];
			_includedTerms=new ArrayList();

			_coursesRootNode= new TreeNode();
			_teachersRootNode= new TreeNode();
			_roomsRootNode= new TreeNode();

			_shownEduProgram=null;

			_ctvSelectedNode=null;
			_ttvSelectedNode=null;
			_rtvSelectedNode=null;
		}

		public int DocumentType
		{
			get
			{
				return _documentType;
			}
			set
			{
				_documentType=value;
			}
		}

		public string DocumentVersion
		{
			get
			{
				return _documentVersion;
			}
			set
			{
				_documentVersion=value;
			}
		}

		public string EduInstitutionName
		{
			get
			{
				return _eduInstitutionName;
			}
			set
			{
				_eduInstitutionName=value;
			}
		}

		public string SchoolYear
		{
			get
			{
				return _schoolYear;
			}
			set
			{
				_schoolYear=value;
			}
		}

		public string RootNodeText
		{
			get
			{
				string text=_eduInstitutionName;

				if(_schoolYear!="")
				{
					text+=", "+_schoolYear;
				}
				return text;
			}
		}

		public string FileName
		{
			get
			{
				return _fileName;
			}
			set
			{
				_fileName=value;
			}
		}


		public string FullPath
		{
			get
			{
				return _fullPath;
			}
			set
			{
				_fullPath=value;
			}
		}

		public ArrayList CourseTypesList
		{
			get
			{
				return _courseTypesList;
			}
			set
			{
				_courseTypesList=value;
			}
		}

		public ArrayList TeacherTitlesList
		{
			get
			{
				return _teacherTitlesList;
			}
			set
			{
				_teacherTitlesList=value;
			}
		}

		public ArrayList TeacherEduRanksList
		{
			get
			{
				return _teacherEduRanksList;
			}
			set
			{
				_teacherEduRanksList=value;
			}
		}

		public int TotalNumberOfUnallocatedLessons
		{
			get
			{
				return _totalNumberOfUnallocatedLessons;
			}
			set
			{
				_totalNumberOfUnallocatedLessons=value;
			}
		}

		public bool [] IncludedDays
		{
			get
			{
				return _includedDays;
			}
			set
			{
				_includedDays=value;
			}
		}

		public ArrayList IncludedTerms
		{
			get
			{
				return _includedTerms;
			}
			set
			{
				_includedTerms=value;
			}
		}

		public TreeNode CoursesRootNode
		{
			get
			{
				return _coursesRootNode;
			} 
		}

		public TreeNode TeachersRootNode
		{
			get
			{
				return _teachersRootNode;
			}
		}

		public TreeNode RoomsRootNode
		{
			get
			{
				return _roomsRootNode;
			}
		}

		public EduProgram ShownEduProgram
		{
			get
			{
				return _shownEduProgram;
			}
			set
			{
				_shownEduProgram=value;
			}
		}

		public TreeNode CTVSelectedNode
		{
			get
			{
				return _ctvSelectedNode;
			}
			set
			{
				_ctvSelectedNode=value;
			}
		}

		public TreeNode TTVSelectedNode
		{
			get
			{
				return _ttvSelectedNode;
			}
			set
			{
				_ttvSelectedNode=value;
			}
		}

		public TreeNode RTVSelectedNode
		{
			get
			{
				return _rtvSelectedNode;
			}
			set
			{
				_rtvSelectedNode=value;
			}
		}

		



		public string getNumOfUnallocatedLessonsStatusText()
		{	
			return RES_MANAGER.GetString("getNumOfUnallocatedLessonsStatusText.text")+" "+_totalNumberOfUnallocatedLessons;
		}

		public void decrUnallocatedLessonsCounter(int step)
		{			
			_totalNumberOfUnallocatedLessons=_totalNumberOfUnallocatedLessons-step;
		}

		public void incrUnallocatedLessonsCounter(int step)
		{
			_totalNumberOfUnallocatedLessons=_totalNumberOfUnallocatedLessons+step;
		}

		public int getNumberOfDays()
		{
			int number=0;
			foreach(bool b in _includedDays)
			{
				if(b==true)
				{
					number++;
				}
			}

			return number;
		}

		public bool getIsDayIncluded(int index)
		{
			return _includedDays[index];
		}

		public void setIsDayIncluded(int index, bool isIncl)
		{
			_includedDays[index]=isIncl;
		}

		public int getDayIndexInModel(int index)
		{
			int indexInModel=-1;
			for(int n=0;n<=index;n++)
			{
				if(_includedDays[n]==true)
				{
					indexInModel++;
				}
			}
			return indexInModel;
		}

        public int getRealWeekDayIndex(int indexInModel)
        {
            int realWeekIndex = 0;
            int n = 0;
            int k = 0;
            while(n<indexInModel)
            {
                
                if (_includedDays[k] == true)
                {
                    n++;
                    realWeekIndex = k+1;
                }

                k++;
            }
            return realWeekIndex;
        }	

		public void refreshTreeRootText()
		{
			_coursesRootNode.Text = this.RootNodeText;
			_teachersRootNode.Text = this.RootNodeText;
			_roomsRootNode.Text = this.RootNodeText;
		}

		

	}
}
