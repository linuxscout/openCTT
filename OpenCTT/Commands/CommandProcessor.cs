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

namespace OpenCTT
{
	/// <summary>
	/// Summary description for CommandProcessor.
	/// </summary>
	public class CommandProcessor
	{
		private AbstractCommand _lastSavedCmd;
		private Stack _doneStack, _undoneStack;		
		private int _maxStackSize;
		private static CommandProcessor COMMAND_PROCESSOR;


		public CommandProcessor()
		{
			_doneStack = new Stack();
			_undoneStack = new Stack();
			_maxStackSize = 51; //desired size + 1
			COMMAND_PROCESSOR=this;
		}

		public void doCmd(AbstractCommand cmd) 
		{			
			cmd.doit();
			_doneStack.Push(cmd);
			_undoneStack.Clear();

			if (_doneStack.Count== _maxStackSize) 
			{
				_doneStack=this.reduceStackSize(_doneStack);
			}

			setUnReButtonState();
					
		}

		public void undoLastCmd() 
		{
			if (_doneStack.Count!=0) 
			{
				AbstractCommand lastcmd = (AbstractCommand) _doneStack.Pop();
				lastcmd.undo();
				_undoneStack.Push(lastcmd);
				
				if (_undoneStack.Count== _maxStackSize) 
				{
					_undoneStack=this.reduceStackSize(_undoneStack);
				}
				
				setUnReButtonState();
			}
		}

		public void redoLastUndone() 
		{
			if (_undoneStack.Count!=0) 
			{				
				AbstractCommand last_undone_cmd = (AbstractCommand) _undoneStack.Pop();
				last_undone_cmd.redo();
				_doneStack.Push(last_undone_cmd);

				if (_doneStack.Count== _maxStackSize) 
				{
					_doneStack=this.reduceStackSize(_doneStack);
				}
			
				setUnReButtonState();
			}
		}

		public static CommandProcessor getCommandProcessor()
		{
			return COMMAND_PROCESSOR;
		}

		public AbstractCommand getLastCmdOnStack()
		{			
			if(_doneStack.Count>0)
			{
				return (AbstractCommand)_doneStack.Peek();				
			}else return null;
		}

		public AbstractCommand getLastSavedCmd()
		{
			return _lastSavedCmd;
		}

		public void setLastSavedCmd(AbstractCommand lsCmd)
		{
			_lastSavedCmd=lsCmd;
		}



		public void setUnReButtonState()
		{
			if(_doneStack.Count>0)
			{
				//AppForm.getAppForm().getUndoToolBarButton().Enabled=true;
				AppForm.getAppForm().getUndoToolBarButton().ImageIndex=4;
			}
			else
			{
				//AppForm.getAppForm().getUndoToolBarButton().Enabled=false;
				AppForm.getAppForm().getUndoToolBarButton().ImageIndex=11;

			}

			if(_undoneStack.Count>0)
			{
				//AppForm.getAppForm().getRedoToolBarButton().Enabled=true;
                AppForm.getAppForm().getRedoToolBarButton().ImageIndex=5;
			}
			else
			{
				//AppForm.getAppForm().getRedoToolBarButton().Enabled=false;
				AppForm.getAppForm().getRedoToolBarButton().ImageIndex=12;

			}

		}

		public void emptyAllStacks()
		{
			_undoneStack.Clear();
			_doneStack.Clear();
			_lastSavedCmd=null;
		}

		private Stack reduceStackSize(Stack oldStack)
		{			
			Stack newStack = new Stack();
			int stackCount=oldStack.Count;

			for(int n=1;n<stackCount;n++)
			{				
				AbstractCommand ac=(AbstractCommand)oldStack.Pop();
				newStack.Push(ac);				
			}

			return newStack;



		}

	}
}
