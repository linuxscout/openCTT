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
using System.Windows.Forms;
using OCTTPluginInterface;

namespace OCTT_MySql_Plugin
{
	/// <summary>
	/// Summary description for OCTT_MySql_DBExportPlugin.
	/// </summary>
	public class OCTT_MySql_DBExportPlugin: IPlugin
	{
		string _hostMenuItemText="Export timetable to MySql database";
		MenuItem _hostMenuItemForActivation=null;
		int _enabledDisabledMIType=2;//menu item is enabled only if document is open 


		string _myName = "OCTT To MySql Export Plugin";
		string _myDescription = "This plugin exports OCTT timetable to MySql database";
		string _myAuthor = "Ivan Æurak";
		string _myVersion = "0.8.1";
		IPluginHost _myHost = null;
		
		System.Windows.Forms.Form _mainGUIForm;

		public OCTT_MySql_DBExportPlugin()
		{
			
		}	
        		
		public string Description
		{
			get {return _myDescription;}
		}
		
		public string Author
		{
			get	{return _myAuthor;}		
		}
		
		public IPluginHost Host
		{			
			get {return _myHost;}
			set	{_myHost = value;}
		}

		public string Name
		{
			get {return _myName;}
		}

		public System.Windows.Forms.Form MainGUIForm
		{
			get {return _mainGUIForm;}
		}

		public string Version
		{
			get	{return _myVersion;}
		}

		public string MITextForHost
		{
			get
			{
				return _hostMenuItemText;
			}
		}

		public MenuItem HostMenuItemForActivation
		{
			get
			{
				return _hostMenuItemForActivation;
			}
			set
			{
				_hostMenuItemForActivation=value;
			}
		}		

		public int EnabledDisabledMIType
		{
			get
			{
				return _enabledDisabledMIType;
			}
		}

		
		public void Initialize()
		{
			_mainGUIForm= new OCTT_MySql_DBExportTTForm(this);			
		}
		
		public void Dispose()
		{
			_mainGUIForm=null;			
		}
	}
}
