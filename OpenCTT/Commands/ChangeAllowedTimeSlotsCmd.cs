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

namespace OpenCTT
{
	/// <summary>
	/// Summary description for ChangeAllowedTimeSlotsCmd.
	/// </summary>
	public class ChangeAllowedTimeSlotsCmd:AbstractCommand
	{
		private int _cmdType;
		private Object _workingObject;
		private bool [,] _oldAllowedTimeSlots; 
		private bool [,] _newAllowedTimeSlots;
		AllowedTimeSlotsForm _atsf;

		public ChangeAllowedTimeSlotsCmd(Object workingObject,int cmdType,AllowedTimeSlotsForm atsf)
		{
			_atsf=atsf;
			_cmdType=cmdType;
			_workingObject=workingObject;

			if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_TEACHER)
			{
				Teacher teacher = (Teacher)_workingObject;
				_oldAllowedTimeSlots=teacher.getAllowedTimeSlots();
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM)
			{
				EduProgram ep = (EduProgram)_workingObject;
				_oldAllowedTimeSlots=ep.getAllowedTimeSlots();				
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP)
			{
				EduProgramGroup epg = (EduProgramGroup)_workingObject;
				_oldAllowedTimeSlots = epg.getAllowedTimeSlots();
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_ROOM)
			{
				Room room = (Room)_workingObject;
				_oldAllowedTimeSlots=room.getAllowedTimeSlots();			
			}

			_newAllowedTimeSlots = (bool [,])_oldAllowedTimeSlots.Clone();

			foreach(Label edotlW in _atsf.getMainPanel().Controls)
			{
				if(edotlW.GetType().FullName=="OpenCTT.EnableDisableOneTermLabel")
				{
					EnableDisableOneTermLabel edotl =(EnableDisableOneTermLabel)edotlW;
												
					if(edotl.getIsTermEnabled())
					{
						_newAllowedTimeSlots[edotl.getIndexRow(),edotl.getIndexCol()]=true;
					}
					else
					{
						_newAllowedTimeSlots[edotl.getIndexRow(),edotl.getIndexCol()]=false;
					}										
				}
			}
			
		}

		public override void doit()
		{		

			if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_TEACHER)
			{
				Teacher teacher = (Teacher)_workingObject;
				teacher.setAllowedTimeSlots(_newAllowedTimeSlots);
				AppForm.getAppForm().getTeachersTreeView().SelectedNode=teacher;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM)
			{
				EduProgram ep = (EduProgram)_workingObject;
				ep.setAllowedTimeSlots(_newAllowedTimeSlots);
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=ep;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP)
			{
				EduProgramGroup epg = (EduProgramGroup)_workingObject;
				epg.setAllowedTimeSlots(_newAllowedTimeSlots);
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=epg;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_ROOM)
			{
				Room room = (Room)_workingObject;
				room.setAllowedTimeSlots(_newAllowedTimeSlots);
				AppForm.getAppForm().getRoomsTreeView().SelectedNode=room;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;	
			}		
			
		}

		public override void undo()
		{
			if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_TEACHER)
			{
				Teacher teacher = (Teacher)_workingObject;
				teacher.setAllowedTimeSlots(_oldAllowedTimeSlots);
				AppForm.getAppForm().getTeachersTreeView().SelectedNode=teacher;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM)
			{
				EduProgram ep = (EduProgram)_workingObject;
				ep.setAllowedTimeSlots(_oldAllowedTimeSlots);
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=ep;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP)
			{
				EduProgramGroup epg = (EduProgramGroup)_workingObject;
				epg.setAllowedTimeSlots(_oldAllowedTimeSlots);
				AppForm.getAppForm().getCoursesTreeView().SelectedNode=epg;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
			}
			else if(_cmdType==Constants.ATSF_TIME_SLOT_TYPE_ROOM)
			{
				Room room = (Room)_workingObject;
				room.setAllowedTimeSlots(_oldAllowedTimeSlots);
				AppForm.getAppForm().getRoomsTreeView().SelectedNode=room;
				AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;	
			}
			
		}

		public override void redo()
		{
			doit();			
		}
	}
}
