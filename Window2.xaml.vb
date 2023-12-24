Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Window2
    <DllImport("gdi32.dll")>
    Private Shared Function AddFontResource(ByVal lpFileName As String) As Integer
    End Function

    Private Sub RefreshFonts()
        ' 删除字体缓存中的所有字体
        For Each fontFile As String In System.IO.Directory.GetFiles("C:\Windows\Fonts", "*.ttf")
            AddFontResource(fontFile)
        Next

        ' 重新加载所有字体
        For Each fontFile As String In System.IO.Directory.GetFiles("C:\Windows\Fonts", "*.ttf")
            AddFontResource(fontFile)
        Next
    End Sub
    Private Sub Window2_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        'Start()
        Topmost = True
        Focus()
        check()
    End Sub
    Private Async Sub check()
        Do While SharedV.Saving = False
            ' 可以在循环中执行其他需要的操作
            ' 例如，检查变量的更新情况

            ' 在这里添加适当的延迟，以避免过多消耗 CPU
            Topmost = True
            Focus()
            Await Task.Delay(100) '异步等待

            ' 更新 variable 的值，直到条件满足
            ' 将变量设置为 True 以结束循环
            ' 例如，从某个地方获取变量的新值
            ' variable = GetUpdatedVariableValue() 
        Loop
        w1.Text = "保存成功"
        Await Task.Delay(1000)
        Hide()
        Close()
    End Sub
    Private Async Sub Start()
        Await Task.Delay(2000)
        Dim appDirectory As String = AppDomain.CurrentDomain.BaseDirectory 'System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Dim fontFilePath As String = appDirectory & "\DingTalk_JinBuTi_Regular.ttf"
        'InstallFontToSystem(fontFilePath)
        Process.Start(fontFilePath
                      )
        Await Task.Delay(2000)
        Focus()
        MsgBox("请在弹出的字体安装对话框中点击【安装】以安装字体，安装好后，点击确定以进行下一步。")
        Await Task.Delay(2000)
        MsgBox("请重启程序以应用更新。", vbInformation, "结束")
        Hide()
        Close()
        End
        'RestartApplication()
    End Sub
    Public Sub RestartApplication()
        Dim exePath As String = Process.GetCurrentProcess().MainModule.FileName
        Dim startInfo As New ProcessStartInfo(exePath)
        Process.Start(startInfo)
        End
    End Sub
    Private Sub RemoveFontFromCache(fontFilePath As String)
        For Each fontFile As String In System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Fonts))
            If String.Compare(fontFile, fontFilePath, StringComparison.OrdinalIgnoreCase) = 0 Then
                Dim fontFamilyName As String = Path.GetFileNameWithoutExtension(fontFile)
                Dim fontCollection As New PrivateFontCollection()
                fontCollection.AddFontFile(fontFile)
                fontCollection.Families(0).Dispose()
            End If
        Next
    End Sub

    Public Sub InstallFontToSystem(fontFilePath As String)
        Try
            Dim destinationPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                                                    Path.GetFileName(fontFilePath))

            ' 先在字体缓存中删除同名的字体
            RemoveFontFromCache(destinationPath)

            ' 复制字体文件到字体文件夹
            File.Copy(fontFilePath, destinationPath, True)

            ' 添加新字体到字体缓存
            AddFontResource(destinationPath)

            MsgBox("程序已经更新完成，请重启本程序！", vbInformation, "成功")
        Catch ex As Exception
            MsgBox("更新失败！因为出现错误：" & ex.Message, vbCritical, "失败")
        End Try
    End Sub
End Class
