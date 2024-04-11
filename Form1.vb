Imports System.IO
Imports Newtonsoft.Json
Public Class Form1

    Private WithEvents notificationTimer As New Timer()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadTasksFromFile()
            ConfigureMaskedTextBoxes()
            AddHandler TextBox1.TextChanged, AddressOf Input_Changed
            AddHandler MaskedTextBoxDate.TextChanged, AddressOf Input_Changed
            AddHandler MaskedTextBoxTime.TextChanged, AddressOf Input_Changed
            ValidateInputs()

            ' Start the timer
            notificationTimer.Interval = 60000 ' 1 minute
            notificationTimer.Start()

            ' Check tasks and display notifications when the form loads
            CheckAndNotifyTasks()
        Catch ex As Exception
            MsgBox("Error loading data.")
        End Try
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

    Private Sub notificationTimer_Tick(sender As Object, e As EventArgs) Handles notificationTimer.Tick
        ' Check tasks and display notifications periodically
        CheckAndNotifyTasks()
    End Sub

    Private Sub CheckAndNotifyTasks()
        Dim currentTime As DateTime = DateTime.Now
        For Each taskItem As TaskItem In checktask.Items
            Dim taskDateTime As DateTime = DateTime.ParseExact(taskItem.Date1 & " " & taskItem.Time, "dd/MM/yyyy HH:mm", Nothing)
            If currentTime >= taskDateTime Then
                MessageBox.Show($"It's time for task: {taskItem.Name}", "Task Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub

    Private Sub Input_Changed(sender As Object, e As EventArgs)
        ValidateInputs()
    End Sub


    Private Shadows Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim taskName As String = TextBox1.Text.Trim()
        Dim taskDate As String = MaskedTextBoxDate.Text
        Dim taskTime As String = MaskedTextBoxTime.Text

        ' Since Add button is enabled only when inputs are valid, directly add the task.
        If Not String.IsNullOrEmpty(taskName) Then
            ' Add the new task with date and time
            Dim newTask As New TaskItem(taskName, False, taskDate, taskTime)
            ' Check if a similar task already exists (based on Name, Date, and Time)
            Dim taskExists As Boolean = checktask.Items.Cast(Of TaskItem)().Any(Function(item) item.Name = newTask.Name AndAlso item.Date1 = newTask.Date1 AndAlso item.Time = newTask.Time)

            If Not taskExists Then
                checktask.Items.Add(newTask, False)
                TextBox1.Clear()
                SaveTasksToFile()
            Else
                MessageBox.Show("This task with the same date and time has already been added.", "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please enter a task.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub SaveTasksToFile()
        Dim tasksList As New List(Of TaskItem)
        For Each item As TaskItem In checktask.Items
            tasksList.Add(item)
        Next

        Dim tasksJson As String = JsonConvert.SerializeObject(tasksList)
        File.WriteAllText("tasks.json", tasksJson)
    End Sub

    Private Sub LoadTasksFromFile()
        If File.Exists("tasks.json") Then
            Dim tasksJson As String = File.ReadAllText("tasks.json")
            Dim tasksList As List(Of TaskItem) = JsonConvert.DeserializeObject(Of List(Of TaskItem))(tasksJson)

            checktask.Items.Clear() ' Clear existing items before loading new ones
            For Each taskItem As TaskItem In tasksList
                checktask.Items.Add(taskItem, taskItem.IsChecked)
            Next
        End If
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
        ' Looping in reverse order to avoid skipping items due to removal shifting indices
        For i As Integer = checktask.Items.Count - 1 To 0 Step -1
            If checktask.GetItemChecked(i) Then ' If the item is checked (or selected, based on your UI)
                checktask.Items.RemoveAt(i) ' Remove the item
            End If
        Next

        SaveTasksToFile() ' Save the updated list of tasks to file
    End Sub

    Public Class TaskItem
        Public Property Name As String
        Public Property IsChecked As Boolean
        Public Property Date1 As String
        Public Property Time As String

        Public Sub New(name As String, isChecked As Boolean, [date] As String, time As String)
            Me.Name = name
            Me.IsChecked = isChecked
            Me.Date1 = [date]
            Me.Time = time
        End Sub
        Public Overrides Function ToString() As String
            ' Format the output to ensure it fits within the width of the checklist box
            Dim nameLengthLimit As Integer = 20 ' Limit for the length of the task name
            Dim formattedName As String = If(Name.Length > nameLengthLimit, Name.Substring(0, nameLengthLimit) & "...", Name)

            ' Combine the task name and additional information (date and time) using a separator
            Return $"{formattedName} | Date: {Date1}, Time: {Time}"
        End Function
    End Class

    Private Sub exitbtn_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        SaveTasksToFile()
        Application.Exit()
    End Sub

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
                MessageBox.Show($"It's time for task: {taskItem.Name}", "Task Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
    End Sub
End Class
