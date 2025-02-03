Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports Microsoft

Module Module1
    Public strBuildInfo As String = "Build 14020413"   'ignore 2nd row of file: usr
    Public strCurrentVersion As String = "" 'version of db on server (show in frmInfo)
    Public Server2Connect As String = ""
    Public strDatabaseCNNstring As String = ""
    Public CnnSS As New SqlClient.SqlConnection
    Public CmdSS As New SqlClient.SqlCommand
    Public DASS As New SqlDataAdapter
    Public DS As New DataSet
    Public tblDepartments, tblBioProgs, tblCourses, tblEntries, tblRooms As New DataTable
    Public tblStaff, tblTechs, tblTerms, tblTermProgs As New DataTable
    Public tblTemplates, tblTemplateData, tblSettings As New DataTable
    Public tblTermExams, tblLogs, tblMsgs As New DataTable

    Public tblAllProgs As New DataTable 'For frmTadakhols
    Public tblThisCourseTime As New DataTable

    Public Retval1, Retval2, Retval3, Retval4 As Integer
    Public strFacultyPass, strDepartmentPass As String
    Public Userx As String          'USERFaculty | USERDepartment 
    Public intUser As Integer       'ID of Department   (as intUser)
    Public strUser As String        'Name of Department (as strUser)
    Public UserNickName As String   'Name of the User
    Public UserAccessControls As Integer  'acc1-acc5 (user access controls)
    Public strCaption As String
    Public strSQL As String

    Public intDept, intBioProg, intEntry, intCourse, intTerm, intRoom, intStaff, intTech, intTemp As Long
    Public strDept, strBioProg, strEntry, strCourse, strTerm, strRoom, strStaff, strTech, strTemp As String
    Public strExamDateTime As String
    Public intCourseNumber As Long
    Public intYearEntered As Integer
    Public intGridRow As Integer ' used in frm.Choose_Class, showing info of occupied class-times: need row-index of Grid4 
    Public Roomx As Integer      ' used in frm.Choose_Class: prog is for Room1 or Room2?
    Public intDefaultTermID As Integer 'a default term id : to show an entry's prog for this term by default (if not zero)

    Public strFilename As String        ' // path of text file for backend.path, user.id, pass strings
    Public strDbBackEnd As String = ""  ' // (read from cnn file) Path of Backend file on local or server 
    Public BackEndPass As String = "NexTermSiliconPower" ' //encryption password of ACCDB Backend file
    Public strServeruid As String = ""
    Public strServerpwd As String = ""
    Public strReportBG As String = "bg2.png" ' //background filename for html reports

    Public intClass1DayData(5) As Integer '5 days for Class 1
    Public intClass2DayData(5) As Integer '5 days for Class 2
    Public strTime() As String = {"08:30", "09:30", "10:30", "11:30", "13:30", "14:30", "15:30", "16:30"}
    Public strDay() As String = {"شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه"}
    Public intTimeFlag(5, 7) As Integer ' (r:6days, c:8times //begins from 0)
    Public boolLog As Boolean 'Log User Activity (YES/NO) in Setting

    Public strReportsStyle = "<style>table, th,td {border: 1px solid;} body {background-image:url('bg2.png');} .button {border: none;color: black;padding: 5px 20px;Text-align: center;Text-decoration: none;display: inline-block;font-family:Tahoma;Font-Size: 12px;margin: 10px 5px;cursor: pointer;}.button1 {background-Color: lightsilver; border-radius: 4px;}.button2 {background-Color: lightgreen; border-radius: 4px;}.button3 {background-Color: salmon; border-radius: 4px;}</style>"
    Public strReportsStyleSinBg = "<style>table, th,td {border: 1px solid;} .button {border: none;color: black;padding: 5px 20px;Text-align: center;Text-decoration: none;display: inline-block;font-family:Tahoma;Font-Size: 12px;margin: 10px 5px;cursor: pointer;}.button1 {background-Color: lightsilver; border-radius: 4px;}.button2 {background-Color: lightgreen; border-radius: 4px;}.button3 {background-Color: salmon; border-radius: 4px;}</style>"
    Public strReportsFooterx As String = "<a href=""http://msht.ir/NexTerm_00.html"">NexTerm</a> Desktop App <a href=""http://msht.ir"">[ www.msht.ir ]</a> , Faculty of Science, <a href=""https://sku.ac.ir"">SKU</a>. Developer: <a href=""https://sku.ac.ir/en/DepartmentGroup/ProfessorForm.aspx?ID=143"">Dr. Majid Sharifi-Tehrani</a> (1400-1402 / 2021-2023)"
    Public strReportsFooter = "<p style='font-family:tahoma; font-size:10px; text-align: center'>" & strReportsFooterx & "<hr> <button class=""button button1"" onclick=""location.href='http://msht.ir/NexTerm_00.html';"">nexterm guide</button> <button class=""button button1"" onclick=""location.href='http://msht.ir';"">website</button> <button class=""button button1"" onclick=""location.href='https://sku.ac.ir/en/DepartmentGroup/ProfessorForm.aspx?ID=143';"">about author</button>  <button class=""button button3"" onclick=""self.close();"">close</button> <hr></p>"

    Public ReportSettings As Integer = &H3 ' &H2C = &B000000011 = 3 'bit4:DayInCols/Rows is off
    Public strExamDateStart As String = ""
    Public strExamDateEnd As String = ""
    Public tmpExamDateTime As String = ""


    Sub Main()
        Application.EnableVisualStyles()
        DefineTables()
        frmCNN.ShowDialog()
    End Sub
    Public Sub DefineTables()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1") : tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1")
        tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1") : tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1")
        tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1") : tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1")
        DS.Tables.Add("tblDepartments")
        DS.Tables.Add("tblBioProgs")
        DS.Tables.Add("tblCourses")
        DS.Tables.Add("tblEntries")
        DS.Tables.Add("tblRooms")
        DS.Tables.Add("tblStaff")
        DS.Tables.Add("tblTechs")
        DS.Tables.Add("tblTerms")
        DS.Tables.Add("tblTermProgs")
        DS.Tables.Add("tblTemplates")
        DS.Tables.Add("tblTemplateData")
        DS.Tables.Add("tblSettings")
        DS.Tables.Add("tblAllProgs")
        DS.Tables.Add("tblTermExams4Entry")
        DS.Tables.Add("tblTermExams4Staff")
        DS.Tables.Add("tblMsgs")
        DS.Tables.Add("tblReportProgData")
    End Sub

    Public Sub WipeOut_NexTermInfo(tblNames As String)
        Retval1 = 0
        Dim myansw As DialogResult = MsgBox("داده ها پاک شوند؟" & vbCrLf & "مطمئن هستيد؟", vbOKCancel + vbDefaultButton2 + vbExclamation, "نکسترم")
        Select Case myansw
            Case vbOK
                Randomize()
                Dim strRndNumber As Integer = Trim(Str(CInt(Int((10000 * Rnd()) + 1001))))
                Dim strAnsw As String = InputBox("کد ايمني" & strRndNumber, "عدد تصادفي زير را وارد کنيد", "")
                If strAnsw <> strRndNumber Then Exit Sub
            Case vbCancel
                Exit Sub
        End Select
        '//Assuming an OPEN CNN for this SUB
        '//Clear DataTables 
        DS.Tables("tblDepartments").Clear()
        DS.Tables("tblBioProgs").Clear()
        DS.Tables("tblCourses").Clear()
        DS.Tables("tblEntries").Clear()
        DS.Tables("tblRooms").Clear()
        DS.Tables("tblStaff").Clear()
        DS.Tables("tblTechs").Clear()
        DS.Tables("tblTerms").Clear()
        DS.Tables("tblTermProgs").Clear()
        DS.Tables("tblTemplates").Clear()
        DS.Tables("tblTemplateData").Clear()
        DS.Tables("tblSettings").Clear()
        DS.Tables("tblAllProgs").Clear()
        DS.Tables("tblTermExams").Clear()
        DS.Tables("tblMsgs").Clear()
        DS.Tables("tblReportProgData").Clear()
        '//Del Database Tables Rows 
        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
            CnnSS.Open()
            Try
                Select Case tblNames
                    Case "Messages"
                        For Each strTableName In {"msgs"}
                            strSQL = "DELETE FROM " & strTableName & ";"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Next
                    Case "ProgData"
                        For Each strTableName In {"TermProgs"}
                            strSQL = "DELETE FROM " & strTableName & ";"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Next
                    Case "Entries" '+ProgData which are dependant on Entries
                        For Each strTableName In {"Entries", "TermProgs"}
                            strSQL = "DELETE FROM " & strTableName & ";"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Next
                    Case "ClearAllData"
                        For Each strTableName In {"Departments", "BioProgs", "Terms", "Entries", "Rooms", "Staff", "Technecians", "Courses", "TermProgs", "Templates", "TemplateData", "msgs"}
                            strSQL = "DELETE FROM " & strTableName & ";"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Next
                End Select
                Retval1 = 1
            Catch ex As Exception
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            CnnSS.Close()
        End Using
        '//ReSeed Table IDs to 1
        Retval2 = 0
        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
            Try
                CnnSS.Open()
                For Each strTableName In {tblNames}
                    strSQL = "DBCC CHECKIDENT (" & strTableName & ", RESEED, 1)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Next
                Retval2 = 1
            Catch ex As Exception
                MsgBox(ex.ToString)
                Exit Sub
            End Try
            CnnSS.Close()
        End Using
    End Sub

End Module
