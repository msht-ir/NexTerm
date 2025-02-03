using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NexTerm
    {
    public partial class frmDateTimeDialog
        {
        public frmDateTimeDialog ()
            {
            InitializeComponent ();
            }
        private void frmDateTimeDialog_Load (object sender, EventArgs e)
            {
            txtExamDate.Text = TermProg.tmpExamDateTime;
            ABC ();
            }
        private void ABC ()
            {
            txtExamDate.SelectionStart = 0;
            }
        private void txtExamDate_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13:
                        {
                        Menu_OK_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 27:
                        {
                        Menu_Cancel_Click (sender, e);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }

        private void Menu_OK_Click (object sender, EventArgs e)
            {
            TermProg.tmpExamDateTime = txtExamDate.Text;
            if (Conversion.Val (Strings.Mid (TermProg.tmpExamDateTime, 13)) == 0d & !string.IsNullOrEmpty (Strings.Trim (TermProg.tmpExamDateTime)))
                {
                txtExamDate.SelectionStart = 12;
                return;
                }
            Dispose ();
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            TermProg.tmpExamDateTime = "";
            Dispose ();
            }
        }
    }