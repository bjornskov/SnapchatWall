using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.IO;

namespace Presentation
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string notSeenfilteredSnaps = @"C:\Presentation\notSeen\";
        static string alreadySeenfilteredSnaps = @"C:\Presentation\alreadySeen\";
        static string cache = @"C:\Presentation\cache\";

        static bool debugMode = false;

        public MainWindow()
        {
            InitializeComponent();

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }
       
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(MainWindow.notSeenfilteredSnaps);
                FileInfo[] Files = d.GetFiles("*.png");
                foreach (FileInfo file in Files)
                {
                    string currentPicture_l = MainWindow.notSeenfilteredSnaps + file.Name;

                    imageBox.Source = GetCopyImage(currentPicture_l);

                    DateTime foo = DateTime.Now;
                    string destFile = System.IO.Path.Combine(MainWindow.alreadySeenfilteredSnaps, ((DateTimeOffset)foo).ToUnixTimeSeconds() + ".png");
                    File.Copy(currentPicture_l, destFile, true);
                    File.Delete(currentPicture_l);

                    return;
                }

                d = new DirectoryInfo(MainWindow.alreadySeenfilteredSnaps);
                Files = d.GetFiles("*.png");
                List<FileInfo> fileInfos = new List<FileInfo>();
                foreach (FileInfo file in Files)
                {
                    fileInfos.Add(file);
                }

                if (fileInfos.Count > 0)
                {
                    int rand = new Random().Next(0, fileInfos.Count);

                    string currentPicture = MainWindow.alreadySeenfilteredSnaps + fileInfos[rand].Name;

                    BitmapImage source = new BitmapImage();
                    source.BeginInit();
                    source.UriSource = new Uri(currentPicture);
                    source.EndInit();

                    imageBox.Source = source;
                }
            }
            catch { }
        }

        private ImageSource GetCopyImage(string path)
        {
            DateTime foo = DateTime.Now;
            string destFile = System.IO.Path.Combine(MainWindow.cache, ((DateTimeOffset)foo).ToUnixTimeSeconds() + ".png");
            File.Copy(path, destFile, true);

            BitmapImage source = new BitmapImage();
            source.BeginInit();
            source.UriSource = new Uri(destFile);
            source.EndInit();

            return source;
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
