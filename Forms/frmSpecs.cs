using System;
using System.Windows.Forms;

namespace NexTerm
    {
    public partial class frmSpecs
        {
        public frmSpecs ()
            {
            InitializeComponent ();
            }
        private void frmSpecs_Load (object sender, EventArgs e)
            {
            /*
             * Retval1 {1:ProgsSpecs  | 2:CourseSpecs}
             * Retval2 : result are stored in Retval2 when menu_OK is clicked
             */
            switch (Nxt.Retval1)
                {
                case 1: //progs
                        {
                        Chk1.Text = "فوق ديپلم";
                        Chk2.Text = "کارشناسي";
                        Chk3.Text = "کارشناسي ارشد";
                        Chk4.Text = "دکتري عمومي";
                        Chk5.Text = "دکتري تخصصي";
                        Chk6.Text = "سرويس هاي آموزشي دانشکده";
                        Chk7.Text = "برنامه گروه آموزشي";
                        Chk8.Text = "امور اجرايي";
                        break;
                        }
                case 2: //courses
                        {
                        Chk1.Text = "درس عملي";
                        Chk2.Text = "درس تئوري";
                        Chk3.Text = "درس الزامي";
                        Chk4.Text = "-";
                        Chk4.Enabled = false;
                        Chk4.Visible = false;
                        Chk5.Text = "-";
                        Chk5.Enabled = false;
                        Chk5.Visible = false;
                        Chk6.Text = "-";
                        Chk6.Enabled = false;
                        Chk6.Visible = false;
                        Chk7.Text = "-";
                        Chk7.Enabled = false;
                        Chk7.Visible = false;
                        Chk8.Text = "-";
                        Chk8.Enabled = false;
                        Chk8.Visible = false;
                        break;
                        }
                }
            if ((Nxt.Retval2 & 0x1) == 0x1)
                Chk1.Checked = true;
            if ((Nxt.Retval2 & 0x2) == 0x2)
                Chk2.Checked = true;
            if ((Nxt.Retval2 & 0x4) == 0x4)
                Chk3.Checked = true;
            if ((Nxt.Retval2 & 0x8) == 0x8)
                Chk4.Checked = true;
            if ((Nxt.Retval2 & 0x10) == 0x10)
                Chk5.Checked = true;
            if ((Nxt.Retval2 & 0x20) == 0x20)
                Chk6.Checked = true;
            if ((Nxt.Retval2 & 0x40) == 0x40)
                Chk7.Checked = true;
            if ((Nxt.Retval2 & 0x80) == 0x80)
                Chk8.Checked = true;
            }
        private void Menu_OK_Click (object sender, EventArgs e)
            {
            Nxt.Retval2 = 0;
            Nxt.Retval1 = 1; // [1: OK | 2: Cancel]
            if (Chk1.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x1;
            if (Chk2.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x2;
            if (Chk3.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x4;
            if (Chk4.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x8;
            if (Chk5.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x10;
            if (Chk6.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x20;
            if (Chk7.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x40;
            if (Chk8.Checked == true)
                Nxt.Retval2 = Nxt.Retval2 | 0x80;
            Dispose ();
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Nxt.Retval1 = 0; // [1: OK | 2: Cancel]
            Dispose ();
            }

        }
    }