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

namespace OpenCTT
{
	/// <summary>
	/// Summary description for ChangeRoomDataCmd.
	/// </summary>
	public class ChangeRoomDataCmd:AbstractCommand
	{
		private Room _room;

		private string _oldName;
		private string _oldExtID;
		private int _oldCapacity;
		
		private string _newName;
		private string _newExtID;
		private int _newCapacity;
	
		public ChangeRoomDataCmd(Room room, string newName,int newCapacity, string newExtID)
		{
			_room=room;
			_oldName=_room.getName();
			_oldExtID=_room.ExtID;
			_oldCapacity=_room.getRoomCapacity();

			_newName=newName;
			_newCapacity=newCapacity;
			_newExtID=newExtID;
		}

		public override void doit()
		{
			_room.setName(_newName);
			_room.setRoomCapacity(_newCapacity);	
			_room.ExtID=_newExtID;

			sortIt();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
		}

		public override void undo()
		{
			_room.setName(_oldName);
			_room.setRoomCapacity(_oldCapacity);	
			_room.ExtID=_oldExtID;

			sortIt();

			AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
			
		}

		public override void redo()
		{
			doit();			
		}

		private void sortIt()
		{			
			AppForm.getAppForm().getRoomsTreeView().BeginUpdate();
			AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Remove(_room);
			AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes.Add(_room);
			AppForm.getAppForm().getRoomsTreeView().SelectedNode=_room;
			AppForm.getAppForm().getRoomsTreeView().EndUpdate();

		}
	}
}
