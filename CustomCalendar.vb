Imports System.Windows.Forms

Public Class CustomCalendar
    Inherits UserControl

    Private tasks As New Dictionary(Of DateTime, List(Of String))

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
    End Sub

    Public Sub AddTask(taskDate As DateTime, taskTitle As String)
        If Not tasks.ContainsKey(taskDate.Date) Then
            tasks(taskDate.Date) = New List(Of String)
        End If
        tasks(taskDate.Date).Add(taskTitle)
        Invalidate() ' Refresh the control to show the updated tasks
    End Sub

    Public Sub ClearTasks()
        tasks.Clear()
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim startDate As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        Dim startDayOfWeek As Integer = CType(startDate.DayOfWeek, Integer)
        Dim currentMonth As Integer = DateTime.Now.Month

        Dim cellWidth As Integer = Width / 7
        Dim cellHeight As Integer = Height / 6

        Dim currentDate As DateTime = startDate.AddDays(-startDayOfWeek)

        For row As Integer = 0 To 5
            For col As Integer = 0 To 6
                Dim cellRect As New Rectangle(col * cellWidth, row * cellHeight, cellWidth, cellHeight)
                e.Graphics.DrawRectangle(Pens.Black, cellRect)

                If currentDate.Month = currentMonth Then
                    e.Graphics.DrawString(currentDate.Day.ToString(), Font, Brushes.Black, cellRect.Location)

                    If tasks.ContainsKey(currentDate.Date) Then
                        Dim taskTitles As String = String.Join(", ", tasks(currentDate.Date))
                        e.Graphics.DrawString(taskTitles, Font, Brushes.Blue, cellRect.X, cellRect.Y + 20)
                    End If
                Else
                    e.Graphics.DrawString(currentDate.Day.ToString(), Font, Brushes.Gray, cellRect.Location)
                End If

                currentDate = currentDate.AddDays(1)
            Next
        Next
    End Sub
End Class
