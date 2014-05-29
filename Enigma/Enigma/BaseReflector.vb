Public MustInherit Class BaseReflector
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

    Sub New(ByVal Outlist() As Char)
        Dim abc As String = "abcdefghijklmnopqrstuvwxyz"
        For Each ch In abc
            If _inlist.Count = 26 Then Exit For
            _inlist.Add(Char.ToUpper(ch))
        Next

        For Each ch In Outlist
            If _outlist.Count = 26 Then Exit For
            Me._outlist.Add(Char.ToUpper(ch))
        Next
    End Sub
End Class

