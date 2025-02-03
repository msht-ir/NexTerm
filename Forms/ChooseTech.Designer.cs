using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseTech : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (ChooseTech));
            ListTechs = new ListBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            MenuOK = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            MenuAddNew = new ToolStripMenuItem ();
            MenuEdit = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            MenuCancel = new ToolStripMenuItem ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnSave = new Button ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ListTechs
            // 
            ListTechs.BackColor = Color.FromArgb (  248,   248,   248);
            ListTechs.BorderStyle = BorderStyle.None;
            ListTechs.ContextMenuStrip = ContextMenuStrip1;
            ListTechs.Font = new Font ("Segoe UI", 11F);
            ListTechs.ForeColor = Color.IndianRed;
            ListTechs.FormattingEnabled = true;
            ListTechs.ItemHeight = 20;
            ListTechs.Location = new Point (12, 12);
            ListTechs.Name = "ListTechs";
            ListTechs.RightToLeft = RightToLeft.Yes;
            ListTechs.Size = new Size (333, 420);
            ListTechs.TabIndex = 8;
            ListTechs.DoubleClick += ListTechs_DoubleClick;
            ListTechs.KeyDown += ListTechs_KeyDown;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { MenuOK, ToolStripMenuItem1, MenuAddNew, MenuEdit, ToolStripMenuItem2, MenuCancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (156, 104);
            // 
            // MenuOK
            // 
            MenuOK.Name = "MenuOK";
            MenuOK.Size = new Size (155, 22);
            MenuOK.Text = "انتخاب / تاييد";
            MenuOK.Click += MenuOK_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (152, 6);
            // 
            // MenuAddNew
            // 
            MenuAddNew.Name = "MenuAddNew";
            MenuAddNew.Size = new Size (155, 22);
            MenuAddNew.Text = "+ کارشناس جديد";
            MenuAddNew.Click += MenuAddNew_Click;
            // 
            // MenuEdit
            // 
            MenuEdit.Name = "MenuEdit";
            MenuEdit.Size = new Size (155, 22);
            MenuEdit.Text = "ويرايش";
            MenuEdit.Click += MenuEdit_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (152, 6);
            // 
            // MenuCancel
            // 
            MenuCancel.ForeColor = Color.IndianRed;
            MenuCancel.Name = "MenuCancel";
            MenuCancel.Size = new Size (155, 22);
            MenuCancel.Text = "انصراف / خروج";
            MenuCancel.Click += MenuCancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 485);
            panel1.Name = "panel1";
            panel1.Size = new Size (358, 20);
            panel1.TabIndex = 11;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (358, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point (129, 447);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (101, 23);
            btnSave.TabIndex = 16;
            btnSave.Text = "تاييد";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChooseTech
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (358, 505);
            ControlBox = false;
            Controls.Add (btnSave);
            Controls.Add (panel1);
            Controls.Add (ListTechs);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "ChooseTech";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "کارشناس";
            Load += ChooseTech_Load;
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ListBox ListTechs;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripMenuItem MenuAddNew;
        internal ToolStripMenuItem MenuCancel;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem MenuEdit;
        private Panel panel1;
        private Label lblCancel;
        private Button btnSave;
        }
    }