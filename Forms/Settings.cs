using System;
using System.Data;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class Settings
        {
        public int cmdLineStatus = 0;

        public Settings ()
            {
            InitializeComponent ();
            }
        private void Settings_Load (object sender, EventArgs e)
            {
            // READ FROM DATABASE
            NxDb.DS.Tables ["tblSettings"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, SettingsKey, SettingsValue, Notes, Header FROM Settings WHERE Header ='pref' ORDER BY SettingsKey", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblSettings");
                CnnSS.Close ();
                }
            GridSettings.DataSource = NxDb.DS.Tables ["tblSettings"];
            GridSettings.Refresh ();
            GridSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridSettings.Columns [0].Visible = false;    // ID
            GridSettings.Columns [1].Width = 180;        // SettingsKey
            GridSettings.Columns [2].Width = 200;        // SettingsValue
            GridSettings.Columns [3].Width = 325;        // Note (Description)
            GridSettings.Columns [4].Visible = false;    // Header
            //disable col sort
            for (int k = 0, loopTo = GridSettings.Columns.Count - 1; k <= loopTo; k++)
                GridSettings.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
            txtCMD.Text = "";
            txtCMD.Focus ();
            }
        private void GridSettings_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (GridSettings.RowCount < 1)
                return;
            int r = e.RowIndex;    // count from 0
            int c = e.ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;
            if (c != 2)
                return;
            //
            string sttng = NxDb.DS.Tables ["tblsettings"].Rows [r] [2].ToString();
            switch (r)
                {
                
                case 1: //Default Term ID
                        {
                        My.MyProject.Forms.ChooseTerm.ShowDialog ();
                        sttng = Strings.Trim (Term.Id.ToString ());
                        if (string.IsNullOrEmpty (sttng))
                            return;
                        NxDb.DS.Tables ["tblSettings"].Rows [r] [2] = sttng;
                        NxDb.DS.Tables ["tblSettings"].Rows [r] [3] = "Default Term: " + Term.Name;
                        TermProg.DefaultTermId = (int) Term.Id;
                        MessageBox.Show ("Default Term changed to: " + Term.Name, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // WriteLOG(n)
                        SaveSettings (); // Other settings?
                        break;
                        }
                case 5: //Officer can Class
                        {
                        if (NxDb.DS.Tables ["tblSettings"].Rows [r] [2].ToString() == "NO")
                            {
                            sttng = "YES";
                            NxDb.DS.Tables ["tblSettings"].Rows [r] [2] = sttng;
                            NxDb.LOG ("admin.class on");
                            }
                        else //already was NO
                            {
                            sttng = "NO";
                            NxDb.DS.Tables ["tblSettings"].Rows [r] [2] = sttng;
                            NxDb.LOG ("admin.class off");
                            }
                        SaveSettings ();
                        break;
                        }
                case 6: //Officer can Prog
                        {
                        if (NxDb.DS.Tables ["tblSettings"].Rows [r] [2].ToString() == "NO")
                            {
                            sttng = "YES";
                            NxDb.DS.Tables ["tblSettings"].Rows [r] [2] = sttng;
                            NxDb.LOG ("admin.prog on");
                            }
                        else //already was YES
                            {
                            sttng = "NO";
                            NxDb.DS.Tables ["tblSettings"].Rows [r] [2] = sttng;
                            NxDb.LOG ("admin.prog off");
                            }
                        SaveSettings ();
                        break;
                        }
                case 8: //Reports bg
                        {
                        using (var dialog = new OpenFileDialog () { InitialDirectory = Application.StartupPath, Filter = "Image files (PNG format)|*.png" })
                            {
                            if (dialog.ShowDialog () == DialogResult.OK)
                                {
                                sttng = dialog.FileName;
                                }
                            else
                                {
                                Dispose ();
                                return;
                                }
                            }
                        sttng = sttng.Replace (@"\", "/");
                        NxDb.DS.Tables ["tblSettings"].Rows [6] [2] = sttng;
                        SaveSettings ();
                        break;
                        }
                default:
                        {
                        break;
                        }
                    /*
                    * sttng = Trim(InputBox("تغيير داده شود به", "تنظيمات نکسترم", sttng))
                    * If sttng = "" Then Exit Sub
                    * DS.Tables("tblSettings").Rows(r).Item(2) = sttng
                    */
                }
            txtCMD.Focus ();

            }
        private void txtCMD_TextChanged (object sender, EventArgs e)
            {
            // txtCMD.Text = Trim(txtCMD.Text)
            if (string.IsNullOrEmpty (txtCMD.Text))
                return;
            try
                {
                switch (cmdLineStatus)
                    {
                    case 0: //Ready for Commands
                            {
                            switch (Strings.Trim (txtCMD.Text.ToLower ()))
                                {
                                case "cmd": // "help" "guide"
                                        {
                                        cmdHelp_settings ();
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        break;
                                        }
                                case "class on":
                                case "classon":
                                        {
                                        NxDb.DS.Tables ["tblSettings"].Rows [5] [2] = "YES"; //Grid-Col: 5
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        NxDb.LOG ("admin.class on");
                                        break;
                                        }
                                case "class off":
                                case "classoff":
                                        {
                                        NxDb.DS.Tables ["tblSettings"].Rows [5] [2] = "NO";  //Grid-Col: 5
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        NxDb.LOG ("admin.class off");
                                        break;
                                        }
                                case "prog on":
                                case "progon":
                                        {
                                        NxDb.DS.Tables ["tblSettings"].Rows [6] [2] = "YES"; //Grid-Col: 6
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        NxDb.LOG ("admin.prog on");
                                        break;
                                        }
                                case "prog off":
                                case "progoff":
                                        {
                                        NxDb.DS.Tables ["tblSettings"].Rows [6] [2] = "NO";  //Grid-Col: 6
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        NxDb.LOG ("admin.prog off");
                                        break;
                                        }
                                case "deputy pass":
                                case "deputypass":
                                        {
                                        cmdLineStatus = 2; //be ready for input deputy pass
                                        txtCMD.Text = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [2] [2]); // Grid-Col: 2
                                        txtCMD.SelectionStart = Strings.Len (txtCMD.Text);
                                        break;
                                        }
                                case "officer pass":
                                case "officerpass":
                                        {
                                        cmdLineStatus = 3; //be ready for input officer pass
                                        txtCMD.Text = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [3] [2]); // Grid-Col: 3
                                        txtCMD.SelectionStart = Strings.Len (txtCMD.Text);
                                        break;
                                        }
                                case "version":
                                        {
                                        cmdLineStatus = 4; //be ready for input build info
                                        txtCMD.Text = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [0] [2]); // Grid-Col: 0
                                        txtCMD.SelectionStart = Strings.Len (txtCMD.Text);
                                        break;
                                        }
                                case "log on":
                                case "logon":
                                        {
                                        NxDb.DS.Tables ["tblSettings"].Rows [4] [2] = "YES";       //Grid-Col: 4
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        NxDb.LOG ("usr.log on");
                                        break;
                                        }
                                case "log off":
                                case "logoff":
                                        {
                                        NxDb.DS.Tables ["tblSettings"].Rows [4] [2] = "NO";        //Grid-Col: 4
                                        txtCMD.Text = "";
                                        cmdLineStatus = 0;
                                        NxDb.LOG ("usr.log off");
                                        break;
                                        }
                                case "owner info":
                                case "ownerinfo":
                                        {
                                        cmdLineStatus = 5; //be ready for input owner info
                                        txtCMD.Text = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [7] [2]); // Grid-Col: 7
                                        txtCMD.SelectionStart = Strings.Len (txtCMD.Text);
                                        break;
                                        }
                                case "exit": //"quit"
                                        {
                                        Menu_ExitSetup_Click (sender, e);
                                        break;
                                        }
                                }
                            break;
                            }
                    case 2: 
                            {
                            //input deputy pass
                            if (Strings.Trim (txtCMD.Text.ToLower ()) == "quit" | Strings.Trim (txtCMD.Text.ToLower ()) == "exit" | Strings.Trim (txtCMD.Text.ToLower ()) == "cancel")
                                return;
                            if (Strings.Mid (txtCMD.Text, Strings.Len (txtCMD.Text), 1) == "#")
                                {
                                string sttng = Strings.Mid (txtCMD.Text, 1, Strings.Len (txtCMD.Text) - 1);
                                NxDb.DS.Tables ["tblSettings"].Rows [2] [2] = sttng; // --- Grid-Col: 2
                                SaveSettings ();
                                NxDb.LOG ("admin.pass?");
                                cmdLineStatus = 0; // reset, ready for commands
                                txtCMD.Text = "";
                                }
                            break;
                            }
                    case 3:
                            {
                            //input officer pass
                            if (Strings.Trim (txtCMD.Text.ToLower ()) == "quit" | Strings.Trim (txtCMD.Text.ToLower ()) == "exit" | Strings.Trim (txtCMD.Text.ToLower ()) == "cancel")
                                return;
                            if (Strings.Mid (txtCMD.Text, Strings.Len (txtCMD.Text), 1) == "#")
                                {
                                string sttng = Strings.Mid (txtCMD.Text, 1, Strings.Len (txtCMD.Text) - 1);
                                NxDb.DS.Tables ["tblSettings"].Rows [3] [2] = sttng; // --- Grid-Col: 3
                                SaveSettings ();
                                NxDb.LOG ("admin.pass?");
                                cmdLineStatus = 0; // reset, ready for commands
                                txtCMD.Text = "";
                                }
                            break;
                            }
                    case 4: 
                            {
                            //input build info
                            if (Strings.Trim (txtCMD.Text.ToLower ()) == "quit" | Strings.Trim (txtCMD.Text.ToLower ()) == "exit" | Strings.Trim (txtCMD.Text.ToLower ()) == "cancel")
                                return;
                            if (Strings.Mid (txtCMD.Text, Strings.Len (txtCMD.Text), 1) == "#")
                                {
                                string sttng = Strings.Mid (txtCMD.Text, 1, Strings.Len (txtCMD.Text) - 1);
                                NxDb.DS.Tables ["tblSettings"].Rows [0] [2] = sttng; // --- Grid-Col: 0
                                SaveSettings ();
                                NxDb.LOG ("build.info?");
                                cmdLineStatus = 0; // reset, ready for commands
                                txtCMD.Text = "";
                                }

                            break;
                            }
                    case 5: 
                            {
                            //input owner info
                            if (Strings.Trim (txtCMD.Text.ToLower ()) == "quit" | Strings.Trim (txtCMD.Text.ToLower ()) == "exit" | Strings.Trim (txtCMD.Text.ToLower ()) == "cancel")
                                return;
                            if (Strings.Mid (txtCMD.Text, Strings.Len (txtCMD.Text), 1) == "#")
                                {
                                string sttng = Strings.Mid (txtCMD.Text, 1, Strings.Len (txtCMD.Text) - 1);
                                NxDb.DS.Tables ["tblSettings"].Rows [7] [2] = sttng; // --- Grid-Col: 7
                                SaveSettings ();
                                NxDb.LOG ("owner.info?");
                                cmdLineStatus = 0; // reset, ready for commands
                                txtCMD.Text = "";
                                }
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void cmdHelp_settings ()
            {
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=\"ltr\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>راهنماي فرامين</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>Faculty of Science, SKU</p>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:blue;font-family:tahoma; font-size:14px'>Command-line CMDs - Settings<br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><Quick list</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:14px; border-collapse:collapse'>");
            // Header
            FileSystem.PrintLine (1, "<tr><th>Command > _</th><th>function / notes</th</tr>");
            // Rows
            FileSystem.PrintLine (1, "<tr><td> cmd                     </td> <td>- show this guide (list of commands in settings)           </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> log on                  </td> <td>- log user activities                                       </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> log off                 </td> <td>- disable log                                               </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> class on                </td> <td>- enable faculty-user to set classes                        </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> class off               </td> <td>- disable faculty-user to set classes                       </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> prog on                 </td> <td>- enable faculty-user to programme like a department-user   </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> prog off                </td> <td>- disable faculty-user to programme like a department-user  </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> admin pass -----#       </td> <td>- change admin (faculty-user) password                      </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> version --------#       </td> <td>- change version info on this database                      </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> owner info -----#       </td> <td>- change owner info of this database                        </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> quit                    </td> <td>- exit settings                                             </td></tr>");
            FileSystem.PrintLine (1, "<tr><td> exit                    </td> <td>- exit settings                                             </td></tr>");
            FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            txtCMD.Focus ();

            }
        private void SaveSettings ()
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                for (int r = 0; r <= (GridSettings.Rows.Count - 1); r++)
                    {
                    NxDb.strSQL = "UPDATE Settings SET SettingsValue = @sttng WHERE ID = @id";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@sttng", NxDb.DS.Tables ["tblsettings"].Rows [r] [2]);
                    cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblSettings"].Rows [r] [0].ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                CnnSS.Close ();
                }
            }
        private void Menu_ExitSetup_Click (object sender, EventArgs e)
            {
            SaveSettings ();
            NxDb.DS.Tables ["tblSettings"].Clear ();
            try
                {
                //Get all prefs//
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, SettingsKey, SettingsValue From Settings ORDER BY SettingsKey", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblSettings");
                    CnnSS.Close ();
                }
                /*
                 *0 Current Version
                 *1 Default Term ID
                 *2 Educational Deputy pass
                 *3 Educational Officer pass
                 *4 Log
                 *5 Officer can Class 2^2
                 *6 Officer can Prog  2^4
                 *7 Owner info
                 *8 Report bg
                */
                //default Term id
                TermProg.DefaultTermId = Conversions.ToInteger (NxDb.DS.Tables ["tblSettings"].Rows [1] [2]);
                //Deputy pass
                User.EducationalDeputyPass = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [2] [2]);
                //Officer pass
                User.EducationalOfficerPass = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [3] [2]);
                //Log?
                if (NxDb.DS.Tables ["tblSettings"].Rows [4] [2].ToString().ToUpper() == "YES")
                    Setting.WriteLogs = true;
                else
                    Setting.WriteLogs = false;
                //BG
                Report.BG = Conversions.ToString (NxDb.DS.Tables ["tblSettings"].Rows [8] [2]);
                }
            catch (Exception ex)
                {
                MessageBox.Show ("خطا در بخش تنظيمات نکسترم", "نکسترم", MessageBoxButtons.OK);
                Setting.WriteLogs = false;
                }
            Dispose ();

            }
        private void Settings_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                e.Cancel = true;
                //MessageBox.Show ("براي خروج از منو استفاده کنيد ", "نکسنرم", MessageBoxButtons.OK);
                }
            }
        }
    }