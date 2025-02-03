using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseTerm
        {
        public ChooseTerm ()
            {
            InitializeComponent ();
            }
        private void ChooseTerm_Load (object sender, EventArgs e)
            {
            ShowTerms ();
            if (User.Type == "UserDepartment")
                Menu_Edit.Enabled = false;
            else
                Menu_Edit.Enabled = true;
            }
        private void ShowTerms ()
            {
            NxDb.DS.Tables ["tblTerms"].Clear ();
            if (User.Type == "UserDeputy")
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Terms.ID, Terms.Term, Terms.ExamDateStart, Terms.ExamDateEnd, Terms.Notes, Terms.Active FROM Terms ORDER BY Active, Term", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                    CnnSS.Close ();
                    }
                Menu_Add.Enabled = true;
                }
            else
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    CnnSS.Open ();
                    NxDb.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Terms.ID, Terms.Term, Terms.ExamDateStart, Terms.ExamDateEnd, Terms.Notes, Terms.Active FROM Terms WHERE Terms.Active = 1 ORDER BY Active, Term", CnnSS);
                    NxDb.DASS.Fill (NxDb.DS, "tblTerms");
                    CnnSS.Close ();
                    }
                Menu_Add.Enabled = false;
                }
            Grid1.DataSource = NxDb.DS.Tables ["tblTerms"];
            Grid1.Refresh ();
            Grid1.Columns [0].Visible = false;   // ID
            Grid1.Columns [1].Width = 70;        // Term
            Grid1.Columns [2].Width = 100;       // ExamDateStart
            Grid1.Columns [3].Width = 100;       // ExamDateEnd
            Grid1.Columns [4].Visible = false;   // Notes
            Grid1.Columns [5].Width = 45;        // Active
            // If Userx = "UserDepartment" Then Grid1.Columns(2).Visible = False Else Grid1.Columns(2).Visible = True
            if (User.Type == "UserDeputy" & (User.ACCs & 0x10) == 0x10)
                Grid1.Columns [5].Visible = true;
            else
                Grid1.Columns [5].Visible = false;
            Grid1.Columns [4].Visible = false;
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++)
                Grid1.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        private void Grid1_CellValueChanged (object sender, DataGridViewCellEventArgs e)
            {
            if (User.Type != "UserDeputy")
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم براي کاربر گروه ممکن نيست", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (Grid1.RowCount < 1)
                return;
            int r = Grid1.CurrentCell.RowIndex;
            if (r < 0)
                return;
            Term.Name = Grid1.Rows [r].Cells [1].Value.ToString ();
            NxDb.DS.Tables ["tblTerms"].Rows [r] [1] = Term.Name;
            Term.ExamDateStart = Grid1.Rows [r].Cells [2].Value.ToString ();
            NxDb.DS.Tables ["tblTerms"].Rows [r] [2] = Term.ExamDateStart;
            Term.ExamDateEnd = Grid1.Rows [r].Cells [3].Value.ToString ();
            NxDb.DS.Tables ["tblTerms"].Rows [r] [3] = Term.ExamDateEnd;
            Term.Notes = Grid1.Rows [r].Cells [4].Value.ToString ();
            NxDb.DS.Tables ["tblTerms"].Rows [r] [4] = Term.Notes;
            Term.Active = (bool) (Grid1.Rows [r].Cells [5].Value);
            NxDb.DS.Tables ["tblTerms"].Rows [r] [5] = Term.Active;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                {
                NxDb.strSQL = "UPDATE Terms SET Term = @name, ExamDateStart = @start, ExamDateEnd = @end, Notes = @notes, Active = @active WHERE ID = @id";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@name", Term.Name);
                cmd.Parameters.AddWithValue ("@start", Term.ExamDateStart);
                cmd.Parameters.AddWithValue ("@end", Term.ExamDateEnd);
                cmd.Parameters.AddWithValue ("@notes", Term.Notes);
                cmd.Parameters.AddWithValue ("@active", Term.Active);
                cmd.Parameters.AddWithValue ("@id", NxDb.DS.Tables ["tblTerms"].Rows [r] [0].ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        // PopMENU
        private void Menu_Add_Click (object sender, EventArgs e)
            {
            if (User.Type != "UserDeputy")
                return;
            if ((User.ACCs & 0x10) == 0x0)
                {
                MessageBox.Show ("قابليت (افزودن) اين آيتم اکنون براي شما غير فعال است", "تنظيمات نکسترم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            DialogResult myansw = (DialogResult) MessageBox.Show ("يک ترم جديد اضافه شود؟", "نکسترم" + TermProg.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                {
                return;
                }
            else
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (NxDb.CnnString))
                    {
                    NxDb.strSQL = "INSERT INTO Terms (Term, ExamDateStart, ExamDateEnd, Notes, [Active]) VALUES ('1300-0', '1300.01.01', '1300.01.10', '-', False)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (NxDb.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                Grid1.Refresh ();
                ShowTerms ();
                }
            }
        private void Menu_Edit_Click (object sender, EventArgs e)
            {
            if (Grid1.RowCount < 1)
                return;
            int r = Grid1.SelectedCells [0].RowIndex;    // count from 0
            int c = Grid1.SelectedCells [0].ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;
            try
                {
                switch (c)
                    {
                    case 1: // TERM
                            {
                            if (User.Type == "UserDeputy" & (User.ACCs & 0x10) == 0x0)
                                {
                                MessageBox.Show ("مجوز تغيير نام ترم را نداريد", "تنظيمات نکسترم", MessageBoxButtons.OK);
                                return;
                                }
                            string strValue = Conversions.ToString (Grid1 [c, r].Value);
                            strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            Grid1 [c, r].Value = Strings.Trim (strValue);
                            break;
                            }

                    case 2: // ExamStart
                            {
                            if (User.Type == "UserDeputy" & (User.ACCs & 0x10) == 0x0)
                                {
                                MessageBox.Show ("مجوز تغيير نام ترم را نداريد", "تنظيمات نکسترم", MessageBoxButtons.OK);
                                return;
                                }
                            string strValue = Conversions.ToString (Grid1 [c, r].Value);
                            strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            Grid1 [c, r].Value = Strings.Trim (strValue);
                            break;
                            }

                    case 3: // ExamEnd
                            {
                            if (User.Type == "UserDeputy" & (User.ACCs & 0x10) == 0x0)
                                {
                                MessageBox.Show ("مجوز تغيير نام ترم را نداريد", "تنظيمات نکسترم", MessageBoxButtons.OK);
                                return;
                                }
                            string strValue = Conversions.ToString (Grid1 [c, r].Value);
                            strValue = Interaction.InputBox ("مقدار جديد را وارد کنيد", "نکسترم", strValue);
                            if (string.IsNullOrEmpty (Strings.Trim (strValue)))
                                return;
                            Grid1 [c, r].Value = Strings.Trim (strValue);
                            break;
                            }

                    case 5: // ACTIVE
                            {
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Grid1 [c, r].Value.ToString (), true, false)))
                                {
                                Grid1 [c, r].Value = false;
                                }
                            else
                                {
                                Grid1 [c, r].Value = true;
                                }

                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu_OK_Click (object sender, EventArgs e)
            {
            int r = Grid1.SelectedCells [0].RowIndex;
            Term.Id = (long) Math.Round (Conversion.Val (Grid1 [0, r].Value));
            Term.Name = Conversions.ToString (Grid1 [1, r].Value);
            Close ();
            Dispose ();
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Term.Id = 0L;
            Term.Name = "";
            Close ();
            Dispose ();
            }

        private void btnSave_Click (object sender, EventArgs e)
            {
            Menu_OK_Click (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Menu_Cancel_Click (null, null);
            }
        }
    }