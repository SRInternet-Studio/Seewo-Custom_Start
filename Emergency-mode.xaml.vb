Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Media.Animation

Public Class Emergency_mode
    Public appDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Public zt As String
    Private Sub Emergency_mode_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If File.Exists(appDirectory & "\file.sr") Then

            Using reader As New StreamReader(appDirectory & "\Emergency-mode.Sr")
                zt = reader.ReadLine()
            End Using
        End If
        If zt = "True" Then
            oon.Text = "已启用应急模式"
            image.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/1036-1.bmp"))
            oon.Foreground = New SolidColorBrush(Color.FromRgb(255, 0, 0))
            _114514warp.IsChecked = True
            in1.Text = "你的 定制启动器 是 "
            Dim myTextBlock As TextBlock = TryCast(Application.Current.MainWindow.FindName("in1"), TextBlock)
            Dim additionalTextBlock As New TextBlock()
            additionalTextBlock.Text = "私密的"
            additionalTextBlock.Foreground = New SolidColorBrush(Color.FromRgb(243, 128, 32))
            myTextBlock.Inlines.Add(additionalTextBlock)
        Else
            oon.Text = "已停用应急模式"
            image.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/1035-1.bmp"))
            oon.Foreground = New SolidColorBrush(Color.FromRgb(0, 0, 255))
            _114514warp.IsChecked = False
            in1.Text = "你的 定制启动器 不是 "
            Dim myTextBlock As TextBlock = TryCast(Application.Current.MainWindow.FindName("in1"), TextBlock)
            Dim additionalTextBlock As New TextBlock()
            additionalTextBlock.Text = "私密的"
            additionalTextBlock.Foreground = New SolidColorBrush(Color.FromRgb(243, 128, 32))
            myTextBlock.Inlines.Add(additionalTextBlock)
        End If
    End Sub

    'Private Sub ellipse_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ellipse.MouseLeftButtonDown
    '    If zt = "False" Then
    '        zt = "True"
    '        oon.Text = "已启用"
    '        oon.Foreground = New SolidColorBrush(Color.FromRgb(255, 0, 0))
    '        in1.Text = "应急模式已开启，SeewoStart的功能受限制"

    '        File.Delete(appDirectory & "\Emergency-mode.Sr")
    '        Using reader As New StreamWriter(appDirectory & "\Emergency-mode.Sr")
    '            reader.WriteLine(zt)
    '        End Using
    '        Dim startStoryboard As Storyboard = TryCast(FindResource("on"), Storyboard)
    '        ' 当Storyboard资源存在时，播放动画
    '        startStoryboard.Begin()
    '    Else
    '        zt = "False"
    '        oon.Text = "已禁用"
    '        oon.Foreground = New SolidColorBrush(Color.FromRgb(0, 0, 255))
    '        in1.Text = "应急模式已关闭，SeewoStart的功能将不再受限制"
    '        File.Delete(appDirectory & "\Emergency-mode.Sr")
    '        Using reader As New StreamWriter(appDirectory & "\Emergency-mode.Sr")
    '            reader.WriteLine(zt)
    '        End Using
    '        Dim startStoryboard As Storyboard = TryCast(FindResource("off"), Storyboard)
    '        ' 当Storyboard资源存在时，播放动画
    '        startStoryboard.Begin()
    '    End If
    'End Sub

    Private Sub Emergency_mode_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Process.GetCurrentProcess().Kill()
    End Sub

    Private Sub Emergency_mode_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Sub _114514warp_Click(sender As Object, e As RoutedEventArgs) Handles _114514warp.Click
        If _114514warp.IsChecked = True Then
            zt = "True"
            oon.Text = "已启用应急模式"
            image.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/1036-1.bmp"))
            oon.Foreground = New SolidColorBrush(Color.FromRgb(255, 0, 0))
            in1.Text = "你的 定制启动器 是 "
            Dim myTextBlock As TextBlock = TryCast(Application.Current.MainWindow.FindName("in1"), TextBlock)
            Dim additionalTextBlock As New TextBlock()
            additionalTextBlock.Text = "私密的"
            additionalTextBlock.Foreground = New SolidColorBrush(Color.FromRgb(243, 128, 32))
            myTextBlock.Inlines.Add(additionalTextBlock)
            File.Delete(appDirectory & "\Emergency-mode.Sr")
            Using reader As New StreamWriter(appDirectory & "\Emergency-mode.Sr")
                reader.WriteLine(zt)
            End Using

        Else
            zt = "False"
            oon.Text = "已停用应急模式"
            image.Source = New BitmapImage(New Uri("pack://application:,,,/default-img/1035-1.bmp"))
            oon.Foreground = New SolidColorBrush(Color.FromRgb(0, 0, 255))
            in1.Text = "你的 定制启动器 不是 "
            Dim myTextBlock As TextBlock = TryCast(Application.Current.MainWindow.FindName("in1"), TextBlock)
            Dim additionalTextBlock As New TextBlock()
            additionalTextBlock.Text = "私密的"
            additionalTextBlock.Foreground = New SolidColorBrush(Color.FromRgb(243, 128, 32))
            myTextBlock.Inlines.Add(additionalTextBlock)
            File.Delete(appDirectory & "\Emergency-mode.Sr")
            Using reader As New StreamWriter(appDirectory & "\Emergency-mode.Sr")
                reader.WriteLine(zt)
            End Using
        End If
    End Sub
End Class
