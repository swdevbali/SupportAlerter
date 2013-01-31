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
            this.lvEmails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.txtContains.Size = new System.Drawing.Size(178, 38);
            this.txtContains.TabIndex = 1;
            // 
            // chkSmsAlert
            // 
            this.chkSmsAlert.AutoSize = true;
            this.chkSmsAlert.Location = new System.Drawing.Point(130, 123);
            this.chkSmsAlert.Name = "chkSmsAlert";
            this.chkSmsAlert.Size = new System.Drawing.Size(100, 17);
            this.chkSmsAlert.TabIndex = 2;
            this.chkSmsAlert.Text = "Send SMS alert";
            this.chkSmsAlert.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Notifications";
            // 
            // chkVoiceCall
            // 
            this.chkVoiceCall.AutoSize = true;
            this.chkVoiceCall.Location = new System.Drawing.Point(236, 123);
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
            // lvEmails
            // 
            this.lvEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEmails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvEmails.GridLines = true;
            this.lvEmails.Location = new System.Drawing.Point(21, 162);
            this.lvEmails.Name = "lvEmails";
            this.lvEmails.Size = new System.Drawing.Size(484, 247);
            this.lvEmails.TabIndex = 20;
            this.lvEmails.UseCompatibleStateImageBehavior = false;
            this.lvEmails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Account";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sender";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Subject";
            this.columnHeader5.Width = 220;
            // 
            // RuleConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvEmails);
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
            this.Size = new System.Drawing.Size(519, 421);
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
        private System.Windows.Forms.ListView lvEmails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
