using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PODFIN
{
    public partial class Aster : Form
    {

        private SoundPlayer _sound;
        IFirebaseClient client;
        IFirebaseConfig config;

        public Aster()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            config = new FirebaseConfig
            {
                AuthSecret = "4JzR3aCPz04mHvqTbH2OPn61Tp32lbkg0vKEsipd",
                BasePath = "https://podfin-be478-default-rtdb.firebaseio.com/"
            };

            startCheckerAsync(config);

            Random rnd = new Random();
            

        }

        private async Task startCheckerAsync(IFirebaseConfig config)
        {
            client = new FireSharp.FirebaseClient(config);

            try
            {
                FirebaseResponse response = await client.GetAsync("Client" + "/start");
                string retrived = response.ResultAs<string>();

                if (retrived is null)
                {
                    FirstTimeFirebaseAsync();
                }
                else
                {                    
                    FirstTimeFirebaseAsync();                    
                }
            }
            catch
            {

            }
        }

        private async Task listenerAsync()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                EventStreamResponse responseq = await client.OnAsync("Client" + "/start", added: (sender, args, context) =>
                {
                    global.start = args.Data;
                    if (args.Data == "1")
                    {
                        Thread t = new Thread(startToRead);
                        t.Start();

                        //startToRead();
                    }
                    if (args.Data == "0")
                    {
                        global.active = false;
                    }

                },
                changed: (sender, args, context) =>
                {
                    global.start = args.Data;
                    if (args.Data == "1")
                    {
                        Thread w = new Thread(startToRead);
                        w.Start();

                    }
                    if (args.Data == "0")
                    {
                        global.active = false;
                    }
                });
            }
            catch
            {

            }            

        }

        private void startToRead()
        {
            try
            {

                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new Action(startToRead));
                    return;
                }

                textBox1.Visible = true;


                for (int i = 1; i < 20000; i++)
                {
                    Thread.Sleep(150);
                    //string rand1 = randomstring(80);
                    //textbox1.appendtext(rand1);

                    switch (i)
                    {
                        case 1:
                            one();
                            break;
                        case 100:
                            two();
                            break;
                        case 200:
                            threeAsync();
                            break;
                        case 300:
                            four();
                            break;
                        case 400:
                            five();
                            break;
                        case 500:
                            six();
                            break;
                        case 600:
                            seven();
                            break;
                        case 700:
                            eight();
                            break;
                        case 800:
                            nine();
                            break;
                        case 900:
                            ten();
                            break;
                        case 1000:
                            eleven();
                            break;
                        case 1100:
                            twevel();
                            break;
                        case 1200:
                            twevel1();
                            break;
                        case 1300:
                            tweve2();
                            break;
                        case 1400:
                            twevel3();
                            break;
                        case 1500:
                            twevel4();
                            break;
                        case 1800:
                            twevel5();
                            break;
                        case 5000:
                            thirteen();
                            break;
                        case 5100:
                            fourteen();
                            break;
                        case 7000:
                            fiftteen();
                            break;
                        case 7200:
                            sixteen();
                            break;
                        case 9000:
                            seventeen();
                            break;
                        case 9100:
                            eightteen();
                            break;
                        case 10000:
                            nineteen();
                            break;
                        case 11000:
                            twenty();
                            break;
                        case 12000:
                            twentyone();
                            break;
                        case 13000:
                            twentytwo();
                            break;
                        case 14000:
                            twentythree();
                            break;
                        case 15000:
                            twentyfour();
                            break;
                        case 16000:
                            twentyfive();
                            break;
                        case 16100:
                            twentysix();
                            break;
                        case 19000:
                            twentyseven();
                            break;
                        case 19100:
                            twentysevenw();
                            break;
                        case 19200:
                            twentysevenq();
                            break;
                        case 19300:
                            twentysevens();
                            break;
                        case 19500:
                            twentysevenju();
                            break;
                        case 19600:
                            twentysevenrj();
                            break;
                        case 19900:
                            twentysevenxh();
                            break;
                        case 20000:
                            twentysevenqz();
                            break;
                        default:
                            // code block
                            break;
                    }

                }

                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private async void twentysevenqz()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "ASUS is Secure",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentysevenxh()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "All tasks successfully executed",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentysevenrj()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Checking all Tasks",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentysevenju()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Successfully Registered Condition",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentysevens()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Registering Condition in Akshitha's Internet Journey",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentysevenq()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Registering Decryption Key in ASUS",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentysevenw()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Creating Decryption Key",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twevel5()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Connection Success",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twevel4()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Synchronized ASUS with Target PC",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twevel3()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Running Worm Malware",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void tweve2()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Running Vinoth's RMR Program",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twevel1()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Running EMMI-GHN Task",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twentyseven()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Program successfully executed",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twentysix()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Restoring Protection in ASUS",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twentyfive()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Files Encrypted Successfully",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twentyfour()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "80,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twentythree()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "70,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twentytwo()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "60,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twentyone()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "50,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void twenty()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "40,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void nineteen()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "30,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void eightteen()
        {            
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "20,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void seventeen()
        {            
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "10,000 files encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void sixteen()
        {            
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Initializing High Speed Encryption",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void fiftteen()
        {            
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "1000 files Encrypted",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void fourteen()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Encryption Started",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void thirteen()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Malware initialized in Target Computer",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void twevel()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Malware dispatched to target IP",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void eleven()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Broadcasted Malware to 190.168.42.12 (Russia)",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void ten()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Transferring Encryption Malware to ASUS",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void nine()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removed Aironet AP",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void eight()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removed Behavioral analytics",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void seven()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removed Network segmentation",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void six()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removed SecureX",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void five()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removed Intrusion prevention system",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void four()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removed Firewall",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async Task threeAsync()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Removing Protection from ASUS",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();
            }
            catch
            {

            }
        }

        private async void two()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    notification = "Program CORSAIR initiated",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void one()
        {
            
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Connected with Guest user: Akshitha",
                };
                FirebaseResponse response = await client.UpdateAsync("Client"+"/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async Task FirstTimeFirebaseAsync()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = new Data
                {
                    startTime = DateTime.Now.ToString("dd MMM yyyy_hh mm ss tt"),
                    reject = "",
                    start = ""
                    
                };
                FirebaseResponse response = await client.UpdateAsync("Client", data);
                Data updatedData = response.ResultAs<Data>();
                listenerAsync();

            }
            catch
            {

            }
        }

        private void ChangeEvery()
        {
            textBox1.Visible = false;
            textBox2.Visible = true;
            for (int i = 1; i < 10000; i++)
            {
                Thread.Sleep(200);
                string Rand1 = RandomString(80);
                textBox2.AppendText(Rand1);

                switch (i)
                {
                    case 1:
                        vone();
                        break;
                    case 30:
                        vtwo();
                        break;
                    case 50:
                        vthree();
                        break;
                    case 80:
                        vfour();
                        break;
                    case 1000:
                        vfive();
                        break;
                    case 2000:
                        vsix();
                        break;
                    case 3000:
                        vseven();
                        break;
                    case 4000:
                        veight();
                        break;
                    case 5000:
                        vnine();
                        break;
                    case 6000:
                        vten();
                        break;
                    case 7000:
                        veleven();
                        break;
                    case 8000:
                        vtwevle();
                        break;
                    case 9000:
                        vthirteen();
                        break;
                    case 10000:
                        vfourteen();
                        break;

                    default:
                        // code block
                        break;

                }
            }
        }

        private async void vfourteen()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled28.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "100% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vthirteen()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled27.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "90% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vtwevle()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled26.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "80% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void veleven()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled25.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "70% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vten()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled24.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "60% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vnine()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled23.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "50% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void veight()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled22.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "40% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vseven()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled21.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "30% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vsix()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled20.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "20% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vfive()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled19.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "10% transfer complete",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vfour()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Sending Infected files to Doris Servers",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vthree()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "Risk Level: HIGH",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vtwo()
        {
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "YWFU-WS to Anago France",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private async void vone()
        {
            _sound = new SoundPlayer(@"E:\publish\DorisServers\Untitled18.wav");
            _sound.Play();
            client = new FireSharp.FirebaseClient(config);
            try
            {

                var data = new Data
                {
                    notification = "LMR-SRTW Breach Detected",
                };
                FirebaseResponse response = await client.UpdateAsync("Client" + "/noti", data);
                Data updatedData = response.ResultAs<Data>();

            }
            catch
            {

            }
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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