using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmReportSettings : Form
        {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode ()]
        protected override void Dispose (bool disposing)
            {
            try
                {
                if (disposing && components is not null)
                    {
                    components.Dispose ();
                    }
                }
            finally
                {
                base.Dispose (disposing);
                }
            }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough ()]
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_OK = new ToolStripMenuItem ();
            Menu_Guide = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Cancel = new ToolStripMenuItem ();
            RadioDaysInCols = new RadioButton ();
            RadioDaysInRows = new RadioButton ();
            CheckBoxDetails = new CheckBox ();
            Panel1 = new Panel ();
            btnOK = new Button ();
            label2 = new Label ();
            label1 = new Label ();
            cboDepts = new ComboBox ();
            CheckBoxExamTable = new CheckBox ();
            CheckBoxSuggest = new CheckBox ();
            CheckBoxFreeTimes = new CheckBox ();
            CheckBoxBG = new CheckBox ();
            cboTerms = new ComboBox ();
            CheckBoxExamDate = new CheckBox ();
            CheckBoxCourseGroup = new CheckBox ();
            CheckBoxCourseNumber = new CheckBox ();
            CheckBoxCourseName = new CheckBox ();
            CheckBoxRememberSettings = new CheckBox ();
            panel2 = new Panel ();
            lblCancel = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            Panel1.SuspendLayout ();
            panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_OK, Menu_Guide, ToolStripMenuItem1, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (112, 76);
            // 
            // Menu_OK
            // 
            Menu_OK.Name = "Menu_OK";
            Menu_OK.Size = new Size (111, 22);
            Menu_OK.Text = "تاييد";
            Menu_OK.Click += Menu_OK_Click;
            // 
            // Menu_Guide
            // 
            Menu_Guide.Name = "Menu_Guide";
            Menu_Guide.Size = new Size (111, 22);
            Menu_Guide.Text = "راهنما";
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (108, 6);
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (111, 22);
            Menu_Cancel.Text = "انصراف";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // RadioDaysInCols
            // 
            RadioDaysInCols.AutoSize = true;
            RadioDaysInCols.Font = new Font ("Segoe UI", 10F);
            RadioDaysInCols.ForeColor = Color.IndianRed;
            RadioDaysInCols.Location = new Point (144, 238);
            RadioDaysInCols.Name = "RadioDaysInCols";
            RadioDaysInCols.Size = new Size (154, 23);
            RadioDaysInCols.TabIndex = 11;
            RadioDaysInCols.Text = "روزهاي هفته در ستون";
            RadioDaysInCols.TextAlign = ContentAlignment.MiddleRight;
            RadioDaysInCols.UseVisualStyleBackColor = true;
            RadioDaysInCols.CheckedChanged += RadioDaysInCols_CheckedChanged;
            // 
            // RadioDaysInRows
            // 
            RadioDaysInRows.AutoSize = true;
            RadioDaysInRows.Checked = true;
            RadioDaysInRows.Font = new Font ("Segoe UI", 10F);
            RadioDaysInRows.ForeColor = Color.IndianRed;
            RadioDaysInRows.Location = new Point (147, 267);
            RadioDaysInRows.Name = "RadioDaysInRows";
            RadioDaysInRows.Size = new Size (151, 23);
            RadioDaysInRows.TabIndex = 6;
            RadioDaysInRows.TabStop = true;
            RadioDaysInRows.Text = "روزهاي هفته در سطر";
            RadioDaysInRows.TextAlign = ContentAlignment.MiddleRight;
            RadioDaysInRows.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDetails
            // 
            CheckBoxDetails.Font = new Font ("Segoe UI", 9F);
            CheckBoxDetails.Location = new Point (103, 113);
            CheckBoxDetails.Name = "CheckBoxDetails";
            CheckBoxDetails.Size = new Size (195, 19);
            CheckBoxDetails.TabIndex = 2;
            CheckBoxDetails.Text = "جزئيات";
            CheckBoxDetails.UseVisualStyleBackColor = true;
            CheckBoxDetails.CheckedChanged += CheckBoxDetails_CheckedChanged;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add (btnOK);
            Panel1.Controls.Add (label2);
            Panel1.Controls.Add (label1);
            Panel1.Controls.Add (cboDepts);
            Panel1.Controls.Add (CheckBoxExamTable);
            Panel1.Controls.Add (CheckBoxSuggest);
            Panel1.Controls.Add (CheckBoxFreeTimes);
            Panel1.Controls.Add (CheckBoxBG);
            Panel1.Controls.Add (cboTerms);
            Panel1.Controls.Add (CheckBoxExamDate);
            Panel1.Controls.Add (CheckBoxCourseGroup);
            Panel1.Controls.Add (CheckBoxCourseNumber);
            Panel1.Controls.Add (CheckBoxCourseName);
            Panel1.Controls.Add (CheckBoxRememberSettings);
            Panel1.Controls.Add (RadioDaysInCols);
            Panel1.Controls.Add (RadioDaysInRows);
            Panel1.Controls.Add (CheckBoxDetails);
            Panel1.Dock = DockStyle.Fill;
            Panel1.Location = new Point (0, 0);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size (372, 494);
            Panel1.TabIndex = 4;
            // 
            // btnOK
            // 
            btnOK.Location = new Point (140, 417);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size (101, 23);
            btnOK.TabIndex = 20;
            btnOK.Text = "تاييد";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point (304, 51);
            label2.Name = "label2";
            label2.Size = new Size (43, 15);
            label2.TabIndex = 15;
            label2.Text = "نيمسال";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point (304, 19);
            label1.Name = "label1";
            label1.Size = new Size (29, 15);
            label1.TabIndex = 14;
            label1.Text = "گروه";
            // 
            // cboDepts
            // 
            cboDepts.BackColor = SystemColors.Control;
            cboDepts.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepts.FlatStyle = FlatStyle.Flat;
            cboDepts.Font = new Font ("Segoe UI", 11F);
            cboDepts.ForeColor = Color.MidnightBlue;
            cboDepts.FormattingEnabled = true;
            cboDepts.Location = new Point (68, 12);
            cboDepts.Name = "cboDepts";
            cboDepts.Size = new Size (230, 28);
            cboDepts.TabIndex = 13;
            // 
            // CheckBoxExamTable
            // 
            CheckBoxExamTable.Font = new Font ("Segoe UI", 9F);
            CheckBoxExamTable.ForeColor = Color.IndianRed;
            CheckBoxExamTable.Location = new Point (103, 188);
            CheckBoxExamTable.Name = "CheckBoxExamTable";
            CheckBoxExamTable.Size = new Size (195, 19);
            CheckBoxExamTable.TabIndex = 5;
            CheckBoxExamTable.Text = "جدول تاريخ امتحانات";
            CheckBoxExamTable.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSuggest
            // 
            CheckBoxSuggest.Font = new Font ("Segoe UI", 9F);
            CheckBoxSuggest.Location = new Point (103, 138);
            CheckBoxSuggest.Name = "CheckBoxSuggest";
            CheckBoxSuggest.Size = new Size (195, 19);
            CheckBoxSuggest.TabIndex = 3;
            CheckBoxSuggest.Text = "پيشنهاد رفع تداخل";
            CheckBoxSuggest.UseVisualStyleBackColor = true;
            // 
            // CheckBoxFreeTimes
            // 
            CheckBoxFreeTimes.Font = new Font ("Segoe UI", 9F);
            CheckBoxFreeTimes.Location = new Point (103, 163);
            CheckBoxFreeTimes.Name = "CheckBoxFreeTimes";
            CheckBoxFreeTimes.Size = new Size (195, 19);
            CheckBoxFreeTimes.TabIndex = 4;
            CheckBoxFreeTimes.Text = "جدول ساعت هاي آزاد";
            CheckBoxFreeTimes.UseVisualStyleBackColor = true;
            CheckBoxFreeTimes.CheckedChanged += CheckBoxFreeTimes_CheckedChanged;
            // 
            // CheckBoxBG
            // 
            CheckBoxBG.Font = new Font ("Segoe UI", 9F);
            CheckBoxBG.Location = new Point (103, 213);
            CheckBoxBG.Name = "CheckBoxBG";
            CheckBoxBG.Size = new Size (195, 19);
            CheckBoxBG.TabIndex = 12;
            CheckBoxBG.Text = "تصوير زمينه";
            CheckBoxBG.UseVisualStyleBackColor = true;
            // 
            // cboTerms
            // 
            cboTerms.BackColor = SystemColors.Window;
            cboTerms.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTerms.Font = new Font ("Segoe UI", 10F);
            cboTerms.FormattingEnabled = true;
            cboTerms.Location = new Point (156, 46);
            cboTerms.Name = "cboTerms";
            cboTerms.RightToLeft = RightToLeft.No;
            cboTerms.Size = new Size (142, 25);
            cboTerms.TabIndex = 0;
            // 
            // CheckBoxExamDate
            // 
            CheckBoxExamDate.Font = new Font ("Segoe UI", 9F);
            CheckBoxExamDate.Location = new Point (103, 371);
            CheckBoxExamDate.Name = "CheckBoxExamDate";
            CheckBoxExamDate.Size = new Size (171, 19);
            CheckBoxExamDate.TabIndex = 10;
            CheckBoxExamDate.Text = "ساعت و تاريخ امتحان";
            CheckBoxExamDate.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCourseGroup
            // 
            CheckBoxCourseGroup.Font = new Font ("Segoe UI", 9F);
            CheckBoxCourseGroup.Location = new Point (103, 346);
            CheckBoxCourseGroup.Name = "CheckBoxCourseGroup";
            CheckBoxCourseGroup.Size = new Size (171, 19);
            CheckBoxCourseGroup.TabIndex = 9;
            CheckBoxCourseGroup.Text = "شماره گروه درس";
            CheckBoxCourseGroup.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCourseNumber
            // 
            CheckBoxCourseNumber.Font = new Font ("Segoe UI", 9F);
            CheckBoxCourseNumber.Location = new Point (103, 321);
            CheckBoxCourseNumber.Name = "CheckBoxCourseNumber";
            CheckBoxCourseNumber.Size = new Size (171, 19);
            CheckBoxCourseNumber.TabIndex = 8;
            CheckBoxCourseNumber.Text = "شماره درس";
            CheckBoxCourseNumber.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCourseName
            // 
            CheckBoxCourseName.Checked = true;
            CheckBoxCourseName.CheckState = CheckState.Checked;
            CheckBoxCourseName.Font = new Font ("Segoe UI", 9F);
            CheckBoxCourseName.Location = new Point (103, 296);
            CheckBoxCourseName.Name = "CheckBoxCourseName";
            CheckBoxCourseName.Size = new Size (171, 19);
            CheckBoxCourseName.TabIndex = 7;
            CheckBoxCourseName.Text = "نام درس";
            CheckBoxCourseName.UseVisualStyleBackColor = true;
            // 
            // CheckBoxRememberSettings
            // 
            CheckBoxRememberSettings.Checked = true;
            CheckBoxRememberSettings.CheckState = CheckState.Checked;
            CheckBoxRememberSettings.Font = new Font ("Segoe UI", 9F);
            CheckBoxRememberSettings.Location = new Point (103, 88);
            CheckBoxRememberSettings.Name = "CheckBoxRememberSettings";
            CheckBoxRememberSettings.Size = new Size (195, 19);
            CheckBoxRememberSettings.TabIndex = 1;
            CheckBoxRememberSettings.Text = "تنظيمات را به خاطر بسپار";
            CheckBoxRememberSettings.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add (lblCancel);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point (0, 474);
            panel2.Name = "panel2";
            panel2.Size = new Size (372, 20);
            panel2.TabIndex = 11;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (372, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // frmReportSettings
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size (372, 494);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel2);
            Controls.Add (Panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReportSettings";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تنظيمات گزارش";
            Load += frmReportSettings_Load;
            ContextMenuStrip1.ResumeLayout (false);
            Panel1.ResumeLayout (false);
            Panel1.PerformLayout ();
            panel2.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_OK;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Cancel;
        internal RadioButton RadioDaysInCols;
        internal RadioButton RadioDaysInRows;
        internal CheckBox CheckBoxDetails;
        internal Panel Panel1;
        internal CheckBox CheckBoxRememberSettings;
        internal CheckBox CheckBox4;
        internal CheckBox CheckBox3;
        internal CheckBox CheckBox2;
        internal CheckBox CheckBoxBG;
        internal CheckBox CheckBoxExamDate;
        internal CheckBox CheckBoxCourseGroup;
        internal CheckBox CheckBoxCourseNumber;
        internal CheckBox CheckBoxCourseName;
        internal ComboBox cboTerms;
        internal CheckBox CheckBoxFreeTimes;
        internal CheckBox CheckBoxSuggest;
        internal CheckBox CheckBoxExamTable;
        internal ToolStripMenuItem Menu_Guide;
        internal ComboBox cboDepts;
        private Panel panel2;
        private Label lblCancel;
        private Label label2;
        private Label label1;
        private Button btnOK;
        }
    }