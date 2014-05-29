Namespace Crypto
    Public Class Enigma

        Public Enum chars
            A = 1
            B
            C
            D
            E
            F
            G
            H
            I
            J
            K
            L
            M
            N
            O
            P
            Q
            R
            S
            T
            U
            V
            W
            X
            Y
            Z
        End Enum

        Private Enum III
            B = 1
            D
            F
            H
            J
            L
            C
            P
            R
            T
            X
            V
            Z
            N
            Y
            E
            I
            W
            G
            A
            K
            M
            U
            S
            Q
            O
        End Enum

        Private Enum II
            A = 1
            J
            D
            K
            S
            I
            R
            U
            X
            B
            L
            H
            W
            T
            M
            C
            Q
            G
            Z
            N
            P
            Y
            F
            V
            O
            E
        End Enum

        Private Enum I
            E = 1
            K
            M
            F
            L
            G
            D
            Q
            V
            Z
            N
            T
            O
            W
            Y
            H
            X
            U
            S
            P
            A
            I
            B
            R
            C
            J
        End Enum

        Private Enum UKWB
            Y = 1
            R
            U
            H
            Q
            S
            L
            D
            P
            X
            N
            G
            O
            K
            M
            I
            E
            B
            F
            Z
            C
            W
            V
            J
            A
            T
        End Enum


        Public Function Compute(ByRef Message As String, ByVal rotor1 As Byte, ByVal rotor2 As Byte, ByVal rotor3 As Byte) As String
            Dim chararray() As Char = Message.ToCharArray()
            Dim curroffset3 As Byte = rotor3
            Dim curroffset2 As Byte = rotor2
            Dim curroffset1 As Byte = rotor1
            Dim outputchar As Char
            Dim output As New List(Of Char)
            Dim workint As Integer
            For Each ch In chararray
                'If curroffset3 <> 26 Then
                '    curroffset3 += 1
                'Else
                '    curroffset3 = 1
                'End If

                workint = curroffset3 + [Enum].Parse(GetType(chars), Char.ToUpper(ch))
                outputchar = [Enum].GetName(GetType(chars), workint Mod 26)
                workint = curroffset2 + [Enum].Parse(GetType(chars), outputchar)
                outputchar = [Enum].GetName(GetType(chars), workint Mod 26)
                workint = curroffset1 + [Enum].Parse(GetType(chars), outputchar)
                outputchar = [Enum].GetName(GetType(chars), workint Mod 26)
                workint = curroffset1 + [Enum].Parse(GetType(chars), outputchar)
                outputchar = [Enum].GetName(GetType(chars), workint Mod 26)
                workint = curroffset2 + [Enum].Parse(GetType(chars), outputchar)
                outputchar = [Enum].GetName(GetType(chars), workint Mod 26)
                workint = curroffset3 + [Enum].Parse(GetType(chars), outputchar)
                outputchar = [Enum].GetName(GetType(chars), workint Mod 26)
                output.Add(outputchar)
            Next
            Return output.ToArray
        End Function

    End Class
End Namespace
