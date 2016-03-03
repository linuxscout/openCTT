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


namespace OpenCTT
{
	/// <summary>
	/// Summary description for AddDaysForm.
	/// </summary>
	public class AddDaysForm : System.Windows.Forms.Form
	{		

		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.CheckBox _checkBox1;
		private System.Windows.Forms.CheckBox _checkBox2;
		private System.Windows.Forms.CheckBox _checkBox7;
		private System.Windows.Forms.CheckBox _checkBox6;
		private System.Windows.Forms.CheckBox _checkBox5;
		private System.Windows.Forms.CheckBox _checkBox4;
		private System.Windows.Forms.CheckBox _checkBox3;
		private System.Windows.Forms.GroupBox _groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddDaysForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();			

			String[] dayText = AppForm.getDayText();
			this._checkBox1.Text = dayText[0];
			this._checkBox2.Text = dayText[1];
			this._checkBox3.Text = dayText[2];
			this._checkBox4.Text = dayText[3];
			this._checkBox5.Text = dayText[4];
			this._checkBox6.Text = dayText[5];
			this._checkBox7.Text = dayText[6];
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddDaysForm));
			this._checkBox1 = new System.Windows.Forms.CheckBox();
			this._checkBox2 = new System.Windows.Forms.CheckBox();
			this._checkBox7 = new System.Windows.Forms.CheckBox();
			this._checkBox6 = new System.Windows.Forms.CheckBox();
			this._checkBox5 = new System.Windows.Forms.CheckBox();
			this._checkBox4 = new System.Windows.Forms.CheckBox();
			this._checkBox3 = new System.Windows.Forms.CheckBox();
			this._groupBox1 = new System.Windows.Forms.GroupBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _checkBox1
			// 
			this._checkBox1.AccessibleDescription = resources.GetString("_checkBox1.AccessibleDescription");
			this._checkBox1.AccessibleName = resources.GetString("_checkBox1.AccessibleName");
			this._checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox1.Anchor")));
			this._checkBox1.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox1.Appearance")));
			this._checkBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox1.BackgroundImage")));
			this._checkBox1.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox1.CheckAlign")));
			this._checkBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox1.Dock")));
			this._checkBox1.Enabled = ((bool)(resources.GetObject("_checkBox1.Enabled")));
			this._checkBox1.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox1.FlatStyle")));
			this._checkBox1.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox1.Font")));
			this._checkBox1.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox1.Image")));
			this._checkBox1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox1.ImageAlign")));
			this._checkBox1.ImageIndex = ((int)(resources.GetObject("_checkBox1.ImageIndex")));
			this._checkBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox1.ImeMode")));
			this._checkBox1.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox1.Location")));
			this._checkBox1.Name = "_checkBox1";
			this._checkBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox1.RightToLeft")));
			this._checkBox1.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox1.Size")));
			this._checkBox1.TabIndex = ((int)(resources.GetObject("_checkBox1.TabIndex")));
			this._checkBox1.Text = resources.GetString("_checkBox1.Text");
			this._checkBox1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox1.TextAlign")));
			this._checkBox1.Visible = ((bool)(resources.GetObject("_checkBox1.Visible")));
			// 
			// _checkBox2
			// 
			this._checkBox2.AccessibleDescription = resources.GetString("_checkBox2.AccessibleDescription");
			this._checkBox2.AccessibleName = resources.GetString("_checkBox2.AccessibleName");
			this._checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox2.Anchor")));
			this._checkBox2.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox2.Appearance")));
			this._checkBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox2.BackgroundImage")));
			this._checkBox2.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox2.CheckAlign")));
			this._checkBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox2.Dock")));
			this._checkBox2.Enabled = ((bool)(resources.GetObject("_checkBox2.Enabled")));
			this._checkBox2.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox2.FlatStyle")));
			this._checkBox2.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox2.Font")));
			this._checkBox2.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox2.Image")));
			this._checkBox2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox2.ImageAlign")));
			this._checkBox2.ImageIndex = ((int)(resources.GetObject("_checkBox2.ImageIndex")));
			this._checkBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox2.ImeMode")));
			this._checkBox2.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox2.Location")));
			this._checkBox2.Name = "_checkBox2";
			this._checkBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox2.RightToLeft")));
			this._checkBox2.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox2.Size")));
			this._checkBox2.TabIndex = ((int)(resources.GetObject("_checkBox2.TabIndex")));
			this._checkBox2.Text = resources.GetString("_checkBox2.Text");
			this._checkBox2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox2.TextAlign")));
			this._checkBox2.Visible = ((bool)(resources.GetObject("_checkBox2.Visible")));
			// 
			// _checkBox7
			// 
			this._checkBox7.AccessibleDescription = resources.GetString("_checkBox7.AccessibleDescription");
			this._checkBox7.AccessibleName = resources.GetString("_checkBox7.AccessibleName");
			this._checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox7.Anchor")));
			this._checkBox7.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox7.Appearance")));
			this._checkBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox7.BackgroundImage")));
			this._checkBox7.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox7.CheckAlign")));
			this._checkBox7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox7.Dock")));
			this._checkBox7.Enabled = ((bool)(resources.GetObject("_checkBox7.Enabled")));
			this._checkBox7.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox7.FlatStyle")));
			this._checkBox7.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox7.Font")));
			this._checkBox7.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox7.Image")));
			this._checkBox7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox7.ImageAlign")));
			this._checkBox7.ImageIndex = ((int)(resources.GetObject("_checkBox7.ImageIndex")));
			this._checkBox7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox7.ImeMode")));
			this._checkBox7.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox7.Location")));
			this._checkBox7.Name = "_checkBox7";
			this._checkBox7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox7.RightToLeft")));
			this._checkBox7.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox7.Size")));
			this._checkBox7.TabIndex = ((int)(resources.GetObject("_checkBox7.TabIndex")));
			this._checkBox7.Text = resources.GetString("_checkBox7.Text");
			this._checkBox7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox7.TextAlign")));
			this._checkBox7.Visible = ((bool)(resources.GetObject("_checkBox7.Visible")));
			// 
			// _checkBox6
			// 
			this._checkBox6.AccessibleDescription = resources.GetString("_checkBox6.AccessibleDescription");
			this._checkBox6.AccessibleName = resources.GetString("_checkBox6.AccessibleName");
			this._checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox6.Anchor")));
			this._checkBox6.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox6.Appearance")));
			this._checkBox6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox6.BackgroundImage")));
			this._checkBox6.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox6.CheckAlign")));
			this._checkBox6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox6.Dock")));
			this._checkBox6.Enabled = ((bool)(resources.GetObject("_checkBox6.Enabled")));
			this._checkBox6.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox6.FlatStyle")));
			this._checkBox6.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox6.Font")));
			this._checkBox6.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox6.Image")));
			this._checkBox6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox6.ImageAlign")));
			this._checkBox6.ImageIndex = ((int)(resources.GetObject("_checkBox6.ImageIndex")));
			this._checkBox6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox6.ImeMode")));
			this._checkBox6.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox6.Location")));
			this._checkBox6.Name = "_checkBox6";
			this._checkBox6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox6.RightToLeft")));
			this._checkBox6.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox6.Size")));
			this._checkBox6.TabIndex = ((int)(resources.GetObject("_checkBox6.TabIndex")));
			this._checkBox6.Text = resources.GetString("_checkBox6.Text");
			this._checkBox6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox6.TextAlign")));
			this._checkBox6.Visible = ((bool)(resources.GetObject("_checkBox6.Visible")));
			// 
			// _checkBox5
			// 
			this._checkBox5.AccessibleDescription = resources.GetString("_checkBox5.AccessibleDescription");
			this._checkBox5.AccessibleName = resources.GetString("_checkBox5.AccessibleName");
			this._checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox5.Anchor")));
			this._checkBox5.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox5.Appearance")));
			this._checkBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox5.BackgroundImage")));
			this._checkBox5.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox5.CheckAlign")));
			this._checkBox5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox5.Dock")));
			this._checkBox5.Enabled = ((bool)(resources.GetObject("_checkBox5.Enabled")));
			this._checkBox5.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox5.FlatStyle")));
			this._checkBox5.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox5.Font")));
			this._checkBox5.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox5.Image")));
			this._checkBox5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox5.ImageAlign")));
			this._checkBox5.ImageIndex = ((int)(resources.GetObject("_checkBox5.ImageIndex")));
			this._checkBox5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox5.ImeMode")));
			this._checkBox5.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox5.Location")));
			this._checkBox5.Name = "_checkBox5";
			this._checkBox5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox5.RightToLeft")));
			this._checkBox5.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox5.Size")));
			this._checkBox5.TabIndex = ((int)(resources.GetObject("_checkBox5.TabIndex")));
			this._checkBox5.Text = resources.GetString("_checkBox5.Text");
			this._checkBox5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox5.TextAlign")));
			this._checkBox5.Visible = ((bool)(resources.GetObject("_checkBox5.Visible")));
			// 
			// _checkBox4
			// 
			this._checkBox4.AccessibleDescription = resources.GetString("_checkBox4.AccessibleDescription");
			this._checkBox4.AccessibleName = resources.GetString("_checkBox4.AccessibleName");
			this._checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox4.Anchor")));
			this._checkBox4.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox4.Appearance")));
			this._checkBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox4.BackgroundImage")));
			this._checkBox4.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox4.CheckAlign")));
			this._checkBox4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox4.Dock")));
			this._checkBox4.Enabled = ((bool)(resources.GetObject("_checkBox4.Enabled")));
			this._checkBox4.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox4.FlatStyle")));
			this._checkBox4.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox4.Font")));
			this._checkBox4.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox4.Image")));
			this._checkBox4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox4.ImageAlign")));
			this._checkBox4.ImageIndex = ((int)(resources.GetObject("_checkBox4.ImageIndex")));
			this._checkBox4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox4.ImeMode")));
			this._checkBox4.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox4.Location")));
			this._checkBox4.Name = "_checkBox4";
			this._checkBox4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox4.RightToLeft")));
			this._checkBox4.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox4.Size")));
			this._checkBox4.TabIndex = ((int)(resources.GetObject("_checkBox4.TabIndex")));
			this._checkBox4.Text = resources.GetString("_checkBox4.Text");
			this._checkBox4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox4.TextAlign")));
			this._checkBox4.Visible = ((bool)(resources.GetObject("_checkBox4.Visible")));
			// 
			// _checkBox3
			// 
			this._checkBox3.AccessibleDescription = resources.GetString("_checkBox3.AccessibleDescription");
			this._checkBox3.AccessibleName = resources.GetString("_checkBox3.AccessibleName");
			this._checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_checkBox3.Anchor")));
			this._checkBox3.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_checkBox3.Appearance")));
			this._checkBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_checkBox3.BackgroundImage")));
			this._checkBox3.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox3.CheckAlign")));
			this._checkBox3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_checkBox3.Dock")));
			this._checkBox3.Enabled = ((bool)(resources.GetObject("_checkBox3.Enabled")));
			this._checkBox3.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_checkBox3.FlatStyle")));
			this._checkBox3.Font = ((System.Drawing.Font)(resources.GetObject("_checkBox3.Font")));
			this._checkBox3.Image = ((System.Drawing.Image)(resources.GetObject("_checkBox3.Image")));
			this._checkBox3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox3.ImageAlign")));
			this._checkBox3.ImageIndex = ((int)(resources.GetObject("_checkBox3.ImageIndex")));
			this._checkBox3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_checkBox3.ImeMode")));
			this._checkBox3.Location = ((System.Drawing.Point)(resources.GetObject("_checkBox3.Location")));
			this._checkBox3.Name = "_checkBox3";
			this._checkBox3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_checkBox3.RightToLeft")));
			this._checkBox3.Size = ((System.Drawing.Size)(resources.GetObject("_checkBox3.Size")));
			this._checkBox3.TabIndex = ((int)(resources.GetObject("_checkBox3.TabIndex")));
			this._checkBox3.Text = resources.GetString("_checkBox3.Text");
			this._checkBox3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_checkBox3.TextAlign")));
			this._checkBox3.Visible = ((bool)(resources.GetObject("_checkBox3.Visible")));
			// 
			// _groupBox1
			// 
			this._groupBox1.AccessibleDescription = resources.GetString("_groupBox1.AccessibleDescription");
			this._groupBox1.AccessibleName = resources.GetString("_groupBox1.AccessibleName");
			this._groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_groupBox1.Anchor")));
			this._groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_groupBox1.BackgroundImage")));
			this._groupBox1.Controls.Add(this._checkBox1);
			this._groupBox1.Controls.Add(this._checkBox2);
			this._groupBox1.Controls.Add(this._checkBox3);
			this._groupBox1.Controls.Add(this._checkBox4);
			this._groupBox1.Controls.Add(this._checkBox5);
			this._groupBox1.Controls.Add(this._checkBox6);
			this._groupBox1.Controls.Add(this._checkBox7);
			this._groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_groupBox1.Dock")));
			this._groupBox1.Enabled = ((bool)(resources.GetObject("_groupBox1.Enabled")));
			this._groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("_groupBox1.Font")));
			this._groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_groupBox1.ImeMode")));
			this._groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("_groupBox1.Location")));
			this._groupBox1.Name = "_groupBox1";
			this._groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_groupBox1.RightToLeft")));
			this._groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("_groupBox1.Size")));
			this._groupBox1.TabIndex = ((int)(resources.GetObject("_groupBox1.TabIndex")));
			this._groupBox1.TabStop = false;
			this._groupBox1.Text = resources.GetString("_groupBox1.Text");
			this._groupBox1.Visible = ((bool)(resources.GetObject("_groupBox1.Visible")));
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
			// AddDaysForm
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
			this.Controls.Add(this._groupBox1);
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
			this.Name = "AddDaysForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.AddDaysForm_Load);
			this._groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void AddDaysForm_Load(object sender, System.EventArgs e)
		{
			for(int n=0;n<7;n++)
			{
				if(AppForm.CURR_OCTT_DOC.getIsDayIncluded(n)==true)
				{
					this._groupBox1.Controls[n].Enabled=false;
					((CheckBox)this._groupBox1.Controls[n]).Checked=true;					
				}
			}
		}

		public GroupBox getGroup()
		{
			return _groupBox1;
		}



	}
}

		
	
