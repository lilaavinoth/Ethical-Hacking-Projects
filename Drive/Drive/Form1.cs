using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;

namespace Drive
{
    public partial class Form1
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Google.Apis.Drive.v2.DriveService service = new Google.Apis.Drive.v2.DriveService();

        private void createservice()
        {
            string clientid = "33112220271-90jmr0k7ajfptp3fvte99h27b9srcg5o.apps.googleusercontent.com";
            string clientsecret = "ofn4YpoJsGJ2mfOjFlliKvXx";
            var uc = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets() { ClientId = clientid, ClientSecret = clientsecret }, new[] { DriveService.Scope.Drive }, "user", CancellationToken.None).Result;
            service = new Google.Apis.Drive.v2.DriveService(new BaseClientService.Initializer() { HttpClientInitializer = uc, ApplicationName = "Google Drive VB Dot Net" });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string[] myfiles = Directory.GetFiles(@"c:\Windows\Logs\Telephony\Tempo\");

                if (service.ApplicationName != "Google Drive VB Dot Net")
                {
                    createservice();
                }

                Google.Apis.Drive.v3.DriveService service = GetService();
                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = FolderName;
                //this mimetype specify that we need folder in google drive
                FileMetaData.MimeType = "application/vnd.google-apps.folder";
                Google.Apis.Drive.v3.FilesResource.CreateRequest request;
                request = service.Files.Create(FileMetaData);
                request.Fields = "id";
                var file = request.Execute();

                var myfile = new Google.Apis.Drive.v2.Data.File();

                for (int i = 0; i < myfiles.Length; i++)
                {
                    var bytearry = System.IO.File.ReadAllBytes(myfiles[i]);
                    var stream = new System.IO.MemoryStream(bytearry);
                    var uploadrequest = service.Files.Insert(myfile, stream, myfile.MimeType);
                    uploadrequest.Upload();
                    var file = uploadrequest.ResponseBody;
                    MessageBox.Show("upload successful" + file.Id);
                }

                for (int i = 0; i < myfiles.Length; i++)
                {
                    System.IO.File.Delete(myfiles[i]);
                }


            }
            catch
            {

            }

            // Dim f As New OpenFileDialog
            // If f.ShowDialog = DialogResult.OK Then
            // Dim filenameloc As String = f.FileName
            // Else
            // Exit Sub
            // End If



            //if (service.ApplicationName != "Google Drive VB Dot Net")
            //    createservice();
            //var myfile = new File();
            //var bytearry = System.IO.File.ReadAllBytes("C:\\Windows\\Logs\\Telephony\\Tempo");
            //var stream = new System.IO.MemoryStream(bytearry);
            //var uploadrequest = service.Files.Insert(myfile, stream, );
            //uploadrequest.Upload();
            //var file = uploadrequest.ResponseBody;
            //MessageBox.Show("upload successful" + file.Id);
        }

        private Google.Apis.Drive.v3.DriveService GetService()
        {
            throw new NotImplementedException();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}