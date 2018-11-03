Option Compare Text
Imports System.IO

Public Class FRM_TemplateBuilder
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
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents AddMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents MNU_AddName As System.Windows.Forms.MenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LBL_Spot6 As System.Windows.Forms.Label
    Friend WithEvents LBL_Spot5 As System.Windows.Forms.Label
    Friend WithEvents LBL_Spot4 As System.Windows.Forms.Label
    Friend WithEvents LBL_Spot3 As System.Windows.Forms.Label
    Friend WithEvents LBL_Spot2 As System.Windows.Forms.Label
    Friend WithEvents LBL_Spot1 As System.Windows.Forms.Label
    Friend WithEvents TLB_TopBar As System.Windows.Forms.ToolBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TBB_New As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Open As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Save As System.Windows.Forms.ToolBarButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_Group1 As System.Windows.Forms.Button
    Friend WithEvents TBB_Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents BTN_Group2 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group3 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group4 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group5 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group6 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group7 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group8 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group12 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group11 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group10 As System.Windows.Forms.Button
    Friend WithEvents BTN_Group9 As System.Windows.Forms.Button
    Friend WithEvents MNU_Class1 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class2 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class3 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class5 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class6 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class7 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class8 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class4 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class9 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class10 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class11 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class12 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class13 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class14 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class15 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_Class16 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddType1 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddType2 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddType3 As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddAny As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_RemoveLast As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_RemoveSpot As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_ClearGroup As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddOtherName As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddKnown As System.Windows.Forms.MenuItem
    Friend WithEvents ChangeGroupNameMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents MNI_ChangeGroupName As System.Windows.Forms.MenuItem
    Friend WithEvents MNU_AddType4 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FRM_TemplateBuilder))
        Me.AddMenu = New System.Windows.Forms.ContextMenu
        Me.MNU_AddName = New System.Windows.Forms.MenuItem
        Me.MNU_AddKnown = New System.Windows.Forms.MenuItem
        Me.MNU_AddOtherName = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MNU_Class1 = New System.Windows.Forms.MenuItem
        Me.MNU_Class2 = New System.Windows.Forms.MenuItem
        Me.MNU_Class3 = New System.Windows.Forms.MenuItem
        Me.MNU_Class4 = New System.Windows.Forms.MenuItem
        Me.MNU_Class5 = New System.Windows.Forms.MenuItem
        Me.MNU_Class6 = New System.Windows.Forms.MenuItem
        Me.MNU_Class7 = New System.Windows.Forms.MenuItem
        Me.MNU_Class8 = New System.Windows.Forms.MenuItem
        Me.MNU_Class9 = New System.Windows.Forms.MenuItem
        Me.MNU_Class10 = New System.Windows.Forms.MenuItem
        Me.MNU_Class11 = New System.Windows.Forms.MenuItem
        Me.MNU_Class12 = New System.Windows.Forms.MenuItem
        Me.MNU_Class13 = New System.Windows.Forms.MenuItem
        Me.MNU_Class14 = New System.Windows.Forms.MenuItem
        Me.MNU_Class15 = New System.Windows.Forms.MenuItem
        Me.MNU_Class16 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MNU_AddType1 = New System.Windows.Forms.MenuItem
        Me.MNU_AddType2 = New System.Windows.Forms.MenuItem
        Me.MNU_AddType3 = New System.Windows.Forms.MenuItem
        Me.MNU_AddAny = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MNU_RemoveLast = New System.Windows.Forms.MenuItem
        Me.MNU_RemoveSpot = New System.Windows.Forms.MenuItem
        Me.MNU_ClearGroup = New System.Windows.Forms.MenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LBL_Spot6 = New System.Windows.Forms.Label
        Me.LBL_Spot5 = New System.Windows.Forms.Label
        Me.LBL_Spot4 = New System.Windows.Forms.Label
        Me.LBL_Spot3 = New System.Windows.Forms.Label
        Me.LBL_Spot2 = New System.Windows.Forms.Label
        Me.LBL_Spot1 = New System.Windows.Forms.Label
        Me.TLB_TopBar = New System.Windows.Forms.ToolBar
        Me.TBB_New = New System.Windows.Forms.ToolBarButton
        Me.TBB_Sep1 = New System.Windows.Forms.ToolBarButton
        Me.TBB_Open = New System.Windows.Forms.ToolBarButton
        Me.TBB_Save = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTN_Group9 = New System.Windows.Forms.Button
        Me.ChangeGroupNameMenu = New System.Windows.Forms.ContextMenu
        Me.MNI_ChangeGroupName = New System.Windows.Forms.MenuItem
        Me.BTN_Group10 = New System.Windows.Forms.Button
        Me.BTN_Group11 = New System.Windows.Forms.Button
        Me.BTN_Group12 = New System.Windows.Forms.Button
        Me.BTN_Group8 = New System.Windows.Forms.Button
        Me.BTN_Group7 = New System.Windows.Forms.Button
        Me.BTN_Group6 = New System.Windows.Forms.Button
        Me.BTN_Group5 = New System.Windows.Forms.Button
        Me.BTN_Group4 = New System.Windows.Forms.Button
        Me.BTN_Group3 = New System.Windows.Forms.Button
        Me.BTN_Group2 = New System.Windows.Forms.Button
        Me.BTN_Group1 = New System.Windows.Forms.Button
        Me.MNU_AddType4 = New System.Windows.Forms.MenuItem
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'AddMenu
        '
        Me.AddMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNU_AddName, Me.MenuItem2, Me.MenuItem5, Me.MNU_AddAny, Me.MenuItem10, Me.MNU_RemoveLast, Me.MNU_RemoveSpot, Me.MNU_ClearGroup})
        '
        'MNU_AddName
        '
        Me.MNU_AddName.Index = 0
        Me.MNU_AddName.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNU_AddKnown, Me.MNU_AddOtherName})
        Me.MNU_AddName.Text = "Add Name"
        '
        'MNU_AddKnown
        '
        Me.MNU_AddKnown.Index = 0
        Me.MNU_AddKnown.Text = "KnownName"
        '
        'MNU_AddOtherName
        '
        Me.MNU_AddOtherName.Index = 1
        Me.MNU_AddOtherName.Text = "Other"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNU_Class1, Me.MNU_Class2, Me.MNU_Class3, Me.MNU_Class4, Me.MNU_Class5, Me.MNU_Class6, Me.MNU_Class7, Me.MNU_Class8, Me.MNU_Class9, Me.MNU_Class10, Me.MNU_Class11, Me.MNU_Class12, Me.MNU_Class13, Me.MNU_Class14, Me.MNU_Class15, Me.MNU_Class16})
        Me.MenuItem2.Text = "Add Class"
        '
        'MNU_Class1
        '
        Me.MNU_Class1.Index = 0
        Me.MNU_Class1.Text = "a"
        '
        'MNU_Class2
        '
        Me.MNU_Class2.Index = 1
        Me.MNU_Class2.Text = "a"
        '
        'MNU_Class3
        '
        Me.MNU_Class3.Index = 2
        Me.MNU_Class3.Text = "a"
        '
        'MNU_Class4
        '
        Me.MNU_Class4.Index = 3
        Me.MNU_Class4.Text = "a"
        '
        'MNU_Class5
        '
        Me.MNU_Class5.Index = 4
        Me.MNU_Class5.Text = "a"
        '
        'MNU_Class6
        '
        Me.MNU_Class6.Index = 5
        Me.MNU_Class6.Text = "a"
        '
        'MNU_Class7
        '
        Me.MNU_Class7.Index = 6
        Me.MNU_Class7.Text = "a"
        '
        'MNU_Class8
        '
        Me.MNU_Class8.Index = 7
        Me.MNU_Class8.Text = "a"
        '
        'MNU_Class9
        '
        Me.MNU_Class9.Index = 8
        Me.MNU_Class9.Text = "a"
        '
        'MNU_Class10
        '
        Me.MNU_Class10.Index = 9
        Me.MNU_Class10.Text = "a"
        '
        'MNU_Class11
        '
        Me.MNU_Class11.Index = 10
        Me.MNU_Class11.Text = "a"
        '
        'MNU_Class12
        '
        Me.MNU_Class12.Index = 11
        Me.MNU_Class12.Text = "a"
        '
        'MNU_Class13
        '
        Me.MNU_Class13.Index = 12
        Me.MNU_Class13.Text = "a"
        '
        'MNU_Class14
        '
        Me.MNU_Class14.Index = 13
        Me.MNU_Class14.Text = "a"
        '
        'MNU_Class15
        '
        Me.MNU_Class15.Index = 14
        Me.MNU_Class15.Text = "a"
        '
        'MNU_Class16
        '
        Me.MNU_Class16.Index = 15
        Me.MNU_Class16.Text = "a"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNU_AddType1, Me.MNU_AddType2, Me.MNU_AddType3, Me.MNU_AddType4})
        Me.MenuItem5.Text = "Add Type"
        '
        'MNU_AddType1
        '
        Me.MNU_AddType1.Index = 0
        Me.MNU_AddType1.Text = "Healer"
        '
        'MNU_AddType2
        '
        Me.MNU_AddType2.Index = 1
        Me.MNU_AddType2.Text = "DPS"
        '
        'MNU_AddType3
        '
        Me.MNU_AddType3.Index = 2
        Me.MNU_AddType3.Text = "Tank"
        '
        'MNU_AddAny
        '
        Me.MNU_AddAny.Index = 3
        Me.MNU_AddAny.Text = "*"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 4
        Me.MenuItem10.Text = "-"
        '
        'MNU_RemoveLast
        '
        Me.MNU_RemoveLast.Index = 5
        Me.MNU_RemoveLast.Text = "Remove Last"
        '
        'MNU_RemoveSpot
        '
        Me.MNU_RemoveSpot.Index = 6
        Me.MNU_RemoveSpot.Text = "Clear Spot"
        '
        'MNU_ClearGroup
        '
        Me.MNU_ClearGroup.Index = 7
        Me.MNU_ClearGroup.Text = "Clear Group"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LBL_Spot6)
        Me.GroupBox1.Controls.Add(Me.LBL_Spot5)
        Me.GroupBox1.Controls.Add(Me.LBL_Spot4)
        Me.GroupBox1.Controls.Add(Me.LBL_Spot3)
        Me.GroupBox1.Controls.Add(Me.LBL_Spot2)
        Me.GroupBox1.Controls.Add(Me.LBL_Spot1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Group Composition"
        '
        'LBL_Spot6
        '
        Me.LBL_Spot6.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Spot6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Spot6.ContextMenu = Me.AddMenu
        Me.LBL_Spot6.Location = New System.Drawing.Point(12, 96)
        Me.LBL_Spot6.Name = "LBL_Spot6"
        Me.LBL_Spot6.Size = New System.Drawing.Size(308, 17)
        Me.LBL_Spot6.TabIndex = 18
        '
        'LBL_Spot5
        '
        Me.LBL_Spot5.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Spot5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Spot5.ContextMenu = Me.AddMenu
        Me.LBL_Spot5.Location = New System.Drawing.Point(12, 80)
        Me.LBL_Spot5.Name = "LBL_Spot5"
        Me.LBL_Spot5.Size = New System.Drawing.Size(308, 17)
        Me.LBL_Spot5.TabIndex = 17
        '
        'LBL_Spot4
        '
        Me.LBL_Spot4.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Spot4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Spot4.ContextMenu = Me.AddMenu
        Me.LBL_Spot4.Location = New System.Drawing.Point(12, 64)
        Me.LBL_Spot4.Name = "LBL_Spot4"
        Me.LBL_Spot4.Size = New System.Drawing.Size(308, 17)
        Me.LBL_Spot4.TabIndex = 16
        '
        'LBL_Spot3
        '
        Me.LBL_Spot3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Spot3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Spot3.ContextMenu = Me.AddMenu
        Me.LBL_Spot3.Location = New System.Drawing.Point(12, 48)
        Me.LBL_Spot3.Name = "LBL_Spot3"
        Me.LBL_Spot3.Size = New System.Drawing.Size(308, 17)
        Me.LBL_Spot3.TabIndex = 15
        '
        'LBL_Spot2
        '
        Me.LBL_Spot2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Spot2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Spot2.ContextMenu = Me.AddMenu
        Me.LBL_Spot2.Location = New System.Drawing.Point(12, 32)
        Me.LBL_Spot2.Name = "LBL_Spot2"
        Me.LBL_Spot2.Size = New System.Drawing.Size(308, 17)
        Me.LBL_Spot2.TabIndex = 14
        '
        'LBL_Spot1
        '
        Me.LBL_Spot1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Spot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Spot1.ContextMenu = Me.AddMenu
        Me.LBL_Spot1.Location = New System.Drawing.Point(12, 16)
        Me.LBL_Spot1.Name = "LBL_Spot1"
        Me.LBL_Spot1.Size = New System.Drawing.Size(308, 17)
        Me.LBL_Spot1.TabIndex = 13
        '
        'TLB_TopBar
        '
        Me.TLB_TopBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.TLB_TopBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBB_New, Me.TBB_Sep1, Me.TBB_Open, Me.TBB_Save})
        Me.TLB_TopBar.DropDownArrows = True
        Me.TLB_TopBar.ImageList = Me.ImageList1
        Me.TLB_TopBar.Location = New System.Drawing.Point(0, 0)
        Me.TLB_TopBar.Name = "TLB_TopBar"
        Me.TLB_TopBar.ShowToolTips = True
        Me.TLB_TopBar.Size = New System.Drawing.Size(330, 28)
        Me.TLB_TopBar.TabIndex = 1
        '
        'TBB_New
        '
        Me.TBB_New.ImageIndex = 0
        Me.TBB_New.ToolTipText = "New Template"
        '
        'TBB_Sep1
        '
        Me.TBB_Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBB_Open
        '
        Me.TBB_Open.ImageIndex = 1
        Me.TBB_Open.ToolTipText = "Open existing template"
        '
        'TBB_Save
        '
        Me.TBB_Save.ImageIndex = 2
        Me.TBB_Save.ToolTipText = "Save Template"
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTN_Group9)
        Me.GroupBox2.Controls.Add(Me.BTN_Group10)
        Me.GroupBox2.Controls.Add(Me.BTN_Group11)
        Me.GroupBox2.Controls.Add(Me.BTN_Group12)
        Me.GroupBox2.Controls.Add(Me.BTN_Group8)
        Me.GroupBox2.Controls.Add(Me.BTN_Group7)
        Me.GroupBox2.Controls.Add(Me.BTN_Group6)
        Me.GroupBox2.Controls.Add(Me.BTN_Group5)
        Me.GroupBox2.Controls.Add(Me.BTN_Group4)
        Me.GroupBox2.Controls.Add(Me.BTN_Group3)
        Me.GroupBox2.Controls.Add(Me.BTN_Group2)
        Me.GroupBox2.Controls.Add(Me.BTN_Group1)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(328, 112)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Groups"
        '
        'BTN_Group9
        '
        Me.BTN_Group9.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group9.Location = New System.Drawing.Point(8, 80)
        Me.BTN_Group9.Name = "BTN_Group9"
        Me.BTN_Group9.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group9.TabIndex = 17
        Me.BTN_Group9.Text = "Group 9"
        '
        'ChangeGroupNameMenu
        '
        Me.ChangeGroupNameMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNI_ChangeGroupName})
        '
        'MNI_ChangeGroupName
        '
        Me.MNI_ChangeGroupName.Index = 0
        Me.MNI_ChangeGroupName.Text = "Change Name"
        '
        'BTN_Group10
        '
        Me.BTN_Group10.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group10.Location = New System.Drawing.Point(88, 80)
        Me.BTN_Group10.Name = "BTN_Group10"
        Me.BTN_Group10.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group10.TabIndex = 16
        Me.BTN_Group10.Text = "Group 10"
        '
        'BTN_Group11
        '
        Me.BTN_Group11.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group11.Location = New System.Drawing.Point(168, 80)
        Me.BTN_Group11.Name = "BTN_Group11"
        Me.BTN_Group11.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group11.TabIndex = 15
        Me.BTN_Group11.Text = "Group 11"
        '
        'BTN_Group12
        '
        Me.BTN_Group12.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group12.Location = New System.Drawing.Point(248, 80)
        Me.BTN_Group12.Name = "BTN_Group12"
        Me.BTN_Group12.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group12.TabIndex = 14
        Me.BTN_Group12.Text = "Group 12"
        '
        'BTN_Group8
        '
        Me.BTN_Group8.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group8.Location = New System.Drawing.Point(248, 48)
        Me.BTN_Group8.Name = "BTN_Group8"
        Me.BTN_Group8.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group8.TabIndex = 13
        Me.BTN_Group8.Text = "Group 8"
        '
        'BTN_Group7
        '
        Me.BTN_Group7.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group7.Location = New System.Drawing.Point(168, 48)
        Me.BTN_Group7.Name = "BTN_Group7"
        Me.BTN_Group7.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group7.TabIndex = 12
        Me.BTN_Group7.Text = "Group 7"
        '
        'BTN_Group6
        '
        Me.BTN_Group6.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group6.Location = New System.Drawing.Point(88, 48)
        Me.BTN_Group6.Name = "BTN_Group6"
        Me.BTN_Group6.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group6.TabIndex = 11
        Me.BTN_Group6.Text = "Group 6"
        '
        'BTN_Group5
        '
        Me.BTN_Group5.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group5.Location = New System.Drawing.Point(8, 48)
        Me.BTN_Group5.Name = "BTN_Group5"
        Me.BTN_Group5.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group5.TabIndex = 10
        Me.BTN_Group5.Text = "Group 5"
        '
        'BTN_Group4
        '
        Me.BTN_Group4.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group4.Location = New System.Drawing.Point(248, 16)
        Me.BTN_Group4.Name = "BTN_Group4"
        Me.BTN_Group4.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group4.TabIndex = 9
        Me.BTN_Group4.Text = "Group 4"
        '
        'BTN_Group3
        '
        Me.BTN_Group3.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group3.Location = New System.Drawing.Point(168, 16)
        Me.BTN_Group3.Name = "BTN_Group3"
        Me.BTN_Group3.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group3.TabIndex = 8
        Me.BTN_Group3.Text = "Group 3"
        '
        'BTN_Group2
        '
        Me.BTN_Group2.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group2.Location = New System.Drawing.Point(88, 16)
        Me.BTN_Group2.Name = "BTN_Group2"
        Me.BTN_Group2.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group2.TabIndex = 7
        Me.BTN_Group2.Text = "Group 2"
        '
        'BTN_Group1
        '
        Me.BTN_Group1.ContextMenu = Me.ChangeGroupNameMenu
        Me.BTN_Group1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_Group1.Location = New System.Drawing.Point(8, 16)
        Me.BTN_Group1.Name = "BTN_Group1"
        Me.BTN_Group1.Size = New System.Drawing.Size(72, 24)
        Me.BTN_Group1.TabIndex = 6
        Me.BTN_Group1.Text = "Group 1"
        '
        'MNU_AddType4
        '
        Me.MNU_AddType4.Index = 3
        Me.MNU_AddType4.Text = "Control"
        '
        'FRM_TemplateBuilder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(330, 279)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TLB_TopBar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FRM_TemplateBuilder"
        Me.Text = "Group Template Builder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private SelectedLabel As Label
    Private SelectedGroup As Button

    Private CurrentGroup As Byte
    Private CurrentSpot As Byte

    Private Groups(6, 12) As String

    Public frm_Main As frm_Main
    Public GroupNames(12) As String

    Private Sub BTN_Group_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Group1.Click, BTN_Group2.Click, BTN_Group3.Click, BTN_Group4.Click, BTN_Group5.Click, BTN_Group6.Click, BTN_Group7.Click, BTN_Group8.Click, BTN_Group9.Click, BTN_Group10.Click, BTN_Group11.Click, BTN_Group12.Click
        Dim i As Byte
        SelectedGroup = sender

        For i = 1 To 12
            If SelectedGroup Is BTN_Group(i) Then
                CurrentGroup = i
            End If
        Next

        For i = 1 To 6
            LBL_Spot(i).Text = Groups(i - 1, CurrentGroup - 1)
        Next

    End Sub

    Private Sub FRM_TemplateBuilder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectedLabel = LBL_Spot1
        SelectedLabel.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)

        CurrentGroup = 1
        CurrentSpot = 1
    End Sub

    Private Sub LBL_Spot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBL_Spot1.Click, LBL_Spot2.Click, LBL_Spot3.Click, LBL_Spot4.Click, LBL_Spot5.Click, LBL_Spot6.Click
        Dim i As Byte

        SelectedLabel.BackColor = Color.FromKnownColor(KnownColor.InactiveCaptionText)
        SelectedLabel = sender
        SelectedLabel.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)

        For i = 1 To 6
            If SelectedLabel Is LBL_Spot(i) Then
                CurrentSpot = i
            End If
        Next

    End Sub

    Public Function AddStringToGroup(ByVal sT As String)

        If SelectedLabel.Text <> "" Then

            ' Check for twice !
            If InStr(SelectedLabel.Text, sT) > 0 Then
                MsgBox("You already have assigned that spot to that class/player", MsgBoxStyle.Exclamation)
                Exit Function
            End If

            SelectedLabel.Text = SelectedLabel.Text & " | " & sT
        Else
            SelectedLabel.Text = sT
        End If

        Groups(CurrentSpot - 1, CurrentGroup - 1) = SelectedLabel.Text
    End Function

    Private Function ClearSpot()
        SelectedLabel.Text = ""
        Groups(CurrentSpot - 1, CurrentGroup - 1) = SelectedLabel.Text
    End Function

    Private Function ClearGroup()
        Dim i As Byte

        For i = 1 To 6
            LBL_Spot(i).Text = ""
            Groups(i - 1, CurrentGroup - 1) = ""
        Next
    End Function

    Private Function RemoveLast()
        Dim i, iNB, iLast As Byte
        Dim sT As String

        sT = SelectedLabel.Text
        iNB = InStrRev(sT, "|")
        If iNB = 0 Then
            SelectedLabel.Text = ""
        Else
            sT = Mid(sT, 1, iNB - 1).Trim
            SelectedLabel.Text = sT
        End If

        Groups(CurrentSpot - 1, CurrentGroup - 1) = SelectedLabel.Text
    End Function

#Region "File Handling"

    Private Function ClearTemplate()
        Dim i, j As Byte

        For i = 0 To 5
            For j = 0 To 11
                Groups(i, j) = ""
            Next
        Next

        ClearGroup()

        For i = 0 To 11
            GroupNames(i) = "Group " & (i + 1)
        Next

    End Function

    Private Function NewTemplate()
        Dim response As MsgBoxResult
        Dim Message As String

        Message = "Your current template will be delete, are you sure you want to create a new template ?"
        response = MsgBox(Message, MsgBoxStyle.YesNo, "New Template")

        If response = MsgBoxResult.Yes Then
            ClearTemplate()
        End If

    End Function

    Private Function SaveTemplate()
        Dim i, j As Byte

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "Group Setup files (*.grs)|*.grs|All files (*.*)|*.*"
        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sW As StreamWriter = New StreamWriter(saveFileDialog1.FileName)
            sW.AutoFlush = True

            For j = 1 To 12
                sW.WriteLine("[Group " & j & "]")
                For i = 1 To 6
                    If Groups(i - 1, j - 1) <> "" Then
                        sW.WriteLine(Groups(i - 1, j - 1))
                    End If
                Next
                sW.WriteLine(" ")
            Next

            sW.Flush()
            sW.Close()

            SaveGroupNames(saveFileDialog1.FileName.Remove(saveFileDialog1.FileName.Length - 4, 4))
        End If
    End Function


    Private Function OpenTemplate()
        Dim OpenFileDialog1 As New OpenFileDialog()
        Dim StreamGroup, StreamSpot, temp As Byte
        Dim Line As String
        Dim It(12) As Byte

        OpenFileDialog1.Filter = "Group Setup files (*.grs)|*.grs|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.RestoreDirectory = True

        StreamGroup = 255
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim sR As StreamReader = New StreamReader(OpenFileDialog1.FileName)

            While (sR.Peek <> -1)
                Line = sR.ReadLine()

                temp = IsGroupTag(Line)

                If temp <> 255 Then
                    StreamGroup = temp
                Else
                    If StreamGroup > 0 And StreamGroup < 13 Then
                        If IsValid(Line) And It(StreamGroup) < 7 Then
                            Groups(It(StreamGroup), StreamGroup - 1) = Line
                            It(StreamGroup) = It(StreamGroup) + 1
                        End If
                    End If
                End If

            End While
            sR.Close()

            LoadGroupNames(OpenFileDialog1.FileName.Remove(OpenFileDialog1.FileName.Length - 4, 4))
        End If

    End Function

    Private Function IsValid(ByVal sT As String) As Boolean
        Dim iNB1, iNB2 As Integer

        iNB1 = InStr(sT, "[")
        iNB2 = InStr(sT, "]")

        If sT <> "" And iNB1 = 0 And iNB1 = 0 Then
            IsValid = True
        Else
            IsValid = False
        End If

    End Function

    Private Function IsGroupTag(ByVal st As String) As Byte
        Dim iNB1, iNB2 As Integer
        Dim sT2 As String

        On Error GoTo ErrorHandler
        iNB1 = InStr(st, "[")
        iNB2 = InStr(st, "]")

        If iNB1 > 0 And iNB2 > 0 Then
            sT2 = Mid(st, iNB1 + 1, iNB2 - iNB1 - 1)

            iNB1 = InStr(sT2, "Group")
            sT2 = Mid(sT2, iNB1 + 5)

            IsGroupTag = CByte(sT2.Trim)
            Exit Function
        End If

ErrorHandler:
        IsGroupTag = 255
    End Function

#End Region

#Region "Ugly stuff"
    ' Not Very clean, but got no idea how grouping controls work in VB.net ;)
    Private Function MNU_Class(ByVal i As Byte) As MenuItem
        Select Case i
            Case 1
                MNU_Class = MNU_Class1
            Case 2
                MNU_Class = MNU_Class2
            Case 3
                MNU_Class = MNU_Class3
            Case 4
                MNU_Class = MNU_Class4
            Case 5
                MNU_Class = MNU_Class5
            Case 6
                MNU_Class = MNU_Class6
            Case 7
                MNU_Class = MNU_Class7
            Case 8
                MNU_Class = MNU_Class8
            Case 9
                MNU_Class = MNU_Class9
            Case 10
                MNU_Class = MNU_Class10
            Case 11
                MNU_Class = MNU_Class11
            Case 12
                MNU_Class = MNU_Class12
            Case 13
                MNU_Class = MNU_Class13
            Case 14
                MNU_Class = MNU_Class14
            Case 15
                MNU_Class = MNU_Class15
            Case 16
                MNU_Class = MNU_Class16

            Case Else
                MNU_Class = MNU_Class1
        End Select
    End Function

    Private Function LBL_Spot(ByVal i As Byte) As Label
        Select Case i
            Case 1
                LBL_Spot = LBL_Spot1
            Case 2
                LBL_Spot = LBL_Spot2
            Case 3
                LBL_Spot = LBL_Spot3
            Case 4
                LBL_Spot = LBL_Spot4
            Case 5
                LBL_Spot = LBL_Spot5
            Case 6
                LBL_Spot = LBL_Spot6

            Case Else
                LBL_Spot = LBL_Spot1

        End Select
    End Function

    Private Function BTN_Group(ByVal i As Byte) As Button
        Select Case i
            Case 1
                BTN_Group = BTN_Group1
            Case 2
                BTN_Group = BTN_Group2
            Case 3
                BTN_Group = BTN_Group3
            Case 4
                BTN_Group = BTN_Group4
            Case 5
                BTN_Group = BTN_Group5
            Case 6
                BTN_Group = BTN_Group6
            Case 7
                BTN_Group = BTN_Group7
            Case 8
                BTN_Group = BTN_Group8
            Case 9
                BTN_Group = BTN_Group9
            Case 10
                BTN_Group = BTN_Group10
            Case 11
                BTN_Group = BTN_Group11
            Case 12
                BTN_Group = BTN_Group12

            Case Else
                BTN_Group = BTN_Group1
        End Select
    End Function
#End Region

#Region " Menu Controls"
    Private Sub AddMenu_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMenu.Popup
        Dim i As Byte

        For i = 1 To 16
            MNU_Class(i).Text = frm_Main.pClassesName(i)
        Next

    End Sub

    Private Sub MNU_AddName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_AddName.Click

    End Sub

    Private Sub MNU_AddOtherName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_AddOtherName.Click
        Dim Name As String

        Name = InputBox("Player Name :", "Add Player Name", , Me.Left + 50, Me.Top + 50)
        AddStringToGroup(Name)
    End Sub

    Private Sub MNU_Class_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_Class1.Click, MNU_Class2.Click, MNU_Class3.Click, MNU_Class4.Click, MNU_Class5.Click, MNU_Class6.Click, MNU_Class7.Click, MNU_Class8.Click, MNU_Class9.Click, MNU_Class10.Click, MNU_Class11.Click, MNU_Class12.Click, MNU_Class13.Click, MNU_Class14.Click, MNU_Class15.Click, MNU_Class16.Click
        Dim ClassName As String
        Dim SelectedMnuItem As MenuItem

        SelectedMnuItem = sender
        ClassName = SelectedMnuItem.Text
        AddStringToGroup(ClassName)
    End Sub

    Private Sub MNU_AddType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_AddType1.Click, MNU_AddType2.Click, MNU_AddType3.Click, MNU_AddType4.Click
        Dim TypeName As String
        Dim SelectedMnuItem As MenuItem

        SelectedMnuItem = sender
        TypeName = SelectedMnuItem.Text
        AddStringToGroup(TypeName)
    End Sub

    Private Sub MNU_AddAny_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_AddAny.Click
        AddStringToGroup("*")
    End Sub

    Private Sub MNU_ClearGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_ClearGroup.Click
        ClearGroup()
    End Sub

    Private Sub MNU_RemoveSpot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_RemoveSpot.Click
        ClearSpot()
    End Sub

    Private Sub MNU_RemoveLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_RemoveLast.Click
        RemoveLast()
    End Sub
#End Region

    Private Sub TLB_TopBar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TLB_TopBar.ButtonClick
        Select Case TLB_TopBar.Buttons.IndexOf(e.Button)
            Case 0
                'New Template
                NewTemplate()

            Case 2
                'Open Existing Template
                OpenTemplate()

            Case 3
                'Save Template
                SaveTemplate()

        End Select
    End Sub

    Private Sub MNU_AddKnown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNU_AddKnown.Click

        If Not frm_Main.bKnownPlayers Then
            MsgBox("You need to activate KnownPlayer Option to use this feature", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim Test As New FRM_Known()

        Test.bTemplateBuilder = True
        Test.FRM_Main = frm_Main
        Test.CreateTree()
        Test.ShowDialog(Me)
    End Sub

    Private Sub MNI_ChangeGroupName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNI_ChangeGroupName.Click
        Dim Temp As Button
        Dim Name As String
        Dim i As Byte

        Temp = ChangeGroupNameMenu.SourceControl

        Name = InputBox("Group Name :", "Group Name", , Me.Left + 50, Me.Top + 50)

        If Name <> "" Then
            Temp.Text = Name

            For i = 1 To 12
                If BTN_Group(i) Is Temp Then
                    GroupNames(i - 1) = Name
                End If
            Next
        End If

    End Sub

    Private Function LoadGroupNames(ByVal FileName As String)
        Dim Iterator As Integer

        For Iterator = 0 To 11
            GroupNames(Iterator) = "Group " & (Iterator + 1)
        Next

        FileName = FileName & ".grn"
        If File.Exists(FileName) Then
            Dim sr As StreamReader
            Dim sT As String

            sr = File.OpenText(FileName)

            Iterator = 0
            While (sr.Peek <> -1)
                sT = sr.ReadLine()
                GroupNames(Iterator) = sT
                Iterator = Iterator + 1
            End While

            sr.Close()
        End If

        For Iterator = 1 To 12
            BTN_Group(Iterator).Text = GroupNames(Iterator - 1)
        Next

    End Function

    Private Function SaveGroupNames(ByVal FileName As String)
        Dim Iterator As Integer

        FileName = FileName & ".grn"

        Dim sW As StreamWriter = New StreamWriter(FileName)
        sW.AutoFlush = True

        For Iterator = 0 To 11
            sW.WriteLine(GroupNames(Iterator))
        Next

        sW.Flush()
        sW.Close()

    End Function

End Class
