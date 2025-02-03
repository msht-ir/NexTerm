<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Label2 = New Label()
        Label3 = New Label()
        Timer1 = New Timer(components)
        lblBuildInfo = New Label()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Microsoft Sans Serif", 40F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.LightSteelBlue
        Label2.Location = New Point(12, 22)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.No
        Label2.Size = New Size(755, 79)
        Label2.TabIndex = 1
        Label2.Text = "NexTerm"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.BackColor = SystemColors.Control
        Label3.Font = New Font("Courier New", 10F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.CadetBlue
        Label3.ImageAlign = ContentAlignment.MiddleRight
        Label3.Location = New Point(12, 113)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.No
        Label3.Size = New Size(755, 42)
        Label3.TabIndex = 3
        Label3.Text = "by Dr Majid Sharifi-Tehrani 2023 Faculty of Science, Shahrekord University"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 4000
        ' 
        ' lblBuildInfo
        ' 
        lblBuildInfo.BackColor = SystemColors.Control
        lblBuildInfo.Font = New Font("Courier New", 11F, FontStyle.Bold, GraphicsUnit.Point)
        lblBuildInfo.ForeColor = Color.DarkGoldenrod
        lblBuildInfo.Location = New Point(12, 169)
        lblBuildInfo.Name = "lblBuildInfo"
        lblBuildInfo.RightToLeft = RightToLeft.No
        lblBuildInfo.Size = New Size(755, 32)
        lblBuildInfo.TabIndex = 4
        lblBuildInfo.Text = "Build 14020306"
        lblBuildInfo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmAbout
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonFace
        ClientSize = New Size(779, 242)
        ControlBox = False
        Controls.Add(lblBuildInfo)
        Controls.Add(Label3)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmAbout"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "about"
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblBuildInfo As Label
End Class
