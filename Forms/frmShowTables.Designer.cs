using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmShowTables : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmShowTables));
            Grid1 = new DataGridView ();
            ContextMenuCourses = new ContextMenuStrip (components);
            Menu_AddNew = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Exit = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            btnOkExit = new Button ();
            ((System.ComponentModel.ISupportInitialize) Grid1).BeginInit ();
            ContextMenuCourses.SuspendLayout ();
            SuspendLayout ();
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.AllowUserToResizeColumns = false;
            Grid1.AllowUserToResizeRows = false;
            Grid1.BackgroundColor = Color.WhiteSmoke;
            Grid1.BorderStyle = BorderStyle.None;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Grid1.ContextMenuStrip = ContextMenuCourses;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            Grid1.DefaultCellStyle = dataGridViewCellStyle1;
            Grid1.Dock = DockStyle.Top;
            Grid1.GridColor = SystemColors.ControlLight;
            Grid1.Location = new Point (0, 0);
            Grid1.MultiSelect = false;
            Grid1.Name = "Grid1";
            Grid1.RightToLeft = RightToLeft.Yes;
            Grid1.RowHeadersVisible = false;
            Grid1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Grid1.Size = new Size (559, 536);
            Grid1.TabIndex = 0;
            Grid1.CellValueChanged += Grid1_CellValueChanged;
            // 
            // ContextMenuCourses
            // 
            ContextMenuCourses.Items.AddRange (new ToolStripItem [] { Menu_AddNew, ToolStripMenuItem1, Menu_Exit, Menu_Cancel });
            ContextMenuCourses.Name = "ContextMenuStrip1";
            ContextMenuCourses.RightToLeft = RightToLeft.Yes;
            ContextMenuCourses.Size = new Size (161, 76);
            // 
            // Menu_AddNew
            // 
            Menu_AddNew.Name = "Menu_AddNew";
            Menu_AddNew.Size = new Size (160, 22);
            Menu_AddNew.Text = "افزودن درس جديد";
            Menu_AddNew.Click += Menu_AddNewItem;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (157, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (160, 22);
            Menu_Exit.Text = "انتخاب / تاييد";
            Menu_Exit.Click += PopMenu_Exit;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (160, 22);
            Menu_Cancel.Text = "انصراف / خروج";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // btnOkExit
            // 
            btnOkExit.BackColor = SystemColors.Control;
            btnOkExit.Location = new Point (204, 545);
            btnOkExit.Name = "btnOkExit";
            btnOkExit.Size = new Size (143, 25);
            btnOkExit.TabIndex = 9;
            btnOkExit.Text = "انتخاب / تاييد";
            btnOkExit.UseVisualStyleBackColor = false;
            btnOkExit.Click += btnOkExit_Click;
            // 
            // frmShowTables
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (559, 579);
            ControlBox = false;
            Controls.Add (btnOkExit);
            Controls.Add (Grid1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmShowTables";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "درس ها";
            Load += frmShowTables_Load;
            ((System.ComponentModel.ISupportInitialize) Grid1).EndInit ();
            ContextMenuCourses.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal DataGridView Grid1;
        internal ContextMenuStrip ContextMenuCourses;
        internal ToolStripMenuItem Menu_Exit;
        internal ToolStripMenuItem Menu_AddNew;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal Button btnOkExit;
        internal ToolStripMenuItem Menu_Cancel;
        }
    }