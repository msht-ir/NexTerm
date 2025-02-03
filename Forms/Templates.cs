using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class Templates
        {
        public int trm = 1;
        public Templates ()
            {
            InitializeComponent ();
            }
        private void Templates_Load (object sender, EventArgs e)
            {
            // Fill ComboBox (Depts)
            ComboDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            ComboDepts.DisplayMember = "DEPT";
            ComboDepts.ValueMember = "ID";
            ComboDepts.SelectedValue = Department.Id;
            GridTemplates.Focus ();
            }
        private void ComboDepts_SelectedIndexChanged (object sender, EventArgs e)
            {
            ShowDepartment ();
            }
        private void ShowDepartment ()
            {
            // ComboDept -> Populates GridBioProgs
            string i = ComboDepts.GetItemText (ComboDepts.SelectedValue);
            if (Conversion.Val (i) == 0d)
                return;
            NxDb.DS.Tables ["tblTemplates"].Clear ();
            NxDb.DS.Tables ["tblTemplateData"].Clear ();
            if (Conversions.ToBoolean (Operators.AndObject (User.Type == "UserDepartment", Operators.ConditionalCompareObjectNotEqual (ComboDepts.SelectedValue, User.Id, false))))
                return;
            GridTemplates.Focus ();
            if (Conversions.ToBoolean (Operators.AndObject (User.Type == "UserDepartment", Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblDepartments"].Rows [ComboDepts.SelectedIndex] [2], false, false))))
                return;
            // READ FROM DATABASE
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Templates.ID, ProgramName As Prog, TemplateName As Termic, nTerms As Terms, BioProgs.Department_ID, Templates.BioProg_ID FROM ((Departments INNER JOIN  BioProgs ON Departments.ID = BioProgs.Department_ID) INNER JOIN  Templates ON BioProgs.ID = Templates.BioProg_ID) WHERE BioProgs.Department_ID =" + i.ToString () + " ORDER BY ProgramName, TemplateName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTemplates");
                CnnSS.Close ();
                }
            GridTemplates.DataSource = NxDb.DS.Tables ["tblTemplates"];
            GridTemplates.Refresh ();
            GridTemplates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridTemplates.RowHeadersVisible = false;
            GridTemplates.Columns [0].Visible = false; // ID
            GridTemplates.Columns [1].Width = 230;  // Prog
            GridTemplates.Columns [2].Width = 280;   // Termic (TemplateName)
            GridTemplates.Columns [3].Visible = false; // .Width = 45   'nTerm
            GridTemplates.Columns [4].Visible = false; // DeptID
            GridTemplates.Columns [5].Visible = false; // BioProgID
            for (int k = 0, loopTo = GridTemplates.Columns.Count - 1; k <= loopTo; k++)
                GridTemplates.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        private void ShowTemplate ()
            {
            // Refresh GridData
            int r = GridTemplates.CurrentRow.Index;
            if (r < 0)
                return;

            int i = (int) Math.Round (Conversion.Val (GridTemplates [0, r].Value));
            if (Conversion.Val (i) == 0d)
                return;
            // READ FROM DATABASE
            NxDb.DS.Tables ["tblTemplateData"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TemplateData.ID, Template_ID, Course_ID, [Term], CourseName, CourseNumber, BioProg_ID FROM (TemplateData INNER JOIN Courses ON TemplateData.Course_ID = Courses.ID) WHERE Template_ID = " + i.ToString () + " ORDER BY [Term], CourseName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTemplateData");
                CnnSS.Close ();
                }
            GridTemplateData.DataSource = NxDb.DS.Tables ["tblTemplateData"];
            GridTemplateData.Refresh ();
            GridTemplateData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridTemplateData.RowHeadersVisible = false;
            GridTemplateData.Columns [0].Width = 0;     // ID
            GridTemplateData.Columns [1].Width = 0;     // Template_ID
            GridTemplateData.Columns [2].Width = 0;     // Course_ID
            GridTemplateData.Columns [3].Width = 60;    // Term
            GridTemplateData.Columns [4].Width = 300;   // CourseName
            GridTemplateData.Columns [5].Width = 120;   // CourseNumber
            GridTemplateData.Columns [6].Width = 0;     // BioProgID
            GridTemplateData.Columns [0].Visible = false;
            GridTemplateData.Columns [1].Visible = false;
            GridTemplateData.Columns [2].Visible = false;
            GridTemplateData.Columns [6].Visible = false;
            var loopTo = GridTemplateData.Columns.Count - 1;
            for (i = 0; i <= loopTo; i++)
                GridTemplateData.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        private void Grid1 (object sender, DataGridViewCellEventArgs e)
            {
            // GridTemplates -> Populates GridData
            ShowTemplate ();
            trm = 1;
            }
        private void GridTemplates_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                        {
                        Grid1 (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }

                case 27: // escape
                        {
                        Menu_ExitBack_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void GridTemplates_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type == "UserDeputy")
                {
                MessageBox.Show ("برنامه ريزي ترميک در اختيار مدير گروه است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridTemplates.RowCount < 1)
                return;
            int r = e.RowIndex; // count from 0
            int c = e.ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;
            switch (c)// SELECT BASED ON GRID.COLUMN
                {
                case 2: // Termic Prog Title
                        {
                        string ProTitle = Conversions.ToString (NxDb.DS.Tables ["tblTemplates"].Rows [r] [2]);
                        ProTitle = Interaction.InputBox ("Change to  > ", "NexTerm", ProTitle);
                        if (String.IsNullOrEmpty (ProTitle))
                            {
                            return;
                            }
                        NxDb.DS.Tables ["tblTemPlates"].Rows [r] [2] = ProTitle;
                        NxDb.strSQL = "UPDATE Templates SET TemplateName = @ProTitle WHERE ID = @ID";
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@ProTitle", ProTitle);
                            cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTemplates"].Rows [r] [0].ToString ());
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        break;
                        }
                case 3: // nTerm
                        {
                        int nt = Conversions.ToInteger (NxDb.DS.Tables ["tblTemplates"].Rows [r] [3]);
                        nt = (int) Math.Round (Conversion.Val (Interaction.InputBox ("Change to  > ", "NexTerm", nt.ToString ())));
                        if (nt == 0)
                            {
                            return;
                            }
                        NxDb.DS.Tables ["tblTemPlates"].Rows [r] [3] = nt;
                        NxDb.strSQL = "UPDATE Templates SET nTerms = @nt WHERE Templates.ID = @ID";
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@nt", nt);
                            cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTemplates"].Rows [r] [0].ToString ());
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        break;
                        }
                }
            }
        private void Grid2_DoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type == "UserDeputy")
                {
                MessageBox.Show ("برنامه ريزي ترميک در اختيار مدير گروه است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridTemplateData.RowCount < 1)
                return;
            int r = e.RowIndex; // count from 0
            int c = e.ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;
            switch (c)// SELECT BASED ON GRID.COLUMN
                {
                case 3: // Term
                        {
                        trm = Conversions.ToInteger (NxDb.DS.Tables ["tblTemplateData"].Rows [r] [3]);
                        trm = (int) Math.Round (Conversion.Val (Interaction.InputBox ("انتقال به ترم:", "NexTerm", trm.ToString ())));
                        if (trm == 0)
                            trm = 1;
                        NxDb.DS.Tables ["tblTemplateData"].Rows [r] [3] = trm;
                        NxDb.strSQL = "UPDATE TemplateData SET [Term] = @trm WHERE TemplateData.ID = @ID";
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@trm", trm);
                            cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTemplateData"].Rows [r] [0].ToString ());
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        break;
                        }
                case 4: // Course
                        {
                        Department.Id = Conversions.ToLong (ComboDepts.GetItemText (ComboDepts.SelectedValue));
                        Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [5]);
                        Course.Id = Conversions.ToLong (NxDb.DS.Tables ["tbltemplateData"].Rows [r] [2]);
                        My.MyProject.Forms.ChooseCourse.ShowDialog ();
                        if (string.IsNullOrEmpty (Course.Name))
                            return;
                        NxDb.DS.Tables ["tbltemplateData"].Rows [r] [4] = Course.Name;
                        NxDb.DS.Tables ["tbltemplateData"].Rows [r] [5] = Course.Number;
                        NxDb.strSQL = "UPDATE TemplateData SET Course_ID = @courseid WHERE TemplateData.ID = @ID";
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@courseid", Conversion.Val (Course.Id));
                            cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblTemplateData"].Rows [r] [0].ToString ());
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        break;
                        }
                case 5: // CourseNumber
                        {
                        Course.Id = (long) Math.Round (Conversion.Val (NxDb.DS.Tables ["tblTemplateData"].Rows [r] [2]));
                        double coursenumber;
                        try
                            {
                            coursenumber = Conversion.Val (NxDb.DS.Tables ["tblTemplateData"].Rows [r] [5]);
                            }
                        catch
                            {
                            coursenumber = 0d;
                            }
                        coursenumber = Conversion.Val (Interaction.InputBox ("تصحيح شماره درس", "NexTerm", coursenumber.ToString ()));
                        if (coursenumber == 0d)
                            return;
                        NxDb.DS.Tables ["tblTemplateData"].Rows [r] [5] = coursenumber;
                        try
                            {
                            NxDb.strSQL = "UPDATE Courses SET CourseNumber=@coursenumber WHERE ID=@ID";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue ("@coursenumber", coursenumber.ToString ());
                                cmd.Parameters.AddWithValue ("@ID", Course.Id.ToString ());
                                int i = cmd.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            }
                        catch
                            {
                            MessageBox.Show ("Err... intCourse:" + Course.Id + " / CourseNumber: " + coursenumber);
                            }
                        break;
                        }
                }
            ShowTemplate ();
            }
        private void Menu_AddCourse_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDeputy")
                {
                MessageBox.Show ("برنامه ريزي ترميک در اختيار مدير گروه است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridTemplates.SelectedCells.Count < 1)
                {
                MessageBox.Show ("يک برنامه الگو از ليست انتخاب کنيد", "نکسترم", MessageBoxButtons.OK);
                return;
                }
            try
                {
                Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [0]);
                // MsgBox(intBioProg.ToString)
                if (Prog.Id < 1L)
                    return;
                Department.Id = Conversions.ToLong (ComboDepts.GetItemText (ComboDepts.SelectedValue));
                Department.Name = ComboDepts.Text;
                Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [5]);
                Prog.Name = Conversions.ToString (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [1]);
                My.MyProject.Forms.ChooseCourse.ShowDialog ();
                if (string.IsNullOrEmpty (Course.Name))
                    return;
                trm = (int) Math.Round (Conversion.Val (txtTerm.Text));
                if (trm < 1 | trm > 10 | chkAsk.Checked == true)
                    {
                    trm = (int) Math.Round (Conversion.Val (Interaction.InputBox ("در ترم", "برنامه ترميک", trm.ToString ())));
                    if (trm < 1 | trm > 10)
                        trm = 1;
                    txtTerm.Text = trm.ToString ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                try
                    {
                    NxDb.strSQL = "INSERT INTO TemplateData (Template_ID, Course_ID, [Term]) VALUES (@templateid, @courseid, @trm)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@templateid", Conversion.Val (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [0]));
                    cmd.Parameters.AddWithValue ("@courseid", Conversion.Val (Course.Id));
                    cmd.Parameters.AddWithValue ("@trm", trm);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                catch (Exception ex)
                    {
                    CnnSS.Close ();
                    MessageBox.Show (ex.ToString ());
                    }
                }
            ShowTemplate ();
            }
        private void Menu_DelCourse_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDeputy")
                {
                MessageBox.Show ("برنامه ريزي ترميک در اختيار مدير گروه است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            try
                {
                if (GridTemplateData.SelectedCells.Count < 1)
                    {
                    MessageBox.Show ("يک برنامه الگو از ليست انتخاب کنيد", "نکسترم", MessageBoxButtons.OK);
                    return;
                    }
                int r = GridTemplateData.SelectedCells [0].RowIndex; // count from 0
                if (r < 0)
                    {
                    MessageBox.Show ("يک درس را انتخاب کنيد", "نکسترم", MessageBoxButtons.OK);
                    return;
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                try
                    {
                    DialogResult myansw = MessageBox.Show ("اين درس حذف شود؟ \n\n" + NxDb.DS.Tables ["tblTemplateData"].Rows [GridTemplateData.CurrentRow.Index] [4], "تاييد کنيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    if (myansw == DialogResult.No)
                        return;
                    int idDEL = Conversions.ToInteger (NxDb.DS.Tables ["tblTemplateData"].Rows [GridTemplateData.CurrentRow.Index] [0]);
                    NxDb.strSQL = "DELETE From TemplateData WHERE ID = @iddel";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@iddel", idDEL);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                catch (Exception ex)
                    {
                    CnnSS.Close ();
                    MessageBox.Show (ex.ToString ());
                    }
                }
            ShowTemplate ();
            }
        private void Menu_AddNew_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDeputy")
                {
                MessageBox.Show ("برنامه ريزي ترميک در اختيار مدير گروه است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (ComboDepts.SelectedIndex == -1)
                return;
            Department.Id = Conversions.ToLong (ComboDepts.SelectedValue);
            My.MyProject.Forms.ChooseBioProg.ShowDialog ();
            if (string.IsNullOrEmpty (Prog.Name))
                return;
            string strTemplate = Interaction.InputBox ("Enter Template Name  >", "NexTerm", "برنامه ترميک");
            if (string.IsNullOrEmpty (strTemplate))
                return;
            int intTerms = 1;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "INSERT INTO Templates (TemplateName, nTerms, [BioProg_ID]) VALUES (@templatenm, @nt, @progid)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@templatenm", strTemplate);
                    cmd.Parameters.AddWithValue ("@nt", Conversion.Val (intTerms));
                    cmd.Parameters.AddWithValue ("@progid", Conversion.Val (Prog.Id));
                    cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                NxDb.LOG ("tmplt+:" + Prog.Id.ToString ());
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            ShowDepartment ();
            }
        private void Menu_Del_Click (object sender, EventArgs e)
            {
            DialogResult myansw;
            if (User.Type == "UserDeputy")
                {
                MessageBox.Show ("برنامه ريزي ترميک در اختيار مدير گروه است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (GridTemplates.RowCount < 1)
                return;
            if (GridTemplateData.RowCount > 0)
                {
                myansw = MessageBox.Show ("اين الگو برنامه ريزي شده است، حذف شوند؟", "تاييد کنيد", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (myansw == DialogResult.No)
                    {
                    return;
                    }
                else
                    {
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "DELETE From TemplateData WHERE Template_ID = @iddel1";
                            CnnSS.Open ();
                            var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd1.CommandType = CommandType.Text;
                            cmd1.Parameters.AddWithValue ("@iddel1", Conversion.Val (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [0]));
                            int i = cmd1.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        ShowTemplate ();
                        MessageBox.Show ("برنامه ريزي اين الگو پاک شد", "Title: ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            myansw = MessageBox.Show ("اين الگو حذف شود؟ \n\n" + NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [2], "تاييد کنيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                return;
            int idDEL = Conversions.ToInteger (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [0]);
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "DELETE From Templates WHERE ID = @iddel";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@iddel", idDEL);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                NxDb.LOG ("tmplt-:" + Prog.Id.ToString ());
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            ShowDepartment ();
            }
        private void Menu_ReportMe_Click (object sender, EventArgs e)
            {
            if (GridTemplateData.Rows.Count < 1)
                return;
            // MsgBox(GridTemplateData.Rows.Count.ToString)
            Prog.Name = Conversions.ToString (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentCell.RowIndex] [1]);
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Report_Template.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=\"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>الگو</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>", Report.AppOwner, "</p>");
            FileSystem.PrintLine (1, "<h1 style ='color:red; text-align: center'> برنامه ترميک براي دوره آموزشي ", Prog.Name, "</h1>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>");
            FileSystem.PrintLine (1, " برنامه ترميک (الگو) براي ورودي هاي ");
            FileSystem.PrintLine (1, Prog.Name);
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
            FileSystem.PrintLine (1, "<tr>");
            FileSystem.PrintLine (1, "<th>نيمسال</th>");
            FileSystem.PrintLine (1, "<th>نام درس</th>");
            FileSystem.PrintLine (1, "<th>شماره درس</th>");
            FileSystem.PrintLine (1, "</tr>");
            for (int i = 0, loopTo = GridTemplateData.Rows.Count - 1; i <= loopTo; i++)
                {
                FileSystem.PrintLine (1, "<tr>");
                FileSystem.PrintLine (1, "<td Style=Text-Align:Center;>", GridTemplateData [3, i].Value, "</td>"); // Term
                FileSystem.PrintLine (1, "<td>", GridTemplateData [4, i].Value, "</td>"); // CourseName
                FileSystem.PrintLine (1, "<td>", GridTemplateData [5, i].Value, "</td>"); // CourseNumber
                FileSystem.PrintLine (1, "</tr>");
                }
            FileSystem.PrintLine (1, "</table>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Report_Template.html");
            }
        private void Menu_Apply_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (برنامه ريزي) اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (GridTemplateData.Rows.Count == 0)
                return;
            // A: Get an Entry ID 
            Prog.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [5]);
            Prog.Name = Conversions.ToString (GridTemplates [1, GridTemplates.CurrentRow.Index].Value);
            Department.Id = Conversions.ToLong (ComboDepts.SelectedValue);
            My.MyProject.Forms.ChooseEntry.ShowDialog ();
            if (Entry.Id == 0L)
                return;
            // OK, we have: intEntry (ID), intYearEntered (EntYear)

            int intNTerms = Conversions.ToInteger (NxDb.DS.Tables ["tblTemplates"].Rows [GridTemplates.CurrentRow.Index] [3]); // Item 3 is nTerms 
                                                                                                                               // B: Check if Entry is already programmed -> Del previous progs in this Entry?
                                                                                                                               // -> Confirm: Assign this_Template -> selected_Entry ?
            NxDb.DS.Tables ["tblTermProgs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID FROM TermProgs WHERE Entry_ID = " + Entry.Id.ToString (), CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTermProgs");
                CnnSS.Close ();
                }
            if (NxDb.DS.Tables ["tblTermProgs"].Rows.Count > 0)
                {
                switch (User.Type ?? "")
                    {
                    case "UserDeputy":
                    case "UserOfficer":
                            {
                            DialogResult myansw = MessageBox.Show ("ورودي   \n" + Entry.Name + "\n قبلا برنامه ريزي شده است \n برنامه ريزي قبلي اين ورودي حذف شود؟", "توجه:", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                            if (myansw == DialogResult.Yes)
                                {
                                try
                                    {
                                    // DELETE existing TermProgs of this Entry
                                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                        {
                                        NxDb.strSQL = "DELETE * From TermProgs WHERE Entry_ID = @id";
                                        CnnSS.Open ();
                                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue ("@id", Entry.Id.ToString ());
                                        int i = cmd.ExecuteNonQuery ();
                                        CnnSS.Close ();
                                        }
                                    MessageBox.Show ("برنامه حذف شد", "NexTerm", MessageBoxButtons.OK);
                                    }
                                catch (Exception ex)
                                    {
                                    MessageBox.Show (ex.ToString ());
                                    }
                                }

                            break;
                            }
                    case "UserDepartment":
                            {
                            MessageBox.Show ("اين ورودي قبلا برنامه ريزي شده است \n براي برنامه ريزي مجدد ورودي\n" + Entry.Name + "\nاز کاربر دانشکده بخواهيد برنامه ريزي قبلي اين ورودي را حذف نمايد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            return;
                            }
                    }
                }
            // C: Required Terms be created {nTerms, YearEnt -> create required Terms}
            NxDb.DS.Tables ["tblTerms"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM Terms", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                CnnSS.Close ();
                }
            string Term1, Term2;
            int ix;
            for (int i = 1, loopTo = (int) Math.Round (Conversion.Int (intNTerms / 2d + 0.5d)); i <= loopTo; i++)
                {
                Term1 = Strings.Trim ((Entry.YearEntered + i - 1).ToString () + "-1");
                var Resultx = from trm in NxDb.DS.Tables ["tblTerms"].AsEnumerable ()
                              where (trm.Field<string> ("Term") ?? "") == (Term1 ?? "")
                              select trm;
                int ResultxCount = Resultx.Count ();
                if (ResultxCount == 0)
                    {
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "INSERT INTO Terms (Term) VALUES (@term)";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@term", Term1);
                            ix = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        }
                    // MsgBox(Term1 & " ايجاد شد ")
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                Term2 = Strings.Trim (Conversion.Str (Entry.YearEntered + i - 1) + "-2");
                var Resultx2 = from trm in NxDb.DS.Tables ["tblTerms"].AsEnumerable ()
                               where (trm.Field<string> ("Term") ?? "") == (Term2 ?? "")
                               select trm;
                int Resultx2Count = Resultx.Count ();
                if (ResultxCount == 0)
                    {
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "INSERT INTO Terms (Term) VALUES (@term)";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@term", Term2);
                            ix = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            // D: Add Courses in Template to Correct Terms
            NxDb.DS.Tables ["tblTemplateData"].Clear ();
            int intTemplateID = Conversions.ToInteger (GridTemplates [0, GridTemplates.CurrentRow.Index].Value);
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, TempLate_ID, Course_ID, Term FROM TemPlateData WHERE Template_ID = " + intTemplateID.ToString (), CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTemplateData");
                CnnSS.Close ();
                }
            int intTemplateDateRecords = NxDb.DS.Tables ["tblTemplateData"].Rows.Count;
            int intThisCourseTerm;
            int grp = 1;
            for (int i = 0, loopTo1 = intTemplateDateRecords - 1; i <= loopTo1; i++)
                {
                Course.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTemplateData"].Rows [i] [2]); // Course: ID
                intThisCourseTerm = Conversions.ToInteger (NxDb.DS.Tables ["tblTemplateData"].Rows [i] [3]);   // Term: int from 1 to 8)
                Term.Name = Strings.Trim (Conversion.Str (Entry.YearEntered + Conversion.Int (intThisCourseTerm / 2d - 0.5d)));
                if (intThisCourseTerm / 2d == Conversion.Int (intThisCourseTerm / 2d))
                    Term.Name = Term.Name + "-2";
                else
                    Term.Name = Term.Name + "-1";
                NxDb.DS.Tables ["tblTerms"].Clear ();
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        CnnSS.Open ();
                        NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM Terms WHERE Term ='" + Term.Name + "'", CnnSS);
                        NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                        Term.Id = Conversions.ToLong (NxDb.DS.Tables ["tblTerms"].Rows [0] [0]);
                        NxDb.strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@entryid, @termid, @courseid, 1)";
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@entryid", Conversion.Val (Entry.Id));
                        cmd.Parameters.AddWithValue ("@termid", Conversion.Val (Term.Id));
                        cmd.Parameters.AddWithValue ("@courseid", Conversion.Val (Course.Id));
                        int n = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            NxDb.LOG ("tmplt.usd:" + Prog.Id.ToString ());
            MessageBox.Show ("ورودي  " + Entry.Name + " برنامه ريزي شد", "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            ShowTemplate ();
            }
        private void Menu_Guide_Click (object sender, EventArgs e)
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
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> برنامه هاي الگو _ ترميک <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "در ليست سمت راست پنجره، يک برنامه الگو را انتخاب و يا يک الگو ايجاد کنيد<br>");
            FileSystem.PrintLine (1, "مي توانيد براي هر دوره آموزشي، بيش از يک الگو ايجاد کنيد<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "در ليست سمت چپ پنجره: درس هاي لازم براي دوره آموزشي را اضافه / جايگزين و يا حذف کنيد<br>");
            FileSystem.PrintLine (1, "مشخص کنيد هر درس در چه ترمي بايد ارايه شود<br>");
            FileSystem.PrintLine (1, "شماره درس ها را مي توانيد با دبل کليک اصلاح کنيد <br>");
            FileSystem.PrintLine (1, "اصلاح شماره درس را با دقت انجام دهيد: اصلاحات شماره درس در همه ليست ها اعمال مي شود <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> برنامه ريزي يک ورودي جديد بوسيله الگو <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "براي برنامه ريزي يک ورودي جديد، از ليست سمت راست الگوي مناسب را انتخاب و الگو را به ورودي اختصاص دهيد <br>");
            FileSystem.PrintLine (1, "درس ها براساس شماره ترم (درالگو) به ترم هاي مختلف يک ورودي جديد اضافه مي شوند<br>");
            FileSystem.PrintLine (1, "بنابراين ترتيب درس ها ي ورودي را مي توانيد در پنجره اصلي برنامه تغيير دهيد  <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> اصلاحات در برنامه ورودي - پس از برنامه ريزي با الگو <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "براي اصلاح برنامه ورودي (پس ازآنکه بوسيله الگو برنامه ريزي شد)، در پنجره اصلي: ورودي، ترم و نام درس را انتخاب و سپس آن را به ترم ديگري جابجا کنيد <br>");
            FileSystem.PrintLine (1, "توجه: درس هاي ترم هاي قبل (اجرا شده) را جابجا نکنيد. فقط درس هاي ترم هاي پيش رو را جابجا يا جايگزين کنيد<br>");
            FileSystem.PrintLine (1, "همواره اطمينان حاصل کنيد که دانشجويان به موقع فارغ التحصيل مي شوند<br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, "تغيير برنامه ورودي باعث تغيير در برنامه الگو نمي شود<br>");
            FileSystem.PrintLine (1, "تغيير در برنامه الگو باعث تغيير در برنامه ورودي هايي که قبلا برنامه ريزي شده اند، نمي شود <br>");
            FileSystem.PrintLine (1, "<br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body>");
            FileSystem.PrintLine (1, "</html>");
            FileSystem.FileClose (1);
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "NexTerm_Guide.html");
            }
        private void Menu_ExitBack_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void btnExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }