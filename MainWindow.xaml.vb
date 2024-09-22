Imports System.IO
Imports System.Media
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Media.Animation
Imports System.Windows.Threading


Public Class MainWindow
    Inherits Window
    Public zt As String
    Private firstLine As String = String.Empty
    'Private secondLine As String = String.Empty
    Private thirdLine As String = String.Empty
    Private fourLine As String = String.Empty
    Private fifthLine As String = String.Empty
    Private sixthLine As String = String.Empty
    Private seventhLine As String = String.Empty
    Private eighthLine As String = String.Empty
    Dim wjjlj As String
    Dim sound As New MediaPlayer()
    'Private ninthLine As String = String.Empty
    Private tenthLine As String = String.Empty
    Private Line11 As String = String.Empty
    'Private Line12 As String = String.Empty
    'Private Line13 As String = String.Empty
    Private Line14 As String = String.Empty
    Private Line15 As String = String.Empty
    Private Line16 As String = String.Empty
    Private Startupparameters As String = String.Empty
    Private textw1 As String
    Private textw2 As String
    Private textw3 As String
    Private textw4 As String
    Private textw5 As String
    Private onoffmp4 As String
    Public musicfile As String
    Private ReadOnly classNameRegex As String = "HwndWrapper\[\w+;;(.*?)\]" ' 使用正则表达式从类名中提取 GUID
    Private ReadOnly targetClassName As String = "HwndWrapper[EasiNote;;a202198c-ccc9-4ab4-943a-bc666c7851a3]" ' 目标窗口的类名
    Private IsEnded As Boolean = False
    'Private starting_config As String
    'Dim targetTitle As String = "希沃白板" ' 目标窗口的标题
    Private Declare Function IsWindowVisible Lib "user32.dll" (ByVal hWnd As IntPtr) As Boolean
    'Private Declare Function FindWindowEx Lib "user32.dll" (ByVal hwndParent As IntPtr, ByVal hwndChildAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
    Private Declare Function FindWindowEx Lib "user32.dll" Alias "FindWindowExA" (ByVal hwndParent As IntPtr, ByVal hwndChildAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As StringBuilder, ByVal cch As Integer) As Integer
    Private Declare Function GetClassName Lib "user32.dll" Alias "GetClassNameA" (ByVal hWnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer

    Private WithEvents pollTimer As New DispatcherTimer()
    Private ReadOnly started As Boolean = False
    Public backgroundfile As String
    Public startimgfile As String
    Public trademarkfile As String

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function
    'Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
    '    MyBase.OnInitialized(e)

    '    ' 查找窗口标题为"希沃白板"的窗口
    '    Dim hWnd As IntPtr = FindWindow(Nothing, "希沃白板")

    '    If hWnd <> IntPtr.Zero Then
    '        MessageBox.Show("窗口存在")
    '    Else
    '        MessageBox.Show("窗口不存在")
    '    End If
    'End Sub
    'Private Sub PollWindowVisible()

    '    ' 通过遍历顶级窗口找到目标窗口
    '    Dim rootHWnd As IntPtr = IntPtr.Zero
    '    Dim currentHWnd As IntPtr = IntPtr.Zero
    '    While True
    '        currentHWnd = FindWindowEx(rootHWnd, currentHWnd, Nothing, Nothing)
    '        If currentHWnd = IntPtr.Zero Then
    '            ' 遍历完毕，退出循环
    '            Exit While
    '        End If

    '        Dim windowText As New StringBuilder(512)
    '        Dim className As New StringBuilder(512
    '        GetWindowText(currentHWnd, windowText, windowText.Capacity)
    '        GetClassName(currentHWnd, className, className.Capacity)

    '        ' 使用正则表达式匹配类名
    '        Dim match As Match = Regex.Match(className.ToString(), classNameRegex)
    '        If match.Success AndAlso match.Groups.Count > 1 Then
    '            Dim guid As String = match.Groups(1).Value
    '            If className.ToString() = targetClassName AndAlso windowText.ToString() = targetTitle Then
    '                ' 找到了目标窗口，检查窗口是否可见
    '                Dim isVisible As Boolean = IsWindowVisible(currentHWnd)
    '                If isVisible Then
    '                    ' 窗口可见，执行相应的操作
    '                    Hide()
    '                    Close()
    '                    End
    '                Else
    '                    ' 窗口不可见，执行相应的操作
    '                    '...
    '                    Console.WriteLine("Noooooooooooo")
    '                    Exit Sub ' 可根据需要决定是否结束轮询
    '                End If
    '            End If
    '        End If
    '    End While

    '    ' 找不到窗口，执行相应的操作
    '    '...
    '    Console.WriteLine("Onnnnnnnnnnnn")
    'End Sub

    ' 寻找窗口是否存在的方法
    Public Function IsWindowExistsByTitle(windowTitle As String) As Boolean
        Dim windows = Application.Current.Windows.OfType(Of Window)()

        Dim existingWindow = windows.FirstOrDefault(Function(w) w.Title = windowTitle)

        Return existingWindow IsNot Nothing
    End Function
    Public Sub New()

        ' 設計工具需要此呼叫。
        InitializeComponent()
        'If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "\zt.ttf") Then
        '    Dim fontUri As New Uri(AppDomain.CurrentDomain.BaseDirectory & "\zt.ttf", UriKind.Absolute)
        '    Dim fontFamily As New FontFamily(fontUri, "MyFontName") ' 

        '    textBlock.FontFamily = fontFamily
        '    textBlock1.FontFamily = fontFamily
        '    textBlock2.FontFamily = fontFamily
        '    textBlock3.FontFamily = fontFamily
        '    textBlock4.FontFamily = fontFamily
        '    textBlock_Copy6.FontFamily = fontFamily
        'End If
    End Sub

    Public offoncs As String
    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        If (SharedV.StartWindow = "1") = False Then

            Focus()

            'Dim FontFamily As New FontFamily("DingTalk JinBuTi")
            'If Not Fonts.SystemFontFamilies.Contains(FontFamily) Then
            '    Dim window2 As New Window2
            '    Hide()
            '    window2.ShowDialog()
            'End If

            Topmost = True

            Dim appDirectory As String = AppDomain.CurrentDomain.BaseDirectory 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

            Dim ThemsDirectory As String = appDirectory & "\Thems"

            Dim folders() As String = Directory.GetDirectories(ThemsDirectory)

            System.Diagnostics.Debug.WriteLine(folders.Length)

            Dim filePath As String = appDirectory & "\settings.ini"
            Dim configPath As String = appDirectory & "\product.config"
            Console.WriteLine(starting_config)

            If File.Exists(configPath) Then
                Using reader As New StreamReader(configPath)
                    starting_config = reader.ReadLine()
                    Startupparameters = reader.ReadLine()
                    offoncs = reader.ReadLine()
                    Console.WriteLine(starting_config)
                    Console.WriteLine(offoncs)
                End Using
            End If
            Console.WriteLine(starting_config)

            If File.Exists(filePath) Then
                Using reader As New StreamReader(filePath)
                    firstLine = reader.ReadLine()

                    secondLine = reader.ReadLine()

                    thirdLine = reader.ReadLine()

                    fourLine = reader.ReadLine()

                    fifthLine = reader.ReadLine()

                    sixthLine = reader.ReadLine()

                    seventhLine = reader.ReadLine()

                    eighthLine = reader.ReadLine()

                    ninthline = reader.ReadLine()

                    tenthLine = reader.ReadLine()

                    Line11 = reader.ReadLine()

                    line12 = reader.ReadLine()

                    line13 = reader.ReadLine()

                    Line14 = reader.ReadLine()

                    Line15 = reader.ReadLine()

                    ' Line16 = reader.ReadLine()
                End Using
            End If
            ' If File.Exists(appDirectory & "\file.sr") Then

            Using reader As New StreamReader(appDirectory & "\Emergency-mode.Sr")
                zt = reader.ReadLine()
            End Using
            If zt = "True" Then
                Hide()
                Try
                    If SharedV.StartString = Nothing Then
                        If line12 = "True" Then
                            Process.Start(secondLine, Startupparameters)
                        Else
                            Process.Start(secondLine)
                        End If
                    Else
                        'MsgBox("""" & SharedV.StartString & """")
                        Process.Start(secondLine, """" & SharedV.StartString & """")
                    End If
                Catch ex As Exception
                    MsgBox("无法启动希沃白板,文件路径有误" & secondLine, vbExclamation)
                End Try
                Process.GetCurrentProcess.Kill()
            End If
            '  End If
            Waittime = thirdLine
            'xiwofile = secondLine
            'If Line14 = True Then
            '  Dim hWnd As IntPtr = FindWindow(Nothing, "SeewoPro loading……")
            '    Console.WriteLine("SeewoPro loading……")

            '    If hWnd <> IntPtr.Zero Then
            '          Console.WriteLine("窗口存在，退出")
            '            End
            '        Else
            'Console.WriteLine("窗口不存在")
            '  End If
            'End If

            If File.Exists(appDirectory & "\file.sr") Then
                Using reader As New StreamReader(appDirectory & "\file.sr")
                    'backgroundfile = reader.ReadLine()



                    'trademarkfile = reader.ReadLine()
                    'startimgfile = reader.ReadLine()
                    musicfile = reader.ReadLine()
                End Using
            End If
            If line13 = "True" Then
                Dim hWnd As IntPtr = FindWindow(Nothing, starting_config)
                Console.WriteLine(starting_config)

                If hWnd <> IntPtr.Zero Then
                    Console.WriteLine("窗口存在，退出")
                    If line12 = "True" Then
                        Process.Start(secondLine, Startupparameters)
                    Else
                        Process.Start(secondLine)
                    End If
                    End
                Else
                    Console.WriteLine("窗口不存在")
                End If
            End If

            Dim selectedFolder As String

            Try
                image2_Copy.Source = New BitmapImage(New Uri(appDirectory & "\sbenlauncher.ico", UriKind.Absolute))
            Catch ex As Exception
                MsgBox("主题读取失败。 " & secondLine & " sbenlauncher.ico 可能消失了，这意味着我们无法获取将要启动的程序的图标。", vbExclamation)
            End Try


            If ninthline = "True" Then
                If folders.Length > 0 Then
                    ' 生成随机索引
                    Dim random As New Random()
                    Dim randomIndex As Integer = random.Next(0, folders.Length)

                    ' 获取随机选择的文件夹
                    selectedFolder = folders(randomIndex)
                    wjjlj = selectedFolder


                    Try
                        If File.Exists(wjjlj & "\mp4.sr") Then

                            Using reader As New StreamReader(wjjlj & "\mp4.sr")
                                onoffmp4 = reader.ReadLine()

                            End Using
                        End If

                        '获取选定文件夹内的所有文件
                        Dim files() As String = Directory.GetFiles(selectedFolder)
                        If File.Exists(selectedFolder & "\file.sr") Then

                            Using reader As New StreamReader(selectedFolder & "\file.sr")
                                backgroundfile = reader.ReadLine()
                                trademarkfile = reader.ReadLine()
                                startimgfile = reader.ReadLine()
                                Line16 = reader.ReadLine()

                            End Using
                        End If
                        Dim wholeDirectory As String = selectedFolder & "\" & backgroundfile

                        Dim wholeDirectory_1 As String = selectedFolder & "\" & startimgfile

                        Dim wholeDirectory_2 As String = selectedFolder & "\" & trademarkfile


                        System.Diagnostics.Debug.WriteLine(wholeDirectory)

                        image.Source = New BitmapImage(New Uri(wholeDirectory, UriKind.Absolute))

                        yuanshen.Source = New BitmapImage(New Uri(wholeDirectory_1, UriKind.Absolute))

                        image2.Source = New BitmapImage(New Uri(wholeDirectory_2, UriKind.Absolute))
                    Catch ex As Exception
                        Dim errorw As New error114()

                        errorw.ShowDialog()
                    End Try
                Else
                    Hide()
                    Dim errorw As New error114()
                    error1 = "主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。"
                    error2 = "无"
                    errorw.ShowDialog()
                    Close()
                End If
            Else
                selectedFolder = Path.Combine(path1:=ThemsDirectory, path2:=ninthline)
                Try
                    If File.Exists(selectedFolder & "\mp4.sr") Then

                        Using reader As New StreamReader(selectedFolder & "\mp4.sr")
                            onoffmp4 = reader.ReadLine()

                        End Using
                    End If
                    '获取选定文件夹内的所有文件
                    Dim files() As String = Directory.GetFiles(selectedFolder)
                    If File.Exists(selectedFolder & "\file.sr") Then

                        Using reader As New StreamReader(selectedFolder & "\file.sr")
                            backgroundfile = reader.ReadLine()
                            trademarkfile = reader.ReadLine()
                            startimgfile = reader.ReadLine()
                            Line16 = reader.ReadLine()

                        End Using
                    End If

                    Dim wholeDirectory As String = selectedFolder & "\" & backgroundfile

                    Dim wholeDirectory_1 As String = selectedFolder & "\" & startimgfile

                    Dim wholeDirectory_2 As String = selectedFolder & "\" & trademarkfile




                    System.Diagnostics.Debug.WriteLine(wholeDirectory)

                    image.Source = New BitmapImage(New Uri(wholeDirectory, UriKind.Absolute))

                    yuanshen.Source = New BitmapImage(New Uri(wholeDirectory_1, UriKind.Absolute))

                    image2.Source = New BitmapImage(New Uri(wholeDirectory_2, UriKind.Absolute))
                    If Line16 = "True" Then
                        If File.Exists(selectedFolder & "\text.ini") Then

                            Using reader As New StreamReader(selectedFolder & "\text.ini")
                                textw1 = reader.ReadLine()
                                textw2 = reader.ReadLine()
                                textw3 = reader.ReadLine()
                                textw4 = reader.ReadLine()
                                textw5 = reader.ReadLine()

                            End Using
                        End If
                        textBlock.Text = textw1
                        textBlock1.Text = textw2
                        textBlock2.Text = textw3
                        textBlock3.Text = textw4
                        textBlock4.Text = textw5
                    End If
                Catch ex As Exception
                    Hide()
                    Dim errorw As New error114()
                    error1 = "主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。"
                    error2 = ex.ToString
                    errorw.ShowDialog()
                    Close()
                End Try

            End If
            If onoffmp4 = "False" Then
            Else

                If onoffmp4 = "True" Then
                    Enableclicking = Nothing
                    Hide()
                    Dim window18 As New mp4

                    window18.ShowDialog()
                    Show()
                Else
                    If onoffmp4 = "TrueWindow" Then
                        Whethertostartinfullscreen = "ON"
                        Hide()
                        Dim window18 As New mp46

                        window18.ShowDialog()
                        Show()
                    Else
                        If onoffmp4 = "TrueWindow1" Then
                            Whethertostartinfullscreen = "ON"
                            Enableclicking = "SR"
                            Hide()
                            Dim window18 As New mp46
                            window18.ShowDialog()
                            Show()


                        Else

                            Enableclicking = "SR"
                            Hide()
                            Dim window18 As New mp4
                            window18.ShowDialog()
                            Show()
                        End If
                    End If
                End If

            End If
            If Line16 = "True" Then

                If File.Exists(wjjlj & "\text.ini") Then

                    Using reader As New StreamReader(wjjlj & "\text.ini")
                        textw1 = reader.ReadLine()
                        textw2 = reader.ReadLine()
                        textw3 = reader.ReadLine()
                        textw4 = reader.ReadLine()
                        textw5 = reader.ReadLine()
                    End Using
                End If
                textBlock.Text = textw1
                textBlock1.Text = textw2
                textBlock2.Text = textw3
                textBlock3.Text = textw4
                textBlock4.Text = textw5
                textBlock_Copy6.Text = textw1
                If textw2 = "" Then
                    textBlock1.Visibility = Visibility.Hidden
                    textBlock_Copy6.Visibility = Visibility.Visible
                    textBlock.Text = Nothing
                End If

            Else
                textBlock.Text = fourLine
                textBlock1.Text = fifthLine
                textBlock2.Text = sixthLine
                textBlock3.Text = seventhLine
                textBlock4.Text = eighthLine
                textBlock_Copy6.Text = fourLine
                If fifthLine = "" Then
                    textBlock1.Visibility = Visibility.Hidden
                    textBlock_Copy6.Visibility = Visibility.Visible
                    textBlock.Text = Nothing
                End If

            End If
            Dim processName As String = firstLine
            Dim isRunning As Boolean = IsProcessRunning(processName)

            If isRunning Then
                End
            End If

            If tenthLine = "False" Then
                Try
                    sound.Open(New Uri(appDirectory & "\" & musicfile, UriKind.Absolute)) ' 替换为实际的音效文件路径
                    sound.Play()
                Catch ex As Exception
                    MsgBox("音效触发失败。 " & secondLine & "请检查" & musicfile & "是否可用，或在设置界面中关闭启动音效。", vbExclamation)
                End Try
                End If
            'If Line11 = "True" The
            '  Try
            '        kdtkyd6666.Source = New Uri(selectedFolder & "/startMP4.MP4", UriKind.Absolute)
            '          Catch ex As Exception
            '            MsgBox("视频触发失败,请检查" & selectedFolder & "\startmp4.mp4是否可用，或在设置页面中关闭启动视频。", vbExclamation)
            '            End Try
            'End If

            Start()
                Focus()
            Else
                Hide()
            Close()
        End If
    End Sub

    Private Async Sub Start()
        Focus()
        Await Task.Delay(1000)
        Focus()
        If SharedV.StartString IsNot Nothing Then
            textBlock2.Text = "正在加载：" & SharedV.StartString
        End If
        Focus()
        Await Task.Delay(2000)
        Focus()
        Try

            If SharedV.StartString = Nothing Then
                If line12 = "True" Then
                    Process.Start(secondLine, Startupparameters)
                Else
                    Process.Start(secondLine)
                End If
            Else
                'MsgBox("""" & SharedV.StartString & """")
                Process.Start(secondLine, """" & SharedV.StartString & """")
            End If
        Catch ex As Exception
            MsgBox("无法启动 " & secondLine & " 请检查程序路径是否有误。", vbExclamation)
            End
        End Try
        ' 配置计时器
        pollTimer.Interval = TimeSpan.FromSeconds(0.5) ' 设置轮询间隔为1秒
        pollTimer.Start() ' 启动计时器
        Console.WriteLine("启动监测")
        Focus()
        Await Task.Delay(Int(thirdLine))
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
        Dim startStoryboard As Storyboard = TryCast(FindResource("EndAni"), Storyboard)
        ' 当Storyboard资源存在时，播放动画
        startStoryboard.Begin()
        Await Task.Delay(2000)
        Hide()
        Close()
        End
    End Sub

    Private Function IsProcessRunning(processName As String) As Boolean
        Dim runningProcesses() As Process = Process.GetProcessesByName(processName)
        Return runningProcesses.Length > 0
    End Function
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
            Ended（）
        Else
            Console.WriteLine("窗口不存在")
        End If
    End Sub
End Class
