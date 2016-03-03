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
	/// Summary description for EPGPropertiesForm.
	/// </summary>
	public class EPGPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private EduProgramGroup _epg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.TextBox _epgNameTextBox;
		private System.Windows.Forms.TextBox _extIDTextBox;

		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		
		

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public EPGPropertiesForm()
		{			
			InitializeComponent();

			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPGPropertiesFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.EPGPropertiesFormSchool",this.GetType().Assembly);
			}

			this.Text=RES_MANAGER.GetString("this.Text");			
		}


		public EPGPropertiesForm(EduProgramGroup epg):this()
		{			
			_epg=epg;
			_epgNameTextBox.Text=epg.getName();
			_extIDTextBox.Text=epg.ExtID;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EPGPropertiesForm));
			this.label1 = new System.Windows.Forms.Label();
			this._epgNameTextBox = new System.Windows.Forms.TextBox();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._extIDTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
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
			// _epgNameTextBox
			// 
			this._epgNameTextBox.AccessibleDescription = resources.GetString("_epgNameTextBox.AccessibleDescription");
			this._epgNameTextBox.AccessibleName = resources.GetString("_epgNameTextBox.AccessibleName");
			this._epgNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_epgNameTextBox.Anchor")));
			this._epgNameTextBox.AutoSize = ((bool)(resources.GetObject("_epgNameTextBox.AutoSize")));
			this._epgNameTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_epgNameTextBox.BackgroundImage")));
			this._epgNameTextBox.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_epgNameTextBox.Dock")));
			this._epgNameTextBox.Enabled = ((bool)(resources.GetObject("_epgNameTextBox.Enabled")));
			this._epgNameTextBox.Font = ((System.Drawing.Font)(resources.GetObject("_epgNameTextBox.Font")));
			this._epgNameTextBox.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_epgNameTextBox.ImeMode")));
			this._epgNameTextBox.Location = ((System.Drawing.Point)(resources.GetObject("_epgNameTextBox.Location")));
			this._epgNameTextBox.MaxLength = ((int)(resources.GetObject("_epgNameTextBox.MaxLength")));
			this._epgNameTextBox.Multiline = ((bool)(resources.GetObject("_epgNameTextBox.Multiline")));
			this._epgNameTextBox.Name = "_epgNameTextBox";
			this._epgNameTextBox.PasswordChar = ((char)(resources.GetObject("_epgNameTextBox.PasswordChar")));
			this._epgNameTextBox.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_epgNameTextBox.RightToLeft")));
			this._epgNameTextBox.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("_epgNameTextBox.ScrollBars")));
			this._epgNameTextBox.Size = ((System.Drawing.Size)(resources.GetObject("_epgNameTextBox.Size")));
			this._epgNameTextBox.TabIndex = ((int)(resources.GetObject("_epgNameTextBox.TabIndex")));
			this._epgNameTextBox.Text = resources.GetString("_epgNameTextBox.Text");
			this._epgNameTextBox.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_epgNameTextBox.TextAlign")));
			this._epgNameTextBox.Visible = ((bool)(resources.GetObject("_epgNameTextBox.Visible")));
			this._epgNameTextBox.WordWrap = ((bool)(resources.GetObject("_epgNameTextBox.WordWrap")));
			this._epgNameTextBox.TextChanged += new System.EventHandler(this._epgNameTextBox_TextChanged);
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
			// EPGPropertiesForm
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
			this.Controls.Add(this._epgNameTextBox);
			this.Controls.Add(this.label2);
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
			this.Name = "EPGPropertiesForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
			this.ResumeLayout(false);

		}
		#endregion



		private void _epgNameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_epgNameTextBox.Text.Trim()!="") 
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
				if(_epg==null)
				{
					if (!EduProgramGroup.checkNewName(_epgNameTextBox.Text)) 
					{
						e.Cancel = true;
					
						string message2 = RES_MANAGER.GetString("Form_Closing.msb.epgnotcreated.message");
					
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.epgnotcreated.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else 
					{
						e.Cancel = false;		
					}
				}
				else
				{
					if(_epgNameTextBox.Text.ToUpper()!=_epg.getName().ToUpper())
					{
						if (!EduProgramGroup.checkNewName(_epgNameTextBox.Text)) 
						{
							e.Cancel = true;					
							
							string message2 = RES_MANAGER.GetString("Form_Closing.msb.epgdatanotchanged.message");
											
							string caption2 = RES_MANAGER.GetString("Form_Closing.msb.epgdatanotchanged.caption");

							MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
							MessageBox.Show(this, message2, caption2, buttons2,
								MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
						}
						else 
						{
							e.Cancel = false;		
						}
					}

				}
				
			}
		}

		public TextBox EPGNameTextBox
		{
			get
			{
				return _epgNameTextBox;
			}
		}

		public TextBox EPGExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}


		}



	}

}
