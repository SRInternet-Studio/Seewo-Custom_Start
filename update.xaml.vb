Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Public Class update
    Public phpcontent As String
    Public number114 As String
    Public ver114 As String
    Private Async Sub update_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Version.Contains("beta") Then
            phpcontent = Await GetPhpContentAsync("http://update.seewostart.sr-studio.top/updatebeta.php")
        Else
            phpcontent = Await GetPhpContentAsync("http://update.seewostart.sr-studio.top/update.php")
        End If
        Await Task.Delay(1000)
        If phpcontent IsNot Nothing Then
            number114 = GetNumbersAndDecimalPoint(phpcontent)
            ver114 = GetNumbersAndDecimalPoint(Version)
            If number114 = ver114 Then
                _114514in.Text = "您的定制启动器版本是最新的"

                Await Task.Delay(2000)
                Hide()
                Close()
            Else
                If number114 > ver114 Then
                    _114514in.Text = "您的定制启动器版本不是最新的，需更新"

                    If MsgBox("您的定制启动器版本为:" & ver114 & "最新版本是:" & number114 & "请问是否要更新?", vbYesNo + vbQuestion) = MsgBoxResult.Yes Then
                        Hide()
                        Dim rl114 As New dl
                        rl114.ShowDialog()
                        Close()
                    Else
                        Await Task.Delay(2000)
                        Hide()
                        Close()
                    End If
                Else
                    _114514in.Text = "您的定制启动器版本居然比我们的最新版本还高，NB"

                    Await Task.Delay(2000)

                    Hide()
                    Close()
                End If
            End If
        Else
            _114514in.Text = "未能获取到版本，请重试"
            Await Task.Delay(2000)
            Hide()
            Close()
        End If
    End Sub

    Private Async Function GetPhpContentAsync(url As String) As Task(Of String)
        Try
            Using client As New HttpClient()
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                response.EnsureSuccessStatusCode()
                Dim content As String = Await response.Content.ReadAsStringAsync()
                Return content
            End Using
        Catch ex As HttpRequestException
            MsgBox("您的网络可能有问题,我们无法连接到更新服务器,请检查您的网络后重试┗|｀O′|┛ 嗷~~", vbCritical)
            Return Nothing
        Catch ex1 As Exception
            MsgBox("啊,我们无法连接到服务器,报错信息如下" & ex1.ToString, vbCritical)
            Return Nothing
        End Try
    End Function
    Public Function GetNumbersAndDecimalPoint(strInput As String) As String
        Dim regex As New Regex("[0-9.]+") ' 匹配所有数字和小数点
        Dim match As Match = regex.Match(strInput)
        If match.Success Then
            Return match.Value
        Else
            Return "" ' 如果没有找到数字和小数点，返回空字符串
        End If
    End Function
End Class
