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
	/// Summary description for RoomsRestrictionForm.
	/// </summary>
	public class RoomsRestrictionForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ListBox _possibleRoomsListBox;
		private System.Windows.Forms.ListBox _choosedRoomsListBox;
		private System.Windows.Forms.Button _moveRightButton;
		private System.Windows.Forms.Button _moveLeftButton;
		
		private ArrayList _possibleRoomsFromModelList;
		private System.Windows.Forms.Label _topLabel;
		private System.Windows.Forms.Label _hideLabel;

		private int _numOfEnrStudents;
		private System.Windows.Forms.Label _possibleRoomsLabel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RoomsRestrictionForm(ArrayList possibleRoomsFromModelList, string labelText, int numOfEnrStudents)
		{			
			InitializeComponent();
							
			RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.RoomsRestrictionForm",this.GetType().Assembly);
			
            this.Text+=" "+RES_MANAGER.GetString("for.text")+" "+labelText;

			_numOfEnrStudents=numOfEnrStudents;

			_possibleRoomsFromModelList=possibleRoomsFromModelList;

			this.Closing += new CancelEventHandler(this.Form_Closing);

			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RoomsRestrictionForm));
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._possibleRoomsListBox = new System.Windows.Forms.ListBox();
			this._choosedRoomsListBox = new System.Windows.Forms.ListBox();
			this._moveRightButton = new System.Windows.Forms.Button();
			this._moveLeftButton = new System.Windows.Forms.Button();
			this._topLabel = new System.Windows.Forms.Label();
			this._hideLabel = new System.Windows.Forms.Label();
			this._possibleRoomsLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
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
			// _possibleRoomsListBox
			// 
			this._possibleRoomsListBox.AccessibleDescription = resources.GetString("_possibleRoomsListBox.AccessibleDescription");
			this._possibleRoomsListBox.AccessibleName = resources.GetString("_possibleRoomsListBox.AccessibleName");
			this._possibleRoomsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_possibleRoomsListBox.Anchor")));
			this._possibleRoomsListBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_possibleRoomsListBox.BackgroundImage")));
			this._possibleRoomsListBox.ColumnWidth = ((int)(resources.GetObject("_possibleRoomsListBox.ColumnWidth")));
			this._possibleRoomsListBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_possibleRoomsListBox.Dock")));
			this._possibleRoomsListBox.Enabled = ((bool)(resources.GetObject("_possibleRoomsListBox.Enabled")));
			this._possibleRoomsListBox.Font = ((System.Drawing.Font)(resources.GetObject("_possibleRoomsListBox.Font")));
			this._possibleRoomsListBox.HorizontalExtent = ((int)(resources.GetObject("_possibleRoomsListBox.HorizontalExtent")));
			this._possibleRoomsListBox.HorizontalScrollbar = ((bool)(resources.GetObject("_possibleRoomsListBox.HorizontalScrollbar")));
			this._possibleRoomsListBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_possibleRoomsListBox.ImeMode")));
			this._possibleRoomsListBox.IntegralHeight = ((bool)(resources.GetObject("_possibleRoomsListBox.IntegralHeight")));
			this._possibleRoomsListBox.ItemHeight = ((int)(resources.GetObject("_possibleRoomsListBox.ItemHeight")));
			this._possibleRoomsListBox.Location = ((System.Drawing.Point)(resources.GetObject("_possibleRoomsListBox.Location")));
			this._possibleRoomsListBox.Name = "_possibleRoomsListBox";
			this._possibleRoomsListBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_possibleRoomsListBox.RightToLeft")));
			this._possibleRoomsListBox.ScrollAlwaysVisible = ((bool)(resources.GetObject("_possibleRoomsListBox.ScrollAlwaysVisible")));
			this._possibleRoomsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this._possibleRoomsListBox.Size = ((System.Drawing.Size)(resources.GetObject("_possibleRoomsListBox.Size")));
			this._possibleRoomsListBox.Sorted = true;
			this._possibleRoomsListBox.TabIndex = ((int)(resources.GetObject("_possibleRoomsListBox.TabIndex")));
			this._possibleRoomsListBox.Visible = ((bool)(resources.GetObject("_possibleRoomsListBox.Visible")));
			// 
			// _choosedRoomsListBox
			// 
			this._choosedRoomsListBox.AccessibleDescription = resources.GetString("_choosedRoomsListBox.AccessibleDescription");
			this._choosedRoomsListBox.AccessibleName = resources.GetString("_choosedRoomsListBox.AccessibleName");
			this._choosedRoomsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_choosedRoomsListBox.Anchor")));
			this._choosedRoomsListBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_choosedRoomsListBox.BackgroundImage")));
			this._choosedRoomsListBox.ColumnWidth = ((int)(resources.GetObject("_choosedRoomsListBox.ColumnWidth")));
			this._choosedRoomsListBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_choosedRoomsListBox.Dock")));
			this._choosedRoomsListBox.Enabled = ((bool)(resources.GetObject("_choosedRoomsListBox.Enabled")));
			this._choosedRoomsListBox.Font = ((System.Drawing.Font)(resources.GetObject("_choosedRoomsListBox.Font")));
			this._choosedRoomsListBox.HorizontalExtent = ((int)(resources.GetObject("_choosedRoomsListBox.HorizontalExtent")));
			this._choosedRoomsListBox.HorizontalScrollbar = ((bool)(resources.GetObject("_choosedRoomsListBox.HorizontalScrollbar")));
			this._choosedRoomsListBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_choosedRoomsListBox.ImeMode")));
			this._choosedRoomsListBox.IntegralHeight = ((bool)(resources.GetObject("_choosedRoomsListBox.IntegralHeight")));
			this._choosedRoomsListBox.ItemHeight = ((int)(resources.GetObject("_choosedRoomsListBox.ItemHeight")));
			this._choosedRoomsListBox.Location = ((System.Drawing.Point)(resources.GetObject("_choosedRoomsListBox.Location")));
			this._choosedRoomsListBox.Name = "_choosedRoomsListBox";
			this._choosedRoomsListBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_choosedRoomsListBox.RightToLeft")));
			this._choosedRoomsListBox.ScrollAlwaysVisible = ((bool)(resources.GetObject("_choosedRoomsListBox.ScrollAlwaysVisible")));
			this._choosedRoomsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this._choosedRoomsListBox.Size = ((System.Drawing.Size)(resources.GetObject("_choosedRoomsListBox.Size")));
			this._choosedRoomsListBox.Sorted = true;
			this._choosedRoomsListBox.TabIndex = ((int)(resources.GetObject("_choosedRoomsListBox.TabIndex")));
			this._choosedRoomsListBox.Visible = ((bool)(resources.GetObject("_choosedRoomsListBox.Visible")));
			// 
			// _moveRightButton
			// 
			this._moveRightButton.AccessibleDescription = resources.GetString("_moveRightButton.AccessibleDescription");
			this._moveRightButton.AccessibleName = resources.GetString("_moveRightButton.AccessibleName");
			this._moveRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_moveRightButton.Anchor")));
			this._moveRightButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_moveRightButton.BackgroundImage")));
			this._moveRightButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_moveRightButton.Dock")));
			this._moveRightButton.Enabled = ((bool)(resources.GetObject("_moveRightButton.Enabled")));
			this._moveRightButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_moveRightButton.FlatStyle")));
			this._moveRightButton.Font = ((System.Drawing.Font)(resources.GetObject("_moveRightButton.Font")));
			this._moveRightButton.Image = ((System.Drawing.Image)(resources.GetObject("_moveRightButton.Image")));
			this._moveRightButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_moveRightButton.ImageAlign")));
			this._moveRightButton.ImageIndex = ((int)(resources.GetObject("_moveRightButton.ImageIndex")));
			this._moveRightButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_moveRightButton.ImeMode")));
			this._moveRightButton.Location = ((System.Drawing.Point)(resources.GetObject("_moveRightButton.Location")));
			this._moveRightButton.Name = "_moveRightButton";
			this._moveRightButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_moveRightButton.RightToLeft")));
			this._moveRightButton.Size = ((System.Drawing.Size)(resources.GetObject("_moveRightButton.Size")));
			this._moveRightButton.TabIndex = ((int)(resources.GetObject("_moveRightButton.TabIndex")));
			this._moveRightButton.Text = resources.GetString("_moveRightButton.Text");
			this._moveRightButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_moveRightButton.TextAlign")));
			this._moveRightButton.Visible = ((bool)(resources.GetObject("_moveRightButton.Visible")));
			this._moveRightButton.Click += new System.EventHandler(this._moveRightButton_Click);
			// 
			// _moveLeftButton
			// 
			this._moveLeftButton.AccessibleDescription = resources.GetString("_moveLeftButton.AccessibleDescription");
			this._moveLeftButton.AccessibleName = resources.GetString("_moveLeftButton.AccessibleName");
			this._moveLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_moveLeftButton.Anchor")));
			this._moveLeftButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_moveLeftButton.BackgroundImage")));
			this._moveLeftButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_moveLeftButton.Dock")));
			this._moveLeftButton.Enabled = ((bool)(resources.GetObject("_moveLeftButton.Enabled")));
			this._moveLeftButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_moveLeftButton.FlatStyle")));
			this._moveLeftButton.Font = ((System.Drawing.Font)(resources.GetObject("_moveLeftButton.Font")));
			this._moveLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("_moveLeftButton.Image")));
			this._moveLeftButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_moveLeftButton.ImageAlign")));
			this._moveLeftButton.ImageIndex = ((int)(resources.GetObject("_moveLeftButton.ImageIndex")));
			this._moveLeftButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_moveLeftButton.ImeMode")));
			this._moveLeftButton.Location = ((System.Drawing.Point)(resources.GetObject("_moveLeftButton.Location")));
			this._moveLeftButton.Name = "_moveLeftButton";
			this._moveLeftButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_moveLeftButton.RightToLeft")));
			this._moveLeftButton.Size = ((System.Drawing.Size)(resources.GetObject("_moveLeftButton.Size")));
			this._moveLeftButton.TabIndex = ((int)(resources.GetObject("_moveLeftButton.TabIndex")));
			this._moveLeftButton.Text = resources.GetString("_moveLeftButton.Text");
			this._moveLeftButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_moveLeftButton.TextAlign")));
			this._moveLeftButton.Visible = ((bool)(resources.GetObject("_moveLeftButton.Visible")));
			this._moveLeftButton.Click += new System.EventHandler(this._moveLeftButton_Click);
			// 
			// _topLabel
			// 
			this._topLabel.AccessibleDescription = resources.GetString("_topLabel.AccessibleDescription");
			this._topLabel.AccessibleName = resources.GetString("_topLabel.AccessibleName");
			this._topLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_topLabel.Anchor")));
			this._topLabel.AutoSize = ((bool)(resources.GetObject("_topLabel.AutoSize")));
			this._topLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_topLabel.Dock")));
			this._topLabel.Enabled = ((bool)(resources.GetObject("_topLabel.Enabled")));
			this._topLabel.Font = ((System.Drawing.Font)(resources.GetObject("_topLabel.Font")));
			this._topLabel.Image = ((System.Drawing.Image)(resources.GetObject("_topLabel.Image")));
			this._topLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_topLabel.ImageAlign")));
			this._topLabel.ImageIndex = ((int)(resources.GetObject("_topLabel.ImageIndex")));
			this._topLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_topLabel.ImeMode")));
			this._topLabel.Location = ((System.Drawing.Point)(resources.GetObject("_topLabel.Location")));
			this._topLabel.Name = "_topLabel";
			this._topLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_topLabel.RightToLeft")));
			this._topLabel.Size = ((System.Drawing.Size)(resources.GetObject("_topLabel.Size")));
			this._topLabel.TabIndex = ((int)(resources.GetObject("_topLabel.TabIndex")));
			this._topLabel.Text = resources.GetString("_topLabel.Text");
			this._topLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_topLabel.TextAlign")));
			this._topLabel.Visible = ((bool)(resources.GetObject("_topLabel.Visible")));
			// 
			// _hideLabel
			// 
			this._hideLabel.AccessibleDescription = resources.GetString("_hideLabel.AccessibleDescription");
			this._hideLabel.AccessibleName = resources.GetString("_hideLabel.AccessibleName");
			this._hideLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_hideLabel.Anchor")));
			this._hideLabel.AutoSize = ((bool)(resources.GetObject("_hideLabel.AutoSize")));
			this._hideLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._hideLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_hideLabel.Dock")));
			this._hideLabel.Enabled = ((bool)(resources.GetObject("_hideLabel.Enabled")));
			this._hideLabel.Font = ((System.Drawing.Font)(resources.GetObject("_hideLabel.Font")));
			this._hideLabel.ForeColor = System.Drawing.Color.Green;
			this._hideLabel.Image = ((System.Drawing.Image)(resources.GetObject("_hideLabel.Image")));
			this._hideLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_hideLabel.ImageAlign")));
			this._hideLabel.ImageIndex = ((int)(resources.GetObject("_hideLabel.ImageIndex")));
			this._hideLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_hideLabel.ImeMode")));
			this._hideLabel.Location = ((System.Drawing.Point)(resources.GetObject("_hideLabel.Location")));
			this._hideLabel.Name = "_hideLabel";
			this._hideLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_hideLabel.RightToLeft")));
			this._hideLabel.Size = ((System.Drawing.Size)(resources.GetObject("_hideLabel.Size")));
			this._hideLabel.TabIndex = ((int)(resources.GetObject("_hideLabel.TabIndex")));
			this._hideLabel.Text = resources.GetString("_hideLabel.Text");
			this._hideLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_hideLabel.TextAlign")));
			this._hideLabel.Visible = ((bool)(resources.GetObject("_hideLabel.Visible")));
			// 
			// _possibleRoomsLabel
			// 
			this._possibleRoomsLabel.AccessibleDescription = resources.GetString("_possibleRoomsLabel.AccessibleDescription");
			this._possibleRoomsLabel.AccessibleName = resources.GetString("_possibleRoomsLabel.AccessibleName");
			this._possibleRoomsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_possibleRoomsLabel.Anchor")));
			this._possibleRoomsLabel.AutoSize = ((bool)(resources.GetObject("_possibleRoomsLabel.AutoSize")));
			this._possibleRoomsLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_possibleRoomsLabel.Dock")));
			this._possibleRoomsLabel.Enabled = ((bool)(resources.GetObject("_possibleRoomsLabel.Enabled")));
			this._possibleRoomsLabel.Font = ((System.Drawing.Font)(resources.GetObject("_possibleRoomsLabel.Font")));
			this._possibleRoomsLabel.Image = ((System.Drawing.Image)(resources.GetObject("_possibleRoomsLabel.Image")));
			this._possibleRoomsLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_possibleRoomsLabel.ImageAlign")));
			this._possibleRoomsLabel.ImageIndex = ((int)(resources.GetObject("_possibleRoomsLabel.ImageIndex")));
			this._possibleRoomsLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_possibleRoomsLabel.ImeMode")));
			this._possibleRoomsLabel.Location = ((System.Drawing.Point)(resources.GetObject("_possibleRoomsLabel.Location")));
			this._possibleRoomsLabel.Name = "_possibleRoomsLabel";
			this._possibleRoomsLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_possibleRoomsLabel.RightToLeft")));
			this._possibleRoomsLabel.Size = ((System.Drawing.Size)(resources.GetObject("_possibleRoomsLabel.Size")));
			this._possibleRoomsLabel.TabIndex = ((int)(resources.GetObject("_possibleRoomsLabel.TabIndex")));
			this._possibleRoomsLabel.Text = resources.GetString("_possibleRoomsLabel.Text");
			this._possibleRoomsLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_possibleRoomsLabel.TextAlign")));
			this._possibleRoomsLabel.Visible = ((bool)(resources.GetObject("_possibleRoomsLabel.Visible")));
			// 
			// RoomsRestrictionForm
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
			this.Controls.Add(this._possibleRoomsLabel);
			this.Controls.Add(this._hideLabel);
			this.Controls.Add(this._choosedRoomsListBox);
			this.Controls.Add(this._topLabel);
			this.Controls.Add(this._moveLeftButton);
			this.Controls.Add(this._moveRightButton);
			this.Controls.Add(this._possibleRoomsListBox);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
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
			this.Name = "RoomsRestrictionForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.RoomsRestrictionForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void RoomsRestrictionForm_Load(object sender, System.EventArgs e)
		{			
			
			if(_possibleRoomsFromModelList!=null)
			{				
				foreach(Room room in _possibleRoomsFromModelList)
				{
					_choosedRoomsListBox.Items.Add(room);
				}
			}
			
			
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				if(room.getRoomCapacity()>=_numOfEnrStudents)
				{
					if(_possibleRoomsFromModelList!=null)
					{
						if(!_possibleRoomsFromModelList.Contains(room))
						{
							_possibleRoomsListBox.Items.Add(room);
						}
					} 
					else 
					{
						_possibleRoomsListBox.Items.Add(room);
					}
				}
			}

			checkWhatIsVisible();
		
		}

		private void _moveLeftButton_Click(object sender, System.EventArgs e)
		{	
			ArrayList tempList = new ArrayList();
			foreach(Room room in _possibleRoomsListBox.SelectedItems)
			{	
				tempList.Add(room);				
				
			}

			foreach(Room roomForMove in tempList)
			{
				_possibleRoomsListBox.Items.Remove(roomForMove);												
				_choosedRoomsListBox.Items.Add(roomForMove);
			}

			checkWhatIsVisible();
			setOKButtonState();
		}

		private void _moveRightButton_Click(object sender, System.EventArgs e)
		{
			ArrayList tempList = new ArrayList();
			foreach(Room room in _choosedRoomsListBox.SelectedItems)
			{	
				tempList.Add(room);				
				
			}

			foreach(Room roomForMove in tempList)
			{
				_choosedRoomsListBox.Items.Remove(roomForMove);												
				_possibleRoomsListBox.Items.Add(roomForMove);
			}

			checkWhatIsVisible();
			setOKButtonState();
		
		}


		private void checkWhatIsVisible()
		{
			if(_choosedRoomsListBox.Items.Count==0)
			{
				_hideLabel.Visible=true;
				_choosedRoomsListBox.Visible=false;
				_moveRightButton.Visible=false;

			}
			else
			{
				_hideLabel.Visible=false;
				_choosedRoomsListBox.Visible=true;
				_moveRightButton.Visible=true;

			}

		}

		public ListBox getChoosedRoomsListBox()
		{
			return _choosedRoomsListBox;			
		}

		private void Form_Closing (Object sender, CancelEventArgs e) 
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if (_numOfEnrStudents>-1) //course
				{
					if(!this.getIsRoomRelCourseOK())
					{
						e.Cancel = true;
					
						string message1 = RES_MANAGER.GetString("Form_Closing.msb.course.restrictions_not_changed.message");
					
						string caption1 = RES_MANAGER.GetString("Form_Closing.msb.course.restrictions_not_changed.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;			
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else
					{
                        e.Cancel=false;
					}
				}
				else //teacher
				{
					if(!this.getIsRoomRelTeacherOK())
					{
						e.Cancel = true;
					
                        string message2 = RES_MANAGER.GetString("Form_Closing.msb.teacher.restrictions_not_changed.message");
											
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.teacher.restrictions_not_changed.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else
					{
						e.Cancel=false;
					}						
				}
			}
		}

		private bool getIsRoomRelCourseOK()
		{
			ArrayList [,] mytt = AppForm.CURR_OCTT_DOC.ShownEduProgram.getTimetable();
			Course selCourse = (Course)AppForm.getAppForm().getSelectedCourse();
			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{					
					ArrayList lessonsInOneTimeSlot = mytt[j,k];
					if(lessonsInOneTimeSlot!=null) 
					{
						foreach(Object [] courseAndRoomPair in lessonsInOneTimeSlot) 
						{							
							Course course = (Course)courseAndRoomPair[0];
							if(course==selCourse)
							{
								Room room = (Room)courseAndRoomPair[1];
								if(!(_choosedRoomsListBox.Items.Contains(room)|| _choosedRoomsListBox.Items.Count==0)) return false;
							}
						}
					}					
				}


			}

			return true;
		}

		private bool getIsRoomRelTeacherOK()
		{
			Teacher selTeacher=AppForm.getAppForm().getSelectedTeacher();

			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{				
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
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
									Course course = (Course)courseAndRoomPair[0];
									Teacher teacherFromModel=course.getTeacher();	
									if(teacherFromModel==selTeacher)
									{
										Room room = (Room)courseAndRoomPair[1];
										if(!(_choosedRoomsListBox.Items.Contains(room) || _choosedRoomsListBox.Items.Count==0)) return false;
									}
								}
							}
						}
					}
					
				}


			}

			return true;
		}

		private void setOKButtonState()
		{
			if(_possibleRoomsFromModelList==null || _possibleRoomsFromModelList.Count==0)
			{
				if(_choosedRoomsListBox.Items.Count>0)
				{
					_okButton.Enabled=true;
				}
				else
				{
					_okButton.Enabled=false;
				}				
			}
			else
			{
				bool containsAll=true;

				foreach(Room room in _possibleRoomsFromModelList)
				{
					if(!_choosedRoomsListBox.Items.Contains(room))
					{
						containsAll=false;
						_okButton.Enabled=true;
						break;
					}
				}

				if(containsAll)
				{
					if(_possibleRoomsFromModelList.Count==_choosedRoomsListBox.Items.Count)
					{
                        _okButton.Enabled=false;
					}
					else
					{
						_okButton.Enabled=true;
					}

				}
			}
		}

	}
}
