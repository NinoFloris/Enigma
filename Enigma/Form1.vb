Public Class Form1
    Dim rotornames() As String = New String() {"Rotor I", "Rotor II", "Rotor III", "Rotor IV", "Rotor V"}
    Dim currentrotors As New List(Of String)
    Dim debugwriter As TraceListener
    Dim enigma As Enigma
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Compute.Click
        debugwriter = New TextWriterTraceListener("debug.txt")
        Trace.Listeners.Add(debugwriter)
        If Turn1.SelectedItem Is Nothing Then Turn1.SelectedIndex = 0
        If Turn2.SelectedItem Is Nothing Then Turn2.SelectedIndex = 0
        If Turn3.SelectedItem Is Nothing Then Turn3.SelectedIndex = 0
        enigma.Stepmechanism.Rotor1.Turn(Turn1.SelectedItem(0))
        enigma.Stepmechanism.Rotor2.Turn(Turn2.SelectedItem(0))
        enigma.Stepmechanism.Rotor3.Turn(Turn3.SelectedItem(0))
        Output.Text = enigma.Encrypt(Input.Text)
        debugwriter.Flush()
        debugwriter.Close()
        debugwriter.Dispose()
        Dim strreader As New IO.StreamReader("debug.txt")
        Debugtxtbox.Text = strreader.ReadToEnd()
        strreader.Dispose()
    End Sub

    Private Sub SelectRotor1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectRotor1.DropDown
        currentrotors.Clear()
        currentrotors.AddRange(rotornames)
        currentrotors.Remove(SelectRotor2.SelectedItem)
        currentrotors.Remove(SelectRotor3.SelectedItem)
        SelectRotor1.Items.Clear()
        SelectRotor1.Items.AddRange(currentrotors.ToArray)
    End Sub

    Private Sub SelectRotor2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectRotor2.DropDown
        currentrotors.Clear()
        currentrotors.AddRange(rotornames)
        currentrotors.Remove(SelectRotor1.SelectedItem)
        currentrotors.Remove(SelectRotor3.SelectedItem)
        SelectRotor2.Items.Clear()
        SelectRotor2.Items.AddRange(currentrotors.ToArray)
    End Sub

    Private Sub SelectRotor3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectRotor3.DropDown
        currentrotors.Clear()
        currentrotors.AddRange(rotornames)
        currentrotors.Remove(SelectRotor1.SelectedItem)
        currentrotors.Remove(SelectRotor2.SelectedItem)
        SelectRotor3.Items.Clear()
        SelectRotor3.Items.AddRange(currentrotors.ToArray)
    End Sub



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TableLayoutPanel6.BackColor = Color.FromArgb(50, 255, 255, 255)

    End Sub

    Private Function getseq(ByVal selected As String)
        Select Case selected

            Case "Rotor I"
                Dim rotor As New Rotor_I
                Return rotor.OutList.ToArray
            Case "Rotor II"
                Dim rotor As New Rotor_II
                Return rotor.OutList.ToArray
            Case "Rotor III"
                Dim rotor As New Rotor_III
                Return rotor.OutList.ToArray
            Case "Rotor IV"
                Dim rotor As New Rotor_IV
                Return rotor.OutList.ToArray
            Case "Rotor V"
                Dim rotor As New Rotor_V
                Return rotor.OutList.ToArray
        End Select

    End Function

    Private Sub SelectRotor1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectRotor1.SelectedValueChanged
        Rotor1ch.Text = SelectRotor1.SelectedItem
        Rotor1seq.Text = getseq(SelectRotor1.SelectedItem)
    End Sub

    Private Sub SelectRotor2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectRotor2.SelectedValueChanged
        Rotor2ch.Text = SelectRotor2.SelectedItem
        Rotor2seq.Text = getseq(SelectRotor2.SelectedItem)
    End Sub

    Private Sub SelectRotor3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectRotor3.SelectedValueChanged
        Rotor3ch.Text = SelectRotor3.SelectedItem
        Rotor3seq.Text = getseq(SelectRotor3.SelectedItem)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            Reflectorch.Text = "Reflector B"
            Dim reflector As New ReflectorB
            Reflectorseq.Text = reflector.OutList.ToArray
        Else
            Reflectorch.Text = "Reflector C"
            Dim reflector As New ReflectorC
            Reflectorseq.Text = reflector.OutList.ToArray
        End If
    End Sub

    Private Function selectobj(ByVal selected As String, Optional ByVal adjustment As Integer = 0)
        Select Case selected
            Case "Rotor I"
                Return New Rotor_I(adjustment)
            Case "Rotor II"
                Return New Rotor_II(adjustment)
            Case "Rotor III"
                Return New Rotor_III(adjustment)
            Case "Rotor IV"
                Return New Rotor_IV(adjustment)
            Case "Rotor V"
                Return New Rotor_V(adjustment)
            Case "Reflector B"
                Return New ReflectorB
            Case "Reflector C"
                Return New ReflectorC
        End Select
    End Function


    Private Sub TabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles TabControl1.Selecting
        If (Rotor1ch.Text = "" OrElse Rotor2ch.Text = "" OrElse Rotor3ch.Text = "" OrElse Reflectorch.Text = "") Then
            MsgBox("Nog niet alle keuzes zijn gemaakt")
            e.Cancel = True
        ElseIf Label20.Text < 26 OrElse Label20.Text > 26 Then
            MsgBox("Het steckerbord is in/overcompleet, beide kanten moeten 26 letters hebben.")
            e.Cancel = True
        Else
            enigma = New Enigma(New StepMechanism(selectobj(Rotor1ch.Text, ComboBox4.SelectedItem), selectobj(Rotor2ch.Text, ComboBox5.SelectedItem), _
                                                selectobj(Rotor3ch.Text, ComboBox6.SelectedItem)), selectobj(Reflectorch.Text), New Steckerbord(AlphaBlendTextBox1.Text, AlphaBlendTextBox2.Text))
        End If

    End Sub


    Private Sub AlphaBlendTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlphaBlendTextBox2.TextChanged
        Dim str As String = AlphaBlendTextBox2.Text.Trim
        Label20.Text = str.Replace(" ", "").Length
    End Sub

    Private Sub Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reset.Click
        AlphaBlendTextBox1.Text = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z"
        AlphaBlendTextBox2.Text = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z"
    End Sub
End Class
