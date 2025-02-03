using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmCNN : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmCNN));
            GridCNN = new DataGridView ();
            MenuStripCNN = new ContextMenuStrip (components);
            Menu_Select = new ToolStripMenuItem ();
            Menu_Edit = new ToolStripMenuItem ();
            ToolStripMenuItem3 = new ToolStripSeparator ();
            Menu_Guide = new ToolStripMenuItem ();
            Menu_Exit = new ToolStripMenuItem ();
            Label2 = new Label ();
            PasswordTextBox = new TextBox ();
            lstUsers = new ListBox ();
            MenuStripGroups = new ContextMenuStrip (components);
            Menu2_Guide = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu2_Exit = new ToolStripMenuItem ();
            panel1 = new Panel ();
            lblExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridCNN).BeginInit ();
            MenuStripCNN.SuspendLayout ();
            MenuStripGroups.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridCNN
            // 
            GridCNN.AllowUserToAddRows = false;
            GridCNN.AllowUserToDeleteRows = false;
            GridCNN.AllowUserToResizeColumns = false;
            GridCNN.AllowUserToResizeRows = false;
            GridCNN.BackgroundColor = Color.WhiteSmoke;
            GridCNN.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridCNN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridCNN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCNN.ColumnHeadersVisible = false;
            GridCNN.ContextMenuStrip = MenuStripCNN;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = Color.RoyalBlue;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridCNN.DefaultCellStyle = dataGridViewCellStyle2;
            GridCNN.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridCNN.GridColor = Color.WhiteSmoke;
            GridCNN.Location = new Point (13, 22);
            GridCNN.MultiSelect = false;
            GridCNN.Name = "GridCNN";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.InfoText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridCNN.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridCNN.RowHeadersVisible = false;
            GridCNN.RowHeadersWidth = 4;
            GridCNN.Size = new Size (385, 108);
            GridCNN.TabIndex = 3;
            GridCNN.CellDoubleClick += GridCNN_CellDoubleClick;
            GridCNN.Click += GridCNN_Click;
            GridCNN.KeyDown += GridCNN_KeyDown;
            // 
            // MenuStripCNN
            // 
            MenuStripCNN.Items.AddRange (new ToolStripItem [] { Menu_Select, Menu_Edit, ToolStripMenuItem3, Menu_Guide, Menu_Exit });
            MenuStripCNN.Name = "MenuStripCNN";
            MenuStripCNN.RightToLeft = RightToLeft.Yes;
            MenuStripCNN.Size = new Size (152, 98);
            // 
            // Menu_Select
            // 
            Menu_Select.Name = "Menu_Select";
            Menu_Select.Size = new Size (151, 22);
            Menu_Select.Text = "انتخاب / ادامه...";
            Menu_Select.Click += Menu_Select_Click;
            // 
            // Menu_Edit
            // 
            Menu_Edit.Name = "Menu_Edit";
            Menu_Edit.Size = new Size (151, 22);
            Menu_Edit.Text = "ويرايش";
            Menu_Edit.Visible = false;
            Menu_Edit.Click += Menu_Edit_Click;
            // 
            // ToolStripMenuItem3
            // 
            ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            ToolStripMenuItem3.Size = new Size (148, 6);
            // 
            // Menu_Guide
            // 
            Menu_Guide.Name = "Menu_Guide";
            Menu_Guide.Size = new Size (151, 22);
            Menu_Guide.Text = "راهنما";
            Menu_Guide.Visible = false;
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (151, 22);
            Menu_Exit.Text = "خروج";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // Label2
            // 
            Label2.BackColor = Color.White;
            Label2.Font = new Font ("Courier New", 14F);
            Label2.ForeColor = Color.IndianRed;
            Label2.Location = new Point (13, 317);
            Label2.Name = "Label2";
            Label2.RightToLeft = RightToLeft.No;
            Label2.Size = new Size (121, 23);
            Label2.TabIndex = 6;
            Label2.Text = "nexterm";
            Label2.TextAlign = ContentAlignment.MiddleLeft;
            Label2.DoubleClick += Label2_DoubleClick;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = Color.White;
            PasswordTextBox.BorderStyle = BorderStyle.None;
            PasswordTextBox.Font = new Font ("Courier New", 12F);
            PasswordTextBox.ForeColor = Color.IndianRed;
            PasswordTextBox.Location = new Point (13, 299);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '-';
            PasswordTextBox.Size = new Size (383, 19);
            PasswordTextBox.TabIndex = 10;
            PasswordTextBox.TextAlign = HorizontalAlignment.Center;
            PasswordTextBox.Visible = false;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
            // 
            // lstUsers
            // 
            lstUsers.BackColor = Color.WhiteSmoke;
            lstUsers.BorderStyle = BorderStyle.None;
            lstUsers.ContextMenuStrip = MenuStripGroups;
            lstUsers.Font = new Font ("Segoe UI", 10F);
            lstUsers.FormattingEnabled = true;
            lstUsers.ItemHeight = 17;
            lstUsers.Location = new Point (13, 140);
            lstUsers.Name = "lstUsers";
            lstUsers.RightToLeft = RightToLeft.Yes;
            lstUsers.Size = new Size (385, 153);
            lstUsers.TabIndex = 12;
            lstUsers.Visible = false;
            lstUsers.Click += lstUsers_Click;
            lstUsers.SelectedIndexChanged += lstUsers_SelectedIndexChanged;
            lstUsers.DoubleClick += lstUsers_DoubleClick;
            lstUsers.KeyDown += lstUsers_KeyDown;
            // 
            // MenuStripGroups
            // 
            MenuStripGroups.Items.AddRange (new ToolStripItem [] { Menu2_Guide, ToolStripMenuItem1, Menu2_Exit });
            MenuStripGroups.Name = "MenuStripGroups";
            MenuStripGroups.RightToLeft = RightToLeft.Yes;
            MenuStripGroups.Size = new Size (104, 54);
            // 
            // Menu2_Guide
            // 
            Menu2_Guide.Name = "Menu2_Guide";
            Menu2_Guide.Size = new Size (103, 22);
            Menu2_Guide.Text = "راهنما";
            Menu2_Guide.Click += Menu2_Guide_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (100, 6);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new Size (103, 22);
            Menu2_Exit.Text = "خروج";
            Menu2_Exit.Click += Menu2_Exit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblExit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 352);
            panel1.Name = "panel1";
            panel1.Size = new Size (408, 20);
            panel1.TabIndex = 13;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (0, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (408, 20);
            lblExit.TabIndex = 11;
            lblExit.Text = "خروج";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmCNN
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size (408, 372);
            ContextMenuStrip = MenuStripGroups;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (Label2);
            Controls.Add (lstUsers);
            Controls.Add (PasswordTextBox);
            Controls.Add (GridCNN);
            ForeColor = Color.DarkSlateGray;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCNN";
            StartPosition = FormStartPosition.CenterScreen;
            Load += cnn_Load;
            ((System.ComponentModel.ISupportInitialize) GridCNN).EndInit ();
            MenuStripCNN.ResumeLayout (false);
            MenuStripGroups.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal DataGridView GridCNN;
        internal ContextMenuStrip MenuStripCNN;
        internal ToolStripMenuItem Menu_SelectBE;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Exit;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem Menu_FindDB;
        internal ToolStripMenuItem Menu_AddCNN;
        internal ToolStripMenuItem Menu_Edit;
        internal ToolStripMenuItem Menu2_Guide;
        internal ToolStripMenuItem Menu_Guide;
        internal ToolStripSeparator ToolStripMenuItem3;
        internal Label Label2;
        internal Label Label5;
        internal TextBox PasswordTextBox;
        internal Label lblNewVersion;
        internal ListBox lstUsers;
        internal ToolStripMenuItem Menu_Select;
        internal ContextMenuStrip MenuStripGroups;
        internal ToolStripMenuItem Menu2_Exit;
        private Panel panel1;
        private Label lblExit;
        }
    }