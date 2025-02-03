using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseDept : Form
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
            ListDepts = new ListBox ();
            ContextMenu_Depts = new ContextMenuStrip (components);
            MenuOK = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            MenuCancel = new ToolStripMenuItem ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnSave = new Button ();
            ContextMenu_Depts.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ListDepts
            // 
            ListDepts.BackColor = Color.WhiteSmoke;
            ListDepts.BorderStyle = BorderStyle.None;
            ListDepts.ContextMenuStrip = ContextMenu_Depts;
            ListDepts.Font = new Font ("Segoe UI", 12F);
            ListDepts.FormattingEnabled = true;
            ListDepts.ItemHeight = 21;
            ListDepts.Location = new Point (12, 12);
            ListDepts.Name = "ListDepts";
            ListDepts.RightToLeft = RightToLeft.Yes;
            ListDepts.Size = new Size (333, 399);
            ListDepts.TabIndex = 9;
            ListDepts.DoubleClick += ListDepts_DoubleClick;
            ListDepts.KeyDown += ListDepts_KeyDown;
            // 
            // ContextMenu_Depts
            // 
            ContextMenu_Depts.Items.AddRange (new ToolStripItem [] { MenuOK, ToolStripMenuItem1, MenuCancel });
            ContextMenu_Depts.Name = "ContextMenuStrip1";
            ContextMenu_Depts.RightToLeft = RightToLeft.Yes;
            ContextMenu_Depts.Size = new Size (148, 54);
            // 
            // MenuOK
            // 
            MenuOK.Name = "MenuOK";
            MenuOK.Size = new Size (147, 22);
            MenuOK.Text = "انتخاب / تاييد";
            MenuOK.Click += MenuOK_Click;
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
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 467);
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
            btnSave.Location = new Point (131, 423);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (101, 23);
            btnSave.TabIndex = 18;
            btnSave.Text = "تاييد";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChooseDept
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (358, 487);
            ControlBox = false;
            Controls.Add (btnSave);
            Controls.Add (panel1);
            Controls.Add (ListDepts);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseDept";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "گروه آموزشي";
            Load += ChooseDept_Load;
            ContextMenu_Depts.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ListBox ListDepts;
        internal ContextMenuStrip ContextMenu_Depts;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem MenuCancel;
        private Panel panel1;
        private Label lblCancel;
        private Button btnSave;
        }
    }