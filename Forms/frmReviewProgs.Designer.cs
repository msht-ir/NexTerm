using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmReviewProgs : Form
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle ();
            t1630 = new DataGridViewTextBoxColumn ();
            t1430 = new DataGridViewTextBoxColumn ();
            t1330 = new DataGridViewTextBoxColumn ();
            t1130 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn ();
            Dayx = new DataGridViewTextBoxColumn ();
            GridTime = new DataGridView ();
            t1530 = new DataGridViewTextBoxColumn ();
            ContextMenu_frmReview = new ContextMenuStrip (components);
            Menu_ShowInGridTime2 = new ToolStripMenuItem ();
            toolStripMenuItem3 = new ToolStripSeparator ();
            Menu_Report = new ToolStripMenuItem ();
            Menu_Exit = new ToolStripMenuItem ();
            cboDepts = new ComboBox ();
            List1 = new ListBox ();
            ContextMenuStripReviewType = new ContextMenuStrip (components);
            Menu2_Entries = new ToolStripMenuItem ();
            Menu2_Staff = new ToolStripMenuItem ();
            Menu2_Classes = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu2_More = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu2_Guide = new ToolStripMenuItem ();
            Menu2_Exit = new ToolStripMenuItem ();
            Grid4 = new DataGridView ();
            ContextMenuGridTime2 = new ContextMenuStrip (components);
            Menu3_Exit = new ToolStripMenuItem ();
            ListTerm = new ListBox ();
            GridTime2 = new DataGridView ();
            DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn ();
            lblGridTime2 = new Label ();
            lblGridTime1 = new Label ();
            lblExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridTime).BeginInit ();
            ContextMenu_frmReview.SuspendLayout ();
            ContextMenuStripReviewType.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid4).BeginInit ();
            ContextMenuGridTime2.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridTime2).BeginInit ();
            SuspendLayout ();
            // 
            // t1630
            // 
            t1630.HeaderText = "16:30";
            t1630.Name = "t1630";
            // 
            // t1430
            // 
            t1430.HeaderText = "14:30";
            t1430.Name = "t1430";
            // 
            // t1330
            // 
            t1330.HeaderText = "13:30";
            t1330.Name = "t1330";
            // 
            // t1130
            // 
            t1130.HeaderText = "11:30";
            t1130.Name = "t1130";
            // 
            // DataGridViewTextBoxColumn3
            // 
            DataGridViewTextBoxColumn3.HeaderText = "10:30";
            DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            // 
            // DataGridViewTextBoxColumn2
            // 
            DataGridViewTextBoxColumn2.HeaderText = "09:30";
            DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            // 
            // DataGridViewTextBoxColumn1
            // 
            DataGridViewTextBoxColumn1.HeaderText = "08:30";
            DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            // 
            // Dayx
            // 
            Dayx.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Dayx.HeaderText = "روز";
            Dayx.Name = "Dayx";
            Dayx.Width = 47;
            // 
            // GridTime
            // 
            GridTime.AllowUserToAddRows = false;
            GridTime.AllowUserToDeleteRows = false;
            GridTime.AllowUserToResizeColumns = false;
            GridTime.AllowUserToResizeRows = false;
            GridTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridTime.BackgroundColor = Color.WhiteSmoke;
            GridTime.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            GridTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            GridTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTime.Columns.AddRange (new DataGridViewColumn [] { Dayx, DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, t1130, t1330, t1430, t1530, t1630 });
            GridTime.ContextMenuStrip = ContextMenu_frmReview;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle9.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle9.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            GridTime.DefaultCellStyle = dataGridViewCellStyle9;
            GridTime.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTime.GridColor = SystemColors.Control;
            GridTime.Location = new Point (12, 254);
            GridTime.Name = "GridTime";
            GridTime.RightToLeft = RightToLeft.Yes;
            GridTime.RowHeadersVisible = false;
            GridTime.ShowCellToolTips = false;
            GridTime.Size = new Size (1243, 177);
            GridTime.TabIndex = 40;
            GridTime.CellClick += GridTime_CellClick;
            // 
            // t1530
            // 
            t1530.HeaderText = "15:30";
            t1530.Name = "t1530";
            // 
            // ContextMenu_frmReview
            // 
            ContextMenu_frmReview.Items.AddRange (new ToolStripItem [] { Menu_ShowInGridTime2, toolStripMenuItem3, Menu_Report, Menu_Exit });
            ContextMenu_frmReview.Name = "ContextMenu_frmStaff";
            ContextMenu_frmReview.RightToLeft = RightToLeft.Yes;
            ContextMenu_frmReview.Size = new Size (142, 76);
            // 
            // Menu_ShowInGridTime2
            // 
            Menu_ShowInGridTime2.Name = "Menu_ShowInGridTime2";
            Menu_ShowInGridTime2.Size = new Size (141, 22);
            Menu_ShowInGridTime2.Text = "در جدول پايين";
            Menu_ShowInGridTime2.Click += Menu_ShowInGridTime2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size (138, 6);
            // 
            // Menu_Report
            // 
            Menu_Report.Name = "Menu_Report";
            Menu_Report.Size = new Size (141, 22);
            Menu_Report.Text = "گزارش";
            Menu_Report.Click += Menu_Report_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (141, 22);
            Menu_Exit.Text = "بازگشت";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // cboDepts
            // 
            cboDepts.BackColor = Color.WhiteSmoke;
            cboDepts.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepts.FlatStyle = FlatStyle.Flat;
            cboDepts.Font = new Font ("Segoe UI", 10F);
            cboDepts.ForeColor = Color.MidnightBlue;
            cboDepts.FormattingEnabled = true;
            cboDepts.Location = new Point (1036, 3);
            cboDepts.Name = "cboDepts";
            cboDepts.RightToLeft = RightToLeft.Yes;
            cboDepts.Size = new Size (219, 25);
            cboDepts.TabIndex = 36;
            cboDepts.SelectedIndexChanged += cboDepts_SelectedIndexChanged;
            // 
            // List1
            // 
            List1.BackColor = Color.WhiteSmoke;
            List1.BorderStyle = BorderStyle.None;
            List1.ContextMenuStrip = ContextMenuStripReviewType;
            List1.Font = new Font ("Segoe UI", 10F);
            List1.ForeColor = Color.IndianRed;
            List1.FormattingEnabled = true;
            List1.ItemHeight = 17;
            List1.Location = new Point (1036, 39);
            List1.Name = "List1";
            List1.RightToLeft = RightToLeft.Yes;
            List1.Size = new Size (219, 187);
            List1.TabIndex = 37;
            List1.Click += List1_Click;
            // 
            // ContextMenuStripReviewType
            // 
            ContextMenuStripReviewType.Items.AddRange (new ToolStripItem [] { Menu2_Entries, Menu2_Staff, Menu2_Classes, ToolStripMenuItem2, Menu2_More, ToolStripMenuItem1, Menu2_Guide, Menu2_Exit });
            ContextMenuStripReviewType.Name = "ContextMenuStripReviewType";
            ContextMenuStripReviewType.RightToLeft = RightToLeft.Yes;
            ContextMenuStripReviewType.Size = new Size (134, 148);
            // 
            // Menu2_Entries
            // 
            Menu2_Entries.Name = "Menu2_Entries";
            Menu2_Entries.Size = new Size (133, 22);
            Menu2_Entries.Text = "ورودي ها";
            Menu2_Entries.Click += Menu2_Entries_Click;
            // 
            // Menu2_Staff
            // 
            Menu2_Staff.Name = "Menu2_Staff";
            Menu2_Staff.Size = new Size (133, 22);
            Menu2_Staff.Text = "اساتيد";
            Menu2_Staff.Click += Menu2_Staff_Click;
            // 
            // Menu2_Classes
            // 
            Menu2_Classes.Name = "Menu2_Classes";
            Menu2_Classes.Size = new Size (133, 22);
            Menu2_Classes.Text = "کلاس ها";
            Menu2_Classes.Click += Menu2_Classes_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (130, 6);
            // 
            // Menu2_More
            // 
            Menu2_More.Font = new Font ("Segoe UI", 9F);
            Menu2_More.ForeColor = Color.MediumBlue;
            Menu2_More.Name = "Menu2_More";
            Menu2_More.Size = new Size (133, 22);
            Menu2_More.Text = "سه برنامه ...";
            Menu2_More.Click += Menu2_More_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (130, 6);
            // 
            // Menu2_Guide
            // 
            Menu2_Guide.Name = "Menu2_Guide";
            Menu2_Guide.Size = new Size (133, 22);
            Menu2_Guide.Text = "راهنما";
            Menu2_Guide.Click += Menu2_Guide_Click;
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new Size (133, 22);
            Menu2_Exit.Text = "بازگشت";
            Menu2_Exit.Click += Menu2_Exit_Click;
            // 
            // Grid4
            // 
            Grid4.AllowUserToAddRows = false;
            Grid4.AllowUserToDeleteRows = false;
            Grid4.AllowUserToResizeColumns = false;
            Grid4.AllowUserToResizeRows = false;
            Grid4.BackgroundColor = Color.WhiteSmoke;
            Grid4.BorderStyle = BorderStyle.None;
            Grid4.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Grid4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Grid4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Grid4.ContextMenuStrip = ContextMenuGridTime2;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Grid4.DefaultCellStyle = dataGridViewCellStyle2;
            Grid4.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid4.GridColor = Color.WhiteSmoke;
            Grid4.Location = new Point (12, 3);
            Grid4.MultiSelect = false;
            Grid4.Name = "Grid4";
            Grid4.RightToLeft = RightToLeft.Yes;
            Grid4.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new Font ("Segoe UI", 8.25F);
            dataGridViewCellStyle10.ForeColor = Color.Gray;
            Grid4.RowsDefaultCellStyle = dataGridViewCellStyle10;
            Grid4.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Grid4.ShowCellToolTips = false;
            Grid4.Size = new Size (912, 223);
            Grid4.TabIndex = 39;
            Grid4.CellContentDoubleClick += Grid4_CellContentDoubleClick;
            // 
            // ContextMenuGridTime2
            // 
            ContextMenuGridTime2.Items.AddRange (new ToolStripItem [] { Menu3_Exit });
            ContextMenuGridTime2.Name = "ContextMenuGridTime2";
            ContextMenuGridTime2.RightToLeft = RightToLeft.Yes;
            ContextMenuGridTime2.Size = new Size (113, 26);
            // 
            // Menu3_Exit
            // 
            Menu3_Exit.ForeColor = Color.IndianRed;
            Menu3_Exit.Name = "Menu3_Exit";
            Menu3_Exit.Size = new Size (112, 22);
            Menu3_Exit.Text = "بازگشت";
            Menu3_Exit.Click += Menu3_Exit_Click;
            // 
            // ListTerm
            // 
            ListTerm.BackColor = Color.WhiteSmoke;
            ListTerm.BorderStyle = BorderStyle.None;
            ListTerm.ContextMenuStrip = ContextMenuStripReviewType;
            ListTerm.Font = new Font ("Segoe UI", 11F);
            ListTerm.FormattingEnabled = true;
            ListTerm.ItemHeight = 20;
            ListTerm.Location = new Point (937, 3);
            ListTerm.Name = "ListTerm";
            ListTerm.RightToLeft = RightToLeft.No;
            ListTerm.Size = new Size (88, 220);
            ListTerm.TabIndex = 38;
            ListTerm.Click += ListTerm_Click;
            // 
            // GridTime2
            // 
            GridTime2.AllowUserToAddRows = false;
            GridTime2.AllowUserToDeleteRows = false;
            GridTime2.AllowUserToResizeColumns = false;
            GridTime2.AllowUserToResizeRows = false;
            GridTime2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridTime2.BackgroundColor = Color.WhiteSmoke;
            GridTime2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridTime2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridTime2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTime2.Columns.AddRange (new DataGridViewColumn [] { DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5, DataGridViewTextBoxColumn6, DataGridViewTextBoxColumn7, DataGridViewTextBoxColumn8, DataGridViewTextBoxColumn9, DataGridViewTextBoxColumn10, DataGridViewTextBoxColumn11, DataGridViewTextBoxColumn12 });
            GridTime2.ContextMenuStrip = ContextMenuGridTime2;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            GridTime2.DefaultCellStyle = dataGridViewCellStyle4;
            GridTime2.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTime2.GridColor = SystemColors.Control;
            GridTime2.Location = new Point (12, 458);
            GridTime2.Name = "GridTime2";
            GridTime2.RightToLeft = RightToLeft.Yes;
            GridTime2.RowHeadersVisible = false;
            GridTime2.ShowCellToolTips = false;
            GridTime2.Size = new Size (1243, 177);
            GridTime2.TabIndex = 48;
            // 
            // DataGridViewTextBoxColumn4
            // 
            DataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DataGridViewTextBoxColumn4.HeaderText = "روز";
            DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
            DataGridViewTextBoxColumn4.Width = 47;
            // 
            // DataGridViewTextBoxColumn5
            // 
            DataGridViewTextBoxColumn5.HeaderText = "08:30";
            DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
            // 
            // DataGridViewTextBoxColumn6
            // 
            DataGridViewTextBoxColumn6.HeaderText = "09:30";
            DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
            // 
            // DataGridViewTextBoxColumn7
            // 
            DataGridViewTextBoxColumn7.HeaderText = "10:30";
            DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
            // 
            // DataGridViewTextBoxColumn8
            // 
            DataGridViewTextBoxColumn8.HeaderText = "11:30";
            DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
            // 
            // DataGridViewTextBoxColumn9
            // 
            DataGridViewTextBoxColumn9.HeaderText = "13:30";
            DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
            // 
            // DataGridViewTextBoxColumn10
            // 
            DataGridViewTextBoxColumn10.HeaderText = "14:30";
            DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
            // 
            // DataGridViewTextBoxColumn11
            // 
            DataGridViewTextBoxColumn11.HeaderText = "15:30";
            DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11";
            // 
            // DataGridViewTextBoxColumn12
            // 
            DataGridViewTextBoxColumn12.HeaderText = "16:30";
            DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12";
            // 
            // lblGridTime2
            // 
            lblGridTime2.BackColor = Color.SlateGray;
            lblGridTime2.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblGridTime2.ForeColor = Color.WhiteSmoke;
            lblGridTime2.Location = new Point (12, 436);
            lblGridTime2.Name = "lblGridTime2";
            lblGridTime2.RightToLeft = RightToLeft.Yes;
            lblGridTime2.Size = new Size (1243, 18);
            lblGridTime2.TabIndex = 50;
            lblGridTime2.Text = "-";
            lblGridTime2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGridTime1
            // 
            lblGridTime1.BackColor = Color.SlateGray;
            lblGridTime1.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblGridTime1.ForeColor = Color.WhiteSmoke;
            lblGridTime1.Location = new Point (12, 232);
            lblGridTime1.Name = "lblGridTime1";
            lblGridTime1.RightToLeft = RightToLeft.Yes;
            lblGridTime1.Size = new Size (1243, 18);
            lblGridTime1.TabIndex = 51;
            lblGridTime1.Text = "-";
            lblGridTime1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (0, 643);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (1256, 20);
            lblExit.TabIndex = 52;
            lblExit.Text = "خروج";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmReviewProgs
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (1256, 663);
            ControlBox = false;
            Controls.Add (lblExit);
            Controls.Add (lblGridTime1);
            Controls.Add (lblGridTime2);
            Controls.Add (GridTime2);
            Controls.Add (GridTime);
            Controls.Add (cboDepts);
            Controls.Add (List1);
            Controls.Add (Grid4);
            Controls.Add (ListTerm);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReviewProgs";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مرور برنامه ورودي ها";
            Load += frmReviewProgs_Load;
            ((System.ComponentModel.ISupportInitialize) GridTime).EndInit ();
            ContextMenu_frmReview.ResumeLayout (false);
            ContextMenuStripReviewType.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) Grid4).EndInit ();
            ContextMenuGridTime2.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridTime2).EndInit ();
            ResumeLayout (false);
            }

        internal DataGridViewTextBoxColumn t1630;
        internal DataGridViewTextBoxColumn t1430;
        internal DataGridViewTextBoxColumn t1330;
        internal DataGridViewTextBoxColumn t1130;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal DataGridViewTextBoxColumn Dayx;
        internal DataGridView GridTime;
        internal DataGridViewTextBoxColumn t1530;
        internal ContextMenuStrip ContextMenu_frmReview;
        internal ToolStripMenuItem Menu_Report;
        internal ToolStripMenuItem Menu_Exit;
        internal ComboBox cboDepts;
        internal ListBox List1;
        internal DataGridView Grid4;
        internal ListBox ListTerm;
        internal ContextMenuStrip ContextMenuStripReviewType;
        internal ToolStripMenuItem Menu2_Entries;
        internal ToolStripMenuItem Menu2_Staff;
        internal ToolStripMenuItem Menu2_Classes;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem Menu2_Exit;
        internal DataGridView GridTime2;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn8;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn9;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn10;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn11;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn12;
        internal ToolStripMenuItem Menu_ShowInGridTime2;
        internal ContextMenuStrip ContextMenuGridTime2;
        internal ToolStripMenuItem Menu3_Exit;
        internal Label lblGridTime2;
        internal Label lblGridTime1;
        internal ToolStripMenuItem Menu2_More;
        internal ToolStripMenuItem Menu2_Guide;
        internal ToolStripSeparator ToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem3;
        private Label lblExit;
        }
    }