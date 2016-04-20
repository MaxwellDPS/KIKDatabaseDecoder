Imports System.Data.SQLite

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog1.ShowDialog()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        MakeCase(SaveFileDialog1.FileName)
    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        OpenCase(OpenFileDialog1.FileName)
    End Sub
    Public Sub OpenCase(filename As String)
        My.Settings.CurrentDB = filename
        Form1.Show()
        Close()
    End Sub
    Public Sub MakeCase(filename As String)
        SQLiteConnection.CreateFile(filename)
        Dim m_dbConnection = New SQLiteConnection("Data Source=" + filename + ";Version=3;")
        Try
            m_dbConnection.Open()
            Dim Sql = "CREATE TABLE KIKcontactsTable (_id INTEGER PRIMARY KEY AUTOINCREMENT, jid VARCHAR, display_name VARCHAR, local_name VARCHAR, user_name VARCHAR, in_roster BOOLEAN,photo_url VARCHAR, photo_timestamp VARCHAR, is_stub BOOLEAN,is_group BOOLEAN,is_blocked BOOLEAN,is_ignored BOOLEAN,pending_convo_clear BOOLEAN,pending_in_roster BOOLEAN,pending_is_blocked BOOLEAN,appear_in_convos_list BOOLEAN,roster_operation_attempts INT,verified BOOLEAN,public_key BLOB,is_public_key_resolved BOOLEAN,is_user_admin BOOLEAN,group_hashtag VARCHAR,is_user_removed BOOLEAN,content_links BLOB,description VARCHAR,tags_array VARCHAR)"
            Dim Command = New SQLiteCommand(Sql, m_dbConnection)
            Command.ExecuteNonQuery()
            Sql = "CREATE TABLE messagesTable (_id INTEGER PRIMARY KEY AUTOINCREMENT, body VARCHAR, partner_jid VARCHAR, was_me INT, read_state INT, uid VARCHAR, length INTEGER, timestamp LONG, bin_id VARCHAR, sys_msg VARCHAR, stat_msg VARCHAR, stat_user_jid VARCHAR, stat_special_visibility BOOLEAN,req_read_reciept BOOLEAN, content_id VARCHAR, app_id VARCHAR, message_retry_count INT, encryption_failure BOOLEAN, render_instructions VARCHAR, friend_attr_id INT , encryption_key BLOB ,server_sig VARCHAR ,mention_reply VARCHAR,mentioned_contact_id VARCHAR)"
            Command = New SQLiteCommand(Sql, m_dbConnection)
            Command.ExecuteNonQuery()
            m_dbConnection.Close()
            OpenCase(filename)
        Catch ex As Exception
            MsgBox("Error Creating Database")
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Application.CommandLineArgs IsNot Nothing Then
                OpenCase(My.Application.CommandLineArgs(0))
            End If
        Catch
        End Try
    End Sub
End Class