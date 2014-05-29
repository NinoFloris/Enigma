Public MustInherit Class BaseRotor
    Implements ISteppable

    Private _currentposition As Integer
    Public Property CurrentPosition() As Integer Implements ITurnable.CurrentPosition
        Get
            Return _currentposition
        End Get
        Set(ByVal value As Integer)
            _currentposition = (value Mod (_inlist.Count))
        End Set
    End Property

    Private _currentchar As Char
    Public Property CurrentChar() As Char Implements ITurnable.CurrentChar
        Get
            Return _inlist.Item(CurrentPosition)
        End Get
        Set(ByVal value As Char)
            CurrentPosition = _inlist.IndexOf(Char.ToUpper(value))
        End Set
    End Property

    Private _outlist As New List(Of Char)
    ReadOnly Property OutList As List(Of Char)
        Get
            Return _outlist
        End Get
    End Property

    Private _inlist As New List(Of Char)
    ReadOnly Property InList As List(Of Char)
        Get
            Return _inlist
        End Get
    End Property

    Private _stepoverchar As Char
    ReadOnly Property StepoverChar As Char Implements ISteppable.StepoverChar
        Get
            Return _stepoverchar
        End Get
    End Property

    Private _stepoverposition As Integer
    ReadOnly Property Stepoverposition As Integer Implements ISteppable.StepoverPosition
        Get
            Return _stepoverposition
        End Get
    End Property

    Private _adjustmentring As Integer
    ReadOnly Property Adjustmentring As Integer
        Get
            Return _adjustmentring
        End Get
    End Property

    Sub New(ByVal Outlist() As Char, ByVal Adjustmentring As Integer, ByVal StepoverChar As Char)
        Dim abc As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        For Each ch In abc
            If InList.Count = 26 Then Exit For
            InList.Add(Char.ToUpper(ch))
        Next
        _stepoverchar = StepoverChar
        _stepoverposition = InList.IndexOf(StepoverChar)
        For Each ch In Outlist
            If _outlist.Count = 26 Then Exit For
            Me._outlist.Add(Char.ToUpper(ch))
        Next

        _adjustmentring = Adjustmentring
        Dim templist As List(Of Char) = _outlist.Take(_adjustmentring Mod _outlist.Count).ToList
        _outlist = _outlist.Skip(Adjustmentring).ToList
        _outlist.AddRange(templist)

    End Sub

    Function GetPosition(ByVal Character As Char)
        Return _outlist.IndexOf(Char.ToUpper(Character))
    End Function

    Function GetChar(ByVal Character As Char)
        Return _outlist(_inlist.IndexOf(Char.ToUpper(Character)) + CurrentPosition)
    End Function

    Function Getpos(ByVal Character As Integer)
        Return Character + CurrentPosition
    End Function

    Sub Turn(ByVal Turns As Integer) Implements ITurnable.Turn
        CurrentPosition = (_currentposition + Turns) 'Mod outlist_var.Count
    End Sub

    Sub Turn(ByVal Character As Char) Implements ITurnable.Turn
        CurrentPosition = _inlist.IndexOf(Char.ToUpper(Character))
    End Sub

    Sub [Step]() Implements ISteppable.Step
        CurrentPosition += 1
    End Sub

End Class
