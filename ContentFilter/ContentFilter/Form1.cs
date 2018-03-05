using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ContentFilter
{
    public partial class Form1 : Form
    {
        static string unfilteredSnaps = @"C:\ContentFilter\unfilteredSnaps\";
        static string filteredAcceptedSnaps = @"C:\ContentFilter\accepted\";
        static string filteredUnaccptedSnaps = @"C:\ContentFilter\declined\";
        static string currentPicture = null;

        public Form1()
        {
            InitializeComponent();

            InitializeTimer();
        }

        private void button_decline_Click(object sender, EventArgs e)
        {
            decline();
        }

        private void decline()
        {
            if (currentPicture != null)
            {
                try
                {
                    timer.Stop();
                    pictureBox.Image.Dispose();
                    pictureBox.Image = null;

                    DateTime foo = DateTime.Now;
                    string destFile = System.IO.Path.Combine(Form1.filteredUnaccptedSnaps, ((DateTimeOffset)foo).ToUnixTimeSeconds() + ".png");
                    File.Copy(currentPicture, destFile, true);
                    File.Delete(currentPicture);
                    timer.Start();
                } catch
                {
                    timer.Stop();
                    timer.Start();
                }
            }
        }

        private void button_accept_Click(object sender, EventArgs e)
        {
            accept();
        }

        private void accept()
        {
            if (currentPicture != null)
            {
                try
                {
                    timer.Stop();
                    pictureBox.Image.Dispose();
                    pictureBox.Image = null;

                    DateTime foo = DateTime.Now;
                    string destFile = System.IO.Path.Combine(Form1.filteredAcceptedSnaps, ((DateTimeOffset)foo).ToUnixTimeSeconds() + ".png");
                    File.Copy(currentPicture, destFile, true);
                    File.Delete(currentPicture);
                    timer.Start();
                } catch
                {
                    timer.Stop();
                    timer.Start();
                }
            }
        }

        private void InitializeTimer()
        {
            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer_Tick);
  
            timer.Enabled = true;         
        }

        private void Timer_Tick(object Sender, EventArgs e)
        {
            if(pictureBox.Image == null)
            {
                try
                {
                    DirectoryInfo d = new DirectoryInfo(Form1.unfilteredSnaps);//Assuming Test is your Folder
                    FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
                    foreach (FileInfo file in Files)
                    {
                        Form1.currentPicture = Form1.unfilteredSnaps + file.Name;

                        pictureBox.Image = GetCopyImage(Form1.currentPicture);
                        break;
                    }
                } catch { }
            }
        }

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.J:
                    {
                        accept();
                        break;
                    }
                case Keys.N:
                    {
                        decline();
                        break;
                    }
              
                default:
                    {
                        break;
                    }
            }
        }
    }
}
