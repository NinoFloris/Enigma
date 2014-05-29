Public Class Enigma
    Private _stepper As StepMechanism
    ReadOnly Property Stepmechanism As StepMechanism
        Get
            Return _stepper
        End Get
    End Property
    Dim reflector As BaseReflector
    Dim steckerbord As Steckerbord

    Sub New(ByVal Stepmechanism As StepMechanism, ByVal Reflector As BaseReflector, ByVal Steckerbord As Steckerbord)
        _stepper = Stepmechanism
        Me.reflector = Reflector
        Me.steckerbord = Steckerbord
    End Sub

    Function Encrypt(ByVal data() As Char) As Char()
        Dim rotor1 As BaseRotor = _stepper.Rotor1
        Dim rotor2 As BaseRotor = _stepper.Rotor2
        Dim rotor3 As BaseRotor = _stepper.Rotor3
        Dim results As New List(Of Char)
        For Each ch In data
            _stepper.Step()

            ch = steckerbord.OutList(steckerbord.InList.IndexOf(Char.ToUpper(ch)))
            Dim datapos As Integer = rotor1.InList.IndexOf(ch)

            Dim firstrotor As Integer = rotor1.InList.IndexOf(rotor1.OutList((datapos + rotor1.CurrentPosition) Mod 26))
            If firstrotor - rotor1.CurrentPosition < 0 Then firstrotor += 26

            Dim secondrotor As Integer = rotor2.InList.IndexOf(rotor2.OutList((firstrotor - rotor1.CurrentPosition + rotor2.CurrentPosition) Mod 26))
            If secondrotor - rotor2.CurrentPosition < 0 Then secondrotor += 26

            Dim lastrotor As Integer = rotor3.InList.IndexOf(rotor3.OutList((secondrotor - rotor2.CurrentPosition + rotor3.CurrentPosition) Mod 26))
            If lastrotor - rotor3.CurrentPosition < 0 Then lastrotor += 26

            Dim reflect As Integer = reflector.InList.IndexOf(reflector.OutList((lastrotor - rotor3.CurrentPosition) Mod 26))

            Dim blastrotor As Integer = rotor3.OutList.IndexOf(rotor3.InList((reflect + rotor3.CurrentPosition) Mod 26))
            If blastrotor - rotor3.CurrentPosition < 0 Then blastrotor += 26

            Dim bsecondrotor As Integer = rotor2.OutList.IndexOf(rotor2.InList((blastrotor + rotor2.CurrentPosition - rotor3.CurrentPosition) Mod 26))
            If bsecondrotor - rotor2.CurrentPosition < 0 Then bsecondrotor += 26

            Dim bfirstrotor As Integer = rotor1.OutList.IndexOf(rotor2.InList((bsecondrotor + rotor1.CurrentPosition - rotor2.CurrentPosition) Mod 26))
            If bfirstrotor - rotor1.CurrentPosition < 0 Then bfirstrotor += 26

            Dim result As Integer = (bfirstrotor + 26 - rotor1.CurrentPosition) Mod 26


            Dim ofirstrotorchar As Char = rotor1.InList(firstrotor Mod 26)
            Dim osecondrotorchar As Char = rotor2.InList(secondrotor Mod 26)
            Dim olastrotorchar As Char = rotor3.InList(lastrotor Mod 26)
            Dim oreflectchar As Char = reflector.InList(reflect Mod 26)
            Dim oblastrotorchar As Char = rotor3.InList(blastrotor Mod 26)
            Dim obsecondrotorchar As Char = rotor2.InList(bsecondrotor Mod 26)
            Dim obfirstrotorchar As Char = rotor1.InList(bfirstrotor Mod 26)
            Dim oresultchar As Char = rotor1.InList(result Mod 26)

            oresultchar = steckerbord.InList(steckerbord.OutList.IndexOf(oresultchar))

            results.Add(oresultchar)

            Trace.WriteLine("Input: " & ch)
            Trace.WriteLine("First: " & ofirstrotorchar)
            Trace.WriteLine("Second: " & osecondrotorchar)
            Trace.WriteLine("Last: " & olastrotorchar)
            Trace.WriteLine("Reflect: " & oreflectchar)
            Trace.WriteLine("Back Last: " & oblastrotorchar)
            Trace.WriteLine("Back Second: " & obsecondrotorchar)
            Trace.WriteLine("Back First: " & obfirstrotorchar)
            Trace.WriteLine("Output: " & oresultchar)
            Trace.WriteLine("")
        Next
        Return results.ToArray
    End Function


End Class
