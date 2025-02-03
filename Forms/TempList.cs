using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {

    public partial class TempList
        {
        public TempList ()
            {
            InitializeComponent ();
            }
        private void TempList_Load (object sender, EventArgs e)
            {
            for (int i = 0; i <= 2; i++)
                GridCourse.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            Menu_ReadFromFile_Click (null, null);
            }

        // GRID
        private void GridCourse_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            int r = GridCourse.CurrentCell.RowIndex;
            int c = GridCourse.CurrentCell.ColumnIndex;
            if (c == 0)
                {
                if (GridCourse [0, r].Value.ToString () == "+")
                    {
                    GridCourse [0, r].Value = "";
                    }
                else
                    {
                    GridCourse [0, r].Value = "+";
                    }
                }
            }
        private void GridCourse_CellContentDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            int r = GridCourse.CurrentCell.RowIndex;
            int c = GridCourse.CurrentCell.ColumnIndex;
            if (GridCourse.RowCount < 1)
                return;
            if (r < 0)
                return;

            switch (c)
                {
                case 0:
                        {
                        return;
                        }
                case 1:
                case 2:
                case 4:
                        {
                        string strGridContent = GridCourse [c, r].Value.ToString ();
                        strGridContent = Strings.Trim (Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strGridContent));
                        if (string.IsNullOrEmpty (strGridContent))
                            {
                            return;
                            }
                        else
                            {
                            GridCourse [c, r].Value = strGridContent;
                            }
                        break;
                        }
                case 3:
                        {
                        Nxt.Retval1 = 2; //1:Programs 2:Courses
                        Nxt.Retval2 = Convert.ToInt32 (GridCourse [3, r].Value); //data in bits
                        My.MyProject.Forms.frmSpecs.ShowDialog ();
                        /*
                         * Retval2: data
                         * Retval1:{OK|Cancel}
                        */
                        if (Nxt.Retval1 == 1)
                            {
                            GridCourse [3, r].Value = Nxt.Retval2.ToString ();
                            }
                        else
                            {
                            return;
                            }
                        break;
                        }
                }
            }

        // MENU
        private void Menu_Guide_Click (object sender, EventArgs e)
            {
            //guide
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
        private void Menu_ReadFromFile_Click (object sender, EventArgs e)
            {
            // clear the grid
            while (GridCourse.Rows.Count > 0)
                GridCourse.Rows.Remove (GridCourse.Rows [0]);
            try
                {
                var dialog = new OpenFileDialog ()
                    {
                    InitialDirectory = Application.StartupPath,
                    Filter = "Nexterm Course List|*.xlsx"
                    };
                if (dialog.ShowDialog () == DialogResult.OK)
                    {
                    NxDb.Filename = dialog.FileName;
                    }
                else
                    {
                    Dispose ();
                    return;
                    }
                using (IXLWorkbook WB = new XLWorkbook (NxDb.Filename))
                    {
                    var WS0 = WB.Worksheets.ElementAtOrDefault (0);
                    int iRow = 0;
                    int intCourseUnits = 0;
                    int intIsLab = 0;
                    int intIsClass = 0;
                    int intIsMandatory = 0;
                    int intCourseSpecs = 0;
                    foreach (IXLRow Rowx in WS0.Rows ())
                        {
                        iRow = iRow + 1;
                        if (iRow > 1)
                            {
                            Course.Name = WS0.Cell (iRow, 1).Value.ToString ();
                            Course.Number = Convert.ToInt64 (WS0.Cell (iRow, 2).Value.ToString ());
                            intCourseUnits = Convert.ToInt32 (WS0.Cell (iRow, 3).Value.ToString ());
                            intIsLab = Convert.ToInt32 (WS0.Cell (iRow, 4).Value.ToString ());
                            intIsClass = Convert.ToInt32 (WS0.Cell (iRow, 5).Value.ToString ());
                            intIsMandatory = Convert.ToInt32 (WS0.Cell (iRow, 6).Value.ToString ());
                            intCourseSpecs = 0;
                            if (intIsLab == 1)
                                intCourseSpecs += 1;
                            if (intIsClass == 1)
                                intCourseSpecs += 2;
                            if (intIsMandatory == 1)
                                intCourseSpecs += 4;
                            GridCourse.Rows.Add ("+", Course.Number, Course.Name, intCourseSpecs, intCourseUnits);
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error importing Courses\n\n" + ex.ToString ());
                return;
                }
            }
        private void Menu_All_Click (object sender, EventArgs e)
            {
            for (int i = 0, loopTo = GridCourse.Rows.Count - 1; i <= loopTo; i++)
                GridCourse [0, i].Value = "+";
            }
        private void Menu_InvertSelection_Click (object sender, EventArgs e)
            {
            for (int i = 0, loopTo = GridCourse.Rows.Count - 1; i <= loopTo; i++)
                {
                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (GridCourse [0, i].Value, "+", false)))
                    {
                    GridCourse [0, i].Value = "";
                    }
                else
                    {
                    GridCourse [0, i].Value = "+";
                    }
                }
            }
        private void Menu_OK_Click (object sender, EventArgs e)
            {
            int intCourseSpecs = 0;
            int intCourseUnits = 0;
            try
                {
                for (int k = 0, loopTo = GridCourse.Rows.Count - 1; k <= loopTo; k++)
                    {
                    if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (GridCourse [0, k].Value, "+", false)))
                        {
                        Course.Number = Conversions.ToLong (GridCourse [1, k].Value);
                        Course.Name = Conversions.ToString (GridCourse [2, k].Value);
                        intCourseSpecs = Conversions.ToInteger (GridCourse [3, k].Value);
                        intCourseUnits = Conversions.ToInteger (GridCourse [4, k].Value);
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Coursespecs, Units) VALUES (@bioprogid, @coursename, @coursenumber, @coursespecs, @units)";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@bioprogid", Prog.Id.ToString ());
                            cmd.Parameters.AddWithValue ("@coursename", Course.Name);
                            cmd.Parameters.AddWithValue ("@coursenumber", Course.Number.ToString ());
                            cmd.Parameters.AddWithValue ("@coursespecs", intCourseSpecs.ToString ());
                            cmd.Parameters.AddWithValue ("@units", intCourseUnits.ToString ());
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("error: " + ex.ToString ());
                }
            Dispose ();
            }

        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
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