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
	/// Summary description for TeacherPropertiesForm.
	/// </summary>
	public class TeacherPropertiesForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;

		private bool _isNew;
		private Teacher _teacher;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.TextBox _lastnameTextBox;
		private System.Windows.Forms.ComboBox _titleComboBox;
		private System.Windows.Forms.ComboBox _eduRankComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox _nameTextBox;
		private System.Windows.Forms.TextBox _extIDTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TeacherPropertiesForm()
		{
			InitializeComponent();
			
			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.TeacherPropertiesForm",this.GetType().Assembly);
			}

			_titleComboBox.DataSource=AppForm.CURR_OCTT_DOC.TeacherTitlesList;
			_eduRankComboBox.DataSource=AppForm.CURR_OCTT_DOC.TeacherEduRanksList;

			_isNew=true;


		}

		public TeacherPropertiesForm(Teacher teacher):this()
		{
			_isNew=false;
			_teacher=teacher;

			this._nameTextBox.Text=_teacher.getName();
			this._lastnameTextBox.Text=_teacher.getLastName();
			this._extIDTextBox.Text=_teacher.ExtID;			

			this._titleComboBox.SelectedItem=_teacher.getTitle();
			this._eduRankComboBox.SelectedItem=_teacher.getEduRank();
			
			

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherPropertiesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._lastnameTextBox = new System.Windows.Forms.TextBox();
            this._titleComboBox = new System.Windows.Forms.ComboBox();
            this._eduRankComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._extIDTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Font = null;
            this.label4.Name = "label4";
            // 
            // _okButton
            // 
            this._okButton.AccessibleDescription = null;
            this._okButton.AccessibleName = null;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.BackgroundImage = null;
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Font = null;
            this._okButton.Name = "_okButton";
            // 
            // _cancelButton
            // 
            this._cancelButton.AccessibleDescription = null;
            this._cancelButton.AccessibleName = null;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.BackgroundImage = null;
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Font = null;
            this._cancelButton.Name = "_cancelButton";
            // 
            // _lastnameTextBox
            // 
            this._lastnameTextBox.AccessibleDescription = null;
            this._lastnameTextBox.AccessibleName = null;
            resources.ApplyResources(this._lastnameTextBox, "_lastnameTextBox");
            this._lastnameTextBox.BackgroundImage = null;
            this._lastnameTextBox.Font = null;
            this._lastnameTextBox.Name = "_lastnameTextBox";
            this._lastnameTextBox.TextChanged += new System.EventHandler(this._nameLastnameTextBox_TextChanged);
            // 
            // _titleComboBox
            // 
            this._titleComboBox.AccessibleDescription = null;
            this._titleComboBox.AccessibleName = null;
            resources.ApplyResources(this._titleComboBox, "_titleComboBox");
            this._titleComboBox.BackgroundImage = null;
            this._titleComboBox.Font = null;
            this._titleComboBox.Name = "_titleComboBox";
            // 
            // _eduRankComboBox
            // 
            this._eduRankComboBox.AccessibleDescription = null;
            this._eduRankComboBox.AccessibleName = null;
            resources.ApplyResources(this._eduRankComboBox, "_eduRankComboBox");
            this._eduRankComboBox.BackgroundImage = null;
            this._eduRankComboBox.Font = null;
            this._eduRankComboBox.Name = "_eduRankComboBox";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // _nameTextBox
            // 
            this._nameTextBox.AccessibleDescription = null;
            this._nameTextBox.AccessibleName = null;
            resources.ApplyResources(this._nameTextBox, "_nameTextBox");
            this._nameTextBox.BackgroundImage = null;
            this._nameTextBox.Font = null;
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.TextChanged += new System.EventHandler(this._nameLastnameTextBox_TextChanged);
            // 
            // _extIDTextBox
            // 
            this._extIDTextBox.AccessibleDescription = null;
            this._extIDTextBox.AccessibleName = null;
            resources.ApplyResources(this._extIDTextBox, "_extIDTextBox");
            this._extIDTextBox.BackgroundImage = null;
            this._extIDTextBox.Font = null;
            this._extIDTextBox.Name = "_extIDTextBox";
            // 
            // TeacherPropertiesForm
            // 
            this.AcceptButton = this._okButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._extIDTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._eduRankComboBox);
            this.Controls.Add(this._titleComboBox);
            this.Controls.Add(this._lastnameTextBox);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeacherPropertiesForm";
            this.ShowInTaskbar = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
		private void _nameLastnameTextBox_TextChanged(object sender, System.EventArgs e)
		{
			if(_nameTextBox.Text.Trim()!="" && _lastnameTextBox.Text.Trim()!="") 
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
				string title = (string)_titleComboBox.SelectedItem;
				if(title==null)title=_titleComboBox.Text;
					
				string eduRank = (string)_eduRankComboBox.SelectedItem;
				if(eduRank==null)eduRank=_eduRankComboBox.Text;

				if(_isNew) 
				{					
					if(Teacher.getIsTeacherDataOK(null,_nameTextBox.Text.Trim(),_lastnameTextBox.Text.Trim(),title.Trim(), eduRank.Trim()))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
					
						string message1 = RES_MANAGER.GetString("Form_Closing.msb.teacher_not_created.message");

						string caption1 = RES_MANAGER.GetString("Form_Closing.msb.teacher_not_created.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}
				}
				else
				{
					if(Teacher.getIsTeacherDataOK(_teacher,_nameTextBox.Text.Trim(),_lastnameTextBox.Text.Trim(),title.Trim(), eduRank.Trim()))
					{
						e.Cancel=false;
					}
					else
					{
						e.Cancel = true;
					
						string message2 = RES_MANAGER.GetString("Form_Closing.msb.teacher_data_not_changed.message");
					
						string caption2 = RES_MANAGER.GetString("Form_Closing.msb.teacher_data_not_changed.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

					}

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

		public TextBox LastnameTextBox
		{
			get
			{
				return _lastnameTextBox;
			}
		}


		public TextBox ExtIDTextBox
		{
			get
			{
				return _extIDTextBox;
			}
		}

		public ComboBox TitleComboBox
		{
			get
			{
				return _titleComboBox;
			}
		}	

		public ComboBox EduRankComboBox
		{
			get
			{
				return _eduRankComboBox;
			}
		}		


	}
}
