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
using System.Collections;
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for TermLabel.
	/// </summary>
	public class TermLabel:System.Windows.Forms.Label
	{
		private static ResourceManager RES_MANAGER;	

		private int _index;
		private string _text;

		private ContextMenu _labelContextMenu;

		public TermLabel(int x, int y, String text,int index)
		{
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.TermLabel",this.GetType().Assembly);
			}

			_text=text;
			_index=index;

			this.Text=text;			

			this.Size=new System.Drawing.Size(Constants.DAY_HOUR_PANEL_WIDTH,Settings.TIME_SLOT_PANEL_HEIGHT);

			this.Location=new System.Drawing.Point(x,y);

			this.BackColor=System.Drawing.Color.Ivory;

			
			this.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;	

			_labelContextMenu = new ContextMenu();
			this.ContextMenu=_labelContextMenu;			

			_labelContextMenu.Popup += new System.EventHandler(this._labelContextMenu_Popup);

			this.MouseEnter += new System.EventHandler(this.thisLabel_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.thisLabel_MouseLeave);

		}

		private void _labelContextMenu_Popup(object sender, System.EventArgs e)
		{
	
			_labelContextMenu.MenuItems.Clear();
			
			MenuItem menuItem1 = new MenuItem(RES_MANAGER.GetString("_labelContextMenu_Popup.delTermMI.Text1")+" '"+_text+"' "+RES_MANAGER.GetString("_labelContextMenu_Popup.delTermMI.Text2"));

			menuItem1.Click += new System.EventHandler(this.delTerm_Click);
			_labelContextMenu.MenuItems.Add(menuItem1);		

		}

		private void thisLabel_MouseEnter(object sender, System.EventArgs e)
		{
			
			this.BackColor=System.Drawing.SystemColors.GrayText;
			
		}

		private void thisLabel_MouseLeave(object sender, System.EventArgs e)
		{
			this.BackColor=System.Drawing.Color.Ivory;			
		}

		private void delTerm_Click(object sender, System.EventArgs e)
		{
			if(ModelOperations.checkIfTermIsEmpty(_index))
			{
				DeleteTermCmd dtCmd= new DeleteTermCmd(_index);
				CommandProcessor.getCommandProcessor().doCmd(dtCmd);				
			}
			else
			{	
				string message;

				if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
				{
					message = RES_MANAGER.GetString("delTerm_Click.msb.termnotdeleted.university.message");

				}
				else
				{
                    message = RES_MANAGER.GetString("delTerm_Click.msb.termnotdeleted.school.message");
				}
			
				string caption = RES_MANAGER.GetString("delTerm_Click.msb.termnotdeleted.caption");
				MessageBoxButtons buttons = MessageBoxButtons.OK;
		
				MessageBox.Show(this, message, caption, buttons,
					MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

			}
		}
	}
}
