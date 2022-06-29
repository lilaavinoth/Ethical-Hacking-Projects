Imports System
Imports Google.Apis.Auth
Imports Google.Apis.Download
Imports Google.Apis.Drive.v2
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Services
Imports Google.Apis.Drive.v2.Data
Imports System.Threading
Imports System.Configuration

Public Class Form1
    Dim service As New DriveService

    Private Sub createservice()
        Dim clientid = "33112220271-90jmr0k7ajfptp3fvte99h27b9srcg5o.apps.googleusercontent.com"
        Dim clientsecret = "ofn4YpoJsGJ2mfOjFlliKvXx"
        Dim uc As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = clientid, .ClientSecret = clientsecret}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
        service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = uc, .ApplicationName = "Google Drive VB Dot Net"})
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim f As New OpenFileDialog
        'If f.ShowDialog = DialogResult.OK Then
        '    Dim filenameloc As String = f.FileName
        'Else
        '    Exit Sub
        'End If

        If service.ApplicationName <> "Google Drive VB Dot Net" Then createservice()
        Dim myfile As New File
        Dim bytearry As Byte() = System.IO.File.ReadAllBytes("D:\OPPO\IMG_2202.JPG")
        Dim stream As New System.IO.MemoryStream(bytearry)
        Dim uploadrequest As FilesResource.InsertMediaUpload = service.Files.Insert(myfile, stream, myfile.MimeType)
        uploadrequest.Upload()
        Dim file As File = uploadrequest.ResponseBody
        MessageBox.Show("upload successful" & file.Id)
    End Sub
End Class
