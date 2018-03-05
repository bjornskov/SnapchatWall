using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Presentation
{
    public partial class Presentation : Form
    {
        static string notSeenfilteredSnaps = @"C:\Presentation\notSeen\";
        static string alreadySeenfilteredSnaps = @"C:\Presentation\alreadySeen\";

        static bool debugMode = false;

        public Presentation()
        {
            InitializeComponent();

            if (!debugMode)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer.Interval = 5000;
            timer.Tick += new EventHandler(Timer_Tick);
            
            timer.Enabled = true;
        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(Presentation.notSeenfilteredSnaps);
                FileInfo[] Files = d.GetFiles("*.png");
                foreach (FileInfo file in Files)
                {
                    string currentPicture_l = Presentation.notSeenfilteredSnaps + file.Name;

                    pictureBox.Image = GetCopyImage(currentPicture_l);

                    DateTime foo = DateTime.Now;
                    string destFile = Path.Combine(Presentation.alreadySeenfilteredSnaps, ((DateTimeOffset)foo).ToUnixTimeSeconds() + ".png");
                    File.Copy(currentPicture_l, destFile, true);
                    File.Delete(currentPicture_l);

                    return;
                }

                d = new DirectoryInfo(Presentation.alreadySeenfilteredSnaps);
                Files = d.GetFiles("*.png");
                List<FileInfo> fileInfos = new List<FileInfo>();
                foreach (FileInfo file in Files)
                {
                    fileInfos.Add(file);
                }

                if (fileInfos.Count > 0)
                {
                    int rand = new Random().Next(0, fileInfos.Count);

                    string currentPicture = Presentation.alreadySeenfilteredSnaps + fileInfos[rand].Name;

                    pictureBox.Image = GetCopyImage(currentPicture);
                }
            } catch { }
        }

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
