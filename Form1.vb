Imports System.IO
Imports Newtonsoft.Json

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadTasksFromFile()
            ConfigureMaskedTextBoxes()
            AddHandler TextBox1.TextChanged, AddressOf Input_Changed
            AddHandler MaskedTextBoxDate.TextChanged, AddressOf Input_Changed
            AddHandler MaskedTextBoxTime.TextChanged, AddressOf Input_Changed
            ValidateInputs()
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

    Private Sub Input_Changed(sender As Object, e As EventArgs)
        ValidateInputs()
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

    Private Shadows Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        ' Since Add button is enabled only when inputs are valid, directly add the task.
        Dim task As String = TextBox1.Text.Trim()
        ' Check if the task already exists in the list
        If Not checktask.Items.Contains(task) Then
            ' Add the task to the CheckedListBox
            checktask.Items.Add(task, False)
            TextBox1.Clear()
            ' Optionally, save tasks right away or according to your application's flow
            SaveTasksToFile()
        Else
            MessageBox.Show("This task has already been added.", "Duplicate Task", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub SaveTasksToFile()
        Dim tasksList As New List(Of TaskItem)
        For i As Integer = 0 To checktask.Items.Count - 1
            Dim taskName As String = checktask.Items(i).ToString()
            Dim isChecked As Boolean = checktask.GetItemChecked(i)
            tasksList.Add(New TaskItem(taskName, isChecked))
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
                checktask.Items.Add(taskItem.Name, taskItem.IsChecked)
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

        Public Sub New(name As String, isChecked As Boolean)
            Me.Name = name
            Me.IsChecked = isChecked
        End Sub
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
End Class
