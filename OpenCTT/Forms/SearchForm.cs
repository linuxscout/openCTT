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
	/// Summary description for SearchForm.
	/// </summary>
	public class SearchForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private static bool _instanceFlag=false;		
		private static string LAST_SEARCHED_FOR;
		private static int LAST_SEARCHED_TYPE;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _findButton;
		private System.Windows.Forms.TextBox _searchForTextBox;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ListView _resultsListView;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SearchForm()
		{			
			if(_instanceFlag)
			{
				throw new Exception();
			}
			else
			{				
				InitializeComponent();
				_instanceFlag=true;
				LAST_SEARCHED_FOR="";
				LAST_SEARCHED_TYPE=-1;

				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.SearchForm",this.GetType().Assembly);

				if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
				{				
					radioButton1.Text= RES_MANAGER.GetString("radioButton1.university.Text");

				}
				else
				{			
					radioButton1.Text= RES_MANAGER.GetString("radioButton1.school.Text");
				}
		
				
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
				_instanceFlag=false;				
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SearchForm));
			this._searchForTextBox = new System.Windows.Forms.TextBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._findButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _searchForTextBox
			// 
			this._searchForTextBox.AccessibleDescription = resources.GetString("_searchForTextBox.AccessibleDescription");
			this._searchForTextBox.AccessibleName = resources.GetString("_searchForTextBox.AccessibleName");
			this._searchForTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_searchForTextBox.Anchor")));
			this._searchForTextBox.AutoSize = ((bool)(resources.GetObject("_searchForTextBox.AutoSize")));
			this._searchForTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_searchForTextBox.BackgroundImage")));
			this._searchForTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_searchForTextBox.Dock")));
			this._searchForTextBox.Enabled = ((bool)(resources.GetObject("_searchForTextBox.Enabled")));
			this._searchForTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_searchForTextBox.Font")));
			this._searchForTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_searchForTextBox.ImeMode")));
			this._searchForTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_searchForTextBox.Location")));
			this._searchForTextBox.MaxLength = ((int)(resources.GetObject("_searchForTextBox.MaxLength")));
			this._searchForTextBox.Multiline = ((bool)(resources.GetObject("_searchForTextBox.Multiline")));
			this._searchForTextBox.Name = "_searchForTextBox";
			this._searchForTextBox.PasswordChar = ((char)(resources.GetObject("_searchForTextBox.PasswordChar")));
			this._searchForTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_searchForTextBox.RightToLeft")));
			this._searchForTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_searchForTextBox.ScrollBars")));
			this._searchForTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_searchForTextBox.Size")));
			this._searchForTextBox.TabIndex = ((int)(resources.GetObject("_searchForTextBox.TabIndex")));
			this._searchForTextBox.Text = resources.GetString("_searchForTextBox.Text");
			this._searchForTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_searchForTextBox.TextAlign")));
			this._searchForTextBox.Visible = ((bool)(resources.GetObject("_searchForTextBox.Visible")));
			this._searchForTextBox.WordWrap = ((bool)(resources.GetObject("_searchForTextBox.WordWrap")));
			this._searchForTextBox.TextChanged += new System.EventHandler(this._searchForTextBox_TextChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AccessibleDescription = resources.GetString("radioButton1.AccessibleDescription");
			this.radioButton1.AccessibleName = resources.GetString("radioButton1.AccessibleName");
			this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioButton1.Anchor")));
			this.radioButton1.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioButton1.Appearance")));
			this.radioButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton1.BackgroundImage")));
			this.radioButton1.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton1.CheckAlign")));
			this.radioButton1.Checked = true;
			this.radioButton1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioButton1.Dock")));
			this.radioButton1.Enabled = ((bool)(resources.GetObject("radioButton1.Enabled")));
			this.radioButton1.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioButton1.FlatStyle")));
			this.radioButton1.Font = ((System.Drawing.Font)(resources.GetObject("radioButton1.Font")));
			this.radioButton1.Image = ((System.Drawing.Image)(resources.GetObject("radioButton1.Image")));
			this.radioButton1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton1.ImageAlign")));
			this.radioButton1.ImageIndex = ((int)(resources.GetObject("radioButton1.ImageIndex")));
			this.radioButton1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioButton1.ImeMode")));
			this.radioButton1.Location = ((System.Drawing.Point)(resources.GetObject("radioButton1.Location")));
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioButton1.RightToLeft")));
			this.radioButton1.Size = ((System.Drawing.Size)(resources.GetObject("radioButton1.Size")));
			this.radioButton1.TabIndex = ((int)(resources.GetObject("radioButton1.TabIndex")));
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = resources.GetString("radioButton1.Text");
			this.radioButton1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton1.TextAlign")));
			this.radioButton1.Visible = ((bool)(resources.GetObject("radioButton1.Visible")));
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AccessibleDescription = resources.GetString("radioButton2.AccessibleDescription");
			this.radioButton2.AccessibleName = resources.GetString("radioButton2.AccessibleName");
			this.radioButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioButton2.Anchor")));
			this.radioButton2.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioButton2.Appearance")));
			this.radioButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton2.BackgroundImage")));
			this.radioButton2.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton2.CheckAlign")));
			this.radioButton2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioButton2.Dock")));
			this.radioButton2.Enabled = ((bool)(resources.GetObject("radioButton2.Enabled")));
			this.radioButton2.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioButton2.FlatStyle")));
			this.radioButton2.Font = ((System.Drawing.Font)(resources.GetObject("radioButton2.Font")));
			this.radioButton2.Image = ((System.Drawing.Image)(resources.GetObject("radioButton2.Image")));
			this.radioButton2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton2.ImageAlign")));
			this.radioButton2.ImageIndex = ((int)(resources.GetObject("radioButton2.ImageIndex")));
			this.radioButton2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioButton2.ImeMode")));
			this.radioButton2.Location = ((System.Drawing.Point)(resources.GetObject("radioButton2.Location")));
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioButton2.RightToLeft")));
			this.radioButton2.Size = ((System.Drawing.Size)(resources.GetObject("radioButton2.Size")));
			this.radioButton2.TabIndex = ((int)(resources.GetObject("radioButton2.TabIndex")));
			this.radioButton2.Text = resources.GetString("radioButton2.Text");
			this.radioButton2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton2.TextAlign")));
			this.radioButton2.Visible = ((bool)(resources.GetObject("radioButton2.Visible")));
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.AccessibleDescription = resources.GetString("radioButton3.AccessibleDescription");
			this.radioButton3.AccessibleName = resources.GetString("radioButton3.AccessibleName");
			this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioButton3.Anchor")));
			this.radioButton3.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioButton3.Appearance")));
			this.radioButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioButton3.BackgroundImage")));
			this.radioButton3.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton3.CheckAlign")));
			this.radioButton3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioButton3.Dock")));
			this.radioButton3.Enabled = ((bool)(resources.GetObject("radioButton3.Enabled")));
			this.radioButton3.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioButton3.FlatStyle")));
			this.radioButton3.Font = ((System.Drawing.Font)(resources.GetObject("radioButton3.Font")));
			this.radioButton3.Image = ((System.Drawing.Image)(resources.GetObject("radioButton3.Image")));
			this.radioButton3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton3.ImageAlign")));
			this.radioButton3.ImageIndex = ((int)(resources.GetObject("radioButton3.ImageIndex")));
			this.radioButton3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioButton3.ImeMode")));
			this.radioButton3.Location = ((System.Drawing.Point)(resources.GetObject("radioButton3.Location")));
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioButton3.RightToLeft")));
			this.radioButton3.Size = ((System.Drawing.Size)(resources.GetObject("radioButton3.Size")));
			this.radioButton3.TabIndex = ((int)(resources.GetObject("radioButton3.TabIndex")));
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = resources.GetString("radioButton3.Text");
			this.radioButton3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioButton3.TextAlign")));
			this.radioButton3.Visible = ((bool)(resources.GetObject("radioButton3.Visible")));
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
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
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
			this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
			// 
			// _findButton
			// 
			this._findButton.AccessibleDescription = resources.GetString("_findButton.AccessibleDescription");
			this._findButton.AccessibleName = resources.GetString("_findButton.AccessibleName");
			this._findButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_findButton.Anchor")));
			this._findButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_findButton.BackgroundImage")));
			this._findButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_findButton.Dock")));
			this._findButton.Enabled = ((bool)(resources.GetObject("_findButton.Enabled")));
			this._findButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_findButton.FlatStyle")));
			this._findButton.Font = ((System.Drawing.Font)(resources.GetObject("_findButton.Font")));
			this._findButton.Image = ((System.Drawing.Image)(resources.GetObject("_findButton.Image")));
			this._findButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_findButton.ImageAlign")));
			this._findButton.ImageIndex = ((int)(resources.GetObject("_findButton.ImageIndex")));
			this._findButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_findButton.ImeMode")));
			this._findButton.Location = ((System.Drawing.Point)(resources.GetObject("_findButton.Location")));
			this._findButton.Name = "_findButton";
			this._findButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_findButton.RightToLeft")));
			this._findButton.Size = ((System.Drawing.Size)(resources.GetObject("_findButton.Size")));
			this._findButton.TabIndex = ((int)(resources.GetObject("_findButton.TabIndex")));
			this._findButton.Text = resources.GetString("_findButton.Text");
			this._findButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_findButton.TextAlign")));
			this._findButton.Visible = ((bool)(resources.GetObject("_findButton.Visible")));
			this._findButton.Click += new System.EventHandler(this._findButton_Click);
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
			this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
			// 
			// SearchForm
			// 
			this.AcceptButton = this._findButton;
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
			this.Controls.Add(this._findButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._searchForTextBox);
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
			this.Name = "SearchForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void _cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void _findButton_Click(object sender, System.EventArgs e)
		{	
			this.ClientSize = new System.Drawing.Size(528, 410);

			if(_resultsListView==null)
			{				
				_resultsListView = new ListView();
				ColumnHeader  columnHeader1=new ColumnHeader();

				_resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  columnHeader1});
				_resultsListView.FullRowSelect = true;
				_resultsListView.GridLines = true;
				_resultsListView.Location = new System.Drawing.Point(24, 192);
				_resultsListView.MultiSelect = false;
				_resultsListView.Name = "_resultsListView";
				_resultsListView.Size = new System.Drawing.Size(488, 195);
				_resultsListView.TabIndex = 10;
				_resultsListView.View = System.Windows.Forms.View.Details;
				
 
				
				columnHeader1.Width = 484;

				this._resultsListView.SmallImageList=AppForm.getAppForm().getTreeImageList();

				this._resultsListView.SelectedIndexChanged += new System.EventHandler(this._resultsListView_SelectedIndexChanged);				
			
				this.Controls.Add(_resultsListView);
			}
			else
			{
				_resultsListView.Items.Clear();
			}

			LAST_SEARCHED_FOR=_searchForTextBox.Text.Trim();

			if(radioButton1.Checked)
			{
				LAST_SEARCHED_TYPE=0;
			}
			else if(radioButton2.Checked)
			{
				LAST_SEARCHED_TYPE=1;

			}else LAST_SEARCHED_TYPE=2;
			
			_findButton.Enabled=false;
		
			ModelOperations.searchForStringInDocument(_searchForTextBox.Text.Trim(),_resultsListView,LAST_SEARCHED_TYPE);
            			
			_resultsListView.Columns[0].Text=RES_MANAGER.GetString("_resultsListView.Column.Text1")+" "+_resultsListView.Items.Count+" - "+RES_MANAGER.GetString("_resultsListView.Column.Text2")+" '"+_searchForTextBox.Text.Trim()+"'";
			
		}

		private void _searchForTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_searchForTextBox.Text.Trim()!=LAST_SEARCHED_FOR && _searchForTextBox.Text.Trim()!="")
			{
				_findButton.Enabled=true;				
			}
			else
			{
				_findButton.Enabled=false;
			}
		}

		private void _resultsListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(_resultsListView.SelectedItems.Count>0)
			{
				ListViewItem lvi=_resultsListView.SelectedItems[0];
				TreeNode tn=(TreeNode)lvi.Tag;
				if(LAST_SEARCHED_TYPE==0)
				{
					AppForm.getAppForm().getTreeTabControl().SelectedIndex=0;
					AppForm.getAppForm().getCoursesTreeView().SelectedNode=tn;
				}
				else if(LAST_SEARCHED_TYPE==1)
				{		
					AppForm.getAppForm().getTreeTabControl().SelectedIndex=1;
					AppForm.getAppForm().getTeachersTreeView().SelectedNode=tn;
				}
				else if(LAST_SEARCHED_TYPE==2)
				{
					AppForm.getAppForm().getTreeTabControl().SelectedIndex=2;
					AppForm.getAppForm().getRoomsTreeView().SelectedNode=tn;
				}
			}
		
		}

		private void radioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			int type;
			if(radioButton1.Checked)
			{
				type=0;
			}
			else if(radioButton2.Checked)
			{
                type=1;
			}
			else
			{
				type=2;
			}

			if(type!=LAST_SEARCHED_TYPE || (_searchForTextBox.Text.Trim()!=LAST_SEARCHED_FOR && _searchForTextBox.Text.Trim()!=""))
			{
				_findButton.Enabled=true;
			}
			else
			{
				_findButton.Enabled=false;
			}
		
		}

		
		
	}
}
