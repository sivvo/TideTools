Public Class FRM_Known
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
    Friend WithEvents TRV_Players As System.Windows.Forms.TreeView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TRV_Players = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'TRV_Players
        '
        Me.TRV_Players.ImageIndex = -1
        Me.TRV_Players.Name = "TRV_Players"
        Me.TRV_Players.SelectedImageIndex = -1
        Me.TRV_Players.Size = New System.Drawing.Size(144, 322)
        Me.TRV_Players.TabIndex = 0
        '
        'FRM_Known
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(144, 322)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TRV_Players})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FRM_Known"
        Me.Text = "Known Players"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public FRM_Main As FRM_Main
    Public FRM_Template As FRM_TemplateBuilder
    Private SelectedNode As TreeNode
    Public NumGroup As Byte = 0
    Public bTemplateBuilder As Byte = False

    Private Sub FRM_Known_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Function CreateTree()
        Dim i As Integer
        Dim j As Byte
        Dim MyNode As TreeNode

        For i = 0 To 16
            TRV_Players.Nodes.Add(FRM_Main.pClassesName(i))
        Next

        For i = 0 To FRM_Main.KnownPlayers.Count - 1

            MyNode = TRV_Players.Nodes(FRM_Main.KnownPlayers(i).Type).Nodes.Add(FRM_Main.KnownPlayers(i).Name)

            If bTemplateBuilder Then

            Else
                If FRM_Main.KnownPlayers.Count > 0 And FRM_Main.PlayerTab.Count > 0 Then
                    For j = 0 To FRM_Main.PlayerTab.Count - 1
                        If FRM_Main.PlayerTab(j).Name = FRM_Main.KnownPlayers(i).Name Then
                            MyNode.ForeColor = Color.Red
                            MyNode.Tag = "Fuck"
                        End If
                    Next
                End If
            End If

        Next

    End Function

    Private Sub FRM_Known_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        TRV_Players.Width = Me.Width - 8
        TRV_Players.Height = Me.Height - 24
    End Sub

    Private Sub TRV_Players_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TRV_Players.AfterSelect
        If Not e.Node.Parent Is Nothing Then
            SelectedNode = e.Node
        End If
    End Sub

    Private Sub TRV_Players_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TRV_Players.DoubleClick

        If SelectedNode Is Nothing Then
            MsgBox("Error, no selected node", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If bTemplateBuilder Then
            Dim Cast As FRM_TemplateBuilder
            CAst = Owner
            Cast.AddStringToGroup(SelectedNode.Text)
        Else

            Dim Cast As FRM_Main
            Dim pPlayer As New Player

            If SelectedNode.Tag = "Fuck" Then
                MsgBox("Error, That player is already in your raid", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Cast = Owner

            pPlayer.Name = SelectedNode.Text
            pPlayer.Type = SelectedNode.Parent.Index
            pPlayer.Group = NumGroup

            FRM_Main.AddPlayer(pPlayer, NumGroup)

        End If

        Me.Close()

    End Sub
End Class
