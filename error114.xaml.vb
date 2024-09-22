Imports System.IO
Public Class error114

    ' dim appdirectory = readsettings.appdirectoryin '运行目录
    Dim printend As Boolean
    Private Sub error114_loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        papa114()

    End Sub
    Public Async Sub papa114()
        Await Task.Delay(100)
        Try
            Dim Preventthepointtoomanytimes2514 As String = error1 & vbCrLf & "详细报错：" & error2
            textBlock.Text = Preventthepointtoomanytimes2514

        Catch ex As Exception
            Dim em As String = ex.Message.Replace("。", "")
            textBlock.Text = "呜呜呜，我被玩坏了～主人救救我吧……" & vbCrLf & "主人，我" & em & "了，求求主人寻找良医药方吧喵呜……" & vbCrLf & vbCrLf & "根本病因：" & ex.ToString
        End Try
    End Sub

    Private Sub toanswer_click(sender As Object, e As RoutedEventArgs) Handles ToAnswer.Click
        Clipboard.SetText(error1 & vbCrLf & "详细报错：" & error2)
        MsgBox("已自动将报错消息复制到剪切板", vbInformation)
        Process.Start("https://github.com/SRInternet-Studio/Seewo-Custom_Start/issues")
    End Sub

    'private async sub printtotext(text as string)
    '    printend = false
    '    textblock.text = ""
    '    for i as integer = 0 to text.length() - 1
    '        await task.delay(20)
    '        textblock.text = textblock.text + text(i)
    '    next
    '    printend = true
    'end sub

End Class
