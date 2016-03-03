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
using System.Xml;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for Settings.
	/// </summary>
	public class Settings
	{
        public static double SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT;
        public static double SC_TEACHER_MAX_HOURS_DAILY_WEIGHT;
        public static double SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT;

        public static double SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT;
        public static double SC_STUDENT_MAX_HOURS_DAILY_WEIGHT;
        public static double SC_STUDENT_MAX_DAYS_PER_WEEK_WEIGHT;
        public static double SC_STUDENT_NO_GAPS_WEIGHT;
        public static double SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT;

        public static double SC_COURSE_LESSON_BLOCKS_WEIGHT;

        ///
        public static int TTREP_MTS_X;
        public static int TTREP_MTS_Y;
        public static int TTREP_MTRH;
        public static int TTREP_MTCW;
        public static int TTREP_HTRH;
        public static int TTREP_TPTCW;

        public static string TTREP_PAPER_SIZE;
        public static string TTREP_PAPER_ORIENTATION;

        public static int TTREP_COURSE_FORMAT;
        public static int TTREP_PRINT_TEACHER_IN_TS;

        public static string TTREP_COLOR_HEADER;
        public static string TTREP_COLOR_TP;
        public static string TTREP_COLOR_TS;

        public static string TTREP_FONT_PAGE_TITLE;
        public static string TTREP_FONT_DAY_NAMES;
        public static string TTREP_FONT_TIME_PERIODS;
        public static string TTREP_FONT_TIME_SLOTS;
        public static string TTREP_FONT_FOOTER;

		public static string PDF_READER_APPLICATION;

		public static string EXE_DIR_PATH;
		private static string CONFIG_FILE_NAME="octtconfig.xml";
		private static string RECENT_DOCS_FILE_NAME="octtdh.xml";

		public static string GUI_LANGUAGE;
		public static int DEFAULT_GUI_TEXT_TYPE;        

		public static int TIME_SLOT_PANEL_WIDTH;
		public static int TIME_SLOT_PANEL_HEIGHT;

		public static int TIME_SLOT_PANEL_FONT_SIZE;		

        public static string EDU_INSTITUTION_NAME_SETT;
		public static string SCHOOL_YEAR_SETT;
		public static string WORKING_DIR_SETT;

		private const string OCTTCONFIG_TAG="octtconfig";
		private const string VERSION_ATTRIB="version";
		private const string EDU_INSTITUTION_NAME_TAG="edu_institution_name";
		private const string SCHOOL_YEAR_TAG="school_year";
		private const string WORKING_DIR_TAG="working_dir";

		private const string GUI_TS_WIDTH_TAG="gui_ts_width";
		private const string GUI_TS_HEIGHT_TAG="gui_ts_height";
		private const string GUI_TS_FONT_SIZE_TAG="gui_ts_font_size";
		private const string GUI_DEFAULT_TEXT_TYPE_TAG="gui_default_text_type";
		private const string GUI_LANGUAGE_TAG="gui_language";		
		private const string PDF_READER_TAG="pdf_reader_application";

		private const string RD_TAG="recent_docs";
		private const string DOC_TAG="octdocument";
		private const string KEY_TAG="key";
		private const string PATH_TAG="path";

        private const string TT_REPORT_TAG = "timetable_report";
        private const string TTREP_MTSX_TAG = "main_table_start_x";
        private const string TTREP_MTSY_TAG = "main_table_start_y";
        private const string TTREP_MTRH_TAG = "main_table_row_height";
        private const string TTREP_MTCW_TAG = "main_table_column_width";
        private const string TTREP_HTRH_TAG = "header_table_row_height";
        private const string TTREP_TPTCW_TAG = "time_periods_table_col_width";

        private const string TTREP_PAPER_SIZE_TAG = "paper_size";
        private const string TTREP_PAPER_ORIENTATION_TAG = "paper_orientation";

        private const string TTREP_COURSE_FORMAT_TAG = "course_format";
        private const string TTREP_PRINT_TEACHER_IN_TS_TAG = "print_teacher_in_ts";

        private const string TTREP_COLOR_HEADER_TAG = "color_header";
        private const string TTREP_COLOR_TP_TAG = "color_time_periods";
        private const string TTREP_COLOR_TS_TAG = "color_time_slots";

        private const string TTREP_FONT_PAGE_TITLE_TAG = "font_page_title";
        private const string TTREP_FONT_DAY_NAMES_TAG = "font_day_names";
        private const string TTREP_FONT_TIME_PERIODS_TAG = "font_time_periods";
        private const string TTREP_FONT_TIME_SLOTS_TAG = "font_time_slots";
        private const string TTREP_FONT_FOOTER_TAG = "font_footer";

        private const string SC_WEIGHT_TAG = "soft_constraint_weight";
        private const string SC_WEIGHT_TEACHER_MAX_HOURS_CONT_TAG = "teacher_max_hours_continuously";
        private const string SC_WEIGHT_TEACHER_MAX_HOURS_DAILY_TAG = "teacher_max_hours_daily";
        private const string SC_WEIGHT_TEACHER_MAX_DAYS_PER_WEEK_TAG = "teacher_max_days_per_week";
        private const string SC_WEIGHT_STUDENT_MAX_HOURS_CONT_TAG = "student_max_hours_continuously";
        private const string SC_WEIGHT_STUDENT_MAX_HOURS_DAILY_TAG = "student_max_hours_daily";
        private const string SC_WEIGHT_STUDENT_MAX_DAYS_PER_WEEK_TAG = "student_max_days_per_week";
        private const string SC_WEIGHT_STUDENT_NO_GAPS_TAG = "student_no_gaps";
        private const string SC_WEIGHT_STUDENT_PREFERRED_START_TIME_PERIOD_TAG = "student_preferred_start_time_period";
        private const string SC_WEIGHT_COURSE_LESSON_BLOCKS_TAG = "course_lesson_blocks";

		public static ArrayList RECENT_DOCS_LIST;
                

		static Settings()
		{	
			string fullPath= Application.ExecutablePath;
			int lastFileSeparatorIndex=fullPath.LastIndexOf(@System.IO.Path.DirectorySeparatorChar);
			EXE_DIR_PATH=fullPath.Substring(0,lastFileSeparatorIndex+1);

			WORKING_DIR_SETT="";
		}

		public static void loadSettings()
		{				
	        
			XmlDocument myXmlDocument = new XmlDocument();

			try
			{				
				myXmlDocument.Load(EXE_DIR_PATH+CONFIG_FILE_NAME);

				XmlNodeList elemList = myXmlDocument.GetElementsByTagName(EDU_INSTITUTION_NAME_TAG);
				EDU_INSTITUTION_NAME_SETT=elemList[0].InnerXml;

				elemList = myXmlDocument.GetElementsByTagName(SCHOOL_YEAR_TAG);
				SCHOOL_YEAR_SETT=elemList[0].InnerXml;

				elemList = myXmlDocument.GetElementsByTagName(WORKING_DIR_TAG);
				WORKING_DIR_SETT=elemList[0].InnerXml;		

				elemList = myXmlDocument.GetElementsByTagName(GUI_TS_WIDTH_TAG);
				TIME_SLOT_PANEL_WIDTH=System.Convert.ToInt32(elemList[0].InnerXml);

				elemList = myXmlDocument.GetElementsByTagName(GUI_TS_HEIGHT_TAG);
				TIME_SLOT_PANEL_HEIGHT=System.Convert.ToInt32(elemList[0].InnerXml);

				elemList = myXmlDocument.GetElementsByTagName(GUI_TS_FONT_SIZE_TAG);
				TIME_SLOT_PANEL_FONT_SIZE=System.Convert.ToInt32(elemList[0].InnerXml);

				elemList = myXmlDocument.GetElementsByTagName(GUI_DEFAULT_TEXT_TYPE_TAG);
				DEFAULT_GUI_TEXT_TYPE=System.Convert.ToInt32(elemList[0].InnerXml);

				elemList = myXmlDocument.GetElementsByTagName(GUI_LANGUAGE_TAG);
				GUI_LANGUAGE=elemList[0].InnerXml;
				
				elemList = myXmlDocument.GetElementsByTagName(PDF_READER_TAG);
				PDF_READER_APPLICATION=elemList[0].InnerXml;
                ////
                XmlNode myElemNode;
                elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[0];
                TTREP_MTS_X = System.Convert.ToInt32(myElemNode.InnerXml);
                //Console.WriteLine(TTREP_MTS_X);

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[1];
                TTREP_MTS_Y = System.Convert.ToInt32(myElemNode.InnerXml);                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[2];
                TTREP_MTRH = System.Convert.ToInt32(myElemNode.InnerXml);                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[3];
                TTREP_MTCW = System.Convert.ToInt32(myElemNode.InnerXml);                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[4];
                TTREP_HTRH = System.Convert.ToInt32(myElemNode.InnerXml);                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[5];
                TTREP_TPTCW = System.Convert.ToInt32(myElemNode.InnerXml);
                
                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[6];
                TTREP_PAPER_SIZE = myElemNode.InnerXml;                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[7];
                TTREP_PAPER_ORIENTATION = myElemNode.InnerXml;                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[8];
                TTREP_COURSE_FORMAT = System.Convert.ToInt32(myElemNode.InnerXml);                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[9];
                TTREP_PRINT_TEACHER_IN_TS = System.Convert.ToInt32(myElemNode.InnerXml);                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[10];
                TTREP_COLOR_HEADER = myElemNode.InnerXml;                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[11];
                TTREP_COLOR_TP = myElemNode.InnerXml;                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[12];
                TTREP_COLOR_TS = myElemNode.InnerXml;                

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[13];
                TTREP_FONT_PAGE_TITLE = myElemNode.InnerXml;

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[14];
                TTREP_FONT_DAY_NAMES = myElemNode.InnerXml;

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[15];
                TTREP_FONT_TIME_PERIODS = myElemNode.InnerXml;

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[16];
                TTREP_FONT_TIME_SLOTS = myElemNode.InnerXml;

                //elemList = myXmlDocument.GetElementsByTagName(TT_REPORT_TAG);
                myElemNode = elemList[0].ChildNodes[17];                
                TTREP_FONT_FOOTER = myElemNode.InnerXml;

                //
                elemList = myXmlDocument.GetElementsByTagName(SC_WEIGHT_TAG);
                myElemNode = elemList[0].ChildNodes[0];
                SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[1];
                SC_TEACHER_MAX_HOURS_DAILY_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[2];
                SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[3];
                SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[4];
                SC_STUDENT_MAX_HOURS_DAILY_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[5];
                SC_STUDENT_MAX_DAYS_PER_WEEK_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[6];
                SC_STUDENT_NO_GAPS_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[7];
                SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

                myElemNode = elemList[0].ChildNodes[8];
                SC_COURSE_LESSON_BLOCKS_WEIGHT = System.Convert.ToDouble(myElemNode.InnerXml);

			}
			catch(Exception ex)
			{
                Console.WriteLine(ex.StackTrace);

			}
			finally
			{
				if(EDU_INSTITUTION_NAME_SETT==null) EDU_INSTITUTION_NAME_SETT="Educational institution";
				if(SCHOOL_YEAR_SETT==null) SCHOOL_YEAR_SETT="2007/08";

				if(TIME_SLOT_PANEL_WIDTH == 0) TIME_SLOT_PANEL_WIDTH=100;
				if(TIME_SLOT_PANEL_HEIGHT==0) TIME_SLOT_PANEL_HEIGHT=50;
				if(TIME_SLOT_PANEL_FONT_SIZE==0) TIME_SLOT_PANEL_FONT_SIZE=7;

				if(DEFAULT_GUI_TEXT_TYPE==0) DEFAULT_GUI_TEXT_TYPE=2;

				if(GUI_LANGUAGE==null) GUI_LANGUAGE="";
				
				if(PDF_READER_APPLICATION==null) PDF_READER_APPLICATION="";

                if (TTREP_MTS_X == 0) TTREP_MTS_X = 20;
                if (TTREP_MTS_Y == 0) TTREP_MTS_Y = 40;
                if (TTREP_MTRH == 0) TTREP_MTRH = 42;
                if (TTREP_MTCW == 0) TTREP_MTCW = 124;
                if (TTREP_HTRH == 0) TTREP_HTRH = 25;
                if (TTREP_TPTCW == 0) TTREP_TPTCW = 60;

                if (TTREP_PAPER_SIZE == null) TTREP_PAPER_SIZE = "A4";
                if (TTREP_PAPER_ORIENTATION == null) TTREP_PAPER_ORIENTATION = "Landscape";

                if (TTREP_COURSE_FORMAT == 0) TTREP_COURSE_FORMAT = 2;
                if (TTREP_PRINT_TEACHER_IN_TS == 0) TTREP_PRINT_TEACHER_IN_TS = 2;

                if (TTREP_COLOR_HEADER == null) TTREP_COLOR_HEADER = "125,125,125";
                if (TTREP_COLOR_TP == null) TTREP_COLOR_TP = "125,125,125";
                if (TTREP_COLOR_TS == null) TTREP_COLOR_TS = "100,100,100";

                if (TTREP_FONT_PAGE_TITLE == null) TTREP_FONT_PAGE_TITLE = "Arial,Regular,14";
                if (TTREP_FONT_DAY_NAMES == null) TTREP_FONT_DAY_NAMES = "Arial,Bold,10";
                if (TTREP_FONT_TIME_PERIODS == null) TTREP_FONT_TIME_PERIODS = "Arial,Bold,8";
                if (TTREP_FONT_TIME_SLOTS == null) TTREP_FONT_TIME_SLOTS = "Arial,Regular,7";
                if (TTREP_FONT_FOOTER == null) TTREP_FONT_FOOTER = "Arial,Regular,6";

                if (SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT == 0) SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT = 1.0;
                if (SC_TEACHER_MAX_HOURS_DAILY_WEIGHT == 0) SC_TEACHER_MAX_HOURS_DAILY_WEIGHT = 1.0;
                if (SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT == 0) SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT = 1.0;
                if (SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT == 0) SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT = 1.0;
                if (SC_STUDENT_MAX_HOURS_DAILY_WEIGHT == 0) SC_STUDENT_MAX_HOURS_DAILY_WEIGHT = 1.2;
                if (SC_STUDENT_MAX_DAYS_PER_WEEK_WEIGHT == 0) SC_STUDENT_MAX_DAYS_PER_WEEK_WEIGHT = 1.0;
                if (SC_STUDENT_NO_GAPS_WEIGHT == 0) SC_STUDENT_NO_GAPS_WEIGHT = 1.5;
                if (SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT == 0) SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT = 1.0;
                if (SC_COURSE_LESSON_BLOCKS_WEIGHT == 0) SC_COURSE_LESSON_BLOCKS_WEIGHT = 2.5;

			}
		}

		public static void saveAppSettings(SettingsForm settForm)
		{			

			Settings.WORKING_DIR_SETT = settForm.WorkingDir;

			XmlDocument myXmlDocument = new XmlDocument();

			try
			{				
				myXmlDocument.AppendChild(myXmlDocument.CreateXmlDeclaration("1.0","UTF-8",null));
				
				myXmlDocument.AppendChild(myXmlDocument.CreateComment(
					"Generated by Open Course Timetabler"+
					"\nCopyright Ivan Æurak - Split, CROATIA"+
					"\ne-mail: Ivan.Curak@fesb.hr"+
					"\n"+"\nConfiguration file for Open Course Timetabler application"+"\n"));
				
				
				XmlElement myRootElement=myXmlDocument.CreateElement(OCTTCONFIG_TAG);
				myXmlDocument.AppendChild(myRootElement);
				XmlAttribute verAtt= myXmlDocument.CreateAttribute(VERSION_ATTRIB);
				verAtt.Value="0.8.1";
				myRootElement.SetAttributeNode(verAtt);

				XmlElement elem;
				XmlText textNode;
				elem=myXmlDocument.CreateElement(EDU_INSTITUTION_NAME_TAG);
				myRootElement.AppendChild(elem);                				
				textNode= myXmlDocument.CreateTextNode(settForm.EduInstitutionNameText);
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(SCHOOL_YEAR_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.SchoolYearText);
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(WORKING_DIR_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.WorkingDir);
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(GUI_TS_WIDTH_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.TSPanelWidth.ToString());
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(GUI_TS_HEIGHT_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.TSPanelHeight.ToString());
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(GUI_TS_FONT_SIZE_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.TSPanelFontSize.ToString());
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(GUI_DEFAULT_TEXT_TYPE_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.DefaultGUITextType.ToString());
				elem.AppendChild(textNode);

				elem=myXmlDocument.CreateElement(GUI_LANGUAGE_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.GUILanguage);
				elem.AppendChild(textNode);				

				elem=myXmlDocument.CreateElement(PDF_READER_TAG);
				myRootElement.AppendChild(elem);
				textNode= myXmlDocument.CreateTextNode(settForm.PdfReaderApplication);
				elem.AppendChild(textNode);
                ////
                XmlElement subelem;
                elem = myXmlDocument.CreateElement(TT_REPORT_TAG);
                myRootElement.AppendChild(elem);
                subelem = myXmlDocument.CreateElement(TTREP_MTSX_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.MtsX.ToString());
                subelem.AppendChild(textNode);
                                
                subelem = myXmlDocument.CreateElement(TTREP_MTSY_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.MtsY.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_MTRH_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.Mtrh.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_MTCW_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.Mtcw.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_HTRH_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.Htrh.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_TPTCW_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.Tptcw.ToString());
                subelem.AppendChild(textNode);

                //Console.WriteLine(settForm.PaperSize.ToString());
                subelem = myXmlDocument.CreateElement(TTREP_PAPER_SIZE_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.PaperSize);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_PAPER_ORIENTATION_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.PaperOrientation);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_COURSE_FORMAT_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.CourseFormat.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_PRINT_TEACHER_IN_TS_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.PrintTeacherInTS.ToString());
                subelem.AppendChild(textNode);

                
                subelem = myXmlDocument.CreateElement(TTREP_COLOR_HEADER_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.ColorHeaderRGB);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_COLOR_TP_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.ColorTimePeriodsRGB);
                subelem.AppendChild(textNode);
                
                subelem = myXmlDocument.CreateElement(TTREP_COLOR_TS_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.ColorTimeSlotsRGB);
                subelem.AppendChild(textNode);


                subelem = myXmlDocument.CreateElement(TTREP_FONT_PAGE_TITLE_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.FontPageTitle);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_FONT_DAY_NAMES_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.FontDayNames);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_FONT_TIME_PERIODS_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.FontTimePeriods);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_FONT_TIME_SLOTS_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.FontTimeSlots);
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(TTREP_FONT_FOOTER_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.FontFooter);
                subelem.AppendChild(textNode);

                //sc weights
                elem = myXmlDocument.CreateElement(SC_WEIGHT_TAG);
                myRootElement.AppendChild(elem);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_TEACHER_MAX_HOURS_CONT_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.TeacherMaxHoursContinuouslyWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_TEACHER_MAX_HOURS_DAILY_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.TeacherMaxHoursDailyWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_TEACHER_MAX_DAYS_PER_WEEK_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.TeacherMaxDaysPerWeekWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_STUDENT_MAX_HOURS_CONT_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.StudentMaxHoursContWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_STUDENT_MAX_HOURS_DAILY_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.StudentMaxHoursDailyWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_STUDENT_MAX_DAYS_PER_WEEK_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.StudentMaxDaysPerWeekWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_STUDENT_NO_GAPS_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.StudentNoGapsWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_STUDENT_PREFERRED_START_TIME_PERIOD_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.StudentPreferredStartTimePeriodWeight.ToString());
                subelem.AppendChild(textNode);

                subelem = myXmlDocument.CreateElement(SC_WEIGHT_COURSE_LESSON_BLOCKS_TAG);
                elem.AppendChild(subelem);
                textNode = myXmlDocument.CreateTextNode(settForm.CourseLessonBlocksWeight.ToString());
                subelem.AppendChild(textNode);              


			}
			catch(Exception ex)
			{
                Console.WriteLine(ex.StackTrace);
				
			}
			finally
			{
				myXmlDocument.Save(EXE_DIR_PATH+CONFIG_FILE_NAME);

				EDU_INSTITUTION_NAME_SETT=settForm.EduInstitutionNameText;
				SCHOOL_YEAR_SETT=settForm.SchoolYearText;

				TIME_SLOT_PANEL_WIDTH=settForm.TSPanelWidth;
				TIME_SLOT_PANEL_HEIGHT=settForm.TSPanelHeight;
				TIME_SLOT_PANEL_FONT_SIZE=settForm.TSPanelFontSize;

				DEFAULT_GUI_TEXT_TYPE=settForm.DefaultGUITextType;
				GUI_LANGUAGE=settForm.GUILanguage;				
				PDF_READER_APPLICATION=settForm.PdfReaderApplication;

                TTREP_MTS_X = settForm.MtsX;
                TTREP_MTS_Y = settForm.MtsY;
                TTREP_MTRH = settForm.Mtrh;
                TTREP_MTCW = settForm.Mtcw;
                TTREP_HTRH = settForm.Htrh;
                TTREP_TPTCW = settForm.Tptcw;

                TTREP_PAPER_SIZE = settForm.PaperSize;
                TTREP_PAPER_ORIENTATION = settForm.PaperOrientation;

                TTREP_COURSE_FORMAT = settForm.CourseFormat;
                TTREP_PRINT_TEACHER_IN_TS = settForm.PrintTeacherInTS;

                TTREP_COLOR_HEADER = settForm.ColorHeaderRGB;
                TTREP_COLOR_TP = settForm.ColorTimePeriodsRGB;
                TTREP_COLOR_TS = settForm.ColorTimeSlotsRGB;

                TTREP_FONT_PAGE_TITLE = settForm.FontPageTitle;
                TTREP_FONT_DAY_NAMES = settForm.FontDayNames;
                TTREP_FONT_TIME_PERIODS = settForm.FontTimePeriods;
                TTREP_FONT_TIME_SLOTS = settForm.FontTimeSlots;
                TTREP_FONT_FOOTER = settForm.FontFooter;

                SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT = settForm.TeacherMaxHoursContinuouslyWeight;
                SC_TEACHER_MAX_HOURS_DAILY_WEIGHT = settForm.TeacherMaxHoursDailyWeight;
                SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT = settForm.TeacherMaxDaysPerWeekWeight;
                SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT = settForm.StudentMaxHoursContWeight;
                SC_STUDENT_MAX_HOURS_DAILY_WEIGHT = settForm.StudentMaxHoursDailyWeight;
                SC_STUDENT_MAX_DAYS_PER_WEEK_WEIGHT = settForm.StudentMaxDaysPerWeekWeight;
                SC_STUDENT_NO_GAPS_WEIGHT = settForm.StudentNoGapsWeight;
                SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT=settForm.StudentPreferredStartTimePeriodWeight;
                SC_COURSE_LESSON_BLOCKS_WEIGHT=settForm.CourseLessonBlocksWeight;

            }

		}



		public static void saveFileHistory()
		{
			XmlDocument myXmlDocument = new XmlDocument();

			try
			{				
				myXmlDocument.AppendChild(myXmlDocument.CreateXmlDeclaration("1.0","UTF-8",null));
				
				myXmlDocument.AppendChild(myXmlDocument.CreateComment(
					"Generated by Open Course Timetabler"+
					"\nCopyright Ivan Æurak - Split, CROATIA"+
					"\ne-mail: Ivan.Curak@fesb.hr"+
					"\n"+"\nRecent documents file for Open Course Timetabler application"+"\n"));
				
				
				XmlElement myRootElement=myXmlDocument.CreateElement(RD_TAG);
				myXmlDocument.AppendChild(myRootElement);
				XmlAttribute verAtt= myXmlDocument.CreateAttribute(VERSION_ATTRIB);
				verAtt.Value="0.8.1";
				myRootElement.SetAttributeNode(verAtt);

				for(int n=0;n<RECENT_DOCS_LIST.Count;n++)
				{

					XmlElement docElem=myXmlDocument.CreateElement(DOC_TAG);
					myRootElement.AppendChild(docElem);                				

					XmlElement elem;
					XmlText textNode;
					elem=myXmlDocument.CreateElement(KEY_TAG);
					docElem.AppendChild(elem);
					string key="File"+(n+1);
					textNode= myXmlDocument.CreateTextNode(key);
					elem.AppendChild(textNode);

					string path = (string)RECENT_DOCS_LIST[n];
					elem=myXmlDocument.CreateElement(PATH_TAG);
					docElem.AppendChild(elem);
					textNode= myXmlDocument.CreateTextNode(@path);
					elem.AppendChild(textNode);
					
				}
						
			}
			catch
			{					
				
			}
			finally
			{
				myXmlDocument.Save(EXE_DIR_PATH+RECENT_DOCS_FILE_NAME);				
			}

		}


		public static void loadFileHistory()
		{
			RECENT_DOCS_LIST= new ArrayList();
			
			XmlDocument myXmlDocument = new XmlDocument();

			try
			{				
				myXmlDocument.Load(EXE_DIR_PATH+RECENT_DOCS_FILE_NAME);

				XmlNodeList docsElemList = myXmlDocument.GetElementsByTagName(DOC_TAG);

				foreach(XmlElement xmlElem in docsElemList)
				{
					XmlNodeList elemList;					
					elemList = xmlElem.GetElementsByTagName(PATH_TAG);
					string path = elemList[0].InnerXml;					

					RECENT_DOCS_LIST.Add(path);

				}

			}
			catch
			{

			}
			finally
			{
				

			}
		}

	}
}
