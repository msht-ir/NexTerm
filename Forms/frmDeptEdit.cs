using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {

    public partial class frmDeptEdit
        {
        private int r = Nxt.Retval1;

        public frmDeptEdit ()
            {
            InitializeComponent ();
            }
        private void frmDeptEdit_Load (object sender, EventArgs e)
            {
            txtDeptName.Text = Conversions.ToString (NxDb.DS.Tables ["tblDepartments"].Rows [r] [1]);         // strDept
            CheckDeptActive.Checked = Conversions.ToBoolean (NxDb.DS.Tables ["tblDepartments"].Rows [r] [2]); // strPass
            txtDeptNote.Text = Conversions.ToString (NxDb.DS.Tables ["tblDepartments"].Rows [r] [3]);         // strNotes
            txtDeptPass.Text = Conversions.ToString (NxDb.DS.Tables ["tblDepartments"].Rows [r] [4]);         // boolActive
            //ACCs
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x1) == 0x1)
                CheckDeptAcc1.Checked = true;
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x2) == 0x2)
                CheckDeptAcc2.Checked = true;
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x4) == 0x4)
                CheckDeptAcc3.Checked = true;
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x8) == 0x8)
                CheckDeptAcc4.Checked = true;
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x10) == 0x10)
                CheckDeptAcc5.Checked = true;
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x20) == 0x20)
                CheckDeptAcc6.Checked = true;
            if ((Convert.ToInt32 (NxDb.DS.Tables ["tblDepartments"].Rows [r] [5].ToString ()) & 0x40) == 0x40)
                CheckDeptAcc7.Checked = true;
            }
        private void Menu_Save_Click (object sender, EventArgs e)
            {
            SaveChanges_Departments ();
            Dispose ();
            }
        private void SaveChanges_Departments ()
            {
            string strDept = txtDeptName.Text;
            bool boolActive = CheckDeptActive.Checked;
            string strNotes = txtDeptNote.Text;
            string strPass = txtDeptPass.Text;
            int ACCs = 0;
            if (CheckDeptAcc1.Checked == true)
                ACCs = ACCs | 0x1;
            if (CheckDeptAcc2.Checked == true)
                ACCs = ACCs | 0x2;
            if (CheckDeptAcc3.Checked == true)
                ACCs = ACCs | 0x4;
            if (CheckDeptAcc4.Checked == true)
                ACCs = ACCs | 0x8;
            if (CheckDeptAcc5.Checked == true)
                ACCs = ACCs | 0x10;
            if (CheckDeptAcc6.Checked == true)
                ACCs = ACCs | 0x20;
            if (CheckDeptAcc7.Checked == true)
                ACCs = ACCs | 0x40;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "UPDATE Departments SET DepartmentName = @dept, DepartmentActive = @departmentactive, Notes = @notes, DepartmentPass = @departmentpass, acc = @acc WHERE ID = @ID";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@dept", strDept);
                cmd.Parameters.AddWithValue ("@departmentactive", boolActive);
                cmd.Parameters.AddWithValue ("@notes", strNotes);
                cmd.Parameters.AddWithValue ("@departmentpass", strPass);
                cmd.Parameters.AddWithValue ("@acc", ACCs);
                cmd.Parameters.AddWithValue ("@ID", Department.Id.ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Dispose ();
            }

        private void btnSave_Click (object sender, EventArgs e)
            {
            Menu_Save_Click (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Dispose ();
            }

        }
    }