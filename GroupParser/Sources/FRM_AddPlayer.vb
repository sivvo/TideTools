Public Class FRM_AddPlayer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTN_Add As System.Windows.Forms.Button
    Friend WithEvents TXT_Name As System.Windows.Forms.TextBox
    Friend WithEvents CMB_Class As System.Windows.Forms.ComboBox
    Friend WithEvents BTN_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TXT_Name = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMB_Class = New System.Windows.Forms.ComboBox
        Me.BTN_Add = New System.Windows.Forms.Button
        Me.BTN_Cancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TXT_Name
        '
        Me.TXT_Name.Location = New System.Drawing.Point(48, 8)
        Me.TXT_Name.Name = "TXT_Name"
        Me.TXT_Name.Size = New System.Drawing.Size(208, 20)
        Me.TXT_Name.TabIndex = 0
        Me.TXT_Name.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name :"
        '
        'CMB_Class
        '
        Me.CMB_Class.Location = New System.Drawing.Point(48, 32)
        Me.CMB_Class.Name = "CMB_Class"
        Me.CMB_Class.Size = New System.Drawing.Size(208, 21)
        Me.CMB_Class.TabIndex = 2
        '
        'BTN_Add
        '
        Me.BTN_Add.Location = New System.Drawing.Point(176, 64)
        Me.BTN_Add.Name = "BTN_Add"
        Me.BTN_Add.Size = New System.Drawing.Size(80, 24)
        Me.BTN_Add.TabIndex = 3
        Me.BTN_Add.Text = "Add"
        '
        'BTN_Cancel
        '
        Me.BTN_Cancel.Location = New System.Drawing.Point(8, 64)
        Me.BTN_Cancel.Name = "BTN_Cancel"
        Me.BTN_Cancel.Size = New System.Drawing.Size(80, 24)
        Me.BTN_Cancel.TabIndex = 4
        Me.BTN_Cancel.Text = "Cancel"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Class :"
        '
        'FRM_AddPlayer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(264, 96)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTN_Cancel)
        Me.Controls.Add(Me.BTN_Add)
        Me.Controls.Add(Me.CMB_Class)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXT_Name)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRM_AddPlayer"
        Me.Text = "Add Player"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public FRM_Main As FRM_Main
    Public pPlayer As New Player
    Public NumGroup As Byte

    Private Sub FRM_AddPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Byte

        For i = 0 To FRM_Main.pClassesName.Length - 1
            CMB_Class.Items.Add(FRM_Main.pClassesName(i))
        Next

        pPlayer.Name = ""
        pPlayer.Type = pClasses.CLS_BARD
    End Sub

    Private Sub BTN_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Cancel.Click
        Me.Close()
    End Sub

    Private Sub BTN_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Add.Click
        If TXT_Name.Text = "" Then
            MsgBox("You need a valid player name")
            Exit Sub
        End If

        If CMB_Class.SelectedIndex < 0 Then
            MsgBox("You need to select a class")
            Exit Sub
        End If


        pPlayer.Name = TXT_Name.Text
        pPlayer.Type = CMB_Class.SelectedIndex
        pPlayer.Group = NumGroup

        FRM_Main.AddPlayer(pPlayer, NumGroup)

        Me.Close()

    End Sub
End Class
