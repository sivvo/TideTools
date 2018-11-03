Option Compare Text
Imports System.IO
Imports System.Drawing
Imports System.Collections

Public Class FRM_Main
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
    Friend WithEvents TLB_Topbar As System.Windows.Forms.ToolBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TBB_OpenDump As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Parse As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Modify As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Settings As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Export As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBB_Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LST_Numbers As System.Windows.Forms.ListBox
    Friend WithEvents LBL_Group1 As System.Windows.Forms.Label
    Friend WithEvents LST_Group1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox4 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox6 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox8 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox10 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox12 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox14 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox16 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox18 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox20 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox22 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group2 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group3 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group4 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group5 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group6 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group7 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group8 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group9 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group10 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group11 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group12 As System.Windows.Forms.ListBox
    Friend WithEvents LST_Group255 As System.Windows.Forms.ListBox
    Friend WithEvents AddRemovePlayer As System.Windows.Forms.ContextMenu
    Friend WithEvents MNI_AddPlayer As System.Windows.Forms.MenuItem
    Friend WithEvents MNI_RemovePlayer As System.Windows.Forms.MenuItem
    Friend WithEvents MNI_Known As System.Windows.Forms.MenuItem
    Friend WithEvents MNI_AddOther As System.Windows.Forms.MenuItem
    Friend WithEvents LBL_Group2 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group3 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group4 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group5 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group6 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group7 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group8 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group9 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group10 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group11 As System.Windows.Forms.Label
    Friend WithEvents LBL_Group12 As System.Windows.Forms.Label
    Friend WithEvents TXT_RaidName As System.Windows.Forms.TextBox
    Friend WithEvents LBL_RaidName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FRM_Main))
        Me.TLB_Topbar = New System.Windows.Forms.ToolBar
        Me.TBB_OpenDump = New System.Windows.Forms.ToolBarButton
        Me.TBB_Parse = New System.Windows.Forms.ToolBarButton
        Me.TBB_Sep1 = New System.Windows.Forms.ToolBarButton
        Me.TBB_Export = New System.Windows.Forms.ToolBarButton
        Me.TBB_Sep2 = New System.Windows.Forms.ToolBarButton
        Me.TBB_Modify = New System.Windows.Forms.ToolBarButton
        Me.TBB_Sep3 = New System.Windows.Forms.ToolBarButton
        Me.TBB_Settings = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.LST_Numbers = New System.Windows.Forms.ListBox
        Me.LST_Group255 = New System.Windows.Forms.ListBox
        Me.AddRemovePlayer = New System.Windows.Forms.ContextMenu
        Me.MNI_AddPlayer = New System.Windows.Forms.MenuItem
        Me.MNI_Known = New System.Windows.Forms.MenuItem
        Me.MNI_AddOther = New System.Windows.Forms.MenuItem
        Me.MNI_RemovePlayer = New System.Windows.Forms.MenuItem
        Me.LST_Group1 = New System.Windows.Forms.ListBox
        Me.LBL_Group1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LBL_Group2 = New System.Windows.Forms.Label
        Me.LST_Group2 = New System.Windows.Forms.ListBox
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.LBL_Group3 = New System.Windows.Forms.Label
        Me.LST_Group3 = New System.Windows.Forms.ListBox
        Me.ListBox4 = New System.Windows.Forms.ListBox
        Me.LBL_Group4 = New System.Windows.Forms.Label
        Me.LST_Group4 = New System.Windows.Forms.ListBox
        Me.ListBox6 = New System.Windows.Forms.ListBox
        Me.LBL_Group5 = New System.Windows.Forms.Label
        Me.LST_Group5 = New System.Windows.Forms.ListBox
        Me.ListBox8 = New System.Windows.Forms.ListBox
        Me.LBL_Group6 = New System.Windows.Forms.Label
        Me.LST_Group6 = New System.Windows.Forms.ListBox
        Me.ListBox10 = New System.Windows.Forms.ListBox
        Me.LBL_Group7 = New System.Windows.Forms.Label
        Me.LST_Group7 = New System.Windows.Forms.ListBox
        Me.ListBox12 = New System.Windows.Forms.ListBox
        Me.LBL_Group8 = New System.Windows.Forms.Label
        Me.LST_Group8 = New System.Windows.Forms.ListBox
        Me.ListBox14 = New System.Windows.Forms.ListBox
        Me.LBL_Group9 = New System.Windows.Forms.Label
        Me.LST_Group9 = New System.Windows.Forms.ListBox
        Me.ListBox16 = New System.Windows.Forms.ListBox
        Me.LBL_Group10 = New System.Windows.Forms.Label
        Me.LST_Group10 = New System.Windows.Forms.ListBox
        Me.ListBox18 = New System.Windows.Forms.ListBox
        Me.LBL_Group11 = New System.Windows.Forms.Label
        Me.LST_Group11 = New System.Windows.Forms.ListBox
        Me.ListBox20 = New System.Windows.Forms.ListBox
        Me.LBL_Group12 = New System.Windows.Forms.Label
        Me.LST_Group12 = New System.Windows.Forms.ListBox
        Me.ListBox22 = New System.Windows.Forms.ListBox
        Me.TXT_RaidName = New System.Windows.Forms.TextBox
        Me.LBL_RaidName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TLB_Topbar
        '
        Me.TLB_Topbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.TLB_Topbar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBB_OpenDump, Me.TBB_Parse, Me.TBB_Sep1, Me.TBB_Export, Me.TBB_Sep2, Me.TBB_Modify, Me.TBB_Sep3, Me.TBB_Settings})
        Me.TLB_Topbar.DropDownArrows = True
        Me.TLB_Topbar.ImageList = Me.ImageList1
        Me.TLB_Topbar.Location = New System.Drawing.Point(0, 0)
        Me.TLB_Topbar.Name = "TLB_Topbar"
        Me.TLB_Topbar.ShowToolTips = True
        Me.TLB_Topbar.Size = New System.Drawing.Size(530, 28)
        Me.TLB_Topbar.TabIndex = 0
        '
        'TBB_OpenDump
        '
        Me.TBB_OpenDump.ImageIndex = 0
        Me.TBB_OpenDump.ToolTipText = "Open a new dump file"
        '
        'TBB_Parse
        '
        Me.TBB_Parse.ImageIndex = 1
        Me.TBB_Parse.ToolTipText = "Parse groups"
        '
        'TBB_Sep1
        '
        Me.TBB_Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBB_Export
        '
        Me.TBB_Export.ImageIndex = 4
        Me.TBB_Export.ToolTipText = "Export Groups To EQIM File"
        '
        'TBB_Sep2
        '
        Me.TBB_Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBB_Modify
        '
        Me.TBB_Modify.ImageIndex = 2
        Me.TBB_Modify.ToolTipText = "Group templates Editor"
        '
        'TBB_Sep3
        '
        Me.TBB_Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'TBB_Settings
        '
        Me.TBB_Settings.ImageIndex = 3
        Me.TBB_Settings.ToolTipText = "Options"
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'LST_Numbers
        '
        Me.LST_Numbers.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LST_Numbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Numbers.Enabled = False
        Me.LST_Numbers.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Numbers.ItemHeight = 14
        Me.LST_Numbers.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.LST_Numbers.Location = New System.Drawing.Point(0, 48)
        Me.LST_Numbers.Name = "LST_Numbers"
        Me.LST_Numbers.Size = New System.Drawing.Size(17, 86)
        Me.LST_Numbers.TabIndex = 1
        '
        'LST_Group255
        '
        Me.LST_Group255.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group255.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group255.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group255.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group255.ItemHeight = 14
        Me.LST_Group255.Location = New System.Drawing.Point(384, 48)
        Me.LST_Group255.Name = "LST_Group255"
        Me.LST_Group255.Size = New System.Drawing.Size(144, 422)
        Me.LST_Group255.Sorted = True
        Me.LST_Group255.TabIndex = 2
        '
        'AddRemovePlayer
        '
        Me.AddRemovePlayer.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNI_AddPlayer, Me.MNI_RemovePlayer})
        '
        'MNI_AddPlayer
        '
        Me.MNI_AddPlayer.Index = 0
        Me.MNI_AddPlayer.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MNI_Known, Me.MNI_AddOther})
        Me.MNI_AddPlayer.Text = "Add Player"
        '
        'MNI_Known
        '
        Me.MNI_Known.Index = 0
        Me.MNI_Known.Text = "Known Player"
        '
        'MNI_AddOther
        '
        Me.MNI_AddOther.Index = 1
        Me.MNI_AddOther.Text = "Other"
        '
        'MNI_RemovePlayer
        '
        Me.MNI_RemovePlayer.Index = 1
        Me.MNI_RemovePlayer.Text = "Remove Player"
        '
        'LST_Group1
        '
        Me.LST_Group1.AllowDrop = True
        Me.LST_Group1.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group1.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group1.ItemHeight = 14
        Me.LST_Group1.Location = New System.Drawing.Point(16, 48)
        Me.LST_Group1.Name = "LST_Group1"
        Me.LST_Group1.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group1.TabIndex = 3
        '
        'LBL_Group1
        '
        Me.LBL_Group1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group1.Enabled = False
        Me.LBL_Group1.Location = New System.Drawing.Point(0, 32)
        Me.LBL_Group1.Name = "LBL_Group1"
        Me.LBL_Group1.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group1.TabIndex = 4
        Me.LBL_Group1.Text = "Group 1"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(384, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ungrouped"
        '
        'LBL_Group2
        '
        Me.LBL_Group2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group2.Enabled = False
        Me.LBL_Group2.Location = New System.Drawing.Point(128, 32)
        Me.LBL_Group2.Name = "LBL_Group2"
        Me.LBL_Group2.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group2.TabIndex = 8
        Me.LBL_Group2.Text = "Group 2"
        '
        'LST_Group2
        '
        Me.LST_Group2.AllowDrop = True
        Me.LST_Group2.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group2.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group2.ItemHeight = 14
        Me.LST_Group2.Location = New System.Drawing.Point(144, 48)
        Me.LST_Group2.Name = "LST_Group2"
        Me.LST_Group2.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group2.TabIndex = 7
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Enabled = False
        Me.ListBox2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.ItemHeight = 14
        Me.ListBox2.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox2.Location = New System.Drawing.Point(128, 48)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(17, 86)
        Me.ListBox2.TabIndex = 6
        '
        'LBL_Group3
        '
        Me.LBL_Group3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group3.Enabled = False
        Me.LBL_Group3.Location = New System.Drawing.Point(256, 32)
        Me.LBL_Group3.Name = "LBL_Group3"
        Me.LBL_Group3.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group3.TabIndex = 11
        Me.LBL_Group3.Text = "Group 3"
        '
        'LST_Group3
        '
        Me.LST_Group3.AllowDrop = True
        Me.LST_Group3.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group3.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group3.ItemHeight = 14
        Me.LST_Group3.Location = New System.Drawing.Point(272, 48)
        Me.LST_Group3.Name = "LST_Group3"
        Me.LST_Group3.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group3.TabIndex = 10
        '
        'ListBox4
        '
        Me.ListBox4.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox4.Enabled = False
        Me.ListBox4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox4.ItemHeight = 14
        Me.ListBox4.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox4.Location = New System.Drawing.Point(256, 48)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(17, 86)
        Me.ListBox4.TabIndex = 9
        '
        'LBL_Group4
        '
        Me.LBL_Group4.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group4.Enabled = False
        Me.LBL_Group4.Location = New System.Drawing.Point(0, 144)
        Me.LBL_Group4.Name = "LBL_Group4"
        Me.LBL_Group4.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group4.TabIndex = 14
        Me.LBL_Group4.Text = "Group 4"
        '
        'LST_Group4
        '
        Me.LST_Group4.AllowDrop = True
        Me.LST_Group4.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group4.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group4.ItemHeight = 14
        Me.LST_Group4.Location = New System.Drawing.Point(16, 160)
        Me.LST_Group4.Name = "LST_Group4"
        Me.LST_Group4.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group4.TabIndex = 13
        '
        'ListBox6
        '
        Me.ListBox6.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox6.Enabled = False
        Me.ListBox6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox6.ItemHeight = 14
        Me.ListBox6.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox6.Location = New System.Drawing.Point(0, 160)
        Me.ListBox6.Name = "ListBox6"
        Me.ListBox6.Size = New System.Drawing.Size(17, 86)
        Me.ListBox6.TabIndex = 12
        '
        'LBL_Group5
        '
        Me.LBL_Group5.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group5.Enabled = False
        Me.LBL_Group5.Location = New System.Drawing.Point(128, 144)
        Me.LBL_Group5.Name = "LBL_Group5"
        Me.LBL_Group5.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group5.TabIndex = 17
        Me.LBL_Group5.Text = "Group 5"
        '
        'LST_Group5
        '
        Me.LST_Group5.AllowDrop = True
        Me.LST_Group5.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group5.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group5.ItemHeight = 14
        Me.LST_Group5.Location = New System.Drawing.Point(144, 160)
        Me.LST_Group5.Name = "LST_Group5"
        Me.LST_Group5.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group5.TabIndex = 16
        '
        'ListBox8
        '
        Me.ListBox8.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox8.Enabled = False
        Me.ListBox8.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox8.ItemHeight = 14
        Me.ListBox8.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox8.Location = New System.Drawing.Point(128, 160)
        Me.ListBox8.Name = "ListBox8"
        Me.ListBox8.Size = New System.Drawing.Size(17, 86)
        Me.ListBox8.TabIndex = 15
        '
        'LBL_Group6
        '
        Me.LBL_Group6.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group6.Enabled = False
        Me.LBL_Group6.Location = New System.Drawing.Point(256, 144)
        Me.LBL_Group6.Name = "LBL_Group6"
        Me.LBL_Group6.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group6.TabIndex = 20
        Me.LBL_Group6.Text = "Group 6"
        '
        'LST_Group6
        '
        Me.LST_Group6.AllowDrop = True
        Me.LST_Group6.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group6.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group6.ItemHeight = 14
        Me.LST_Group6.Location = New System.Drawing.Point(272, 160)
        Me.LST_Group6.Name = "LST_Group6"
        Me.LST_Group6.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group6.TabIndex = 19
        '
        'ListBox10
        '
        Me.ListBox10.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox10.Enabled = False
        Me.ListBox10.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox10.ItemHeight = 14
        Me.ListBox10.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox10.Location = New System.Drawing.Point(256, 160)
        Me.ListBox10.Name = "ListBox10"
        Me.ListBox10.Size = New System.Drawing.Size(17, 86)
        Me.ListBox10.TabIndex = 18
        '
        'LBL_Group7
        '
        Me.LBL_Group7.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group7.Enabled = False
        Me.LBL_Group7.Location = New System.Drawing.Point(0, 256)
        Me.LBL_Group7.Name = "LBL_Group7"
        Me.LBL_Group7.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group7.TabIndex = 23
        Me.LBL_Group7.Text = "Group 7"
        '
        'LST_Group7
        '
        Me.LST_Group7.AllowDrop = True
        Me.LST_Group7.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group7.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group7.ItemHeight = 14
        Me.LST_Group7.Location = New System.Drawing.Point(16, 272)
        Me.LST_Group7.Name = "LST_Group7"
        Me.LST_Group7.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group7.TabIndex = 22
        '
        'ListBox12
        '
        Me.ListBox12.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox12.Enabled = False
        Me.ListBox12.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox12.ItemHeight = 14
        Me.ListBox12.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox12.Location = New System.Drawing.Point(0, 272)
        Me.ListBox12.Name = "ListBox12"
        Me.ListBox12.Size = New System.Drawing.Size(17, 86)
        Me.ListBox12.TabIndex = 21
        '
        'LBL_Group8
        '
        Me.LBL_Group8.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group8.Enabled = False
        Me.LBL_Group8.Location = New System.Drawing.Point(128, 256)
        Me.LBL_Group8.Name = "LBL_Group8"
        Me.LBL_Group8.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group8.TabIndex = 26
        Me.LBL_Group8.Text = "Group 8"
        '
        'LST_Group8
        '
        Me.LST_Group8.AllowDrop = True
        Me.LST_Group8.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group8.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group8.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group8.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group8.ItemHeight = 14
        Me.LST_Group8.Location = New System.Drawing.Point(144, 272)
        Me.LST_Group8.Name = "LST_Group8"
        Me.LST_Group8.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group8.TabIndex = 25
        '
        'ListBox14
        '
        Me.ListBox14.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox14.Enabled = False
        Me.ListBox14.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox14.ItemHeight = 14
        Me.ListBox14.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox14.Location = New System.Drawing.Point(128, 272)
        Me.ListBox14.Name = "ListBox14"
        Me.ListBox14.Size = New System.Drawing.Size(17, 86)
        Me.ListBox14.TabIndex = 24
        '
        'LBL_Group9
        '
        Me.LBL_Group9.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group9.Enabled = False
        Me.LBL_Group9.Location = New System.Drawing.Point(256, 256)
        Me.LBL_Group9.Name = "LBL_Group9"
        Me.LBL_Group9.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group9.TabIndex = 29
        Me.LBL_Group9.Text = "Group 9"
        '
        'LST_Group9
        '
        Me.LST_Group9.AllowDrop = True
        Me.LST_Group9.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group9.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group9.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group9.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group9.ItemHeight = 14
        Me.LST_Group9.Location = New System.Drawing.Point(272, 272)
        Me.LST_Group9.Name = "LST_Group9"
        Me.LST_Group9.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group9.TabIndex = 28
        '
        'ListBox16
        '
        Me.ListBox16.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox16.Enabled = False
        Me.ListBox16.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox16.ItemHeight = 14
        Me.ListBox16.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox16.Location = New System.Drawing.Point(256, 272)
        Me.ListBox16.Name = "ListBox16"
        Me.ListBox16.Size = New System.Drawing.Size(17, 86)
        Me.ListBox16.TabIndex = 27
        '
        'LBL_Group10
        '
        Me.LBL_Group10.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group10.Enabled = False
        Me.LBL_Group10.Location = New System.Drawing.Point(0, 368)
        Me.LBL_Group10.Name = "LBL_Group10"
        Me.LBL_Group10.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group10.TabIndex = 32
        Me.LBL_Group10.Text = "Group 10"
        '
        'LST_Group10
        '
        Me.LST_Group10.AllowDrop = True
        Me.LST_Group10.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group10.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group10.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group10.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group10.ItemHeight = 14
        Me.LST_Group10.Location = New System.Drawing.Point(16, 384)
        Me.LST_Group10.Name = "LST_Group10"
        Me.LST_Group10.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group10.TabIndex = 31
        '
        'ListBox18
        '
        Me.ListBox18.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox18.Enabled = False
        Me.ListBox18.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox18.ItemHeight = 14
        Me.ListBox18.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox18.Location = New System.Drawing.Point(0, 384)
        Me.ListBox18.Name = "ListBox18"
        Me.ListBox18.Size = New System.Drawing.Size(17, 86)
        Me.ListBox18.TabIndex = 30
        '
        'LBL_Group11
        '
        Me.LBL_Group11.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group11.Enabled = False
        Me.LBL_Group11.Location = New System.Drawing.Point(128, 368)
        Me.LBL_Group11.Name = "LBL_Group11"
        Me.LBL_Group11.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group11.TabIndex = 35
        Me.LBL_Group11.Text = "Group 11"
        '
        'LST_Group11
        '
        Me.LST_Group11.AllowDrop = True
        Me.LST_Group11.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group11.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group11.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group11.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group11.ItemHeight = 14
        Me.LST_Group11.Location = New System.Drawing.Point(144, 384)
        Me.LST_Group11.Name = "LST_Group11"
        Me.LST_Group11.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group11.TabIndex = 34
        '
        'ListBox20
        '
        Me.ListBox20.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox20.Enabled = False
        Me.ListBox20.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox20.ItemHeight = 14
        Me.ListBox20.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox20.Location = New System.Drawing.Point(128, 384)
        Me.ListBox20.Name = "ListBox20"
        Me.ListBox20.Size = New System.Drawing.Size(17, 86)
        Me.ListBox20.TabIndex = 33
        '
        'LBL_Group12
        '
        Me.LBL_Group12.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.LBL_Group12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_Group12.Enabled = False
        Me.LBL_Group12.Location = New System.Drawing.Point(256, 368)
        Me.LBL_Group12.Name = "LBL_Group12"
        Me.LBL_Group12.Size = New System.Drawing.Size(120, 17)
        Me.LBL_Group12.TabIndex = 38
        Me.LBL_Group12.Text = "Group 12"
        '
        'LST_Group12
        '
        Me.LST_Group12.AllowDrop = True
        Me.LST_Group12.BackColor = System.Drawing.SystemColors.Window
        Me.LST_Group12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LST_Group12.ContextMenu = Me.AddRemovePlayer
        Me.LST_Group12.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.LST_Group12.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LST_Group12.ItemHeight = 14
        Me.LST_Group12.Location = New System.Drawing.Point(272, 384)
        Me.LST_Group12.Name = "LST_Group12"
        Me.LST_Group12.Size = New System.Drawing.Size(104, 86)
        Me.LST_Group12.TabIndex = 37
        '
        'ListBox22
        '
        Me.ListBox22.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ListBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox22.Enabled = False
        Me.ListBox22.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox22.ItemHeight = 14
        Me.ListBox22.Items.AddRange(New Object() {"1.", "2.", "3.", "4.", "5.", "6."})
        Me.ListBox22.Location = New System.Drawing.Point(256, 384)
        Me.ListBox22.Name = "ListBox22"
        Me.ListBox22.Size = New System.Drawing.Size(17, 86)
        Me.ListBox22.TabIndex = 36
        '
        'TXT_RaidName
        '
        Me.TXT_RaidName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_RaidName.Location = New System.Drawing.Point(256, 8)
        Me.TXT_RaidName.Name = "TXT_RaidName"
        Me.TXT_RaidName.Size = New System.Drawing.Size(272, 20)
        Me.TXT_RaidName.TabIndex = 39
        Me.TXT_RaidName.Text = ""
        '
        'LBL_RaidName
        '
        Me.LBL_RaidName.Location = New System.Drawing.Point(184, 8)
        Me.LBL_RaidName.Name = "LBL_RaidName"
        Me.LBL_RaidName.Size = New System.Drawing.Size(72, 23)
        Me.LBL_RaidName.TabIndex = 40
        Me.LBL_RaidName.Text = "Raid Name :"
        '
        'FRM_Main
        '
        Me.AllowDrop = True
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(530, 479)
        Me.Controls.Add(Me.LBL_RaidName)
        Me.Controls.Add(Me.TXT_RaidName)
        Me.Controls.Add(Me.LBL_Group12)
        Me.Controls.Add(Me.LST_Group12)
        Me.Controls.Add(Me.ListBox22)
        Me.Controls.Add(Me.LBL_Group11)
        Me.Controls.Add(Me.LST_Group11)
        Me.Controls.Add(Me.ListBox20)
        Me.Controls.Add(Me.LBL_Group10)
        Me.Controls.Add(Me.LST_Group10)
        Me.Controls.Add(Me.ListBox18)
        Me.Controls.Add(Me.LBL_Group9)
        Me.Controls.Add(Me.LST_Group9)
        Me.Controls.Add(Me.ListBox16)
        Me.Controls.Add(Me.LBL_Group8)
        Me.Controls.Add(Me.LST_Group8)
        Me.Controls.Add(Me.ListBox14)
        Me.Controls.Add(Me.LBL_Group7)
        Me.Controls.Add(Me.LST_Group7)
        Me.Controls.Add(Me.ListBox12)
        Me.Controls.Add(Me.LBL_Group6)
        Me.Controls.Add(Me.LST_Group6)
        Me.Controls.Add(Me.ListBox10)
        Me.Controls.Add(Me.LBL_Group5)
        Me.Controls.Add(Me.LST_Group5)
        Me.Controls.Add(Me.ListBox8)
        Me.Controls.Add(Me.LBL_Group4)
        Me.Controls.Add(Me.LST_Group4)
        Me.Controls.Add(Me.ListBox6)
        Me.Controls.Add(Me.LBL_Group3)
        Me.Controls.Add(Me.LST_Group3)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.LBL_Group2)
        Me.Controls.Add(Me.LST_Group2)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LBL_Group1)
        Me.Controls.Add(Me.LST_Group1)
        Me.Controls.Add(Me.LST_Group255)
        Me.Controls.Add(Me.LST_Numbers)
        Me.Controls.Add(Me.TLB_Topbar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FRM_Main"
        Me.Text = "GroupParser v2.02"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public pClassesName() As String = {"unknown", "bard", "beastlord", "berserker", "cleric", "druid", "enchanter", "magician", "monk", "necromancer", "paladin", "ranger", "rogue", "shaman", "shadow knight", "warrior", "wizard"}
    Public pClassesShortName() As String = {"ukn", "brd", "bst", "ber", "clr", "dru", "enc", "mag", "mnk", "nec", "pal", "rng", "rog", "shm", "shd", "war", "wiz"}
    Public pClassesColors(17) As Color

    Public AppName As String = "GroupParser"
    Public SecName As String = "General"
    Public SecColorName As String = "Colors"
    Public EQIMFile As String

    Structure GroupSetup
        Public Line As String
        Public Processed As Boolean
    End Structure

    Public PlayerTab As New PlayerCollection
    Public GroupSetupTab(6, 12) As GroupSetup
    Public KnownPlayers As New KnownPlayerCollection
    Public GroupNames(12) As String

    'Options
    Public ParseType As Byte = 1
    Public ChannelType As Byte = 6
    Public ButtonType As Byte = 6
    Public ExtendedName As Boolean = True
    Public LogPath, GroupPath, IniPath As String
    Public bKnownPlayersOption As Boolean = True
    Public bKnownPlayers As Boolean = True
    Public bUseSetupAsName As Boolean = True

    Private DragIndex As Integer
    Private IndiceDragged As Byte
    Private dragBoxFromMouseDown As Rectangle
    Private screenOffset As Point

    Private ListBoxBrush As New System.Drawing.SolidBrush(Color.Black)

    Private Sub LST_Group_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles LST_Group1.DrawItem, LST_Group2.DrawItem, LST_Group3.DrawItem, LST_Group4.DrawItem, LST_Group5.DrawItem, LST_Group6.DrawItem, LST_Group7.DrawItem, LST_Group8.DrawItem, LST_Group9.DrawItem, LST_Group10.DrawItem, LST_Group11.DrawItem, LST_Group12.DrawItem, LST_Group255.DrawItem

        Dim pListbox As ListBox
        Dim Index, playerIndex As Integer

        pListbox = sender
        Index = GetIndiceLSTGroup(pListbox)

        pListbox.DrawMode = DrawMode.OwnerDrawFixed
        e.DrawBackground()

        If pListbox.Items.Count > 0 And e.Index >= 0 Then
            playerIndex = GetPlayerIndiceByName(pListbox.Items(e.Index))
            ListBoxBrush.Color = pClassesColors(PlayerTab(playerIndex).Type)

            e.Graphics.DrawString(pListbox.Items(e.Index), e.Font, ListBoxBrush, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
            e.DrawFocusRectangle()
        End If
    End Sub


    ' Not Very clean, but got no idea how grouping controls work in VB.net ;)
    Private Function LST_Group(ByVal i As Byte) As ListBox
        Select Case i
            Case 1
                LST_Group = LST_Group1
            Case 2
                LST_Group = LST_Group2
            Case 3
                LST_Group = LST_Group3
            Case 4
                LST_Group = LST_Group4
            Case 5
                LST_Group = LST_Group5
            Case 6
                LST_Group = LST_Group6
            Case 7
                LST_Group = LST_Group7
            Case 8
                LST_Group = LST_Group8
            Case 9
                LST_Group = LST_Group9
            Case 10
                LST_Group = LST_Group10
            Case 11
                LST_Group = LST_Group11
            Case 12
                LST_Group = LST_Group12

            Case Else
                LST_Group = LST_Group255

        End Select
    End Function


    Private Function LBL_Group(ByVal i As Byte) As Label
        Select Case i
            Case 1
                LBL_Group = LBL_Group1
            Case 2
                LBL_Group = LBL_Group2
            Case 3
                LBL_Group = LBL_Group3
            Case 4
                LBL_Group = LBL_Group4
            Case 5
                LBL_Group = LBL_Group5
            Case 6
                LBL_Group = LBL_Group6
            Case 7
                LBL_Group = LBL_Group7
            Case 8
                LBL_Group = LBL_Group8
            Case 9
                LBL_Group = LBL_Group9
            Case 10
                LBL_Group = LBL_Group10
            Case 11
                LBL_Group = LBL_Group11
            Case 12
                LBL_Group = LBL_Group12

            Case Else
                LBL_Group = LBL_Group1

        End Select
    End Function

    Private Function GetIndiceLSTGroup(ByVal Test As ListBox) As Byte
        Dim i As Byte

        For i = 1 To 12
            If LST_Group(i) Is Test Then
                GetIndiceLSTGroup = i
                Exit Function
            End If
        Next

        GetIndiceLSTGroup = 255

    End Function

    Public Function GetCLS(ByVal st As String)
        Dim i As Byte

        For i = 0 To pClassesName.Length
            If st = pClassesName(i) Then
                GetCLS = i
                Exit Function
            End If
        Next

        GetCLS = 0
    End Function

    Public Function GetpName(ByVal pPLayer As Player) As String
        If ExtendedName Then
            GetpName = pPLayer.Name & " <" & pClassesShortName(pPLayer.Type) & ">"
        Else
            GetpName = pPLayer.Name
        End If
    End Function


    Private Sub TLB_Topbar_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TLB_Topbar.ButtonClick

        Select Case TLB_Topbar.Buttons.IndexOf(e.Button)
            Case 0
                'Open Raid Dump File
                LoadDump()
            Case 1
                'Open Group Setup File
                LoadGroupSetup()

            Case 3
                'Export
                'ExportIni()
                ExportTXT()

            Case 5
                Dim frmTest As New FRM_TemplateBuilder
                frmTest.frm_Main = Me
                frmTest.ShowDialog(Me)

            Case 7
                Dim frmSettings As New FRM_Option
                frmSettings.FRM_Main = Me
                frmSettings.ShowDialog(Me)

        End Select
    End Sub

    Private Sub FRM_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LogPath = GetSetting(AppName, SecName, "LogPath")
        GroupPath = GetSetting(AppName, SecName, "GroupPath")
        IniPath = GetSetting(AppName, SecName, "IniPath")
        EQIMFile = GetSetting(AppName, SecName, "EQIMFile")

        ParseType = CByte(GetSetting(AppName, SecName, "ParseType", "1"))
        ChannelType = CByte(GetSetting(AppName, SecName, "ChannelType", "6"))
        ButtonType = CByte(GetSetting(AppName, SecName, "ButtonType", "9"))
        ExtendedName = CBool(GetSetting(AppName, SecName, "ExtendedName", "False"))
        bKnownPlayersOption = CBool(GetSetting(AppName, SecName, "bKnownPlayersOption", "False"))
        bUseSetupAsName = CBool(GetSetting(AppName, SecName, "bUseSetupAsName", "False"))

        Dim r, g, b As Byte
        Dim i As Integer
        For i = 0 To 16
            r = CByte(GetSetting(AppName, SecColorName, "R" & i))
            g = CByte(GetSetting(AppName, SecColorName, "G" & i))
            b = CByte(GetSetting(AppName, SecColorName, "B" & i))

            pClassesColors(i) = Color.FromArgb(255, r, g, b)

        Next i

        bKnownPlayers = bKnownPlayersOption

        LoadKnownPlayers()

        'Me.BackColor = Color.Plum

        'Dim i As Byte

        'For i = 0 To 12
        '   LST_Group(i).BackColor = Color.PaleGreen
        'Next
    End Sub


    Private Sub FRM_Main_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        SaveSetting(AppName, SecName, "LogPath", LogPath)
        SaveSetting(AppName, SecName, "GroupPath", GroupPath)
        SaveSetting(AppName, SecName, "IniPath", IniPath)
        SaveSetting(AppName, SecName, "EQIMFile", EQIMFile)

        SaveSetting(AppName, SecName, "ParseType", ParseType)
        SaveSetting(AppName, SecName, "ChannelType", ChannelType)
        SaveSetting(AppName, SecName, "ButtonType", ButtonType)
        SaveSetting(AppName, SecName, "ExtendedName", ExtendedName)
        SaveSetting(AppName, SecName, "bKnownPlayersOption", bKnownPlayersOption)
        SaveSetting(AppName, SecName, "bUseSetupAsName", bUseSetupAsName)

        Dim i As Integer
        For i = 0 To 16
            SaveSetting(AppName, SecColorName, "R" & i, pClassesColors(i).R)
            SaveSetting(AppName, SecColorName, "G" & i, pClassesColors(i).G)
            SaveSetting(AppName, SecColorName, "B" & i, pClassesColors(i).B)
        Next i

        DumpKnownPlayers()

    End Sub

    Private Function DumpKnownPlayers()
        If bKnownPlayers Then
            Dim sr As StreamWriter
            Dim sT As String
            Dim i As Integer
            Dim j As Byte

            Dim sW As New StreamWriter("KnownPlayers.Dat")

            For j = 0 To 16
                sW.WriteLine("[" & pClassesName(j) & "]")

                For i = 0 To KnownPlayers.Count - 1
                    If KnownPlayers(i).Type = j Then
                        sW.WriteLine(KnownPlayers(i).Name)
                    End If
                Next
            Next

            sW.Close()

        End If

    End Function

    Private Function LoadKnownPlayers()

        On Error GoTo ErrorHandler

        If bKnownPlayers Then
            Dim sr As StreamReader
            Dim sT As String
            Dim CurrClass As pClasses
            Dim Iterator As Integer

            CurrClass = pClasses.CLS_BARD

            If File.Exists("KnownPlayers.Dat") Then
                sr = File.OpenText("KnownPlayers.Dat")

                While (sr.Peek <> -1)
                    sT = sr.ReadLine()
                    If sT.Chars(0) = "[" Then
                        sT = sT.Remove(0, 1)
                        sT = sT.Remove(sT.Length - 1, 1)
                        CurrClass = GetCLS(sT)
                    Else
                        Dim KNP As New KnownPlayer

                        KNP.Name = sT
                        KNP.Type = CurrClass
                        KnownPlayers.Add(KNP)
                    End If
                End While

                sr.Close()
            End If
        End If
        Exit Function
ErrorHandler:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)
    End Function

    Private Function LoadDump()
        Dim sr As StreamReader
        Dim sT As String
        Dim openFileDialog1 As New OpenFileDialog
        Dim Iterator, i As Integer
        Dim bExists As Boolean

        On Error GoTo ErrorHandler

        openFileDialog1.InitialDirectory = LogPath
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1

        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then

            LogPath = openFileDialog1.FileName

            PlayerTab.Clear()

            ResetForm()
            sr = File.OpenText(openFileDialog1.FileName)

            While (sr.Peek <> -1)
                sT = sr.ReadLine()
                Dim P As New Player

                P = ParsePlayer(sT)
                LST_Group(P.Group).Items.Add(GetpName(P))
                PlayerTab.Add(P)

                'Adds Player to known list
                If bKnownPlayers Then
                    bExists = False
                    For Iterator = 0 To KnownPlayers.Count - 1
                        If KnownPlayers(Iterator).Name = P.Name Then
                            bExists = True
                        End If
                    Next

                    If Not bExists Then
                        Dim KNP As New KnownPlayer

                        KNP.Name = P.Name
                        KNP.Type = P.Type
                        KnownPlayers.Add(KNP)
                    End If
                End If

            End While

            sr.Close()

            For i = 0 To 11
                GroupNames(i) = "Group " & (i + 1)
            Next
        End If

        Exit Function
ErrorHandler:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation)

    End Function

    Private Function LoadGroupSetup()
        Dim StreamGroup, StreamSpot, temp As Byte
        Dim Line As String
        Dim It(12) As Byte
        Dim openFileDialog1 As New OpenFileDialog

        If PlayerTab.Count < 1 Then
            MsgBox(" No players, please load a raid Dump file")
            Exit Function
        End If

        openFileDialog1.InitialDirectory = GroupPath
        openFileDialog1.Filter = "Group Setup files (*.grs)|*.grs|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        StreamGroup = 255
        If openFileDialog1.ShowDialog() = DialogResult.OK Then

            GroupPath = openFileDialog1.FileName
            ResetGroupSetup()

            Dim sR As StreamReader = New StreamReader(openFileDialog1.FileName)

            While (sR.Peek <> -1)
                Line = sR.ReadLine()

                temp = IsGroupTag(Line)

                If temp <> 255 Then
                    StreamGroup = temp
                Else
                    If StreamGroup > 0 And StreamGroup < 13 Then
                        If IsValid(Line) And It(StreamGroup) < 7 Then
                            GroupSetupTab(It(StreamGroup), StreamGroup - 1).Line = Line
                            GroupSetupTab(It(StreamGroup), StreamGroup - 1).Processed = False
                            It(StreamGroup) = It(StreamGroup) + 1
                        End If
                    End If
                End If

            End While
            sR.Close()

            LoadGroupNames(openFileDialog1.FileName.Remove(openFileDialog1.FileName.Length - 4, 4))
        End If

        ParseGroups()
    End Function

    Private Function LoadGroupNames(ByVal FileName As String)
        Dim Iterator As Integer

        If bUseSetupAsName Then
            TXT_RaidName.Text = Mid(FileName, InStrRev(FileName, "\") + 1)
        End If

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
            LBL_Group(Iterator).Text = GroupNames(Iterator - 1)
        Next

    End Function

    Private Function ResetGroupSetup()
        Dim i, j As Byte

        For i = 0 To 5
            For j = 0 To 11
                GroupSetupTab(i, j).Line = ""
                GroupSetupTab(i, j).Processed = False
            Next
        Next

        For i = 0 To PlayerTab.Count - 1

            PlayerTab(i).Placed = False

            If PlayerTab.Item(i).Group = 0 Then
                PlayerTab.Item(i).Group = 255
            End If

        Next

        ResetForm()

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

    Private Function ResetForm()
        Dim i As Byte

        For i = 1 To 13
            LST_Group(i).Items.Clear()
        Next

    End Function

    Public Function ExtendedStateChanged()
        Dim i As Byte

        For i = 1 To 13
            LST_Group(i).Items.Clear()
        Next

        If PlayerTab.Count > 0 Then
            For i = 0 To PlayerTab.Count - 1
                LST_Group(PlayerTab(i).Group).Items.Add(GetpName(PlayerTab(i)))
            Next
        End If
    End Function



    Private Function ParsePlayer(ByVal sT As String) As Player
        Dim TempPlayer As New Player
        Dim iNB, iStart As Integer
        Dim sTemp As String

        'Group
        iStart = 1
        iNB = InStr(iStart, sT, Chr(9), CompareMethod.Text)
        If iNB = 0 Then
            TempPlayer.Group = 255
        Else
            sTemp = Mid(sT, iStart, iNB - 1)
            TempPlayer.Group = CByte(sTemp)
        End If

        'Name
        iStart = iNB + 1
        iNB = InStr(iStart, sT, Chr(9), CompareMethod.Text)
        If iNB = 0 Then
            TempPlayer.Name = "ERROR"
        Else
            sTemp = Mid(sT, iStart, iNB - iStart)
            TempPlayer.Name = sTemp
        End If


        'Level
        iStart = iNB + 1
        iNB = InStr(iStart, sT, Chr(9), CompareMethod.Text)
        If iNB = 0 Then
            TempPlayer.Level = 255
        Else
            sTemp = Mid(sT, iStart, iNB - iStart)
            TempPlayer.Level = CByte(sTemp)
        End If

        'Class
        iStart = iNB + 1
        iNB = InStr(iStart, sT, Chr(9), CompareMethod.Text)
        If iNB = 0 Then
            TempPlayer.Type = 0
        Else
            sTemp = Mid(sT, iStart, iNB - iStart)
            TempPlayer.Type = GetCLS(sTemp)
        End If

        'Rest

        ParsePlayer = TempPlayer
    End Function

#Region "Export"
    Private Function ExportTXT()

        If PlayerTab.Count < 1 Then
            MsgBox(" No players, please load a raid Dump file")
            Exit Function
        End If

        If Not File.Exists(EQIMFile) Then

            MsgBox(" No EQIM file specified, do now NOW FFS !")

            Dim SaveFileDialog1 As New SaveFileDialog
            SaveFileDialog1.InitialDirectory = IniPath
            SaveFileDialog1.Filter = "EQIM export file (*.exp)|*.exp|All files (*.*)|*.*"
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.RestoreDirectory = True

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                EQIMFile = SaveFileDialog1.FileName()
                SaveSetting(AppName, SecName, "EQIMFile", EQIMFile)
            Else
                Exit Function
            End If
        End If

        Dim sW As New StreamWriter(EQIMFile)
        Dim i, j As Byte
        Dim sT As String

        If TXT_RaidName.Text <> "" Then
            sT = ";1 -<##### " & TXT_RaidName.Text & " #####>-"
        Else
            sT = ";1 -<##### TIDE RAID #####>-"
        End If

        sW.WriteLine(sT)

        For j = 1 To 12
            sT = ";1 "
            If LST_Group(j).Items.Count > 0 Then
                sT = sT & GroupNames(j - 1) & ":"
                For i = 0 To (LST_Group(j).Items.Count - 1)
                    sT = sT & "[ " & LST_Group(j).Items(i) & " ]"
                Next
                sW.WriteLine(sT)
            End If
        Next

        sW.Close()

    End Function

    Private Function ExportIni()

        If PlayerTab.Count < 1 Then
            MsgBox(" No players, please load a raid Dump file")
            Exit Function
        End If

        Dim openFileDialog1 As New OpenFileDialog
        Dim i, iNB As Byte
        Dim bGoodFile As Boolean

        openFileDialog1.InitialDirectory = IniPath
        openFileDialog1.Filter = "EverQuest ini file (*.ini)|*.ini|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        bGoodFile = False

        Dim txt As New ListBox
        Dim len, j As Int32

        If openFileDialog1.ShowDialog() = DialogResult.OK Then

            IniPath = openFileDialog1.FileName()

            Dim sr As StreamReader
            Dim sT As String
            Dim SocialLine As Int32
            Dim bSocial, bAlreadyWritten As Boolean

            sr = File.OpenText(openFileDialog1.FileName())

            'Check Groups
            len = 0
            While sr.Peek <> -1
                sT = sr.ReadLine()
                txt.Items.Add(sT)

                If InStr(sT, "[Socials]") Then
                    SocialLine = len
                    bGoodFile = True
                End If

                len = len + 1
            End While

            sr.Close()

            If Not bGoodFile Then
                MessageBox.Show("This isn't a Button config file", "Wrong ini", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                'Llaenx_venril.ini

                '[Socials]
                'Page3Button10Name = Cyrilette
                'Page3Button10Color = 14
                'Page3Button10Line1=/assist Cyrilette

                Dim FileDest, FileSrc, FilePath As String

                FileSrc = openFileDialog1.FileName()
                FileDest = FileSrc & "2"

                Dim sW As New StreamWriter(FileDest)
                sr = File.OpenText(FileSrc)

                bSocial = False
                ' gets to the end of the options, and removes the page10 stuff
                While (sr.Peek <> -1)
                    sT = sr.ReadLine()

                    ' FFS stupid "and" code, ugly piece of code!
                    Dim bTest As Boolean = False

                    If sT = "" Then
                        bTest = True
                    Else
                        If sT.Chars(0) = "[" Then
                            bTest = True
                        End If
                    End If


                    ' Social not at the end of the thing => i write now !
                    If bSocial And bTest And Not bAlreadyWritten Then
                        For j = 1 To 12
                            If LST_Group(j).Items.Count > 0 Then
                                sT = GetButtonNumber(ButtonType) & j & "Name=" & GroupNames(j - 1)
                                sW.WriteLine(sT)
                                sT = GetButtonNumber(ButtonType) & j & "Color=14"
                                sW.WriteLine(sT)
                                sT = GetButtonNumber(ButtonType) & j & "Line1=" & GetChannelType(ChannelType) & " " & GroupNames(j - 1) & " : "

                                For i = 0 To (LST_Group(j).Items.Count - 1)
                                    sT = sT & "[ " & LST_Group(j).Items(i) & " ]"
                                Next
                                sW.WriteLine(sT)
                            End If
                        Next
                        sW.WriteLine("")
                        bAlreadyWritten = True
                    End If

                    iNB = InStr(sT, GetButtonNumber(ButtonType))

                    If iNB < 1 Then
                        sW.WriteLine(sT)
                    End If

                    If InStr(sT, "[Socials]") Then
                        bSocial = True
                    End If

                End While

                ' writes my page10 stuff
                If Not bAlreadyWritten Then
                    For j = 1 To 12
                        If LST_Group(j).Items.Count > 0 Then
                            sT = GetButtonNumber(ButtonType) & j & "Name=" & GroupNames(j - 1)
                            sW.WriteLine(sT)
                            sT = GetButtonNumber(ButtonType) & j & "Color=14"
                            sW.WriteLine(sT)
                            sT = GetButtonNumber(ButtonType) & j & "Line1=" & GetChannelType(ChannelType) & " " & GroupNames(j - 1) & " : "

                            For i = 0 To (LST_Group(j).Items.Count - 1)
                                sT = sT & "[ " & LST_Group(j).Items(i) & " ]"
                            Next
                            sW.WriteLine(sT)
                        End If
                    Next
                End If

                sr.Close()
                sW.Close()

                If File.Exists(FileSrc & ".old") Then
                    File.Delete(FileSrc & ".old")
                End If

                File.Move(FileSrc, FileSrc & ".old")
                File.Move(FileDest, FileSrc)
            End If
        End If
    End Function


    Private Function GetChannelType(ByVal i As Byte) As String
        Dim st As String

        Select Case i
            Case 0
                st = "/ooc"
            Case 1
                st = "/shout"
            Case 2
                st = "/Say"
            Case 3
                st = "/Gu"
            Case 4
                st = "/G"
            Case 5
                st = "/1"
            Case 6
                st = "/2"
            Case 7
                st = "/3"
            Case 8
                st = "/4"
            Case 9
                st = "/5"
            Case 10
                st = "/6"
            Case 11
                st = "/7"
            Case 12
                st = "/8"
            Case 13
                st = "/9"
            Case 14
                st = "/10"
        End Select

        GetChannelType = st
    End Function

    Private Function GetButtonNumber(ByVal i As Byte) As String
        Dim st As String

        Select Case i
            Case 0
                st = "Page1Button"
            Case 1
                st = "Page2Button"
            Case 2
                st = "Page3Button"
            Case 3
                st = "Page4Button"
            Case 4
                st = "Page5Button"
            Case 5
                st = "Page6Button"
            Case 6
                st = "Page7Button"
            Case 7
                st = "Page8Button"
            Case 8
                st = "Page9Button"
            Case 9
                st = "Page10Button"
        End Select

        GetButtonNumber = st
    End Function
#End Region

#Region "Parse Stuff"

    ' Parsing Group lines
    Private Function ParseGroups()

        Select Case ParseType
            Case 1
                ParseFirstFill()

            Case 2
                ParseOldStyle()

            Case 3
                ParseColumn()
        End Select


    End Function

    ' Parse the lines one after another and fills the first spot
    Private Function ParseFirstFill()
        Dim i, j, iNB As Byte
        Dim LineParse, sT As String
        Dim bFound As Boolean

        For j = 1 To 12
            For i = 1 To 6
                LineParse = GroupSetupTab(i - 1, j - 1).Line

                bFound = False
                While LineParse <> "" And Not bFound
                    iNB = InStr(LineParse, "|")
                    If iNB > 0 Then
                        sT = Mid(LineParse, 1, iNB - 1).Trim
                        LineParse = Mid(LineParse, iNB + 1).Trim
                    Else
                        sT = LineParse
                        LineParse = ""
                    End If

                    iNB = FindMatchingPlayer(sT)
                    If iNB <> 255 Then
                        PlayerTab(iNB).Placed = True
                        PlayerTab(iNB).Group = j

                        LST_Group(j).Items.Add(GetpName(PlayerTab(iNB)))

                        bFound = True
                    End If

                End While

                GroupSetupTab(i - 1, j - 1).Processed = True
            Next
        Next

        ' Places unwanted players in ungrouped
        For i = 0 To PlayerTab.Count - 1
            If PlayerTab(i).Placed = False Then

                PlayerTab(i).Placed = True
                PlayerTab(i).Group = 255
                LST_Group255.Items.Add(GetpName(PlayerTab(i)))
            End If
        Next

    End Function


    Private Function FindMatchingPlayer(ByVal sT As String) As Byte
        Dim i, j As Byte

        For i = 0 To PlayerTab.Count - 1
            If PlayerTab(i).Placed = False Then

                ' Check Name
                If PlayerTab(i).Name = sT Then
                    FindMatchingPlayer = i
                    Exit Function
                End If

                'Check Class
                If pClassesName(PlayerTab(i).Type) = sT Then
                    FindMatchingPlayer = i
                    Exit Function
                End If

                'Check Special Class
                Select Case sT
                    Case "DPS"
                        If CheckIsDPS(PlayerTab(i).Type) Then
                            FindMatchingPlayer = i
                            Exit Function
                        End If

                    Case "HEALER"
                        If CheckIsHEALER(PlayerTab(i).Type) Then
                            FindMatchingPlayer = i
                            Exit Function
                        End If

                    Case "TANK"
                        If CheckIsTANK(PlayerTab(i).Type) Then
                            FindMatchingPlayer = i
                            Exit Function
                        End If

                    Case "CONTROL"
                        If CheckIsCC(PlayerTab(i).Type) Then
                            FindMatchingPlayer = i
                            Exit Function
                        End If
                End Select
            End If
        Next

        FindMatchingPlayer = 255
    End Function

    ' Ugly way of parsing
    Private Function ParseOldStyle()
        Dim i, j, ii, iNB As Byte
        Dim LineParse, sT As String
        Dim bFound As Boolean

        'Checks Players in first slot
        For j = 1 To 12
            For i = 1 To 6

                LineParse = GroupSetupTab(i - 1, j - 1).Line

                bFound = False
                While LineParse <> "" And Not bFound
                    iNB = InStr(LineParse, "|")

                    If iNB > 0 Then
                        sT = Mid(LineParse, 1, iNB - 1).Trim
                        LineParse = Mid(LineParse, iNB + 1).Trim
                    Else
                        sT = LineParse
                        LineParse = ""
                    End If

                    If isPlayerName(sT) Then
                        iNB = FindMatchingPlayer(sT)
                        If iNB <> 255 Then
                            PlayerTab(iNB).Placed = True
                            PlayerTab(iNB).Group = j

                            LST_Group(j).Items.Add(GetpName(PlayerTab(iNB)))
                            GroupSetupTab(i - 1, j - 1).Processed = True
                            bFound = True
                        End If
                    End If

                End While
            Next
        Next

        'Checks Classes
        For j = 1 To 12
            For i = 1 To 6
                If Not GroupSetupTab(i - 1, j - 1).Processed Then
                    LineParse = GroupSetupTab(i - 1, j - 1).Line

                    bFound = False
                    While LineParse <> "" And Not bFound
                        iNB = InStr(LineParse, "|")

                        If iNB > 0 Then
                            sT = Mid(LineParse, 1, iNB - 1).Trim
                            LineParse = Mid(LineParse, iNB + 1).Trim
                        Else
                            sT = LineParse
                            LineParse = ""
                        End If

                        iNB = isClassName(sT)
                        If iNB <> 255 Then
                            For ii = 0 To PlayerTab.Count - 1
                                If PlayerTab(ii).Placed = False And PlayerTab(ii).Type = iNB Then
                                    PlayerTab(ii).Placed = True
                                    PlayerTab(ii).Group = j

                                    LST_Group(j).Items.Add(GetpName(PlayerTab(ii)))
                                    GroupSetupTab(i - 1, j - 1).Processed = True
                                    bFound = True
                                    Exit For
                                End If
                            Next
                        End If
                    End While
                End If
            Next
        Next

        ' Check Special Type
        For j = 1 To 12
            For i = 1 To 6
                If Not GroupSetupTab(i - 1, j - 1).Processed Then
                    LineParse = GroupSetupTab(i - 1, j - 1).Line

                    bFound = False
                    While LineParse <> "" And Not bFound
                        iNB = InStr(LineParse, "|")

                        If iNB > 0 Then
                            sT = Mid(LineParse, 1, iNB - 1).Trim
                            LineParse = Mid(LineParse, iNB + 1).Trim
                        Else
                            sT = LineParse
                            LineParse = ""
                        End If

                        If sT = "DPS" Or sT = "HEALER" Or sT = "TANK" Then
                            For ii = 0 To PlayerTab.Count - 1
                                If PlayerTab(ii).Placed = False Then

                                    If (sT = "DPS" And CheckIsDPS(PlayerTab(ii).Type)) Or _
                                        (sT = "HEALER" And CheckIsHEALER(PlayerTab(ii).Type)) Or _
                                        (sT = "CONTROL" And CheckIsCC(PlayerTab(ii).Type)) Or _
                                        (sT = "TANK" And CheckIsTANK(PlayerTab(ii).Type)) Then
                                        PlayerTab(ii).Placed = True
                                        PlayerTab(ii).Group = j

                                        LST_Group(j).Items.Add(GetpName(PlayerTab(ii)))
                                        GroupSetupTab(i - 1, j - 1).Processed = True
                                        bFound = True
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    End While
                End If
            Next
        Next

        ' Checks for "*"
        For j = 1 To 12
            For i = 1 To 6
                If Not GroupSetupTab(i - 1, j - 1).Processed Then
                    LineParse = GroupSetupTab(i - 1, j - 1).Line

                    bFound = False
                    While LineParse <> "" And Not bFound
                        iNB = InStr(LineParse, "|")

                        If iNB > 0 Then
                            sT = Mid(LineParse, 1, iNB - 1).Trim
                            LineParse = Mid(LineParse, iNB + 1).Trim
                        Else
                            sT = LineParse
                            LineParse = ""
                        End If

                        If sT = "*" Then
                            For ii = 0 To PlayerTab.Count - 1
                                If PlayerTab(ii).Placed = False Then

                                    PlayerTab(ii).Placed = True
                                    PlayerTab(ii).Group = j

                                    LST_Group(j).Items.Add(GetpName(PlayerTab(ii)))
                                    GroupSetupTab(i - 1, j - 1).Processed = True
                                    bFound = True

                                    Exit For
                                End If
                            Next
                        End If

                    End While
                End If
            Next
        Next


        ' Places unwanted players in ungrouped
        For i = 0 To PlayerTab.Count - 1
            If PlayerTab(i).Placed = False Then

                PlayerTab(i).Placed = True
                PlayerTab(i).Group = 255
                LST_Group255.Items.Add(GetpName(PlayerTab(i)))
            End If
        Next

    End Function


    Private Function ParseColumn()
        Dim i, j, ii, iNB As Byte
        Dim LineParse, sT As String
        Dim bTabNotEmpty, bFound As Boolean

        bTabNotEmpty = False

        While bTabNotEmpty = False
            For j = 1 To 12
                For i = 1 To 6

                    LineParse = GroupSetupTab(i - 1, j - 1).Line

                    If LineParse <> "" Then
                        bTabNotEmpty = True
                    End If

                    iNB = InStr(LineParse, "|")

                    If iNB > 0 Then
                        sT = Mid(LineParse, 1, iNB - 1).Trim
                        LineParse = Mid(LineParse, iNB + 1).Trim
                    Else
                        sT = LineParse
                        LineParse = ""
                    End If

                    bFound = False

                    If isPlayerName(sT) Then
                        iNB = FindMatchingPlayer(sT)
                        If iNB <> 255 Then
                            PlayerTab(iNB).Placed = True
                            PlayerTab(iNB).Group = j

                            LST_Group(j).Items.Add(GetpName(PlayerTab(iNB)))
                            GroupSetupTab(i - 1, j - 1).Processed = True
                            bFound = True
                        End If
                    Else
                        iNB = isClassName(sT)
                        If iNB <> 255 Then
                            For ii = 0 To PlayerTab.Count - 1
                                If PlayerTab(ii).Placed = False And PlayerTab(ii).Type = iNB Then
                                    PlayerTab(ii).Placed = True
                                    PlayerTab(ii).Group = j

                                    LST_Group(j).Items.Add(GetpName(PlayerTab(ii)))
                                    GroupSetupTab(i - 1, j - 1).Processed = True
                                    bFound = True
                                    Exit For
                                End If
                            Next
                        Else
                            If sT = "DPS" Or sT = "HEALER" Or sT = "TANK" Then
                                For ii = 0 To PlayerTab.Count - 1
                                    If PlayerTab(ii).Placed = False Then

                                        If (sT = "DPS" And CheckIsDPS(PlayerTab(ii).Type)) Or _
                                            (sT = "HEALER" And CheckIsHEALER(PlayerTab(ii).Type)) Or _
                                            (sT = "CONTROL" And CheckIsCC(PlayerTab(ii).Type)) Or _
                                            (sT = "TANK" And CheckIsTANK(PlayerTab(ii).Type)) Then
                                            PlayerTab(ii).Placed = True
                                            PlayerTab(ii).Group = j

                                            LST_Group(j).Items.Add(GetpName(PlayerTab(ii)))
                                            GroupSetupTab(i - 1, j - 1).Processed = True
                                            Exit For
                                        End If
                                    End If
                                Next
                            Else
                                If sT = "*" Then
                                    For ii = 0 To PlayerTab.Count - 1
                                        If PlayerTab(ii).Placed = False Then

                                            PlayerTab(ii).Placed = True
                                            PlayerTab(ii).Group = j

                                            LST_Group(j).Items.Add(GetpName(PlayerTab(ii)))
                                            GroupSetupTab(i - 1, j - 1).Processed = True
                                            bFound = True

                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If


                    If bFound Then
                        GroupSetupTab(i - 1, j - 1).Line = ""
                    Else
                        GroupSetupTab(i - 1, j - 1).Line = LineParse
                    End If
                Next
            Next

        End While


        ' Places unwanted players in ungrouped
        For i = 0 To PlayerTab.Count - 1
            If PlayerTab(i).Placed = False Then

                PlayerTab(i).Placed = True
                PlayerTab(i).Group = 255
                LST_Group255.Items.Add(GetpName(PlayerTab(i)))
            End If
        Next

    End Function

    Private Function isPlayerName(ByVal st As String) As Boolean
        Dim Check As Boolean
        Dim i As Byte

        Check = False

        For i = 0 To pClassesName.Length - 1
            If st = pClassesName(i) Then
                Check = True
                Exit For
            End If
        Next

        Select Case st

            Case "DPS"
                Check = True
            Case "HEALER"
                Check = True
            Case "TANK"
                Check = True
            Case "*"
                Check = True
        End Select

        isPlayerName = Not Check
    End Function

    Private Function isClassName(ByVal st As String) As Byte
        Dim Check As Byte
        Dim i As Byte

        Check = 255

        For i = 0 To pClassesName.Length - 1

            If st = pClassesName(i) Then
                Check = i
                Exit For
            End If
        Next

        isClassName = Check
    End Function

    Private Function CheckIsDPS(ByVal i As Byte) As Boolean
        If i = pClasses.CLS_WIZARD Or i = pClasses.CLS_RANGER Or i = pClasses.CLS_MONK _
        Or i = pClasses.CLS_ROGUE Or i = pClasses.CLS_MAGICIAN Then
            CheckIsDPS = True
        Else
            CheckIsDPS = False
        End If
    End Function

    Private Function CheckIsHEALER(ByVal i As Byte) As Boolean
        If i = pClasses.CLS_CLERIC Or i = pClasses.CLS_DRUID Or i = pClasses.CLS_SHAMAN Then
            CheckIsHEALER = True
        Else
            CheckIsHEALER = False
        End If
    End Function

    Private Function CheckIsTANK(ByVal i As Byte) As Boolean
        If i = pClasses.CLS_WARRIOR Or i = pClasses.CLS_PALADIN Or i = pClasses.CLS_SHADOWKNIGHT Then
            CheckIsTANK = True
        Else
            CheckIsTANK = False
        End If
    End Function

    Private Function CheckIsCC(ByVal i As Byte) As Boolean
        If i = pClasses.CLS_BARD Or i = pClasses.CLS_ENCHANTER Then
            CheckIsCC = True
        Else
            CheckIsCC = False
        End If
    End Function


#End Region

#Region "Drag drop stuff"

    Private Function GetPlayerIndiceByName(ByVal sT As String) As Byte
        Dim i As Byte
        Dim st2 As String

        If ExtendedName Then
            Dim iNB As Byte

            iNB = InStr(sT, "<")
            st2 = Mid(sT, 1, iNB - 1).Trim
        Else
            st2 = sT
        End If

        For i = 0 To PlayerTab.Count - 1
            If PlayerTab(i).Name = st2 Then
                GetPlayerIndiceByName = i
                Exit Function
            End If
        Next

        GetPlayerIndiceByName = 255
    End Function

    Private Sub LST_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LST_Group1.MouseDown, LST_Group2.MouseDown, LST_Group3.MouseDown, LST_Group4.MouseDown, LST_Group5.MouseDown, LST_Group6.MouseDown, LST_Group7.MouseDown, LST_Group8.MouseDown, LST_Group9.MouseDown, LST_Group10.MouseDown, LST_Group11.MouseDown, LST_Group12.MouseDown, LST_Group255.MouseDown
        Dim i As Byte
        Dim Test As ListBox

        Test = sender
        i = GetIndiceLSTGroup(Test)

        On Error GoTo Skip
        If LST_Group(i).Items.Count > 0 Then

            DragIndex = LST_Group(i).IndexFromPoint(e.X, e.Y)

            If DragIndex >= 0 Then
                IndiceDragged = GetPlayerIndiceByName(LST_Group(i).Items(DragIndex))

                If (DragIndex <> ListBox.NoMatches) Then
                    Dim dragSize As Size = SystemInformation.DragSize
                    dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
                Else
                    dragBoxFromMouseDown = Rectangle.Empty
                End If
            End If

        Else
            DragIndex = -1
        End If
        Exit Sub
Skip:
        DragIndex = -1
    End Sub

    Private Sub LST_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles LST_Group1.MouseMove, LST_Group2.MouseMove, LST_Group3.MouseMove, LST_Group4.MouseMove, LST_Group5.MouseMove, LST_Group6.MouseMove, LST_Group7.MouseMove, LST_Group8.MouseMove, LST_Group9.MouseMove, LST_Group10.MouseMove, LST_Group11.MouseMove, LST_Group12.MouseMove, LST_Group255.MouseMove
        Dim i As Byte
        Dim Test As ListBox

        Test = sender
        i = GetIndiceLSTGroup(Test)

        If DragIndex >= 0 Then

            If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
                If (Rectangle.op_Inequality(dragBoxFromMouseDown, Rectangle.Empty) And _
                    Not dragBoxFromMouseDown.Contains(e.X, e.Y)) Then

                    screenOffset = SystemInformation.WorkingArea.Location

                    Dim dropEffect As DragDropEffects = LST_Group(i).DoDragDrop(LST_Group(i).Items(DragIndex), _
                                                                                DragDropEffects.All Or DragDropEffects.Link)

                    LST_Group(i).Items.RemoveAt(DragIndex)

                    If (DragIndex > 0) Then
                        LST_Group(i).SelectedIndex = DragIndex - 1

                    ElseIf (LST_Group(i).Items.Count > 0) Then
                        LST_Group(i).SelectedIndex = 0
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub LST_QueryContinueDrag(ByVal sender As Object, ByVal e As QueryContinueDragEventArgs) Handles LST_Group1.QueryContinueDrag, LST_Group2.QueryContinueDrag, LST_Group3.QueryContinueDrag, LST_Group4.QueryContinueDrag, LST_Group5.QueryContinueDrag, LST_Group6.QueryContinueDrag, LST_Group7.QueryContinueDrag, LST_Group8.QueryContinueDrag, LST_Group9.QueryContinueDrag, LST_Group10.QueryContinueDrag, LST_Group11.QueryContinueDrag, LST_Group12.QueryContinueDrag, LST_Group255.QueryContinueDrag
        Dim lb As ListBox = CType(sender, System.Windows.Forms.ListBox)

        If Not (lb Is Nothing) Then

            Dim f As Form = lb.FindForm()
            If (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) Or _
                ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) Or _
                ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) Or _
                ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom)) Then

                LST_Group255.Items.Add(GetpName(PlayerTab(IndiceDragged)))
                PlayerTab(IndiceDragged).Group = 255

                e.Action = DragAction.Cancel
            End If
        End If
    End Sub


    Private Sub LST_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LST_Group1.DragEnter, LST_Group2.DragEnter, LST_Group3.DragEnter, LST_Group4.DragEnter, LST_Group5.DragEnter, LST_Group6.DragEnter, LST_Group7.DragEnter, LST_Group8.DragEnter, LST_Group9.DragEnter, LST_Group10.DragEnter, LST_Group11.DragEnter, LST_Group12.DragEnter, LST_Group255.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LST_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LST_Group1.DragDrop, LST_Group2.DragDrop, LST_Group3.DragDrop, LST_Group4.DragDrop, LST_Group5.DragDrop, LST_Group6.DragDrop, LST_Group7.DragDrop, LST_Group8.DragDrop, LST_Group9.DragDrop, LST_Group10.DragDrop, LST_Group11.DragDrop, LST_Group12.DragDrop, LST_Group255.DragDrop
        Dim i As Byte
        Dim Test As ListBox

        Test = sender
        i = GetIndiceLSTGroup(Test)
        LST_Group(i).Items.Add(GetpName(PlayerTab(IndiceDragged)))
        PlayerTab(IndiceDragged).Group = i
    End Sub


    Private Sub Form_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub Form_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        LST_Group255.Items.Add(GetpName(PlayerTab(IndiceDragged)))
        PlayerTab(IndiceDragged).Group = 255
    End Sub

#End Region


    Public Function RemovePlayer(ByVal Num As Byte)

        PlayerTab.RemoveAt(Num)
    End Function

    Public Function AddPlayer(ByVal pPlayer As Player, ByVal numgroup As Byte)

        If PlayerTab.Count > 99 Then
            MsgBox("Too many players in raid ( 100 )", MsgBoxStyle.Exclamation)
            Exit Function
        End If

        pPlayer.Group = numgroup

        PlayerTab.Add(pPlayer)
        LST_Group(numgroup).Items.Add(GetpName(pPlayer))
    End Function


    Private Sub MNI_AddOtherPlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNI_AddOther.Click
        Dim frmNew As New FRM_AddPlayer
        Dim i As Byte
        Dim Test As ListBox

        Test = AddRemovePlayer.SourceControl
        i = GetIndiceLSTGroup(Test)

        frmNew.NumGroup = i
        frmNew.FRM_Main = Me
        frmNew.ShowDialog(Me)
    End Sub

    Private Sub MNI_RemovePlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNI_RemovePlayer.Click

        Dim i, indice As Byte
        Dim Test As ListBox

        Test = AddRemovePlayer.SourceControl
        i = GetIndiceLSTGroup(Test)

        If LST_Group(i).Items.Count > 0 Then

            If LST_Group(i).SelectedIndex >= 0 Then

                indice = GetPlayerIndiceByName(LST_Group(i).SelectedItem)
                RemovePlayer(indice)
                LST_Group(i).Items.Remove(LST_Group(i).SelectedItem)
            Else
                MsgBox("You have to select a player to remove", MsgBoxStyle.Information)
            End If
        End If

    End Sub

    Private Sub MNI_Known_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNI_Known.Click

        If Not bKnownPlayers Then
            MsgBox("You need to activate KnownPlayer Option to use this feature", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim Test As New FRM_Known

        Dim i As Byte
        Dim LST As ListBox

        LST = AddRemovePlayer.SourceControl
        i = GetIndiceLSTGroup(LST)

        Test.NumGroup = i
        Test.bTemplateBuilder = False
        Test.FRM_Main = Me
        Test.CreateTree()
        Test.ShowDialog(Me)

    End Sub


End Class