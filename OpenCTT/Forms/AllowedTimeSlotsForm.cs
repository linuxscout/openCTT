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
	/// Summary description for AllowedTimeSlotsForm.
	/// </summary>
	public class AllowedTimeSlotsForm : System.Windows.Forms.Form
	{		
		private static ResourceManager RES_MANAGER;

		private static AllowedTimeSlotsForm ATS_FORM;
		public int _timeSlotChangeCounter=0;
		private bool [,] _allowedTimeSlots;

		public static Panel MAIN_PANEL;
		private int _atsFormType;
		private Object _workingObject;

		private System.Windows.Forms.Panel _rightPanel;
		private System.Windows.Forms.Panel _bottomPanel;
		public System.Windows.Forms.Panel _mainPanel;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AllowedTimeSlotsForm(bool [,] allowedTimeSlots, int atsFormType, Object workingObject)
		{
			
			InitializeComponent();            
			
			if(AppForm.CURR_OCTT_DOC.DocumentType==Constants.OCTT_DOC_TYPE_UNIVERSITY)
			{				
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.ATSFormUniversity",this.GetType().Assembly);

			}
			else
			{			
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.ATSFormSchool",this.GetType().Assembly);
			}			

			_cancelButton.Text=RES_MANAGER.GetString("_cancelButton.Text");
			this.Text=RES_MANAGER.GetString("formtitle.Text");

			ATS_FORM=this;
			_allowedTimeSlots=allowedTimeSlots;
			MAIN_PANEL=_mainPanel;
			_atsFormType=atsFormType;
			_workingObject=workingObject;
			
			this.Closing += new CancelEventHandler(this.Form_Closing);
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
			this._rightPanel = new System.Windows.Forms.Panel();
			this._bottomPanel = new System.Windows.Forms.Panel();
			this._cancelButton = new System.Windows.Forms.Button();
			this._okButton = new System.Windows.Forms.Button();
			this._mainPanel = new System.Windows.Forms.Panel();
			this._bottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _rightPanel
			// 
			this._rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this._rightPanel.Location = new System.Drawing.Point(412, 0);
			this._rightPanel.Name = "_rightPanel";
			this._rightPanel.Size = new System.Drawing.Size(74, 328);
			this._rightPanel.TabIndex = 0;
			// 
			// _bottomPanel
			// 
			this._bottomPanel.Controls.Add(this._cancelButton);
			this._bottomPanel.Controls.Add(this._okButton);
			this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._bottomPanel.Location = new System.Drawing.Point(0, 328);
			this._bottomPanel.Name = "_bottomPanel";
			this._bottomPanel.Size = new System.Drawing.Size(486, 124);
			this._bottomPanel.TabIndex = 1;
			// 
			// _cancelButton
			// 
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this._cancelButton.Location = new System.Drawing.Point(256, 69);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size(66, 26);
			this._cancelButton.TabIndex = 1;
			this._cancelButton.Text = "Cancel";
			// 
			// _okButton
			// 
			this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._okButton.Enabled = false;
			this._okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this._okButton.Location = new System.Drawing.Point(164, 69);
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size(67, 26);
			this._okButton.TabIndex = 0;
			this._okButton.Text = "OK";
			// 
			// _mainPanel
			// 
			this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._mainPanel.Location = new System.Drawing.Point(0, 0);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(412, 328);
			this._mainPanel.TabIndex = 2;
			// 
			// AllowedTimeSlotsForm
			// 
			this.AcceptButton = this._okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this._cancelButton;
			this.ClientSize = new System.Drawing.Size(486, 452);
			this.Controls.Add(this._mainPanel);
			this.Controls.Add(this._rightPanel);
			this.Controls.Add(this._bottomPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AllowedTimeSlotsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Defining allowed/unallowed time-slots";
			this.Load += new System.EventHandler(this.AllowedTimeSlotsForm_Load);
			this._bottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void AllowedTimeSlotsForm_Load(object sender, System.EventArgs e)
		{
			_mainPanel.SuspendLayout();

			int dlStartX=15;
			int hlStartY=15;
			int dayLabelWidth=60;
			int dayLabelHeight=20;
			int hourLabelWidth=55;
			int hourLabelHeight=22;
			
			Label dayHourLabel = new Label();
			dayHourLabel.Text=RES_MANAGER.GetString("dayHourLabel.text");
			dayHourLabel.Size=new System.Drawing.Size(hourLabelWidth,dayLabelHeight);
			dayHourLabel.Location=new System.Drawing.Point(dlStartX,hlStartY);
			dayHourLabel.BorderStyle=BorderStyle.FixedSingle;
			dayHourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			dayHourLabel.BackColor=System.Drawing.Color.LightBlue;
			_mainPanel.Controls.Add(dayHourLabel);
			

			int nn=0;
			foreach(int[] term in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				string [] printTerm=new string[4];
				for(int k=0;k<4;k++)
				{
					if(term[k]<10)
					{
						printTerm[k]="0"+System.Convert.ToString(term[k]);
					}
					else
					{
						printTerm[k]=System.Convert.ToString(term[k]);
					}
				}

				string labelText=printTerm[0]+":"+printTerm[1]+"-"+printTerm[2]+":"+printTerm[3];
				
				Label termLabel=new Label();
				termLabel.Size=new System.Drawing.Size(hourLabelWidth,hourLabelHeight);
				termLabel.Location=new System.Drawing.Point(dlStartX,hlStartY+dayLabelHeight+nn*hourLabelHeight);
				termLabel.BorderStyle=BorderStyle.FixedSingle;
				termLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				termLabel.BackColor=System.Drawing.Color.Ivory;
				termLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
				termLabel.Text=labelText;
				_mainPanel.Controls.Add(termLabel);				
				nn++;
			}

			String[] dayText = new String[7];			
			dayText[0]=RES_MANAGER.GetString("dayMonday.text");
			dayText[1]=RES_MANAGER.GetString("dayTuesday.text");
			dayText[2]=RES_MANAGER.GetString("dayWednesday.text");
			dayText[3]=RES_MANAGER.GetString("dayThursday.text");
			dayText[4]=RES_MANAGER.GetString("dayFriday.text");
			dayText[5]=RES_MANAGER.GetString("daySaturday.text");
			dayText[6]=RES_MANAGER.GetString("daySunday.text");

			int goAhead=0;
			for(int n=0;n<7;n++)
			{
				if(AppForm.CURR_OCTT_DOC.getIsDayIncluded(n))
				{
					Label dayLabel=new Label();
					dayLabel.Size=new System.Drawing.Size(dayLabelWidth,dayLabelHeight);
					dayLabel.Location=new System.Drawing.Point(hourLabelWidth+dlStartX+goAhead*dayLabelWidth,hlStartY);
					dayLabel.BorderStyle=BorderStyle.FixedSingle;
					dayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
					dayLabel.BackColor=System.Drawing.Color.Ivory;
					dayLabel.Text=dayText[n];
					_mainPanel.Controls.Add(dayLabel);

					goAhead++;
				}
			}
			
			int otlStartX=dlStartX+hourLabelWidth;
			int otlStartY=hlStartY+dayLabelHeight;

			for(int j=0;j<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;j++) 
			{
				for(int k=0;k<AppForm.CURR_OCTT_DOC.getNumberOfDays();k++) 
				{
					bool tsState=_allowedTimeSlots[j,k];

										
					EnableDisableOneTermLabel edotl=new EnableDisableOneTermLabel(tsState,j,k);

					edotl.Size=new System.Drawing.Size(dayLabelWidth,hourLabelHeight);
					edotl.Location=new Point(otlStartX+k*dayLabelWidth,otlStartY+j*hourLabelHeight);
					
					_mainPanel.Controls.Add(edotl);
				}
			}

			int startY=36;
			for(int n=0;n<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;n++)
			{
				EnableDisableRCButton edb= new EnableDisableRCButton(10, startY+n*22,n,0,true,true);
				_rightPanel.Controls.Add(edb);

			}

			for(int n=0;n<AppForm.CURR_OCTT_DOC.IncludedTerms.Count;n++)
			{
				EnableDisableRCButton edb= new EnableDisableRCButton(35, startY+n*22,n,0,false,true);
				_rightPanel.Controls.Add(edb);
			}

			int startX=otlStartX+10;
			for(int n=0;n<AppForm.CURR_OCTT_DOC.getNumberOfDays();n++)
			{
				EnableDisableRCButton edb= new EnableDisableRCButton(startX+n*dayLabelWidth,1 ,0,n,true,false);
				_bottomPanel.Controls.Add(edb);
			}

			for(int n=0;n<AppForm.CURR_OCTT_DOC.getNumberOfDays();n++)
			{
				EnableDisableRCButton edb= new EnableDisableRCButton(startX+n*dayLabelWidth,26 ,0,n,false,false);
				_bottomPanel.Controls.Add(edb);
			}

			int mainPanelWidth=dlStartX+hourLabelWidth+dayLabelWidth*AppForm.CURR_OCTT_DOC.getNumberOfDays()+5;
			int formHeight= hlStartY+dayLabelHeight+hourLabelHeight*AppForm.CURR_OCTT_DOC.IncludedTerms.Count+_bottomPanel.Height+15;
            int formWidth=mainPanelWidth+74;

			this.ClientSize = new System.Drawing.Size(formWidth, formHeight);

			this._okButton.Location = new System.Drawing.Point(formWidth/2-78, 75);
			this._cancelButton.Location = new System.Drawing.Point(_okButton.Location.X+92, 75);
			
			_mainPanel.ResumeLayout(false);

		}
		
		
		public Panel getMainPanel()
		{
			return _mainPanel;
		}

		public Button getOKButton()
		{
			return _okButton;
		}

		public int getTimeSlotChangeCounter()
		{
			return _timeSlotChangeCounter;
		}

		public void incrTimeSlotChangeCounter()
		{
			_timeSlotChangeCounter++;            
		}

		public void decrTimeSlotChangeCounter()
		{
			_timeSlotChangeCounter--;            
		}

		public static AllowedTimeSlotsForm getATSForm()
		{
            return ATS_FORM;
		}

		public bool[,] getAllowedTimeSlots()
		{
			return _allowedTimeSlots;
		}

		private void Form_Closing (Object sender, CancelEventArgs e) 
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if(_atsFormType==Constants.ATSF_TIME_SLOT_TYPE_TEACHER)
				{
                    checkChangeTeacher(e);					
				}
				else if(_atsFormType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM)
				{
					checkChangeEduProgram(e);
					
				}
				else if(_atsFormType==Constants.ATSF_TIME_SLOT_TYPE_EDU_PROGRAM_GROUP)
				{
					checkChangeEduProgramGroup(e);

				}
				else if(_atsFormType==Constants.ATSF_TIME_SLOT_TYPE_ROOM)
				{
					checkChangeRoom(e);
				}
			}
		}

		private void checkChangeEduProgram(CancelEventArgs e)
		{
			EduProgram ep = (EduProgram)_workingObject;
			ArrayList [,] mytt=ep.getTimetable();
			bool allowed=true;

			foreach(Label edotlW in _mainPanel.Controls)
			{				
				if(edotlW.GetType().FullName=="OpenCTT.EnableDisableOneTermLabel")
				{
					EnableDisableOneTermLabel edotl =(EnableDisableOneTermLabel)edotlW;
					if(!edotl.getIsTermEnabled())
					{
						if(!(mytt[edotl.getIndexRow(),edotl.getIndexCol()]==null || mytt[edotl.getIndexRow(),edotl.getIndexCol()].Count==0))
						{
							allowed=false;
							break;
						}
					}
					
				}
			}

			if(!allowed)
			{
				e.Cancel = true;			
				string message1 = RES_MANAGER.GetString("checkChangeEduProgram.msb.notsuccessfull.message");
				string caption1 = RES_MANAGER.GetString("checkChangeEduProgram.msb.notsuccessfull.caption");

				MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
				MessageBox.Show(this, message1, caption1, buttons1,
					MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

			}
			else
			{
				e.Cancel=false;
			}
		}


		private void checkChangeEduProgramGroup(CancelEventArgs e)
		{
			EduProgramGroup epg = (EduProgramGroup)_workingObject;			
			bool allowed=true;
			
			foreach(Label edotlW in _mainPanel.Controls)
			{
				if(edotlW.GetType().FullName=="OpenCTT.EnableDisableOneTermLabel")
				{
					EnableDisableOneTermLabel edotl =(EnableDisableOneTermLabel)edotlW;
					if(!edotl.getIsTermEnabled())
					{
						foreach(EduProgram ep in epg.Nodes)
						{
							ArrayList [,] mytt=ep.getTimetable();
							if(!(mytt[edotl.getIndexRow(),edotl.getIndexCol()]==null || mytt[edotl.getIndexRow(),edotl.getIndexCol()].Count==0))
							{
								allowed=false;
								goto raus;                           						
							}
						}
					}
				
				}
			}

			raus:			

			if(!allowed)
			{
				e.Cancel = true;
				string message1 = RES_MANAGER.GetString("checkChangeEduProgramGroup.msb.notsuccessfull.message");

				string caption1 = RES_MANAGER.GetString("checkChangeEduProgramGroup.msb.notsuccessfull.caption");

				MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
				MessageBox.Show(this, message1, caption1, buttons1,
					MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

			}
			else
			{
				e.Cancel=false;
			}
		}


		private void checkChangeTeacher(CancelEventArgs e)
		{
			Teacher teacher = (Teacher)_workingObject;
			bool allowed=true;
			
			foreach(Label edotlW in _mainPanel.Controls)
			{
				if(edotlW.GetType().FullName=="OpenCTT.EnableDisableOneTermLabel")
				{
					EnableDisableOneTermLabel edotl =(EnableDisableOneTermLabel)edotlW;
					if(!edotl.getIsTermEnabled())
					{
						foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
						{
							foreach(EduProgram ep in epg.Nodes)
							{
								ArrayList [,] mytt=ep.getTimetable();
								ArrayList lessonsInOneTimeSlot=mytt[edotl.getIndexRow(),edotl.getIndexCol()];
								if(lessonsInOneTimeSlot!=null)
								{
									foreach(Object [] puPair in lessonsInOneTimeSlot)
									{										
										Course course = (Course)puPair[0];
										Teacher teacherFM=course.getTeacher();
										if(teacherFM==teacher)
										{
											allowed=false;
											goto raus;
										}
									}
								}
							}
						}
					}
				
				}
			}

			raus:			

				if(!allowed)
				{
					e.Cancel = true;					
					
					string message1 = RES_MANAGER.GetString("checkChangeTeacher.msb.notsuccessfull.message");
					
					string caption1 = RES_MANAGER.GetString("checkChangeTeacher.msb.notsuccessfull.caption");

					MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message1, caption1, buttons1,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
				else
				{
					e.Cancel=false;
				}
		}


		private void checkChangeRoom(CancelEventArgs e)
		{
			Room room = (Room)_workingObject;
			bool allowed=true;
			
			foreach(Label edotlW in _mainPanel.Controls)
			{
				if(edotlW.GetType().FullName=="OpenCTT.EnableDisableOneTermLabel")
				{
					EnableDisableOneTermLabel edotl =(EnableDisableOneTermLabel)edotlW;
					if(!edotl.getIsTermEnabled())
					{
						foreach(EduProgramGroup epg in AppForm.CURR_OCTT_DOC.CoursesRootNode.Nodes)
						{
							foreach(EduProgram ep in epg.Nodes)
							{
								ArrayList [,] mytt=ep.getTimetable();
								ArrayList lessonsInOneTimeSlot=mytt[edotl.getIndexRow(),edotl.getIndexCol()];
								if(lessonsInOneTimeSlot!=null)
								{
									foreach(Object [] puPair in lessonsInOneTimeSlot)
									{
										Room roomFM = (Room)puPair[1];										
										if(roomFM==room)
										{
											allowed=false;
											goto raus;
										}
									}
								}
							}
						}
					}
				
				}
			}

			raus:			

				if(!allowed)
				{
					e.Cancel = true;				
					
					string message1 = RES_MANAGER.GetString("checkChangeRoom.msb.notsuccessfull.message");
					
                    string caption1 = RES_MANAGER.GetString("checkChangeRoom.msb.notsuccessfull.caption");

					MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
					MessageBox.Show(this, message1, caption1, buttons1,
						MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				}
				else
				{
					e.Cancel=false;
				}
		}
	}

	
	internal class EnableDisableRCButton:System.Windows.Forms.Label
	{		
		private int _row;
		private int _col;
		private bool _isForEnable;
		private bool _isForRow;

		public EnableDisableRCButton(int xPos, int yPos,int row, int col, bool isForEnable, bool isForRow)
		{
			_row=row;
			_col=col;
			_isForEnable=isForEnable;
			_isForRow=isForRow;

			this.Location=new System.Drawing.Point(xPos,yPos);			
			this.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;

			this.Click += new System.EventHandler(this.RCButton_Click);
			this.MouseEnter += new System.EventHandler(this.RCButton_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.RCButton_MouseLeave);

			if(isForEnable)
			{
				this.BackColor=System.Drawing.Color.DarkSeaGreen;
			}
			else
			{
				this.BackColor=System.Drawing.Color.DarkSalmon;
			}

			if(isForRow) 
			{
				this.Size=new System.Drawing.Size(20,20);

			}
			else if(!isForRow)
			{
				this.Size=new System.Drawing.Size(40,20);

			}
			
		}

		private void RCButton_MouseEnter(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;
			label.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
		}

		private void RCButton_MouseLeave(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;			
			label.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
		}

		private void RCButton_Click(object sender, System.EventArgs e)
		{			
			
			foreach(Label edotlW in AllowedTimeSlotsForm.MAIN_PANEL.Controls )
			{
				if(edotlW.GetType().FullName=="OpenCTT.EnableDisableOneTermLabel")
				{
					EnableDisableOneTermLabel edotl =(EnableDisableOneTermLabel)edotlW;

					if(_isForRow)
					{						
						if(edotl.getIndexRow()==_row)
						{
							if(_isForEnable && !edotl.getIsTermEnabled())
							{
								edotl.setIsTermEnabled(true);
								if(edotl.getIsTermEnabled()==AllowedTimeSlotsForm.getATSForm().getAllowedTimeSlots()[edotl.getIndexRow(),edotl.getIndexCol()])
								{
									AllowedTimeSlotsForm.getATSForm().decrTimeSlotChangeCounter();
								}
								else
								{
									AllowedTimeSlotsForm.getATSForm().incrTimeSlotChangeCounter();
								}
							}
							else if(!_isForEnable && edotl.getIsTermEnabled())
							{
								edotl.setIsTermEnabled(false);
								if(edotl.getIsTermEnabled()==AllowedTimeSlotsForm.getATSForm().getAllowedTimeSlots()[edotl.getIndexRow(),edotl.getIndexCol()])
								{
									AllowedTimeSlotsForm.getATSForm().decrTimeSlotChangeCounter();
								}
								else
								{
									AllowedTimeSlotsForm.getATSForm().incrTimeSlotChangeCounter();
								}
							}							
						}

					}
					else
					{						
						if(edotl.getIndexCol()==_col)
						{							
							if(_isForEnable && !edotl.getIsTermEnabled())
							{
								edotl.setIsTermEnabled(true);
								if(edotl.getIsTermEnabled()==AllowedTimeSlotsForm.getATSForm().getAllowedTimeSlots()[edotl.getIndexRow(),edotl.getIndexCol()])
								{
									AllowedTimeSlotsForm.getATSForm().decrTimeSlotChangeCounter();
								}
								else
								{
									AllowedTimeSlotsForm.getATSForm().incrTimeSlotChangeCounter();
								}
							}
							else if(!_isForEnable && edotl.getIsTermEnabled())
							{
								edotl.setIsTermEnabled(false);
								if(edotl.getIsTermEnabled()==AllowedTimeSlotsForm.getATSForm().getAllowedTimeSlots()[edotl.getIndexRow(),edotl.getIndexCol()])
								{
									AllowedTimeSlotsForm.getATSForm().decrTimeSlotChangeCounter();
								}
								else
								{
									AllowedTimeSlotsForm.getATSForm().incrTimeSlotChangeCounter();
								}
							}
						}						

					}

					
				}
			}			

			if(AllowedTimeSlotsForm.getATSForm().getTimeSlotChangeCounter()>0)
			{
				AllowedTimeSlotsForm.getATSForm().getOKButton().Enabled=true;			
			}
			else
			{
				AllowedTimeSlotsForm.getATSForm().getOKButton().Enabled=false;
			}		
		
		}
	}

	internal class EnableDisableOneTermLabel:System.Windows.Forms.Label
	{
		private bool _isTermEnabled;
		private int _indexRow;
		private int _indexCol;

		public EnableDisableOneTermLabel(bool isTermEnabled, int indexRow, int indexCol)
		{
			_isTermEnabled=isTermEnabled;
			_indexRow=indexRow;
			_indexCol=indexCol;

			this.BorderStyle=BorderStyle.Fixed3D;
			if(isTermEnabled)
			{
				this.BackColor=System.Drawing.Color.DarkSeaGreen;
			}
			else
			{
				this.BackColor=System.Drawing.Color.DarkSalmon;
			}

			this.Click += new System.EventHandler(this.label_Click);
			this.MouseEnter += new System.EventHandler(this.edotl_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.edotl_MouseLeave);
		}

		private void edotl_MouseEnter(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;
			label.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
		}

		private void edotl_MouseLeave(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;			
			label.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
		}

		public void setIsTermEnabled(bool isTermEnabled)
		{
			_isTermEnabled=isTermEnabled;
			if(_isTermEnabled)
			{
				this.BackColor=System.Drawing.Color.DarkSeaGreen;
			}
			else
			{
				this.BackColor=System.Drawing.Color.DarkSalmon;
			}
		}

		public bool getIsTermEnabled()
		{
			return _isTermEnabled;
		}

		public int getIndexRow()
		{
			return _indexRow;
		}

		public int getIndexCol()
		{
			return _indexCol;
		}

		private void label_Click(object sender, System.EventArgs e)
		{
			if(_isTermEnabled)
			{
				_isTermEnabled=false;
				this.BackColor=System.Drawing.Color.DarkSalmon;
			}
			else
			{
				_isTermEnabled=true;
				this.BackColor=System.Drawing.Color.DarkSeaGreen;
			}

			if(_isTermEnabled==AllowedTimeSlotsForm.getATSForm().getAllowedTimeSlots()[_indexRow,_indexCol])
			{
                AllowedTimeSlotsForm.getATSForm().decrTimeSlotChangeCounter();
			}
			else
			{
				AllowedTimeSlotsForm.getATSForm().incrTimeSlotChangeCounter();
			}
			
			if(AllowedTimeSlotsForm.getATSForm().getTimeSlotChangeCounter()>0)
			{
				AllowedTimeSlotsForm.getATSForm().getOKButton().Enabled=true;			
			}
			else
			{
				AllowedTimeSlotsForm.getATSForm().getOKButton().Enabled=false;
			}
		
		}
	}
}
