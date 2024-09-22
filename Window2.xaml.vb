Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Media.Animation

Public Class Window2
    Public appDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    <DllImport("gdi32.dll")>
    Private Shared Function AddFontResource(ByVal lpFileName As String) As Integer
    End Function


    Private Sub Window2_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Preventthepointtoomanytimes2 = True Then
            Hide()
            Close()
        Else
            Preventthepointtoomanytimes2 = True
        End If

        Me.Width = SystemParameters.WorkArea.Width
        image1.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/81.ico"))
        'Start()
        Topmost = True
        Focus()
        check()
    End Sub
    Private Async Sub check()

        Await Task.Delay(1200)
        If errormsgbox = "ok" Then
            image1.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/1405.ico"))

            w1.Text = "保存成功~"
            Await Task.Delay(1000)
            Preventthepointtoomanytimes = False
            StartShrinkAnimation()
            'Hide()
            'Close()
        Else
            image1.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/1402.ico"))

            w1.Text = "保存失败！！！"
            Await Task.Delay(500)
            MsgBox("错误:" & errormsgbox, vbInformation, "Error！")
            Await Task.Delay(1000)
            Preventthepointtoomanytimes = False
            StartShrinkAnimation()
            'Hide()
            'Close()

        End If

    End Sub

    Private Sub StartShrinkAnimation()
        Dim initialX As Double = Me.Left
        Dim targetX As Double = SystemParameters.PrimaryScreenWidth
        Dim animation As New DoubleAnimation()
        animation.From = initialX
        animation.To = targetX
        animation.Duration = New Duration(TimeSpan.FromSeconds(1))
        animation.EasingFunction = New QuadraticEase()
        AddHandler animation.Completed, AddressOf Animation_Completed
        Me.BeginAnimation(Window.LeftProperty, animation)
    End Sub

    Private Sub Animation_Completed(sender As Object, e As EventArgs)
        Preventthepointtoomanytimes2 = False
        Close()
    End Sub

End Class
