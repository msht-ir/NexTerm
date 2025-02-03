using System;
using Microsoft.VisualBasic.CompilerServices;

namespace NexTerm
    {
    public partial class ChooseDept
        {
        public ChooseDept ()
            {
            InitializeComponent ();
            }
        private void ChooseDept_Load (object sender, EventArgs e)
            {
            ListDepts.DataSource = NxDb.DS.Tables ["tblDepartments"];
            ListDepts.DisplayMember = "DEPT";
            ListDepts.ValueMember = "ID";
            ListDepts.Refresh ();
            ListDepts.SelectedIndex = -1;
            ListDepts.SelectedValue = 0;
            }
        private void ListDepts_DoubleClick (object sender, EventArgs e)
            {
            MenuOK_Click (sender, e);
            }
        private void ListDepts_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e)
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
            Department.Name = ListDepts.Text;
            Department.Id = Convert.ToInt64 (ListDepts.SelectedValue);
            Dispose ();
            }
        private void MenuCancel_Click (object sender, EventArgs e)
            {
            Department.Name = "";
            Department.Id = 0L;
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