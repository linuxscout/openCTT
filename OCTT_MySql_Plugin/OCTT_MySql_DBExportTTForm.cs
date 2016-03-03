#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan Ćurak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan Ćurak, Split, Croatia
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
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace OCTT_MySql_Plugin
{
	/// <summary>
	/// Summary description for OCTT_MySql_DBExportTTForm.
	/// </summary>
	public class OCTT_MySql_DBExportTTForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        /// 

        private BackgroundWorker _backWorker;
		public static OCTT_MySql_DBExportTTForm OCTT_MYSQL_EDBF;
		public static OCTT_MySql_DBExportPlugin OCTT_MYSQL_DBEXPLG;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.Button _exportButton;
		public System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TextBox _serverTextBox;
		public System.Windows.Forms.TextBox _dbNameTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox _userNameTextBox;
		public System.Windows.Forms.TextBox _passwordTextBox;
		public System.Windows.Forms.ProgressBar progressBar1;

		private System.Windows.Forms.Label _statusLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label _descriptionLabel;
		private System.Windows.Forms.Label _authorLabel;
		private System.Windows.Forms.Label _versionLabel;
		private System.Windows.Forms.GroupBox groupBox3;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCTT_MySql_DBExportTTForm(OCTT_MySql_DBExportPlugin explg)
		{
			//
			// Required for Windows Form Designer support
			//

			InitializeComponent();

			OCTT_MYSQL_EDBF=this;
			OCTT_MYSQL_DBEXPLG=explg;

			_statusLabel.Text="";
			this.Text=OCTT_MYSQL_DBEXPLG.Name;

			_descriptionLabel.Text=_descriptionLabel.Text+" "+OCTT_MYSQL_DBEXPLG.Description;
			_authorLabel.Text=_authorLabel.Text+" "+OCTT_MYSQL_DBEXPLG.Author;
			_versionLabel.Text=_versionLabel.Text+" "+OCTT_MYSQL_DBEXPLG.Version;
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._serverTextBox = new System.Windows.Forms.TextBox();
            this._dbNameTextBox = new System.Windows.Forms.TextBox();
            this._exportButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._userNameTextBox = new System.Windows.Forms.TextBox();
            this._passwordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this._statusLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._versionLabel = new System.Windows.Forms.Label();
            this._authorLabel = new System.Windows.Forms.Label();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "MySql server name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _serverTextBox
            // 
            this._serverTextBox.Location = new System.Drawing.Point(144, 24);
            this._serverTextBox.Name = "_serverTextBox";
            this._serverTextBox.Size = new System.Drawing.Size(160, 20);
            this._serverTextBox.TabIndex = 1;
            this._serverTextBox.Text = "localhost";
            this._serverTextBox.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // _dbNameTextBox
            // 
            this._dbNameTextBox.Location = new System.Drawing.Point(144, 48);
            this._dbNameTextBox.Name = "_dbNameTextBox";
            this._dbNameTextBox.Size = new System.Drawing.Size(160, 20);
            this._dbNameTextBox.TabIndex = 2;
            this._dbNameTextBox.Text = "timetable";
            this._dbNameTextBox.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // _exportButton
            // 
            this._exportButton.BackColor = System.Drawing.SystemColors.Control;
            this._exportButton.Enabled = false;
            this._exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._exportButton.Location = new System.Drawing.Point(256, 376);
            this._exportButton.Name = "_exportButton";
            this._exportButton.Size = new System.Drawing.Size(96, 26);
            this._exportButton.TabIndex = 5;
            this._exportButton.Text = "Export";
            this._exportButton.UseVisualStyleBackColor = false;
            this._exportButton.Click += new System.EventHandler(this._exportButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(156, 504);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(67, 26);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Close";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(32, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "tt_data, epg, ep, course, allocated_lesson, teacher, room, day, term";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(24, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 70);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Note: timetable export goes to tables";
            // 
            // _userNameTextBox
            // 
            this._userNameTextBox.Location = new System.Drawing.Point(144, 80);
            this._userNameTextBox.Name = "_userNameTextBox";
            this._userNameTextBox.Size = new System.Drawing.Size(160, 20);
            this._userNameTextBox.TabIndex = 3;
            this._userNameTextBox.TextChanged += new System.EventHandler(this.checkInput);
            // 
            // _passwordTextBox
            // 
            this._passwordTextBox.Location = new System.Drawing.Point(144, 104);
            this._passwordTextBox.Name = "_passwordTextBox";
            this._passwordTextBox.PasswordChar = '●';
            this._passwordTextBox.Size = new System.Drawing.Size(160, 20);
            this._passwordTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(40, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Username:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 424);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(320, 20);
            this.progressBar1.TabIndex = 13;
            // 
            // _statusLabel
            // 
            this._statusLabel.Location = new System.Drawing.Point(32, 448);
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(320, 40);
            this._statusLabel.TabIndex = 14;
            this._statusLabel.Text = "status text";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._versionLabel);
            this.groupBox2.Controls.Add(this._authorLabel);
            this.groupBox2.Controls.Add(this._descriptionLabel);
            this.groupBox2.Location = new System.Drawing.Point(24, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 88);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Plugin properties";
            // 
            // _versionLabel
            // 
            this._versionLabel.Location = new System.Drawing.Point(8, 64);
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(304, 14);
            this._versionLabel.TabIndex = 2;
            this._versionLabel.Text = "Version:";
            // 
            // _authorLabel
            // 
            this._authorLabel.Location = new System.Drawing.Point(8, 48);
            this._authorLabel.Name = "_authorLabel";
            this._authorLabel.Size = new System.Drawing.Size(304, 14);
            this._authorLabel.TabIndex = 1;
            this._authorLabel.Text = "Author:";
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.Location = new System.Drawing.Point(8, 16);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(304, 26);
            this._descriptionLabel.TabIndex = 0;
            this._descriptionLabel.Text = "Description:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this._serverTextBox);
            this.groupBox3.Controls.Add(this._dbNameTextBox);
            this.groupBox3.Controls.Add(this._userNameTextBox);
            this.groupBox3.Controls.Add(this._passwordTextBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(24, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 144);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MySql server data";
            // 
            // OCTT_MySql_DBExportTTForm
            // 
            this.AcceptButton = this._exportButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(378, 544);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this._statusLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._exportButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OCTT_MySql_DBExportTTForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export to MySql database";
            this.Closed += new System.EventHandler(this.OCTT_MySql_DBExportTTForm_Closed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void _exportButton_Click(object sender, System.EventArgs e)
		{
            try
            {
                _exportButton.Enabled = false;
                _backWorker = new BackgroundWorker();
                _backWorker.WorkerReportsProgress = true;
                _backWorker.WorkerSupportsCancellation = true;

                _backWorker.DoWork += new DoWorkEventHandler(_backWorker_DoWork);
                _backWorker.ProgressChanged += new ProgressChangedEventHandler(_backWorker_ProgressChanged);
                _backWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backWorker_RunWorkerCompleted);

                _backWorker.RunWorkerAsync();
            }
            catch { }

		}


        void _backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _exportButton.Enabled = true;
        }

        void _backWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (e.UserState != null)
            {
                string s = e.UserState as string;
                _statusLabel.Text = s;
            }

        }

        void _backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                OCTT_MySql_DBOperations.doExportInMySqlDB(_backWorker, e);
            }
            catch { }
        }
		

		private void checkInput(object sender, System.EventArgs e)
		{
			if(_serverTextBox.Text.Trim()!="" &&
				_dbNameTextBox.Text.Trim()!="" &&
				_userNameTextBox.Text.Trim()!="")
			{
				_exportButton.Enabled=true;
			}
			else
			{
				_exportButton.Enabled=false;
			}		
		}

		private void OCTT_MySql_DBExportTTForm_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
			OCTT_MYSQL_DBEXPLG.Dispose();
		}		
	}
}
