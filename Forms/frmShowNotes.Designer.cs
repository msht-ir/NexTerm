using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmShowNotes : Form
        {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode ()]
        protected override void Dispose (bool disposing)
            {
            try
                {
                if (disposing && components is not null)
                    {
                    components.Dispose ();
                    }
                }
            finally
                {
                base.Dispose (disposing);
                }
            }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough ()]
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle ();
            GridNotes = new DataGridView ();
            ContextMenuNotes = new ContextMenuStrip (components);
            Menu_IsRead = new ToolStripMenuItem ();
            Menu_Del = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_Help = new ToolStripMenuItem ();
            Menu_Exit = new ToolStripMenuItem ();
            ListDepts = new ListBox ();
            ContextMenuExit = new ContextMenuStrip (components);
            MenuExit2 = new ToolStripMenuItem ();
            Label1 = new Label ();
            Label2 = new Label ();
            txtNote = new TextBox ();
            Label3 = new Label ();
            Label4 = new Label ();
            ListDeanEdu = new ListBox ();
            Label6 = new Label ();
            Label7 = new Label ();
            Label5 = new Label ();
            Label8 = new Label ();
            Panel1 = new Panel ();
            lblExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridNotes).BeginInit ();
            ContextMenuNotes.SuspendLayout ();
            ContextMenuExit.SuspendLayout ();
            Panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridNotes
            // 
            GridNotes.AllowUserToAddRows = false;
            GridNotes.AllowUserToDeleteRows = false;
            GridNotes.AllowUserToResizeColumns = false;
            GridNotes.AllowUserToResizeRows = false;
            GridNotes.BackgroundColor = Color.FromArgb (  244,   244,   244);
            GridNotes.BorderStyle = BorderStyle.None;
            GridNotes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridNotes.ColumnHeadersVisible = false;
            GridNotes.ContextMenuStrip = ContextMenuNotes;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = Color.FromArgb (  234,   234,   234);
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb (  244,   244,   244);
            dataGridViewCellStyle3.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            GridNotes.DefaultCellStyle = dataGridViewCellStyle3;
            GridNotes.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridNotes.GridColor = Color.FromArgb (  244,   244,   244);
            GridNotes.Location = new Point (12, 25);
            GridNotes.Name = "GridNotes";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font ("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            GridNotes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            GridNotes.RowHeadersVisible = false;
            GridNotes.Size = new Size (1079, 421);
            GridNotes.TabIndex = 1;
            GridNotes.CellClick += GridNotes_CellClick;
            GridNotes.DoubleClick += GridNotes_DoubleClick;
            // 
            // ContextMenuNotes
            // 
            ContextMenuNotes.Items.AddRange (new ToolStripItem [] { Menu_IsRead, Menu_Del, ToolStripMenuItem2, Menu_Help, Menu_Exit });
            ContextMenuNotes.Name = "ContextMenuNotes";
            ContextMenuNotes.RightToLeft = RightToLeft.Yes;
            ContextMenuNotes.Size = new Size (121, 98);
            // 
            // Menu_IsRead
            // 
            Menu_IsRead.Name = "Menu_IsRead";
            Menu_IsRead.Size = new Size (120, 22);
            Menu_IsRead.Text = "خواندم";
            Menu_IsRead.Click += Menu_IsRead_Click;
            // 
            // Menu_Del
            // 
            Menu_Del.ForeColor = Color.IndianRed;
            Menu_Del.Name = "Menu_Del";
            Menu_Del.Size = new Size (120, 22);
            Menu_Del.Text = "حذف پيام";
            Menu_Del.Click += Menu_Del_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (117, 6);
            // 
            // Menu_Help
            // 
            Menu_Help.Name = "Menu_Help";
            Menu_Help.Size = new Size (120, 22);
            Menu_Help.Text = "راهنما";
            Menu_Help.Click += Menu_Help_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (120, 22);
            Menu_Exit.Text = "بازگشت";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // ListDepts
            // 
            ListDepts.BackColor = Color.White;
            ListDepts.BorderStyle = BorderStyle.None;
            ListDepts.ContextMenuStrip = ContextMenuExit;
            ListDepts.Font = new Font ("Segoe UI", 11F, FontStyle.Bold);
            ListDepts.ForeColor = Color.IndianRed;
            ListDepts.FormattingEnabled = true;
            ListDepts.ItemHeight = 20;
            ListDepts.Location = new Point (1104, 150);
            ListDepts.Name = "ListDepts";
            ListDepts.RightToLeft = RightToLeft.Yes;
            ListDepts.Size = new Size (217, 320);
            ListDepts.TabIndex = 1;
            ListDepts.Click += ListDepts_Click;
            // 
            // ContextMenuExit
            // 
            ContextMenuExit.Items.AddRange (new ToolStripItem [] { MenuExit2 });
            ContextMenuExit.Name = "ContextMenuSentNoteToGroup";
            ContextMenuExit.RightToLeft = RightToLeft.Yes;
            ContextMenuExit.Size = new Size (113, 26);
            // 
            // MenuExit2
            // 
            MenuExit2.ForeColor = Color.IndianRed;
            MenuExit2.Name = "MenuExit2";
            MenuExit2.Size = new Size (112, 22);
            MenuExit2.Text = "بازگشت";
            MenuExit2.Click += MenuExit2_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.BackColor = Color.White;
            Label1.Font = new Font ("Segoe UI", 8F);
            Label1.ForeColor = SystemColors.ControlDarkDark;
            Label1.Location = new Point (116, 458);
            Label1.Name = "Label1";
            Label1.Size = new Size (29, 13);
            Label1.TabIndex = 4;
            Label1.Text = "جديد";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = Color.White;
            Label2.Font = new Font ("Segoe UI", 8F);
            Label2.ForeColor = SystemColors.ControlDarkDark;
            Label2.Location = new Point (9, 458);
            Label2.Name = "Label2";
            Label2.Size = new Size (75, 13);
            Label2.TabIndex = 5;
            Label2.Text = "گيرنده نخوانده";
            // 
            // txtNote
            // 
            txtNote.BackColor = Color.FromArgb (  252,   252,   252);
            txtNote.BorderStyle = BorderStyle.None;
            txtNote.ContextMenuStrip = ContextMenuExit;
            txtNote.Font = new Font ("Segoe UI", 12F);
            txtNote.ForeColor = Color.DarkBlue;
            txtNote.Location = new Point (215, 453);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size (854, 22);
            txtNote.TabIndex = 0;
            txtNote.TextAlign = HorizontalAlignment.Right;
            txtNote.KeyDown += txtNote_KeyDown;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.BackColor = Color.FromArgb (  255,   192,   192);
            Label3.Font = new Font ("Segoe UI", 8F);
            Label3.ForeColor = SystemColors.ControlDarkDark;
            Label3.Location = new Point (87, 458);
            Label3.Name = "Label3";
            Label3.Size = new Size (19, 13);
            Label3.TabIndex = 11;
            Label3.Text = "    ";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.BackColor = Color.Cyan;
            Label4.Font = new Font ("Segoe UI", 8F);
            Label4.ForeColor = SystemColors.ControlDarkDark;
            Label4.Location = new Point (150, 458);
            Label4.Name = "Label4";
            Label4.Size = new Size (19, 13);
            Label4.TabIndex = 10;
            Label4.Text = "    ";
            // 
            // ListDeanEdu
            // 
            ListDeanEdu.BackColor = Color.White;
            ListDeanEdu.BorderStyle = BorderStyle.None;
            ListDeanEdu.Font = new Font ("Segoe UI", 11F, FontStyle.Bold);
            ListDeanEdu.ForeColor = SystemColors.ControlDark;
            ListDeanEdu.FormattingEnabled = true;
            ListDeanEdu.ItemHeight = 20;
            ListDeanEdu.Items.AddRange (new object [] { "آموزش دانشکده" });
            ListDeanEdu.Location = new Point (1104, 104);
            ListDeanEdu.Name = "ListDeanEdu";
            ListDeanEdu.RightToLeft = RightToLeft.Yes;
            ListDeanEdu.Size = new Size (217, 40);
            ListDeanEdu.TabIndex = 12;
            ListDeanEdu.Click += ListDeanEdu_Click;
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.BackColor = Color.White;
            Label6.Font = new Font ("Segoe UI", 8F);
            Label6.ForeColor = SystemColors.ControlDarkDark;
            Label6.Location = new Point (890, 3);
            Label6.Name = "Label6";
            Label6.Size = new Size (46, 13);
            Label6.TabIndex = 15;
            Label6.Text = "فرستنده";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.BackColor = Color.White;
            Label7.Font = new Font ("Segoe UI", 8F);
            Label7.ForeColor = SystemColors.ControlDarkDark;
            Label7.Location = new Point (734, 3);
            Label7.Name = "Label7";
            Label7.Size = new Size (37, 13);
            Label7.TabIndex = 16;
            Label7.Text = "گيرنده";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.BackColor = Color.White;
            Label5.Font = new Font ("Segoe UI", 14F);
            Label5.ForeColor = Color.IndianRed;
            Label5.Location = new Point (1075, 450);
            Label5.Name = "Label5";
            Label5.Size = new Size (25, 25);
            Label5.TabIndex = 18;
            Label5.Text = "<";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.BackColor = Color.White;
            Label8.Font = new Font ("Courier New", 10F);
            Label8.ForeColor = SystemColors.ControlText;
            Label8.Location = new Point (18, 3);
            Label8.Name = "Label8";
            Label8.Size = new Size (72, 17);
            Label8.TabIndex = 19;
            Label8.Text = "MESSAGES";
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add (lblExit);
            Panel1.Dock = DockStyle.Bottom;
            Panel1.Location = new Point (0, 494);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size (1355, 20);
            Panel1.TabIndex = 48;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (0, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (1355, 20);
            lblExit.TabIndex = 46;
            lblExit.Text = "خروج";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmShowNotes
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (1355, 514);
            ControlBox = false;
            Controls.Add (Panel1);
            Controls.Add (Label8);
            Controls.Add (Label5);
            Controls.Add (Label7);
            Controls.Add (Label6);
            Controls.Add (ListDeanEdu);
            Controls.Add (Label3);
            Controls.Add (Label4);
            Controls.Add (txtNote);
            Controls.Add (Label2);
            Controls.Add (Label1);
            Controls.Add (ListDepts);
            Controls.Add (GridNotes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmShowNotes";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "يادداشت";
            Load += frmShowNotes_Load;
            KeyDown += frmShowNotes_KeyDown;
            ((System.ComponentModel.ISupportInitialize) GridNotes).EndInit ();
            ContextMenuNotes.ResumeLayout (false);
            ContextMenuExit.ResumeLayout (false);
            Panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal DataGridView GridNotes;
        internal ContextMenuStrip ContextMenuNotes;
        internal ToolStripMenuItem Menu_Exit;
        internal ToolStripMenuItem Menu_Del;
        internal ToolStripMenuItem Menu_OnlyMyNotes;
        internal ListBox ListDepts;
        internal ContextMenuStrip ContextMenuExit;
        internal ToolStripMenuItem MenuExit2;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal Label Label1;
        internal Label Label2;
        internal ToolStripMenuItem Menu_Help;
        internal TextBox txNote;
        internal TextBox txtNote;
        internal Label Label3;
        internal Label Label4;
        internal PictureBox PictureBox1;
        internal ListBox ListDeanEdu;
        internal Label lblDept;
        internal Label Label6;
        internal Label Label7;
        internal ToolStripMenuItem Menu_IsRead;
        internal PictureBox PictureBox2;
        internal Label Label5;
        internal Label Label8;
        internal Panel Panel1;
        private Label lblExit;
        }
    }