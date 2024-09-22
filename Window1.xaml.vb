Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.Windows.Threading
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Public Class Window1
    Private ReadOnly secondWindow As MainWindow
    Private starting_config As String
    Public Videolaunch As String
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
    Private Line11 As String = String.Empty
    Private Line12 As String = String.Empty
    Private Line13 As String = String.Empty
    Private Line14 As String = String.Empty
    Private Line15 As String = String.Empty
    Private Line16 As String = String.Empty
    Private Line17 As String = String.Empty
    Private Line18 As String = String.Empty
    Private zt As String
    Private Parametertext As String
    Public musicfile As String
    Public backgroundfile As String
    Public startimgfile As String
    Public trademarkfile As String
    Private ReadOnly appDirectory As String = AppDomain.CurrentDomain.BaseDirectory 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

    Private ReadOnly ThemsDirectory As String = appDirectory & "\Thems"

    Private folders() As String = Directory.GetDirectories(ThemsDirectory)

    'Public Shared Function ComputeFileHash(ByVal filePath As String) As String
    '    Dim hashProvider As New MD5CryptoServiceProvider()
    '    Dim fileStream As Stream = File.OpenRead(filePath)
    '    Dim hash As Byte() = hashProvider.ComputeHash(fileStream)
    '    fileStream.Close()

    '    Return String.Concat(hash.Select(Function(b) b.ToString("x2")))
    'End Function


    'Public Shared Function AreFilesSame(ByVal filePath1 As String, ByVal filePath2 As String) As Boolean
    '    Dim hash1 As String = ComputeFileHash(filePath1)
    '    Dim hash2 As String = ComputeFileHash(filePath2)

    '    Return hash1.Equals(hash2)
    'End Function
    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ver.Text = "当前程序版本:" & Version
        kdtkyd6666.Stop()

        For i As Integer = 1 To folders.Length()
            Console.WriteLine(i - 1)
            Dim myString As String = folders(i - 1)

            '查找最后一个 "\" 的位置
            Dim lastBackslashIndex As Integer = myString.LastIndexOf("\")
            If lastBackslashIndex <> -1 Then '确保找到了 "\" 符号
                '截取 "\" 后面的全部字符
                Dim result As String = myString.Substring(lastBackslashIndex + 1)
                Console.WriteLine(result) '输出结果

                Dim newItem As New ListBoxItem With {
                    .Content = result
                }
                List1.Items.Add(newItem)

                Dim newItem1 As New ComboBoxItem With {
                    .Content = result
                }
                comboBox.Items.Add(newItem1)
            End If
        Next
        AddHandler List1.SelectionChanged, AddressOf MySelectionChanged


        Dim filePath As String = appDirectory & "\settings.ini"
        Dim configPath As String = appDirectory & "\product.config"
        Console.WriteLine(starting_config)

        If File.Exists(configPath) Then
            Using reader As New StreamReader(configPath)
                starting_config = reader.ReadLine()
                Parametertext = reader.ReadLine()
                Line17 = reader.ReadLine()
                Line18 = reader.ReadLine()
                Console.WriteLine(starting_config)
            End Using
        End If
        If File.Exists(appDirectory & "\file.sr") Then
            Using reader As New StreamReader(appDirectory & "\file.sr")
                'backgroundfile = reader.ReadLine()

                'startimgfile = reader.ReadLine()

                'trademarkfile = reader.ReadLine()
                musicfile = reader.ReadLine()
            End Using
        End If
        textBox.Text = musicfile
        Console.WriteLine(starting_config)
        windowname.Text = starting_config
        cstext.Text = Parametertext
        MySelectionChanged()

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

                Line11 = reader.ReadLine()

                Line12 = reader.ReadLine()

                Line13 = reader.ReadLine()

                Line14 = reader.ReadLine()

                Line15 = reader.ReadLine()

                'Line16 = reader.ReadLine()
            End Using
            _1.Text = fourLine
            _2.Text = fifthLine
            _3.Text = sixthLine
            _4.Text = seventhLine
            _5.Text = eighthLine
        End If

        _filepath.Text = secondLine
        Dim selectedItem As ListBoxItem = List1.SelectedItem
        If File.Exists(ThemsDirectory & "\" & selectedItem.Content & "\file.sr") Then

            Using reader As New StreamReader(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                backgroundfile = reader.ReadLine()

                trademarkfile = reader.ReadLine()
                startimgfile = reader.ReadLine()
                Line16 = reader.ReadLine()
            End Using
        End If
        Try
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & backgroundfile
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & startimgfile
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & trademarkfile
            Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"

            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
            sname.Text = selectedItem.Content
            zt = ThemsDirectory & "\" & selectedItem.Content & "\text.ini"
        Catch ex As Exception
            MsgBox("你是不是偷偷去目录把主题配置文件改成了一个不存在的值？如果不是请截图以下报错反馈！" & vbCrLf & ex.ToString, vbExclamation)
        End Try
        'If Line16 = "True" Then


        '    'Dim filePath1 As String = ThemsDirectory & "\" & selectedItem.Content & "\text.ini"
        '    'If File.Exists(filePath1) Then
        '    '    Console.WriteLine("文件存在")
        '    'Else
        '    '    MsgBox("读取配置时发生错误 " & secondLine & "没有找到主题下的text.ini，请查看文件是否存在，或者取消勾选文字跟随主题", vbExclamation)
        '    'End If


        'Else

        'End If

        If Line17 = "True" Then
            cs_Copy.IsChecked = True
            cstext_Copy.IsEnabled = False
        Else
            cs_Copy.IsChecked = False
            cstext_Copy.IsEnabled = True
        End If

        If ninthLine = "True" Then
            checkBox.IsChecked = True
            comboBox.IsEnabled = False
        Else
            checkBox.IsChecked = False
            comboBox.IsEnabled = True

            Dim founded = False
            For Each item As Object In comboBox.Items ' 遍历ComboBox的所有项
                Dim comboBoxItem As ComboBoxItem = TryCast(item, ComboBoxItem) ' 将项转换为ComboBoxItem类型
                If comboBoxItem IsNot Nothing AndAlso comboBoxItem.Content.ToString() = ninthLine.ToString() Then ' 判断Content属性是否为"测试"
                    comboBox.SelectedItem = comboBoxItem ' 选中该项
                    founded = True
                    Exit For ' 退出循环
                End If
            Next
            'If founded = True Then




            'End If
            If founded = False Then
                MsgBox("读取配置时发生错误 " & secondLine & "没有找到所配置的主题，请重新配置启动时要显示的主题，或勾选【启动时随机选择主题】", vbExclamation)
            End If
        End If


        If tenthLine = "True" Then
            checkBox1.IsChecked = True
            textBox.IsEnabled = False
            button1.IsEnabled = False
        Else
            checkBox1.IsChecked = False
            textBox.IsEnabled = True
            button1.IsEnabled = True
        End If
        'If Line11 = "False" Then
        '    MP4114.IsChecked = True
        '    sname_Copy.IsEnabled = False
        '    namesave_Copy.IsEnabled = False
        '    kdtkyd6666.Visibility = Visibility.Hidden
        'Else
        '    MP4114.IsChecked = False
        '    sname_Copy.IsEnabled = True
        '    namesave_Copy.IsEnabled = True
        '    kdtkyd6666.Visibility = Visibility.Visible
        'End If
        cstext_Copy.Text = Line18
        If Line12 = "True" Then
            cs.IsChecked = True
            cstext.IsEnabled = True
        Else
            cs.IsChecked = False
            cstext.IsEnabled = False
        End If
        If Line13 = "True" Then
            ckjczq.IsChecked = True
        Else
            ckjczq.IsChecked = False
        End If

        If Line15 = "True" Then
            cjmode.IsChecked = True
        Else
            cjmode.IsChecked = False
        End If
    End Sub

    Private Sub MySelectionChanged()
        Try
            '获取当前选中的 ListBoxItem
            Dim selectedItem As ListBoxItem = List1.SelectedItem
            'zt = ThemsDirectory & "\" & selectedItem.Content & "\text.ini"
            Dim bimg As String = Nothing
            Dim simg As String = Nothing
            Dim timg As String = Nothing
            If selectedItem IsNot Nothing Then
                If File.Exists(ThemsDirectory & "\" & selectedItem.Content & "\file.sr") Then

                    Using reader As New StreamReader(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                        bimg = reader.ReadLine()

                        timg = reader.ReadLine()
                        simg = reader.ReadLine()
                        Line16 = reader.ReadLine()
                    End Using
                End If

                If File.Exists(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr") Then

                    Using reader As New StreamReader(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr")
                        Videolaunch = reader.ReadLine()
                    End Using
                End If
                If Videolaunch = "False" Then
                    MP4114.IsChecked = True
                    sname_Copy.IsEnabled = False
                    sname_Copy1.IsEnabled = False
                    namesave_Copy.IsEnabled = False
                    MP4114_Copy.IsEnabled = False
                    MP4114_Copy1.IsEnabled = False
                    kdtkyd6666.Visibility = Visibility.Hidden
                Else
                    If Videolaunch = "False1" Then
                        MP4114_Copy.IsChecked = False
                        MP4114_Copy1.IsChecked = True
                    End If
                    If Videolaunch = "TrueWindow" Then
                        MP4114_Copy.IsChecked = True
                    Else
                        If Videolaunch = "TrueWindow1" Then
                            MP4114_Copy.IsChecked = True
                            MP4114_Copy1.IsChecked = True
                        End If
                    End If
                    MP4114.IsChecked = False
                    sname_Copy.IsEnabled = True
                    sname_Copy1.IsEnabled = True
                    namesave_Copy.IsEnabled = True
                    MP4114_Copy.IsEnabled = True
                    MP4114_Copy1.IsEnabled = True
                    kdtkyd6666.Source = New Uri(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\startmp4.mp4")
                    kdtkyd6666.Stop()
                    kdtkyd6666.Visibility = Visibility.Visible
                End If
                If Line16 = "True" Then
                    ff.IsChecked = True

                    _1.IsEnabled = False
                    _2.IsEnabled = False
                    _3.IsEnabled = False
                    _4.IsEnabled = False
                    _5.IsEnabled = False

                    _1_1.IsEnabled = True
                    _2_2.IsEnabled = True
                    _3_3.IsEnabled = True
                    _4_4.IsEnabled = True
                    _5_5.IsEnabled = True



                    Try
                        'MsgBox(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\text.ini")
                        Using reader As New StreamReader(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\text.ini")
                            _1_1.Text = reader.ReadLine()

                            _2_2.Text = reader.ReadLine()

                            _3_3.Text = reader.ReadLine()

                            _4_4.Text = reader.ReadLine()

                            _5_5.Text = reader.ReadLine()


                        End Using

                    Catch ex As Exception
                        MsgBox("读取配置时发生错误 " & secondLine & "没有找到主题下的text.ini，请查看文件是否存在，或者取消勾选文字跟随主题", vbExclamation)
                    End Try
                Else
                    _1.IsEnabled = True
                    _2.IsEnabled = True
                    _3.IsEnabled = True
                    _4.IsEnabled = True
                    _5.IsEnabled = True
                    ff.IsChecked = False
                    _1_1.IsEnabled = False
                    _2_2.IsEnabled = False
                    _3_3.IsEnabled = False
                    _4_4.IsEnabled = False
                    _5_5.IsEnabled = False
                    _1.Text = fourLine
                    _2.Text = fifthLine
                    _3.Text = sixthLine
                    _4.Text = seventhLine
                    _5.Text = eighthLine
                End If
                tbackground.Text = bimg
                tstartimg.Text = simg
                ttrademark.Text = timg

                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & bimg
                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & simg
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & timg
                Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"

                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                sname.Text = selectedItem.Content
                If Line16 = "True" Then
                    zt = ThemsDirectory & "\" & selectedItem.Content & "\text.ini"
                    If File.Exists(ThemsDirectory & "\" & selectedItem.Content & "\text.ini") Then
                        Using reader As New StreamReader(zt)
                            _1_1.Text = reader.ReadLine()

                            _2_2.Text = reader.ReadLine()

                            _3_3.Text = reader.ReadLine()

                            _4_4.Text = reader.ReadLine()

                            _5_5.Text = reader.ReadLine()

                        End Using
                    End If
                End If

                cuowu.Visibility = Visibility.Hidden
                tbackground.IsEnabled = True
                ttrademark.IsEnabled = True
                tstartimg.IsEnabled = True
                xbacoground.IsEnabled = True
                xtrademark.IsEnabled = True
                xstartimg.IsEnabled = True
                sname.IsEnabled = True
                namesave.IsEnabled = True
                sname_Copy.IsEnabled = True
                namesave_Copy.IsEnabled = True
                sname_Copy1.IsEnabled = True
                namesave_Copy2.IsEnabled = True
                '_1_1.IsEnabled = True
                '_2_2.IsEnabled = True
                '_3_3.IsEnabled = True
                '_4_4.IsEnabled = True
                '_5_5.IsEnabled = True
                namesave_Copy1.IsEnabled = True
                MP4114.IsEnabled = True
                'MP4114_Copy.IsEnabled = True
                'MP4114_Copy1.IsEnabled = True
                ff.IsEnabled = True
                If selectedItem.Content = "default" Or selectedItem.Content = "Default" Or selectedItem.Content = "DEFAULT" Then
                    namesave.IsEnabled = False
                End If
            Else
                cuowu.Visibility = Visibility.Visible
                tbackground.IsEnabled = False
                ttrademark.IsEnabled = False
                tstartimg.IsEnabled = False
                xbacoground.IsEnabled = False
                xtrademark.IsEnabled = False
                xstartimg.IsEnabled = False
                sname.IsEnabled = False
                namesave.IsEnabled = False
                sname_Copy.IsEnabled = False
                namesave_Copy.IsEnabled = False
                sname_Copy1.IsEnabled = False
                namesave_Copy2.IsEnabled = False
                _1_1.IsEnabled = False
                _2_2.IsEnabled = False
                _3_3.IsEnabled = False
                _4_4.IsEnabled = False
                _5_5.IsEnabled = False
                namesave_Copy1.IsEnabled = False
                MP4114.IsEnabled = False
                MP4114_Copy.IsEnabled = False
                MP4114_Copy1.IsEnabled = False
                ff.IsEnabled = False
            End If
        Catch ex As Exception
            cuowu.Visibility = Visibility.Visible
            tbackground.IsEnabled = False
            ttrademark.IsEnabled = False
            tstartimg.IsEnabled = False
            xbacoground.IsEnabled = False
            xtrademark.IsEnabled = False
            xstartimg.IsEnabled = False
            sname.IsEnabled = False
            namesave.IsEnabled = False
            sname_Copy.IsEnabled = False
            namesave_Copy.IsEnabled = False
            sname_Copy1.IsEnabled = False
            namesave_Copy2.IsEnabled = False
            _1_1.IsEnabled = False
            _2_2.IsEnabled = False
            _3_3.IsEnabled = False
            _4_4.IsEnabled = False
            _5_5.IsEnabled = False
            namesave_Copy1.IsEnabled = False
            MP4114.IsEnabled = False
            MP4114_Copy.IsEnabled = False
            MP4114_Copy1.IsEnabled = False
            ff.IsEnabled = False
        End Try
        GC.Collect()
        '...
    End Sub

    Private Sub xbacoground_Click(sender As Object, e As RoutedEventArgs) Handles xbacoground.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing
        kdtkyd6666.Source = Nothing

        GC.Collect()
        Dim selectedItem As ListBoxItem = List1.SelectedItem
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "image Files (*.png;*.jpg;*.jpge;*.bmp)|*.png;*.jpg;*.jpge;*.bmp",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 image 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                If ComparePaths(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\" & tbackground.Text, openFileDialog.FileName) = False Then
                    Dim secondWindow As New Window2
                    Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                    Dim y As Double = Me.Top

                    secondWindow.Left = x
                    secondWindow.Top = y
                    Dim moveAnimation As New DoubleAnimation()
                    moveAnimation.From = secondWindow.Left + secondWindow.Width
                    moveAnimation.To = x
                    moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                    moveAnimation.EasingFunction = New QuarticEase()
                    secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

                    secondWindow.Show()

                    Dim selectedFilePath As String = openFileDialog.FileName
                    tbackground.Text = System.IO.Path.GetFileName(openFileDialog.FileName)
                    errormsgbox = "ok"

                    SharedV.Saving = False



                    GC.Collect()
                    GC.WaitForPendingFinalizers()


                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    File.Delete(background)
                    File.Copy(selectedFilePath, background, True)

                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"

                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                    ' If File.Exists(ThemsDirectory & "\" & List1.SelectedItem.ToString() & "\file.sr") Then
                    File.Delete(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                    Using reader As New StreamWriter(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                        reader.WriteLine(tbackground.Text)
                        reader.WriteLine(ttrademark.Text)
                        reader.WriteLine(tstartimg.Text)
                    End Using
                    ' End If
                    SharedV.Saving = True
                Else
                    MsgBox("不是，哥们，你选文件自己干嘛？", vbExclamation)

                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                End If
            Catch ex As Exception
                errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString
                SharedV.Saving = True
                'Dim window2 As New Window2
                'SharedV.Saving = False
                'window2.Show()
            End Try
        Else


            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
            Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)

        End If
    End Sub

    Private Sub refreshh_Click(sender As Object, e As RoutedEventArgs) Handles refreshh.Click
        List1.Items.Clear()
        comboBox.Items.Clear()
        folders = Directory.GetDirectories(ThemsDirectory)
        For i As Integer = 1 To folders.Length()
            Console.WriteLine(i - 1)
            Dim myString As String = folders(i - 1)

            '查找最后一个 "\" 的位置
            Dim lastBackslashIndex As Integer = myString.LastIndexOf("\")
            If lastBackslashIndex <> -1 Then '确保找到了 "\" 符号
                '截取 "\" 后面的全部字符
                Dim result As String = myString.Substring(lastBackslashIndex + 1)
                Console.WriteLine(result) '输出结果

                Dim newItem As New ListBoxItem With {
                    .Content = result
                }

                List1.Items.Add(newItem)

                Dim newItem1 As New ComboBoxItem With {
                    .Content = result
                }
                comboBox.Items.Add(newItem1)
            End If
        Next
    End Sub

    Private Sub xstartimg_Click(sender As Object, e As RoutedEventArgs) Handles xstartimg.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing
        kdtkyd6666.Source = Nothing

        GC.Collect()

        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "image Files (*.png;*.jpg;*.jpge;*.bmp)|*.png;*.jpg;*.jpge;*.bmp",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 image 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                If ComparePaths(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\" & tstartimg.Text, openFileDialog.FileName) = False Then
                    Dim secondWindow As New Window2
                    Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                    Dim y As Double = Me.Top

                    secondWindow.Left = x
                    secondWindow.Top = y
                    Dim moveAnimation As New DoubleAnimation()
                    moveAnimation.From = secondWindow.Left + secondWindow.Width
                    moveAnimation.To = x
                    moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                    moveAnimation.EasingFunction = New QuarticEase()
                    secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

                    secondWindow.Show()

                    tstartimg.Text = System.IO.Path.GetFileName(openFileDialog.FileName)
                    Dim selectedFilePath As String = openFileDialog.FileName
                    errormsgbox = "ok"
                    Dim window2 As New Window2
                    SharedV.Saving = False
                    window2.Show()


                    GC.Collect()
                    GC.WaitForPendingFinalizers()

                    'Dim selectedItem As ListBoxItem = List1.SelectedItem
                    '这一行要改
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    '删除的变量要改
                    File.Delete(StartIMG)
                    '目标路径要改
                    File.Copy(selectedFilePath, StartIMG, True)

                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"

                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                    'If File.Exists(ThemsDirectory & "\" & List1.SelectedItem.ToString() & "\file.sr") Then
                    File.Delete(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                    Using reader As New StreamWriter(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                        reader.WriteLine(tbackground.Text)
                        reader.WriteLine(ttrademark.Text)
                        reader.WriteLine(tstartimg.Text)
                    End Using
                    'End If
                    SharedV.Saving = True
                Else
                    MsgBox("不是，哥们，你选文件自己干嘛？", vbExclamation)

                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                End If
            Catch ex As Exception
                errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString

                SharedV.Saving = True
                'Dim window2 As New Window2
                'SharedV.Saving = False
                'window2.Show()
            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
            Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)

        End If
    End Sub

    Private Sub xtrademark_Click(sender As Object, e As RoutedEventArgs) Handles xtrademark.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing
        kdtkyd6666.Source = Nothing

        GC.Collect()

        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "image Files (*.png;*.jpg;*.jpge;*.bmp)|*.png;*.jpg;*.jpge;*.bmp",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 image 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                Dim selectedItem As ListBoxItem = List1.SelectedItem
                If ComparePaths(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\" & ttrademark.Text, openFileDialog.FileName) = False Then
                    Dim secondWindow As New Window2
                    Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                    Dim y As Double = Me.Top

                    secondWindow.Left = x
                    secondWindow.Top = y
                    Dim moveAnimation As New DoubleAnimation()
                    moveAnimation.From = secondWindow.Left + secondWindow.Width
                    moveAnimation.To = x
                    moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                    moveAnimation.EasingFunction = New QuarticEase()
                    secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

                    secondWindow.Show()

                    ttrademark.Text = System.IO.Path.GetFileName(openFileDialog.FileName)
                    Dim selectedFilePath As String = openFileDialog.FileName
                    errormsgbox = "ok"

                    GC.Collect()
                    GC.WaitForPendingFinalizers()

                    'Dim selectedItem As ListBoxItem = List1.SelectedItem
                    '这一行要改
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    '删除的变量要改
                    File.Delete(trademark)
                    '目标路径要改
                    File.Copy(selectedFilePath, trademark, True)

                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"

                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                    'MsgBox(ThemsDirectory & "\" & List1.SelectedItem.ToString & "\file.sr")
                    ' If File.Exists(ThemsDirectory & "\" & List1.SelectedItem.ToString & "\file.sr") Then
                    File.Delete(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")

                    Using reader As New StreamWriter(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                        reader.WriteLine(tbackground.Text)
                        reader.WriteLine(ttrademark.Text)
                        reader.WriteLine(tstartimg.Text)
                    End Using
                    ' End If
                    SharedV.Saving = True
                Else
                    MsgBox("不是，哥们，你选文件自己干嘛？", vbExclamation)

                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                End If
            Catch ex As Exception
                errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString
                SharedV.Saving = True
                'Dim window2 As New Window2
                'SharedV.Saving = False
                'window2.Show()
            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
            Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)

        End If
    End Sub

    Private Sub add_Click(sender As Object, e As RoutedEventArgs) Handles add.Click
        Dim input As String = InputBox("请输入新的主题名称", "主题名称", "")
        Console.WriteLine(input)
        If input = "" Then
            MsgBox("你需要输入文字", vbInformation, "无法创建新主题")
        Else
            Dim NewWholeName As String = ThemsDirectory & "\" & input
            If Directory.Exists(NewWholeName) Then
                MsgBox("同名称的主题已经存在，请先删除旧的主题，或更换名称后重试。", vbInformation, "无法创建新主题")
            Else
                errormsgbox = “ok”
                Dim secondWindow As New Window2
                Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                Dim y As Double = Me.Top

                secondWindow.Left = x
                secondWindow.Top = y
                Dim moveAnimation As New DoubleAnimation()
                moveAnimation.From = secondWindow.Left + secondWindow.Width
                moveAnimation.To = x
                moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                moveAnimation.EasingFunction = New QuarticEase()
                secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
                secondWindow.Show()

                Directory.CreateDirectory(NewWholeName)
                Try
                    For Each filePath As String In Directory.GetFiles(ThemsDirectory & "\" & "DEFAULT")
                        Dim fileName As String = Path.GetFileName(filePath)
                        Dim destFilePath As String = Path.Combine(NewWholeName, fileName)
                        File.Copy(filePath, destFilePath, True) ' 第三个参数表示覆盖已存在的文件
                    Next
                    SharedV.Saving = True
                Catch ex As Exception
                    SharedV.Saving = True
                    errormsgbox = "无法复制主题模板，可能是 DEFAULT 主题被删除。你可能需要重新安装本工具再进行重试。"


                    Directory.Delete(NewWholeName)
                    'Dim window4 As New Window2

                    'window4.Show()
                End Try
            End If
        End If

        List1.Items.Clear()
        comboBox.Items.Clear()
        folders = Directory.GetDirectories(ThemsDirectory)
        For i As Integer = 1 To folders.Length()
            Console.WriteLine(i - 1)
            Dim myString As String = folders(i - 1)

            '查找最后一个 "\" 的位置
            Dim lastBackslashIndex As Integer = myString.LastIndexOf("\")
            If lastBackslashIndex <> -1 Then '确保找到了 "\" 符号
                '截取 "\" 后面的全部字符
                Dim result As String = myString.Substring(lastBackslashIndex + 1)
                Console.WriteLine(result) '输出结果

                Dim newItem As New ListBoxItem With {
                    .Content = result
                }

                List1.Items.Add(newItem)

                Dim newItem1 As New ComboBoxItem With {
                    .Content = result
                }
                comboBox.Items.Add(newItem1)
            End If
        Next

    End Sub

    Private Sub del_Click(sender As Object, e As RoutedEventArgs) Handles del.Click

        Dim selectedItem As ListBoxItem = List1.SelectedItem
        If selectedItem Is Nothing Then
            MsgBox("请先选择一个主题", vbInformation, "不能删除")
        ElseIf selectedItem.Content = "default" Or selectedItem.Content = "Default" Or selectedItem.Content = "DEFAULT" Then
            MsgBox("你不能删除默认主题", vbExclamation, "不能删除")
        Else

            image1.Source = Nothing
            yuanshen.Source = Nothing
            image2.Source = Nothing
            kdtkyd6666.Source = Nothing

            GC.Collect()

            Dim ISOK = MsgBox("真的要删除主题 " & selectedItem.Content & " 吗？这是不可恢复的噢！＞﹏＜", vbYesNo, "删除确认")
            If ISOK = 6 Then
                SharedV.Saving = False
                errormsgbox = "ok"
                Dim secondWindow As New Window2
                Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                Dim y As Double = Me.Top

                secondWindow.Left = x
                secondWindow.Top = y
                Dim moveAnimation As New DoubleAnimation()
                moveAnimation.From = secondWindow.Left + secondWindow.Width
                moveAnimation.To = x
                moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                moveAnimation.EasingFunction = New QuarticEase()
                secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
                secondWindow.Show()
                image1.Source = Nothing
                image2.Source = Nothing
                yuanshen.Source = Nothing
                kdtkyd6666.Source = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                Try
                    Directory.Delete(ThemsDirectory & "\" & selectedItem.Content, True)
                Catch ex As Exception
                    errormsgbox = "错误,无法删除该主题，报错如下" & ex.ToString
                End Try
                List1.Items.Clear()
                comboBox.Items.Clear()
                folders = Directory.GetDirectories(ThemsDirectory)
                For i As Integer = 1 To folders.Length()
                    Console.WriteLine(i - 1)
                    Dim myString As String = folders(i - 1)

                    '查找最后一个 "\" 的位置
                    Dim lastBackslashIndex As Integer = myString.LastIndexOf("\")
                    If lastBackslashIndex <> -1 Then '确保找到了 "\" 符号
                        '截取 "\" 后面的全部字符
                        Dim result As String = myString.Substring(lastBackslashIndex + 1)
                        Console.WriteLine(result) '输出结果

                        Dim newItem As New ListBoxItem With {
                            .Content = result
                        }

                        List1.Items.Add(newItem)

                        Dim newItem1 As New ComboBoxItem With {
                            .Content = result
                        }
                        comboBox.Items.Add(newItem1)
                    End If
                Next

                cuowu.Visibility = Visibility.Visible
                tbackground.IsEnabled = False
                ttrademark.IsEnabled = False
                tstartimg.IsEnabled = False
                xbacoground.IsEnabled = False
                xtrademark.IsEnabled = False
                xstartimg.IsEnabled = False
                sname.IsEnabled = False
                namesave.IsEnabled = False
                sname_Copy.IsEnabled = False
                namesave_Copy.IsEnabled = False
                sname_Copy1.IsEnabled = False
                namesave_Copy2.IsEnabled = False
                _1_1.IsEnabled = False
                _2_2.IsEnabled = False
                _3_3.IsEnabled = False
                _4_4.IsEnabled = False
                _5_5.IsEnabled = False
                SharedV.Saving = True
            Else
                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
            End If
        End If
    End Sub

    Private Sub namesave_Click(sender As Object, e As RoutedEventArgs) Handles namesave.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing
        kdtkyd6666.Source = Nothing

        GC.Collect()
        GC.WaitForPendingFinalizers()

        Try
            changename()

        Catch ex As Exception
            errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString
            SharedV.Saving = True
        End Try
    End Sub
    Private Sub changename()

        'Dim window2 As New Window2
        'SharedV.Saving = False
        'window2.Show()
        Dim secondWindow As New Window2
        Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
        Dim y As Double = Me.Top

        secondWindow.Left = x
        secondWindow.Top = y
        Dim moveAnimation As New DoubleAnimation()
        moveAnimation.From = secondWindow.Left + secondWindow.Width
        moveAnimation.To = x
        moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
        moveAnimation.EasingFunction = New QuarticEase()
        secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
        secondWindow.Show()
        GC.Collect()
        GC.WaitForPendingFinalizers()

        Dim selectedItem As ListBoxItem = List1.SelectedItem
        Dim oldFolderPath As String = ThemsDirectory & "\" & selectedItem.Content   ' 原文件夹路径
        Dim newFolderName As String = sname.Text        ' 新的文件夹名字
        Dim isSuccess As Boolean = False

        While Not isSuccess
            Try
                ' 组合新的文件夹路径
                Dim newFolderPath As String = Path.Combine(Path.GetDirectoryName(oldFolderPath), newFolderName)

                ' 使用 Directory.Move 方法重命名文件夹
                Directory.Move(oldFolderPath, newFolderPath)

                isSuccess = True
            Catch ex As Exception
                Thread.Sleep(100)
            End Try
        End While
        errormsgbox = "ok"

        Console.WriteLine("文件夹重命名成功！")

        List1.Items.Clear()
        comboBox.Items.Clear()
        folders = Directory.GetDirectories(ThemsDirectory)
        For i As Integer = 1 To folders.Length()
            Console.WriteLine(i - 1)
            Dim myString As String = folders(i - 1)

            '查找最后一个 "\" 的位置
            Dim lastBackslashIndex As Integer = myString.LastIndexOf("\")
            If lastBackslashIndex <> -1 Then '确保找到了 "\" 符号
                '截取 "\" 后面的全部字符
                Dim result As String = myString.Substring(lastBackslashIndex + 1)
                Console.WriteLine(result) '输出结果

                Dim newItem As New ListBoxItem With {
                    .Content = result
                }

                List1.Items.Add(newItem)

                Dim newItem1 As New ComboBoxItem With {
                    .Content = result
                }
                comboBox.Items.Add(newItem1)
            End If
        Next

        cuowu.Visibility = Visibility.Visible
        tbackground.IsEnabled = False
        ttrademark.IsEnabled = False
        tstartimg.IsEnabled = False
        xbacoground.IsEnabled = False
        xtrademark.IsEnabled = False
        xstartimg.IsEnabled = False
        sname.IsEnabled = False
        namesave.IsEnabled = False
        sname_Copy.IsEnabled = False
        namesave_Copy1.IsEnabled = False
        sname_Copy1.IsEnabled = False
        namesave_Copy2.IsEnabled = False
        _1_1.IsEnabled = False
        _2_2.IsEnabled = False
        _3_3.IsEnabled = False
        _4_4.IsEnabled = False
        _5_5.IsEnabled = False
        SharedV.Saving = True
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "可执行文件 (*.exe)|*.exe",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择可执行文件路径"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()
        Dim path As String = openFileDialog.FileName
        If result = True Then
            _filepath.Text = path
        End If


    End Sub

    Private Sub checkBox_Click(sender As Object, e As RoutedEventArgs) Handles checkBox.Click
        If checkBox.IsChecked = True Then
            comboBox.IsEnabled = False
        Else
            comboBox.IsEnabled = True
        End If
    End Sub

    Private Sub checkBox1_Click(sender As Object, e As RoutedEventArgs) Handles checkBox1.Click
        If checkBox1.IsChecked = True Then
            textBox.IsEnabled = False
            button1.IsEnabled = False
        Else
            textBox.IsEnabled = True
            button1.IsEnabled = True
        End If
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "音频 (*.wav;*.mp3;*.flac;*.wma)|*.wav;*.mp3;*.flac;*.wma",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择启动音效路径"
        }


        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then
            Dim path As String = openFileDialog.FileName
            Dim path114 As String = System.IO.Path.GetFileName(openFileDialog.FileName)
            If ComparePaths(appDirectory & "\" & textBox.Text, path) = False Then
                Dim secondWindow As New Window2
                Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                Dim y As Double = Me.Top

                secondWindow.Left = x
                secondWindow.Top = y
                Dim moveAnimation As New DoubleAnimation()
                moveAnimation.From = secondWindow.Left + secondWindow.Width
                moveAnimation.To = x
                moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                moveAnimation.EasingFunction = New QuarticEase()
                secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
                secondWindow.Show()
                'errormsgbox = "ok"
                'Dim window2 As New Window2
                'SharedV.Saving = False
                'window2.Show()
                errormsgbox = "ok"
                musicfile = path114
                textBox.Text = path114
                Try
                    File.Copy(path, appDirectory & "\" & textBox.Text, True)
                    File.Delete(appDirectory & "\file.sr")
                    Using reader As New StreamWriter(appDirectory & "\file.sr")
                        reader.WriteLine(musicfile)
                    End Using
                    SharedV.Saving = True


                Catch ex As Exception
                    errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString
                    SharedV.Saving = False
                    'Dim window3 As New Window2
                    'window3.Show()
                End Try
            Else
                MsgBox("不是，哥们，你选文件自己干嘛？", vbExclamation)
            End If
        End If

    End Sub

    Private Sub Window1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Dim yon = MsgBox("确认关闭前，请确保所有设置已经应用，否则您的更改不会生效。" & vbCrLf & "以后，您可以在本程序的根目录下双击【配置启动器.bat】文件以再次打开本设置界面。o((>ω< ))o", vbYesNo, "关闭？")
        If yon = 6 Then
            End
        End If
    End Sub
    Public Async Sub Preventthepointtoomanytimes2514()
        Await Task.Delay(100)
        '.HorizontalAlignment = HorizontalAlignment.Center,
        '.VerticalAlignment = VerticalAlignment.Center
    End Sub
    Private Sub saving_Click(sender As Object, e As RoutedEventArgs) Handles saving.Click
        SharedV.Saving = False
        errormsgbox = "ok"
        ' Dim window2 As New Window2
        'Window2.Show()
        Dim secondWindow As New Window2
        Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
        Dim y As Double = Me.Top

        secondWindow.Left = x
        secondWindow.Top = y
        Dim moveAnimation As New DoubleAnimation()
        moveAnimation.From = secondWindow.Left + secondWindow.Width
        moveAnimation.To = x
        moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
        moveAnimation.EasingFunction = New QuarticEase()
        secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

        secondWindow.Show()

        If File.Exists(_filepath.Text()) = True Then
            Try
                secondLine = _filepath.Text()
                fourLine = _1.Text()
                fifthLine = _2.Text()
                sixthLine = _3.Text()
                seventhLine = _4.Text()
                eighthLine = _5.Text()

                If checkBox.IsChecked = True Then
                    ninthLine = "True"
                Else
                    Dim item As ListBoxItem = comboBox.SelectedItem
                    If IsNothing(item) Then
                        MsgBox("【主题】配置中有值为空。在程序被启动时，主题会被随机选取。"， vbCritical, "错误")
                        checkBox.IsChecked = True
                        ninthLine = "True"
                        comboBox.IsEnabled = False
                    Else
                        ninthLine = item.Content.ToString
                    End If
                End If

                If checkBox1.IsChecked = True Then
                    tenthLine = "True"
                Else
                    tenthLine = "False"
                End If

                File.Delete("settings.ini")
                Dim filePath As String = "settings.ini" ' 设置文件路径
                Using writer As New StreamWriter(filePath) ' 创建StreamWriter对象并打开文件
                    writer.WriteLine(firstLine)
                    writer.WriteLine(secondLine)
                    writer.WriteLine(thirdLine)
                    writer.WriteLine(fourLine)
                    writer.WriteLine(fifthLine)
                    writer.WriteLine(sixthLine)
                    writer.WriteLine(seventhLine)
                    writer.WriteLine(eighthLine)
                    writer.WriteLine(ninthLine)
                    writer.WriteLine(tenthLine)
                    writer.WriteLine(Line11)
                    writer.WriteLine(Line12)
                    writer.WriteLine(Line13)
                    writer.WriteLine(Line14)
                    writer.WriteLine(Line15)
                    'MsgBox(Line16)
                    writer.WriteLine(Line16)

                End Using ' 关闭文件并释放资源
            Catch ex As System.NullReferenceException
                errormsgbox = "已引发异常：" & vbCrLf & ex.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
            Catch _e As Exception
                errormsgbox = "已引发异常：" & vbCrLf & _e.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
            End Try
        Else
            errormsgbox = "指定的 " & _filepath.Text() & " 由于不存在、不可用、不完整、没有权限等其他原因无法被设定，请更换路径。" & vbLf & vbCrLf & "提示：暂不支持完整路径后面接参数"
        End If
        File.Delete("product.config")
        Dim filePath1 As String = "product.config" ' 设置文件路径
        Using writer As New StreamWriter(filePath1) ' 创建StreamWriter对象并打开文件
            writer.WriteLine(starting_config)
            writer.WriteLine(cstext.Text)
            writer.WriteLine(Line17)
            writer.WriteLine(cstext_Copy.Text)

        End Using ' 关闭文件并释放资源
        SharedV.Saving = True

    End Sub

    Private Sub windowsave_Click() Handles windowsave.Click
        SharedV.Saving = False
        errormsgbox = "ok"
        'Dim window2 As New Window2
        'window2.Show()
        'Dim secondWindow As New Window2
        'Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
        'Dim y As Double = Me.Top

        'secondWindow.Left = x
        'secondWindow.Top = y
        'Dim moveAnimation As New DoubleAnimation()
        'moveAnimation.From = secondWindow.Left + secondWindow.Width
        'moveAnimation.To = x
        'moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
        'moveAnimation.EasingFunction = New QuarticEase()
        'secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

        'secondWindow.Show()

        starting_config = windowname.Text()

        File.Delete("product.config")
        Dim filePath1 As String = "product.config" ' 设置文件路径
        Using writer As New StreamWriter(filePath1) ' 创建StreamWriter对象并打开文件
            writer.WriteLine(starting_config)
            writer.WriteLine(cstext.Text)
            writer.WriteLine(Line17)
            writer.WriteLine(cstext_Copy.Text)

        End Using ' 关闭文件并释放资源

        SharedV.Saving = True
    End Sub

    Private Sub cs_Click(sender As Object, e As RoutedEventArgs) Handles cs.Click
        If cs.IsChecked = True Then
            Line12 = "True"
            cstext.IsEnabled = True
        Else
            Line12 = "False"
            cstext.IsEnabled = False
        End If
    End Sub

    Private Sub ckjczq_Click(sender As Object, e As RoutedEventArgs) Handles ckjczq.Click
        If ckjczq.IsChecked = True Then
            Line13 = "True"

        Else
            Line13 = "False"
        End If
    End Sub

    Private Sub cjmode_Click(sender As Object, e As RoutedEventArgs) Handles cjmode.Click
        If cjmode.IsChecked = True Then
            Line15 = "True"
        Else
            Line15 = "False"
        End If
    End Sub



    Private Sub windowsave_Copy_Click() Handles windowsave_Copy.Click
        Try
            Dim secondWindow As New Window2
            Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
            Dim y As Double = Me.Top

            secondWindow.Left = x
            secondWindow.Top = y
            Dim moveAnimation As New DoubleAnimation()
            moveAnimation.From = secondWindow.Left + secondWindow.Width
            moveAnimation.To = x
            moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
            moveAnimation.EasingFunction = New QuarticEase()
            secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

            secondWindow.Show()

            'MsgBox(zt)
            File.Delete(zt)
            Dim filePath2 As String = zt ' 设置文件路径
            Using writer As New StreamWriter(filePath2) ' 创建StreamWriter对象并打开文件
                writer.WriteLine(_1_1.Text)
                writer.WriteLine(_2_2.Text)
                writer.WriteLine(_3_3.Text)
                writer.WriteLine(_4_4.Text)
                writer.WriteLine(_5_5.Text)
            End Using ' 关闭文件并释放资源
            errormsgbox = "ok"

            'Window2.Show()
        Catch ex As Exception
            errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString
            'Dim secondWindow As New Window2
            'Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
            'Dim y As Double = Me.Top

            'secondWindow.Left = x
            'secondWindow.Top = y
            'Dim moveAnimation As New DoubleAnimation()
            'moveAnimation.From = secondWindow.Left + secondWindow.Width
            'moveAnimation.To = x
            'moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
            'moveAnimation.EasingFunction = New QuarticEase()
            'secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
            'secondWindow.Show()
        End Try
    End Sub

    Function ComparePaths(path1, path2) As Boolean
        Return Path.GetFullPath(path1).Equals(Path.GetFullPath(path2))
    End Function

    Private Sub namesave_Copy_Click(sender As Object, e As RoutedEventArgs) Handles namesave_Copy.Click

        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing
        kdtkyd6666.Source = Nothing


        GC.Collect()


        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "mp4 Files (*.mp4)|*.mp4",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 mp4 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                Dim selectedFilePath As String = openFileDialog.FileName
                'Dim window2 As New Window2

                'SharedV.Saving = False
                'window2.Show()

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                If ComparePaths(startmp4, selectedFilePath) = False Then
                    Dim secondWindow As New Window2
                    Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                    Dim y As Double = Me.Top

                    secondWindow.Left = x
                    secondWindow.Top = y
                    Dim moveAnimation As New DoubleAnimation()
                    moveAnimation.From = secondWindow.Left + secondWindow.Width
                    moveAnimation.To = x
                    moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                    moveAnimation.EasingFunction = New QuarticEase()
                    secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
                    secondWindow.Show()
                    SharedV.Saving = False


                    GC.Collect()
                    GC.WaitForPendingFinalizers()

                    File.Delete(startmp4)
                    File.Copy(selectedFilePath, startmp4, True)

                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text

                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                    errormsgbox = "ok"
                    SharedV.Saving = True
                Else
                    MsgBox("不是，哥们，你选文件自己干嘛？", vbExclamation)
                    'Dim selectedItem As ListBoxItem = List1.SelectedItem
                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4g = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4g, UriKind.Absolute)
                End If

            Catch ex As Exception

                errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString


            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
            Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)

        End If
    End Sub

    Private Sub ff_Click(sender As Object, e As RoutedEventArgs) Handles ff.Click
        If ff.IsChecked = True Then
            _1.IsEnabled = False
            _2.IsEnabled = False
            _3.IsEnabled = False
            _4.IsEnabled = False
            _5.IsEnabled = False
            _1_1.IsEnabled = True
            _2_2.IsEnabled = True
            _3_3.IsEnabled = True
            _4_4.IsEnabled = True
            _5_5.IsEnabled = True
            Line16 = "True"
        Else
            _1.IsEnabled = True
            Line16 = "False"
            _2.IsEnabled = True
            _3.IsEnabled = True
            _4.IsEnabled = True
            _5.IsEnabled = True
            _1.IsEnabled = True
            _1_1.IsEnabled = False
            _2_2.IsEnabled = False
            _3_3.IsEnabled = False
            _4_4.IsEnabled = False
            _5_5.IsEnabled = False
        End If
    End Sub

    Private Sub MP4114_Click() Handles MP4114.Click
        If MP4114.IsChecked = True Then
            Try
                Dim secondWindow As New Window2
                Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                Dim y As Double = Me.Top

                secondWindow.Left = x
                secondWindow.Top = y
                Dim moveAnimation As New DoubleAnimation()
                moveAnimation.From = secondWindow.Left + secondWindow.Width
                moveAnimation.To = x
                moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                moveAnimation.EasingFunction = New QuarticEase()
                secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

                secondWindow.Show()

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                sname_Copy.IsEnabled = False
                namesave_Copy.IsEnabled = False
                sname_Copy1.IsEnabled = False
                namesave_Copy2.IsEnabled = False
                Videolaunch = "False"
                kdtkyd6666.Visibility = Visibility.Hidden
                MP4114_Copy1.IsEnabled = False
                MP4114_Copy.IsEnabled = False
                'If File.Exists(ThemsDirectory & "\" & List1.SelectedItem.ToString() & "\mp4.sr") Then
                '''' MsgBox(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr")
                File.Delete(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr")
                Using reader As New StreamWriter(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr")
                    reader.WriteLine(Videolaunch)
                End Using
                'End If
                errormsgbox = "ok"
                'Dim win As New Window2
                'win.Show()
            Catch ex As Exception
                error1 = "保存失败"
                error2 = ex.ToString
                Dim error114 As New error114
                error114.ShowDialog()
            End Try
        Else
            Try
                Dim secondWindow As New Window2
                Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                Dim y As Double = Me.Top

                secondWindow.Left = x
                secondWindow.Top = y
                Dim moveAnimation As New DoubleAnimation()
                moveAnimation.From = secondWindow.Left + secondWindow.Width
                moveAnimation.To = x
                moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                moveAnimation.EasingFunction = New QuarticEase()
                secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

                secondWindow.Show()

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                MP4114_Copy1.IsEnabled = True
                sname_Copy.IsEnabled = True
                sname_Copy1.IsEnabled = True
                namesave_Copy2.IsEnabled = True
                namesave_Copy.IsEnabled = True
                If MP4114_Copy1.IsChecked = False Then


                    Videolaunch = "True"

                Else
                    Videolaunch = "False1"
                End If
                If MP4114_Copy.IsChecked = True And MP4114_Copy1.IsChecked = True Then
                    Videolaunch = "TrueWindow1"
                    'MsgBox("满足")
                Else
                    If MP4114_Copy.IsChecked = True Then
                        Videolaunch = "TrueWindow"
                    Else
                        If MP4114_Copy1.IsChecked = True Then
                            Videolaunch = "False1"
                        End If
                    End If

                    'MsgBox("不满足")
                End If
                MP4114_Copy.IsEnabled = True
                'kdtkyd6666.Source = New Uri(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\startmp4.mp4", UriKind.Absolute)
                kdtkyd6666.Visibility = Visibility.Visible
                ' If File.Exists(ThemsDirectory & "\" & List1.SelectedItem.ToString() & "\mp4.sr") Then
                File.Delete(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr")
                Using reader As New StreamWriter(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\mp4.sr")
                    reader.WriteLine(Videolaunch)
                End Using
                'End If
                errormsgbox = "ok"
                'Dim win As New Window2
                'win.Show()
            Catch ex As Exception
                error1 = "保存失败"
                error2 = ex.ToString
                Dim error114 As New error114
                error114.Show()
            End Try
        End If
    End Sub

    Private Sub windowsave_Copy1_Click() Handles windowsave_Copy1.Click
        SharedV.Saving = False
        errormsgbox = "ok"
        'Dim window2 As New Window2
        'window2.Show()
        Dim secondWindow As New Window2
        Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
        Dim y As Double = Me.Top
        secondWindow.Left = x
        secondWindow.Top = y
        Dim moveAnimation As New DoubleAnimation()
        moveAnimation.From = secondWindow.Left + secondWindow.Width
        moveAnimation.To = x
        moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
        moveAnimation.EasingFunction = New QuarticEase()
        secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

        secondWindow.Show()

        If File.Exists(_filepath.Text()) = True Then
            Try
                secondLine = _filepath.Text()
                fourLine = _1.Text()
                fifthLine = _2.Text()
                sixthLine = _3.Text()
                seventhLine = _4.Text()
                eighthLine = _5.Text()

                If checkBox.IsChecked = True Then
                    ninthLine = "True"
                Else
                    Dim item As ListBoxItem = comboBox.SelectedItem
                    If IsNothing(item) Then
                        MsgBox("【主题】配置中有值为空。在程序被启动时，主题会被随机选取。"， vbCritical, "错误")
                        checkBox.IsChecked = True
                        ninthLine = "True"
                        comboBox.IsEnabled = False
                    Else
                        ninthLine = item.Content.ToString
                    End If
                End If

                If checkBox1.IsChecked = True Then
                    tenthLine = "True"
                Else
                    tenthLine = "False"
                End If

                File.Delete("settings.ini")
                Dim filePath As String = "settings.ini" ' 设置文件路径
                Using writer As New StreamWriter(filePath) ' 创建StreamWriter对象并打开文件
                    writer.WriteLine(firstLine)
                    writer.WriteLine(secondLine)
                    writer.WriteLine(thirdLine)
                    writer.WriteLine(fourLine)
                    writer.WriteLine(fifthLine)
                    writer.WriteLine(sixthLine)
                    writer.WriteLine(seventhLine)
                    writer.WriteLine(eighthLine)
                    writer.WriteLine(ninthLine)
                    writer.WriteLine(tenthLine)
                    writer.WriteLine(Line11)
                    writer.WriteLine(Line12)
                    writer.WriteLine(Line13)
                    writer.WriteLine(Line14)
                    writer.WriteLine(Line15)
                    'MsgBox(Line16)
                    writer.WriteLine(Line16)
                    File.Delete("product.config")
                    Dim filePath1 As String = "product.config" ' 设置文件路径

                End Using ' 关闭文件并释放资源
                windowsave_Click()
            Catch ex As System.NullReferenceException
                errormsgbox = "已引发异常：" & vbCrLf & ex.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
            Catch _e As Exception
                errormsgbox = "已引发异常：" & vbCrLf & _e.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
            End Try
        Else
            errormsgbox = "指定的 " & _filepath.Text() & " 由于不存在、不可用、不完整、没有权限等其他原因无法被设定，请更换路径。" & vbLf & vbCrLf & "提示：暂不支持完整路径后面接参数"
        End If

        SharedV.Saving = True
    End Sub

    Private Sub namesave_Copy1_Click(sender As Object, e As RoutedEventArgs) Handles namesave_Copy1.Click
        SharedV.Saving = False
        errormsgbox = "ok"
        'Dim window2 As New Window2
        'Window2.Show()
        Dim secondWindow As New Window2
        Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
        Dim y As Double = Me.Top

        secondWindow.Left = x
        secondWindow.Top = y
        Dim moveAnimation As New DoubleAnimation()
        moveAnimation.From = secondWindow.Left + secondWindow.Width
        moveAnimation.To = x
        moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
        moveAnimation.EasingFunction = New QuarticEase()
        secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)

        secondWindow.Show()

        If File.Exists(_filepath.Text()) = True Then
            Try

                secondLine = _filepath.Text()
                fourLine = _1.Text()
                fifthLine = _2.Text()
                sixthLine = _3.Text()
                seventhLine = _4.Text()
                eighthLine = _5.Text()

                If checkBox.IsChecked = True Then
                    ninthLine = "True"
                Else
                    Dim item As ListBoxItem = comboBox.SelectedItem
                    If IsNothing(item) Then
                        MsgBox("【主题】配置中有值为空。在程序被启动时，主题会被随机选取。"， vbCritical, "错误")
                        checkBox.IsChecked = True
                        ninthLine = "True"
                        comboBox.IsEnabled = False
                    Else
                        ninthLine = item.Content.ToString
                    End If
                End If

                If checkBox1.IsChecked = True Then
                    tenthLine = "True"
                Else
                    tenthLine = "False"
                End If
                File.Delete(zt)
                Dim filePath2 As String = zt ' 设置文件路径
                Using writer As New StreamWriter(filePath2) ' 创建StreamWriter对象并打开文件
                    writer.WriteLine(_1_1.Text)
                    writer.WriteLine(_2_2.Text)
                    writer.WriteLine(_3_3.Text)
                    writer.WriteLine(_4_4.Text)
                    writer.WriteLine(_5_5.Text)
                End Using ' 关闭文件并释放资源
                errormsgbox = "ok"
                If File.Exists(_filepath.Text()) = True Then
                    Try
                        secondLine = _filepath.Text()
                        fourLine = _1.Text()
                        fifthLine = _2.Text()
                        sixthLine = _3.Text()
                        seventhLine = _4.Text()
                        eighthLine = _5.Text()

                        If checkBox.IsChecked = True Then
                            ninthLine = "True"
                        Else
                            Dim item As ListBoxItem = comboBox.SelectedItem
                            If IsNothing(item) Then
                                MsgBox("【主题】配置中有值为空。在程序被启动时，主题会被随机选取。"， vbCritical, "错误")
                                checkBox.IsChecked = True
                                ninthLine = "True"
                                comboBox.IsEnabled = False
                            Else
                                ninthLine = item.Content.ToString
                            End If
                        End If

                        If checkBox1.IsChecked = True Then
                            tenthLine = "True"
                        Else
                            tenthLine = "False"
                        End If

                        File.Delete("settings.ini")
                        Dim filePath114 As String = "settings.ini" ' 设置文件路径
                        Using writer As New StreamWriter(filePath114) ' 创建StreamWriter对象并打开文件
                            writer.WriteLine(firstLine)
                            writer.WriteLine(secondLine)
                            writer.WriteLine(thirdLine)
                            writer.WriteLine(fourLine)
                            writer.WriteLine(fifthLine)
                            writer.WriteLine(sixthLine)
                            writer.WriteLine(seventhLine)
                            writer.WriteLine(eighthLine)
                            writer.WriteLine(ninthLine)
                            writer.WriteLine(tenthLine)
                            writer.WriteLine(Line11)
                            writer.WriteLine(Line12)
                            writer.WriteLine(Line13)
                            writer.WriteLine(Line14)
                            writer.WriteLine(Line15)
                            'MsgBox(Line16)
                            'writer.WriteLine(Line16)

                        End Using ' 关闭文件并释放资源
                    Catch ex As System.NullReferenceException
                        errormsgbox = "已引发异常：" & vbCrLf & ex.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
                    Catch _e As Exception
                        errormsgbox = "已引发异常：" & vbCrLf & _e.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
                    End Try
                Else
                    errormsgbox = "指定的 " & _filepath.Text() & " 由于不存在、不可用、不完整、没有权限等其他原因无法被设定，请更换路径。" & vbLf & vbCrLf & "提示：暂不支持完整路径后面接参数"
                End If
                File.Delete("product.config")
                Dim filePath115 As String = "product.config" ' 设置文件路径
                Using writer As New StreamWriter(filePath115) ' 创建StreamWriter对象并打开文件
                    writer.WriteLine(starting_config)
                    writer.WriteLine(cstext.Text)
                    writer.WriteLine(Line17)
                    writer.WriteLine(cstext_Copy.Text)
                End Using ' 关闭文件并释放资源
                SharedV.Saving = True
                If File.Exists(appDirectory & "\file.sr") Then
                    Using reader As New StreamWriter(appDirectory & "\file.sr")
                        reader.WriteLine(musicfile)
                    End Using
                End If
                Dim selectedItem As ListBoxItem = List1.SelectedItem
                File.Delete(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                Using xieru As New StreamWriter(ThemsDirectory & "\" & selectedItem.Content.ToString() & "\file.sr")
                    xieru.WriteLine(tbackground.Text)
                    xieru.WriteLine(ttrademark.Text)
                    xieru.WriteLine(tstartimg.Text)
                    xieru.WriteLine(Line16)
                End Using
                File.Delete("product.config")
                Dim filePath1 As String = "product.config" ' 设置文件路径
                Using writer As New StreamWriter(filePath1) ' 创建StreamWriter对象并打开文件
                    writer.WriteLine(starting_config)
                    writer.WriteLine(cstext.Text)
                    writer.WriteLine(Line17)
                    writer.WriteLine(cstext_Copy.Text)
                End Using ' 关闭文件并释放资源
            Catch ex As System.NullReferenceException
                errormsgbox = "已引发异常：" & vbCrLf & ex.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"

            Catch _e As Exception
                errormsgbox = "已引发异常：" & vbCrLf & _e.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"
            End Try
        Else
            errormsgbox = "指定的 " & _filepath.Text() & " 由于不存在、不可用、不完整、没有权限等其他原因无法被设定，请更换路径。" & vbLf & vbCrLf & "提示：暂不支持完整路径后面接参数"
        End If

        SharedV.Saving = True
    End Sub

    Private Sub cs_Copy_Click(sender As Object, e As RoutedEventArgs) Handles cs_Copy.Click
        If cs_Copy.IsChecked = True Then
            cstext_Copy.IsEnabled = False
            Line17 = "True"
        Else
            cstext_Copy.IsEnabled = True
            Line17 = "False"
        End If
    End Sub

    Private Sub namesave_Copy2_Click(sender As Object, e As RoutedEventArgs) Handles namesave_Copy2.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing
        kdtkyd6666.Source = Nothing


        GC.Collect()


        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "mp4 Files (*.mp4)|*.mp4",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 mp4 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                Dim secondWindow As New Window2
                Dim x As Double = Me.Left + Me.ActualWidth - (secondWindow.Width / 3)
                Dim y As Double = Me.Top

                secondWindow.Left = x
                secondWindow.Top = y
                Dim moveAnimation As New DoubleAnimation()
                moveAnimation.From = secondWindow.Left + secondWindow.Width
                moveAnimation.To = x
                moveAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
                moveAnimation.EasingFunction = New QuarticEase()
                secondWindow.BeginAnimation(Window.LeftProperty, moveAnimation)
                secondWindow.Show()
                Dim selectedItem As ListBoxItem = List1.SelectedItem
                Dim selectedFilePath As String = openFileDialog.FileName
                If ComparePaths(ThemsDirectory & "\" & selectedItem.Content & "\startmp41.mp4", selectedFilePath) = False Then
                    Dim window2 As New Window2

                    SharedV.Saving = False

                    window2.Show()



                    GC.Collect()
                    GC.WaitForPendingFinalizers()

                    'Dim selectedItem As ListBoxItem = List1.SelectedItem
                    Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                    File.Delete(ThemsDirectory & "\" & selectedItem.Content & "\startmp41.mp4")
                    File.Copy(selectedFilePath, ThemsDirectory & "\" & selectedItem.Content & "\startmp41.mp4", True)

                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text

                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)
                    errormsgbox = "ok"
                    SharedV.Saving = True
                Else
                    MsgBox("不是，哥们，你选文件自己干嘛？", vbExclamation)
                    'Dim selectedItem As ListBoxItem = List1.SelectedItem
                    Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
                    Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
                    Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
                    Dim startmp4g = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
                    image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                    yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                    image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                    kdtkyd6666.Source = New Uri(startmp4g, UriKind.Absolute)
                End If

            Catch ex As Exception

                errormsgbox = "替换失败，因为" & vbCrLf & vbCrLf & ex.ToString
                'Dim window2 As New Window2

                'SharedV.Saving = True
                'window2.Show()

            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\" & tbackground.Text
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\" & tstartimg.Text
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\" & ttrademark.Text
            Dim startmp4 = ThemsDirectory & "\" & selectedItem.Content & "\startmp4.mp4"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            kdtkyd6666.Source = New Uri(startmp4, UriKind.Absolute)

        End If
    End Sub

    Private Sub MP4114_Copy1_Click(sender As Object, e As RoutedEventArgs) Handles MP4114_Copy1.Click
        MP4114_Click()
    End Sub



    Private Sub MP4114_Copy_Click(sender As Object, e As RoutedEventArgs) Handles MP4114_Copy.Click
        MP4114_Click()
    End Sub

    Private Sub namesave_Copy2_GotKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles namesave_Copy2.GotKeyboardFocus

    End Sub

    Private Sub update114_Click(sender As Object, e As RoutedEventArgs) Handles update114.Click
        Dim update9 As New update
        update9.ShowDialog()
    End Sub

    Private Sub tabControl_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles tabControl.SelectionChanged
        Dim tabControl As TabControl = CType(sender, TabControl)
        Dim selectedTab As TabItem = CType(tabControl.SelectedItem, TabItem)
        If selectedTab IsNot Nothing AndAlso selectedTab.Header.ToString() = "主题编辑" Then
            add.IsEnabled = True
            add.Foreground = New SolidColorBrush(Color.FromRgb(0, 0, 0))
            del.IsEnabled = True
            del.Foreground = New SolidColorBrush(Color.FromRgb(0, 0, 0))
            refreshh.IsEnabled = True
            refreshh.Foreground = New SolidColorBrush(Color.FromRgb(0, 0, 0))
        Else
            add.IsEnabled = False
            add.Foreground = New SolidColorBrush(Color.FromRgb(128, 128, 128))
            del.IsEnabled = False
            del.Foreground = New SolidColorBrush(Color.FromRgb(128, 128, 128))
            refreshh.IsEnabled = False
            refreshh.Foreground = New SolidColorBrush(Color.FromRgb(128, 128, 128))
        End If
    End Sub
End Class
