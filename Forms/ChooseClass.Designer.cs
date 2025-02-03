using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class ChooseClass : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (ChooseClass));
            GridRoom = new DataGridView ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            MenuOK = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            MenuAddNewClass = new ToolStripMenuItem ();
            Menu_Edit = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            MenuCancel = new ToolStripMenuItem ();
            Grid5 = new DataGridView ();
            DataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn ();
            DataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn ();
            lblInfo = new Label ();
            panel1 = new Panel ();
            lblCancel = new Label ();
            lblOK = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridRoom).BeginInit ();
            ContextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid5).BeginInit ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridRoom
            // 
            GridRoom.AllowUserToAddRows = false;
            GridRoom.AllowUserToDeleteRows = false;
            GridRoom.AllowUserToResizeColumns = false;
            GridRoom.AllowUserToResizeRows = false;
            GridRoom.BackgroundColor = Color.WhiteSmoke;
            GridRoom.BorderStyle = BorderStyle.None;
            GridRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridRoom.ContextMenuStrip = ContextMenuStrip1;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridRoom.DefaultCellStyle = dataGridViewCellStyle1;
            GridRoom.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridRoom.GridColor = SystemColors.Control;
            GridRoom.Location = new Point (419, 12);
            GridRoom.Name = "GridRoom";
            GridRoom.RightToLeft = RightToLeft.Yes;
            GridRoom.RowHeadersVisible = false;
            GridRoom.Size = new Size (364, 444);
            GridRoom.TabIndex = 11;
            GridRoom.Tag = "کلاس يا آزمايشگاه را انتخاب و تاييد کنيد";
            GridRoom.CellClick += GridRoom_CellClick;
            GridRoom.CellDoubleClick += GridRoom_CellDoubleClick;
            GridRoom.CellValueChanged += GridRoom_CellValueChanged;
            GridRoom.KeyDown += GridRoom_KeyDown;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { MenuOK, ToolStripMenuItem1, MenuAddNewClass, Menu_Edit, ToolStripMenuItem2, MenuCancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (139, 104);
            // 
            // MenuOK
            // 
            MenuOK.Name = "MenuOK";
            MenuOK.Size = new Size (138, 22);
            MenuOK.Text = "تاييد";
            MenuOK.Click += MenuOK_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (135, 6);
            // 
            // MenuAddNewClass
            // 
            MenuAddNewClass.Name = "MenuAddNewClass";
            MenuAddNewClass.Size = new Size (138, 22);
            MenuAddNewClass.Text = "+ کلاس جديد";
            MenuAddNewClass.Click += MenuAddNewClass_Click;
            // 
            // Menu_Edit
            // 
            Menu_Edit.Name = "Menu_Edit";
            Menu_Edit.Size = new Size (138, 22);
            Menu_Edit.Text = "ويرايش";
            Menu_Edit.Click += Menu_Edit_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (135, 6);
            // 
            // MenuCancel
            // 
            MenuCancel.ForeColor = Color.IndianRed;
            MenuCancel.Name = "MenuCancel";
            MenuCancel.Size = new Size (138, 22);
            MenuCancel.Text = "انصراف";
            MenuCancel.Click += MenuCancel_Click;
            // 
            // Grid5
            // 
            Grid5.AllowUserToAddRows = false;
            Grid5.AllowUserToDeleteRows = false;
            Grid5.AllowUserToResizeColumns = false;
            Grid5.AllowUserToResizeRows = false;
            Grid5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid5.BackgroundColor = Color.WhiteSmoke;
            Grid5.BorderStyle = BorderStyle.None;
            Grid5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid5.Columns.AddRange (new DataGridViewColumn [] { DataGridViewTextBoxColumn4, DataGridViewTextBoxColumn5, DataGridViewTextBoxColumn6, DataGridViewTextBoxColumn7, DataGridViewTextBoxColumn8, DataGridViewTextBoxColumn9, DataGridViewTextBoxColumn10, DataGridViewTextBoxColumn11, DataGridViewTextBoxColumn12 });
            Grid5.ContextMenuStrip = ContextMenuStrip1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Grid5.DefaultCellStyle = dataGridViewCellStyle2;
            Grid5.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid5.GridColor = SystemColors.Control;
            Grid5.Location = new Point (12, 12);
            Grid5.MultiSelect = false;
            Grid5.Name = "Grid5";
            Grid5.RightToLeft = RightToLeft.Yes;
            Grid5.RowHeadersVisible = false;
            Grid5.ShowCellToolTips = false;
            Grid5.Size = new Size (390, 185);
            Grid5.TabIndex = 36;
            Grid5.Tag = "نمايش برنامه کلاس يا آزمايشگاه در ترم انتخاب شده";
            Grid5.Visible = false;
            Grid5.CellClick += Grid5_CellClick;
            Grid5.CellDoubleClick += Grid5_CellDoubleClick;
            Grid5.KeyDown += Grid5_KeyDown;
            // 
            // DataGridViewTextBoxColumn4
            // 
            DataGridViewTextBoxColumn4.HeaderText = "روز";
            DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
            // 
            // DataGridViewTextBoxColumn5
            // 
            DataGridViewTextBoxColumn5.HeaderText = "08:30";
            DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
            // 
            // DataGridViewTextBoxColumn6
            // 
            DataGridViewTextBoxColumn6.HeaderText = "09:30";
            DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
            // 
            // DataGridViewTextBoxColumn7
            // 
            DataGridViewTextBoxColumn7.HeaderText = "10:30";
            DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
            // 
            // DataGridViewTextBoxColumn8
            // 
            DataGridViewTextBoxColumn8.HeaderText = "11:30";
            DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
            // 
            // DataGridViewTextBoxColumn9
            // 
            DataGridViewTextBoxColumn9.HeaderText = "13:30";
            DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
            // 
            // DataGridViewTextBoxColumn10
            // 
            DataGridViewTextBoxColumn10.HeaderText = "14:30";
            DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
            // 
            // DataGridViewTextBoxColumn11
            // 
            DataGridViewTextBoxColumn11.HeaderText = "15:30";
            DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11";
            // 
            // DataGridViewTextBoxColumn12
            // 
            DataGridViewTextBoxColumn12.HeaderText = "16:30";
            DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12";
            // 
            // lblInfo
            // 
            lblInfo.BackColor = Color.WhiteSmoke;
            lblInfo.Font = new Font ("Segoe UI", 9F);
            lblInfo.ForeColor = SystemColors.ControlText;
            lblInfo.Location = new Point (12, 216);
            lblInfo.Name = "lblInfo";
            lblInfo.RightToLeft = RightToLeft.Yes;
            lblInfo.Size = new Size (390, 240);
            lblInfo.TabIndex = 39;
            lblInfo.Text = "info";
            lblInfo.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Controls.Add (lblOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 495);
            panel1.Name = "panel1";
            panel1.Size = new Size (799, 20);
            panel1.TabIndex = 40;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Left;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (240, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // lblOK
            // 
            lblOK.BackColor = Color.WhiteSmoke;
            lblOK.Dock = DockStyle.Right;
            lblOK.Location = new Point (559, 0);
            lblOK.Name = "lblOK";
            lblOK.Size = new Size (240, 20);
            lblOK.TabIndex = 11;
            lblOK.Text = "تاييد";
            lblOK.TextAlign = ContentAlignment.MiddleCenter;
            lblOK.Click += lblOK_Click;
            // 
            // ChooseClass
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size (799, 515);
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (lblInfo);
            Controls.Add (GridRoom);
            Controls.Add (Grid5);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "ChooseClass";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "کلاس/ آزمايشگاه";
            Load += ChooseClass_Load;
            ((System.ComponentModel.ISupportInitialize) GridRoom).EndInit ();
            ContextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) Grid5).EndInit ();
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal DataGridView GridRoom;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem MenuOK;
        internal ToolStripMenuItem MenuCancel;
        internal ToolStripMenuItem MenuAddNewClass;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal DataGridView GridTime;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn4;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn8;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn9;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn10;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn11;
        internal DataGridViewTextBoxColumn DataGridViewTextBoxColumn12;
        internal DataGridView Grid5;
        internal ToolStripMenuItem Menu_Edit;
        internal Label lblInfo;
        private Panel panel1;
        private Label lblCancel;
        private Label lblOK;
        }
    }