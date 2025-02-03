using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NexTerm
    {

    public partial class frmDepts
        {
        public frmDepts ()
            {
            InitializeComponent ();
            }
        // GRID DEPARTMENT
        private void frmShowTables_Load (object sender, EventArgs e)
            {
            Text = User.Type + "  Connected to :  " + NxDb.Server2Connect;
            NxDb.LOG ("resources");
            Show_DeptTable ();
            EnableDisableMenus ();
            }
        private void Show_DeptTable ()
            {
            Nxt.Retval1 = User.Id; // saving intUser before SQL!
            NxDb.DS.Tables ["tblDepartments"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, DepartmentName AS DEPT, DepartmentActive, Notes, DepartmentPass, acc FROM Departments ORDER BY Departments.DepartmentName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblDepartments");
                CnnSS.Close ();
                }
            Grid1.DataSource = NxDb.DS.Tables ["tblDepartments"];
            if (User.Type == "UserDeputy" & (User.ACCs & 0x10) == 0x10)
                {
                Grid1.Columns [4].Visible = true;  // Pass
                }
            else
                {
                Grid1.Columns [4].Visible = false;
                }      // Pass
            Grid1.Columns [0].Visible = false;     // ID
            Grid1.Columns [0].Width = 0;           // ID
            Grid1.Columns [1].Width = 250;         // DepartmentName
            Grid1.Columns [2].Width = 45;          // Active
            Grid1.Columns [3].Visible = false;     // Notes
            Grid1.Columns [4].Width = 95;          // Pass
            Grid1.Columns [5].Visible = false;     // Access-1-7
            //disable sort
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++)
                Grid1.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            // restoring back intUser!
            User.Id = Nxt.Retval1;
            ShowProgsAndStaff ();
            }
        private void EnableDisableMenus ()
            {
            try
                {
                bool boolENBL;
                // A: strictly for each user
                switch (User.Type ?? "")
                    {
                    case "UserDeputy":
                    case "UserOfficer":
                            {
                            if ((User.ACCs & 0x10) == 0x10)
                                boolENBL = true;
                            else
                                boolENBL = false;
                            Menu_ChangePassDept.Enabled = boolENBL;
                            Menu_AddStaff.Enabled = boolENBL;
                            Menu_EditStaff.Enabled = boolENBL;
                            Menu_AddEntry.Enabled = boolENBL;
                            Menu_EditEntry.Enabled = boolENBL;
                            Menu_AddDept.Enabled = boolENBL;
                            Menu_EditDept.Enabled = boolENBL;
                            Menu_AddBioProg.Enabled = boolENBL;
                            Menu_EditBioProg.Enabled = boolENBL;
                            Menu_ProgramSpecs.Enabled = boolENBL;
                            Menu_AddCourse.Enabled = boolENBL;
                            Menu_EditCourseNumber.Enabled = boolENBL;
                            Menu_EditCourseSpecs.Enabled = boolENBL;
                            Menu_ExportCourseList.Enabled = boolENBL;
                            if ((User.ACCs & 0x10) == 0x10)
                                {
                                Menu_AddCourseFromList.Enabled = true;
                                }
                            else
                                {
                                Menu_AddCourseFromList.Enabled = false;
                                }

                            break;
                            }
                    case "UserDepartment": // Userx: Department | quit
                            {
                            Menu_AddDept.Enabled = false;
                            Menu_EditDept.Enabled = false;
                            Menu_AddBioProg.Enabled = false;
                            Menu_EditBioProg.Enabled = false;
                            Menu_EditCourseNumber.Enabled = true;
                            if ((User.ACCs & 0x10) == 0x10)
                                {
                                // acc1: Courses
                                if ((User.ACCs & 0x1) == 0x0)
                                    {
                                    Menu_AddEntry.Enabled = false;
                                    Menu_AddCourse.Enabled = false;
                                    Menu_EditEntry.Enabled = false;
                                    Menu_AddCourseFromList.Enabled = false;
                                    Menu_ProgramSpecs.Enabled = false;
                                    Menu_EditCourseSpecs.Enabled = false;
                                    }
                                else
                                    {
                                    Menu_AddEntry.Enabled = true;
                                    Menu_AddCourse.Enabled = true;
                                    Menu_EditEntry.Enabled = true;
                                    Menu_AddCourseFromList.Enabled = true;
                                    Menu_ProgramSpecs.Enabled = true;
                                    Menu_EditCourseSpecs.Enabled = true;
                                    }
                                // acc2: staff
                                if ((User.ACCs & 0x2) == 0x0)
                                    Menu_EditStaff.Enabled = false;
                                else
                                    Menu_EditStaff.Enabled = true;
                                if ((User.ACCs & 0x2) == 0x0)
                                    Menu_AddStaff.Enabled = false;
                                else
                                    Menu_AddStaff.Enabled = true;
                                // acc5: pass
                                if ((User.ACCs & 0x10) == 0x0)
                                    Menu_ChangePassDept.Enabled = false;
                                else
                                    Menu_ChangePassDept.Enabled = true;
                                Menu_ExportCourseList.Enabled = true;
                                }
                            else
                                {
                                // acc1: Courses
                                Menu_EditEntry.Enabled = false;
                                Menu_AddEntry.Enabled = false;
                                Menu_AddCourse.Enabled = false;
                                Menu_ExportCourseList.Enabled = false;
                                Menu_AddCourseFromList.Enabled = false;
                                // acc2: staff
                                Menu_EditStaff.Enabled = false;
                                Menu_AddStaff.Enabled = false;
                                // acc5: pass
                                Menu_ChangePassDept.Enabled = false;
                                }

                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString (), "گزارش خطا در اجراي نکسترم", MessageBoxButtons.OK);
                }
            }
        private void Grid1_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            ShowProgsAndStaff ();
            }
        private void ShowProgsAndStaff ()
            {
            int r = 0;
            try
                {
                r = Grid1.CurrentCell.RowIndex;
                if (r < 0)
                    return;
                }
            catch
                {
                return;
                }
            //Clear all
            NxDb.DS.Tables ["tblBioProgs"].Clear ();
            NxDb.DS.Tables ["tblStaff"].Clear ();
            NxDb.DS.Tables ["tblEntries"].Clear ();
            NxDb.DS.Tables ["tblCourses"].Clear ();

            Department.Id = Conversions.ToLong (Grid1 [0, r].Value);
            if ((User.Type == "UserDepartment") & (Department.Id != User.Id))
                return;

            //Feed Prog list
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT BioProgs.ID, ProgramName, ProgramSpecs, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" + Department.Id.ToString () + " ORDER BY ProgramName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblBioProgs");
                CnnSS.Close ();
                }
            ListBioProg.DataSource = NxDb.DS.Tables ["tblBioProgs"];
            ListBioProg.DisplayMember = "ProgramName";
            ListBioProg.ValueMember = "ID";
            ListBioProg.Refresh ();
            ListBioProg.SelectedIndex = -1;
            ListBioProg.SelectedValue = 0;

            //Feed Staff list
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" + Department.Id.ToString () + " ORDER BY StaffName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblStaff");
                CnnSS.Close ();
                }
            ListStaff.DataSource = NxDb.DS.Tables ["tblStaff"];
            ListStaff.DisplayMember = "StaffName";
            ListStaff.ValueMember = "ID";
            ListStaff.Refresh ();
            ListStaff.SelectedIndex = -1;
            ListStaff.SelectedValue = 0;

            }
        private void Grid1_KeyDown (object sender, KeyEventArgs e)
            {
            if (((int) e.KeyCode == 13) & (User.Type == "UserDeputy"))
                {
                EditDepartment ();
                e.SuppressKeyPress = true;
                }
            else if ((((int) e.KeyCode == 37) | ((int) e.KeyCode == 13)) & (User.Type == "UserDepartment"))
                {
                Grid1_CellClick (null, null);
                e.SuppressKeyPress = true;
                }
            else if ((int) e.KeyCode == 27)
                {
                Menu_CancelDept_Click (null, null);
                e.SuppressKeyPress = true;
                }
            }
        private void Grid1_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            EditDepartment ();
            }
        private void Menu_AddDept_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (User.Type != "UserDeputy")
                {
                MessageBox.Show ("Changes discarded", "کاربر : گروه آموزشي", MessageBoxButtons.OK);
                return;
                }
            DialogResult myansw = (DialogResult) MessageBox.Show ("يک گروه آموزشي جديد افزوده شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                return;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "INSERT INTO Departments (DepartmentName, Notes) VALUES ('گروه آموزشي جديد', '-')";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            Grid1.Refresh ();
            Show_DeptTable ();
            }
        private void Menu_EditDept_Click (object sender, EventArgs e)
            {
            EditDepartment ();
            }
        private void EditDepartment ()
            {
            if (Grid1.RowCount < 1)
                return;
            int r = Grid1.CurrentCell.RowIndex;
            if (r < 0)
                {
                return;
                }
            else
                {
                if (User.Type != "UserDeputy")
                    return;
                if ((User.ACCs & 0x10) == 0x0)
                    {
                    MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    }
                else
                    {
                    Department.Id = Conversions.ToLong (NxDb.DS.Tables ["tblDepartments"].Rows [r] [0]);
                    Nxt.Retval1 = r;
                    My.MyProject.Forms.frmDeptEdit.ShowDialog ();
                    /*
                      Show_DeptTable ();
                      Clear all
                      NxDb.DS.Tables ["tblBioProgs"].Clear ();
                      NxDb.DS.Tables ["tblStaff"].Clear ();
                      NxDb.DS.Tables ["tblEntries"].Clear ();
                      NxDb.DS.Tables ["tblCourses"].Clear ();
                    */
                    }
                }
            Show_DeptTable ();
            }
        private void Menu_ChangePassDept_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0) //0x10 = 16 = 0001'0000 (fifth item in ACCs)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            try
                {
                int r = Grid1.CurrentCell.RowIndex;
                if (r < 0)
                    {
                    MessageBox.Show ("select a row!", "NexTerm", MessageBoxButtons.OK);
                    return;
                    }
                if (Conversions.ToBoolean (Operators.OrObject (Operators.ConditionalCompareObjectEqual (Grid1 [0, Grid1.CurrentCell.RowIndex].Value, User.Id, false), User.Id == 0)))
                    {
                    string strOldPass = Grid1 [4, r].Value.ToString ();
                    string strNewPass = Interaction.InputBox ("کلمه عبور جديد را وارد کنيد", "تغيير کلمه عبور", strOldPass);
                    if (string.IsNullOrEmpty (Strings.Trim (strNewPass)))
                        {
                        MessageBox.Show ("انصراف توسط کاربر", "نکسترم", MessageBoxButtons.OK);
                        return;
                        }
                    strOldPass = Interaction.InputBox ("کلمه عبور جديد را (مجددا) وارد کنيد", "تغيير کلمه عبور", "****");
                    if ((strOldPass) != (strNewPass))
                        {
                        MessageBox.Show ("تکرار کلمه عبور نادرست بود", "تغيير کلمه عبور انجام نشد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    User.DepartmentPass = strNewPass;
                    Grid1 [4, r].Value = strNewPass;
                    NxDb.DS.Tables ["tblDepartments"].Rows [r] [4] = strNewPass;
                    MessageBox.Show ("Password changed to :   " + strNewPass, "NexTerm", MessageBoxButtons.OK);

                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "UPDATE Departments SET DepartmentPass = @pass WHERE ID = @id";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@pass", strNewPass);
                        cmd.Parameters.AddWithValue ("@id", Department.Id.ToString ());
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                else
                    {
                    MessageBox.Show ("نمي توانيد کلمه عبور ساير گروه ها را تغيير دهيد", "نکسترم", MessageBoxButtons.OK);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }

            }
        private void Menu_GuideDept_Click (object sender, EventArgs e)
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
        private void Menu_CancelDept_Click (object sender, EventArgs e)
            {
            Dispose ();
            My.MyProject.Forms.frmTermProgs.ShowDialog ();
            }
        // STAFF
        private void Menu_AddStaff_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (Grid1.CurrentCell.RowIndex < 0)
                return;
            DialogResult myansw = (DialogResult) MessageBox.Show ("استاد جديد به اين گروه افزوده شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if ((int) myansw == (int) DialogResult.Yes)
                {
                Staff.Name = Interaction.InputBox ("نام استاد را وارد کنيد", "NexTerm", " استاد جديد ");
                if (string.IsNullOrEmpty (Strings.Trim (Staff.Name)))
                    {
                    return;
                    }
                else
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        try
                            {
                            NxDb.strSQL = "INSERT INTO Staff (StaffName, StaffCode, Affiliation, Notes) VALUES (@staffname, 0, @affiliation, '-')";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@staffname", Staff.Name).ToString ();
                            cmd.Parameters.AddWithValue ("@affiliation", Department.Id).ToString ();
                            int i = cmd.ExecuteNonQuery ();
                            ListStaff.Refresh ();
                            ShowProgsAndStaff ();
                            NxDb.LOG ("staff+; dpt:" + Department.Id.ToString ());
                            CnnSS.Close ();
                            }
                        catch (Exception ex)
                            {
                            CnnSS.Close ();
                            MessageBox.Show (ex.ToString ());
                            }
                        }
                    }
                }
            }
        private void Menu_EditStaff_Click (object sender, EventArgs e)
            {
            // Edit
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            DialogResult myansw = (DialogResult) MessageBox.Show ("نام استاد ويرايش شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            Staff.Name = ListStaff.Text;
            int r = Conversions.ToInteger (ListStaff.SelectedValue);
            if ((int) myansw == (int) DialogResult.Yes)
                {
                Staff.Name = Interaction.InputBox ("نام استاد را تصحيح کنيد", "NexTerm", Staff.Name);
                if (string.IsNullOrEmpty (Staff.Name))
                    {
                    return;
                    }
                else
                    {
                    try
                        {
                        NxDb.DS.Tables ["tblStaff"].Rows [ListStaff.SelectedIndex] [1] = Staff.Name;
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "UPDATE Staff SET StaffName = @staffname WHERE ID = @id";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@staffname", Staff.Name.ToString ());
                            cmd.Parameters.AddWithValue ("@id", r.ToString ());
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        ShowProgsAndStaff ();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                NxDb.LOG ("staff?; dpt:" + Department.Id.ToString ());
                }
            }
        private void Menu_DelStaff_Click (object sender, EventArgs e)
            {
            MessageBox.Show ("امکان حذف نام استاد اکنون وجود ندارد", "نکسترم", MessageBoxButtons.OK);
            }
        private void Menu_CancelStaff_Click (object sender, EventArgs e)
            {
            Dispose ();
            My.MyProject.Forms.frmTermProgs.ShowDialog ();
            }
        //PROGRAM
        private void Menu_AddBioProg_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (Grid1.CurrentCell.RowIndex < 0)
                return;
            DialogResult myansw = MessageBox.Show ("دوره آموزشي جديد به اين گروه افزوده شود؟", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if ((int) myansw == (int) DialogResult.Yes)
                {
                Prog.Name = Interaction.InputBox ("نام دوره را وارد کنيد", "NexTerm", " دوره جديد ");
                if (string.IsNullOrEmpty (Strings.Trim (Prog.Name)))
                    {
                    return;
                    }
                else
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "INSERT INTO BioProgs (ProgramName, Department_ID) VALUES (@programname, @departmentid)";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@programname", Prog.Name.ToString ());
                        cmd.Parameters.AddWithValue ("@departmentid", Department.Id.ToString ());
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ListBioProg.Refresh ();
                    NxDb.LOG ("prg+; prg:" + Prog.Id.ToString ());
                    }
                }
            ShowProgsAndStaff ();
            }
        private void Menu_EditBioProg_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            int r = ListBioProg.SelectedIndex;
            if (r == -1)
                return;
            Prog.Id = Conversions.ToLong (ListBioProg.SelectedValue);
            Prog.Name = ListBioProg.Text;
            Prog.Name = Interaction.InputBox ("نام دوره آموزشی", "وارد کنید", Prog.Name);
            if (string.IsNullOrEmpty (Prog.Name.Trim ()))
                {
                return;
                }
            try
                {
                NxDb.DS.Tables ["tblBioProgs"].Rows [r] [1] = Prog.Name;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "UPDATE BioProgs SET ProgramName = @programname WHERE ID = @id";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@programname", Prog.Name.ToString ());
                    cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblBioProgs"].Rows [r] [0]);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                NxDb.LOG ("prg?; prg:" + Prog.Id.ToString ());
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            ShowProgsAndStaff ();
            }
        private void Menu_ProgramSpecs_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            int r = ListBioProg.SelectedIndex;
            if (r == -1)
                return;
            Nxt.Retval1 = 1;                                                                     // {1:BioProgs | 2:Courses}
            Nxt.Retval2 = Conversions.ToInteger (NxDb.DS.Tables ["tblBioProgs"].Rows [r] [2]);   // {data : in bits}
            My.MyProject.Forms.frmSpecs.ShowDialog ();
            if (Nxt.Retval1 == 1) // retval1 {0:Cancelled , 1:OK}
                {
                NxDb.DS.Tables ["tblBioProgs"].Rows [r] [2] = Nxt.Retval2;
                try
                    {
                    NxDb.DS.Tables ["tblBioProgs"].Rows [r] [1] = Prog.Name;
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "UPDATE BioProgs SET ProgramSpecs = @programspecs WHERE ID = @id";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@programspecs", Nxt.Retval2.ToString ());
                        cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblBioProgs"].Rows [r] [0]);
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    NxDb.LOG ("prg?; prg:" + Prog.Id.ToString ());
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                ShowProgsAndStaff ();
                }
            else
                {
                return;
                }
            }
        private void Menu_CancelBioProg_Click (object sender, EventArgs e)
            {
            Dispose ();
            My.MyProject.Forms.frmTermProgs.ShowDialog ();
            }
        private void ListBioProg_Click (object sender, EventArgs e)
            {
            // populate Grid_Entry
            if (ListBioProg.SelectedIndex < 0)
                return;
            ShowEntries ();
            ShowCourses ();
            }
        private void ShowEntries ()
            {
            // populate Grid_Entry
            if (Grid1.CurrentCell.RowIndex < 0)
                return;
            string i = ListBioProg.GetItemText (ListBioProg.SelectedValue);
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
        private void ShowCourses ()
            {
            // ComboBioProg -> Populates GridCourse
            if (Grid1.CurrentCell.RowIndex < 0)
                return;
            string i = ListBioProg.GetItemText (ListBioProg.SelectedValue);
            if (Conversion.Val (i) == 0d)
                return;
            // READ FROM DATABASE
            Prog.Id = (long) Math.Round (Conversion.Val (i));
            // READ FROM DATABASE
            NxDb.DS.Tables ["tblCourses"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Courses.ID, CourseName, CourseNumber, CourseSpecs, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" + Prog.Id.ToString () + " ORDER BY CourseName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblCourses");
                CnnSS.Close ();
                }
            GridCourse.DataSource = NxDb.DS.Tables ["tblCourses"];
            GridCourse.Refresh ();
            GridCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridCourse.Columns [0].Width = 0;    // ID
            GridCourse.Columns [1].Width = 220;  // Course
            GridCourse.Columns [2].Width = 80;   // Number
            GridCourse.Columns [3].Width = 0;    // Specs
            GridCourse.Columns [4].Width = 40;   // Units
            GridCourse.Columns [0].Visible = false; // ID
            GridCourse.Columns [3].Visible = false; // Specs
            for (int k = 0, loopTo = GridCourse.Columns.Count - 1; k <= loopTo; k++)
                GridCourse.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        // ENTRY
        private void GridEntries_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type == "UserDepartment")
                {
                MessageBox.Show ("توجه: تغييرات با اکانت گروه ثبت نمي شوند", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Menu_AddEntry_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (Grid1.CurrentCell.RowIndex < 0)
                return;
            if (ListBioProg.SelectedIndex == -1)
                return;
            Prog.Id = (long) Math.Round (Conversion.Int (Conversion.Val (ListBioProg.SelectedValue)));
            int intEntYear = (int) Math.Round (Conversion.Val (Interaction.InputBox ("سال ورود به دوره آموزشي", "NexTerm", "1401")));
            if (intEntYear == 0)
                {
                MessageBox.Show ("سال معتبر نيست", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            //ADD CODES HERE TO CHECK IF EntYear IS NEW FOR THIS Entry IN THIS BioProg ----------- do it -----------
            int intStudentCount = 5;
            try
                {
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
            NxDb.LOG ("ent?; ent:" + Entry.Id.ToString ());
            }
        private void GridEntries_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            switch (User.Type ?? "")
                {
                case "UserDepartment":
                        {
                        Menu_EditEntry_Click (sender, e);
                        //Menu_OKEntry_Click(sender, e)
                        return;
                        }
                case "UserDeputy":
                case "UserOfficer":
                        {
                        if ((User.ACCs & 0x10) == 0x0)
                            {
                            MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                            }
                        Menu_EditEntry_Click (sender, e);
                        break;
                        }
                }
            }
        private void Menu_EditEntry_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (GridEntries.RowCount < 1)
                return;
            int r = GridEntries.SelectedCells [0].RowIndex;    // count from 0
            int c = GridEntries.SelectedCells [0].ColumnIndex; // count from 0
            if (r < 0 || c < 0)
                return;
            try
                {
                switch (c)
                    {
                    case 3:
                    case 4: // Yr, Cnt
                            {
                            string strValue = Conversions.ToString (GridEntries [c, r].Value);
                            strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strValue);
                            if (Conversion.Val (strValue) == 0d)
                                return;
                            GridEntries [c, r].Value = Strings.Trim (strValue);
                            NxDb.LOG ("ent.yr/cnt?; ent:" + Entry.Id.ToString ());
                            break;
                            }
                    case 5: // ACTIVE
                            {
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (GridEntries [c, r].Value, true, false)))
                                {
                                GridEntries [c, r].Value = false;
                                }
                            else
                                {
                                GridEntries [c, r].Value = true;
                                }
                            NxDb.LOG ("ent.actv?; ent:" + Entry.Id.ToString ());
                            break;
                            }
                    case 6: // Note
                            {
                            string strValue = Conversions.ToString (GridEntries [c, r].Value);
                            strValue = Interaction.InputBox ("يادداشت جديد را وارد کنيد", "نکسترم", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            GridEntries [c, r].Value = Strings.Trim (strValue);
                            NxDb.LOG ("ent.note?; ent:" + Entry.Id.ToString ());
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu_CancelEntry_Click (object sender, EventArgs e)
            {
            ListBioProg.Focus (); // to save changes
            Dispose ();
            My.MyProject.Forms.frmTermProgs.ShowDialog ();
            }
        // COURSE
        private void GridCourse_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            int r = GridCourse.SelectedCells [0].RowIndex;    // count from 0
            int c = GridCourse.SelectedCells [0].ColumnIndex; // count from 0
            if (GridCourse.RowCount < 1)
                return;
            if (r < 0 | c < 0)
                return;

            if (User.Type == "UserDepartment" & c == 1)
                {
                return;
                }
            else
                {
                string strValue = Conversions.ToString (GridCourse [c, r].Value);
                strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strValue);
                try
                    {
                    switch (c)
                        {
                        case 1: // Course Name
                                {
                                if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                    return;
                                DialogResult myansw = (DialogResult) MessageBox.Show ("نام درس را به \n" + strValue + "\nتغيير مي دهيد؟", "نکسترم: توجه: در حال ويرايش نام درس هستيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                                if (myansw == DialogResult.No)
                                    return;
                                GridCourse [c, r].Value = strValue;
                                NxDb.LOG ("crs?:" + Course.Name);
                                break;
                                }
                        case 2:
                        case 4: // Number, Unit
                                {
                                if (Conversion.Val (strValue) == 0d)
                                    return;
                                GridCourse [c, r].Value = strValue;
                                if (c == 2)
                                    {
                                    NxDb.LOG ("crs.nr?:" + Course.Number.ToString ());
                                    }
                                else if (c == 4)
                                    {
                                    NxDb.LOG ("crs.unt?:" + Course.Number.ToString ());
                                    }
                                break;
                                }
                        }
                    UpdateAfterGridCourseChanged ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        private void GridCourse_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            UpdateAfterGridCourseChanged ();
            }
        private void UpdateAfterGridCourseChanged ()
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (GridCourse.RowCount < 1)
                return;
            int r = GridCourse.CurrentCell.RowIndex;   //count from 0
            if (r < 0)
                return;
            GridCourse.CurrentCell = GridCourse [1, r];
            string strCourseName = Conversions.ToString (GridCourse.Rows [r].Cells [1].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [1] = strCourseName;
            int intCourseNumber = Conversions.ToInteger (GridCourse.Rows [r].Cells [2].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [2] = intCourseNumber;
            int intCourseSpecs = Conversions.ToInteger (GridCourse.Rows [r].Cells [3].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [3] = intCourseSpecs;
            int intCourseUnits = Conversions.ToInteger (GridCourse.Rows [r].Cells [4].Value);
            NxDb.DS.Tables ["tblCourses"].Rows [r] [4] = intCourseUnits;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Coursespecs = @coursespecs, Units = @units WHERE ID = @ID";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@coursename", strCourseName);
                cmd.Parameters.AddWithValue ("@coursenumber", intCourseNumber);
                cmd.Parameters.AddWithValue ("@coursespecs", intCourseSpecs);
                cmd.Parameters.AddWithValue ("@units", intCourseUnits);
                cmd.Parameters.AddWithValue ("@ID", NxDb.DS.Tables ["tblCourses"].Rows [r] [0].ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        private void Menu_AddCourse_Click (object sender, EventArgs e)
            {
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (ListBioProg.SelectedIndex == -1)
                return;
            DialogResult myansw = MessageBox.Show ("درس جديد به اين دوره آموزشي افزوده شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            if ((int) myansw == (int) DialogResult.Yes)
                {
                Course.Number = (long) Math.Round (Conversion.Val (Interaction.InputBox ("شماره درس", "NexTerm", "123456789")));
                Course.Name = Interaction.InputBox ("نام درس را وارد کنيد", "NexTerm", " درس جديد " + ListBioProg.Text);
                if (string.IsNullOrEmpty (Course.Name))
                    {
                    return;
                    }
                else
                    {
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                            {
                            NxDb.strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, CourseSpecs, Units) VALUES (@bioprogid, @coursename, @coursenumber, 2, 2)";
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue ("@bioprogid", ListBioProg.SelectedValue);
                            cmd.Parameters.AddWithValue ("@coursename", Course.Name);
                            cmd.Parameters.AddWithValue ("@coursenumber", Conversion.Str (Course.Number));
                            int i = cmd.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show ("error: " + ex.ToString ());
                        }
                    NxDb.LOG ("+crs:" + Course.Number.ToString ());
                    }
                ListBioProg_Click (sender, e);
                //GridCourse.Refresh()
                }
            }
        private void Menu_AddCourseFromList_Click (object sender, EventArgs e)
            {
            //import list of courses from excel
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return;
                }
            if (ListBioProg.SelectedIndex == -1)
                return;
            Prog.Id = Convert.ToInt64 (ListBioProg.SelectedValue);
            My.MyProject.Forms.TempList.ShowDialog ();
            NxDb.LOG ("+crs<-list");
            ListBioProg_Click (sender, e);
            GridCourse.Refresh ();
            }
        private void Menu_EditCourseNumber_Click (object sender, EventArgs e)
            {
            if (ListBioProg.SelectedIndex == -1)
                return;
            if (GridCourse.RowCount < 1)
                return;
            int r = GridCourse.CurrentCell.RowIndex;   // count from 0
            if (r < 0)
                return;
            Course.Name = "";
            Course.Number = 0L;
            Course.Number = (long) Math.Round (Conversion.Val (Interaction.InputBox ("شماره درس را تصحيح کنيد", "نکسترم", Conversions.ToString (GridCourse [2, r].Value))));
            if (Course.Number == 0L)
                {
                return;
                }
            else
                {
                GridCourse [2, r].Value = Course.Number;
                UpdateAfterGridCourseChanged ();
                NxDb.LOG ("crs.nr?:" + Course.Number.ToString ());
                }
            }
        private void Menu_EditCourseSpecs_Click (object sender, EventArgs e)
            {
            if (ListBioProg.SelectedIndex == -1)
                return;
            if (GridCourse.RowCount < 1)
                return;
            int r = GridCourse.CurrentCell.RowIndex;   // count from 0
            if (r < 0)
                return;
            Nxt.Retval1 = 2; // {1:Programs | 2:Courses}
            Nxt.Retval2 = Conversions.ToInteger (NxDb.DS.Tables ["tblCourses"].Rows [r] [3]);    // {data: in bits}
            My.MyProject.Forms.frmSpecs.ShowDialog ();
            /*
             * Retval2: data
             * Retval1:{OK|Cancel}
            */
            if (Nxt.Retval1 == 1)
                {
                GridCourse [3, r].Value = Nxt.Retval2.ToString ();
                NxDb.DS.Tables ["tblCourses"].Rows [r] [3] = Nxt.Retval2;
                UpdateAfterGridCourseChanged ();
                ListBioProg_Click (sender, e);
                NxDb.LOG ("crs.specs?:" + Course.Number.ToString ());
                }
            else
                {
                return;
                }
            }
        private void Menu_ExportCourseList_Click (object sender, EventArgs e)
            {
            // Export
            FileSystem.FileClose (1);
            using (var dialog = new SaveFileDialog () { InitialDirectory = Application.StartupPath, Filter = "Nexterm Course List|*.xlsx" })
                {
                if (dialog.ShowDialog () == DialogResult.OK)
                    {
                    NxDb.Filename = dialog.FileName;
                    }
                else
                    {
                    Dispose ();
                    return;
                    }
                }
            using (IXLWorkbook WB = new XLWorkbook ())
                {
                Nxt.Retval1 = 0;
                try
                    {
                    var WS0 = WB.Worksheets.Add ("NexTerm Courses");
                    WS0.Cell (1, 1).Value = "Title";
                    WS0.Cell (1, 2).Value = "Number";
                    WS0.Cell (1, 3).Value = "Units";
                    WS0.Cell (1, 4).Value = "Lab";
                    WS0.Cell (1, 5).Value = "Class";
                    WS0.Cell (1, 6).Value = "Mandatory";
                    for (int i = 0, loopTo = GridCourse.Rows.Count - 1; i <= loopTo; i++)
                        {
                        WS0.Cell (i + 2, 1).Value = GridCourse [1, i].Value.ToString (); //title
                        WS0.Cell (i + 2, 2).Value = GridCourse [2, i].Value.ToString (); //number
                        WS0.Cell (i + 2, 3).Value = GridCourse [4, i].Value.ToString (); //units: excel.col3 = grid.col4
                        WS0.Cell (i + 2, 4).Value = (Convert.ToInt32 (GridCourse [3, i].Value) & 1).ToString (); //lab
                        WS0.Cell (i + 2, 5).Value = ((Convert.ToInt32 (GridCourse [3, i].Value) & 2) / 2).ToString (); //class
                        WS0.Cell (i + 2, 6).Value = ((Convert.ToInt32 (GridCourse [3, i].Value) & 4) / 4).ToString (); //mandatory
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show ("Error in Exporting Courses" + ex.ToString ());
                    return;
                    }
                //save excel
                WB.SaveAs (NxDb.Filename);
                NxDb.LOG ("crs->export");
                MessageBox.Show ("ليست درس در فولدر برنامه ذخيره شد\n\n" + NxDb.Filename, "نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                Nxt.Retval1 = 1;
                }
            }
        private void Menu_CancelCourse_Click (object sender, EventArgs e)
            {
            Dispose ();
            My.MyProject.Forms.frmTermProgs.ShowDialog ();
            }

        private void lblCancel_Click (object sender, EventArgs e)
            {
            Dispose ();
            My.MyProject.Forms.frmTermProgs.ShowDialog ();
            }
        }
    }