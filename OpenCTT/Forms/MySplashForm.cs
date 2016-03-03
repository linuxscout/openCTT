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
using System.Threading;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for MySplashForm.
	/// </summary>
	public class MySplashForm : System.Windows.Forms.Form
	{
		private string _octFileName;
		private string _aVersion;
		private System.Drawing.Image imSplashScreen;
		private System.Reflection.Assembly myAssembly;
		private string assemblyPath;
		private System.Windows.Forms.Timer _timer;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Label _verLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.IContainer components;

		public MySplashForm()
		{
			
			myAssembly = System.Reflection.Assembly.GetExecutingAssembly();			
			_aVersion = myAssembly.GetName().Version.ToString();
            int ri = _aVersion.LastIndexOf('.');
            _aVersion=_aVersion.Remove(ri);           

			assemblyPath = myAssembly.GetName().Name.Replace(" "," ");
            
			imSplashScreen = System.Drawing.Image.FromStream(myAssembly.GetManifestResourceStream(assemblyPath+"."+"SplashScreen.png"));

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_verLabel.Text="Version: "+_aVersion;

		}

		public MySplashForm(string startUpFileName):this()		
		{
			_octFileName=startUpFileName;
		}

		public MySplashForm(bool isAbout):this()		
		{
			_timer.Enabled=false;
			_okButton.Visible=true;
			
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MySplashForm));
            this._okButton = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._verLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.ForeColor = System.Drawing.Color.CadetBlue;
            this._okButton.Location = new System.Drawing.Point(506, 394);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(80, 24);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.Visible = false;
            // 
            // _timer
            // 
            this._timer.Enabled = true;
            this._timer.Interval = 800;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // _verLabel
            // 
            this._verLabel.BackColor = System.Drawing.SystemColors.Window;
            this._verLabel.Location = new System.Drawing.Point(16, 344);
            this._verLabel.Name = "_verLabel";
            this._verLabel.Size = new System.Drawing.Size(352, 16);
            this._verLabel.TabIndex = 2;
            this._verLabel.Text = "Version";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(16, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Copyright © 2007 Ivan Æurak, Split, Croatia. E-mail: ivan.curak@gmail.com   www.o" +
                "penctt.org";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(16, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(424, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "This application is released under GNU General Public License (GPL).";
            // 
            // MySplashForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(608, 437);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._verLabel);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MySplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

		}
		#endregion
	
	
		[STAThread]
		static void Main(string [] args) 
		{				
			if(args.Length==0)
			{
				Application.Run(new MySplashForm());
			}
			else if(args.Length==1)
			{
				Application.Run(new MySplashForm(args[0]));
			}			
		}

		protected override void OnPaint(PaintEventArgs e)
		{

		}

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			System.Drawing.Graphics g = pevent.Graphics;
			g.DrawImage(imSplashScreen,new System.Drawing.Rectangle(0,0,this.Width,this.Height));

		}
		

		private void _timer_Tick(object sender, System.EventArgs e)
		{
			_timer.Enabled=false;
			_timer.Dispose();
			
			AppForm appFrm;

			if(_octFileName!=null)
			{
				appFrm= new AppForm(_octFileName);				
			}
			else
			{
                appFrm= new AppForm();                
			}

			appFrm.Show();	
			this.Hide();
		}

		
	
	}

}
