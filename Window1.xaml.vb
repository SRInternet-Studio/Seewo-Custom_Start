Imports System.ComponentModel
Imports System.IO
Imports System.Threading
Imports Microsoft.Win32

Public Class Window1
    Private ReadOnly secondWindow As MainWindow
    Private starting_config As String

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

    Private ReadOnly appDirectory As String = AppDomain.CurrentDomain.BaseDirectory 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

    Private ReadOnly ThemsDirectory As String = appDirectory & "\Thems"

    Private folders() As String = Directory.GetDirectories(ThemsDirectory)

    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

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
                Console.WriteLine(starting_config)
            End Using
        End If
        Console.WriteLine(starting_config)
        windowname.Text = starting_config

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

        _1.Text = fourLine
        _2.Text = fifthLine
        _3.Text = sixthLine
        _4.Text = seventhLine
        _5.Text = eighthLine
        _filepath.Text = secondLine

        Dim selectedItem As ListBoxItem = List1.SelectedItem
        Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
        Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
        Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"

        image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
        yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
        image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
        sname.Text = selectedItem.Content

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

    End Sub

    Private Sub MySelectionChanged(sender As Object, e As EventArgs)
        Try
            '获取当前选中的 ListBoxItem
            Dim selectedItem As ListBoxItem = List1.SelectedItem
            If selectedItem IsNot Nothing Then
                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"

                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
                sname.Text = selectedItem.Content

                cuowu.Visibility = Visibility.Hidden
                tbackground.IsEnabled = True
                ttrademark.IsEnabled = True
                tstartimg.IsEnabled = True
                xbacoground.IsEnabled = True
                xtrademark.IsEnabled = True
                xstartimg.IsEnabled = True
                sname.IsEnabled = True
                namesave.IsEnabled = True

                If selectedItem.Content = "DEFAULT" Then
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
        End Try
        GC.Collect()
        '...
    End Sub

    Private Sub xbacoground_Click(sender As Object, e As RoutedEventArgs) Handles xbacoground.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing

        GC.Collect()

        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "PNG Files (*.png)|*.png",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 PNG 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                Dim selectedFilePath As String = openFileDialog.FileName
                Dim window2 As New Window2
                SharedV.Saving = False
                window2.Show()


                GC.Collect()
                GC.WaitForPendingFinalizers()

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
                File.Delete(background)
                File.Copy(selectedFilePath, background, True)

                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"

                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))

                SharedV.Saving = True
            Catch ex As Exception
                MsgBox("替换失败，因为" & vbCrLf & vbCrLf & ex.ToString, vbExclamation, "失败")
                SharedV.Saving = True
            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))

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

        GC.Collect()

        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "PNG Files (*.png)|*.png",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 PNG 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                Dim selectedFilePath As String = openFileDialog.FileName
                Dim window2 As New Window2
                SharedV.Saving = False
                window2.Show()


                GC.Collect()
                GC.WaitForPendingFinalizers()

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                '这一行要改
                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
                '删除的变量要改
                File.Delete(StartIMG)
                '目标路径要改
                File.Copy(selectedFilePath, StartIMG, True)

                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"

                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))

                SharedV.Saving = True
            Catch ex As Exception
                MsgBox("替换失败，因为" & vbCrLf & vbCrLf & ex.ToString, vbExclamation, "失败")
                SharedV.Saving = True
            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))

        End If
    End Sub

    Private Sub xtrademark_Click(sender As Object, e As RoutedEventArgs) Handles xtrademark.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing

        GC.Collect()

        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "PNG Files (*.png)|*.png",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择 PNG 文件"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()

        If result = True Then

            Try
                Dim selectedFilePath As String = openFileDialog.FileName
                Dim window2 As New Window2
                SharedV.Saving = False
                window2.Show()


                GC.Collect()
                GC.WaitForPendingFinalizers()

                Dim selectedItem As ListBoxItem = List1.SelectedItem
                '这一行要改
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"
                '删除的变量要改
                File.Delete(trademark)
                '目标路径要改
                File.Copy(selectedFilePath, trademark, True)

                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"

                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))

                SharedV.Saving = True
            Catch ex As Exception
                MsgBox("替换失败，因为" & vbCrLf & vbCrLf & ex.ToString, vbExclamation, "失败")
                SharedV.Saving = True
            End Try
        Else

            Dim selectedItem As ListBoxItem = List1.SelectedItem
            Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
            Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
            Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"
            image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
            yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
            image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))

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

                Dim window2 As New Window2
                SharedV.Saving = False
                window2.Show()

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
                    MsgBox("无法复制主题模板，可能是 DEFAULT 主题被删除。你可能需要重新安装本工具再进行重试。", vbExclamation, "无法创建主题")
                    Directory.Delete(NewWholeName)
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
        ElseIf selectedItem.Content = "DEFAULT" Then
            MsgBox("你不能删除默认主题", vbExclamation, "不能删除")
        Else

            image1.Source = Nothing
            yuanshen.Source = Nothing
            image2.Source = Nothing

            GC.Collect()

            Dim ISOK = MsgBox("真的要删除主题 " & selectedItem.Content & " 吗？这是不可恢复的噢！＞﹏＜", vbYesNo, "删除确认")
            If ISOK = 6 Then
                Dim window2 As New Window2
                SharedV.Saving = False
                window2.Show()

                GC.Collect()
                GC.WaitForPendingFinalizers()

                Directory.Delete(ThemsDirectory & "\" & selectedItem.Content, True)

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

                SharedV.Saving = True
            Else
                Dim background = ThemsDirectory & "\" & selectedItem.Content & "\background.png"
                Dim StartIMG = ThemsDirectory & "\" & selectedItem.Content & "\StartIMG.png"
                Dim trademark = ThemsDirectory & "\" & selectedItem.Content & "\trademark.png"
                image1.Source = New BitmapImage(New Uri(background, UriKind.Absolute))
                yuanshen.Source = New BitmapImage(New Uri(StartIMG, UriKind.Absolute))
                image2.Source = New BitmapImage(New Uri(trademark, UriKind.Absolute))
            End If
        End If
    End Sub

    Private Sub namesave_Click(sender As Object, e As RoutedEventArgs) Handles namesave.Click
        image1.Source = Nothing
        yuanshen.Source = Nothing
        image2.Source = Nothing

        GC.Collect()
        GC.WaitForPendingFinalizers()

        Try
            changename()
        Catch ex As Exception
            MsgBox("替换失败，因为" & vbCrLf & vbCrLf & ex.ToString, vbExclamation, "失败")
            SharedV.Saving = True
        End Try
    End Sub
    Private Sub changename()

        Dim window2 As New Window2
        SharedV.Saving = False
        window2.Show()

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
            .Filter = "波形音频 (*.wav)|*.wav",
            .FilterIndex = 1,
            .Multiselect = False,
            .Title = "选择启动音效路径"
        }

        Dim result As Boolean = openFileDialog.ShowDialog()
        Dim path As String = openFileDialog.FileName

        If result = True Then
            Dim window2 As New Window2
            SharedV.Saving = False
            window2.Show()

            Dim oldpath As String = appDirectory & "\" & "Start.wav"

            Try
                File.Copy(path, oldpath, True)
                SharedV.Saving = True
            Catch ex As Exception
                MsgBox("替换失败，因为" & vbCrLf & vbCrLf & ex.ToString, vbExclamation, "失败")
                SharedV.Saving = True
            End Try

        End If

    End Sub

    Private Sub Window1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        Dim yon = MsgBox("确认关闭前，请确保所有设置已经应用，否则您的更改不会生效。" & vbCrLf & "以后，您可以在本程序的根目录下双击【配置启动器.bat】文件以再次打开本设置界面。o((>ω< ))o", vbYesNo, "关闭？")
        If yon = 6 Then
            End
        End If
    End Sub

    Private Sub saving_Click(sender As Object, e As RoutedEventArgs) Handles saving.Click
        SharedV.Saving = False
        Dim window2 As New Window2
        window2.Show()

        If File.Exists(_filepath.Text()) = True Then
            Try
                secondLine = _filepath.Text()
                fourLine = _1.Text()
                fifthLine = _2.Text()
                sixthLine = _3.Text()
                seventhLine = _4.Text()
                eighthLine = _5.Text()

                If checkBox.IsChecked = True Then
                    ninthLine = True
                Else
                    Dim item As ListBoxItem = comboBox.SelectedItem
                    If IsNothing(item) Then
                        MsgBox("【主题】配置中有值为空。在程序被启动时，主题会被随机选取。"， vbCritical, "错误")
                        checkBox.IsChecked = True
                        ninthLine = True
                        comboBox.IsEnabled = False
                    Else
                        ninthLine = item.Content.ToString
                    End If
                End If

                If checkBox1.IsChecked = True Then
                    tenthLine = True
                Else
                    tenthLine = False
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
                End Using ' 关闭文件并释放资源
            Catch ex As System.NullReferenceException
                MsgBox("已引发异常：" & vbCrLf & ex.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"， vbCritical, "错误")
            Catch _e As Exception
                MsgBox("已引发异常：" & vbCrLf & _e.ToString & vbCrLf & vbCrLf & "    请用户检查主题配置中是否有值为空"， vbCritical, "错误")
            End Try
        Else
            MsgBox("指定的 " & _filepath.Text() & " 由于不存在、不可用、不完整、没有权限等其他原因无法被设定，请更换路径。" & vbLf & vbCrLf & "提示：暂不支持完整路径后面接参数", vbCritical, "错误")
        End If

        SharedV.Saving = True

    End Sub

    Private Sub windowsave_Click(sender As Object, e As RoutedEventArgs) Handles windowsave.Click
        SharedV.Saving = False
        Dim window2 As New Window2
        window2.Show()

        starting_config = windowname.Text()

        File.Delete("product.config")
        Dim filePath As String = "product.config" ' 设置文件路径
        Using writer As New StreamWriter(filePath) ' 创建StreamWriter对象并打开文件
            writer.WriteLine(starting_config)
        End Using ' 关闭文件并释放资源

        SharedV.Saving = True
    End Sub
End Class
