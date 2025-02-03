using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {

    public partial class ChooseStaff
        {
        public ChooseStaff ()
            {
            InitializeComponent ();
            }
        private void ChooseStaff_Load (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                {
                MenuAddNew.Enabled = false;
                Menu_DelStaff.Enabled = false;
                MenuEdit.Enabled = false;
                }

            ListDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            ListDepts.DisplayMember = "DEPT";
            ListDepts.ValueMember = "ID";
            ListDepts.SelectedValue = Department.Id;
            ListDepts_Click (sender, e);
            }
        private void ListDepts_Click (object sender, EventArgs e)
            {
            try
                {
                // ComboDept -> Populates ListStaff
                string i = ListDepts.GetItemText (ListDepts.SelectedValue);
                if (Conversion.Val (i) == 0d)
                    return;
                if ((User.ACCs & 0x2) == 0x2)
                    MenuEdit.Enabled = true;
                else
                    MenuEdit.Enabled = false;
                // READ FROM DATABASE
                NxDb.DS.Tables ["tblStaff"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" + i.ToString () + " ORDER BY StaffName", CnnSS);
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
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void ListDepts_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                        {
                        ListDepts_Click (sender, e);
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
                        ListStaff.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void ListStaff_DoubleClick (object sender, EventArgs e)
            {
            MenuOK_Click (sender, e);
            }
        private void ListStaff_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                        {
                        ListStaff_DoubleClick (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }

                case 27: // escape
                        {
                        MenuCancel_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 39: //right
                        {
                        ListDepts.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }

        //MENUs
        private void MenuOK_Click (object sender, EventArgs e)
            {
            Staff.Name = ListStaff.Text;
            Staff.Id = Conversions.ToLong (ListStaff.SelectedValue);
            Dispose ();
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            Staff.Name = "";
            Staff.Id = 0L;
            Dispose ();
            }
        private void MenuAddNew_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (ListDepts.SelectedIndex == -1)
                return;
            DialogResult myansw = MessageBox.Show ("استاد جديد به اين گروه افزوده شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.Yes)
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
                        NxDb.strSQL = "INSERT INTO Staff (StaffName, StaffCode, Affiliation, Notes) VALUES (@staffname, 0, @affiliation, '-')";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@staffname", Staff.Name);
                        cmd.Parameters.AddWithValue ("@affiliation", ListDepts.SelectedValue);
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ListStaff.Refresh ();
                    ListDepts_Click (sender, e);
                    }
                }
            }
        private void MenuEdit_Click (object sender, EventArgs e)
            {
            // Edit
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            DialogResult myansw = MessageBox.Show ("نام استاد ويرايش شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            Staff.Name = ListStaff.Text;
            int r = Conversions.ToInteger (ListStaff.SelectedValue);
            if (myansw == DialogResult.Yes)
                {
                Staff.Name = Interaction.InputBox ("نام استاد را تصحيح کنيد", "NexTerm", Staff.Name);
                if (string.IsNullOrEmpty (Staff.Name))
                    {
                    return;
                    }
                else
                    {
                    NxDb.DS.Tables ["tblStaff"].Rows [ListStaff.SelectedIndex] [1] = Staff.Name;
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "UPDATE Staff SET StaffName = @staffname WHERE ID = @id";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@staffname", Staff.Name);
                        cmd.Parameters.AddWithValue ("@id", r.ToString ());
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ListDepts_Click (sender, e);
                    }
                }
            }
        private void Menu_DelStaff_Click (object sender, EventArgs e)
            {
            MessageBox.Show ("اين ويژگي براي همه کاربران غير فعال است", "نکسترم", MessageBoxButtons.OK);
            }

        private void lblOK_Click (object sender, EventArgs e)
            {
            }

        private void lblCancel_Click (object sender, EventArgs e)
            {
            MenuCancel_Click (null, null);
            }

        private void btnSave_Click (object sender, EventArgs e)
            {
            MenuOK_Click (null, null);
            }
        }
    }