using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Word = Microsoft.Office.Interop.Word;
using System.Management;
using DocumentFormat.OpenXml.Presentation;
namespace NexTerm
    {
    internal class Course
        {
        public static DataTable tblCourses = new DataTable ();
        public static long Id;
        public static string Name;
        public static long Number;
        public static short Spec;
        public static short Units;
        }
    internal class Department
        {
        public static DataTable tblDepartments = new DataTable ();
        public static long Id;
        public static string Name;

        }
    internal class Entry
        {
        public static DataTable tblEntries = new DataTable ();
        public static long Id;
        public static string Name;
        public static int YearEntered;
        }
    internal class Log
        {
        public static DataTable tblLogs = new DataTable ();
        }
    internal class Message
        {
        public static DataTable tblMsgs = new DataTable ();
        }
    internal class NxDb
        {
        public static string DriveSerialNumber = "-";
        public static string BuildInfo = "nexterm build 14031115";     // ignore 2nd row of file: usr
        public static string CurrentVersion = "";                      // version of db on server (show in frmInfo)
        public static string Server2Connect = "";
        public static string DbBackEnd = "";                           // (read from cnn file) Path of Backend file on local or server 
        public static string CnnString = "";
        public static string Filename;                                 // path of text file for backend.path, user.id, pass strings
        public static SqlConnection CnnSS = new SqlConnection ();
        public static SqlCommand CmdSS = new SqlCommand ();
        public static SqlDataAdapter DASS = new SqlDataAdapter ();
        public static DataSet DS = new DataSet ();
        public static string strSQL;
        public static void GetSerialNumber ()
            {
            //get SerialNumber of Drive from OS /Use managementObject and Win32_LogicalDisk 2 obtain disk info
            var oHD = new ManagementObject ("Win32_LogicalDisk.DeviceID=\"C:\"");
            oHD.Get (); // Get Info
            DriveSerialNumber = Strings.Trim (oHD ["VolumeSerialNumber"].ToString ());
            }
        public static void GetBuildInfo ()
            {
            //strBuildInfo : Build info is set in Module
            User.NickName = "";
            User.Id = 0;
            NxDb.Filename = Application.StartupPath + "usr";
            if (System.IO.File.Exists (NxDb.Filename) == true)
                {
                try
                    {
                    FileSystem.FileOpen (1, NxDb.Filename, OpenMode.Input);
                    //check header
                    string header = FileSystem.LineInput (1);
                    if (Strings.Trim (header) != "NexTerm")
                        {
                        FileSystem.FileClose (1);
                        return;
                        }
                    else
                        {
                        //header is correct
                        string tmprowx = FileSystem.LineInput (1);
                        User.NickName = Strings.LCase (Strings.Trim (Strings.Mid (FileSystem.LineInput (1), 6)));
                        if (User.NickName == "na" | User.NickName == "-")
                            User.NickName = "";
                        User.Id = (int) Conversion.Val (Strings.Mid (FileSystem.LineInput (1), 5));
                        }
                    }
                catch (Exception ex)
                    {
                    }
                FileSystem.FileClose (1);
                }

            //if NickName not set?
            while (string.IsNullOrEmpty (Strings.Trim (User.NickName)))
                {
                User.NickName = Strings.Trim (Interaction.InputBox ("Enter your NickName :", "NexTerm:", ""));
                }
            NxDb.SetBuildInfo ();
            }
        public static void SetBuildInfo ()
            {
            FileSystem.FileOpen (1, Application.StartupPath + "usr", OpenMode.Output);
            FileSystem.PrintLine (1, "NexTerm");
            FileSystem.PrintLine (1, NxDb.BuildInfo);
            FileSystem.PrintLine (1, "nick " + Strings.LCase (User.NickName));
            FileSystem.PrintLine (1, "usr " + User.Id.ToString ());
            FileSystem.FileClose (1);
            }
        public static String Connect2DB (string cnnstring)
            {
            //CLEAR workspace!
            //Delete all existing tables in Dataset
            NxDb.DS.Clear ();
            //Delete Dataset
            NxDb.DS.Dispose ();

            string CNNresult = "not connected";
            TermProg.Caption = "Connected to " + DbBackEnd;
            CNNresult = "connected";
            //initialize Tables
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    //tbl 0: Keyless
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select User_Id, SerialNumber FROM KeyLess", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblKeyless");
                    //tbl 1: Depts
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, DepartmentName As DEPT, DepartmentActive, Notes, DepartmentPass, acc FROM Departments ORDER BY DepartmentName", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblDepartments");
                    //tbl 2: BioProgs
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID FROM BioProgs", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblBioProgs");
                    //tbl 3: Courses
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID FROM Courses", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblCourses");
                    //tbl 4: Staff
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID FROM Staff", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblStaff");
                    //tbl 5: Techs
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID FROM Technecians", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTechs");
                    //tbl 6: Rooms
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, RoomName AS Class FROM Rooms ORDER BY RoomName", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblRooms");
                    //tbl 7: Entries
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID As EntID FROM Entries", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblEntries");
                    //tbl 8: Terms
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID FROM Terms", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                    //tbl 9: Templates
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID FROM Templates", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTemplates");
                    //tbl 10: TemplateData
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID FROM TemplateData", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTemplateData");
                    //tbl 11: TermProgs
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID From TermProgs", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTermProgs");
                    //tbl 12: Settings (will be read via settings.read() )
                    //tbl 13: AllProgs
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID From TermProgs", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                    //tbl 14: Exams
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID From TermProgs", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
                    //tbl Logs
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DateTimex From xLog", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblLogs");
                    //tbl notes (messages)
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID FROM msgs", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblMsgs");

                    //WRITE-LOG
                    if (User.Type == "UserDeputy")
                        User.Id = 0;
                    //Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
                    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById ("Iran Standard Time");
                    string strDateTime = TimeZoneInfo.ConvertTime (DateTime.Now, timeZoneInfo).ToString ("yyyy.MM.dd - HH:mm:ss");
                    int intUserID = User.Id;
                    string strNickName = User.NickName;
                    string strClientName = Strings.LCase (Environment.MachineName);
                    string strFrontEnd = Strings.LCase (NxDb.BuildInfo);
                    string strLog = "login";
                    NxDb.strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@datetime", strDateTime);
                    cmdx.Parameters.AddWithValue ("@userid", intUserID.ToString ());
                    cmdx.Parameters.AddWithValue ("@nickname", strNickName);
                    cmdx.Parameters.AddWithValue ("@clientname", strClientName);
                    cmdx.Parameters.AddWithValue ("@frontend", strFrontEnd);
                    cmdx.Parameters.AddWithValue ("@strlog", strLog);
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                DialogResult myansw = MessageBox.Show ("خطا: نکسترم به ديتابيس زير متصل نشد\n" + NxDb.DbBackEnd + "\n\nجزييات خطا نشان داده شود؟", "خطا در اتصال به ديتابيس", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.Yes)
                    MessageBox.Show (ex.ToString ());
                CNNresult = "not connected";
                return CNNresult;
                }
            return CNNresult;
            }
        public static void WipeOut_NxInfo (string tblNames)
            {
            Nxt.Retval1 = 0;
            DialogResult myansw = MessageBox.Show ("داده ها پاک شوند؟ \n مطمئن هستيد؟", "نکسترم", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            switch (myansw)
                {
                case DialogResult.OK:
                        {
                        Random rnd = new Random ();
                        string RndNumber = Strings.Trim (rnd.Next (10001, 19999).ToString ());
                        string strAnsw = Interaction.InputBox ("کد ايمني" + RndNumber, "عدد تصادفي زير را وارد کنيد", "");
                        if (strAnsw != RndNumber)
                            return;
                        break;
                        }
                case DialogResult.Cancel:
                        {
                        return;
                        }
                }
            //Assuming an OPEN CNN for this BLOCK
            //Clear DataTables 
            NxDb.DS.Tables ["tblKeyless"].Clear ();
            NxDb.DS.Tables ["tblDepartments"].Clear ();
            NxDb.DS.Tables ["tblBioProgs"].Clear ();
            NxDb.DS.Tables ["tblCourses"].Clear ();
            NxDb.DS.Tables ["tblEntries"].Clear ();
            NxDb.DS.Tables ["tblRooms"].Clear ();
            NxDb.DS.Tables ["tblStaff"].Clear ();
            NxDb.DS.Tables ["tblTechs"].Clear ();
            NxDb.DS.Tables ["tblTerms"].Clear ();
            NxDb.DS.Tables ["tblTermProgs"].Clear ();
            NxDb.DS.Tables ["tblTemplates"].Clear ();
            NxDb.DS.Tables ["tblTemplateData"].Clear ();
            NxDb.DS.Tables ["tblSettings"].Clear ();
            NxDb.DS.Tables ["tblAllProgs"].Clear ();
            NxDb.DS.Tables ["tblTermExams"].Clear ();
            NxDb.DS.Tables ["tblMsgs"].Clear ();
            NxDb.DS.Tables ["tblReportProgData"].Clear ();
            //Del Database Tables Rows 
            using (var CnnSS = new SqlConnection (CnnString))
                {
                CnnSS.Open ();
                try
                    {
                    switch (tblNames ?? "")
                        {
                        case "Messages":
                                {
                                foreach (var strTableName in new [] { "msgs" })
                                    {
                                    strSQL = "DELETE FROM " + strTableName + ";";
                                    var cmd = new SqlCommand (strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    int i = cmd.ExecuteNonQuery ();
                                    }

                                break;
                                }
                        case "ProgData":
                                {
                                foreach (var strTableName in new [] { "TermProgs" })
                                    {
                                    strSQL = "DELETE FROM " + strTableName + ";";
                                    var cmd = new SqlCommand (strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    int i = cmd.ExecuteNonQuery ();
                                    }

                                break;
                                }
                        case "Entries": // +ProgData which are dependant on Entries
                                {
                                foreach (var strTableName in new [] { "Entries", "TermProgs" })
                                    {
                                    strSQL = "DELETE FROM " + strTableName + ";";
                                    var cmd = new SqlCommand (strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    int i = cmd.ExecuteNonQuery ();
                                    }

                                break;
                                }
                        case "ClearAllData":
                                {
                                foreach (var strTableName in new [] { "Departments", "BioProgs", "Terms", "Entries", "Rooms", "Staff", "Technecians", "Courses", "TermProgs", "Templates", "TemplateData", "msgs" })
                                    {
                                    strSQL = "DELETE FROM " + strTableName + ";";
                                    var cmd = new SqlCommand (strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    int i = cmd.ExecuteNonQuery ();
                                    }

                                break;
                                }
                        }
                    Nxt.Retval1 = 1;
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    return;
                    }
                CnnSS.Close ();
                }
            //ReSeed Table IDs to 1
            Nxt.Retval2 = 0;
            using (var CnnSS = new SqlConnection (CnnString))
                {
                try
                    {
                    CnnSS.Open ();
                    foreach (var strTableName in new [] { tblNames })
                        {
                        strSQL = "DBCC CHECKIDENT (" + strTableName + ", RESEED, 1)";
                        var cmd = new SqlCommand (strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery ();
                        }
                    Nxt.Retval2 = 1;
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    return;
                    }
                CnnSS.Close ();
                }
            }
        public static bool CheckKeylessClient ()
            {
            //refresh
            NxDb.DS.Tables ["tblKeyless"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select User_Id, SerialNumber FROM KeyLess", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblKeyless");
                CnnSS.Close ();
                }
            //check
            bool boolKlss = false;
            foreach (DataRow r in NxDb.DS.Tables ["tblKeyless"].Rows)
                {
                if (((int) r [0] == User.Id) & (r [1].ToString () == NxDb.DriveSerialNumber))
                    boolKlss = true;
                }
            return boolKlss;
            }
        public static bool AddKeyless ()
            {
            bool boolKeyless = CheckKeylessClient ();
            if (boolKeyless == false)
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "INSERT INTO KeyLess (User_Id, SerialNumber) VALUES (@userid, @serialnumber)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                    cmd.Parameters.AddWithValue ("@serialnumber", NxDb.DriveSerialNumber);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                return true;
                }
            else
                return false;
            }
        public static void RemoveKeyless ()
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "DELETE FROM KeyLess WHERE (User_Id = @userid AND SerialNumber = @serialnumber)";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                cmd.Parameters.AddWithValue ("@serialnumber", NxDb.DriveSerialNumber);
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        public static void LOG (string logText)
            {
            if (Setting.WriteLogs == false)
                return;
            //string strDateTime = = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById ("Iran Standard Time");
            string strDateTime = TimeZoneInfo.ConvertTime (DateTime.Now, timeZoneInfo).ToString ("yyyy.MM.dd - HH:mm:ss");
            //    
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@datetime", strDateTime);
                    cmdx.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                    cmdx.Parameters.AddWithValue ("@nickname", User.NickName);
                    cmdx.Parameters.AddWithValue ("@clientname", Strings.LCase (Environment.MachineName) + " [" + NxDb.DriveSerialNumber + "] ");
                    cmdx.Parameters.AddWithValue ("@frontend", NxDb.BuildInfo);
                    cmdx.Parameters.AddWithValue ("@strlog", logText);
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        }
    static class Nxt
        {
        public static int Retval1;
        public static int Retval2;

        /*
         * [STAThread] : 
         * Using this line is important when working with FileDialogs in a Project!
         */
        [STAThread]
        public static void Main ()
            {
            Application.EnableVisualStyles ();
            DefineTables ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        public static void DefineTables ()
            {
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Columns.Add ();
            TermProg.tblThisCourseTime.Rows.Add ("1", "1", "1", "1", "1", "1", "1", "1");
            TermProg.tblThisCourseTime.Rows.Add ("1", "1", "1", "1", "1", "1", "1", "1");
            TermProg.tblThisCourseTime.Rows.Add ("1", "1", "1", "1", "1", "1", "1", "1");
            TermProg.tblThisCourseTime.Rows.Add ("1", "1", "1", "1", "1", "1", "1", "1");
            TermProg.tblThisCourseTime.Rows.Add ("1", "1", "1", "1", "1", "1", "1", "1");
            TermProg.tblThisCourseTime.Rows.Add ("1", "1", "1", "1", "1", "1", "1", "1");
            NxDb.DS.Tables.Add ("tblKeyless");
            NxDb.DS.Tables.Add ("tblDepartments");
            NxDb.DS.Tables.Add ("tblBioProgs");
            NxDb.DS.Tables.Add ("tblCourses");
            NxDb.DS.Tables.Add ("tblEntries");
            NxDb.DS.Tables.Add ("tblRooms");
            NxDb.DS.Tables.Add ("tblStaff");
            NxDb.DS.Tables.Add ("tblTechs");
            NxDb.DS.Tables.Add ("tblTerms");
            NxDb.DS.Tables.Add ("tblTermProgs");
            NxDb.DS.Tables.Add ("tblTemplates");
            NxDb.DS.Tables.Add ("tblTemplateData");
            NxDb.DS.Tables.Add ("tblSettings");
            NxDb.DS.Tables.Add ("tblAllProgs");
            NxDb.DS.Tables.Add ("tblTermExams4Entry");
            NxDb.DS.Tables.Add ("tblTermExams4Staff");
            NxDb.DS.Tables.Add ("tblMsgs");
            NxDb.DS.Tables.Add ("tblReportProgData");
            }

        public static void CreateDocument ()
            {
            try
                {
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application (); //Create an instance for word app   
                winword.ShowAnimation = false;                     //Set animation status for word application
                winword.Visible = false;                           //Set status for word application is to be visible or not.
                object missing = System.Reflection.Missing.Value;  //Create a missing variable for missing value       

                //Create a new document 
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add (ref missing, ref missing, ref missing, ref missing);
                //Add header
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                    {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers [Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add (headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlue;
                    headerRange.Font.Size = 10;
                    headerRange.Text = "Header text goes here";
                    }
                //Add footers
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                    {
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers [Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Footer text goes here";
                    }

                //add text
                document.Content.SetRange (0, 0);
                document.Content.Text = "This is test document " + Environment.NewLine;
                //Add paragraph with Heading 1
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add (ref missing);
                object styleHeading1 = "Heading 1";
                para1.Range.set_Style (ref styleHeading1);
                para1.Range.Text = "Para 1 text";
                para1.Range.InsertParagraphAfter ();

                //Add paragraph with Heading 2
                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add (ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style (ref styleHeading2);
                para2.Range.Text = "Para 2 text";
                para2.Range.InsertParagraphAfter ();

                //Create a 5X5 table
                //Table firstTable = (Table) document.Tables.Add (para1.Range, 5, 5, ref missing, ref missing);

                //firstTable.Borders.Enable = 1;
                //foreach (Row row in firstTable.Rows)
                //    {
                //    foreach (Cell cell in row.Cells)
                //        {
                //        //Header row
                //        if (cell.RowIndex == 1)
                //            {
                //            cell.Range.Text = "Column " + cell.ColumnIndex.ToString ();
                //            cell.Range.Font.Bold = 1;
                //            //other format properties goes here
                //            cell.Range.Font.Name = "verdana";
                //            cell.Range.Font.Size = 10;
                //            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;
                //            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                //            //Center alignment for the Header cells
                //            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                //            }
                //        //Data row
                //        else
                //            {
                //            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString ();
                //            }
                //        }
                //    }

                //Save the document
                object filename = @"d:\temp1.docx";
                document.SaveAs2 (ref filename);
                document.Close (ref missing, ref missing, ref missing);
                document = null;
                winword.Quit (ref missing, ref missing, ref missing);
                winword = null;
                MessageBox.Show ("Document created successfully !");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.Message);
                }
            }
        }
    internal class Prog
        {
        public static DataTable tblBioProgs = new DataTable ();
        public static long Id;
        public static string Name;
        }
    internal class Report
        {
        public static string AppOwner = NxDb.BuildInfo + " -  database: " + NxDb.DbBackEnd;
        public static string Style = "<style>table, th,td {border: 1px solid;} .button {border: none;color: black;padding: 5px 20px;Text-align: center;Text-decoration: none;display: inline-block;font-family:Tahoma;Font-Size: 12px;margin: 10px 5px;cursor: pointer;}.button1 {background-Color: lightsilver; border-radius: 4px;}.button2 {background-Color: lightgreen; border-radius: 4px;}.button3 {background-Color: salmon; border-radius: 4px;}</style>" +
         "<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n";
        public static string StyleSinBg = "<style>table, th,td {border: 1px solid;} .button {border: none;color: black;padding: 5px 20px;Text-align: center;Text-decoration: none;display: inline-block;font-family:Tahoma;Font-Size: 12px;margin: 10px 5px;cursor: pointer;}.button1 {background-Color: lightsilver; border-radius: 4px;}.button2 {background-Color: lightgreen; border-radius: 4px;}.button3 {background-Color: salmon; border-radius: 4px;}</style>"+
        "<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3\" crossorigin=\"anonymous\">\r\n";
        public static string Footerx = "<center><a href=\"http://msht.ir/NexTerm_00.html\">NexTerm</a> Desktop App <a href=\"http://msht.ir\">[ www.msht.ir ]</a> , Faculty of Science, <a href=\"https://sku.ac.ir\">SKU</a>. Developer: <a href=\"https://sku.ac.ir/en/DepartmentGroup/ProfessorForm.aspx?ID=143\">Dr. Majid Sharifi-Tehrani</a> (1400-1402 / 2021-2023)";
        public static string Footer = "<p style='font-family:tahoma; font-size:10px; text-align: center'>" + Footerx + "<hr> <button class=\"button button1\" onclick=\"location.href='http://msht.ir/NexTerm_00.html';\">nexterm guide</button> <button class=\"button button1\" onclick=\"location.href='http://msht.ir';\">website</button> <button class=\"button button1\" onclick=\"location.href='https://sku.ac.ir/en/DepartmentGroup/ProfessorForm.aspx?ID=143';\">about author</button>  <button class=\"button button3\" onclick=\"window.open('', '_self', ''); window.close();\">close</button> <hr></p></center>";
        public static int Settings = 0x3;     //&H2C = &B000000011 = 3 'bit4:DayInCols/Rows is off
        public static string BG = "bg2.png";  //background filename for html reports
        }
    internal class Room
        {
        public static DataTable tblRooms = new DataTable ();
        public static long Id;
        public static string Name;
        }
    internal class Setting
        {
        public static DataTable tblSettings = new DataTable ();
        public static bool WriteLogs;    //Log User Activity (YES/NO) in Setting
        public static void ReadSettings ()
            {
            NxDb.DS.Tables ["tblSettings"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, SettingsKey, SettingsValue From Settings ORDER BY SettingsKey", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblSettings");
                CnnSS.Close ();
                }
            /*
             * 0 current ver
             * 1 default Term ID
             * 2 educational Deputy pass
             * 3 educational Officer pass
             * 4 Log
             * 5 officer can Class
             * 6 officer can Prog
             * 7 owner info
             * 8 report bg
             */
            NxDb.CurrentVersion = NxDb.DS.Tables ["tblSettings"].Rows [0] [2].ToString ();
            TermProg.DefaultTermId = Convert.ToInt32 (NxDb.DS.Tables ["tblSettings"].Rows [1] [2].ToString ());
            User.EducationalDeputyPass = NxDb.DS.Tables ["tblSettings"].Rows [2] [2].ToString ();
            User.EducationalOfficerPass = NxDb.DS.Tables ["tblSettings"].Rows [3] [2].ToString ();

            //Log?
            if (NxDb.DS.Tables ["tblSettings"].Rows [4] [2].ToString ().ToUpper () == "YES")
                Setting.WriteLogs = true;
            else
                Setting.WriteLogs = false;

            /* officer can class
            if (NxDb.DS.Tables ["tblSettings"].Rows [5] [2].ToString ().ToUpper () == "YES")
                User.ACCs = User.ACCs | 0x4;
            else
                User.ACCs = User.ACCs & 0xFB;
            
            //officer can prog
            if (NxDb.DS.Tables ["tblSettings"].Rows [6] [2].ToString ().ToUpper () == "YES")
                User.ACCs = User.ACCs | 0x10;
            else
                User.ACCs = User.ACCs & 0xEF;
            */
            }
        }
    internal class Staff
        {
        public static DataTable tblStaff = new DataTable ();
        public static long Id;
        public static string Name;
        }
    internal class Tech
        {
        public static DataTable tblTechs = new DataTable ();
        public static long Id;
        public static string Name;
        }
    internal class Template
        {
        public static DataTable tblTemplates = new DataTable ();
        public static DataTable tblTemplateData = new DataTable ();
        public static long Id;
        public static string Name;
        }
    internal class Term
        {
        public static DataTable tblTerms = new DataTable ();
        public static long Id;
        public static string Name = "";
        public static string ExamDateStart = "";
        public static string ExamDateEnd = "";
        public static string Notes = "";
        public static bool Active = false;
        }
    internal class TermProg
        {
        public static DataTable tblTermProgs = new DataTable ();
        public static DataTable tblAllProgs = new DataTable ();     // For frmTadakhols
        public static DataTable tblTermExams = new DataTable ();
        public static DataTable tblThisCourseTime = new DataTable ();


        public static int Roomx;                                    // used in frm.Choose_Class: prog is for Room1 or Room2?
        public static int DefaultTermId;                            // a default term id : to show an entry's prog for this term by default (if not zero)
        public static string ExamDateTime;
        public static string tmpExamDateTime = "";
        public static string [] Time = new string [] { "08:30", "09:30", "10:30", "11:30", "13:30", "14:30", "15:30", "16:30" };
        public static string [] Day = new string [] { "شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
        public static int [,] TimeFlag = new int [6, 8];            // (r:6days, c:8times //begins from 0)
        public static int [] Class1DayData = new int [6];           // 5 days for Class 1
        public static int [] Class2DayData = new int [6];           // 5 days for Class 2
        public static int GridRowId;                                // used in frm.Choose_Class, showing info of occupied class-times: need row-index of Grid4 
        public static string Caption;                               // Which Grid must be shown below the main Grid?
        }
    internal class User
        {
        public static string Type;         // UserDeputy | UserOfficer | UserDepartment 
        public static int Id;              // ID of Department   (as intUser)
        public static string Usrname;      // Name of Department (as strUser)
        public static string NickName;     // Name of the User
        public static int ACCs;            // acc1-acc5 (user access controls)
        public static string EducationalDeputyPass;
        public static string EducationalOfficerPass;
        public static string DepartmentPass;

        public static void SetUserACCs ()
            {
            //reset
            User.ACCs = 0;
            switch (User.Type)
                {
                case "UserDeputy":
                    User.ACCs = 0x7F; //127=0111'1111 : +all acc 1-7
                    break;
                case "UserOfficer":
                        {
                        //can class?
                        if (NxDb.DS.Tables ["tblSettings"].Rows [5] [2].ToString ().ToUpper () == "YES")
                            User.ACCs = 0x4; //0000'0100
                        else
                            User.ACCs = User.ACCs & 0xFB; //1111'1011=251d
                                                          //can prog?
                        if (NxDb.DS.Tables ["tblSettings"].Rows [6] [2].ToString ().ToUpper () == "YES")
                            User.ACCs = User.ACCs | 0x10; //0001'0000=16d
                        else
                            User.ACCs = User.ACCs & 0xEF; //1110'1111=239d
                        break;
                        }
                case "UserDepartment":
                    /* find User in tblDepartments
                     * read flags from table
                     * set ACCs for the user
                    */
                    foreach (DataRow r in NxDb.DS.Tables ["tblDepartments"].Rows)
                        {
                        if ((int) r [0] == User.Id)
                            {
                            User.ACCs = Convert.ToInt32 (r [5].ToString ());
                            break;
                            }
                        }
                    break;
                }
            }
        }
    }