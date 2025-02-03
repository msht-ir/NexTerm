using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmReviewProgs3 : Form
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle ();
            lblGridTime1 = new Label ();
            lblGridTime2 = new Label ();
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
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu3_Exit = new ToolStripMenuItem ();
            GridTime = new DataGridView ();
            Dayx = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn ();
            t1130 = new DataGridViewTextBoxColumn ();
            t1330 = new DataGridViewTextBoxColumn ();
            t1430 = new DataGridViewTextBoxColumn ();
            t1530 = new DataGridViewTextBoxColumn ();
            t1630 = new DataGridViewTextBoxColumn ();
            ContextMenu_frmReview = new ContextMenuStrip (components);
            Menu_Guide = new ToolStripMenuItem ();
            toolStripMenuItem3 = new ToolStripSeparator ();
            Menu_ShowInGridTime2 = new ToolStripMenuItem ();
            Menu_ShowInGridTime3 = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Exit = new ToolStripMenuItem ();
            cboDepts = new ComboBox ();
            ContextMenuStripReviewType = new ContextMenuStrip (components);
            Menu2_Entries = new ToolStripMenuItem ();
            Menu2_Staff = new ToolStripMenuItem ();
            Menu2_Classes = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu2_Exit = new ToolStripMenuItem ();
            lblGridTime3 = new Label ();
            GridTime3 = new DataGridView ();
            DataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn ();
            cboTerms = new ComboBox ();
            cboEntries = new ComboBox ();
            lblExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridTime2).BeginInit ();
            ContextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridTime).BeginInit ();
            ContextMenu_frmReview.SuspendLayout ();
            ContextMenuStripReviewType.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridTime3).BeginInit ();
            SuspendLayout ();
            // 
            // lblGridTime1
            // 
            lblGridTime1.BackColor = Color.SlateGray;
            lblGridTime1.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblGridTime1.ForeColor = Color.WhiteSmoke;
            lblGridTime1.Location = new Point (9, 36);
            lblGridTime1.Name = "lblGridTime1";
            lblGridTime1.RightToLeft = RightToLeft.Yes;
            lblGridTime1.Size = new Size (1243, 18);
            lblGridTime1.TabIndex = 59;
            lblGridTime1.Text = "-";
            lblGridTime1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGridTime2
            // 
            lblGridTime2.BackColor = Color.SlateGray;
            lblGridTime2.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblGridTime2.ForeColor = Color.WhiteSmoke;
            lblGridTime2.Location = new Point (9, 242);
            lblGridTime2.Name = "lblGridTime2";
            lblGridTime2.RightToLeft = RightToLeft.Yes;
            lblGridTime2.Size = new Size (1243, 18);
            lblGridTime2.TabIndex = 58;
            lblGridTime2.Text = "-";
            lblGridTime2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridTime2
            // 
            GridTime2.AllowUserToAddRows = false;
            GridTime2.AllowUserToDeleteRows = false;
            GridTime2.AllowUserToResizeColumns = false;
            GridTime2.AllowUserToResizeRows = false;
            GridTime2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridTime2.BackgroundColor = SystemColors.Control;
            GridTime2.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            GridTime2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            GridTime2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTime2.Columns.AddRange (new DataGridViewColumn [] { DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5, DataGridViewTextBoxColumn6, DataGridViewTextBoxColumn7, DataGridViewTextBoxColumn8, DataGridViewTextBoxColumn9, DataGridViewTextBoxColumn10, DataGridViewTextBoxColumn11, DataGridViewTextBoxColumn12 });
            GridTime2.ContextMenuStrip = ContextMenuStrip1;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle8.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            GridTime2.DefaultCellStyle = dataGridViewCellStyle8;
            GridTime2.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTime2.GridColor = SystemColors.ControlLight;
            GridTime2.Location = new Point (9, 264);
            GridTime2.Name = "GridTime2";
            GridTime2.RightToLeft = RightToLeft.Yes;
            GridTime2.RowHeadersVisible = false;
            GridTime2.ShowCellToolTips = false;
            GridTime2.Size = new Size (1243, 177);
            GridTime2.TabIndex = 57;
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
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu3_Exit });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (113, 26);
            // 
            // Menu3_Exit
            // 
            Menu3_Exit.ForeColor = Color.IndianRed;
            Menu3_Exit.Name = "Menu3_Exit";
            Menu3_Exit.Size = new Size (112, 22);
            Menu3_Exit.Text = "بازگشت";
            Menu3_Exit.Click += Menu3_Exit_Click_1;
            // 
            // GridTime
            // 
            GridTime.AllowUserToAddRows = false;
            GridTime.AllowUserToDeleteRows = false;
            GridTime.AllowUserToResizeColumns = false;
            GridTime.AllowUserToResizeRows = false;
            GridTime.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridTime.BackgroundColor = SystemColors.Control;
            GridTime.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTime.Columns.AddRange (new DataGridViewColumn [] { Dayx, DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, t1130, t1330, t1430, t1530, t1630 });
            GridTime.ContextMenuStrip = ContextMenu_frmReview;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridTime.DefaultCellStyle = dataGridViewCellStyle2;
            GridTime.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTime.GridColor = SystemColors.ControlLight;
            GridTime.Location = new Point (9, 58);
            GridTime.Name = "GridTime";
            GridTime.RightToLeft = RightToLeft.Yes;
            GridTime.RowHeadersVisible = false;
            GridTime.ShowCellToolTips = false;
            GridTime.Size = new Size (1243, 177);
            GridTime.TabIndex = 56;
            GridTime.CellClick += GridTime_CellClick;
            // 
            // Dayx
            // 
            Dayx.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Dayx.HeaderText = "روز";
            Dayx.Name = "Dayx";
            Dayx.Width = 47;
            // 
            // DataGridViewTextBoxColumn1
            // 
            DataGridViewTextBoxColumn1.HeaderText = "08:30";
            DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            // 
            // DataGridViewTextBoxColumn2
            // 
            DataGridViewTextBoxColumn2.HeaderText = "09:30";
            DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            // 
            // DataGridViewTextBoxColumn3
            // 
            DataGridViewTextBoxColumn3.HeaderText = "10:30";
            DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            // 
            // t1130
            // 
            t1130.HeaderText = "11:30";
            t1130.Name = "t1130";
            // 
            // t1330
            // 
            t1330.HeaderText = "13:30";
            t1330.Name = "t1330";
            // 
            // t1430
            // 
            t1430.HeaderText = "14:30";
            t1430.Name = "t1430";
            // 
            // t1530
            // 
            t1530.HeaderText = "15:30";
            t1530.Name = "t1530";
            // 
            // t1630
            // 
            t1630.HeaderText = "16:30";
            t1630.Name = "t1630";
            // 
            // ContextMenu_frmReview
            // 
            ContextMenu_frmReview.Items.AddRange (new ToolStripItem [] { Menu_Guide, toolStripMenuItem3, Menu_ShowInGridTime2, Menu_ShowInGridTime3, ToolStripMenuItem1, Menu_Exit });
            ContextMenu_frmReview.Name = "ContextMenu_frmStaff";
            ContextMenu_frmReview.RightToLeft = RightToLeft.Yes;
            ContextMenu_frmReview.Size = new Size (145, 104);
            // 
            // Menu_Guide
            // 
            Menu_Guide.Name = "Menu_Guide";
            Menu_Guide.Size = new Size (144, 22);
            Menu_Guide.Text = "راهنما";
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size (141, 6);
            // 
            // Menu_ShowInGridTime2
            // 
            Menu_ShowInGridTime2.Name = "Menu_ShowInGridTime2";
            Menu_ShowInGridTime2.Size = new Size (144, 22);
            Menu_ShowInGridTime2.Text = "در جدول وسط";
            Menu_ShowInGridTime2.Click += Menu_ShowInGridTime2_Click;
            // 
            // Menu_ShowInGridTime3
            // 
            Menu_ShowInGridTime3.Name = "Menu_ShowInGridTime3";
            Menu_ShowInGridTime3.Size = new Size (144, 22);
            Menu_ShowInGridTime3.Text = "در جدول پايين";
            Menu_ShowInGridTime3.Click += Menu_ShowInGridTime3_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (141, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (144, 22);
            Menu_Exit.Text = "بازگشت";
            Menu_Exit.Click += Menu_Exit_Click_1;
            // 
            // cboDepts
            // 
            cboDepts.BackColor = Color.WhiteSmoke;
            cboDepts.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepts.FlatStyle = FlatStyle.Flat;
            cboDepts.Font = new Font ("Segoe UI", 10F);
            cboDepts.ForeColor = Color.MidnightBlue;
            cboDepts.FormattingEnabled = true;
            cboDepts.Location = new Point (963, 5);
            cboDepts.Name = "cboDepts";
            cboDepts.RightToLeft = RightToLeft.Yes;
            cboDepts.Size = new Size (284, 25);
            cboDepts.TabIndex = 52;
            cboDepts.SelectedIndexChanged += cboDepts_SelectedIndexChanged;
            // 
            // ContextMenuStripReviewType
            // 
            ContextMenuStripReviewType.Items.AddRange (new ToolStripItem [] { Menu2_Entries, Menu2_Staff, Menu2_Classes, ToolStripMenuItem2, Menu2_Exit });
            ContextMenuStripReviewType.Name = "ContextMenuStripReviewType";
            ContextMenuStripReviewType.RightToLeft = RightToLeft.Yes;
            ContextMenuStripReviewType.Size = new Size (120, 98);
            // 
            // Menu2_Entries
            // 
            Menu2_Entries.Name = "Menu2_Entries";
            Menu2_Entries.Size = new Size (119, 22);
            Menu2_Entries.Text = "ورودي ها";
            Menu2_Entries.Click += Menu2_Entries_Click;
            // 
            // Menu2_Staff
            // 
            Menu2_Staff.Name = "Menu2_Staff";
            Menu2_Staff.Size = new Size (119, 22);
            Menu2_Staff.Text = "اساتيد";
            Menu2_Staff.Click += Menu2_Staff_Click;
            // 
            // Menu2_Classes
            // 
            Menu2_Classes.Name = "Menu2_Classes";
            Menu2_Classes.Size = new Size (119, 22);
            Menu2_Classes.Text = "کلاس ها";
            Menu2_Classes.Click += Menu2_Classes_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (116, 6);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new Size (119, 22);
            Menu2_Exit.Text = "بازگشت";
            Menu2_Exit.Click += Menu2_Exit_Click_1;
            // 
            // lblGridTime3
            // 
            lblGridTime3.BackColor = Color.SlateGray;
            lblGridTime3.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblGridTime3.ForeColor = Color.WhiteSmoke;
            lblGridTime3.Location = new Point (9, 449);
            lblGridTime3.Name = "lblGridTime3";
            lblGridTime3.RightToLeft = RightToLeft.Yes;
            lblGridTime3.Size = new Size (1243, 18);
            lblGridTime3.TabIndex = 63;
            lblGridTime3.Text = "-";
            lblGridTime3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridTime3
            // 
            GridTime3.AllowUserToAddRows = false;
            GridTime3.AllowUserToDeleteRows = false;
            GridTime3.AllowUserToResizeColumns = false;
            GridTime3.AllowUserToResizeRows = false;
            GridTime3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridTime3.BackgroundColor = SystemColors.Control;
            GridTime3.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridTime3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridTime3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTime3.Columns.AddRange (new DataGridViewColumn [] { DataGridViewTextBoxColumn13, DataGridViewTextBoxColumn14, DataGridViewTextBoxColumn15, DataGridViewTextBoxColumn16, DataGridViewTextBoxColumn17, DataGridViewTextBoxColumn18, DataGridViewTextBoxColumn19, DataGridViewTextBoxColumn20, DataGridViewTextBoxColumn21 });
            GridTime3.ContextMenuStrip = ContextMenuStrip1;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            GridTime3.DefaultCellStyle = dataGridViewCellStyle4;
            GridTime3.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTime3.GridColor = SystemColors.ControlLight;
            GridTime3.Location = new Point (9, 471);
            GridTime3.Name = "GridTime3";
            GridTime3.RightToLeft = RightToLeft.Yes;
            GridTime3.RowHeadersVisible = false;
            GridTime3.ShowCellToolTips = false;
            GridTime3.Size = new Size (1243, 177);
            GridTime3.TabIndex = 62;
            // 
            // DataGridViewTextBoxColumn13
            // 
            DataGridViewTextBoxColumn13.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            DataGridViewTextBoxColumn13.HeaderText = "روز";
            DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13";
            DataGridViewTextBoxColumn13.Width = 47;
            // 
            // DataGridViewTextBoxColumn14
            // 
            DataGridViewTextBoxColumn14.HeaderText = "08:30";
            DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14";
            // 
            // DataGridViewTextBoxColumn15
            // 
            DataGridViewTextBoxColumn15.HeaderText = "09:30";
            DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15";
            // 
            // DataGridViewTextBoxColumn16
            // 
            DataGridViewTextBoxColumn16.HeaderText = "10:30";
            DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16";
            // 
            // DataGridViewTextBoxColumn17
            // 
            DataGridViewTextBoxColumn17.HeaderText = "11:30";
            DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17";
            // 
            // DataGridViewTextBoxColumn18
            // 
            DataGridViewTextBoxColumn18.HeaderText = "13:30";
            DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18";
            // 
            // DataGridViewTextBoxColumn19
            // 
            DataGridViewTextBoxColumn19.HeaderText = "14:30";
            DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19";
            // 
            // DataGridViewTextBoxColumn20
            // 
            DataGridViewTextBoxColumn20.HeaderText = "15:30";
            DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20";
            // 
            // DataGridViewTextBoxColumn21
            // 
            DataGridViewTextBoxColumn21.HeaderText = "16:30";
            DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21";
            // 
            // cboTerms
            // 
            cboTerms.BackColor = Color.WhiteSmoke;
            cboTerms.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTerms.FlatStyle = FlatStyle.Flat;
            cboTerms.Font = new Font ("Segoe UI", 10F);
            cboTerms.ForeColor = Color.MidnightBlue;
            cboTerms.FormattingEnabled = true;
            cboTerms.Location = new Point (9, 5);
            cboTerms.Name = "cboTerms";
            cboTerms.Size = new Size (133, 25);
            cboTerms.TabIndex = 66;
            cboTerms.Click += cboTerms_Click;
            // 
            // cboEntries
            // 
            cboEntries.BackColor = Color.WhiteSmoke;
            cboEntries.ContextMenuStrip = ContextMenuStripReviewType;
            cboEntries.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEntries.FlatStyle = FlatStyle.Flat;
            cboEntries.Font = new Font ("Segoe UI", 10F);
            cboEntries.ForeColor = Color.MidnightBlue;
            cboEntries.FormattingEnabled = true;
            cboEntries.Location = new Point (412, 5);
            cboEntries.Name = "cboEntries";
            cboEntries.RightToLeft = RightToLeft.Yes;
            cboEntries.Size = new Size (385, 25);
            cboEntries.TabIndex = 67;
            cboEntries.SelectedIndexChanged += cboEntries_SelectedIndexChanged;
            cboEntries.Click += cboEntries_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.Font = new Font ("Segoe UI", 8F);
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (0, 655);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (1260, 14);
            lblExit.TabIndex = 68;
            lblExit.Text = "خروج";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmReviewProgs3
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (1260, 669);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (lblExit);
            Controls.Add (cboEntries);
            Controls.Add (cboTerms);
            Controls.Add (lblGridTime3);
            Controls.Add (GridTime3);
            Controls.Add (lblGridTime1);
            Controls.Add (lblGridTime2);
            Controls.Add (GridTime2);
            Controls.Add (GridTime);
            Controls.Add (cboDepts);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReviewProgs3";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmReviewProgs3";
            Load += frmReviewProgs3_Load;
            ((System.ComponentModel.ISupportInitialize) GridTime2).EndInit ();
            ContextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridTime).EndInit ();
            ContextMenu_frmReview.ResumeLayout (false);
            ContextMenuStripReviewType.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridTime3).EndInit ();
            ResumeLayout (false);
            }

        internal Label lblGridTime1;
        internal Label lblGridTime2;
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
        internal DataGridView GridTime;
        internal DataGridViewTextBoxColumn Dayx;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        internal DataGridViewTextBoxColumn t1130;
        internal DataGridViewTextBoxColumn t1330;
        internal DataGridViewTextBoxColumn t1430;
        internal DataGridViewTextBoxColumn t1530;
        internal DataGridViewTextBoxColumn t1630;
        internal ComboBox cboDepts;
        internal Label lblGridTime3;
        internal DataGridView GridTime3;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn13;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn14;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn15;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn16;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn17;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn18;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn19;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn20;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn21;
        internal ContextMenuStrip ContextMenuStripReviewType;
        internal ToolStripMenuItem Menu2_Entries;
        internal ToolStripMenuItem Menu2_Staff;
        internal ToolStripMenuItem Menu2_Classes;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem Menu2_Exit;
        internal ContextMenuStrip ContextMenu_frmReview;
        internal ToolStripMenuItem Menu_ShowInGridTime2;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Exit;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu3_Exit;
        internal ToolStripMenuItem Menu_ShowInGridTime3;
        internal ToolStripMenuItem Menu_Guide;
        internal ComboBox cboTerms;
        internal ComboBox cboEntries;
        private ToolStripSeparator toolStripMenuItem3;
        private Label lblExit;
        }
    }