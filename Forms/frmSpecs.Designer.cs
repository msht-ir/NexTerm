using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmSpecs : Form
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
            Chk1 = new CheckBox ();
            Chk2 = new CheckBox ();
            Chk3 = new CheckBox ();
            Chk4 = new CheckBox ();
            Chk5 = new CheckBox ();
            Chk6 = new CheckBox ();
            Chk7 = new CheckBox ();
            Chk8 = new CheckBox ();
            ContextMenuSpecs = new ContextMenuStrip (components);
            Menu_OK = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            ContextMenuSpecs.SuspendLayout ();
            SuspendLayout ();
            // 
            // Chk1
            // 
            Chk1.Location = new Point (41, 18);
            Chk1.Name = "Chk1";
            Chk1.RightToLeft = RightToLeft.Yes;
            Chk1.Size = new Size (190, 23);
            Chk1.TabIndex = 0;
            Chk1.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk1.UseVisualStyleBackColor = true;
            // 
            // Chk2
            // 
            Chk2.Location = new Point (41, 43);
            Chk2.Name = "Chk2";
            Chk2.RightToLeft = RightToLeft.Yes;
            Chk2.Size = new Size (190, 23);
            Chk2.TabIndex = 1;
            Chk2.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk2.UseVisualStyleBackColor = true;
            // 
            // Chk3
            // 
            Chk3.Location = new Point (41, 68);
            Chk3.Name = "Chk3";
            Chk3.RightToLeft = RightToLeft.Yes;
            Chk3.Size = new Size (190, 23);
            Chk3.TabIndex = 2;
            Chk3.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk3.UseVisualStyleBackColor = true;
            // 
            // Chk4
            // 
            Chk4.Location = new Point (41, 93);
            Chk4.Name = "Chk4";
            Chk4.RightToLeft = RightToLeft.Yes;
            Chk4.Size = new Size (190, 23);
            Chk4.TabIndex = 3;
            Chk4.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk4.UseVisualStyleBackColor = true;
            // 
            // Chk5
            // 
            Chk5.Location = new Point (41, 119);
            Chk5.Name = "Chk5";
            Chk5.RightToLeft = RightToLeft.Yes;
            Chk5.Size = new Size (190, 23);
            Chk5.TabIndex = 4;
            Chk5.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk5.UseVisualStyleBackColor = true;
            // 
            // Chk6
            // 
            Chk6.Location = new Point (41, 144);
            Chk6.Name = "Chk6";
            Chk6.RightToLeft = RightToLeft.Yes;
            Chk6.Size = new Size (190, 23);
            Chk6.TabIndex = 5;
            Chk6.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk6.UseVisualStyleBackColor = true;
            // 
            // Chk7
            // 
            Chk7.Location = new Point (41, 169);
            Chk7.Name = "Chk7";
            Chk7.RightToLeft = RightToLeft.Yes;
            Chk7.Size = new Size (190, 23);
            Chk7.TabIndex = 6;
            Chk7.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk7.UseVisualStyleBackColor = true;
            // 
            // Chk8
            // 
            Chk8.Location = new Point (41, 194);
            Chk8.Name = "Chk8";
            Chk8.RightToLeft = RightToLeft.Yes;
            Chk8.Size = new Size (190, 23);
            Chk8.TabIndex = 7;
            Chk8.Text = "مشخصات قابل تنظيم را وارد کنيد";
            Chk8.UseVisualStyleBackColor = true;
            // 
            // ContextMenuSpecs
            // 
            ContextMenuSpecs.Items.AddRange (new ToolStripItem [] { Menu_OK, Menu_Cancel });
            ContextMenuSpecs.Name = "ContextMenuSpecs";
            ContextMenuSpecs.RightToLeft = RightToLeft.Yes;
            ContextMenuSpecs.Size = new Size (112, 48);
            // 
            // Menu_OK
            // 
            Menu_OK.Name = "Menu_OK";
            Menu_OK.Size = new Size (111, 22);
            Menu_OK.Text = "تاييد";
            Menu_OK.Click += Menu_OK_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (111, 22);
            Menu_Cancel.Text = "انصراف";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // frmSpecs
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size (269, 234);
            ContextMenuStrip = ContextMenuSpecs;
            ControlBox = false;
            Controls.Add (Chk8);
            Controls.Add (Chk7);
            Controls.Add (Chk6);
            Controls.Add (Chk5);
            Controls.Add (Chk4);
            Controls.Add (Chk3);
            Controls.Add (Chk2);
            Controls.Add (Chk1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSpecs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "مشخصات";
            Load += frmSpecs_Load;
            ContextMenuSpecs.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal CheckBox Chk1;
        internal CheckBox Chk2;
        internal CheckBox Chk3;
        internal CheckBox Chk4;
        internal CheckBox Chk5;
        internal CheckBox Chk6;
        internal CheckBox Chk7;
        internal CheckBox Chk8;
        internal ContextMenuStrip ContextMenuSpecs;
        internal ToolStripMenuItem Menu_OK;
        internal ToolStripMenuItem Menu_Cancel;
        }
    }