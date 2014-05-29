Public Interface IEnigmaPart

End Interface

Public Interface ITurnable
    Inherits IEnigmaPart
    Property CurrentPosition As Integer
    Property CurrentChar As Char
    Sub Turn(ByVal Turns As Integer)
    Sub Turn(ByVal Character As Char)
End Interface

Public Interface ISteppable
    Inherits ITurnable
    ReadOnly Property StepoverChar As Char
    ReadOnly Property StepoverPosition As Integer
    Sub [Step]()
End Interface