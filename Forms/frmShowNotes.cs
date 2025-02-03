using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {


    public partial class frmShowNotes
        {
        public frmShowNotes ()
            {
            InitializeComponent ();
            }
        private void frmShowNotes_Load (object sender, EventArgs e)
            {
            ShowNotes (0);
            NxDb.DS.Tables ["tblMSgs"].Clear ();
            GridNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // 0 ID
            // 1 usrFrom_ID
            // 2 usrTo_ID
            // 3 IsActive
            // 4 msgString As [پيام]
            // 5 usrTo As [به]
            // 6 usrFrom As [از]
            // 7 SentDate As [زمان]

            GridNotes.Columns [0].Visible = false;     // 0 ID
            GridNotes.Columns [1].Visible = false;     // 1 usrFrom ID
            GridNotes.Columns [2].Visible = false;     // 2 usrTo ID
            GridNotes.Columns [3].Visible = false;     // 3 Active?
            GridNotes.Columns [4].Width = 600;         // 4 msg (width: 600 +160 +160 =920)
            GridNotes.Columns [5].Width = 160;         // 5 To
            GridNotes.Columns [6].Width = 160;         // 6 From
                                                       // GridNotes.Columns(5).Visible = False    '5 To
                                                       // GridNotes.Columns(6).Visible = False    '6 From
            GridNotes.Columns [7].Width = 120;         // 7 DateSent
            for (int i = 0, loopTo = GridNotes.Columns.Count - 1; i <= loopTo; i++)
                GridNotes.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;

            ListDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            ListDepts.DisplayMember = "DEPT";
            ListDepts.ValueMember = "ID";
            ListDepts.SelectedIndex = -1;
            if (User.Type == "UserDeputy")
                {
                User.Id = 0;
                User.Usrname = "معاون آموزشي دانشکده";
                }
            Text = "کاربر : " + User.Usrname;
            ShowNotes (-1);
            txtNote.Focus ();
            }
        private void frmShowNotes_KeyDown (object sender, KeyEventArgs e)
            {
            if ((int) e.KeyCode == 27)
                {
                DialogResult myansw = MessageBox.Show ("خارج مي شويد؟", "Confirm:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (myansw == DialogResult.OK)
                    Dispose ();
                }
            }

        //SELECT Groups
        private void ListDepts_Click (object sender, EventArgs e)
            {
            try
                {
                ListDeanEdu.SelectedIndex = -1;
                switch (ListDepts.SelectedValue)
                    {
                    case var @case when Operators.ConditionalCompareObjectEqual (@case, User.Id, false):
                            {
                            // Show All
                            ShowNotes (-1);
                            ListDepts.SelectedIndex = -1;
                            break;
                            }

                    default:
                            {
                            ShowNotes (Conversions.ToInteger (Conversion.Int (ListDepts.SelectedValue)));
                            break;
                            }
                    }
                txtNote.Focus ();
                }
            catch (Exception ex)
                {
                }
            }
        private void ListDeanEdu_Click (object sender, EventArgs e)
            {
            ListDepts.SelectedIndex = -1;
            if (User.Id == 0)
                {
                ListDeanEdu.SelectedIndex = -1; //dont send msg to yourself
                // Show All
                ShowNotes (-1);
                }
            else
                {
                ShowNotes (0);
                }
            txtNote.Focus ();
            }
        private void GridNotes_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            txtNote.Text = "";
            }

        //SHOW NOTES
        private void ShowNotes (int intDeptID)
            {
            txtNote.Text = "";
            NxDb.DS.Tables ["tblMSgs"].Clear ();
            GridNotes.DataBindings.Clear ();
            try
                {
                switch (intDeptID)
                    {
                    case -1: // All <-> Me 
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, usrFrom_ID, usrTo_ID, IsActive, msgString As [پيام], usrTo As [به], usrFrom As [از], SentDate As [زمان] FROM msgs WHERE (usrFrom_ID=" + User.Id.ToString () + " OR UsrTo_ID=" + User.Id.ToString () + ") ORDER BY SentDate", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblMsgs");
                                CnnSS.Close ();
                                }
                            break;
                            }
                    case 0: // Edu <-> Me
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, usrFrom_ID, usrTo_ID, IsActive, msgString As [پيام], usrTo As [به], usrFrom As [از], SentDate As [زمان] FROM msgs WHERE (usrFrom_ID=" + User.Id.ToString () + " AND usrTo_ID=0) OR (usrTo_ID=" + User.Id.ToString () + " AND usrFrom_ID=0) ORDER BY SentDate", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblMsgs"); // Groups <-> Me
                                CnnSS.Close ();
                                }
                            break;
                            }

                    default:
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, usrFrom_ID, usrTo_ID, IsActive, msgString As [پيام], usrTo As [به], usrFrom As [از], SentDate As [زمان] FROM msgs WHERE ((usrFrom_ID=" + User.Id.ToString () + ") AND (usrTo_ID=" + intDeptID.ToString () + ")) OR ((usrTo_ID=" + User.Id.ToString () + ") AND (usrFrom_ID=" + intDeptID.ToString () + ")) ORDER BY SentDate", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblMsgs");
                                CnnSS.Close ();
                                }
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            GridNotes.DataSource = NxDb.DS.Tables ["tblMsgs"];
            //colour rows  ------   colour rows  ------   colour rows  ------   colour rows  ------   colour rows  ------   colour rows
            try
                {
                for (int i = 0, loopTo = GridNotes.Rows.Count - 1; i <= loopTo; i++)
                    {
                    for (int j = 1; j <= 7; j++)
                        {
                        GridNotes [j, i].Style.BackColor = Color.FromArgb (244, 244, 244); // Color.LightGray
                        GridNotes [j, i].Style.ForeColor = Color.Black;
                        }
                    if (Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblMsgs"].Rows [i] [3], true, false))
                        {
                        if (Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblMsgs"].Rows [i] [2], User.Id, false))
                            {
                            GridNotes [7, i].Style.BackColor = Color.LightCyan;
                            }
                        else
                            {
                            GridNotes [7, i].Style.BackColor = Color.MistyRose;
                            }
                        }
                    }
                GridNotes.CurrentCell = GridNotes [0, 0];
                }
            catch (Exception ex)
                {
                }
            }

        //SEND NOTE
        private void txtNote_KeyDown (object sender, KeyEventArgs e)
            {
            if ((int) e.KeyCode == 13)
                {
                string strDatex = DateTime.Now.ToString ("yyyy.MM.dd - HH:mm"); // 18 chars
                string strMessage = Strings.Trim (txtNote.Text);
                if (string.IsNullOrEmpty (strMessage))
                    return;
                if (ListDeanEdu.SelectedIndex == 0)
                    {
                    Department.Id = 0L;
                    Department.Name = "معاون آموزشي دانشکده";
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "INSERT INTO msgs (SentDate, usrFrom, usrFrom_ID, usrTo, usrTo_ID, msgString, IsActive) VALUES (@sentdate, @usrfrom, @usrfromid, @usrto, @usrtoid, @msgstring, 1)";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@sentdate", strDatex);
                        cmd.Parameters.AddWithValue ("@usrfrom", User.Usrname);
                        cmd.Parameters.AddWithValue ("@usrfromid", User.Id);
                        cmd.Parameters.AddWithValue ("@usrto", Department.Name);
                        cmd.Parameters.AddWithValue ("@usrtoid", Department.Id);
                        cmd.Parameters.AddWithValue ("@msgstring", strMessage);
                        cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ShowNotes (-1);
                    }
                else if (ListDepts.SelectedIndex != -1)
                    {
                    Department.Id = Conversions.ToLong (ListDepts.SelectedValue);
                    Department.Name = ListDepts.Text;
                    if (Department.Id == 0L)
                        return;
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        try
                            {
                            NxDb.strSQL = "INSERT INTO msgs (SentDate, usrFrom, usrFrom_ID, usrTo, usrTo_ID, msgString, IsActive) VALUES (@sentdate, @usrfrom, @usrfromid, @usrto, @usrtoid, @msgstring, 1)";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@sentdate", strDatex);
                            cmd.Parameters.AddWithValue ("@usrfrom", User.Usrname); // & " " & UserNickName)
                            cmd.Parameters.AddWithValue ("@usrfromid", User.Id);
                            cmd.Parameters.AddWithValue ("@usrto", Department.Name);
                            cmd.Parameters.AddWithValue ("@usrtoid", Department.Id);
                            cmd.Parameters.AddWithValue ("@msgstring", strMessage);
                            cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }
                        }
                    ShowNotes (Conversions.ToInteger (Conversion.Int (ListDepts.SelectedValue)));
                    }
                else
                    {
                    return;
                    }
                e.SuppressKeyPress = true;
                }
            }

        //Delete/Tag
        private void GridNotes_DoubleClick (object sender, EventArgs e)
            {
            if (GridNotes.RowCount < 1)
                return;
            int r = GridNotes.CurrentCell.RowIndex;
            int c = GridNotes.CurrentCell.ColumnIndex;
            if (r < 0)
                return;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblMsgs"].Rows [r] [1], User.Id.ToString (), false)))
                {
                txtNote.Text = "اين يادداشت ارسالي از خود شما است؛ نمي توانيد وضعيت آن را تغيير دهيد";
                return;
                }
            bool boolActive = Conversions.ToBoolean (NxDb.DS.Tables ["tblMsgs"].Rows [r] [3]);
            if (boolActive == true)
                boolActive = false;
            else
                boolActive = true; // toggle
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "UPDATE msgs SET IsActive = @boolactive WHERE ID = @id";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@boolactive", boolActive);
                    cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblMsgs"].Rows [r] [0].ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                ShowNotes (-1);
                }
            catch (Exception ex)
                {
                }
            }
        private void Menu_IsRead_Click (object sender, EventArgs e)
            {
            GridNotes_DoubleClick (sender, e);
            }
        private void Menu_Del_Click (object sender, EventArgs e)
            {
            if (GridNotes.RowCount < 1)
                return;
            int r = GridNotes.CurrentCell.RowIndex;
            if (r < 0)
                return;
            // If (DS.Tables("tblMsgs").Rows(r).Item(2) <> intUser.ToString) Then 'And (DS.Tables("tblMsgs").Rows(r).Item(3) = False)
            // txtNote.Text = "پيام ارسالي خودتان را نمي توانيد حذف کنيد"
            // Exit Sub
            // End If
            // If (DS.Tables("tblMsgs").Rows(r).Item(3) = True) Then
            // txtNote.Text = "اين پيام هنوز (خوانده نشده) است  - پيام هاي جديد را با (دبل کليک) در حالت (خوانده شده) قرار دهيد"
            // Exit Sub
            // End If
            DialogResult myansw = (DialogResult) MessageBox.Show ("يادداشت انتخاب شده حذف شود؟", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                return;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "DELETE FROM msgs WHERE ID=@id";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblMsgs"].Rows [r] [0].ToString ());
                    cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                ShowNotes (-1);
                }
            catch (Exception ex)
                {
                }
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void MenuExit2_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu_Help_Click (object sender, EventArgs e)
            {
            //Help
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=rtl>");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>راهنما</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>راهنماي نکسترم</p>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> بررسي پيام ها <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "روي دکمه (همه پيام ها) کليک کنيد<br>");
            FileSystem.PrintLine (1, "به ستون هاي (از) و (به) و پيام هايي که فرستاده ايد يا دريافت کرده ايد توجه کنيد <br>");
            FileSystem.PrintLine (1, "پيام هايي که دريافت کرده ايد ولي هنوز نخوانده ايد، درستون (زمان) با رنگ آبي مشخص شده اند<br>");
            FileSystem.PrintLine (1, "پيام هايي که ارسال کرده ايد ولي مخاطب هنوز نخوانده است، با رنگ قرمز در ستون (به) مشخص شده اند<br>");
            FileSystem.PrintLine (1, "روي يک مخاطب (در سمت راست) کليک کنيد : فقط پيام هاي بين شما و آن مخاطب را مشاهده مي کنيد<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> ارسال <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "براي ارسال پيام، يک مخاطب را از ليست (سمت راست) انتخاب و راست کليک کنيد و گزينه ارسال را از منو انتخاب کنيد  <br>");
            FileSystem.PrintLine (1, "پيام ارسالي فقط بوسيله گيرنده، و پس از مشاهده پيام، قابل حذف مي باشد<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> خواندن <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "براي خواندن يک پيام، روي آن دبل کليک کنيد تا رنگ آبي (در ستون زمان) سفيد شود <br>");
            FileSystem.PrintLine (1, "پس از خواندن يک پيام، مي توانيد آن را حذف نماييد <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> حذف <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "براي حذف يک پيام، ابتدا بايد آن را بخوانيد (رنگ سفيد در ستون زمان)<br>");
            FileSystem.PrintLine (1, "سپس با راست کليک روي پيام، گزينه حذف را از منو انتخاب کنيد<br>");
            FileSystem.PrintLine (1, "پيام حذف شده قابل بازيافت نيست <br>");
            FileSystem.PrintLine (1, "");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br></p>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            }

        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }