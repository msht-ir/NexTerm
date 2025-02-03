using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseEntry
        {
        public ChooseEntry ()
            {
            InitializeComponent ();
            }

        private void ChooseEntry_Load (object sender, EventArgs e)
            {
            GridEntries.EditMode = DataGridViewEditMode.EditProgrammatically;
            if (User.Type == "UserDepartment")
                {
                ComboDepts.Enabled = false;
                MenuAddNewEntry.Enabled = false;
                }
            // Fill ComboBox1 (Depts)
            ComboDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            ComboDepts.DisplayMember = "DEPT";
            ComboDepts.ValueMember = "ID";
            ComboDepts.SelectedValue = Department.Id;
            try
                {
                ListBioProgs.SelectedValue = Prog.Id;
                ListBioProgs_Click (sender, e);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void ComboDepts_SelectedIndexChanged (object sender, EventArgs e)
            {
            // ComboDept -> Populates ListOfEntries
            string i = ComboDepts.GetItemText (ComboDepts.SelectedValue);
            if (Conversion.Val (i) == 0d)
                return;
            // READ FROM DATABASE
            NxDb.DS.Tables ["tblBioProgs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT BioProgs.ID, ProgramName, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" + i.ToString () + " ORDER BY ProgramName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblBioProgs");
                CnnSS.Close ();
                }
            ListBioProgs.DataSource = NxDb.DS.Tables ["tblBioProgs"];
            ListBioProgs.DisplayMember = "ProgramName";
            ListBioProgs.ValueMember = "BioProgs.ID";
            ListBioProgs.Refresh ();
            ListBioProgs.SelectedIndex = -1;
            ListBioProgs.SelectedValue = 0;
            NxDb.DS.Tables ["tblEntries"].Clear ();
            }
        private void ListBioProgs_Click (object sender, EventArgs e)
            {
            // ComboBioProg -> Populates GridEntry
            ShowEntries ();
            }
        private void ListBioProgs_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                        {
                        ListBioProgs_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 27: // escape
                        {
                        MenuCancel_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 37: //left
                        {
                        GridEntries.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void ShowEntries ()
            {
            // ComboBioProg -> Populates GridEntry
            if (ComboDepts.SelectedIndex == -1)
                return;
            string i = ListBioProgs.GetItemText (ListBioProgs.SelectedValue);
            if (Conversion.Val (i) == 0d)
                return;
            // READ FROM DATABASE
            try
                {
                NxDb.DS.Tables ["tblEntries"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Entries.ID AS EntID, CONCAT(Entries.EntYear , ' - ' , BioProgs.ProgramName) AS Prog, Entries.BioProg_ID, Entries.EntYear As Yr, Entries.StudentCount As STDs, Entries.Active, Entries.Notes FROM (Entries INNER JOIN  BioProgs ON Entries.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" + i.ToString () + " ORDER BY EntYear, ProgramName", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblEntries");
                    CnnSS.Close ();
                    }
                GridEntries.DataSource = NxDb.DS.Tables ["tblEntries"];
                GridEntries.Refresh ();
                GridEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                GridEntries.Columns [0].Width = 0;   // EntID
                GridEntries.Columns [1].Width = 0;   // TEXT
                GridEntries.Columns [2].Width = 0;   // BioProgID
                GridEntries.Columns [3].Width = 50;  // EntYear
                GridEntries.Columns [4].Width = 50;  // StudentCount
                GridEntries.Columns [5].Width = 50;  // Active
                GridEntries.Columns [6].Width = 250; // Notes
                GridEntries.Columns [0].Visible = false;
                GridEntries.Columns [1].Visible = false;
                GridEntries.Columns [2].Visible = false;
                for (int k = 0, loopTo = GridEntries.Columns.Count - 1; k <= loopTo; k++)
                    GridEntries.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                MessageBox.Show ("Err was in ShowEntries");
                return;
                }
            GridEntries.Focus ();
            }
        private void GridEntries_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (GridEntries.RowCount < 1)
                return;
            int r = GridEntries.CurrentCell.RowIndex;   // count from 0
            int c = GridEntries.CurrentCell.ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;

            GridEntries.CurrentCell = GridEntries [3, r];

            int intYear = Conversions.ToInteger (GridEntries.Rows [r].Cells [3].Value);
            NxDb.DS.Tables ["tblEntries"].Rows [r] [3] = intYear;

            int intStudents = Conversions.ToInteger (GridEntries.Rows [r].Cells [4].Value);
            NxDb.DS.Tables ["tblEntries"].Rows [r] [4] = intStudents;

            int boolActive = Conversions.ToInteger (GridEntries.Rows [r].Cells [5].Value);
            NxDb.DS.Tables ["tblEntries"].Rows [r] [5] = boolActive;

            string strNotes = GridEntries.Rows [r].Cells [6].Value.ToString ();
            NxDb.DS.Tables ["tblEntries"].Rows [r] [6] = strNotes;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "UPDATE Entries SET EntYear = @entyear, StudentCount = @studentcount, Active = @active, Notes = @notes WHERE ID = @ID";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@entyear", Conversion.Val (intYear));
                    cmd.Parameters.AddWithValue ("@studentcount", intStudents);
                    cmd.Parameters.AddWithValue ("@active", boolActive);
                    cmd.Parameters.AddWithValue ("@notes", strNotes);
                    cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblEntries"].Rows [r] [0].ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void MenuAddNewEntry_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (ComboDepts.SelectedIndex == -1)
                return;
            if (ListBioProgs.SelectedIndex == -1)
                return;
            Prog.Id = (long) Math.Round (Conversion.Int (Conversion.Val (ListBioProgs.SelectedValue)));
            int intEntYear = (int) Math.Round (Conversion.Val (Interaction.InputBox ("سال ورود به دوره آموزشي", "NexTerm", "1401")));
            if (intEntYear == 0)
                {
                MessageBox.Show ("سال معتبر نيست", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            //ADD CODES HERE TO CHECK IF EntYear IS NEW FOR THIS Entry IN THIS BioProg ----------- do it -----------
            try
                {
                int intStudentCount = 5;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "INSERT INTO Entries (BioProg_ID, EntYear, StudentCount) VALUES (@bioprogid, @entyear, @studentcount)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@bioprogid", Conversion.Val (Prog.Id));
                    cmd.Parameters.AddWithValue ("@entyear", Conversion.Val (intEntYear));
                    cmd.Parameters.AddWithValue ("@studentcount", Conversion.Val (intStudentCount));
                    cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            finally
                {
                ShowEntries ();
                }
            }
        private void GridEntries_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            switch (User.Type)
                {
                case "UserDepartment":
                        {
                        MenuOK_Click (sender, e);
                        return;
                        }
                case "UserDeputy":
                case "UserOfficer":
                        {
                        if (GridEntries.RowCount < 1)
                            return;
                        int r = GridEntries.SelectedCells [0].RowIndex;    // count from 0
                        int c = GridEntries.SelectedCells [0].ColumnIndex; // count from 0
                        if (r < 0 | c < 0)
                            return;
                        try
                            {
                            switch (c)
                                {
                                case 3:
                                case 4: // Yr, Cnt
                                        {
                                        if ((User.ACCs & 0x10) == 0)
                                            {
                                            MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                            return;
                                            }
                                        string strValue = Conversions.ToString (GridEntries [c, r].Value);
                                        strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strValue);
                                        if (Conversion.Val (strValue) == 0d)
                                            return;
                                        GridEntries [c, r].Value = Strings.Trim (strValue);
                                        break;
                                        }
                                case 5: // ACTIVE
                                        {
                                        if ((User.ACCs & 0x10) == 0)
                                            {
                                            MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                            return;
                                            }
                                        if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (GridEntries [c, r].Value, true, false)))
                                            {
                                            GridEntries [c, r].Value = false;
                                            }
                                        else
                                            {
                                            GridEntries [c, r].Value = true;
                                            }

                                        break;
                                        }
                                case 6: // Note
                                        {
                                        string strValue = Conversions.ToString (GridEntries [c, r].Value);
                                        strValue = Interaction.InputBox ("يادداشت جديد را وارد کنيد", "نکسترم", strValue);
                                        if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                            return;
                                        GridEntries [c, r].Value = Strings.Trim (strValue);
                                        break;
                                        }
                                }
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }

                        break;
                        }
                }
            }
        private void GridEntries_KeyDown (object sender, KeyEventArgs e)
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
        private void MenuOK_Click (object sender, EventArgs e)
            {
            if (GridEntries.Rows.Count > 0)
                {
                if (GridEntries.SelectedCells [0].RowIndex < 0)
                    return;
                try
                    {
                    int r = GridEntries.CurrentRow.Index;
                    // Department
                    Department.Id = Conversions.ToLong (ComboDepts.SelectedValue);
                    Department.Name = ComboDepts.Text;
                    if (Conversions.ToBoolean (Operators.ConditionalCompareObjectNotEqual (ListBioProgs.SelectedValue, Prog.Id, false)))
                        {
                        DialogResult myansw = MessageBox.Show ("اين ورودي مربوط به دوره آموزشي " + ListBioProgs.Text + "است\n" + "از انتخاب آن مطمئن هستيد؟", "مغايرت دوره هاي آموزشي", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                        if (myansw == DialogResult.No)
                            return;
                        }
                    // BioProg
                    ListBioProgs.Focus (); // to save changes
                    Prog.Id = Conversions.ToLong (ListBioProgs.SelectedValue);
                    Prog.Name = ListBioProgs.Text;
                    // Entry
                    Entry.Id = Conversions.ToLong (NxDb.DS.Tables ["tblEntries"].Rows [r] [0]);
                    Entry.Name = Conversions.ToString (NxDb.DS.Tables ["tblEntries"].Rows [r] [1]);
                    Entry.YearEntered = Conversions.ToInteger (NxDb.DS.Tables ["tblEntries"].Rows [r] [3]);
                    Close ();
                    Dispose ();
                    }
                catch (Exception ex)
                    {
                    //
                    }
                }
            else
                {
                return;
                }
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            ListBioProgs.Focus (); // to save changes
            Entry.Id = 0L;
            Entry.Name = "";
            Close ();
            Dispose ();
            }
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            ListBioProgs.Focus (); // to save changes
            Entry.Id = 0L;
            Entry.Name = "";
            Close ();
            Dispose ();

            }

        private void btnSave_Click (object sender, EventArgs e)
            {
            MenuOK_Click (null, null);
            }
        private void lblOK_Click (object sender, EventArgs e)
            {
            }

        private void lblCancel_Click (object sender, EventArgs e)
            {
            MenuCancel_Click (null, null);
            }

        }
    }