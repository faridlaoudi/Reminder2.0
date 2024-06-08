<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotificationForm
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
        Me.LabelTask = New System.Windows.Forms.Label()
        Me.ButtonCompleted = New System.Windows.Forms.Button()
        Me.ButtonNotifyLater = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LabelTask
        '
        Me.LabelTask.AutoSize = True
        Me.LabelTask.Location = New System.Drawing.Point(12, 9)
        Me.LabelTask.Name = "LabelTask"
        Me.LabelTask.Size = New System.Drawing.Size(78, 13)
        Me.LabelTask.TabIndex = 0
        Me.LabelTask.Text = "Task Reminder"
        '
        'ButtonCompleted
        '
        Me.ButtonCompleted.Location = New System.Drawing.Point(15, 35)
        Me.ButtonCompleted.Name = "ButtonCompleted"
        Me.ButtonCompleted.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCompleted.TabIndex = 1
        Me.ButtonCompleted.Text = "Completed"
        Me.ButtonCompleted.UseVisualStyleBackColor = True
        '
        'ButtonNotifyLater
        '
        Me.ButtonNotifyLater.Location = New System.Drawing.Point(96, 35)
        Me.ButtonNotifyLater.Name = "ButtonNotifyLater"
        Me.ButtonNotifyLater.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNotifyLater.TabIndex = 2
        Me.ButtonNotifyLater.Text = "Notify Later"
        Me.ButtonNotifyLater.UseVisualStyleBackColor = True
        '
        'NotificationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 61)
        Me.Controls.Add(Me.ButtonNotifyLater)
        Me.Controls.Add(Me.ButtonCompleted)
        Me.Controls.Add(Me.LabelTask)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NotificationForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelTask As System.Windows.Forms.Label
    Friend WithEvents ButtonCompleted As System.Windows.Forms.Button
    Friend WithEvents ButtonNotifyLater As System.Windows.Forms.Button
End Class
