Imports System.IO
Imports Newtonsoft.Json
Imports System.Windows.Forms

Public Class Form1
    Private WithEvents NotificationTimer As New Timer()
    Private WithEvents TrayIcon As New NotifyIcon()
    Private WithEvents TrayMenu As New ContextMenuStrip()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AddToStartup()
            LoadTasksFromFile()
            ConfigureMaskedTextBoxes()
            AddHandler TextBox1.TextChanged, AddressOf Input_Changed
            AddHandler MaskedTextBoxDate.TextChanged, AddressOf Input_Changed
            AddHandler MaskedTextBoxTime.TextChanged, AddressOf Input_Changed
            ValidateInputs()

            ' Configure Tray Icon
            TrayIcon.Icon = SystemIcons.Application
            TrayIcon.Text = "Task Reminder"
            TrayMenu.Items.Add("Open", Nothing, AddressOf RestoreFromTray)
            TrayMenu.Items.Add("Exit", Nothing, AddressOf ExitApplication)
            TrayIcon.ContextMenuStrip = TrayMenu
            TrayIcon.Visible = True

            ' Start the timer
            NotificationTimer.Interval = 60000 ' 1 minute
            NotificationTimer.Start()

            ' Check tasks and display notifications when the form loads
            CheckAndNotifyTasks()
        Catch ex As Exception
            MsgBox("Error loading data.")
        End Try
    End Sub

    Private Sub AddToStartup()
        Try
            Dim startupFolderPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
            Dim shortcutPath As String = Path.Combine(startupFolderPath, "TaskReminderApp.lnk")

            If Not IO.File.Exists(shortcutPath) Then
                Dim shell = CreateObject("WScript.Shell")
                Dim shortcut = shell.CreateShortcut(shortcutPath)
                shortcut.TargetPath = Application.ExecutablePath
                shortcut.WorkingDirectory = Application.StartupPath
                shortcut.Save()
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to add to startup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Hide()
            TrayIcon.Visible = True
        End If
    End Sub

    Private Sub RestoreFromTray(sender As Object, e As EventArgs)
        Show()
        WindowState = FormWindowState.Normal
        TrayIcon.Visible = False
    End Sub

    Private Sub ExitApplication(sender As Object, e As EventArgs) Handles exitbtn.Click
        SaveTasksToFile()
        Application.Exit()
    End Sub
    Private Sub ConfigureMaskedTextBoxes()
        ' Date configuration
        MaskedTextBoxDate.Mask = "00/00/0000"
        MaskedTextBoxDate.ValidatingType = GetType(System.DateTime)
        ' Time configuration
        MaskedTextBoxTime.Mask = "00:00"
        MaskedTextBoxTime.ValidatingType = GetType(System.DateTime) ' Note: This is for simplicity; actual time validation happens in ValidateInputs.
    End Sub

    Private Sub ValidateInputs()
        Dim dateValue As DateTime
        Dim isValidDate As Boolean = DateTime.TryParse(MaskedTextBoxDate.Text, dateValue)
        Dim timeValue As TimeSpan
        Dim isValidTime As Boolean = TimeSpan.TryParse(MaskedTextBoxTime.Text, timeValue)
        Dim isTaskNotEmpty As Boolean = Not String.IsNullOrWhiteSpace(TextBox1.Text)
        ' Enable the Add button only if all conditions are met
        Add.Enabled = isValidDate AndAlso isValidTime AndAlso isTaskNotEmpty
    End Sub

    Private Sub NotificationTimer_Tick(sender As Object, e As EventArgs) Handles NotificationTimer.Tick
        ' Check tasks and display notifications periodically
        CheckAndNotifyTasks()
    End Sub

    Private Sub CheckAndNotifyTasks()
        Dim currentTime As DateTime = DateTime.Now

        For Each taskItem As TaskItem In checktask.Items
            Dim taskDateTime As DateTime = DateTime.ParseExact(taskItem.Date1 & " " & taskItem.Time, "dd/MM/yyyy HH:mm", Nothing)
            If currentTime >= taskDateTime And Not taskItem.Notified Then
                MessageBox.Show($"It's time for task: {taskItem.Name}", "Task Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                taskItem.LastNotified = currentTime
                taskItem.Notified = True
            End If
        Next
        SaveTasksToFile()
    End Sub


    Private Sub Input_Changed(sender As Object, e As EventArgs)
        ValidateInputs()
    End Sub

    Private Shadows Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim taskName As String = TextBox1.Text.Trim()
        Dim taskDate As String = MaskedTextBoxDate.Text
        Dim taskTime As String = MaskedTextBoxTime.Text
        Dim taskDescription As String = TextBoxDescription.Text.Trim()

        ' Since Add button is enabled only when inputs are valid, directly add the task.
        If Not String.IsNullOrEmpty(taskName) Then
            ' Add the new task with date, time, and description
            Dim newTask As New TaskItem(taskName, False, taskDate, taskTime, taskDescription)
            ' Check if a similar task already exists (based on Name, Date, and Time)
            Dim taskExists As Boolean = checktask.Items.Cast(Of TaskItem)().Any(Function(item) item.Name = newTask.Name AndAlso item.Date1 = newTask.Date1 AndAlso item.Time = newTask.Time)

            If Not taskExists Then
                checktask.Items.Add(newTask, False)
                TextBox1.Clear()
                TextBoxDescription.Clear()
                SaveTasksToFile()
            Else
                MessageBox.Show("This task with the same date and time has already been added.", "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please enter a task.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub SaveTasksToFile()
        Try
            Dim tasksList As New List(Of TaskItem)
            For Each item As TaskItem In checktask.Items
                tasksList.Add(item)
            Next

            Dim tasksJson As String = JsonConvert.SerializeObject(tasksList, Formatting.Indented)

            ' Get the path to the user's Documents folder
            Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

            ' Combine the path with the filename "tasks.json"
            Dim filePath As String = Path.Combine(documentsPath, "tasks.json")

            ' Write the tasks data to the file
            File.WriteAllText(filePath, tasksJson)
        Catch ex As Exception
            MessageBox.Show($"Error saving tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTasksFromFile()
        Try
            Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim filePath As String = Path.Combine(documentsPath, "tasks.json")

            If File.Exists(filePath) Then
                Dim tasksJson As String = File.ReadAllText(filePath)
                Dim tasksList As List(Of TaskItem) = JsonConvert.DeserializeObject(Of List(Of TaskItem))(tasksJson)

                If tasksList IsNot Nothing Then
                    checktask.Items.Clear()

                    Dim sortedTasks = tasksList.Where(Function(task) DateTime.ParseExact(task.Date1 & " " & task.Time, "dd/MM/yyyy HH:mm", Nothing) > DateTime.Now OrElse task.Notified) _
                                           .OrderBy(Function(task) DateTime.ParseExact(task.Date1 & " " & task.Time, "dd/MM/yyyy HH:mm", Nothing))

                    For Each taskItem As TaskItem In sortedTasks
                        checktask.Items.Add(taskItem, taskItem.IsChecked)
                    Next
                Else
                    MessageBox.Show("Failed to load tasks from file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        For i As Integer = checktask.Items.Count - 1 To 0 Step -1
            If checktask.GetItemChecked(i) Then
                checktask.Items.RemoveAt(i)
            End If
        Next

        SaveTasksToFile()
    End Sub

    Public Class TaskItem
        Public Property Name As String
        Public Property IsChecked As Boolean
        Public Property Date1 As String
        Public Property Time As String
        Public Property Description As String
        Public Property LastNotified As DateTime? = Nothing
        Public Property Notified As Boolean = False ' New property to track if the task has been notified

        Public Sub New(name As String, isChecked As Boolean, [date] As String, time As String, Optional description As String = "")
            Me.Name = name
            Me.IsChecked = isChecked
            Me.Date1 = [date]
            Me.Time = time
            Me.Description = description
        End Sub

        Public Overrides Function ToString() As String
            Dim nameLengthLimit As Integer = 20
            Dim formattedName As String = If(Name.Length > nameLengthLimit, String.Concat(Name.AsSpan(0, nameLengthLimit), "..."), Name)
            Return $"{formattedName} | يوم: {Date1}, على : {Time}"
        End Function
    End Class

    Private Sub MaskedTextBox_ValidationCompleted(sender As Object, e As TypeValidationEventArgs)
        If Not e.IsValidInput Then
            MessageBox.Show("Please enter a valid date or time.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CType(sender, MaskedTextBox).Focus()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Dim currentTime As DateTime = DateTime.Now
        For Each taskItem As TaskItem In checktask.Items
            Dim taskDateTime As DateTime = DateTime.ParseExact(taskItem.Date1 & " " & taskItem.Time, "dd/MM/yyyy HH:mm", Nothing)
            If currentTime = taskDateTime Then
                MessageBox.Show($"انه وقت : {taskItem.Name}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub


    Private Sub Checktask_SelectedIndexChanged(sender As Object, e As EventArgs) Handles checktask.SelectedIndexChanged
        If checktask.SelectedIndex >= 0 Then
            Dim selectedTask As TaskItem = CType(checktask.SelectedItem, TaskItem)
            If selectedTask IsNot Nothing Then
                MessageBox.Show(selectedTask.Description, "Task Description", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class
