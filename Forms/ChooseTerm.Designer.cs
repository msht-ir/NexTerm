using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseTerm : Form
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
            Grid1 = new DataGridView ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_OK = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_Edit = new ToolStripMenuItem ();
            Menu_Add = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Cancel = new ToolStripMenuItem ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnSave = new Button ();
            ((System.ComponentModel.ISupportInitialize) Grid1).BeginInit ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.AllowUserToResizeColumns = false;
            Grid1.AllowUserToResizeRows = false;
            Grid1.BackgroundColor = SystemColors.Control;
            Grid1.BorderStyle = BorderStyle.None;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            Grid1.ContextMenuStrip = ContextMenuStrip1;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            Grid1.DefaultCellStyle = dataGridViewCellStyle1;
            Grid1.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid1.GridColor = SystemColors.ControlLight;
            Grid1.Location = new Point (12, 12);
            Grid1.MultiSelect = false;
            Grid1.Name = "Grid1";
            Grid1.RowHeadersVisible = false;
            Grid1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Grid1.Size = new Size (352, 449);
            Grid1.TabIndex = 10;
            Grid1.CellValueChanged += Grid1_CellValueChanged;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_OK, ToolStripMenuItem2, Menu_Edit, Menu_Add, ToolStripMenuItem1, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (148, 104);
            // 
            // Menu_OK
            // 
            Menu_OK.Name = "Menu_OK";
            Menu_OK.Size = new Size (147, 22);
            Menu_OK.Text = "انتخاب / تاييد";
            Menu_OK.Click += Menu_OK_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (144, 6);
            // 
            // Menu_Edit
            // 
            Menu_Edit.Name = "Menu_Edit";
            Menu_Edit.Size = new Size (147, 22);
            Menu_Edit.Text = "ويرايش / تغيير";
            Menu_Edit.Click += Menu_Edit_Click;
            // 
            // Menu_Add
            // 
            Menu_Add.Name = "Menu_Add";
            Menu_Add.Size = new Size (147, 22);
            Menu_Add.Text = "افزودن";
            Menu_Add.Click += Menu_Add_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (144, 6);
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (147, 22);
            Menu_Cancel.Text = "انصراف / خروج";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 523);
            panel1.Name = "panel1";
            panel1.Size = new Size (377, 20);
            panel1.TabIndex = 11;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (377, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point (139, 474);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (101, 23);
            btnSave.TabIndex = 16;
            btnSave.Text = "تاييد";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChooseTerm
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (377, 543);
            ControlBox = false;
            Controls.Add (btnSave);
            Controls.Add (panel1);
            Controls.Add (Grid1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseTerm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ترم";
            Load += ChooseTerm_Load;
            ((System.ComponentModel.ISupportInitialize) Grid1).EndInit ();
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal DataGridView Grid1;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Add;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_OK;
        internal ToolStripMenuItem Menu_Cancel;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem Menu_Edit;
        private Panel panel1;
        private Label lblCancel;
        private Button btnSave;
        }
    }