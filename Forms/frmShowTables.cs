using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class frmShowTables
        {
        public frmShowTables ()
            {
            InitializeComponent ();
            }

        private void frmShowTables_Load (object sender, EventArgs e)
            {
            Show_Table ();
            if ((User.ACCs & 0x1) == 0x0 & User.Type == "UserDepartment")
                {
                Menu_AddNew.Enabled = false;
                }
            else
                {
                Menu_AddNew.Enabled = true;
                }
            }
        private void Show_Table ()
            {
            NxDb.DS.Tables ["tblCourses"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Courses.ID, CourseName, CourseNumber, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" + Prog.Id.ToString () + " ORDER BY CourseName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblCourses");
                CnnSS.Close ();
                }
            Grid1.DataSource = NxDb.DS.Tables ["tblCourses"];
            Grid1.Refresh ();
            Grid1.Columns [0].Width = 0;         // ID
            Grid1.Columns [1].Width = 290;       // CourseName
            Grid1.Columns [2].Width = 90;        // CourseNumber
            Grid1.Columns [3].Width = 50;        // Unit
            Grid1.Columns [0].Visible = false;   // ID
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++)
                Grid1.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        private void Grid1_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type == "UserDepartment" & (User.ACCs & 0x10) == 0x0) // 2^0 (1-1) is for Courses: acc1
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            SvaeChanges_Courses ();
            }

        // Save CHANGES
        private void SvaeChanges_Courses ()
            {
            if (Grid1.RowCount < 1)
                return;
            int r = Grid1.CurrentCell.RowIndex;
            if (r < 0)
                return;
            string strCourseName = Conversions.ToString (Grid1.Rows [r].Cells [1].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [1] = strCourseName;
            int intCourseNumber = Conversions.ToInteger (Grid1.Rows [r].Cells [2].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [2] = intCourseNumber;
            int intCourseUnit = Conversions.ToInteger (Grid1.Rows [r].Cells [3].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [3] = intCourseUnit;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Units = @units WHERE ID = @ID";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@coursename", strCourseName);
                cmd.Parameters.AddWithValue ("@coursenumber", intCourseNumber);
                cmd.Parameters.AddWithValue ("@units", intCourseUnit);
                cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblCourses"].Rows [r] [0].ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        private void Menu_AddNewItem (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            DialogResult myansw = MessageBox.Show ("درس جديد اضافه شود؟", "NexTerm :  " + TermProg.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                return;
            string strNewCourse = Interaction.InputBox ("نام درس جديد را وارد کنيد" + Constants.vbCrLf + Constants.vbCrLf + "در اين ليست (جديد) باشد", "تعريف درس جديد", "");
            if (string.IsNullOrEmpty (Strings.Trim (strNewCourse)))
                return;
            long intNewCourse = Conversions.ToLong (Interaction.InputBox ("شماره درس؟", "تعريف درس جديد", "1234"));
            if (intNewCourse < 0L)
                return;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units) VALUES (@bioprogid, @newcourse, @coursenumber, 2)";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@bioprogid", Prog.Id.ToString ());
                cmd.Parameters.AddWithValue ("@newcourse", strNewCourse);
                cmd.Parameters.AddWithValue ("@coursenumber", intNewCourse.ToString ());
                cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            Grid1.Refresh ();
            Show_Table ();
            }
        private void PopMenu_Exit (object sender, EventArgs e)
            {
            btnOkExit.Focus ();
            int r = Grid1.SelectedCells [0].RowIndex;
            Course.Id = (long) Math.Round (Conversion.Val (Grid1 [0, r].Value));
            Course.Name = Conversions.ToString (Grid1 [1, r].Value);
            Close ();
            Dispose ();
            }

        private void btnOkExit_Click (object sender, EventArgs e)
            {
            PopMenu_Exit (sender, e);
            }

        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            btnOkExit.Focus ();
            int r = Grid1.SelectedCells [0].RowIndex;
            Course.Id = 0L;
            Course.Name = "";
            Close ();
            Dispose ();
            }
        }
    }