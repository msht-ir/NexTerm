using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseCourse : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (ChooseCourse));
            ComboBioProg = new ComboBox ();
            GridCourse = new DataGridView ();
            ContextMenuCourses = new ContextMenuStrip (components);
            MenuOK = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            MenuAddCourse = new ToolStripMenuItem ();
            Menu_Edit = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            MenuCancel = new ToolStripMenuItem ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnSave = new Button ();
            ((System.ComponentModel.ISupportInitialize) GridCourse).BeginInit ();
            ContextMenuCourses.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ComboBioProg
            // 
            ComboBioProg.BackColor = SystemColors.Control;
            ComboBioProg.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBioProg.Font = new Font ("Segoe UI", 10F);
            ComboBioProg.FormattingEnabled = true;
            ComboBioProg.Location = new Point (12, 12);
            ComboBioProg.Name = "ComboBioProg";
            ComboBioProg.RightToLeft = RightToLeft.Yes;
            ComboBioProg.Size = new Size (438, 25);
            ComboBioProg.TabIndex = 5;
            ComboBioProg.SelectedIndexChanged += ComboBioProg_SelectedIndexChanged;
            // 
            // GridCourse
            // 
            GridCourse.AllowUserToAddRows = false;
            GridCourse.AllowUserToDeleteRows = false;
            GridCourse.AllowUserToResizeColumns = false;
            GridCourse.AllowUserToResizeRows = false;
            GridCourse.BackgroundColor = Color.WhiteSmoke;
            GridCourse.BorderStyle = BorderStyle.None;
            GridCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCourse.ContextMenuStrip = ContextMenuCourses;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridCourse.DefaultCellStyle = dataGridViewCellStyle1;
            GridCourse.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridCourse.GridColor = Color.WhiteSmoke;
            GridCourse.Location = new Point (12, 43);
            GridCourse.Name = "GridCourse";
            GridCourse.RightToLeft = RightToLeft.Yes;
            GridCourse.RowHeadersVisible = false;
            GridCourse.Size = new Size (438, 477);
            GridCourse.TabIndex = 8;
            GridCourse.CellDoubleClick += GridCourse_CellDoubleClick;
            GridCourse.CellValueChanged += GridCourse_CellValueChanged;
            GridCourse.KeyDown += GridCourse_KeyDown;
            // 
            // ContextMenuCourses
            // 
            ContextMenuCourses.Items.AddRange (new ToolStripItem [] { MenuOK, ToolStripMenuItem2, MenuAddCourse, Menu_Edit, ToolStripMenuItem1, MenuCancel });
            ContextMenuCourses.Name = "ContextMenuStrip1";
            ContextMenuCourses.RightToLeft = RightToLeft.Yes;
            ContextMenuCourses.Size = new Size (148, 104);
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
            // MenuAddCourse
            // 
            MenuAddCourse.Name = "MenuAddCourse";
            MenuAddCourse.Size = new Size (147, 22);
            MenuAddCourse.Text = "+ درس جديد";
            MenuAddCourse.Click += MenuAddCourse_Click;
            // 
            // Menu_Edit
            // 
            Menu_Edit.Name = "Menu_Edit";
            Menu_Edit.Size = new Size (147, 22);
            Menu_Edit.Text = "ويرايش";
            Menu_Edit.Click += Menu_Edit_Click;
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
            MenuCancel.Text = "خروج / انصراف";
            MenuCancel.Click += MenuCancel_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 590);
            panel1.Name = "panel1";
            panel1.Size = new Size (462, 20);
            panel1.TabIndex = 41;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (462, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point (146, 535);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (170, 23);
            btnSave.TabIndex = 42;
            btnSave.Text = "تاييد";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChooseCourse
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (462, 610);
            ControlBox = false;
            Controls.Add (btnSave);
            Controls.Add (panel1);
            Controls.Add (GridCourse);
            Controls.Add (ComboBioProg);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseCourse";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "انتخاب درس";
            Load += ChooseCourse_Load;
            ((System.ComponentModel.ISupportInitialize) GridCourse).EndInit ();
            ContextMenuCourses.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ComboBox ComboBioProg;
        internal DataGridView GridCourse;
        internal ContextMenuStrip ContextMenuCourses;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripMenuItem MenuCancel;
        internal ToolStripMenuItem MenuAddCourse;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Edit;
        private Panel panel1;
        private Label lblCancel;
        private Button btnSave;
        }
    }