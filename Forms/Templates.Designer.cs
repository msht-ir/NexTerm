using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class Templates : Form
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (Templates));
            GridTemplateData = new DataGridView ();
            ContextMenuTempData = new ContextMenuStrip (components);
            Menu_AddCourse = new ToolStripMenuItem ();
            ToolStripMenuItem3 = new ToolStripSeparator ();
            Menu_DelCourse = new ToolStripMenuItem ();
            GridTemplates = new DataGridView ();
            ContextMenuTemp = new ContextMenuStrip (components);
            Menu_AddNew = new ToolStripMenuItem ();
            Menu_Del = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_ReportMe = new ToolStripMenuItem ();
            Menu_Apply = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Guide = new ToolStripMenuItem ();
            Menu_ExitBack = new ToolStripMenuItem ();
            ExitToolStripMenuItem = new ToolStripMenuItem ();
            ComboDepts = new ComboBox ();
            txtTerm = new TextBox ();
            Label4 = new Label ();
            chkAsk = new CheckBox ();
            Panel1 = new Panel ();
            Panel2 = new Panel ();
            btnExit = new Button ();
            Label1 = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridTemplateData).BeginInit ();
            ContextMenuTempData.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridTemplates).BeginInit ();
            ContextMenuTemp.SuspendLayout ();
            Panel1.SuspendLayout ();
            Panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridTemplateData
            // 
            GridTemplateData.AllowUserToAddRows = false;
            GridTemplateData.AllowUserToDeleteRows = false;
            GridTemplateData.AllowUserToOrderColumns = true;
            GridTemplateData.AllowUserToResizeColumns = false;
            GridTemplateData.AllowUserToResizeRows = false;
            GridTemplateData.BackgroundColor = Color.WhiteSmoke;
            GridTemplateData.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridTemplateData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridTemplateData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTemplateData.ContextMenuStrip = ContextMenuTempData;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridTemplateData.DefaultCellStyle = dataGridViewCellStyle2;
            GridTemplateData.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTemplateData.GridColor = Color.WhiteSmoke;
            GridTemplateData.Location = new Point (12, 53);
            GridTemplateData.Name = "GridTemplateData";
            GridTemplateData.RightToLeft = RightToLeft.Yes;
            GridTemplateData.Size = new Size (523, 566);
            GridTemplateData.TabIndex = 0;
            GridTemplateData.CellDoubleClick += Grid2_DoubleClick;
            // 
            // ContextMenuTempData
            // 
            ContextMenuTempData.Items.AddRange (new ToolStripItem [] { Menu_AddCourse, ToolStripMenuItem3, Menu_DelCourse });
            ContextMenuTempData.Name = "ContextMenuStrip3";
            ContextMenuTempData.RightToLeft = RightToLeft.Yes;
            ContextMenuTempData.Size = new Size (170, 54);
            // 
            // Menu_AddCourse
            // 
            Menu_AddCourse.ForeColor = SystemColors.ControlText;
            Menu_AddCourse.Name = "Menu_AddCourse";
            Menu_AddCourse.Size = new Size (169, 22);
            Menu_AddCourse.Text = "افزودن درس به الگو";
            Menu_AddCourse.Click += Menu_AddCourse_Click;
            // 
            // ToolStripMenuItem3
            // 
            ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            ToolStripMenuItem3.Size = new Size (166, 6);
            // 
            // Menu_DelCourse
            // 
            Menu_DelCourse.ForeColor = SystemColors.ControlText;
            Menu_DelCourse.Name = "Menu_DelCourse";
            Menu_DelCourse.Size = new Size (169, 22);
            Menu_DelCourse.Text = "حذف درس از الگو";
            Menu_DelCourse.Click += Menu_DelCourse_Click;
            // 
            // GridTemplates
            // 
            GridTemplates.AllowUserToAddRows = false;
            GridTemplates.AllowUserToDeleteRows = false;
            GridTemplates.AllowUserToOrderColumns = true;
            GridTemplates.AllowUserToResizeColumns = false;
            GridTemplates.AllowUserToResizeRows = false;
            GridTemplates.BackgroundColor = Color.WhiteSmoke;
            GridTemplates.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridTemplates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTemplates.ContextMenuStrip = ContextMenuTemp;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            GridTemplates.DefaultCellStyle = dataGridViewCellStyle4;
            GridTemplates.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridTemplates.GridColor = Color.WhiteSmoke;
            GridTemplates.Location = new Point (557, 53);
            GridTemplates.Name = "GridTemplates";
            GridTemplates.RightToLeft = RightToLeft.Yes;
            GridTemplates.Size = new Size (543, 566);
            GridTemplates.TabIndex = 1;
            GridTemplates.CellClick += Grid1;
            GridTemplates.CellDoubleClick += GridTemplates_CellDoubleClick;
            GridTemplates.KeyDown += GridTemplates_KeyDown;
            // 
            // ContextMenuTemp
            // 
            ContextMenuTemp.Items.AddRange (new ToolStripItem [] { Menu_AddNew, Menu_Del, ToolStripMenuItem2, Menu_ReportMe, Menu_Apply, ToolStripMenuItem1, Menu_Guide, Menu_ExitBack });
            ContextMenuTemp.Name = "ContextMenuStrip3";
            ContextMenuTemp.RightToLeft = RightToLeft.Yes;
            ContextMenuTemp.Size = new Size (129, 148);
            // 
            // Menu_AddNew
            // 
            Menu_AddNew.Name = "Menu_AddNew";
            Menu_AddNew.Size = new Size (128, 22);
            Menu_AddNew.Text = "الگوي جديد";
            Menu_AddNew.Click += Menu_AddNew_Click;
            // 
            // Menu_Del
            // 
            Menu_Del.Name = "Menu_Del";
            Menu_Del.Size = new Size (128, 22);
            Menu_Del.Text = "حذف الگو";
            Menu_Del.Click += Menu_Del_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (125, 6);
            // 
            // Menu_ReportMe
            // 
            Menu_ReportMe.ForeColor = SystemColors.ControlText;
            Menu_ReportMe.Name = "Menu_ReportMe";
            Menu_ReportMe.Size = new Size (128, 22);
            Menu_ReportMe.Text = "گزارش";
            Menu_ReportMe.Click += Menu_ReportMe_Click;
            // 
            // Menu_Apply
            // 
            Menu_Apply.ForeColor = SystemColors.ControlText;
            Menu_Apply.Name = "Menu_Apply";
            Menu_Apply.Size = new Size (128, 22);
            Menu_Apply.Text = "بکارگيري";
            Menu_Apply.Click += Menu_Apply_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (125, 6);
            // 
            // Menu_Guide
            // 
            Menu_Guide.AccessibleRole = AccessibleRole.OutlineButton;
            Menu_Guide.Name = "Menu_Guide";
            Menu_Guide.Size = new Size (128, 22);
            Menu_Guide.Text = "راهنما";
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // Menu_ExitBack
            // 
            Menu_ExitBack.ForeColor = Color.IndianRed;
            Menu_ExitBack.Name = "Menu_ExitBack";
            Menu_ExitBack.Size = new Size (128, 22);
            Menu_ExitBack.Text = "خروج";
            Menu_ExitBack.Click += Menu_ExitBack_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size (180, 22);
            ExitToolStripMenuItem.Text = "خروج";
            // 
            // ComboDepts
            // 
            ComboDepts.BackColor = Color.WhiteSmoke;
            ComboDepts.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboDepts.FlatStyle = FlatStyle.Flat;
            ComboDepts.FormattingEnabled = true;
            ComboDepts.Location = new Point (804, 12);
            ComboDepts.Name = "ComboDepts";
            ComboDepts.RightToLeft = RightToLeft.Yes;
            ComboDepts.Size = new Size (296, 23);
            ComboDepts.TabIndex = 5;
            ComboDepts.SelectedIndexChanged += ComboDepts_SelectedIndexChanged;
            // 
            // txtTerm
            // 
            txtTerm.BackColor = Color.White;
            txtTerm.Font = new Font ("Segoe UI", 8F);
            txtTerm.Location = new Point (151, 14);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size (37, 22);
            txtTerm.TabIndex = 9;
            txtTerm.Text = "1";
            txtTerm.TextAlign = HorizontalAlignment.Center;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.ForeColor = SystemColors.ControlText;
            Label4.Location = new Point (193, 15);
            Label4.Name = "Label4";
            Label4.Size = new Size (71, 15);
            Label4.TabIndex = 10;
            Label4.Text = "افزودن به ترم";
            // 
            // chkAsk
            // 
            chkAsk.AutoSize = true;
            chkAsk.ForeColor = SystemColors.ControlText;
            chkAsk.Location = new Point (23, 16);
            chkAsk.Name = "chkAsk";
            chkAsk.RightToLeft = RightToLeft.Yes;
            chkAsk.Size = new Size (52, 19);
            chkAsk.TabIndex = 11;
            chkAsk.Text = "بپرس";
            chkAsk.TextAlign = ContentAlignment.MiddleRight;
            chkAsk.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add (ComboDepts);
            Panel1.Controls.Add (chkAsk);
            Panel1.Controls.Add (txtTerm);
            Panel1.Controls.Add (Label4);
            Panel1.Dock = DockStyle.Top;
            Panel1.ForeColor = SystemColors.ControlText;
            Panel1.Location = new Point (0, 0);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size (1114, 47);
            Panel1.TabIndex = 12;
            // 
            // Panel2
            // 
            Panel2.BackColor = Color.White;
            Panel2.Controls.Add (btnExit);
            Panel2.Controls.Add (Label1);
            Panel2.Controls.Add (Panel1);
            Panel2.Controls.Add (GridTemplates);
            Panel2.Controls.Add (GridTemplateData);
            Panel2.Dock = DockStyle.Fill;
            Panel2.Location = new Point (0, 0);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size (1114, 656);
            Panel2.TabIndex = 13;
            // 
            // btnExit
            // 
            btnExit.ForeColor = Color.IndianRed;
            btnExit.Location = new Point (917, 625);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size (185, 23);
            btnExit.TabIndex = 48;
            btnExit.Text = "خروج";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.BackColor = Color.Transparent;
            Label1.Font = new Font ("Courier New", 14F);
            Label1.ForeColor = Color.DarkGoldenrod;
            Label1.Location = new Point (23, 622);
            Label1.Name = "Label1";
            Label1.RightToLeft = RightToLeft.No;
            Label1.Size = new Size (87, 21);
            Label1.TabIndex = 13;
            Label1.Text = "nexterm";
            // 
            // Templates
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Goldenrod;
            ClientSize = new Size (1114, 656);
            ControlBox = false;
            Controls.Add (Panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "Templates";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "برنامه هاي ترميک (الگوها)";
            Load += Templates_Load;
            ((System.ComponentModel.ISupportInitialize) GridTemplateData).EndInit ();
            ContextMenuTempData.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridTemplates).EndInit ();
            ContextMenuTemp.ResumeLayout (false);
            Panel1.ResumeLayout (false);
            Panel1.PerformLayout ();
            Panel2.ResumeLayout (false);
            Panel2.PerformLayout ();
            ResumeLayout (false);
            }

        internal DataGridView GridTemplateData;
        internal DataGridView GridTemplates;
        internal ToolStripMenuItem الگوهاToolStripMenuItem;
        internal ToolStripMenuItem ExitToolStripMenuItem;
        internal ComboBox ComboDepts;
        internal ToolStripMenuItem Menu_Report;
        internal Label Label2;
        internal TextBox txtTerm;
        internal Label Label4;
        internal CheckBox chkAsk;
        internal ContextMenuStrip ContextMenuTempData;
        internal ToolStripMenuItem Menu_AddCourse;
        internal ToolStripMenuItem Menu_DelCourse;
        internal ContextMenuStrip ContextMenuTemp;
        internal ToolStripMenuItem Menu_AddNew;
        internal ToolStripMenuItem Menu_Del;
        internal ToolStripMenuItem Menu_Apply;
        internal ToolStripMenuItem Menu_ReportMe;
        internal ToolStripMenuItem Menu_ExitBack;
        internal Panel Panel1;
        internal Panel Panel2;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripSeparator ToolStripMenuItem3;
        internal Label Label1;
        internal ToolStripMenuItem Menu_Guide;
        internal ToolStripSeparator ToolStripMenuItem1;
        private Button btnExit;
        }
    }