Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Threading

Public Class mp4
    Dim time As String '时间
    Dim selectedFolder As String '选择的文件夹

    Dim startmp4file As String
    Dim startmp4file514 As String
    Private firstLine As String = String.Empty
    'Private secondLine As String = String.Empty
    Private timewhenthecountdownstarts As String
    Private IsEnded As Boolean = False
    Private starting_config As String
    Public ClickLaunch As String = Nothing
    Private Declare Function FindWindowEx Lib "user32.dll" Alias "FindWindowExA" (ByVal hwndParent As IntPtr, ByVal hwndChildAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
    Private Declare Function GetClassName Lib "user32.dll" Alias "GetClassNameA" (ByVal hWnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
    Private WithEvents pollTimer As New DispatcherTimer()
    Private ReadOnly started As Boolean = False
    Public Determinewhetherthevideowasclicked As Boolean = False
    Public isend114 As Boolean = True
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function
    Dim appDirecory As String = AppDomain.CurrentDomain.BaseDirectory
    Dim ThemsDirectory As String = AppDomain.CurrentDomain.BaseDirectory & "\Thems"
    Private Sub mp4_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Topmost = True
        Dim folders() As String = Directory.GetDirectories(ThemsDirectory)
        'If Whethertostartinfullscreen = "ON" Then
        '    Me.WindowState = WindowState.Normal
        'End If
        System.Diagnostics.Debug.WriteLine(folders.Length)
        If File.Exists("product.config") Then
            Using reader As New StreamReader("product.config")
                Dim a114 As String = reader.ReadLine() '没用的变量，占行的

                Startupparameters = reader.ReadLine()

                firstLine = reader.ReadLine()

                timewhenthecountdownstarts = reader.ReadLine()


            End Using
        End If
        If ninthline = "True" Then
            If folders.Length > 0 Then

                Dim random As New Random()
                Dim randomIndex As Integer = random.Next(0, folders.Length)

                selectedFolder = folders(randomIndex)


                Try

                    Dim files() As String = Directory.GetFiles(selectedFolder)

                    startmp4file = selectedFolder & "\startmp4.mp4"

                    If Enableclicking = "SR" Then
                        ClickLaunch = selectedFolder & "\startmp41.mp4"
                    End If


                Catch ex As Exception
                    MsgBox("主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。", vbExclamation)
                End Try
            Else
                MsgBox("主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。", vbExclamation)
            End If
            Try
                If File.Exists(startmp4file) Then
                    kdtkyd6666.Source = New Uri(startmp4file, UriKind.Absolute)
                    'kdtkyd6666.Play()
                Else
                    MsgBox("视频触发失败,请检查" & startmp4file & "\startmp4.mp4是否可用，或在设置页面中关闭启动视频", vbExclamation）
                    isend114 = False
                    Close()
                End If
                ' kdtkyd6666.Source = New Uri(startmp4file, UriKind.Absolute)

            Catch ex As Exception
                MsgBox("视频触发失败,请检查" & startmp4file & "\startmp4.mp4是否可用，或在设置页面中关闭启动视频。错误信息::" & ex.ToString, vbExclamation）
                '   End
            End Try
        Else
            selectedFolder = Path.Combine(path1:=ThemsDirectory, path2:=ninthline)
            Try

                Dim files() As String = Directory.GetFiles(selectedFolder)

                startmp4file514 = selectedFolder & "\startmp4.mp4"


                If Enableclicking = "SR" Then
                    ClickLaunch = selectedFolder & "\startmp41.mp4"
                End If




                System.Diagnostics.Debug.WriteLine(startmp4file514)



            Catch ex As Exception
                MsgBox("主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。", vbExclamation)
            End Try
            Try
                If File.Exists(startmp4file514) Then
                    kdtkyd6666.Source = New Uri(startmp4file514, UriKind.Absolute)
                    'kdtkyd6666.Play()
                Else
                    MsgBox("视频触发失败,请检查" & startmp4file514 & "\startmp4.mp4是否可用，或在设置页面中关闭启动视频", vbExclamation）
                    isend114 = False
                    Close()
                End If


            Catch ex As Exception
                MsgBox("视频触发失败,请检查" & startmp4file514 & "\startmp4.mp4是否可用，或在设置页面中关闭启动视频。错误信息::" & ex.ToString, vbExclamation）
                Close()
            End Try
        End If
        If firstLine = "False" And ClickLaunch IsNot Nothing Then

            isend114 = False
            MsgBox("暂不支持点击后启动与倒计时启动同时启用qwq", vbInformation)
            Close()

        End If
        If firstLine = "False" And ClickLaunch = Nothing Then
            countdownstarts()
        End If
    End Sub

    Private Sub kdtkyd6666_MediaEnded() Handles kdtkyd6666.MediaEnded
        kdtkyd6666.Stop()
        Console.WriteLine("114")
        'If firstLine = "True" Then
        Try
            If ClickLaunch = Nothing Then
                If SharedV.StartString = Nothing Then
                    'MsgBox(line12)
                    'MsgBox(Startupparameters)
                    If line12 = "True" Then
                        Process.Start(secondLine, Startupparameters)
                    Else
                        Process.Start(secondLine)
                    End If
                    Initiateswindowdetection()
                Else


                    Process.Start(secondLine, """" & SharedV.StartString & """")
                    Initiateswindowdetection()
                End If

            Else
                'kdtkyd6666_Copy.Visibility = Visibility.Visible
                Determinewhetherthevideowasclicked = True
            End If




        Catch ex As Exception
            MsgBox("无法启动 " & secondLine & " 请检查程序路径是否有误。", vbExclamation)
            End
        End Try

        'End If


    End Sub
    Private Async Sub Initiateswindowdetection()
        pollTimer.Interval = TimeSpan.FromSeconds(0.5) ' 设置轮询间隔为1秒
        pollTimer.Start() ' 启动计时器
        Console.WriteLine("启动监测")
        Focus()
        Await Task.Delay(Int(Waittime))
        Hide()
        Close()

    End Sub



    Private Sub pollTimer_Tick(sender As Object, e As EventArgs) Handles pollTimer.Tick
        Topmost = True
        Focus()
        ' 执行轮询
        'PollWindowVisible()

        'Dim windowTitle As String = "希沃白板"

        'Dim windowExists As Boolean = IsWindowExistsByTitle(windowTitle)
        'If windowExists Then
        '    Console.WriteLine("窗口存在")
        'Else
        '    Console.WriteLine("窗口不存在")
        'End If
        ' 查找窗口标题为"希沃白板"的窗口
        Dim hWnd As IntPtr = FindWindow(Nothing, starting_config)
        Console.WriteLine(starting_config)

        If hWnd <> IntPtr.Zero Then
            Console.WriteLine("窗口存在，退出")
            Ended()
        Else
            Console.WriteLine("窗口不存在")
        End If
    End Sub
    Private Async Sub countdownstarts()
        Await Task.Delay(Int(timewhenthecountdownstarts))
        Try
            If SharedV.StartString = Nothing Then
                If line12 = "True" Then
                    Process.Start(secondLine, Startupparameters)
                Else
                    Process.Start(secondLine)
                End If
            Else

                Process.Start(secondLine, """" & SharedV.StartString & """")
            End If
        Catch ex As Exception
            MsgBox("无法启动 " & secondLine & " 请检查程序路径是否有误。", vbExclamation)
            End
        End Try
        pollTimer.Interval = TimeSpan.FromSeconds(0.5)
        pollTimer.Start()
        Console.WriteLine("启动监测")
        Focus()
        Await Task.Delay(Int(Waittime))
        Hide()
        Close()
        If IsEnded = False Then
            Ended()
        End If
    End Sub
    Private Async Sub Ended()
        IsEnded = True
        Focus()
        pollTimer.Stop()
        Await Task.Delay(2000)
        Hide()
        Close()
        End
    End Sub

    Private Sub mp4_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If isend114 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub kdtkyd6666_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles kdtkyd6666.MouseLeftButtonDown
        Console.WriteLine(Determinewhetherthevideowasclicked)
        If Determinewhetherthevideowasclicked Then
            Determinewhetherthevideowasclicked = False
            If File.Exists(ClickLaunch) Then
                Me.Background = New SolidColorBrush(Media.Color.FromRgb(255, 255, 255))
                kdtkyd6666_Copy.Visibility = Visibility.Visible
                kdtkyd6666_Copy.Source = New Uri(ClickLaunch, UriKind.Absolute)

                kdtkyd6666_Copy.Play()


                kdtkyd6666.Visibility = Visibility.Hidden
                Try
                    If SharedV.StartString = Nothing Then
                        If line12 = "True" Then
                            Process.Start(secondLine, Startupparameters)
                        Else
                            Process.Start(secondLine)
                        End If
                        'Initiateswindowdetection()
                    Else


                        Process.Start(secondLine, """" & SharedV.StartString & """")
                        'Initiateswindowdetection()
                    End If
                Catch ex As Exception
                    MsgBox("无法启动 " & secondLine & " 请检查程序路径是否有误。", vbExclamation)
                    End
                End Try
            Else
                MsgBox("视频触发失败,请检查" & startmp4file514 & "\startmp42.mp4是否可用，或在设置页面中关闭启动视频点击", vbExclamation）

                isend114 = False
                Close()
            End If


        End If
    End Sub

    Private Sub kdtkyd6666_Copy_MediaEnded(sender As Object, e As RoutedEventArgs) Handles kdtkyd6666_Copy.MediaEnded
        Initiateswindowdetection()

    End Sub
End Class
