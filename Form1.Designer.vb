<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label2 = New Label()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Delete = New Button()
        MaskedTextBoxDate = New MaskedTextBox()
        Label4 = New Label()
        mytasks = New Label()
        checktask = New CheckedListBox()
        Add = New Button()
        MaskedTextBoxTime = New MaskedTextBox()
        exitbtn = New Button()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(24, 170)
        Label2.Name = "Label2"
        Label2.Size = New Size(151, 20)
        Label2.TabIndex = 1
        Label2.Text = "When is the deadline:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(25, 55)
        Label3.Name = "Label3"
        Label3.Size = New Size(128, 20)
        Label3.TabIndex = 2
        Label3.Text = "What is your task :"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(24, 82)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(280, 78)
        TextBox1.TabIndex = 4
        ' 
        ' Delete
        ' 
        Delete.Location = New Point(371, 378)
        Delete.Name = "Delete"
        Delete.Size = New Size(119, 29)
        Delete.TabIndex = 5
        Delete.Text = "Delete Tasks"
        Delete.UseVisualStyleBackColor = True
        ' 
        ' MaskedTextBoxDate
        ' 
        MaskedTextBoxDate.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MaskedTextBoxDate.Location = New Point(24, 193)
        MaskedTextBoxDate.Mask = "00/00/0000"
        MaskedTextBoxDate.Name = "MaskedTextBoxDate"
        MaskedTextBoxDate.Size = New Size(203, 31)
        MaskedTextBoxDate.TabIndex = 8
        MaskedTextBoxDate.TextAlign = HorizontalAlignment.Center
        MaskedTextBoxDate.ValidatingType = GetType(Date)
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(25, 279)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 20)
        Label4.TabIndex = 10
        ' 
        ' mytasks
        ' 
        mytasks.AutoSize = True
        mytasks.Location = New Point(323, 55)
        mytasks.Name = "mytasks"
        mytasks.Size = New Size(72, 20)
        mytasks.TabIndex = 11
        mytasks.Text = "My tasks :"
        ' 
        ' checktask
        ' 
        checktask.FormattingEnabled = True
        checktask.Location = New Point(323, 81)
        checktask.Name = "checktask"
        checktask.Size = New Size(205, 290)
        checktask.TabIndex = 12
        ' 
        ' Add
        ' 
        Add.Location = New Point(99, 242)
        Add.Name = "Add"
        Add.Size = New Size(128, 36)
        Add.TabIndex = 13
        Add.Text = "Add"
        Add.UseVisualStyleBackColor = True
        ' 
        ' MaskedTextBoxTime
        ' 
        MaskedTextBoxTime.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MaskedTextBoxTime.Location = New Point(233, 193)
        MaskedTextBoxTime.Mask = "00:00"
        MaskedTextBoxTime.Name = "MaskedTextBoxTime"
        MaskedTextBoxTime.Size = New Size(71, 31)
        MaskedTextBoxTime.TabIndex = 14
        MaskedTextBoxTime.TextAlign = HorizontalAlignment.Center
        MaskedTextBoxTime.ValidatingType = GetType(Date)
        ' 
        ' exitbtn
        ' 
        exitbtn.BackColor = SystemColors.ActiveBorder
        exitbtn.Location = New Point(497, 12)
        exitbtn.Name = "exitbtn"
        exitbtn.Size = New Size(35, 29)
        exitbtn.TabIndex = 15
        exitbtn.Text = "X"
        exitbtn.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(544, 425)
        Controls.Add(exitbtn)
        Controls.Add(MaskedTextBoxTime)
        Controls.Add(Add)
        Controls.Add(checktask)
        Controls.Add(mytasks)
        Controls.Add(Label4)
        Controls.Add(MaskedTextBoxDate)
        Controls.Add(Delete)
        Controls.Add(TextBox1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        FormBorderStyle = FormBorderStyle.None
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Delete As Button
    Friend WithEvents MaskedTextBoxDate As MaskedTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents mytasks As Label
    Friend WithEvents checktask As CheckedListBox
    Friend WithEvents Add As Button
    Friend WithEvents MaskedTextBoxTime As MaskedTextBox
    Friend WithEvents exitbtn As Button

End Class
