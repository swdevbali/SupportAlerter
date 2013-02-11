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
            this.txtBodyContains = new System.Windows.Forms.TextBox();
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
            this.chkBody = new System.Windows.Forms.CheckBox();
            this.chkSender = new System.Windows.Forms.CheckBox();
            this.txtSenderContains = new System.Windows.Forms.TextBox();
            this.chkSubject = new System.Windows.Forms.CheckBox();
            this.txtSubjectContains = new System.Windows.Forms.TextBox();
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
            this.txtName.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBodyContains
            // 
            this.txtBodyContains.Enabled = false;
            this.txtBodyContains.Location = new System.Drawing.Point(130, 156);
            this.txtBodyContains.Multiline = true;
            this.txtBodyContains.Name = "txtBodyContains";
            this.txtBodyContains.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBodyContains.Size = new System.Drawing.Size(287, 38);
            this.txtBodyContains.TabIndex = 6;
            // 
            // chkSmsAlert
            // 
            this.chkSmsAlert.AutoSize = true;
            this.chkSmsAlert.Location = new System.Drawing.Point(130, 82);
            this.chkSmsAlert.Name = "chkSmsAlert";
            this.chkSmsAlert.Size = new System.Drawing.Size(100, 17);
            this.chkSmsAlert.TabIndex = 3;
            this.chkSmsAlert.Text = "Send SMS alert";
            this.chkSmsAlert.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Notifications";
            // 
            // chkVoiceCall
            // 
            this.chkVoiceCall.AutoSize = true;
            this.chkVoiceCall.Location = new System.Drawing.Point(236, 82);
            this.chkVoiceCall.Name = "chkVoiceCall";
            this.chkVoiceCall.Size = new System.Drawing.Size(72, 17);
            this.chkVoiceCall.TabIndex = 4;
            this.chkVoiceCall.Text = "Voice call";
            this.chkVoiceCall.UseVisualStyleBackColor = true;
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.Location = new System.Drawing.Point(71, 17);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new System.Drawing.Size(96, 23);
            this.btnSaveTest.TabIndex = 1;
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
            this.lvEmails.Location = new System.Drawing.Point(21, 259);
            this.lvEmails.Name = "lvEmails";
            this.lvEmails.Size = new System.Drawing.Size(562, 209);
            this.lvEmails.TabIndex = 8;
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
            // chkBody
            // 
            this.chkBody.AutoSize = true;
            this.chkBody.Location = new System.Drawing.Point(21, 156);
            this.chkBody.Name = "chkBody";
            this.chkBody.Size = new System.Drawing.Size(93, 17);
            this.chkBody.TabIndex = 21;
            this.chkBody.Text = "Body contains";
            this.chkBody.UseVisualStyleBackColor = true;
            this.chkBody.CheckedChanged += new System.EventHandler(this.chkBody_CheckedChanged);
            // 
            // chkSender
            // 
            this.chkSender.AutoSize = true;
            this.chkSender.Location = new System.Drawing.Point(21, 111);
            this.chkSender.Name = "chkSender";
            this.chkSender.Size = new System.Drawing.Size(103, 17);
            this.chkSender.TabIndex = 23;
            this.chkSender.Text = "Sender contains";
            this.chkSender.UseVisualStyleBackColor = true;
            this.chkSender.CheckedChanged += new System.EventHandler(this.chkSender_CheckedChanged);
            // 
            // txtSenderContains
            // 
            this.txtSenderContains.Enabled = false;
            this.txtSenderContains.Location = new System.Drawing.Point(130, 111);
            this.txtSenderContains.Multiline = true;
            this.txtSenderContains.Name = "txtSenderContains";
            this.txtSenderContains.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtSenderContains.Size = new System.Drawing.Size(287, 38);
            this.txtSenderContains.TabIndex = 5;
            // 
            // chkSubject
            // 
            this.chkSubject.AutoSize = true;
            this.chkSubject.Location = new System.Drawing.Point(21, 201);
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.Size = new System.Drawing.Size(105, 17);
            this.chkSubject.TabIndex = 25;
            this.chkSubject.Text = "Subject contains";
            this.chkSubject.UseVisualStyleBackColor = true;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // txtSubjectContains
            // 
            this.txtSubjectContains.Enabled = false;
            this.txtSubjectContains.Location = new System.Drawing.Point(130, 201);
            this.txtSubjectContains.Multiline = true;
            this.txtSubjectContains.Name = "txtSubjectContains";
            this.txtSubjectContains.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtSubjectContains.Size = new System.Drawing.Size(287, 38);
            this.txtSubjectContains.TabIndex = 7;
            // 
            // RuleConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkSubject);
            this.Controls.Add(this.txtSubjectContains);
            this.Controls.Add(this.chkSender);
            this.Controls.Add(this.txtSenderContains);
            this.Controls.Add(this.chkBody);
            this.Controls.Add(this.lvEmails);
            this.Controls.Add(this.btnSaveTest);
            this.Controls.Add(this.chkVoiceCall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSmsAlert);
            this.Controls.Add(this.txtBodyContains);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "RuleConfiguration";
            this.Size = new System.Drawing.Size(597, 471);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBodyContains;
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
        private System.Windows.Forms.CheckBox chkBody;
        private System.Windows.Forms.CheckBox chkSender;
        private System.Windows.Forms.TextBox txtSenderContains;
        private System.Windows.Forms.CheckBox chkSubject;
        private System.Windows.Forms.TextBox txtSubjectContains;
    }
}
