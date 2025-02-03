<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCNN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmCNN))
        GridCNN = New DataGridView()
        MenuStripCNN = New ContextMenuStrip(components)
        Menu_Select = New ToolStripMenuItem()
        Menu_Edit = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripSeparator()
        Menu_Guide = New ToolStripMenuItem()
        Menu_Exit = New ToolStripMenuItem()
        Label2 = New Label()
        PasswordTextBox = New TextBox()
        lstUsers = New ListBox()
        MenuStripGroups = New ContextMenuStrip(components)
        Menu2_Guide = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        Menu2_Exit = New ToolStripMenuItem()
        CType(GridCNN, ComponentModel.ISupportInitialize).BeginInit()
        MenuStripCNN.SuspendLayout()
        MenuStripGroups.SuspendLayout()
        SuspendLayout()
        ' 
        ' GridCNN
        ' 
        GridCNN.AllowUserToAddRows = False
        GridCNN.AllowUserToDeleteRows = False
        GridCNN.AllowUserToResizeColumns = False
        GridCNN.AllowUserToResizeRows = False
        GridCNN.BackgroundColor = Color.FromArgb(CByte(234), CByte(234), CByte(234))
        GridCNN.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = SystemColors.ControlLight
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        GridCNN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        GridCNN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        GridCNN.ColumnHeadersVisible = False
        GridCNN.ContextMenuStrip = MenuStripCNN
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(234), CByte(234), CByte(234))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(234), CByte(234), CByte(234))
        DataGridViewCellStyle2.SelectionForeColor = Color.RoyalBlue
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        GridCNN.DefaultCellStyle = DataGridViewCellStyle2
        GridCNN.EditMode = DataGridViewEditMode.EditProgrammatically
        GridCNN.GridColor = Color.FromArgb(CByte(234), CByte(234), CByte(234))
        GridCNN.Location = New Point(10, 9)
        GridCNN.MultiSelect = False
        GridCNN.Name = "GridCNN"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = SystemColors.InfoText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        GridCNN.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        GridCNN.RowHeadersVisible = False
        GridCNN.RowHeadersWidth = 4
        GridCNN.RowTemplate.Height = 25
        GridCNN.Size = New Size(385, 153)
        GridCNN.TabIndex = 3
        ' 
        ' MenuStripCNN
        ' 
        MenuStripCNN.Items.AddRange(New ToolStripItem() {Menu_Select, Menu_Edit, ToolStripMenuItem3, Menu_Guide, Menu_Exit})
        MenuStripCNN.Name = "MenuStripCNN"
        MenuStripCNN.RightToLeft = RightToLeft.Yes
        MenuStripCNN.Size = New Size(152, 98)
        ' 
        ' Menu_Select
        ' 
        Menu_Select.Name = "Menu_Select"
        Menu_Select.Size = New Size(151, 22)
        Menu_Select.Text = "انتخاب / ادامه..."
        ' 
        ' Menu_Edit
        ' 
        Menu_Edit.Name = "Menu_Edit"
        Menu_Edit.Size = New Size(151, 22)
        Menu_Edit.Text = "ويرايش"
        Menu_Edit.Visible = False
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(148, 6)
        ' 
        ' Menu_Guide
        ' 
        Menu_Guide.Name = "Menu_Guide"
        Menu_Guide.Size = New Size(151, 22)
        Menu_Guide.Text = "راهنما"
        Menu_Guide.Visible = False
        ' 
        ' Menu_Exit
        ' 
        Menu_Exit.ForeColor = Color.IndianRed
        Menu_Exit.Name = "Menu_Exit"
        Menu_Exit.Size = New Size(151, 22)
        Menu_Exit.Text = "خروج"
        ' 
        ' Label2
        ' 
        Label2.BackColor = SystemColors.Control
        Label2.Font = New Font("Courier New", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DarkGoldenrod
        Label2.Location = New Point(12, 168)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.No
        Label2.Size = New Size(172, 27)
        Label2.TabIndex = 6
        Label2.Text = "nexterm"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.BackColor = Color.FromArgb(CByte(234), CByte(234), CByte(234))
        PasswordTextBox.BorderStyle = BorderStyle.None
        PasswordTextBox.Font = New Font("Courier New", 13F, FontStyle.Regular, GraphicsUnit.Point)
        PasswordTextBox.ForeColor = SystemColors.ControlDarkDark
        PasswordTextBox.Location = New Point(401, 168)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "-"c
        PasswordTextBox.Size = New Size(361, 20)
        PasswordTextBox.TabIndex = 10
        PasswordTextBox.TextAlign = HorizontalAlignment.Center
        PasswordTextBox.Visible = False
        ' 
        ' lstUsers
        ' 
        lstUsers.BackColor = Color.FromArgb(CByte(234), CByte(234), CByte(234))
        lstUsers.BorderStyle = BorderStyle.None
        lstUsers.ContextMenuStrip = MenuStripGroups
        lstUsers.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        lstUsers.FormattingEnabled = True
        lstUsers.ItemHeight = 17
        lstUsers.Location = New Point(401, 9)
        lstUsers.Name = "lstUsers"
        lstUsers.RightToLeft = RightToLeft.Yes
        lstUsers.Size = New Size(361, 153)
        lstUsers.TabIndex = 12
        lstUsers.Visible = False
        ' 
        ' MenuStripGroups
        ' 
        MenuStripGroups.Items.AddRange(New ToolStripItem() {Menu2_Guide, ToolStripMenuItem1, Menu2_Exit})
        MenuStripGroups.Name = "MenuStripGroups"
        MenuStripGroups.RightToLeft = RightToLeft.Yes
        MenuStripGroups.Size = New Size(104, 54)
        ' 
        ' Menu2_Guide
        ' 
        Menu2_Guide.Name = "Menu2_Guide"
        Menu2_Guide.Size = New Size(103, 22)
        Menu2_Guide.Text = "راهنما"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(100, 6)
        ' 
        ' Menu2_Exit
        ' 
        Menu2_Exit.ForeColor = Color.IndianRed
        Menu2_Exit.Name = "Menu2_Exit"
        Menu2_Exit.Size = New Size(103, 22)
        Menu2_Exit.Text = "خروج"
        ' 
        ' frmCNN
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(772, 197)
        ContextMenuStrip = MenuStripGroups
        ControlBox = False
        Controls.Add(lstUsers)
        Controls.Add(PasswordTextBox)
        Controls.Add(Label2)
        Controls.Add(GridCNN)
        ForeColor = Color.DarkSlateGray
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmCNN"
        Opacity = 0.94R
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = ">"
        CType(GridCNN, ComponentModel.ISupportInitialize).EndInit()
        MenuStripCNN.ResumeLayout(False)
        MenuStripGroups.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents GridCNN As DataGridView
    Friend WithEvents MenuStripCNN As ContextMenuStrip
    Friend WithEvents Menu_SelectBE As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_FindDB As ToolStripMenuItem
    Friend WithEvents Menu_AddCNN As ToolStripMenuItem
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents Menu2_Guide As ToolStripMenuItem
    Friend WithEvents Menu_Guide As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents lblNewVersion As Label
    Friend WithEvents lstUsers As ListBox
    Friend WithEvents Menu_Select As ToolStripMenuItem
    Friend WithEvents MenuStripGroups As ContextMenuStrip
    Friend WithEvents Menu2_Exit As ToolStripMenuItem
End Class
