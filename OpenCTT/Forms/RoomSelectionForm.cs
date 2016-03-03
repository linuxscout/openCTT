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
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for RoomSelectionForm.
	/// </summary>
	public class RoomSelectionForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private Room _currRoom;
		private Label _roomLabel;
		private Object [] _courseAndRoomPair;
		private System.Windows.Forms.ListBox _roomsListBox;
		private System.Windows.Forms.Label _courseLabel;
		private System.Windows.Forms.Label _numOfEnrolledStudentsLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RoomSelectionForm(Label roomLabel,ArrayList possibleRooms, Room currRoom,Course currCourse,Object [] courseAndRoomPair)
		{			
			InitializeComponent();

			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.RoomSelectionForm",this.GetType().Assembly);
			}

			_currRoom=currRoom;

			_roomLabel = roomLabel;
			_courseAndRoomPair=courseAndRoomPair;
			
			foreach(Room tempRoom in possibleRooms)
			{
				_roomsListBox.Items.Add(tempRoom);
			}

			_roomsListBox.SelectedItem=currRoom;
	
			_courseLabel.Text+=" "+currCourse.getName();
			if(currCourse.getIsGroup())
			{			
				_courseLabel.Text+=" "+RES_MANAGER.GetString("_courseLabel.group.text")+" "+currCourse.getGroupName();
			}
			int numOfEnrStudents = currCourse.getNumberOfEnrolledStudents();
			if(currCourse.getCoursesToHoldTogetherList().Count>0)
			{
				foreach(Course course in currCourse.getCoursesToHoldTogetherList())
				{
					numOfEnrStudents+=course.getNumberOfEnrolledStudents();
				}
			}

			_numOfEnrolledStudentsLabel.Text+=" "+numOfEnrStudents.ToString();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RoomSelectionForm));
			this._roomsListBox = new System.Windows.Forms.ListBox();
			this._courseLabel = new System.Windows.Forms.Label();
			this._numOfEnrolledStudentsLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _roomsListBox
			// 
			this._roomsListBox.AccessibleDescription = resources.GetString("_roomsListBox.AccessibleDescription");
			this._roomsListBox.AccessibleName = resources.GetString("_roomsListBox.AccessibleName");
			this._roomsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_roomsListBox.Anchor")));
			this._roomsListBox.BackColor = System.Drawing.Color.Gainsboro;
			this._roomsListBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_roomsListBox.BackgroundImage")));
			this._roomsListBox.ColumnWidth = ((int)(resources.GetObject("_roomsListBox.ColumnWidth")));
			this._roomsListBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_roomsListBox.Dock")));
			this._roomsListBox.Enabled = ((bool)(resources.GetObject("_roomsListBox.Enabled")));
			this._roomsListBox.Font = ((System.Drawing.Font)(resources.GetObject("_roomsListBox.Font")));
			this._roomsListBox.HorizontalExtent = ((int)(resources.GetObject("_roomsListBox.HorizontalExtent")));
			this._roomsListBox.HorizontalScrollbar = ((bool)(resources.GetObject("_roomsListBox.HorizontalScrollbar")));
			this._roomsListBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_roomsListBox.ImeMode")));
			this._roomsListBox.IntegralHeight = ((bool)(resources.GetObject("_roomsListBox.IntegralHeight")));
			this._roomsListBox.ItemHeight = ((int)(resources.GetObject("_roomsListBox.ItemHeight")));
			this._roomsListBox.Location = ((System.Drawing.Point)(resources.GetObject("_roomsListBox.Location")));
			this._roomsListBox.Name = "_roomsListBox";
			this._roomsListBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_roomsListBox.RightToLeft")));
			this._roomsListBox.ScrollAlwaysVisible = ((bool)(resources.GetObject("_roomsListBox.ScrollAlwaysVisible")));
			this._roomsListBox.Size = ((System.Drawing.Size)(resources.GetObject("_roomsListBox.Size")));
			this._roomsListBox.Sorted = true;
			this._roomsListBox.TabIndex = ((int)(resources.GetObject("_roomsListBox.TabIndex")));
			this._roomsListBox.Visible = ((bool)(resources.GetObject("_roomsListBox.Visible")));
			this._roomsListBox.DoubleClick += new System.EventHandler(this._roomsListBox_DoubleClick);
			this._roomsListBox.SelectedIndexChanged += new System.EventHandler(this._roomsListBox_SelectedIndexChanged);
			// 
			// _courseLabel
			// 
			this._courseLabel.AccessibleDescription = resources.GetString("_courseLabel.AccessibleDescription");
			this._courseLabel.AccessibleName = resources.GetString("_courseLabel.AccessibleName");
			this._courseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_courseLabel.Anchor")));
			this._courseLabel.AutoSize = ((bool)(resources.GetObject("_courseLabel.AutoSize")));
			this._courseLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_courseLabel.Dock")));
			this._courseLabel.Enabled = ((bool)(resources.GetObject("_courseLabel.Enabled")));
			this._courseLabel.Font = ((System.Drawing.Font)(resources.GetObject("_courseLabel.Font")));
			this._courseLabel.Image = ((System.Drawing.Image)(resources.GetObject("_courseLabel.Image")));
			this._courseLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_courseLabel.ImageAlign")));
			this._courseLabel.ImageIndex = ((int)(resources.GetObject("_courseLabel.ImageIndex")));
			this._courseLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_courseLabel.ImeMode")));
			this._courseLabel.Location = ((System.Drawing.Point)(resources.GetObject("_courseLabel.Location")));
			this._courseLabel.Name = "_courseLabel";
			this._courseLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_courseLabel.RightToLeft")));
			this._courseLabel.Size = ((System.Drawing.Size)(resources.GetObject("_courseLabel.Size")));
			this._courseLabel.TabIndex = ((int)(resources.GetObject("_courseLabel.TabIndex")));
			this._courseLabel.Text = resources.GetString("_courseLabel.Text");
			this._courseLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_courseLabel.TextAlign")));
			this._courseLabel.Visible = ((bool)(resources.GetObject("_courseLabel.Visible")));
			// 
			// _numOfEnrolledStudentsLabel
			// 
			this._numOfEnrolledStudentsLabel.AccessibleDescription = resources.GetString("_numOfEnrolledStudentsLabel.AccessibleDescription");
			this._numOfEnrolledStudentsLabel.AccessibleName = resources.GetString("_numOfEnrolledStudentsLabel.AccessibleName");
			this._numOfEnrolledStudentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_numOfEnrolledStudentsLabel.Anchor")));
			this._numOfEnrolledStudentsLabel.AutoSize = ((bool)(resources.GetObject("_numOfEnrolledStudentsLabel.AutoSize")));
			this._numOfEnrolledStudentsLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_numOfEnrolledStudentsLabel.Dock")));
			this._numOfEnrolledStudentsLabel.Enabled = ((bool)(resources.GetObject("_numOfEnrolledStudentsLabel.Enabled")));
			this._numOfEnrolledStudentsLabel.Font = ((System.Drawing.Font)(resources.GetObject("_numOfEnrolledStudentsLabel.Font")));
			this._numOfEnrolledStudentsLabel.Image = ((System.Drawing.Image)(resources.GetObject("_numOfEnrolledStudentsLabel.Image")));
			this._numOfEnrolledStudentsLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_numOfEnrolledStudentsLabel.ImageAlign")));
			this._numOfEnrolledStudentsLabel.ImageIndex = ((int)(resources.GetObject("_numOfEnrolledStudentsLabel.ImageIndex")));
			this._numOfEnrolledStudentsLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_numOfEnrolledStudentsLabel.ImeMode")));
			this._numOfEnrolledStudentsLabel.Location = ((System.Drawing.Point)(resources.GetObject("_numOfEnrolledStudentsLabel.Location")));
			this._numOfEnrolledStudentsLabel.Name = "_numOfEnrolledStudentsLabel";
			this._numOfEnrolledStudentsLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_numOfEnrolledStudentsLabel.RightToLeft")));
			this._numOfEnrolledStudentsLabel.Size = ((System.Drawing.Size)(resources.GetObject("_numOfEnrolledStudentsLabel.Size")));
			this._numOfEnrolledStudentsLabel.TabIndex = ((int)(resources.GetObject("_numOfEnrolledStudentsLabel.TabIndex")));
			this._numOfEnrolledStudentsLabel.Text = resources.GetString("_numOfEnrolledStudentsLabel.Text");
			this._numOfEnrolledStudentsLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_numOfEnrolledStudentsLabel.TextAlign")));
			this._numOfEnrolledStudentsLabel.Visible = ((bool)(resources.GetObject("_numOfEnrolledStudentsLabel.Visible")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// _okButton
			// 
			this._okButton.AccessibleDescription = resources.GetString("_okButton.AccessibleDescription");
			this._okButton.AccessibleName = resources.GetString("_okButton.AccessibleName");
			this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_okButton.Anchor")));
			this._okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_okButton.BackgroundImage")));
			this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._okButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_okButton.Dock")));
			this._okButton.Enabled = ((bool)(resources.GetObject("_okButton.Enabled")));
			this._okButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_okButton.FlatStyle")));
			this._okButton.Font = ((System.Drawing.Font)(resources.GetObject("_okButton.Font")));
			this._okButton.Image = ((System.Drawing.Image)(resources.GetObject("_okButton.Image")));
			this._okButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_okButton.ImageAlign")));
			this._okButton.ImageIndex = ((int)(resources.GetObject("_okButton.ImageIndex")));
			this._okButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_okButton.ImeMode")));
			this._okButton.Location = ((System.Drawing.Point)(resources.GetObject("_okButton.Location")));
			this._okButton.Name = "_okButton";
			this._okButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_okButton.RightToLeft")));
			this._okButton.Size = ((System.Drawing.Size)(resources.GetObject("_okButton.Size")));
			this._okButton.TabIndex = ((int)(resources.GetObject("_okButton.TabIndex")));
			this._okButton.Text = resources.GetString("_okButton.Text");
			this._okButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_okButton.TextAlign")));
			this._okButton.Visible = ((bool)(resources.GetObject("_okButton.Visible")));
			// 
			// _cancelButton
			// 
			this._cancelButton.AccessibleDescription = resources.GetString("_cancelButton.AccessibleDescription");
			this._cancelButton.AccessibleName = resources.GetString("_cancelButton.AccessibleName");
			this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_cancelButton.Anchor")));
			this._cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_cancelButton.BackgroundImage")));
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_cancelButton.Dock")));
			this._cancelButton.Enabled = ((bool)(resources.GetObject("_cancelButton.Enabled")));
			this._cancelButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_cancelButton.FlatStyle")));
			this._cancelButton.Font = ((System.Drawing.Font)(resources.GetObject("_cancelButton.Font")));
			this._cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("_cancelButton.Image")));
			this._cancelButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_cancelButton.ImageAlign")));
			this._cancelButton.ImageIndex = ((int)(resources.GetObject("_cancelButton.ImageIndex")));
			this._cancelButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_cancelButton.ImeMode")));
			this._cancelButton.Location = ((System.Drawing.Point)(resources.GetObject("_cancelButton.Location")));
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_cancelButton.RightToLeft")));
			this._cancelButton.Size = ((System.Drawing.Size)(resources.GetObject("_cancelButton.Size")));
			this._cancelButton.TabIndex = ((int)(resources.GetObject("_cancelButton.TabIndex")));
			this._cancelButton.Text = resources.GetString("_cancelButton.Text");
			this._cancelButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_cancelButton.TextAlign")));
			this._cancelButton.Visible = ((bool)(resources.GetObject("_cancelButton.Visible")));
			// 
			// RoomSelectionForm
			// 
			this.AcceptButton = this._okButton;
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this._cancelButton;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._numOfEnrolledStudentsLabel);
			this.Controls.Add(this._courseLabel);
			this.Controls.Add(this._roomsListBox);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximizeBox = false;
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimizeBox = false;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "RoomSelectionForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.ResumeLayout(false);

		}
		#endregion		

		public Room getSelectedRoom()
		{
			Room room = (Room)_roomsListBox.SelectedItem;
			return room;
		}

		private void _roomsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_roomsListBox.SelectedItem!=_currRoom)
			{
                _okButton.Enabled=true;
			}
			else
			{
                _okButton.Enabled=false;
			}
		
		}

		

		private void _roomsListBox_DoubleClick(object sender, System.EventArgs e)
		{
			if(_okButton.Enabled)
			{
				this.DialogResult=DialogResult.OK;
			}			
		}
	}
}
