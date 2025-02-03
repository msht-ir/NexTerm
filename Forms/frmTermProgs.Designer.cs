using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmTermProgs : Form
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmTermProgs));
            MenuStrip1 = new MenuStrip ();
            Menu_1 = new ToolStripMenuItem ();
            Menu_ChangePass = new ToolStripMenuItem ();
            Menu_Userx = new ToolStripMenuItem ();
            Menu_Messenger = new ToolStripMenuItem ();
            ToolStripMenuItem8 = new ToolStripSeparator ();
            Menu_Settings = new ToolStripMenuItem ();
            Menu_About = new ToolStripMenuItem ();
            Menu_Quit = new ToolStripMenuItem ();
            Menu_2 = new ToolStripMenuItem ();
            Menu_Departments = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_Courses = new ToolStripMenuItem ();
            Menu_Classes = new ToolStripMenuItem ();
            Menu_Terms = new ToolStripMenuItem ();
            Menu_Staff = new ToolStripMenuItem ();
            Menu_Tech = new ToolStripMenuItem ();
            Menu_4 = new ToolStripMenuItem ();
            M2Templates = new ToolStripMenuItem ();
            ToolStripMenuItem3 = new ToolStripSeparator ();
            Menu_ReProgram_ThisEnteryTerm_inclStaff = new ToolStripMenuItem ();
            Menu_ReProgram_ThisEnteryTerm = new ToolStripMenuItem ();
            Menu_Delete_Entry_TermProg = new ToolStripMenuItem ();
            Menu_Report = new ToolStripMenuItem ();
            Menu_ReviewPrograms = new ToolStripMenuItem ();
            ToolStripMenuItem5 = new ToolStripSeparator ();
            Menu_ReportEntriesPrograms = new ToolStripMenuItem ();
            Menu_ReportClassPrograms = new ToolStripMenuItem ();
            Menu_ReportStaffPrograms = new ToolStripMenuItem ();
            Menu_ReportStaffPrograms_Word = new ToolStripMenuItem ();
            Menu_ReportTechPrograms = new ToolStripMenuItem ();
            ToolStripMenuItem10 = new ToolStripSeparator ();
            Menu_UserActivityLogs = new ToolStripMenuItem ();
            Menu_CMD = new ToolStripTextBox ();
            Grid4 = new DataGridView ();
            PopMenuGrid4 = new ContextMenuStrip (components);
            MenuAddCourse = new ToolStripMenuItem ();
            MenuEditCourse = new ToolStripMenuItem ();
            MenuReplaceCourse = new ToolStripMenuItem ();
            MenuDelCourse = new ToolStripMenuItem ();
            MenuLine1 = new ToolStripSeparator ();
            MenuAddGroup1 = new ToolStripMenuItem ();
            MenuAddGroup = new ToolStripMenuItem ();
            MenuEditGroup = new ToolStripMenuItem ();
            MenuSetStaff = new ToolStripMenuItem ();
            MenuDelStaff = new ToolStripMenuItem ();
            MenuSetTech = new ToolStripMenuItem ();
            MenuDelTech = new ToolStripMenuItem ();
            MenuSetClass1 = new ToolStripMenuItem ();
            MenuDelClass1 = new ToolStripMenuItem ();
            MenuSetClass2 = new ToolStripMenuItem ();
            MenuDelClass2 = new ToolStripMenuItem ();
            MenuNumberOfStudents = new ToolStripMenuItem ();
            MenuShowCourseNote = new ToolStripMenuItem ();
            MenuShowCourseExamDate = new ToolStripMenuItem ();
            ListBox1 = new ListBox ();
            PopMenuGridTermic = new ContextMenuStrip (components);
            Menu_EntryProg_AllTerms = new ToolStripMenuItem ();
            ToolStripMenuItem7 = new ToolStripSeparator ();
            Menu_Guide = new ToolStripMenuItem ();
            Menu_ExitNexTerm = new ToolStripMenuItem ();
            ComboBox1 = new ComboBox ();
            ListBox2 = new ListBox ();
            PopMenuTerms = new ContextMenuStrip (components);
            Menu_TermsDefault_Set = new ToolStripMenuItem ();
            Menu_TermsDefault_Clear = new ToolStripMenuItem ();
            PopMenuGridTime = new ContextMenuStrip (components);
            PopMenu_SaveWeek = new ToolStripMenuItem ();
            ToolStripMenuItem4 = new ToolStripSeparator ();
            MenuGridTimeReport = new ToolStripMenuItem ();
            txtExamDate = new MaskedTextBox ();
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
            lblExamDate = new Label ();
            GridWeek = new DataGridView ();
            DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn ();
            PopMenuGridWeek = new ContextMenuStrip (components);
            MenuGridWeekReport = new ToolStripMenuItem ();
            MenuGridWeek_Export = new ToolStripMenuItem ();
            lblCourse = new Label ();
            lbl_UserInactiveProg = new Label ();
            lbl_UserInactiveClass = new Label ();
            lbl_UserType = new Label ();
            Panel1 = new Panel ();
            lblExit = new Label ();
            lblClss2 = new Label ();
            lblClss1 = new Label ();
            lblExtraUnitsError = new Label ();
            progressBar1 = new ProgressBar ();
            MenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid4).BeginInit ();
            PopMenuGrid4.SuspendLayout ();
            PopMenuGridTermic.SuspendLayout ();
            PopMenuTerms.SuspendLayout ();
            PopMenuGridTime.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridTime).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) GridWeek).BeginInit ();
            PopMenuGridWeek.SuspendLayout ();
            Panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // MenuStrip1
            // 
            MenuStrip1.BackColor = Color.White;
            MenuStrip1.Font = new Font ("Segoe UI", 9F);
            MenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_1, Menu_2, Menu_4, Menu_Report, Menu_CMD });
            MenuStrip1.Location = new Point (0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.RightToLeft = RightToLeft.Yes;
            MenuStrip1.Size = new Size (1289, 24);
            MenuStrip1.TabIndex = 0;
            MenuStrip1.Text = "MenuStrip1";
            // 
            // Menu_1
            // 
            Menu_1.DropDownItems.AddRange (new ToolStripItem [] { Menu_ChangePass, Menu_Userx, Menu_Messenger, ToolStripMenuItem8, Menu_Settings, Menu_About, Menu_Quit });
            Menu_1.ForeColor = SystemColors.ActiveCaptionText;
            Menu_1.Name = "Menu_1";
            Menu_1.Size = new Size (42, 20);
            Menu_1.Text = "کاربر";
            // 
            // Menu_ChangePass
            // 
            Menu_ChangePass.Name = "Menu_ChangePass";
            Menu_ChangePass.Size = new Size (131, 22);
            Menu_ChangePass.Text = "تغيير پسورد";
            Menu_ChangePass.Visible = false;
            Menu_ChangePass.Click += Menu_ChangePass_Click;
            // 
            // Menu_Userx
            // 
            Menu_Userx.ForeColor = SystemColors.ControlText;
            Menu_Userx.Name = "Menu_Userx";
            Menu_Userx.Size = new Size (131, 22);
            Menu_Userx.Text = "کاربر";
            Menu_Userx.Click += Menu_Userx_Click;
            // 
            // Menu_Messenger
            // 
            Menu_Messenger.Font = new Font ("Segoe UI", 9F);
            Menu_Messenger.ForeColor = SystemColors.ControlText;
            Menu_Messenger.Name = "Menu_Messenger";
            Menu_Messenger.Size = new Size (131, 22);
            Menu_Messenger.Text = "پيام ها";
            Menu_Messenger.Click += Menu_Messenger_Click;
            // 
            // ToolStripMenuItem8
            // 
            ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            ToolStripMenuItem8.Size = new Size (128, 6);
            // 
            // Menu_Settings
            // 
            Menu_Settings.Name = "Menu_Settings";
            Menu_Settings.Size = new Size (131, 22);
            Menu_Settings.Text = "تنظيمات";
            Menu_Settings.Click += Menu_Settings_Click;
            // 
            // Menu_About
            // 
            Menu_About.Name = "Menu_About";
            Menu_About.Size = new Size (131, 22);
            Menu_About.Text = "درباره";
            Menu_About.Click += Menu_About_Click;
            // 
            // Menu_Quit
            // 
            Menu_Quit.ForeColor = Color.IndianRed;
            Menu_Quit.Name = "Menu_Quit";
            Menu_Quit.Size = new Size (131, 22);
            Menu_Quit.Text = "خروج";
            Menu_Quit.Click += Menu_Quit_Click;
            // 
            // Menu_2
            // 
            Menu_2.DropDownItems.AddRange (new ToolStripItem [] { Menu_Departments, ToolStripMenuItem2, Menu_Courses, Menu_Classes, Menu_Terms, Menu_Staff, Menu_Tech });
            Menu_2.ForeColor = SystemColors.ActiveCaptionText;
            Menu_2.Name = "Menu_2";
            Menu_2.Size = new Size (44, 20);
            Menu_2.Text = "منابع";
            // 
            // Menu_Departments
            // 
            Menu_Departments.Name = "Menu_Departments";
            Menu_Departments.Size = new Size (125, 22);
            Menu_Departments.Text = "سازمان";
            Menu_Departments.Click += Menu_Departments_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (122, 6);
            // 
            // Menu_Courses
            // 
            Menu_Courses.Name = "Menu_Courses";
            Menu_Courses.Size = new Size (125, 22);
            Menu_Courses.Text = "درس ها";
            Menu_Courses.Click += Menu_Courses_Click;
            // 
            // Menu_Classes
            // 
            Menu_Classes.Name = "Menu_Classes";
            Menu_Classes.Size = new Size (125, 22);
            Menu_Classes.Text = "کلاس ها";
            Menu_Classes.Click += Menu_Classes_Click;
            // 
            // Menu_Terms
            // 
            Menu_Terms.Name = "Menu_Terms";
            Menu_Terms.Size = new Size (125, 22);
            Menu_Terms.Text = "ترم ها";
            Menu_Terms.Click += Menu_Terms_Click;
            // 
            // Menu_Staff
            // 
            Menu_Staff.Name = "Menu_Staff";
            Menu_Staff.Size = new Size (125, 22);
            Menu_Staff.Text = "اساتيد";
            Menu_Staff.Click += Menu_Staff_Click;
            // 
            // Menu_Tech
            // 
            Menu_Tech.Name = "Menu_Tech";
            Menu_Tech.Size = new Size (125, 22);
            Menu_Tech.Text = "کارشناسان";
            Menu_Tech.Click += Menu_Tech_Click;
            // 
            // Menu_4
            // 
            Menu_4.DropDownItems.AddRange (new ToolStripItem [] { M2Templates, ToolStripMenuItem3, Menu_ReProgram_ThisEnteryTerm_inclStaff, Menu_ReProgram_ThisEnteryTerm, Menu_Delete_Entry_TermProg });
            Menu_4.ForeColor = SystemColors.ActiveCaptionText;
            Menu_4.Name = "Menu_4";
            Menu_4.Size = new Size (47, 20);
            Menu_4.Text = "برنامه";
            // 
            // M2Templates
            // 
            M2Templates.Font = new Font ("Segoe UI", 9F);
            M2Templates.Name = "M2Templates";
            M2Templates.Size = new Size (290, 22);
            M2Templates.Text = "برنامه های الگو";
            M2Templates.Click += Menu_Templates;
            // 
            // ToolStripMenuItem3
            // 
            ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            ToolStripMenuItem3.Size = new Size (287, 6);
            // 
            // Menu_ReProgram_ThisEnteryTerm_inclStaff
            // 
            Menu_ReProgram_ThisEnteryTerm_inclStaff.Name = "Menu_ReProgram_ThisEnteryTerm_inclStaff";
            Menu_ReProgram_ThisEnteryTerm_inclStaff.Size = new Size (290, 22);
            Menu_ReProgram_ThisEnteryTerm_inclStaff.Text = "برنامه ريزي مجدد اين ترم (استاد و زمان بندي)";
            Menu_ReProgram_ThisEnteryTerm_inclStaff.Click += Menu_ReProgram_ThisEnteryTerm_inclStaff_Click;
            // 
            // Menu_ReProgram_ThisEnteryTerm
            // 
            Menu_ReProgram_ThisEnteryTerm.Name = "Menu_ReProgram_ThisEnteryTerm";
            Menu_ReProgram_ThisEnteryTerm.Size = new Size (290, 22);
            Menu_ReProgram_ThisEnteryTerm.Text = "برنامه ريزي مجدد اين ترم (فقط  زمان بندي)";
            Menu_ReProgram_ThisEnteryTerm.Click += Menu_ReProgram_ThisEnteryTerm_Click;
            // 
            // Menu_Delete_Entry_TermProg
            // 
            Menu_Delete_Entry_TermProg.ForeColor = Color.IndianRed;
            Menu_Delete_Entry_TermProg.Name = "Menu_Delete_Entry_TermProg";
            Menu_Delete_Entry_TermProg.Size = new Size (290, 22);
            Menu_Delete_Entry_TermProg.Text = "حذف برنامه ورودي (احتياط)";
            Menu_Delete_Entry_TermProg.Click += Menu_Delete_Entry_TermProg_Click;
            // 
            // Menu_Report
            // 
            Menu_Report.DropDownItems.AddRange (new ToolStripItem [] { Menu_ReviewPrograms, ToolStripMenuItem5, Menu_ReportEntriesPrograms, Menu_ReportClassPrograms, Menu_ReportStaffPrograms, Menu_ReportStaffPrograms_Word, Menu_ReportTechPrograms, ToolStripMenuItem10, Menu_UserActivityLogs });
            Menu_Report.ForeColor = SystemColors.ActiveCaptionText;
            Menu_Report.Name = "Menu_Report";
            Menu_Report.Size = new Size (50, 20);
            Menu_Report.Text = "گزارش";
            // 
            // Menu_ReviewPrograms
            // 
            Menu_ReviewPrograms.Font = new Font ("Segoe UI", 9F);
            Menu_ReviewPrograms.ForeColor = Color.IndianRed;
            Menu_ReviewPrograms.Name = "Menu_ReviewPrograms";
            Menu_ReviewPrograms.Size = new Size (162, 22);
            Menu_ReviewPrograms.Text = "مرور برنامه";
            Menu_ReviewPrograms.Click += Menu_ReviewPrograms_Click;
            // 
            // ToolStripMenuItem5
            // 
            ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            ToolStripMenuItem5.Size = new Size (159, 6);
            // 
            // Menu_ReportEntriesPrograms
            // 
            Menu_ReportEntriesPrograms.ForeColor = SystemColors.ControlText;
            Menu_ReportEntriesPrograms.Name = "Menu_ReportEntriesPrograms";
            Menu_ReportEntriesPrograms.Size = new Size (162, 22);
            Menu_ReportEntriesPrograms.Text = "برنامه ورودي ها";
            Menu_ReportEntriesPrograms.Click += Menu_ReportEntriesPrograms_Click;
            // 
            // Menu_ReportClassPrograms
            // 
            Menu_ReportClassPrograms.Name = "Menu_ReportClassPrograms";
            Menu_ReportClassPrograms.Size = new Size (162, 22);
            Menu_ReportClassPrograms.Text = "برنامه کلاس ها";
            Menu_ReportClassPrograms.Click += Menu_ReportClassPrograms_Click;
            // 
            // Menu_ReportStaffPrograms
            // 
            Menu_ReportStaffPrograms.Name = "Menu_ReportStaffPrograms";
            Menu_ReportStaffPrograms.Size = new Size (162, 22);
            Menu_ReportStaffPrograms.Text = "برنامه اساتيد";
            Menu_ReportStaffPrograms.Click += Menu_ReportStaffPrograms_Click;
            // 
            // Menu_ReportStaffPrograms_Word
            // 
            Menu_ReportStaffPrograms_Word.Name = "Menu_ReportStaffPrograms_Word";
            Menu_ReportStaffPrograms_Word.Size = new Size (162, 22);
            Menu_ReportStaffPrograms_Word.Text = "برنامه اساتيد - ورد";
            Menu_ReportStaffPrograms_Word.Click += Menu_ReportStaffPrograms_Word_Click;
            // 
            // Menu_ReportTechPrograms
            // 
            Menu_ReportTechPrograms.Enabled = false;
            Menu_ReportTechPrograms.Name = "Menu_ReportTechPrograms";
            Menu_ReportTechPrograms.Size = new Size (162, 22);
            Menu_ReportTechPrograms.Text = "برنامه کارشناسان";
            Menu_ReportTechPrograms.Visible = false;
            // 
            // ToolStripMenuItem10
            // 
            ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            ToolStripMenuItem10.Size = new Size (159, 6);
            // 
            // Menu_UserActivityLogs
            // 
            Menu_UserActivityLogs.Font = new Font ("Segoe UI", 9F);
            Menu_UserActivityLogs.ForeColor = SystemColors.ActiveCaptionText;
            Menu_UserActivityLogs.Name = "Menu_UserActivityLogs";
            Menu_UserActivityLogs.Size = new Size (162, 22);
            Menu_UserActivityLogs.Text = "گزارش فعاليت";
            Menu_UserActivityLogs.Click += Menu_UserActivityLogs_Click;
            // 
            // Menu_CMD
            // 
            Menu_CMD.BorderStyle = BorderStyle.None;
            Menu_CMD.ForeColor = Color.IndianRed;
            Menu_CMD.Margin = new Padding (5, -1, 100, -1);
            Menu_CMD.Name = "Menu_CMD";
            Menu_CMD.RightToLeft = RightToLeft.No;
            Menu_CMD.Size = new Size (450, 22);
            Menu_CMD.Text = ">";
            Menu_CMD.Visible = false;
            Menu_CMD.TextChanged += Menu_CMD_TextChanged;
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
            Grid4.ContextMenuStrip = PopMenuGrid4;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Grid4.DefaultCellStyle = dataGridViewCellStyle2;
            Grid4.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid4.GridColor = SystemColors.Control;
            Grid4.Location = new Point (13, 28);
            Grid4.MultiSelect = false;
            Grid4.Name = "Grid4";
            Grid4.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 8.25F);
            Grid4.RowsDefaultCellStyle = dataGridViewCellStyle3;
            Grid4.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Grid4.ShowCellToolTips = false;
            Grid4.Size = new Size (892, 416);
            Grid4.TabIndex = 3;
            Grid4.CellClick += Grid4_CellClick;
            Grid4.CellDoubleClick += Grid4_CellDblClick;
            Grid4.KeyDown += Grid4_KeyDown;
            // 
            // PopMenuGrid4
            // 
            PopMenuGrid4.Items.AddRange (new ToolStripItem [] { MenuAddCourse, MenuEditCourse, MenuReplaceCourse, MenuDelCourse, MenuLine1, MenuAddGroup1, MenuAddGroup, MenuEditGroup, MenuSetStaff, MenuDelStaff, MenuSetTech, MenuDelTech, MenuSetClass1, MenuDelClass1, MenuSetClass2, MenuDelClass2, MenuNumberOfStudents, MenuShowCourseNote, MenuShowCourseExamDate });
            PopMenuGrid4.Name = "ContextMenuStrip3";
            PopMenuGrid4.RightToLeft = RightToLeft.Yes;
            PopMenuGrid4.Size = new Size (178, 406);
            // 
            // MenuAddCourse
            // 
            MenuAddCourse.Name = "MenuAddCourse";
            MenuAddCourse.Size = new Size (177, 22);
            MenuAddCourse.Text = "افزودن درس";
            MenuAddCourse.Click += PopMenu_AddCourse;
            // 
            // MenuEditCourse
            // 
            MenuEditCourse.Name = "MenuEditCourse";
            MenuEditCourse.Size = new Size (177, 22);
            MenuEditCourse.Text = "ويرايش";
            MenuEditCourse.Click += MenuEditCourse_Click;
            // 
            // MenuReplaceCourse
            // 
            MenuReplaceCourse.Name = "MenuReplaceCourse";
            MenuReplaceCourse.Size = new Size (177, 22);
            MenuReplaceCourse.Text = "انتقال به ترم  ...";
            MenuReplaceCourse.Click += Menu_ReplaceCourse;
            // 
            // MenuDelCourse
            // 
            MenuDelCourse.ForeColor = Color.IndianRed;
            MenuDelCourse.Name = "MenuDelCourse";
            MenuDelCourse.Size = new Size (177, 22);
            MenuDelCourse.Text = "حذف";
            MenuDelCourse.Click += PopMenu_DelCourse;
            // 
            // MenuLine1
            // 
            MenuLine1.Name = "MenuLine1";
            MenuLine1.Size = new Size (174, 6);
            // 
            // MenuAddGroup1
            // 
            MenuAddGroup1.Name = "MenuAddGroup1";
            MenuAddGroup1.Size = new Size (177, 22);
            MenuAddGroup1.Text = "افزودن گروه (سکشن)";
            MenuAddGroup1.Click += MenuAddGroup1_Click;
            // 
            // MenuAddGroup
            // 
            MenuAddGroup.Name = "MenuAddGroup";
            MenuAddGroup.Size = new Size (177, 22);
            MenuAddGroup.Text = "افزودن گروه (سکشن)";
            MenuAddGroup.Click += PopMenu_AddGroup;
            // 
            // MenuEditGroup
            // 
            MenuEditGroup.Name = "MenuEditGroup";
            MenuEditGroup.Size = new Size (177, 22);
            MenuEditGroup.Text = "ويرايش";
            MenuEditGroup.Click += MenuEditGroup_Click;
            // 
            // MenuSetStaff
            // 
            MenuSetStaff.Name = "MenuSetStaff";
            MenuSetStaff.Size = new Size (177, 22);
            MenuSetStaff.Text = "تعيين استاد درس";
            MenuSetStaff.Click += MenuSetStaff_Click;
            // 
            // MenuDelStaff
            // 
            MenuDelStaff.ForeColor = Color.IndianRed;
            MenuDelStaff.Name = "MenuDelStaff";
            MenuDelStaff.Size = new Size (177, 22);
            MenuDelStaff.Text = "حذف";
            MenuDelStaff.Click += MenuDelStaff_Click;
            // 
            // MenuSetTech
            // 
            MenuSetTech.Name = "MenuSetTech";
            MenuSetTech.Size = new Size (177, 22);
            MenuSetTech.Text = "تعيين کارشناس درس";
            MenuSetTech.Click += MenuSetTech_Click;
            // 
            // MenuDelTech
            // 
            MenuDelTech.ForeColor = Color.IndianRed;
            MenuDelTech.Name = "MenuDelTech";
            MenuDelTech.Size = new Size (177, 22);
            MenuDelTech.Text = "حذف";
            MenuDelTech.Click += MenuDelTech_Click;
            // 
            // MenuSetClass1
            // 
            MenuSetClass1.Name = "MenuSetClass1";
            MenuSetClass1.Size = new Size (177, 22);
            MenuSetClass1.Text = "تعيين کلاس 1";
            MenuSetClass1.Click += MenuSetClass1_Click;
            // 
            // MenuDelClass1
            // 
            MenuDelClass1.Name = "MenuDelClass1";
            MenuDelClass1.Size = new Size (177, 22);
            MenuDelClass1.Text = "حذف کلاس 1";
            MenuDelClass1.Click += MenuDelClass1_Click;
            // 
            // MenuSetClass2
            // 
            MenuSetClass2.Name = "MenuSetClass2";
            MenuSetClass2.Size = new Size (177, 22);
            MenuSetClass2.Text = "تعيين کلاس 2";
            MenuSetClass2.Click += MenuSetClass2_Click;
            // 
            // MenuDelClass2
            // 
            MenuDelClass2.Name = "MenuDelClass2";
            MenuDelClass2.Size = new Size (177, 22);
            MenuDelClass2.Text = "حذف کلاس 2";
            MenuDelClass2.Click += MenuDelClass2_Click;
            // 
            // MenuNumberOfStudents
            // 
            MenuNumberOfStudents.Name = "MenuNumberOfStudents";
            MenuNumberOfStudents.Size = new Size (177, 22);
            MenuNumberOfStudents.Text = "تعداد دانشجويان";
            MenuNumberOfStudents.Click += MenuNumberOfStudents_Click;
            // 
            // MenuShowCourseNote
            // 
            MenuShowCourseNote.Checked = true;
            MenuShowCourseNote.CheckState = CheckState.Checked;
            MenuShowCourseNote.Name = "MenuShowCourseNote";
            MenuShowCourseNote.Size = new Size (177, 22);
            MenuShowCourseNote.Text = "ستون يادداشت ها";
            MenuShowCourseNote.Click += MenuShowCourseNote_Click;
            // 
            // MenuShowCourseExamDate
            // 
            MenuShowCourseExamDate.Name = "MenuShowCourseExamDate";
            MenuShowCourseExamDate.Size = new Size (177, 22);
            MenuShowCourseExamDate.Text = "ستون تاريخ امتحانات";
            MenuShowCourseExamDate.Click += MenuShowCourseExamDate_Click;
            // 
            // ListBox1
            // 
            ListBox1.BackColor = Color.WhiteSmoke;
            ListBox1.BorderStyle = BorderStyle.None;
            ListBox1.ContextMenuStrip = PopMenuGridTermic;
            ListBox1.Font = new Font ("Segoe UI", 10F);
            ListBox1.ForeColor = Color.Brown;
            ListBox1.FormattingEnabled = true;
            ListBox1.ItemHeight = 17;
            ListBox1.Location = new Point (922, 138);
            ListBox1.Name = "ListBox1";
            ListBox1.RightToLeft = RightToLeft.Yes;
            ListBox1.Size = new Size (354, 306);
            ListBox1.TabIndex = 1;
            ListBox1.Click += ListBox1_Click;
            ListBox1.KeyDown += ListBox1_KeyDown;
            // 
            // PopMenuGridTermic
            // 
            PopMenuGridTermic.Items.AddRange (new ToolStripItem [] { Menu_EntryProg_AllTerms, ToolStripMenuItem7, Menu_Guide, Menu_ExitNexTerm });
            PopMenuGridTermic.Name = "ContextMenuStrip3";
            PopMenuGridTermic.RightToLeft = RightToLeft.Yes;
            PopMenuGridTermic.Size = new Size (188, 76);
            // 
            // Menu_EntryProg_AllTerms
            // 
            Menu_EntryProg_AllTerms.Enabled = false;
            Menu_EntryProg_AllTerms.Name = "Menu_EntryProg_AllTerms";
            Menu_EntryProg_AllTerms.Size = new Size (187, 22);
            Menu_EntryProg_AllTerms.Text = "برنامه ترميک اين ورودي";
            Menu_EntryProg_AllTerms.Click += Menu_EntryProg_AllTerms_Click;
            // 
            // ToolStripMenuItem7
            // 
            ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            ToolStripMenuItem7.Size = new Size (184, 6);
            // 
            // Menu_Guide
            // 
            Menu_Guide.Name = "Menu_Guide";
            Menu_Guide.Size = new Size (187, 22);
            Menu_Guide.Text = "راهنما";
            Menu_Guide.Visible = false;
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // Menu_ExitNexTerm
            // 
            Menu_ExitNexTerm.ForeColor = Color.IndianRed;
            Menu_ExitNexTerm.Name = "Menu_ExitNexTerm";
            Menu_ExitNexTerm.Size = new Size (187, 22);
            Menu_ExitNexTerm.Text = "خروج از برنامه";
            Menu_ExitNexTerm.Click += Menu_ExitNexTerm_Click;
            // 
            // ComboBox1
            // 
            ComboBox1.BackColor = Color.WhiteSmoke;
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox1.FlatStyle = FlatStyle.Flat;
            ComboBox1.Font = new Font ("Segoe UI", 11F);
            ComboBox1.ForeColor = SystemColors.ActiveCaptionText;
            ComboBox1.FormattingEnabled = true;
            ComboBox1.Location = new Point (922, 28);
            ComboBox1.Name = "ComboBox1";
            ComboBox1.Size = new Size (355, 28);
            ComboBox1.TabIndex = 0;
            ComboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            ComboBox1.KeyDown += ComboBox1_KeyDown;
            // 
            // ListBox2
            // 
            ListBox2.BackColor = Color.WhiteSmoke;
            ListBox2.BorderStyle = BorderStyle.None;
            ListBox2.ContextMenuStrip = PopMenuTerms;
            ListBox2.Font = new Font ("Segoe UI", 10.25F);
            ListBox2.FormattingEnabled = true;
            ListBox2.ItemHeight = 19;
            ListBox2.Location = new Point (922, 62);
            ListBox2.Name = "ListBox2";
            ListBox2.RightToLeft = RightToLeft.No;
            ListBox2.Size = new Size (354, 57);
            ListBox2.TabIndex = 2;
            ListBox2.Click += ListBox2_Click;
            // 
            // PopMenuTerms
            // 
            PopMenuTerms.Items.AddRange (new ToolStripItem [] { Menu_TermsDefault_Set, Menu_TermsDefault_Clear });
            PopMenuTerms.Name = "ContextMenuTerms";
            PopMenuTerms.RightToLeft = RightToLeft.Yes;
            PopMenuTerms.Size = new Size (153, 48);
            // 
            // Menu_TermsDefault_Set
            // 
            Menu_TermsDefault_Set.Name = "Menu_TermsDefault_Set";
            Menu_TermsDefault_Set.Size = new Size (152, 22);
            Menu_TermsDefault_Set.Text = "ترم پيش فرض";
            Menu_TermsDefault_Set.Click += Menu_TermsDefault_Set_Click;
            // 
            // Menu_TermsDefault_Clear
            // 
            Menu_TermsDefault_Clear.Name = "Menu_TermsDefault_Clear";
            Menu_TermsDefault_Clear.Size = new Size (152, 22);
            Menu_TermsDefault_Clear.Text = "بدون پيش فرض";
            Menu_TermsDefault_Clear.Click += Menu_TermsDefault_Clear_Click;
            // 
            // PopMenuGridTime
            // 
            PopMenuGridTime.Font = new Font ("Segoe UI", 9F);
            PopMenuGridTime.Items.AddRange (new ToolStripItem [] { PopMenu_SaveWeek, ToolStripMenuItem4, MenuGridTimeReport });
            PopMenuGridTime.Name = "ContextMenuStrip1";
            PopMenuGridTime.RightToLeft = RightToLeft.Yes;
            PopMenuGridTime.Size = new Size (127, 54);
            // 
            // PopMenu_SaveWeek
            // 
            PopMenu_SaveWeek.Font = new Font ("Segoe UI", 9F);
            PopMenu_SaveWeek.ForeColor = Color.IndianRed;
            PopMenu_SaveWeek.Name = "PopMenu_SaveWeek";
            PopMenu_SaveWeek.Size = new Size (126, 22);
            PopMenu_SaveWeek.Text = "ذخيره شود";
            PopMenu_SaveWeek.Click += PopMenu_SaveWeekGrid;
            // 
            // ToolStripMenuItem4
            // 
            ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            ToolStripMenuItem4.Size = new Size (123, 6);
            // 
            // MenuGridTimeReport
            // 
            MenuGridTimeReport.Name = "MenuGridTimeReport";
            MenuGridTimeReport.Size = new Size (126, 22);
            MenuGridTimeReport.Text = "گزارش";
            MenuGridTimeReport.Click += MenuGridTimeReport_Click;
            // 
            // txtExamDate
            // 
            txtExamDate.BackColor = Color.White;
            txtExamDate.BorderStyle = BorderStyle.None;
            txtExamDate.ContextMenuStrip = PopMenuGridTime;
            txtExamDate.Font = new Font ("Courier New", 12F);
            txtExamDate.ForeColor = Color.IndianRed;
            txtExamDate.Location = new Point (13, 545);
            txtExamDate.Mask = "0000.00.00 (00:00)";
            txtExamDate.Name = "txtExamDate";
            txtExamDate.PromptChar = '-';
            txtExamDate.RightToLeft = RightToLeft.No;
            txtExamDate.Size = new Size (196, 19);
            txtExamDate.TabIndex = 27;
            txtExamDate.Tag = "";
            txtExamDate.Text = "130000000830";
            txtExamDate.TextAlign = HorizontalAlignment.Center;
            txtExamDate.ValidatingType = typeof (DateTime);
            txtExamDate.Visible = false;
            txtExamDate.Click += txtExamDate_Click;
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
            GridTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTime.Columns.AddRange (new DataGridViewColumn [] { Dayx, DataGridViewTextBoxColumn1, DataGridViewTextBoxColumn2, DataGridViewTextBoxColumn3, t1130, t1330, t1430, t1530, t1630 });
            GridTime.ContextMenuStrip = PopMenuGridTime;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            GridTime.DefaultCellStyle = dataGridViewCellStyle4;
            GridTime.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTime.GridColor = SystemColors.Control;
            GridTime.Location = new Point (219, 451);
            GridTime.Name = "GridTime";
            GridTime.RightToLeft = RightToLeft.Yes;
            GridTime.RowHeadersVisible = false;
            GridTime.ShowCellToolTips = false;
            GridTime.Size = new Size (686, 177);
            GridTime.TabIndex = 32;
            GridTime.Visible = false;
            GridTime.CellClick += GridTime_CellClick;
            // 
            // Dayx
            // 
            Dayx.HeaderText = "روز";
            Dayx.Name = "Dayx";
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
            // lblExamDate
            // 
            lblExamDate.AutoSize = true;
            lblExamDate.BackColor = Color.Transparent;
            lblExamDate.Font = new Font ("Segoe UI", 10F);
            lblExamDate.ForeColor = SystemColors.ActiveCaptionText;
            lblExamDate.Location = new Point (70, 567);
            lblExamDate.Name = "lblExamDate";
            lblExamDate.Size = new Size (80, 19);
            lblExamDate.TabIndex = 33;
            lblExamDate.Text = "تاريخ امتحان";
            lblExamDate.Visible = false;
            lblExamDate.Click += lblExamDate_Click;
            // 
            // GridWeek
            // 
            GridWeek.AllowUserToAddRows = false;
            GridWeek.AllowUserToDeleteRows = false;
            GridWeek.AllowUserToResizeColumns = false;
            GridWeek.AllowUserToResizeRows = false;
            GridWeek.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridWeek.BackgroundColor = Color.WhiteSmoke;
            GridWeek.BorderStyle = BorderStyle.None;
            GridWeek.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridWeek.Columns.AddRange (new DataGridViewColumn [] { DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5, DataGridViewTextBoxColumn6, DataGridViewTextBoxColumn7, DataGridViewTextBoxColumn8, DataGridViewTextBoxColumn9, DataGridViewTextBoxColumn10, DataGridViewTextBoxColumn11, DataGridViewTextBoxColumn12 });
            GridWeek.ContextMenuStrip = PopMenuGridWeek;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            GridWeek.DefaultCellStyle = dataGridViewCellStyle5;
            GridWeek.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridWeek.GridColor = SystemColors.Control;
            GridWeek.Location = new Point (922, 451);
            GridWeek.MultiSelect = false;
            GridWeek.Name = "GridWeek";
            GridWeek.RightToLeft = RightToLeft.Yes;
            GridWeek.RowHeadersVisible = false;
            GridWeek.ShowCellToolTips = false;
            GridWeek.Size = new Size (355, 177);
            GridWeek.TabIndex = 35;
            GridWeek.Visible = false;
            GridWeek.CellClick += GridWeek_CellClick;
            // 
            // DataGridViewTextBoxColumn4
            // 
            DataGridViewTextBoxColumn4.HeaderText = "روز";
            DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
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
            // PopMenuGridWeek
            // 
            PopMenuGridWeek.Items.AddRange (new ToolStripItem [] { MenuGridWeekReport, MenuGridWeek_Export });
            PopMenuGridWeek.Name = "ContextMenuGridWeek";
            PopMenuGridWeek.RightToLeft = RightToLeft.Yes;
            PopMenuGridWeek.Size = new Size (152, 48);
            // 
            // MenuGridWeekReport
            // 
            MenuGridWeekReport.Name = "MenuGridWeekReport";
            MenuGridWeekReport.Size = new Size (151, 22);
            MenuGridWeekReport.Text = "گزارش برنامه";
            MenuGridWeekReport.Click += MenuGridWeekReport_Click;
            // 
            // MenuGridWeek_Export
            // 
            MenuGridWeek_Export.Name = "MenuGridWeek_Export";
            MenuGridWeek_Export.Size = new Size (151, 22);
            MenuGridWeek_Export.Text = "ذخيره در فايل ...";
            MenuGridWeek_Export.Click += MenuGridWeek_Export_Click;
            // 
            // lblCourse
            // 
            lblCourse.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
            lblCourse.BackColor = Color.Transparent;
            lblCourse.ForeColor = Color.DarkRed;
            lblCourse.Location = new Point (345, 632);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size (560, 18);
            lblCourse.TabIndex = 38;
            lblCourse.Text = "برنامه هفتگي اين درس";
            lblCourse.Visible = false;
            // 
            // lbl_UserInactiveProg
            // 
            lbl_UserInactiveProg.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
            lbl_UserInactiveProg.BackColor = Color.Transparent;
            lbl_UserInactiveProg.Font = new Font ("Segoe UI", 7F);
            lbl_UserInactiveProg.ForeColor = Color.Crimson;
            lbl_UserInactiveProg.Location = new Point (117, 478);
            lbl_UserInactiveProg.Name = "lbl_UserInactiveProg";
            lbl_UserInactiveProg.RightToLeft = RightToLeft.Yes;
            lbl_UserInactiveProg.Size = new Size (64, 18);
            lbl_UserInactiveProg.TabIndex = 41;
            lbl_UserInactiveProg.Text = "برنامه ريزي";
            lbl_UserInactiveProg.TextAlign = ContentAlignment.MiddleLeft;
            lbl_UserInactiveProg.Visible = false;
            // 
            // lbl_UserInactiveClass
            // 
            lbl_UserInactiveClass.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
            lbl_UserInactiveClass.BackColor = Color.Transparent;
            lbl_UserInactiveClass.Font = new Font ("Segoe UI", 7F);
            lbl_UserInactiveClass.ForeColor = Color.Crimson;
            lbl_UserInactiveClass.Location = new Point (33, 478);
            lbl_UserInactiveClass.Name = "lbl_UserInactiveClass";
            lbl_UserInactiveClass.RightToLeft = RightToLeft.Yes;
            lbl_UserInactiveClass.Size = new Size (64, 18);
            lbl_UserInactiveClass.TabIndex = 42;
            lbl_UserInactiveClass.Text = "کلاس بندي";
            lbl_UserInactiveClass.TextAlign = ContentAlignment.MiddleLeft;
            lbl_UserInactiveClass.Visible = false;
            // 
            // lbl_UserType
            // 
            lbl_UserType.BackColor = Color.Transparent;
            lbl_UserType.Font = new Font ("Segoe UI", 8F);
            lbl_UserType.ForeColor = Color.Black;
            lbl_UserType.Location = new Point (13, 455);
            lbl_UserType.Name = "lbl_UserType";
            lbl_UserType.RightToLeft = RightToLeft.Yes;
            lbl_UserType.Size = new Size (168, 18);
            lbl_UserType.TabIndex = 43;
            lbl_UserType.Text = "کاربر: دانشکده";
            lbl_UserType.TextAlign = ContentAlignment.MiddleCenter;
            lbl_UserType.DoubleClick += lbl_UserType_DoubleClick;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add (lblExit);
            Panel1.Dock = DockStyle.Bottom;
            Panel1.Location = new Point (0, 666);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size (1289, 20);
            Panel1.TabIndex = 44;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (0, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (1289, 20);
            lblExit.TabIndex = 46;
            lblExit.Text = "خروج";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // lblClss2
            // 
            lblClss2.AutoSize = true;
            lblClss2.BackColor = Color.MistyRose;
            lblClss2.ForeColor = Color.Red;
            lblClss2.Location = new Point (219, 632);
            lblClss2.Name = "lblClss2";
            lblClss2.Size = new Size (43, 15);
            lblClss2.TabIndex = 45;
            lblClss2.Text = "کلاس 2";
            // 
            // lblClss1
            // 
            lblClss1.AutoSize = true;
            lblClss1.BackColor = Color.LightCyan;
            lblClss1.ForeColor = Color.RoyalBlue;
            lblClss1.Location = new Point (268, 632);
            lblClss1.Name = "lblClss1";
            lblClss1.Size = new Size (40, 15);
            lblClss1.TabIndex = 45;
            lblClss1.Text = "کلاس 1";
            // 
            // lblExtraUnitsError
            // 
            lblExtraUnitsError.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
            lblExtraUnitsError.BackColor = Color.IndianRed;
            lblExtraUnitsError.Font = new Font ("Segoe UI", 9F);
            lblExtraUnitsError.ForeColor = Color.White;
            lblExtraUnitsError.Location = new Point (52, 608);
            lblExtraUnitsError.Name = "lblExtraUnitsError";
            lblExtraUnitsError.RightToLeft = RightToLeft.Yes;
            lblExtraUnitsError.Size = new Size (119, 22);
            lblExtraUnitsError.TabIndex = 45;
            lblExtraUnitsError.Text = "تعداد ساعات";
            lblExtraUnitsError.TextAlign = ContentAlignment.MiddleCenter;
            lblExtraUnitsError.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point (922, 639);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size (355, 11);
            progressBar1.TabIndex = 46;
            progressBar1.Visible = false;
            // 
            // frmTermProgs
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (1289, 686);
            Controls.Add (progressBar1);
            Controls.Add (lblCourse);
            Controls.Add (lblClss2);
            Controls.Add (lblClss1);
            Controls.Add (lbl_UserInactiveProg);
            Controls.Add (lbl_UserInactiveClass);
            Controls.Add (lblExtraUnitsError);
            Controls.Add (lbl_UserType);
            Controls.Add (Panel1);
            Controls.Add (GridWeek);
            Controls.Add (lblExamDate);
            Controls.Add (GridTime);
            Controls.Add (txtExamDate);
            Controls.Add (ListBox2);
            Controls.Add (ComboBox1);
            Controls.Add (ListBox1);
            Controls.Add (Grid4);
            Controls.Add (MenuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "frmTermProgs";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NexTerm";
            FormClosing += frmTermProgs_FormClosing;
            Load += frmTermProgs_Load;
            KeyDown += frmTermProgs_KeyDown;
            MenuStrip1.ResumeLayout (false);
            MenuStrip1.PerformLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid4).EndInit ();
            PopMenuGrid4.ResumeLayout (false);
            PopMenuGridTermic.ResumeLayout (false);
            PopMenuTerms.ResumeLayout (false);
            PopMenuGridTime.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridTime).EndInit ();
            ((System.ComponentModel.ISupportInitialize) GridWeek).EndInit ();
            PopMenuGridWeek.ResumeLayout (false);
            Panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem Menu_BioPorogs;
        internal ToolStripMenuItem Menu_4;
        internal ToolStripMenuItem M2Templates;
        internal DataGridView Grid4;
        internal ListBox ListBox1;
        internal ComboBox ComboBox1;
        internal ListBox ListBox2;
        internal MaskedTextBox txtExamDate;
        internal ContextMenuStrip PopMenuGrid4;
        internal ToolStripMenuItem MenuAddCourse;
        internal ToolStripMenuItem MenuDelCourse;
        internal ToolStripMenuItem MenuReplaceCourse;
        internal ToolStripMenuItem MenuAddGroup;
        internal ToolStripComboBox Menu_User;
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
        internal Label lblExamDate;
        internal DataGridView GridWeek;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn8;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn9;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn10;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn11;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn12;
        internal Label lblWeek;
        internal ContextMenuStrip PopMenuGridTime;
        internal ToolStripMenuItem PopMenu_SaveWeek;
        internal Label lblCourse;
        internal ToolStripMenuItem Menu_Delete_Entry_TermProg;
        internal ToolStripMenuItem Menu_1;
        internal ToolStripMenuItem Menu_Userx;
        internal ToolStripMenuItem Menu_Settings;
        internal ToolStripMenuItem Menu_About;
        internal ToolStripMenuItem Menu_Quit;
        internal ToolStripMenuItem Menu_2;
        internal ToolStripMenuItem Menu_Courses;
        internal ToolStripMenuItem Menu_Classes;
        internal ToolStripMenuItem Menu_Terms;
        internal ToolStripMenuItem Menu_Staff;
        internal ToolStripMenuItem Menu_Tech;
        internal ToolStripSeparator ToolStripMenuItem3;
        internal ContextMenuStrip PopMenuGridWeek;
        internal ToolStripMenuItem MenuGridWeekReport;
        internal ToolStripMenuItem MenuGridTimeReport;
        internal ToolStripSeparator ToolStripMenuItem4;
        internal ToolStripMenuItem Menu_ReProgram_ThisEnteryTerm;
        internal ToolStripMenuItem Menu_ChangePass;
        internal ContextMenuStrip PopMenuGridTermic;
        internal ToolStripMenuItem Menu_ExitNexTerm;
        internal ToolStripMenuItem Menu_EntryProg_AllTerms;
        internal ToolStripSeparator ToolStripMenuItem7;
        internal MonthCalendar Calendar1;
        internal Label lbl_UserInactiveClass;
        internal ToolStripMenuItem MenuDelClass1;
        internal ToolStripMenuItem MenuDelClass2;
        internal ToolStripMenuItem Menu_Report;
        internal ToolStripMenuItem Menu_UserActivityLogs;
        internal ToolStripMenuItem Menu_ReportStaffPrograms;
        internal ToolStripMenuItem Menu_ReportTechPrograms;
        internal ToolStripMenuItem Menu_ReportClassPrograms;
        internal ToolStripMenuItem Menu_ReProgram_ThisEnteryTerm_inclStaff;
        internal ToolStripMenuItem Menu_Departments;
        internal ToolStripSeparator ToolStripMenuItem5;
        internal ToolStripMenuItem Menu_ReportEntriesPrograms;
        internal Label lbl_UserInactiveProg;
        internal Label lbl_UserType;
        internal ContextMenuStrip PopMenuTerms;
        internal ToolStripMenuItem Menu_TermsDefault_Set;
        internal ToolStripMenuItem Menu_TermsDefault_Clear;
        internal ToolStripTextBox DToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem10;
        internal ToolStripTextBox txtCMD1;
        internal ToolStripMenuItem MenuGridWeek_Export;
        internal ToolStripTextBox Menu_CMDLine;
        internal ToolStripSeparator ToolStripMenuItem8;
        internal ToolStripMenuItem Menu_Messenger;
        internal ToolStripMenuItem Menu_ReviewPrograms;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem MenuShowCourseNote;
        internal ToolStripMenuItem MenuShowCourseExamDate;
        internal ToolStripTextBox ToolStripTextBox1;
        internal ToolStripMenuItem Menu_Guide;
        internal Panel Panel1;
        internal Label lblClss1;
        internal Label lblClss2;
        internal Label lblExtraUnitsError;
        private ToolStripMenuItem MenuEditCourse;
        private ToolStripMenuItem MenuEditGroup;
        private ToolStripMenuItem MenuSetStaff;
        private ToolStripMenuItem MenuDelStaff;
        private ToolStripMenuItem تعيينکارشناسToolStripMenuItem;
        private ToolStripMenuItem MenuDelTech;
        private ToolStripMenuItem MenuSetClass1;
        private ToolStripMenuItem MenuSetClass2;
        private ToolStripMenuItem MenuNumberOfStudents;
        private ToolStripMenuItem MenuSetTech;
        private ToolStripMenuItem MenuAddGroup1;
        private ToolStripSeparator MenuLine1;
        private ToolStripTextBox Menu_CMD;
        private ToolStripMenuItem Menu_ReportStaffPrograms_Word;
        private Label lblExit;
        private ProgressBar progressBar1;
        }
    }