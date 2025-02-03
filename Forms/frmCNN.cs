using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class frmCNN
        {
        //define a table for connections in the cnn textfile
        private DataTable tblConnection = new DataTable ();
        public frmCNN ()
            {
            InitializeComponent ();
            }
        //form Load
        private void cnn_Load (object sender, EventArgs e)
            {
            NxDb.GetSerialNumber ();
            //MessageBox.Show ("SN:  " + Client.DriveSerialNumber);
            int intYear = Convert.ToInt32 (DateTime.Now.ToString ("yyyy").ToString ());
            if (intYear > 1450)
                {
                DialogResult myansw = MessageBox.Show ("بهتر است تقويم ويندوز را به شمسي (تقويم جلالي) تغيير دهيد\n \n نمايش راهنما؟", "تنظيمات ويندوز", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (myansw == DialogResult.Yes)
                    {
                    ShowGuide4Calendar ();
                    }
                }
            My.MyProject.Forms.frmTermProgs.Dispose ();
            NxDb.GetBuildInfo (); //from file strFilename
            //Text = NxDb.BuildInfo;
            string strConnectionName = "";
            string strConnectionAddress = "";
            string strConnectionCnnString = "";
            tblConnection.Columns.Add ("Database", typeof (string));
            tblConnection.Columns.Add ("انتخاب ديتابيس", typeof (string));
            tblConnection.Columns.Add ("cnn", typeof (string));
            NxDb.Filename = Application.StartupPath + "cnn";
            if (System.IO.File.Exists (NxDb.Filename) == true)
                {
                FileSystem.FileOpen (1, NxDb.Filename, OpenMode.Input);
                while (!FileSystem.EOF (1))
                    {
                    try
                        {
                        string strx1 = FileSystem.LineInput (1);
                        if (strx1 == "NexTerm Connection")
                            {
                            strConnectionName = FileSystem.LineInput (1);
                            strConnectionAddress = FileSystem.LineInput (1);
                            strConnectionCnnString = FileSystem.LineInput (1);
                            tblConnection.Rows.Add (strConnectionName, strConnectionAddress, strConnectionCnnString);
                            }
                        }
                    catch (Exception ex)
                        {
                        }
                    }
                FileSystem.FileClose (1);
                GridCNN.DataBindings.Clear ();
                GridCNN.DataSource = tblConnection;
                GridCNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                GridCNN.Columns [0].Visible = false;    //cnn name
                GridCNN.Columns [1].Width = 360;        //cnn address
                GridCNN.Columns [2].Visible = false;    //cnn string

                //disable grid cols manual-sort
                for (int i = 0, loopTo = GridCNN.Columns.Count - 1; i <= loopTo; i++)
                    //disable sort for column_haeders
                    GridCNN.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                GridCNN.Refresh ();
                }
            }

        //Select a Database
        private void GridCNN_Click (object sender, EventArgs e)
            {
            lstUsers.Visible = false;
            PasswordTextBox.Text = "";
            PasswordTextBox.Visible = false;
            }
        private void Menu_Select_Click (object sender, EventArgs e)
            {
            SelectBackEnd ();
            }
        private void GridCNN_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            SelectBackEnd ();
            }
        private void GridCNN_KeyDown (object sender, KeyEventArgs e)
            {
            if ((int) e.KeyCode == 13 | (int) e.KeyCode == 39)
                {
                SelectBackEnd ();
                e.SuppressKeyPress = true;
                }
            }
        private void SelectBackEnd ()
            {
            //a server is selectd from the grid at leftPanel
            if (GridCNN.RowCount < 1)
                return;
            int r = GridCNN.SelectedCells [0].RowIndex;    // count from 0
            int c = GridCNN.SelectedCells [0].ColumnIndex; // count from 0            
            if (r < 0 | c < 0)
                return;
            NxDb.Server2Connect = Strings.Trim (GridCNN [0, r].Value.ToString ());   // 0 connection name
            if (string.IsNullOrEmpty (NxDb.Server2Connect))
                return;
            NxDb.DbBackEnd = Strings.Trim (GridCNN [1, r].Value.ToString ());        // 1 connection name
            NxDb.CnnString = Strings.Trim (GridCNN [2, r].Value.ToString ());        // 2 connection cnnstring
            //connect now
            switch (NxDb.Connect2DB (NxDb.CnnString))
                {
                case "connected":
                    //a.Read Settings
                    Setting.ReadSettings ();
                    //b.show users
                    lstUsers.Visible = true;
                    PasswordTextBox.Visible = true;
                    lstUsers.Focus ();
                    try
                        {
                        lstUsers.DataSource = NxDb.DS.Tables ["tblDepartments"];
                        lstUsers.DisplayMember = "DEPT";
                        lstUsers.ValueMember = "ID";
                        lstUsers.SelectedValue = User.Id;
                        //PasswordTextBox.Focus ();
                        PasswordTextBox.Text = ".";
                        PasswordTextBox.Text = "";
                        }
                    catch (Exception ex)
                        {
                        //MessageBox.Show (ex.ToString ());
                        }
                    break;
                default:
                    My.MyProject.Forms.ChooseStaff.Dispose ();
                    My.MyProject.Forms.ChooseTech.Dispose ();
                    Application.Exit ();
                    Environment.Exit (0);
                    break;
                }
            }

        //Enter Password
        private void lstUsers_Click (object sender, EventArgs e)
            {
            PasswordTextBox.SelectionStart = 0;
            PasswordTextBox.SelectionLength = PasswordTextBox.TextLength;
            }
        private void lstUsers_SelectedIndexChanged (object sender, EventArgs e)
            {
            lstUsers.Focus ();
            }
        private void lstUsers_KeyDown (object sender, KeyEventArgs e)
            {
            if ((int) e.KeyCode == 13 | (int) e.KeyCode == 39)
                {
                lstUsers_DoubleClick (null, null);
                e.SuppressKeyPress = true;
                }
            else if (((int) e.KeyCode == 37) | ((int) e.KeyCode == 27)) //left or esc
                {
                lstUsers.Visible = false;
                //GridCNN.Visible = true;
                GridCNN.Focus ();
                GridCNN_Click (sender, e);
                }
            }
        private void lstUsers_DoubleClick (object sender, EventArgs e)
            {
            if (lstUsers.SelectedIndex == -1)
                return;
            try
                {
                User.Id = Convert.ToInt32 (lstUsers.SelectedValue.ToString ());
                //Check Keyless Clients
                if (NxDb.CheckKeylessClient () == true)
                    {
                    //ok login keyless
                    PasswordTextBox.Text = NxDb.DS.Tables ["tblDepartments"].Rows [lstUsers.SelectedIndex] [4].ToString ();
                    }
                PasswordTextBox.Text = ".";
                PasswordTextBox.Text = "";
                PasswordTextBox.Focus ();
                }
            catch (Exception ex)
                {
                }
            }
        private void PasswordTextBox_KeyDown (object sender, KeyEventArgs e)
            {
            if (((int) e.KeyCode == 38) | ((int) e.KeyCode == 40) | ((int) e.KeyCode == 27)) //up, down, esc
                {
                lstUsers.Focus ();
                e.SuppressKeyPress = true;
                }
            }
        private void PasswordTextBox_TextChanged (object sender, EventArgs e)
            {
            string txt = PasswordTextBox.Text;
            //USER?
            if (lstUsers.SelectedIndex == -1)
                {
                return;
                }
            int usr = 0;
            try
                {
                if (lstUsers.SelectedValue is DBNull)
                    usr = 0;
                else
                    usr = (int) lstUsers.SelectedValue;
                }
            catch (Exception ex)
                {
                MessageBox.Show ("okkkk!\n" + ex.ToString ());
                }
            //TEXT CHANGE
            if ((txt == "") | (string.IsNullOrEmpty (Strings.Trim (txt))))
                {
                PasswordTextBox.Text = "password";
                PasswordTextBox.SelectionStart = 0;
                PasswordTextBox.SelectionLength = 8;
                PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                }
            else
                PasswordTextBox.PasswordChar = '-';

            //EXIT
            if ((txt.ToLower () == "quit") | (txt.ToLower () == "exit")) //quit
                {
                PasswordTextBox.Text = "Exit? yes / no";
                PasswordTextBox.SelectionStart = 6;
                PasswordTextBox.SelectionLength = 10;
                PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                }
            else if (txt.ToLower () == "exit? y")
                {
                User.Type = "quit";
                Dispose ();
                Environment.Exit (0);
                }
            else if (txt.ToLower () == "exit? n")
                {
                PasswordTextBox.Text = "";
                }

            //INFO
            if ((txt.ToLower () == "info") | (txt.ToLower () == "exit"))
                {
                PasswordTextBox.Text = "visit msht.ir / call +989133112733 ";
                PasswordTextBox.SelectionStart = 0;
                PasswordTextBox.SelectionLength = PasswordTextBox.TextLength;
                PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                }

            //USERS
            else if (txt == "mshtaccesson")
                {
                User.Type = "UserDeputy";
                User.SetUserACCs ();
                Dispose ();
                My.MyProject.Forms.frmTermProgs.ShowDialog ();
                }
            else if ((txt) == (User.EducationalDeputyPass))
                {
                User.Type = "UserDeputy";
                User.SetUserACCs ();
                Dispose ();
                My.MyProject.Forms.frmTermProgs.ShowDialog ();
                }
            else if ((txt) == (User.EducationalOfficerPass))
                {
                User.Type = "UserOfficer";
                User.SetUserACCs ();
                Dispose ();
                My.MyProject.Forms.frmTermProgs.ShowDialog ();
                }
            else //usr must be department
                {
                User.Id = Conversions.ToInteger (lstUsers.SelectedValue); //ID of selected Department
                if (User.Id == 0)
                    return;
                if (txt == NxDb.DS.Tables ["tblDepartments"].Rows [lstUsers.SelectedIndex] [4].ToString ())
                    {
                    User.Type = "UserDepartment";
                    User.Usrname = lstUsers.Text;
                    User.Id = (int) lstUsers.SelectedValue;
                    User.SetUserACCs ();
                    Dispose ();
                    My.MyProject.Forms.frmTermProgs.ShowDialog ();
                    }
                }
            }
        //MENU-1 Left panel
        private void Menu_Edit_Click (object sender, EventArgs e)
            {
            try
                {
                if (GridCNN.RowCount < 1)
                    return;
                int r = GridCNN.SelectedCells [0].RowIndex;    // count from 0
                int c = GridCNN.SelectedCells [0].ColumnIndex; // count from 0
                if (r < 0 | c < 0)
                    return;
                string strValue = Conversions.ToString (GridCNN [c, r].Value);
                strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "تنظيمات اتصال به ديتابيس", strValue);
                GridCNN [c, r].Value = strValue;
                SaveChanges (); // AutoSave
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void SaveChanges ()
            {
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "cnn", OpenMode.Output);
                for (int r = 0, loopTo = GridCNN.Rows.Count - 1; r <= loopTo; r++)
                    {
                    if (GridCNN [0, r].Value is DBNull)
                        {
                        GridCNN [0, r].Value = "untitled Connection";
                        }
                    for (int c = 0; c <= 3; c++)
                        {
                        if (GridCNN [c, r].Value is DBNull)
                            GridCNN [c, r].Value = "";
                        }
                    }
                for (int r = 0, loopTo1 = GridCNN.Rows.Count - 1; r <= loopTo1; r++)
                    {
                    FileSystem.PrintLine (1, "NexTerm Connection");
                    FileSystem.PrintLine (1, GridCNN [0, r].Value); // 0 connection name
                    FileSystem.PrintLine (1, GridCNN [1, r].Value); // 1 connection address
                    FileSystem.PrintLine (1, GridCNN [2, r].Value); // 2 connection username
                    FileSystem.PrintLine (1, GridCNN [3, r].Value); // 3 connection password
                    FileSystem.PrintLine (1, " ");
                    }
                FileSystem.FileClose (1);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu_Guide_Click (object sender, EventArgs e)
            {
            try
                {
                var pWeb = new Process ();
                pWeb.StartInfo.UseShellExecute = true;
                pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir";
                pWeb.Start ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", "مرورگر اج پيدا نشد", MessageBoxButtons.OK);
                }
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            Environment.Exit (0);
            }
        //MENU-2 Right panel
        private void Menu2_Guide_Click (object sender, EventArgs e)
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
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> راهنماي استفاده از نرم افزار <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "نام دانشکده خود را از ليست انتخاب کنيد <br>");
            FileSystem.PrintLine (1, "راست کليک کنيد و گزينه انتخاب / ادامه را کليک کنيد  <br>");
            FileSystem.PrintLine (1, "از ليست سمت راست گروه خود را انتخاب کنيد و کلمه رمز را وارد کنيد <br>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, "براي راهنمايي بيشتر به وبسايت   ");
            FileSystem.PrintLine (1, " <a href=\"http://www.msht.ir\">  msht.ir</a>  ");
            FileSystem.PrintLine (1, "   بخش نکسترم  مراجعه کنيد  <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:green;font-family:tahoma; font-size:14px'> راه اندازي اوليه <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "در شروع استفاده از نکسترم، راه اندازي اوليه (توسط ادمين نکسترم) بصورت زير انجام شود <br>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, "</p> <br>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> براي آموزش دانشکده <br></p>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "ليست گروه هاي آموزشي دانشکده در بخش منابع واردشود <br>");
            FileSystem.PrintLine (1, "ليست کارشناسان آزمايشگاه ها در بخش منابع واردشود <br>");
            FileSystem.PrintLine (1, "ليست کلاس ها و آزمايشگاه ها در بخش منابع واردشود <br>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, "</p> <br>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> براي مدير گروه آموزشي <br></p>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "ليست اساتيد گروه (در بخش منابع) واردشده باشند  <br>");
            FileSystem.PrintLine (1, "ليست دوره هاي آموزشي گروه (در بخش منابع) واردشده باشند <br>");
            FileSystem.PrintLine (1, "دربخش منابع، براي هر دوره آموزشي ليست درس ها واردشده باشند  <br>");
            FileSystem.PrintLine (1, "دربخش منابع، براي هر دوره آموزشي ليست ورودي هاي فعال واردشده باشند  <br>");
            FileSystem.PrintLine (1, " <br>");
            FileSystem.PrintLine (1, "براي هر دوره آموزشي دست کم يک برنامه الگو (ترميک) طراحي و ثبت شده باشد <br>");
            FileSystem.PrintLine (1, "به هر ورودي فعال، برنامه الگو اختصاص داده شده باشد <br>");
            FileSystem.PrintLine (1, "برنامه پيش روي هر ورودي بررسي شده باشد تا دانشجويان هر ورودي بتوانند نهايتا در ترمي که تعيين شده، فارغ التحصيل شوند <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "آموزش مصور و فيلم هاي آموزشي مربوط به نکسترم را در بخش نکسترم در وبسايت مولف ببينيد<br>");
            FileSystem.PrintLine (1, "<br></p>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            }
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            Environment.Exit (0);
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            Environment.Exit (0);
            }
        private void ShowGuide4Calendar ()
            {
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=\"ltr\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>راهنما</title>");
            FileSystem.PrintLine (1, Report.Style); //strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>راهنماي نرم افزار نکسترم</p>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:blue;font-family:tahoma; font-size:14px'> راهنماي تبديل تقويم ويندوز به هجري يا جلالي<br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            //
            FileSystem.PrintLine (1, "Go to ControlPanel of your PC, then select: Region <br>");
            FileSystem.PrintLine (1, "Set Format to: Persian(Iran)  <br>");
            FileSystem.PrintLine (1, "Click : Additional Settings...  <br>");
            FileSystem.PrintLine (1, "Set Decimal Points to: period (.) <br>");
            FileSystem.PrintLine (1, "Click: Date <br>");
            FileSystem.PrintLine (1, "Set Calendat Type to : Hijri Farsi <br>");
            FileSystem.PrintLine (1, "Save <br>");
            FileSystem.PrintLine (1, "براي راهنمايي بيشتر به وبسايت   ");
            FileSystem.PrintLine (1, " <a href=\"http://www.msht.ir\">  msht.ir</a>  ");
            FileSystem.PrintLine (1, "   بخش نکسترم مراجعه کنيد  <br>");
            FileSystem.PrintLine (1, " <a href=\"https://msht.ir/NexTerm_00.html\" >  msht.ir</a>  ");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "   راهنما  <br>");
            FileSystem.PrintLine (1, " <a href=\"https://drive.google.com/file/d/18w80t6TAuQT9B6Hyn42FhcQSCpOFlmxx/view?usp=drive_link\" >  راهنماي مصور</a>  ");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<br></p>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            }
        private void Label2_DoubleClick (object sender, EventArgs e)
            {
            Menu2_Guide_Click (null, null);
            }

        }
    }