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
using System.IO;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Windows.Forms;


using OCTTPluginInterface;


namespace OpenCTT
{
	
	public class PluginServices : IPluginHost   
	{		
		public PluginServices()
		{
		}
	
		private Types.AvailablePluginsCollection _availablePluginsCollection = new Types.AvailablePluginsCollection();
		
		
		public Types.AvailablePluginsCollection MyAvailablePluginsCollection
		{
			get {return _availablePluginsCollection;}
			set {_availablePluginsCollection = value;}
		}		
		
		public void FindPlugins()
		{
			FindPlugins(AppDomain.CurrentDomain.BaseDirectory);
		}

		public void FindPlugins(string Path)
		{
			_availablePluginsCollection.Clear();		
		
			foreach (string fileOn in Directory.GetFiles(Path))
			{
				FileInfo file = new FileInfo(fileOn);				
				
				if (file.Extension.Equals(".dll"))
				{		
					this.AddPlugin(fileOn);				
				}
			}
		}
				
		public void ClosePlugins()
		{
			foreach (Types.OneAvailablePlugin plugin in _availablePluginsCollection)
			{
				plugin.Instance.Dispose(); 
				
				plugin.Instance = null;
			}
			
			_availablePluginsCollection.Clear();

		}
		
		private void AddPlugin(string FileName)
		{			
			Assembly pluginAssembly = Assembly.LoadFrom(FileName);
				
			foreach (Type pluginType in pluginAssembly.GetTypes())
			{
				if (pluginType.IsPublic)
				{
					if (!pluginType.IsAbstract)
					{						
						Type typeInterface = pluginType.GetInterface("OCTTPluginInterface.IPlugin", true);
									
						if (typeInterface != null)
						{
							Types.OneAvailablePlugin newPlugin = new Types.OneAvailablePlugin();
							newPlugin.AssemblyPath = FileName;
					
							newPlugin.Instance = (IPlugin)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
							
							newPlugin.Instance.Host = this;			
							newPlugin.Instance.Initialize();
							
							this._availablePluginsCollection.Add(newPlugin);
							
							newPlugin = null;
						}	
						
						typeInterface = null;
					}				
				}			
			}
			
			pluginAssembly = null;
		}	
		

		public string ActiveDocumentData_Test
		{
			get
			{
				return AppForm.CURR_OCTT_DOC.EduInstitutionName+" "+AppForm.CURR_OCTT_DOC.SchoolYear;

			}
		}

		public bool closeActiveDocument()
		{
			if(AppForm.getAppForm().doCloseDoc()) return true;

			return false;
		}

		public void importDataForTTStart(DataSet ds)
		{			
			AppForm.CURR_OCTT_DOC= new OCTTDocument();

			DataTable dtDocumentProperties=ds.Tables["DocumentProperties"];
			DataRow drDP= dtDocumentProperties.Rows[0];

			AppForm.CURR_OCTT_DOC.EduInstitutionName=(string)drDP["DocEduInstitutionName"];
			AppForm.CURR_OCTT_DOC.SchoolYear=(string)drDP["DocSchoolYear"];
			AppForm.CURR_OCTT_DOC.DocumentType=System.Convert.ToInt32(drDP["DocType"]);
			AppForm.CURR_OCTT_DOC.DocumentVersion=(string)drDP["DocVersion"];

			//included days
			DataTable dtIncludedDays=ds.Tables["IncludedDays"];
			ArrayList dl= new ArrayList();
			foreach(DataRow dr in dtIncludedDays.Rows)
			{			
				int d=System.Convert.ToInt16(dr["DayIndexInWeek"])-1;
				dl.Add(d);				
			}

			for(int n=0;n<7;n++)
			{
				if(dl.Contains(n))
				{
					AppForm.CURR_OCTT_DOC.setIsDayIncluded(n,true);
				}
				else
				{
					AppForm.CURR_OCTT_DOC.setIsDayIncluded(n,false);
				}
			}

			//included terms
			DataTable dtIncludedTerms=ds.Tables["IncludedTerms"];
			int[] oneT;
			AppForm.CURR_OCTT_DOC.IncludedTerms.Clear();
			foreach(DataRow dr in dtIncludedTerms.Rows)
			{
				oneT = new int[4];
				oneT[0]=System.Convert.ToInt32(dr["StartH"]);
				oneT[1]=System.Convert.ToInt32(dr["StartM"]);
				oneT[2]=System.Convert.ToInt32(dr["EndH"]);
				oneT[3]=System.Convert.ToInt32(dr["EndM"]);

				AppForm.CURR_OCTT_DOC.IncludedTerms.Add(oneT);
			}
            
			//teachers
			DataTable dtTeachers=ds.Tables["Teachers"];
			Hashtable htTeachers= new Hashtable();

			foreach(DataRow dr in dtTeachers.Rows)
			{	
				int tID=System.Convert.ToInt16(dr["ID"]);
				Teacher teacher = new Teacher((string)dr["Name"], (string)dr["Lastname"], (string)dr["Title"], (string)dr["EduRank"], (string)dr["ExtId"]);

				AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Add(teacher);
				htTeachers.Add(tID,teacher);
										
				if(!AppForm.CURR_OCTT_DOC.TeacherTitlesList.Contains(teacher.getTitle()))
				{
					AppForm.CURR_OCTT_DOC.TeacherTitlesList.Add(teacher.getTitle());						
				}

				if(!AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Contains(teacher.getEduRank()))
				{
					AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Add(teacher.getEduRank());						
				}				
			}

			AppForm.CURR_OCTT_DOC.TeacherTitlesList.Sort();
			AppForm.CURR_OCTT_DOC.TeacherEduRanksList.Sort();
			AppForm.CURR_OCTT_DOC.TeachersRootNode.ExpandAll();
			

			//rooms
			DataTable dtRooms=ds.Tables["Rooms"];
			foreach(DataRow dr in dtRooms.Rows)
			{	
				Room room = new Room((string)dr["Name"],System.Convert.ToInt32(dr["Capacity"]),(string)dr["ExtId"]);
				AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Add(room);				
			}

			AppForm.CURR_OCTT_DOC.RoomsRootNode.Expand();

		
			//EPGs, EPs, courses
			DataTable dtEduProgramGroups=ds.Tables["EduProgramGroups"];
			DataTable dtEduPrograms=ds.Tables["EduPrograms"];
			DataTable dtCourses=ds.Tables["Courses"];

			foreach(DataRow drepg in dtEduProgramGroups.Rows)
			{
	            string name = (string)drepg["Name"];
				string extid;
				if(drepg["ExtId"]!=null)
				{
					extid = (string)drepg["ExtId"];
				}
				else
				{
					extid="";
				}

				EduProgramGroup newEPG=new EduProgramGroup(name,extid);				
				AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Add(newEPG);

				DataRow[] drep=drepg.GetChildRows(ds.Relations["EPG_EP"]);				
				foreach(DataRow r in drep)
				{
                    string semester;
					string code;
					string extidop;
					if(r["Semester"]!=null)
					{
						semester = (string)r["Semester"];
					}
					else
					{
                        semester="";
					}

					if(r["Code"]!=null)
					{
						code = (string)r["Code"];
					}
					else
					{
						code="";
					}

					if(r["ExtId"]!=null)
					{
						extidop = (string)r["ExtId"];
					}
					else
					{
						extidop="";
					}

					EduProgram newEP= new EduProgram((string)r["Name"],semester,code,extidop);
					newEPG.Nodes.Add(newEP);

					DataRow[] drc=r.GetChildRows(ds.Relations["EP_Courses"]);				
					foreach(DataRow rc in drc)
					{
						int teacherID;

						string groupName;
						string extidc;
						
						int numoflessperweek;
						int numofenrstud;
						string courseType;

						Teacher myTeacher;
						teacherID= System.Convert.ToInt32(rc["TeacherID"]);

						myTeacher = (Teacher)htTeachers[teacherID];						

						numoflessperweek= System.Convert.ToInt32(rc["NumOfLessPerWeek"]);
						numofenrstud= System.Convert.ToInt32(rc["NumOfEnrolledStud"]);
						courseType= (string)rc["CourseType"];

						if(rc["GroupName"]!=null)
						{
							groupName = System.Convert.ToString(rc["GroupName"]);
						}
						else
						{
							groupName="";
						}  

						bool isGroup;
						if(groupName==null || groupName=="")
						{
							isGroup= false;
						}
						else
						{
							isGroup= true;
						}


						if(rc["ExtId"]!=null)
						{
							extidc = (string)rc["ExtId"];
						}
						else
						{
							extidc="";
						}       
                
						Course newCourse = new Course((string)rc["Name"],(string)rc["ShortName"],myTeacher,numoflessperweek,numofenrstud,isGroup,groupName,extidc, courseType);
						newEP.Nodes.Add(newCourse);
				
						if(!AppForm.CURR_OCTT_DOC.CourseTypesList.Contains(courseType)) AppForm.CURR_OCTT_DOC.CourseTypesList.Add(courseType);				
				
						AppForm.CURR_OCTT_DOC.incrUnallocatedLessonsCounter(numoflessperweek);

						for(int k=0;k<numoflessperweek;k++) 
						{
							ListViewItem lvi=new ListViewItem();
							lvi.Tag=newCourse;
							newEP.getUnallocatedLessonsList().Add(lvi);
						}

					}

				}
				
				AppForm.CURR_OCTT_DOC.CoursesRootNode.Expand();
				foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
				{
					epg.Expand();
				}

				AppForm.CURR_OCTT_DOC.CourseTypesList.Sort();
				AppForm.getAppForm().getStatusBarPanel2().Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			}
		
			AppForm.getAppForm().doNewDocAction();

		}


		public DataSet OpenCTTDataSet
		{
			get
			{
				DataSet octtDS= new DataSet("OpenCTTDataSet");

				DataColumn myDataColumn;
				DataTable myTable;
				DataRow newRow;
				DataColumn [] PK;

				//table: DocumentProperties
				myTable= new DataTable("DocumentProperties");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int32");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="DocType";
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="DocVersion";
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="DocEduInstitutionName";
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="DocSchoolYear";
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="DocDateTimeOfLastChange";
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=myTable.Columns["ID"];
				myTable.PrimaryKey=PK;
                
				newRow=myTable.NewRow();
				newRow["DocType"]=AppForm.CURR_OCTT_DOC.DocumentType;
				newRow["DocVersion"]=AppForm.CURR_OCTT_DOC.DocumentVersion;
				newRow["DocEduInstitutionName"]=AppForm.CURR_OCTT_DOC.EduInstitutionName;
				newRow["DocSchoolYear"]=AppForm.CURR_OCTT_DOC.SchoolYear;
				newRow["DocDateTimeOfLastChange"]=System.Convert.ToString(System.DateTime.Now);
				myTable.Rows.Add(newRow);

				octtDS.Tables.Add(myTable);

				//table: IncludedDays
				myTable= new DataTable("IncludedDays");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="DayName";
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="DayIndexInWeek"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=myTable.Columns["ID"];
				myTable.PrimaryKey=PK;
                				
				if(AppForm.CURR_OCTT_DOC.getNumberOfDays()>0)
				{
					for(int n=0;n<7;n++)
					{
						if(AppForm.CURR_OCTT_DOC.getIsDayIncluded(n))
						{
							newRow=myTable.NewRow();
							string dayName=AppForm.getDayText()[n];	
							newRow["DayName"]=dayName;

							newRow["DayIndexInWeek"]=n+1;

							myTable.Rows.Add(newRow);
						}
					}
				}

				octtDS.Tables.Add(myTable);

				//table: IncludedTerms
				myTable= new DataTable("IncludedTerms");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				myTable.Columns.Add(myDataColumn);				

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="TermIndex"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="StartH"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="StartM"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="EndH"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="EndM"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=myTable.Columns["ID"];
				myTable.PrimaryKey=PK;

				if(AppForm.CURR_OCTT_DOC.IncludedTerms.Count>0)
				{
					int termIndex=0;
					foreach(int[] term in AppForm.CURR_OCTT_DOC.IncludedTerms)
					{
						termIndex++;
						newRow=myTable.NewRow();
						
						newRow["TermIndex"]=termIndex;
						newRow["StartH"]=term[0];
						newRow["StartM"]=term[1];
						newRow["EndH"]=term[2];
						newRow["EndM"]=term[3];

						myTable.Rows.Add(newRow);
					}
				}

				octtDS.Tables.Add(myTable);

				//table: Teachers
				myTable= new DataTable("Teachers");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				myTable.Columns.Add(myDataColumn);				

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Name"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Lastname"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Title"; 
				myDataColumn.AllowDBNull=true;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="EduRank"; 
				myDataColumn.AllowDBNull=true;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="ExtId"; 
				myDataColumn.AllowDBNull=true;
				myTable.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=myTable.Columns["ID"];
				myTable.PrimaryKey=PK;

				if(AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Count>0)
				{	
					int teacherCounter=0;
					foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
					{	
						teacherCounter++;
						teacher.setTempID(teacherCounter);
						newRow=myTable.NewRow();
						
						newRow["Name"]=teacher.getName();
						newRow["Lastname"]=teacher.getLastName();
						if(teacher.getTitle()!=null) newRow["Title"]=teacher.getTitle();
						if(teacher.getEduRank()!=null) newRow["EduRank"]=teacher.getEduRank();
						if(teacher.ExtID!=null) newRow["ExtId"]=teacher.ExtID;						

						myTable.Rows.Add(newRow);												
					}
				}

				octtDS.Tables.Add(myTable);

				//table: Rooms
				myTable= new DataTable("Rooms");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				myTable.Columns.Add(myDataColumn);				

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Name"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="Capacity"; 
				myDataColumn.AllowDBNull=false;
				myTable.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="ExtId"; 
				myDataColumn.AllowDBNull=true;
				myTable.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=myTable.Columns["ID"];
				myTable.PrimaryKey=PK;

				if(AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Count>0)
				{
					int roomCounter=0;

					foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
					{
						roomCounter++;
						room.setTempID(roomCounter);

						newRow=myTable.NewRow();
						
						newRow["Name"]=room.getName();
						newRow["Capacity"]=room.getRoomCapacity();						
						if(room.ExtID!=null) newRow["ExtId"]=room.ExtID;

						myTable.Rows.Add(newRow);				
					}
				}

				octtDS.Tables.Add(myTable);


				//table: EduProgramGroups
				DataTable dtEduProgramGroups = new DataTable("EduProgramGroups");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				dtEduProgramGroups.Columns.Add(myDataColumn);	

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Name"; 
				myDataColumn.AllowDBNull=false;
				dtEduProgramGroups.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="ExtId"; 
				myDataColumn.AllowDBNull=true;
				dtEduProgramGroups.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=dtEduProgramGroups.Columns["ID"];
				dtEduProgramGroups.PrimaryKey=PK;

				octtDS.Tables.Add(dtEduProgramGroups);

				//table: EduPrograms
				DataTable dtEduPrograms = new DataTable("EduPrograms");				

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				dtEduPrograms.Columns.Add(myDataColumn);	

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Name"; 
				myDataColumn.AllowDBNull=false;
				dtEduPrograms.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Code"; 
				myDataColumn.AllowDBNull=true;
				dtEduPrograms.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Semester"; 
				myDataColumn.AllowDBNull=false;
				dtEduPrograms.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="EpgID"; 
				myDataColumn.AllowDBNull=false;
				dtEduPrograms.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="ExtId"; 
				myDataColumn.AllowDBNull=true;
				dtEduPrograms.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=dtEduPrograms.Columns["ID"];
				dtEduPrograms.PrimaryKey=PK;

				octtDS.Tables.Add(dtEduPrograms);

				//add relation EduProgramGroups ->EduPrograms
				DataRelation drel1= new DataRelation("EPG_EP",octtDS.Tables["EduProgramGroups"].Columns["ID"],octtDS.Tables["EduPrograms"].Columns["EpgID"]);
				octtDS.Relations.Add(drel1);	

				//table: Course
				DataTable dtCourses = new DataTable("Courses");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				dtCourses.Columns.Add(myDataColumn);	

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="Name"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="ShortName"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="TeacherID"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="GroupName"; 
				myDataColumn.AllowDBNull=true;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="NumOfLessPerWeek"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="NumOfEnrolledStud"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="EpID"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="CourseType"; 
				myDataColumn.AllowDBNull=false;
				dtCourses.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.String");
				myDataColumn.ColumnName="ExtId"; 
				myDataColumn.AllowDBNull=true;
				dtCourses.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=dtCourses.Columns["ID"];
				dtCourses.PrimaryKey=PK;

				octtDS.Tables.Add(dtCourses);

				//add relation EduPrograms ->Courses
				DataRelation drel2= new DataRelation("EP_Courses",octtDS.Tables["EduPrograms"].Columns["ID"],octtDS.Tables["Courses"].Columns["EpID"]);
				octtDS.Relations.Add(drel2);

				//table: LessonsInTT
				DataTable dtLessonsInTT = new DataTable("LessonsInTT");

				myDataColumn= new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="ID";
				myDataColumn.ReadOnly=true;
				myDataColumn.AllowDBNull=false;
				myDataColumn.Unique=true;
				myDataColumn.AutoIncrement=true;
				myDataColumn.AutoIncrementSeed=1;
				myDataColumn.AutoIncrementStep=1;
				dtLessonsInTT.Columns.Add(myDataColumn);	

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="CourseID"; 
				myDataColumn.AllowDBNull=false;
				dtLessonsInTT.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="DayID"; 
				myDataColumn.AllowDBNull=false;
				dtLessonsInTT.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="TermID"; 
				myDataColumn.AllowDBNull=false;
				dtLessonsInTT.Columns.Add(myDataColumn);

				myDataColumn = new DataColumn();
				myDataColumn.DataType=Type.GetType("System.Int16");
				myDataColumn.ColumnName="RoomID"; 
				myDataColumn.AllowDBNull=false;
				dtLessonsInTT.Columns.Add(myDataColumn);

				PK = new DataColumn[1];
				PK[0]=dtLessonsInTT.Columns["ID"];
				dtLessonsInTT.PrimaryKey=PK;

				octtDS.Tables.Add(dtLessonsInTT);

				
				if(AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes.Count>0)
				{			
					int epgID=0;
					int epID=0;
					int courseID=0;	
				
					//edu program groups
					foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
					{
						epgID++;

						newRow=dtEduProgramGroups.NewRow();
						
						newRow["Name"]=epg.getName();						
						if(epg.ExtID!=null) newRow["ExtId"]=epg.ExtID;

						dtEduProgramGroups.Rows.Add(newRow);							

						//edu programs
						if(epg.Nodes.Count>0)
						{       
							foreach(EduProgram ep in epg.Nodes)
							{
								epID++;
								
								newRow=dtEduPrograms.NewRow();
						
								newRow["Name"]=ep.getName();
								if(ep.getCode()!=null) newRow["Code"]=ep.getCode();
								newRow["Semester"]=ep.getSemester();
								newRow["EpgID"]=epgID;		
								if(ep.ExtID!=null) newRow["ExtId"]=ep.ExtID;

								dtEduPrograms.Rows.Add(newRow);
								

								//courses
								if(ep.Nodes.Count>0)
								{									
									foreach(Course course in ep.Nodes)
									{
										courseID++;

										newRow=dtCourses.NewRow();
						
										newRow["Name"]=course.getName();
										newRow["ShortName"]=course.getShortName();
										newRow["TeacherID"]=course.getTeacher().getTempID();
										if(course.getIsGroup()==true) newRow["GroupName"]=course.getGroupName();
										newRow["NumOfLessPerWeek"]=course.getNumberOfLessonsPerWeek();
										newRow["NumOfEnrolledStud"]=course.getNumberOfEnrolledStudents();
										newRow["EpID"]=epID;
										newRow["CourseType"]=course.CourseType;
										if(course.ExtID!=null) newRow["ExtId"]=course.ExtID;

										dtCourses.Rows.Add(newRow);																			

										//lessons in timetable
										ArrayList lessonsInTTArrayList=FileOperations.getMyLessonsInTimetable(ep,course);
										if(lessonsInTTArrayList.Count>0)
										{
											foreach(Object [] oneItem in lessonsInTTArrayList)
											{
												int dayIndex=(int)oneItem[0];
												int termIndex=(int)oneItem[1];
												Room room = (Room)oneItem[2];

												newRow=dtLessonsInTT.NewRow();
						
												newRow["CourseID"]=courseID;
												newRow["DayID"]=dayIndex;
												newRow["TermID"]=termIndex;
												newRow["RoomID"]=room.getTempID();

												dtLessonsInTT.Rows.Add(newRow);
												
											}

										}
									}

								}
							}
						}
					}
				}

				

				return octtDS;
			}		
		}


		


	}



	namespace Types
	{
	
		public class AvailablePluginsCollection : System.Collections.CollectionBase
		{
			
			public void Add(Types.OneAvailablePlugin pluginToAdd)
			{
				this.List.Add(pluginToAdd); 
			}
		
			public void Remove(Types.OneAvailablePlugin pluginToRemove)
			{
				this.List.Remove(pluginToRemove);
			}
		

			public Types.OneAvailablePlugin Find(string pluginNameOrPath)
			{
				Types.OneAvailablePlugin toReturn = null;

				foreach (Types.OneAvailablePlugin plugin in this.List)
				{				
					if ((plugin.Instance.Name.Equals(pluginNameOrPath)) || plugin.AssemblyPath.Equals(pluginNameOrPath))
					{
						toReturn = plugin;
						break;		
					}
				}
				return toReturn;
			}
		}
		

		
		public class OneAvailablePlugin
		{			
			private IPlugin myInstance = null;
			private string myAssemblyPath = "";
			
			public IPlugin Instance
			{
				get {return myInstance;}
				set	{myInstance = value;}
			}
			public string AssemblyPath
			{
				get {return myAssemblyPath;}
				set {myAssemblyPath = value;}
			}
		}
	}


}
