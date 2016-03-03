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
	/// Summary description for EduProgramPropertiesForm.
	/// </summary>
	public class EduProgramPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private EduProgram _ep;
        private bool _isNew;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _codeTextBox;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _semesterTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _extIDTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public EduProgramPropertiesForm()
		{
			InitializeComponent();
			_isNew=true;

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPPropertiesFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPPropertiesFormSchool",this.GetType().Assembly);
			}
			//
			this.Text=RES_MANAGER.GetString("this.Text");
			this.label3.Text=RES_MANAGER.GetString("label3.Text");
            //

		}

		public EduProgramPropertiesForm(EduProgram ep):this()
		{
			_ep=ep;
			_isNew=false;

			this._codeTextBox.Text=_ep.getCode();
			this._nameTextBox.Text=_ep.getName();
			this._semesterTextBox.Text=_ep.getSemester();
			this._extIDTextBox.Text=_ep.ExtID;
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EduProgramPropertiesForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._codeTextBox = new System.Windows.Forms.TextBox();
			this._nameTextBox = new System.Windows.Forms.TextBox();
			this._semesterTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this._extIDTextBox = new System.Windows.Forms.TextBox();
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
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
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
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
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
			// _codeTextBox
			// 
			this._codeTextBox.AccessibleDescription = resources.GetString("_codeTextBox.AccessibleDescription");
			this._codeTextBox.AccessibleName = resources.GetString("_codeTextBox.AccessibleName");
			this._codeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_codeTextBox.Anchor")));
			this._codeTextBox.AutoSize = ((bool)(resources.GetObject("_codeTextBox.AutoSize")));
			this._codeTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_codeTextBox.BackgroundImage")));
			this._codeTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_codeTextBox.Dock")));
			this._codeTextBox.Enabled = ((bool)(resources.GetObject("_codeTextBox.Enabled")));
			this._codeTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_codeTextBox.Font")));
			this._codeTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_codeTextBox.ImeMode")));
			this._codeTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_codeTextBox.Location")));
			this._codeTextBox.MaxLength = ((int)(resources.GetObject("_codeTextBox.MaxLength")));
			this._codeTextBox.Multiline = ((bool)(resources.GetObject("_codeTextBox.Multiline")));
			this._codeTextBox.Name = "_codeTextBox";
			this._codeTextBox.PasswordChar = ((char)(resources.GetObject("_codeTextBox.PasswordChar")));
			this._codeTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_codeTextBox.RightToLeft")));
			this._codeTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_codeTextBox.ScrollBars")));
			this._codeTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_codeTextBox.Size")));
			this._codeTextBox.TabIndex = ((int)(resources.GetObject("_codeTextBox.TabIndex")));
			this._codeTextBox.Text = resources.GetString("_codeTextBox.Text");
			this._codeTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_codeTextBox.TextAlign")));
			this._codeTextBox.Visible = ((bool)(resources.GetObject("_codeTextBox.Visible")));
			this._codeTextBox.WordWrap = ((bool)(resources.GetObject("_codeTextBox.WordWrap")));
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
			this._nameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_nameTextBox.Font")));
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
			// _semesterTextBox
			// 
			this._semesterTextBox.AccessibleDescription = resources.GetString("_semesterTextBox.AccessibleDescription");
			this._semesterTextBox.AccessibleName = resources.GetString("_semesterTextBox.AccessibleName");
			this._semesterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_semesterTextBox.Anchor")));
			this._semesterTextBox.AutoSize = ((bool)(resources.GetObject("_semesterTextBox.AutoSize")));
			this._semesterTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_semesterTextBox.BackgroundImage")));
			this._semesterTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_semesterTextBox.Dock")));
			this._semesterTextBox.Enabled = ((bool)(resources.GetObject("_semesterTextBox.Enabled")));
			this._semesterTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_semesterTextBox.Font")));
			this._semesterTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_semesterTextBox.ImeMode")));
			this._semesterTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_semesterTextBox.Location")));
			this._semesterTextBox.MaxLength = ((int)(resources.GetObject("_semesterTextBox.MaxLength")));
			this._semesterTextBox.Multiline = ((bool)(resources.GetObject("_semesterTextBox.Multiline")));
			this._semesterTextBox.Name = "_semesterTextBox";
			this._semesterTextBox.PasswordChar = ((char)(resources.GetObject("_semesterTextBox.PasswordChar")));
			this._semesterTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_semesterTextBox.RightToLeft")));
			this._semesterTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_semesterTextBox.ScrollBars")));
			this._semesterTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_semesterTextBox.Size")));
			this._semesterTextBox.TabIndex = ((int)(resources.GetObject("_semesterTextBox.TabIndex")));
			this._semesterTextBox.Text = resources.GetString("_semesterTextBox.Text");
			this._semesterTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_semesterTextBox.TextAlign")));
			this._semesterTextBox.Visible = ((bool)(resources.GetObject("_semesterTextBox.Visible")));
			this._semesterTextBox.WordWrap = ((bool)(resources.GetObject("_semesterTextBox.WordWrap")));
			this._semesterTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
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
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
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
			this._extIDTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_extIDTextBox.Font")));
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
			// EduProgramPropertiesForm
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
			this.Controls.Add(this._extIDTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._semesterTextBox);
			this.Controls.Add(this._nameTextBox);
			this.Controls.Add(this._codeTextBox);
			this.Controls.Add(this.label3);
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
			this.Name = "EduProgramPropertiesForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void _nameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="" && _semesterTextBox.Text.Trim()!="") 
			{
				_okButton.Enabled=true;
			}
			else 
			{
				_okButton.Enabled=false;
			}
		}		

		private void Form_Closing (Object sender, CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if(_isNew) 
				{
					if(EduProgram.getIsEduProgramDataOK(null,_codeTextBox.Text.Trim(),_nameTextBox.Text.Trim(),_semesterTextBox.Text.Trim()))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
					
						string message1 = RES_MANAGER.GetString("Form_Closing.msb.epnotcreated.message");
										
						string caption1 = RES_MANAGER.GetString("Form_Closing.msb.epnotcreated.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}
				}
				else
				{
					if(EduProgram.getIsEduProgramDataOK(_ep,_codeTextBox.Text.Trim(),_nameTextBox.Text.Trim(),_semesterTextBox.Text.Trim()))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
					
						string message2 = RES_MANAGER.GetString("Form_Closing.msb.epdatanotchanged.message");
										
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.epdatanotchanged.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}

				}
			}

		}	


		public TextBox SemesterTextBox
		{
			get
			{
				return _semesterTextBox;
			}
		}

		public TextBox NameTextBox
		{
			get
			{
				return _nameTextBox;
			}
		}


		public TextBox CodeTextBox
		{
			get
			{
				return _codeTextBox;
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
