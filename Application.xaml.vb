Class Application

    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        If e.Args.Length > 0 Then
            'MsgBox(e.Args(0).ToString)
            If e.Args(0) = "/settings" Then
                SharedV.StartWindow = "1"
                Dim settingsWindow As New Window1()
                settingsWindow.Show()
            Else
                SharedV.StartString = e.Args(0)
            End If
            'Else
            '    Dim mainWindow As New MainWindow()
            '    mainWindow.Show()
        End If

        'SharedV.StartWindow = "1"
        'Dim settingsWindow As New Window1()
        'settingsWindow.Show()
    End Sub

End Class
