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
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Xml.Schema;
using Microsoft.Win32;
using System.Data;

using System.Globalization;
using System.Resources;





namespace OpenCTT
{
	/// <summary>
	///
	/// </summary>
	public class AppForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		public static OCTTDocument CURR_OCTT_DOC;

		private static string APPLICATION_NAME="Open Course Timetabler";
		private static string APPLICATION_VERSION="0.8";

		public static ArrayList DOCUMENT_TYPES_LIST;

		private static ArrayList RFL_MENU_ITEMS_LIST;

		private CommandProcessor _cmdProcessor;
		private static String[] DAY_TEXT;
		
        private static bool IS_DOC_OPEN;

		private static AppForm APP_FORM;			
			
		private System.Windows.Forms.MainMenu _mainMenu;
		private System.Windows.Forms.ToolBar _mainToolBar;
		private System.Windows.Forms.ToolBarButton _newDocToolBarButton;
		private System.Windows.Forms.ToolBarButton _openDocToolBarButton;
		private System.Windows.Forms.ToolBarButton _saveDocToolBarButton;
		private System.Windows.Forms.ToolBarButton _closeDocToolBarButton;
		private System.Windows.Forms.ToolBarButton _undoToolBarButton;
		private System.Windows.Forms.ToolBarButton _redoToolBarButton;
		private System.Windows.Forms.StatusBar _statusBar;
		private System.Windows.Forms.ContextMenu _coursesTreeContextMenu;
		private System.Windows.Forms.ContextMenu _teachersTreeContextMenu;
		private System.Windows.Forms.ImageList _toolbarImageList;
		private System.Windows.Forms.ImageList _treeImageList;
		private System.Windows.Forms.ContextMenu _roomsTreeContextMenu;
		private System.Windows.Forms.Panel _firstPanel;
		private System.Windows.Forms.MenuItem _openDocMenuItem;
		private System.Windows.Forms.MenuItem _saveDocMenuItem;
		private System.Windows.Forms.MenuItem _saveAsDocMenuItem;
		private System.Windows.Forms.MenuItem _newDocMenuItem;
		private System.Windows.Forms.MenuItem _exitAppMenuItem;
		private System.Windows.Forms.MenuItem _separator1MenuItem;
		private System.Windows.Forms.MenuItem _separator2MenuItem;

		private System.Windows.Forms.TabControl _treeTabControl;
		private System.Windows.Forms.TabControl _timetableTabControl;
		private System.Windows.Forms.TabPage _timetableTab;

		private System.Windows.Forms.Splitter _splitterVer;
		private System.Windows.Forms.TabPage _coursesTab;
		private System.Windows.Forms.TabPage _teachersTab;
		private System.Windows.Forms.TabPage _roomsTab;

		private System.Windows.Forms.TreeView _coursesTreeView;
		private System.Windows.Forms.TreeView _teachersTreeView;
		private System.Windows.Forms.TreeView _roomsTreeView;

		private System.Windows.Forms.ListView _unallocatedLessonsListView;
		private System.Windows.Forms.ListView _unallocatedLessonsTeacherListView;
	
		private System.Windows.Forms.Splitter _splitterHor;

		private System.Windows.Forms.Panel _emptyPanel;
		private System.Windows.Forms.Panel _timetablePanel;		
		private OpenCTT.ScrollablePanel _mainTimetablePanel;
        //private System.Windows.Forms.Panel _mainTimetablePanel;
		private System.Windows.Forms.Panel _termsPanel;
		private System.Windows.Forms.Panel _daysPanel;
		private System.Windows.Forms.StatusBarPanel _statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel _statusBarPanel2;

		private System.Windows.Forms.MenuItem _settingsMenuItem;
		private System.Windows.Forms.ToolBarButton separator1;
		private System.Windows.Forms.ToolBarButton separator2;
		private System.Windows.Forms.MenuItem _closeDocMenuItem;
		private System.Windows.Forms.MenuItem _separator3MenuItem;
		private System.Windows.Forms.MenuItem _separator4MenuItem;
		private System.Windows.Forms.MenuItem _fileMenuItem;
		private System.Windows.Forms.MenuItem _toolsMenuItem;
		private System.Windows.Forms.MenuItem _printTimetableMenuItem;
		private System.Windows.Forms.MenuItem _printChoiceEPMenuItem;
		private System.Windows.Forms.MenuItem _printChoiceTeacherMenuItem;
		private System.Windows.Forms.MenuItem _printChoiceRoomMenuItem;
		private System.Windows.Forms.MenuItem _epgMenuItem;
		private System.Windows.Forms.MenuItem _epMenuItem;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem _docMenuItem;
		private System.Windows.Forms.MenuItem _searchMenuItem;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem _addCourseFromClipboardMenuItem;
		private System.Windows.Forms.MenuItem _clearTimetableMenuItem;
		private System.Windows.Forms.MenuItem _courseMenuItem;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem _printTimetableAllTeachersMenuItem;
		private System.Windows.Forms.MenuItem _delAllTeachersMenuItem;
		private System.Windows.Forms.MenuItem _printTimetableAllRoomsMenuItem;
		private System.Windows.Forms.MenuItem _delAllRoomsMenuItem;
		private System.Windows.Forms.MenuItem _teacherMenuItem;
		private System.Windows.Forms.MenuItem _roomMenuItem;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem _delCourseMenuItem;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem38;
		private System.Windows.Forms.MenuItem menuItem39;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuItem45;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem menuItem51;
		private System.Windows.Forms.MenuItem _aboutMenuItem;
		private System.Windows.Forms.MenuItem _helpContentMenuItem;
		private System.Windows.Forms.MenuItem menuItem47;
		private System.Windows.Forms.ToolBarButton _helpToolBarButton;
		private System.Windows.Forms.ToolBarButton _searchToolBarButton;
		private System.Windows.Forms.ToolBarButton _printToolBarButton;

		private ColumnHeader _columnHeaderULLVCourses1;
		private ColumnHeader _columnHeaderULLVCourses2;

		private ColumnHeader _columnHeaderULLVTeachers1;
		private ColumnHeader _columnHeaderULLVTeachers2;
		private ColumnHeader _columnHeaderULLVTeachers3;
		private System.Windows.Forms.MenuItem _addEPGMenuItem;
		private System.Windows.Forms.MenuItem _addTeacherMenuItem;
		private System.Windows.Forms.MenuItem _addRoomMenuItem;
		private System.Windows.Forms.MenuItem _docPropertiesMenuItem;
		private System.Windows.Forms.MenuItem _epgPropertiesMenuItem;
		private System.Windows.Forms.MenuItem _addEPMenuItem;
		private System.Windows.Forms.MenuItem _epgATSMenuItem;
		private System.Windows.Forms.MenuItem _delEPGMenuItem;
		private System.Windows.Forms.MenuItem _epgPrintTTForAllEPsMenuItem;
		private System.Windows.Forms.MenuItem _epPropertiesMenuItem;
		private System.Windows.Forms.MenuItem _addCourseMenuItem;
		private System.Windows.Forms.MenuItem _epATSMenuItem;
		private System.Windows.Forms.MenuItem _epDelAllMyCoursesMenuItem;
		private System.Windows.Forms.MenuItem _delEPMenuItem;
		private System.Windows.Forms.MenuItem _epPrintTTMenuItem;
		private System.Windows.Forms.MenuItem _coursePropertiesMenuItem;
		private System.Windows.Forms.MenuItem _courseRoomsRestrictionMenuItem;
		private System.Windows.Forms.MenuItem _coursesToHoldTogetherMenuItem;
		private System.Windows.Forms.MenuItem _convertToGroupsMenuItem;
		private System.Windows.Forms.MenuItem _courseStoreToClipboardMenuItem;
		private System.Windows.Forms.MenuItem _teacherPropertiesMenuItem;
		private System.Windows.Forms.MenuItem _teacherATSMenuItem;
		private System.Windows.Forms.MenuItem _teacherRoomsRestrictionMenuItem;
		private System.Windows.Forms.MenuItem _delTeacherMenuItem;
		private System.Windows.Forms.MenuItem _teacherPrintTTMenuItem;
		private System.Windows.Forms.MenuItem _roomPropertiesMenuItem;
		private System.Windows.Forms.MenuItem _roomATSMenuItem;
		private System.Windows.Forms.MenuItem _delRoomMenuItem;
		private System.Windows.Forms.MenuItem _roomPrintTTMenuItem;
		private System.Windows.Forms.MenuItem _helpMenuItem;
		private System.Windows.Forms.MenuItem _addDaysMenuItem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem _addTermMenuItem;
        private MenuItem menuItem2;
        private MenuItem _autoTTMenuItem;
        private MenuItem _printTeacherListMenuItem;
        private MenuItem _printTeacherHoursMenuItem;
        private MenuItem _printRoomsListMenuItem;
        private MenuItem _scBaseTeachersMenuItem;
        private MenuItem menuItem3;
        public MenuItem _scBaseCoursesMenuItem;
        public MenuItem _scBaseEPMenuItem;
        private MenuItem menuItem4;
        private MenuItem _scTeacherMenuItem;
        private MenuItem menuItem6;
        public MenuItem _scEduProgramMenuItem;
        private MenuItem _autoTTDocMenuItem;
        private MenuItem _autoTTEPMenuItem;
        private MenuItem _autoTTTeacherMenuItem;
        private MenuItem menuItem7;
        private MenuItem _autoTTCourseMenuItem;
        public MenuItem _scCourseMenuItem;
        private MenuItem menuItem13;
        private MenuItem _printMasterTimetableMenuItem;

		private System.ComponentModel.IContainer components;

		
		public AppForm()
		{
			Settings.loadSettings();		
			
			try
			{
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.GUI_LANGUAGE);
			}
			catch{}
		
			InitializeComponent();		
	
			setResourceManager();
			
			updateFormRelatedStrings();

			DOCUMENT_TYPES_LIST= new ArrayList();			
			DOCUMENT_TYPES_LIST.Add(RES_MANAGER.GetString("doctypeslist.school.text"));			
			DOCUMENT_TYPES_LIST.Add(RES_MANAGER.GetString("doctypeslist.university.text"));

            _cmdProcessor=new CommandProcessor();
			
			enableDisableTBButton();	
			
			this.Text=APPLICATION_NAME;
			
			IS_DOC_OPEN=false;
			APP_FORM=this;

			DAY_TEXT = new String[7];
			DAY_TEXT[0]=RES_MANAGER.GetString("daytext.monday");
			DAY_TEXT[1]=RES_MANAGER.GetString("daytext.tuesday");
			DAY_TEXT[2]=RES_MANAGER.GetString("daytext.wednesday");
			DAY_TEXT[3]=RES_MANAGER.GetString("daytext.thursday");
			DAY_TEXT[4]=RES_MANAGER.GetString("daytext.friday");
			DAY_TEXT[5]=RES_MANAGER.GetString("daytext.saturday");
			DAY_TEXT[6]=RES_MANAGER.GetString("daytext.sunday");
	
			
			Settings.loadFileHistory();
			RFL_MENU_ITEMS_LIST = new ArrayList();
	
			if(Settings.RECENT_DOCS_LIST.Count>0)
			{
				makeRFLMenuItems();
			}

			//find all plugins and add menu items for them
			findPluginsAndAddMenuItems();
			
		}

		private void findPluginsAndAddMenuItems()
		{			
			PluginGlobal.Plugins.FindPlugins(Application.StartupPath);	
		
			MenuItem pluginsMenuItem=null;

			if(PluginGlobal.Plugins.MyAvailablePluginsCollection.Count>0)
			{
				MenuItem smi = new MenuItem("-");
				_toolsMenuItem.MenuItems.Add(smi);

				pluginsMenuItem = new MenuItem("Plugins");
				_toolsMenuItem.MenuItems.Add(pluginsMenuItem);

                
			}
			
			foreach (Types.OneAvailablePlugin plugin in PluginGlobal.Plugins.MyAvailablePluginsCollection)
			{				
				MenuItem mi = new MenuItem(plugin.Instance.MITextForHost);
				mi.Click+=new EventHandler(miPlugin_Click);
				pluginsMenuItem.MenuItems.Add(mi);

				plugin.Instance.HostMenuItemForActivation=mi;				
			}

			updateEnableDisableStateForPluginMenuItems();
		}

		private void miPlugin_Click(object sender, EventArgs e)
		{
			MenuItem mi = (MenuItem)sender;

			Types.OneAvailablePlugin pluginToShow = null;

			foreach (Types.OneAvailablePlugin plugin in PluginGlobal.Plugins.MyAvailablePluginsCollection)
			{	
				if(plugin.Instance.HostMenuItemForActivation==mi)
				{
					pluginToShow=plugin;
					break;
				}
			}

			if(pluginToShow!=null)
			{
				pluginToShow.Instance.Initialize();
				pluginToShow.Instance.MainGUIForm.ShowDialog(this);			
			}

		}

		private void updateEnableDisableStateForPluginMenuItems()
		{
			foreach (Types.OneAvailablePlugin plugin in PluginGlobal.Plugins.MyAvailablePluginsCollection)
			{
				MenuItem mi=plugin.Instance.HostMenuItemForActivation; 
				if(IS_DOC_OPEN)
				{
					if(plugin.Instance.EnabledDisabledMIType!=1)
					{
						mi.Enabled=true;
					}
					else
					{
						mi.Enabled=false;
					}
					
				}
				else
				{
					if(plugin.Instance.EnabledDisabledMIType!=2)
					{
						mi.Enabled=true;
					}
					else
					{
						mi.Enabled=false;
					}
				}
			}
		}


		private void makeRFLMenuItems()
		{
			try
			{
				int index=0;

				for(int cc=0;cc<Settings.RECENT_DOCS_LIST.Count;cc++)
				{					
					string s = (String)Settings.RECENT_DOCS_LIST[Settings.RECENT_DOCS_LIST.Count-1-cc];
					string reducedStr=reduceMe(s);
				
					MenuItem rfmi = new MenuItem((cc+1)+"  "+reducedStr);
					rfmi.Click += new System.EventHandler(this._openRFLDocMenuItem_Click);
					index=10+cc;
					_fileMenuItem.MenuItems.Add(index,rfmi);
					RFL_MENU_ITEMS_LIST.Add(rfmi);
				}
				
				MenuItem newSeparatorMI= new MenuItem("-");
				_fileMenuItem.MenuItems.Add((index+1),newSeparatorMI);
				RFL_MENU_ITEMS_LIST.Add(newSeparatorMI);
			}
			catch
			{
				Settings.RECENT_DOCS_LIST.Clear();

				foreach(MenuItem miFromList in RFL_MENU_ITEMS_LIST)
				{
					_fileMenuItem.MenuItems.Remove(miFromList);
				}

				RFL_MENU_ITEMS_LIST.Clear();                

			}
			
		}

		private string reduceMe(string s)
		{
			if(s.Length>30)
			{	
				int lastFileSeparatorIndex=s.LastIndexOf(@System.IO.Path.DirectorySeparatorChar);
				string redStr=s.Substring(0,3)+"..."+s.Substring(lastFileSeparatorIndex);
				return redStr;

			}else return s;

		}

		private void _openRFLDocMenuItem_Click(object sender, System.EventArgs e)
		{
			MenuItem mi = (MenuItem) sender;
			int fileIndex=Settings.RECENT_DOCS_LIST.Count-System.Convert.ToInt32(mi.Text.Substring(0,1));
			
			string fullFileName = (String)Settings.RECENT_DOCS_LIST[fileIndex];

			doOpenDocAction(fullFileName);
			
		}

		public AppForm(string startUpFileName):this()
		{			
			doOpenDocAction(startUpFileName);			

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this._fileMenuItem = new System.Windows.Forms.MenuItem();
            this._newDocMenuItem = new System.Windows.Forms.MenuItem();
            this._openDocMenuItem = new System.Windows.Forms.MenuItem();
            this._separator1MenuItem = new System.Windows.Forms.MenuItem();
            this._saveDocMenuItem = new System.Windows.Forms.MenuItem();
            this._saveAsDocMenuItem = new System.Windows.Forms.MenuItem();
            this._separator2MenuItem = new System.Windows.Forms.MenuItem();
            this._closeDocMenuItem = new System.Windows.Forms.MenuItem();
            this._separator3MenuItem = new System.Windows.Forms.MenuItem();
            this._printTimetableMenuItem = new System.Windows.Forms.MenuItem();
            this._printChoiceEPMenuItem = new System.Windows.Forms.MenuItem();
            this._printChoiceTeacherMenuItem = new System.Windows.Forms.MenuItem();
            this._printChoiceRoomMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this._printMasterTimetableMenuItem = new System.Windows.Forms.MenuItem();
            this._separator4MenuItem = new System.Windows.Forms.MenuItem();
            this._exitAppMenuItem = new System.Windows.Forms.MenuItem();
            this._docMenuItem = new System.Windows.Forms.MenuItem();
            this._addEPGMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this._addTeacherMenuItem = new System.Windows.Forms.MenuItem();
            this._delAllTeachersMenuItem = new System.Windows.Forms.MenuItem();
            this._printTimetableAllTeachersMenuItem = new System.Windows.Forms.MenuItem();
            this._printTeacherListMenuItem = new System.Windows.Forms.MenuItem();
            this._printTeacherHoursMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this._addRoomMenuItem = new System.Windows.Forms.MenuItem();
            this._delAllRoomsMenuItem = new System.Windows.Forms.MenuItem();
            this._printTimetableAllRoomsMenuItem = new System.Windows.Forms.MenuItem();
            this._printRoomsListMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this._addDaysMenuItem = new System.Windows.Forms.MenuItem();
            this._addTermMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this._autoTTDocMenuItem = new System.Windows.Forms.MenuItem();
            this._scBaseEPMenuItem = new System.Windows.Forms.MenuItem();
            this._scBaseCoursesMenuItem = new System.Windows.Forms.MenuItem();
            this._scBaseTeachersMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this._docPropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this._searchMenuItem = new System.Windows.Forms.MenuItem();
            this._epgMenuItem = new System.Windows.Forms.MenuItem();
            this._epgPropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this._addEPMenuItem = new System.Windows.Forms.MenuItem();
            this._epgATSMenuItem = new System.Windows.Forms.MenuItem();
            this._delEPGMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this._epgPrintTTForAllEPsMenuItem = new System.Windows.Forms.MenuItem();
            this._epMenuItem = new System.Windows.Forms.MenuItem();
            this._epPropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this._addCourseMenuItem = new System.Windows.Forms.MenuItem();
            this._addCourseFromClipboardMenuItem = new System.Windows.Forms.MenuItem();
            this._epATSMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this._clearTimetableMenuItem = new System.Windows.Forms.MenuItem();
            this._epDelAllMyCoursesMenuItem = new System.Windows.Forms.MenuItem();
            this._delEPMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this._epPrintTTMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this._autoTTEPMenuItem = new System.Windows.Forms.MenuItem();
            this._scEduProgramMenuItem = new System.Windows.Forms.MenuItem();
            this._courseMenuItem = new System.Windows.Forms.MenuItem();
            this._coursePropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this._courseRoomsRestrictionMenuItem = new System.Windows.Forms.MenuItem();
            this._coursesToHoldTogetherMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this._convertToGroupsMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this._delCourseMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this._courseStoreToClipboardMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this._autoTTCourseMenuItem = new System.Windows.Forms.MenuItem();
            this._scCourseMenuItem = new System.Windows.Forms.MenuItem();
            this._teacherMenuItem = new System.Windows.Forms.MenuItem();
            this._teacherPropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this._teacherATSMenuItem = new System.Windows.Forms.MenuItem();
            this._teacherRoomsRestrictionMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this._delTeacherMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this._teacherPrintTTMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this._autoTTTeacherMenuItem = new System.Windows.Forms.MenuItem();
            this._scTeacherMenuItem = new System.Windows.Forms.MenuItem();
            this._roomMenuItem = new System.Windows.Forms.MenuItem();
            this._roomPropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this._roomATSMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this._delRoomMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this._roomPrintTTMenuItem = new System.Windows.Forms.MenuItem();
            this._toolsMenuItem = new System.Windows.Forms.MenuItem();
            this._settingsMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this._autoTTMenuItem = new System.Windows.Forms.MenuItem();
            this._helpMenuItem = new System.Windows.Forms.MenuItem();
            this._helpContentMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this._aboutMenuItem = new System.Windows.Forms.MenuItem();
            this._mainToolBar = new System.Windows.Forms.ToolBar();
            this._newDocToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._openDocToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._saveDocToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._closeDocToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.separator1 = new System.Windows.Forms.ToolBarButton();
            this._undoToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._redoToolBarButton = new System.Windows.Forms.ToolBarButton();
            this.separator2 = new System.Windows.Forms.ToolBarButton();
            this._searchToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._printToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._helpToolBarButton = new System.Windows.Forms.ToolBarButton();
            this._toolbarImageList = new System.Windows.Forms.ImageList(this.components);
            this._statusBar = new System.Windows.Forms.StatusBar();
            this._statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this._statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this._coursesTreeContextMenu = new System.Windows.Forms.ContextMenu();
            this._treeImageList = new System.Windows.Forms.ImageList(this.components);
            this._teachersTreeContextMenu = new System.Windows.Forms.ContextMenu();
            this._roomsTreeContextMenu = new System.Windows.Forms.ContextMenu();
            this._firstPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._statusBarPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._fileMenuItem,
            this._docMenuItem,
            this._epgMenuItem,
            this._epMenuItem,
            this._courseMenuItem,
            this._teacherMenuItem,
            this._roomMenuItem,
            this._toolsMenuItem,
            this._helpMenuItem});
            // 
            // _fileMenuItem
            // 
            this._fileMenuItem.Index = 0;
            this._fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._newDocMenuItem,
            this._openDocMenuItem,
            this._separator1MenuItem,
            this._saveDocMenuItem,
            this._saveAsDocMenuItem,
            this._separator2MenuItem,
            this._closeDocMenuItem,
            this._separator3MenuItem,
            this._printTimetableMenuItem,
            this._separator4MenuItem,
            this._exitAppMenuItem});
            this._fileMenuItem.Text = "File";
            this._fileMenuItem.Popup += new System.EventHandler(this._fileMenuItem_Popup);
            // 
            // _newDocMenuItem
            // 
            this._newDocMenuItem.Index = 0;
            this._newDocMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this._newDocMenuItem.Text = "New document";
            this._newDocMenuItem.Click += new System.EventHandler(this._newDocMenuItem_Click);
            // 
            // _openDocMenuItem
            // 
            this._openDocMenuItem.Index = 1;
            this._openDocMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this._openDocMenuItem.Text = "Open document";
            this._openDocMenuItem.Click += new System.EventHandler(this._openDocMenuItem_Click);
            // 
            // _separator1MenuItem
            // 
            this._separator1MenuItem.Index = 2;
            this._separator1MenuItem.Text = "-";
            // 
            // _saveDocMenuItem
            // 
            this._saveDocMenuItem.Index = 3;
            this._saveDocMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this._saveDocMenuItem.Text = "Save";
            this._saveDocMenuItem.Click += new System.EventHandler(this._saveDocMenuItem_Click);
            // 
            // _saveAsDocMenuItem
            // 
            this._saveAsDocMenuItem.Index = 4;
            this._saveAsDocMenuItem.Text = "Save as...";
            this._saveAsDocMenuItem.Click += new System.EventHandler(this._saveAsDocMenuItem_Click);
            // 
            // _separator2MenuItem
            // 
            this._separator2MenuItem.Index = 5;
            this._separator2MenuItem.Text = "-";
            // 
            // _closeDocMenuItem
            // 
            this._closeDocMenuItem.Index = 6;
            this._closeDocMenuItem.Text = "Close document";
            this._closeDocMenuItem.Click += new System.EventHandler(this._closeDocMenuItem_Click);
            // 
            // _separator3MenuItem
            // 
            this._separator3MenuItem.Index = 7;
            this._separator3MenuItem.Text = "-";
            // 
            // _printTimetableMenuItem
            // 
            this._printTimetableMenuItem.Enabled = false;
            this._printTimetableMenuItem.Index = 8;
            this._printTimetableMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._printChoiceEPMenuItem,
            this._printChoiceTeacherMenuItem,
            this._printChoiceRoomMenuItem,
            this.menuItem13,
            this._printMasterTimetableMenuItem});
            this._printTimetableMenuItem.Text = "Print timetable";
            // 
            // _printChoiceEPMenuItem
            // 
            this._printChoiceEPMenuItem.Index = 0;
            this._printChoiceEPMenuItem.Text = "For educational programs";
            this._printChoiceEPMenuItem.Click += new System.EventHandler(this._printEPMenuItem_Click);
            // 
            // _printChoiceTeacherMenuItem
            // 
            this._printChoiceTeacherMenuItem.Index = 1;
            this._printChoiceTeacherMenuItem.Text = "For teachers";
            this._printChoiceTeacherMenuItem.Click += new System.EventHandler(this._printTeachersMenuItem_Click);
            // 
            // _printChoiceRoomMenuItem
            // 
            this._printChoiceRoomMenuItem.Index = 2;
            this._printChoiceRoomMenuItem.Text = "For rooms";
            this._printChoiceRoomMenuItem.Click += new System.EventHandler(this._printRoomsMenuItem_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 3;
            this.menuItem13.Text = "-";
            // 
            // _printMasterTimetableMenuItem
            // 
            this._printMasterTimetableMenuItem.Index = 4;
            this._printMasterTimetableMenuItem.Text = "Master timetable";
            this._printMasterTimetableMenuItem.Click += new System.EventHandler(this._printMasterTimetableMenuItem_Click);
            // 
            // _separator4MenuItem
            // 
            this._separator4MenuItem.Index = 9;
            this._separator4MenuItem.Text = "-";
            // 
            // _exitAppMenuItem
            // 
            this._exitAppMenuItem.Index = 10;
            this._exitAppMenuItem.Text = "Exit";
            this._exitAppMenuItem.Click += new System.EventHandler(this._exitAppMenuItem_Click);
            // 
            // _docMenuItem
            // 
            this._docMenuItem.Enabled = false;
            this._docMenuItem.Index = 1;
            this._docMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._addEPGMenuItem,
            this.menuItem21,
            this._addTeacherMenuItem,
            this._delAllTeachersMenuItem,
            this._printTimetableAllTeachersMenuItem,
            this._printTeacherListMenuItem,
            this._printTeacherHoursMenuItem,
            this.menuItem25,
            this._addRoomMenuItem,
            this._delAllRoomsMenuItem,
            this._printTimetableAllRoomsMenuItem,
            this._printRoomsListMenuItem,
            this.menuItem29,
            this._addDaysMenuItem,
            this._addTermMenuItem,
            this.menuItem3,
            this._autoTTDocMenuItem,
            this.menuItem1,
            this._docPropertiesMenuItem,
            this.menuItem31,
            this._searchMenuItem});
            this._docMenuItem.Text = "Document";
            this._docMenuItem.Popup += new System.EventHandler(this._docMenuItem_Popup);
            // 
            // _addEPGMenuItem
            // 
            this._addEPGMenuItem.Index = 0;
            this._addEPGMenuItem.Text = "Add new educational program group";
            this._addEPGMenuItem.Click += new System.EventHandler(this.addEPG_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 1;
            this.menuItem21.Text = "-";
            // 
            // _addTeacherMenuItem
            // 
            this._addTeacherMenuItem.Index = 2;
            this._addTeacherMenuItem.Text = "Add teacher";
            this._addTeacherMenuItem.Click += new System.EventHandler(this.addTeacher_Click);
            // 
            // _delAllTeachersMenuItem
            // 
            this._delAllTeachersMenuItem.Index = 3;
            this._delAllTeachersMenuItem.Text = "Delete all teachers";
            this._delAllTeachersMenuItem.Click += new System.EventHandler(this.deleteAllTeachers_Click);
            // 
            // _printTimetableAllTeachersMenuItem
            // 
            this._printTimetableAllTeachersMenuItem.Index = 4;
            this._printTimetableAllTeachersMenuItem.Text = "Print timetable for all teachers";
            this._printTimetableAllTeachersMenuItem.Click += new System.EventHandler(this.printTimetableForAllTeachers_Click);
            // 
            // _printTeacherListMenuItem
            // 
            this._printTeacherListMenuItem.Index = 5;
            this._printTeacherListMenuItem.Text = "Print teacher list";
            this._printTeacherListMenuItem.Click += new System.EventHandler(this.printTeacherList_Click);
            // 
            // _printTeacherHoursMenuItem
            // 
            this._printTeacherHoursMenuItem.Index = 6;
            this._printTeacherHoursMenuItem.Text = "Print teacher hours";
            this._printTeacherHoursMenuItem.Click += new System.EventHandler(this.printTeacherHours_Click);
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 7;
            this.menuItem25.Text = "-";
            // 
            // _addRoomMenuItem
            // 
            this._addRoomMenuItem.Index = 8;
            this._addRoomMenuItem.Text = "Add room";
            this._addRoomMenuItem.Click += new System.EventHandler(this.addUcionica_Click);
            // 
            // _delAllRoomsMenuItem
            // 
            this._delAllRoomsMenuItem.Index = 9;
            this._delAllRoomsMenuItem.Text = "Delete all rooms";
            this._delAllRoomsMenuItem.Click += new System.EventHandler(this.deleteAllRooms_Click);
            // 
            // _printTimetableAllRoomsMenuItem
            // 
            this._printTimetableAllRoomsMenuItem.Index = 10;
            this._printTimetableAllRoomsMenuItem.Text = "Print timetable for all rooms";
            this._printTimetableAllRoomsMenuItem.Click += new System.EventHandler(this.printTimetableForAllRooms_Click);
            // 
            // _printRoomsListMenuItem
            // 
            this._printRoomsListMenuItem.Index = 11;
            this._printRoomsListMenuItem.Text = "Print rooms list";
            this._printRoomsListMenuItem.Click += new System.EventHandler(this.printRoomsList_Click);
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 12;
            this.menuItem29.Text = "-";
            // 
            // _addDaysMenuItem
            // 
            this._addDaysMenuItem.Index = 13;
            this._addDaysMenuItem.Text = "Add day";
            this._addDaysMenuItem.Click += new System.EventHandler(this._addDaysMenuItem_Click);
            // 
            // _addTermMenuItem
            // 
            this._addTermMenuItem.Index = 14;
            this._addTermMenuItem.Text = "Add term";
            this._addTermMenuItem.Click += new System.EventHandler(this._addTermMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 15;
            this.menuItem3.Text = "-";
            // 
            // _autoTTDocMenuItem
            // 
            this._autoTTDocMenuItem.Index = 16;
            this._autoTTDocMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._scBaseEPMenuItem,
            this._scBaseCoursesMenuItem,
            this._scBaseTeachersMenuItem});
            this._autoTTDocMenuItem.Text = "Automated timetabling";
            // 
            // _scBaseEPMenuItem
            // 
            this._scBaseEPMenuItem.Index = 0;
            this._scBaseEPMenuItem.Text = "Base soft cons. for educational programs";
            this._scBaseEPMenuItem.Click += new System.EventHandler(this.softConsBaseEPMenuItem_Click);
            // 
            // _scBaseCoursesMenuItem
            // 
            this._scBaseCoursesMenuItem.Index = 1;
            this._scBaseCoursesMenuItem.Text = "Base soft cons. for courses";
            this._scBaseCoursesMenuItem.Click += new System.EventHandler(this.softConsBaseCoursesMenuItem_Click);
            // 
            // _scBaseTeachersMenuItem
            // 
            this._scBaseTeachersMenuItem.Index = 2;
            this._scBaseTeachersMenuItem.Text = "Base soft cons. for teachers";
            this._scBaseTeachersMenuItem.Click += new System.EventHandler(this.softConsBaseTeachersMenuItem_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 17;
            this.menuItem1.Text = "-";
            // 
            // _docPropertiesMenuItem
            // 
            this._docPropertiesMenuItem.Index = 18;
            this._docPropertiesMenuItem.Text = "Document properties";
            this._docPropertiesMenuItem.Click += new System.EventHandler(this.docPropertiesMenuItem_Click);
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 19;
            this.menuItem31.Text = "-";
            // 
            // _searchMenuItem
            // 
            this._searchMenuItem.Index = 20;
            this._searchMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this._searchMenuItem.Text = "Find";
            this._searchMenuItem.Click += new System.EventHandler(this._searchMenuItem_Click);
            // 
            // _epgMenuItem
            // 
            this._epgMenuItem.Enabled = false;
            this._epgMenuItem.Index = 2;
            this._epgMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._epgPropertiesMenuItem,
            this.menuItem9,
            this._addEPMenuItem,
            this._epgATSMenuItem,
            this._delEPGMenuItem,
            this.menuItem10,
            this._epgPrintTTForAllEPsMenuItem});
            this._epgMenuItem.Text = "Educational program group";
            // 
            // _epgPropertiesMenuItem
            // 
            this._epgPropertiesMenuItem.Index = 0;
            this._epgPropertiesMenuItem.Text = "Educational program group properties";
            this._epgPropertiesMenuItem.Click += new System.EventHandler(this.renameEPG_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "-";
            // 
            // _addEPMenuItem
            // 
            this._addEPMenuItem.Index = 2;
            this._addEPMenuItem.Text = "Add new educational program";
            this._addEPMenuItem.Click += new System.EventHandler(this.addEduProgram_Click);
            // 
            // _epgATSMenuItem
            // 
            this._epgATSMenuItem.Index = 3;
            this._epgATSMenuItem.Text = "Define allowed/unallowed time-slots";
            this._epgATSMenuItem.Click += new System.EventHandler(this.allowedTimeSlotsEPG_Click);
            // 
            // _delEPGMenuItem
            // 
            this._delEPGMenuItem.Index = 4;
            this._delEPGMenuItem.Text = "Delete educational program group";
            this._delEPGMenuItem.Click += new System.EventHandler(this.deleteEPG_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 5;
            this.menuItem10.Text = "-";
            // 
            // _epgPrintTTForAllEPsMenuItem
            // 
            this._epgPrintTTForAllEPsMenuItem.Index = 6;
            this._epgPrintTTForAllEPsMenuItem.Text = "Print timetable for all belonging educational programs";
            this._epgPrintTTForAllEPsMenuItem.Click += new System.EventHandler(this.printTimetableForAllEduPrograms_Click);
            // 
            // _epMenuItem
            // 
            this._epMenuItem.Enabled = false;
            this._epMenuItem.Index = 3;
            this._epMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._epPropertiesMenuItem,
            this.menuItem11,
            this._addCourseMenuItem,
            this._addCourseFromClipboardMenuItem,
            this._epATSMenuItem,
            this.menuItem15,
            this._clearTimetableMenuItem,
            this._epDelAllMyCoursesMenuItem,
            this._delEPMenuItem,
            this.menuItem19,
            this._epPrintTTMenuItem,
            this.menuItem6,
            this._autoTTEPMenuItem});
            this._epMenuItem.Text = "Educational program";
            this._epMenuItem.Popup += new System.EventHandler(this._epMenuItem_Popup);
            // 
            // _epPropertiesMenuItem
            // 
            this._epPropertiesMenuItem.Index = 0;
            this._epPropertiesMenuItem.Text = "Educational program properties";
            this._epPropertiesMenuItem.Click += new System.EventHandler(this.propertiesEduProgram_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "-";
            // 
            // _addCourseMenuItem
            // 
            this._addCourseMenuItem.Index = 2;
            this._addCourseMenuItem.Text = "Add new course";
            this._addCourseMenuItem.Click += new System.EventHandler(this.addCourse_Click);
            // 
            // _addCourseFromClipboardMenuItem
            // 
            this._addCourseFromClipboardMenuItem.Index = 3;
            this._addCourseFromClipboardMenuItem.Text = "Add new course from clipboard";
            this._addCourseFromClipboardMenuItem.Click += new System.EventHandler(this.addCourseFromClipboard_Click);
            // 
            // _epATSMenuItem
            // 
            this._epATSMenuItem.Index = 4;
            this._epATSMenuItem.Text = "Define allowed/unallowed time-slots";
            this._epATSMenuItem.Click += new System.EventHandler(this.allowedTimeSlotsEduProgram_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 5;
            this.menuItem15.Text = "-";
            // 
            // _clearTimetableMenuItem
            // 
            this._clearTimetableMenuItem.Index = 6;
            this._clearTimetableMenuItem.Text = "Clear timetable";
            this._clearTimetableMenuItem.Click += new System.EventHandler(this.clearTimetable_Click);
            // 
            // _epDelAllMyCoursesMenuItem
            // 
            this._epDelAllMyCoursesMenuItem.Index = 7;
            this._epDelAllMyCoursesMenuItem.Text = "Delete all belonging courses";
            this._epDelAllMyCoursesMenuItem.Click += new System.EventHandler(this.deleteAllCourses_Click);
            // 
            // _delEPMenuItem
            // 
            this._delEPMenuItem.Index = 8;
            this._delEPMenuItem.Text = "Delete educational program";
            this._delEPMenuItem.Click += new System.EventHandler(this.deleteEduProgram_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 9;
            this.menuItem19.Text = "-";
            // 
            // _epPrintTTMenuItem
            // 
            this._epPrintTTMenuItem.Index = 10;
            this._epPrintTTMenuItem.Text = "Print timetable for educational program";
            this._epPrintTTMenuItem.Click += new System.EventHandler(this.printTimetableForOneEduProgram_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 11;
            this.menuItem6.Text = "-";
            // 
            // _autoTTEPMenuItem
            // 
            this._autoTTEPMenuItem.Index = 12;
            this._autoTTEPMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._scEduProgramMenuItem});
            this._autoTTEPMenuItem.Text = "Automated timetabling";
            // 
            // _scEduProgramMenuItem
            // 
            this._scEduProgramMenuItem.Index = 0;
            this._scEduProgramMenuItem.Text = "Soft constraints settings for educational program";
            this._scEduProgramMenuItem.Click += new System.EventHandler(this.softConsEPMenuItem_Click);
            // 
            // _courseMenuItem
            // 
            this._courseMenuItem.Enabled = false;
            this._courseMenuItem.Index = 4;
            this._courseMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._coursePropertiesMenuItem,
            this.menuItem5,
            this._courseRoomsRestrictionMenuItem,
            this._coursesToHoldTogetherMenuItem,
            this.menuItem23,
            this._convertToGroupsMenuItem,
            this.menuItem47,
            this._delCourseMenuItem,
            this.menuItem32,
            this._courseStoreToClipboardMenuItem,
            this.menuItem7,
            this._autoTTCourseMenuItem});
            this._courseMenuItem.Text = "Course";
            this._courseMenuItem.Popup += new System.EventHandler(this._courseMenuItem_Popup);
            // 
            // _coursePropertiesMenuItem
            // 
            this._coursePropertiesMenuItem.Index = 0;
            this._coursePropertiesMenuItem.Text = "Course properties";
            this._coursePropertiesMenuItem.Click += new System.EventHandler(this.propertiesCourse_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // _courseRoomsRestrictionMenuItem
            // 
            this._courseRoomsRestrictionMenuItem.Index = 2;
            this._courseRoomsRestrictionMenuItem.Text = "Restrict possible rooms";
            this._courseRoomsRestrictionMenuItem.Click += new System.EventHandler(this.roomRestrictionForCourse_Click);
            // 
            // _coursesToHoldTogetherMenuItem
            // 
            this._coursesToHoldTogetherMenuItem.Index = 3;
            this._coursesToHoldTogetherMenuItem.Text = "Define courses to hold together";
            this._coursesToHoldTogetherMenuItem.Click += new System.EventHandler(this.defCoursesToHoldTogether_Click);
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 4;
            this.menuItem23.Text = "-";
            // 
            // _convertToGroupsMenuItem
            // 
            this._convertToGroupsMenuItem.Enabled = false;
            this._convertToGroupsMenuItem.Index = 5;
            this._convertToGroupsMenuItem.Text = "Convert to groups";
            this._convertToGroupsMenuItem.Click += new System.EventHandler(this._courseConvertToGroupsMenuItem_Click);
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 6;
            this.menuItem47.Text = "-";
            // 
            // _delCourseMenuItem
            // 
            this._delCourseMenuItem.Index = 7;
            this._delCourseMenuItem.Text = "Delete course";
            this._delCourseMenuItem.Click += new System.EventHandler(this.deleteCourse_Click);
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 8;
            this.menuItem32.Text = "-";
            // 
            // _courseStoreToClipboardMenuItem
            // 
            this._courseStoreToClipboardMenuItem.Index = 9;
            this._courseStoreToClipboardMenuItem.Text = "Copy course to clipboard";
            this._courseStoreToClipboardMenuItem.Click += new System.EventHandler(this.addCourseDataToClipboard_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 10;
            this.menuItem7.Text = "-";
            // 
            // _autoTTCourseMenuItem
            // 
            this._autoTTCourseMenuItem.Index = 11;
            this._autoTTCourseMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._scCourseMenuItem});
            this._autoTTCourseMenuItem.Text = "Automated timetabling";
            // 
            // _scCourseMenuItem
            // 
            this._scCourseMenuItem.Index = 0;
            this._scCourseMenuItem.Text = "Soft constraints settings for selected course";
            this._scCourseMenuItem.Click += new System.EventHandler(this.softConsCourseMenuItem_Click);
            // 
            // _teacherMenuItem
            // 
            this._teacherMenuItem.Enabled = false;
            this._teacherMenuItem.Index = 5;
            this._teacherMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._teacherPropertiesMenuItem,
            this.menuItem37,
            this._teacherATSMenuItem,
            this._teacherRoomsRestrictionMenuItem,
            this.menuItem38,
            this._delTeacherMenuItem,
            this.menuItem39,
            this._teacherPrintTTMenuItem,
            this.menuItem4,
            this._autoTTTeacherMenuItem});
            this._teacherMenuItem.Text = "Teacher";
            // 
            // _teacherPropertiesMenuItem
            // 
            this._teacherPropertiesMenuItem.Index = 0;
            this._teacherPropertiesMenuItem.Text = "Teacher properties";
            this._teacherPropertiesMenuItem.Click += new System.EventHandler(this.propertiesTeacher_Click);
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 1;
            this.menuItem37.Text = "-";
            // 
            // _teacherATSMenuItem
            // 
            this._teacherATSMenuItem.Index = 2;
            this._teacherATSMenuItem.Text = "Define allowed/unallowed time-slots";
            this._teacherATSMenuItem.Click += new System.EventHandler(this.allowedTimeSlotsForTeacher_Click);
            // 
            // _teacherRoomsRestrictionMenuItem
            // 
            this._teacherRoomsRestrictionMenuItem.Index = 3;
            this._teacherRoomsRestrictionMenuItem.Text = "Restrict possible rooms";
            this._teacherRoomsRestrictionMenuItem.Click += new System.EventHandler(this.roomRestrictionForTeacher_Click);
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 4;
            this.menuItem38.Text = "-";
            // 
            // _delTeacherMenuItem
            // 
            this._delTeacherMenuItem.Index = 5;
            this._delTeacherMenuItem.Text = "Delete teacher";
            this._delTeacherMenuItem.Click += new System.EventHandler(this.deleteTeacher_Click);
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 6;
            this.menuItem39.Text = "-";
            // 
            // _teacherPrintTTMenuItem
            // 
            this._teacherPrintTTMenuItem.Index = 7;
            this._teacherPrintTTMenuItem.Text = "Print timetable for teacher";
            this._teacherPrintTTMenuItem.Click += new System.EventHandler(this.printTimetableForOneTeacher_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 8;
            this.menuItem4.Text = "-";
            // 
            // _autoTTTeacherMenuItem
            // 
            this._autoTTTeacherMenuItem.Index = 9;
            this._autoTTTeacherMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._scTeacherMenuItem});
            this._autoTTTeacherMenuItem.Text = "Automated timetabling";
            // 
            // _scTeacherMenuItem
            // 
            this._scTeacherMenuItem.Index = 0;
            this._scTeacherMenuItem.Text = "Soft constraints settings for teacher";
            this._scTeacherMenuItem.Click += new System.EventHandler(this.softConsTeacherMenuItem_Click);
            // 
            // _roomMenuItem
            // 
            this._roomMenuItem.Enabled = false;
            this._roomMenuItem.Index = 6;
            this._roomMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._roomPropertiesMenuItem,
            this.menuItem44,
            this._roomATSMenuItem,
            this.menuItem45,
            this._delRoomMenuItem,
            this.menuItem46,
            this._roomPrintTTMenuItem});
            this._roomMenuItem.Text = "Room";
            // 
            // _roomPropertiesMenuItem
            // 
            this._roomPropertiesMenuItem.Index = 0;
            this._roomPropertiesMenuItem.Text = "Room properties";
            this._roomPropertiesMenuItem.Click += new System.EventHandler(this.propertiesRoom_Click);
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 1;
            this.menuItem44.Text = "-";
            // 
            // _roomATSMenuItem
            // 
            this._roomATSMenuItem.Index = 2;
            this._roomATSMenuItem.Text = "Define allowed/unallowed time-slots";
            this._roomATSMenuItem.Click += new System.EventHandler(this.allowedTimeSlotsForRoom_Click);
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 3;
            this.menuItem45.Text = "-";
            // 
            // _delRoomMenuItem
            // 
            this._delRoomMenuItem.Index = 4;
            this._delRoomMenuItem.Text = "Delete room";
            this._delRoomMenuItem.Click += new System.EventHandler(this.deleteRoom_Click);
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 5;
            this.menuItem46.Text = "-";
            // 
            // _roomPrintTTMenuItem
            // 
            this._roomPrintTTMenuItem.Index = 6;
            this._roomPrintTTMenuItem.Text = "Print timetable for room";
            this._roomPrintTTMenuItem.Click += new System.EventHandler(this.printTimetableForOneRoom_Click);
            // 
            // _toolsMenuItem
            // 
            this._toolsMenuItem.Index = 7;
            this._toolsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._autoTTMenuItem,
            this.menuItem2,
            this._settingsMenuItem});
            this._toolsMenuItem.Text = "Tools";
            this._toolsMenuItem.Popup += new System.EventHandler(this._toolsMenuItem_Popup);
            // 
            // _settingsMenuItem
            // 
            this._settingsMenuItem.Index = 2;
            this._settingsMenuItem.Text = "Settings";
            this._settingsMenuItem.Click += new System.EventHandler(this._settingsMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // _autoTTMenuItem
            // 
            this._autoTTMenuItem.Index = 0;
            this._autoTTMenuItem.Text = "Automated timetabling";
            this._autoTTMenuItem.Click += new System.EventHandler(this._autoTTMenuItem_Click);
            // 
            // _helpMenuItem
            // 
            this._helpMenuItem.Index = 8;
            this._helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._helpContentMenuItem,
            this.menuItem51,
            this._aboutMenuItem});
            this._helpMenuItem.Text = "Help";
            // 
            // _helpContentMenuItem
            // 
            this._helpContentMenuItem.Index = 0;
            this._helpContentMenuItem.Text = "Contents";
            this._helpContentMenuItem.Visible = false;
            this._helpContentMenuItem.Click += new System.EventHandler(this._helpContentMenuItem_Click);
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 1;
            this.menuItem51.Text = "-";
            this.menuItem51.Visible = false;
            // 
            // _aboutMenuItem
            // 
            this._aboutMenuItem.Index = 2;
            this._aboutMenuItem.Text = "About";
            this._aboutMenuItem.Click += new System.EventHandler(this._aboutMenuItem_Click);
            // 
            // _mainToolBar
            // 
            this._mainToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this._mainToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._newDocToolBarButton,
            this._openDocToolBarButton,
            this._saveDocToolBarButton,
            this._closeDocToolBarButton,
            this.separator1,
            this._undoToolBarButton,
            this._redoToolBarButton,
            this.separator2,
            this._searchToolBarButton,
            this._printToolBarButton,
            this._helpToolBarButton});
            this._mainToolBar.ButtonSize = new System.Drawing.Size(22, 22);
            this._mainToolBar.Divider = false;
            this._mainToolBar.DropDownArrows = true;
            this._mainToolBar.ImageList = this._toolbarImageList;
            this._mainToolBar.Location = new System.Drawing.Point(0, 0);
            this._mainToolBar.Name = "_mainToolBar";
            this._mainToolBar.ShowToolTips = true;
            this._mainToolBar.Size = new System.Drawing.Size(744, 26);
            this._mainToolBar.TabIndex = 0;
            this._mainToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._mainToolBar_ButtonClick);
            // 
            // _newDocToolBarButton
            // 
            this._newDocToolBarButton.ImageIndex = 0;
            this._newDocToolBarButton.Name = "_newDocToolBarButton";
            this._newDocToolBarButton.ToolTipText = "Novi dokument";
            // 
            // _openDocToolBarButton
            // 
            this._openDocToolBarButton.ImageIndex = 1;
            this._openDocToolBarButton.Name = "_openDocToolBarButton";
            this._openDocToolBarButton.ToolTipText = "Otvori dokument";
            // 
            // _saveDocToolBarButton
            // 
            this._saveDocToolBarButton.ImageIndex = 2;
            this._saveDocToolBarButton.Name = "_saveDocToolBarButton";
            this._saveDocToolBarButton.ToolTipText = "Spremi";
            // 
            // _closeDocToolBarButton
            // 
            this._closeDocToolBarButton.ImageIndex = 3;
            this._closeDocToolBarButton.Name = "_closeDocToolBarButton";
            this._closeDocToolBarButton.ToolTipText = "Zatvori";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // _undoToolBarButton
            // 
            this._undoToolBarButton.ImageIndex = 4;
            this._undoToolBarButton.Name = "_undoToolBarButton";
            this._undoToolBarButton.ToolTipText = "Undo";
            // 
            // _redoToolBarButton
            // 
            this._redoToolBarButton.ImageIndex = 5;
            this._redoToolBarButton.Name = "_redoToolBarButton";
            this._redoToolBarButton.ToolTipText = "Redo";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // _searchToolBarButton
            // 
            this._searchToolBarButton.ImageIndex = 6;
            this._searchToolBarButton.Name = "_searchToolBarButton";
            this._searchToolBarButton.ToolTipText = "Pretraživanje";
            // 
            // _printToolBarButton
            // 
            this._printToolBarButton.ImageIndex = 7;
            this._printToolBarButton.Name = "_printToolBarButton";
            this._printToolBarButton.ToolTipText = "Ispis";
            // 
            // _helpToolBarButton
            // 
            this._helpToolBarButton.ImageIndex = 8;
            this._helpToolBarButton.Name = "_helpToolBarButton";
            this._helpToolBarButton.ToolTipText = "Pomoæ";
            this._helpToolBarButton.Visible = false;
            // 
            // _toolbarImageList
            // 
            this._toolbarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_toolbarImageList.ImageStream")));
            this._toolbarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._toolbarImageList.Images.SetKeyName(0, "");
            this._toolbarImageList.Images.SetKeyName(1, "");
            this._toolbarImageList.Images.SetKeyName(2, "");
            this._toolbarImageList.Images.SetKeyName(3, "");
            this._toolbarImageList.Images.SetKeyName(4, "");
            this._toolbarImageList.Images.SetKeyName(5, "");
            this._toolbarImageList.Images.SetKeyName(6, "");
            this._toolbarImageList.Images.SetKeyName(7, "");
            this._toolbarImageList.Images.SetKeyName(8, "");
            this._toolbarImageList.Images.SetKeyName(9, "");
            this._toolbarImageList.Images.SetKeyName(10, "");
            this._toolbarImageList.Images.SetKeyName(11, "");
            this._toolbarImageList.Images.SetKeyName(12, "");
            this._toolbarImageList.Images.SetKeyName(13, "");
            this._toolbarImageList.Images.SetKeyName(14, "");
            // 
            // _statusBar
            // 
            this._statusBar.Location = new System.Drawing.Point(0, 353);
            this._statusBar.Name = "_statusBar";
            this._statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this._statusBarPanel1,
            this._statusBarPanel2});
            this._statusBar.ShowPanels = true;
            this._statusBar.Size = new System.Drawing.Size(744, 20);
            this._statusBar.TabIndex = 1;
            // 
            // _statusBarPanel1
            // 
            this._statusBarPanel1.MinWidth = 150;
            this._statusBarPanel1.Name = "_statusBarPanel1";
            this._statusBarPanel1.Width = 600;
            // 
            // _statusBarPanel2
            // 
            this._statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this._statusBarPanel2.MinWidth = 100;
            this._statusBarPanel2.Name = "_statusBarPanel2";
            this._statusBarPanel2.Width = 127;
            // 
            // _treeImageList
            // 
            this._treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_treeImageList.ImageStream")));
            this._treeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._treeImageList.Images.SetKeyName(0, "");
            this._treeImageList.Images.SetKeyName(1, "");
            this._treeImageList.Images.SetKeyName(2, "");
            this._treeImageList.Images.SetKeyName(3, "");
            this._treeImageList.Images.SetKeyName(4, "");
            this._treeImageList.Images.SetKeyName(5, "");
            this._treeImageList.Images.SetKeyName(6, "");
            // 
            // _firstPanel
            // 
            this._firstPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this._firstPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._firstPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._firstPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._firstPanel.Location = new System.Drawing.Point(0, 26);
            this._firstPanel.Name = "_firstPanel";
            this._firstPanel.Size = new System.Drawing.Size(744, 327);
            this._firstPanel.TabIndex = 2;
            // 
            // AppForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(744, 373);
            this.Controls.Add(this._firstPanel);
            this.Controls.Add(this._statusBar);
            this.Controls.Add(this._mainToolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this._mainMenu;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AppForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this._statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._statusBarPanel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		[STAThread]
		static void Main(string [] args) 
		{
			if(args.Length==0)
			{
				Application.Run(new AppForm());
			}
			else if(args.Length==1)
			{
                Application.Run(new AppForm(args[0]));
			}			
		}

		public static AppForm getAppForm()
		{
			return APP_FORM;
		}		

		private void _fileMenuItem_Popup(object sender, System.EventArgs e)
		{
			if(!IS_DOC_OPEN)
			{				
				_saveDocMenuItem.Enabled=false;
				_saveAsDocMenuItem.Enabled=false;
				_closeDocMenuItem.Enabled=false;
				_printTimetableMenuItem.Enabled=false;
				
			}
			else
			{
				_saveDocMenuItem.Enabled=true;
				_saveAsDocMenuItem.Enabled=true;
				_closeDocMenuItem.Enabled=true;
				_printTimetableMenuItem.Enabled=true;
			}
		}

		private void _newDocMenuItem_Click(object sender, System.EventArgs e)
		{
			doNewDocument();			
		}

		private void doNewDocument()
		{
			if(doCloseDoc())
			{

				DocumentPropertiesForm syf=new DocumentPropertiesForm(true);
				syf.ShowDialog(this);

				if (syf.DialogResult == DialogResult.OK)
				{
										
					CURR_OCTT_DOC= new OCTTDocument();
					CURR_OCTT_DOC.DocumentType= syf.getDocumentType();
					CURR_OCTT_DOC.DocumentVersion=APPLICATION_VERSION;
					CURR_OCTT_DOC.EduInstitutionName=syf.getEduInstitutionNameInput();
					CURR_OCTT_DOC.SchoolYear=syf.getSchoolYear();					
					
					doNewDocAction();				
			
					syf.Dispose();
				}
			}

		}
		
		public void doNewDocAction()
		{
			IS_DOC_OPEN=true;			
			_docMenuItem.Enabled=true;			
			
			AppForm.CURR_OCTT_DOC.FileName="Untitled";
			AppForm.CURR_OCTT_DOC.FullPath=null;
			this.Text=AppForm.CURR_OCTT_DOC.FileName+" - "+APPLICATION_NAME;

			AppForm.CURR_OCTT_DOC.refreshTreeRootText();			

			AppForm.CURR_OCTT_DOC.RTVSelectedNode=null;
			AppForm.CURR_OCTT_DOC.TTVSelectedNode=null;
			
			setResourceManager();


			createGUIForNewDoc();

			updateFormRelatedStrings();
			updateOpenDocumentRelatedStrings();

			_cmdProcessor.emptyAllStacks();
			enableDisableTBButton();

			//_undoToolBarButton.Enabled=false;
			//_redoToolBarButton.Enabled=false;	
			_undoToolBarButton.ImageIndex=11;
			_redoToolBarButton.ImageIndex=12;
			
			updateEnableDisableStateForPluginMenuItems();

		}

		private void createGUIForNewDoc()
		{	

			_treeTabControl = new System.Windows.Forms.TabControl();
			_treeTabControl.Dock = System.Windows.Forms.DockStyle.Left;
			_treeTabControl.Location = new System.Drawing.Point(0, 41);
			_treeTabControl.Name = "_treeTabControl";
			_treeTabControl.SelectedIndex = 0;
			_treeTabControl.Size = new System.Drawing.Size(300, 512);
			_treeTabControl.SelectedIndexChanged += new System.EventHandler(this.treeTabControl_SelectedIndexChanged);

			_splitterVer = new System.Windows.Forms.Splitter();
			_splitterVer.Location = new System.Drawing.Point(200, 41);
			_splitterVer.Dock=System.Windows.Forms.DockStyle.Left;
			_splitterVer.Name = "_splitterVer";
			_splitterVer.Size = new System.Drawing.Size(8, 512);			
			_splitterVer.TabStop = false;
			
			_coursesTab = new System.Windows.Forms.TabPage();
			_coursesTreeView = new System.Windows.Forms.TreeView();
			_coursesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.coursesTreeView_AfterSelect);
			_teachersTab = new System.Windows.Forms.TabPage();
			_teachersTreeView = new System.Windows.Forms.TreeView();
			_teachersTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.teachersTreeView_AfterSelect);
			_roomsTab = new System.Windows.Forms.TabPage();
			_roomsTreeView = new System.Windows.Forms.TreeView();
			_roomsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.roomsTreeView_AfterSelect);

			_roomsTreeView.DoubleClick+=new EventHandler(tv_DoubleClick);

			
			_treeTabControl.Controls.Add(_coursesTab);
			_treeTabControl.Controls.Add(_teachersTab);
			_treeTabControl.Controls.Add(_roomsTab);
			 
			_coursesTab.AutoScroll = true;
			_coursesTab.Location = new System.Drawing.Point(4, 25);
			_coursesTab.Name = "_coursesTab";
			_coursesTab.Size = new System.Drawing.Size(192, 483);
			_coursesTab.TabIndex = 0;		
			
			_coursesTab.Controls.Add(_coursesTreeView);

			_coursesTreeView.ContextMenu = this._coursesTreeContextMenu;
			_coursesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			_coursesTreeView.HideSelection = false;
			_coursesTreeView.ImageIndex = 0;
			_coursesTreeView.SelectedImageIndex = 0;
			_coursesTreeView.ImageList = this._treeImageList;
			_coursesTreeView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			_coursesTreeView.Name = "_coursesTreeView";
			_coursesTreeView.Size = new System.Drawing.Size(192, 483);
			_coursesTreeView.Sorted = true;
			_coursesTreeView.TabIndex = 0;	
			_coursesTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);

            _coursesTreeView.DoubleClick+=new EventHandler(tv_DoubleClick);
			
			
			_coursesTreeContextMenu.Popup += new System.EventHandler(this._coursesTreeContextMenu_Popup);

			// _teachersTab
			// 
			_teachersTab.AutoScroll = true;			
			_teachersTab.Location = new System.Drawing.Point(4, 25);
			_teachersTab.Name = "_teachersTab";
			_teachersTab.Size = new System.Drawing.Size(192, 483);
			_teachersTab.TabIndex = 1;
		
			_teachersTab.Controls.Add(_teachersTreeView); 
			// 
			// _teachersTreeView
			// 
			_teachersTreeView.ContextMenu = this._teachersTreeContextMenu;
			_teachersTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			_teachersTreeView.HideSelection = false;
			_teachersTreeView.ImageIndex = 0;
			_teachersTreeView.ImageList = this._treeImageList;
			_teachersTreeView.Name = "_teachersTreeView";
			_teachersTreeView.SelectedImageIndex = 0;
			_teachersTreeView.Size = new System.Drawing.Size(192, 483);
			_teachersTreeView.Sorted = true;
			_teachersTreeView.TabIndex = 0;
			_teachersTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);

			_teachersTreeView.DoubleClick+=new EventHandler(tv_DoubleClick);
			// 
			// _teachersTreeContextMenu
			// 
			_teachersTreeContextMenu.Popup += new System.EventHandler(this._teachersTreeContextMenu_Popup);			
			//
			// _roomsTab
			// 
			_roomsTab.AutoScroll = true;
			_roomsTab.Location = new System.Drawing.Point(4, 25);
			_roomsTab.Name = "_roomsTab";
			_roomsTab.Size = new System.Drawing.Size(192, 483);
			_roomsTab.TabIndex = 2;		
			_roomsTab.Controls.Add(_roomsTreeView);
			// 
			// _roomsTreeView
			// 
			_roomsTreeView.ContextMenu = this._roomsTreeContextMenu;
			_roomsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			_roomsTreeView.HideSelection = false;
			_roomsTreeView.ImageIndex = 0;
			_roomsTreeView.ImageList = this._treeImageList;
			_roomsTreeView.Name = "_roomsTreeView";
			_roomsTreeView.SelectedImageIndex = 0;
			_roomsTreeView.Size = new System.Drawing.Size(192, 483);
			_roomsTreeView.Sorted = true;
			_roomsTreeView.TabIndex = 0;
			_roomsTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
			// 
			// _roomsTreeContextMenu
			// 
			_roomsTreeContextMenu.Popup += new System.EventHandler(this._roomsTreeContextMenu_Popup);
			//

			_emptyPanel= new Panel();
			_emptyPanel.BackColor= System.Drawing.SystemColors.Control;			
			_emptyPanel.BorderStyle= System.Windows.Forms.BorderStyle.None;
			_emptyPanel.Name="_emptyPanel";
			_emptyPanel.Dock = System.Windows.Forms.DockStyle.Fill;

			_firstPanel.Parent=null;

			this.Controls.Add(_emptyPanel);
			this.Controls.Add(_treeTabControl);
			this.Controls.Add(_splitterVer);				

			this.Controls.SetChildIndex(_splitterVer,0);
			this.Controls.SetChildIndex(_treeTabControl,1);
			this.Controls.SetChildIndex(_emptyPanel,2);

			//
			//			
			_timetableTabControl=new TabControl();
			_timetableTabControl.Dock=System.Windows.Forms.DockStyle.Fill;
			_timetableTabControl.Name="_timetableTabControl";
				
			_timetableTab = new TabPage();				
			_timetableTab.Name="_timetableTab";
			_timetableTabControl.Controls.Add(_timetableTab);

			_timetablePanel = new System.Windows.Forms.Panel();					
			_timetablePanel.BackColor= System.Drawing.SystemColors.Control;
			_timetablePanel.Dock=System.Windows.Forms.DockStyle.Fill;
			_timetablePanel.Name="_timetablePanel";				
			_timetableTab.Controls.Add(_timetablePanel);									

			_unallocatedLessonsListView= new System.Windows.Forms.ListView();
			_unallocatedLessonsListView.AllowDrop=true;
			_unallocatedLessonsListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ULLVCourseView_DragEnter);
			_unallocatedLessonsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ULLVCourseView_DragDrop);
			_unallocatedLessonsListView.DragLeave += new System.EventHandler(this.ULLVCoursesView_DragLeave);

			_unallocatedLessonsListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this._unallocatedLessonsForCourseViewListView_ItemDrag);			
			
			_columnHeaderULLVCourses1=new System.Windows.Forms.ColumnHeader();
			_columnHeaderULLVCourses2=new System.Windows.Forms.ColumnHeader();
				
			// _unallocatedLessonsListView
			// 
			_unallocatedLessonsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									 _columnHeaderULLVCourses1,
																									 _columnHeaderULLVCourses2});
			_unallocatedLessonsListView.Dock = System.Windows.Forms.DockStyle.Bottom;
			_unallocatedLessonsListView.FullRowSelect = true;
			_unallocatedLessonsListView.GridLines = true;
			_unallocatedLessonsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			_unallocatedLessonsListView.LabelWrap = false;			
			_unallocatedLessonsListView.MultiSelect = false;
			_unallocatedLessonsListView.Name = "_unallocatedLessonsListView";
			_unallocatedLessonsListView.Size = new System.Drawing.Size(520, 116);
			_unallocatedLessonsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;			
			_unallocatedLessonsListView.View = System.Windows.Forms.View.Details;
			// 
			// _columnHeaderULLVCourses1
			// 
			
			_columnHeaderULLVCourses1.Width = 450;
			// 
			// _columnHeaderULLVCourses2
			// 
			
			_columnHeaderULLVCourses2.Width = 260;	
	
			/////////////////////////////////////
			///
			_unallocatedLessonsTeacherListView= new System.Windows.Forms.ListView();
			_unallocatedLessonsTeacherListView.AllowDrop=true;
			_unallocatedLessonsTeacherListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ULLVTeachersView_DragEnter);
			_unallocatedLessonsTeacherListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ULLVTeachersView_DragDrop);				
			_unallocatedLessonsTeacherListView.DragLeave += new System.EventHandler(this.ULLVTeachersView_DragLeave);

			_unallocatedLessonsTeacherListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this._unallocatedLessonsForTeachersViewListView_ItemDrag);				

			_columnHeaderULLVTeachers1=new System.Windows.Forms.ColumnHeader();
			_columnHeaderULLVTeachers2=new System.Windows.Forms.ColumnHeader();
			_columnHeaderULLVTeachers3=new System.Windows.Forms.ColumnHeader();
								
			_unallocatedLessonsTeacherListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																											  _columnHeaderULLVTeachers1,
																											  _columnHeaderULLVTeachers2,
																											  _columnHeaderULLVTeachers3});
			_unallocatedLessonsTeacherListView.Dock = System.Windows.Forms.DockStyle.Bottom;
			_unallocatedLessonsTeacherListView.FullRowSelect = true;
			_unallocatedLessonsTeacherListView.GridLines = true;
			_unallocatedLessonsTeacherListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			_unallocatedLessonsTeacherListView.LabelWrap = false;				
			_unallocatedLessonsTeacherListView.MultiSelect = false;
			_unallocatedLessonsTeacherListView.Name = "_unallocatedLessonsTeacherListView";
			_unallocatedLessonsTeacherListView.Size = new System.Drawing.Size(520, 116);
			_unallocatedLessonsTeacherListView.Sorting = System.Windows.Forms.SortOrder.Ascending;				
			_unallocatedLessonsTeacherListView.View = System.Windows.Forms.View.Details;
				
			
			_columnHeaderULLVTeachers1.Width = 400;
				
			
			_columnHeaderULLVTeachers2.Width = 240;

			
			_columnHeaderULLVTeachers3.Width = 70;

			// 
			// _splitterHor
			// 
			_splitterHor= new System.Windows.Forms.Splitter();
			_splitterHor.Dock = System.Windows.Forms.DockStyle.Bottom;
			_splitterHor.Name = "_splitterHor";
			_splitterHor.Size = new System.Drawing.Size(520, 3);
			_splitterHor.TabStop = false;


			_mainTimetablePanel= new ScrollablePanel();
            //_mainTimetablePanel = new Panel();
			_termsPanel= new Panel();
			_daysPanel= new Panel();

			// _mainTimetablePanel
			// 
			_mainTimetablePanel.AutoScroll = true;
			_mainTimetablePanel.Dock = System.Windows.Forms.DockStyle.Fill;			
			_mainTimetablePanel.Name = "_mainTimetablePanel";
			_mainTimetablePanel.Size = new System.Drawing.Size(458, 338);			
			_mainTimetablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this._mainTimetablePanel_Paint);
			_mainTimetablePanel.ScrollHorizontal+= new System.Windows.Forms.ScrollEventHandler(this._mainTimetablePanel_Scroll);
			_mainTimetablePanel.ScrollVertical+= new System.Windows.Forms.ScrollEventHandler(this._mainTimetablePanel_Scroll);
								
			// 
			// _termsPanel
			// 
			_termsPanel.Dock = System.Windows.Forms.DockStyle.Left;			
			_termsPanel.Name = "_termsPanel";
			_termsPanel.Size = new System.Drawing.Size(60+Constants.DAY_HOUR_LABEL_OFFSET, 338);
			
			// 
			// _daysPanel
			// 
			_daysPanel.Dock = System.Windows.Forms.DockStyle.Top;
			_daysPanel.Name = "_daysPanel";
			_daysPanel.Size = new System.Drawing.Size(520, 25);
			
			_timetablePanel.Controls.Add(_mainTimetablePanel);
			_timetablePanel.Controls.Add(_termsPanel);
			_timetablePanel.Controls.Add(_daysPanel);
			

			this.Controls.Add(_timetableTabControl);
			this.Controls.Add(_splitterHor);
			this.Controls.Add(_unallocatedLessonsListView);
			this.Controls.Add(_unallocatedLessonsTeacherListView);					

			this.Controls.SetChildIndex(_timetableTabControl,0);
			this.Controls.SetChildIndex(_splitterHor,1);
			this.Controls.SetChildIndex(_unallocatedLessonsListView,2);
			this.Controls.SetChildIndex(_unallocatedLessonsTeacherListView,3);
				
			_unallocatedLessonsListView.Visible=false;
			_unallocatedLessonsTeacherListView.Visible=false;
			_splitterHor.Visible=false;
			_timetableTabControl.Visible=false;
			

			
			_coursesTreeView.Nodes.Add(AppForm.CURR_OCTT_DOC.CoursesRootNode);
			_teachersTreeView.Nodes.Add(AppForm.CURR_OCTT_DOC.TeachersRootNode);
			_roomsTreeView.Nodes.Add(AppForm.CURR_OCTT_DOC.RoomsRootNode);

			drawDaysAndTermsLabels();
			drawEmptyTimeSlotPanels();
			_statusBarPanel2.Text= AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
			this.ResumeLayout();
		}		

		private void _mainTimetablePanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			refreshDaysAndTermsPanelsPosOnAutoScroll();
		}

		private void _mainTimetablePanel_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			refreshDaysAndTermsPanelsPosOnAutoScroll();
		}


		public void refreshDaysAndTermsPanelsPosOnAutoScroll()
		{
			int k=0;			
			
			foreach(Label lb in _daysPanel.Controls) 
			{
				if(k>0) lb.Location= new Point(Constants.DAY_HOUR_PANEL_WIDTH+Constants.DAY_HOUR_LABEL_OFFSET+(k-1)*Settings.TIME_SLOT_PANEL_WIDTH+_mainTimetablePanel.AutoScrollPosition.X,Constants.DAY_HOUR_PANEL_OFFSET_Y);				
				k++;
			}

			k=0;			
			foreach(TermLabel tl in _termsPanel.Controls) 
			{
				tl.Location= new Point(Constants.DAY_HOUR_LABEL_OFFSET,k*Settings.TIME_SLOT_PANEL_HEIGHT+_mainTimetablePanel.AutoScrollPosition.Y);
				k++;
			}

		}


		private void drawDaysAndTermsLabels() 
		{
			DayHourCornerLabel dhcl= new DayHourCornerLabel();
			this._daysPanel.Controls.Add(dhcl);
			

			int startX=Constants.DAY_HOUR_PANEL_WIDTH+Constants.DAY_HOUR_LABEL_OFFSET;
			int startY=Constants.DAY_HOUR_PANEL_OFFSET_Y;
			int stepX = Settings.TIME_SLOT_PANEL_WIDTH;
			
			int goAhead=0;
			for(int k=0;k<7;k++)
			{
				if(AppForm.CURR_OCTT_DOC.IncludedDays[k]==true)
				{	
					DayLabel dlb=new DayLabel(startX+goAhead*stepX,startY,DAY_TEXT[k],k);
					this._daysPanel.Controls.Add(dlb);
					goAhead++;
				}
			}

			startX=Constants.DAY_HOUR_LABEL_OFFSET;
			startY=0;			
			int stepY = Settings.TIME_SLOT_PANEL_HEIGHT;
			
			int n=0;			
			foreach(int[] term in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				string [] printTerm=new string[4];
				for(int k=0;k<4;k++)
				{
					if(term[k]<10)
					{
                        printTerm[k]="0"+System.Convert.ToString(term[k]);
					}
					else
					{
						printTerm[k]=System.Convert.ToString(term[k]);
					}
				}

				string labelText=printTerm[0]+":"+printTerm[1]+"-"+printTerm[2]+":"+printTerm[3];				
				TermLabel tl=new TermLabel(startX,startY+n*stepY,labelText,n);
				this._termsPanel.Controls.Add(tl);
				n++;
			}
			
		}	

		private void _coursesTreeContextMenu_Popup(object sender, System.EventArgs e)
		{			
			TreeNode selectedNode = _coursesTreeView.SelectedNode;
			_coursesTreeContextMenu.MenuItems.Clear();
			
			if(selectedNode.GetType().FullName=="System.Windows.Forms.TreeNode") 			
			{ 
				
				MenuItem menuItem1 = new MenuItem(RES_MANAGER.GetString("_docPropertiesMenuItem.Text"));
				menuItem1.Click += new System.EventHandler(this.docPropertiesMenuItem_Click);				
				
				MenuItem menuItem2 = new MenuItem(RES_MANAGER.GetString("_addEPGMenuItem.Text"));
				menuItem2.Click += new System.EventHandler(this.addEPG_Click);
				_coursesTreeContextMenu.MenuItems.Add(menuItem2);
				_coursesTreeContextMenu.MenuItems.Add(new MenuItem("-"));
				_coursesTreeContextMenu.MenuItems.Add(menuItem1);

                _coursesTreeContextMenu.MenuItems.Add(new MenuItem("-"));
                MenuItem menuItem3 = new MenuItem(RES_MANAGER.GetString("_autoTTMenuItem.Text"));

                MenuItem menuItem4 = new MenuItem(RES_MANAGER.GetString("_scBaseEPMenuItem.Text"));
                menuItem4.Click += new System.EventHandler(this.softConsBaseEPMenuItem_Click);

                MenuItem menuItem5 = new MenuItem(RES_MANAGER.GetString("_scBaseCoursesMenuItem.Text"));
                menuItem5.Click += new System.EventHandler(this.softConsBaseCoursesMenuItem_Click);

                menuItem3.MenuItems.AddRange(new MenuItem[] {menuItem4, menuItem5 });
                _coursesTreeContextMenu.MenuItems.Add(menuItem3);
                //_coursesTreeContextMenu.MenuItems.Add(menuItem4);

				
			} 
			else if(selectedNode.GetType().FullName=="OpenCTT.EduProgramGroup") 
			{
				foreach(MenuItem mi in _epgMenuItem.MenuItems)
				{
                    _coursesTreeContextMenu.MenuItems.Add(mi.CloneMenu());
				}
			} 
			else if(selectedNode.GetType().FullName=="OpenCTT.EduProgram") 
			{
				checkWhatIsEnabledForEP();

				foreach(MenuItem mi in _epMenuItem.MenuItems)
				{					
					_coursesTreeContextMenu.MenuItems.Add(mi.CloneMenu());
				}

			}
			else if(selectedNode.GetType().FullName=="OpenCTT.Course") 
			{
				checkWhatIsEnabledForCourse();

				foreach(MenuItem mi in _courseMenuItem.MenuItems)
				{					
					_coursesTreeContextMenu.MenuItems.Add(mi.CloneMenu());
				}
			}
			
		}
		

		private void addEPG_Click(object sender, System.EventArgs e)
		{	
			EPGPropertiesForm epgpf=new EPGPropertiesForm();
			epgpf.ShowDialog(this);

			if (epgpf.DialogResult == DialogResult.OK)
			{
				string name=epgpf.EPGNameTextBox.Text.Trim();
				string extID=epgpf.EPGExtIDTextBox.Text.Trim();

				AddEduProgramGroupCmd asCmd= new AddEduProgramGroupCmd(name, extID);
				_cmdProcessor.doCmd(asCmd);

				epgpf.Dispose();
			}		
		
		}

		

		private void renameEPG_Click(object sender, System.EventArgs e)
		{

			EduProgramGroup epg=(EduProgramGroup)_coursesTreeView.SelectedNode;

			EPGPropertiesForm epgpf=new EPGPropertiesForm(epg);
			epgpf.ShowDialog(this);

			if (epgpf.DialogResult == DialogResult.OK)
			{				
				string newName=epgpf.EPGNameTextBox.Text.Trim();
				string newExtID=epgpf.EPGExtIDTextBox.Text.Trim();

				if(epg.getName()!=newName || epg.ExtID!=newExtID)
				{
					ChangeEduProgramGroupDataCmd rsCmd= new ChangeEduProgramGroupDataCmd(epg,newName,newExtID);
					_cmdProcessor.doCmd(rsCmd);
				}

				epgpf.Dispose();
			}
			
		}


		private void allowedTimeSlotsEPG_Click(object sender, System.EventArgs e)
		{			
			EduProgramGroup epg=(EduProgramGroup)_coursesTreeView.SelectedNode;
			bool[,] allowedTimeSlots=epg.getAllowedTimeSlots();
			AllowedTimeSlotsForm cf=new AllowedTimeSlotsForm(allowedTimeSlots, Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP, epg);
			cf.ShowDialog(this);

			if (cf.DialogResult == DialogResult.OK)
			{
				ChangeAllowedTimeSlotsCmd cptsCmd=new ChangeAllowedTimeSlotsCmd(epg,Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP,cf);
				_cmdProcessor.doCmd(cptsCmd);
								
				cf.Dispose();
			}

		}


		private void addEduProgram_Click(object sender, System.EventArgs e)
		{
			EduProgramGroup epg=(EduProgramGroup)_coursesTreeView.SelectedNode;
			EduProgramPropertiesForm popf=new EduProgramPropertiesForm();
			popf.ShowDialog(this);

			if (popf.DialogResult == DialogResult.OK)
			{
				string name=popf.NameTextBox.Text.Trim();
				string semester = popf.SemesterTextBox.Text.Trim();
				string code=popf.CodeTextBox.Text.Trim();
				string extID=popf.ExtIDTextBox.Text.Trim();

                AddEduProgramCmd aopCmd= new AddEduProgramCmd(epg,name,semester,code,extID);
				_cmdProcessor.doCmd(aopCmd);
				
				popf.Dispose();				
			}

		}
		
		

		private void deleteEPG_Click(object sender, System.EventArgs e)
		{
			EduProgramGroup epg = (EduProgramGroup)_coursesTreeView.SelectedNode;
		
			string message = RES_MANAGER.GetString("deleteEPG_Click.msb.message");
			string caption = RES_MANAGER.GetString("deleteEPG_Click.msb.caption");
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				bool del=true;
				int numOfUnallocatedLessStep=0;

				ArrayList unallocatedLessonsiRelHTList= new ArrayList();

				foreach(EduProgram ep in epg.Nodes)
				{
					if(!ep.getIsTimetableEmpty())
					{
						del=false;
						break;
					}

					foreach(Course course in ep.Nodes)
					{
						if(course.getCoursesToHoldTogetherList().Count==0)
						{
							numOfUnallocatedLessStep+=course.getNumberOfLessonsPerWeek();
						}
						else
						{
							bool isForAdding=true;
							foreach(Course deepCourse in course.getCoursesToHoldTogetherList())
							{
								EduProgram deepEP=(EduProgram)deepCourse.Parent;
								EduProgramGroup deepEPG = (EduProgramGroup)deepEP.Parent;								

								if(deepEPG!=epg)
								{
									isForAdding=false;
									break;

								}else if(unallocatedLessonsiRelHTList.Contains(deepCourse))
								{
									isForAdding=false;
									break;                                    
								}

							}

							if(isForAdding) unallocatedLessonsiRelHTList.Add(course);

						}

					}				

					
				}

				if(del)
				{
					foreach(Course p in unallocatedLessonsiRelHTList)
					{
						numOfUnallocatedLessStep+=p.getNumberOfLessonsPerWeek();
					}


					DeleteEduProgramGroupCmd dsCmd=new DeleteEduProgramGroupCmd(epg,numOfUnallocatedLessStep);
					_cmdProcessor.doCmd(dsCmd);					
				}
				else
				{					

					string message2 = RES_MANAGER.GetString("deleteEPG_Click.msb.notdel.message");
					string caption2 = RES_MANAGER.GetString("deleteEPG_Click.msb.notdel.caption");
								
					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
			}
		}

		private void propertiesEduProgram_Click(object sender, System.EventArgs e)
		{
			EduProgram ep=(EduProgram)_coursesTreeView.SelectedNode;
			showEPProperties(ep);			
		}

		private void showEPProperties(EduProgram ep)
		{
			EduProgramPropertiesForm popf=new EduProgramPropertiesForm(ep);
			popf.ShowDialog(this);

			if (popf.DialogResult == DialogResult.OK)
			{
				if(ep.getCode()!=popf.CodeTextBox.Text.Trim() || ep.getSemester()!=popf.SemesterTextBox.Text.Trim() || ep.getName()!=popf.NameTextBox.Text.Trim() || ep.ExtID!=popf.ExtIDTextBox.Text.Trim())
				{
					string newCode=popf.CodeTextBox.Text.Trim();
					string newSemester=popf.SemesterTextBox.Text.Trim();
					string newName=popf.NameTextBox.Text.Trim();
					string newExtID=popf.ExtIDTextBox.Text.Trim();

					ChangeEduProgramDataCmd copdCmd= new ChangeEduProgramDataCmd(ep,newName,newCode,newSemester,newExtID);
					_cmdProcessor.doCmd(copdCmd);
				}
				
				popf.Dispose();
			}

		}

		private void addCourse_Click(object sender, System.EventArgs e)
		{
			CoursePropertiesForm ppf=new CoursePropertiesForm();
			ppf.ShowDialog(this);

			if (ppf.DialogResult == DialogResult.OK)
			{				
					
				string groupName;
				if(ppf.IsGroupCheckBox.Checked) 
				{
					groupName=ppf.GroupNameTextBox.Text.Trim();
				} 
				else 
				{
					groupName=null;
				}

				string name=ppf.NameTextBox.Text.Trim();
				string shortName=ppf.ShortNameTextBox.Text.Trim();
				int numOfLessPerWeek=System.Convert.ToInt32(ppf.NumOfLessonsPerWeekTextBox.Text.Trim());
				int numOfEnroledStudents = System.Convert.ToInt32(ppf.NumOfEnrolledStudentsTextBox.Text.Trim());
				bool isGroup=ppf.IsGroupCheckBox.Checked;

				string extID=ppf.ExtIDTextBox.Text.Trim();
				string courseType=(string)ppf.CourseTypeComboBox.SelectedItem;				
				if(courseType==null)courseType=ppf.CourseTypeComboBox.Text.Trim();

				Teacher myTeacher = (Teacher)ppf.TeacherComboBox.SelectedItem;
				
				EduProgram ep=(EduProgram)_coursesTreeView.SelectedNode;

				AddCourseCmd apCmd=new AddCourseCmd(ep,name,shortName, myTeacher,numOfLessPerWeek,numOfEnroledStudents,isGroup,groupName,extID,courseType);
				_cmdProcessor.doCmd(apCmd);

				ppf.Dispose();				
				
			}
		}
		

		private void addCourseDataToClipboard_Click(object sender, System.EventArgs e)
		{			
			Course course = (Course)_coursesTreeView.SelectedNode;
			Hashtable ht=new Hashtable();
			ht.Add("cname",course.getName());
			ht.Add("cshortname",course.getShortName());
			ht.Add("cnumofenrstud",course.getNumberOfEnrolledStudents());
			ht.Add("cnumoflessperweek",course.getNumberOfLessonsPerWeek());
			ht.Add("cisgroup",course.getIsGroup());
			ht.Add("cgroupname",course.getGroupName());
			
			ht.Add("ccoursetype",course.CourseType);
			ht.Add("cextid",course.ExtID);			

			ht.Add("teachername",course.getTeacher().getName());
			ht.Add("teacherlastname",course.getTeacher().getLastName());
			ht.Add("teachertitle",course.getTeacher().getTitle());
			ht.Add("teacheredurank",course.getTeacher().getEduRank());
            			
			DataObject myDataObject=new DataObject();
			myDataObject.SetData(DataFormats.Serializable,ht);
			Clipboard.SetDataObject(myDataObject);			
		}

		private void addCourseFromClipboard_Click(object sender, System.EventArgs e)
		{
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Serializable))
			{				
				Hashtable cht=(Hashtable)Clipboard.GetDataObject().GetData(DataFormats.Serializable);
				if(cht!=null)
				{
					string cName=(string)cht["cname"];
					string cShortName=(string)cht["cshortname"];
					string tName=(string)cht["teachername"];
					string tLastname=(string)cht["teacherlastname"];
					string tTitle=(string)cht["teachertitle"];
					string tEduRank=(string)cht["teacheredurank"];
					int cNumOfEnrStud=(int)cht["cnumofenrstud"];
					int cNumOfLessPerWeek=(int)cht["cnumoflessperweek"];
					bool cIsGroup=(bool)cht["cisgroup"];
					string cGroupName=(string)cht["cgroupname"];
					
					string cCourseType=(string)cht["ccoursetype"];
					string cExtID=(string)cht["cextid"];
					

					EduProgram ep = (EduProgram)_coursesTreeView.SelectedNode;

					Teacher myTeacher=Teacher.getTeacherByData(tName,tLastname,tTitle,tEduRank);
				
					if(Course.getIsCourseDataOK(null,cName,cShortName,cCourseType, cGroupName, cIsGroup))
					{
						if(myTeacher!=null)
						{							
							AddCourseCmd apCmd=new AddCourseCmd(ep,cName,cShortName,myTeacher,cNumOfLessPerWeek,cNumOfEnrStud,cIsGroup,cGroupName,cExtID,cCourseType);
							_cmdProcessor.doCmd(apCmd);
						}
						else
						{
							string message1 = RES_MANAGER.GetString("addCourseFromClipboard_Click.msb.notadded.reason.teacher.message");
							string caption1 = RES_MANAGER.GetString("addCourseFromClipboard_Click.msb.notadded.reason.teacher.caption");
							
							MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
	
							MessageBox.Show(this, message1, caption1, buttons1,
								MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

						}
					}
					else
					{
						string message2 = RES_MANAGER.GetString("addCourseFromClipboard_Click.msb.notadded.reason.name.message");
						
						string caption2 = RES_MANAGER.GetString("addCourseFromClipboard_Click.msb.notadded.reason.name.caption");
						
						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
	
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
				}
				
			}
		}

		private void allowedTimeSlotsEduProgram_Click(object sender, System.EventArgs e)
		{			
			EduProgram ep=(EduProgram)_coursesTreeView.SelectedNode;
			AllowedTimeSlotsForm cf=new AllowedTimeSlotsForm(ep.getAllowedTimeSlots(), Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM,ep);
			cf.ShowDialog(this);

			if (cf.DialogResult == DialogResult.OK)
			{
				ChangeAllowedTimeSlotsCmd cptsCmd=new ChangeAllowedTimeSlotsCmd(ep,Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM,cf);
				_cmdProcessor.doCmd(cptsCmd);

				cf.Dispose();
			}

		}

		private void deleteAllCourses_Click(object sender, System.EventArgs e)
		{
			string message = RES_MANAGER.GetString("deleteAllCourses_Click.msb.confirm.message");
			
			string caption = RES_MANAGER.GetString("deleteAllCourses_Click.msb.confirm.caption");
			
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				EduProgram ep=(EduProgram)_coursesTreeView.SelectedNode;

				ArrayList tempList = new ArrayList();

				foreach(Course courseForDel in ep.Nodes) 
				{
					if(!ep.getIsCourseInTimetable(courseForDel)) tempList.Add(courseForDel);
				}

				bool isAll=false;
				if(ep.Nodes.Count==tempList.Count) isAll=true;

				DeleteMoreThanOneCourseCmd dmtopCmd=new DeleteMoreThanOneCourseCmd(ep,tempList);
				_cmdProcessor.doCmd(dmtopCmd);

				if(!isAll)
				{
					string message2 = RES_MANAGER.GetString("deleteAllCourses_Click.msb.notalldeleted.message");
					
					string caption2 = RES_MANAGER.GetString("deleteAllCourses_Click.msb.notalldeleted.caption");
					
					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				}				
				
                _statusBarPanel2.Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

			}
		}

		private void deleteEduProgram_Click(object sender, System.EventArgs e)
		{
			string message = RES_MANAGER.GetString("deleteEduProgram_Click.msb.confirm.message");
			
			string caption = RES_MANAGER.GetString("deleteEduProgram_Click.msb.confirm.caption");
			
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				EduProgram ep = (EduProgram)_coursesTreeView.SelectedNode;
				EduProgramGroup epg = (EduProgramGroup)ep.Parent;				
				
				if(ep.getIsTimetableEmpty())
				{
					DeleteEduProgramCmd dopCmd= new DeleteEduProgramCmd(ep);
					_cmdProcessor.doCmd(dopCmd);
				}
				else
				{
					string message2 = RES_MANAGER.GetString("deleteEduProgram_Click.msb.notdeleted.message");
					
					string caption2 = RES_MANAGER.GetString("deleteEduProgram_Click.msb.notdeleted.caption");
					
					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
			}
		}

		private void clearTimetable_Click(object sender, System.EventArgs e)
		{
			string message = RES_MANAGER.GetString("clearTimetable_Click.msb.confirm.message");
			
			string caption = RES_MANAGER.GetString("clearTimetable_Click.msb.confirm.caption");
			
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				EduProgram ep=(EduProgram)_coursesTreeView.SelectedNode;
				ClearTimetableCmd crCmd= new ClearTimetableCmd(ep);
                _cmdProcessor.doCmd(crCmd);
			}
		}

		private void deleteCourse_Click(object sender, System.EventArgs e)
		{
			string message = RES_MANAGER.GetString("deleteCourse_Click.msb.confirm.message");
			
			string caption = RES_MANAGER.GetString("deleteCourse_Click.msb.confirm.caption");
			
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				Course courseForDel = (Course)_coursesTreeView.SelectedNode;
				EduProgram ep = (EduProgram)courseForDel.Parent;

				if(!ep.getIsCourseInTimetable(courseForDel))
				{
					DeleteCourseCmd dpCmd=new DeleteCourseCmd(courseForDel);
					_cmdProcessor.doCmd(dpCmd);
				}
				else 
				{
					string message2 = RES_MANAGER.GetString("deleteCourse_Click.msb.notdeleted.message");
					string caption2 = RES_MANAGER.GetString("deleteCourse_Click.msb.notdeleted.caption");
										
					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
				}

			}
		}


		private void propertiesCourse_Click(object sender, System.EventArgs e)
		{
			Course course=(Course)_coursesTreeView.SelectedNode;
			showCourseProperties(course);
		}

		private void showCourseProperties(Course course)
		{
			EduProgram myEP=(EduProgram)course.Parent;
			bool isAllEnabled=!myEP.getIsCourseInTimetable(course);

			CoursePropertiesForm ppf=new CoursePropertiesForm(course,isAllEnabled);
			ppf.ShowDialog(this);

			if (ppf.DialogResult == DialogResult.OK)
			{
				string newName=ppf.NameTextBox.Text.Trim();
				string newShortName=ppf.ShortNameTextBox.Text.Trim();
				string newGroupName=ppf.GroupNameTextBox.Text.Trim();
				int newNumOfEnrolledStudents=System.Convert.ToInt32(ppf.NumOfEnrolledStudentsTextBox.Text.Trim());
				int newNumOfLessPerWeek=System.Convert.ToInt32(ppf.NumOfLessonsPerWeekTextBox.Text.Trim());
				bool newIsGroup=ppf.IsGroupCheckBox.Checked;
				Teacher newTeacher = (Teacher)ppf.TeacherComboBox.SelectedItem;

				string newExtID=ppf.ExtIDTextBox.Text.Trim();
				string newCourseType = (string)ppf.CourseTypeComboBox.SelectedItem;
				if(newCourseType==null)newCourseType=ppf.CourseTypeComboBox.Text.Trim();

				if(course.getNumberOfLessonsPerWeek()!=newNumOfLessPerWeek
					|| course.getNumberOfEnrolledStudents()!=newNumOfEnrolledStudents
					|| course.getIsGroup()!=newIsGroup
					|| course.getGroupName()!=newGroupName
					|| course.getName()!=newName
					|| course.getShortName()!=newShortName
					|| course.getTeacher()!=newTeacher
					|| course.ExtID!=newExtID
					|| course.CourseType!=newCourseType)
				{

					ChangeCourseDataCmd cpdCmd= new ChangeCourseDataCmd(course,newName,newShortName,newGroupName,newNumOfLessPerWeek,newNumOfEnrolledStudents,newIsGroup,newTeacher,newExtID,newCourseType);
					_cmdProcessor.doCmd(cpdCmd);
				}

				ppf.Dispose();
			}

		}

		private void defCoursesToHoldTogether_Click(object sender, System.EventArgs e)
		{
			bool isFormDisabled=!this.checkIsHTPossible();

			Course course=(Course)_coursesTreeView.SelectedNode;
			CoursesToHoldTogetherForm atstf=new CoursesToHoldTogetherForm(course,isFormDisabled);
			
			atstf.ShowDialog(this);

			if (atstf.DialogResult == DialogResult.OK)
			{
				
				ArrayList newAL=(ArrayList)atstf.getTHTWorkingList().Clone();
				SetCoursesToHoldTogetherCmd dipCmd=new SetCoursesToHoldTogetherCmd(course,newAL);
				_cmdProcessor.doCmd(dipCmd);

				atstf.Dispose();
			
			}

		}

		private void roomRestrictionForCourse_Click(object sender, System.EventArgs e)
		{	
			Course course=(Course)_coursesTreeView.SelectedNode;
			
			string labelText=RES_MANAGER.GetString("roomRestrictionForCourse_Click.course.text")+" '"+course.getName();
			if(course.getIsGroup()) 
			{
				labelText+=" - "+RES_MANAGER.GetString("roomRestrictionForCourse_Click.group.text")+" "+course.getGroupName();
			}
			labelText+="'";
			RoomsRestrictionForm ouf=new RoomsRestrictionForm(course.getAllowedRoomsList(),labelText, course.getNumberOfEnrolledStudents());
			ouf.ShowDialog(this);

			if (ouf.DialogResult == DialogResult.OK)
			{
				ArrayList tempList = new ArrayList();
				foreach(Room room in ouf.getChoosedRoomsListBox().Items)
				{
					tempList.Add(room);
				}

				if(tempList.Count==0) tempList=null;

				SetAllowedRoomsCmd puCmd = new SetAllowedRoomsCmd(course,null,tempList);
				_cmdProcessor.doCmd(puCmd);				
								
				ouf.Dispose();
			}

		}


		private void _teachersTreeContextMenu_Popup(object sender, System.EventArgs e)
		{
			_teachersTreeContextMenu.MenuItems.Clear();			
			
			if(_teachersTreeView.SelectedNode.GetType().FullName=="System.Windows.Forms.TreeNode") 			
			{	
				MenuItem menuItem1 = new MenuItem(RES_MANAGER.GetString("_addTeacherMenuItem.Text"));
				menuItem1.Click += new System.EventHandler(this.addTeacher_Click);
				_teachersTreeContextMenu.MenuItems.Add(menuItem1);

				

				if(AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Count>0) 
				{
					_teachersTreeContextMenu.MenuItems.Add(new MenuItem("-"));

					MenuItem menuItem2 = new MenuItem(RES_MANAGER.GetString("_delAllTeachersMenuItem.Text"));
					menuItem2.Click += new System.EventHandler(this.deleteAllTeachers_Click);					
					_teachersTreeContextMenu.MenuItems.Add(menuItem2);
					_teachersTreeContextMenu.MenuItems.Add(new MenuItem("-"));
			
					MenuItem menuItem3 = new MenuItem(RES_MANAGER.GetString("_printTimetableAllTeachersMenuItem.Text"));
					menuItem3.Click += new System.EventHandler(this.printTimetableForAllTeachers_Click);
					_teachersTreeContextMenu.MenuItems.Add(menuItem3);

                    MenuItem menuItem4 = new MenuItem(RES_MANAGER.GetString("_printTeacherListMenuItem.Text"));
                    menuItem4.Click += new System.EventHandler(this.printTeacherList_Click);
                    _teachersTreeContextMenu.MenuItems.Add(menuItem4);

                    MenuItem menuItem5 = new MenuItem(RES_MANAGER.GetString("_printTeacherHoursMenuItem.Text"));
                    menuItem5.Click += new System.EventHandler(this.printTeacherHours_Click);
                    _teachersTreeContextMenu.MenuItems.Add(menuItem5);
				}

                _teachersTreeContextMenu.MenuItems.Add(new MenuItem("-"));

                MenuItem menuItem6 = new MenuItem(RES_MANAGER.GetString("_autoTTMenuItem.Text"));

                MenuItem menuItem7 = new MenuItem(RES_MANAGER.GetString("_scBaseTeachersMenuItem.Text"));
                menuItem7.Click += new System.EventHandler(this.softConsBaseTeachersMenuItem_Click);

                menuItem6.MenuItems.AddRange(new MenuItem[] {menuItem7 });

                _teachersTreeContextMenu.MenuItems.Add(menuItem6);
                //_teachersTreeContextMenu.MenuItems.Add(menuItem7);



				
				
			} 
			else if(_teachersTreeView.SelectedNode.GetType().FullName=="OpenCTT.Teacher") 
			{
				foreach(MenuItem mi in _teacherMenuItem.MenuItems)
				{					
					_teachersTreeContextMenu.MenuItems.Add(mi.CloneMenu());
				}
			}
		
		}

		private void addTeacher_Click(object sender, System.EventArgs e)
		{			
			TeacherPropertiesForm pnf=new TeacherPropertiesForm();
			pnf.ShowDialog(this);

			if (pnf.DialogResult == DialogResult.OK)
			{
				string name = pnf.NameTextBox.Text.Trim();
				string lastName = pnf.LastnameTextBox.Text.Trim();				
				string title = (string)pnf.TitleComboBox.SelectedItem;
				if(title==null)title=pnf.TitleComboBox.Text.Trim();				
				string eduRank = (string)pnf.EduRankComboBox.SelectedItem;
				if(eduRank==null)eduRank=pnf.EduRankComboBox.Text.Trim();
				string extID=pnf.ExtIDTextBox.Text.Trim();

				AddTeacherCmd anCmd=new AddTeacherCmd(name, lastName,title,eduRank,extID);
				_cmdProcessor.doCmd(anCmd);			
				
				pnf.Dispose();
			}		

		}

		

		private void deleteAllTeachers_Click(object sender, System.EventArgs e) 
		{
            string message = RES_MANAGER.GetString("deleteAllTeachers_Click.msb.confirm.message");
			
            string caption = RES_MANAGER.GetString("deleteAllTeachers_Click.msb.confirm.caption");			
			
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
	
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				bool delAll=true;
				ArrayList tempList=new ArrayList();
				foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
				{
					if(!teacher.getIsUsedAsTeacherForAnyCourse())
					{
						tempList.Add(teacher);						
					}
					else
					{
						delAll=false;
					}
				}

				if(tempList.Count>0)
				{
					DeleteMoreThanOneTeacherCmd dmtonCmd=new DeleteMoreThanOneTeacherCmd(tempList);
					_cmdProcessor.doCmd(dmtonCmd);
				}

				if(!delAll)
				{
					string message2 = RES_MANAGER.GetString("deleteAllTeachers_Click.msb.notalldeleted.message");
					string caption2 = RES_MANAGER.GetString("deleteAllTeachers_Click.msb.notalldeleted.caption");
					
					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
				
			}			

		}

		private void propertiesTeacher_Click(object sender, System.EventArgs e)
		{
			Teacher teacher=(Teacher)_teachersTreeView.SelectedNode;

			showTeacherProperties(teacher);
		}

		private void showTeacherProperties(Teacher teacher)
		{
			TeacherPropertiesForm pnf=new TeacherPropertiesForm(teacher);
			pnf.ShowDialog(this);

			if (pnf.DialogResult == DialogResult.OK)
			{
				string newTitle = (string)pnf.TitleComboBox.SelectedItem;
				if(newTitle==null)newTitle=pnf.TitleComboBox.Text.Trim();
				string newEduRank = (string)pnf.EduRankComboBox.SelectedItem;
				if(newEduRank==null)newEduRank=pnf.EduRankComboBox.Text.Trim();

				string newName = pnf.NameTextBox.Text.Trim();
				string newLastname= pnf.LastnameTextBox.Text.Trim();
				string newExtID= pnf.ExtIDTextBox.Text.Trim();


				if(teacher.getName()!=newName
					|| teacher.getLastName()!=newLastname
					|| teacher.getTitle()!=newTitle
					|| teacher.getEduRank()!=newEduRank
					|| teacher.ExtID!=newExtID)
				{
					ChangeTeacherDataCmd cndCmd=new ChangeTeacherDataCmd(teacher,newName,newLastname,newTitle,newEduRank, newExtID);
					_cmdProcessor.doCmd(cndCmd);

				}
				
				pnf.Dispose();
			}

		}

		private void allowedTimeSlotsForTeacher_Click(object sender, System.EventArgs e)
		{			
			Teacher teacher=(Teacher)_teachersTreeView.SelectedNode;
			AllowedTimeSlotsForm cf=new AllowedTimeSlotsForm(teacher.getAllowedTimeSlots(), Constants.ATSF_TIME_SLOT_TYPE_TEACHER, teacher);
			cf.ShowDialog(this);

			if (cf.DialogResult == DialogResult.OK)
			{
				ChangeAllowedTimeSlotsCmd cptsCmd=new ChangeAllowedTimeSlotsCmd(teacher,Constants.ATSF_TIME_SLOT_TYPE_TEACHER,cf);
				_cmdProcessor.doCmd(cptsCmd);				
								
				cf.Dispose();
			}

		}

		private void roomRestrictionForTeacher_Click(object sender, System.EventArgs e)
		{			
			Teacher teacher=(Teacher)_teachersTreeView.SelectedNode;			
			
			string labelText=RES_MANAGER.GetString("roomRestrictionForTeacher_Click.forteacher.text")+" '"+teacher.getLastName()+" "+teacher.getName()+"'";
			RoomsRestrictionForm ouf=new RoomsRestrictionForm(teacher.getAllowedRoomsList(),labelText,-1);
			ouf.ShowDialog(this);

			if (ouf.DialogResult == DialogResult.OK)
			{
				ArrayList tempList = new ArrayList();
				foreach(Room room in ouf.getChoosedRoomsListBox().Items)
				{
					tempList.Add(room);
				}

				if(tempList.Count==0) tempList=null;

				SetAllowedRoomsCmd puCmd = new SetAllowedRoomsCmd(null,teacher,tempList);
				_cmdProcessor.doCmd(puCmd);				
								
				ouf.Dispose();
			}

		}

		private void deleteTeacher_Click(object sender, System.EventArgs e)
		{
			Teacher teacher = (Teacher)_teachersTreeView.SelectedNode;
			
			string message = RES_MANAGER.GetString("deleteTeacher_Click.msb.confirm.message");
		
			string caption = RES_MANAGER.GetString("deleteTeacher_Click.msb.confirm.caption");
			
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				if(!teacher.getIsUsedAsTeacherForAnyCourse())
				{
					DeleteTeacherCmd dnCmd=new DeleteTeacherCmd(teacher);
					_cmdProcessor.doCmd(dnCmd);					
				}
				else
				{					
					string message2 = RES_MANAGER.GetString("deleteTeacher_Click.msb.notdeleted.message");
									
					string caption2 = RES_MANAGER.GetString("deleteTeacher_Click.msb.notdeleted.caption");

					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}

			}

		}

		private void _roomsTreeContextMenu_Popup(object sender, System.EventArgs e)
		{
			_roomsTreeContextMenu.MenuItems.Clear();			
			
			if(_roomsTreeView.SelectedNode.GetType().FullName=="System.Windows.Forms.TreeNode")
			{ 				
				MenuItem menuItem1 = new MenuItem(RES_MANAGER.GetString("_addRoomMenuItem.Text"));
				menuItem1.Click += new System.EventHandler(this.addUcionica_Click);
				_roomsTreeContextMenu.MenuItems.Add(menuItem1);				

				if(AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Count>0) 
				{
					_roomsTreeContextMenu.MenuItems.Add(new MenuItem("-"));
			
					MenuItem menuItem2 = new MenuItem(RES_MANAGER.GetString("_delAllRoomsMenuItem.Text"));
					menuItem2.Click += new System.EventHandler(this.deleteAllRooms_Click);					
					_roomsTreeContextMenu.MenuItems.Add(menuItem2);
					_roomsTreeContextMenu.MenuItems.Add(new MenuItem("-"));
					
					MenuItem menuItem3 = new MenuItem(RES_MANAGER.GetString("_printTimetableAllRoomsMenuItem.Text"));
					menuItem3.Click += new System.EventHandler(this.printTimetableForAllRooms_Click);
					_roomsTreeContextMenu.MenuItems.Add(menuItem3);

                    MenuItem menuItem4 = new MenuItem(RES_MANAGER.GetString("_printRoomsListMenuItem.Text"));
                    menuItem4.Click += new System.EventHandler(this.printRoomsList_Click);
                    _roomsTreeContextMenu.MenuItems.Add(menuItem4);
				}

				
				
			} 
			else if(_roomsTreeView.SelectedNode.GetType().FullName=="OpenCTT.Room") 
			{
				foreach(MenuItem mi in _roomMenuItem.MenuItems)
				{					
					_roomsTreeContextMenu.MenuItems.Add(mi.CloneMenu());
				}
			}
		
		}


		private void addUcionica_Click(object sender, System.EventArgs e)
		{
	
			RoomPropertiesForm puf=new RoomPropertiesForm();
			puf.ShowDialog(this);

			if (puf.DialogResult == DialogResult.OK)
			{	
				string name = puf.NameTextBox.Text.Trim();
				int capacity=System.Convert.ToInt32(puf.CapacityTextBox.Text.Trim());

				string extID=puf.ExtIDTextBox.Text.Trim();
				
				
				AddRoomCmd auCmd=new AddRoomCmd(name,capacity,extID);
				_cmdProcessor.doCmd(auCmd);
				
				puf.Dispose();
			}		

		}

		
		private void deleteAllRooms_Click(object sender, System.EventArgs e) 
		{	
			string message = RES_MANAGER.GetString("deleteAllRooms_Click.msb.confirm.message");

			string caption = RES_MANAGER.GetString("deleteAllRooms_Click.msb.confirm.caption");

			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
	
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
                bool delAll=true;
				ArrayList tempList = new ArrayList();
				foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
				{
					if(!room.getIsInTimetable())
					{
						tempList.Add(room);
					}
					else
					{
						delAll=false;
					}
				}
				if(tempList.Count>0)
				{
					DeleteMoreThanOneRoomCmd dmtouCmd=new DeleteMoreThanOneRoomCmd(tempList);
					_cmdProcessor.doCmd(dmtouCmd);
				}	
				
				if(!delAll)
				{	
					string message2 = RES_MANAGER.GetString("deleteAllRooms_Click.msb.notalldeleted.message");
				
					string caption2 = RES_MANAGER.GetString("deleteAllRooms_Click.msb.notalldeleted.caption");

					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}				
			}
		}

		private void propertiesRoom_Click(object sender, System.EventArgs e)
		{
			Room room=(Room)_roomsTreeView.SelectedNode;
			showRoomProperties(room);
			
		}

		private void showRoomProperties(Room room)
		{
			RoomPropertiesForm puf=new RoomPropertiesForm(room);
			puf.ShowDialog(this);

			if (puf.DialogResult == DialogResult.OK)
			{
				if(room.getName()!=puf.NameTextBox.Text.Trim() || room.getRoomCapacity()!=System.Convert.ToInt32(puf.CapacityTextBox.Text.Trim()) || room.ExtID!=puf.ExtIDTextBox.Text.Trim())
				{
					string newName=puf.NameTextBox.Text.Trim();
					int newCapacity=System.Convert.ToInt32(puf.CapacityTextBox.Text.Trim());

					string newExtID= puf.ExtIDTextBox.Text.Trim();

					ChangeRoomDataCmd cudCmd=new ChangeRoomDataCmd(room,newName,newCapacity, newExtID);
					_cmdProcessor.doCmd(cudCmd);					
				}

				puf.Dispose();
			}

		}

		private void allowedTimeSlotsForRoom_Click(object sender, System.EventArgs e)
		{			
			Room room=(Room)_roomsTreeView.SelectedNode;
			AllowedTimeSlotsForm cf=new AllowedTimeSlotsForm(room.getAllowedTimeSlots(), Constants.ATSF_TIME_SLOT_TYPE_ROOM,room);
			cf.ShowDialog(this);

			if (cf.DialogResult == DialogResult.OK)
			{
				ChangeAllowedTimeSlotsCmd cptsCmd=new ChangeAllowedTimeSlotsCmd(room,Constants.ATSF_TIME_SLOT_TYPE_ROOM,cf);
				_cmdProcessor.doCmd(cptsCmd);				
								
				cf.Dispose();
			}

		}

		private void deleteRoom_Click(object sender, System.EventArgs e)
		{
			Room room = (Room)_roomsTreeView.SelectedNode;			
			string message = RES_MANAGER.GetString("deleteRoom_Click.msb.confirm.message");

			string caption = RES_MANAGER.GetString("deleteRoom_Click.msb.confirm.caption");

			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;
		
			result = MessageBox.Show(this, message, caption, buttons,
				MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 
				MessageBoxOptions.RightAlign);

			if(result == DialogResult.Yes)
			{
				if(room.getIsInTimetable())
				{					
					string message2 = RES_MANAGER.GetString("deleteRoom_Click.msb.notdeleted.message");
				
					string caption2 = RES_MANAGER.GetString("deleteRoom_Click.msb.notdeleted.caption");

					MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message2, caption2, buttons2,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
				else
				{
                    DeleteRoomCmd duCmd=new DeleteRoomCmd(room);
					_cmdProcessor.doCmd(duCmd);
					
				}
			}

		}

		public void coursesTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode selTN=e.Node;
			AppForm.CURR_OCTT_DOC.CTVSelectedNode=selTN;
			
			ctvRefreshTimetablePanel(selTN, false,false);			
			
		}

		public void ctvRefreshTimetablePanel(TreeNode selTN, bool newDraw, bool isRefresh)
		{	

			if(selTN.GetType().FullName=="OpenCTT.EduProgram"
				|| selTN.GetType().FullName=="OpenCTT.Course")
			{
				EduProgram ep;
				if(selTN.GetType().FullName=="OpenCTT.Course")
				{
					Course course = (Course)selTN;
					ep = (EduProgram)course.Parent;
					_courseMenuItem.Enabled=true;
					_epgMenuItem.Enabled=false;
					_epMenuItem.Enabled=false;

					//_printToolBarButton.Enabled=false;
					_printToolBarButton.ImageIndex=14;
				}
				else
				{					
					ep = (EduProgram)selTN;
					_epMenuItem.Enabled=true;
					_courseMenuItem.Enabled=false;
					_epgMenuItem.Enabled=false;

					//_printToolBarButton.Enabled=true;
					_printToolBarButton.ImageIndex=7;
				}
				
				if(ep!=AppForm.CURR_OCTT_DOC.ShownEduProgram || isRefresh)
				{
					AppForm.CURR_OCTT_DOC.ShownEduProgram=ep;
					_unallocatedLessonsListView.Items.Clear();
					
					ArrayList unallocatedLessList = ep.getUnallocatedLessonsList();

					foreach(ListViewItem lvi in unallocatedLessList)
					{
						Course courseTag = (Course)lvi.Tag;
						string [] courseAndTeacher= new string[2];						
						courseAndTeacher[0]=courseTag.getFullName();
												
						string teacherStr=courseTag.getTeacher().getLastName()+" "+courseTag.getTeacher().getName();
						courseAndTeacher[1]=teacherStr;
						ListViewItem newLvi= new ListViewItem(courseAndTeacher);
						newLvi.Tag=courseTag;
						_unallocatedLessonsListView.Items.Add(newLvi);
					}
					
					_timetableTab.Text=RES_MANAGER.GetString("ctv.timetableTab.for.Text")+" "+ep.getName()+" "+ep.getCode()+", "+ep.getSemester()+RES_MANAGER.GetString("ctv.timetableTab.sem.text");
								
					updateTimeSlotPanel(1,AppForm.CURR_OCTT_DOC.ShownEduProgram,newDraw);

					_unallocatedLessonsListView.Visible=true;
					_unallocatedLessonsTeacherListView.Visible=false;
					_splitterHor.Visible=true;
					_timetableTabControl.Visible=true;
				}
			}
			else
			{
				_splitterHor.Visible=false;
				_unallocatedLessonsListView.Visible=false;
				_unallocatedLessonsTeacherListView.Visible=false;
				_timetableTabControl.Visible=false;
				AppForm.CURR_OCTT_DOC.ShownEduProgram=null;
				
				if(selTN.GetType().FullName=="OpenCTT.EduProgramGroup")
				{
					_epgMenuItem.Enabled=true;
					
					//_printToolBarButton.Enabled=true;
					_printToolBarButton.ImageIndex=7;
				}
				else
				{
					_epgMenuItem.Enabled=false;

					//_printToolBarButton.Enabled=false;
					_printToolBarButton.ImageIndex=14;
				}

				_epMenuItem.Enabled=false;
				_courseMenuItem.Enabled=false;
			}

			_teacherMenuItem.Enabled=false;
			_roomMenuItem.Enabled=false;
		}
		
		private void _unallocatedLessonsForCourseViewListView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{	
			ListViewItem dragedLvi = (ListViewItem)e.Item;
			Course dragedCourse=(Course)dragedLvi.Tag;

			ArrayList notPossibleTimeSlots=HardConstraintChecks.findAllFreeTimeSlots(dragedCourse);
						
			if(DragDropEffects.Move==_unallocatedLessonsListView.DoDragDrop(dragedLvi,DragDropEffects.Move)) 
			{
	
				ULLVCoursesItemDragSuccessfullCmd nsslvidds=new ULLVCoursesItemDragSuccessfullCmd(dragedLvi,_unallocatedLessonsListView);
				TimeSlotPanel.DRAG_DROP_MACRO_CMD.addInList(nsslvidds);
				CommandProcessor.getCommandProcessor().doCmd(TimeSlotPanel.DRAG_DROP_MACRO_CMD);
				
			}
			
			doBackTimeSlotPanelGUI(notPossibleTimeSlots);
		
		}

		public void doBackTimeSlotPanelGUI(ArrayList notPossibleTimeSlots)
		{
			//back original state of colors
			foreach(TimeSlotPanel tsp in notPossibleTimeSlots) 
			{
				tsp.AllowDrop=true;
				tsp.BackColor=System.Drawing.Color.Gainsboro;
				ArrayList subLabels= tsp.getAllSubLabels();
				foreach(Label [] courseRoomLabel in subLabels) 
				{
					Label courseLabel = courseRoomLabel[0];
					Label roomLabel = courseRoomLabel[1];
					
					Course p = (Course)courseLabel.Tag;
					courseLabel.BackColor=p.MyGUIColor;
					roomLabel.BackColor=System.Drawing.SystemColors.ControlLight;
				}
			}

		}	

		

		public StatusBarPanel getStatusBarPanel1() 
		{
			return _statusBarPanel1;
		}

		public StatusBarPanel getStatusBarPanel2()
		{
			return _statusBarPanel2;
		}

		private void ULLVCourseView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(TimeSlotPanel.DRAG_DROP_START_PANEL!=null)
			{
				ListView ullv =(ListView)sender;
				e.Effect = DragDropEffects.Move;
				ullv.BackColor=Color.LightSteelBlue;
			}
		}

		private void ULLVCourseView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ListView ullv =(ListView)sender;
			ListViewItem lviDraged = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
            ullv.BackColor=System.Drawing.SystemColors.Window;

			ULLVCoursesDragDropCmd nslvsddCmd=new ULLVCoursesDragDropCmd(lviDraged,ullv);
			TimeSlotPanel.DRAG_DROP_MACRO_CMD=new MacroCommand();
			TimeSlotPanel.DRAG_DROP_MACRO_CMD.addInList(nslvsddCmd);

		}		


		public void roomsTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode selTN=e.Node;
			AppForm.CURR_OCTT_DOC.RTVSelectedNode=selTN;
			
			rtvRefreshTimetablePanel(selTN, false);
							
		}

		public void rtvRefreshTimetablePanel(TreeNode selTN, bool newDraw)
		{
			//_printToolBarButton.Enabled=true;
			_printToolBarButton.ImageIndex=7;

			AppForm.CURR_OCTT_DOC.ShownEduProgram=null;

			_epgMenuItem.Enabled=false;
			_epMenuItem.Enabled=false;
			_courseMenuItem.Enabled=false;
			_teacherMenuItem.Enabled=false;

			if(selTN.GetType().FullName=="OpenCTT.Room") 
			{
				_roomMenuItem.Enabled=true;

				Room room = (Room)selTN;				
				_timetableTab.Text=RES_MANAGER.GetString("rtv.timetableTab.for.Text")+" "+room.getName();
				
				updateTimeSlotPanel(3,room,newDraw);
				
				_splitterHor.Visible=false;
				_unallocatedLessonsListView.Visible=false;
				_unallocatedLessonsTeacherListView.Visible=false;
				_timetableTabControl.Visible=true;	
				
			}
			else
			{
				_splitterHor.Visible=false;
				_unallocatedLessonsListView.Visible=false;
				_unallocatedLessonsTeacherListView.Visible=false;
				_timetableTabControl.Visible=false;				
				_roomMenuItem.Enabled=false;
			}

		}

		
		public void teachersTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode selTN=e.Node;
			AppForm.CURR_OCTT_DOC.TTVSelectedNode=selTN;

            ttvRefreshTimetablePanel(selTN, false);			
			
		}

		public void ttvRefreshTimetablePanel(TreeNode selTN, bool newDraw)
		{
			//_printToolBarButton.Enabled=true;
			_printToolBarButton.ImageIndex=7;

			AppForm.CURR_OCTT_DOC.ShownEduProgram=null;
			_epgMenuItem.Enabled=false;
			_epMenuItem.Enabled=false;
			_courseMenuItem.Enabled=false;
			_roomMenuItem.Enabled=false;

			if(selTN.GetType().FullName=="OpenCTT.Teacher") 
			{			
				_teacherMenuItem.Enabled=true;
				
				Teacher teacher = (Teacher)selTN;

				_unallocatedLessonsTeacherListView.Items.Clear();
				
				ArrayList unallocatedLessList = teacher.getUnallocatedLessonsList();				

				foreach(ListViewItem lvi in unallocatedLessList) 
				{
					Course course = (Course)lvi.Tag;
					string [] courseAndEPAndSem= new string[3];
					courseAndEPAndSem[0]=course.getFullName();
					EduProgram eduProg=(EduProgram)course.Parent;
					string epText="";
					if(eduProg.getCode()!=null)
					{
						epText=eduProg.getCode()+", ";
					}
					epText+=eduProg.getName();
					courseAndEPAndSem[1]=epText;
					courseAndEPAndSem[2]=eduProg.getSemester();						
					ListViewItem newLvi= new ListViewItem(courseAndEPAndSem);
					newLvi.Tag=course;
					_unallocatedLessonsTeacherListView.Items.Add(newLvi);
				}				
				
				_timetableTab.Text=RES_MANAGER.GetString("ttv.timetableTab.for.Text")+" "+teacher.getTreeText();

				
				updateTimeSlotPanel(2,teacher,newDraw);

				_unallocatedLessonsTeacherListView.Visible=true;
				_unallocatedLessonsListView.Visible=false;
				_splitterHor.Visible=true;
				_timetableTabControl.Visible=true;

			}
			else
			{
				_splitterHor.Visible=false;
				_unallocatedLessonsListView.Visible=false;
				_unallocatedLessonsTeacherListView.Visible=false;
				_timetableTabControl.Visible=false;
				
				_teacherMenuItem.Enabled=false;
			}

		}

		
		private void _unallocatedLessonsForTeachersViewListView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			ListViewItem dragedLvi = (ListViewItem)e.Item;
			Course dragedCourse=(Course)dragedLvi.Tag;
			
			ArrayList notPossibleTimeSlots = HardConstraintChecks.findAllFreeTimeSlots(dragedCourse);

			if(DragDropEffects.Move==_unallocatedLessonsTeacherListView.DoDragDrop(dragedLvi,DragDropEffects.Move)) 
			{

				ULLVTeachersItemDragSuccessfullCmd nsnlvidds=new ULLVTeachersItemDragSuccessfullCmd(dragedLvi,_unallocatedLessonsTeacherListView);
				TimeSlotPanel.DRAG_DROP_MACRO_CMD.addInList(nsnlvidds);
				CommandProcessor.getCommandProcessor().doCmd(TimeSlotPanel.DRAG_DROP_MACRO_CMD);

				_statusBarPanel2.Text=AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();
			}
			
			doBackTimeSlotPanelGUI(notPossibleTimeSlots);
		
		}

		private void ULLVTeachersView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(TimeSlotPanel.DRAG_DROP_START_PANEL!=null)
			{
				ListView ullv =(ListView)sender;
				e.Effect = DragDropEffects.Move;
				ullv.BackColor=Color.LightSteelBlue;
			}
		}

		private void ULLVTeachersView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ListView ullv =(ListView)sender;
			ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
			ullv.BackColor=System.Drawing.SystemColors.Window;

			ULLVTeachersDragDropCmd nslvnddCmd=new ULLVTeachersDragDropCmd(lvi,ullv);
			TimeSlotPanel.DRAG_DROP_MACRO_CMD=new MacroCommand();
			TimeSlotPanel.DRAG_DROP_MACRO_CMD.addInList(nslvnddCmd);
		}


		public Panel getMainTimetablePanel()
		{
			return _mainTimetablePanel;
		}
		
		public void treeTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TabControl tc = (TabControl)sender;
			if(tc.SelectedIndex==0)
			{	
				if(AppForm.CURR_OCTT_DOC.CTVSelectedNode==null) AppForm.CURR_OCTT_DOC.CTVSelectedNode=AppForm.CURR_OCTT_DOC.CoursesRootNode;

                _teacherMenuItem.Enabled=false;
				_roomMenuItem.Enabled=false;				
				ctvRefreshTimetablePanel(AppForm.CURR_OCTT_DOC.CTVSelectedNode,false,false);

			}
			else if(tc.SelectedIndex==1)
			{
				if(AppForm.CURR_OCTT_DOC.TTVSelectedNode==null) AppForm.CURR_OCTT_DOC.TTVSelectedNode=AppForm.CURR_OCTT_DOC.TeachersRootNode;
				
				_epgMenuItem.Enabled=false;
				_epMenuItem.Enabled=false;
				_courseMenuItem.Enabled=false;
				_roomMenuItem.Enabled=false;

				ttvRefreshTimetablePanel(AppForm.CURR_OCTT_DOC.TTVSelectedNode,false);

			}
			else if(tc.SelectedIndex==2)
			{
				if(AppForm.CURR_OCTT_DOC.RTVSelectedNode==null) AppForm.CURR_OCTT_DOC.RTVSelectedNode=AppForm.CURR_OCTT_DOC.RoomsRootNode;

				_epgMenuItem.Enabled=false;
				_epMenuItem.Enabled=false;
				_courseMenuItem.Enabled=false;
				_teacherMenuItem.Enabled=false;

				rtvRefreshTimetablePanel(AppForm.CURR_OCTT_DOC.RTVSelectedNode,false);
			}			
		}

		public Course getSelectedCourse()
		{
			Course course=(Course)_coursesTreeView.SelectedNode;
			return course;
		}

		public Teacher getSelectedTeacher()
		{
			Teacher teacher=(Teacher)_teachersTreeView.SelectedNode;
			return teacher;
		}

		private bool checkIsHTPossible()
		{
			Course course=(Course)_coursesTreeView.SelectedNode;
			EduProgram ep = (EduProgram)course.Parent;
			if(ep.getIsCourseInTimetable(course))
			{
                return false;
			}
			else
			{
				return true;
			}
		}			
		

		public void refreshGUIAfterDaysTermsChange(bool isFullRefresh)
		{
			_daysPanel.Controls.Clear();
			_termsPanel.Controls.Clear();
			_mainTimetablePanel.Controls.Clear();

			drawDaysAndTermsLabels();	
			
			if(isFullRefresh)
			{
				if(_treeTabControl.SelectedIndex==0)
				{					
					updateTimeSlotPanel(1,AppForm.CURR_OCTT_DOC.ShownEduProgram,true);					
				}
				else if(_treeTabControl.SelectedIndex==1)
				{
					Teacher teacher;
					if(_teachersTreeView.SelectedNode.GetType().GetType().FullName=="OpenCTT.Teacher")
					{
						teacher = (Teacher)_teachersTreeView.SelectedNode;						
					}
					else
					{
						teacher=null;						
					}
					
					updateTimeSlotPanel(2,teacher,true);
				}
				else if(_treeTabControl.SelectedIndex==2)
				{
					Room room;
					if(_roomsTreeView.SelectedNode.GetType().GetType().FullName=="OpenCTT.Room")
					{
						room = (Room)_roomsTreeView.SelectedNode;
					}
					else
					{
						room=null;
					}						
					
					updateTimeSlotPanel(3,room,true);
				}
			}
			
		}		


		private void printTimetableForOneEduProgram_Click(object sender, System.EventArgs e)
		{
			printTimetableForOneEduProgram();			
		}

		private void printTimetableForOneEduProgram()
		{
			ArrayList listForPrint = new ArrayList();
			EduProgram ep = (EduProgram)_coursesTreeView.SelectedNode;
			listForPrint.Add(ep);			

			ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,1);
			PdfCreator.createPdfDocument(pdfReportDataTablesList);
			
		}

		private void printTimetableForAllEduPrograms_Click(object sender, System.EventArgs e)
		{
			printTimetableForAllEduPrograms();			
		}

		private void printTimetableForAllEduPrograms()
		{
			ArrayList listForPrint = new ArrayList();
			EduProgramGroup epg = (EduProgramGroup)_coursesTreeView.SelectedNode;

			foreach(EduProgram ep in epg.Nodes)
			{
				listForPrint.Add(ep);
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,1);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}
		}

		private void printTimetableForOneTeacher_Click(object sender, System.EventArgs e)
		{
            printTimetableForOneTeacher();
		}

		private void printTimetableForOneTeacher()
		{
			Teacher teacher = (Teacher)_teachersTreeView.SelectedNode;
			ArrayList listForPrint = new ArrayList();
			listForPrint.Add(teacher);
			
			ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,2);
			PdfCreator.createPdfDocument(pdfReportDataTablesList);			
		}

		private void printTimetableForAllTeachers_Click(object sender, System.EventArgs e)
		{
            printTimetableForAllTeachers();			
		}

        private void printTeacherList_Click(object sender, System.EventArgs e)
        {
            PdfCreatorTeacherList.createPdfDocumentTeacherList();
        }

        private void printTeacherHours_Click(object sender, System.EventArgs e)
        {
            PdfCreatorTeacherHours.createPdfDocumentTeacherHours();
        }



		private void printTimetableForAllTeachers()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{
				listForPrint.Add(teacher);
			}

			if(listForPrint.Count>0)
			{	
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,2);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}
		}

		private void printTimetableForOneRoom_Click(object sender, System.EventArgs e)
		{
			printTimetableForOneRoom();
		}

		private void printTimetableForOneRoom()
		{
			Room room = (Room)_roomsTreeView.SelectedNode;
			ArrayList listForPrint = new ArrayList();			
			listForPrint.Add(room);
			
			ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,3);
			PdfCreator.createPdfDocument(pdfReportDataTablesList);
		}

        private void printRoomsList_Click(object sender, System.EventArgs e)
        {
            PdfCreatorRoomsList.createPdfDocumentRoomsList();
        }

		private void printTimetableForAllRooms_Click(object sender, System.EventArgs e)
		{
			printTimetableForAllRooms();					
		}

		private void printTimetableForAllRooms()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				listForPrint.Add(room);
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,3);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);	
			}
		}

		private void _printEPMenuItem_Click(object sender, System.EventArgs e)
		{
			PrintSelectionForm psf=new PrintSelectionForm(1);
			psf.ShowDialog(this);
			psf.Dispose();
		
		}

		private void _printTeachersMenuItem_Click(object sender, System.EventArgs e)
		{
			PrintSelectionForm psf=new PrintSelectionForm(2);

			psf.ShowDialog(this);
									
			psf.Dispose();		
		}

		private void _printRoomsMenuItem_Click(object sender, System.EventArgs e)
		{
			PrintSelectionForm psf=new PrintSelectionForm(3);
			psf.ShowDialog(this);			
			psf.Dispose();			
		}

		private void _exitAppMenuItem_Click(object sender, System.EventArgs e)
		{
			Application.Exit();			
		}

		private void docPropertiesMenuItem_Click(object sender, System.EventArgs e)
		{			
			DocumentPropertiesForm syf=new DocumentPropertiesForm(false);
			syf.ShowDialog(this);

			if (syf.DialogResult == DialogResult.OK)
			{
				if(CURR_OCTT_DOC.DocumentType!=syf.getDocumentType() ||  CURR_OCTT_DOC.SchoolYear!=syf.getSchoolYear() || CURR_OCTT_DOC.EduInstitutionName!=syf.getEduInstitutionNameInput())
				{					

					ChangeDocumentDataCmd cfdCmd=new ChangeDocumentDataCmd(CURR_OCTT_DOC.DocumentType,CURR_OCTT_DOC.EduInstitutionName,CURR_OCTT_DOC.SchoolYear,syf.getDocumentType(),syf.getEduInstitutionNameInput(),syf.getSchoolYear());
					_cmdProcessor.doCmd(cfdCmd);

					/*setResourceManager();
					updateFormRelatedStrings();
					updateOpenDocumentRelatedStrings();*/
				}

				syf.Dispose();
				
			}
		
		}		

		private void tv_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			TreeView tv = (TreeView)sender;
			TreeNode tn = tv.GetNodeAt(e.X,e.Y);
			if(tn!=null) tv.SelectedNode=tn;
		}

		private void ULLVCoursesView_DragLeave(object sender, System.EventArgs e)
		{
			if(TimeSlotPanel.DRAG_DROP_START_PANEL!=null)
			{
				ListView ullv =(ListView)sender;				
				ullv.BackColor=System.Drawing.SystemColors.Window;
			}
		}

		private void ULLVTeachersView_DragLeave(object sender, System.EventArgs e)
		{
			if(TimeSlotPanel.DRAG_DROP_START_PANEL!=null)
			{
				ListView ullv =(ListView)sender;				
				ullv.BackColor=System.Drawing.SystemColors.Window;
			}
		}

		
		public static string getApplicationVersion()
		{
			return APPLICATION_VERSION;
		}
		

		private void _openDocMenuItem_Click(object sender, System.EventArgs e)
		{
			doOpenDoc();			
		}

		private void doOpenDoc()
		{		

			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter=APPLICATION_NAME+" (*.oct)|*.oct";			
			openFileDialog.InitialDirectory = Settings.WORKING_DIR_SETT;
		
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				doOpenDocAction(openFileDialog.FileName);
			}

			openFileDialog.Dispose();
		}
		

		private void doOpenDocAction(string fileName)
		{
			try
			{
				if(IS_DOC_OPEN)	doCloseDoc();

				CURR_OCTT_DOC= new OCTTDocument();
			
				AppForm.CURR_OCTT_DOC.FullPath=fileName;
				AppForm.CURR_OCTT_DOC.FileName=AppForm.CURR_OCTT_DOC.FullPath.Substring(AppForm.CURR_OCTT_DOC.FullPath.LastIndexOf(@System.IO.Path.DirectorySeparatorChar)+1);
				this.Text=AppForm.CURR_OCTT_DOC.FileName+" - "+APPLICATION_NAME;

				IS_DOC_OPEN=true;
				_docMenuItem.Enabled=true;
			
				FileOperations.openDocFromFile(AppForm.CURR_OCTT_DOC.FullPath);
			
				AppForm.CURR_OCTT_DOC.CoursesRootNode.Expand();
				AppForm.CURR_OCTT_DOC.TeachersRootNode.Expand();
				AppForm.CURR_OCTT_DOC.RoomsRootNode.Expand();

				foreach(EduProgramGroup st in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
				{
					st.Expand();
					foreach(EduProgram ep in st.Nodes)
					{
						ep.Collapse();
					} 
				}

				AppForm.CURR_OCTT_DOC.RTVSelectedNode=null;
				AppForm.CURR_OCTT_DOC.TTVSelectedNode=null;

				_statusBarPanel2.Text= AppForm.CURR_OCTT_DOC.getNumOfUnallocatedLessonsStatusText();

				setResourceManager();

				createGUIForNewDoc();

				updateFormRelatedStrings();
				updateOpenDocumentRelatedStrings();

				_cmdProcessor.emptyAllStacks();
				enableDisableTBButton();
			
				//_undoToolBarButton.Enabled=false;
				//_redoToolBarButton.Enabled=false;
				_undoToolBarButton.ImageIndex=11;
				_redoToolBarButton.ImageIndex=12;

				updateEnableDisableStateForPluginMenuItems();

				changeRFLState();				
			}
			catch(FileNotFoundException e)
			{
				AppForm.getAppForm().getStatusBarPanel1().Text="";
				
				string message1 = RES_MANAGER.GetString("doOpenDocAction.msb.filenotfound.message1");
				string message2 = RES_MANAGER.GetString("doOpenDocAction.msb.filenotfound.message2");
				string message=message1+" "+e.FileName+" "+message2;
			
				string caption = RES_MANAGER.GetString("doOpenDocAction.msb.filenotfound.caption");

				MessageBoxButtons buttons = MessageBoxButtons.OK;
				MessageBox.Show(AppForm.getAppForm(), message, caption, buttons,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);				

				_docMenuItem.Enabled=false;
				IS_DOC_OPEN=false;
				this.Text=APPLICATION_NAME;
				updateEnableDisableStateForPluginMenuItems();

			}
			catch(DirectoryNotFoundException e)
			{
				AppForm.getAppForm().getStatusBarPanel1().Text="";
				
				string message1 = RES_MANAGER.GetString("doOpenDocAction.msb.filenotfound.message1");
				string message2 = RES_MANAGER.GetString("doOpenDocAction.msb.filenotfound.message2");
				string message=message1+" "+fileName+" "+message2;
				
				string caption = RES_MANAGER.GetString("doOpenDocAction.msb.filenotfound.caption");

				MessageBoxButtons buttons = MessageBoxButtons.OK;
				MessageBox.Show(AppForm.getAppForm(), message, caption, buttons,
					MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);				

				_docMenuItem.Enabled=false;
				IS_DOC_OPEN=false;
				this.Text=APPLICATION_NAME;
				updateEnableDisableStateForPluginMenuItems();
			}


			catch(XmlSchemaException e)
			{
				_docMenuItem.Enabled=false;
				IS_DOC_OPEN=false;
				this.Text=APPLICATION_NAME;
				updateEnableDisableStateForPluginMenuItems();
			}


		}


		private void changeRFLState()
		{
			try
			{				

				int regFileCounter=Settings.RECENT_DOCS_LIST.Count;
			
				ArrayList recentFileNames= new ArrayList();
			
				for(int f=0;f<regFileCounter;f++)
				{					
					string s = (string)Settings.RECENT_DOCS_LIST[f];				
					if(s!=AppForm.CURR_OCTT_DOC.FullPath)
					{
						recentFileNames.Add(s);					
					}				
				}

				Settings.RECENT_DOCS_LIST.Clear();


				if(recentFileNames.Count==5)
				{
					recentFileNames.RemoveAt(0);
				}
			
				for(int f2=0;f2<recentFileNames.Count;f2++)
				{
					Settings.RECENT_DOCS_LIST.Insert(f2,recentFileNames[f2]);							
				}			

				Settings.RECENT_DOCS_LIST.Insert(recentFileNames.Count,AppForm.CURR_OCTT_DOC.FullPath);			

				foreach(MenuItem miFromList in RFL_MENU_ITEMS_LIST)
				{
					_fileMenuItem.MenuItems.Remove(miFromList);
				}
			}
			catch
			{
				Settings.RECENT_DOCS_LIST.Clear();
			}

			Settings.saveFileHistory();

			makeRFLMenuItems();

		}



		private void _closeDocMenuItem_Click(object sender, System.EventArgs e)
		{
			doCloseDoc();			
		}

		public bool doCloseDoc()
		{
			
			if(checkSaveBeforeCloseDocument())
			{	
				doCloseDocAction();
				return true;
			}
			

			return false;

		}


		public void doCloseDocAction()
		{
			CURR_OCTT_DOC=null;

			IS_DOC_OPEN=false;

			this.SuspendLayout();
			_docMenuItem.Enabled=false;
			_epgMenuItem.Enabled=false;
			_epMenuItem.Enabled=false;
			_courseMenuItem.Enabled=false;
			_teacherMenuItem.Enabled=false;
			_roomMenuItem.Enabled=false;				

			this.Controls.Remove(_emptyPanel);
			this.Controls.Remove(_treeTabControl);
			this.Controls.Remove(_splitterVer);
			this.Controls.Remove(_timetableTabControl);
			this.Controls.Remove(_splitterHor);
			this.Controls.Remove(_unallocatedLessonsListView);
			this.Controls.Remove(_unallocatedLessonsTeacherListView);

			this.Controls.Add(_firstPanel);
			this.Controls.SetChildIndex(_firstPanel,0);

			_statusBarPanel2.Text="";

			this.Text=APPLICATION_NAME;

			_cmdProcessor.emptyAllStacks();

			enableDisableTBButton();			

			this.ResumeLayout();

			updateEnableDisableStateForPluginMenuItems();

		}

		private void _saveAsDocMenuItem_Click(object sender, System.EventArgs e)
		{
            saveAsDocument();			
		}


		private void _saveDocMenuItem_Click(object sender, System.EventArgs e)
		{
			doSaveDoc();			
		}

		private void doSaveDoc()
		{
			if(IS_DOC_OPEN)
			{
				if(AppForm.CURR_OCTT_DOC.FullPath!=null)
				{
					FileOperations.saveToFile(AppForm.CURR_OCTT_DOC.FullPath);
				}
				else
				{
					saveAsDocument();
				}
			}
		}


		private void saveAsDocument()
		{
			SaveFileDialog _saveFileDialog = new SaveFileDialog();
			_saveFileDialog.Filter=APPLICATION_NAME+" (*.oct)|*.oct";			
			_saveFileDialog.InitialDirectory = Settings.WORKING_DIR_SETT;
			
			if(_saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				AppForm.CURR_OCTT_DOC.FullPath=_saveFileDialog.FileName;
				AppForm.CURR_OCTT_DOC.FileName=AppForm.CURR_OCTT_DOC.FullPath.Substring(AppForm.CURR_OCTT_DOC.FullPath.LastIndexOf(@System.IO.Path.DirectorySeparatorChar)+1);
				this.Text=AppForm.CURR_OCTT_DOC.FileName+" - "+APPLICATION_NAME;
				
				FileOperations.saveToFile(AppForm.CURR_OCTT_DOC.FullPath);
				
				changeRFLState();
								
			}

			_saveFileDialog.Dispose();		

		}
		

		public static string [] getDayText()
		{
			return DAY_TEXT;
		}

		private void _mainToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if(e.Button==_newDocToolBarButton)
			{
				doNewDocument();
			}
			else if(e.Button==_openDocToolBarButton)
			{
				doOpenDoc();
			}
			else if(e.Button==_saveDocToolBarButton)
			{
				doSaveDoc();
			}
			else if(e.Button==_closeDocToolBarButton)
			{
				doCloseDoc();
			}
			else if(e.Button==_undoToolBarButton)
			{
				_cmdProcessor.undoLastCmd();
				
			}
			else if(e.Button==_redoToolBarButton)
			{
				_cmdProcessor.redoLastUndone();
			}
			else if(e.Button==_searchToolBarButton)
			{
				showSearchForm();				
			}
			else if(e.Button==_printToolBarButton)
			{
				if(IS_DOC_OPEN)
				{
					int tabIndex=_treeTabControl.SelectedIndex;			

					if(tabIndex==0)
					{
						TreeNode selTN = CURR_OCTT_DOC.CTVSelectedNode;
						if(selTN!=null){
							if(selTN.GetType().FullName=="OpenCTT.EduProgramGroup")
							{
								printTimetableForAllEduPrograms();
							}
							else if(selTN.GetType().FullName=="OpenCTT.EduProgram")
							{
								printTimetableForOneEduProgram();
							}
						}
					
					}
					else if(tabIndex==1)
					{
						TreeNode selTN = CURR_OCTT_DOC.TTVSelectedNode;
						if(selTN.GetType().FullName=="OpenCTT.Teacher")
						{
							printTimetableForOneTeacher();
						
						}
						else
						{
							printTimetableForAllTeachers();
						
						}
					
					}
					else if(tabIndex==2)
					{
						TreeNode selTN = CURR_OCTT_DOC.RTVSelectedNode;
						if(selTN.GetType().FullName=="OpenCTT.Room")
						{
							printTimetableForOneRoom();
						}
						else
						{
							printTimetableForAllRooms();
						}
					
					}
				}
				
			}
			else if(e.Button==_helpToolBarButton)
			{
				showHelpContent();						
			}

		}

		public void enableDisableTBButton()
		{
			if(IS_DOC_OPEN)
			{
				_saveDocToolBarButton.ImageIndex=2;
				_closeDocToolBarButton.ImageIndex=3;
				_undoToolBarButton.ImageIndex=4;
				_redoToolBarButton.ImageIndex=5;
				_searchToolBarButton.ImageIndex=6;
				//_mainToolBar.Buttons[7].ImageIndex=7;

				/*_saveDocToolBarButton.Enabled=true;
                _closeDocToolBarButton.Enabled=true;
				_undoToolBarButton.Enabled=true;
				_redoToolBarButton.Enabled=true;

				_searchToolBarButton.Enabled=true;				
				_printToolBarButton.Enabled=false;*/
				
			}
			else
			{
				_saveDocToolBarButton.ImageIndex=9;
				_closeDocToolBarButton.ImageIndex=10;
				_undoToolBarButton.ImageIndex=11;
				_redoToolBarButton.ImageIndex=12;
				_searchToolBarButton.ImageIndex=13;
				//_mainToolBar.Buttons[7].ImageIndex=14;


				//_saveDocToolBarButton.Enabled=false;
				//_closeDocToolBarButton.Enabled=false;
				//_undoToolBarButton.Enabled=false;
				//_redoToolBarButton.Enabled=false;

				//_searchToolBarButton.Enabled=false;
				//_printToolBarButton.Enabled=false;
			}

			_printToolBarButton.ImageIndex=14;

			_helpToolBarButton.Enabled=true;

		}

		public TreeView getCoursesTreeView()
		{
			return _coursesTreeView;
		}

		public TreeView getTeachersTreeView()
		{
			return _teachersTreeView;
		}

		public TreeView getRoomsTreeView()
		{
			return _roomsTreeView;
		}

		public ListView getUnallocatedLessonsListView()
		{
			return _unallocatedLessonsListView;
		}

		public TabControl getTreeTabControl()
		{
			return _treeTabControl;
		}

		public ToolBarButton getUndoToolBarButton()
		{
			return _undoToolBarButton;
		}
		
		public ToolBarButton getRedoToolBarButton()
		{
			return _redoToolBarButton;
		}

		private bool checkSaveBeforeCloseDocument()
		{
			if(_cmdProcessor.getLastCmdOnStack()!=_cmdProcessor.getLastSavedCmd())
			{	
				string message1 = RES_MANAGER.GetString("checkSaveBeforeCloseDocument.msb.confirm.message1");
				string message2 = RES_MANAGER.GetString("checkSaveBeforeCloseDocument.msb.confirm.message2");
				string message=message1+" '"+AppForm.CURR_OCTT_DOC.FileName+"' "+message2;

				string caption = RES_MANAGER.GetString("checkSaveBeforeCloseDocument.msb.confirm.caption");

				MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
				DialogResult result;
		
				result = MessageBox.Show(this, message, caption, buttons,
					MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

				if(result == DialogResult.Yes)
				{
					doSaveDoc();					
				}
				else if(result == DialogResult.Cancel)
				{
					return false;
				}
			}

			return true;

		}

		private void AppForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(!checkSaveBeforeCloseDocument())
			{
				e.Cancel=true;
			}
			else
			{
				Application.Exit();
			}
			
		}

		private void _searchMenuItem_Click(object sender, System.EventArgs e)
		{
			showSearchForm();
		}
	
		private void showSearchForm()
		{
			if(IS_DOC_OPEN)
			{
				try
				{
					SearchForm sf= new SearchForm();				
					sf.Show();
				}
				catch
				{

				}
			}
		}

		public ImageList getTreeImageList()
		{
			return _treeImageList;
		}

		private void _settingsMenuItem_Click(object sender, System.EventArgs e)
		{
			SettingsForm sf = new SettingsForm();
			sf.ShowDialog(this);
			if (sf.DialogResult == DialogResult.OK)
			{
				bool isThereAnyChange=false;
				if(sf.TSPanelWidth!=Settings.TIME_SLOT_PANEL_WIDTH || sf.TSPanelHeight!=Settings.TIME_SLOT_PANEL_HEIGHT || sf.TSPanelFontSize!=Settings.TIME_SLOT_PANEL_FONT_SIZE) isThereAnyChange=true;
				
				/*Settings.DEFAULT_GUI_TEXT_TYPE=sf.DefaultGUITextType;
				Settings.GUI_LANGUAGE=sf.GUILanguage;
				Settings.OCTT_REPORT_ENGINE=sf.ReportEngine;*/

				Settings.saveAppSettings(sf);
				
				if(isThereAnyChange && IS_DOC_OPEN) refreshGUIAfterDaysTermsChange(true);


				sf.Dispose();
			}
		
		}

		private void _epMenuItem_Popup(object sender, System.EventArgs e)
		{
			checkWhatIsEnabledForEP();
		}

		private void checkWhatIsEnabledForEP()
		{
			if(_epMenuItem.Enabled)
			{
				if(_coursesTreeView!=null && _coursesTreeView.SelectedNode!=null)
				{
					EduProgram ep = (EduProgram)_coursesTreeView.SelectedNode;

					if(ep.Nodes.Count==0)
					{
						_epDelAllMyCoursesMenuItem.Enabled=false;
					}
					else
					{
						_epDelAllMyCoursesMenuItem.Enabled=true;
					}

					if(ep.getIsTimetableEmpty())
					{
						_clearTimetableMenuItem.Enabled=false;
					}
					else
					{
						_clearTimetableMenuItem.Enabled=true;
					}

					_addCourseFromClipboardMenuItem.Enabled=false;

					if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Serializable))
					{
						if(Clipboard.GetDataObject().GetData(DataFormats.Serializable) is Hashtable)
						{
							Hashtable cht=(Hashtable)Clipboard.GetDataObject().GetData(DataFormats.Serializable);
							if(cht!=null)
							{
								_addCourseFromClipboardMenuItem.Enabled=true;
							}
						}					
					}

				}
			}

		}

		private void _docMenuItem_Popup(object sender, System.EventArgs e)
		{
			checkWhatIsEnabledForDocument();		
		}

		private void checkWhatIsEnabledForDocument()
		{		
			if(_docMenuItem.Enabled)
			{
				if(AppForm.CURR_OCTT_DOC.TeachersRootNode!=null)
				{
					if(AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Count>0)
					{
						_delAllTeachersMenuItem.Enabled=true;
						_printTimetableAllTeachersMenuItem.Enabled=true;
                        _printTeacherListMenuItem.Enabled = true;
                        _printTeacherHoursMenuItem.Enabled = true;
					}
					else
					{
						_delAllTeachersMenuItem.Enabled=false;
						_printTimetableAllTeachersMenuItem.Enabled=false;
                        _printTeacherListMenuItem.Enabled = false;
                        _printTeacherHoursMenuItem.Enabled = false;
					}

					if(AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Count>0)
					{
						_delAllRoomsMenuItem.Enabled=true;
						_printTimetableAllRoomsMenuItem.Enabled=true;
                        _printRoomsListMenuItem.Enabled = true;
					}
					else
					{
						_delAllRoomsMenuItem.Enabled=false;
						_printTimetableAllRoomsMenuItem.Enabled=false;
                        _printRoomsListMenuItem.Enabled = false;
					}			
				}
			}
		}

		private void _courseMenuItem_Popup(object sender, System.EventArgs e)
		{
			checkWhatIsEnabledForCourse();			
		}

		private void checkWhatIsEnabledForCourse()
		{
			if(_courseMenuItem.Enabled)
			{
				if(_coursesTreeView!=null && _coursesTreeView.SelectedNode!=null)			
				{
					Course course = (Course)_coursesTreeView.SelectedNode;

                    if (course.getNumberOfLessonsPerWeek() <= 1) _scCourseMenuItem.Enabled = false;

					EduProgram ep = (EduProgram)course.Parent;
					if(ep.getIsCourseInTimetable(course))
					{
						_delCourseMenuItem.Enabled=false;
						_convertToGroupsMenuItem.Enabled=false;
					}
					else
					{
						_delCourseMenuItem.Enabled=true;
						if(!course.getIsGroup())
						{
							_convertToGroupsMenuItem.Enabled=true;
						}
						else
						{
                            _convertToGroupsMenuItem.Enabled=false;
						}
					}
				}
			}
		}

		private void _toolsMenuItem_Popup(object sender, System.EventArgs e)
		{
			if(IS_DOC_OPEN)
			{				
				//
                _autoTTMenuItem.Enabled = true;
			}
			else
			{             
				//
                _autoTTMenuItem.Enabled = false;
			}
		}

		public void updateTimeSlotPanel(int type,TreeNode selNode,bool newDraw)
		{
			if(newDraw)
			{
				_mainTimetablePanel.Controls.Clear();
			
				TimeSlotPanel tsp;

				for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
				{
					for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
					{
						tsp = new TimeSlotPanel(type,k*Settings.TIME_SLOT_PANEL_WIDTH,j*Settings.TIME_SLOT_PANEL_HEIGHT, j,k);
						if(type==1)
						{
							EduProgram ep=(EduProgram)selNode;
							if(ep!=null)
							{
								ArrayList [,] mytt = ep.getTimetable();

								ArrayList lessonsInOneTimeSlot = mytt[j,k];
								if(lessonsInOneTimeSlot!=null)
								{
									foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
									{							
										Course course = (Course)courseAndRoomPair[0];
										Room room = (Room)courseAndRoomPair[1];

										tsp.makeSubLabel(course,room);
									}
								}
							}
						}
						else
						{
							foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
							{
								foreach(EduProgram ep in epg.Nodes)
								{

									ArrayList [,] mytt = ep.getTimetable();
									ArrayList lessonsInOneTimeSlot = mytt[j,k];
									if(lessonsInOneTimeSlot!=null) 
									{
										foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
										{
											if(type==2)
											{
												if(selNode!=null)
												{
													Teacher teacher = (Teacher)selNode;
													Course course = (Course)courseAndRoomPair[0];
													Teacher teacherFromModel=course.getTeacher();	
													if(teacherFromModel==teacher)
													{
														Room room = (Room)courseAndRoomPair[1];
														tsp.makeSubLabel(course,room);
													}
												}

											}
											else if(type==3)
											{
												if(selNode!=null)
												{
													Room room = (Room)selNode;
													Room roomFromModel = (Room)courseAndRoomPair[1];
													if(roomFromModel==room)
													{											
														Course course = (Course)courseAndRoomPair[0];
														Teacher teacher=course.getTeacher();										
														tsp.makeSubLabel(course,teacher);
													}
												}

											}
										}
									}
								}
							}

						}
						
						this._mainTimetablePanel.Controls.Add(tsp);
					}
				}
			}
			else
			{
				foreach(TimeSlotPanel tsp in _mainTimetablePanel.Controls)
				{
					tsp.getAllSubLabels().Clear();
					tsp.Controls.Clear();
					tsp.Type=type;

					if(type==1)
					{
						EduProgram ep=(EduProgram)selNode;
						ArrayList [,] mytt = ep.getTimetable();

						ArrayList lessonsInOneTimeSlot = mytt[tsp.getIndexRow(),tsp.getIndexCol()];
						if(lessonsInOneTimeSlot!=null) 
						{
							foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
							{							
								Course course = (Course)courseAndRoomPair[0];
								Room room = (Room)courseAndRoomPair[1];

								tsp.makeSubLabel(course,room);
							}
						}
					}
					else
					{
						foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
						{
							foreach(EduProgram ep in epg.Nodes)
							{

								ArrayList [,] mytt = ep.getTimetable();
								ArrayList lessonsInOneTimeSlot = mytt[tsp.getIndexRow(),tsp.getIndexCol()];
								if(lessonsInOneTimeSlot!=null) 
								{
									foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
									{
										if(type==2)
										{
											Teacher teacher = (Teacher)selNode;
											Course course = (Course)courseAndRoomPair[0];
											Teacher teacherFromModel=course.getTeacher();	
											if(teacherFromModel==teacher)
											{
												Room room = (Room)courseAndRoomPair[1];
												tsp.makeSubLabel(course,room);
											}									

										}
										else if(type==3)
										{
											Room room = (Room)selNode;
											Room roomFromModel = (Room)courseAndRoomPair[1];
											if(roomFromModel==room)
											{											
												Course course = (Course)courseAndRoomPair[0];
												Teacher teacher=course.getTeacher();										
												tsp.makeSubLabel(course,teacher);
											}

										}
									}
								}
							}
						}


					}


				}
			}

			

		}

		private void drawEmptyTimeSlotPanels()
		{
			
			TimeSlotPanel tsp;
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{
					tsp = new TimeSlotPanel(1,k*Settings.TIME_SLOT_PANEL_WIDTH,j*Settings.TIME_SLOT_PANEL_HEIGHT, j,k);
					
					this._mainTimetablePanel.Controls.Add(tsp);
				}
			}
			
		}

		private void _aboutMenuItem_Click(object sender, System.EventArgs e)
		{			
			MySplashForm sf= new MySplashForm(true);
			sf.ShowDialog();            
			sf.Dispose();
		}	


		private void _helpContentMenuItem_Click(object sender, System.EventArgs e)
		{
            showHelpContent();            		
		}
		private void showHelpContent()
		{
			MessageBox.Show("Not implemented yet!");            
		}		

		private void tv_DoubleClick(object sender, EventArgs e)
		{
			TreeView tv=(TreeView)sender;
			TreeNode tn = (TreeNode)tv.SelectedNode;
			if (tn is Course)
			{
				Course course = (Course)tn;
                showCourseProperties(course);
			}			
			else if(tn is Room)
			{
				Room room = (Room)tn;
				showRoomProperties(room);
			}
			else if(tn is Teacher)
			{
				Teacher teacher =(Teacher)tn;
				showTeacherProperties(teacher);
			}
		}

		private void _courseConvertToGroupsMenuItem_Click(object sender, System.EventArgs e)
		{	
			Course course = (Course)_coursesTreeView.SelectedNode;
			CourseConversionToGroupForm cptgf= new CourseConversionToGroupForm(course);
			cptgf.ShowDialog(this);

			if (cptgf.DialogResult == DialogResult.OK)
			{				
				ConvertStandardCourseToGroupsCmd cpgCmd= new ConvertStandardCourseToGroupsCmd(course,cptgf.AllTextBox,cptgf.NumberOfGroups);
				_cmdProcessor.doCmd(cpgCmd);
			}

            cptgf.Dispose();
		}

		

		public void updateFormRelatedStrings()
		{

			// different strings
			this._printChoiceEPMenuItem.Text = RES_MANAGER.GetString("_printChoiceEPMenuItem.Text");
			this._addEPGMenuItem.Text = RES_MANAGER.GetString("_addEPGMenuItem.Text");
			this._epgMenuItem.Text = RES_MANAGER.GetString("_epgMenuItem.Text");
			this._epgPropertiesMenuItem.Text = RES_MANAGER.GetString("_epgPropertiesMenuItem.Text");
			this._addEPMenuItem.Text = RES_MANAGER.GetString("_addEPMenuItem.Text");
			this._delEPGMenuItem.Text = RES_MANAGER.GetString("_delEPGMenuItem.Text");
			this._epgPrintTTForAllEPsMenuItem.Text = RES_MANAGER.GetString("_epgPrintTTForAllEPsMenuItem.Text");
			this._epMenuItem.Text = RES_MANAGER.GetString("_epMenuItem.Text");
			this._epPropertiesMenuItem.Text = RES_MANAGER.GetString("_epPropertiesMenuItem.Text");			
			this._delEPMenuItem.Text = RES_MANAGER.GetString("_delEPMenuItem.Text");
			this._epPrintTTMenuItem.Text = RES_MANAGER.GetString("_epPrintTTMenuItem.Text");

			//common strings
			this._fileMenuItem.Text = RES_MANAGER.GetString("_fileMenuItem.Text");
			this._newDocMenuItem.Text = RES_MANAGER.GetString("_newDocMenuItem.Text");
			this._openDocMenuItem.Text = RES_MANAGER.GetString("_openDocMenuItem.Text");
			this._saveDocMenuItem.Text = RES_MANAGER.GetString("_saveDocMenuItem.Text");
			this._saveAsDocMenuItem.Text = RES_MANAGER.GetString("_saveAsDocMenuItem.Text");
			this._closeDocMenuItem.Text = RES_MANAGER.GetString("_closeDocMenuItem.Text");
			this._printTimetableMenuItem.Text = RES_MANAGER.GetString("_printTimetableMenuItem.Text");		
			this._printChoiceTeacherMenuItem.Text = RES_MANAGER.GetString("_printChoiceTeacherMenuItem.Text");
			this._printChoiceRoomMenuItem.Text = RES_MANAGER.GetString("_printChoiceRoomMenuItem.Text");
            this._printMasterTimetableMenuItem.Text = RES_MANAGER.GetString("_printMasterTimetableMenuItem.Text");
			this._exitAppMenuItem.Text = RES_MANAGER.GetString("_exitAppMenuItem.Text");			

			this._docMenuItem.Text = RES_MANAGER.GetString("_docMenuItem.Text");
			this._addTeacherMenuItem.Text = RES_MANAGER.GetString("_addTeacherMenuItem.Text");
			this._delAllTeachersMenuItem.Text = RES_MANAGER.GetString("_delAllTeachersMenuItem.Text");
			this._printTimetableAllTeachersMenuItem.Text = RES_MANAGER.GetString("_printTimetableAllTeachersMenuItem.Text");
            this._printTeacherListMenuItem.Text = RES_MANAGER.GetString("_printTeacherListMenuItem.Text");
            this._printTeacherHoursMenuItem.Text = RES_MANAGER.GetString("_printTeacherHoursMenuItem.Text");
			this._addRoomMenuItem.Text = RES_MANAGER.GetString("_addRoomMenuItem.Text");
			this._delAllRoomsMenuItem.Text = RES_MANAGER.GetString("_delAllRoomsMenuItem.Text");
			this._printTimetableAllRoomsMenuItem.Text = RES_MANAGER.GetString("_printTimetableAllRoomsMenuItem.Text");
            this._printRoomsListMenuItem.Text = RES_MANAGER.GetString("_printRoomsListMenuItem.Text");

			this._addDaysMenuItem.Text=RES_MANAGER.GetString("addNewDayMenuItem.Text");
			this._addTermMenuItem.Text=RES_MANAGER.GetString("addNewTermMenuItem.Text");

            this._autoTTDocMenuItem.Text = RES_MANAGER.GetString("_autoTTMenuItem.Text");
            this._scBaseTeachersMenuItem.Text = RES_MANAGER.GetString("_scBaseTeachersMenuItem.Text");
            this._scBaseEPMenuItem.Text = RES_MANAGER.GetString("_scBaseEPMenuItem.Text");
            this._scBaseCoursesMenuItem.Text = RES_MANAGER.GetString("_scBaseCoursesMenuItem.Text");
                        

			this._docPropertiesMenuItem.Text = RES_MANAGER.GetString("_docPropertiesMenuItem.Text");
			this._searchMenuItem.Text = RES_MANAGER.GetString("_searchMenuItem.Text");			
			
			this._epgATSMenuItem.Text = RES_MANAGER.GetString("_epgATSMenuItem.Text");
			
			this._addCourseMenuItem.Text = RES_MANAGER.GetString("_addCourseMenuItem.Text");
			this._addCourseFromClipboardMenuItem.Text = RES_MANAGER.GetString("_addCourseFromClipboardMenuItem.Text");
			this._epATSMenuItem.Text = RES_MANAGER.GetString("_epATSMenuItem.Text");
			this._clearTimetableMenuItem.Text = RES_MANAGER.GetString("_clearTimetableMenuItem.Text");
			this._epDelAllMyCoursesMenuItem.Text = RES_MANAGER.GetString("_epDelAllMyCoursesMenuItem.Text");
            this._autoTTEPMenuItem.Text = RES_MANAGER.GetString("_autoTTMenuItem.Text");
            this._scEduProgramMenuItem.Text = RES_MANAGER.GetString("_scEduProgramMenuItem.Text");
            
			
			this._courseMenuItem.Text = RES_MANAGER.GetString("_courseMenuItem.Text");
			this._coursePropertiesMenuItem.Text = RES_MANAGER.GetString("_coursePropertiesMenuItem.Text");
			this._courseRoomsRestrictionMenuItem.Text = RES_MANAGER.GetString("_courseRoomsRestrictionMenuItem.Text");
			this._coursesToHoldTogetherMenuItem.Text = RES_MANAGER.GetString("_coursesToHoldTogetherMenuItem.Text");
			this._convertToGroupsMenuItem.Text = RES_MANAGER.GetString("_convertToGroupsMenuItem.Text");
			this._delCourseMenuItem.Text = RES_MANAGER.GetString("_delCourseMenuItem.Text");
			this._courseStoreToClipboardMenuItem.Text = RES_MANAGER.GetString("_courseStoreToClipboardMenuItem.Text");
            this._autoTTCourseMenuItem.Text = RES_MANAGER.GetString("_autoTTMenuItem.Text");
            this._scCourseMenuItem.Text = RES_MANAGER.GetString("_scCourseMenuItem.Text");


			this._teacherMenuItem.Text = RES_MANAGER.GetString("_teacherMenuItem.Text");
			this._teacherPropertiesMenuItem.Text = RES_MANAGER.GetString("_teacherPropertiesMenuItem.Text");
			this._teacherATSMenuItem.Text = RES_MANAGER.GetString("_teacherATSMenuItem.Text");
			this._teacherRoomsRestrictionMenuItem.Text = RES_MANAGER.GetString("_teacherRoomsRestrictionMenuItem.Text");
			this._delTeacherMenuItem.Text = RES_MANAGER.GetString("_delTeacherMenuItem.Text");
			this._teacherPrintTTMenuItem.Text = RES_MANAGER.GetString("_teacherPrintTTMenuItem.Text");
            this._autoTTTeacherMenuItem.Text = RES_MANAGER.GetString("_autoTTMenuItem.Text");
            this._scTeacherMenuItem.Text = RES_MANAGER.GetString("_scTeacherMenuItem.Text");
            

			this._roomMenuItem.Text = RES_MANAGER.GetString("_roomMenuItem.Text");
			this._roomPropertiesMenuItem.Text = RES_MANAGER.GetString("_roomPropertiesMenuItem.Text");
			this._roomATSMenuItem.Text = RES_MANAGER.GetString("_roomATSMenuItem.Text");
			this._delRoomMenuItem.Text = RES_MANAGER.GetString("_delRoomMenuItem.Text");
			this._roomPrintTTMenuItem.Text = RES_MANAGER.GetString("_roomPrintTTMenuItem.Text");

			this._toolsMenuItem.Text = RES_MANAGER.GetString("_toolsMenuItem.Text");

			this._settingsMenuItem.Text = RES_MANAGER.GetString("_settingsMenuItem.Text");

			this._helpMenuItem.Text = RES_MANAGER.GetString("_helpMenuItem.Text");
			this._helpContentMenuItem.Text = RES_MANAGER.GetString("_helpContentMenuItem.Text");

			this._aboutMenuItem.Text = RES_MANAGER.GetString("_aboutMenuItem.Text");
			

			this._newDocToolBarButton.ToolTipText = RES_MANAGER.GetString("_newDocToolBarButton.ToolTipText");
			this._openDocToolBarButton.ToolTipText = RES_MANAGER.GetString("_openDocToolBarButton.ToolTipText");
			this._saveDocToolBarButton.ToolTipText = RES_MANAGER.GetString("_saveDocToolBarButton.ToolTipText");
			this._closeDocToolBarButton.ToolTipText = RES_MANAGER.GetString("_closeDocToolBarButton.ToolTipText");
			this._undoToolBarButton.ToolTipText = RES_MANAGER.GetString("_undoToolBarButton.ToolTipText");
			this._redoToolBarButton.ToolTipText = RES_MANAGER.GetString("_redoToolBarButton.ToolTipText");
			this._searchToolBarButton.ToolTipText = RES_MANAGER.GetString("_searchToolBarButton.ToolTipText");
			this._printToolBarButton.ToolTipText = RES_MANAGER.GetString("_printToolBarButton.ToolTipText");
			this._helpToolBarButton.ToolTipText = RES_MANAGER.GetString("_helpToolBarButton.ToolTipText");

		}


		public void updateOpenDocumentRelatedStrings()
		{
			_coursesTab.Text = RES_MANAGER.GetString("_coursesTab.Text");
			_columnHeaderULLVTeachers2.Text = RES_MANAGER.GetString("_columnHeaderULLVTeachers2.Text");
			_columnHeaderULLVTeachers3.Text = RES_MANAGER.GetString("_columnHeaderULLVTeachers3.Text");


			_teachersTab.Text = RES_MANAGER.GetString("_teachersTab.Text");
			_roomsTab.Text = RES_MANAGER.GetString("_roomsTab.Text");

			_columnHeaderULLVCourses1.Text = RES_MANAGER.GetString("_columnHeaderULLVCourses1.Text");
			_columnHeaderULLVCourses2.Text = RES_MANAGER.GetString("_columnHeaderULLVCourses2.Text");

			_columnHeaderULLVTeachers1.Text = RES_MANAGER.GetString("_columnHeaderULLVTeachers1.Text");
			
		}
		

		public static void setResourceManager()
		{
			if(!IS_DOC_OPEN)
			{
				if(Settings.DEFAULT_GUI_TEXT_TYPE==Constants.OCTT_DOC_TYPE_UNIVERSITY)
				{	
					RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.AppFormUniversity",typeof (AppForm).Assembly);
				}
				else
				{				
					RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.AppFormSchool",typeof (AppForm).Assembly);
				}
			}
			else
			{
				if(CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
				{				
					RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.AppFormUniversity",typeof (AppForm).Assembly);

				}
				else
				{			
					RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.AppFormSchool",typeof (AppForm).Assembly);
				}

			}
		}

		private void _addDaysMenuItem_Click(object sender, System.EventArgs e)
		{
			AddDaysForm adf= new AddDaysForm();
			adf.ShowDialog(AppForm.getAppForm());

			if (adf.DialogResult == DialogResult.OK)
			{
				ArrayList tempList = new ArrayList();
				for(int n=0;n<7;n++)
				{
					if(((CheckBox)adf.getGroup().Controls[n]).Checked==true && ((CheckBox)adf.getGroup().Controls[n]).Enabled==true)
					{
						tempList.Add(n);
					}
				}

				AddDaysCmd adsCmd= new AddDaysCmd(tempList,true);
				CommandProcessor.getCommandProcessor().doCmd(adsCmd);
			
			}
		
		}

		private void _addTermMenuItem_Click(object sender, System.EventArgs e)
		{
			AddTermForm tpf= new AddTermForm(true,null);
			tpf.ShowDialog(AppForm.getAppForm());

			if (tpf.DialogResult == DialogResult.OK)
			{
				int index = tpf.getPosOfNewTerm();
				int [] termData = tpf.getNewTermData();

				AddTermCmd atdCmd= new AddTermCmd(index,termData, true);
				CommandProcessor.getCommandProcessor().doCmd(atdCmd);				
			}
		}

        private void _autoTTMenuItem_Click(object sender, EventArgs e)
        {
            AutomatedTTForm attf = new AutomatedTTForm();
            attf.ShowDialog(this);
            attf.Dispose();
        }

        public CommandProcessor getCommandProcessor()
        {
            return _cmdProcessor;
        }

        private void softConsBaseTeachersMenuItem_Click(object sender, EventArgs e)
        {
            SoftConsTeachersBaseSettingsForm sctsf = new SoftConsTeachersBaseSettingsForm();
            sctsf.ShowDialog(this);

            if (sctsf.DialogResult == DialogResult.OK)
            {
                ChangeSoftConsTeachersBaseSettingsCmd csctbsCmd = new ChangeSoftConsTeachersBaseSettingsCmd(sctsf.MaxHContinuously, sctsf.MaxHDaily, sctsf.MaxDaysPerWeek);
                _cmdProcessor.doCmd(csctbsCmd);
            }

            sctsf.Dispose();


        }

        private void softConsTeacherMenuItem_Click(object sender, EventArgs e)
        {
            Teacher teacher = (Teacher)_teachersTreeView.SelectedNode;

            SoftConsTeacherSettingsForm sctsf = new SoftConsTeacherSettingsForm(teacher);
            sctsf.ShowDialog(this);

            if (sctsf.DialogResult == DialogResult.OK)
            {
                ChangeSoftConsTeacherSettingsCmd csctsCmd = new ChangeSoftConsTeacherSettingsCmd(teacher, sctsf.SCMaxHoursContinouslyNewVal, sctsf.SCMaxHoursDailyNewVal, sctsf.SCMaxDaysPerWeekNewVal);
                _cmdProcessor.doCmd(csctsCmd);
            }

            sctsf.Dispose();
        }

        private void softConsBaseEPMenuItem_Click(object sender, EventArgs e)
        {
            SoftConsEPBaseSettingsForm scbepsf = new SoftConsEPBaseSettingsForm();
            scbepsf.ShowDialog(this);

            if (scbepsf.DialogResult == DialogResult.OK)
            {
                ChangeSoftConsEPBaseSettingsCmd cscepbsCmd = new ChangeSoftConsEPBaseSettingsCmd(scbepsf.MaxHContinuously, scbepsf.MaxHDaily, scbepsf.MaxDaysPerWeek, scbepsf.NoGapsGapIndicator, scbepsf.PreferredStartTimePeriod);
                _cmdProcessor.doCmd(cscepbsCmd);
            }

            scbepsf.Dispose();            
        }

        private void softConsEPMenuItem_Click(object sender, EventArgs e)
        {
            EduProgram ep = (EduProgram)_coursesTreeView.SelectedNode;

            SoftConsEPSettingsForm scepsf = new SoftConsEPSettingsForm(ep);
            scepsf.ShowDialog(this);

            if (scepsf.DialogResult == DialogResult.OK)
            {
                ChangeSoftConsEPSettingsCmd cscepsCmd = new ChangeSoftConsEPSettingsCmd(ep, scepsf.SCMaxHoursContinouslyNewVal, scepsf.SCMaxHoursDailyNewVal, scepsf.SCMaxDaysPerWeekNewVal, scepsf.SCGapIndicatorNewVal, scepsf.SCPreferredStartTimePeriod);
                _cmdProcessor.doCmd(cscepsCmd);
            }

            scepsf.Dispose();            
        }

        private void softConsBaseCoursesMenuItem_Click(object sender, EventArgs e)
        {
            SoftConsCoursesBaseSettingsForm sccbsf = new SoftConsCoursesBaseSettingsForm();
            sccbsf.ShowDialog(this);

            if (sccbsf.DialogResult == DialogResult.OK)
            {
                ChangeSoftConsCoursesBaseSettingsCmd csccbsCmd = new ChangeSoftConsCoursesBaseSettingsCmd(sccbsf.NewCoursesLessonsBlocksHT);
                _cmdProcessor.doCmd(csccbsCmd);
            }

            sccbsf.Dispose();
        }

        private void softConsCourseMenuItem_Click(object sender, EventArgs e)
        {
            Course course = (Course)_coursesTreeView.SelectedNode;

            SoftConsCourseSettingsForm sccsf = new SoftConsCourseSettingsForm(course);
            sccsf.ShowDialog(this);

            if (sccsf.DialogResult == DialogResult.OK)
            {
                course.SCLessonBlocksParameters = sccsf.SCCourseLessonBlocksNewVal;
            }

            sccsf.Dispose();            

        }

        private void _printMasterTimetableMenuItem_Click(object sender, EventArgs e)
        {            
            DataTable pdfReportMasterTimetableDataTable= ModelOperations.getPdfSharpMasterTimetableDataTable();
            PdfCreatorMasterTimetable.createPdfDocument(pdfReportMasterTimetableDataTable);
        }
        		
	}

	
}
