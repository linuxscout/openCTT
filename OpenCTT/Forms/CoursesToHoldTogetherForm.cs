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
	/// Summary description for CoursesToHoldTogetherForm.
	/// </summary>
	public class CoursesToHoldTogetherForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isFormDisabled;

		private ArrayList _thtWorkingList;
		private Course _course;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ListView _thtCoursesListView;
		private System.Windows.Forms.ListView _thtPickListView;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label _topLabel;
		private System.Windows.Forms.Label _middleLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CoursesToHoldTogetherForm(Course course, bool isFormDisabled)
		{			
			InitializeComponent();

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CTHTFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.CTHTFormSchool",this.GetType().Assembly);
			}

			
			columnHeader1.Text=RES_MANAGER.GetString("columnHeader1.Text");
			columnHeader2.Text=RES_MANAGER.GetString("columnHeader2.Text");
			columnHeader3.Text=RES_MANAGER.GetString("columnHeader3.Text");
			columnHeader4.Text=RES_MANAGER.GetString("columnHeader4.Text");
			columnHeader5.Text=RES_MANAGER.GetString("columnHeader5.Text");
			columnHeader6.Text=RES_MANAGER.GetString("columnHeader6.Text");

			label1.Text=RES_MANAGER.GetString("label1.Text");

			            
			_isFormDisabled=isFormDisabled;
			_course=course;
            _thtWorkingList=new ArrayList();
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CoursesToHoldTogetherForm));
			this._thtCoursesListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._thtPickListView = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this._topLabel = new System.Windows.Forms.Label();
			this._middleLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _thtCoursesListView
			// 
			this._thtCoursesListView.AccessibleDescription = resources.GetString("_thtCoursesListView.AccessibleDescription");
			this._thtCoursesListView.AccessibleName = resources.GetString("_thtCoursesListView.AccessibleName");
			this._thtCoursesListView.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("_thtCoursesListView.Alignment")));
			this._thtCoursesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_thtCoursesListView.Anchor")));
			this._thtCoursesListView.BackColor = System.Drawing.Color.LightSteelBlue;
			this._thtCoursesListView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_thtCoursesListView.BackgroundImage")));
			this._thtCoursesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.columnHeader1,
																								  this.columnHeader2,
																								  this.columnHeader3});
			this._thtCoursesListView.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_thtCoursesListView.Dock")));
			this._thtCoursesListView.Enabled = ((bool)(resources.GetObject("_thtCoursesListView.Enabled")));
			this._thtCoursesListView.Font = ((System.Drawing.Font)(resources.GetObject("_thtCoursesListView.Font")));
			this._thtCoursesListView.FullRowSelect = true;
			this._thtCoursesListView.GridLines = true;
			this._thtCoursesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this._thtCoursesListView.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_thtCoursesListView.ImeMode")));
			this._thtCoursesListView.LabelWrap = ((bool)(resources.GetObject("_thtCoursesListView.LabelWrap")));
			this._thtCoursesListView.Location = ((System.Drawing.Point)(resources.GetObject("_thtCoursesListView.Location")));
			this._thtCoursesListView.MultiSelect = false;
			this._thtCoursesListView.Name = "_thtCoursesListView";
			this._thtCoursesListView.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_thtCoursesListView.RightToLeft")));
			this._thtCoursesListView.Size = ((System.Drawing.Size)(resources.GetObject("_thtCoursesListView.Size")));
			this._thtCoursesListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._thtCoursesListView.TabIndex = ((int)(resources.GetObject("_thtCoursesListView.TabIndex")));
			this._thtCoursesListView.Text = resources.GetString("_thtCoursesListView.Text");
			this._thtCoursesListView.View = System.Windows.Forms.View.Details;
			this._thtCoursesListView.Visible = ((bool)(resources.GetObject("_thtCoursesListView.Visible")));
			this._thtCoursesListView.DoubleClick += new System.EventHandler(this._thtCoursesListView_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = resources.GetString("columnHeader1.Text");
			this.columnHeader1.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader1.TextAlign")));
			this.columnHeader1.Width = ((int)(resources.GetObject("columnHeader1.Width")));
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = resources.GetString("columnHeader2.Text");
			this.columnHeader2.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader2.TextAlign")));
			this.columnHeader2.Width = ((int)(resources.GetObject("columnHeader2.Width")));
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = resources.GetString("columnHeader3.Text");
			this.columnHeader3.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader3.TextAlign")));
			this.columnHeader3.Width = ((int)(resources.GetObject("columnHeader3.Width")));
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
			// _thtPickListView
			// 
			this._thtPickListView.AccessibleDescription = resources.GetString("_thtPickListView.AccessibleDescription");
			this._thtPickListView.AccessibleName = resources.GetString("_thtPickListView.AccessibleName");
			this._thtPickListView.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("_thtPickListView.Alignment")));
			this._thtPickListView.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_thtPickListView.Anchor")));
			this._thtPickListView.BackColor = System.Drawing.Color.MediumAquamarine;
			this._thtPickListView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_thtPickListView.BackgroundImage")));
			this._thtPickListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.columnHeader4,
																							   this.columnHeader5,
																							   this.columnHeader6});
			this._thtPickListView.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_thtPickListView.Dock")));
			this._thtPickListView.Enabled = ((bool)(resources.GetObject("_thtPickListView.Enabled")));
			this._thtPickListView.Font = ((System.Drawing.Font)(resources.GetObject("_thtPickListView.Font")));
			this._thtPickListView.FullRowSelect = true;
			this._thtPickListView.GridLines = true;
			this._thtPickListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this._thtPickListView.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_thtPickListView.ImeMode")));
			this._thtPickListView.LabelWrap = ((bool)(resources.GetObject("_thtPickListView.LabelWrap")));
			this._thtPickListView.Location = ((System.Drawing.Point)(resources.GetObject("_thtPickListView.Location")));
			this._thtPickListView.MultiSelect = false;
			this._thtPickListView.Name = "_thtPickListView";
			this._thtPickListView.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_thtPickListView.RightToLeft")));
			this._thtPickListView.Size = ((System.Drawing.Size)(resources.GetObject("_thtPickListView.Size")));
			this._thtPickListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._thtPickListView.TabIndex = ((int)(resources.GetObject("_thtPickListView.TabIndex")));
			this._thtPickListView.Text = resources.GetString("_thtPickListView.Text");
			this._thtPickListView.View = System.Windows.Forms.View.Details;
			this._thtPickListView.Visible = ((bool)(resources.GetObject("_thtPickListView.Visible")));
			this._thtPickListView.DoubleClick += new System.EventHandler(this._thtPickListView_DoubleClick);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = resources.GetString("columnHeader4.Text");
			this.columnHeader4.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader4.TextAlign")));
			this.columnHeader4.Width = ((int)(resources.GetObject("columnHeader4.Width")));
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = resources.GetString("columnHeader5.Text");
			this.columnHeader5.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader5.TextAlign")));
			this.columnHeader5.Width = ((int)(resources.GetObject("columnHeader5.Width")));
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = resources.GetString("columnHeader6.Text");
			this.columnHeader6.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("columnHeader6.TextAlign")));
			this.columnHeader6.Width = ((int)(resources.GetObject("columnHeader6.Width")));
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
			// _middleLabel
			// 
			this._middleLabel.AccessibleDescription = resources.GetString("_middleLabel.AccessibleDescription");
			this._middleLabel.AccessibleName = resources.GetString("_middleLabel.AccessibleName");
			this._middleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_middleLabel.Anchor")));
			this._middleLabel.AutoSize = ((bool)(resources.GetObject("_middleLabel.AutoSize")));
			this._middleLabel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_middleLabel.Dock")));
			this._middleLabel.Enabled = ((bool)(resources.GetObject("_middleLabel.Enabled")));
			this._middleLabel.Font = ((System.Drawing.Font)(resources.GetObject("_middleLabel.Font")));
			this._middleLabel.Image = ((System.Drawing.Image)(resources.GetObject("_middleLabel.Image")));
			this._middleLabel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_middleLabel.ImageAlign")));
			this._middleLabel.ImageIndex = ((int)(resources.GetObject("_middleLabel.ImageIndex")));
			this._middleLabel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_middleLabel.ImeMode")));
			this._middleLabel.Location = ((System.Drawing.Point)(resources.GetObject("_middleLabel.Location")));
			this._middleLabel.Name = "_middleLabel";
			this._middleLabel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_middleLabel.RightToLeft")));
			this._middleLabel.Size = ((System.Drawing.Size)(resources.GetObject("_middleLabel.Size")));
			this._middleLabel.TabIndex = ((int)(resources.GetObject("_middleLabel.TabIndex")));
			this._middleLabel.Text = resources.GetString("_middleLabel.Text");
			this._middleLabel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_middleLabel.TextAlign")));
			this._middleLabel.Visible = ((bool)(resources.GetObject("_middleLabel.Visible")));
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
			// CoursesToHoldTogetherForm
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
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._middleLabel);
			this.Controls.Add(this._topLabel);
			this.Controls.Add(this._thtPickListView);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
			this.Controls.Add(this._thtCoursesListView);
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
			this.Name = "CoursesToHoldTogetherForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void Form_Load(object sender, System.EventArgs e)
		{			
			_topLabel.Text=RES_MANAGER.GetString("Form_Load._topLabel.Text1")+" '"+_course.getFullName()+"' "+RES_MANAGER.GetString("Form_Load._topLabel.Text2");
			
			if(_course.getCoursesToHoldTogetherList()!=null)
			{
				_thtWorkingList=(ArrayList)_course.getCoursesToHoldTogetherList().Clone();
			}
	
			foreach(Course tempCourse in _thtWorkingList)
			{
				string [] epgAndEpAndCourse= new string[3];

				EduProgram ep = (EduProgram)tempCourse.Parent;
				EduProgramGroup epg = (EduProgramGroup)ep.Parent;
				
				String textEduProgram=ep.getName()+", "+ep.getCode()+", "+ep.getSemester()+". "+RES_MANAGER.GetString("Form_Load.listView.textEduProgram.sem");

				epgAndEpAndCourse[0]=epg.getName();
				epgAndEpAndCourse[1]=textEduProgram;
				epgAndEpAndCourse[2]=tempCourse.getFullName();				
				
				ListViewItem newLvi= new ListViewItem(epgAndEpAndCourse);
				newLvi.Tag=tempCourse;
				_thtCoursesListView.Items.Add(newLvi);

			}
			
			this.fillPickListView();

			if(_isFormDisabled)
			{
				this._thtPickListView.DoubleClick -= new System.EventHandler(this._thtPickListView_DoubleClick);
				this._thtCoursesListView.DoubleClick -= new System.EventHandler(this._thtCoursesListView_DoubleClick);
			

				this.Text+=" - READ ONLY";
				_okButton.Enabled=false;

				

			}			

		}

		private void _thtPickListView_DoubleClick(object sender, System.EventArgs e)
		{
			ListView lv=(ListView)sender;
			foreach(ListViewItem lvi in lv.SelectedItems)
			{				
				_thtPickListView.Items.Clear();

				_thtWorkingList.Add((Course)lvi.Tag);
				_thtCoursesListView.Items.Add(lvi);
				
				fillPickListView();
			}

			setOKButtonState();
		}

		private void _thtCoursesListView_DoubleClick(object sender, System.EventArgs e)
		{
			ListView lv=(ListView)sender;
			foreach(ListViewItem lvi in lv.SelectedItems)
			{	
				_thtWorkingList.Remove((Course)lvi.Tag);
				lv.Items.Remove(lvi);
								
				_thtPickListView.Items.Clear();
				fillPickListView();
			}

			setOKButtonState();
		
		}

		public ArrayList getTHTWorkingList()
		{
			return _thtWorkingList;
		}

		private void fillPickListView()
		{
			EduProgram selEduProgram=(EduProgram)_course.Parent;

			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{				
				foreach(EduProgram ep in epg.Nodes)
				{
					if(ep!=selEduProgram && !isEduProgramInWorkingList(ep))
					{
						foreach(Course tempCourse in ep.Nodes)
						{
							if(!ep.getIsCourseInTimetable(tempCourse))
							{
								if(tempCourse.getTeacher()==_course.getTeacher() && tempCourse.getNumberOfLessonsPerWeek()==_course.getNumberOfLessonsPerWeek())
								{
									if(!_thtWorkingList.Contains(tempCourse))
									{	
										string textEduProgram=ep.getName()+", "+ep.getCode()+", "+ep.getSemester()+". "+RES_MANAGER.GetString("Form_Load.listView.textEduProgram.sem");

										string [] epgAndEpAndCourse= new string[3];
										epgAndEpAndCourse[0]=epg.getName();
										epgAndEpAndCourse[1]=textEduProgram;
										epgAndEpAndCourse[2]=tempCourse.getFullName();
														
										ListViewItem newLvi= new ListViewItem(epgAndEpAndCourse);
										newLvi.Tag=tempCourse;
										_thtPickListView.Items.Add(newLvi);
									}

								}
							}
						}
					}
				}
			}

		}


		private bool isEduProgramInWorkingList(EduProgram thisEP)
		{
			foreach(Course course in _thtWorkingList)
			{
				EduProgram ep=(EduProgram)course.Parent;
				if(ep==thisEP)
				{
					return true;
				}
			}
			return false;

		}

		private void setOKButtonState()
		{
			if(_course.getCoursesToHoldTogetherList()==null || _course.getCoursesToHoldTogetherList().Count==0)
			{
				if(_thtWorkingList.Count>0)
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

				foreach(Course course in _course.getCoursesToHoldTogetherList())
				{
					if(!_thtWorkingList.Contains(course))
					{
						containsAll=false;
						_okButton.Enabled=true;
						break;
					}
				}

				if(containsAll)
				{
					if(_course.getCoursesToHoldTogetherList().Count==_thtWorkingList.Count)
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
