using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmDateTime : Form
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
            GridExam = new DataGridView ();
            TermProgID = new DataGridViewTextBoxColumn ();
            StaffID = new DataGridViewTextBoxColumn ();
            Column1 = new DataGridViewTextBoxColumn ();
            Column2 = new DataGridViewTextBoxColumn ();
            Column4 = new DataGridViewTextBoxColumn ();
            Column3 = new DataGridViewTextBoxColumn ();
            Column7 = new DataGridViewTextBoxColumn ();
            MenuStripCalendar = new ContextMenuStrip (components);
            MenuDateStart = new ToolStripMenuItem ();
            MenuDateEnd = new ToolStripMenuItem ();
            MenuStrip0 = new ContextMenuStrip (components);
            Menu_Help = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Exit = new ToolStripMenuItem ();
            MntCal = new MonthCalendar ();
            lbl_Grid = new Label ();
            lbl2Calendar = new Label ();
            lblDbleClick = new Label ();
            Panel1 = new Panel ();
            lblExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridExam).BeginInit ();
            MenuStripCalendar.SuspendLayout ();
            MenuStrip0.SuspendLayout ();
            Panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridExam
            // 
            GridExam.AllowUserToAddRows = false;
            GridExam.AllowUserToDeleteRows = false;
            GridExam.AllowUserToResizeColumns = false;
            GridExam.AllowUserToResizeRows = false;
            GridExam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridExam.BackgroundColor = Color.WhiteSmoke;
            GridExam.BorderStyle = BorderStyle.None;
            GridExam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridExam.Columns.AddRange (new DataGridViewColumn [] { TermProgID, StaffID, Column1, Column2, Column4, Column3, Column7 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridExam.DefaultCellStyle = dataGridViewCellStyle1;
            GridExam.Dock = DockStyle.Top;
            GridExam.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridExam.GridColor = SystemColors.Control;
            GridExam.Location = new Point (0, 0);
            GridExam.MultiSelect = false;
            GridExam.Name = "GridExam";
            GridExam.RightToLeft = RightToLeft.Yes;
            GridExam.RowHeadersVisible = false;
            GridExam.ShowCellToolTips = false;
            GridExam.Size = new Size (1042, 401);
            GridExam.TabIndex = 36;
            GridExam.CellClick += GridExam_CellClick;
            GridExam.CellDoubleClick += GridExam_CellDoubleClick;
            // 
            // TermProgID
            // 
            TermProgID.HeaderText = "کد درس";
            TermProgID.Name = "TermProgID";
            TermProgID.Visible = false;
            // 
            // StaffID
            // 
            StaffID.HeaderText = "کد استاد";
            StaffID.Name = "StaffID";
            StaffID.Visible = false;
            // 
            // Column1
            // 
            Column1.HeaderText = "تاريخ";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "درس";
            Column2.Name = "Column2";
            // 
            // Column4
            // 
            Column4.HeaderText = "ورودي";
            Column4.Name = "Column4";
            // 
            // Column3
            // 
            Column3.HeaderText = "استاد";
            Column3.Name = "Column3";
            // 
            // Column7
            // 
            Column7.HeaderText = "ت";
            Column7.Name = "Column7";
            // 
            // MenuStripCalendar
            // 
            MenuStripCalendar.Items.AddRange (new ToolStripItem [] { MenuDateStart, MenuDateEnd });
            MenuStripCalendar.Name = "MenuStripCalendar";
            MenuStripCalendar.Size = new Size (205, 48);
            // 
            // MenuDateStart
            // 
            MenuDateStart.Name = "MenuDateStart";
            MenuDateStart.Size = new Size (204, 22);
            MenuDateStart.Text = "تنظيم تاريخ شروع امتحانات";
            MenuDateStart.Click += MenuDateStart_Click;
            // 
            // MenuDateEnd
            // 
            MenuDateEnd.Name = "MenuDateEnd";
            MenuDateEnd.Size = new Size (204, 22);
            MenuDateEnd.Text = "تنظيم تاريخ پايان امتحانات";
            MenuDateEnd.Click += MenuDateEnd_Click;
            // 
            // MenuStrip0
            // 
            MenuStrip0.Items.AddRange (new ToolStripItem [] { Menu_Help, ToolStripMenuItem1, Menu_Exit });
            MenuStrip0.Name = "MenuStrip0";
            MenuStrip0.Size = new Size (104, 54);
            // 
            // Menu_Help
            // 
            Menu_Help.Name = "Menu_Help";
            Menu_Help.Size = new Size (103, 22);
            Menu_Help.Text = "راهنما";
            Menu_Help.Click += Menu_Help_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (100, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (103, 22);
            Menu_Exit.Text = "خروج";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // MntCal
            // 
            MntCal.CalendarDimensions = new Size (2, 1);
            MntCal.ContextMenuStrip = MenuStripCalendar;
            MntCal.FirstDayOfWeek = Day.Saturday;
            MntCal.Font = new Font ("Segoe UI", 11F);
            MntCal.Location = new Point (158, 453);
            MntCal.MaxDate = new DateTime (2024, 3, 20, 0, 0, 0, 0);
            MntCal.MinDate = new DateTime (2022, 3, 21, 0, 0, 0, 0);
            MntCal.Name = "MntCal";
            MntCal.RightToLeft = RightToLeft.Yes;
            MntCal.RightToLeftLayout = true;
            MntCal.ShowToday = false;
            MntCal.ShowTodayCircle = false;
            MntCal.TabIndex = 44;
            MntCal.DateSelected += MntCal_DateSelected;
            // 
            // lbl_Grid
            // 
            lbl_Grid.Font = new Font ("Segoe UI", 11F, FontStyle.Bold);
            lbl_Grid.ForeColor = Color.IndianRed;
            lbl_Grid.Location = new Point (88, 413);
            lbl_Grid.Name = "lbl_Grid";
            lbl_Grid.RightToLeft = RightToLeft.Yes;
            lbl_Grid.Size = new Size (875, 31);
            lbl_Grid.TabIndex = 39;
            lbl_Grid.Text = "   امتحانات ورودي";
            lbl_Grid.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl2Calendar
            // 
            lbl2Calendar.AutoSize = true;
            lbl2Calendar.Font = new Font ("Segoe UI", 32F, FontStyle.Bold);
            lbl2Calendar.ForeColor = Color.IndianRed;
            lbl2Calendar.Location = new Point (906, 508);
            lbl2Calendar.Name = "lbl2Calendar";
            lbl2Calendar.Size = new Size (72, 59);
            lbl2Calendar.TabIndex = 45;
            lbl2Calendar.Text = "<-";
            lbl2Calendar.Visible = false;
            // 
            // lblDbleClick
            // 
            lblDbleClick.Font = new Font ("Segoe UI", 7F);
            lblDbleClick.ForeColor = Color.Black;
            lblDbleClick.Location = new Point (978, 404);
            lblDbleClick.Name = "lblDbleClick";
            lblDbleClick.Size = new Size (64, 19);
            lblDbleClick.TabIndex = 46;
            lblDbleClick.Text = "^ دبل کليک";
            lblDbleClick.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add (lblExit);
            Panel1.Dock = DockStyle.Bottom;
            Panel1.Location = new Point (0, 635);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size (1042, 20);
            Panel1.TabIndex = 47;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (0, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (1042, 20);
            lblExit.TabIndex = 46;
            lblExit.Text = "خروج";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmDateTime
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (1042, 655);
            ContextMenuStrip = MenuStrip0;
            ControlBox = false;
            Controls.Add (Panel1);
            Controls.Add (lblDbleClick);
            Controls.Add (lbl2Calendar);
            Controls.Add (lbl_Grid);
            Controls.Add (GridExam);
            Controls.Add (MntCal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDateTime";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تاريخ و ساعت امتحان";
            Load += frmDateTime_Load;
            ((System.ComponentModel.ISupportInitialize) GridExam).EndInit ();
            MenuStripCalendar.ResumeLayout (false);
            MenuStrip0.ResumeLayout (false);
            Panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal DataGridView GridExam;
        internal DataGridViewTextBoxColumn Col1;
        internal DataGridViewTextBoxColumn Col2;
        internal DataGridViewTextBoxColumn Col3;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        internal Label lblDbleClick;
        internal Label Label2;
        internal ContextMenuStrip MenuStrip0;
        internal ToolStripMenuItem Menu_Exit;
        internal DateTimePicker DateTimePicker1;
        internal DateTimePicker DateTimePicker2;
        internal MonthCalendar MntCal;
        internal ContextMenuStrip MenuStripCalendar;
        internal ToolStripMenuItem MenuDateStart;
        internal ToolStripMenuItem MenuDateEnd;
        internal ToolStripMenuItem Menu_Help;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal Label Label3;
        internal Label lbl_Grid;
        internal DataGridViewTextBoxColumn TermProgID;
        internal DataGridViewTextBoxColumn StaffID;
        internal DataGridViewTextBoxColumn Column1;
        internal DataGridViewTextBoxColumn Column2;
        internal DataGridViewTextBoxColumn Column4;
        internal DataGridViewTextBoxColumn Column3;
        internal DataGridViewTextBoxColumn Column7;
        internal Label lbl2Calendar;
        internal Panel Panel1;
        private Label lblExit;
        }
    }