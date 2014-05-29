Public Class Steckerbord

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

    Sub New(ByVal Inlist() As Char, ByVal Outlist() As Char)
        For Each ch In Inlist
            _inlist.Add(ch)
        Next
        For Each ch In Outlist
            _outlist.Add(ch)
        Next
    End Sub


End Class
