using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class UserActivityLog
        {
        public UserActivityLog ()
            {
            InitializeComponent ();
            }
        // FormLoad
        private void UserActivityLog_Load (object sender, EventArgs e)
            {
            cboDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            cboDepts.DisplayMember = "DEPT";
            cboDepts.ValueMember = "ID";
            cboDepts.SelectedValue = Department.Id;
            // Fill combo_Activity_Report_Sort
            cboActivityReportSort.Items.Add ("تاريخ و زمان");
            cboActivityReportSort.Items.Add ("گروه آموزشي");
            cboActivityReportSort.Items.Add ("سرويس گيرنده");
            cboActivityReportSort.Items.Add ("نام مستعار");
            if (User.Type == "UserDeputy" & (User.ACCs & 0x10) == 0x10) // 0x10=16=0001'0000
                {
                cboActivityReportSort.Items.Add ("پاک کردن");
                }
            CheckBoxFaculty.Checked = true;
            CheckBoxDepts.Checked = false;
            cboActivityReportSort.SelectedIndex = 0;
            NxDb.DS.Tables ["tblTerms"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                try
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM Terms WHERE Terms.Active = 1 ORDER BY Term", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                    CnnSS.Close ();
                    }
                catch (Exception ex)
                    {
                    CnnSS.Close ();
                    MessageBox.Show (ex.ToString ());
                    }
                }
            cboTerms.DataSource = NxDb.DS.Tables ["tblterms"];
            cboTerms.DisplayMember = "Term";
            cboTerms.ValueMember = "ID";
            cboTerms.SelectedValue = Term.Id;
            cboActivityReportSort.Focus ();
            }
        private void CheckBoxDepts_CheckedChanged (object sender, EventArgs e)
            {
            if (CheckBoxDepts.Checked == false)
                {
                CheckBoxFaculty.Checked = true;
                cboDepts.SelectedValue = -1;
                }
            else
                {
                CheckBoxFaculty.Checked = false;
                cboDepts.SelectedValue = User.Id;
                }
            }
        private void CheckBoxFaculty_CheckedChanged (object sender, EventArgs e)
            {
            if (CheckBoxFaculty.Checked == false)
                {
                cboDepts.SelectedValue = User.Id;
                CheckBoxDepts.Checked = true;
                }
            else
                {
                cboDepts.SelectedValue = -1;
                CheckBoxDepts.Checked = false;
                }
            }
        private void cboDepts_Click (object sender, EventArgs e)
            {
            try
                {
                CheckBoxFaculty.Checked = false;
                CheckBoxDepts.Checked = true;
                User.Id = Convert.ToInt32 (cboDepts.SelectedValue);
                }
            catch (Exception ex)
                {
                //ignore it
                }
            }

        //Menu A
        private void Menu_ReportCourses_Click (object sender, EventArgs e)
            {
            //Report Courses
            if (CheckBoxDepts.Checked == true)
                {
                Department.Name = cboDepts.Text;
                Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
                }
            else
                {
                Department.Name = "";
                Department.Id = 0L;
                }
            Term.Name = cboTerms.Text;
            int intProgLevel = cboProglevel.SelectedIndex;   //{Dop, Bsc, Msc, Md, Phd}
            string strProgLevel = cboProglevel.Text;
            int intCourseType = cboCoursetype.SelectedIndex; //{theor, exper}
            string strCourseType = cboCoursetype.Text;
            if (cboTerms.SelectedIndex == -1)
                Term.Name = "";
            else
                Term.Name = cboTerms.Text;
            string strFilter = "";
            if (Department.Id > 0L)
                strFilter = strFilter + " AND (Departments.ID = " + Department.Id.ToString () + ")";
            if (intCourseType >= 0)
                strFilter = strFilter + " AND ((CourseSpecs & " + Math.Pow (2d, intCourseType).ToString () + ") = " + Math.Pow (2d, intCourseType).ToString () + ")";
            if (intProgLevel >= 0)
                strFilter = strFilter + " AND ((ProgramSpecs & " + Math.Pow (2d, intProgLevel).ToString () + ") = " + Math.Pow (2d, intProgLevel).ToString () + ")";
            if (!string.IsNullOrEmpty (Term.Name))
                strFilter = strFilter + " AND (Terms.Term = '" + Term.Name + "')";
            if (string.IsNullOrEmpty (strFilter))
                {
                MessageBox.Show ("گروه آموزشي ويا ترم را مشخص کنيد", "نکسترم", MessageBoxButtons.OK);
                return;
                }
            // MsgBox(strFilter)
            strFilter = " WHERE (1 = 1) " + strFilter;
            NxDb.DS.Tables ["tblReportProgData"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                try
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Departments.DepartmentName, Terms.Term, BioProgs.ProgramName, Entries.EntYear, Courses.CourseName, Courses.CourseNumber, Units, [Group], TermProgs.Notes, ProgramSpecs, CourseSpecs FROM Courses INNER JOIN Entries INNER JOIN TermProgs ON  Entries.ID =  TermProgs.Entry_ID INNER JOIN Terms ON  TermProgs.Term_ID =  Terms.ID ON  Courses.ID =  TermProgs.Course_ID INNER JOIN BioProgs ON  Entries.BioProg_ID =  BioProgs.ID INNER JOIN Departments ON  BioProgs.Department_ID =  Departments.ID" + strFilter + " ORDER BY DepartmentName, Term, ProgramName, EntYear, CourseName, [Group]", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblReportProgData");
                    CnnSS.Close ();
                    }
                catch (Exception ex)
                    {
                    CnnSS.Close ();
                    MessageBox.Show (ex.ToString ());
                    }
                }
            // 0 Term, 1 DepartmentName, 2 ProgramName, 3 EntYear, 4 CourseName, 5 CourseNumber, 6 Units, 7 Group, 8 Note
            FileSystem.FileOpen (1, Application.StartupPath + @"\Nexterm_ReportCourses.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir= \"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>گزارش درس ها</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>", Report.AppOwner, "</p>");
            FileSystem.PrintLine (1, "<p style='color:green; font-family:tahoma; font-size:12px; text-align:center'>گزارش درس هاي برنامه ريزي شده</p><hr>");
            FileSystem.PrintLine (1, "<p style='color:steelblue; font-family:tahoma; font-size:12px'>فيلتر:</p>");
            if (!string.IsNullOrEmpty (Department.Name))
                FileSystem.PrintLine (1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'> گروه آموزشي: ", Department.Name, "</p>");
            if (!string.IsNullOrEmpty (Term.Name))
                FileSystem.PrintLine (1, "<p style='color:darkgray; font-family:tahoma; font-size:12px'>", Term.Name, "</p>");
            if (!string.IsNullOrEmpty (strProgLevel))
                FileSystem.PrintLine (1, "<p style='color:MediumPurple; font-family:tahoma; font-size:12px'> مقطع ", strProgLevel, "</p>");
            if (!string.IsNullOrEmpty (strCourseType))
                FileSystem.PrintLine (1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>", strCourseType, "</p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p><hr>");
            //draw table
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>درس هاي برنامه ريزي شده به تفکيک دروه آموزشي در هر گروه</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
            FileSystem.PrintLine (1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>");
            try
                {
                string strTermName = Conversions.ToString (NxDb.DS.Tables ["tblreportProgData"].Rows [0] [0]);
                string strEntryName = Conversions.ToString (NxDb.DS.Tables ["tblreportProgData"].Rows [0] [2]);
                int intCounter4Term = 0;
                int intUnits4Term = 0;
                int intCounter4Entry = 0;
                int intUnits4Entry = 0;
                for (int i = 0, loopTo = NxDb.DS.Tables ["tblreportProgData"].Rows.Count - 1; i <= loopTo; i++)
                    {
                    if (Conversions.ToBoolean (Operators.ConditionalCompareObjectNotEqual (strEntryName, NxDb.DS.Tables ["tblreportProgData"].Rows [i] [2], false))) // reached Next Entry
                        {
                        strEntryName = Conversions.ToString (NxDb.DS.Tables ["tblreportProgData"].Rows [i] [2]);      // change  Next Entry
                        FileSystem.PrintLine (1, "<tr><td>^</td><td>" + intCounter4Entry + ":" + intUnits4Entry + "</td></tr>");
                        intCounter4Entry = 0;
                        intUnits4Entry = 0;
                        }
                    if (Conversions.ToBoolean (Operators.ConditionalCompareObjectNotEqual (strTermName, NxDb.DS.Tables ["tblreportProgData"].Rows [i] [0], false))) // reached Next Term
                        {
                        strTermName = Conversions.ToString (NxDb.DS.Tables ["tblreportProgData"].Rows [i] [0]);      // change  Next Term
                        FileSystem.PrintLine (1, "<tr><td>^</td><td>" + intCounter4Term + ":" + intUnits4Term + "</td></tr>");
                        FileSystem.PrintLine (1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>");
                        intCounter4Term = 0;
                        intUnits4Term = 0;
                        }

                    FileSystem.PrintLine (1, "<tr>");
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [0], "</td>");   // 0 term
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [1], "</td>");   // 1
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [2], "</td>");   // 2
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [3], "</td>");   // 3
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [4], "</td>");   // 4
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [5], "</td>");   // 5
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [6], "</td>");   // 6
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [7], "</td>");   // 7
                    FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblReportProgData"].Rows [i] [8], "</td>");   // 8 notes
                    FileSystem.PrintLine (1, "</tr>");
                    intCounter4Entry = intCounter4Entry + 1;
                    intUnits4Entry = Conversions.ToInteger (Operators.AddObject (intUnits4Entry, NxDb.DS.Tables ["tblReportProgData"].Rows [i] [6]));
                    intCounter4Term = intCounter4Term + 1;
                    intUnits4Term = Conversions.ToInteger (Operators.AddObject (intUnits4Term, NxDb.DS.Tables ["tblReportProgData"].Rows [i] [6]));
                    }
                FileSystem.PrintLine (1, "<tr><td>^</td><td>" + intCounter4Entry + ":" + intUnits4Entry + "</td></tr>");
                FileSystem.PrintLine (1, "<tr><td>^</td><td>" + intCounter4Term + ":" + intUnits4Term + "</td></tr>");
                FileSystem.PrintLine (1, "</table><br>");
                FileSystem.PrintLine (1, "</div>");
                FileSystem.PrintLine (1, "</center>");
                // Filter reprint
                FileSystem.PrintLine (1, "<p style='color:steelblue; font-family:tahoma; font-size:12px'>فيلتر - يادآوري:</p>");
                if (!string.IsNullOrEmpty (Department.Name))
                    FileSystem.PrintLine (1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'> گروه آموزشي: ", Department.Name, "</p>");
                if (!string.IsNullOrEmpty (Term.Name))
                    FileSystem.PrintLine (1, "<p style='color:darkgray; font-family:tahoma; font-size:12px'>", Term.Name, "</p>");
                if (!string.IsNullOrEmpty (strProgLevel))
                    FileSystem.PrintLine (1, "<p style='color:MediumPurple; font-family:tahoma; font-size:12px'> مقطع ", strProgLevel, "</p>");
                if (!string.IsNullOrEmpty (strCourseType))
                    FileSystem.PrintLine (1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>", strCourseType, "</p>");
                //FOOTER
                FileSystem.PrintLine (1, "<br>");
                FileSystem.PrintLine (1, Report.Footer);
                FileSystem.PrintLine (1, "</body></html>");
                FileSystem.FileClose (1);
                NxDb.LOG ("rprt.stats");
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_ReportCourses.html");
                }
            catch (Exception ex)
                {
                FileSystem.FileClose (1);
                return;
                }
            }

        //Menu B
        private void cboActivityReportSort_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13:
                        {
                        Menu_Activity_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 27:
                        {
                        Menu_Exit_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }

            }
        private void Menu_Activity_Click (object sender, EventArgs e)
            {
            if (CheckBoxDepts.Checked == true & cboDepts.SelectedIndex < 0 & CheckBoxFaculty.Checked == false)
                {
                MessageBox.Show ("يک گروه از ليست انتخاب کنيد", "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            int intSortType = 0;
            string strFltr = "";
            int x = 0;
            if (cboActivityReportSort.SelectedIndex == 4)
                {
                ClearUserActivity ();
                return;
                }
            NxDb.LOG ("rprt.usrlog");
            if (cboActivityReportSort.SelectedIndex == 0)
                intSortType = 1;
            if (cboActivityReportSort.SelectedIndex == 1)
                intSortType = 2;
            if (cboActivityReportSort.SelectedIndex == 2)
                intSortType = 3;
            if (cboActivityReportSort.SelectedIndex == 3)
                intSortType = 4;
            if (intSortType == 0)
                return;
            NxDb.DS.Tables ["tblLogs"].Clear ();
            Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
            Department.Name = cboDepts.Text;
            //Add filter
            try
                {
                NxDb.strSQL = "SELECT DateTimex, UserID, NickName, ClientName, FrontEnd, strLog From xLog";
                if (CheckBoxFaculty.Checked == true)
                    x = 1;
                if (CheckBoxDepts.Checked == true)
                    x = 2;
                switch (x)
                    {
                    case 1:
                            {
                            strFltr = "شامل: همه کاربران" + Constants.vbCrLf;
                            break;
                            }
                    case 2:
                            {
                            strFltr = "شامل: فقط يک گروه :" + Department.Name + " " + Constants.vbCrLf;
                            NxDb.strSQL = NxDb.strSQL + " WHERE userID=" + Department.Id.ToString ();
                            break;
                            }
                    case 0:
                            {
                            return;
                            }
                    }
                //Add order
                switch (intSortType)
                    {
                    case 1:
                            {
                            NxDb.strSQL = NxDb.strSQL + " ORDER BY DateTimex DESC";
                            strFltr = strFltr + " - " + "ترتيب: تاريخ و زمان";
                            break;
                            }
                    case 2:
                            {
                            NxDb.strSQL = NxDb.strSQL + " ORDER BY UserID, DateTimex DESC";
                            strFltr = strFltr + " - " + "ترتيب: شناسه گروه";
                            break;
                            }
                    case 3:
                            {
                            NxDb.strSQL = NxDb.strSQL + " ORDER BY ClientName, DateTimex DESC";
                            strFltr = strFltr + " - " + "ترتيب: سرويس گيرنده";
                            break;
                            }
                    case 4:
                            {
                            NxDb.strSQL = NxDb.strSQL + " ORDER BY NickName, DateTimex DESC";
                            strFltr = strFltr + " - " + "ترتيب: نام مستعار";
                            break;
                            }
                    }
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (NxDb.strSQL, CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblLogs"); // tbl Logs
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_log.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir= \"ltr\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>فعاليت کاربران</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            //FileSystem.PrintLine (1, "<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n");
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style='color:darkgray; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
            FileSystem.PrintLine (1, "<h4 style='color:green; font-family:tahoma; text-align: center'>Log for " + NxDb.Server2Connect + ": " + NxDb.DbBackEnd + "</h4>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-6\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
            FileSystem.PrintLine (1, "<tr><th>شناسه</th><th>نام گروه آموزشي</th></tr>");
            for (int i = 0, loopTo = NxDb.DS.Tables ["tblDepartments"].Rows.Count - 1; i <= loopTo; i++)
                {
                FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblDepartments"].Rows [i] [0], "</td>");           // 1 :id
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblDepartments"].Rows [i] [1], "</td></tr>");          // 2 :DeptName
                }
            FileSystem.PrintLine (1, "</table>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>فعاليت کاربران </p>");
            FileSystem.PrintLine (1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>" + strFltr + "</p>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive  col-md-8\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
            FileSystem.PrintLine (1, "<tr><th>Date and Time</th><th>Client</th><th>FrontEnd</th><th>Nickname</th><th>usr</th><th>Operation</th></tr>");
            for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblLogs"].Rows.Count - 1; i <= loopTo1; i++)
                {
                FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblLogs"].Rows [i] [0], "</td>");      //DateTime
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblLogs"].Rows [i] [3], "</td>");          //clnt
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblLogs"].Rows [i] [4], "</td>");          //fe
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblLogs"].Rows [i] [2], "</td>");          //nck
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblLogs"].Rows [i] [1], "</td>");          //usr
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblLogs"].Rows [i] [5], "</td></tr>");     //activity
                }
            FileSystem.PrintLine (1, "</table>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            //footer
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body></html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_log.html");
            }
        private void ClearUserActivity ()
            {
            int x = 0;
            string strFltr = "";
            if (CheckBoxFaculty.Checked == true)
                x = 1;
            if (CheckBoxDepts.Checked == true)
                x = 2;
            switch (x)
                {
                case 1:
                        {
                        Department.Name = "";
                        Department.Id = 0L;
                        DialogResult myansw = MessageBox.Show ("YES : سوابق فعاليت همه کاربران پاک شود" + Constants.vbCrLf + "NO : فقط سوابق فعاليت کاربر دانشکده پاک شود", "نکسترم", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3, MessageBoxOptions.RightAlign);
                        switch (myansw)
                            {
                            case DialogResult.Yes:
                                    {
                                    strFltr = "";
                                    break;
                                    }
                            case DialogResult.No:
                                    {
                                    strFltr = " WHERE userID=0";
                                    break;
                                    }
                            case DialogResult.Cancel:
                                    {
                                    return;
                                    }
                            }

                        break;
                        }
                case 2:
                        {
                        Department.Name = cboDepts.Text;
                        Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
                        strFltr = " WHERE userID=" + Department.Id.ToString ();
                        DialogResult myansw = MessageBox.Show ("سوابق فعاليت کاربر گروه  " + Department.Name + "  پاک شود؟  ", "نکسترم", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        if (myansw == DialogResult.Cancel)
                            return;
                        break;
                        }
                case 0:
                        {
                        return;
                        }
                }
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Delete From xLog" + strFltr, CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblLogs"); // tbl Logs
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            NxDb.LOG ("rprt.usrlog.clr");
            MessageBox.Show ("انجام شد", "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            cboActivityReportSort.SelectedIndex = 0;
            // Menu_ReportUserActivity_Click()
            }
        //Exit
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            NxDb.DS.Tables ["tblTerms"].Clear ();
            Dispose ();
            }
        private void Menu_Exit2_Click (object sender, EventArgs e)
            {
            Menu_Exit_Click (null, null);
            }
        private void UserActivityLog_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                Menu_Exit_Click (null, null);
                e.SuppressKeyPress = true;
                }
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Menu_Exit_Click (null, null);
            }
        private void btnReportB_Click (object sender, EventArgs e)
            {
            Menu_Activity_Click (null, null);
            }
        private void btnReportA_Click (object sender, EventArgs e)
            {
            Menu_ReportCourses_Click (null, null);
            }
        }
    }