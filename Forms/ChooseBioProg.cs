using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseBioProg
        {
        public ChooseBioProg ()
            {
            InitializeComponent ();
            }
        private void ChooseBioProg_Load (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                {
                MenuEditThisProg.Enabled = false;
                MenuAddNewProg.Enabled = false;
                }

            // Fill ComboBox (Depts)
            ListDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            ListDepts.DisplayMember = "DEPT";
            ListDepts.ValueMember = "ID";
            ListDepts.SelectedValue = Department.Id;

            }
        private void ListDepts_SelectedIndexChanged (object sender, EventArgs e)
            {
            // ListDepts -> Populates ListStaff
            NxDb.DS.Tables ["tblBioProgs"].Clear ();
            string i = ListDepts.GetItemText (ListDepts.SelectedValue);
            if (Conversion.Val (i) == 0d)
                return;
            if ((User.Type == "UserDepartment") & (Convert.ToInt32 (ListDepts.SelectedValue) != User.Id))
                return;

            // READ FROM DATABASE
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                CnnSS.Open ();
                NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT BioProgs.ID, ProgramName, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" + i.ToString () + " ORDER BY ProgramName", CnnSS);
                NxDb.DASS.Fill (NxDb.DS, "tblBioProgs");
                CnnSS.Close ();
                }
            ListBioProg.DataSource = NxDb.DS.Tables ["tblBioProgs"];
            ListBioProg.DisplayMember = "ProgramName";
            ListBioProg.ValueMember = "ID";
            ListBioProg.Refresh ();
            ListBioProg.SelectedIndex = -1;
            ListBioProg.SelectedValue = 0;
            }
        private void ListBioProg_DoubleClick (object sender, EventArgs e)
            {
            MenuOK_Click (sender, e);
            }
        private void MenuEditThisProg_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
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
                    cmd.Parameters.AddWithValue ("@programname", Prog.Name);
                    cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblBioProgs"].Rows [r] [0]);
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            ListDepts_SelectedIndexChanged (sender, e);
            }
        private void MenuAddNewProg_Click (object sender, EventArgs e)
            {
            if (User.Type == "UserDepartment")
                return;
            if ((User.ACCs & 0x10) == 0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (ListDepts.SelectedIndex == -1)
                return;
            DialogResult myansw = MessageBox.Show ("دوره آموزشي جديد به اين گروه افزوده شود؟", "نکسترم", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
            if (myansw == DialogResult.Yes)
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
                        cmd.Parameters.AddWithValue ("@programname", Prog.Name);
                        cmd.Parameters.AddWithValue ("@departmentid", ListDepts.SelectedValue);
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    ListBioProg.Refresh ();
                    }
                }
            ListDepts_SelectedIndexChanged (sender, e);

            }
        private void btnOK_Click (object sender, EventArgs e)
            {
            MenuOK_Click (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            MenuCancel_Click (null, null);
            }
        private void MenuOK_Click (object sender, EventArgs e)
            {
            // BioProg
            if (ListBioProg.SelectedIndex == -1)
                return;
            Prog.Name = ListBioProg.Text;
            Prog.Id = Conversions.ToLong (ListBioProg.SelectedValue);
            // Department
            Department.Name = ListDepts.Text;
            Department.Id = Conversions.ToLong (ListDepts.SelectedValue);
            Dispose ();
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            Prog.Name = "";
            Prog.Id = 0L;
            Dispose ();
            }

        }
    }