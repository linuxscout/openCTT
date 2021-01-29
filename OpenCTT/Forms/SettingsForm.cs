#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan 苪rak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan 苪rak, Split, Croatia
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
using System.IO;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;

namespace OpenCTT
{
	/// <summary>
	/// Summary description for SettingsForm.
	/// </summary>
	public class SettingsForm : System.Windows.Forms.Form
	{
        
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.TabControl _tabControl;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _schoolYearTextBox;
		private System.Windows.Forms.TextBox _eduInstNameTextBox;
        private System.Windows.Forms.TabPage _generalSettTabPage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox _workDirTextBox;
        private System.Windows.Forms.Button _browseDirButton;
        private TabPage _reportMain1TabPage;
        private TextBox _mtsXTextBox;
        private Label label9;
        private TextBox _mtcwTextBox;
        private Label label13;
        private TextBox _mtrhTextBox;
        private Label label12;
        private TextBox _mtsYTextBox;
        private Label label11;
        private TextBox _htrhTextBox;
        private Label label14;
        private TextBox _tptcwTextBox;
        private Label label15;
        private ComboBox _paperSizeComboBox;
        private Label label19;
        private ComboBox _paperOrientationComboBox;
        private Label label20;
        private TabPage _reportMain2TabPage;
        private Button _browsePdfViewerButton;
        private TextBox _pdfReaderTextBox;
        private Label label10;
        private ComboBox _pageTitleFontComboBox;
        private Label label29;
        private GroupBox groupBox4;
        private ComboBox _pageTitleFontSizeComboBox;
        private Label label31;
        private ComboBox _pageTitleFontStyleComboBox;
        private Label label30;
        private GroupBox groupBox5;
        private ComboBox _dayNamesFontSizeComboBox;
        private Label label32;
        private Label label33;
        private ComboBox _dayNamesFontStyleComboBox;
        private ComboBox _dayNamesFontComboBox;
        private Label label34;
        private GroupBox groupBox6;
        private ComboBox _timePerFontSizeComboBox;
        private Label label35;
        private Label label36;
        private ComboBox _timePerFontStyleComboBox;
        private ComboBox _timePerFontComboBox;
        private Label label37;
        private GroupBox groupBox7;
        private ComboBox _timeSlotsFontSizeComboBox;
        private Label label38;
        private Label label39;
        private ComboBox _timeSlotsFontStyleComboBox;
        private ComboBox _timeSlotsFontComboBox;
        private Label label40;
        private GroupBox groupBox8;
        private ComboBox _footerFontSizeComboBox;
        private Label label41;
        private Label label42;
        private ComboBox _footerFontStyleComboBox;
        private ComboBox _footerFontComboBox;
        private Label label43;
        private GroupBox groupBox9;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label8;
        private ComboBox _guiLanguageComboBox;
        private ComboBox _defaultGUITextTypeComboBox;
        private Label label7;
        private ComboBox _courseFormatComboBox;
        private ComboBox _printTeacherComboBox;
        private Label label17;
        private Label label16;
        private GroupBox groupBox3;
        private TextBox _colorTS_B_TextBox;
        private TextBox _colorTS_G_TextBox;
        private TextBox _colorTS_R_TextBox;
        private Label label21;
        private Label label27;
        private Label label28;
        private GroupBox groupBox2;
        private TextBox _colorTP_B_TextBox;
        private TextBox _colorTP_G_TextBox;
        private TextBox _colorTP_R_TextBox;
        private Label label24;
        private Label label25;
        private Label label26;
        private GroupBox groupBox1;
        private TextBox _colorH_B_TextBox;
        private TextBox _colorH_G_TextBox;
        private Label label22;
        private Label label23;
        private TextBox _colorH_R_TextBox;
        private Label label18;
        private TabPage _scWeightsTabPage;
        private TextBox _teacherMaxHoursDailyWeightTextBox;
        private Label label44;
        private TextBox _teacherMaxHoursContWeightTextBox;
        private Label label45;
        private TextBox _teacherMaxDaysPerWeekWeightTextBox;
        private Label label46;
        private TextBox _studentMaxHoursContWeightTextBox;
        private Label label47;
        private TextBox _studentMaxHoursDailyWeightTextBox;
        private Label label48;
        private TextBox _studentMaxDaysPerWeekWeightTextBox;
        private Label label49;
        private TextBox _studentNoGapsWeightTextBox;
        private Label label50;
        private TextBox _studentPreferredStartTimePeriodWeightTextBox;
        private Label label58;
        private Label label51;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label52;
        private TextBox textBox3;
        private Label label53;
        private TextBox textBox4;
        private Label label54;
        private TextBox textBox5;
        private Label label55;
        private TextBox textBox6;
        private Label label56;
        private TextBox textBox7;
        private Label label57;
        private TextBox _courseLessonBlocksWeightTextBox;
        private Label label59;
        private IContainer components;

		public SettingsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();		
	
			_defaultGUITextTypeComboBox.DataSource=AppForm.DOCUMENT_TYPES_LIST;		
	
			ArrayList languagesList = new ArrayList();
			languagesList.Add(new OCTTGuiLanguage("en","English"));
            languagesList.Add(new OCTTGuiLanguage("hr-HR","Croatian (Hrvatski)"));
            languagesList.Add(new OCTTGuiLanguage("fr-FR", "French (Fran?ais)")); 
            languagesList.Add(new OCTTGuiLanguage("ar-AR", "Arabic (العربية)"));

            _guiLanguageComboBox.DataSource=languagesList;
			_guiLanguageComboBox.ValueMember="ShortLang";
			_guiLanguageComboBox.DisplayMember="LongLang";

            Type ps = typeof(PageSize);
            //_paperSizeComboBox.DataSource = Enum.GetValues(ps);
            ArrayList als = new ArrayList();            
            foreach (string s in Enum.GetNames(ps))
            {
                als.Add(s);
            }
            _paperSizeComboBox.DataSource = als; ;

            Type po = typeof(PageOrientation);            
            ArrayList alo = new ArrayList();
            foreach (string s in Enum.GetNames(po))
            {
                alo.Add(s);
            }
            _paperOrientationComboBox.DataSource = alo;

            //
            Type fs = typeof(XFontStyle);
            ArrayList alfs = new ArrayList();           

            foreach (string s in Enum.GetNames(fs))
            {
                alfs.Add(s);
            }
            _pageTitleFontStyleComboBox.DataSource = alfs;
            _dayNamesFontStyleComboBox.DataSource = alfs.Clone();
            _timePerFontStyleComboBox.DataSource = alfs.Clone();
            _timeSlotsFontStyleComboBox.DataSource = alfs.Clone();
            _footerFontStyleComboBox.DataSource = alfs.Clone();

            ArrayList familyList = new ArrayList();
            foreach (FontFamily ff in FontFamily.Families)
            {
                familyList.Add(ff.GetName(0));
            }
            _pageTitleFontComboBox.DataSource = familyList;
            _dayNamesFontComboBox.DataSource = familyList.Clone();
            _timePerFontComboBox.DataSource = familyList.Clone();
            _timeSlotsFontComboBox.DataSource = familyList.Clone();
            _footerFontComboBox.DataSource = familyList.Clone();

            ArrayList sizeList = new ArrayList();
            for (int n = 1; n < 61; n++)
            {
                sizeList.Add(n);
            }
            _pageTitleFontSizeComboBox.DataSource = sizeList;
            _dayNamesFontSizeComboBox.DataSource = sizeList.Clone();
            _timePerFontSizeComboBox.DataSource = sizeList.Clone();
            _timeSlotsFontSizeComboBox.DataSource = sizeList.Clone();
            _footerFontSizeComboBox.DataSource = sizeList.Clone();
			
		}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._generalSettTabPage = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this._guiLanguageComboBox = new System.Windows.Forms.ComboBox();
            this._defaultGUITextTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._browsePdfViewerButton = new System.Windows.Forms.Button();
            this._pdfReaderTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._browseDirButton = new System.Windows.Forms.Button();
            this._workDirTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._schoolYearTextBox = new System.Windows.Forms.TextBox();
            this._eduInstNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._reportMain1TabPage = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._colorTS_B_TextBox = new System.Windows.Forms.TextBox();
            this._colorTS_G_TextBox = new System.Windows.Forms.TextBox();
            this._colorTS_R_TextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._colorTP_B_TextBox = new System.Windows.Forms.TextBox();
            this._colorTP_G_TextBox = new System.Windows.Forms.TextBox();
            this._colorTP_R_TextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._colorH_B_TextBox = new System.Windows.Forms.TextBox();
            this._colorH_G_TextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this._colorH_R_TextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this._courseFormatComboBox = new System.Windows.Forms.ComboBox();
            this._printTeacherComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this._paperOrientationComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this._paperSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this._tptcwTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this._htrhTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._mtcwTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this._mtrhTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._mtsYTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._mtsXTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._reportMain2TabPage = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this._footerFontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this._footerFontStyleComboBox = new System.Windows.Forms.ComboBox();
            this._footerFontComboBox = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this._timeSlotsFontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this._timeSlotsFontStyleComboBox = new System.Windows.Forms.ComboBox();
            this._timeSlotsFontComboBox = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this._timePerFontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this._timePerFontStyleComboBox = new System.Windows.Forms.ComboBox();
            this._timePerFontComboBox = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._dayNamesFontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this._dayNamesFontStyleComboBox = new System.Windows.Forms.ComboBox();
            this._dayNamesFontComboBox = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._pageTitleFontSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this._pageTitleFontStyleComboBox = new System.Windows.Forms.ComboBox();
            this._pageTitleFontComboBox = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this._scWeightsTabPage = new System.Windows.Forms.TabPage();
            this._courseLessonBlocksWeightTextBox = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this._studentPreferredStartTimePeriodWeightTextBox = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this._studentNoGapsWeightTextBox = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this._studentMaxDaysPerWeekWeightTextBox = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this._studentMaxHoursDailyWeightTextBox = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this._studentMaxHoursContWeightTextBox = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this._teacherMaxDaysPerWeekWeightTextBox = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this._teacherMaxHoursContWeightTextBox = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this._teacherMaxHoursDailyWeightTextBox = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this._tabControl.SuspendLayout();
            this._generalSettTabPage.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this._reportMain1TabPage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._reportMain2TabPage.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this._scWeightsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._generalSettTabPage);
            this._tabControl.Controls.Add(this._reportMain1TabPage);
            this._tabControl.Controls.Add(this._reportMain2TabPage);
            this._tabControl.Controls.Add(this._scWeightsTabPage);
            resources.ApplyResources(this._tabControl, "_tabControl");
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            // 
            // _generalSettTabPage
            // 
            this._generalSettTabPage.Controls.Add(this.groupBox9);
            this._generalSettTabPage.Controls.Add(this._browsePdfViewerButton);
            this._generalSettTabPage.Controls.Add(this._pdfReaderTextBox);
            this._generalSettTabPage.Controls.Add(this.label10);
            this._generalSettTabPage.Controls.Add(this._browseDirButton);
            this._generalSettTabPage.Controls.Add(this._workDirTextBox);
            this._generalSettTabPage.Controls.Add(this.label6);
            this._generalSettTabPage.Controls.Add(this._schoolYearTextBox);
            this._generalSettTabPage.Controls.Add(this._eduInstNameTextBox);
            this._generalSettTabPage.Controls.Add(this.label2);
            this._generalSettTabPage.Controls.Add(this.label1);
            resources.ApplyResources(this._generalSettTabPage, "_generalSettTabPage");
            this._generalSettTabPage.Name = "_generalSettTabPage";
            this._generalSettTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this._guiLanguageComboBox);
            this.groupBox9.Controls.Add(this._defaultGUITextTypeComboBox);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.numericUpDown3);
            this.groupBox9.Controls.Add(this.numericUpDown2);
            this.groupBox9.Controls.Add(this.numericUpDown1);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox9, "groupBox9");
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // _guiLanguageComboBox
            // 
            this._guiLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._guiLanguageComboBox, "_guiLanguageComboBox");
            this._guiLanguageComboBox.Name = "_guiLanguageComboBox";
            // 
            // _defaultGUITextTypeComboBox
            // 
            this._defaultGUITextTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this._defaultGUITextTypeComboBox, "_defaultGUITextTypeComboBox");
            this._defaultGUITextTypeComboBox.Name = "_defaultGUITextTypeComboBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numericUpDown3
            // 
            resources.ApplyResources(this.numericUpDown3, "numericUpDown3");
            this.numericUpDown3.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            resources.ApplyResources(this.numericUpDown2, "numericUpDown2");
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // _browsePdfViewerButton
            // 
            resources.ApplyResources(this._browsePdfViewerButton, "_browsePdfViewerButton");
            this._browsePdfViewerButton.Name = "_browsePdfViewerButton";
            this._browsePdfViewerButton.Click += new System.EventHandler(this._browsePdfViewerButton_Click);
            // 
            // _pdfReaderTextBox
            // 
            resources.ApplyResources(this._pdfReaderTextBox, "_pdfReaderTextBox");
            this._pdfReaderTextBox.Name = "_pdfReaderTextBox";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // _browseDirButton
            // 
            resources.ApplyResources(this._browseDirButton, "_browseDirButton");
            this._browseDirButton.Name = "_browseDirButton";
            this._browseDirButton.Click += new System.EventHandler(this._browseDirButton_Click);
            // 
            // _workDirTextBox
            // 
            resources.ApplyResources(this._workDirTextBox, "_workDirTextBox");
            this._workDirTextBox.Name = "_workDirTextBox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // _schoolYearTextBox
            // 
            resources.ApplyResources(this._schoolYearTextBox, "_schoolYearTextBox");
            this._schoolYearTextBox.Name = "_schoolYearTextBox";
            // 
            // _eduInstNameTextBox
            // 
            resources.ApplyResources(this._eduInstNameTextBox, "_eduInstNameTextBox");
            this._eduInstNameTextBox.Name = "_eduInstNameTextBox";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _reportMain1TabPage
            // 
            this._reportMain1TabPage.Controls.Add(this.groupBox3);
            this._reportMain1TabPage.Controls.Add(this.groupBox2);
            this._reportMain1TabPage.Controls.Add(this.groupBox1);
            this._reportMain1TabPage.Controls.Add(this._courseFormatComboBox);
            this._reportMain1TabPage.Controls.Add(this._printTeacherComboBox);
            this._reportMain1TabPage.Controls.Add(this.label17);
            this._reportMain1TabPage.Controls.Add(this.label16);
            this._reportMain1TabPage.Controls.Add(this._paperOrientationComboBox);
            this._reportMain1TabPage.Controls.Add(this.label20);
            this._reportMain1TabPage.Controls.Add(this._paperSizeComboBox);
            this._reportMain1TabPage.Controls.Add(this.label19);
            this._reportMain1TabPage.Controls.Add(this._tptcwTextBox);
            this._reportMain1TabPage.Controls.Add(this.label15);
            this._reportMain1TabPage.Controls.Add(this._htrhTextBox);
            this._reportMain1TabPage.Controls.Add(this.label14);
            this._reportMain1TabPage.Controls.Add(this._mtcwTextBox);
            this._reportMain1TabPage.Controls.Add(this.label13);
            this._reportMain1TabPage.Controls.Add(this._mtrhTextBox);
            this._reportMain1TabPage.Controls.Add(this.label12);
            this._reportMain1TabPage.Controls.Add(this._mtsYTextBox);
            this._reportMain1TabPage.Controls.Add(this.label11);
            this._reportMain1TabPage.Controls.Add(this._mtsXTextBox);
            this._reportMain1TabPage.Controls.Add(this.label9);
            resources.ApplyResources(this._reportMain1TabPage, "_reportMain1TabPage");
            this._reportMain1TabPage.Name = "_reportMain1TabPage";
            this._reportMain1TabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._colorTS_B_TextBox);
            this.groupBox3.Controls.Add(this._colorTS_G_TextBox);
            this.groupBox3.Controls.Add(this._colorTS_R_TextBox);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.label28);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // _colorTS_B_TextBox
            // 
            resources.ApplyResources(this._colorTS_B_TextBox, "_colorTS_B_TextBox");
            this._colorTS_B_TextBox.Name = "_colorTS_B_TextBox";
            this._colorTS_B_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // _colorTS_G_TextBox
            // 
            resources.ApplyResources(this._colorTS_G_TextBox, "_colorTS_G_TextBox");
            this._colorTS_G_TextBox.Name = "_colorTS_G_TextBox";
            this._colorTS_G_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // _colorTS_R_TextBox
            // 
            resources.ApplyResources(this._colorTS_R_TextBox, "_colorTS_R_TextBox");
            this._colorTS_R_TextBox.Name = "_colorTS_R_TextBox";
            this._colorTS_R_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._colorTP_B_TextBox);
            this.groupBox2.Controls.Add(this._colorTP_G_TextBox);
            this.groupBox2.Controls.Add(this._colorTP_R_TextBox);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label26);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // _colorTP_B_TextBox
            // 
            resources.ApplyResources(this._colorTP_B_TextBox, "_colorTP_B_TextBox");
            this._colorTP_B_TextBox.Name = "_colorTP_B_TextBox";
            this._colorTP_B_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // _colorTP_G_TextBox
            // 
            resources.ApplyResources(this._colorTP_G_TextBox, "_colorTP_G_TextBox");
            this._colorTP_G_TextBox.Name = "_colorTP_G_TextBox";
            this._colorTP_G_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // _colorTP_R_TextBox
            // 
            resources.ApplyResources(this._colorTP_R_TextBox, "_colorTP_R_TextBox");
            this._colorTP_R_TextBox.Name = "_colorTP_R_TextBox";
            this._colorTP_R_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._colorH_B_TextBox);
            this.groupBox1.Controls.Add(this._colorH_G_TextBox);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this._colorH_R_TextBox);
            this.groupBox1.Controls.Add(this.label18);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // _colorH_B_TextBox
            // 
            resources.ApplyResources(this._colorH_B_TextBox, "_colorH_B_TextBox");
            this._colorH_B_TextBox.Name = "_colorH_B_TextBox";
            this._colorH_B_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // _colorH_G_TextBox
            // 
            resources.ApplyResources(this._colorH_G_TextBox, "_colorH_G_TextBox");
            this._colorH_G_TextBox.Name = "_colorH_G_TextBox";
            this._colorH_G_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // _colorH_R_TextBox
            // 
            resources.ApplyResources(this._colorH_R_TextBox, "_colorH_R_TextBox");
            this._colorH_R_TextBox.Name = "_colorH_R_TextBox";
            this._colorH_R_TextBox.TextChanged += new System.EventHandler(this.RGB_TextBox_TextChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // _courseFormatComboBox
            // 
            this._courseFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseFormatComboBox.FormattingEnabled = true;
            this._courseFormatComboBox.Items.AddRange(new object[] {
            resources.GetString("_courseFormatComboBox.Items"),
            resources.GetString("_courseFormatComboBox.Items1")});
            resources.ApplyResources(this._courseFormatComboBox, "_courseFormatComboBox");
            this._courseFormatComboBox.Name = "_courseFormatComboBox";
            // 
            // _printTeacherComboBox
            // 
            this._printTeacherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._printTeacherComboBox.FormattingEnabled = true;
            this._printTeacherComboBox.Items.AddRange(new object[] {
            resources.GetString("_printTeacherComboBox.Items"),
            resources.GetString("_printTeacherComboBox.Items1")});
            resources.ApplyResources(this._printTeacherComboBox, "_printTeacherComboBox");
            this._printTeacherComboBox.Name = "_printTeacherComboBox";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // _paperOrientationComboBox
            // 
            this._paperOrientationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._paperOrientationComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._paperOrientationComboBox, "_paperOrientationComboBox");
            this._paperOrientationComboBox.Name = "_paperOrientationComboBox";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // _paperSizeComboBox
            // 
            this._paperSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._paperSizeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._paperSizeComboBox, "_paperSizeComboBox");
            this._paperSizeComboBox.Name = "_paperSizeComboBox";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // _tptcwTextBox
            // 
            resources.ApplyResources(this._tptcwTextBox, "_tptcwTextBox");
            this._tptcwTextBox.Name = "_tptcwTextBox";
            this._tptcwTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // _htrhTextBox
            // 
            resources.ApplyResources(this._htrhTextBox, "_htrhTextBox");
            this._htrhTextBox.Name = "_htrhTextBox";
            this._htrhTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // _mtcwTextBox
            // 
            resources.ApplyResources(this._mtcwTextBox, "_mtcwTextBox");
            this._mtcwTextBox.Name = "_mtcwTextBox";
            this._mtcwTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // _mtrhTextBox
            // 
            resources.ApplyResources(this._mtrhTextBox, "_mtrhTextBox");
            this._mtrhTextBox.Name = "_mtrhTextBox";
            this._mtrhTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // _mtsYTextBox
            // 
            resources.ApplyResources(this._mtsYTextBox, "_mtsYTextBox");
            this._mtsYTextBox.Name = "_mtsYTextBox";
            this._mtsYTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // _mtsXTextBox
            // 
            resources.ApplyResources(this._mtsXTextBox, "_mtsXTextBox");
            this._mtsXTextBox.Name = "_mtsXTextBox";
            this._mtsXTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // _reportMain2TabPage
            // 
            this._reportMain2TabPage.Controls.Add(this.groupBox8);
            this._reportMain2TabPage.Controls.Add(this.groupBox7);
            this._reportMain2TabPage.Controls.Add(this.groupBox6);
            this._reportMain2TabPage.Controls.Add(this.groupBox5);
            this._reportMain2TabPage.Controls.Add(this.groupBox4);
            resources.ApplyResources(this._reportMain2TabPage, "_reportMain2TabPage");
            this._reportMain2TabPage.Name = "_reportMain2TabPage";
            this._reportMain2TabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this._footerFontSizeComboBox);
            this.groupBox8.Controls.Add(this.label41);
            this.groupBox8.Controls.Add(this.label42);
            this.groupBox8.Controls.Add(this._footerFontStyleComboBox);
            this.groupBox8.Controls.Add(this._footerFontComboBox);
            this.groupBox8.Controls.Add(this.label43);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // _footerFontSizeComboBox
            // 
            this._footerFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._footerFontSizeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._footerFontSizeComboBox, "_footerFontSizeComboBox");
            this._footerFontSizeComboBox.Name = "_footerFontSizeComboBox";
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // _footerFontStyleComboBox
            // 
            this._footerFontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._footerFontStyleComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._footerFontStyleComboBox, "_footerFontStyleComboBox");
            this._footerFontStyleComboBox.Name = "_footerFontStyleComboBox";
            // 
            // _footerFontComboBox
            // 
            this._footerFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._footerFontComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._footerFontComboBox, "_footerFontComboBox");
            this._footerFontComboBox.Name = "_footerFontComboBox";
            // 
            // label43
            // 
            resources.ApplyResources(this.label43, "label43");
            this.label43.Name = "label43";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this._timeSlotsFontSizeComboBox);
            this.groupBox7.Controls.Add(this.label38);
            this.groupBox7.Controls.Add(this.label39);
            this.groupBox7.Controls.Add(this._timeSlotsFontStyleComboBox);
            this.groupBox7.Controls.Add(this._timeSlotsFontComboBox);
            this.groupBox7.Controls.Add(this.label40);
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // _timeSlotsFontSizeComboBox
            // 
            this._timeSlotsFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._timeSlotsFontSizeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._timeSlotsFontSizeComboBox, "_timeSlotsFontSizeComboBox");
            this._timeSlotsFontSizeComboBox.Name = "_timeSlotsFontSizeComboBox";
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // _timeSlotsFontStyleComboBox
            // 
            this._timeSlotsFontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._timeSlotsFontStyleComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._timeSlotsFontStyleComboBox, "_timeSlotsFontStyleComboBox");
            this._timeSlotsFontStyleComboBox.Name = "_timeSlotsFontStyleComboBox";
            // 
            // _timeSlotsFontComboBox
            // 
            this._timeSlotsFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._timeSlotsFontComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._timeSlotsFontComboBox, "_timeSlotsFontComboBox");
            this._timeSlotsFontComboBox.Name = "_timeSlotsFontComboBox";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this._timePerFontSizeComboBox);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this._timePerFontStyleComboBox);
            this.groupBox6.Controls.Add(this._timePerFontComboBox);
            this.groupBox6.Controls.Add(this.label37);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // _timePerFontSizeComboBox
            // 
            this._timePerFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._timePerFontSizeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._timePerFontSizeComboBox, "_timePerFontSizeComboBox");
            this._timePerFontSizeComboBox.Name = "_timePerFontSizeComboBox";
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // _timePerFontStyleComboBox
            // 
            this._timePerFontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._timePerFontStyleComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._timePerFontStyleComboBox, "_timePerFontStyleComboBox");
            this._timePerFontStyleComboBox.Name = "_timePerFontStyleComboBox";
            // 
            // _timePerFontComboBox
            // 
            this._timePerFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._timePerFontComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._timePerFontComboBox, "_timePerFontComboBox");
            this._timePerFontComboBox.Name = "_timePerFontComboBox";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._dayNamesFontSizeComboBox);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this._dayNamesFontStyleComboBox);
            this.groupBox5.Controls.Add(this._dayNamesFontComboBox);
            this.groupBox5.Controls.Add(this.label34);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // _dayNamesFontSizeComboBox
            // 
            this._dayNamesFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dayNamesFontSizeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._dayNamesFontSizeComboBox, "_dayNamesFontSizeComboBox");
            this._dayNamesFontSizeComboBox.Name = "_dayNamesFontSizeComboBox";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // _dayNamesFontStyleComboBox
            // 
            this._dayNamesFontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dayNamesFontStyleComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._dayNamesFontStyleComboBox, "_dayNamesFontStyleComboBox");
            this._dayNamesFontStyleComboBox.Name = "_dayNamesFontStyleComboBox";
            // 
            // _dayNamesFontComboBox
            // 
            this._dayNamesFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dayNamesFontComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._dayNamesFontComboBox, "_dayNamesFontComboBox");
            this._dayNamesFontComboBox.Name = "_dayNamesFontComboBox";
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._pageTitleFontSizeComboBox);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this._pageTitleFontStyleComboBox);
            this.groupBox4.Controls.Add(this._pageTitleFontComboBox);
            this.groupBox4.Controls.Add(this.label30);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // _pageTitleFontSizeComboBox
            // 
            this._pageTitleFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._pageTitleFontSizeComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._pageTitleFontSizeComboBox, "_pageTitleFontSizeComboBox");
            this._pageTitleFontSizeComboBox.Name = "_pageTitleFontSizeComboBox";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // _pageTitleFontStyleComboBox
            // 
            this._pageTitleFontStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._pageTitleFontStyleComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._pageTitleFontStyleComboBox, "_pageTitleFontStyleComboBox");
            this._pageTitleFontStyleComboBox.Name = "_pageTitleFontStyleComboBox";
            // 
            // _pageTitleFontComboBox
            // 
            this._pageTitleFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._pageTitleFontComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._pageTitleFontComboBox, "_pageTitleFontComboBox");
            this._pageTitleFontComboBox.Name = "_pageTitleFontComboBox";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // _scWeightsTabPage
            // 
            this._scWeightsTabPage.Controls.Add(this._courseLessonBlocksWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label59);
            this._scWeightsTabPage.Controls.Add(this._studentPreferredStartTimePeriodWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label58);
            this._scWeightsTabPage.Controls.Add(this._studentNoGapsWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label50);
            this._scWeightsTabPage.Controls.Add(this._studentMaxDaysPerWeekWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label49);
            this._scWeightsTabPage.Controls.Add(this._studentMaxHoursDailyWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label48);
            this._scWeightsTabPage.Controls.Add(this._studentMaxHoursContWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label47);
            this._scWeightsTabPage.Controls.Add(this._teacherMaxDaysPerWeekWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label46);
            this._scWeightsTabPage.Controls.Add(this._teacherMaxHoursContWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label45);
            this._scWeightsTabPage.Controls.Add(this._teacherMaxHoursDailyWeightTextBox);
            this._scWeightsTabPage.Controls.Add(this.label44);
            resources.ApplyResources(this._scWeightsTabPage, "_scWeightsTabPage");
            this._scWeightsTabPage.Name = "_scWeightsTabPage";
            this._scWeightsTabPage.UseVisualStyleBackColor = true;
            // 
            // _courseLessonBlocksWeightTextBox
            // 
            resources.ApplyResources(this._courseLessonBlocksWeightTextBox, "_courseLessonBlocksWeightTextBox");
            this._courseLessonBlocksWeightTextBox.Name = "_courseLessonBlocksWeightTextBox";
            this._courseLessonBlocksWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label59
            // 
            resources.ApplyResources(this.label59, "label59");
            this.label59.Name = "label59";
            // 
            // _studentPreferredStartTimePeriodWeightTextBox
            // 
            resources.ApplyResources(this._studentPreferredStartTimePeriodWeightTextBox, "_studentPreferredStartTimePeriodWeightTextBox");
            this._studentPreferredStartTimePeriodWeightTextBox.Name = "_studentPreferredStartTimePeriodWeightTextBox";
            this._studentPreferredStartTimePeriodWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label58
            // 
            resources.ApplyResources(this.label58, "label58");
            this.label58.Name = "label58";
            // 
            // _studentNoGapsWeightTextBox
            // 
            resources.ApplyResources(this._studentNoGapsWeightTextBox, "_studentNoGapsWeightTextBox");
            this._studentNoGapsWeightTextBox.Name = "_studentNoGapsWeightTextBox";
            this._studentNoGapsWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label50
            // 
            resources.ApplyResources(this.label50, "label50");
            this.label50.Name = "label50";
            // 
            // _studentMaxDaysPerWeekWeightTextBox
            // 
            resources.ApplyResources(this._studentMaxDaysPerWeekWeightTextBox, "_studentMaxDaysPerWeekWeightTextBox");
            this._studentMaxDaysPerWeekWeightTextBox.Name = "_studentMaxDaysPerWeekWeightTextBox";
            this._studentMaxDaysPerWeekWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
            // 
            // _studentMaxHoursDailyWeightTextBox
            // 
            resources.ApplyResources(this._studentMaxHoursDailyWeightTextBox, "_studentMaxHoursDailyWeightTextBox");
            this._studentMaxHoursDailyWeightTextBox.Name = "_studentMaxHoursDailyWeightTextBox";
            this._studentMaxHoursDailyWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // _studentMaxHoursContWeightTextBox
            // 
            resources.ApplyResources(this._studentMaxHoursContWeightTextBox, "_studentMaxHoursContWeightTextBox");
            this._studentMaxHoursContWeightTextBox.Name = "_studentMaxHoursContWeightTextBox";
            this._studentMaxHoursContWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // _teacherMaxDaysPerWeekWeightTextBox
            // 
            resources.ApplyResources(this._teacherMaxDaysPerWeekWeightTextBox, "_teacherMaxDaysPerWeekWeightTextBox");
            this._teacherMaxDaysPerWeekWeightTextBox.Name = "_teacherMaxDaysPerWeekWeightTextBox";
            this._teacherMaxDaysPerWeekWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // _teacherMaxHoursContWeightTextBox
            // 
            resources.ApplyResources(this._teacherMaxHoursContWeightTextBox, "_teacherMaxHoursContWeightTextBox");
            this._teacherMaxHoursContWeightTextBox.Name = "_teacherMaxHoursContWeightTextBox";
            this._teacherMaxHoursContWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.Name = "label45";
            // 
            // _teacherMaxHoursDailyWeightTextBox
            // 
            resources.ApplyResources(this._teacherMaxHoursDailyWeightTextBox, "_teacherMaxHoursDailyWeightTextBox");
            this._teacherMaxHoursDailyWeightTextBox.Name = "_teacherMaxHoursDailyWeightTextBox";
            this._teacherMaxHoursDailyWeightTextBox.TextChanged += new System.EventHandler(this.scWeightsTextBox_TextChanged);
            // 
            // label44
            // 
            resources.ApplyResources(this.label44, "label44");
            this.label44.Name = "label44";
            // 
            // label51
            // 
            resources.ApplyResources(this.label51, "label51");
            this.label51.Name = "label51";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // label52
            // 
            resources.ApplyResources(this.label52, "label52");
            this.label52.Name = "label52";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // label53
            // 
            resources.ApplyResources(this.label53, "label53");
            this.label53.Name = "label53";
            // 
            // textBox4
            // 
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // label54
            // 
            resources.ApplyResources(this.label54, "label54");
            this.label54.Name = "label54";
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // label55
            // 
            resources.ApplyResources(this.label55, "label55");
            this.label55.Name = "label55";
            // 
            // textBox6
            // 
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            // 
            // label56
            // 
            resources.ApplyResources(this.label56, "label56");
            this.label56.Name = "label56";
            // 
            // textBox7
            // 
            resources.ApplyResources(this.textBox7, "textBox7");
            this.textBox7.Name = "textBox7";
            // 
            // label57
            // 
            resources.ApplyResources(this.label57, "label57");
            this.label57.Name = "label57";
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this._tabControl.ResumeLayout(false);
            this._generalSettTabPage.ResumeLayout(false);
            this._generalSettTabPage.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this._reportMain1TabPage.ResumeLayout(false);
            this._reportMain1TabPage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._reportMain2TabPage.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this._scWeightsTabPage.ResumeLayout(false);
            this._scWeightsTabPage.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void SettingsForm_Load(object sender, System.EventArgs e)
		{
            try
            {
                _eduInstNameTextBox.Text = Settings.EDU_INSTITUTION_NAME_SETT;
                _schoolYearTextBox.Text = Settings.SCHOOL_YEAR_SETT;
                _workDirTextBox.Text = Settings.WORKING_DIR_SETT;
                _defaultGUITextTypeComboBox.SelectedIndex = Settings.DEFAULT_GUI_TEXT_TYPE - 1;

                numericUpDown1.Value = System.Convert.ToInt32(Settings.TIME_SLOT_PANEL_WIDTH);
                numericUpDown2.Value = System.Convert.ToInt32(Settings.TIME_SLOT_PANEL_HEIGHT);
                numericUpDown3.Value = System.Convert.ToInt32(Settings.TIME_SLOT_PANEL_FONT_SIZE);

                _guiLanguageComboBox.SelectedValue = Settings.GUI_LANGUAGE;

                _pdfReaderTextBox.Text = Settings.PDF_READER_APPLICATION;

                _mtsXTextBox.Text = Settings.TTREP_MTS_X.ToString();
                _mtsYTextBox.Text = Settings.TTREP_MTS_Y.ToString();
                _mtrhTextBox.Text = Settings.TTREP_MTRH.ToString();
                _mtcwTextBox.Text = Settings.TTREP_MTCW.ToString();
                _htrhTextBox.Text = Settings.TTREP_HTRH.ToString();
                _tptcwTextBox.Text = Settings.TTREP_TPTCW.ToString();

                //Console.WriteLine(Settings.TTREP_PAPER_SIZE);                
                _paperSizeComboBox.SelectedItem = Settings.TTREP_PAPER_SIZE;
                _paperOrientationComboBox.SelectedItem = Settings.TTREP_PAPER_ORIENTATION;

                _courseFormatComboBox.SelectedIndex = Settings.TTREP_COURSE_FORMAT - 1;
                _printTeacherComboBox.SelectedIndex = Settings.TTREP_PRINT_TEACHER_IN_TS-1;

                char[] separator = new char[1];
                separator[0] = ',';
                string[] ss = Settings.TTREP_COLOR_HEADER.Split(separator, 3);
                _colorH_R_TextBox.Text = ss[0];
                _colorH_G_TextBox.Text = ss[1];
                _colorH_B_TextBox.Text = ss[2];

                string[] rr = Settings.TTREP_COLOR_TP.Split(separator, 3);
                _colorTP_R_TextBox.Text = rr[0];
                _colorTP_G_TextBox.Text = rr[1];
                _colorTP_B_TextBox.Text = rr[2];

                string[] ts = Settings.TTREP_COLOR_TS.Split(separator, 3);
                _colorTS_R_TextBox.Text = ts[0];
                _colorTS_G_TextBox.Text = ts[1];
                _colorTS_B_TextBox.Text = ts[2];

                string[] fpt = Settings.TTREP_FONT_PAGE_TITLE.Split(separator, 3);
                _pageTitleFontComboBox.SelectedItem = fpt[0];
                _pageTitleFontStyleComboBox.SelectedItem = fpt[1];
                int myi = System.Convert.ToInt32(fpt[2]);
                _pageTitleFontSizeComboBox.SelectedItem = myi;
                //
                string[] fdn = Settings.TTREP_FONT_DAY_NAMES.Split(separator, 3);
                _dayNamesFontComboBox.SelectedItem = fdn[0];
                _dayNamesFontStyleComboBox.SelectedItem = fdn[1];
                myi = System.Convert.ToInt32(fdn[2]);
                _dayNamesFontSizeComboBox.SelectedItem = myi;

                string[] ftp = Settings.TTREP_FONT_TIME_PERIODS.Split(separator, 3);
                _timePerFontComboBox.SelectedItem = ftp[0];
                _timePerFontStyleComboBox.SelectedItem = ftp[1];
                myi = System.Convert.ToInt32(ftp[2]);
                _timePerFontSizeComboBox.SelectedItem = myi;

                string[] fts = Settings.TTREP_FONT_TIME_SLOTS.Split(separator, 3);
                _timeSlotsFontComboBox.SelectedItem = fts[0];
                _timeSlotsFontStyleComboBox.SelectedItem = fts[1];
                myi = System.Convert.ToInt32(fts[2]);
                _timeSlotsFontSizeComboBox.SelectedItem = myi;

                string[] ffo = Settings.TTREP_FONT_FOOTER.Split(separator, 3);
                _footerFontComboBox.SelectedItem = ffo[0];
                _footerFontStyleComboBox.SelectedItem = ffo[1];
                myi = System.Convert.ToInt32(ffo[2]);
                _footerFontSizeComboBox.SelectedItem = myi;

                //
                _teacherMaxHoursContWeightTextBox.Text = Settings.SC_TEACHER_MAX_HOURS_CONTINUOUSLY_WEIGHT.ToString();
                _teacherMaxHoursDailyWeightTextBox.Text = Settings.SC_TEACHER_MAX_HOURS_DAILY_WEIGHT.ToString();
                _teacherMaxDaysPerWeekWeightTextBox.Text = Settings.SC_TEACHER_MAX_DAYS_PER_WEEK_WEIGHT.ToString();

                _studentMaxHoursContWeightTextBox.Text = Settings.SC_STUDENT_MAX_HOURS_CONTINUOUSLY_WEIGHT.ToString();
                _studentMaxHoursDailyWeightTextBox.Text = Settings.SC_STUDENT_MAX_HOURS_DAILY_WEIGHT.ToString();
                _studentMaxDaysPerWeekWeightTextBox.Text = Settings.SC_STUDENT_MAX_DAYS_PER_WEEK_WEIGHT.ToString();
                _studentNoGapsWeightTextBox.Text = Settings.SC_STUDENT_NO_GAPS_WEIGHT.ToString();
                _studentPreferredStartTimePeriodWeightTextBox.Text = Settings.SC_STUDENT_PREFERRED_START_TIME_PERIOD_WEIGHT.ToString();

                _courseLessonBlocksWeightTextBox.Text = Settings.SC_COURSE_LESSON_BLOCKS_WEIGHT.ToString();              


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
		}

		private void numericUpDown_Leave(object sender, System.EventArgs e)
		{
			if(numericUpDown1.Value>numericUpDown1.Maximum)
			{
				numericUpDown1.Value=numericUpDown1.Maximum;
			}
			else if(numericUpDown1.Value<numericUpDown1.Minimum)
			{
				numericUpDown1.Value=numericUpDown1.Minimum;
			}

			if(numericUpDown2.Value>numericUpDown2.Maximum)
			{
				numericUpDown2.Value=numericUpDown2.Maximum;
			}
			else if(numericUpDown2.Value<numericUpDown2.Minimum)
			{
				numericUpDown2.Value=numericUpDown2.Minimum;
			}

			if(numericUpDown3.Value>numericUpDown3.Maximum)
			{
				numericUpDown3.Value=numericUpDown3.Maximum;
			}
			else if(numericUpDown3.Value<numericUpDown3.Minimum)
			{
				numericUpDown3.Value=numericUpDown3.Minimum;
			}

		}

		private void _browseDirButton_Click(object sender, System.EventArgs e)
		{
			string folderName;
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.RootFolder = Environment.SpecialFolder.MyComputer;			

			DialogResult result = fbd.ShowDialog();
			if( result == DialogResult.OK )
			{
				folderName = fbd.SelectedPath;
				_workDirTextBox.Text=folderName;				
			}

		}

		private void _browsePdfViewerButton_Click(object sender, System.EventArgs e)
		{
			string fileName;
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter="Pdf reader"+" (*.exe)|*.exe";
			ofd.InitialDirectory = Settings.WORKING_DIR_SETT;

			DialogResult result = ofd.ShowDialog();
			if( result == DialogResult.OK )
			{
				fileName = ofd.FileName;
				_pdfReaderTextBox.Text=fileName;				
			}
		
		}

		

		


		public string EduInstitutionNameText
		{
			get
			{
				return _eduInstNameTextBox.Text.Trim();
			}

		}

		public string SchoolYearText
		{
			get
			{
				return _schoolYearTextBox.Text.Trim();
			}

		}

		public string WorkingDir
		{
			get
			{
				return _workDirTextBox.Text.Trim();
			}

		}

		public int TSPanelWidth
		{
			get
			{
				return (int)numericUpDown1.Value;
			}

		}

		public int TSPanelHeight
		{
			get
			{
				return (int)numericUpDown2.Value;
			}

		}

		public int TSPanelFontSize
		{
			get
			{
				return (int)numericUpDown3.Value;
			}
		}

		public int DefaultGUITextType
		{
			get
			{
				return _defaultGUITextTypeComboBox.SelectedIndex+1;
			}
		}

		public string GUILanguage
		{			
			get
			{				
				return _guiLanguageComboBox.SelectedValue.ToString();
			}
		}
		

		public string PdfReaderApplication
		{
			get
			{
				return _pdfReaderTextBox.Text.Trim();
			}

		}

        public int MtsX
        {
            get
            {
                return System.Convert.ToInt32(_mtsXTextBox.Text);
            }
        }

        public int MtsY
        {
            get
            {
                return System.Convert.ToInt32(_mtsYTextBox.Text);
            }
        }

        public int Mtrh
        {
            get
            {
                return System.Convert.ToInt32(_mtrhTextBox.Text);
            }
        }

        public int Mtcw
        {
            get
            {
                return System.Convert.ToInt32(_mtcwTextBox.Text);
            }
        }

        public int Htrh
        {
            get
            {
                return System.Convert.ToInt32(_htrhTextBox.Text);
            }
        }

        public int Tptcw
        {
            get
            {
                return System.Convert.ToInt32(_tptcwTextBox.Text);
            }
        }

        public string PaperSize
        {
            get
            {
                return _paperSizeComboBox.SelectedValue.ToString();
            }
        }

        public string PaperOrientation
        {
            get
            {
                return _paperOrientationComboBox.SelectedValue.ToString();
            }
        }

        public int CourseFormat
        {
            get
            {
                int n = _courseFormatComboBox.SelectedIndex + 1;
                return n;
            }
        }

        public int PrintTeacherInTS
        {
            get
            {
                int n = _printTeacherComboBox.SelectedIndex + 1;
                return n;
            }
        }

        public string ColorHeaderRGB
        {
            get
            {
                string s = _colorH_R_TextBox.Text.Trim() + "," + _colorH_G_TextBox.Text.Trim() + "," + _colorH_B_TextBox.Text.Trim();
                //Console.WriteLine(s);
                return s;
            }
        }

        public string ColorTimePeriodsRGB
        {
            get
            {
                string s = _colorTP_R_TextBox.Text.Trim() + "," + _colorTP_G_TextBox.Text.Trim() + "," + _colorTP_B_TextBox.Text.Trim();
                //Console.WriteLine(s);
                return s;
            }
        }

        public string ColorTimeSlotsRGB
        {
            get
            {
                string s = _colorTS_R_TextBox.Text.Trim() + "," + _colorTS_G_TextBox.Text.Trim() + "," + _colorTS_B_TextBox.Text.Trim();
                //Console.WriteLine(s);
                return s;
            }
        }


        public string FontPageTitle
        {
            get
            {
                string s = _pageTitleFontComboBox.SelectedValue.ToString() + "," + _pageTitleFontStyleComboBox.SelectedValue.ToString() + "," + _pageTitleFontSizeComboBox.SelectedValue.ToString();
                //Console.WriteLine(s);
                return s;
            }
        }

        public string FontDayNames
        {
            get
            {
                string s =  _dayNamesFontComboBox.SelectedValue.ToString() + "," + _dayNamesFontStyleComboBox.SelectedValue.ToString() + "," + _dayNamesFontSizeComboBox.SelectedValue.ToString();
                //Console.WriteLine(s);
                return s;
            }
        }

        public string FontTimePeriods
        {
            get
            {
                string s = _timePerFontComboBox.SelectedValue.ToString() + "," + _timePerFontStyleComboBox.SelectedValue.ToString() + "," + _timePerFontSizeComboBox.SelectedValue.ToString();
                //Console.WriteLine(s);
                return s;
            }
        }

        public string FontTimeSlots
        {
            get
            {
                string s = _timeSlotsFontComboBox.SelectedValue.ToString() + "," + _timeSlotsFontStyleComboBox.SelectedValue.ToString() + "," + _timeSlotsFontSizeComboBox.SelectedValue.ToString();
                //Console.WriteLine(s);
                return s;
            }
        }

        public string FontFooter
        {
            get
            {
                string s = _footerFontComboBox.SelectedValue.ToString() + "," + _footerFontStyleComboBox.SelectedValue.ToString() + "," + _footerFontSizeComboBox.SelectedValue.ToString();
                //Console.WriteLine(s);
                return s;
            }
        }

        public double TeacherMaxHoursContinuouslyWeight
        {
            get
            {
                double d = Double.Parse(_teacherMaxHoursContWeightTextBox.Text);
                return d;
            }
        }

        public double TeacherMaxHoursDailyWeight
        {
            get
            {
                double d = Double.Parse(_teacherMaxHoursDailyWeightTextBox.Text);
                return d;
            }
        }

        public double TeacherMaxDaysPerWeekWeight
        {
            get
            {
                double d = Double.Parse(_teacherMaxDaysPerWeekWeightTextBox.Text);
                return d;
            }
        }

        public double StudentMaxHoursContWeight
        {
            get
            {
                double d = Double.Parse(_studentMaxHoursContWeightTextBox.Text);
                return d;
            }
        }

        public double StudentMaxHoursDailyWeight
        {
            get
            {
                double d = Double.Parse(_studentMaxHoursDailyWeightTextBox.Text);
                return d;
            }
        }

        public double StudentMaxDaysPerWeekWeight
        {
            get
            {
                double d = Double.Parse(_studentMaxDaysPerWeekWeightTextBox.Text);
                return d;
            }
        }

        public double StudentNoGapsWeight
        {
            get
            {
                double d = Double.Parse(_studentNoGapsWeightTextBox.Text);
                return d;
            }
        }

        public double StudentPreferredStartTimePeriodWeight
        {
            get
            {
                double d = Double.Parse(_studentPreferredStartTimePeriodWeightTextBox.Text);
                return d;
            }
        }

        public double CourseLessonBlocksWeight
        {
            get
            {
                double d = Double.Parse(_courseLessonBlocksWeightTextBox.Text);
                return d;
            }
        }





        private void numericTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isTTReportFormValuesOK())
            {
                _okButton.Enabled = true;

            }else{

                _okButton.Enabled = false;
            }
        }
        

        private bool isTTReportFormValuesOK()
        {
            try
            {
                int x1 = Int32.Parse(_mtsXTextBox.Text);
                int x2 = Int32.Parse(_mtsYTextBox.Text);
                int x3 = Int32.Parse(_mtrhTextBox.Text);
                int x4 = Int32.Parse(_mtcwTextBox.Text);
                int x5 = Int32.Parse(_htrhTextBox.Text);
                int x6 = Int32.Parse(_tptcwTextBox.Text);

                if (x1 >= 1 && x2 >= 1 && x3 >= 1 && x4 >= 1 && x5 >= 1 && x6 >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }

            return true;
        }

        private void RGB_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (isRGBOK())
            {
                _okButton.Enabled = true;

            }
            else
            {

                _okButton.Enabled = false;
            }

        }

        private bool isRGBOK()
        {
            try
            {
                int x1 = Int32.Parse(_colorH_R_TextBox.Text);
                int x2 = Int32.Parse(_colorH_G_TextBox.Text);
                int x3 = Int32.Parse(_colorH_B_TextBox.Text);
                int x4 = Int32.Parse(_colorTP_R_TextBox.Text);
                int x5 = Int32.Parse(_colorTP_G_TextBox.Text);
                int x6 = Int32.Parse(_colorTP_B_TextBox.Text);
                int x7 = Int32.Parse(_colorTS_R_TextBox.Text);
                int x8 = Int32.Parse(_colorTS_G_TextBox.Text);
                int x9 = Int32.Parse(_colorTS_B_TextBox.Text);

                if (x1 < 0)
                {
                    _colorH_R_TextBox.Text = "0";
                }
                else if (x1 > 255)
                {
                    _colorH_R_TextBox.Text = "255";
                }

                if (x2 < 0)
                {
                    _colorH_G_TextBox.Text = "0";
                }
                else if (x2 > 255)
                {
                    _colorH_G_TextBox.Text = "255";
                }

                if (x3 < 0)
                {
                    _colorH_B_TextBox.Text = "0";
                }
                else if (x3 > 255)
                {
                    _colorH_B_TextBox.Text = "255";
                }

                if (x4 < 0)
                {
                    _colorTP_R_TextBox.Text = "0";
                }
                else if (x4 > 255)
                {
                    _colorTP_R_TextBox.Text = "255";
                }

                if (x5 < 0)
                {
                    _colorTP_G_TextBox.Text = "0";
                }
                else if (x5 > 255)
                {
                    _colorTP_G_TextBox.Text = "255";
                }

                if (x6 < 0)
                {
                    _colorTP_B_TextBox.Text = "0";
                }
                else if (x6 > 255)
                {
                    _colorTP_B_TextBox.Text = "255";
                }

                //
                if (x7 < 0)
                {
                    _colorTS_R_TextBox.Text = "0";
                }
                else if (x7 > 255)
                {
                    _colorTS_R_TextBox.Text = "255";
                }

                if (x8 < 0)
                {
                    _colorTS_G_TextBox.Text = "0";
                }
                else if (x8 > 255)
                {
                    _colorTS_G_TextBox.Text = "255";
                }

                if (x9 < 0)
                {
                    _colorTS_B_TextBox.Text = "0";
                }
                else if (x9 > 255)
                {
                    _colorTS_B_TextBox.Text = "255";
                }
                
            }
            catch
            {

                return false;
            }

            return true;
        }


        private void scWeightsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isWeightFormValuesOK())
            {
                _okButton.Enabled = true;

            }
            else
            {

                _okButton.Enabled = false;
            }
        }

        private bool isWeightFormValuesOK()
        {
            try
            {
                double x1 = Double.Parse(_teacherMaxHoursContWeightTextBox.Text);
                double x2 = Double.Parse(_teacherMaxHoursDailyWeightTextBox.Text);
                double x3 = Double.Parse(_teacherMaxDaysPerWeekWeightTextBox.Text);
                double x4 = Double.Parse(_studentMaxHoursContWeightTextBox.Text);
                double x5 = Double.Parse(_studentMaxHoursDailyWeightTextBox.Text);
                double x6 = Double.Parse(_studentMaxDaysPerWeekWeightTextBox.Text);
                double x7 = Double.Parse(_studentNoGapsWeightTextBox.Text);
                double x8 = Double.Parse(_studentPreferredStartTimePeriodWeightTextBox.Text);
                double x9 = Double.Parse(_courseLessonBlocksWeightTextBox.Text);                

                if (x1 <= 0)
                {
                    _teacherMaxHoursContWeightTextBox.Text = (0.1).ToString();
                }                

                if (x2 <= 0)
                {
                    _teacherMaxHoursDailyWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x3 <= 0)
                {
                    _teacherMaxDaysPerWeekWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x4 <= 0)
                {
                    _studentMaxHoursContWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x5 <= 0)
                {
                    _studentMaxHoursDailyWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x6 <= 0)
                {
                    _studentMaxDaysPerWeekWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x7 <= 0)
                {
                    _studentNoGapsWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x8 <= 0)
                {
                    _studentPreferredStartTimePeriodWeightTextBox.Text = (0.1).ToString();
                }
                

                if (x9 <= 0)
                {
                    _courseLessonBlocksWeightTextBox.Text = (0.1).ToString();
                }

            }
            catch
            {

                return false;
            }

            return true;
        }

        
	}


	internal class OCTTGuiLanguage
	{
		private string _shortLang;
		private string _longLang;

		public OCTTGuiLanguage(string shortLang, string longLang)
		{
			_shortLang= shortLang;
			_longLang=longLang;
		}
        
		public string ShortLang
		{
			get
			{
				return _shortLang;
			}
		}

		public string LongLang
		{
			get
			{
				return _longLang;
			}
		}
	}
	
}
