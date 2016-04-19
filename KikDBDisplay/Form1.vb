Imports System.Data.SQLite
Imports System.IO
Imports System.Security.Cryptography

Public Class Form1
    Dim appPath As String = Application.StartupPath()
    Dim simpledate As String = TimeOfDay.Date.ToShortDateString + TimeOfDay.Date.ToShortTimeString
    Public Overridable Property AutoPostBack As Boolean = True
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub
    Sub loadprimary()
        Dim constr As String = "Data Source=" + My.Settings.CurrentDB
        Dim query1 As String = "SELECT * FROM KIKcontactsTable"
        Dim dt As DataTable = Nothing
        Dim ds As DataSet = New DataSet
        Try
            Using con As New SQLiteConnection(constr)
                Using cmd As New SQLiteCommand(query1, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)
                    End Using
                End Using
            End Using
            ListBox1.ValueMember = "_id"
            ListBox1.DisplayMember = "user_name"
            ListBox1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub importData(fileLoc As [String])
        Dim constr As String = "Data Source=" + My.Settings.CurrentDB
        Dim con As New SQLiteConnection(constr)
        Dim SQL As String = "ATTACH '" + fileLoc + "' AS TOMERGE"
        Dim cmd As New SQLiteCommand(SQL, con)
        cmd.Connection = con
        con.Open()
        Dim retval As Integer = 0
        Try
            retval = cmd.ExecuteNonQuery()
        Catch generatedExceptionName As Exception
            MessageBox.Show("An error occurred, your import was not completed.")
        Finally
            cmd.Dispose()
        End Try
        SQL = "INSERT INTO KIKcontactsTable SELECT NULL , TOMERGE.KIKcontactsTable.jid , TOMERGE.KIKcontactsTable.display_name , TOMERGE.KIKcontactsTable.local_name , TOMERGE.KIKcontactsTable.user_name , TOMERGE.KIKcontactsTable.in_roster , TOMERGE.KIKcontactsTable.photo_url , TOMERGE.KIKcontactsTable.photo_timestamp , TOMERGE.KIKcontactsTable.is_stub , TOMERGE.KIKcontactsTable.is_group , TOMERGE.KIKcontactsTable.is_blocked , TOMERGE.KIKcontactsTable.is_ignored , TOMERGE.KIKcontactsTable.pending_convo_clear , TOMERGE.KIKcontactsTable.pending_in_roster , TOMERGE.KIKcontactsTable.pending_is_blocked , TOMERGE.KIKcontactsTable.appear_in_convos_list , TOMERGE.KIKcontactsTable.roster_operation_attempts , TOMERGE.KIKcontactsTable.verified , TOMERGE.KIKcontactsTable.public_key , TOMERGE.KIKcontactsTable.is_public_key_resolved , TOMERGE.KIKcontactsTable.is_user_admin , TOMERGE.KIKcontactsTable.group_hashtag , TOMERGE.KIKcontactsTable.is_user_removed , TOMERGE.KIKcontactsTable.content_links , TOMERGE.KIKcontactsTable.description , TOMERGE.KIKcontactsTable.tags_array FROM TOMERGE.KIKcontactsTable WHERE NOT EXISTS (SELECT * FROM KIKcontactsTable WHERE KIKcontactsTable.jid = TOMERGE.KIKcontactsTable.jid)"
        cmd = New SQLiteCommand(SQL)
        cmd.Connection = con
        retval = 0
        retval = 0
        Try
            retval = cmd.ExecuteNonQuery()
        Catch generatedExceptionName As Exception
            MessageBox.Show("An error occurred, your import was not completed.")
        Finally
            cmd.Dispose()
        End Try
        SQL = "INSERT INTO messagesTable SELECT NULL , TOMERGE.messagesTable.body , TOMERGE.messagesTable.partner_jid, TOMERGE.messagesTable.was_me, TOMERGE.messagesTable.read_state, TOMERGE.messagesTable.uid, TOMERGE.messagesTable.length, TOMERGE.messagesTable.timestamp, TOMERGE.messagesTable.bin_id, TOMERGE.messagesTable.sys_msg, TOMERGE.messagesTable.stat_msg, TOMERGE.messagesTable.stat_user_jid, TOMERGE.messagesTable.stat_special_visibility, TOMERGE.messagesTable.req_read_reciept, TOMERGE.messagesTable.content_id, TOMERGE.messagesTable.app_id, TOMERGE.messagesTable.message_retry_count, TOMERGE.messagesTable.encryption_failure, TOMERGE.messagesTable.render_instructions, TOMERGE.messagesTable.friend_attr_id, TOMERGE.messagesTable.encryption_key, TOMERGE.messagesTable.server_sig, TOMERGE.messagesTable.mention_reply, TOMERGE.messagesTable.mentioned_contact_id  FROM TOMERGE.messagesTable WHERE NOT EXISTS( SELECT * FROM messagesTable WHERE messagesTable.uid = TOMERGE.messagesTable.uid)"
        cmd = New SQLiteCommand(SQL)
        cmd.Connection = con
        retval = 0
        Try
            retval = cmd.ExecuteNonQuery()
        Catch generatedExceptionName As Exception
            MessageBox.Show("An error occurred, your import was not completed.")
        Finally
            cmd.Dispose()
            con.Close()
        End Try
    End Sub
    Public Sub importData_iOS(fileLoc As [String])
        Dim constr As String = "Data Source=" + My.Settings.CurrentDB
        Dim con As New SQLiteConnection(constr)
        Dim SQL As String = "ATTACH '" + fileLoc + "' AS TOMERGE"
        Dim cmd As New SQLiteCommand(SQL, con)
        cmd.Connection = con
        con.Open()
        Dim retval As Integer = 0
        Try
            retval = cmd.ExecuteNonQuery()
        Catch generatedExceptionName As Exception
            MessageBox.Show("An error occurred, your import was not completed.")
        Finally
            cmd.Dispose()
        End Try
        SQL = "INSERT INTO KIKcontactsTable SELECT NULL , TOMERGE.ZKIKUSER.jid , TOMERGE.ZKIKUSER.display_name , TOMERGE.ZKIKUSER.local_name , TOMERGE.ZKIKUSER.user_name , TOMERGE.ZKIKUSER.in_roster , TOMERGE.ZKIKUSER.photo_url , TOMERGE.ZKIKUSER.photo_timestamp , TOMERGE.ZKIKUSER.is_stub , TOMERGE.ZKIKUSER.is_group , TOMERGE.ZKIKUSER.is_blocked , TOMERGE.ZKIKUSER.is_ignored , TOMERGE.ZKIKUSER.pending_convo_clear , TOMERGE.ZKIKUSER.pending_in_roster , TOMERGE.ZKIKUSER.pending_is_blocked , TOMERGE.ZKIKUSER.appear_in_convos_list , TOMERGE.ZKIKUSER.roster_operation_attempts , TOMERGE.ZKIKUSER.verified , TOMERGE.ZKIKUSER.public_key , TOMERGE.ZKIKUSER.is_public_key_resolved , TOMERGE.ZKIKUSER.is_user_admin , TOMERGE.ZKIKUSER.group_hashtag , TOMERGE.ZKIKUSER.is_user_removed , TOMERGE.ZKIKUSER.content_links , TOMERGE.ZKIKUSER.description , TOMERGE.ZKIKUSER.tags_array FROM TOMERGE.ZKIKUSER WHERE NOT EXISTS (SELECT * FROM KIKcontactsTable WHERE KIKcontactsTable.jid = TOMERGE.ZKIKUSER.jid)"
        cmd = New SQLiteCommand(SQL)
        cmd.Connection = con
        retval = 0
        retval = 0
        Try
            retval = cmd.ExecuteNonQuery()
        Catch generatedExceptionName As Exception
            MessageBox.Show("An error occurred, your import was not completed.")
        Finally
            cmd.Dispose()
        End Try
        SQL = "INSERT INTO messagesTable SELECT NULL , TOMERGE.ZKIKMESSAGE.body , TOMERGE.ZKIKMESSAGE.partner_jid, TOMERGE.ZKIKMESSAGE.was_me, TOMERGE.ZKIKMESSAGE.read_state, TOMERGE.ZKIKMESSAGE.uid, TOMERGE.ZKIKMESSAGE.length, TOMERGE.ZKIKMESSAGE.timestamp, TOMERGE.ZKIKMESSAGE.bin_id, TOMERGE.ZKIKMESSAGE.sys_msg, TOMERGE.ZKIKMESSAGE.stat_msg, TOMERGE.ZKIKMESSAGE.stat_user_jid, TOMERGE.ZKIKMESSAGE.stat_special_visibility, TOMERGE.ZKIKMESSAGE.req_read_reciept, TOMERGE.ZKIKMESSAGE.content_id, TOMERGE.ZKIKMESSAGE.app_id, TOMERGE.ZKIKMESSAGE.message_retry_count, TOMERGE.ZKIKMESSAGE.encryption_failure, TOMERGE.ZKIKMESSAGE.render_instructions, TOMERGE.ZKIKMESSAGE.friend_attr_id, TOMERGE.ZKIKMESSAGE.encryption_key, TOMERGE.ZKIKMESSAGE.server_sig, TOMERGE.ZKIKMESSAGE.mention_reply, TOMERGE.ZKIKMESSAGE.mentioned_contact_id  FROM TOMERGE.ZKIKMESSAGE WHERE NOT EXISTS( SELECT * FROM messagesTable WHERE messagesTable.uid = TOMERGE.ZKIKMESSAGE.uid)"
        cmd = New SQLiteCommand(SQL)
        cmd.Connection = con
        retval = 0
        Try
            retval = cmd.ExecuteNonQuery()
        Catch generatedExceptionName As Exception
            MessageBox.Show("An error occurred, your import was not completed.")
        Finally
            cmd.Dispose()
            con.Close()
        End Try
    End Sub
    Sub decodeDB_Android()
        importData(TextBox1.Text)
        loadprimary()
    End Sub
    Sub decodeDB_iOS()
        importData_iOS(TextBox1.Text)
        loadprimary()
    End Sub
    Function sha_256(ByVal file_name As String)
        Return hash_generator("sha256", file_name)
    End Function
    Function sha_1(ByVal file_name As String)
        Return hash_generator("sha1", file_name)
    End Function
    Function md_5(ByVal file_name As String)
        Return hash_generator("md5", file_name)
    End Function
    Public Function PrintByteArray(ByVal array() As Byte)
        Dim hex_value As String = ""
        Dim i As Integer
        For i = 0 To array.Length - 1
            hex_value += array(i).ToString("X2")
        Next i
        Return hex_value.ToLower
    End Function
    Function hash_generator(ByVal hash_type As String, ByVal file_name As String)
        Dim hash
        If hash_type.ToLower = "md5" Then
            hash = MD5.Create
        ElseIf hash_type.ToLower = "sha1" Then
            hash = SHA1.Create()
        ElseIf hash_type.ToLower = "sha256" Then
            hash = SHA256.Create()
        Else
            MsgBox("Unknown type of hash : " & hash_type, MsgBoxStyle.Critical)
            Return False
        End If
        Dim hashValue() As Byte
        Dim fileStream As FileStream = File.OpenRead(file_name)
        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)
        Dim hash_hex = PrintByteArray(hashValue)
        fileStream.Close()
        Return hash_hex
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TextBox1.Text IsNot "" Then
            If File.Exists(TextBox1.Text) Then
                Try
                    Label9.Text = sha_256(TextBox1.Text)
                    Label8.Text = sha_1(TextBox1.Text)
                    Label14.Text = md_5(TextBox1.Text)
                Catch ex As Exception
                End Try
            End If
        End If
        makeitpretty()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        unlock()
        loadprimary()
    End Sub
    Function ConvertTimestamp(ByVal timestamp As Double) As DateTime
        Dim dt As DateTime = New DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(timestamp).ToLocalTime()
        Dim final As String = dt.ToShortDateString + " " + dt.ToShortTimeString
        Return final
    End Function
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text IsNot Nothing Then
            If RadioButton4.Checked = True Then
                decodeDB_Android()
            Else
                decodeDB_iOS()
            End If
        End If
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        infoqwry(ListBox1.SelectedValue)
    End Sub
    Public Sub infoqwry(id As String)
        Dim constr As String = "Data Source=" + My.Settings.CurrentDB
        Dim query1 As String = "SELECT * FROM KIKcontactsTable WHERE _id=" + id
        Dim dt As DataTable = Nothing
        Dim ds As DataSet = New DataSet
        Dim emprow As DataRow = Nothing
        Try
            Using con As New SQLiteConnection(constr)
                Using cmd As New SQLiteCommand(query1, con)
                    con.Open()
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)
                    End Using
                End Using
            End Using
            emprow = dt.Rows(0)
            If dt.Rows.Count > 0 Then
                If emprow IsNot Nothing Then
                    Dim times As String = getvalue(emprow("photo_timestamp"))
                    TextBox5.Text = emprow("_id")
                    TextBox9.Text = getvalue(emprow("description"))
                    Label44.Text = getvalue(emprow("user_name"))
                    Label15.Text = getvalue(emprow("display_name"))
                    Label46.Text = getvalue(emprow("jid"))
                    Label45.Text = ConvertTimestamp(times)
                    Label19.Text = getvalue(emprow("is_stub"))
                    Label21.Text = getvalue(emprow("is_group"))
                    Label18.Text = getvalue(emprow("in_roster"))
                    Label23.Text = getvalue(emprow("is_blocked"))
                    Label48.Text = getvalue(emprow("is_ignored"))
                    Label25.Text = getvalue(emprow("pending_convo_clear"))
                    Label27.Text = getvalue(emprow("pending_in_roster"))
                    Label31.Text = getvalue(emprow("pending_is_blocked"))
                    Label29.Text = getvalue(emprow("appear_in_convos_list"))
                    Label35.Text = getvalue(emprow("roster_operation_attempts"))
                    Label41.Text = getvalue(emprow("verified"))
                    Label33.Text = getvalue(emprow("is_public_key_resolved"))
                    Label37.Text = getvalue(emprow("is_user_admin"))
                    Label39.Text = getvalue(emprow("is_user_removed"))
                    PictureBox1.ImageLocation = getvalue(emprow("photo_url")) + "/orig.jpg"
                End If
            End If
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
    Public Function getbool(value As String)
        If value = 1 Then
            Return "True"
        Else
            Return "False"
        End If
    End Function
    Public Sub makeitpretty()
        If Label18.Text = "True" Then
            Label18.Font = Label50.Font
        Else
            Label18.Font = Label51.Font
        End If

        If Label19.Text = "True" Then
            Label19.Font = Label50.Font
        Else
            Label19.Font = Label51.Font
        End If
        If Label21.Text = "True" Then
            Label21.Font = Label50.Font
        Else
            Label21.Font = Label51.Font
        End If
        If Label23.Text = "True" Then
            Label23.Font = Label50.Font
            Label23.ForeColor = Color.Red
        Else
            Label23.Font = Label51.Font
            Label23.ForeColor = Color.Black
        End If
        If Label48.Text = "True" Then
            Label48.Font = Label50.Font
        Else
            Label48.Font = Label51.Font
        End If
        If Label25.Text = "True" Then
            Label25.Font = Label50.Font
        Else
            Label25.Font = Label51.Font
        End If
        If Label27.Text = "True" Then
            Label27.Font = Label50.Font
        Else
            Label27.Font = Label51.Font
        End If
        If Label31.Text = "True" Then
            Label31.Font = Label50.Font
        Else
            Label31.Font = Label51.Font
        End If
        If Label29.Text = "True" Then
            Label29.Font = Label50.Font
        Else
            Label29.Font = Label51.Font
        End If
        If Label35.Text = "True" Then
            Label35.Font = Label50.Font
        Else
            Label35.Font = Label51.Font
        End If
        If Label41.Text = "True" Then
            Label41.Font = Label50.Font
        Else
            Label41.Font = Label51.Font
        End If
        If Label33.Text = "True" Then
            Label33.Font = Label50.Font
        Else
            Label33.Font = Label51.Font
        End If
        If Label37.Text = "True" Then
            Label37.Font = Label50.Font
        Else
            Label37.Font = Label51.Font
        End If
        If Label39.Text = "True" Then
            Label39.Font = Label50.Font
        Else
            Label39.Font = Label51.Font
        End If
    End Sub
    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Form2.Show()
    End Sub
    Public Sub unlock()
        For Each item In Me.Controls
            item.enabled = True
        Next
    End Sub
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub BitcoinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitcoinToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub PaypalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaypalToolStripMenuItem.Click
        Dim htmlfile As String = Application.StartupPath() + "\paypal.html"
        Process.Start(htmlfile)
    End Sub
    Private Sub ExiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExiToolStripMenuItem.Click
        End
    End Sub
End Class

