using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmDeptEdit : Form
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
            txtDeptName = new TextBox ();
            txtDeptPass = new TextBox ();
            Label1 = new Label ();
            Label2 = new Label ();
            Label3 = new Label ();
            txtDeptNote = new TextBox ();
            CheckDeptActive = new CheckBox ();
            CheckDeptAcc1 = new CheckBox ();
            CheckDeptAcc2 = new CheckBox ();
            CheckDeptAcc3 = new CheckBox ();
            CheckDeptAcc4 = new CheckBox ();
            CheckDeptAcc5 = new CheckBox ();
            Panel1 = new Panel ();
            btnSave = new Button ();
            panel2 = new Panel ();
            lblCancel = new Label ();
            CheckDeptAcc7 = new CheckBox ();
            CheckDeptAcc6 = new CheckBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Save = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            Panel1.SuspendLayout ();
            panel2.SuspendLayout ();
            ContextMenuStrip1.SuspendLayout ();
            SuspendLayout ();
            // 
            // txtDeptName
            // 
            txtDeptName.BackColor = Color.White;
            txtDeptName.BorderStyle = BorderStyle.None;
            txtDeptName.Font = new Font ("Segoe UI", 10F);
            txtDeptName.Location = new Point (211, 16);
            txtDeptName.Name = "txtDeptName";
            txtDeptName.RightToLeft = RightToLeft.Yes;
            txtDeptName.Size = new Size (232, 18);
            txtDeptName.TabIndex = 0;
            // 
            // txtDeptPass
            // 
            txtDeptPass.BackColor = Color.White;
            txtDeptPass.BorderStyle = BorderStyle.None;
            txtDeptPass.Font = new Font ("Segoe UI", 10F);
            txtDeptPass.ForeColor = Color.IndianRed;
            txtDeptPass.Location = new Point (23, 14);
            txtDeptPass.Name = "txtDeptPass";
            txtDeptPass.Size = new Size (128, 18);
            txtDeptPass.TabIndex = 1;
            txtDeptPass.TextAlign = HorizontalAlignment.Center;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point (449, 16);
            Label1.Name = "Label1";
            Label1.Size = new Size (86, 15);
            Label1.TabIndex = 2;
            Label1.Text = "نام گروه آموزشي";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point (157, 14);
            Label2.Name = "Label2";
            Label2.Size = new Size (37, 15);
            Label2.TabIndex = 3;
            Label2.Text = "پسورد";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Location = new Point (449, 58);
            Label3.Name = "Label3";
            Label3.Size = new Size (54, 15);
            Label3.TabIndex = 5;
            Label3.Text = "توضيحات";
            // 
            // txtDeptNote
            // 
            txtDeptNote.BackColor = Color.White;
            txtDeptNote.BorderStyle = BorderStyle.None;
            txtDeptNote.Font = new Font ("Segoe UI", 10F);
            txtDeptNote.Location = new Point (23, 58);
            txtDeptNote.Name = "txtDeptNote";
            txtDeptNote.RightToLeft = RightToLeft.Yes;
            txtDeptNote.Size = new Size (420, 18);
            txtDeptNote.TabIndex = 4;
            // 
            // CheckDeptActive
            // 
            CheckDeptActive.AutoSize = true;
            CheckDeptActive.ForeColor = Color.SteelBlue;
            CheckDeptActive.Location = new Point (407, 20);
            CheckDeptActive.Name = "CheckDeptActive";
            CheckDeptActive.RightToLeft = RightToLeft.Yes;
            CheckDeptActive.Size = new Size (80, 19);
            CheckDeptActive.TabIndex = 6;
            CheckDeptActive.Text = "اکانت فعال";
            CheckDeptActive.UseVisualStyleBackColor = true;
            // 
            // CheckDeptAcc1
            // 
            CheckDeptAcc1.Location = new Point (46, 54);
            CheckDeptAcc1.Name = "CheckDeptAcc1";
            CheckDeptAcc1.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc1.Size = new Size (415, 19);
            CheckDeptAcc1.TabIndex = 7;
            CheckDeptAcc1.Text = "ويرايش مشخصات درس ها";
            CheckDeptAcc1.UseVisualStyleBackColor = true;
            // 
            // CheckDeptAcc2
            // 
            CheckDeptAcc2.Location = new Point (46, 82);
            CheckDeptAcc2.Name = "CheckDeptAcc2";
            CheckDeptAcc2.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc2.Size = new Size (415, 19);
            CheckDeptAcc2.TabIndex = 8;
            CheckDeptAcc2.Text = "ويرايش نام استاد / کارشناس";
            CheckDeptAcc2.UseVisualStyleBackColor = true;
            // 
            // CheckDeptAcc3
            // 
            CheckDeptAcc3.Location = new Point (46, 107);
            CheckDeptAcc3.Name = "CheckDeptAcc3";
            CheckDeptAcc3.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc3.Size = new Size (415, 19);
            CheckDeptAcc3.TabIndex = 9;
            CheckDeptAcc3.Text = "کلاس بندي";
            CheckDeptAcc3.UseVisualStyleBackColor = true;
            // 
            // CheckDeptAcc4
            // 
            CheckDeptAcc4.Location = new Point (46, 132);
            CheckDeptAcc4.Name = "CheckDeptAcc4";
            CheckDeptAcc4.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc4.Size = new Size (415, 19);
            CheckDeptAcc4.TabIndex = 10;
            CheckDeptAcc4.Text = "مشاهده همه ترم هاي يک ورودي   /   حذف برنامه يک ترم از يک ورودي";
            CheckDeptAcc4.UseVisualStyleBackColor = true;
            // 
            // CheckDeptAcc5
            // 
            CheckDeptAcc5.Location = new Point (46, 157);
            CheckDeptAcc5.Name = "CheckDeptAcc5";
            CheckDeptAcc5.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc5.Size = new Size (415, 19);
            CheckDeptAcc5.TabIndex = 11;
            CheckDeptAcc5.Text = "برنامه ريزي    /    تغيير پسورد";
            CheckDeptAcc5.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            Panel1.BackColor = Color.White;
            Panel1.Controls.Add (btnSave);
            Panel1.Controls.Add (panel2);
            Panel1.Controls.Add (CheckDeptAcc7);
            Panel1.Controls.Add (CheckDeptAcc6);
            Panel1.Controls.Add (CheckDeptActive);
            Panel1.Controls.Add (CheckDeptAcc5);
            Panel1.Controls.Add (CheckDeptAcc1);
            Panel1.Controls.Add (CheckDeptAcc4);
            Panel1.Controls.Add (CheckDeptAcc2);
            Panel1.Controls.Add (CheckDeptAcc3);
            Panel1.Dock = DockStyle.Bottom;
            Panel1.Location = new Point (0, 128);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size (538, 296);
            Panel1.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Location = new Point (23, 223);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size (101, 23);
            btnSave.TabIndex = 15;
            btnSave.Text = "ذخيره";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add (lblCancel);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point (0, 276);
            panel2.Name = "panel2";
            panel2.Size = new Size (538, 20);
            panel2.TabIndex = 14;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            lblCancel.Dock = DockStyle.Bottom;
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Location = new Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size (538, 20);
            lblCancel.TabIndex = 12;
            lblCancel.Text = "انصراف";
            lblCancel.TextAlign = ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // CheckDeptAcc7
            // 
            CheckDeptAcc7.Location = new Point (46, 207);
            CheckDeptAcc7.Name = "CheckDeptAcc7";
            CheckDeptAcc7.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc7.Size = new Size (415, 19);
            CheckDeptAcc7.TabIndex = 13;
            CheckDeptAcc7.Text = "فقط در کلاس هاي اختصاص يافته برنامه ريزي مي کند";
            CheckDeptAcc7.UseVisualStyleBackColor = true;
            // 
            // CheckDeptAcc6
            // 
            CheckDeptAcc6.Location = new Point (46, 182);
            CheckDeptAcc6.Name = "CheckDeptAcc6";
            CheckDeptAcc6.RightToLeft = RightToLeft.Yes;
            CheckDeptAcc6.Size = new Size (415, 19);
            CheckDeptAcc6.TabIndex = 12;
            CheckDeptAcc6.Text = "فقط کلاس هاي اختصاص يافته را مشاهده مي کند";
            CheckDeptAcc6.UseVisualStyleBackColor = true;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Save, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.RightToLeft = RightToLeft.Yes;
            ContextMenuStrip1.Size = new Size (112, 48);
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            Menu_Save.Size = new Size (111, 22);
            Menu_Save.Text = "ذخيره";
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (111, 22);
            Menu_Cancel.Text = "انصراف";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // frmDeptEdit
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size (538, 424);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (Panel1);
            Controls.Add (Label3);
            Controls.Add (txtDeptNote);
            Controls.Add (Label2);
            Controls.Add (Label1);
            Controls.Add (txtDeptPass);
            Controls.Add (txtDeptName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDeptEdit";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dept Info";
            Load += frmDeptEdit_Load;
            Panel1.ResumeLayout (false);
            Panel1.PerformLayout ();
            panel2.ResumeLayout (false);
            ContextMenuStrip1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal TextBox txtDeptName;
        internal TextBox txtDeptPass;
        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal TextBox txtDeptNote;
        internal CheckBox CheckDeptActive;
        internal CheckBox CheckDeptAcc1;
        internal CheckBox CheckDeptAcc2;
        internal CheckBox CheckDeptAcc3;
        internal CheckBox CheckDeptAcc4;
        internal CheckBox CheckDeptAcc5;
        internal Panel Panel1;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Save;
        internal ToolStripMenuItem Menu_Cancel;
        internal CheckBox CheckDeptAcc7;
        internal CheckBox CheckDeptAcc6;
        private Panel panel2;
        private Label lblCancel;
        private Button btnSave;
        }
    }