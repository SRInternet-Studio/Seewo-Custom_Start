Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Net.Http

Public Class dl
    Private Async Function GetPhpContentAsync(url As String) As Task(Of String)
        Using client As New HttpClient()
            Try

                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                response.EnsureSuccessStatusCode()


                Dim content As String = Await response.Content.ReadAsStringAsync()
                Return content
            Catch ex As Exception
                MsgBox("获取失败，原因" & ex.ToString(), vbCritical)
                Return Nothing
            End Try
        End Using
    End Function
Private WithEvents myWebClient As New WebClient()


    Private Async Sub dl_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim phpContent As String = Await GetPhpContentAsync("http://update.seewostart.sr-studio.top/dlurl.php")
        If phpContent IsNot Nothing Then
            Dim url As New Uri(phpContent)
            If Dir("SeewoStart-Installer.exe") <> "" Then
                File.Delete("SeewoStart-Installer.exe")
            End If
            Dim savePath As String = AppDomain.CurrentDomain.BaseDirectory & "\SeewoStart-Installer.exe"


            ' 开始异步下载
            myWebClient.DownloadFileAsync(url, savePath)
        Else
            MsgBox("无法取得下载链接，无法更新！"， vbCritical)
            Close()
        End If
    End Sub

    Private Sub myWebClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles myWebClient.DownloadProgressChanged
        ' 更新进度条
        ProgressBar1.Value = e.ProgressPercentage
        textBlock_Copy.Text = e.ProgressPercentage & "%"
    End Sub

    Private Async Sub myWebClient_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles myWebClient.DownloadFileCompleted
        Await Task.Delay(1000)
        Process.Start(AppDomain.CurrentDomain.BaseDirectory & "\SeewoStart-Installer.exe")
        End
    End Sub

    Private Sub dl_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
    End Sub
End Class

