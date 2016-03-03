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
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for TimeSlotPanel.
	/// </summary>
	public class TimeSlotPanel:Panel
	{
		private int _type;//(1-educational program group (study,...), 2-teacher, 3-room)
		public static MacroCommand DRAG_DROP_MACRO_CMD;
		private ArrayList _allSubLabels;
		private int _widthPanel=Settings.TIME_SLOT_PANEL_WIDTH;
		private int _heightPanel=Settings.TIME_SLOT_PANEL_HEIGHT;

		private int _indexRow;
		private int _indexCol;		
		
		public static TimeSlotPanel DRAG_DROP_START_PANEL=null;
		private static Room CURR_ROOM=null;

		public TimeSlotPanel(int type, int x, int y, int indexRow, int indexCol)
		{
            _type=type;

			_indexRow=indexRow;
			_indexCol=indexCol;
			
			_allSubLabels= new ArrayList();		

			this.Size=new System.Drawing.Size(_widthPanel,_heightPanel);
			this.Location=new System.Drawing.Point(x,y);
			this.BackColor=System.Drawing.Color.Gainsboro;
			this.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;

			this.AllowDrop=true;
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TSP_DragEnter);
			this.DragLeave += new System.EventHandler(this.TSP_DragLeave);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TSP_DragDrop);					
			
		}

		public void putLabelsOnThePanel() 
		{
			int n=0;
			foreach(Label [] oneSubLabel in _allSubLabels) 
			{
				Label courseLabel = oneSubLabel[0];
				Label underLabel = oneSubLabel[1];			

				Size sizeCourse = new System.Drawing.Size((int)_widthPanel/_allSubLabels.Count,(int)_heightPanel*5/8);
				Point pointCourse = new System.Drawing.Point(0+n*_widthPanel/_allSubLabels.Count,0);
				courseLabel.Location= pointCourse;
				courseLabel.Size= sizeCourse;
				this.Controls.Add(courseLabel);

				Size underSize;
				Point underPoint;

				if(_type==1)
				{
					underSize = new System.Drawing.Size((int)_widthPanel/_allSubLabels.Count,(int)_heightPanel*3/8);
					underPoint = new System.Drawing.Point(0+n*_widthPanel/_allSubLabels.Count,(int)_heightPanel*5/8);
					underLabel.Location= underPoint;
					underLabel.Size= underSize;				
					this.Controls.Add(underLabel);
				}
				else
				{
					underSize = new System.Drawing.Size(_widthPanel,(int)_heightPanel*3/8);
					underPoint = new System.Drawing.Point(0,(int)_heightPanel*5/8);
					underLabel.Location= underPoint;
					underLabel.Size= underSize;		
					if(n==0) this.Controls.Add(underLabel);
				}

				n++;
			}			

		}


		public void makeSubLabel(Course course, Room room) 
		{
			Label[] oneSubLabel = new Label[2];

			Label courseLabel= new Label();
			courseLabel.Tag=course;
			courseLabel.Text=course.getFullName();		
						
			courseLabel.Font = new System.Drawing.Font("Arial",Settings.TIME_SLOT_PANEL_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			courseLabel.BackColor=course.MyGUIColor;

			courseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			courseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			
			courseLabel.MouseEnter += new System.EventHandler(this.courseLabel_MouseEnter);
			courseLabel.MouseLeave += new System.EventHandler(this.courseAndUnderLabel_MouseLeave);
			
			oneSubLabel[0] = courseLabel;

			Label roomLabel= new Label();
			roomLabel.Tag=room;
			roomLabel.Text=room.getName();			
			roomLabel.Font = new System.Drawing.Font("Arial", Settings.TIME_SLOT_PANEL_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			roomLabel.BackColor=System.Drawing.SystemColors.ControlLight;
			roomLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			roomLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			
			roomLabel.MouseEnter += new System.EventHandler(this.roomAndTeacherLabel_MouseEnter);
			roomLabel.MouseLeave += new System.EventHandler(this.courseAndUnderLabel_MouseLeave);
			
			switch(_type)
			{
				case 1:
					courseLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.courseLabelForCoursesView_MouseDown);
					roomLabel.DoubleClick += new System.EventHandler(this.roomLabelForCoursesView_DoubleClick);

					break;

				case 2:
					courseLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.courseLabelForTeacherView_MouseDown);
                    roomLabel.DoubleClick += new System.EventHandler(this.roomLabelForTeacherView_DoubleClick);
					break;
			}
			
			oneSubLabel[1] = roomLabel;

			_allSubLabels.Add(oneSubLabel);
			putLabelsOnThePanel();
		}

		public void makeSubLabel(Course course, Teacher teacher) 
		{
			Label[] oneSubLabel = new Label[2];

			Label courseLabel= new Label();					
			courseLabel.Text=course.getFullName();
			courseLabel.Tag=course;			
			
			courseLabel.Font = new System.Drawing.Font("Arial", Settings.TIME_SLOT_PANEL_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			courseLabel.BackColor=course.MyGUIColor;

			courseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			courseLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			////			
			courseLabel.MouseEnter += new System.EventHandler(this.courseLabel_MouseEnter);
			courseLabel.MouseLeave += new System.EventHandler(this.courseAndUnderLabel_MouseLeave);
			
			courseLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.courseLabelForRoom_MouseDown);
			
			oneSubLabel[0] = courseLabel;

			Label teacherLabel= new Label();
			string teacherName=teacher.getName().Substring(0,1)+"."+teacher.getLastName();
			teacherLabel.Text=teacherName;
			teacherLabel.Tag=teacher;
			teacherLabel.Font = new System.Drawing.Font("Arial", Settings.TIME_SLOT_PANEL_FONT_SIZE, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			teacherLabel.BackColor=System.Drawing.SystemColors.ControlLight;
			teacherLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			teacherLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

			teacherLabel.MouseEnter += new System.EventHandler(this.roomAndTeacherLabel_MouseEnter);
			teacherLabel.MouseLeave += new System.EventHandler(this.courseAndUnderLabel_MouseLeave);
						
			oneSubLabel[1] = teacherLabel;

			_allSubLabels.Add(oneSubLabel);
			putLabelsOnThePanel();
		}


		private void courseLabel_MouseEnter(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;			
			label.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;			
			Course course = (Course)label.Tag;
			String statusText="";
			if(_type==1)
			{
				statusText=course.getTSPCoursesTextForStatusBar();

			}
			else
			{
                statusText=course.getTSPTeachersAndRoomsTextForStatusBar();
			}

			AppForm.getAppForm().getStatusBarPanel1().Text=statusText;
		}

		private void roomAndTeacherLabel_MouseEnter(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;			
			label.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;					
			String statusText="";
			if(_type==3)
			{
				Teacher teacher = (Teacher)label.Tag;			
				statusText=teacher.getTreeText();
			}
			else
			{
				Room room = (Room)label.Tag;		
				statusText=room.getStatusText();
			}			

			AppForm.getAppForm().getStatusBarPanel1().Text=statusText;
		}

		private void courseAndUnderLabel_MouseLeave(object sender, System.EventArgs e)
		{
			Label label = (Label)sender;			
			label.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;	
			this.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;
			AppForm.getAppForm().getStatusBarPanel1().Text="";
		}

		

		private void courseLabelForCoursesView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Label label = (Label)sender;			
			DRAG_DROP_START_PANEL=this;
			int subIndex=this.getSubLabelIndex(label);

			Course dragedCourse = (Course)label.Tag;
			ListViewItem lvi = new ListViewItem();
			lvi.Tag=dragedCourse;
			
			ArrayList notAllowedTimeSlots = HardConstraintChecks.findAllFreeTimeSlots(dragedCourse);

			//if drag-drop was successfull, delete label from old location
			if(DragDropEffects.Move==label.DoDragDrop(lvi,DragDropEffects.Move)) 
			{
				TSPCoursesViewDragDropSuccessfullCmd sddsCmd= new TSPCoursesViewDragDropSuccessfullCmd(dragedCourse,this,subIndex);
				DRAG_DROP_MACRO_CMD.addInList(sddsCmd);
				CommandProcessor.getCommandProcessor().doCmd(DRAG_DROP_MACRO_CMD);								
			}

			DRAG_DROP_START_PANEL=null;
			AppForm.getAppForm().doBackTimeSlotPanelGUI(notAllowedTimeSlots);
		}

		private void courseLabelForTeacherView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Label label = (Label)sender;		
			DRAG_DROP_START_PANEL=this;			

			Course courseForMove=(Course)label.Tag;
			EduProgram epInMove=(EduProgram)courseForMove.Parent;
			ArrayList [,] mytt = epInMove.getTimetable();			
			ArrayList lessonsInOneTimeSlot = mytt[_indexRow,_indexCol];
			
			Object [] courseAndRoomPair=null;
			foreach(Object [] courseAndRoomPairInList in lessonsInOneTimeSlot)
			{				
				Course thisCourse = (Course)courseAndRoomPairInList[0];
				if(thisCourse==courseForMove)
				{
					courseAndRoomPair=courseAndRoomPairInList;
					break;
				}
			}

						
			Course dragedCourse = (Course)courseAndRoomPair[0];
			ListViewItem lvi = new ListViewItem();
			lvi.Tag=dragedCourse;
			
			ArrayList notAllowedTimeSlots = HardConstraintChecks.findAllFreeTimeSlots(dragedCourse);

			//if drag-drop was successfull, delete label from old location
			if(DragDropEffects.Move==label.DoDragDrop(lvi,DragDropEffects.Move)) 
			{		
				TSPTeachersViewDragDropSuccessfullCmd nddsCmd= new TSPTeachersViewDragDropSuccessfullCmd(dragedCourse,this,lessonsInOneTimeSlot,courseAndRoomPair);
				DRAG_DROP_MACRO_CMD.addInList(nddsCmd);
				CommandProcessor.getCommandProcessor().doCmd(DRAG_DROP_MACRO_CMD);
								
			}

			DRAG_DROP_START_PANEL=null;
			AppForm.getAppForm().doBackTimeSlotPanelGUI(notAllowedTimeSlots);
		}

		private void courseLabelForRoom_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{            
			Label label = (Label)sender;		
			DRAG_DROP_START_PANEL=this;
			
			Course courseForMove=(Course)label.Tag;
			EduProgram epInMove=(EduProgram)courseForMove.Parent;
			ArrayList [,] mytt = epInMove.getTimetable();			
			ArrayList lessonsInOneTimeSlot = mytt[_indexRow,_indexCol];
			
			Object [] courseAndRoomPair=null;
			foreach(Object [] courseAndRoomPairInList in lessonsInOneTimeSlot)
			{				
				Course thisCourse = (Course)courseAndRoomPairInList[0];
				if(thisCourse==courseForMove)
				{
					courseAndRoomPair=courseAndRoomPairInList;
					break;
				}
			}
						
			CURR_ROOM=(Room)courseAndRoomPair[1];
			Course dragedCourse = (Course)courseAndRoomPair[0];
			ListViewItem lvi = new ListViewItem();
			lvi.Tag=dragedCourse;

            ArrayList notAllowedTimeSlots = HardConstraintChecks.findAllFreeTimeSlotsForRoomsView(dragedCourse, CURR_ROOM);

			//if drag-drop was successfull, delete label from old location
			if(DragDropEffects.Move==label.DoDragDrop(lvi,DragDropEffects.Move)) 
			{
				TSPRoomsViewDragDropSuccessfullCmd uddsCmd= new TSPRoomsViewDragDropSuccessfullCmd(dragedCourse,this,lessonsInOneTimeSlot,courseAndRoomPair);
				DRAG_DROP_MACRO_CMD.addInList(uddsCmd);
				CommandProcessor.getCommandProcessor().doCmd(DRAG_DROP_MACRO_CMD);
												
			}

			DRAG_DROP_START_PANEL=null;
			AppForm.getAppForm().doBackTimeSlotPanelGUI(notAllowedTimeSlots);
		}
		

		public int getIndexRow() 
		{
			return _indexRow;

		}

		public int getIndexCol() 
		{
			return _indexCol;

		}

		private void TSP_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{			
			if(checkIfDropCanBeDone(this)) 
			{
				this.BorderStyle= System.Windows.Forms.BorderStyle.FixedSingle;
				this.BackColor=System.Drawing.Color.DarkSeaGreen;
				e.Effect = DragDropEffects.Move;
			}
		}

		private void TSP_DragLeave(object sender, System.EventArgs e)
		{			
			if(checkIfDropCanBeDone(this))
			{
				this.BorderStyle= System.Windows.Forms.BorderStyle.Fixed3D;
				this.BackColor=System.Drawing.Color.Gainsboro;
			}
		}


		private void TSP_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{					
			ListViewItem lvi = (ListViewItem)e.Data.GetData(DataFormats.Serializable);
			Course dropedCourse = (Course)lvi.Tag;
			DRAG_DROP_MACRO_CMD= new MacroCommand();
			
			switch(_type)
			{
				case 1:
					TSPCoursesViewDragDropCmd sddCmd= new TSPCoursesViewDragDropCmd(dropedCourse,this);
					DRAG_DROP_MACRO_CMD.addInList(sddCmd);					
					break;
				case 2:
					TSPTeachersViewDragDropCmd nddCmd= new TSPTeachersViewDragDropCmd(dropedCourse,this);
					DRAG_DROP_MACRO_CMD.addInList(nddCmd);					
					break;
				case 3:
					TSPRoomsViewDragDropCmd uddCmd= new TSPRoomsViewDragDropCmd(dropedCourse,this,CURR_ROOM);
					DRAG_DROP_MACRO_CMD.addInList(uddCmd);					
					break;
			}

			this.BackColor=System.Drawing.Color.Gainsboro;
			
		}

		private void roomLabelForTeacherView_DoubleClick(object sender, System.EventArgs e)
		{
			Label roomLabel = (Label)sender;			
			IEnumerator enumerator=_allSubLabels.GetEnumerator();
			enumerator.MoveNext();
			Label[] oneSubLabel=(Label [])enumerator.Current;
			Label courseLabel1=oneSubLabel[0];
			Course course=(Course)courseLabel1.Tag;
			EduProgram ep = (EduProgram)course.Parent;
			ArrayList [,] mytt = ep.getTimetable();
			ArrayList lessonsInOneTimeSlot = mytt[_indexRow,_indexCol];

			Object [] courseAndRoomPair=null;
			foreach(Object [] courseAndRoomPairCC in lessonsInOneTimeSlot)
			{				
				Course courseCheck = (Course)courseAndRoomPairCC[0];
				if(courseCheck==course)
				{
					courseAndRoomPair=courseAndRoomPairCC;
					break;
				}
			}
			
			Room currRoom = (Room)roomLabel.Tag;
			ArrayList allowedRooms=calculateAllAllowedRooms(course,_indexRow,_indexCol);
			allowedRooms.Add(currRoom);

			roomLabel.BackColor=System.Drawing.Color.DarkOrange;

			RoomSelectionForm cu = new RoomSelectionForm(roomLabel,allowedRooms,currRoom, course, courseAndRoomPair);
			cu.ShowDialog(AppForm.getAppForm());
			if(cu.DialogResult == DialogResult.OK)
			{
				Room newRoom = cu.getSelectedRoom();

				ChooseRoomTSPTeachersViewCmd cuCmd=new ChooseRoomTSPTeachersViewCmd(courseAndRoomPair,course,currRoom,newRoom,roomLabel,_indexRow,_indexCol);
				CommandProcessor.getCommandProcessor().doCmd(cuCmd);
			}

			cu.Dispose();
			roomLabel.BackColor=System.Drawing.SystemColors.ControlLight;
		}

		private void roomLabelForCoursesView_DoubleClick(object sender, System.EventArgs e)
		{
			Label roomLabel = (Label)sender;
			int subIndex=getSubLabelIndex(roomLabel);
			
			ArrayList [,] mytt = AppForm.CURR_OCTT_DOC.ShownEduProgram.getTimetable();
			ArrayList lessonsInOneTimeSlot = mytt[_indexRow,_indexCol];			
			IEnumerator enumerator=lessonsInOneTimeSlot.GetEnumerator();
			for(int k=0;k<=subIndex;k++)
			{
				enumerator.MoveNext();
			}
			
			Object [] courseAndRoomPair=(Object [])enumerator.Current;
			Room currRoom = (Room)courseAndRoomPair[1];
			Course course = (Course)courseAndRoomPair[0];
			ArrayList allowedRooms=calculateAllAllowedRooms(course,_indexRow,_indexCol);
			allowedRooms.Add(currRoom);

			roomLabel.BackColor=System.Drawing.Color.DarkOrange;

			RoomSelectionForm cu = new RoomSelectionForm(roomLabel,allowedRooms,currRoom, course, courseAndRoomPair);			
			cu.ShowDialog(AppForm.getAppForm());
			if(cu.DialogResult == DialogResult.OK)
			{
				Room newRoom = cu.getSelectedRoom();

				ChooseRoomTSPCoursesViewCmd cuCmd=new ChooseRoomTSPCoursesViewCmd(courseAndRoomPair,course,currRoom,newRoom,roomLabel,_indexRow,_indexCol);
				CommandProcessor.getCommandProcessor().doCmd(cuCmd);				
			}
			cu.Dispose();		
			roomLabel.BackColor=System.Drawing.SystemColors.ControlLight;
		}

		private int getSubLabelIndex(Label labelToFind)
		{
			int index = -1;
			foreach(Label [] courseRoomSubLabel in _allSubLabels) 
			{
				index++;
				Label courseLabel=courseRoomSubLabel[0];
				Label roomLabel=courseRoomSubLabel[1];
				if(roomLabel==labelToFind || courseLabel==labelToFind) break;
				
			}
			return index;

		} 

		public ArrayList calculateAllAllowedRooms(Course dragedCourse,int indexRow,int indexCol)
		{
			ArrayList allowedRooms = HardConstraintChecks.getPossibleRoomsRelCapacity(dragedCourse);
			
			return HardConstraintChecks.getPossibleRoomsRelTimeSlot(allowedRooms,indexRow, indexCol);
			
		}

		private bool checkIfDropCanBeDone(TimeSlotPanel tsp)
		{		
			if(tsp==DRAG_DROP_START_PANEL)
			{
				return false;
			} 
			else return true;

		}

		public ArrayList getAllSubLabels() 
		{
			return _allSubLabels;
		}

		public int Type
		{
			set{_type=value;}
		}
		
	}
}
