namespace SupportAlerter.Forms
{
    partial class RuleConfiguration
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContains = new System.Windows.Forms.TextBox();
            this.chkSmsAlert = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkVoiceCall = new System.Windows.Forms.CheckBox();
            this.btnSaveTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Rule name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 56);
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 38);
            this.label2.TabIndex = 17;
            this.label2.Text = "Message contains\r\n(Comma separated)";
            // 
            // txtContains
            // 
            this.txtContains.Location = new System.Drawing.Point(130, 79);
            this.txtContains.Multiline = true;
            this.txtContains.Name = "txtContains";
            this.txtContains.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtContains.Size = new System.Drawing.Size(178, 117);
            this.txtContains.TabIndex = 1;
            // 
            // chkSmsAlert
            // 
            this.chkSmsAlert.AutoSize = true;
            this.chkSmsAlert.Location = new System.Drawing.Point(130, 202);
            this.chkSmsAlert.Name = "chkSmsAlert";
            this.chkSmsAlert.Size = new System.Drawing.Size(100, 17);
            this.chkSmsAlert.TabIndex = 2;
            this.chkSmsAlert.Text = "Send SMS alert";
            this.chkSmsAlert.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Notifications";
            // 
            // chkVoiceCall
            // 
            this.chkVoiceCall.AutoSize = true;
            this.chkVoiceCall.Location = new System.Drawing.Point(236, 202);
            this.chkVoiceCall.Name = "chkVoiceCall";
            this.chkVoiceCall.Size = new System.Drawing.Size(72, 17);
            this.chkVoiceCall.TabIndex = 3;
            this.chkVoiceCall.Text = "Voice call";
            this.chkVoiceCall.UseVisualStyleBackColor = true;
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.Location = new System.Drawing.Point(71, 17);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new System.Drawing.Size(96, 23);
            this.btnSaveTest.TabIndex = 5;
            this.btnSaveTest.Text = "Test &Rule";
            this.btnSaveTest.UseVisualStyleBackColor = true;
            this.btnSaveTest.Click += new System.EventHandler(this.btnSaveTest_Click);
            // 
            // RuleConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveTest);
            this.Controls.Add(this.chkVoiceCall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSmsAlert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContains);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "RuleConfiguration";
            this.Size = new System.Drawing.Size(429, 383);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContains;
        private System.Windows.Forms.CheckBox chkSmsAlert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkVoiceCall;
        private System.Windows.Forms.Button btnSaveTest;
    }
}
