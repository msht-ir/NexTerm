using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace NexTerm
    {
    public partial class frmAbout
        {
        public frmAbout ()
            {
            InitializeComponent ();
            }
        private void frmAbout_Load (object sender, EventArgs e)
            {
            // Me.Text = strBuildInfo & "  " & strCurrentVersion
            lblBuildInfo.Text = NxDb.BuildInfo + "  " + NxDb.CurrentVersion;
            }
        private void Timer1_Tick (object sender, EventArgs e)
            {
            Dispose ();
            }

        private void Label2_Click (object sender, EventArgs e)
            {
            try
                {
                var pWeb = new Process ();
                pWeb.StartInfo.UseShellExecute = true;
                pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir";
                pWeb.Start ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", "مرورگر اج پيدا نشد", MessageBoxButtons.OK);
                }
            }

        }
    }