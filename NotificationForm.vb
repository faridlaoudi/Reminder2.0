Imports System.Windows.Forms
Imports reminder1.Form1

Public Class NotificationForm
    Private _taskItem As TaskItem
    Private _parentForm As Form1

    Public Sub New(taskItem As TaskItem, parentForm As Form1)
        InitializeComponent()
        _taskItem = taskItem
        _parentForm = parentForm
        LabelTask.Text = $"It's time for task: {_taskItem.Name}"
        Me.StartPosition = FormStartPosition.Manual
        Dim screenArea = Screen.PrimaryScreen.WorkingArea
        Me.Location = New Point(screenArea.Width - Me.Width, 0)
    End Sub

    Private Sub ButtonCompleted_Click(sender As Object, e As EventArgs) Handles ButtonCompleted.Click
        _taskItem.IsChecked = True
        _parentForm.SaveTasksToFile()
        Me.Close()
    End Sub

    Private Sub ButtonNotifyLater_Click(sender As Object, e As EventArgs) Handles ButtonNotifyLater.Click
        _taskItem.LastNotified = DateTime.Now
        _parentForm.SaveTasksToFile()
        Me.Close()
    End Sub
End Class
