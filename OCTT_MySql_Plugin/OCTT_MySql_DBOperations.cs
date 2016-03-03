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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Data;

using MySql.Data.MySqlClient;

using OCTTPluginInterface;

namespace OCTT_MySql_Plugin
{
	/// <summary>
	/// Summary description for OCTT_MySql_DBOperations.
	/// </summary>
	public class OCTT_MySql_DBOperations
	{
		public OCTT_MySql_DBOperations()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public static void doExportInMySqlDB(BackgroundWorker worker, DoWorkEventArgs e)
		{			
			
			IPluginHost host = OCTT_MySql_DBExportTTForm.OCTT_MYSQL_DBEXPLG.Host;			
			
			DataSet ds = host.OpenCTTDataSet;

			MySqlConnection mySqlConnection= new MySqlConnection();

			mySqlConnection.ConnectionString = "database="+OCTT_MySql_DBExportTTForm.OCTT_MYSQL_EDBF._dbNameTextBox.Text.Trim()+";server="+OCTT_MySql_DBExportTTForm.OCTT_MYSQL_EDBF._serverTextBox.Text.Trim()+";user id="+OCTT_MySql_DBExportTTForm.OCTT_MYSQL_EDBF._userNameTextBox.Text.Trim()+"; pwd="+OCTT_MySql_DBExportTTForm.OCTT_MYSQL_EDBF._passwordTextBox.Text.Trim();

			string createTableTTDataSql="DROP TABLE IF EXISTS `tt_data`;CREATE TABLE IF NOT EXISTS `tt_data` ( `tt_id` tinyint(3) unsigned NOT NULL auto_increment, `type` tinyint(3) unsigned NOT NULL, `institution_name` varchar(80) collate utf8_unicode_ci NOT NULL, `school_year` varchar(20) collate utf8_unicode_ci NOT NULL, `last_change` varchar(40) collate utf8_unicode_ci NOT NULL, PRIMARY KEY  (`tt_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableTeacherCommand=new MySqlCommand(createTableTTDataSql,mySqlConnection);
						
			string createTableTeacherSql="DROP TABLE IF EXISTS `teacher`;CREATE TABLE IF NOT EXISTS `teacher` (`teacher_id` smallint(6) NOT NULL auto_increment, `name` varchar(20) collate utf8_unicode_ci NOT NULL, `lastname` varchar(30) collate utf8_unicode_ci NOT NULL, `title` varchar(40) collate utf8_unicode_ci default NULL, `edurank` varchar(70) collate utf8_unicode_ci default NULL, `ext_id` int(11) default NULL, PRIMARY KEY  (`teacher_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableTTDataCommand=new MySqlCommand(createTableTeacherSql,mySqlConnection);
			
			string createTableRoomSql="DROP TABLE IF EXISTS `room`;CREATE TABLE IF NOT EXISTS `room` ( `room_id` smallint(5) unsigned NOT NULL auto_increment, `name` varchar(20) collate utf8_unicode_ci NOT NULL, `capacity` smallint(5) unsigned NOT NULL, `ext_id` int(10) unsigned default NULL, PRIMARY KEY  (`room_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableRoomCommand=new MySqlCommand(createTableRoomSql,mySqlConnection);

			string createTableDaySql="DROP TABLE IF EXISTS `day`;CREATE TABLE IF NOT EXISTS `day` ( `day_id` smallint(5) unsigned NOT NULL auto_increment, `name` varchar(15) collate utf8_unicode_ci NOT NULL, `day_index` tinyint(3) unsigned NOT NULL, PRIMARY KEY  (`day_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableDayCommand=new MySqlCommand(createTableDaySql,mySqlConnection);

			string createTableTermSql="DROP TABLE IF EXISTS `term`;CREATE TABLE IF NOT EXISTS `term` ( `term_id` smallint(5) unsigned NOT NULL auto_increment, `start_h` tinyint(3) unsigned NOT NULL, `start_min` tinyint(3) unsigned NOT NULL, `end_h` tinyint(3) unsigned NOT NULL, `end_min` tinyint(3) unsigned NOT NULL, `term_index` tinyint(3) unsigned NOT NULL, PRIMARY KEY  (`term_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableTermCommand=new MySqlCommand(createTableTermSql,mySqlConnection);

			string createTableEpgSql="DROP TABLE IF EXISTS `epg`;CREATE TABLE IF NOT EXISTS `epg` ( `epg_id` tinyint(3) unsigned NOT NULL auto_increment, `name` varchar(80) collate utf8_unicode_ci NOT NULL, `ext_id` int(10) unsigned default NULL, PRIMARY KEY  (`epg_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableEpgCommand=new MySqlCommand(createTableEpgSql,mySqlConnection);

			string createTableEpSql="DROP TABLE IF EXISTS `ep`;CREATE TABLE IF NOT EXISTS `ep` ( `ep_id` tinyint(3) unsigned NOT NULL auto_increment, `name` varchar(50) collate utf8_unicode_ci NOT NULL, `code` varchar(10) collate utf8_unicode_ci default NULL, `semester` varchar(10) collate utf8_unicode_ci NOT NULL, `ext_id` int(10) unsigned default NULL, `epg_id` tinyint(3) unsigned NOT NULL,  PRIMARY KEY  (`ep_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableEpCommand=new MySqlCommand(createTableEpSql,mySqlConnection);

			string createTableCourseSql="DROP TABLE IF EXISTS `course`;CREATE TABLE IF NOT EXISTS `course` ( `course_id` int(10) unsigned NOT NULL auto_increment, `name` varchar(70) collate utf8_unicode_ci NOT NULL, `short_name` varchar(70) collate utf8_unicode_ci NOT NULL, `group_name` varchar(15) collate utf8_unicode_ci default NULL, `course_type` varchar(40) NOT NULL, `numoflessperweek` int(10) unsigned NOT NULL, `ext_id` int(10) unsigned default NULL, `ep_id` tinyint(3) unsigned NOT NULL, `teacher_id` tinyint(3) unsigned NOT NULL, PRIMARY KEY  (`course_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableCourseCommand=new MySqlCommand(createTableCourseSql,mySqlConnection);
			

			string createTableAllocatedLessoniSql="DROP TABLE IF EXISTS `allocated_lesson`;CREATE TABLE IF NOT EXISTS `allocated_lesson` ( `allocless_id` int(10) unsigned NOT NULL auto_increment, `course_id` int(10) unsigned NOT NULL, `room_id` smallint(5) unsigned NOT NULL, `day_id` tinyint(3) unsigned NOT NULL, `term_id` tinyint(3) unsigned NOT NULL, PRIMARY KEY  (`allocless_id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;";
			MySqlCommand createTableAllocatedLessonCommand=new MySqlCommand(createTableAllocatedLessoniSql,mySqlConnection);

			try
			{				

				mySqlConnection.Open();
				
				string message = "Connection to database was successfull.\n\n";
				message+="If you proceed with this operation, all the data in tables\n";
				message+="epg, ep, course, allocated_lesson, day, term, teacher, room\n";
				message+="will be deleted and after that these tables will be filled up with new data.\n\n";				
				message+="Are you sure you want to proceed?";

				string caption = "Confirm to delete existing data";
				MessageBoxButtons buttons = MessageBoxButtons.YesNo;
				DialogResult result;
		
				result = MessageBox.Show(message, caption, buttons,
					MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

				if(result == DialogResult.Yes)
				{
					createTableTTDataCommand.ExecuteNonQuery();					
                    worker.ReportProgress(6);
					
					createTableTeacherCommand.ExecuteNonQuery();					
                    worker.ReportProgress(12);
					
					createTableRoomCommand.ExecuteNonQuery();					
                    worker.ReportProgress(25);

					createTableDayCommand.ExecuteNonQuery();					
                    worker.ReportProgress(37);

					createTableTermCommand.ExecuteNonQuery();					
                    worker.ReportProgress(50);
					
					createTableEpgCommand.ExecuteNonQuery();					
                    worker.ReportProgress(62);
					
					createTableEpCommand.ExecuteNonQuery();					
                    worker.ReportProgress(75);
					
					createTableCourseCommand.ExecuteNonQuery();					
                    worker.ReportProgress(87);
					
					createTableAllocatedLessonCommand.ExecuteNonQuery();
                    worker.ReportProgress(100, "Status: New tables in database are created.");
					
					Cursor.Current=Cursors.WaitCursor;					
					string sql;
					MySqlCommand myCommand;					
	

					//TO DO!!!
					//export document properties
					DataTable dtDocumentProperties=ds.Tables["DocumentProperties"];
					DataRow drDP= dtDocumentProperties.Rows[0];

					sql = "insert into tt_data (type,institution_name,school_year,last_change) values (?type,?institution_name,?school_year,?last_change)";		
					myCommand=new MySqlCommand(sql,mySqlConnection);

					myCommand.Parameters.Add(new MySqlParameter("?type",drDP["DocType"]));
					myCommand.Parameters.Add(new MySqlParameter("?institution_name",drDP["DocEduInstitutionName"]));
					myCommand.Parameters.Add(new MySqlParameter("?school_year",drDP["DocSchoolYear"]));
					myCommand.Parameters.Add(new MySqlParameter("?last_change",drDP["DocDateTimeOfLastChange"]));

					myCommand.ExecuteNonQuery();                    					
                    worker.ReportProgress(3, "Status: Table with data about timetable is filled up.");
	
					//export included days
					DataTable dtIncludedDays=ds.Tables["IncludedDays"];            
					foreach(DataRow dr in dtIncludedDays.Rows)
					{
						sql = "insert into day (name,day_index) values (?name,?day_index)";		
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?name",dr["DayName"]));
						myCommand.Parameters.Add(new MySqlParameter("?day_index",dr["DayIndexInWeek"]));

						myCommand.ExecuteNonQuery();
					}					
					
                    worker.ReportProgress(6, "Status: Table with data about days is filled up.");
					
					
					//export included terms
					DataTable dtIncludedTerms=ds.Tables["IncludedTerms"];
					foreach(DataRow dr in dtIncludedTerms.Rows)
					{	
						sql="insert into term (start_h,start_min,end_h,end_min,term_index) values (?start_h,?start_min,?end_h,?end_min,?term_index)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?start_h",dr["StartH"]));
						myCommand.Parameters.Add(new MySqlParameter("?start_min",dr["StartM"]));
						myCommand.Parameters.Add(new MySqlParameter("?end_h",dr["EndH"]));
						myCommand.Parameters.Add(new MySqlParameter("?end_min",dr["EndM"]));
						myCommand.Parameters.Add(new MySqlParameter("?term_index",dr["TermIndex"]));

						myCommand.ExecuteNonQuery();

					}
					
                    worker.ReportProgress(12, "Status: Table with data about time periods is filled up.");

					
					//export teachers
					DataTable dtTeachers=ds.Tables["Teachers"];            
					foreach(DataRow dr in dtTeachers.Rows)
					{
						sql="insert into teacher(name,lastname,title,edurank,ext_id) values (?name,?lastname,?title,?edurank,?ext_id)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?name",dr["Name"]));
						myCommand.Parameters.Add(new MySqlParameter("?lastname",dr["Lastname"]));
						if(dr["Title"]!=null)
						{
							myCommand.Parameters.Add(new MySqlParameter("?title",dr["Title"]));
						}
						else
						{
                            myCommand.Parameters.Add(new MySqlParameter("?title",System.DBNull.Value));
						}

						if(dr["EduRank"]!=null)
						{
							myCommand.Parameters.Add(new MySqlParameter("?edurank",dr["EduRank"]));
						}
						else
						{
                            myCommand.Parameters.Add(new MySqlParameter("?edurank",System.DBNull.Value));
						}

						if(!((string)dr["ExtId"]=="" || dr["ExtId"]==null))
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",(string)dr["ExtId"]));
						}
						else
						{
                            myCommand.Parameters.Add(new MySqlParameter("?ext_id",System.DBNull.Value));
						}
                        
						myCommand.ExecuteNonQuery();
						
					}
					
                    worker.ReportProgress(25, "Status: Table with data about teachers is filled up.");

					
					//export rooms
					DataTable dtRooms=ds.Tables["Rooms"];
					foreach(DataRow dr in dtRooms.Rows)
					{
						sql="insert into room(name,capacity,ext_id) values (?name,?capacity,?ext_id)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?name",dr["Name"]));
						myCommand.Parameters.Add(new MySqlParameter("?capacity",dr["Capacity"]));
						myCommand.Parameters.Add(new MySqlParameter("?ext_id",dr["ExtId"]));

						myCommand.ExecuteNonQuery();						
					}
					
                    worker.ReportProgress(31, "Status: Table with data about rooms is filled up.");

					
					//export edu program groups
					DataTable dtEduProgramGroups=ds.Tables["EduProgramGroups"];
					foreach(DataRow dr in dtEduProgramGroups.Rows)
					{
						sql="insert into epg(name,ext_id) values (?name,?ext_id)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?name",dr["Name"]));						
						if(!((string)dr["ExtId"]=="" || dr["ExtId"]==null))
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",dr["ExtId"]));
						}
						else
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",System.DBNull.Value));
						}

						myCommand.ExecuteNonQuery();

					}
					
                    worker.ReportProgress(37, "Status: Table with data about educational program groups is filled up with data.");

					
					//export edu programs
					DataTable dtEduPrograms=ds.Tables["EduPrograms"];
					foreach(DataRow dr in dtEduPrograms.Rows)
					{
						sql="insert into ep(name,code,semester,epg_id,ext_id) values (?name,?code,?semester,?epg_id,?ext_id)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?name",dr["Name"]));

						if(!((string)dr["Code"]=="" || dr["Code"]==null))
						{
							myCommand.Parameters.Add(new MySqlParameter("?code",dr["Code"]));
						}
						else
						{
							myCommand.Parameters.Add(new MySqlParameter("?code",System.DBNull.Value));
						}
						
						myCommand.Parameters.Add(new MySqlParameter("?semester",dr["Semester"]));
						myCommand.Parameters.Add(new MySqlParameter("?epg_id",dr["EpgID"]));

						if(!((string)dr["ExtId"]=="" || dr["ExtId"]==null))
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",dr["ExtID"]));
						}
						else
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",System.DBNull.Value));
						}					
                        
						myCommand.ExecuteNonQuery();
					}
					
                    worker.ReportProgress(50, "Status: Table with data about educational programs is filled up with data.");
					
					
					//export courses
					DataTable dtCourses=ds.Tables["Courses"];
					foreach(DataRow dr in dtCourses.Rows)
					{
						sql="insert into course(name,short_name,teacher_id,group_name,numoflessperweek,ep_id, course_type, ext_id) values (?name,?short_name,?teacher_id,?group_name,?numoflessperweek,?ep_id, ?course_type, ?ext_id)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?name",dr["Name"]));
						myCommand.Parameters.Add(new MySqlParameter("?short_name",dr["ShortName"]));
						myCommand.Parameters.Add(new MySqlParameter("?teacher_id",dr["TeacherID"]));

						if(dr["GroupName"]==null || System.Convert.ToString(dr["GroupName"])=="")
						{
							myCommand.Parameters.Add(new MySqlParameter("?group_name",System.DBNull.Value));
						}
						else
						{
							myCommand.Parameters.Add(new MySqlParameter("?group_name",dr["GroupName"]));
						}

						myCommand.Parameters.Add(new MySqlParameter("?numoflessperweek",dr["NumOfLessPerWeek"]));
						myCommand.Parameters.Add(new MySqlParameter("?ep_id",dr["EpID"]));

						myCommand.Parameters.Add(new MySqlParameter("?course_type",dr["CourseType"]));

						if(dr["ExtId"]==null || (string)dr["ExtId"]=="")
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",System.DBNull.Value));
						}
						else
						{
							myCommand.Parameters.Add(new MySqlParameter("?ext_id",dr["ExtID"]));
						}
			
						myCommand.ExecuteNonQuery();

					}
                    
                    worker.ReportProgress(75, "Status: Table with data about courses is filled up with data.");

					
					//export lessons in timetable
					DataTable dtLessonsInTT=ds.Tables["LessonsInTT"];
					foreach(DataRow dr in dtLessonsInTT.Rows)
					{
						sql="insert into allocated_lesson(course_id,day_id,term_id,room_id) values (?course_id,?day_id,?term_id,?room_id)";
						myCommand=new MySqlCommand(sql,mySqlConnection);

						myCommand.Parameters.Add(new MySqlParameter("?course_id",dr["CourseID"]));
						myCommand.Parameters.Add(new MySqlParameter("?day_id",dr["DayID"]));
						myCommand.Parameters.Add(new MySqlParameter("?term_id",dr["TermId"]));
						myCommand.Parameters.Add(new MySqlParameter("?room_id",dr["RoomId"]));

						myCommand.ExecuteNonQuery();						
					}
					
                    worker.ReportProgress(93, "Status: Table with data about allocated lessons is filled up with data.");

                    worker.ReportProgress(100, "Status: Export is finished successfully!");

				}
					

			}
			catch(Exception ex)
			{
				string mess="Export procedure was not successfull!\nAn error occurred.\n\n";
				mess+=ex.Message+"\n"+ex.ToString();
				mess+="\n"+ex.StackTrace;

				MessageBox.Show(mess,"Error");				
			}
			finally
			{
				mySqlConnection.Close();				
			}

		}
	}
}
