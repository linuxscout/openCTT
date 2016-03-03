namespace OpenCTT
{
    partial class AutomatedTTForm
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
            this._startButton = new System.Windows.Forms.Button();
            this._stopButton = new System.Windows.Forms.Button();
            this._fromCurrentStateRadioButton = new System.Windows.Forms.RadioButton();
            this._fromStartRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this._bestSolutionValueLabel = new System.Windows.Forms.Label();
            this._acceptBestSolutionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._numOfFoundSolutionsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _startButton
            // 
            this._startButton.BackColor = System.Drawing.Color.SpringGreen;
            this._startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._startButton.Location = new System.Drawing.Point(336, 99);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(95, 68);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = false;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _stopButton
            // 
            this._stopButton.BackColor = System.Drawing.Color.OrangeRed;
            this._stopButton.Enabled = false;
            this._stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._stopButton.Location = new System.Drawing.Point(50, 99);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(93, 68);
            this._stopButton.TabIndex = 1;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = false;
            this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
            // 
            // _fromCurrentStateRadioButton
            // 
            this._fromCurrentStateRadioButton.AutoSize = true;
            this._fromCurrentStateRadioButton.Location = new System.Drawing.Point(50, 31);
            this._fromCurrentStateRadioButton.Name = "_fromCurrentStateRadioButton";
            this._fromCurrentStateRadioButton.Size = new System.Drawing.Size(282, 17);
            this._fromCurrentStateRadioButton.TabIndex = 2;
            this._fromCurrentStateRadioButton.Text = "Start automated timetabling from current partial solution";
            this._fromCurrentStateRadioButton.UseVisualStyleBackColor = true;
            // 
            // _fromStartRadioButton
            // 
            this._fromStartRadioButton.AutoSize = true;
            this._fromStartRadioButton.Checked = true;
            this._fromStartRadioButton.Location = new System.Drawing.Point(50, 54);
            this._fromStartRadioButton.Name = "_fromStartRadioButton";
            this._fromStartRadioButton.Size = new System.Drawing.Size(246, 17);
            this._fromStartRadioButton.TabIndex = 3;
            this._fromStartRadioButton.TabStop = true;
            this._fromStartRadioButton.Text = "Start automated timetabling from empty solution";
            this._fromStartRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(55, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Value of the best solution:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _bestSolutionValueLabel
            // 
            this._bestSolutionValueLabel.AutoSize = true;
            this._bestSolutionValueLabel.Enabled = false;
            this._bestSolutionValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._bestSolutionValueLabel.Location = new System.Drawing.Point(276, 235);
            this._bestSolutionValueLabel.Name = "_bestSolutionValueLabel";
            this._bestSolutionValueLabel.Size = new System.Drawing.Size(19, 20);
            this._bestSolutionValueLabel.TabIndex = 5;
            this._bestSolutionValueLabel.Text = "0";
            this._bestSolutionValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _acceptBestSolutionButton
            // 
            this._acceptBestSolutionButton.Enabled = false;
            this._acceptBestSolutionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._acceptBestSolutionButton.Location = new System.Drawing.Point(50, 278);
            this._acceptBestSolutionButton.Name = "_acceptBestSolutionButton";
            this._acceptBestSolutionButton.Size = new System.Drawing.Size(381, 40);
            this._acceptBestSolutionButton.TabIndex = 6;
            this._acceptBestSolutionButton.Text = "Accept the best obtained solution";
            this._acceptBestSolutionButton.UseVisualStyleBackColor = true;
            this._acceptBestSolutionButton.Click += new System.EventHandler(this._acceptSolutionButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(55, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Number of solutions found:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _numOfFoundSolutionsLabel
            // 
            this._numOfFoundSolutionsLabel.AutoSize = true;
            this._numOfFoundSolutionsLabel.Enabled = false;
            this._numOfFoundSolutionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this._numOfFoundSolutionsLabel.Location = new System.Drawing.Point(295, 199);
            this._numOfFoundSolutionsLabel.Name = "_numOfFoundSolutionsLabel";
            this._numOfFoundSolutionsLabel.Size = new System.Drawing.Size(19, 20);
            this._numOfFoundSolutionsLabel.TabIndex = 11;
            this._numOfFoundSolutionsLabel.Text = "0";
            this._numOfFoundSolutionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AutomatedTTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 347);
            this.Controls.Add(this._numOfFoundSolutionsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._acceptBestSolutionButton);
            this.Controls.Add(this._bestSolutionValueLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._fromStartRadioButton);
            this.Controls.Add(this._fromCurrentStateRadioButton);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this._startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutomatedTTForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automated Timetabling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.RadioButton _fromCurrentStateRadioButton;
        private System.Windows.Forms.RadioButton _fromStartRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _bestSolutionValueLabel;
        private System.Windows.Forms.Button _acceptBestSolutionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _numOfFoundSolutionsLabel;
    }
}