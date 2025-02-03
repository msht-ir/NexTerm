using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseCourse
        {
        public ChooseCourse ()
            {
            InitializeComponent ();
            }
        private void ChooseCourse_Load (object sender, EventArgs e)
            {
            GridCourse.EditMode = DataGridViewEditMode.EditProgrammatically; //DataGridViewEditMode.EditOnKeystrokeOrF2

            if (User.Type == "UserDepartment")
                {
                ComboBioProg.Enabled = false;
                }
            else
                {
                ComboBioProg.Enabled = true;
                }

            if (User.Type == "UserDepartment" & (User.ACCs & 0x1) == 0)
                {
                MenuAddCourse.Enabled = false;
                Menu_Edit.Enabled = false;
                }
            else
                {
                MenuAddCourse.Enabled = true;
                Menu_Edit.Enabled = true;
                }
            // Fill ComboBox (BioProgs)
            if (Department.Id < 1L)
                Department.Id = 2L;
            NxDb.DS.Tables ["tblBioProgs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT BioProgs.ID AS ProgID, ProgramName As Prog FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" + Department.Id.ToString () + " ORDER BY ProgramName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblBioProgs");
                CnnSS.Close ();
                }
            ComboBioProg.DataSource = NxDb.DS.Tables ["tblBioProgs"];
            ComboBioProg.DisplayMember = "Prog";
            ComboBioProg.ValueMember = "ProgID";
            ComboBioProg.SelectedValue = Prog.Id;
            ComboBioProg.Refresh ();
            ComboBioProg_SelectedIndexChanged (sender, e);
            for (int i = 0, loopTo = GridCourse.Rows.Count - 1; i <= loopTo; i++)
                {
                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (GridCourse [0, i].Value, Course.Id, false)))
                    {
                    GridCourse.CurrentCell = GridCourse.Rows [i].Cells [1];
                    return;
                    }
                }
            }
        private void ComboBioProg_SelectedIndexChanged (object sender, EventArgs e)
            {
            // ComboBioProg -> Populates GridCourse
            string i = ComboBioProg.GetItemText (ComboBioProg.SelectedValue);
            if (Conversion.Val (i) == 0d)
                return;
            Prog.Id = (long) Math.Round (Conversion.Val (i));
            // READ FROM DATABASE
            NxDb.DS.Tables ["tblCourses"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Courses.ID, CourseName, CourseNumber, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" + Prog.Id.ToString () + " ORDER BY CourseName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblCourses");
                CnnSS.Close ();
                }
            GridCourse.DataSource = NxDb.DS.Tables ["tblCourses"];
            GridCourse.Refresh ();
            GridCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridCourse.Columns [0].Visible = false;
            GridCourse.Columns [0].Width = 0;    // ID
            GridCourse.Columns [1].Width = 250;  // Course
            GridCourse.Columns [2].Width = 90;   // Number
            GridCourse.Columns [3].Width = 40;   // Units
            for (int k = 0, loopTo = GridCourse.Columns.Count - 1; k <= loopTo; k++)
                GridCourse.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        private void GridCourse_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridCourse.RowCount < 1)
                return;
            int r = GridCourse.CurrentCell.RowIndex;   // count from 0
            if (r < 0)
                return;
            GridCourse.CurrentCell = GridCourse [1, r];
            string strCourseName = Conversions.ToString (GridCourse.Rows [r].Cells [1].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [1] = strCourseName;
            int intCourseNumber = Conversions.ToInteger (GridCourse.Rows [r].Cells [2].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [2] = intCourseNumber;
            int intCourseUnits = Conversions.ToInteger (GridCourse.Rows [r].Cells [3].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [3] = intCourseUnits;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Units = @units WHERE ID = @ID";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@coursename", strCourseName);
                cmd.Parameters.AddWithValue ("@coursenumber", intCourseNumber);
                cmd.Parameters.AddWithValue ("@units", intCourseUnits);
                cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblCourses"].Rows [r] [0].ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        private void GridCourse_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            MenuOK_Click (sender, e); // Return A COURSE
            }
        private void MenuOK_Click (object sender, EventArgs e)
            {
            if (GridCourse.RowCount < 1)
                return;
            int r = GridCourse.CurrentRow.Index;
            try
                {
                Course.Id = Conversions.ToLong (NxDb.DS.Tables ["tblCourses"].Rows [r] [0]);
                Course.Name = Conversions.ToString (NxDb.DS.Tables ["tblCourses"].Rows [r] [1]);
                Course.Number = Conversions.ToLong (NxDb.DS.Tables ["tblCourses"].Rows [r] [2]);
                }
            catch (Exception ex)
                {
                MessageBox.Show ("شماره درس؟", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Course.Number = 0L;
                }
            Dispose ();

            }
        private void MenuAddCourse_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (ComboBioProg.SelectedIndex == -1)
                return;
            DialogResult myansw = MessageBox.Show ("درس جديد به اين دوره آموزشي افزوده شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.Yes)
                {
                Course.Name = Interaction.InputBox ("نام درس را وارد کنيد", "NexTerm", " درس جديد " + ComboBioProg.Text);
                if (string.IsNullOrEmpty (Course.Name))
                    {
                    return;
                    }
                else
                    {
                    Course.Number = (long) Math.Round (Conversion.Val (Interaction.InputBox ("شماره درس", "NexTerm", "123456789")));
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units) VALUES (@bioprogid, @coursename, @coursenumber, 2)";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@bioprogid", ComboBioProg.SelectedValue);
                            cmd.Parameters.AddWithValue ("@coursename", Course.Name);
                            cmd.Parameters.AddWithValue ("@coursenumber", Conversion.Str (Course.Number));
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        MessageBox.Show (" درس " + Course.Name + " افزوده شد ", "نکسترم", MessageBoxButtons.OK);
                        ComboBioProg_SelectedIndexChanged (null, null);
                        GridCourse.Refresh ();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show ("error: " + ex.ToString ());
                        }
                    }
                }
            }
        private void Menu_Edit_Click (object sender, EventArgs e)
            {
            int r = GridCourse.SelectedCells [0].RowIndex;    // count from 0
            int c = GridCourse.SelectedCells [0].ColumnIndex; // count from 0
            if (GridCourse.RowCount < 1)
                return;
            if (r < 0 | c < 0)
                return;
            string strValue = Conversions.ToString (GridCourse [c, r].Value);
            try
                {
                switch (c)
                    {
                    case 1: // Course Name
                            {
                            strValue = Interaction.InputBox ("نام جديد درس را وارد کنيد", "نکسترم", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            if ((User.ACCs & 0x10) == 0)
                                {
                                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                                }
                            DialogResult myansw = MessageBox.Show ("نام درس را به \n" + strValue + "\nتغيير مي دهيد؟", "نکسترم: توجه: در حال ويرايش نام درس هستيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (myansw == DialogResult.No)
                                return;
                            GridCourse [c, r].Value = strValue;
                            NxDb.LOG ("crs? : " + Course.Name);
                            break;
                            }
                    case 2: // Number
                            {
                            strValue = Interaction.InputBox ("شماره جديد درس را وارد کنيد", "نکسترم", strValue);
                            if (Conversion.Val (strValue) == 0d)
                                return;
                            GridCourse [c, r].Value = strValue;
                            NxDb.LOG ("crs.nr/unt? : " + Course.Number.ToString ());
                            break;
                            }
                    case 3: // Unit
                            {
                            strValue = Interaction.InputBox ("تعداد واحد درس را وارد کنيد", "نکسترم", strValue);
                            if (Conversion.Val (strValue) == 0d)
                                return;
                            GridCourse [c, r].Value = strValue;
                            NxDb.LOG ("crs.nr/unt? : " + Course.Number.ToString ());
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            Course.Name = "";
            Course.Id = 0L;
            Dispose ();
            }
        private void GridCourse_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                        {
                        MenuOK_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }

                case 27: // escape
                        {
                        MenuCancel_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void btnSave_Click (object sender, EventArgs e)
            {
            MenuOK_Click (null, null);

            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            MenuCancel_Click (null, null);
            }
        }
    }