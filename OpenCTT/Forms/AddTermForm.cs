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
	/// Summary description for AddTermForm.
	/// </summary>
	public class AddTermForm : System.Windows.Forms.Form
	{
		private static ResourceManager RES_MANAGER;
		private bool _isNew;
		private int[] _termData;
		private int _myPosInList;

		private System.Windows.Forms.NumericUpDown _fromHUpDown;
		private System.Windows.Forms.NumericUpDown _fromMUpDown;
		private System.Windows.Forms.NumericUpDown _toMUpDown;
		private System.Windows.Forms.NumericUpDown _toHUpDown;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AddTermForm(bool isNew, int[] tData)
		{		
			InitializeComponent();

			if(RES_MANAGER==null)
			{
				RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.AddTermForm",this.GetType().Assembly);
			}

			_isNew=isNew;
			_termData=tData;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AddTermForm));
			this._fromHUpDown = new System.Windows.Forms.NumericUpDown();
			this._fromMUpDown = new System.Windows.Forms.NumericUpDown();
			this._toMUpDown = new System.Windows.Forms.NumericUpDown();
			this._toHUpDown = new System.Windows.Forms.NumericUpDown();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this._fromHUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._fromMUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._toMUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._toHUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// _fromHUpDown
			// 
			this._fromHUpDown.AccessibleDescription = resources.GetString("_fromHUpDown.AccessibleDescription");
			this._fromHUpDown.AccessibleName = resources.GetString("_fromHUpDown.AccessibleName");
			this._fromHUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_fromHUpDown.Anchor")));
			this._fromHUpDown.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_fromHUpDown.Dock")));
			this._fromHUpDown.Enabled = ((bool)(resources.GetObject("_fromHUpDown.Enabled")));
			this._fromHUpDown.Font = ((System.Drawing.Font)(resources.GetObject("_fromHUpDown.Font")));
			this._fromHUpDown.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_fromHUpDown.ImeMode")));
			this._fromHUpDown.Location = ((System.Drawing.Point)(resources.GetObject("_fromHUpDown.Location")));
			this._fromHUpDown.Maximum = new System.Decimal(new int[] {
																		 23,
																		 0,
																		 0,
																		 0});
			this._fromHUpDown.Name = "_fromHUpDown";
			this._fromHUpDown.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_fromHUpDown.RightToLeft")));
			this._fromHUpDown.Size = ((System.Drawing.Size)(resources.GetObject("_fromHUpDown.Size")));
			this._fromHUpDown.TabIndex = ((int)(resources.GetObject("_fromHUpDown.TabIndex")));
			this._fromHUpDown.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_fromHUpDown.TextAlign")));
			this._fromHUpDown.ThousandsSeparator = ((bool)(resources.GetObject("_fromHUpDown.ThousandsSeparator")));
			this._fromHUpDown.UpDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("_fromHUpDown.UpDownAlign")));
			this._fromHUpDown.Visible = ((bool)(resources.GetObject("_fromHUpDown.Visible")));
			this._fromHUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
			// 
			// _fromMUpDown
			// 
			this._fromMUpDown.AccessibleDescription = resources.GetString("_fromMUpDown.AccessibleDescription");
			this._fromMUpDown.AccessibleName = resources.GetString("_fromMUpDown.AccessibleName");
			this._fromMUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_fromMUpDown.Anchor")));
			this._fromMUpDown.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_fromMUpDown.Dock")));
			this._fromMUpDown.Enabled = ((bool)(resources.GetObject("_fromMUpDown.Enabled")));
			this._fromMUpDown.Font = ((System.Drawing.Font)(resources.GetObject("_fromMUpDown.Font")));
			this._fromMUpDown.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_fromMUpDown.ImeMode")));
			this._fromMUpDown.Location = ((System.Drawing.Point)(resources.GetObject("_fromMUpDown.Location")));
			this._fromMUpDown.Maximum = new System.Decimal(new int[] {
																		 59,
																		 0,
																		 0,
																		 0});
			this._fromMUpDown.Name = "_fromMUpDown";
			this._fromMUpDown.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_fromMUpDown.RightToLeft")));
			this._fromMUpDown.Size = ((System.Drawing.Size)(resources.GetObject("_fromMUpDown.Size")));
			this._fromMUpDown.TabIndex = ((int)(resources.GetObject("_fromMUpDown.TabIndex")));
			this._fromMUpDown.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_fromMUpDown.TextAlign")));
			this._fromMUpDown.ThousandsSeparator = ((bool)(resources.GetObject("_fromMUpDown.ThousandsSeparator")));
			this._fromMUpDown.UpDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("_fromMUpDown.UpDownAlign")));
			this._fromMUpDown.Visible = ((bool)(resources.GetObject("_fromMUpDown.Visible")));
			this._fromMUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
			// 
			// _toMUpDown
			// 
			this._toMUpDown.AccessibleDescription = resources.GetString("_toMUpDown.AccessibleDescription");
			this._toMUpDown.AccessibleName = resources.GetString("_toMUpDown.AccessibleName");
			this._toMUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_toMUpDown.Anchor")));
			this._toMUpDown.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_toMUpDown.Dock")));
			this._toMUpDown.Enabled = ((bool)(resources.GetObject("_toMUpDown.Enabled")));
			this._toMUpDown.Font = ((System.Drawing.Font)(resources.GetObject("_toMUpDown.Font")));
			this._toMUpDown.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_toMUpDown.ImeMode")));
			this._toMUpDown.Location = ((System.Drawing.Point)(resources.GetObject("_toMUpDown.Location")));
			this._toMUpDown.Maximum = new System.Decimal(new int[] {
																	   59,
																	   0,
																	   0,
																	   0});
			this._toMUpDown.Name = "_toMUpDown";
			this._toMUpDown.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_toMUpDown.RightToLeft")));
			this._toMUpDown.Size = ((System.Drawing.Size)(resources.GetObject("_toMUpDown.Size")));
			this._toMUpDown.TabIndex = ((int)(resources.GetObject("_toMUpDown.TabIndex")));
			this._toMUpDown.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_toMUpDown.TextAlign")));
			this._toMUpDown.ThousandsSeparator = ((bool)(resources.GetObject("_toMUpDown.ThousandsSeparator")));
			this._toMUpDown.UpDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("_toMUpDown.UpDownAlign")));
			this._toMUpDown.Visible = ((bool)(resources.GetObject("_toMUpDown.Visible")));
			this._toMUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
			// 
			// _toHUpDown
			// 
			this._toHUpDown.AccessibleDescription = resources.GetString("_toHUpDown.AccessibleDescription");
			this._toHUpDown.AccessibleName = resources.GetString("_toHUpDown.AccessibleName");
			this._toHUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_toHUpDown.Anchor")));
			this._toHUpDown.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_toHUpDown.Dock")));
			this._toHUpDown.Enabled = ((bool)(resources.GetObject("_toHUpDown.Enabled")));
			this._toHUpDown.Font = ((System.Drawing.Font)(resources.GetObject("_toHUpDown.Font")));
			this._toHUpDown.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_toHUpDown.ImeMode")));
			this._toHUpDown.Location = ((System.Drawing.Point)(resources.GetObject("_toHUpDown.Location")));
			this._toHUpDown.Maximum = new System.Decimal(new int[] {
																	   23,
																	   0,
																	   0,
																	   0});
			this._toHUpDown.Name = "_toHUpDown";
			this._toHUpDown.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_toHUpDown.RightToLeft")));
			this._toHUpDown.Size = ((System.Drawing.Size)(resources.GetObject("_toHUpDown.Size")));
			this._toHUpDown.TabIndex = ((int)(resources.GetObject("_toHUpDown.TabIndex")));
			this._toHUpDown.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("_toHUpDown.TextAlign")));
			this._toHUpDown.ThousandsSeparator = ((bool)(resources.GetObject("_toHUpDown.ThousandsSeparator")));
			this._toHUpDown.UpDownAlign = ((System.Windows.Forms.LeftRightAlignment)(resources.GetObject("_toHUpDown.UpDownAlign")));
			this._toHUpDown.Visible = ((bool)(resources.GetObject("_toHUpDown.Visible")));
			this._toHUpDown.Leave += new System.EventHandler(this.UpDown_Leave);
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
			// label3
			// 
			this.label3.AccessibleDescription = resources.GetString("label3.AccessibleDescription");
			this.label3.AccessibleName = resources.GetString("label3.AccessibleName");
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label3.Anchor")));
			this.label3.AutoSize = ((bool)(resources.GetObject("label3.AutoSize")));
			this.label3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label3.Dock")));
			this.label3.Enabled = ((bool)(resources.GetObject("label3.Enabled")));
			this.label3.Font = ((System.Drawing.Font)(resources.GetObject("label3.Font")));
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.ImageAlign")));
			this.label3.ImageIndex = ((int)(resources.GetObject("label3.ImageIndex")));
			this.label3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label3.ImeMode")));
			this.label3.Location = ((System.Drawing.Point)(resources.GetObject("label3.Location")));
			this.label3.Name = "label3";
			this.label3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label3.RightToLeft")));
			this.label3.Size = ((System.Drawing.Size)(resources.GetObject("label3.Size")));
			this.label3.TabIndex = ((int)(resources.GetObject("label3.TabIndex")));
			this.label3.Text = resources.GetString("label3.Text");
			this.label3.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label3.TextAlign")));
			this.label3.Visible = ((bool)(resources.GetObject("label3.Visible")));
			// 
			// label4
			// 
			this.label4.AccessibleDescription = resources.GetString("label4.AccessibleDescription");
			this.label4.AccessibleName = resources.GetString("label4.AccessibleName");
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label4.Anchor")));
			this.label4.AutoSize = ((bool)(resources.GetObject("label4.AutoSize")));
			this.label4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label4.Dock")));
			this.label4.Enabled = ((bool)(resources.GetObject("label4.Enabled")));
			this.label4.Font = ((System.Drawing.Font)(resources.GetObject("label4.Font")));
			this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
			this.label4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.ImageAlign")));
			this.label4.ImageIndex = ((int)(resources.GetObject("label4.ImageIndex")));
			this.label4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label4.ImeMode")));
			this.label4.Location = ((System.Drawing.Point)(resources.GetObject("label4.Location")));
			this.label4.Name = "label4";
			this.label4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label4.RightToLeft")));
			this.label4.Size = ((System.Drawing.Size)(resources.GetObject("label4.Size")));
			this.label4.TabIndex = ((int)(resources.GetObject("label4.TabIndex")));
			this.label4.Text = resources.GetString("label4.Text");
			this.label4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label4.TextAlign")));
			this.label4.Visible = ((bool)(resources.GetObject("label4.Visible")));
			// 
			// label5
			// 
			this.label5.AccessibleDescription = resources.GetString("label5.AccessibleDescription");
			this.label5.AccessibleName = resources.GetString("label5.AccessibleName");
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label5.Anchor")));
			this.label5.AutoSize = ((bool)(resources.GetObject("label5.AutoSize")));
			this.label5.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label5.Dock")));
			this.label5.Enabled = ((bool)(resources.GetObject("label5.Enabled")));
			this.label5.Font = ((System.Drawing.Font)(resources.GetObject("label5.Font")));
			this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
			this.label5.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.ImageAlign")));
			this.label5.ImageIndex = ((int)(resources.GetObject("label5.ImageIndex")));
			this.label5.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label5.ImeMode")));
			this.label5.Location = ((System.Drawing.Point)(resources.GetObject("label5.Location")));
			this.label5.Name = "label5";
			this.label5.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label5.RightToLeft")));
			this.label5.Size = ((System.Drawing.Size)(resources.GetObject("label5.Size")));
			this.label5.TabIndex = ((int)(resources.GetObject("label5.TabIndex")));
			this.label5.Text = resources.GetString("label5.Text");
			this.label5.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label5.TextAlign")));
			this.label5.Visible = ((bool)(resources.GetObject("label5.Visible")));
			// 
			// label6
			// 
			this.label6.AccessibleDescription = resources.GetString("label6.AccessibleDescription");
			this.label6.AccessibleName = resources.GetString("label6.AccessibleName");
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label6.Anchor")));
			this.label6.AutoSize = ((bool)(resources.GetObject("label6.AutoSize")));
			this.label6.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label6.Dock")));
			this.label6.Enabled = ((bool)(resources.GetObject("label6.Enabled")));
			this.label6.Font = ((System.Drawing.Font)(resources.GetObject("label6.Font")));
			this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
			this.label6.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.ImageAlign")));
			this.label6.ImageIndex = ((int)(resources.GetObject("label6.ImageIndex")));
			this.label6.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label6.ImeMode")));
			this.label6.Location = ((System.Drawing.Point)(resources.GetObject("label6.Location")));
			this.label6.Name = "label6";
			this.label6.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label6.RightToLeft")));
			this.label6.Size = ((System.Drawing.Size)(resources.GetObject("label6.Size")));
			this.label6.TabIndex = ((int)(resources.GetObject("label6.TabIndex")));
			this.label6.Text = resources.GetString("label6.Text");
			this.label6.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label6.TextAlign")));
			this.label6.Visible = ((bool)(resources.GetObject("label6.Visible")));
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this._fromMUpDown);
			this.groupBox1.Controls.Add(this._fromHUpDown);
			this.groupBox1.Controls.Add(this.label6);
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
			// groupBox2
			// 
			this.groupBox2.AccessibleDescription = resources.GetString("groupBox2.AccessibleDescription");
			this.groupBox2.AccessibleName = resources.GetString("groupBox2.AccessibleName");
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox2.Anchor")));
			this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this._toMUpDown);
			this.groupBox2.Controls.Add(this._toHUpDown);
			this.groupBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox2.Dock")));
			this.groupBox2.Enabled = ((bool)(resources.GetObject("groupBox2.Enabled")));
			this.groupBox2.Font = ((System.Drawing.Font)(resources.GetObject("groupBox2.Font")));
			this.groupBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox2.ImeMode")));
			this.groupBox2.Location = ((System.Drawing.Point)(resources.GetObject("groupBox2.Location")));
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox2.RightToLeft")));
			this.groupBox2.Size = ((System.Drawing.Size)(resources.GetObject("groupBox2.Size")));
			this.groupBox2.TabIndex = ((int)(resources.GetObject("groupBox2.TabIndex")));
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = resources.GetString("groupBox2.Text");
			this.groupBox2.Visible = ((bool)(resources.GetObject("groupBox2.Visible")));
			// 
			// AddTermForm
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
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this._cancelButton);
			this.Controls.Add(this._okButton);
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
			this.Name = "AddTermForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closing += new System.ComponentModel.CancelEventHandler(this.TermPropertiesForm_Closing);
			this.Load += new System.EventHandler(this.TermPropertiesForm_Load);
			((System.ComponentModel.ISupportInitialize)(this._fromHUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._fromMUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._toMUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._toHUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		

		private void TermPropertiesForm_Load(object sender, System.EventArgs e)
		{
			if(!_isNew)
			{
				_fromHUpDown.Value=_termData[0];
				_fromMUpDown.Value=_termData[1];
				_toHUpDown.Value=_termData[2];
				_toMUpDown.Value=_termData[3];
			}			
		}

		public int[] getNewTermData()
		{
			int[] newTermData= new int[4]{System.Convert.ToInt16(_fromHUpDown.Value),System.Convert.ToInt16(_fromMUpDown.Value),System.Convert.ToInt16(_toHUpDown.Value),System.Convert.ToInt16(_toMUpDown.Value)};
			return newTermData;
		}

		private void TermPropertiesForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.OK)
			{
				if(_isNew)
				{
					if(!checkIfTermIsCorrect())
					{
						e.Cancel=true;
						
						string message1 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.inputerror.message");
					
						string caption1 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.inputerror.caption");

						MessageBoxButtons buttons1 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message1, caption1, buttons1,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else if(!checkIfTermIsOKRelOtherTerms())
					{
						e.Cancel=true;
						
						string message2 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.overlapping.message");

						string caption2 = RES_MANAGER.GetString("TermPropertiesForm_Closing.msb.overlapping.caption");

						MessageBoxButtons buttons2 = MessageBoxButtons.OK;					
		
						MessageBox.Show(this, message2, caption2, buttons2,
							MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
					}
					else 
					{
						_myPosInList=calculatePosInList();	
					}
				}
			}			
		}

		private bool checkIfTermIsCorrect()
		{
			if(_toHUpDown.Value<_fromHUpDown.Value)
			{
				return false;
			}
			else if(_toHUpDown.Value==_fromHUpDown.Value)
			{
				if(_toMUpDown.Value>_fromMUpDown.Value)
				{
					return true;
				}else return false;
			}else return true;
		}

		private bool checkIfTermIsOKRelOtherTerms()
		{
			if(checkIfTimeIsInsideExistingTerm(System.Convert.ToInt16(_fromHUpDown.Value), System.Convert.ToInt16(_fromMUpDown.Value))) return false;
			if(checkIfTimeIsInsideExistingTerm(System.Convert.ToInt16(_toHUpDown.Value), System.Convert.ToInt16(_toMUpDown.Value))) return false;
			if(checkIfStartInInterspaceAndEndNotBeforeNextTerm()) return false;

			return true;
		}

		private bool checkIfTimeIsInsideExistingTerm(int hour, int min)
		{
			foreach(int[] oneTerm in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				if(checkOneTime(hour, min, oneTerm)) return true;
			}

			return false;
		}

		private bool checkOneTime(int hour, int min, int[] oneTerm)
		{
			if(hour>oneTerm[0] || (hour==oneTerm[0]&&min>oneTerm[1]))
			{
				if(hour<oneTerm[2] || (hour==oneTerm[2] && min<oneTerm[3]))
				{
					return true;
				}
			}
			return false;
		}
		

		private bool checkIfStartInInterspaceAndEndNotBeforeNextTerm()
		{
			int [] possTerm = new int[4]{System.Convert.ToInt16(_fromHUpDown.Value),System.Convert.ToInt16(_fromMUpDown.Value),System.Convert.ToInt16(_toHUpDown.Value),System.Convert.ToInt16(_toMUpDown.Value)};
			foreach(int[] oneTerm in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				int hour=oneTerm[0];
				int min=oneTerm[1];
				if(checkOneTime(hour, min,possTerm)) return true;

				hour=oneTerm[2];
				min=oneTerm[3];
				if(checkOneTime(hour, min,possTerm)) return true;				
			}

			return false;
		}

		private int calculatePosInList()
		{
			int startH=System.Convert.ToInt16(_fromHUpDown.Value);
			int startM=System.Convert.ToInt16(_fromMUpDown.Value);
            
			int counter=0;
			foreach(int[] oneTerm in AppForm.CURR_OCTT_DOC.IncludedTerms)
			{
				if(oneTerm[0]>startH || (oneTerm[0]==startH && oneTerm[1]>=startM)) return counter;
				counter++;
			}
            
			return counter;
		}

		public int getPosOfNewTerm()
		{
			return _myPosInList;
		}

		private void UpDown_Leave(object sender, System.EventArgs e)
		{
			NumericUpDown ud = (NumericUpDown)sender;
			if(ud.Value>ud.Maximum) ud.Value=ud.Maximum;
		
		}

	}
}
