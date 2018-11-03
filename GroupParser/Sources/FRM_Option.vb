Public Class FRM_Option
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
    Friend WithEvents CHK_KnownPlayer As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_Extended As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CHK_Linear As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_OldParser As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_Column As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CHK_0 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_1 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_2 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_3 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_4 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_5 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_6 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_7 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_8 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_9 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RDB_Page1 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page2 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page3 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page4 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page5 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page6 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page7 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page8 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page9 As System.Windows.Forms.RadioButton
    Friend WithEvents RDB_Page10 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_10 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_11 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_12 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioBTN_BEASTLORD As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_13 As System.Windows.Forms.RadioButton
    Friend WithEvents CHK_14 As System.Windows.Forms.RadioButton
    Friend WithEvents TXT_EQIM As System.Windows.Forms.TextBox
    Friend WithEvents BTN_EQIM As System.Windows.Forms.Button
    Friend GRP_Colors As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_UNKNOWN As System.Windows.Forms.Button
    Friend WithEvents BTN_BERSERKER As System.Windows.Forms.Button
    Friend WithEvents BTN_BARD As System.Windows.Forms.Button
    Friend WithEvents BTN_BEASTLORD As System.Windows.Forms.Button
    Friend WithEvents BTN_CLERIC As System.Windows.Forms.Button
    Friend WithEvents BTN_DRUID As System.Windows.Forms.Button
    Friend WithEvents BTN_ENCHANTER As System.Windows.Forms.Button
    Friend WithEvents BTN_MAGICIAN As System.Windows.Forms.Button
    Friend WithEvents BTN_MONK As System.Windows.Forms.Button
    Friend WithEvents BTN_NECROMANCER As System.Windows.Forms.Button
    Friend WithEvents BTN_PALADIN As System.Windows.Forms.Button
    Friend WithEvents BTN_RANGER As System.Windows.Forms.Button
    Friend WithEvents BTN_ROGUE As System.Windows.Forms.Button
    Friend WithEvents BTN_SHAMAN As System.Windows.Forms.Button
    Friend WithEvents BTN_SHADOWKNIGHT As System.Windows.Forms.Button
    Friend WithEvents BTN_WARRIOR As System.Windows.Forms.Button
    Friend WithEvents BTN_WIZARD As System.Windows.Forms.Button
    Friend WithEvents BTN_RESET As System.Windows.Forms.Button
    Friend WithEvents CHK_RaidName As System.Windows.Forms.CheckBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FRM_Option))
        Me.CHK_KnownPlayer = New System.Windows.Forms.CheckBox
        Me.CHK_Extended = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CHK_Column = New System.Windows.Forms.RadioButton
        Me.CHK_OldParser = New System.Windows.Forms.RadioButton
        Me.CHK_Linear = New System.Windows.Forms.RadioButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CHK_14 = New System.Windows.Forms.RadioButton
        Me.CHK_13 = New System.Windows.Forms.RadioButton
        Me.RadioBTN_BEASTLORD = New System.Windows.Forms.RadioButton
        Me.CHK_12 = New System.Windows.Forms.RadioButton
        Me.CHK_11 = New System.Windows.Forms.RadioButton
        Me.CHK_10 = New System.Windows.Forms.RadioButton
        Me.CHK_9 = New System.Windows.Forms.RadioButton
        Me.CHK_8 = New System.Windows.Forms.RadioButton
        Me.CHK_7 = New System.Windows.Forms.RadioButton
        Me.CHK_6 = New System.Windows.Forms.RadioButton
        Me.CHK_5 = New System.Windows.Forms.RadioButton
        Me.CHK_4 = New System.Windows.Forms.RadioButton
        Me.CHK_3 = New System.Windows.Forms.RadioButton
        Me.CHK_2 = New System.Windows.Forms.RadioButton
        Me.CHK_1 = New System.Windows.Forms.RadioButton
        Me.CHK_0 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RDB_Page10 = New System.Windows.Forms.RadioButton
        Me.RDB_Page9 = New System.Windows.Forms.RadioButton
        Me.RDB_Page8 = New System.Windows.Forms.RadioButton
        Me.RDB_Page7 = New System.Windows.Forms.RadioButton
        Me.RDB_Page6 = New System.Windows.Forms.RadioButton
        Me.RDB_Page5 = New System.Windows.Forms.RadioButton
        Me.RDB_Page4 = New System.Windows.Forms.RadioButton
        Me.RDB_Page3 = New System.Windows.Forms.RadioButton
        Me.RDB_Page2 = New System.Windows.Forms.RadioButton
        Me.RDB_Page1 = New System.Windows.Forms.RadioButton
        Me.TXT_EQIM = New System.Windows.Forms.TextBox
        Me.BTN_EQIM = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GRP_Colors = New System.Windows.Forms.GroupBox
        Me.BTN_BERSERKER = New System.Windows.Forms.Button
        Me.BTN_BARD = New System.Windows.Forms.Button
        Me.BTN_BEASTLORD = New System.Windows.Forms.Button
        Me.BTN_CLERIC = New System.Windows.Forms.Button
        Me.BTN_DRUID = New System.Windows.Forms.Button
        Me.BTN_ENCHANTER = New System.Windows.Forms.Button
        Me.BTN_MAGICIAN = New System.Windows.Forms.Button
        Me.BTN_MONK = New System.Windows.Forms.Button
        Me.BTN_NECROMANCER = New System.Windows.Forms.Button
        Me.BTN_PALADIN = New System.Windows.Forms.Button
        Me.BTN_RANGER = New System.Windows.Forms.Button
        Me.BTN_ROGUE = New System.Windows.Forms.Button
        Me.BTN_SHAMAN = New System.Windows.Forms.Button
        Me.BTN_SHADOWKNIGHT = New System.Windows.Forms.Button
        Me.BTN_WARRIOR = New System.Windows.Forms.Button
        Me.BTN_WIZARD = New System.Windows.Forms.Button
        Me.BTN_UNKNOWN = New System.Windows.Forms.Button
        Me.BTN_RESET = New System.Windows.Forms.Button
        Me.CHK_RaidName = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GRP_Colors.SuspendLayout()
        Me.SuspendLayout()
        '
        'CHK_KnownPlayer
        '
        Me.CHK_KnownPlayer.Location = New System.Drawing.Point(8, 24)
        Me.CHK_KnownPlayer.Name = "CHK_KnownPlayer"
        Me.CHK_KnownPlayer.Size = New System.Drawing.Size(200, 16)
        Me.CHK_KnownPlayer.TabIndex = 0
        Me.CHK_KnownPlayer.Text = "Use Known Player Parsing"
        '
        'CHK_Extended
        '
        Me.CHK_Extended.Location = New System.Drawing.Point(8, 8)
        Me.CHK_Extended.Name = "CHK_Extended"
        Me.CHK_Extended.Size = New System.Drawing.Size(192, 16)
        Me.CHK_Extended.TabIndex = 1
        Me.CHK_Extended.Text = "Show Player class in list"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CHK_Column)
        Me.GroupBox1.Controls.Add(Me.CHK_OldParser)
        Me.GroupBox1.Controls.Add(Me.CHK_Linear)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 68)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parsing Type"
        '
        'CHK_Column
        '
        Me.CHK_Column.Location = New System.Drawing.Point(8, 48)
        Me.CHK_Column.Name = "CHK_Column"
        Me.CHK_Column.Size = New System.Drawing.Size(184, 16)
        Me.CHK_Column.TabIndex = 5
        Me.CHK_Column.Text = "Column parsing"
        '
        'CHK_OldParser
        '
        Me.CHK_OldParser.Location = New System.Drawing.Point(8, 32)
        Me.CHK_OldParser.Name = "CHK_OldParser"
        Me.CHK_OldParser.Size = New System.Drawing.Size(184, 16)
        Me.CHK_OldParser.TabIndex = 4
        Me.CHK_OldParser.Text = "Old Parsing"
        '
        'CHK_Linear
        '
        Me.CHK_Linear.Location = New System.Drawing.Point(8, 16)
        Me.CHK_Linear.Name = "CHK_Linear"
        Me.CHK_Linear.Size = New System.Drawing.Size(184, 16)
        Me.CHK_Linear.TabIndex = 3
        Me.CHK_Linear.Text = "Line by Line parsing"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CHK_14)
        Me.GroupBox2.Controls.Add(Me.CHK_13)
        Me.GroupBox2.Controls.Add(Me.RadioBTN_BEASTLORD)
        Me.GroupBox2.Controls.Add(Me.CHK_12)
        Me.GroupBox2.Controls.Add(Me.CHK_11)
        Me.GroupBox2.Controls.Add(Me.CHK_10)
        Me.GroupBox2.Controls.Add(Me.CHK_9)
        Me.GroupBox2.Controls.Add(Me.CHK_8)
        Me.GroupBox2.Controls.Add(Me.CHK_7)
        Me.GroupBox2.Controls.Add(Me.CHK_6)
        Me.GroupBox2.Controls.Add(Me.CHK_5)
        Me.GroupBox2.Controls.Add(Me.CHK_4)
        Me.GroupBox2.Controls.Add(Me.CHK_3)
        Me.GroupBox2.Controls.Add(Me.CHK_2)
        Me.GroupBox2.Controls.Add(Me.CHK_1)
        Me.GroupBox2.Controls.Add(Me.CHK_0)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 312)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 184)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Export To :"
        Me.GroupBox2.Visible = False
        '
        'CHK_14
        '
        Me.CHK_14.Location = New System.Drawing.Point(104, 160)
        Me.CHK_14.Name = "CHK_14"
        Me.CHK_14.Size = New System.Drawing.Size(88, 16)
        Me.CHK_14.TabIndex = 15
        Me.CHK_14.Text = "Channel 10"
        '
        'CHK_13
        '
        Me.CHK_13.Location = New System.Drawing.Point(104, 144)
        Me.CHK_13.Name = "CHK_13"
        Me.CHK_13.Size = New System.Drawing.Size(88, 16)
        Me.CHK_13.TabIndex = 14
        Me.CHK_13.Text = "Channel 9"
        '
        'RadioBTN_BEASTLORD
        '
        Me.RadioBTN_BEASTLORD.Location = New System.Drawing.Point(104, 144)
        Me.RadioBTN_BEASTLORD.Name = "RadioBTN_BEASTLORD"
        Me.RadioBTN_BEASTLORD.Size = New System.Drawing.Size(88, 16)
        Me.RadioBTN_BEASTLORD.TabIndex = 13
        Me.RadioBTN_BEASTLORD.Text = "Channel 5"
        '
        'CHK_12
        '
        Me.CHK_12.Location = New System.Drawing.Point(104, 128)
        Me.CHK_12.Name = "CHK_12"
        Me.CHK_12.Size = New System.Drawing.Size(88, 16)
        Me.CHK_12.TabIndex = 12
        Me.CHK_12.Text = "Channel 8"
        '
        'CHK_11
        '
        Me.CHK_11.Location = New System.Drawing.Point(104, 112)
        Me.CHK_11.Name = "CHK_11"
        Me.CHK_11.Size = New System.Drawing.Size(88, 16)
        Me.CHK_11.TabIndex = 11
        Me.CHK_11.Text = "Channel 7"
        '
        'CHK_10
        '
        Me.CHK_10.Location = New System.Drawing.Point(104, 96)
        Me.CHK_10.Name = "CHK_10"
        Me.CHK_10.Size = New System.Drawing.Size(88, 16)
        Me.CHK_10.TabIndex = 10
        Me.CHK_10.Text = "Channel 6"
        '
        'CHK_9
        '
        Me.CHK_9.Location = New System.Drawing.Point(104, 80)
        Me.CHK_9.Name = "CHK_9"
        Me.CHK_9.Size = New System.Drawing.Size(88, 16)
        Me.CHK_9.TabIndex = 9
        Me.CHK_9.Text = "Channel 5"
        '
        'CHK_8
        '
        Me.CHK_8.Location = New System.Drawing.Point(104, 64)
        Me.CHK_8.Name = "CHK_8"
        Me.CHK_8.Size = New System.Drawing.Size(88, 16)
        Me.CHK_8.TabIndex = 8
        Me.CHK_8.Text = "Channel 4"
        '
        'CHK_7
        '
        Me.CHK_7.Location = New System.Drawing.Point(104, 48)
        Me.CHK_7.Name = "CHK_7"
        Me.CHK_7.Size = New System.Drawing.Size(88, 16)
        Me.CHK_7.TabIndex = 7
        Me.CHK_7.Text = "Channel 3"
        '
        'CHK_6
        '
        Me.CHK_6.Location = New System.Drawing.Point(104, 32)
        Me.CHK_6.Name = "CHK_6"
        Me.CHK_6.Size = New System.Drawing.Size(88, 16)
        Me.CHK_6.TabIndex = 6
        Me.CHK_6.Text = "Channel 2"
        '
        'CHK_5
        '
        Me.CHK_5.Location = New System.Drawing.Point(104, 16)
        Me.CHK_5.Name = "CHK_5"
        Me.CHK_5.Size = New System.Drawing.Size(88, 16)
        Me.CHK_5.TabIndex = 5
        Me.CHK_5.Text = "Channel 1"
        '
        'CHK_4
        '
        Me.CHK_4.Location = New System.Drawing.Point(8, 80)
        Me.CHK_4.Name = "CHK_4"
        Me.CHK_4.Size = New System.Drawing.Size(96, 16)
        Me.CHK_4.TabIndex = 4
        Me.CHK_4.Text = "Group"
        '
        'CHK_3
        '
        Me.CHK_3.Location = New System.Drawing.Point(8, 64)
        Me.CHK_3.Name = "CHK_3"
        Me.CHK_3.Size = New System.Drawing.Size(96, 16)
        Me.CHK_3.TabIndex = 3
        Me.CHK_3.Text = "Guild Channel"
        '
        'CHK_2
        '
        Me.CHK_2.Location = New System.Drawing.Point(8, 48)
        Me.CHK_2.Name = "CHK_2"
        Me.CHK_2.Size = New System.Drawing.Size(80, 16)
        Me.CHK_2.TabIndex = 2
        Me.CHK_2.Text = "Say"
        '
        'CHK_1
        '
        Me.CHK_1.Location = New System.Drawing.Point(8, 32)
        Me.CHK_1.Name = "CHK_1"
        Me.CHK_1.Size = New System.Drawing.Size(80, 16)
        Me.CHK_1.TabIndex = 1
        Me.CHK_1.Text = "Shout"
        '
        'CHK_0
        '
        Me.CHK_0.Location = New System.Drawing.Point(8, 16)
        Me.CHK_0.Name = "CHK_0"
        Me.CHK_0.Size = New System.Drawing.Size(80, 16)
        Me.CHK_0.TabIndex = 0
        Me.CHK_0.Text = "OOC"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RDB_Page10)
        Me.GroupBox3.Controls.Add(Me.RDB_Page9)
        Me.GroupBox3.Controls.Add(Me.RDB_Page8)
        Me.GroupBox3.Controls.Add(Me.RDB_Page7)
        Me.GroupBox3.Controls.Add(Me.RDB_Page6)
        Me.GroupBox3.Controls.Add(Me.RDB_Page5)
        Me.GroupBox3.Controls.Add(Me.RDB_Page4)
        Me.GroupBox3.Controls.Add(Me.RDB_Page3)
        Me.GroupBox3.Controls.Add(Me.RDB_Page2)
        Me.GroupBox3.Controls.Add(Me.RDB_Page1)
        Me.GroupBox3.Location = New System.Drawing.Point(232, 320)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 104)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Export Page"
        Me.GroupBox3.Visible = False
        '
        'RDB_Page10
        '
        Me.RDB_Page10.Location = New System.Drawing.Point(112, 80)
        Me.RDB_Page10.Name = "RDB_Page10"
        Me.RDB_Page10.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page10.TabIndex = 9
        Me.RDB_Page10.Text = "Page 10"
        '
        'RDB_Page9
        '
        Me.RDB_Page9.Location = New System.Drawing.Point(112, 64)
        Me.RDB_Page9.Name = "RDB_Page9"
        Me.RDB_Page9.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page9.TabIndex = 8
        Me.RDB_Page9.Text = "Page 9"
        '
        'RDB_Page8
        '
        Me.RDB_Page8.Location = New System.Drawing.Point(112, 48)
        Me.RDB_Page8.Name = "RDB_Page8"
        Me.RDB_Page8.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page8.TabIndex = 7
        Me.RDB_Page8.Text = "Page 8"
        '
        'RDB_Page7
        '
        Me.RDB_Page7.Location = New System.Drawing.Point(112, 32)
        Me.RDB_Page7.Name = "RDB_Page7"
        Me.RDB_Page7.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page7.TabIndex = 6
        Me.RDB_Page7.Text = "Page 7"
        '
        'RDB_Page6
        '
        Me.RDB_Page6.Location = New System.Drawing.Point(112, 16)
        Me.RDB_Page6.Name = "RDB_Page6"
        Me.RDB_Page6.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page6.TabIndex = 5
        Me.RDB_Page6.Text = "Page 6"
        '
        'RDB_Page5
        '
        Me.RDB_Page5.Location = New System.Drawing.Point(8, 80)
        Me.RDB_Page5.Name = "RDB_Page5"
        Me.RDB_Page5.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page5.TabIndex = 4
        Me.RDB_Page5.Text = "Page 5"
        '
        'RDB_Page4
        '
        Me.RDB_Page4.Location = New System.Drawing.Point(8, 64)
        Me.RDB_Page4.Name = "RDB_Page4"
        Me.RDB_Page4.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page4.TabIndex = 3
        Me.RDB_Page4.Text = "Page 4"
        '
        'RDB_Page3
        '
        Me.RDB_Page3.Location = New System.Drawing.Point(8, 48)
        Me.RDB_Page3.Name = "RDB_Page3"
        Me.RDB_Page3.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page3.TabIndex = 2
        Me.RDB_Page3.Text = "Page 3"
        '
        'RDB_Page2
        '
        Me.RDB_Page2.Location = New System.Drawing.Point(8, 32)
        Me.RDB_Page2.Name = "RDB_Page2"
        Me.RDB_Page2.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page2.TabIndex = 1
        Me.RDB_Page2.Text = "Page 2"
        '
        'RDB_Page1
        '
        Me.RDB_Page1.Location = New System.Drawing.Point(8, 16)
        Me.RDB_Page1.Name = "RDB_Page1"
        Me.RDB_Page1.Size = New System.Drawing.Size(64, 16)
        Me.RDB_Page1.TabIndex = 0
        Me.RDB_Page1.Text = "Page 1"
        '
        'TXT_EQIM
        '
        Me.TXT_EQIM.Enabled = False
        Me.TXT_EQIM.Location = New System.Drawing.Point(8, 16)
        Me.TXT_EQIM.Name = "TXT_EQIM"
        Me.TXT_EQIM.Size = New System.Drawing.Size(160, 20)
        Me.TXT_EQIM.TabIndex = 5
        Me.TXT_EQIM.Text = ""
        '
        'BTN_EQIM
        '
        Me.BTN_EQIM.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_EQIM.Location = New System.Drawing.Point(168, 16)
        Me.BTN_EQIM.Name = "BTN_EQIM"
        Me.BTN_EQIM.Size = New System.Drawing.Size(24, 20)
        Me.BTN_EQIM.TabIndex = 6
        Me.BTN_EQIM.Text = "..."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TXT_EQIM)
        Me.GroupBox4.Controls.Add(Me.BTN_EQIM)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 136)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(200, 48)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "EQIM Link"
        '
        'GRP_Colors
        '
        Me.GRP_Colors.Controls.Add(Me.BTN_BERSERKER)
        Me.GRP_Colors.Controls.Add(Me.BTN_BARD)
        Me.GRP_Colors.Controls.Add(Me.BTN_BEASTLORD)
        Me.GRP_Colors.Controls.Add(Me.BTN_CLERIC)
        Me.GRP_Colors.Controls.Add(Me.BTN_DRUID)
        Me.GRP_Colors.Controls.Add(Me.BTN_ENCHANTER)
        Me.GRP_Colors.Controls.Add(Me.BTN_MAGICIAN)
        Me.GRP_Colors.Controls.Add(Me.BTN_MONK)
        Me.GRP_Colors.Controls.Add(Me.BTN_NECROMANCER)
        Me.GRP_Colors.Controls.Add(Me.BTN_PALADIN)
        Me.GRP_Colors.Controls.Add(Me.BTN_RANGER)
        Me.GRP_Colors.Controls.Add(Me.BTN_ROGUE)
        Me.GRP_Colors.Controls.Add(Me.BTN_SHAMAN)
        Me.GRP_Colors.Controls.Add(Me.BTN_SHADOWKNIGHT)
        Me.GRP_Colors.Controls.Add(Me.BTN_WARRIOR)
        Me.GRP_Colors.Controls.Add(Me.BTN_WIZARD)
        Me.GRP_Colors.Controls.Add(Me.BTN_UNKNOWN)
        Me.GRP_Colors.Controls.Add(Me.BTN_RESET)
        Me.GRP_Colors.Location = New System.Drawing.Point(216, 8)
        Me.GRP_Colors.Name = "GRP_Colors"
        Me.GRP_Colors.Size = New System.Drawing.Size(232, 176)
        Me.GRP_Colors.TabIndex = 9
        Me.GRP_Colors.TabStop = False
        Me.GRP_Colors.Text = "Colors"
        '
        'BTN_BERSERKER
        '
        Me.BTN_BERSERKER.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_BERSERKER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_BERSERKER.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_BERSERKER.Location = New System.Drawing.Point(8, 16)
        Me.BTN_BERSERKER.Name = "BTN_BERSERKER"
        Me.BTN_BERSERKER.Size = New System.Drawing.Size(104, 16)
        Me.BTN_BERSERKER.TabIndex = 26
        Me.BTN_BERSERKER.Text = "Berserker"
        '
        'BTN_BARD
        '
        Me.BTN_BARD.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_BARD.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_BARD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_BARD.Location = New System.Drawing.Point(8, 32)
        Me.BTN_BARD.Name = "BTN_BARD"
        Me.BTN_BARD.Size = New System.Drawing.Size(104, 16)
        Me.BTN_BARD.TabIndex = 25
        Me.BTN_BARD.Text = "Bard"
        '
        'BTN_BEASTLORD
        '
        Me.BTN_BEASTLORD.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_BEASTLORD.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_BEASTLORD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_BEASTLORD.Location = New System.Drawing.Point(8, 48)
        Me.BTN_BEASTLORD.Name = "BTN_BEASTLORD"
        Me.BTN_BEASTLORD.Size = New System.Drawing.Size(104, 16)
        Me.BTN_BEASTLORD.TabIndex = 24
        Me.BTN_BEASTLORD.Text = "Beastlord"
        '
        'BTN_CLERIC
        '
        Me.BTN_CLERIC.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_CLERIC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_CLERIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CLERIC.Location = New System.Drawing.Point(8, 64)
        Me.BTN_CLERIC.Name = "BTN_CLERIC"
        Me.BTN_CLERIC.Size = New System.Drawing.Size(104, 16)
        Me.BTN_CLERIC.TabIndex = 23
        Me.BTN_CLERIC.Text = "Cleric"
        '
        'BTN_DRUID
        '
        Me.BTN_DRUID.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_DRUID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_DRUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DRUID.Location = New System.Drawing.Point(8, 80)
        Me.BTN_DRUID.Name = "BTN_DRUID"
        Me.BTN_DRUID.Size = New System.Drawing.Size(104, 16)
        Me.BTN_DRUID.TabIndex = 22
        Me.BTN_DRUID.Text = "Druid"
        '
        'BTN_ENCHANTER
        '
        Me.BTN_ENCHANTER.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_ENCHANTER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_ENCHANTER.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ENCHANTER.Location = New System.Drawing.Point(8, 96)
        Me.BTN_ENCHANTER.Name = "BTN_ENCHANTER"
        Me.BTN_ENCHANTER.Size = New System.Drawing.Size(104, 16)
        Me.BTN_ENCHANTER.TabIndex = 21
        Me.BTN_ENCHANTER.Text = "Enchanter"
        '
        'BTN_MAGICIAN
        '
        Me.BTN_MAGICIAN.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_MAGICIAN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_MAGICIAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MAGICIAN.Location = New System.Drawing.Point(8, 112)
        Me.BTN_MAGICIAN.Name = "BTN_MAGICIAN"
        Me.BTN_MAGICIAN.Size = New System.Drawing.Size(104, 16)
        Me.BTN_MAGICIAN.TabIndex = 20
        Me.BTN_MAGICIAN.Text = "Magician"
        '
        'BTN_MONK
        '
        Me.BTN_MONK.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_MONK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_MONK.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MONK.Location = New System.Drawing.Point(8, 128)
        Me.BTN_MONK.Name = "BTN_MONK"
        Me.BTN_MONK.Size = New System.Drawing.Size(104, 16)
        Me.BTN_MONK.TabIndex = 19
        Me.BTN_MONK.Text = "Monk"
        '
        'BTN_NECROMANCER
        '
        Me.BTN_NECROMANCER.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_NECROMANCER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_NECROMANCER.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_NECROMANCER.Location = New System.Drawing.Point(120, 16)
        Me.BTN_NECROMANCER.Name = "BTN_NECROMANCER"
        Me.BTN_NECROMANCER.Size = New System.Drawing.Size(104, 16)
        Me.BTN_NECROMANCER.TabIndex = 18
        Me.BTN_NECROMANCER.Text = "Necromancer"
        '
        'BTN_PALADIN
        '
        Me.BTN_PALADIN.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_PALADIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_PALADIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_PALADIN.Location = New System.Drawing.Point(120, 32)
        Me.BTN_PALADIN.Name = "BTN_PALADIN"
        Me.BTN_PALADIN.Size = New System.Drawing.Size(104, 16)
        Me.BTN_PALADIN.TabIndex = 17
        Me.BTN_PALADIN.Text = "Paladin"
        '
        'BTN_RANGER
        '
        Me.BTN_RANGER.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_RANGER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_RANGER.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_RANGER.Location = New System.Drawing.Point(120, 48)
        Me.BTN_RANGER.Name = "BTN_RANGER"
        Me.BTN_RANGER.Size = New System.Drawing.Size(104, 16)
        Me.BTN_RANGER.TabIndex = 16
        Me.BTN_RANGER.Text = "Ranger"
        '
        'BTN_ROGUE
        '
        Me.BTN_ROGUE.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_ROGUE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_ROGUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ROGUE.Location = New System.Drawing.Point(120, 64)
        Me.BTN_ROGUE.Name = "BTN_ROGUE"
        Me.BTN_ROGUE.Size = New System.Drawing.Size(104, 16)
        Me.BTN_ROGUE.TabIndex = 15
        Me.BTN_ROGUE.Text = "Rogue"
        '
        'BTN_SHAMAN
        '
        Me.BTN_SHAMAN.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_SHAMAN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_SHAMAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SHAMAN.Location = New System.Drawing.Point(120, 80)
        Me.BTN_SHAMAN.Name = "BTN_SHAMAN"
        Me.BTN_SHAMAN.Size = New System.Drawing.Size(104, 16)
        Me.BTN_SHAMAN.TabIndex = 14
        Me.BTN_SHAMAN.Text = "Shaman"
        '
        'BTN_SHADOWKNIGHT
        '
        Me.BTN_SHADOWKNIGHT.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_SHADOWKNIGHT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_SHADOWKNIGHT.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SHADOWKNIGHT.Location = New System.Drawing.Point(120, 96)
        Me.BTN_SHADOWKNIGHT.Name = "BTN_SHADOWKNIGHT"
        Me.BTN_SHADOWKNIGHT.Size = New System.Drawing.Size(104, 16)
        Me.BTN_SHADOWKNIGHT.TabIndex = 13
        Me.BTN_SHADOWKNIGHT.Text = "Shadowknight"
        '
        'BTN_WARRIOR
        '
        Me.BTN_WARRIOR.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_WARRIOR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_WARRIOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_WARRIOR.Location = New System.Drawing.Point(120, 112)
        Me.BTN_WARRIOR.Name = "BTN_WARRIOR"
        Me.BTN_WARRIOR.Size = New System.Drawing.Size(104, 16)
        Me.BTN_WARRIOR.TabIndex = 12
        Me.BTN_WARRIOR.Text = "Warrior"
        '
        'BTN_WIZARD
        '
        Me.BTN_WIZARD.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_WIZARD.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_WIZARD.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_WIZARD.Location = New System.Drawing.Point(120, 128)
        Me.BTN_WIZARD.Name = "BTN_WIZARD"
        Me.BTN_WIZARD.Size = New System.Drawing.Size(104, 16)
        Me.BTN_WIZARD.TabIndex = 12
        Me.BTN_WIZARD.Text = "Wizard"
        '
        'BTN_UNKNOWN
        '
        Me.BTN_UNKNOWN.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BTN_UNKNOWN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_UNKNOWN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_UNKNOWN.Location = New System.Drawing.Point(8, 152)
        Me.BTN_UNKNOWN.Name = "BTN_UNKNOWN"
        Me.BTN_UNKNOWN.Size = New System.Drawing.Size(104, 16)
        Me.BTN_UNKNOWN.TabIndex = 11
        Me.BTN_UNKNOWN.Text = "Unknown"
        '
        'BTN_RESET
        '
        Me.BTN_RESET.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_RESET.Location = New System.Drawing.Point(120, 152)
        Me.BTN_RESET.Name = "BTN_RESET"
        Me.BTN_RESET.Size = New System.Drawing.Size(104, 16)
        Me.BTN_RESET.TabIndex = 9
        Me.BTN_RESET.Text = "reset to black"
        '
        'CHK_RaidName
        '
        Me.CHK_RaidName.Location = New System.Drawing.Point(8, 40)
        Me.CHK_RaidName.Name = "CHK_RaidName"
        Me.CHK_RaidName.Size = New System.Drawing.Size(200, 16)
        Me.CHK_RaidName.TabIndex = 10
        Me.CHK_RaidName.Text = "Use group setup file as raid name"
        '
        'FRM_Option
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 194)
        Me.Controls.Add(Me.CHK_RaidName)
        Me.Controls.Add(Me.GRP_Colors)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CHK_Extended)
        Me.Controls.Add(Me.CHK_KnownPlayer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRM_Option"
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GRP_Colors.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public FRM_Main As FRM_Main
    Private bLoad As Boolean

    Private Function CHK_Channel(ByVal i As Byte) As RadioButton
        Select Case i
            Case 0
                CHK_Channel = CHK_0
            Case 1
                CHK_Channel = CHK_1
            Case 2
                CHK_Channel = CHK_2
            Case 3
                CHK_Channel = CHK_3
            Case 4
                CHK_Channel = CHK_4
            Case 5
                CHK_Channel = CHK_5
            Case 6
                CHK_Channel = CHK_6
            Case 7
                CHK_Channel = CHK_7
            Case 8
                CHK_Channel = CHK_8
            Case 9
                CHK_Channel = CHK_9
            Case 10
                CHK_Channel = CHK_10
            Case 11
                CHK_Channel = CHK_11
            Case 12
                CHK_Channel = CHK_12
            Case 13
                CHK_Channel = CHK_13
            Case 14
                CHK_Channel = CHK_14

            Case Else
                CHK_Channel = CHK_0
        End Select
    End Function



    Private Function RDB_Page(ByVal i As Byte) As RadioButton
        Select Case i
            Case 0
                RDB_Page = RDB_Page1
            Case 1
                RDB_Page = RDB_Page2
            Case 2
                RDB_Page = RDB_Page3
            Case 3
                RDB_Page = RDB_Page4
            Case 4
                RDB_Page = RDB_Page5
            Case 5
                RDB_Page = RDB_Page6
            Case 6
                RDB_Page = RDB_Page7
            Case 7
                RDB_Page = RDB_Page8
            Case 8
                RDB_Page = RDB_Page9
            Case 9
                RDB_Page = RDB_Page10
            Case Else
                RDB_Page = RDB_Page1
        End Select
    End Function

    Private Sub FRM_Option_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        bLoad = True

        CHK_Extended.Checked = FRM_Main.ExtendedName

        ToolTip1.SetToolTip(Me.CHK_Linear, "Linear Parsing : not very smart, but fast")
        ToolTip1.SetToolTip(Me.CHK_OldParser, "Old Parser Parsing : You have to use the player name before others, then class name and type of class last in your template to get the best results")
        ToolTip1.SetToolTip(Me.CHK_Extended, "Shows Class next to the players")
        ToolTip1.SetToolTip(Me.CHK_KnownPlayer, "Stores the players from to raid roster to a file, to use them in the template builder")
        ToolTip1.SetToolTip(Me.CHK_Column, "Column Parsing : Parse all First slots of the templates, then second etc.")
        ToolTip1.SetToolTip(Me.TXT_EQIM, "EQIM data file")
        ToolTip1.SetToolTip(Me.CHK_RaidName, "Uses the group setup template filename as Raid Name")

        Select Case FRM_Main.ParseType
            Case 1
                CHK_Linear.Checked = True
            Case 2
                CHK_OldParser.Checked = True
            Case 3
                CHK_Column.Checked = True
        End Select

        CHK_Channel(FRM_Main.ChannelType).Checked = True
        RDB_Page(FRM_Main.ButtonType).Checked = True

        CHK_RaidName.Checked = FRM_Main.bUseSetupAsName
        CHK_KnownPlayer.Checked = FRM_Main.bKnownPlayersOption

        TXT_EQIM.Text = FRM_Main.EQIMFile


        ChangeColor(BTN_UNKNOWN, FRM_Main.pClassesColors(0))
        ChangeColor(BTN_BARD, FRM_Main.pClassesColors(1))
        ChangeColor(BTN_BEASTLORD, FRM_Main.pClassesColors(2))
        ChangeColor(BTN_BERSERKER, FRM_Main.pClassesColors(3))
        ChangeColor(BTN_CLERIC, FRM_Main.pClassesColors(4))
        ChangeColor(BTN_DRUID, FRM_Main.pClassesColors(5))
        ChangeColor(BTN_ENCHANTER, FRM_Main.pClassesColors(6))
        ChangeColor(BTN_MAGICIAN, FRM_Main.pClassesColors(7))
        ChangeColor(BTN_MONK, FRM_Main.pClassesColors(8))
        ChangeColor(BTN_NECROMANCER, FRM_Main.pClassesColors(9))
        ChangeColor(BTN_PALADIN, FRM_Main.pClassesColors(10))
        ChangeColor(BTN_RANGER, FRM_Main.pClassesColors(11))
        ChangeColor(BTN_ROGUE, FRM_Main.pClassesColors(12))
        ChangeColor(BTN_SHAMAN, FRM_Main.pClassesColors(13))
        ChangeColor(BTN_SHADOWKNIGHT, FRM_Main.pClassesColors(14))
        ChangeColor(BTN_WARRIOR, FRM_Main.pClassesColors(15))
        ChangeColor(BTN_WIZARD, FRM_Main.pClassesColors(16))

        bLoad = False

        FRM_Main.Refresh()
    End Sub

    Private Sub BTNColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_UNKNOWN.Click, BTN_BERSERKER.Click, BTN_BARD.Click, BTN_BEASTLORD.Click, BTN_CLERIC.Click, BTN_DRUID.Click, BTN_ENCHANTER.Click, BTN_MAGICIAN.Click, BTN_MONK.Click, BTN_NECROMANCER.Click, BTN_PALADIN.Click, BTN_RANGER.Click, BTN_ROGUE.Click, BTN_SHAMAN.Click, BTN_SHADOWKNIGHT.Click, BTN_WARRIOR.Click, BTN_WIZARD.Click
        Dim ColorDialog1 As New ColorDialog

        ColorDialog1.Color = sender.ForeColor
        If (ColorDialog1.ShowDialog() = DialogResult.OK) Then
            ChangeColor(sender, ColorDialog1.Color)
            FRM_Main.Refresh()
        End If
    End Sub

    Private Sub BTN_ColorReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_RESET.Click
        ChangeColor(BTN_UNKNOWN, Color.Black)
        ChangeColor(BTN_BERSERKER, Color.Black)
        ChangeColor(BTN_BARD, Color.Black)
        ChangeColor(BTN_BEASTLORD, Color.Black)
        ChangeColor(BTN_CLERIC, Color.Black)
        ChangeColor(BTN_DRUID, Color.Black)
        ChangeColor(BTN_ENCHANTER, Color.Black)
        ChangeColor(BTN_MAGICIAN, Color.Black)
        ChangeColor(BTN_MONK, Color.Black)
        ChangeColor(BTN_NECROMANCER, Color.Black)
        ChangeColor(BTN_PALADIN, Color.Black)
        ChangeColor(BTN_RANGER, Color.Black)
        ChangeColor(BTN_ROGUE, Color.Black)
        ChangeColor(BTN_SHAMAN, Color.Black)
        ChangeColor(BTN_SHADOWKNIGHT, Color.Black)
        ChangeColor(BTN_WARRIOR, Color.Black)
        ChangeColor(BTN_WIZARD, Color.Black)
    End Sub

    Private Sub ChangeColor(ByVal sender As System.Object, ByVal C As Color)
        Dim btn As System.Windows.Forms.Button
        Dim i As Integer

        btn = sender
        btn.ForeColor = C
        i = GetClassNum(btn)
        FRM_Main.pClassesColors(i) = C

        SaveSetting(FRM_Main.AppName, FRM_Main.SecColorName, "R" & i, FRM_Main.pClassesColors(i).R)
        SaveSetting(FRM_Main.AppName, FRM_Main.SecColorName, "G" & i, FRM_Main.pClassesColors(i).G)
        SaveSetting(FRM_Main.AppName, FRM_Main.SecColorName, "B" & i, FRM_Main.pClassesColors(i).B)

    End Sub

    Private Function GetClassNum(ByVal sender As System.Object) As Integer
        Dim result As Integer

        If sender Is BTN_UNKNOWN Then
            GetClassNum = 0
            Exit Function
        End If

        If sender Is BTN_BARD Then
            GetClassNum = 1
            Exit Function
        End If

        If sender Is BTN_BEASTLORD Then
            GetClassNum = 2
            Exit Function
        End If

        If sender Is BTN_BERSERKER Then
            GetClassNum = 3
            Exit Function
        End If

        If sender Is BTN_CLERIC Then
            GetClassNum = 4
            Exit Function
        End If

        If sender Is BTN_DRUID Then
            GetClassNum = 5
            Exit Function
        End If

        If sender Is BTN_ENCHANTER Then
            GetClassNum = 6
            Exit Function
        End If

        If sender Is BTN_MAGICIAN Then
            GetClassNum = 7
            Exit Function
        End If

        If sender Is BTN_MONK Then
            GetClassNum = 8
            Exit Function
        End If

        If sender Is BTN_NECROMANCER Then
            GetClassNum = 9
            Exit Function
        End If

        If sender Is BTN_PALADIN Then
            GetClassNum = 10
            Exit Function
        End If

        If sender Is BTN_RANGER Then
            GetClassNum = 11
            Exit Function
        End If
        If sender Is BTN_ROGUE Then
            GetClassNum = 12
            Exit Function
        End If
        If sender Is BTN_SHAMAN Then
            GetClassNum = 13
            Exit Function
        End If
        If sender Is BTN_SHADOWKNIGHT Then
            GetClassNum = 14
            Exit Function
        End If
        If sender Is BTN_WARRIOR Then
            GetClassNum = 15
            Exit Function
        End If
        If sender Is BTN_WIZARD Then
            GetClassNum = 16
            Exit Function
        End If


    End Function

    Private Sub CHK_Extended_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_Extended.CheckedChanged
        If Not bLoad Then
            FRM_Main.ExtendedName = CHK_Extended.Checked
            Call FRM_Main.ExtendedStateChanged()
        End If
    End Sub

    Private Sub CHK_Linear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_Linear.CheckedChanged
        If CHK_Linear.Checked Then
            FRM_Main.ParseType = 1
        End If
    End Sub

    Private Sub CHK_OldParser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_OldParser.CheckedChanged
        If CHK_OldParser.Checked Then
            FRM_Main.ParseType = 2
        End If
    End Sub

    Private Sub CHK_Column_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_Column.CheckedChanged
        If CHK_Column.Checked Then
            FRM_Main.ParseType = 3
        End If
    End Sub

    Private Sub CHK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_0.CheckedChanged, CHK_1.CheckedChanged, CHK_2.CheckedChanged, CHK_3.CheckedChanged, CHK_4.CheckedChanged, CHK_5.CheckedChanged, CHK_6.CheckedChanged, CHK_7.CheckedChanged, CHK_8.CheckedChanged, CHK_9.CheckedChanged, CHK_10.CheckedChanged, CHK_11.CheckedChanged, CHK_12.CheckedChanged, CHK_13.CheckedChanged, CHK_14.CheckedChanged
        Dim i As Byte

        For i = 0 To 14
            If sender Is CHK_Channel(i) Then
                FRM_Main.ChannelType = i
                Exit Sub
            End If
        Next
    End Sub

    Private Sub RDB_Page1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDB_Page1.CheckedChanged, RDB_Page2.CheckedChanged, RDB_Page3.CheckedChanged, RDB_Page4.CheckedChanged, RDB_Page5.CheckedChanged, RDB_Page6.CheckedChanged, RDB_Page7.CheckedChanged, RDB_Page8.CheckedChanged, RDB_Page9.CheckedChanged, RDB_Page10.CheckedChanged
        Dim i As Byte

        For i = 0 To 9
            If sender Is RDB_Page(i) Then
                FRM_Main.ButtonType = i
                Exit Sub
            End If
        Next
    End Sub

    Private Sub CHK_KnownPlayer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_KnownPlayer.CheckedChanged
        If Not bLoad Then
            MsgBox("This will Enable/disable Player known option NEXT TIME YOU USE GROUP PARSER. It will add players to a database for easier adding for a little time loss during raid loading.", MsgBoxStyle.Information)
        End If

        FRM_Main.bKnownPlayersOption = CHK_KnownPlayer.Checked
    End Sub

    Private Sub CHK_RaidName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_RaidName.CheckedChanged
        FRM_Main.bUseSetupAsName = CHK_RaidName.Checked
    End Sub

    Private Sub BTN_EQIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_EQIM.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.InitialDirectory = FRM_Main.IniPath
        openFileDialog1.Filter = "EQIM export file (*.exp)|*.exp|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            FRM_Main.EQIMFile = openFileDialog1.FileName()
            SaveSetting(FRM_Main.AppName, FRM_Main.SecName, "EQIMFile", FRM_Main.EQIMFile)
        Else
            Exit Sub
        End If
    End Sub

End Class
