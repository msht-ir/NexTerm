using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class TempList : Form
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
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Guide = new ToolStripMenuItem ();
            Menu_ReadFromFile = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_All = new ToolStripMenuItem ();
            Menu_InvertSelection = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_OK = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            GridCourse = new DataGridView ();
            Column1 = new DataGridViewTextBoxColumn ();
            Column2 = new DataGridViewTextBoxColumn ();
            Column3 = new DataGridViewTextBoxColumn ();
            Column5 = new DataGridViewTextBoxColumn ();
            Column4 = new DataGridViewTextBoxColumn ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            btnOK = new Button ();
            ContextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridCourse).BeginInit ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Guide, Menu_ReadFromFile, ToolStripMenuItem2, Menu_All, Menu_InvertSelection, ToolStripMenuItem1, Menu_OK, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (156, 148);
            // 
            // Menu_Guide
            // 
            Menu_Guide.Name = "Menu_Guide";
            Menu_Guide.Size = new Size (155, 22);
            Menu_Guide.Text = "راهنما";
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // Menu_ReadFromFile
            // 
            Menu_ReadFromFile.Name = "Menu_ReadFromFile";
            Menu_ReadFromFile.Size = new Size (155, 22);
            Menu_ReadFromFile.Text = "خواندن از فايل ...";
            Menu_ReadFromFile.Click += Menu_ReadFromFile_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (152, 6);
            // 
            // Menu_All
            // 
            Menu_All.Font = new Font ("Segoe UI", 9F);
            Menu_All.Name = "Menu_All";
            Menu_All.Size = new Size (155, 22);
            Menu_All.Text = "همه";
            Menu_All.Click += Menu_All_Click;
            // 
            // Menu_InvertSelection
            // 
            Menu_InvertSelection.Font = new Font ("Segoe UI", 9F);
            Menu_InvertSelection.Name = "Menu_InvertSelection";
            Menu_InvertSelection.Size = new Size (155, 22);
            Menu_InvertSelection.Text = "برعکس";
            Menu_InvertSelection.Click += Menu_InvertSelection_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (152, 6);
            // 
            // Menu_OK
            // 
            Menu_OK.Name = "Menu_OK";
            Menu_OK.Size = new Size (155, 22);
            Menu_OK.Text = "تاييد";
            Menu_OK.Click += Menu_OK_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (155, 22);
            Menu_Cancel.Text = "انصراف / خروج";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // GridCourse
            // 
            GridCourse.AllowUserToAddRows = false;
            GridCourse.AllowUserToResizeColumns = false;
            GridCourse.AllowUserToResizeRows = false;
            GridCourse.BackgroundColor = Color.WhiteSmoke;
            GridCourse.BorderStyle = BorderStyle.None;
            GridCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCourse.Columns.AddRange (new DataGridViewColumn [] { Column1, Column2, Column3, Column5, Column4 });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridCourse.DefaultCellStyle = dataGridViewCellStyle1;
            GridCourse.Dock = DockStyle.Top;
            GridCourse.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridCourse.GridColor = Color.WhiteSmoke;
            GridCourse.Location = new Point (0, 0);
            GridCourse.Name = "GridCourse";
            GridCourse.RightToLeft = RightToLeft.Yes;
            GridCourse.RowHeadersVisible = false;
            GridCourse.Size = new Size (460, 491);
            GridCourse.TabIndex = 0;
            GridCourse.CellClick += GridCourse_CellClick;
            GridCourse.CellContentDoubleClick += GridCourse_CellContentDoubleClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "";
            Column1.Name = "Column1";
            Column1.Width = 18;
            // 
            // Column2
            // 
            Column2.HeaderText = "شماره";
            Column2.Name = "Column2";
            Column2.Width = 90;
            // 
            // Column3
            // 
            Column3.HeaderText = "نام درس";
            Column3.Name = "Column3";
            Column3.Width = 210;
            // 
            // Column5
            // 
            Column5.HeaderText = "مشخصات";
            Column5.Name = "Column5";
            Column5.Width = 60;
            // 
            // Column4
            // 
            Column4.HeaderText = "واحد";
            Column4.Name = "Column4";
            Column4.Width = 35;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 552);
            panel1.Name = "panel1";
            panel1.Size = new Size (460, 20);
            panel1.TabIndex = 11;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (460, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point (182, 500);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size (101, 23);
            btnOK.TabIndex = 20;
            btnOK.Text = "تاييد";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // TempList
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (460, 572);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (btnOK);
            Controls.Add (panel1);
            Controls.Add (GridCourse);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TempList";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TempList";
            Load += TempList_Load;
            ContextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridCourse).EndInit ();
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_OK;
        internal ToolStripMenuItem Menu_Cancel;
        internal ToolStripMenuItem Menu_All;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_InvertSelection;
        internal ToolStripMenuItem Menu_ReadFromFile;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal DataGridView GridCourse;
        internal DataGridViewTextBoxColumn Column1;
        internal DataGridViewTextBoxColumn Column2;
        internal DataGridViewTextBoxColumn Column3;
        internal DataGridViewTextBoxColumn Column5;
        internal DataGridViewTextBoxColumn Column4;
        internal ToolStripMenuItem Menu_Guide;
        private Panel panel1;
        private Label lblCancel;
        private Button btnOK;
        }
    }