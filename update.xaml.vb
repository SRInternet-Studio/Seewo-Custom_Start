Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Net
Imports MaterialDesignThemes.Wpf
Public Class update
    Public phpcontent As String
    Public number114 As String
    Public tagName As String
    Public body As String
    Public ver114 As String
    Public dlurl114 As String
    Private Sub update_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Hide()
        GetReleaseInfo()
    End Sub
    Async Sub GetReleaseInfo()
        Dim apiUrl As String = "https://api.github.com/repos/SRInternet-Studio/Seewo-Custom_Start/releases/latest"

        Dim request As HttpWebRequest = DirectCast(WebRequest.Create(apiUrl), HttpWebRequest)
        request.Method = "GET"
        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/133.0.0.0 Safari/537.36 Edg/133.0.0.0"

        Try
            Dim response As HttpWebResponse = DirectCast(Await request.GetResponseAsync(), HttpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(responseStream)
            Dim jsonString As String = reader.ReadToEnd()

            Dim serializer As New JavaScriptSerializer()
            Dim releaseData As Dictionary(Of String, Object) = DirectCast(serializer.Deserialize(jsonString, GetType(Dictionary(Of String, Object))), Dictionary(Of String, Object))

            tagName = CStr(releaseData("tag_name"))
            body = CStr(releaseData("body"))
            If tagName IsNot Nothing Then
                dlurl114 = $"https://github.com/SRInternet-Studio/Seewo-Custom_Start/releases/download/{tagName}/SeewoStart-Installer.exe"
            Else
                dlurl114 = ""
            End If
            reader.Close()
            responseStream.Close()
            response.Close()
            Show()
            If tagName IsNot Nothing Then
                number114 = GetNumbersAndDecimalPoint(tagName)
                ver114 = GetNumbersAndDecimalPoint(Version)
                If number114 = ver114 Then
                    _114514in.Text = "无可用更新"
                    messagebox("无可用更新")
                    ver666.Text = $"当前版本:{ver114}最新版本:{number114}"
                    gxnr114.Text = "更新内容:" & vbCrLf & body
                    dlgx.IsEnabled = False
                Else
                    If number114 > ver114 Then
                        _114514in.Text = "有可用更新！"
                        messagebox("有可用更新！")
                        ver666.Text = $"当前版本:{ver114}最新版本:{number114}"
                        gxnr114.Text = "更新内容:" & vbCrLf & body
                        dlgx.IsEnabled = True
                    Else
                        _114514in.Text = "您的定制启动器版本居然比我们的最新版本还高，NB"
                        messagebox("您的定制启动器版本居然比我们的最新版本还高，NB")
                        ver666.Text = $"当前版本:{ver114}最新版本:{number114}"
                        gxnr114.Text = "更新内容:" & vbCrLf & body
                        dlgx.IsEnabled = False
                    End If
                End If
            Else
                _114514in.Text = "未能获取到版本，请重试"
                dlurl114 = ""
                messagebox("未能获取到版本，请重试")
                dlgx.IsEnabled = False
            End If
        Catch ex As WebException
            dlurl114 = ""
            Errorbox($"错误:无法获取版本:{ex.Message()}")
        Catch ex As Exception
            dlurl114 = ""
            Errorbox($"错误:无法获取版本:{ex.Message()}")
        End Try
    End Sub
    Public Async Sub messagebox(nr114514 As String)
        SnackbarOne.Message.Content = nr114514
        SnackbarOne.IsActive = True
        Await Task.Delay(3000)
        SnackbarOne.IsActive = False
    End Sub
    Private Async Sub Errorbox(nr114514 As String)
        singleText.Text = nr114514
        singleTitle.Text = "发生错误"
        HelperGrid.MaxWidth = ActualWidth * 0.85
        HelperContent.MaxHeight = ActualHeight * 0.55
        Activate()
        DialogHost.Show(errorbox1145.DialogContent, "errorbox114")
    End Sub
    'Private Async Function GetPhpContentAsync(url As String) As Task(Of String)
    '    Try
    '        Using client As New HttpClient()
    '            Dim response As HttpResponseMessage = Await client.GetAsync(url)
    '            response.EnsureSuccessStatusCode()
    '            Dim content As String = Await response.Content.ReadAsStringAsync()
    '            Return content
    '        End Using
    '    Catch ex As HttpRequestException
    '        MsgBox("您的网络可能有问题,我们无法连接到更新服务器,请检查您的网络后重试┗|｀O′|┛ 嗷~~", vbCritical)
    '        Return Nothing
    '    Catch ex1 As Exception
    '        MsgBox("啊,我们无法连接到服务器,报错信息如下" & ex1.ToString, vbCritical)
    '        Return Nothing
    '    End Try
    'End Function
    Public Function GetNumbersAndDecimalPoint(strInput As String) As String
        Dim regex As New Regex("[0-9.]+") ' 匹配所有数字和小数点
        Dim match As Match = regex.Match(strInput)
        If match.Success Then
            Return match.Value
        Else
            Return "" ' 如果没有找到数字和小数点，返回空字符串
        End If
    End Function
    Private Sub checkupdate_Click(sender As Object, e As RoutedEventArgs) Handles checkupdate.Click
        GetReleaseInfo()
    End Sub
    Private Sub dlgx_Click(sender As Object, e As RoutedEventArgs) Handles dlgx.Click
        If dlurl114 = "" = False Then
            Hide()
            Dim rl114 As New dl(dlurl114)
            rl114.ShowDialog()
            Close()
        Else
            Errorbox("无法获取下载链接")
        End If
    End Sub
End Class
