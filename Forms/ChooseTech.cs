using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseTech
        {
        public ChooseTech ()
            {
            InitializeComponent ();
            }
        private void ChooseTech_Load (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                {
                MenuAddNew.Enabled = false;
                MenuEdit.Enabled = false;
                }
            // READ FROM DATABASE
            NxDb.DS.Tables ["tblTechs"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, StaffName FROM Technecians ORDER BY StaffName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblTechs");
                CnnSS.Close ();
                }
            ListTechs.DataSource = NxDb.DS.Tables ["tblTechs"];
            ListTechs.DisplayMember = "StaffName";
            ListTechs.ValueMember = "ID";
            ListTechs.Refresh ();
            ListTechs.SelectedIndex = -1;
            ListTechs.SelectedValue = 0;
            }
        private void ListTechs_DoubleClick (object sender, EventArgs e)
            {
            MenuOK_Click (sender, e);
            }
        private void ListTechs_KeyDown (object sender, KeyEventArgs e)
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
            Tech.Name = ListTechs.Text;
            Tech.Id = Conversions.ToLong (ListTechs.SelectedValue);
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
            DialogResult myansw = (DialogResult) MessageBox.Show ("کارشناس جديد افزوده شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.Yes)
                {
                Tech.Name = Interaction.InputBox ("نام کارشناس را وارد کنيد", "NexTerm", " کارشناس جديد " + ListTechs.Text);
                if (string.IsNullOrEmpty (Tech.Name))
                    {
                    return;
                    }
                else
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "INSERT INTO Technecians (StaffName, TechCode) VALUES (@staffname, 0)";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@staffname", Tech.Name);
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ChooseTech_Load (sender, e);
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
            DialogResult myansw = (DialogResult) MessageBox.Show ("نام کارشناس ويرايش شود؟", "NexTerm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            Tech.Name = ListTechs.Text;
            int r = Conversions.ToInteger (ListTechs.SelectedValue);
            if (myansw == DialogResult.Yes)
                {
                Staff.Name = Interaction.InputBox ("نام کارشناس را تصحيح کنيد", "NexTerm", Tech.Name);
                if (string.IsNullOrEmpty (Strings.Trim (Tech.Name)))
                    {
                    return;
                    }
                else
                    {
                    NxDb.DS.Tables ["tblTechs"].Rows [ListTechs.SelectedIndex] [1] = Tech.Name;
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                        {
                        NxDb.strSQL = "UPDATE Technecians SET StaffName = @staffname WHERE ID = @id";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@staffname", Staff.Name);
                        cmd.Parameters.AddWithValue ("@id", r.ToString ());
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ListTechs.Refresh ();
                    ChooseTech_Load (sender, e);
                    }
                }
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            Tech.Name = "";
            Tech.Id = 0L;
            Dispose ();
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