using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class frmDateTime
        {
        private string GridMode = ""; //Entry|Staff
        private string tmpThisEnt = "";
        private int tmpThisCrs = 0;

        public frmDateTime ()
            {
            InitializeComponent ();
            }
        private void frmDateTime_Load (object sender, EventArgs e)
            {
            try
                {
                MntCal.MaxDate = Conversions.ToDate (Term.ExamDateEnd);
                MntCal.MinDate = Conversions.ToDate (Term.ExamDateStart);
                //table of Exams dates for Entry
                NxDb.DS.Tables ["tblTermExams4Entry"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt, Entry_ID, Capacity FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE TermProgs.ID=1", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTermExams4Entry");
                    CnnSS.Close ();
                    }
                for (int i = 0, loopTo = NxDb.DS.Tables ["tblTermExams4Entry"].Rows.Count - 1; i <= loopTo; i++)
                    //tblCols: 0 6 1 2 7 5 9 {id, stafid, datetime, course, entry, staff, capa}
                    GridExam.Rows.Add (NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [0].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [6].ToString (), "d_ " + NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [1].ToString () + " _t", NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [2].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [7].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [5].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [9].ToString ());
                GridExam.Columns [0].Width = 0;        //TermProgID
                GridExam.Columns [1].Width = 0;        //StaffID
                GridExam.Columns [0].Visible = false;  //TermProgID
                GridExam.Columns [1].Visible = false;  //StaffID
                GridExam.Columns [2].Width = 120;      //Exam
                GridExam.Columns [3].Width = 210;      //Course
                GridExam.Columns [4].Width = 210;      //Entry
                GridExam.Columns [5].Width = 180;      //Staff
                GridExam.Columns [6].Width = 30;       //Capacity
                lbl_Grid.Text = "    برنامه امتحانات   " + Entry.Name;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            for (int i = 0; i <= 6; i++)
                {
                GridExam.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                GridExam.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            RefreshGridEntry ();
            }
        //Grid
        private void GridExam_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            //Click
            int r = GridExam.CurrentRow.Index;
            if (r < 0)
                return;
            int c = GridExam.SelectedCells [0].ColumnIndex;
            /* 0:ID 
             * 1:StaffID 
             * 2:ExamDate 
             * 3:Course 
             * 4:Entry 
             * 5:Staff 
             * 6:Capa
            */
            switch (c)
                {
                case 2: //ExamDate_Col
                        {
                        if (GridMode == "Entry")
                            {
                            lbl2Calendar.Visible = true;
                            MntCal.Enabled = true;
                            }
                        break;
                        }

                case 3: //Course_Col
                case 4: //Entry_Col
                        {
                        tmpThisCrs = Conversions.ToInteger (Conversion.Int (GridExam [0, r].Value));
                        MntCal.Enabled = false;
                        lbl2Calendar.Visible = false;
                        string tmpEnt = Conversions.ToString (GridExam [4, r].Value);
                        if ((tmpEnt ?? "") == (Entry.Name ?? ""))
                            {
                            RefreshGridEntry ();
                            for (int i = 0, loopTo = GridExam.Rows.Count - 1; i <= loopTo; i++)
                                {
                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Conversion.Int (GridExam [0, i].Value), tmpThisCrs, false)))
                                    {
                                    GridExam.Rows [i].Cells [3].Selected = true;
                                    MntCal.Enabled = false;
                                    lbl2Calendar.Visible = false;
                                    try
                                        {
                                        MntCal.SetDate (Conversions.ToDate (Strings.Mid (GridExam [2, i].Value.ToString (), 4, 10)));
                                        }
                                    catch (Exception ex)
                                        {
                                        }
                                    return;
                                    }
                                }
                            }
                        break;
                        }

                case 5: //Staff_Col
                        {
                        tmpThisCrs = Conversions.ToInteger (Conversion.Int (GridExam [0, r].Value));
                        MntCal.Enabled = false;
                        lbl2Calendar.Visible = false;
                        tmpThisEnt = Conversions.ToString (GridExam [4, r].Value);
                        RefreshGridStaff ();
                        for (int i = 0, loopTo1 = GridExam.Rows.Count - 1; i <= loopTo1; i++)
                            {
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Conversion.Int (GridExam [0, i].Value), tmpThisCrs, false)))
                                {
                                GridExam.Rows [i].Cells [3].Selected = true;
                                MntCal.Enabled = false;
                                lbl2Calendar.Visible = false;
                                try
                                    {
                                    MntCal.SetDate (Conversions.ToDate (Strings.Mid (GridExam [2, i].Value.ToString (), 4, 10)));
                                    }
                                catch (Exception ex)
                                    {
                                    //MessageBox.Show (ex.ToString());
                                    }
                                return;
                                }
                            }
                        break;
                        }
                }
            try
                {
                MntCal.SetDate (Conversions.ToDate (Strings.Mid (GridExam [2, r].Value.ToString (), 4, 10)));
                }
            catch (Exception ex)
                {
                }
            }
        private void GridExam_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            //DoubleClick
            int r = GridExam.CurrentRow.Index;
            if (r < 0)
                return;
            if (GridMode == "Entry")
                {
                int c = GridExam.SelectedCells [0].ColumnIndex; //0:ID 1:StaffID 2: ExamDate 3:Course 4:Entry 5:Staff 6:Capa
                switch (c)
                    {
                    case 2: //ExamDate_Col
                            {
                            Course.Name = Conversions.ToString (GridExam [3, r].Value);
                            TermProg.tmpExamDateTime = Strings.Mid (GridExam [2, r].Value.ToString (), 4);
                            My.MyProject.Forms.frmDateTimeDialog.ShowDialog ();
                            if (!string.IsNullOrEmpty (TermProg.tmpExamDateTime))
                                {
                                //Save
                                GridExam [c, r].Value = "d_ " + TermProg.tmpExamDateTime + " _t";
                                SaveDateTime4ThisCourse (Conversions.ToInteger (Conversion.Int (GridExam [0, r].Value)), TermProg.tmpExamDateTime);
                                }
                            else
                                {
                                DialogResult myansw = (DialogResult) MessageBox.Show ("تاريخ پاک شود؟", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if ((int) myansw == (int) DialogResult.Yes)
                                    {
                                    SaveDateTime4ThisCourse (Conversions.ToInteger (Conversion.Int (GridExam [0, r].Value)), "    .  .   (  :  )");
                                    }
                                }
                            try
                                {
                                MntCal.SetDate (Conversions.ToDate (Strings.Mid (GridExam [2, r].Value.ToString (), 4, 10)));
                                }
                            catch (Exception ex)
                                {
                                }

                            break;
                            }
                    }
                }
            }
        private void RefreshGridEntry ()
            {
            try
                {
                GridExam.Rows.Clear ();
                NxDb.DS.Tables ["tblTermExams4Entry"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt, Entry_ID, Capacity FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Entry_ID = " + Entry.Id.ToString () + " ORDER BY ExamDate", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTermExams4Entry");
                    CnnSS.Close ();
                    }
                for (int i = 0, loopTo = NxDb.DS.Tables ["tblTermExams4Entry"].Rows.Count - 1; i <= loopTo; i++)
                    //tblCols: 0 6 1 2 7 5 9 {id, stafid, datetime, course, entry, staff, capa}
                    GridExam.Rows.Add (NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [0].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [6].ToString (), "d_ " + NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [1].ToString () + " _t", NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [2].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [7].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [5].ToString (), NxDb.DS.Tables ["tblTermExams4Entry"].Rows [i] [9].ToString ());
                //Clear Color of Cells in col (4)
                for (int i = 0, loopTo1 = GridExam.Rows.Count - 1; i <= loopTo1; i++)
                    GridExam [4, i].Style.BackColor = Color.White;
                GridMode = "Entry";
                Entry.Name = Conversions.ToString (GridExam [4, 0].Value);
                lbl_Grid.Text = "    برنامه ورودي   " + Entry.Name;
                //Bold Dates on Calendar 4 Entry
                string tmpDate;
                MntCal.RemoveAllBoldedDates ();
                MntCal.UpdateBoldedDates ();
                for (int m = 0, loopTo2 = NxDb.DS.Tables ["tblTermExams4Entry"].Rows.Count - 1; m <= loopTo2; m++)
                    {
                    tmpDate = Strings.Mid (NxDb.DS.Tables ["tblTermExams4Entry"].Rows [m] [1].ToString (), 1, 10);
                    if (Conversion.Val (tmpDate) > 0d)
                        {
                        MntCal.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                        }
                    }
                MntCal.UpdateBoldedDates ();
                lblDbleClick.Visible = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void RefreshGridStaff ()
            {
            try
                {
                GridMode = "Staff";
                int r = GridExam.SelectedCells [0].RowIndex;
                Staff.Name = Conversions.ToString (GridExam [5, r].Value);
                Staff.Id = Conversions.ToLong (Conversion.Int (GridExam [1, r].Value));
                lbl_Grid.Text = "    برنامه استاد   " + Staff.Name;
                NxDb.DS.Tables ["tblTermExams4Staff"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt, Entry_ID, Capacity FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY ExamDate", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTermExams4Staff");
                    CnnSS.Close ();
                    }
                GridExam.Rows.Clear ();
                for (int i = 0, loopTo = NxDb.DS.Tables ["tblTermExams4Staff"].Rows.Count - 1; i <= loopTo; i++)
                    //tblCols: 0 6 1 2 7 5 9 {id, stafid, datetime, course, entry, staff, capa}
                    GridExam.Rows.Add (NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [0].ToString (), NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [6].ToString (), "d_ " + NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [1].ToString () + " _t", NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [2].ToString (), NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [7].ToString (), NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [5].ToString (), NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [9].ToString ());
                //Color Cells in col (4)
                for (int i = 0, loopTo1 = GridExam.Rows.Count - 1; i <= loopTo1; i++)
                    {
                    if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (GridExam [4, i].Value, tmpThisEnt, false)))
                        GridExam [4, i].Style.BackColor = Color.LightCyan;
                    }

                //Bold Dates on Calendar 4 Staff
                string tmpDate;
                MntCal.RemoveAllBoldedDates ();
                MntCal.UpdateBoldedDates ();
                for (int m = 0, loopTo2 = NxDb.DS.Tables ["tblTermExams4Staff"].Rows.Count - 1; m <= loopTo2; m++)
                    {
                    tmpDate = Strings.Mid (NxDb.DS.Tables ["tblTermExams4Staff"].Rows [m] [1].ToString (), 1, 10);
                    if (Conversion.Val (tmpDate) > 0d)
                        {
                        MntCal.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                        }
                    }
                MntCal.UpdateBoldedDates ();
                lblDbleClick.Visible = false;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void SaveDateTime4ThisCourse (int IDx, string DateTimex)
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                try
                    {
                    NxDb.strSQL = "UPDATE TermProgs SET ExamDate=@ExamDate WHERE ID=@ID";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@ExamDate", DateTimex);
                    cmd.Parameters.AddWithValue ("@ID", IDx.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                catch (Exception ex)
                    {
                    CnnSS.Close ();
                    MessageBox.Show (ex.ToString ());
                    }
                }
            RefreshGridEntry ();
            }
        //Calendar
        private void BoldDatesOnCalendar ()
            {
            //Bold Dates on Calendar 4 Staff
            string tmpDate;
            MntCal.RemoveAllBoldedDates ();
            MntCal.UpdateBoldedDates ();
            for (int i = 0, loopTo = NxDb.DS.Tables ["tblTermExams4Staff"].Rows.Count - 1; i <= loopTo; i++)
                {
                tmpDate = Strings.Mid (NxDb.DS.Tables ["tblTermExams4Staff"].Rows [i] [1].ToString (), 1, 10);
                if (Conversion.Val (tmpDate) > 0d)
                    {
                    MntCal.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                    }
                }
            MntCal.UpdateBoldedDates ();
            }
        private void MntCal_DateSelected (object sender, DateRangeEventArgs e)
            {
            int r = GridExam.CurrentRow.Index;
            if (r < 0)
                return;
            int c = GridExam.SelectedCells [0].ColumnIndex; // 0:ID 1:StaffID 2: ExamDate 3:Course 4:Entry 5:Staff 6:Capa
            if (c != 2)
                return;
            DialogResult myansw = (DialogResult) MessageBox.Show ("تاريخ جديد امتحان ذخيره شود؟", "نکسترم", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.OK)
                {
                string strTimex = Strings.Mid (Conversions.ToString (GridExam [c, r].Value), 16, 5);
                if (Conversion.Val (strTimex) == 0d)
                    strTimex = "00:00";
                TermProg.tmpExamDateTime = "d_ " + MntCal.SelectionStart.Date.ToString ("yyyy.MM.dd") + " (" + strTimex + ")" + " _t ";
                GridExam [c, r].Value = TermProg.tmpExamDateTime;
                TermProg.tmpExamDateTime = MntCal.SelectionStart.Date.ToString ("yyyy.MM.dd") + " (" + strTimex + ")";
                SaveDateTime4ThisCourse (Conversions.ToInteger (Conversion.Int (GridExam [0, r].Value)), TermProg.tmpExamDateTime);
                }
            }
        private void MenuDateStart_Click (object sender, EventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty (Strings.Trim (Term.ExamDateStart)))
                    {
                    MntCal.MinDate = Conversions.ToDate (Interaction.InputBox ("تاريخ شروع", "Calendar Setings", "1402/01/01"));
                    }
                else
                    {
                    MntCal.MinDate = Conversions.ToDate (Interaction.InputBox ("تاريخ شروع", "Calendar Setings", Term.ExamDateStart));
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Err:\n" + ex.ToString ());
                }
            }
        private void MenuDateEnd_Click (object sender, EventArgs e)
            {
            try
                {
                if (string.IsNullOrEmpty (Strings.Trim (Term.ExamDateEnd)))
                    {
                    MntCal.MaxDate = Conversions.ToDate (Interaction.InputBox ("تاريخ پايان امتحانات", "Calendar Setings", "1402/04/20"));
                    }
                else
                    {
                    MntCal.MaxDate = Conversions.ToDate (Interaction.InputBox ("تاريخ پايان امتحانات", "Calendar Setings", Term.ExamDateEnd));
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Err:\n" + ex.ToString ());
                }
            }
        //Exit
        private void Menu_Help_Click (object sender, EventArgs e)
            {
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=\"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>راهنما</title>");
            FileSystem.PrintLine (1, Report.Style); //strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>راهنماي نرم افزار نکسترم</p>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> راهنماي تعيين تاريخ امتحانات <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "ليست درس ها و تاريخ امتحانات دانشجويان يک ورودي در جدول ديده مي شود <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "در ستون تاريخ کليک کنيد و از تقويم تاريخ را انتخاب و (ذخيره) کنيد <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "در ستون تاريخ دبل کليک کنيد و تاريخ-ساعت را وارد کنيد <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "منوها با راست کليک ظاهر مي شوند <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "روزهايي که در آن دست کم يک امتحان وجود دارد، بولد (تيره) مي شوند <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "با انتخاب استاد، ساير امتحانات آن استاد در ليست ظاهر مي شود <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "با انتخاب ورودي، تاريخ امتحانات دانشجويان مجددا در ليست ظاهر مي شود <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br></p>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            TermProg.ExamDateTime = "";
            Dispose ();
            }

        private void lblExit_Click (object sender, EventArgs e)
            {
            TermProg.ExamDateTime = "";
            Dispose ();
            }
        }
    }