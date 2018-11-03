Public Enum pClasses
    CLS_UNKNOWN
    CLS_BARD
    CLS_BEASTLORD
    CLS_BERSERKER
    CLS_CLERIC
    CLS_DRUID
    CLS_ENCHANTER
    CLS_MAGICIAN
    CLS_MONK
    CLS_NECROMANCER
    CLS_PALADIN
    CLS_RANGER
    CLS_ROGUE
    CLS_SHAMAN
    CLS_SHADOWKNIGHT
    CLS_WARRIOR
    CLS_WIZARD
End Enum

Public Class Player
    Public Name As String
    Public Type As pClasses
    Public Level As Byte
    Public Group As Byte
    Public Placed As Boolean
End Class


Public Class PlayerCollection
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As Player
        Get
            Return CType(List(index), Player)
        End Get
        Set(ByVal Value As Player)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal value As Player) As Integer
        Return List.Add(value)
    End Function 'Add

    Public Function IndexOf(ByVal value As Player) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As Player)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As Player)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As Player) As Boolean
        ' If value is not of type Player, this will return false.
        Return List.Contains(value)
    End Function 'Contains


    Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("GroupParser.Player") Then
            Throw New ArgumentException("value must be of type Player.", "value")
        End If
    End Sub 'OnInsert


    Protected Overrides Sub OnRemove(ByVal index As Integer, ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("GroupParser.Player") Then
            Throw New ArgumentException("value must be of type Player.", "value")
        End If
    End Sub 'OnRemove


    Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As [Object], ByVal newValue As [Object])
        If Not newValue.GetType() Is Type.GetType("GroupParser.Player") Then
            Throw New ArgumentException("newValue must be of type Player.", "newValue")
        End If
    End Sub 'OnSet


    Protected Overrides Sub OnValidate(ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("GroupParser.Player") Then
            Throw New ArgumentException("value must be of type Player.")
        End If
    End Sub 'OnValidate

End Class


Public Class KnownPlayer
    Public Name As String
    Public Type As pClasses
End Class

Public Class KnownPlayerCollection
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As KnownPlayer
        Get
            Return CType(List(index), KnownPlayer)
        End Get
        Set(ByVal Value As KnownPlayer)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal value As KnownPlayer) As Integer
        Return List.Add(value)
    End Function 'Add

    Public Function IndexOf(ByVal value As KnownPlayer) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As KnownPlayer)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As KnownPlayer)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As KnownPlayer) As Boolean
        ' If value is not of type KnownPlayer, this will return false.
        Return List.Contains(value)
    End Function 'Contains


    Protected Overrides Sub OnInsert(ByVal index As Integer, ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("GroupParser.KnownPlayer") Then
            Throw New ArgumentException("value must be of type KnownPlayer.", "value")
        End If
    End Sub 'OnInsert


    Protected Overrides Sub OnRemove(ByVal index As Integer, ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("GroupParser.KnownPlayer") Then
            Throw New ArgumentException("value must be of type KnownPlayer.", "value")
        End If
    End Sub 'OnRemove


    Protected Overrides Sub OnSet(ByVal index As Integer, ByVal oldValue As [Object], ByVal newValue As [Object])
        If Not newValue.GetType() Is Type.GetType("GroupParser.KnownPlayer") Then
            Throw New ArgumentException("newValue must be of type KnownPlayer.", "newValue")
        End If
    End Sub 'OnSet


    Protected Overrides Sub OnValidate(ByVal value As [Object])
        If Not value.GetType() Is Type.GetType("GroupParser.KnownPlayer") Then
            Throw New ArgumentException("value must be of type KnownPlayer.")
        End If
    End Sub 'OnValidate

End Class

