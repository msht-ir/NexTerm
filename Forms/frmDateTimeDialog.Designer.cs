using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmDateTimeDialog : Form
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
            txtExamDate = new MaskedTextBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_OK = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Cancel = new ToolStripMenuItem ();
            ContextMenuStrip1.SuspendLayout ();
            SuspendLayout ();
            // 
            // txtExamDate
            // 
            txtExamDate.BackColor = Color.WhiteSmoke;
            txtExamDate.BorderStyle = BorderStyle.None;
            txtExamDate.ContextMenuStrip = ContextMenuStrip1;
            txtExamDate.Font = new Font ("Courier New", 30F, FontStyle.Regular, GraphicsUnit.Point);
            txtExamDate.ForeColor = Color.Crimson;
            txtExamDate.Location = new Point (12, 17);
            txtExamDate.Mask = "0000.00.00 (00:00)";
            txtExamDate.Name = "txtExamDate";
            txtExamDate.PromptChar = '-';
            txtExamDate.RightToLeft = RightToLeft.No;
            txtExamDate.Size = new Size (481, 46);
            txtExamDate.TabIndex = 43;
            txtExamDate.Tag = "";
            txtExamDate.Text = "130000000830";
            txtExamDate.TextAlign = HorizontalAlignment.Center;
            txtExamDate.ValidatingType = typeof (DateTime);
            txtExamDate.KeyDown += txtExamDate_KeyDown;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_OK, ToolStripMenuItem1, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (112, 54);
            // 
            // Menu_OK
            // 
            Menu_OK.Name = "Menu_OK";
            Menu_OK.Size = new Size (111, 22);
            Menu_OK.Text = "تاييد";
            Menu_OK.Click += Menu_OK_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (108, 6);
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (111, 22);
            Menu_Cancel.Text = "انصراف";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // frmDateTimeDialog
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size (501, 73);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (txtExamDate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDateTimeDialog";
            Opacity = 0.8D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تاريخ امتحان";
            Load += frmDateTimeDialog_Load;
            ContextMenuStrip1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal MaskedTextBox txtExamDate;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_OK;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Cancel;
        }
    }