Public Class Rotor_I
    Inherits BaseRotor

    Sub New(Optional ByVal Adjustmentring As Integer = 0)
        MyBase.New("EKMFLGDQVZNTOWYHXUSPAIBRCJ", Adjustmentring, "R")
    End Sub

End Class

Public Class Rotor_II
    Inherits BaseRotor

    Sub New(Optional ByVal Adjustmentring As Integer = 0)
        MyBase.New("AJDKSIRUXBLHWTMCQGZNPYFVOE", Adjustmentring, "F")
    End Sub

End Class

Public Class Rotor_III
    Inherits BaseRotor

    Sub New(Optional ByVal Adjustmentring As Integer = 0)
        MyBase.New("BDFHJLCPRTXVZNYEIWGAKMUSQO", Adjustmentring, "W")
    End Sub

End Class

Public Class Rotor_IV
    Inherits BaseRotor

    Sub New(Optional ByVal Adjustmentring As Integer = 0)
        MyBase.New("ESOVPZJAYQUIRHXLNFTGKDCMWB", Adjustmentring, "K")
    End Sub

End Class

Public Class Rotor_V
    Inherits BaseRotor

    Sub New(Optional ByVal Adjustmentring As Integer = 0)
        MyBase.New("VZBRGITYUPSDNHLXAWMJQOFECK", Adjustmentring, "A")
    End Sub

End Class