using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseStaff : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (ChooseStaff));
            ListStaff = new ListBox ();
            ContextMenu_Staff = new ContextMenuStrip (components);
            MenuOK = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            MenuAddNew = new ToolStripMenuItem ();
            Menu_DelStaff = new ToolStripMenuItem ();
            MenuEdit = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            MenuCancel = new ToolStripMenuItem ();
            ListDepts = new ListBox ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnSave = new Button ();
            ContextMenu_Staff.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ListStaff
            // 
            ListStaff.BackColor = SystemColors.Control;
            ListStaff.BorderStyle = BorderStyle.None;
            ListStaff.ContextMenuStrip = ContextMenu_Staff;
            ListStaff.Font = new Font ("Segoe UI", 11F);
            ListStaff.FormattingEnabled = true;
            ListStaff.ItemHeight = 20;
            ListStaff.Location = new Point (12, 12);
            ListStaff.Name = "ListStaff";
            ListStaff.RightToLeft = RightToLeft.Yes;
            ListStaff.Size = new Size (269, 380);
            ListStaff.TabIndex = 1;
            ListStaff.DoubleClick += ListStaff_DoubleClick;
            ListStaff.KeyDown += ListStaff_KeyDown;
            // 
            // ContextMenu_Staff
            // 
            ContextMenu_Staff.Items.AddRange (new ToolStripItem [] { MenuOK, ToolStripMenuItem2, MenuAddNew, Menu_DelStaff, MenuEdit, ToolStripMenuItem1, MenuCancel });
            ContextMenu_Staff.Name = "ContextMenuStrip1";
            ContextMenu_Staff.RightToLeft = RightToLeft.Yes;
            ContextMenu_Staff.Size = new Size (148, 126);
            // 
            // MenuOK
            // 
            MenuOK.Name = "MenuOK";
            MenuOK.Size = new Size (147, 22);
            MenuOK.Text = "انتخاب / تاييد";
            MenuOK.Click += MenuOK_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (144, 6);
            // 
            // MenuAddNew
            // 
            MenuAddNew.Name = "MenuAddNew";
            MenuAddNew.Size = new Size (147, 22);
            MenuAddNew.Text = "+ استاد جديد";
            MenuAddNew.Click += MenuAddNew_Click;
            // 
            // Menu_DelStaff
            // 
            Menu_DelStaff.Enabled = false;
            Menu_DelStaff.Name = "Menu_DelStaff";
            Menu_DelStaff.Size = new Size (147, 22);
            Menu_DelStaff.Text = "حذف استاد";
            Menu_DelStaff.Click += Menu_DelStaff_Click;
            // 
            // MenuEdit
            // 
            MenuEdit.Name = "MenuEdit";
            MenuEdit.Size = new Size (147, 22);
            MenuEdit.Text = "ويرايش";
            MenuEdit.Click += MenuEdit_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (144, 6);
            // 
            // MenuCancel
            // 
            MenuCancel.ForeColor = Color.IndianRed;
            MenuCancel.Name = "MenuCancel";
            MenuCancel.Size = new Size (147, 22);
            MenuCancel.Text = "انصراف / خروج";
            MenuCancel.Click += MenuCancel_Click;
            // 
            // ListDepts
            // 
            ListDepts.BackColor = SystemColors.ButtonHighlight;
            ListDepts.BorderStyle = BorderStyle.None;
            ListDepts.ContextMenuStrip = ContextMenu_Staff;
            ListDepts.Font = new Font ("Segoe UI", 12F, FontStyle.Bold);
            ListDepts.ForeColor = Color.IndianRed;
            ListDepts.FormattingEnabled = true;
            ListDepts.ItemHeight = 21;
            ListDepts.Location = new Point (287, 12);
            ListDepts.Name = "ListDepts";
            ListDepts.RightToLeft = RightToLeft.Yes;
            ListDepts.Size = new Size (302, 378);
            ListDepts.TabIndex = 5;
            ListDepts.Click += ListDepts_Click;
            ListDepts.KeyDown += ListDepts_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 434);
            panel1.Name = "panel1";
            panel1.Size = new Size (614, 20);
            panel1.TabIndex = 11;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (614, 20);
            lblCancel.TabIndex = 0;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point (97, 405);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (101, 23);
            btnSave.TabIndex = 17;
            btnSave.Text = "تاييد";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChooseStaff
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (614, 454);
            ControlBox = false;
            Controls.Add (btnSave);
            Controls.Add (ListDepts);
            Controls.Add (ListStaff);
            Controls.Add (panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "ChooseStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "اساتيد";
            Load += ChooseStaff_Load;
            ContextMenu_Staff.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ListBox ListStaff;
        internal ContextMenuStrip ContextMenu_Staff;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripMenuItem MenuCancel;
        internal ToolStripMenuItem MenuAddNew;
        internal ToolStripMenuItem MenuEdit;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_DelStaff;
        internal ListBox ListDepts;
        private Panel panel1;
        private Label lblCancel;
        private Button btnSave;
        }
    }