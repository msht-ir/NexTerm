using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseBioProg : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (ChooseBioProg));
            ListBioProg = new ListBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            MenuOK = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            MenuAddNewProg = new ToolStripMenuItem ();
            MenuEditThisProg = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            MenuCancel = new ToolStripMenuItem ();
            ListDepts = new ListBox ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnOK = new Button ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ListBioProg
            // 
            ListBioProg.BackColor = Color.WhiteSmoke;
            ListBioProg.BorderStyle = BorderStyle.None;
            ListBioProg.ContextMenuStrip = ContextMenuStrip1;
            ListBioProg.Font = new Font ("Segoe UI", 10F);
            ListBioProg.FormattingEnabled = true;
            ListBioProg.ItemHeight = 17;
            ListBioProg.Location = new Point (12, 12);
            ListBioProg.Name = "ListBioProg";
            ListBioProg.RightToLeft = RightToLeft.Yes;
            ListBioProg.Size = new Size (267, 374);
            ListBioProg.TabIndex = 8;
            ListBioProg.Tag = "انتخاب دوره آموزشي";
            ListBioProg.DoubleClick += ListBioProg_DoubleClick;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { MenuOK, ToolStripMenuItem1, MenuAddNewProg, MenuEditThisProg, ToolStripMenuItem2, MenuCancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (148, 104);
            // 
            // MenuOK
            // 
            MenuOK.Name = "MenuOK";
            MenuOK.Size = new Size (147, 22);
            MenuOK.Text = "تاييد / انتخاب";
            MenuOK.Click += MenuOK_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (144, 6);
            // 
            // MenuAddNewProg
            // 
            MenuAddNewProg.Name = "MenuAddNewProg";
            MenuAddNewProg.Size = new Size (147, 22);
            MenuAddNewProg.Text = "+ دوره جديد";
            MenuAddNewProg.Click += MenuAddNewProg_Click;
            // 
            // MenuEditThisProg
            // 
            MenuEditThisProg.Name = "MenuEditThisProg";
            MenuEditThisProg.Size = new Size (147, 22);
            MenuEditThisProg.Text = "ويرايش";
            MenuEditThisProg.Click += MenuEditThisProg_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (144, 6);
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
            ListDepts.ContextMenuStrip = ContextMenuStrip1;
            ListDepts.Font = new Font ("Segoe UI", 11F);
            ListDepts.ForeColor = Color.IndianRed;
            ListDepts.FormattingEnabled = true;
            ListDepts.ItemHeight = 20;
            ListDepts.Location = new Point (285, 31);
            ListDepts.Name = "ListDepts";
            ListDepts.RightToLeft = RightToLeft.Yes;
            ListDepts.Size = new Size (271, 360);
            ListDepts.TabIndex = 9;
            ListDepts.Tag = "انتخاب گروه آموزشي";
            ListDepts.SelectedIndexChanged += ListDepts_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 435);
            panel1.Name = "panel1";
            panel1.Size = new Size (568, 20);
            panel1.TabIndex = 10;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (568, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point (97, 392);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size (101, 23);
            btnOK.TabIndex = 19;
            btnOK.Text = "تاييد";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // ChooseBioProg
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size (568, 455);
            ControlBox = false;
            Controls.Add (btnOK);
            Controls.Add (panel1);
            Controls.Add (ListDepts);
            Controls.Add (ListBioProg);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "ChooseBioProg";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "دوره آموزشي";
            Load += ChooseBioProg_Load;
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ListBox ListBioProg;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripMenuItem MenuAddNewProg;
        internal ToolStripMenuItem MenuCancel;
        internal ToolStripMenuItem MenuEditThisProg;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ListBox ListDepts;
        private Panel panel1;
        private Label lblCancel;
        private Button btnOK;
        }
    }