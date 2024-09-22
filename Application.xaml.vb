Imports System.Windows.Threading
Imports System.Diagnostics
Imports System.Security.Principal
Imports System.Reflection

Class Application

    ' 应用程序级事件(例如 Startup、Exit 和 DispatcherUnhandledException)
    ' 可以在此文件中进行处理。

    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
        AddHandler DispatcherUnhandledException, AddressOf Application_DispatcherUnhandledException
        MyBase.OnStartup(e)
    End Sub

    Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        error1 = "SeewoStart 4.0 已不能正常运行，请截图并反馈"
        error2 = e.ExceptionObject.ToString()
        Dim error114 As New error114
        error114.Show()
    End Sub
    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        Dim exePath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim exeFileName As String = System.IO.Path.GetFileNameWithoutExtension(exePath)
        If e.Args.Length > 0 Then
            'MsgBox(e.Args(0).ToString)
            If e.Args(0) = "/settings" Then
                Dim isAdmin As Boolean = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)

                If Not isAdmin Then
                    Dim startInfo As New ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory & exeFileName)
                    startInfo.Verb = "runas"
                    startInfo.Arguments = e.Args(0)
                    Process.Start(startInfo)
                    Process.GetCurrentProcess.Kill()
                End If
                SharedV.StartWindow = "1"
                Dim settingsWindow As New Window1()
                settingsWindow.Show()
            Else
                If e.Args(0) = "/Emergency-mode" Then
                    Dim isAdmin As Boolean = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)

                    If Not isAdmin Then
                        Dim startInfo As New ProcessStartInfo(AppDomain.CurrentDomain.BaseDirectory & exeFileName)
                        startInfo.Verb = "runas"
                        startInfo.Arguments = e.Args(0)
                        Process.Start(startInfo)
                        Process.GetCurrentProcess.Kill()
                    End If
                    SharedV.StartWindow = "1"
                    Dim jy As New Emergency_mode
                    jy.Show()
                Else
                    SharedV.StartString = e.Args(0)
                End If

            End If
            'Else
            '    Dim mainWindow As New MainWindow()
            '    mainWindow.Show()
        End If

        'SharedV.StartWindow = "1"
        'Dim settingsWindow As New Window1()
        'settingsWindow.Show()
    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.[Exit]
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub Application_DispatcherUnhandledException(sender As Object, e As Windows.Threading.DispatcherUnhandledExceptionEventArgs) Handles Me.DispatcherUnhandledException
        error1 = "SeewoStart 4.0 已不能正常运行，请截图并反馈"
        error2 = e.Exception.ToString()
        Dim error114 As New error114
        error114.Show()
        e.Handled = True
    End Sub
End Class
