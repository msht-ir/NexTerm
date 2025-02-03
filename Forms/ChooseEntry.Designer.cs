using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseEntry : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (ChooseEntry));
            ComboDepts = new ComboBox ();
            GridEntries = new DataGridView ();
            ContextMenuStripEntries = new ContextMenuStrip (components);
            MenuAddNewEntry = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            MenuOK = new ToolStripMenuItem ();
            MenuCancel = new ToolStripMenuItem ();
            ListBioProgs = new ListBox ();
            ContextMenu2 = new ContextMenuStrip (components);
            Menu2_Exit = new ToolStripMenuItem ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnSave = new Button ();
            ((System.ComponentModel.ISupportInitialize) GridEntries).BeginInit ();
            ContextMenuStripEntries.SuspendLayout ();
            ContextMenu2.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ComboDepts
            // 
            ComboDepts.BackColor = Color.WhiteSmoke;
            ComboDepts.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboDepts.FlatStyle = FlatStyle.Flat;
            ComboDepts.FormattingEnabled = true;
            ComboDepts.Location = new Point (458, 12);
            ComboDepts.Name = "ComboDepts";
            ComboDepts.RightToLeft = RightToLeft.Yes;
            ComboDepts.Size = new Size (277, 23);
            ComboDepts.TabIndex = 0;
            ComboDepts.SelectedIndexChanged += ComboDepts_SelectedIndexChanged;
            // 
            // GridEntries
            // 
            GridEntries.AllowUserToAddRows = false;
            GridEntries.AllowUserToDeleteRows = false;
            GridEntries.AllowUserToResizeColumns = false;
            GridEntries.AllowUserToResizeRows = false;
            GridEntries.BackgroundColor = SystemColors.Control;
            GridEntries.BorderStyle = BorderStyle.None;
            GridEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridEntries.ContextMenuStrip = ContextMenuStripEntries;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridEntries.DefaultCellStyle = dataGridViewCellStyle1;
            GridEntries.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridEntries.GridColor = SystemColors.Control;
            GridEntries.Location = new Point (12, 12);
            GridEntries.Name = "GridEntries";
            GridEntries.RightToLeft = RightToLeft.Yes;
            GridEntries.RowHeadersVisible = false;
            GridEntries.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridEntries.Size = new Size (430, 360);
            GridEntries.TabIndex = 0;
            GridEntries.CellDoubleClick += GridEntries_CellDoubleClick;
            GridEntries.CellValueChanged += GridEntries_CellValueChanged;
            GridEntries.KeyDown += GridEntries_KeyDown;
            // 
            // ContextMenuStripEntries
            // 
            ContextMenuStripEntries.Items.AddRange (new ToolStripItem [] { MenuAddNewEntry, ToolStripMenuItem2, MenuOK, MenuCancel });
            ContextMenuStripEntries.Name = "ContextMenuStrip1";
            ContextMenuStripEntries.RightToLeft = RightToLeft.Yes;
            ContextMenuStripEntries.Size = new Size (143, 76);
            // 
            // MenuAddNewEntry
            // 
            MenuAddNewEntry.Name = "MenuAddNewEntry";
            MenuAddNewEntry.Size = new Size (142, 22);
            MenuAddNewEntry.Text = "+ ورودي جديد";
            MenuAddNewEntry.Click += MenuAddNewEntry_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (139, 6);
            // 
            // MenuOK
            // 
            MenuOK.Name = "MenuOK";
            MenuOK.Size = new Size (142, 22);
            MenuOK.Text = "تاييد";
            MenuOK.Click += MenuOK_Click;
            // 
            // MenuCancel
            // 
            MenuCancel.ForeColor = Color.IndianRed;
            MenuCancel.Name = "MenuCancel";
            MenuCancel.Size = new Size (142, 22);
            MenuCancel.Text = "انصراف";
            MenuCancel.Click += MenuCancel_Click;
            // 
            // ListBioProgs
            // 
            ListBioProgs.BackColor = SystemColors.ControlLightLight;
            ListBioProgs.BorderStyle = BorderStyle.None;
            ListBioProgs.ContextMenuStrip = ContextMenu2;
            ListBioProgs.Font = new Font ("Segoe UI", 10F, FontStyle.Bold);
            ListBioProgs.ForeColor = Color.IndianRed;
            ListBioProgs.FormattingEnabled = true;
            ListBioProgs.ItemHeight = 17;
            ListBioProgs.Location = new Point (458, 42);
            ListBioProgs.Name = "ListBioProgs";
            ListBioProgs.RightToLeft = RightToLeft.Yes;
            ListBioProgs.Size = new Size (277, 306);
            ListBioProgs.TabIndex = 16;
            ListBioProgs.Click += ListBioProgs_Click;
            ListBioProgs.KeyDown += ListBioProgs_KeyDown;
            // 
            // ContextMenu2
            // 
            ContextMenu2.Items.AddRange (new ToolStripItem [] { Menu2_Exit });
            ContextMenu2.Name = "ContextMenuStrip1";
            ContextMenu2.RightToLeft = RightToLeft.Yes;
            ContextMenu2.Size = new Size (100, 26);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new Size (99, 22);
            Menu2_Exit.Text = "خروج";
            Menu2_Exit.Click += Menu2_Exit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 427);
            panel1.Name = "panel1";
            panel1.Size = new Size (756, 20);
            panel1.TabIndex = 17;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (756, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point (178, 378);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (101, 23);
            btnSave.TabIndex = 18;
            btnSave.Text = "تاييد";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChooseEntry
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size (756, 447);
            ControlBox = false;
            Controls.Add (btnSave);
            Controls.Add (panel1);
            Controls.Add (ListBioProgs);
            Controls.Add (ComboDepts);
            Controls.Add (GridEntries);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "ChooseEntry";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ورودي";
            Load += ChooseEntry_Load;
            ((System.ComponentModel.ISupportInitialize) GridEntries).EndInit ();
            ContextMenuStripEntries.ResumeLayout (false);
            ContextMenu2.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ComboBox ComboDepts;
        internal DataGridView GridEntries;
        internal ListBox ListBioProgs;
        internal ContextMenuStrip ContextMenuStripEntries;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripMenuItem MenuAddNewEntry;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem MenuCancel;
        internal ContextMenuStrip ContextMenu2;
        internal ToolStripMenuItem Menu2_Exit;
        private Panel panel1;
        private Label lblCancel;
        private Button btnSave;
        }
    }