Imports System.IO
Imports System.Media
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Public Class MainWindow
    Inherits Window

    Private firstLine As String = String.Empty
    Private secondLine As String = String.Empty
    Private thirdLine As String = String.Empty
    Private fourLine As String = String.Empty
    Private fifthLine As String = String.Empty
    Private sixthLine As String = String.Empty
    Private seventhLine As String = String.Empty
    Private eighthLine As String = String.Empty
    Private ninthLine As String = String.Empty
    Private tenthLine As String = String.Empty

    Private ReadOnly classNameRegex As String = "HwndWrapper\[\w+;;(.*?)\]" ' 使用正则表达式从类名中提取 GUID
    Private ReadOnly targetClassName As String = "HwndWrapper[EasiNote;;a202198c-ccc9-4ab4-943a-bc666c7851a3]" ' 目标窗口的类名
    Private IsEnded As Boolean = False
    Private starting_config As String
    'Dim targetTitle As String = "希沃白板" ' 目标窗口的标题
    Private Declare Function IsWindowVisible Lib "user32.dll"(hWnd As IntPtr) As Boolean
    'Private Declare Function FindWindowEx Lib "user32.dll" (ByVal hwndParent As IntPtr, ByVal hwndChildAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
    Private Declare Function FindWindowEx Lib "user32.dll" Alias "FindWindowExA"(hwndParent As IntPtr,
                                                                                 hwndChildAfter As IntPtr,
                                                                                 lpszClass As String,
                                                                                 lpszWindow As String) As IntPtr
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA"(hwnd As IntPtr,
                                                                                   lpString As StringBuilder,
                                                                                   cch As Integer) As Integer
    Private Declare Function GetClassName Lib "user32.dll" Alias "GetClassNameA"(hWnd As IntPtr,
                                                                                 lpClassName As StringBuilder,
                                                                                 nMaxCount As Integer) As Integer

    Private WithEvents pollTimer As New DispatcherTimer()
    Private ReadOnly started As Boolean = False

    <DllImport("user32.dll", SetLastError := True, CharSet := CharSet.Auto)>
    Private Shared Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr
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
    '        Dim className As New StringBuilder(512)
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
        Dim windows = Application.Current.Windows.OfType (Of Window)()

        Dim existingWindow = windows.FirstOrDefault(Function(w) w.Title = windowTitle)

        Return existingWindow IsNot Nothing
    End Function

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

            Dim appDirectory As String = AppDomain.CurrentDomain.BaseDirectory _
            'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

            Dim ThemsDirectory As String = appDirectory & "\Thems"

            Dim folders() As String = Directory.GetDirectories(ThemsDirectory)

            Debug.WriteLine(folders.Length)

            Dim filePath As String = appDirectory & "\settings.ini"
            Dim configPath As String = appDirectory & "\product.config"
            Console.WriteLine(starting_config)

            If File.Exists(configPath) Then
                Using reader As New StreamReader(configPath)
                    starting_config = reader.ReadLine()
                    Console.WriteLine(starting_config)
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

                    ninthLine = reader.ReadLine()

                    tenthLine = reader.ReadLine()
                End Using
            End If

            Dim selectedFolder As String

            Try
                image2_Copy.Source = New BitmapImage(New Uri(appDirectory & "\swenlauncher.ico", UriKind.Absolute))
            Catch ex As Exception
                MsgBox("主题读取失败。 " & secondLine & " swenlauncher.ico 可能消失了，这意味着我们无法获取将要启动的程序的图标。", vbExclamation)
            End Try


            If ninthLine = "True" Then
                If folders.Length > 0 Then
                    ' 生成随机索引
                    Dim random As New Random()
                    Dim randomIndex As Integer = random.Next(0, folders.Length)

                    ' 获取随机选择的文件夹
                    selectedFolder = folders(randomIndex)

                    Try
                        '获取选定文件夹内的所有文件
                        Dim files() As String = Directory.GetFiles(selectedFolder)

                        Dim wholeDirectory As String = selectedFolder & "\background.png"

                        Dim wholeDirectory_1 As String = selectedFolder & "\StartIMG.png"

                        Dim wholeDirectory_2 As String = selectedFolder & "\trademark.png"

                        Debug.WriteLine(wholeDirectory)

                        image.Source = New BitmapImage(New Uri(wholeDirectory, UriKind.Absolute))

                        yuanshen.Source = New BitmapImage(New Uri(wholeDirectory_1, UriKind.Absolute))

                        image2.Source = New BitmapImage(New Uri(wholeDirectory_2, UriKind.Absolute))
                    Catch ex As Exception
                        MsgBox("主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。", vbExclamation)
                    End Try
                Else
                    MsgBox("主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。", vbExclamation)
                End If
            Else
                selectedFolder = Path.Combine(path1 := ThemsDirectory, path2 := ninthLine)
                Try
                    '获取选定文件夹内的所有文件
                    Dim files() As String = Directory.GetFiles(selectedFolder)

                    Dim wholeDirectory As String = selectedFolder & "\background.png"

                    Dim wholeDirectory_1 As String = selectedFolder & "\StartIMG.png"

                    Dim wholeDirectory_2 As String = selectedFolder & "\trademark.png"

                    Debug.WriteLine(wholeDirectory)

                    image.Source = New BitmapImage(New Uri(wholeDirectory, UriKind.Absolute))

                    yuanshen.Source = New BitmapImage(New Uri(wholeDirectory_1, UriKind.Absolute))

                    image2.Source = New BitmapImage(New Uri(wholeDirectory_2, UriKind.Absolute))
                Catch ex As Exception
                    MsgBox("主题读取失败。 " & secondLine & " 请检查 Thems 文件夹是否为空，或其内部图片是否完好。", vbExclamation)
                End Try
            End If


            textBlock.Text = fourLine
            textBlock1.Text = fifthLine
            textBlock2.Text = sixthLine
            textBlock3.Text = seventhLine
            textBlock4.Text = eighthLine

            Dim processName As String = firstLine
            Dim isRunning As Boolean = IsProcessRunning(processName)

            If isRunning Then
                End
            End If

            If tenthLine = "False" Then
                Try
                    Dim sound As New SoundPlayer(appDirectory & "\Start.wav") ' 替换为实际的音效文件路径
                    sound.Play()
                Catch ex As Exception
                    MsgBox("音效触发失败。 " & secondLine & "请检查 Start.wav 是否可用，或在设置界面中关闭启动音效。", vbExclamation)
                End Try
            End If

            Start()
            Focus()
        Else
            Hide()
            Close()
        End If
    End Sub

    Private Async Sub Start()
        Focus()
        Await Task.Delay(4000)
        Focus()
        If SharedV.StartString IsNot Nothing Then
            textBlock2.Text = "正在加载：" & SharedV.StartString
        End If
        Focus()
        Await Task.Delay(2000)
        Focus()
        Try
            If SharedV.StartString = Nothing Then
                Process.Start(secondLine, "-m Display -iwb")
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
        Dim startStoryboard = TryCast(FindResource("EndAni"), Storyboard)
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
            Ended()
        Else
            Console.WriteLine("窗口不存在")
        End If
    End Sub
End Class
