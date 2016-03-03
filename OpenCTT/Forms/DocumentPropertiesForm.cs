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
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace OpenCTT
{
	/// <summary>
	/// Summary description for DocumentPropertiesForm.
	/// </summary>
	public class DocumentPropertiesForm : System.Windows.Forms.Form
	{		
		private bool _isNew;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.TextBox _schoolYearTextBox;
		private System.Windows.Forms.TextBox _eduInstitutionNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox _docTypeComboBox;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DocumentPropertiesForm(bool isNew)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();	
            
			_isNew=isNew;	
			this._docTypeComboBox.DataSource=AppForm.DOCUMENT_TYPES_LIST;
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DocumentPropertiesForm));
			this.label1 = new System.Windows.Forms.Label();
			this._schoolYearTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._eduInstitutionNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this._docTypeComboBox = new System.Windows.Forms.ComboBox();
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
			// _schoolYearTextBox
			// 
			this._schoolYearTextBox.AccessibleDescription = resources.GetString("_schoolYearTextBox.AccessibleDescription");
			this._schoolYearTextBox.AccessibleName = resources.GetString("_schoolYearTextBox.AccessibleName");
			this._schoolYearTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_schoolYearTextBox.Anchor")));
			this._schoolYearTextBox.AutoSize = ((bool)(resources.GetObject("_schoolYearTextBox.AutoSize")));
			this._schoolYearTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_schoolYearTextBox.BackgroundImage")));
			this._schoolYearTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_schoolYearTextBox.Dock")));
			this._schoolYearTextBox.Enabled = ((bool)(resources.GetObject("_schoolYearTextBox.Enabled")));
			this._schoolYearTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_schoolYearTextBox.Font")));
			this._schoolYearTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_schoolYearTextBox.ImeMode")));
			this._schoolYearTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_schoolYearTextBox.Location")));
			this._schoolYearTextBox.MaxLength = ((int)(resources.GetObject("_schoolYearTextBox.MaxLength")));
			this._schoolYearTextBox.Multiline = ((bool)(resources.GetObject("_schoolYearTextBox.Multiline")));
			this._schoolYearTextBox.Name = "_schoolYearTextBox";
			this._schoolYearTextBox.PasswordChar = ((char)(resources.GetObject("_schoolYearTextBox.PasswordChar")));
			this._schoolYearTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_schoolYearTextBox.RightToLeft")));
			this._schoolYearTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_schoolYearTextBox.ScrollBars")));
			this._schoolYearTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_schoolYearTextBox.Size")));
			this._schoolYearTextBox.TabIndex = ((int)(resources.GetObject("_schoolYearTextBox.TabIndex")));
			this._schoolYearTextBox.Text = resources.GetString("_schoolYearTextBox.Text");
			this._schoolYearTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_schoolYearTextBox.TextAlign")));
			this._schoolYearTextBox.Visible = ((bool)(resources.GetObject("_schoolYearTextBox.Visible")));
			this._schoolYearTextBox.WordWrap = ((bool)(resources.GetObject("_schoolYearTextBox.WordWrap")));
			this._schoolYearTextBox.TextChanged += new System.EventHandler(this._textBox_TextChanged);
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
			// _eduInstitutionNameTextBox
			// 
			this._eduInstitutionNameTextBox.AccessibleDescription = resources.GetString("_eduInstitutionNameTextBox.AccessibleDescription");
			this._eduInstitutionNameTextBox.AccessibleName = resources.GetString("_eduInstitutionNameTextBox.AccessibleName");
			this._eduInstitutionNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_eduInstitutionNameTextBox.Anchor")));
			this._eduInstitutionNameTextBox.AutoSize = ((bool)(resources.GetObject("_eduInstitutionNameTextBox.AutoSize")));
			this._eduInstitutionNameTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_eduInstitutionNameTextBox.BackgroundImage")));
			this._eduInstitutionNameTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_eduInstitutionNameTextBox.Dock")));
			this._eduInstitutionNameTextBox.Enabled = ((bool)(resources.GetObject("_eduInstitutionNameTextBox.Enabled")));
			this._eduInstitutionNameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_eduInstitutionNameTextBox.Font")));
			this._eduInstitutionNameTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_eduInstitutionNameTextBox.ImeMode")));
			this._eduInstitutionNameTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_eduInstitutionNameTextBox.Location")));
			this._eduInstitutionNameTextBox.MaxLength = ((int)(resources.GetObject("_eduInstitutionNameTextBox.MaxLength")));
			this._eduInstitutionNameTextBox.Multiline = ((bool)(resources.GetObject("_eduInstitutionNameTextBox.Multiline")));
			this._eduInstitutionNameTextBox.Name = "_eduInstitutionNameTextBox";
			this._eduInstitutionNameTextBox.PasswordChar = ((char)(resources.GetObject("_eduInstitutionNameTextBox.PasswordChar")));
			this._eduInstitutionNameTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_eduInstitutionNameTextBox.RightToLeft")));
			this._eduInstitutionNameTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_eduInstitutionNameTextBox.ScrollBars")));
			this._eduInstitutionNameTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_eduInstitutionNameTextBox.Size")));
			this._eduInstitutionNameTextBox.TabIndex = ((int)(resources.GetObject("_eduInstitutionNameTextBox.TabIndex")));
			this._eduInstitutionNameTextBox.Text = resources.GetString("_eduInstitutionNameTextBox.Text");
			this._eduInstitutionNameTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_eduInstitutionNameTextBox.TextAlign")));
			this._eduInstitutionNameTextBox.Visible = ((bool)(resources.GetObject("_eduInstitutionNameTextBox.Visible")));
			this._eduInstitutionNameTextBox.WordWrap = ((bool)(resources.GetObject("_eduInstitutionNameTextBox.WordWrap")));
			this._eduInstitutionNameTextBox.TextChanged += new System.EventHandler(this._textBox_TextChanged);
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
			// _docTypeComboBox
			// 
			this._docTypeComboBox.AccessibleDescription = resources.GetString("_docTypeComboBox.AccessibleDescription");
			this._docTypeComboBox.AccessibleName = resources.GetString("_docTypeComboBox.AccessibleName");
			this._docTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_docTypeComboBox.Anchor")));
			this._docTypeComboBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_docTypeComboBox.BackgroundImage")));
			this._docTypeComboBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_docTypeComboBox.Dock")));
			this._docTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._docTypeComboBox.Enabled = ((bool)(resources.GetObject("_docTypeComboBox.Enabled")));
			this._docTypeComboBox.Font = ((System.Drawing.Font)(resources.GetObject("_docTypeComboBox.Font")));
			this._docTypeComboBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_docTypeComboBox.ImeMode")));
			this._docTypeComboBox.IntegralHeight = ((bool)(resources.GetObject("_docTypeComboBox.IntegralHeight")));
			this._docTypeComboBox.ItemHeight = ((int)(resources.GetObject("_docTypeComboBox.ItemHeight")));
			this._docTypeComboBox.Location = ((System.Drawing.Point)(resources.GetObject("_docTypeComboBox.Location")));
			this._docTypeComboBox.MaxDropDownItems = ((int)(resources.GetObject("_docTypeComboBox.MaxDropDownItems")));
			this._docTypeComboBox.MaxLength = ((int)(resources.GetObject("_docTypeComboBox.MaxLength")));
			this._docTypeComboBox.Name = "_docTypeComboBox";
			this._docTypeComboBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_docTypeComboBox.RightToLeft")));
			this._docTypeComboBox.Size = ((System.Drawing.Size)(resources.GetObject("_docTypeComboBox.Size")));
			this._docTypeComboBox.TabIndex = ((int)(resources.GetObject("_docTypeComboBox.TabIndex")));
			this._docTypeComboBox.Text = resources.GetString("_docTypeComboBox.Text");
			this._docTypeComboBox.Visible = ((bool)(resources.GetObject("_docTypeComboBox.Visible")));
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
			// DocumentPropertiesForm
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
			this.Controls.Add(this._docTypeComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._eduInstitutionNameTextBox);
			this.Controls.Add(this._schoolYearTextBox);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
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
			this.Name = "DocumentPropertiesForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.SchoolYearForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void _textBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_schoolYearTextBox.Text.Trim()!="" && _eduInstitutionNameTextBox.Text.Trim()!="") 
			{
				_okButton.Enabled=true;

			} 
			else 
			{
				_okButton.Enabled=false;

			}
		}		

		public string getSchoolYear()
		{
			return _schoolYearTextBox.Text.Trim();
		}

		public string getEduInstitutionNameInput()
		{
			return _eduInstitutionNameTextBox.Text.Trim();
		}

		public int getDocumentType()
		{	
			return _docTypeComboBox.SelectedIndex+1;
		}

		private void SchoolYearForm_Load(object sender, System.EventArgs e)
		{
			if(!_isNew)
			{				
				this._schoolYearTextBox.Text = AppForm.CURR_OCTT_DOC.SchoolYear;
				this._eduInstitutionNameTextBox.Text = AppForm.CURR_OCTT_DOC.EduInstitutionName;				
				this._docTypeComboBox.SelectedIndex=AppForm.CURR_OCTT_DOC.DocumentType-1;
				
			}
			else
			{				
				this._schoolYearTextBox.Text = Settings.SCHOOL_YEAR_SETT;
				this._eduInstitutionNameTextBox.Text =Settings.EDU_INSTITUTION_NAME_SETT;				
				
			}
		
		}
		
	}
}
