Public Class StepMechanism

    Dim _rotor1 As BaseRotor
    ReadOnly Property Rotor1 As BaseRotor
        Get
            Return _rotor1
        End Get
    End Property

    Dim _rotor2 As BaseRotor
    ReadOnly Property Rotor2 As BaseRotor
        Get
            Return _rotor2
        End Get
    End Property

    Dim _rotor3 As BaseRotor
    ReadOnly Property Rotor3 As BaseRotor
        Get
            Return _rotor3
        End Get
    End Property

    ''' <summary>
    ''' From right to left, the rotors.
    ''' So Rotor1 is the most right one.
    ''' </summary>
    ''' <param name="Rotor1"></param>
    ''' <param name="Rotor2"></param>
    ''' <param name="Rotor3"></param>
    ''' <remarks></remarks>
    Sub New(ByVal Rotor1 As BaseRotor, ByVal Rotor2 As BaseRotor, ByVal Rotor3 As BaseRotor)
        _rotor1 = Rotor1
        _rotor2 = Rotor2
        _rotor3 = Rotor3
    End Sub

    Private rotor2stepped As Boolean = False

    Sub [Step]()
        Rotor1.Step()
        If Rotor1.StepoverChar = Rotor1.CurrentChar Then
            Rotor2.Step()
            If Rotor2.StepoverChar = Rotor2.CurrentChar Then
                Rotor3.Step()
            End If
        End If

        'Double stepping
        If Rotor1.InList(Rotor1.Stepoverposition + 1) = Rotor1.CurrentChar AndAlso Rotor2.InList(Rotor2.Stepoverposition - 1) = Rotor2.CurrentChar Then
            Rotor2.Step()
            Rotor3.Step()
        End If
    End Sub




End Class
