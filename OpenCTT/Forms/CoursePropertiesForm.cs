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
	/// Summary description for CoursePropertiesForm.
	/// </summary>
	public class CoursePropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isAllEnabled;
		private bool _isNew;
		private Course _course;
	
		private bool _isNameOK=true;
		private bool _isNumOfLessonsPerWeekOK=false;
		private bool _isNumOfEnrStudentsOK=false;
		private bool _isGroupNameOK=true;


		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label _groupNameLabel;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _numOfLessonsPerWeekTextBox;
		private System.Windows.Forms.TextBox _numOfEnrolledStudentsTextBox;
		private System.Windows.Forms.ComboBox _teacherComboBox;
		private System.Windows.Forms.CheckBox _isGroupCheckBox;
		private System.Windows.Forms.TextBox _groupNameTextBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _shortNameTextBox;
		private System.Windows.Forms.ErrorProvider _errorProvider1;
		private System.Windows.Forms.ErrorProvider _errorProvider2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox _extIDTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox _courseTypeComboBox;
				
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public CoursePropertiesForm()
		{

			InitializeComponent();
		
			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CoursePropertiesFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CoursePropertiesFormSchool",this.GetType().Assembly);
			}	

			_isNew=true;
			_isAllEnabled=true;

			_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,"");
			_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,"");
			
			_teacherComboBox.DataSource=AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes;
			_teacherComboBox.DisplayMember="Text";

			_courseTypeComboBox.DataSource=AppForm.CURR_OCTT_DOC.CourseTypesList;

		}

		public CoursePropertiesForm(Course course, bool isAllEnabled):this()
		{
			_course=course;

			_isNew=false;
			_isAllEnabled=isAllEnabled;

			this._nameTextBox.Text=_course.getName();
			this._shortNameTextBox.Text=_course.getShortName();
			this._teacherComboBox.SelectedItem=_course.getTeacher();
			this._numOfLessonsPerWeekTextBox.Text=_course.getNumberOfLessonsPerWeek().ToString();
			this._numOfEnrolledStudentsTextBox.Text=_course.getNumberOfEnrolledStudents().ToString();
			this._isGroupCheckBox.Checked=_course.getIsGroup();
                
			this._extIDTextBox.Text=_course.ExtID;
			this._courseTypeComboBox.SelectedItem=_course.CourseType;

			if(_course.getIsGroup()) 
			{
				this._groupNameLabel.Enabled=true;
				this._groupNameTextBox.Enabled=true;
				this._groupNameTextBox.Text=_course.getGroupName();
			} 
			else 
			{
				this._groupNameLabel.Enabled=false;
				this._groupNameTextBox.Enabled=false;
				this._groupNameTextBox.Text="";
			}

			if(!_isAllEnabled)
			{
				label2.Enabled=false;
				label3.Enabled=false;
				label4.Enabled=false;
				_isGroupCheckBox.Enabled=false;
				_groupNameLabel.Enabled=false;
				_groupNameTextBox.Enabled=false;
				_numOfLessonsPerWeekTextBox.Enabled=false;
				_numOfEnrolledStudentsTextBox.Enabled=false;
				_teacherComboBox.Enabled=false;					

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CoursePropertiesForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this._groupNameLabel = new System.Windows.Forms.Label();
			this._nameTextBox = new System.Windows.Forms.TextBox();
			this._numOfLessonsPerWeekTextBox = new System.Windows.Forms.TextBox();
			this._numOfEnrolledStudentsTextBox = new System.Windows.Forms.TextBox();
			this._teacherComboBox = new System.Windows.Forms.ComboBox();
			this._isGroupCheckBox = new System.Windows.Forms.CheckBox();
			this._groupNameTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this._shortNameTextBox = new System.Windows.Forms.TextBox();
			this._errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.label6 = new System.Windows.Forms.Label();
			this._extIDTextBox = new System.Windows.Forms.TextBox();
			this._courseTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this._errorProvider2 = new System.Windows.Forms.ErrorProvider();
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
			this._errorProvider2.SetError(this.label1, resources.GetString("label1.Error1"));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this._errorProvider1.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
			this._errorProvider1.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding1"))));
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
			this._errorProvider2.SetError(this.label2, resources.GetString("label2.Error1"));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this._errorProvider1.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
			this._errorProvider1.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding1"))));
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
			this._errorProvider1.SetError(this.label3, resources.GetString("label3.Error"));
			this._errorProvider2.SetError(this.label3, resources.GetString("label3.Error1"));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this._errorProvider1.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
			this._errorProvider2.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding1"))));
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
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this._errorProvider1.SetError(this.label4, resources.GetString("label4.Error"));
			this._errorProvider2.SetError(this.label4, resources.GetString("label4.Error1"));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this._errorProvider1.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
			this._errorProvider1.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding1"))));
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
			// _groupNameLabel
			// 
			this._groupNameLabel.AccessibleDescription = resources.GetString("_groupNameLabel.AccessibleDescription");
			this._groupNameLabel.AccessibleName = resources.GetString("_groupNameLabel.AccessibleName");
			this._groupNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_groupNameLabel.Anchor")));
			this._groupNameLabel.AutoSize = ((bool)(resources.GetObject("_groupNameLabel.AutoSize")));
			this._groupNameLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_groupNameLabel.Dock")));
			this._groupNameLabel.Enabled = ((bool)(resources.GetObject("_groupNameLabel.Enabled")));
			this._errorProvider1.SetError(this._groupNameLabel, resources.GetString("_groupNameLabel.Error"));
			this._errorProvider2.SetError(this._groupNameLabel, resources.GetString("_groupNameLabel.Error1"));
			this._groupNameLabel.Font = ((System.Drawing.Font)(resources.GetObject("_groupNameLabel.Font")));
			this._errorProvider1.SetIconAlignment(this._groupNameLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_groupNameLabel.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this._groupNameLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_groupNameLabel.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this._groupNameLabel, ((int)(resources.GetObject("_groupNameLabel.IconPadding"))));
			this._errorProvider1.SetIconPadding(this._groupNameLabel, ((int)(resources.GetObject("_groupNameLabel.IconPadding1"))));
			this._groupNameLabel.Image = ((System.Drawing.Image)(resources.GetObject("_groupNameLabel.Image")));
			this._groupNameLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_groupNameLabel.ImageAlign")));
			this._groupNameLabel.ImageIndex = ((int)(resources.GetObject("_groupNameLabel.ImageIndex")));
			this._groupNameLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_groupNameLabel.ImeMode")));
			this._groupNameLabel.Location = ((System.Drawing.Point)(resources.GetObject("_groupNameLabel.Location")));
			this._groupNameLabel.Name = "_groupNameLabel";
			this._groupNameLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_groupNameLabel.RightToLeft")));
			this._groupNameLabel.Size = ((System.Drawing.Size)(resources.GetObject("_groupNameLabel.Size")));
			this._groupNameLabel.TabIndex = ((int)(resources.GetObject("_groupNameLabel.TabIndex")));
			this._groupNameLabel.Text = resources.GetString("_groupNameLabel.Text");
			this._groupNameLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_groupNameLabel.TextAlign")));
			this._groupNameLabel.Visible = ((bool)(resources.GetObject("_groupNameLabel.Visible")));
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
			this._errorProvider2.SetError(this._nameTextBox, resources.GetString("_nameTextBox.Error1"));
			this._nameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_nameTextBox.Font")));
			this._errorProvider2.SetIconAlignment(this._nameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_nameTextBox.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._nameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_nameTextBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._nameTextBox, ((int)(resources.GetObject("_nameTextBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._nameTextBox, ((int)(resources.GetObject("_nameTextBox.IconPadding1"))));
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
			// _numOfLessonsPerWeekTextBox
			// 
			this._numOfLessonsPerWeekTextBox.AccessibleDescription = resources.GetString("_numOfLessonsPerWeekTextBox.AccessibleDescription");
			this._numOfLessonsPerWeekTextBox.AccessibleName = resources.GetString("_numOfLessonsPerWeekTextBox.AccessibleName");
			this._numOfLessonsPerWeekTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_numOfLessonsPerWeekTextBox.Anchor")));
			this._numOfLessonsPerWeekTextBox.AutoSize = ((bool)(resources.GetObject("_numOfLessonsPerWeekTextBox.AutoSize")));
			this._numOfLessonsPerWeekTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_numOfLessonsPerWeekTextBox.BackgroundImage")));
			this._numOfLessonsPerWeekTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_numOfLessonsPerWeekTextBox.Dock")));
			this._numOfLessonsPerWeekTextBox.Enabled = ((bool)(resources.GetObject("_numOfLessonsPerWeekTextBox.Enabled")));
			this._errorProvider1.SetError(this._numOfLessonsPerWeekTextBox, resources.GetString("_numOfLessonsPerWeekTextBox.Error"));
			this._errorProvider2.SetError(this._numOfLessonsPerWeekTextBox, resources.GetString("_numOfLessonsPerWeekTextBox.Error1"));
			this._numOfLessonsPerWeekTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_numOfLessonsPerWeekTextBox.Font")));
			this._errorProvider2.SetIconAlignment(this._numOfLessonsPerWeekTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_numOfLessonsPerWeekTextBox.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._numOfLessonsPerWeekTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_numOfLessonsPerWeekTextBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._numOfLessonsPerWeekTextBox, ((int)(resources.GetObject("_numOfLessonsPerWeekTextBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._numOfLessonsPerWeekTextBox, ((int)(resources.GetObject("_numOfLessonsPerWeekTextBox.IconPadding1"))));
			this._numOfLessonsPerWeekTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_numOfLessonsPerWeekTextBox.ImeMode")));
			this._numOfLessonsPerWeekTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_numOfLessonsPerWeekTextBox.Location")));
			this._numOfLessonsPerWeekTextBox.MaxLength = ((int)(resources.GetObject("_numOfLessonsPerWeekTextBox.MaxLength")));
			this._numOfLessonsPerWeekTextBox.Multiline = ((bool)(resources.GetObject("_numOfLessonsPerWeekTextBox.Multiline")));
			this._numOfLessonsPerWeekTextBox.Name = "_numOfLessonsPerWeekTextBox";
			this._numOfLessonsPerWeekTextBox.PasswordChar = ((char)(resources.GetObject("_numOfLessonsPerWeekTextBox.PasswordChar")));
			this._numOfLessonsPerWeekTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_numOfLessonsPerWeekTextBox.RightToLeft")));
			this._numOfLessonsPerWeekTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_numOfLessonsPerWeekTextBox.ScrollBars")));
			this._numOfLessonsPerWeekTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_numOfLessonsPerWeekTextBox.Size")));
			this._numOfLessonsPerWeekTextBox.TabIndex = ((int)(resources.GetObject("_numOfLessonsPerWeekTextBox.TabIndex")));
			this._numOfLessonsPerWeekTextBox.Text = resources.GetString("_numOfLessonsPerWeekTextBox.Text");
			this._numOfLessonsPerWeekTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_numOfLessonsPerWeekTextBox.TextAlign")));
			this._numOfLessonsPerWeekTextBox.Visible = ((bool)(resources.GetObject("_numOfLessonsPerWeekTextBox.Visible")));
			this._numOfLessonsPerWeekTextBox.WordWrap = ((bool)(resources.GetObject("_numOfLessonsPerWeekTextBox.WordWrap")));
			this._numOfLessonsPerWeekTextBox.TextChanged += new System.EventHandler(this._numOfLessPerWeekTextBox_TextChanged);
			// 
			// _numOfEnrolledStudentsTextBox
			// 
			this._numOfEnrolledStudentsTextBox.AccessibleDescription = resources.GetString("_numOfEnrolledStudentsTextBox.AccessibleDescription");
			this._numOfEnrolledStudentsTextBox.AccessibleName = resources.GetString("_numOfEnrolledStudentsTextBox.AccessibleName");
			this._numOfEnrolledStudentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_numOfEnrolledStudentsTextBox.Anchor")));
			this._numOfEnrolledStudentsTextBox.AutoSize = ((bool)(resources.GetObject("_numOfEnrolledStudentsTextBox.AutoSize")));
			this._numOfEnrolledStudentsTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_numOfEnrolledStudentsTextBox.BackgroundImage")));
			this._numOfEnrolledStudentsTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_numOfEnrolledStudentsTextBox.Dock")));
			this._numOfEnrolledStudentsTextBox.Enabled = ((bool)(resources.GetObject("_numOfEnrolledStudentsTextBox.Enabled")));
			this._errorProvider1.SetError(this._numOfEnrolledStudentsTextBox, resources.GetString("_numOfEnrolledStudentsTextBox.Error"));
			this._errorProvider2.SetError(this._numOfEnrolledStudentsTextBox, resources.GetString("_numOfEnrolledStudentsTextBox.Error1"));
			this._numOfEnrolledStudentsTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_numOfEnrolledStudentsTextBox.Font")));
			this._errorProvider2.SetIconAlignment(this._numOfEnrolledStudentsTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_numOfEnrolledStudentsTextBox.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._numOfEnrolledStudentsTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_numOfEnrolledStudentsTextBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._numOfEnrolledStudentsTextBox, ((int)(resources.GetObject("_numOfEnrolledStudentsTextBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._numOfEnrolledStudentsTextBox, ((int)(resources.GetObject("_numOfEnrolledStudentsTextBox.IconPadding1"))));
			this._numOfEnrolledStudentsTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_numOfEnrolledStudentsTextBox.ImeMode")));
			this._numOfEnrolledStudentsTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_numOfEnrolledStudentsTextBox.Location")));
			this._numOfEnrolledStudentsTextBox.MaxLength = ((int)(resources.GetObject("_numOfEnrolledStudentsTextBox.MaxLength")));
			this._numOfEnrolledStudentsTextBox.Multiline = ((bool)(resources.GetObject("_numOfEnrolledStudentsTextBox.Multiline")));
			this._numOfEnrolledStudentsTextBox.Name = "_numOfEnrolledStudentsTextBox";
			this._numOfEnrolledStudentsTextBox.PasswordChar = ((char)(resources.GetObject("_numOfEnrolledStudentsTextBox.PasswordChar")));
			this._numOfEnrolledStudentsTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_numOfEnrolledStudentsTextBox.RightToLeft")));
			this._numOfEnrolledStudentsTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_numOfEnrolledStudentsTextBox.ScrollBars")));
			this._numOfEnrolledStudentsTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_numOfEnrolledStudentsTextBox.Size")));
			this._numOfEnrolledStudentsTextBox.TabIndex = ((int)(resources.GetObject("_numOfEnrolledStudentsTextBox.TabIndex")));
			this._numOfEnrolledStudentsTextBox.Text = resources.GetString("_numOfEnrolledStudentsTextBox.Text");
			this._numOfEnrolledStudentsTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_numOfEnrolledStudentsTextBox.TextAlign")));
			this._numOfEnrolledStudentsTextBox.Visible = ((bool)(resources.GetObject("_numOfEnrolledStudentsTextBox.Visible")));
			this._numOfEnrolledStudentsTextBox.WordWrap = ((bool)(resources.GetObject("_numOfEnrolledStudentsTextBox.WordWrap")));
			this._numOfEnrolledStudentsTextBox.TextChanged += new System.EventHandler(this._numOfEnrStudentsTextBox_TextChanged);
			// 
			// _teacherComboBox
			// 
			this._teacherComboBox.AccessibleDescription = resources.GetString("_teacherComboBox.AccessibleDescription");
			this._teacherComboBox.AccessibleName = resources.GetString("_teacherComboBox.AccessibleName");
			this._teacherComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_teacherComboBox.Anchor")));
			this._teacherComboBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_teacherComboBox.BackgroundImage")));
			this._teacherComboBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_teacherComboBox.Dock")));
			this._teacherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._teacherComboBox.Enabled = ((bool)(resources.GetObject("_teacherComboBox.Enabled")));
			this._errorProvider1.SetError(this._teacherComboBox, resources.GetString("_teacherComboBox.Error"));
			this._errorProvider2.SetError(this._teacherComboBox, resources.GetString("_teacherComboBox.Error1"));
			this._teacherComboBox.Font = ((System.Drawing.Font)(resources.GetObject("_teacherComboBox.Font")));
			this._errorProvider1.SetIconAlignment(this._teacherComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_teacherComboBox.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this._teacherComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_teacherComboBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._teacherComboBox, ((int)(resources.GetObject("_teacherComboBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._teacherComboBox, ((int)(resources.GetObject("_teacherComboBox.IconPadding1"))));
			this._teacherComboBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_teacherComboBox.ImeMode")));
			this._teacherComboBox.IntegralHeight = ((bool)(resources.GetObject("_teacherComboBox.IntegralHeight")));
			this._teacherComboBox.ItemHeight = ((int)(resources.GetObject("_teacherComboBox.ItemHeight")));
			this._teacherComboBox.Location = ((System.Drawing.Point)(resources.GetObject("_teacherComboBox.Location")));
			this._teacherComboBox.MaxDropDownItems = ((int)(resources.GetObject("_teacherComboBox.MaxDropDownItems")));
			this._teacherComboBox.MaxLength = ((int)(resources.GetObject("_teacherComboBox.MaxLength")));
			this._teacherComboBox.Name = "_teacherComboBox";
			this._teacherComboBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_teacherComboBox.RightToLeft")));
			this._teacherComboBox.Size = ((System.Drawing.Size)(resources.GetObject("_teacherComboBox.Size")));
			this._teacherComboBox.Sorted = true;
			this._teacherComboBox.TabIndex = ((int)(resources.GetObject("_teacherComboBox.TabIndex")));
			this._teacherComboBox.Text = resources.GetString("_teacherComboBox.Text");
			this._teacherComboBox.Visible = ((bool)(resources.GetObject("_teacherComboBox.Visible")));
			// 
			// _isGroupCheckBox
			// 
			this._isGroupCheckBox.AccessibleDescription = resources.GetString("_isGroupCheckBox.AccessibleDescription");
			this._isGroupCheckBox.AccessibleName = resources.GetString("_isGroupCheckBox.AccessibleName");
			this._isGroupCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_isGroupCheckBox.Anchor")));
			this._isGroupCheckBox.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("_isGroupCheckBox.Appearance")));
			this._isGroupCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_isGroupCheckBox.BackgroundImage")));
			this._isGroupCheckBox.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_isGroupCheckBox.CheckAlign")));
			this._isGroupCheckBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_isGroupCheckBox.Dock")));
			this._isGroupCheckBox.Enabled = ((bool)(resources.GetObject("_isGroupCheckBox.Enabled")));
			this._errorProvider2.SetError(this._isGroupCheckBox, resources.GetString("_isGroupCheckBox.Error"));
			this._errorProvider1.SetError(this._isGroupCheckBox, resources.GetString("_isGroupCheckBox.Error1"));
			this._isGroupCheckBox.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_isGroupCheckBox.FlatStyle")));
			this._isGroupCheckBox.Font = ((System.Drawing.Font)(resources.GetObject("_isGroupCheckBox.Font")));
			this._errorProvider1.SetIconAlignment(this._isGroupCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_isGroupCheckBox.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this._isGroupCheckBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_isGroupCheckBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._isGroupCheckBox, ((int)(resources.GetObject("_isGroupCheckBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._isGroupCheckBox, ((int)(resources.GetObject("_isGroupCheckBox.IconPadding1"))));
			this._isGroupCheckBox.Image = ((System.Drawing.Image)(resources.GetObject("_isGroupCheckBox.Image")));
			this._isGroupCheckBox.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_isGroupCheckBox.ImageAlign")));
			this._isGroupCheckBox.ImageIndex = ((int)(resources.GetObject("_isGroupCheckBox.ImageIndex")));
			this._isGroupCheckBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_isGroupCheckBox.ImeMode")));
			this._isGroupCheckBox.Location = ((System.Drawing.Point)(resources.GetObject("_isGroupCheckBox.Location")));
			this._isGroupCheckBox.Name = "_isGroupCheckBox";
			this._isGroupCheckBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_isGroupCheckBox.RightToLeft")));
			this._isGroupCheckBox.Size = ((System.Drawing.Size)(resources.GetObject("_isGroupCheckBox.Size")));
			this._isGroupCheckBox.TabIndex = ((int)(resources.GetObject("_isGroupCheckBox.TabIndex")));
			this._isGroupCheckBox.Text = resources.GetString("_isGroupCheckBox.Text");
			this._isGroupCheckBox.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_isGroupCheckBox.TextAlign")));
			this._isGroupCheckBox.Visible = ((bool)(resources.GetObject("_isGroupCheckBox.Visible")));
			this._isGroupCheckBox.CheckedChanged += new System.EventHandler(this._grupaCheckBox_CheckedChanged);
			// 
			// _groupNameTextBox
			// 
			this._groupNameTextBox.AccessibleDescription = resources.GetString("_groupNameTextBox.AccessibleDescription");
			this._groupNameTextBox.AccessibleName = resources.GetString("_groupNameTextBox.AccessibleName");
			this._groupNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_groupNameTextBox.Anchor")));
			this._groupNameTextBox.AutoSize = ((bool)(resources.GetObject("_groupNameTextBox.AutoSize")));
			this._groupNameTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_groupNameTextBox.BackgroundImage")));
			this._groupNameTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_groupNameTextBox.Dock")));
			this._groupNameTextBox.Enabled = ((bool)(resources.GetObject("_groupNameTextBox.Enabled")));
			this._errorProvider1.SetError(this._groupNameTextBox, resources.GetString("_groupNameTextBox.Error"));
			this._errorProvider2.SetError(this._groupNameTextBox, resources.GetString("_groupNameTextBox.Error1"));
			this._groupNameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_groupNameTextBox.Font")));
			this._errorProvider2.SetIconAlignment(this._groupNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_groupNameTextBox.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._groupNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_groupNameTextBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._groupNameTextBox, ((int)(resources.GetObject("_groupNameTextBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._groupNameTextBox, ((int)(resources.GetObject("_groupNameTextBox.IconPadding1"))));
			this._groupNameTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_groupNameTextBox.ImeMode")));
			this._groupNameTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_groupNameTextBox.Location")));
			this._groupNameTextBox.MaxLength = ((int)(resources.GetObject("_groupNameTextBox.MaxLength")));
			this._groupNameTextBox.Multiline = ((bool)(resources.GetObject("_groupNameTextBox.Multiline")));
			this._groupNameTextBox.Name = "_groupNameTextBox";
			this._groupNameTextBox.PasswordChar = ((char)(resources.GetObject("_groupNameTextBox.PasswordChar")));
			this._groupNameTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_groupNameTextBox.RightToLeft")));
			this._groupNameTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_groupNameTextBox.ScrollBars")));
			this._groupNameTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_groupNameTextBox.Size")));
			this._groupNameTextBox.TabIndex = ((int)(resources.GetObject("_groupNameTextBox.TabIndex")));
			this._groupNameTextBox.Text = resources.GetString("_groupNameTextBox.Text");
			this._groupNameTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_groupNameTextBox.TextAlign")));
			this._groupNameTextBox.Visible = ((bool)(resources.GetObject("_groupNameTextBox.Visible")));
			this._groupNameTextBox.WordWrap = ((bool)(resources.GetObject("_groupNameTextBox.WordWrap")));
			this._groupNameTextBox.TextChanged += new System.EventHandler(this._groupNameTextBox_TextChanged);
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
			this._errorProvider2.SetError(this._okButton, resources.GetString("_okButton.Error"));
			this._errorProvider1.SetError(this._okButton, resources.GetString("_okButton.Error1"));
			this._okButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_okButton.FlatStyle")));
			this._okButton.Font = ((System.Drawing.Font)(resources.GetObject("_okButton.Font")));
			this._errorProvider2.SetIconAlignment(this._okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_okButton.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._okButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_okButton.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._okButton, ((int)(resources.GetObject("_okButton.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._okButton, ((int)(resources.GetObject("_okButton.IconPadding1"))));
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
			this._errorProvider2.SetError(this._cancelButton, resources.GetString("_cancelButton.Error"));
			this._errorProvider1.SetError(this._cancelButton, resources.GetString("_cancelButton.Error1"));
			this._cancelButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_cancelButton.FlatStyle")));
			this._cancelButton.Font = ((System.Drawing.Font)(resources.GetObject("_cancelButton.Font")));
			this._errorProvider2.SetIconAlignment(this._cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_cancelButton.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._cancelButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_cancelButton.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._cancelButton, ((int)(resources.GetObject("_cancelButton.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._cancelButton, ((int)(resources.GetObject("_cancelButton.IconPadding1"))));
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
			// label5
			// 
			this.label5.AccessibleDescription = resources.GetString("label5.AccessibleDescription");
			this.label5.AccessibleName = resources.GetString("label5.AccessibleName");
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label5.Anchor")));
			this.label5.AutoSize = ((bool)(resources.GetObject("label5.AutoSize")));
			this.label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label5.Dock")));
			this.label5.Enabled = ((bool)(resources.GetObject("label5.Enabled")));
			this._errorProvider2.SetError(this.label5, resources.GetString("label5.Error"));
			this._errorProvider1.SetError(this.label5, resources.GetString("label5.Error1"));
			this.label5.Font = ((System.Drawing.Font)(resources.GetObject("label5.Font")));
			this._errorProvider1.SetIconAlignment(this.label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label5, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label5.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this.label5, ((int)(resources.GetObject("label5.IconPadding"))));
			this._errorProvider1.SetIconPadding(this.label5, ((int)(resources.GetObject("label5.IconPadding1"))));
			this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
			this.label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.ImageAlign")));
			this.label5.ImageIndex = ((int)(resources.GetObject("label5.ImageIndex")));
			this.label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label5.ImeMode")));
			this.label5.Location = ((System.Drawing.Point)(resources.GetObject("label5.Location")));
			this.label5.Name = "label5";
			this.label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label5.RightToLeft")));
			this.label5.Size = ((System.Drawing.Size)(resources.GetObject("label5.Size")));
			this.label5.TabIndex = ((int)(resources.GetObject("label5.TabIndex")));
			this.label5.Text = resources.GetString("label5.Text");
			this.label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.TextAlign")));
			this.label5.Visible = ((bool)(resources.GetObject("label5.Visible")));
			// 
			// _shortNameTextBox
			// 
			this._shortNameTextBox.AccessibleDescription = resources.GetString("_shortNameTextBox.AccessibleDescription");
			this._shortNameTextBox.AccessibleName = resources.GetString("_shortNameTextBox.AccessibleName");
			this._shortNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_shortNameTextBox.Anchor")));
			this._shortNameTextBox.AutoSize = ((bool)(resources.GetObject("_shortNameTextBox.AutoSize")));
			this._shortNameTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_shortNameTextBox.BackgroundImage")));
			this._shortNameTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_shortNameTextBox.Dock")));
			this._shortNameTextBox.Enabled = ((bool)(resources.GetObject("_shortNameTextBox.Enabled")));
			this._errorProvider2.SetError(this._shortNameTextBox, resources.GetString("_shortNameTextBox.Error"));
			this._errorProvider1.SetError(this._shortNameTextBox, resources.GetString("_shortNameTextBox.Error1"));
			this._shortNameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_shortNameTextBox.Font")));
			this._errorProvider1.SetIconAlignment(this._shortNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_shortNameTextBox.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this._shortNameTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_shortNameTextBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._shortNameTextBox, ((int)(resources.GetObject("_shortNameTextBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._shortNameTextBox, ((int)(resources.GetObject("_shortNameTextBox.IconPadding1"))));
			this._shortNameTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_shortNameTextBox.ImeMode")));
			this._shortNameTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_shortNameTextBox.Location")));
			this._shortNameTextBox.MaxLength = ((int)(resources.GetObject("_shortNameTextBox.MaxLength")));
			this._shortNameTextBox.Multiline = ((bool)(resources.GetObject("_shortNameTextBox.Multiline")));
			this._shortNameTextBox.Name = "_shortNameTextBox";
			this._shortNameTextBox.PasswordChar = ((char)(resources.GetObject("_shortNameTextBox.PasswordChar")));
			this._shortNameTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_shortNameTextBox.RightToLeft")));
			this._shortNameTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_shortNameTextBox.ScrollBars")));
			this._shortNameTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_shortNameTextBox.Size")));
			this._shortNameTextBox.TabIndex = ((int)(resources.GetObject("_shortNameTextBox.TabIndex")));
			this._shortNameTextBox.Text = resources.GetString("_shortNameTextBox.Text");
			this._shortNameTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_shortNameTextBox.TextAlign")));
			this._shortNameTextBox.Visible = ((bool)(resources.GetObject("_shortNameTextBox.Visible")));
			this._shortNameTextBox.WordWrap = ((bool)(resources.GetObject("_shortNameTextBox.WordWrap")));
			this._shortNameTextBox.TextChanged += new System.EventHandler(this._nameTextBox_TextChanged);
			// 
			// _errorProvider1
			// 
			this._errorProvider1.ContainerControl = this;
			this._errorProvider1.DataMember = "";
			this._errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("_errorProvider1.Icon")));
			// 
			// label6
			// 
			this.label6.AccessibleDescription = resources.GetString("label6.AccessibleDescription");
			this.label6.AccessibleName = resources.GetString("label6.AccessibleName");
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
			this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
			this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
			this.label6.Enabled = ((bool)(resources.GetObject("label6.Enabled")));
			this._errorProvider1.SetError(this.label6, resources.GetString("label6.Error"));
			this._errorProvider2.SetError(this.label6, resources.GetString("label6.Error1"));
			this.label6.Font = ((System.Drawing.Font)(resources.GetObject("label6.Font")));
			this._errorProvider1.SetIconAlignment(this.label6, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label6.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label6, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label6.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this.label6, ((int)(resources.GetObject("label6.IconPadding"))));
			this._errorProvider1.SetIconPadding(this.label6, ((int)(resources.GetObject("label6.IconPadding1"))));
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
			this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
			this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
			this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
			this.label6.Name = "label6";
			this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
			this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
			this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
			this.label6.Text = resources.GetString("label6.Text");
			this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
			this.label6.Visible = ((bool)(resources.GetObject("label6.Visible")));
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
			this._errorProvider2.SetError(this._extIDTextBox, resources.GetString("_extIDTextBox.Error1"));
			this._extIDTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_extIDTextBox.Font")));
			this._errorProvider2.SetIconAlignment(this._extIDTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_extIDTextBox.IconAlignment"))));
			this._errorProvider1.SetIconAlignment(this._extIDTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_extIDTextBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._extIDTextBox, ((int)(resources.GetObject("_extIDTextBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._extIDTextBox, ((int)(resources.GetObject("_extIDTextBox.IconPadding1"))));
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
			// _courseTypeComboBox
			// 
			this._courseTypeComboBox.AccessibleDescription = resources.GetString("_courseTypeComboBox.AccessibleDescription");
			this._courseTypeComboBox.AccessibleName = resources.GetString("_courseTypeComboBox.AccessibleName");
			this._courseTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_courseTypeComboBox.Anchor")));
			this._courseTypeComboBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_courseTypeComboBox.BackgroundImage")));
			this._courseTypeComboBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_courseTypeComboBox.Dock")));
			this._courseTypeComboBox.Enabled = ((bool)(resources.GetObject("_courseTypeComboBox.Enabled")));
			this._errorProvider1.SetError(this._courseTypeComboBox, resources.GetString("_courseTypeComboBox.Error"));
			this._errorProvider2.SetError(this._courseTypeComboBox, resources.GetString("_courseTypeComboBox.Error1"));
			this._courseTypeComboBox.Font = ((System.Drawing.Font)(resources.GetObject("_courseTypeComboBox.Font")));
			this._errorProvider1.SetIconAlignment(this._courseTypeComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_courseTypeComboBox.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this._courseTypeComboBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("_courseTypeComboBox.IconAlignment1"))));
			this._errorProvider1.SetIconPadding(this._courseTypeComboBox, ((int)(resources.GetObject("_courseTypeComboBox.IconPadding"))));
			this._errorProvider2.SetIconPadding(this._courseTypeComboBox, ((int)(resources.GetObject("_courseTypeComboBox.IconPadding1"))));
			this._courseTypeComboBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_courseTypeComboBox.ImeMode")));
			this._courseTypeComboBox.IntegralHeight = ((bool)(resources.GetObject("_courseTypeComboBox.IntegralHeight")));
			this._courseTypeComboBox.ItemHeight = ((int)(resources.GetObject("_courseTypeComboBox.ItemHeight")));
			this._courseTypeComboBox.Location = ((System.Drawing.Point)(resources.GetObject("_courseTypeComboBox.Location")));
			this._courseTypeComboBox.MaxDropDownItems = ((int)(resources.GetObject("_courseTypeComboBox.MaxDropDownItems")));
			this._courseTypeComboBox.MaxLength = ((int)(resources.GetObject("_courseTypeComboBox.MaxLength")));
			this._courseTypeComboBox.Name = "_courseTypeComboBox";
			this._courseTypeComboBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_courseTypeComboBox.RightToLeft")));
			this._courseTypeComboBox.Size = ((System.Drawing.Size)(resources.GetObject("_courseTypeComboBox.Size")));
			this._courseTypeComboBox.Sorted = true;
			this._courseTypeComboBox.TabIndex = ((int)(resources.GetObject("_courseTypeComboBox.TabIndex")));
			this._courseTypeComboBox.Text = resources.GetString("_courseTypeComboBox.Text");
			this._courseTypeComboBox.Visible = ((bool)(resources.GetObject("_courseTypeComboBox.Visible")));
			// 
			// label7
			// 
			this.label7.AccessibleDescription = resources.GetString("label7.AccessibleDescription");
			this.label7.AccessibleName = resources.GetString("label7.AccessibleName");
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label7.Anchor")));
			this.label7.AutoSize = ((bool)(resources.GetObject("label7.AutoSize")));
			this.label7.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label7.Dock")));
			this.label7.Enabled = ((bool)(resources.GetObject("label7.Enabled")));
			this._errorProvider1.SetError(this.label7, resources.GetString("label7.Error"));
			this._errorProvider2.SetError(this.label7, resources.GetString("label7.Error1"));
			this.label7.Font = ((System.Drawing.Font)(resources.GetObject("label7.Font")));
			this._errorProvider1.SetIconAlignment(this.label7, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label7.IconAlignment"))));
			this._errorProvider2.SetIconAlignment(this.label7, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label7.IconAlignment1"))));
			this._errorProvider2.SetIconPadding(this.label7, ((int)(resources.GetObject("label7.IconPadding"))));
			this._errorProvider1.SetIconPadding(this.label7, ((int)(resources.GetObject("label7.IconPadding1"))));
			this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
			this.label7.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.ImageAlign")));
			this.label7.ImageIndex = ((int)(resources.GetObject("label7.ImageIndex")));
			this.label7.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label7.ImeMode")));
			this.label7.Location = ((System.Drawing.Point)(resources.GetObject("label7.Location")));
			this.label7.Name = "label7";
			this.label7.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label7.RightToLeft")));
			this.label7.Size = ((System.Drawing.Size)(resources.GetObject("label7.Size")));
			this.label7.TabIndex = ((int)(resources.GetObject("label7.TabIndex")));
			this.label7.Text = resources.GetString("label7.Text");
			this.label7.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label7.TextAlign")));
			this.label7.Visible = ((bool)(resources.GetObject("label7.Visible")));
			// 
			// _errorProvider2
			// 
			this._errorProvider2.ContainerControl = this;
			this._errorProvider2.DataMember = "";
			this._errorProvider2.Icon = ((System.Drawing.Icon)(resources.GetObject("_errorProvider2.Icon")));
			// 
			// CoursePropertiesForm
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
			this.Controls.Add(this.label7);
			this.Controls.Add(this._courseTypeComboBox);
			this.Controls.Add(this._extIDTextBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this._shortNameTextBox);
			this.Controls.Add(this._groupNameTextBox);
			this.Controls.Add(this._numOfEnrolledStudentsTextBox);
			this.Controls.Add(this._numOfLessonsPerWeekTextBox);
			this.Controls.Add(this._nameTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._isGroupCheckBox);
			this.Controls.Add(this._teacherComboBox);
			this.Controls.Add(this._groupNameLabel);
			this.Controls.Add(this.label4);
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
			this.Name = "CoursePropertiesForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		private void _grupaCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if(_isGroupCheckBox.Checked)
			{
				_groupNameLabel.Enabled=true;
				_groupNameTextBox.Enabled=true;
				if(_groupNameTextBox.Text.Trim()=="")
				{
                    _isGroupNameOK=false;
					_okButton.Enabled=false;
				}
				else
				{
					_isGroupNameOK=true;
				}
			} 
			else 
			{
				_groupNameLabel.Enabled=false;
				_groupNameTextBox.Enabled=false;
				_isGroupNameOK=true;
				if(_isNameOK && _isNumOfEnrStudentsOK && _isNumOfLessonsPerWeekOK)
				{
					_okButton.Enabled=true;
				}
			}
		}
		

		private void Form_Closing (Object sender, CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.OK)
			{
				string courseType=(string)_courseTypeComboBox.SelectedItem;				
				if(courseType==null)courseType=_courseTypeComboBox.Text.Trim();

				if(_isNew) 
				{
					if(Course.getIsCourseDataOK(null,_nameTextBox.Text.Trim(),_shortNameTextBox.Text.Trim(),courseType, _groupNameTextBox.Text.Trim(), _isGroupCheckBox.Checked))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;				
						
						string message1=RES_MANAGER.GetString("Form_Closing.msb.coursenotadded.message");
					
						string caption1=RES_MANAGER.GetString("Form_Closing.msb.coursenotadded.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}
				}
				else
				{
					if(Course.getIsCourseDataOK(_course,_nameTextBox.Text.Trim(),_shortNameTextBox.Text.Trim(),courseType, _groupNameTextBox.Text.Trim(), _isGroupCheckBox.Checked))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
											
						string message2=RES_MANAGER.GetString("Form_Closing.msb.coursedatanotchanged.message");
					
						string caption2=RES_MANAGER.GetString("Form_Closing.msb.coursedatanotchanged.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}

				}
			}

		}

		private void _nameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="" && _shortNameTextBox.Text.Trim()!="" && _teacherComboBox.SelectedItem!=null) 
			{
				_isNameOK=true;

				if(_isNumOfLessonsPerWeekOK && _isNumOfEnrStudentsOK && _isGroupNameOK)
				{
					_okButton.Enabled=true;
				}

			} 
			else
			{
				_isNameOK=false;
				_okButton.Enabled=false;

			}		
		}
		

		private void _numOfLessPerWeekTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				int x = Int32.Parse(_numOfLessonsPerWeekTextBox.Text);
				if(x<=0 || x>=100)
				{
					_isNumOfLessonsPerWeekOK=false;					
					_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,RES_MANAGER.GetString("_numOfLessPerWeekTextBox_TextChanged._errorProvider1.errortext"));
					_okButton.Enabled=false;
				}
				else
				{
					_isNumOfLessonsPerWeekOK=true;
					_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,"");
					if(_isNameOK && _isNumOfEnrStudentsOK && _isGroupNameOK)
					{
						_okButton.Enabled=true;
					}
				}
			}
			catch
			{
				_isNumOfLessonsPerWeekOK=false;				
				_errorProvider1.SetError(_numOfLessonsPerWeekTextBox,RES_MANAGER.GetString("_numOfLessPerWeekTextBox_TextChanged._errorProvider1.errortext"));
				_okButton.Enabled=false;
			}
		
		}

		private void _numOfEnrStudentsTextBox_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				int x = Int32.Parse(_numOfEnrolledStudentsTextBox.Text);
				if(x<=0)
				{
					_isNumOfEnrStudentsOK=false;					
					_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,RES_MANAGER.GetString("_numOfEnrStudentsTextBox_TextChanged._errorProvider2.errortext"));
					_okButton.Enabled=false;
				}
				else
				{
					_isNumOfEnrStudentsOK=true;
					_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,"");
					if(_isNameOK && _isNumOfLessonsPerWeekOK && _isGroupNameOK)
					{
						_okButton.Enabled=true;
					}
				}
			}
			catch
			{
				_isNumOfEnrStudentsOK=false;				
				_errorProvider2.SetError(_numOfEnrolledStudentsTextBox,RES_MANAGER.GetString("_numOfEnrStudentsTextBox_TextChanged._errorProvider2.errortext"));
				_okButton.Enabled=false;
			}
		
		}

		private void _groupNameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_groupNameTextBox.Text.Trim()=="")
			{
				_isGroupNameOK=false;
				_okButton.Enabled=false;
			}
			else
			{
				_isGroupNameOK=true;

				if(_isNameOK && _isNumOfEnrStudentsOK && _isNumOfLessonsPerWeekOK)
				{
					_okButton.Enabled=true;
				}
				else
				{
                    _okButton.Enabled=false;
				}
			}	
		}
	
		public TextBox NameTextBox
		{
			get
			{
				return _nameTextBox;
			}
		}

		public TextBox ShortNameTextBox
		{
			get
			{
				return _shortNameTextBox;
			}
		}

		public TextBox NumOfLessonsPerWeekTextBox
		{
			get
			{
				return _numOfLessonsPerWeekTextBox;
			}
		}

		public TextBox NumOfEnrolledStudentsTextBox
		{
			get
			{
				return _numOfEnrolledStudentsTextBox;
			}
		}

		public TextBox GroupNameTextBox
		{
			get
			{
				return _groupNameTextBox;
			}
		}

		public TextBox ExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}
		}

		public ComboBox TeacherComboBox
		{
			get
			{
				return _teacherComboBox;
			}
		}	

		public ComboBox CourseTypeComboBox
		{
			get
			{
				return _courseTypeComboBox;
			}
		}	

		public CheckBox IsGroupCheckBox
		{
			get
			{
				return _isGroupCheckBox;
			}
		}

		
	}
}
