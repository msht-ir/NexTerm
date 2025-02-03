using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class UserActivityLog : Form
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
            ContextMenuStripA = new ContextMenuStrip (components);
            Menu_ReportCourses = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Exit = new ToolStripMenuItem ();
            cboDepts = new ComboBox ();
            ContextMenuStripB = new ContextMenuStrip (components);
            Menu_Activity = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_Exit2 = new ToolStripMenuItem ();
            CheckBoxFaculty = new CheckBox ();
            CheckBoxDepts = new CheckBox ();
            Panel2 = new Panel ();
            btnReportA = new Button ();
            Label2 = new Label ();
            cboCoursetype = new ComboBox ();
            cboProglevel = new ComboBox ();
            cboTerms = new ComboBox ();
            Panel3 = new Panel ();
            cboActivityReportSort = new ComboBox ();
            btnReportB = new Button ();
            Label1 = new Label ();
            panel4 = new Panel ();
            lblCancel = new Label ();
            ContextMenuStripA.SuspendLayout ();
            ContextMenuStripB.SuspendLayout ();
            Panel2.SuspendLayout ();
            Panel3.SuspendLayout ();
            panel4.SuspendLayout ();
            SuspendLayout ();
            // 
            // ContextMenuStripA
            // 
            ContextMenuStripA.Font = new Font ("Segoe UI", 9F);
            ContextMenuStripA.Items.AddRange (new ToolStripItem [] { Menu_ReportCourses, ToolStripMenuItem1, Menu_Exit });
            ContextMenuStripA.Name = "ContextMenuStrip1";
            ContextMenuStripA.RightToLeft = RightToLeft.Yes;
            ContextMenuStripA.Size = new Size (238, 54);
            // 
            // Menu_ReportCourses
            // 
            Menu_ReportCourses.Name = "Menu_ReportCourses";
            Menu_ReportCourses.Size = new Size (237, 22);
            Menu_ReportCourses.Text = "گزارش درس هاي برنامه ريزي شده";
            Menu_ReportCourses.Click += Menu_ReportCourses_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (234, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (237, 22);
            Menu_Exit.Text = "خروج";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // cboDepts
            // 
            cboDepts.BackColor = Color.FromArgb (  248,   248,   248);
            cboDepts.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepts.Font = new Font ("Segoe UI", 10F);
            cboDepts.FormattingEnabled = true;
            cboDepts.Location = new Point (12, 39);
            cboDepts.Name = "cboDepts";
            cboDepts.RightToLeft = RightToLeft.Yes;
            cboDepts.Size = new Size (253, 25);
            cboDepts.TabIndex = 1;
            cboDepts.Click += cboDepts_Click;
            // 
            // ContextMenuStripB
            // 
            ContextMenuStripB.Items.AddRange (new ToolStripItem [] { Menu_Activity, ToolStripMenuItem2, Menu_Exit2 });
            ContextMenuStripB.Name = "ContextMenuStripB";
            ContextMenuStripB.RightToLeft = RightToLeft.Yes;
            ContextMenuStripB.Size = new Size (180, 54);
            // 
            // Menu_Activity
            // 
            Menu_Activity.Name = "Menu_Activity";
            Menu_Activity.Size = new Size (179, 22);
            Menu_Activity.Text = "گزارش فعاليت کاربران";
            Menu_Activity.Click += Menu_Activity_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (176, 6);
            // 
            // Menu_Exit2
            // 
            Menu_Exit2.ForeColor = Color.IndianRed;
            Menu_Exit2.Name = "Menu_Exit2";
            Menu_Exit2.Size = new Size (179, 22);
            Menu_Exit2.Text = "خروج";
            Menu_Exit2.Click += Menu_Exit2_Click;
            // 
            // CheckBoxFaculty
            // 
            CheckBoxFaculty.AutoSize = true;
            CheckBoxFaculty.Checked = true;
            CheckBoxFaculty.CheckState = CheckState.Checked;
            CheckBoxFaculty.ForeColor = SystemColors.ActiveCaptionText;
            CheckBoxFaculty.Location = new Point (278, 18);
            CheckBoxFaculty.Name = "CheckBoxFaculty";
            CheckBoxFaculty.Size = new Size (67, 19);
            CheckBoxFaculty.TabIndex = 2;
            CheckBoxFaculty.Text = "دانشکده";
            CheckBoxFaculty.UseVisualStyleBackColor = true;
            CheckBoxFaculty.CheckedChanged += CheckBoxFaculty_CheckedChanged;
            // 
            // CheckBoxDepts
            // 
            CheckBoxDepts.AutoSize = true;
            CheckBoxDepts.Checked = true;
            CheckBoxDepts.CheckState = CheckState.Checked;
            CheckBoxDepts.ForeColor = SystemColors.ActiveCaptionText;
            CheckBoxDepts.Location = new Point (278, 43);
            CheckBoxDepts.Name = "CheckBoxDepts";
            CheckBoxDepts.Size = new Size (48, 19);
            CheckBoxDepts.TabIndex = 3;
            CheckBoxDepts.Text = "گروه";
            CheckBoxDepts.UseVisualStyleBackColor = true;
            CheckBoxDepts.CheckedChanged += CheckBoxDepts_CheckedChanged;
            // 
            // Panel2
            // 
            Panel2.BackColor = Color.WhiteSmoke;
            Panel2.ContextMenuStrip = ContextMenuStripA;
            Panel2.Controls.Add (btnReportA);
            Panel2.Controls.Add (Label2);
            Panel2.Controls.Add (cboCoursetype);
            Panel2.Controls.Add (cboProglevel);
            Panel2.Controls.Add (cboTerms);
            Panel2.Location = new Point (12, 76);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size (323, 139);
            Panel2.TabIndex = 6;
            Panel2.TabStop = true;
            // 
            // btnReportA
            // 
            btnReportA.Location = new Point (19, 86);
            btnReportA.Name = "btnReportA";
            btnReportA.Size = new Size (89, 23);
            btnReportA.TabIndex = 18;
            btnReportA.Text = "گزارش";
            btnReportA.UseVisualStyleBackColor = true;
            btnReportA.Click += btnReportA_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font ("Segoe UI", 9F);
            Label2.Location = new Point (199, 27);
            Label2.Name = "Label2";
            Label2.Size = new Size (107, 15);
            Label2.TabIndex = 10;
            Label2.Text = "گزارش حجم برنامه ها";
            // 
            // cboCoursetype
            // 
            cboCoursetype.BackColor = Color.FromArgb (  248,   248,   248);
            cboCoursetype.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCoursetype.Font = new Font ("Segoe UI", 10F);
            cboCoursetype.FormattingEnabled = true;
            cboCoursetype.Items.AddRange (new object [] { "دروس عملي", "دروس تئوري" });
            cboCoursetype.Location = new Point (114, 84);
            cboCoursetype.Name = "cboCoursetype";
            cboCoursetype.RightToLeft = RightToLeft.Yes;
            cboCoursetype.Size = new Size (194, 25);
            cboCoursetype.TabIndex = 9;
            // 
            // cboProglevel
            // 
            cboProglevel.BackColor = Color.FromArgb (  248,   248,   248);
            cboProglevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProglevel.Font = new Font ("Segoe UI", 10F);
            cboProglevel.FormattingEnabled = true;
            cboProglevel.Items.AddRange (new object [] { "فوق ديپلم", "کارشناسي", "کارشناسي ارشد", "دکتري عمومي", "دکتري تخصصي" });
            cboProglevel.Location = new Point (115, 53);
            cboProglevel.Name = "cboProglevel";
            cboProglevel.RightToLeft = RightToLeft.Yes;
            cboProglevel.Size = new Size (193, 25);
            cboProglevel.TabIndex = 8;
            // 
            // cboTerms
            // 
            cboTerms.BackColor = Color.FromArgb (  248,   248,   248);
            cboTerms.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTerms.Font = new Font ("Segoe UI", 10F);
            cboTerms.FormattingEnabled = true;
            cboTerms.Location = new Point (115, 22);
            cboTerms.Name = "cboTerms";
            cboTerms.Size = new Size (78, 25);
            cboTerms.TabIndex = 7;
            // 
            // Panel3
            // 
            Panel3.BackColor = Color.WhiteSmoke;
            Panel3.ContextMenuStrip = ContextMenuStripB;
            Panel3.Controls.Add (cboActivityReportSort);
            Panel3.Controls.Add (btnReportB);
            Panel3.Controls.Add (Label1);
            Panel3.Location = new Point (12, 237);
            Panel3.Name = "Panel3";
            Panel3.RightToLeft = RightToLeft.Yes;
            Panel3.Size = new Size (323, 95);
            Panel3.TabIndex = 0;
            Panel3.TabStop = true;
            // 
            // cboActivityReportSort
            // 
            cboActivityReportSort.BackColor = Color.FromArgb (  248,   248,   248);
            cboActivityReportSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActivityReportSort.Font = new Font ("Segoe UI", 10F);
            cboActivityReportSort.FormattingEnabled = true;
            cboActivityReportSort.Location = new Point (114, 45);
            cboActivityReportSort.Name = "cboActivityReportSort";
            cboActivityReportSort.RightToLeft = RightToLeft.Yes;
            cboActivityReportSort.Size = new Size (194, 25);
            cboActivityReportSort.TabIndex = 5;
            cboActivityReportSort.KeyDown += cboActivityReportSort_KeyDown;
            // 
            // btnReportB
            // 
            btnReportB.Location = new Point (19, 47);
            btnReportB.Name = "btnReportB";
            btnReportB.Size = new Size (89, 23);
            btnReportB.TabIndex = 19;
            btnReportB.Text = "گزارش";
            btnReportB.UseVisualStyleBackColor = true;
            btnReportB.Click += btnReportB_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font ("Segoe UI", 9F);
            Label1.Location = new Point (142, 18);
            Label1.Name = "Label1";
            Label1.Size = new Size (166, 15);
            Label1.TabIndex = 9;
            Label1.Text = "گزارش فعاليت کاربران - به ترتيب:";
            // 
            // panel4
            // 
            panel4.Controls.Add (lblCancel);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point (0, 376);
            panel4.Name = "panel4";
            panel4.Size = new Size (351, 20);
            panel4.TabIndex = 11;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (351, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "خروج";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // UserActivityLog
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (351, 396);
            ControlBox = false;
            Controls.Add (CheckBoxFaculty);
            Controls.Add (CheckBoxDepts);
            Controls.Add (cboDepts);
            Controls.Add (panel4);
            Controls.Add (Panel3);
            Controls.Add (Panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserActivityLog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "گزارش فعاليت";
            Load += UserActivityLog_Load;
            KeyDown += UserActivityLog_KeyDown;
            ContextMenuStripA.ResumeLayout (false);
            ContextMenuStripB.ResumeLayout (false);
            Panel2.ResumeLayout (false);
            Panel2.PerformLayout ();
            Panel3.ResumeLayout (false);
            Panel3.PerformLayout ();
            panel4.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal ContextMenuStrip ContextMenuStripCOURSES;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Exit;
        internal ComboBox cboDepts;
        internal RadioButton RadioButton10;
        internal RadioButton RadioButton11;
        internal ComboBox cboSort;
        internal ComboBox cboTerms;
        internal Panel Panel3;
        internal Label Label2;
        internal ContextMenuStrip ContextMenuSEARCH;
        internal Panel Panel7;
        internal Label Label4;
        internal Panel Panel6;
        internal Label Label3;
        internal ToolStripMenuItem Menu_UserActivicy_Date;
        internal ToolStripMenuItem Menu_UserActivicy_Dept;
        internal ToolStripMenuItem Menu_UserActivicy_Client;
        internal ToolStripMenuItem Menu_UserActivicy_Nick;
        internal ToolStripMenuItem Menu_ReportCourses;
        internal ComboBox cboTerm;
        internal ToolStripComboBox ToolStripComboBox1;
        internal ToolStripMenuItem تهيهگزارشفعاليتکاربرانToolStripMenuItem;
        internal ToolStripComboBox Menu_Cbo;
        internal ToolStripMenuItem Menu_UserActivityReportSorted;
        internal ToolStripComboBox ToolStripComboBox2;
        internal CheckBox CheckBox1;
        internal CheckBox CheckBox2;
        internal Panel Panel2;
        internal RadioButton RadioButton7;
        internal RadioButton RadioButton8;
        internal RadioButton RadioButton9;
        internal ComboBox ComboBox4;
        internal ComboBox ComboBox3;
        internal ComboBox cboCoursetype;
        internal ComboBox cboProglevel;
        internal Label Label1;
        internal ContextMenuStrip ContextMenuStrip_USERS;
        internal ToolStripMenuItem Menu_Activity;
        internal ToolStripSeparator ToolStripMenuItem3;
        internal ToolStripMenuItem Menu_Exit2;
        internal ContextMenuStrip ContextMenuStripA;
        internal CheckBox CheckBoxFaculty;
        internal CheckBox CheckBoxDepts;
        internal ContextMenuStrip ContextMenuStripB;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ComboBox cboActivityReportSort;
        private Panel panel4;
        private Label lblCancel;
        private Button btnReportB;
        private Button btnReportA;
        }
    }