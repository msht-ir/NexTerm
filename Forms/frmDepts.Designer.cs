using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmDepts : Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmDepts));
            Grid1 = new DataGridView ();
            ContextMenu_Depts = new ContextMenuStrip (components);
            Menu_AddDept = new ToolStripMenuItem ();
            Menu_EditDept = new ToolStripMenuItem ();
            Menu_ChangePassDept = new ToolStripMenuItem ();
            Menu_GuideDept = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_CancelDept = new ToolStripMenuItem ();
            ListBioProg = new ListBox ();
            ContextMenu_BioProg = new ContextMenuStrip (components);
            Menu_AddBioProg = new ToolStripMenuItem ();
            Menu_EditBioProg = new ToolStripMenuItem ();
            Menu_ProgramSpecs = new ToolStripMenuItem ();
            ToolStripSeparator1 = new ToolStripSeparator ();
            Menu_CancelBioProg = new ToolStripMenuItem ();
            GridEntries = new DataGridView ();
            ContextMenu_Entries = new ContextMenuStrip (components);
            Menu_AddEntry = new ToolStripMenuItem ();
            Menu_EditEntry = new ToolStripMenuItem ();
            ToolStripSeparator3 = new ToolStripSeparator ();
            Menu_CancelEntry = new ToolStripMenuItem ();
            ListStaff = new ListBox ();
            ContextMenu_Staff = new ContextMenuStrip (components);
            Menu_AddStaff = new ToolStripMenuItem ();
            Menu_EditStaff = new ToolStripMenuItem ();
            Menu_DelStaff = new ToolStripMenuItem ();
            ToolStripSeparator6 = new ToolStripSeparator ();
            Menu_CancelStaff = new ToolStripMenuItem ();
            GridCourse = new DataGridView ();
            ContextMenuCourses = new ContextMenuStrip (components);
            Menu_AddCourse = new ToolStripMenuItem ();
            Menu_AddCourseFromList = new ToolStripMenuItem ();
            Menu_EditCourseNumber = new ToolStripMenuItem ();
            Menu_EditCourseSpecs = new ToolStripMenuItem ();
            Menu_ExportCourseList = new ToolStripMenuItem ();
            ToolStripSeparator4 = new ToolStripSeparator ();
            Menu_CancelCourse = new ToolStripMenuItem ();
            Label2 = new Label ();
            Label1 = new Label ();
            Label3 = new Label ();
            Label4 = new Label ();
            Label5 = new Label ();
            Label6 = new Label ();
            openFileDialog1 = new OpenFileDialog ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            ((System.ComponentModel.ISupportInitialize) Grid1).BeginInit ();
            ContextMenu_Depts.SuspendLayout ();
            ContextMenu_BioProg.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridEntries).BeginInit ();
            ContextMenu_Entries.SuspendLayout ();
            ContextMenu_Staff.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridCourse).BeginInit ();
            ContextMenuCourses.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.AllowUserToResizeColumns = false;
            Grid1.AllowUserToResizeRows = false;
            Grid1.BackgroundColor = SystemColors.Control;
            Grid1.BorderStyle = BorderStyle.None;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Grid1.ContextMenuStrip = ContextMenu_Depts;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            Grid1.DefaultCellStyle = dataGridViewCellStyle1;
            Grid1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid1.GridColor = SystemColors.Control;
            Grid1.Location = new Point (770, 23);
            Grid1.MultiSelect = false;
            Grid1.Name = "Grid1";
            Grid1.RightToLeft = RightToLeft.Yes;
            Grid1.RowHeadersVisible = false;
            Grid1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Grid1.Size = new Size (468, 562);
            Grid1.TabIndex = 10;
            Grid1.CellClick += Grid1_CellClick;
            Grid1.CellDoubleClick += Grid1_CellDoubleClick;
            Grid1.KeyDown += Grid1_KeyDown;
            // 
            // ContextMenu_Depts
            // 
            ContextMenu_Depts.Items.AddRange (new ToolStripItem [] { Menu_AddDept, Menu_EditDept, Menu_ChangePassDept, Menu_GuideDept, ToolStripMenuItem1, Menu_CancelDept });
            ContextMenu_Depts.Name = "ContextMenuStripDepts";
            ContextMenu_Depts.RightToLeft = RightToLeft.Yes;
            ContextMenu_Depts.Size = new Size (137, 120);
            // 
            // Menu_AddDept
            // 
            Menu_AddDept.Name = "Menu_AddDept";
            Menu_AddDept.Size = new Size (136, 22);
            Menu_AddDept.Text = "+  گروه جديد";
            Menu_AddDept.Click += Menu_AddDept_Click;
            // 
            // Menu_EditDept
            // 
            Menu_EditDept.Font = new Font ("Segoe UI", 9F);
            Menu_EditDept.ForeColor = SystemColors.ControlText;
            Menu_EditDept.Name = "Menu_EditDept";
            Menu_EditDept.Size = new Size (136, 22);
            Menu_EditDept.Text = "ويرايش ...";
            Menu_EditDept.Click += Menu_EditDept_Click;
            // 
            // Menu_ChangePassDept
            // 
            Menu_ChangePassDept.ForeColor = SystemColors.ControlText;
            Menu_ChangePassDept.Name = "Menu_ChangePassDept";
            Menu_ChangePassDept.Size = new Size (136, 22);
            Menu_ChangePassDept.Text = "کلمه عبور ...";
            Menu_ChangePassDept.Click += Menu_ChangePassDept_Click;
            // 
            // Menu_GuideDept
            // 
            Menu_GuideDept.Name = "Menu_GuideDept";
            Menu_GuideDept.Size = new Size (136, 22);
            Menu_GuideDept.Text = "راهنما";
            Menu_GuideDept.Click += Menu_GuideDept_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (133, 6);
            // 
            // Menu_CancelDept
            // 
            Menu_CancelDept.ForeColor = Color.IndianRed;
            Menu_CancelDept.Name = "Menu_CancelDept";
            Menu_CancelDept.Size = new Size (136, 22);
            Menu_CancelDept.Text = "خروج";
            Menu_CancelDept.Click += Menu_CancelDept_Click;
            // 
            // ListBioProg
            // 
            ListBioProg.BackColor = Color.FromArgb (  248,   248,   248);
            ListBioProg.BorderStyle = BorderStyle.None;
            ListBioProg.ContextMenuStrip = ContextMenu_BioProg;
            ListBioProg.Font = new Font ("Segoe UI", 10F);
            ListBioProg.FormattingEnabled = true;
            ListBioProg.ItemHeight = 17;
            ListBioProg.Location = new Point (446, 23);
            ListBioProg.Name = "ListBioProg";
            ListBioProg.RightToLeft = RightToLeft.Yes;
            ListBioProg.Size = new Size (318, 136);
            ListBioProg.TabIndex = 13;
            ListBioProg.Tag = "انتخاب دوره آموزشي";
            ListBioProg.Click += ListBioProg_Click;
            // 
            // ContextMenu_BioProg
            // 
            ContextMenu_BioProg.Items.AddRange (new ToolStripItem [] { Menu_AddBioProg, Menu_EditBioProg, Menu_ProgramSpecs, ToolStripSeparator1, Menu_CancelBioProg });
            ContextMenu_BioProg.Name = "ContextMenuStrip1";
            ContextMenu_BioProg.RightToLeft = RightToLeft.Yes;
            ContextMenu_BioProg.Size = new Size (137, 98);
            // 
            // Menu_AddBioProg
            // 
            Menu_AddBioProg.Name = "Menu_AddBioProg";
            Menu_AddBioProg.Size = new Size (136, 22);
            Menu_AddBioProg.Text = "+  دوره جديد";
            Menu_AddBioProg.Click += Menu_AddBioProg_Click;
            // 
            // Menu_EditBioProg
            // 
            Menu_EditBioProg.Name = "Menu_EditBioProg";
            Menu_EditBioProg.Size = new Size (136, 22);
            Menu_EditBioProg.Text = "ويرايش";
            Menu_EditBioProg.Click += Menu_EditBioProg_Click;
            // 
            // Menu_ProgramSpecs
            // 
            Menu_ProgramSpecs.Name = "Menu_ProgramSpecs";
            Menu_ProgramSpecs.Size = new Size (136, 22);
            Menu_ProgramSpecs.Text = "مشخصات";
            Menu_ProgramSpecs.Click += Menu_ProgramSpecs_Click;
            // 
            // ToolStripSeparator1
            // 
            ToolStripSeparator1.Name = "ToolStripSeparator1";
            ToolStripSeparator1.Size = new Size (133, 6);
            // 
            // Menu_CancelBioProg
            // 
            Menu_CancelBioProg.ForeColor = Color.IndianRed;
            Menu_CancelBioProg.Name = "Menu_CancelBioProg";
            Menu_CancelBioProg.Size = new Size (136, 22);
            Menu_CancelBioProg.Text = "خروج";
            Menu_CancelBioProg.Click += Menu_CancelBioProg_Click;
            // 
            // GridEntries
            // 
            GridEntries.AllowUserToAddRows = false;
            GridEntries.AllowUserToDeleteRows = false;
            GridEntries.AllowUserToResizeColumns = false;
            GridEntries.AllowUserToResizeRows = false;
            GridEntries.BackgroundColor = SystemColors.Control;
            GridEntries.BorderStyle = BorderStyle.None;
            GridEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridEntries.ContextMenuStrip = ContextMenu_Entries;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridEntries.DefaultCellStyle = dataGridViewCellStyle2;
            GridEntries.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridEntries.GridColor = SystemColors.Control;
            GridEntries.Location = new Point (12, 23);
            GridEntries.Name = "GridEntries";
            GridEntries.RightToLeft = RightToLeft.Yes;
            GridEntries.RowHeadersVisible = false;
            GridEntries.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridEntries.Size = new Size (428, 136);
            GridEntries.TabIndex = 14;
            GridEntries.CellDoubleClick += GridEntries_CellDoubleClick;
            GridEntries.CellValueChanged += GridEntries_CellValueChanged;
            // 
            // ContextMenu_Entries
            // 
            ContextMenu_Entries.Items.AddRange (new ToolStripItem [] { Menu_AddEntry, Menu_EditEntry, ToolStripSeparator3, Menu_CancelEntry });
            ContextMenu_Entries.Name = "ContextMenuStrip1";
            ContextMenu_Entries.RightToLeft = RightToLeft.Yes;
            ContextMenu_Entries.Size = new Size (146, 76);
            // 
            // Menu_AddEntry
            // 
            Menu_AddEntry.Name = "Menu_AddEntry";
            Menu_AddEntry.Size = new Size (145, 22);
            Menu_AddEntry.Text = "+  ورودي جديد";
            Menu_AddEntry.Click += Menu_AddEntry_Click;
            // 
            // Menu_EditEntry
            // 
            Menu_EditEntry.Name = "Menu_EditEntry";
            Menu_EditEntry.Size = new Size (145, 22);
            Menu_EditEntry.Text = "ويرايش";
            Menu_EditEntry.Click += Menu_EditEntry_Click;
            // 
            // ToolStripSeparator3
            // 
            ToolStripSeparator3.Name = "ToolStripSeparator3";
            ToolStripSeparator3.Size = new Size (142, 6);
            // 
            // Menu_CancelEntry
            // 
            Menu_CancelEntry.ForeColor = Color.IndianRed;
            Menu_CancelEntry.Name = "Menu_CancelEntry";
            Menu_CancelEntry.Size = new Size (145, 22);
            Menu_CancelEntry.Text = "خروج";
            Menu_CancelEntry.Click += Menu_CancelEntry_Click;
            // 
            // ListStaff
            // 
            ListStaff.BackColor = Color.FromArgb (  248,   248,   248);
            ListStaff.BorderStyle = BorderStyle.None;
            ListStaff.ContextMenuStrip = ContextMenu_Staff;
            ListStaff.Font = new Font ("Segoe UI", 10F);
            ListStaff.FormattingEnabled = true;
            ListStaff.ItemHeight = 17;
            ListStaff.Location = new Point (446, 194);
            ListStaff.Name = "ListStaff";
            ListStaff.RightToLeft = RightToLeft.Yes;
            ListStaff.Size = new Size (318, 391);
            ListStaff.TabIndex = 14;
            // 
            // ContextMenu_Staff
            // 
            ContextMenu_Staff.Items.AddRange (new ToolStripItem [] { Menu_AddStaff, Menu_EditStaff, Menu_DelStaff, ToolStripSeparator6, Menu_CancelStaff });
            ContextMenu_Staff.Name = "ContextMenuStrip1";
            ContextMenu_Staff.RightToLeft = RightToLeft.Yes;
            ContextMenu_Staff.Size = new Size (144, 98);
            // 
            // Menu_AddStaff
            // 
            Menu_AddStaff.Name = "Menu_AddStaff";
            Menu_AddStaff.Size = new Size (143, 22);
            Menu_AddStaff.Text = "+   استاد جديد";
            Menu_AddStaff.Click += Menu_AddStaff_Click;
            // 
            // Menu_EditStaff
            // 
            Menu_EditStaff.Name = "Menu_EditStaff";
            Menu_EditStaff.Size = new Size (143, 22);
            Menu_EditStaff.Text = "ويرايش";
            Menu_EditStaff.Click += Menu_EditStaff_Click;
            // 
            // Menu_DelStaff
            // 
            Menu_DelStaff.Enabled = false;
            Menu_DelStaff.Name = "Menu_DelStaff";
            Menu_DelStaff.Size = new Size (143, 22);
            Menu_DelStaff.Text = "حذف استاد";
            Menu_DelStaff.Click += Menu_DelStaff_Click;
            // 
            // ToolStripSeparator6
            // 
            ToolStripSeparator6.Name = "ToolStripSeparator6";
            ToolStripSeparator6.Size = new Size (140, 6);
            // 
            // Menu_CancelStaff
            // 
            Menu_CancelStaff.ForeColor = Color.IndianRed;
            Menu_CancelStaff.Name = "Menu_CancelStaff";
            Menu_CancelStaff.Size = new Size (143, 22);
            Menu_CancelStaff.Text = "خروج";
            Menu_CancelStaff.Click += Menu_CancelStaff_Click;
            // 
            // GridCourse
            // 
            GridCourse.AllowUserToAddRows = false;
            GridCourse.AllowUserToDeleteRows = false;
            GridCourse.AllowUserToResizeColumns = false;
            GridCourse.AllowUserToResizeRows = false;
            GridCourse.BackgroundColor = SystemColors.Control;
            GridCourse.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HotTrack;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridCourse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCourse.ContextMenuStrip = ContextMenuCourses;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            GridCourse.DefaultCellStyle = dataGridViewCellStyle4;
            GridCourse.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridCourse.GridColor = SystemColors.Control;
            GridCourse.Location = new Point (12, 194);
            GridCourse.Name = "GridCourse";
            GridCourse.RightToLeft = RightToLeft.Yes;
            GridCourse.RowHeadersVisible = false;
            GridCourse.Size = new Size (428, 391);
            GridCourse.TabIndex = 18;
            GridCourse.CellDoubleClick += GridCourse_CellDoubleClick;
            GridCourse.CellValueChanged += GridCourse_CellValueChanged;
            // 
            // ContextMenuCourses
            // 
            ContextMenuCourses.Items.AddRange (new ToolStripItem [] { Menu_AddCourse, Menu_AddCourseFromList, Menu_EditCourseNumber, Menu_EditCourseSpecs, Menu_ExportCourseList, ToolStripSeparator4, Menu_CancelCourse });
            ContextMenuCourses.Name = "ContextMenuStrip1";
            ContextMenuCourses.RightToLeft = RightToLeft.Yes;
            ContextMenuCourses.Size = new Size (152, 142);
            // 
            // Menu_AddCourse
            // 
            Menu_AddCourse.Name = "Menu_AddCourse";
            Menu_AddCourse.Size = new Size (151, 22);
            Menu_AddCourse.Text = "+  درس جديد";
            Menu_AddCourse.Click += Menu_AddCourse_Click;
            // 
            // Menu_AddCourseFromList
            // 
            Menu_AddCourseFromList.Enabled = false;
            Menu_AddCourseFromList.Name = "Menu_AddCourseFromList";
            Menu_AddCourseFromList.Size = new Size (151, 22);
            Menu_AddCourseFromList.Text = "از ليست ...";
            Menu_AddCourseFromList.Click += Menu_AddCourseFromList_Click;
            // 
            // Menu_EditCourseNumber
            // 
            Menu_EditCourseNumber.Name = "Menu_EditCourseNumber";
            Menu_EditCourseNumber.Size = new Size (151, 22);
            Menu_EditCourseNumber.Text = "ويرايش شماره";
            Menu_EditCourseNumber.Click += Menu_EditCourseNumber_Click;
            // 
            // Menu_EditCourseSpecs
            // 
            Menu_EditCourseSpecs.Name = "Menu_EditCourseSpecs";
            Menu_EditCourseSpecs.Size = new Size (151, 22);
            Menu_EditCourseSpecs.Text = "مشخصات درس";
            Menu_EditCourseSpecs.Click += Menu_EditCourseSpecs_Click;
            // 
            // Menu_ExportCourseList
            // 
            Menu_ExportCourseList.Name = "Menu_ExportCourseList";
            Menu_ExportCourseList.Size = new Size (151, 22);
            Menu_ExportCourseList.Text = "ذخيره در فايل ...";
            Menu_ExportCourseList.Click += Menu_ExportCourseList_Click;
            // 
            // ToolStripSeparator4
            // 
            ToolStripSeparator4.Name = "ToolStripSeparator4";
            ToolStripSeparator4.Size = new Size (148, 6);
            // 
            // Menu_CancelCourse
            // 
            Menu_CancelCourse.ForeColor = Color.IndianRed;
            Menu_CancelCourse.Name = "Menu_CancelCourse";
            Menu_CancelCourse.Size = new Size (151, 22);
            Menu_CancelCourse.Text = "خروج";
            Menu_CancelCourse.Click += Menu_CancelCourse_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = Color.Transparent;
            Label2.Font = new Font ("Microsoft Sans Serif", 14F);
            Label2.ForeColor = Color.DarkGoldenrod;
            Label2.Location = new Point (1250, 614);
            Label2.Name = "Label2";
            Label2.RightToLeft = RightToLeft.No;
            Label2.Size = new Size (79, 24);
            Label2.TabIndex = 19;
            Label2.Text = "nexterm";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point (1195, 2);
            Label1.Name = "Label1";
            Label1.Size = new Size (43, 15);
            Label1.TabIndex = 20;
            Label1.Text = "گروه ها";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point (723, 173);
            Label3.Name = "Label3";
            Label3.Size = new Size (37, 15);
            Label3.TabIndex = 21;
            Label3.Text = "اساتيد";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point (723, 2);
            Label4.Name = "Label4";
            Label4.Size = new Size (43, 15);
            Label4.TabIndex = 22;
            Label4.Text = "دوره ها";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point (358, 173);
            Label5.Name = "Label5";
            Label5.Size = new Size (82, 15);
            Label5.TabIndex = 23;
            Label5.Text = "واحد هاي درسي";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Location = new Point (388, 2);
            Label6.Name = "Label6";
            Label6.Size = new Size (52, 15);
            Label6.TabIndex = 24;
            Label6.Text = "ورودي ها";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 600);
            panel1.Name = "panel1";
            panel1.Size = new Size (1253, 20);
            panel1.TabIndex = 25;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (1253, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "خروج";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // frmDepts
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size (1253, 620);
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (Label6);
            Controls.Add (Label5);
            Controls.Add (Label4);
            Controls.Add (Label3);
            Controls.Add (Label1);
            Controls.Add (Label2);
            Controls.Add (GridEntries);
            Controls.Add (ListBioProg);
            Controls.Add (GridCourse);
            Controls.Add (ListStaff);
            Controls.Add (Grid1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDepts";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "گروه هاي آموزشي، دوره ها، ورودي ها و اساتيد";
            Load += frmShowTables_Load;
            ((System.ComponentModel.ISupportInitialize) Grid1).EndInit ();
            ContextMenu_Depts.ResumeLayout (false);
            ContextMenu_BioProg.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridEntries).EndInit ();
            ContextMenu_Entries.ResumeLayout (false);
            ContextMenu_Staff.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridCourse).EndInit ();
            ContextMenuCourses.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal DataGridView Grid1;
        internal ContextMenuStrip ContextMenu_Depts;
        internal ToolStripMenuItem Menu_AddDept;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_CancelDept;
        internal ListBox ListBioProg;
        internal DataGridView GridEntries;
        internal ContextMenuStrip ContextMenu_BioProg;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripMenuItem Menu_AddBioProg;
        internal ToolStripMenuItem Menu_EditBioProg;
        internal ToolStripMenuItem Menu_CancelBioProg;
        internal ContextMenuStrip ContextMenu_Entries;
        internal ToolStripMenuItem Menu_AddEntry;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripMenuItem Menu_CancelEntry;
        internal ToolStripMenuItem Menu_EditEntry;
        internal ListBox ListStaff;
        internal ContextMenuStrip ContextMenu_Staff;
        internal ToolStripMenuItem Menu_AddStaff;
        internal ToolStripMenuItem Menu_DelStaff;
        internal ToolStripMenuItem Menu_EditStaff;
        internal ToolStripSeparator ToolStripSeparator6;
        internal ToolStripMenuItem Menu_CancelStaff;
        internal ToolStripMenuItem Menu_ChangePassDept;
        internal ToolStripMenuItem Menu_GuideDept;
        internal DataGridView GridCourse;
        internal ContextMenuStrip ContextMenuCourses;
        internal ToolStripMenuItem Menu_AddCourse;
        internal ToolStripMenuItem Menu_EditCourseNumber;
        internal ToolStripSeparator ToolStripSeparator4;
        internal ToolStripMenuItem Menu_CancelCourse;
        internal ToolStripMenuItem Menu_AddCourseFromList;
        internal ToolStripMenuItem Menu_ExportCourseList;
        internal ToolStripMenuItem Menu_ProgramSpecs;
        internal ToolStripMenuItem Menu_EditCourseSpecs;
        internal Label Label2;
        internal Label Label1;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal ToolStripMenuItem Menu_EditDept;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private Label lblCancel;
        }
    }