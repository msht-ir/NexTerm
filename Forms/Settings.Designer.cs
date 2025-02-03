using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class Settings : Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (Settings));
            GridSettings = new DataGridView ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_ExitSetup = new ToolStripMenuItem ();
            txtCMD = new TextBox ();
            ((System.ComponentModel.ISupportInitialize) GridSettings).BeginInit ();
            ContextMenuStrip1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridSettings
            // 
            GridSettings.AllowUserToAddRows = false;
            GridSettings.AllowUserToDeleteRows = false;
            GridSettings.AllowUserToOrderColumns = true;
            GridSettings.AllowUserToResizeColumns = false;
            GridSettings.AllowUserToResizeRows = false;
            GridSettings.BackgroundColor = SystemColors.Control;
            GridSettings.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridSettings.DefaultCellStyle = dataGridViewCellStyle2;
            GridSettings.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridSettings.GridColor = SystemColors.Control;
            GridSettings.Location = new Point (12, 13);
            GridSettings.Name = "GridSettings";
            GridSettings.RowHeadersVisible = false;
            GridSettings.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridSettings.Size = new Size (695, 305);
            GridSettings.TabIndex = 12;
            GridSettings.TabStop = false;
            GridSettings.CellDoubleClick += GridSettings_CellDoubleClick;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_ExitSetup });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (145, 26);
            // 
            // Menu_ExitSetup
            // 
            Menu_ExitSetup.ForeColor = SystemColors.ControlText;
            Menu_ExitSetup.Name = "Menu_ExitSetup";
            Menu_ExitSetup.Size = new Size (144, 22);
            Menu_ExitSetup.Text = "تاييد / بازگشت";
            Menu_ExitSetup.Click += Menu_ExitSetup_Click;
            // 
            // txtCMD
            // 
            txtCMD.BackColor = Color.FromArgb (  248,   248,   248);
            txtCMD.BorderStyle = BorderStyle.None;
            txtCMD.Font = new Font ("Segoe UI", 12F, FontStyle.Italic);
            txtCMD.ForeColor = SystemColors.HotTrack;
            txtCMD.Location = new Point (12, 336);
            txtCMD.Name = "txtCMD";
            txtCMD.Size = new Size (695, 22);
            txtCMD.TabIndex = 0;
            txtCMD.TextChanged += txtCMD_TextChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (719, 370);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (txtCMD);
            Controls.Add (GridSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تنظيمات";
            FormClosing += Settings_FormClosing;
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize) GridSettings).EndInit ();
            ContextMenuStrip1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal DataGridView GridSettings;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_ExitSetup;
        internal TextBox txtCMD;
        }
    }