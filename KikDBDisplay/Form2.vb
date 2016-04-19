Imports System.Data.SQLite

Public Class Form2
    Dim workingpath As String
    Dim stdelay As Int32 = 0
    Dim count As Int32 = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = Getcurrentuser()
        If CheckBox1.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
    Public Function Getcurrentuser()
        Dim user As String
        user = Form1.Label46.Text
        Return user
    End Function
    Public Sub querymessages()
        Dim constr As String = "Data Source=" + My.Settings.CurrentDB
        Dim query1 As String = "SELECT * FROM messagesTable WHERE partner_jid='" + Getcurrentuser() + "'"
        Dim dt As DataTable = Nothing
        Dim ds As DataSet = New DataSet
        Dim emprow As DataRow = Nothing
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        Dim SQLdr As SQLiteDataReader
        Dim wasme As String = ""
        Dim read As String = ""
        Try
            RichTextBox1.Text = ""
            SQLConn.ConnectionString = constr
            SQLConn.Open()
            SQLcmd.Connection = SQLConn
            SQLcmd.CommandText = query1
            SQLdr = SQLcmd.ExecuteReader()
            While SQLdr.Read()
                wasme = SQLdr("was_me")
                read = SQLdr("read_state")
                If wasme = "1" Then
                    If read = "400" Then
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
                        RichTextBox1.SelectionFont = New Font("Arial", 12)
                        RichTextBox1.SelectionColor = Color.DarkGreen
                        RichTextBox1.AppendText(" " + SQLdr("body").ToString + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
                        RichTextBox1.SelectionFont = New Font("Arial", 9)
                        RichTextBox1.SelectionColor = Color.Black
                        RichTextBox1.AppendText(" " + tstot(SQLdr("timestamp")) + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
                        RichTextBox1.SelectionFont = New Font("Arial", 8, FontStyle.Bold)
                        RichTextBox1.SelectionColor = Color.DarkGray
                        RichTextBox1.AppendText(" " + "Message Unread" + vbCrLf + vbCrLf)
                    Else
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
                        RichTextBox1.SelectionFont = New Font("Arial", 12)
                        RichTextBox1.SelectionColor = Color.DarkGreen
                        RichTextBox1.AppendText(" " + SQLdr("body").ToString + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
                        RichTextBox1.SelectionFont = New Font("Arial", 9)
                        RichTextBox1.SelectionColor = Color.Black
                        RichTextBox1.AppendText(" " + tstot(SQLdr("timestamp")) + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
                        RichTextBox1.SelectionFont = New Font("Arial", 8)
                        RichTextBox1.SelectionColor = Color.DarkGray
                        RichTextBox1.AppendText(" " + "Message Read" + vbCrLf + vbCrLf)
                    End If
                Else
                    If read = "400" Then
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
                        RichTextBox1.SelectionFont = New Font("Arial", 12)
                        RichTextBox1.SelectionColor = Color.Navy
                        RichTextBox1.AppendText(" " + SQLdr("body").ToString + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
                        RichTextBox1.SelectionFont = New Font("Arial", 9)
                        RichTextBox1.SelectionColor = Color.Black
                        RichTextBox1.AppendText(" " + tstot(SQLdr("timestamp")) + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
                        RichTextBox1.SelectionFont = New Font("Arial", 8, FontStyle.Bold)
                        RichTextBox1.SelectionColor = Color.DarkGray
                        RichTextBox1.AppendText(" " + "Message Unread" + vbCrLf + vbCrLf + vbCrLf)
                    Else
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
                        RichTextBox1.SelectionFont = New Font("Arial", 12)
                        RichTextBox1.SelectionColor = Color.Navy
                        RichTextBox1.AppendText(" " + SQLdr("body").ToString + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
                        RichTextBox1.SelectionFont = New Font("Arial", 9)
                        RichTextBox1.SelectionColor = Color.Black
                        RichTextBox1.AppendText(" " + tstot(SQLdr("timestamp")) + vbCrLf)
                        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
                        RichTextBox1.SelectionFont = New Font("Arial", 8)
                        RichTextBox1.SelectionColor = Color.DarkGray
                        RichTextBox1.AppendText(" " + "Message Read" + vbCrLf + vbCrLf)
                    End If
                End If
            End While
            SQLdr.Close()
            SQLConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function getvalue(ByVal dbvalue As Object) As Object
        If IsDBNull(dbvalue) Then
            Return ""
        Else
            Return dbvalue
        End If
    End Function
    Public Function tstot(ts As String)
        Dim dt As DateTime = New DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(ts).ToLocalTime()
        Dim final As String = dt.ToShortDateString + " " + dt.ToShortTimeString
        Return final
    End Function
    Private Sub Label2_textchanged(sender As Object, e As EventArgs) Handles Label2.TextChanged
        If stdelay > 1 Then
            querymessages()
        End If
        stdelay = stdelay + 1
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If count = 1 Then
            Timer2.Enabled = False
            querymessages()
        End If
        count = count + 1
    End Sub
    Private Sub Form2_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer2.Enabled = True
    End Sub
End Class