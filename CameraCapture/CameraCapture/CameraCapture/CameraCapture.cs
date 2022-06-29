using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.IO;
using System.Drawing.Imaging;

namespace CameraCapture
{
    public partial class CameraCapture : Form
    {

        private Capture capture;
        private bool captureInProgress;


        public CameraCapture()
        {
            InitializeComponent();
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Image<Bgr, Byte> ImageFrame = capture.QuerySmallFrame();


            CamImgBox.Image = ImageFrame;
            //  Image<Gray, Byte> grayFrame = capture.QuerySmallFrame().Convert<Gray, Byte>();
            // grayBox.Image = grayFrame;

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {

            #region if capture is not created, create it now
            if (capture == null)
            {
                try
                {
                    capture = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }
            #endregion

            if (capture != null)
            {
                if (captureInProgress)
                {
                    btnStart.Text = "Start!"; //
                    Application.Idle -= ProcessFrame;
                }
                else
                {
                    btnStart.Text = "Stop";
                    Application.Idle += ProcessFrame;
                }

                captureInProgress = !captureInProgress;
            }
        }

        private void ReleaseData()
        {
            if (capture != null)
                capture.Dispose();
        }

        private void CameraCapture_Load(object sender, EventArgs e)
        {

        }

        private void Capturebtn_Click(object sender, EventArgs e)
        {
            CaptureBox.Image = CamImgBox.Image;
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG(*.JPG|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {


                int width = Convert.ToInt32(CaptureBox.Width);
                int height = Convert.ToInt32(CaptureBox.Height);
                Bitmap bmp = new Bitmap(width, height);
                CaptureBox.DrawToBitmap(bmp, new Rectangle(0, 0, Width, Height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);



            }

        }

        private void CaptureBox_Click(object sender, EventArgs e)
        {

        }

        private void CamImgBox_Click(object sender, EventArgs e)
        {

        }
    }
}