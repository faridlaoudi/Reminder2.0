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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
        Timer = New Timer(components)
        TextBoxDescription = New TextBox()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(548, 301)
        Label2.Name = "Label2"
        Label2.RightToLeft = RightToLeft.Yes
        Label2.Size = New Size(100, 23)
        Label2.TabIndex = 1
        Label2.Text = "متى موعدها :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(556, 72)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.Yes
        Label3.Size = New Size(92, 23)
        Label3.TabIndex = 2
        Label3.Text = "اسم المهمة :"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(368, 98)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(280, 46)
        TextBox1.TabIndex = 4
        ' 
        ' Delete
        ' 
        Delete.Location = New Point(95, 391)
        Delete.Name = "Delete"
        Delete.Size = New Size(145, 45)
        Delete.TabIndex = 5
        Delete.Text = "امسح المهمة"
        Delete.UseVisualStyleBackColor = True
        ' 
        ' MaskedTextBoxDate
        ' 
        MaskedTextBoxDate.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MaskedTextBoxDate.Location = New Point(368, 337)
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
        mytasks.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        mytasks.Location = New Point(282, 69)
        mytasks.Name = "mytasks"
        mytasks.RightToLeft = RightToLeft.Yes
        mytasks.Size = New Size(74, 23)
        mytasks.TabIndex = 11
        mytasks.Text = "مهماتي : "
        mytasks.TextAlign = ContentAlignment.TopRight
        ' 
        ' checktask
        ' 
        checktask.FormattingEnabled = True
        checktask.Location = New Point(12, 96)
        checktask.Name = "checktask"
        checktask.RightToLeft = RightToLeft.Yes
        checktask.Size = New Size(344, 290)
        checktask.TabIndex = 12
        ' 
        ' Add
        ' 
        Add.Location = New Point(443, 391)
        Add.Name = "Add"
        Add.Size = New Size(128, 36)
        Add.TabIndex = 13
        Add.Text = "أضف"
        Add.UseVisualStyleBackColor = True
        ' 
        ' MaskedTextBoxTime
        ' 
        MaskedTextBoxTime.Font = New Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MaskedTextBoxTime.Location = New Point(577, 337)
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
        exitbtn.Location = New Point(617, 15)
        exitbtn.Name = "exitbtn"
        exitbtn.Size = New Size(35, 29)
        exitbtn.TabIndex = 15
        exitbtn.Text = "X"
        exitbtn.UseVisualStyleBackColor = False
        ' 
        ' Timer
        ' 
        Timer.Interval = 60000
        ' 
        ' TextBoxDescription
        ' 
        TextBoxDescription.Location = New Point(372, 199)
        TextBoxDescription.Multiline = True
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.Size = New Size(280, 89)
        TextBoxDescription.TabIndex = 17
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(459, 163)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(189, 23)
        Label1.TabIndex = 16
        Label1.Text = "وصف للمهمة :  (اختياري) "
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(137, 67)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 18
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(672, 471)
        Controls.Add(PictureBox1)
        Controls.Add(TextBoxDescription)
        Controls.Add(Label1)
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
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Timer As Timer
    Friend WithEvents TextBoxDescription As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox

End Class
