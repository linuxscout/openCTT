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
using System.Data;
using System.Globalization;
using System.Resources;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for PrintSelectionForm.
	/// </summary>
	public class PrintSelectionForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private int _type;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Button _selAllButton;
		private System.Windows.Forms.Button _delAllButton;
		private System.Windows.Forms.TreeView _treeView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PrintSelectionForm(int type)
		{
            _type=type;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
							
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.PrintSelectionForm",this.GetType().Assembly);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PrintSelectionForm));
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._delAllButton = new System.Windows.Forms.Button();
			this._selAllButton = new System.Windows.Forms.Button();
			this._treeView1 = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// _okButton
			// 
			this._okButton.AccessibleDescription = resources.GetString("_okButton.AccessibleDescription");
			this._okButton.AccessibleName = resources.GetString("_okButton.AccessibleName");
			this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_okButton.Anchor")));
			this._okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_okButton.BackgroundImage")));
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
			this._okButton.Click += new System.EventHandler(this._okButton_Click);
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
			// _delAllButton
			// 
			this._delAllButton.AccessibleDescription = resources.GetString("_delAllButton.AccessibleDescription");
			this._delAllButton.AccessibleName = resources.GetString("_delAllButton.AccessibleName");
			this._delAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_delAllButton.Anchor")));
			this._delAllButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_delAllButton.BackgroundImage")));
			this._delAllButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_delAllButton.Dock")));
			this._delAllButton.Enabled = ((bool)(resources.GetObject("_delAllButton.Enabled")));
			this._delAllButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_delAllButton.FlatStyle")));
			this._delAllButton.Font = ((System.Drawing.Font)(resources.GetObject("_delAllButton.Font")));
			this._delAllButton.Image = ((System.Drawing.Image)(resources.GetObject("_delAllButton.Image")));
			this._delAllButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_delAllButton.ImageAlign")));
			this._delAllButton.ImageIndex = ((int)(resources.GetObject("_delAllButton.ImageIndex")));
			this._delAllButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_delAllButton.ImeMode")));
			this._delAllButton.Location = ((System.Drawing.Point)(resources.GetObject("_delAllButton.Location")));
			this._delAllButton.Name = "_delAllButton";
			this._delAllButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_delAllButton.RightToLeft")));
			this._delAllButton.Size = ((System.Drawing.Size)(resources.GetObject("_delAllButton.Size")));
			this._delAllButton.TabIndex = ((int)(resources.GetObject("_delAllButton.TabIndex")));
			this._delAllButton.Text = resources.GetString("_delAllButton.Text");
			this._delAllButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_delAllButton.TextAlign")));
			this._delAllButton.Visible = ((bool)(resources.GetObject("_delAllButton.Visible")));
			this._delAllButton.Click += new System.EventHandler(this._delAllButton_Click);
			// 
			// _selAllButton
			// 
			this._selAllButton.AccessibleDescription = resources.GetString("_selAllButton.AccessibleDescription");
			this._selAllButton.AccessibleName = resources.GetString("_selAllButton.AccessibleName");
			this._selAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_selAllButton.Anchor")));
			this._selAllButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_selAllButton.BackgroundImage")));
			this._selAllButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_selAllButton.Dock")));
			this._selAllButton.Enabled = ((bool)(resources.GetObject("_selAllButton.Enabled")));
			this._selAllButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_selAllButton.FlatStyle")));
			this._selAllButton.Font = ((System.Drawing.Font)(resources.GetObject("_selAllButton.Font")));
			this._selAllButton.Image = ((System.Drawing.Image)(resources.GetObject("_selAllButton.Image")));
			this._selAllButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_selAllButton.ImageAlign")));
			this._selAllButton.ImageIndex = ((int)(resources.GetObject("_selAllButton.ImageIndex")));
			this._selAllButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_selAllButton.ImeMode")));
			this._selAllButton.Location = ((System.Drawing.Point)(resources.GetObject("_selAllButton.Location")));
			this._selAllButton.Name = "_selAllButton";
			this._selAllButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_selAllButton.RightToLeft")));
			this._selAllButton.Size = ((System.Drawing.Size)(resources.GetObject("_selAllButton.Size")));
			this._selAllButton.TabIndex = ((int)(resources.GetObject("_selAllButton.TabIndex")));
			this._selAllButton.Text = resources.GetString("_selAllButton.Text");
			this._selAllButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_selAllButton.TextAlign")));
			this._selAllButton.Visible = ((bool)(resources.GetObject("_selAllButton.Visible")));
			this._selAllButton.Click += new System.EventHandler(this._selAllButton_Click);
			// 
			// _treeView1
			// 
			this._treeView1.AccessibleDescription = resources.GetString("_treeView1.AccessibleDescription");
			this._treeView1.AccessibleName = resources.GetString("_treeView1.AccessibleName");
			this._treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_treeView1.Anchor")));
			this._treeView1.BackColor = System.Drawing.Color.Gainsboro;
			this._treeView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_treeView1.BackgroundImage")));
			this._treeView1.CheckBoxes = true;
			this._treeView1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_treeView1.Dock")));
			this._treeView1.Enabled = ((bool)(resources.GetObject("_treeView1.Enabled")));
			this._treeView1.Font = ((System.Drawing.Font)(resources.GetObject("_treeView1.Font")));
			this._treeView1.ImageIndex = ((int)(resources.GetObject("_treeView1.ImageIndex")));
			this._treeView1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_treeView1.ImeMode")));
			this._treeView1.Indent = ((int)(resources.GetObject("_treeView1.Indent")));
			this._treeView1.ItemHeight = ((int)(resources.GetObject("_treeView1.ItemHeight")));
			this._treeView1.Location = ((System.Drawing.Point)(resources.GetObject("_treeView1.Location")));
			this._treeView1.Name = "_treeView1";
			this._treeView1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_treeView1.RightToLeft")));
			this._treeView1.SelectedImageIndex = ((int)(resources.GetObject("_treeView1.SelectedImageIndex")));
			this._treeView1.ShowRootLines = false;
			this._treeView1.Size = ((System.Drawing.Size)(resources.GetObject("_treeView1.Size")));
			this._treeView1.Sorted = true;
			this._treeView1.TabIndex = ((int)(resources.GetObject("_treeView1.TabIndex")));
			this._treeView1.Text = resources.GetString("_treeView1.Text");
			this._treeView1.Visible = ((bool)(resources.GetObject("_treeView1.Visible")));
			this._treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
			// 
			// PrintSelectionForm
			// 
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
			this.Controls.Add(this._delAllButton);
			this.Controls.Add(this._selAllButton);
			this.Controls.Add(this._treeView1);
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
			this.Name = "PrintSelectionForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.PrintSelectionForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void PrintSelectionForm_Load(object sender, System.EventArgs e)
		{
			switch(_type)
			{
				case 1:					
					if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
					{
				        this.Text=RES_MANAGER.GetString("type.ep.university.this.text");

					}
					else
					{			
                        this.Text=RES_MANAGER.GetString("type.ep.school.this.text");
					}				

					fillTreeEduPrograms();
					break;
				case 2:					
					this.Text=RES_MANAGER.GetString("type.teacher.this.text");
					fillTreeTeachers();
					break;
				case 3:					
					this.Text=RES_MANAGER.GetString("type.room.this.text");
					fillTreeRooms();
					break;
			}
		}

		private void fillTreeTeachers()
		{
			_treeView1.BeginUpdate();
			foreach(Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
			{
				TreeNode tn = new TreeNode(teacher.getTreeText());
				tn.Tag=teacher;
				_treeView1.Nodes.Add(tn);
			}
            _treeView1.ExpandAll();
			_treeView1.EndUpdate();
			this.Refresh();
		}

		private void fillTreeRooms()
		{
			_treeView1.BeginUpdate();
			foreach(Room room in AppForm.CURR_OCTT_DOC.RoomsRootNode.Nodes)
			{
				TreeNode tn = new TreeNode(room.getName());
				tn.Tag=room;
				_treeView1.Nodes.Add(tn);
			}
			_treeView1.ExpandAll();
			_treeView1.EndUpdate();
			this.Refresh();			
		}


		private void fillTreeEduPrograms()
		{
			_treeView1.BeginUpdate();
			foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes) 
			{
				TreeNode tn = new TreeNode(epg.getName());
				tn.Tag=epg;				
				
				_treeView1.Nodes.Add(tn);

				foreach(EduProgram ep in epg.Nodes)
				{
					TreeNode tnSub = new TreeNode(ep.Text);
					tnSub.Tag=ep;
					tn.Nodes.Add(tnSub);

				}
			}
            _treeView1.ExpandAll();
			_treeView1.EndUpdate();
			this.Refresh();
		}

		private void _selAllButton_Click(object sender, System.EventArgs e)
		{
			foreach(TreeNode tn in _treeView1.Nodes)
			{
				tn.Checked=true;				
			}
			_treeView1.ExpandAll();
		}

		private void _delAllButton_Click(object sender, System.EventArgs e)
		{
			foreach(TreeNode tn in _treeView1.Nodes)
			{
				tn.Checked=false;				
			}
			_treeView1.ExpandAll();
		}

		private void _okButton_Click(object sender, System.EventArgs e)
		{
			switch(_type)
			{
				case 1:
					printForEduPrograms();
					break;
				case 2:
					printForTeachers();
					break;
				case 3:
					printForRooms();					
					break;
			}
		
		}

		private void printForRooms()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(TreeNode tn in _treeView1.Nodes)
			{
				if(tn.Checked)
				{
					listForPrint.Add((Room)tn.Tag);
				}
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,3);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}

		}


		private void printForTeachers()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(TreeNode tn in _treeView1.Nodes)
			{
				if(tn.Checked)
				{
					listForPrint.Add((Teacher)tn.Tag);
				}
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,2);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}

		}


		private void printForEduPrograms()
		{
			ArrayList listForPrint = new ArrayList();			

			foreach(TreeNode tn in _treeView1.Nodes)
			{				
				if(tn.Nodes.Count>0)
				{
					foreach(TreeNode tnSub in tn.Nodes)
					{
						if(tnSub.Checked)
						{
							listForPrint.Add((EduProgram)tnSub.Tag);
						}
					}
				}
			}

			if(listForPrint.Count>0)
			{
				ArrayList pdfReportDataTablesList = ModelOperations.getPdfSharpReportDataTablesList(listForPrint,1);
				PdfCreator.createPdfDocument(pdfReportDataTablesList);
			}

		}

		private void _treeView1_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode tn = e.Node;			
			if(tn.Tag is EduProgramGroup)
			{
				if(tn.Checked)
				{
					foreach(TreeNode tnSub in tn.Nodes)
					{
						tnSub.Checked=true;
					}
				}
				else
				{					
					foreach(TreeNode tnSub in tn.Nodes)
					{				
						tnSub.Checked=false;
					}					

				}
			}
			else if(tn.Tag is EduProgram)
			{
				TreeNode tnUp = (TreeNode)tn.Parent;
				bool isALOU=false;
				foreach(TreeNode tnSub in tnUp.Nodes)
				{
					if(!tnSub.Checked)
					{
                        isALOU=true;
						break;
					}
				}

				if(isALOU)
				{
					this._treeView1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
					tnUp.Checked=false;
					this._treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
				}
				else
				{
					this._treeView1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
                    tnUp.Checked=true;
					this._treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this._treeView1_AfterCheck);
				}
			}
			
		}
	}
}
