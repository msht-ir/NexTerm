using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseClass
        {
        public ChooseClass ()
            {
            InitializeComponent ();
            }
        private void ChooseClass_Load (object sender, EventArgs e)
            {
            Grid5.Rows.Add ("ش");
            Grid5.Rows.Add ("ی");
            Grid5.Rows.Add ("د");
            Grid5.Rows.Add ("س");
            Grid5.Rows.Add ("چ");
            Grid5.Rows.Add ("پ");
            if (Term.Id < 1L)
                {
                DialogResult myansw = MessageBox.Show ("يک نيمسال را مشخص مي کنيد؟", "نکسترم", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3, MessageBoxOptions.RightAlign);
                switch (myansw)
                    {
                    case DialogResult.Cancel:
                            {
                            Dispose ();
                            break;
                            }
                    case DialogResult.Yes:
                            {
                            TermProg.Caption = "Terms";
                            My.MyProject.Forms.ChooseTerm.ShowDialog ();
                            break;
                            }
                    case DialogResult.No:
                            {
                            //do nothing!
                            break;
                            }
                    }
                }
            ShowClasses ();
            }
        private void ShowClasses ()
            {
            if (User.Type == "UserDepartment")
                {
                MenuAddNewClass.Enabled = false;
                Menu_Edit.Enabled = false;
                GridRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            GridRoom.EditMode = DataGridViewEditMode.EditProgrammatically;
            //read from DB
            NxDb.DS.Tables ["tblRooms"].Clear ();
            switch (User.Type)
                {
                case "UserDeputy":
                case "UserOfficer":
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            CnnSS.Open ();
                            NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act, Owner_ID As Own, Restricted2Owner As Res FROM Rooms ORDER BY RoomName", CnnSS);
                            NxDb.DASS.Fill (NxDb.DS, "tblRooms");
                            CnnSS.Close ();
                            }
                        break;
                        }
                case "UserDepartment":
                        {
                        switch (User.ACCs & 0x20) //0010'0000 = 32
                            {
                            case 32:
                                    {
                                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                        {
                                        CnnSS.Open ();
                                        NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act, Owner_ID As Own, Restricted2Owner As Res FROM Rooms WHERE Active = 1 AND Owner_ID = " + User.Id.ToString () + " ORDER BY RoomName", CnnSS);
                                        NxDb.DASS.Fill (NxDb.DS, "tblRooms");
                                        CnnSS.Close ();
                                        }
                                    break;
                                    }

                            case 0:
                                    {
                                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                                        {
                                        CnnSS.Open ();
                                        NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act, Owner_ID As Own, Restricted2Owner As Res FROM Rooms WHERE Active = 1 ORDER BY RoomName", CnnSS);
                                        NxDb.DASS.Fill (NxDb.DS, "tblRooms");
                                        CnnSS.Close ();
                                        }
                                    break;
                                    }
                            }
                        break;
                        }
                }
            GridRoom.DataSource = NxDb.DS.Tables ["tblRooms"];
            GridRoom.Refresh ();
            GridRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridRoom.Columns [0].Visible = false;    // ID
            GridRoom.Columns [1].Width = 180;        // Room
            GridRoom.Columns [2].Width = 38;         // Capa
            GridRoom.Columns [3].Width = 23;         // AV
            GridRoom.Columns [4].Width = 27;         // Active
            GridRoom.Columns [5].Width = 32;         // OwnerID
            GridRoom.Columns [6].Width = 32;         // Restricted2Owner
            if (User.Type == "UserDepartment")
                {
                GridRoom.Columns [4].Visible = false;
                GridRoom.Columns [5].Visible = false;
                GridRoom.Columns [6].Visible = false;
                }
            else
                {
                GridRoom.Columns [4].Visible = true;
                GridRoom.Columns [5].Visible = true;
                GridRoom.Columns [6].Visible = true;
                }
            // inactivate columns sort property
            for (int i = 0, loopTo = Grid5.Columns.Count - 1; i <= loopTo; i++)
                Grid5.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            for (int i = 0, loopTo1 = GridRoom.Columns.Count - 1; i <= loopTo1; i++)
                GridRoom.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            // select default room
            try
                {
                if (Room.Id > 0L)
                    {
                    for (int i = 0, loopTo2 = GridRoom.Rows.Count - 1; i <= loopTo2; i++)
                        {
                        if (Convert.ToInt32 (GridRoom [0, i].Value.ToString ()) == Room.Id)
                            GridRoom.CurrentCell = GridRoom.Rows [i].Cells [1];
                        }
                    RoomCellSelected ();
                    }
                else
                    {
                    //GridRoom.CurrentCell = GridRoom.Rows(0).Cells(1)
                    GridRoom.ClearSelection ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }

        //GridRoom
        private void GridRoom_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridRoom.RowCount < 1)
                return;
            int r = GridRoom.CurrentCell.RowIndex;   //count from 0
            if (r < 0)
                return;
            GridRoom.CurrentCell = GridRoom [1, r];

            string strClassName = Convert.ToString (GridRoom.Rows [r].Cells [1].Value);
            NxDb.DS.Tables ["tblRooms"].Rows [r] [1] = strClassName;
            //
            int intCapa = Convert.ToInt32 (GridRoom.Rows [r].Cells [2].Value);
            NxDb.DS.Tables ["tblRooms"].Rows [r] [2] = intCapa;
            //
            int boolAV = Convert.ToInt32 (GridRoom.Rows [r].Cells [3].Value);
            NxDb.DS.Tables ["tblRooms"].Rows [r] [3] = boolAV;
            //
            bool boolActive = Convert.ToBoolean (GridRoom.Rows [r].Cells [4].Value);
            int Owner = Convert.ToInt32 (GridRoom.Rows [r].Cells [5].Value);
            NxDb.DS.Tables ["tblRooms"].Rows [r] [4] = boolActive;
            //
            int boolRestricted2Owner = Convert.ToInt32 (GridRoom.Rows [r].Cells [6].Value);
            NxDb.DS.Tables ["tblRooms"].Rows [r] [5] = boolRestricted2Owner;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "UPDATE Rooms SET RoomName = @roomname, RoomCapacity = @roomcapacity, VideoProjector = @videoprojector, Active = @active, Owner_ID = @own, Restricted2Owner = @restricted2owner WHERE ID = @ID";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@roomname", strClassName.ToString ());
                    cmd.Parameters.AddWithValue ("@roomcapacity", intCapa);
                    cmd.Parameters.AddWithValue ("@videoprojector", boolAV);
                    cmd.Parameters.AddWithValue ("@active", boolActive);
                    cmd.Parameters.AddWithValue ("@own", Owner);
                    cmd.Parameters.AddWithValue ("@restricted2owner", boolRestricted2Owner);
                    cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblRooms"].Rows [r] [0].ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GridRoom_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            int r = GridRoom.CurrentCell.RowIndex;   //count from 0
            if (r < 0)
                return;
            if ((Convert.ToBoolean (GridRoom [6, r].Value.ToString ()) == true) & (User.Type == "UserDepartment"))
                {
                lblInfo.Text = "اين کلاس/آز در حال حاضر براي شما قابل دسترس نيست. براي اطلاعات بيشتر با آموزش دانشکده تماس بگيريد";
                return;
                }
            try
                {
                if (e.ColumnIndex == 4) // toggle Active_Room
                    {
                    bool boolActx = Convert.ToBoolean (GridRoom.Rows [r].Cells [4].Value);
                    if (boolActx == true)
                        GridRoom.Rows [r].Cells [4].Value = false;
                    else
                        GridRoom.Rows [r].Cells [4].Value = true;
                    return;
                    }
                else if (e.ColumnIndex == 5) //owner
                    {
                    Menu_Edit_Click (sender, e);
                    return;
                    }
                else if (e.ColumnIndex == 6) //restricted2owner
                    {
                    bool boolRetricted = Convert.ToBoolean (GridRoom.Rows [r].Cells [6].Value);
                    if (boolRetricted == true)
                        GridRoom.Rows [r].Cells [6].Value = false;
                    else
                        GridRoom.Rows [r].Cells [6].Value = true;
                    return;
                    }
                else
                    {
                    MenuOK_Click (sender, e);
                    return;
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GridRoom_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            RoomCellSelected ();
            }
        private void GridRoom_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13:
                        {
                        RoomCellSelected ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 27:
                        {
                        MenuCancel_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void RoomCellSelected ()
            {
            try
                {
                int ri = GridRoom.CurrentRow.Index;
                Room.Id = Convert.ToInt64 (GridRoom [0, ri].Value);
                if (Convert.ToBoolean (GridRoom [6, ri].Value.ToString ()) == true)
                    {
                    //Grid5.Visible = false;
                    //MessageBox.Show ("this class is restricted to its owner");
                    //return;
                    }
                Grid5.Visible = true;
                Grid5.Focus ();
                lblInfo.Visible = true;
                lblInfo.Text = "info";
                for (int c = 1; c <= 8; c++)
                    {
                    for (int r = 0; r <= 5; r++)
                        {
                        Grid5 [c, r].Value = "";
                        Grid5 [c, r].Style.ForeColor = Color.Black;
                        Grid5 [c, r].Style.BackColor = Color.White;
                        }
                    }
                NxDb.DS.Tables ["tblAllProgs"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Term_ID = " + Term.Id.ToString () + ") AND ((Room1 = " + Room.Id.ToString () + ") OR (Room2 = " + Room.Id.ToString () + "))", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblAllProgs");
                    CnnSS.Close ();
                    }
                //clear data in intTimeFlag (r:6days, c:8times --begins from 0)
                Array.Clear (TermProg.TimeFlag, 0, TermProg.TimeFlag.Length);
                for (int intTime = 0; intTime <= 7; intTime++) //for each time of day
                    {
                    for (int intDay = 0; intDay <= 5; intDay++)
                        {
                        for (int intThisRoom = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; intThisRoom <= loopTo; intThisRoom++)
                            {
                            if ((((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [intDay + 10]) & (int) (Math.Pow (2d, intTime))) == (int) (Math.Pow (2d, intTime)))) & (Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [16]) == Room.Id))
                                {
                                TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                Grid5 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                }
                            if ((((Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [intDay + 18]) & (int) (Math.Pow (2d, intTime))) == (int) (Math.Pow (2d, intTime)))) & (Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [intThisRoom] [24]) == Room.Id))
                                {
                                TermProg.TimeFlag [intDay, intTime] = TermProg.TimeFlag [intDay, intTime] + 1;
                                Grid5 [intTime + 1, intDay].Value = TermProg.TimeFlag [intDay, intTime];
                                }
                            }
                        }
                    }
                // color conflicts in red
                for (int c = 0; c <= 7; c++)
                    {
                    for (int r = 0; r <= 5; r++)
                        {
                        if (Convert.ToInt32 (Grid5 [c + 1, r].Value) > 1d)
                            Grid5 [c + 1, r].Style.ForeColor = Color.Red;
                        }
                    }
                }
            catch (Exception ex)
                {
                }
            HilightGrid5 ();
            }
        private void HilightGrid5 ()
            {
            try
                {
                for (int intTime = 0; intTime <= 7; intTime++)
                    {
                    for (int intday = 0; intday <= 5; intday++)
                        {
                        Grid5 [intTime + 1, intday].Style.BackColor = Color.White;
                        switch (TermProg.Roomx)
                            {
                            case 1:
                                    {
                                    if (((Convert.ToInt32 (NxDb.DS.Tables ["tblTermProgs"].Rows [TermProg.GridRowId] [intday + 10].ToString ())) & (int) Math.Pow (2d, intTime)) == (int) Math.Pow (2d, intTime))
                                        Grid5 [intTime + 1, intday].Style.BackColor = Color.Khaki;
                                    break;
                                    }
                            case 2:
                                    {
                                    if (((Convert.ToInt32 (NxDb.DS.Tables ["tblTermProgs"].Rows [TermProg.GridRowId] [intday + 18].ToString ())) & (int) Math.Pow (2d, intTime)) == (int) Math.Pow (2d, intTime))
                                        Grid5 [intTime + 1, intday].Style.BackColor = Color.Khaki;
                                    break;
                                    }
                            }
                        }
                    }
                Grid5.CurrentCell = GridTime [0, 0];
                }
            catch
                {
                }
            }

        //Menu - GridRoom
        private void MenuAddNewClass_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            string strClassName = Strings.Trim (Interaction.InputBox ("نام کلاس/ ازمايشگاه را وارد کنيد", "NexTerm", " کلاس/آز جديد "));
            if (string.IsNullOrEmpty (strClassName))
                return;
            int intCapa = 0;
            int boolAV = Conversions.ToInteger (false);
            bool boolActive = true;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "INSERT INTO Rooms (RoomName, RoomCapacity, VideoProjector, Active) VALUES (@roomname, @roomcapacity, @videoprojector, @active)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@roomname", strClassName.ToString ());
                    cmd.Parameters.AddWithValue ("@roomcapacity", intCapa);
                    cmd.Parameters.AddWithValue ("@videoprojector", boolAV);
                    cmd.Parameters.AddWithValue ("@active", boolActive);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            ShowClasses ();
            NxDb.LOG ("clss+");
            }
        private void Menu_Edit_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridRoom.RowCount < 1)
                return;
            int r = GridRoom.SelectedCells [0].RowIndex;    // count from 0
            int c = GridRoom.SelectedCells [0].ColumnIndex; // count from 0
            if (r < 0 | c < 1 | c > 6)
                return;
            string strValue = Conversions.ToString (GridRoom [c, r].Value);
            try
                {
                //MessageBox.Show ("col: " + c.ToString());
                switch (c)
                    {
                    case 1: //roomName
                            {
                            strValue = Interaction.InputBox ("نام کلاس/آز را وارد کنيد", "مشخصات کلاس", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            GridRoom [c, r].Value = strValue;
                            NxDb.LOG ("clss?");
                            break;
                            }
                    case 2: //capa
                            {
                            strValue = Interaction.InputBox ("ظرفيت را وارد کنيد", "مشخصات کلاس", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            GridRoom [c, r].Value = Conversion.Val (strValue);
                            NxDb.LOG ("clss.capa?");
                            break;
                            }
                    case 3: //AV
                            {
                            if (Convert.ToBoolean (GridRoom [c, r].Value) == true)
                                GridRoom [c, r].Value = false;
                            else
                                GridRoom [c, r].Value = true;
                            NxDb.LOG ("clss.av?");
                            break;
                            }
                    case 4: //active
                            {
                            if (Convert.ToBoolean (GridRoom [c, r].Value) == true)
                                GridRoom [c, r].Value = false;
                            else
                                GridRoom [c, r].Value = true;
                            NxDb.LOG ("clss.actv?");
                            break;
                            }
                    case 5: //ownerID
                            {
                            My.MyProject.Forms.ChooseDept.ShowDialog ();
                            GridRoom [c, r].Value = Convert.ToInt32 (Department.Id.ToString ());
                            ShowClasses ();
                            NxDb.LOG ("clss.actv?");
                            break;
                            }
                    case 6: //restricted2owner
                            {
                            if (Convert.ToBoolean (GridRoom [c, r].Value) == true)
                                GridRoom [c, r].Value = false;
                            else
                                GridRoom [c, r].Value = true;
                            NxDb.LOG ("clss.actv?");
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }

        //Grid5
        private void Grid5_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if (GridRoom.CurrentRow.Index < 0)
                    return;
                // strEntry = ? strTerm  = ?
                int r = 0;
                int c = 0;
                r = (int) Grid5.SelectedCells [0].RowIndex;    // count from 0
                c = (int) Grid5.SelectedCells [0].ColumnIndex; // count from 0
                if (r < 0 | c < 1)
                    return;
                // Show conflicts info
                string strTadakholMessage = "";
                for (int i = 0, loopTo = NxDb.DS.Tables ["tblAllProgs"].Rows.Count - 1; i <= loopTo; i++)
                    {
                    if ((((Convert.ToByte (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 10].ToString ())) & (Convert.ToByte (Math.Pow (2d, c - 1)))) == ((int) (Math.Pow (2d, c - 1))) & (Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [16].ToString ()) == Room.Id)))
                        {
                        strTadakholMessage = strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3].ToString () + "    استاد: " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7] + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29] + "\n\n";
                        }
                    if ((((Convert.ToByte (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [r + 18].ToString ())) & (Convert.ToByte (Math.Pow (2d, c - 1)))) == ((int) (Math.Pow (2d, c - 1))) & (Convert.ToInt32 (NxDb.DS.Tables ["tblAllProgs"].Rows [i] [24].ToString ()) == Room.Id)))
                        {
                        strTadakholMessage = strTadakholMessage + " درس " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [3].ToString () + "    استاد: " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [7] + "\n ورودي " + NxDb.DS.Tables ["tblAllProgs"].Rows [i] [29] + "\n\n";
                        }
                    }
                lblInfo.Text = strTadakholMessage;
                Grid5 [0, r].Selected = true;
                // hilight
                if (Grid5 [c, r].Value.ToString () != "")
                    {
                    return;
                    }
                else
                    {
                    if ((User.ACCs & 0x10) == 0)
                        return;
                        {
                        var withBlock = Grid5 [c, r].Style;
                        if (withBlock.BackColor == Color.Khaki)
                            withBlock.BackColor = Color.White;
                        else
                            withBlock.BackColor = Color.Khaki;
                        }
                    Grid5 [0, r].Selected = true;
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Grid5_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13:
                        {
                        MenuOK_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 27:
                        {
                        MenuCancel_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 32:
                        {
                        Grid5_CellClick (sender, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void Grid5_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            int r = 0;
            int c = 0;
            r = (int) Math.Round (Conversion.Val (Grid5.CurrentCell.RowIndex));    // count from 0
            c = (int) Math.Round (Conversion.Val (Grid5.CurrentCell.ColumnIndex)); // count from 0
            if (r < 0 | c < 1)
                return;
            // hilight
            if ((User.ACCs & 0x10) == 0)
                return;
                {
                var withBlock = Grid5 [c, r].Style;
                if (withBlock.BackColor == Color.Khaki)
                    withBlock.BackColor = Color.White;
                else
                    withBlock.BackColor = Color.Khaki;
                }
            Grid5 [0, r].Selected = true;
            }

        //Menu - Grid5
        private void lblOK_Click (object sender, EventArgs e)
            {
            MenuOK_Click (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            MenuCancel_Click(null, null);
            }
        private void MenuOK_Click (object sender, EventArgs e)
            {
            if (GridRoom.RowCount < 1)
                return;
            int r = GridRoom.CurrentRow.Index;
            Room.Name = Conversions.ToString (NxDb.DS.Tables ["tblRooms"].Rows [r] [1]);
            Room.Id = Conversions.ToLong (NxDb.DS.Tables ["tblRooms"].Rows [r] [0]);
            SetTiming ();
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            Room.Name = "";
            Room.Id = 0L;
            Dispose ();
            }
        private void SetTiming ()
            {
            int r = GridRoom.CurrentCell.RowIndex;   //count from 0
            if (r < 0)
                return;
            int Owner = Convert.ToInt32 (GridRoom.Rows [r].Cells [5].Value);
            if (((User.ACCs & 0x40) == 0x40) & (User.Id != Owner))
                {
                lblInfo.Text = "اين کلاس به گروه شما تخصيص داده نشده است";
                return;
                }

            int intDay, intTime;
            switch (TermProg.Roomx)
                {
                case 1: // class1
                        {
                        for (intDay = 0; intDay <= 5; intDay++)
                            {
                            TermProg.Class1DayData [intDay] = 0; // reset and then refill
                            for (intTime = 1; intTime <= 8; intTime++)
                                {
                                if (Grid5 [intTime, intDay].Style.BackColor == Color.Khaki)
                                    TermProg.Class1DayData [intDay] = (int) ((long) TermProg.Class1DayData [intDay] | (long) Math.Round (Math.Pow (2d, intTime - 1)));
                                }
                            NxDb.DS.Tables ["tblTermProgs"].Rows [TermProg.GridRowId] [intDay + 10] = Conversion.Val (TermProg.Class1DayData [intDay]);
                            }

                        break;
                        }
                case 2: // class2
                        {
                        for (intDay = 0; intDay <= 5; intDay++)
                            {
                            TermProg.Class2DayData [intDay] = 0; // reset and then refill
                            for (intTime = 1; intTime <= 8; intTime++)
                                {
                                if (Grid5 [intTime, intDay].Style.BackColor == Color.Khaki)
                                    TermProg.Class2DayData [intDay] = (int) ((long) TermProg.Class2DayData [intDay] | (long) Math.Round (Math.Pow (2d, intTime - 1)));
                                }
                            NxDb.DS.Tables ["tblTermProgs"].Rows [TermProg.GridRowId] [intDay + 18] = Conversion.Val (TermProg.Class2DayData [intDay]);
                            }

                        break;
                        }
                }
            Dispose ();
            }

        }
    }