namespace OpenCTT
{
    partial class SoftConsTeachersBaseSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftConsTeachersBaseSettingsForm));
            this._maxHContinuouslyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._maxHDailyTextBox = new System.Windows.Forms.TextBox();
            this._maxDaysPerWeekTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _maxHContinuouslyTextBox
            // 
            resources.ApplyResources(this._maxHContinuouslyTextBox, "_maxHContinuouslyTextBox");
            this._maxHContinuouslyTextBox.Name = "_maxHContinuouslyTextBox";
            this._maxHContinuouslyTextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // _maxHDailyTextBox
            // 
            resources.ApplyResources(this._maxHDailyTextBox, "_maxHDailyTextBox");
            this._maxHDailyTextBox.Name = "_maxHDailyTextBox";
            this._maxHDailyTextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // _maxDaysPerWeekTextBox
            // 
            resources.ApplyResources(this._maxDaysPerWeekTextBox, "_maxDaysPerWeekTextBox");
            this._maxDaysPerWeekTextBox.Name = "_maxDaysPerWeekTextBox";
            this._maxDaysPerWeekTextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // _okButton
            // 
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this._okButton, "_okButton");
            this._okButton.Name = "_okButton";
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this._cancelButton, "_cancelButton");
            this._cancelButton.Name = "_cancelButton";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // SoftConsTeachersBaseSettingsForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._maxDaysPerWeekTextBox);
            this.Controls.Add(this._maxHDailyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._maxHContinuouslyTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SoftConsTeachersBaseSettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SoftConsTeachersSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _maxHContinuouslyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _maxHDailyTextBox;
        private System.Windows.Forms.TextBox _maxDaysPerWeekTextBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}