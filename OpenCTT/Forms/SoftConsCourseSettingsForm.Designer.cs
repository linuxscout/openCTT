namespace OpenCTT
{
    partial class SoftConsCourseSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoftConsCourseSettingsForm));
            this._d2TextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this._d1TextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this._d3TextBox = new System.Windows.Forms.TextBox();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._obsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _d2TextBox
            // 
            resources.ApplyResources(this._d2TextBox, "_d2TextBox");
            this._d2TextBox.Name = "_d2TextBox";
            this._d2TextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // _d1TextBox
            // 
            resources.ApplyResources(this._d1TextBox, "_d1TextBox");
            this._d1TextBox.Name = "_d1TextBox";
            this._d1TextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // _d3TextBox
            // 
            resources.ApplyResources(this._d3TextBox, "_d3TextBox");
            this._d3TextBox.Name = "_d3TextBox";
            this._d3TextBox.TextChanged += new System.EventHandler(this.allTextBoxs_TextChanged);
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
            // _obsCheckBox
            // 
            resources.ApplyResources(this._obsCheckBox, "_obsCheckBox");
            this._obsCheckBox.Name = "_obsCheckBox";
            this._obsCheckBox.CheckedChanged += new System.EventHandler(this._obsCheckBox_CheckedChanged);
            // 
            // SoftConsCourseSettingsForm
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._obsCheckBox);
            this.Controls.Add(this._d2TextBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this._d1TextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this.label23);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.label24);
            this.Controls.Add(this._d3TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SoftConsCourseSettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SoftConsCourseSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _d2TextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox _d1TextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox _d3TextBox;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.CheckBox _obsCheckBox;
    }
}