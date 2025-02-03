Public Class frmAbout
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Text = strBuildInfo & "  " & strCurrentVersion
        lblBuildInfo.Text = strBuildInfo & "  " & strCurrentVersion
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Dispose()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Try
            Dim pWeb As Process = New Process()
            pWeb.StartInfo.UseShellExecute = True
            pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir"
            pWeb.Start()
        Catch ex As Exception
            MsgBox("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", vbOKOnly, "مرورگر اج پيدا نشد") 'MsgBox(ex.ToString)
        End Try

    End Sub

End Class