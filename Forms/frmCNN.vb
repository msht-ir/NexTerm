Imports DocumentFormat.OpenXml.Office2019.Drawing
Imports System.Reflection

Public Class frmCNN
    Dim tblConnection As New DataTable
    '//form Load
    Private Sub cnn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmTermProgs.Dispose()
        GetBuildInfo() 'From file strFilename
        Me.Text = strBuildInfo
        Dim strConnectionName As String = ""
        Dim strConnectionAddress As String = ""
        Dim strConnectionUsername As String = ""
        Dim strConnectionPassword As String = ""
        tblConnection.Columns.Add("Database", GetType(String))
        tblConnection.Columns.Add("انتخاب ديتابيس", GetType(String))
        tblConnection.Columns.Add("uid", GetType(String))
        tblConnection.Columns.Add("pwd", GetType(String))
        strFilename = Application.StartupPath & "cnn"
        If IO.File.Exists(strFilename) = True Then
            FileOpen(1, strFilename, OpenMode.Input)
lbl_Read:
            Try
                Dim strx1 As String = LineInput(1)
                If strx1 = "NexTerm Connection" Then
                    strConnectionName = LineInput(1)
                    strConnectionAddress = LineInput(1)
                    strConnectionUsername = LineInput(1)
                    strConnectionPassword = LineInput(1)
                    tblConnection.Rows.Add(strConnectionName, strConnectionAddress, strConnectionUsername, strConnectionPassword)
                End If
                GoTo lbl_Read
            Catch ex As Exception
                'MsgBox("خطا در فايل تنظيمات اتصال ", vbOKOnly, "نکسترم") ' MsgBox(ex.ToString)
            End Try
            If Not EOF(1) Then GoTo lbl_Read
            FileClose(1)
            GridCNN.DataBindings.Clear()
            GridCNN.DataSource = tblConnection
            GridCNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            GridCNN.Columns(0).Visible = False     'connection name
            GridCNN.Columns(1).Width = 370         'connection address
            GridCNN.Columns(2).Width = 0           'connection username
            GridCNN.Columns(3).Width = 0           'connection password
            GridCNN.Columns(2).Visible = False     'connection username
            GridCNN.Columns(3).Visible = False     'connection password
            'Disable manual-sort for Grid columns
            For i As Integer = 0 To GridCNN.Columns.Count - 1 'Disable sort for column_haeders
                GridCNN.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
            GridCNN.Refresh()
        End If
    End Sub
    Private Sub GetBuildInfo()
        'strBuildInfo : Build info is set in Module
        UserNickName = ""
        intUser = 0
        strFilename = Application.StartupPath & "usr"
        If IO.File.Exists(strFilename) = True Then
            Try
                FileOpen(1, strFilename, OpenMode.Input)
                Dim strx As String = LineInput(1)
                If Trim(strx) <> "NexTerm" Then 'Check header
                    FileClose(1)
                    Exit Sub
                Else 'header is correct
                    Dim tmprowx = LineInput(1)
                    UserNickName = LCase(Trim(Mid(LineInput(1), 6)))
                    If (UserNickName = "na" Or UserNickName = "-") Then UserNickName = ""
                    intUser = Val(Mid(LineInput(1), 5))
                End If
            Catch ex As Exception
                'MsgBox("خطا در فايل تنظيمات اتصال ", vbOKOnly, "نکسترم") '// MsgBox(ex.ToString)
            End Try
            FileClose(1)
        End If
    End Sub
    '//Menu
    Private Sub Menu_Select_Click(sender As Object, e As EventArgs) Handles Menu_Select.Click
        SelectBackEnd()
    End Sub
    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        Try
            If GridCNN.RowCount < 1 Then Exit Sub
            Dim r As Integer = GridCNN.SelectedCells(0).RowIndex    'count from 0
            Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
            If r < 0 Or c < 0 Then Exit Sub
            Dim strValue As String = GridCNN(c, r).Value
            strValue = InputBox("مقدار جديد را وارد کنيد", "تنظيمات اتصال به ديتابيس", strValue)
            GridCNN(c, r).Value = strValue
            SaveChanges() 'AutoSave
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub SaveChanges()
        Try
            FileOpen(1, Application.StartupPath & "cnn", OpenMode.Output)
            For r As Integer = 0 To GridCNN.Rows.Count - 1
                If IsDBNull(GridCNN(0, r).Value) Then
                    GridCNN(0, r).Value = "untitled Connection"
                End If
                For c As Integer = 0 To 3
                    If IsDBNull(GridCNN(c, r).Value) Then GridCNN(c, r).Value = ""
                Next c
            Next r
            For r As Integer = 0 To GridCNN.Rows.Count - 1
                PrintLine(1, "NexTerm Connection")
                PrintLine(1, GridCNN(0, r).Value) '0 connection name
                PrintLine(1, GridCNN(1, r).Value) '1 connection address
                PrintLine(1, GridCNN(2, r).Value) '2 connection username
                PrintLine(1, GridCNN(3, r).Value) '3 connection password
                PrintLine(1, " ")
            Next r
            FileClose(1)
            'MsgBox("تغييرات ذخيره شد", vbOKOnly, "نکسترم")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu_Guide_Click(sender As Object, e As EventArgs) Handles Menu_Guide.Click
        Try
            Dim pWeb As Process = New Process()
            pWeb.StartInfo.UseShellExecute = True
            pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir"
            pWeb.Start()
        Catch ex As Exception
            MsgBox("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", vbOKOnly, "مرورگر اج پيدا نشد") 'MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        Me.Dispose()
        End
    End Sub

    '//Select a Database
    Private Sub GridCNN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCNN.CellDoubleClick
        SelectBackEnd()
    End Sub
    Private Sub SelectBackEnd()
        'Also with DblClick
        If GridCNN.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCNN.SelectedCells(0).RowIndex    'count from 0
        Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Server2Connect = Trim(GridCNN(0, r).Value) '0 connection name
        strDbBackEnd = Trim(GridCNN(1, r).Value)   '1 connection address
        strServeruid = Trim(GridCNN(2, r).Value)   '2 connection username
        strServerpwd = Trim(GridCNN(3, r).Value)   '3 connection password
        If Server2Connect = "" Then Exit Sub
        lstUsers.Visible = True
        lstUsers.Focus()
        PasswordTextBox.Visible = True
        '//Connect now
        DS.Clear()   'Delete all existing tables in Dataset
        DS.Dispose() 'Delete Dataset
        DoConnectToDatabase()
        SetFacultyUserRights() ' Set acc1-5 for Faculty
        Try
            Me.Text = "connected to:  " & Server2Connect
            lstUsers.DataSource = DS.Tables("tblDepartments")
            lstUsers.DisplayMember = "DEPT"
            lstUsers.ValueMember = "ID"
            lstUsers.SelectedValue = intUser
            PasswordTextBox.Focus()
            PasswordTextBox.Text = "Password"
            PasswordTextBox.SelectionStart = 0
            PasswordTextBox.SelectionLength = 8
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub DoConnectToDatabase()
        Select Case Server2Connect
            Case "NexTerm DB-1" 'FACULTY OF SCIENCE
                strDatabaseCNNstring = "Data Source=31.25.91.22;Initial Catalog=mshtir_NexTerm; User ID=mshtir1_nx1user; Password=nExTeRm_1401_uSrxUnAxT;"
            Case "NexTerm DB-2" 'FACULTY OF MATH ?
                strDatabaseCNNstring = "Data Source=31.25.91.22;Initial Catalog=mshtir_NX2; User ID=mshtir1_nx2user; Password=SiliconPower_740;"
            Case "NexTerm DB-3" 'FACULTY OF NATRES ?
                strDatabaseCNNstring = "Data Source=31.25.91.22;Initial Catalog=mshtir_NX3; User ID=mshtir1_nx3user; Password=nExTeRm_1401_uSr3;"
                'strDatabaseCNNstring = "Server=31.2--5.91.22\sqlserver2019; Initial Catalog=mshtir_NX3; User ID=mshtir_nx3user; Password=nExTeRm_1401_uSrxThiRd;"
            Case "Local Server 1", "Local Server 2", "Local Server 3"
                strDatabaseCNNstring = strDbBackEnd 'sql server on ThisPC NX1, NX2, NX3
        End Select
        strCaption = "Connected to " & Server2Connect
        '//Initialize Tables
        Try
            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                CnnSS.Open()
                DASS = New SqlClient.SqlDataAdapter("Select ID, DepartmentName As DEPT, DepartmentActive, Notes, DepartmentPass, acc1, acc2, acc3, acc4, acc5 FROM Departments ORDER BY DepartmentName", CnnSS)
                DASS.Fill(DS, "tblDepartments") ' tbl 1: Depts
                DASS = New SqlClient.SqlDataAdapter("SELECT ID FROM BioProgs", CnnSS)
                DASS.Fill(DS, "tblBioProgs") ' tbl 2: BioProgs
                DASS = New SqlClient.SqlDataAdapter("Select ID FROM Courses", CnnSS)
                DASS.Fill(DS, "tblCourses") ' tbl 3: Courses
                DASS = New SqlClient.SqlDataAdapter("Select ID FROM Staff", CnnSS)
                DASS.Fill(DS, "tblStaff") ' tbl 4: Staff
                DASS = New SqlClient.SqlDataAdapter("Select ID FROM Technecians", CnnSS)
                DASS.Fill(DS, "tblTechs") ' tbl 5: Techs
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, RoomName AS Class FROM Rooms ORDER BY RoomName", CnnSS)
                DASS.Fill(DS, "tblRooms") ' tbl 6: Rooms
                DASS = New SqlClient.SqlDataAdapter("SELECT ID As EntID FROM Entries", CnnSS)
                DASS.Fill(DS, "tblEntries") ' tbl 7: Entries
                DASS = New SqlClient.SqlDataAdapter("Select ID FROM Terms", CnnSS)
                DASS.Fill(DS, "tblTerms") ' tbl 8: Terms
                DASS = New SqlClient.SqlDataAdapter("Select ID FROM Templates", CnnSS)
                DASS.Fill(DS, "tblTemplates") ' tbl 9: Templates
                DASS = New SqlClient.SqlDataAdapter("Select ID FROM TemplateData", CnnSS)
                DASS.Fill(DS, "tblTemplateData") ' tbl 10: TemplateData
                DASS = New SqlClient.SqlDataAdapter("SELECT ID From TermProgs", CnnSS)
                DASS.Fill(DS, "tblTermProgs") ' tbl 11: TermProgs
                DS.Tables("tblSettings").Clear()
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Log User%' ORDER BY iHerbsConstant", CnnSS) ' search: (Log User Activity)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                '//boolLog
                Try
                    If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then boolLog = True Else boolLog = False
                Catch ex As Exception
                    boolLog = False
                End Try
                DS.Tables("tblSettings").Clear()
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Report background%' ORDER BY iHerbsConstant", CnnSS) ' search: (bg)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                '//strReportBG
                Try
                    strReportBG = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    strReportBG = "bg2.png"
                End Try
                DS.Tables("tblSettings").Clear()
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin Password%' ORDER BY iHerbsConstant", CnnSS) ' search: (Password for Admin)
                DASS.Fill(DS, "tblSettings")
                '//strFacultyPass
                Try
                    strFacultyPass = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    Try
                        MsgBox("خطا: ديتابيس خراب است")
                        CnnSS.Close() : CnnSS.Dispose() : Me.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Application.Exit() : End
                    Catch
                        MsgBox("Error in Exit module ....")
                    End Try
                End Try
                DS.Tables("tblSettings").Clear()
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant='Current Version'", CnnSS) ' search: (version)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                '//Version
                Try
                    strCurrentVersion = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    strCurrentVersion = "Error in Table Settings"
                End Try
                'intDefaultTermID
                DS.Tables("tblSettings").Clear()
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant='TermDefaultID'", CnnSS)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                '//TermDefault
                Try
                    intDefaultTermID = Int(DS.Tables("tblSettings").Rows(0).Item(2))
                Catch ex As Exception
                    intDefaultTermID = 0
                End Try
                'strExamDateStart/End
                DS.Tables("tblSettings").Clear()
                DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'ExamDate%' ORDER BY iHerbsConstant", CnnSS)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                '//Exam Date End/Start
                Try
                    strExamDateEnd = DS.Tables("tblSettings").Rows(0).Item(2)
                    strExamDateStart = DS.Tables("tblSettings").Rows(1).Item(2)
                Catch ex As Exception
                    strExamDateEnd = ""
                    strExamDateStart = ""
                End Try
                DASS = New SqlClient.SqlDataAdapter("SELECT ID From TermProgs", CnnSS)
                DASS.Fill(DS, "tblAllProgs") ' tbl 13: AllProgs
                DASS = New SqlClient.SqlDataAdapter("SELECT ID From TermProgs", CnnSS)
                DASS.Fill(DS, "tblTermExams") ' tbl 14: Exams
                DASS = New SqlClient.SqlDataAdapter("SELECT DateTimex From xLog", CnnSS)
                DASS.Fill(DS, "tblLogs") ' tbl Logs
                DASS = New SqlClient.SqlDataAdapter("SELECT ID FROM msgs", CnnSS)
                DASS.Fill(DS, "tblMsgs") ' tbl notes (messages)
                If Userx = "quit" Then
                    Try
                        CnnSS.Close()
                        CnnSS.Dispose()
                        Me.Dispose()
                        ChooseStaff.Dispose()
                        ChooseTech.Dispose()
                        Application.Exit()
                        End
                    Catch
                        MsgBox("خطا در ماژول خروج", vbOKOnly, "نکسترم")
                        End
                    End Try
                Else
                    If boolLog = True Then
                        'WRITE-LOG
                        Try
                            If Userx = "USER Faculty" Then intUser = 0
                            'Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
                            Dim timeZoneInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
                            Dim strDateTime As String = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo).ToString("yyyy.MM.dd - HH:mm:ss")
                            Dim intUserID As Integer = intUser
                            Dim strNickName As String = UserNickName
                            Dim strClientName As String = LCase(Environment.MachineName)
                            Dim strFrontEnd As String = LCase(strBuildInfo)
                            Dim strLog As String = "login"
                            strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                            cmdx.Parameters.AddWithValue("@userid", intUserID.ToString)
                            cmdx.Parameters.AddWithValue("@nickname", strNickName)
                            cmdx.Parameters.AddWithValue("@clientname", strClientName)
                            cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                            cmdx.Parameters.AddWithValue("@strlog", strLog)
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox(ex.ToString) 'Do Nothing!
                        End Try
                    End If
                End If
                CnnSS.Close()
            End Using
        Catch ex As Exception
            Dim myansw As DialogResult = MsgBox("خطا: نکسترم به ديتابيس زير متصل نشد" & vbCrLf & strDbBackEnd & vbCrLf & vbCrLf & "جزييات خطا نشان داده شود؟", vbYesNo + vbDefaultButton2, "خطا در اتصال به ديتابيس")
            If myansw = vbYes Then MsgBox(ex.ToString)
            Application.Exit()
            End
        End Try
    End Sub
    Private Sub SetFacultyUserRights()
        DS.Tables("tblSettings").Clear()
        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
            CnnSS.Open()
            DASS = New SqlClient.SqlDataAdapter("SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin can%' ORDER BY iHerbsConstant", CnnSS)
            DASS.Fill(DS, "tblSettings")
            CnnSS.Close()
        End Using
        Try 'Admin Can Class / Prog
            If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or &H4) Else UserAccessControls = (UserAccessControls And &HFB)   ' ( 4=0000'0100 | 251=1111'1011)
            If UCase(DS.Tables("tblSettings").Rows(1).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or &H10) Else UserAccessControls = (UserAccessControls And &HEF)  ' (16=0001'0000 | 239=1110'1111)
        Catch ex As Exception
            UserAccessControls = (UserAccessControls And &HFB)  ' ( 4=0000'0100   251=1111'1011)
            UserAccessControls = (UserAccessControls And &HEF)  ' (16=0001'0000   239=1110'1111)
        End Try
    End Sub
    Private Sub GridCNN_KeyDown(sender As Object, e As KeyEventArgs) Handles GridCNN.KeyDown
        If e.KeyCode = 13 Then
            SelectBackEnd()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub GridCNN_Click(sender As Object, e As EventArgs) Handles GridCNN.Click
        Me.Text = strBuildInfo
        lstUsers.Visible = False
        PasswordTextBox.Text = ""
        PasswordTextBox.Visible = False
    End Sub

    '//Enter Password
    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
        If PasswordTextBox.Text = "Password" Then
            PasswordTextBox.PasswordChar = ""
        Else
            PasswordTextBox.PasswordChar = "-"
        End If
        '//Check .text
        Dim usr As Integer = 0
        If IsDBNull(lstUsers.SelectedValue) Then usr = 0 Else usr = lstUsers.SelectedValue
        If PasswordTextBox.Text = "quit" Or PasswordTextBox.Text = "exit" Then '---------------------------------------------------------------- (quit)
            Userx = "quit"
            Me.Dispose()
            End
        ElseIf Trim(PasswordTextBox.Text) = "" Then '---------------------------------------------------- show prompt
            PasswordTextBox.Text = "Password"
            PasswordTextBox.SelectionStart = 0
            PasswordTextBox.SelectionLength = 8
            Exit Sub
        ElseIf PasswordTextBox.Text = "mshtaccesson" Then '---------------------------------------------------- usr = msht
            Userx = "USER Faculty"
            UserAccessControls = &HFF '0x1f=31=0001'1111 : +all acc 1-5!
            Me.Dispose()
            frmTermProgs.ShowDialog()
        ElseIf PasswordTextBox.Text = strFacultyPass Then '---------------------------------------------------- usr = Faculty
            Userx = "USER Faculty"
lbl_GetUserNickName1:
            If Trim(UserNickName) = "" Then UserNickName = Trim(InputBox("Enter your NickName :", "NexTerm:", ""))
            If Trim(UserNickName) = "" Then GoTo lbl_GetUserNickName1
            SetBuildInfo()
            Me.Dispose()
            frmTermProgs.ShowDialog()
        Else '------------------------------------------------------------------------------------------------- usr = Department 
            intUser = lstUsers.SelectedValue ' ID of selected Department
            If intUser = 0 Then Exit Sub
            If PasswordTextBox.Text = DS.Tables("tblDepartments").Rows(lstUsers.SelectedIndex).Item(4) Then
                Userx = "USER Department"
lbl_GetUserNickName2:
                If Trim(UserNickName) = "" Then UserNickName = Trim(InputBox("Enter your NickName :", "NexTerm:", ""))
                If Trim(UserNickName) = "" Then GoTo lbl_GetUserNickName2
                SetBuildInfo()
                strUser = lstUsers.Text
                UserAccessControls = 0 'SET UserAccessControls
                For i As Integer = 0 To 4
                    If DS.Tables("tblDepartments").Rows(lstUsers.SelectedIndex).Item(i + 5) = True Then UserAccessControls = (UserAccessControls Or (2 ^ i))
                Next i
                Me.Dispose()
                frmTermProgs.ShowDialog()
            End If
        End If
    End Sub
    Private Sub SetBuildInfo()
        FileOpen(1, Application.StartupPath & "usr", OpenMode.Output)
        PrintLine(1, "NexTerm")
        PrintLine(1, strBuildInfo)
        PrintLine(1, "nick " & LCase(UserNickName))
        PrintLine(1, "usr " & intUser.ToString)
        FileClose(1)
    End Sub
    Private Sub lstUsers_KeyDown(sender As Object, e As KeyEventArgs) Handles lstUsers.KeyDown
        If e.KeyCode = 13 Then PasswordTextBox.Focus()
        e.SuppressKeyPress = True
    End Sub
    Private Sub lstUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstUsers.SelectedIndexChanged
        PasswordTextBox.Focus()
        PasswordTextBox.Text = "Password"
        PasswordTextBox.SelectionStart = 0
        PasswordTextBox.SelectionLength = 8
    End Sub

    Private Sub Menu2_Guide_Click(sender As Object, e As EventArgs) Handles Menu2_Guide.Click
        FileOpen(1, Application.StartupPath & "\NexTerm_Guide.html", OpenMode.Output)
        PrintLine(1, "<html dir=""rtl"">")
        PrintLine(1, "<head>")
        PrintLine(1, "<title>راهنما</title>")
        PrintLine(1, strReportsStyle) ' strReportsStyle is defined in Module1
        PrintLine(1, "</head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>")
        PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:14px; Text-Align:Center'>راهنماي نرم افزار نکسترم</p>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'> راهنماي استفاده از نرم افزار <br></p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:14px'>")
        PrintLine(1, "نام دانشکده خود را از ليست انتخاب کنيد <br>")
        PrintLine(1, "راست کليک کنيد و گزينه انتخاب / ادامه را کليک کنيد  <br>")
        PrintLine(1, "از ليست سمت راست گروه خود را انتخاب کنيد و کلمه رمز را وارد کنيد <br>")
        PrintLine(1, " <br>")
        PrintLine(1, " <br>")
        PrintLine(1, "براي راهنمايي بيشتر به وبسايت   ")
        PrintLine(1, " <a href=""http://www.msht.ir"">  msht.ir</a>  ")
        PrintLine(1, "   بخش نکسترم  مراجعه کنيد  <br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='color:green;font-family:tahoma; font-size:14px'> راه اندازي اوليه <br></p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:14px'>")
        PrintLine(1, "در شروع استفاده از نکسترم، راه اندازي اوليه (توسط ادمين نکسترم) بصورت زير انجام شود <br>")
        PrintLine(1, " <br>")
        PrintLine(1, "</p> <br>")
        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'> براي آموزش دانشکده <br></p>")
        PrintLine(1, " <br>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:14px'>")
        PrintLine(1, "ليست گروه هاي آموزشي دانشکده در بخش منابع واردشود <br>")
        PrintLine(1, "ليست کارشناسان آزمايشگاه ها در بخش منابع واردشود <br>")
        PrintLine(1, "ليست کلاس ها و آزمايشگاه ها در بخش منابع واردشود <br>")
        PrintLine(1, " <br>")
        PrintLine(1, "</p> <br>")
        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'> براي مدير گروه آموزشي <br></p>")
        PrintLine(1, " <br>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:14px'>")
        PrintLine(1, "ليست اساتيد گروه (در بخش منابع) واردشده باشند  <br>")
        PrintLine(1, "ليست دوره هاي آموزشي گروه (در بخش منابع) واردشده باشند <br>")
        PrintLine(1, "دربخش منابع، براي هر دوره آموزشي ليست درس ها واردشده باشند  <br>")
        PrintLine(1, "دربخش منابع، براي هر دوره آموزشي ليست ورودي هاي فعال واردشده باشند  <br>")
        PrintLine(1, " <br>")
        PrintLine(1, "براي هر دوره آموزشي دست کم يک برنامه الگو (ترميک) طراحي و ثبت شده باشد <br>")
        PrintLine(1, "به هر ورودي فعال، برنامه الگو اختصاص داده شده باشد <br>")
        PrintLine(1, "برنامه پيش روي هر ورودي بررسي شده باشد تا دانشجويان هر ورودي بتوانند نهايتا در ترمي که تعيين شده، فارغ التحصيل شوند <br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "<br>")
        PrintLine(1, "آموزش مصور و فيلم هاي آموزشي مربوط به نکسترم را در بخش نکسترم در وبسايت مولف ببينيد<br>")
        PrintLine(1, "<br></p>")
        PrintLine(1, strReportsFooter) '//strReportsFooter is defined in Module1
        PrintLine(1, "</body>")
        PrintLine(1, "</html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "NexTerm_Guide.html")
    End Sub
    Private Sub Menu2_Exit_Click(sender As Object, e As EventArgs) Handles Menu2_Exit.Click
        Me.Dispose()
        End
    End Sub

End Class