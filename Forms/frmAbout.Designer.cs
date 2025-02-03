using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NexTerm
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmAbout : Form
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
            Label2 = new Label ();
            Label3 = new Label ();
            Timer1 = new Timer (components);
            lblBuildInfo = new Label ();
            SuspendLayout ();
            // 
            // Label2
            // 
            Label2.BackColor = Color.FromArgb (  248,   248,   248);
            Label2.Font = new Font ("Courier New", 32F, FontStyle.Regular, GraphicsUnit.Point);
            Label2.ForeColor = Color.IndianRed;
            Label2.Location = new Point (12, 22);
            Label2.Name = "Label2";
            Label2.RightToLeft = RightToLeft.No;
            Label2.Size = new Size (755, 79);
            Label2.TabIndex = 1;
            Label2.Text = "nexterm";
            Label2.TextAlign = ContentAlignment.MiddleCenter;
            Label2.Click += Label2_Click;
            // 
            // Label3
            // 
            Label3.BackColor = Color.FromArgb (  248,   248,   248);
            Label3.Font = new Font ("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.ForeColor = Color.CadetBlue;
            Label3.ImageAlign = ContentAlignment.MiddleRight;
            Label3.Location = new Point (12, 91);
            Label3.Name = "Label3";
            Label3.RightToLeft = RightToLeft.No;
            Label3.Size = new Size (755, 42);
            Label3.TabIndex = 3;
            Label3.Text = "Majid Sharifi-Tehrani, Faculty of Science, Shahrekord Univ.  / www.msht.ir";
            Label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Timer1
            // 
            Timer1.Enabled = true;
            Timer1.Interval = 4000;
            Timer1.Tick += Timer1_Tick;
            // 
            // lblBuildInfo
            // 
            lblBuildInfo.BackColor = Color.FromArgb (  248,   248,   248);
            lblBuildInfo.Font = new Font ("Courier New", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblBuildInfo.ForeColor = Color.DarkGoldenrod;
            lblBuildInfo.Location = new Point (12, 147);
            lblBuildInfo.Name = "lblBuildInfo";
            lblBuildInfo.RightToLeft = RightToLeft.No;
            lblBuildInfo.Size = new Size (755, 32);
            lblBuildInfo.TabIndex = 4;
            lblBuildInfo.Text = "Build 14020306";
            lblBuildInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb (  248,   248,   248);
            ClientSize = new Size (771, 203);
            ControlBox = false;
            Controls.Add (lblBuildInfo);
            Controls.Add (Label3);
            Controls.Add (Label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "about";
            Load += frmAbout_Load;
            ResumeLayout (false);
            }

        internal Label Label2;
        internal Label Label3;
        internal Timer Timer1;
        internal Label lblBuildInfo;
        }
    }