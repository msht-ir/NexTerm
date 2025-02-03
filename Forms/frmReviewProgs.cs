using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {

    public partial class frmReviewProgs
        {
        private string frmReviewType = "Entries"; // {Entries | Staff | Classes}

        public frmReviewProgs ()
            {
            InitializeComponent ();
            }
        private void frmReviewProgs_Load (object sender, EventArgs e)
            {
            Width = 1280;
            Height = 710;
            Text = "NexTerm  |  " + User.Type + "  Connected to :  " + NxDb.Server2Connect;
            // GridTime
            GridTime.Rows.Add ("ش");
            GridTime.Rows.Add ("ي");
            GridTime.Rows.Add ("د");
            GridTime.Rows.Add ("س");
            GridTime.Rows.Add ("چ");
            GridTime.Rows.Add ("پ");
            // GridTime2
            GridTime2.Rows.Add ("ش");
            GridTime2.Rows.Add ("ي");
            GridTime2.Rows.Add ("د");
            GridTime2.Rows.Add ("س");
            GridTime2.Rows.Add ("چ");
            GridTime2.Rows.Add ("پ");
            for (int i = 0; i <= 8; i++)
                {
                GridTime.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                GridTime2.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            // Fill Depts
            try
                {
                cboDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
                cboDepts.DisplayMember = "DEPT";
                cboDepts.ValueMember = "ID";
                if (User.Type == "UserDeputy")
                    {
                    cboDepts.SelectedValue = Department.Id; // This triggers cbo_Change ?
                    List1_Click (sender, e);
                    ListTerm_Click (sender, e);
                    }
                else if (User.Type == "UserDepartment")
                    {
                    cboDepts.SelectedValue = User.Id; // This triggers cbo_Change ?
                    List1_Click (sender, e);
                    ListTerm_Click (sender, e);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Menu2_Entries_Click (sender, e);
            }
        private void cboDepts_SelectedIndexChanged (object sender, EventArgs e)
            {
            switch (frmReviewType ?? "")
                {
                case "Entries":
                        {
                        Menu2_Entries_Click (sender, e);
                        break;
                        }
                case "Staff":
                        {
                        Menu2_Staff_Click (sender, e);
                        break;
                        }
                }
            }
        //Menu ReviewType
        private void Grid4_CellContentDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (Grid4.RowCount < 1)
                return;
            int r = Grid4.SelectedCells [0].RowIndex;
            int c = Grid4.SelectedCells [0].ColumnIndex;
            if (c != 7 & c != 29)
                return; // col7: Staff / col29: Entry
            Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
            Term.Id = Conversions.ToLong (ListTerm.SelectedValue);
            switch (frmReviewType ?? "")
                {
                case "Entries":
                        {
                        Staff.Id = Conversions.ToLong (Grid4 [6, r].Value);
                        Staff.Name = Conversions.ToString (Grid4 [7, r].Value);
                        Menu2_Staff_Click (sender, e);
                        break;
                        }
                case "Staff":
                        {
                        Entry.Id = Conversions.ToLong (List1.SelectedValue);
                        Entry.Name = Conversions.ToString (Grid4 [29, r].Value);
                        Menu2_Entries_Click (sender, e);
                        break;
                        }
                case "Classes":
                        {
                        switch (c)
                            {
                            case 7: // DblClick on Staff
                                    {
                                    Staff.Id = Conversions.ToLong (Grid4 [6, r].Value);
                                    Staff.Name = Conversions.ToString (Grid4 [7, r].Value);
                                    Menu2_Staff_Click (sender, e);
                                    break;
                                    }
                            case 29: // DblClick on Entry
                                    {
                                    Entry.Id = Conversions.ToLong (List1.SelectedValue);
                                    Entry.Name = Conversions.ToString (Grid4 [29, r].Value);
                                    Menu2_Entries_Click (sender, e);
                                    break;
                                    }
                            }

                        break;
                        }
                }

            }
        private void Menu2_Entries_Click (object sender, EventArgs e)
            {
            frmReviewType = "Entries"; // {Entries | Staff | Classes}
            cboDepts.Enabled = true;
            NxDb.DS.Tables ["tblEntries"].Clear ();
            try
                {
                string i = cboDepts.GetItemText (cboDepts.SelectedValue);
                if (Conversion.Val (i) == 0d)
                    return;
                if (Conversions.ToBoolean (Operators.AndObject (User.Type == "UserDepartment", Operators.ConditionalCompareObjectNotEqual (cboDepts.SelectedValue, User.Id, false))))
                    return;
                if (Conversions.ToBoolean (Operators.AndObject (User.Type == "UserDepartment", Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblDepartments"].Rows [cboDepts.SelectedIndex] [2], false, false))))
                    return; // check if department is active  //  Item(2):DepartmentActive
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Entries.ID AS EntID, CONCAT(EntYear , ' - ' , ProgramName) As Prog, BioProg_ID FROM ((BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID) INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) WHERE Department_ID =" + i.ToString () + " AND Active = 1 ORDER BY EntYear, ProgramName", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblEntries");
                    CnnSS.Close ();
                    }
                List1.DataSource = NxDb.DS.Tables ["tblEntries"];
                List1.DisplayMember = "Prog";
                List1.ValueMember = "EntID";
                List1.SelectedValue = Entry.Id;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            //TERMs
            UpdateListTerms ();
            Grid4.DataSource = "";
            ClearGridTime ();
            if (ListTerm.Items.Count > 0 & TermProg.DefaultTermId > 0)
                {
                ListTerm.SelectedValue = TermProg.DefaultTermId;
                }
            ListTerm_Click (sender, e);
            }
        private void Menu2_Staff_Click (object sender, EventArgs e)
            {
            frmReviewType = "Staff"; // {Entries | Staff | Classes}
            cboDepts.Enabled = true;
            NxDb.DS.Tables ["tblStaff"].Clear ();
            try
                {
                string i = cboDepts.GetItemText (cboDepts.SelectedValue);
                if (Conversion.Val (i) == 0d)
                    return;
                if (Conversions.ToBoolean (Operators.AndObject (User.Type == "UserDepartment", Operators.ConditionalCompareObjectNotEqual (cboDepts.SelectedValue, User.Id, false))))
                    return;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" + i.ToString () + " ORDER BY StaffName", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblStaff");
                    CnnSS.Close ();
                    }
                List1.DataSource = NxDb.DS.Tables ["tblStaff"];
                List1.DisplayMember = "StaffName";
                List1.ValueMember = "ID";
                List1.SelectedValue = 0;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }

            //TERMs
            UpdateListTerms ();
            Grid4.DataSource = "";
            ClearGridTime ();
            if (ListTerm.Items.Count > 0 & TermProg.DefaultTermId > 0)
                {
                ListTerm.SelectedValue = TermProg.DefaultTermId;
                }
            try
                {
                for (int i = 0, loopTo = List1.Items.Count - 1; i <= loopTo; i++)
                    {
                    List1.SelectedIndex = i;
                    if ((List1.Text ?? "") == (Staff.Name ?? ""))
                        {
                        break;
                        }
                    }
                ListTerm_Click (sender, e);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu2_Classes_Click (object sender, EventArgs e)
            {
            frmReviewType = "Classes"; // {Entries | Staff | Classes}
            cboDepts.Enabled = false;
            NxDb.DS.Tables ["tblRooms"].Clear ();
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act FROM Rooms WHERE Active = 1 ORDER BY RoomName", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblRooms");
                    CnnSS.Close ();
                    }
                //Populate ListBox1(the Classes)
                List1.DataSource = NxDb.DS.Tables ["tblRooms"];
                List1.DisplayMember = "Class";
                List1.ValueMember = "ID";
                List1.SelectedValue = 0;
                UpdateListTerms ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Grid4.DataSource = "";
            ClearGridTime ();
            if (ListTerm.Items.Count > 0 & TermProg.DefaultTermId > 0)
                {
                ListTerm.SelectedValue = TermProg.DefaultTermId;
                }
            ListTerm_Click (sender, e);
            }
        private void ClearGridTime ()
            {
            for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
                {
                for (int intDay = 0; intDay <= 5; intDay++) // each day
                    GridTime [intTime + 1, intDay].Value = "";
                }
            }
        //
        public void UpdateListTerms ()
            {
            //TERMs
            try
                {
                NxDb.DS.Tables ["tblTerms"].Clear ();
                switch (User.Type)
                    {
                    case "UserDepartment": //show active terms
                            {
                            //if (Conversions.ToBoolean (Operators.ConditionalCompareObjectNotEqual (NxDb.DS.Tables ["tblDepartments"].Rows [cboDepts.SelectedIndex] [8], true, false)))
                            //if ((bool)NxDb.DS.Tables ["tblDepartments"].Rows [cboDepts.SelectedIndex] [8] == false)
                            if ((User.ACCs & 0x8) == 0x0)
                                {
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                    {
                                    CnnSS.Open ();
                                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Terms.[Active] = 1 ORDER BY Term", CnnSS);
                                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                                    CnnSS.Close ();
                                    }
                                }
                            else
                                {
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                    {
                                    CnnSS.Open ();
                                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) ORDER BY Term", CnnSS);
                                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                                    CnnSS.Close ();
                                    }
                                }
                            break;
                            }
                    case "UserDeputy": // show all terms
                    case "UserOfficer":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT DISTINCT Terms.ID, Terms.Term, ExamDateStart, ExamDateEnd, Terms.Notes, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) ORDER BY Term", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblTerms");
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
            ListTerm.DataSource = NxDb.DS.Tables ["tblTerms"];
            ListTerm.DisplayMember = "Term";
            ListTerm.ValueMember = "ID";
            ListTerm.SelectedIndex = -1;
            ListTerm.SelectedValue = 0;
            }
        private void List1_Click (object sender, EventArgs e)
            {
            ListTerm_Click (sender, e);
            }
        private void ListTerm_Click (object sender, EventArgs e)
            {
            FillGrids ("GridTime1");
            lblGridTime1.Text = List1.Text + "        Term   " + ListTerm.Text;
            }
        private void FillGrids (string strDestinationGrid)
            {
            string Trm = ListTerm.GetItemText (ListTerm.SelectedValue);
            if (Conversion.Val (Trm) == 0d)
                return;
            Grid4.DataSource = null;
            GridTime.DataSource = null;
            switch (frmReviewType ?? "")
                {
                case "Entries": // ---------------------------------------------------------------------------------------------- /// Entries
                        {
                        string Ent = List1.GetItemText (List1.SelectedValue);
                        if (Conversion.Val (Ent) == 0d)
                            return;
                        try
                            {
                            Grid4.DataBindings.Clear ();
                            NxDb.DS.Tables ["tblAllProgs"].Clear ();
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Trm.ToString () + " AND Entry_ID = " + Ent.ToString () + " ORDER BY CourseName, [Group]", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }
                        Grid4.DataSource = NxDb.DS.Tables ["tblAllProgs"];
                        Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        // hide some cols
                        Grid4.Columns [0].Visible = false;    // ID
                        Grid4.Columns [1].Visible = false;    // Course ID
                        Grid4.Columns [6].Visible = false;    // Staff ID
                        Grid4.Columns [7].Width = 250;        // StaffName
                        Grid4.Columns [8].Visible = false;    // Tech ID
                        Grid4.Columns [9].Visible = false;    // Tech Name
                        Grid4.Columns [10].Visible = false;   // SAT 1
                        Grid4.Columns [11].Visible = false;   // SUN 1
                        Grid4.Columns [12].Visible = false;   // MON 1
                        Grid4.Columns [13].Visible = false;   // TUE 1
                        Grid4.Columns [14].Visible = false;   // WED 1
                        Grid4.Columns [15].Visible = false;   // THR 1
                        Grid4.Columns [16].Visible = false;   // Room 1
                        Grid4.Columns [17].Visible = false;   // Room 1
                        Grid4.Columns [18].Visible = false;   // SAT 2
                        Grid4.Columns [19].Visible = false;   // SUN 2
                        Grid4.Columns [20].Visible = false;   // MON 2
                        Grid4.Columns [21].Visible = false;   // TUE 2
                        Grid4.Columns [22].Visible = false;   // WED 2
                        Grid4.Columns [23].Visible = false;   // THR 2
                        Grid4.Columns [24].Visible = false;   // Room 2
                        Grid4.Columns [25].Visible = false;   // Room 2
                        Grid4.Columns [26].Visible = false;   // Capa
                        Grid4.Columns [27].Visible = false;   // ExamDate
                        Grid4.Columns [30].Visible = false;   // Term
                        Grid4.Columns [2].Width = 90;         // CourseNumber
                        Grid4.Columns [3].Width = 220;        // CourseName
                        Grid4.Columns [4].Width = 35;         // Units
                        Grid4.Columns [5].Width = 30;         // Group
                        Grid4.Columns [28].Width = 250;       // Note
                        Grid4.Columns [29].Visible = false;   // Entry-Name
                        for (int i = 0, loopTo = Grid4.Columns.Count - 1; i <= loopTo; i++)
                            Grid4.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                        // FILL GRID TIME
                        Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
                        bool TadakholExists = false;
                        for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
                            {
                            for (int intDay = 0; intDay <= 5; intDay++) // each day
                                {
                                switch (strDestinationGrid ?? "")
                                    {
                                    case "GridTime1":
                                            {
                                            GridTime [intTime + 1, intDay].Value = "";
                                            for (int intThisStaff = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo1; intThisStaff++)
                                                {
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                }

                                            break;
                                            }
                                    case "GridTime2":
                                            {
                                            GridTime2 [intTime + 1, intDay].Value = "";
                                            for (int intThisStaff = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo2; intThisStaff++)
                                                {
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime2 [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime2 [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                }

                                            break;
                                            }
                                    }
                                }
                            }

                        break;
                        }
                case "Staff": // ---------------------------------------------------------------------------------------------- /// Staff
                        {
                        string intStaff = List1.GetItemText (List1.SelectedValue);
                        if (Conversion.Val (intStaff) == 0d)
                            return;
                        try
                            {
                            Grid4.DataBindings.Clear ();
                            NxDb.DS.Tables ["tblAllProgs"].Clear ();
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Trm.ToString () + " AND Staff_ID = " + intStaff.ToString () + " ORDER BY CourseName", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }
                        Grid4.DataSource = NxDb.DS.Tables ["tblAllProgs"];
                        Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        // hide some cols
                        Grid4.Columns [0].Visible = false;    // ID
                        Grid4.Columns [1].Visible = false;    // Course ID
                        Grid4.Columns [6].Visible = false;    // Staff ID
                        Grid4.Columns [7].Visible = false;    // StaffName
                        Grid4.Columns [8].Visible = false;    // Tech ID
                        Grid4.Columns [9].Visible = false;    // Tech Name
                        Grid4.Columns [10].Visible = false;   // SAT 1
                        Grid4.Columns [11].Visible = false;   // SUN 1
                        Grid4.Columns [12].Visible = false;   // MON 1
                        Grid4.Columns [13].Visible = false;   // TUE 1
                        Grid4.Columns [14].Visible = false;   // WED 1
                        Grid4.Columns [15].Visible = false;   // THR 1
                        Grid4.Columns [16].Visible = false;   // Room 1
                        Grid4.Columns [17].Visible = false;   // Room 1
                        Grid4.Columns [18].Visible = false;   // SAT 2
                        Grid4.Columns [19].Visible = false;   // SUN 2
                        Grid4.Columns [20].Visible = false;   // MON 2
                        Grid4.Columns [21].Visible = false;   // TUE 2
                        Grid4.Columns [22].Visible = false;   // WED 2
                        Grid4.Columns [23].Visible = false;   // THR 2
                        Grid4.Columns [24].Visible = false;   // Room 2
                        Grid4.Columns [25].Visible = false;   // Room 2
                        Grid4.Columns [26].Visible = false;   // Capa
                        Grid4.Columns [27].Visible = false;   // ExamDate
                        Grid4.Columns [30].Visible = false;   // Term
                        Grid4.Columns [2].Width = 90;     // CourseNumber
                        Grid4.Columns [3].Width = 220;    // CourseName
                        Grid4.Columns [4].Width = 35;     // Units
                        Grid4.Columns [5].Width = 30;     // Group
                        Grid4.Columns [28].Width = 250;   // Note
                        Grid4.Columns [29].Width = 250;   // Entry-Name
                        for (int i = 0, loopTo3 = Grid4.Columns.Count - 1; i <= loopTo3; i++)
                            Grid4.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                        // FILL GRID TIME
                        Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
                        bool TadakholExists = false;
                        for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
                            {
                            for (int intDay = 0; intDay <= 5; intDay++) // each day
                                {
                                switch (strDestinationGrid ?? "")
                                    {
                                    case "GridTime1":
                                            {
                                            GridTime [intTime + 1, intDay].Value = "";
                                            for (int intThisStaff = 0, loopTo4 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo4; intThisStaff++)
                                                {
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                }

                                            break;
                                            }
                                    case "GridTime2":
                                            {
                                            GridTime2 [intTime + 1, intDay].Value = "";
                                            for (int intThisStaff = 0, loopTo5 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo5; intThisStaff++)
                                                {
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime2 [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime2 [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                }

                                            break;
                                            }
                                    }
                                }
                            }

                        break;
                        }

                case "Classes": // ---------------------------------------------------------------------------------------------- /// Classes
                        {
                        string Roomx = List1.GetItemText (List1.SelectedValue);
                        if (Conversion.Val (Roomx) == 0d)
                            return;
                        try
                            {
                            Grid4.DataBindings.Clear ();
                            NxDb.DS.Tables ["tblAllProgs"].Clear ();
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                {
                                CnnSS.Open ();
                                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Trm + " AND (Room1 = " + Roomx + " OR Room2 = " + Roomx + ")  ORDER BY CourseName, [Group]", CnnSS);
                                NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }
                        Grid4.DataSource = NxDb.DS.Tables ["tblAllProgs"];
                        Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        // hide some cols
                        Grid4.Columns [0].Visible = false;    // ID
                        Grid4.Columns [1].Visible = false;    // Course ID
                        Grid4.Columns [6].Visible = false;    // Staff ID
                        Grid4.Columns [7].Width = 250;        // StaffName
                        Grid4.Columns [8].Visible = false;    // Tech ID
                        Grid4.Columns [9].Visible = false;    // Tech Name
                        Grid4.Columns [10].Visible = false;   // SAT 1
                        Grid4.Columns [11].Visible = false;   // SUN 1
                        Grid4.Columns [12].Visible = false;   // MON 1
                        Grid4.Columns [13].Visible = false;   // TUE 1
                        Grid4.Columns [14].Visible = false;   // WED 1
                        Grid4.Columns [15].Visible = false;   // THR 1
                        Grid4.Columns [16].Visible = false;   // Room 1
                        Grid4.Columns [17].Visible = false;   // Room 1
                        Grid4.Columns [18].Visible = false;   // SAT 2
                        Grid4.Columns [19].Visible = false;   // SUN 2
                        Grid4.Columns [20].Visible = false;   // MON 2
                        Grid4.Columns [21].Visible = false;   // TUE 2
                        Grid4.Columns [22].Visible = false;   // WED 2
                        Grid4.Columns [23].Visible = false;   // THR 2
                        Grid4.Columns [24].Visible = false;   // Room 2
                        Grid4.Columns [25].Visible = false;   // Room 2
                        Grid4.Columns [26].Visible = false;   // Capa
                        Grid4.Columns [27].Visible = false;   // ExamDate
                        Grid4.Columns [30].Visible = false;   // Term
                        Grid4.Columns [2].Width = 90;         // CourseNumber
                        Grid4.Columns [3].Width = 220;        // CourseName
                        Grid4.Columns [4].Width = 35;         // Units
                        Grid4.Columns [5].Width = 30;         // Group
                        Grid4.Columns [28].Visible = false;   // Note
                        Grid4.Columns [29].Width = 250;       // Entry-Name
                        for (int i = 0, loopTo6 = Grid4.Columns.Count - 1; i <= loopTo6; i++)
                            Grid4.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                        // FILL GRID TIME
                        Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
                        bool TadakholExists = false;
                        for (int intTime = 0; intTime <= 7; intTime++) // for each time of day
                            {
                            for (int intDay = 0; intDay <= 5; intDay++) // each day
                                {
                                switch (strDestinationGrid ?? "")
                                    {
                                    case "GridTime1":
                                            {
                                            GridTime [intTime + 1, intDay].Value = "";
                                            for (int intThisStaff = 0, loopTo7 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo7; intThisStaff++)
                                                {
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                }

                                            break;
                                            }
                                    case "GridTime2":
                                            {
                                            GridTime2 [intTime + 1, intDay].Value = "";
                                            for (int intThisStaff = 0, loopTo8 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisStaff <= loopTo8; intThisStaff++)
                                                {
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime2 [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisStaff] [intDay + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false)))
                                                    {
                                                    TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                                    GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                    if (TermProg.TimeFlag [intDay, intTime] > 1)
                                                        {
                                                        TadakholExists = true;
                                                        GridTime2 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                                        }
                                                    else
                                                        {
                                                        GridTime2 [intTime + 1, intDay].Value = Grid4 [3, intThisStaff].Value;
                                                        }
                                                    }
                                                }

                                            break;
                                            }
                                    }
                                }
                            }

                        break;
                        }
                }

            }
        private void GridTime_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                Term.Name = ListTerm.Text;
                int r = GridTime.CurrentCell.RowIndex;    // count from 0
                int c = GridTime.CurrentCell.ColumnIndex; // count from 0
                if (r < 0 | c < 0)
                    return;
                switch (frmReviewType ?? "")
                    {
                    case "Entries": // ---------------------------------------------------------------- ////// ---------------- Ent
                            {
                            string strTadakholMessage = "";
                            if (Conversion.Val (GridTime [c, r].Value) > 0d)
                                {
                                for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
                                    {
                                    if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false))))
                                        {
                                        strTadakholMessage = Conversions.ToString (strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3] + "\n استاد " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7] + "\n" + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17]) + "   " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25] + "\n\n\n";
                                        }
                                    }
                                MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK);
                                GridTime.CurrentCell = GridTime [0, r];
                                }

                            break;
                            }
                    case "Staff": // ---------------------------------------------------------------- ////// ---------------- Staff
                            {
                            string strTadakholMessage = "";
                            if (Conversion.Val (GridTime [c, r].Value) > 0d)
                                {
                                for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo1; i++)
                                    {
                                    if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false))))
                                        {
                                        strTadakholMessage = Conversions.ToString (strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3] + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29] + "\n" + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17]) + "   " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25] + "\n\n\n";
                                        }
                                    }
                                MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK);
                                GridTime.CurrentCell = GridTime [0, r];
                                }

                            break;
                            }
                    case "Classes": // ---------------------------------------------------------------- ////// ---------------- Class
                            {
                            string strTadakholMessage = "";
                            if (Conversion.Val (GridTime [c, r].Value) > 0d)
                                {
                                for (int i = 0, loopTo2 = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo2; i++)
                                    {
                                    if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false), Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18], Math.Pow (2d, c - 1)), Math.Pow (2d, c - 1), false))))
                                        {
                                        strTadakholMessage = Conversions.ToString (strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3] + "\n استاد " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7]) + "\n" + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [17] + "   " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [25] + "\n\n\n";
                                        }
                                    }
                                MessageBox.Show (strTadakholMessage, "نکسترم", MessageBoxButtons.OK);
                                GridTime.CurrentCell = GridTime [0, r];
                                }

                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("err");
                MessageBox.Show (ex.ToString ());
                }
            }
        //Menu Report-Exit
        private void Menu_ShowInGridTime2_Click (object sender, EventArgs e)
            {
            if (ListTerm.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                FillGrids ("GridTime2");
                lblGridTime2.Text = List1.Text + "        Term   " + ListTerm.Text;
                Grid4.DataSource = null;
                ClearGridTime ();
                }
            }
        private void Menu_Report_Click (object sender, EventArgs e)
            {
            switch (frmReviewType ?? "")
                {
                case "Entries":
                        {
                        ReportProgEntries ();
                        break;
                        }
                case "Staff":
                        {
                        ReportProgStaff ();
                        break;
                        }
                case "Classes":
                        {
                        ReportProgClasses ();
                        break;
                        }
                }

            }
        public void ReportProgEntries ()
            {
            // Report ENTRIES
            // Get Department ID, Term ID and Entry ID
            if (cboDepts.SelectedIndex != -1)
                {
                Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
                }
            else
                {
                return;
                }
            if (List1.SelectedIndex != -1)
                {
                Entry.Name = List1.Text;
                Entry.Id = Conversions.ToLong (List1.SelectedValue);
                }
            else
                {
                return;
                }
            if (ListTerm.SelectedIndex != -1)
                {
                Term.Id = Conversions.ToLong (ListTerm.SelectedValue);
                Term.Name = ListTerm.Text;
                }
            else
                {
                return;
                }
            // READ Entry TABLE
            FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_entries_All.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir= \"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>برنامه ورودي</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
            FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><p style='color:blue;text-align: center'>" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "</p><hr>");
            NxDb.DS.Tables ["tblAllProgs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Entry_ID = " + Entry.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                CnnSS.Close ();
                }
            FileSystem.PrintLine (1, "<h4 style='color:red'>", Entry.Name, "</h4>");
            Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
            //Main Table 
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse; Text-Align:Center'>");
            FileSystem.PrintLine (1, "<tr><th>روز</th><th>8:30</th><th>9:30</th><th>10:30</th><th>11:30</th><th>13:30</th><th>14:30</th><th>15:30</th><th>16:30</th></tr>");
            for (int intday = 0; intday <= 5; intday++)
                {
                FileSystem.PrintLine (1, "<tr><td>", TermProg.Day [intday], "</td>");                                 // Day of Week
                for (int intTime = 0; intTime <= 7; intTime++)
                    {
                    FileSystem.PrintLine (1, "<td>");
                    for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
                        {
                        if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
                            {
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");              // 2 :CourseNumber
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");              // 7 :Staff
                            }
                        if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
                            {
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");              // 2 :CourseNumber
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");              // 7 :Staff
                            }
                        }
                    FileSystem.PrintLine (1, "</td>");
                    }
                FileSystem.PrintLine (1, "</tr>");
                }
            FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            // table: Exams dates for Staff
            NxDb.DS.Tables ["tblTermExams"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Entry_ID = " + Entry.Id.ToString () + " ORDER BY ExamDate", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
                CnnSS.Close ();
                }
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه امتحانات</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
            FileSystem.PrintLine (1, "<tr><th>تاريخ</th>");
            FileSystem.PrintLine (1, "<th>درس</th>");
            FileSystem.PrintLine (1, "<th>استاد</th></tr>");
            for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo1; i++)
                {
                FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [1], "</td>");  // 1 :Exam
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [2], "</td>");      // 2 :Course
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [5], "</td></tr>"); // 5 :StaffName
                }
            FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            //footer
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body></html>");
            FileSystem.FileClose (1);
            // WriteLOG(13)
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_entries_All.html");
            }
        public void ReportProgStaff ()
            {
            // Report STAFFs
            // Get Department ID, Term ID and Staff ID
            if (cboDepts.SelectedIndex != -1)
                {
                Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
                }
            else
                {
                return;
                }
            if (List1.SelectedIndex != -1)
                {
                Staff.Name = List1.Text;
                Staff.Id = Conversions.ToLong (List1.SelectedValue);
                }
            else
                {
                return;
                }
            if (ListTerm.SelectedIndex != -1)
                {
                Term.Id = Conversions.ToLong (ListTerm.SelectedValue);
                Term.Name = ListTerm.Text;
                }
            else
                {
                return;
                }

            // READ STAFF TABLE
            FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_staff_All.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir= \"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>برنامه استاد</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
            FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><p style='color:blue;text-align: center'>" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "</p><hr>");
            NxDb.DS.Tables ["tblAllProgs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                CnnSS.Close ();
                }
            FileSystem.PrintLine (1, "<h4 style='color:red'>", Staff.Name, "</h4>");
            Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
            //Main Table 
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse; Text-Align:Center'>");
            FileSystem.PrintLine (1, "<tr><th>روز</th><th>8:30</th><th>9:30</th><th>10:30</th><th>11:30</th><th>13:30</th><th>14:30</th><th>15:30</th><th>16:30</th></tr>");
            for (int intday = 0; intday <= 5; intday++)
                {
                FileSystem.PrintLine (1, "<tr><td>", TermProg.Day [intday], "</td>");                                 // Day of Week
                for (int intTime = 0; intTime <= 7; intTime++)
                    {
                    FileSystem.PrintLine (1, "<td>");
                    for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
                        {
                        if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
                            {
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");               // 3 :CourseName
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");               // 2 :CourseNumber
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");              // 29 :Entry
                            }
                        if (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false))
                            {
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");               // 3 :CourseName
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");               // 2 :CourseNumber
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");              // 29 :Entry
                            }
                        }
                    FileSystem.PrintLine (1, "</td>");
                    }
                FileSystem.PrintLine (1, "</tr>");
                }
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            FileSystem.PrintLine (1, "</table><br>");
            // table: Exams dates for Staff
            NxDb.DS.Tables ["tblTermExams"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " + Term.Id.ToString () + " AND Staff_ID = " + Staff.Id.ToString () + " ORDER BY ExamDate", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTermExams");
                CnnSS.Close ();
                }
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'>برنامه امتحانات</p>");
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse'>");
            FileSystem.PrintLine (1, "<tr><th>تاريخ</th>");
            FileSystem.PrintLine (1, "<th>درس</th>");
            FileSystem.PrintLine (1, "<th>ورودي</th></tr>");
            for (int i = 0, loopTo1 = NxDb.DS.Tables ["tblTermExams"].Rows.Count - 1; i <= loopTo1; i++)
                {
                FileSystem.PrintLine (1, "<tr><td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [1], "</td>");  // 1 :Exam
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [2], "</td>");      // 2 :Course
                FileSystem.PrintLine (1, "<td>", NxDb.DS.Tables ["tblTermExams"].Rows [i] [7], "</td></tr>"); // 7 :Entry string
                }
            FileSystem.PrintLine (1, "</table><br>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            //footer
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body></html>");
            FileSystem.FileClose (1);
            // WriteLOG(15)     ///This sub is in frm.TermProgs!
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_staff_All.html");
            //reset back the list of Entries to original (for intUser, rather than intDept which is modified in frmReportSettings) 

            }
        public void ReportProgClasses ()
            {
            // Report CLASSS ? correct the code!
            // REPORT all CLASSES (in a term)
            if (List1.SelectedIndex != -1)
                {
                Room.Name = List1.Text;
                Room.Id = Conversions.ToLong (List1.SelectedValue);
                }
            else
                {
                return;
                }
            if (ListTerm.SelectedIndex != -1)
                {
                Term.Id = Conversions.ToLong (ListTerm.SelectedValue);
                Term.Name = ListTerm.Text;
                }
            else
                {
                return;
                }
            // READ ROOM TABLE
            FileSystem.FileOpen (1, Application.StartupPath + "Nexterm_class_All.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir= \"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>برنامه کلاس</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>", Report.AppOwner, "</p>");
            FileSystem.PrintLine (1, "<h2 style='color:Green; text-align: center'>", Term.Name, "</h2><p style='color:blue;text-align: center'>" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "</p><hr>");
            NxDb.DS.Tables ["tblAllProgs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Term_ID = " + Term.Id.ToString () + " AND (Room1 = " + Room.Id.ToString () + " OR Room2 = " + Room.Id.ToString () + ")) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                CnnSS.Close ();
                }
            FileSystem.PrintLine (1, "<h4 style='color:red'>", Room.Name, "</h4>");
            Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length); // clear data in intTimeFlag (r:6days, c:8times //begins from 0)
                                                                          //Main Table
            FileSystem.PrintLine (1, "<center>");
            FileSystem.PrintLine (1, "<div class= \"table-responsive col-md-10\">");
            FileSystem.PrintLine (1, "<table class= \"table table-hover\" style='font-family:tahoma; font-size:12px; border-collapse:collapse; Text-Align:Center'>");
            FileSystem.PrintLine (1, "<tr><th>روز</th><th>8:30</th><th>9:30</th><th>10:30</th><th>11:30</th><th>13:30</th><th>14:30</th><th>15:30</th><th>16:30</th></tr>");
            for (int intday = 0; intday <= 5; intday++)
                {
                FileSystem.PrintLine (1, "<tr><td>", TermProg.Day [intday], "</td>");                                 // Day of Week
                for (int intTime = 0; intTime <= 7; intTime++)
                    {
                    FileSystem.PrintLine (1, "<td>");
                    for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
                        {
                        if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 10], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [16], Room.Id, false))))
                            {
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");              // 2 :CourseNumber
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");              // 7 :Staff
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");             // 29 :Entry
                            }
                        if (Conversions.ToBoolean (Operators.AndObject (Operators.ConditionalCompareObjectEqual (Operators.AndObject (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [intday + 18], Math.Pow (2d, intTime)), Math.Pow (2d, intTime), false), Operators.ConditionalCompareObjectEqual (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [24], Room.Id, false))))
                            {
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3], "<br>");              // 3 :CourseName
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [2], "<br>");              // 2 :CourseNumber
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7], "<br>");              // 7 :Staff
                            FileSystem.PrintLine (1, NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29], "<br>");             // 29 :Entry
                            }
                        }
                    FileSystem.PrintLine (1, "</td>");
                    }
                FileSystem.PrintLine (1, "</tr>");
                }
            FileSystem.PrintLine (1, "</table>");
            FileSystem.PrintLine (1, "</div>");
            FileSystem.PrintLine (1, "</center>");
            //footer
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><br></p><br>");
            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
            FileSystem.PrintLine (1, "</body></html>");
            FileSystem.FileClose (1);
            // WriteLOG(14)
            Interaction.Shell ("explorer.exe " + Application.StartupPath + "Nexterm_class_All.html");
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu2_More_Click (object sender, EventArgs e)
            {
            Department.Id = Conversions.ToLong (cboDepts.SelectedValue);
            if (frmReviewType == "Entries")
                {
                Entry.Id = Conversions.ToLong (List1.SelectedValue);
                }
            Dispose ();
            My.MyProject.Forms.frmReviewProgs3.ShowDialog ();
            }
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu3_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu2_Guide_Click (object sender, EventArgs e)
            {
            FileSystem.FileOpen (1, Application.StartupPath + @"\NexTerm_Guide.html", OpenMode.Output);
            FileSystem.PrintLine (1, "<html dir=\"rtl\">");
            FileSystem.PrintLine (1, "<head>");
            FileSystem.PrintLine (1, "<title>راهنما</title>");
            FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
            FileSystem.PrintLine (1, "</head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>");
            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>راهنماي نرم افزار نکسترم</p>");
            FileSystem.PrintLine (1, "<hr>");
            FileSystem.PrintLine (1, "<p style='color:red;font-family:tahoma; font-size:14px'> راهنماي مرور برنامه ها <br></p>");
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:14px'>");
            FileSystem.PrintLine (1, " گروه آموزشي را از ليست انتخاب کنيد <br>");
            FileSystem.PrintLine (1, "ورودي را از ليست انتخاب کنيد <br>");
            FileSystem.PrintLine (1, "برنامه فعلي را توسط منو (راست کليک) به جدول پايين انتقال دهيد <br>");
            FileSystem.PrintLine (1, "محتواي جدول بالا را با انتخاب يک ورودي ديگر تغيير دهيد <br>");
            FileSystem.PrintLine (1, "  <br>");
            FileSystem.PrintLine (1, "روي ليست وروديها راست کليک کنيد و برنامه اساتيد و يا کلاسها را ببينيد  <br>");
            FileSystem.PrintLine (1, "  <br>");
            FileSystem.PrintLine (1, "از منو، گزينه (بيشتر) را انتخاب کنيد تا پنجره ديگر با تعداد جدول بيشتر باز شود <br>");
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