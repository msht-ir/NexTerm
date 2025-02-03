using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {

    public partial class frmReportSettings
        {
        public frmReportSettings ()
            {
            InitializeComponent ();
            }
        private void frmReportSettings_Load (object sender, EventArgs e)
            {
            /* 
             * Flags of ReportSettings Register
             * 0  1   : &H1   Remember Settings
             * 1  2   : &H2   Report con Details
             * 2  4   : &H4   Day in Cols:0/Rows:1
             * 3  8   : &H8   Show CourseName
             * 4  16  : &H10  Show CourseNr
             * 5  32  : &H20  Show Group
             * 6  64  : &H40  Show ExamDate
             * 7  128 : &H80  BG 1/0
             * 8  256 : &H100 Show free times (in Day in Col mode)
             * 9  512 : &H200 Show suggestion for Tadakhols
             * 10 1024: &H400 Show ExamDate Table
            */
            if ((Report.Settings & 0x1) == 0x1) //Remember Settings ? YES
                {
                CheckBoxRememberSettings.Checked = true;
                if ((Report.Settings & 0x2) == 0x2)
                    {
                    CheckBoxDetails.Checked = true;
                    }
                else
                    {
                    CheckBoxDetails.Checked = false;
                    }
                if ((Report.Settings & 0x4) == 0x4)
                    {
                    RadioDaysInRows.Checked = true;
                    RadioDaysInCols.Checked = false;
                    }
                else
                    {
                    RadioDaysInRows.Checked = false;
                    RadioDaysInCols.Checked = true;
                    }
                if ((Report.Settings & 0x8) == 0x8)
                    {
                    CheckBoxCourseName.Checked = true;
                    }
                else
                    {
                    CheckBoxCourseName.Checked = false;
                    }
                if ((Report.Settings & 0x10) == 0x10)
                    {
                    CheckBoxCourseNumber.Checked = true;
                    }
                else
                    {
                    CheckBoxCourseNumber.Checked = false;
                    }
                if ((Report.Settings & 0x20) == 0x20)
                    {
                    CheckBoxCourseGroup.Checked = true;
                    }
                else
                    {
                    CheckBoxCourseGroup.Checked = false;
                    }
                if ((Report.Settings & 0x40) == 0x40)
                    {
                    CheckBoxExamDate.Checked = true;
                    }
                else
                    {
                    CheckBoxExamDate.Checked = false;
                    }
                if ((Report.Settings & 0x80) == 0x80)
                    {
                    CheckBoxBG.Checked = true;
                    }
                else
                    {
                    CheckBoxBG.Checked = false;
                    }
                if ((Report.Settings & 0x100) == 0x100)
                    {
                    CheckBoxFreeTimes.Checked = true;
                    }
                else
                    {
                    CheckBoxFreeTimes.Checked = false;
                    }
                if ((Report.Settings & 0x200) == 0x200)
                    {
                    CheckBoxSuggest.Checked = true;
                    }
                else
                    {
                    CheckBoxSuggest.Checked = false;
                    }
                if ((Report.Settings & 0x400) == 0x400)
                    {
                    CheckBoxExamTable.Checked = true;
                    }
                else
                    {
                    CheckBoxExamTable.Checked = false;
                    }
                }
            else //Remember Settings ? NO
                {
                CheckBoxRememberSettings.Checked = false;
                }
            //TermsTable
            try
                {
                NxDb.DS.Tables ["tblTerms"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM Terms WHERE Terms.Active = 1 ORDER BY Term", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            //Depts
            cboDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            cboDepts.DisplayMember = "DEPT";
            cboDepts.ValueMember = "ID";
            cboDepts.SelectedValue = User.Id;
            // Terms
            cboTerms.DataSource = NxDb.DS.Tables ["tblterms"];
            cboTerms.DisplayMember = "Term";
            cboTerms.ValueMember = "ID";
            cboTerms.SelectedValue = Term.Id;
            CheckBoxDetails_CheckedChanged (sender, e);
            if (Department.Id > 0L)
                cboDepts.SelectedValue = Department.Id;
            if (Term.Id > 0L)
                cboTerms.SelectedValue = Term.Id;
            }
        private void CheckBoxDetails_CheckedChanged (object sender, EventArgs e)
            {
            bool boolEnable = false;
            if (CheckBoxDetails.Checked == false)
                boolEnable = false;
            else
                boolEnable = true;
            //
            CheckBoxSuggest.Enabled = boolEnable;
            CheckBoxFreeTimes.Enabled = true; //allways enabled
            CheckBoxExamTable.Enabled = boolEnable;
            CheckBoxSuggest.Enabled = boolEnable;
            RadioDaysInCols.Enabled = boolEnable;
            RadioDaysInRows.Enabled = boolEnable;
            CheckBoxCourseName.Enabled = boolEnable;
            CheckBoxCourseNumber.Enabled = boolEnable;
            CheckBoxCourseGroup.Enabled = boolEnable;
            CheckBoxExamDate.Enabled = boolEnable;
            if (CheckBoxDetails.Checked == false)
                CheckBoxFreeTimes.Checked = true;
            RadioDaysInCols_CheckedChanged (sender, e);
            }
        private void CheckBoxFreeTimes_CheckedChanged (object sender, EventArgs e)
            {
            if (CheckBoxFreeTimes.Checked == false)
                CheckBoxDetails.Checked = true;
            }
        private void RadioDaysInCols_CheckedChanged (object sender, EventArgs e)
            {
            bool boolEnable = false;
            if (RadioDaysInRows.Checked == false)
                boolEnable = false;
            else
                boolEnable = true;
            CheckBoxCourseName.Enabled = boolEnable;
            CheckBoxCourseNumber.Enabled = boolEnable;
            CheckBoxCourseGroup.Enabled = boolEnable;
            CheckBoxExamDate.Enabled = boolEnable;
            }
        //SET ReportSettings bits
        private void SetReportSettings ()
            {
            Report.Settings = 0;
            /*
             * Flags of ReportSettings Register
             * 0  1   : &H1   Remember Settings
             * 1  2   : &H2   Report con Details
             * 2  4   : &H4   Day in Cols:0/Rows:1
             * 3  8   : &H8   Show CourseName
             * 4  16  : &H10  Show CourseNr
             * 5  32  : &H20  Show Group
             * 6  64  : &H40  Show ExamDate
             * 7  128 : &H80  BG 1/0
             * 8  256 : &H100 Show free times (in Day in Col mode)
             * 9  512 : &H200 Show suggestion for Tadakhols
             * 10 1024: &H400 Show ExamDate Table
            */
            if (CheckBoxRememberSettings.Checked == true)
                Report.Settings = 0x1;
            else
                Report.Settings = 0x0;
            if (CheckBoxDetails.Checked == true)
                Report.Settings = Report.Settings | 0x2;
            if (RadioDaysInRows.Checked == true)
                Report.Settings = Report.Settings | 0x4;    //Cols:0/Rows:1
            if (CheckBoxCourseName.Checked == true)
                Report.Settings = Report.Settings | 0x8;
            if (CheckBoxCourseNumber.Checked == true)
                Report.Settings = Report.Settings | 0x10;   //16
            if (CheckBoxCourseGroup.Checked == true)
                Report.Settings = Report.Settings | 0x20;   //32
            if (CheckBoxExamDate.Checked == true)
                Report.Settings = Report.Settings | 0x40;   //64
            if (CheckBoxBG.Checked == true)
                Report.Settings = Report.Settings | 0x80;   //128
            if (CheckBoxFreeTimes.Checked == true)
                Report.Settings = Report.Settings | 0x100;  //256
            if (CheckBoxSuggest.Checked == true)
                Report.Settings = Report.Settings | 0x200;  //512
            if (CheckBoxExamTable.Checked == true)
                Report.Settings = Report.Settings | 0x400;  //1024
            }

        // POPMENU
        private void Menu_Guide_Click (object sender, EventArgs e)
            {
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=\"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>راهنما</title>");
            FileSystem.PrintLine (1, Report.Style); //strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>دانشکده علوم پايه، دانشگاه شهرکرد</p>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:blue;font-family:tahoma; font-size:14px'>راهنماي گزينه هاي تنظيمات گزارش در نکسترم<br></p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>تنظيمات را به خاطر بسپار</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>با اين گزينه تا وقتي از نکسترم خارج نشده باشيد تنظيمات اين بخش براي گزارش هاي بعد حفظ مي شوند و نيازي به تکرار تنظيمات نيست</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>گزارش با جزئيات</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>با غير فعال کردن اين گزينه، فقط محل برنامه ها روي جدول هفتگي با عدد 1 نشان داده مي شوند و تداخل ها با اعداد بزرگتر از 1 نشان داده مي شوند</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>پيشنهاد رفع تداخل</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>با اين گزينه درصورت وجود تداخل در برنامه، يکي از موارد به عنوان پيشنهاد نشان داده مي شود. يعني با تغيير زمانبندي آن درس ويا تغيير کلاس (بنا به مورد) مي توان تداخل را برطرف نمود </p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>جدول ساعت هاي ازاد</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>با انتخاب اين گزينه در زير جدول اصلي جدول برنامه هفتگي نشان داده مي شود که در آن محل برنامه ها با عدد 1 و تداخل ها با اعداد بزرگتر از 1 نشان داده مي شوند </p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>جدول تاريخ امتحانات</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>با انتخاب اين گزينه، جدول برنامه امتحانات که در ان درس ها به ترتيب تاريخ امتخان مرتب شده اند نشان داده مي شود. تاريخ/ساعت امتحانات را مي توان در نمايش (روزهاي هفته در سطر) نيز همراه با نام درس نشان داد</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>روزهاي هفته در سطر</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در اين نوع نمايش برنامه ها، روز هاي هفته در سطرها و ساعات روز در ستون ها هستند و در داخل جدول نام درس همراه با جزييات ديگر نشان داده مي شود</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>نام درس</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) نام درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>شماره درس</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) شماره درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>شماره گروه درس</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) شماره گروه درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>ساعت و تاريخ امتحان</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) ساعت و تاريخ امتحان درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>روزهاي هفته در ستون</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در اين نوع نمايش برنامه ها، هر سطر به يک درس از برنامه اختصاص دارد و روزهاي هفته همراه با نام، شماره، واحد، گروه و ... ساير مشخصات درس، در ستون ها قرار دارند. درون جدول در (همان سطر) ساعات ارايه درس در هفته نشان داده مي شودي  </p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>تصوير زمينه</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>در صورت انتخاب اين گزينه، در پس زمينه گزارش يک تصوير (بک گراند) قرار داده مي شود. انتخاب تصوير در بخش تنظيمات توسط کاربر دانشکده صورت گرفته است و توسط ساير کاربران قابل تغيير نيست. براي خواناتر بودن گزارش بهتر است از پس زمينه استفاده نشود</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>منوي پنجره تنظيمات گزارش</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>منوهاي اين پنجره مانند بسياري از بخش هاي ديگر برنامه با راست کليک در پنجره برنامه ظاهر مي شوند. گزينه هاي اين منو عبارتند از</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>تاييد/ادامه</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>تنظيمات مورد نظر شما براي تهيه گزارش مورد استفاده قرار مي گيرند. همچنين در صورت انتخاب گزينه (تنظيمات را به خاطر بسپار) اين تنظيمات براي گزارش هاي بعدي (در همين جلسه کاري) مورد استفاده قرار مي گيرند</p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>راهنما</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>اين راهنما که در حال خواندن آن هستيد را نشان مي دهد </p>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'>انصراف/خروج</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>از پنجره تنظيمات گزارش خارج مي شود و گزارشي تهيه نمي شود. در صورت انتخاب گزينه (تنظيمات را به خاطر بسپار) اين تنظيمات براي گزارش هاي بعدي (در همين جلسه کاري) مورد استفاده قرار مي گيرند</p>");
            FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            }
        private void Menu_OK_Click (object sender, EventArgs e)
            {
            if (cboDepts.SelectedIndex == -1)
                {
                MessageBox.Show ("يک گروه آمورشي را انتخاب کنيد", "نکسترم", MessageBoxButtons.OK);
                cboDepts.Focus ();
                return;
                }
            Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
            Term.Id = Conversions.ToLong (cboTerms.SelectedValue);
            if (Term.Id < 1L)
                {
                MessageBox.Show ("يک ترم را انتخاب کنيد", "نکسترم", MessageBoxButtons.OK);
                cboTerms.Focus ();
                return;
                }
            Term.Name = cboTerms.Text;
            SetReportSettings ();
            if (Conversions.ToBoolean (Report.Settings & Conversions.ToInteger (0x2 == 0x0)))
                {
                Report.Settings = Report.Settings | 0x100;
                return;
                } //0x100= 0b100000000
            Nxt.Retval1 = 1; //make the report
            Dispose ();
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            SetReportSettings ();
            Nxt.Retval1 = 0; //cancel report
            Dispose ();
            }
        private void btnOK_Click (object sender, EventArgs e)
            {
            Menu_OK_Click (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Menu_Cancel_Click (null, null);
            }
        }
    }