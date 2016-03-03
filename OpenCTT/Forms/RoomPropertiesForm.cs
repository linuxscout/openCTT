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
	/// Summary description for RoomPropertiesForm.
	/// </summary>
	public class RoomPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isNew;
		private Room _room;

		private bool _isNameOK;
		private bool _isCapacityOK;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _capacityTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ErrorProvider _errorProvider1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _extIDTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public RoomPropertiesForm()
		{
			InitializeComponent();

			_isNew=true;

			_isNameOK=false;
			_isCapacityOK=false;

			_errorProvider1.SetError(_capacityTextBox,"");

			RES_MANAGER = new System.Resources.ResourceManager(typeof(RoomPropertiesForm));

		}


		public RoomPropertiesForm(Room room):this()
		{	
			_isNew=false;
			_room=room;

			_isNameOK=true;
			_isCapacityOK=true;

			this._nameTextBox.Text=_room.getName();
			this._capacityTextBox.Text=_room.getRoomCapacity().ToString();
			if(_room.ExtID!=null)
			{
				this._extIDTextBox.Text=_room.ExtID;
			}
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RoomPropertiesForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this._nameTextBox = new System.Windows.Forms.TextBox();
			this._capacityTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this._extIDTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this._errorProvider1.SetError(this.label1, resources.GetString("label1.Error"));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this._errorProvider1.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
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
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this._errorProvider1.SetError(this.label2, resources.GetString("label2.Error"));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this._errorProvider1.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// _nameTextBox
			// 
			this._nameTextBox.AccessibleDescription = resources.GetString("_nameTextBox.AccessibleDescription");
			this._nameTextBox.AccessibleName = resources.GetString("_nameTextBox.AccessibleName");
			this._nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_nameTextBox.Anchor")));
			this._nameTextBox.AutoSize = ((bool)(resources.GetObject("_nameTextBox.AutoSize")));
			this._nameTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_nameTextBox.BackgroundImage")));
			this._nameTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_nameTextBox.Dock")));
			this._nameTextBox.Enabled = ((bool)(resources.GetObject("_nameTextBox.Enabled")));
			this._errorProvider1.SetError(this._nameTextBox, resources.GetString("_nameTextBox.Error"));
			this._nameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_nameTextBox.Font")));
			this._errorProvider1.SetIconAlignment(this._nameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_nameTextBox.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this._nameTextBox, ((int)(resources.GetObject("_nameTextBox.IconPadding"))));
			this._nameTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_nameTextBox.ImeMode")));
			this._nameTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_nameTextBox.Location")));
			this._nameTextBox.MaxLength = ((int)(resources.GetObject("_nameTextBox.MaxLength")));
			this._nameTextBox.Multiline = ((bool)(resources.GetObject("_nameTextBox.Multiline")));
			this._nameTextBox.Name = "_nameTextBox";
			this._nameTextBox.PasswordChar = ((char)(resources.GetObject("_nameTextBox.PasswordChar")));
			this._nameTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_nameTextBox.RightToLeft")));
			this._nameTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_nameTextBox.ScrollBars")));
			this._nameTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_nameTextBox.Size")));
			this._nameTextBox.TabIndex = ((int)(resources.GetObject("_nameTextBox.TabIndex")));
			this._nameTextBox.Text = resources.GetString("_nameTextBox.Text");
			this._nameTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_nameTextBox.TextAlign")));
			this._nameTextBox.Visible = ((bool)(resources.GetObject("_nameTextBox.Visible")));
			this._nameTextBox.WordWrap = ((bool)(resources.GetObject("_nameTextBox.WordWrap")));
			this._nameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
			// 
			// _capacityTextBox
			// 
			this._capacityTextBox.AccessibleDescription = resources.GetString("_capacityTextBox.AccessibleDescription");
			this._capacityTextBox.AccessibleName = resources.GetString("_capacityTextBox.AccessibleName");
			this._capacityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_capacityTextBox.Anchor")));
			this._capacityTextBox.AutoSize = ((bool)(resources.GetObject("_capacityTextBox.AutoSize")));
			this._capacityTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_capacityTextBox.BackgroundImage")));
			this._capacityTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_capacityTextBox.Dock")));
			this._capacityTextBox.Enabled = ((bool)(resources.GetObject("_capacityTextBox.Enabled")));
			this._errorProvider1.SetError(this._capacityTextBox, resources.GetString("_capacityTextBox.Error"));
			this._capacityTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_capacityTextBox.Font")));
			this._errorProvider1.SetIconAlignment(this._capacityTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_capacityTextBox.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this._capacityTextBox, ((int)(resources.GetObject("_capacityTextBox.IconPadding"))));
			this._capacityTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_capacityTextBox.ImeMode")));
			this._capacityTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_capacityTextBox.Location")));
			this._capacityTextBox.MaxLength = ((int)(resources.GetObject("_capacityTextBox.MaxLength")));
			this._capacityTextBox.Multiline = ((bool)(resources.GetObject("_capacityTextBox.Multiline")));
			this._capacityTextBox.Name = "_capacityTextBox";
			this._capacityTextBox.PasswordChar = ((char)(resources.GetObject("_capacityTextBox.PasswordChar")));
			this._capacityTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_capacityTextBox.RightToLeft")));
			this._capacityTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_capacityTextBox.ScrollBars")));
			this._capacityTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_capacityTextBox.Size")));
			this._capacityTextBox.TabIndex = ((int)(resources.GetObject("_capacityTextBox.TabIndex")));
			this._capacityTextBox.Text = resources.GetString("_capacityTextBox.Text");
			this._capacityTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_capacityTextBox.TextAlign")));
			this._capacityTextBox.Visible = ((bool)(resources.GetObject("_capacityTextBox.Visible")));
			this._capacityTextBox.WordWrap = ((bool)(resources.GetObject("_capacityTextBox.WordWrap")));
			this._capacityTextBox.TextChanged += new System.EventHandler(this._capacityTextBox_TextChanged);
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
			this._errorProvider1.SetError(this._okButton, resources.GetString("_okButton.Error"));
			this._okButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_okButton.FlatStyle")));
			this._okButton.Font = ((System.Drawing.Font)(resources.GetObject("_okButton.Font")));
			this._errorProvider1.SetIconAlignment(this._okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_okButton.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this._okButton, ((int)(resources.GetObject("_okButton.IconPadding"))));
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
			this._errorProvider1.SetError(this._cancelButton, resources.GetString("_cancelButton.Error"));
			this._cancelButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_cancelButton.FlatStyle")));
			this._cancelButton.Font = ((System.Drawing.Font)(resources.GetObject("_cancelButton.Font")));
			this._errorProvider1.SetIconAlignment(this._cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_cancelButton.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this._cancelButton, ((int)(resources.GetObject("_cancelButton.IconPadding"))));
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
			// _errorProvider1
			// 
			this._errorProvider1.ContainerControl = this;
			this._errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("_errorProvider1.Icon")));
			// 
			// _extIDTextBox
			// 
			this._extIDTextBox.AccessibleDescription = resources.GetString("_extIDTextBox.AccessibleDescription");
			this._extIDTextBox.AccessibleName = resources.GetString("_extIDTextBox.AccessibleName");
			this._extIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_extIDTextBox.Anchor")));
			this._extIDTextBox.AutoSize = ((bool)(resources.GetObject("_extIDTextBox.AutoSize")));
			this._extIDTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_extIDTextBox.BackgroundImage")));
			this._extIDTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_extIDTextBox.Dock")));
			this._extIDTextBox.Enabled = ((bool)(resources.GetObject("_extIDTextBox.Enabled")));
			this._errorProvider1.SetError(this._extIDTextBox, resources.GetString("_extIDTextBox.Error"));
			this._extIDTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_extIDTextBox.Font")));
			this._errorProvider1.SetIconAlignment(this._extIDTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_extIDTextBox.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this._extIDTextBox, ((int)(resources.GetObject("_extIDTextBox.IconPadding"))));
			this._extIDTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_extIDTextBox.ImeMode")));
			this._extIDTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_extIDTextBox.Location")));
			this._extIDTextBox.MaxLength = ((int)(resources.GetObject("_extIDTextBox.MaxLength")));
			this._extIDTextBox.Multiline = ((bool)(resources.GetObject("_extIDTextBox.Multiline")));
			this._extIDTextBox.Name = "_extIDTextBox";
			this._extIDTextBox.PasswordChar = ((char)(resources.GetObject("_extIDTextBox.PasswordChar")));
			this._extIDTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_extIDTextBox.RightToLeft")));
			this._extIDTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_extIDTextBox.ScrollBars")));
			this._extIDTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_extIDTextBox.Size")));
			this._extIDTextBox.TabIndex = ((int)(resources.GetObject("_extIDTextBox.TabIndex")));
			this._extIDTextBox.Text = resources.GetString("_extIDTextBox.Text");
			this._extIDTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_extIDTextBox.TextAlign")));
			this._extIDTextBox.Visible = ((bool)(resources.GetObject("_extIDTextBox.Visible")));
			this._extIDTextBox.WordWrap = ((bool)(resources.GetObject("_extIDTextBox.WordWrap")));
			// 
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this._errorProvider1.SetError(this.label3, resources.GetString("label3.Error"));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this._errorProvider1.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
			this._errorProvider1.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// RoomPropertiesForm
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
			this.Controls.Add(this.label3);
			this.Controls.Add(this._extIDTextBox);
			this.Controls.Add(this._capacityTextBox);
			this.Controls.Add(this._nameTextBox);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
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
			this.Name = "RoomPropertiesForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
			this.ResumeLayout(false);

		}
		#endregion


		

		private void Form_Closing (Object sender, CancelEventArgs e) 
		{
			if(_isNew)
			{
				if(this.DialogResult==DialogResult.OK)
				{
					if (!Room.getIsNewNameOK(_nameTextBox.Text)) 
					{
						e.Cancel = true;
					
						string message=RES_MANAGER.GetString("Form_Closing.msb.newroomnotcreated.message");
					
						string caption=RES_MANAGER.GetString("Form_Closing.msb.newroomnotcreated.caption");

						MessageBoxButtons buttons = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message, caption, buttons,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else 
					{
						e.Cancel = false;		
					}
				}
			}
			else if(!_isNew)
			{
				if(this.DialogResult==DialogResult.OK)
				{
					if(_nameTextBox.Text.ToUpper()!=_room.getName().ToUpper())
					{
						if (!Room.getIsNewNameOK(_nameTextBox.Text)) 
						{
							e.Cancel = true;
					
							string message2=RES_MANAGER.GetString("Form_Closing.msb.roomdatanotchanged.message");
                    
							string caption2=RES_MANAGER.GetString("Form_Closing.msb.roomdatanotchanged.caption");

							MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
							MessageBox.Show(this, message2, caption2, buttons2,
								MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
						}
						else 
						{							
							checkNewCapacity(e);
						}
					}
					else
					{
						checkNewCapacity(e);
					}
				}

			}
		}


		private void checkNewCapacity(CancelEventArgs e)
		{
			if(System.Convert.ToInt32(_capacityTextBox.Text)>=_room.getRoomCapacity())
			{
				e.Cancel = false;
			}
			else
			{
				//new capacity is smaller
				if(Room.getIsNewCapacityOK(_room,System.Convert.ToInt32(_capacityTextBox.Text)))
				{
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
					
					string message3=RES_MANAGER.GetString("Form_Closing.checkNewCapacity.msb.roomdatanotchanged.message");
					
					string caption3=RES_MANAGER.GetString("Form_Closing.checkNewCapacity.msb.roomdatanotchanged.caption");

					MessageBoxButtons buttons3 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message3, caption3, buttons3,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
			}

		}

		private void _capacityTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				int x = Int32.Parse(_capacityTextBox.Text);
				if(x<=0)
				{
					_isCapacityOK=false;					
					_errorProvider1.SetError(_capacityTextBox,RES_MANAGER.GetString("capacity.greater.than.zero.text"));
					_okButton.Enabled=false;
				}
				else
				{
					_isCapacityOK=true;
					_errorProvider1.SetError(_capacityTextBox,"");
					if(_isNameOK)
					{
						_okButton.Enabled=true;
					}
					else
					{
						_okButton.Enabled=false;
					}
				}
			}
			catch
			{
				_isCapacityOK=false;				
				_errorProvider1.SetError(_capacityTextBox,RES_MANAGER.GetString("capacity.greater.than.zero.text"));
				_okButton.Enabled=false;
			}
		
		}

		private void _nameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="") 
			{
				_isNameOK=true;
				if(_isCapacityOK)
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
				_isNameOK=false;
				_okButton.Enabled=false;

			}
		
		}

		public TextBox NameTextBox
		{
			get
			{
				return _nameTextBox;
			}
		}

		public TextBox CapacityTextBox
		{
			get
			{
				return _capacityTextBox;
			}
		}

		public TextBox ExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}
		}


	}
}
