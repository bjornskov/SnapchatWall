using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;


namespace SnapchatBot {
    public class Utilities {
        
        #region getColor
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        private static Color GetColorFromPixel(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                (int)(pixel & 0x0000FF00) >> 8,
                (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        public static string GetColorStringFromPixel(int x, int y) {
            return Utilities.GetColorFromPixel(x, y).Name;
        }
        #endregion
        
        #region makeClick
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        // ReSharper disable once InconsistentNaming
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        // ReSharper disable once InconsistentNaming
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public static void MakeSingleClickAtPixel(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static void MakeClickDownAtPixel(int x, int y) {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }

        public static void MakeClickUpAtPixel(int x, int y) {
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static void MoveCursor(int x, int y) {
            SetCursorPos(x, y);
        }

        #endregion

        public static bool IsSnapStillOpen() {
            if(!Utilities.GetColorFromPixel(Config.GetIsStillInSnapLeftEdgeDistance(),
                    Config.GetIsStillInSnapTopEdgeDistance()).Equals(Config.GetReadSnapColor())) {
                return false;

            } else if(!Utilities.GetColorFromPixel(Config.GetIsStillInSnap1LeftEdgeDistance(), Config.GetIsStillInSnap1TopEdgeDistance()).Equals(Config.GetIsStillInSnap1Color()))
            {
                return false;

            } else if(Utilities.GetColorFromPixel(Config.GetIsStillInSnap2LeftEdgeDistance(), Config.GetIsStillInSnap2TopEdgeDistance()).Equals(Config.GetIsStillInSnap2Color()))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static void MakeScreenshot() {
            for (int i = 0; i < 40; i++) {
                if (Utilities.IsSnapStillOpen()) {
                    try
                    {
                        DateTime foo = DateTime.Now;
                        long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

                        Bitmap bmp = new Bitmap(Config.GetPictureWidth(), Config.GetPictureHeight());
                        Graphics gr = Graphics.FromImage(bmp);
                        gr.CopyFromScreen(Config.GetPictureLeftEdgeDistance(), Config.GetPictureTopEdgeDistance(), 0, 0, bmp.Size);
                        bmp.Save(Config.GetSavedSnapsPath() + unixTime + ".png", ImageFormat.Png);

                        Program.SavedSnapsCount++;
                        
                        break;
                    } catch (Exception)
                    {
                    }
                }
                
                Thread.Sleep(100);
            }
        }
        
        /* Useless because not used
        public static void MakeRefreshSwipe() {
            new SwipeVertical(Config.GetRefreshLeftEdgeDistance(), Config.GetRefreshTopEdgeDistance(),
                Config.GetRefreshSwipeDistance(), Config.GetSwipeSpeed(), Config.GetSleepTime());
            
        }
        
        public static void MakeLeftSwipe() {
            new SwipeHorizontal(Config.GetSwipeLeftLeftEdgeDistance(), Config.GetSwipeLeftTopEdgeDistance(),
                Config.GetSwipeLeftSwipeDistance(), Config.GetSwipeSpeed(), Config.GetSleepTime());
            
        }*/

        #region Write

        public static void WriteLine(Prefix prefix, string message) {
            switch (prefix) {
                case Prefix.STARTUP:
                    Console.WriteLine("[Startup] " + message);
                    break;
                case Prefix.CONFIG:
                    Console.WriteLine("[Config] " + message);
                    break;
                default:
                    Console.WriteLine(message);
                    break;
            }
        }
        
        public static void Write(Prefix prefix, string message) {
            switch (prefix) {
                case Prefix.STARTUP:
                    Console.Write("[Startup] " + message);
                    break;
                case Prefix.CONFIG:
                    Console.Write("[Config] " + message);
                    break;
                default:
                    Console.Write(message);
                    break;
            }
        }
        
        private static int _currentVisibleMessagesCount = 0;
        private static int _standartVisibleMessages = 11;
        private static int maxMessagesVisible = 15;
        private static void CheckConsole() {
            if (_currentVisibleMessagesCount > maxMessagesVisible) {
                Console.Clear();
                WriteProgramInformations();
                WriteStopInformations();
                _currentVisibleMessagesCount = 0;
            }
            _currentVisibleMessagesCount++;
            Console.CursorTop = _standartVisibleMessages + _currentVisibleMessagesCount;
        }
        
        public static void Write(string message) {
            CheckConsole();
            
            Console.WriteLine(message);
        }

        public static void WriteProgramInformations() {
            Console.WriteLine("SnapchatWall");
            Console.WriteLine("Version: v" + Program.GetVersion());
            Console.WriteLine("Author: Dominik Dafert");
            Console.WriteLine("Website: https://dafnik.me");
            Console.WriteLine("Source Code: https://github.com/Dafnik/SnapchatWall");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("Informations:");
            Console.WriteLine("All config files and saved snaps are stored in 'C:\\snapchatmanager'");
            Console.WriteLine("Saved Snaps in this session: " + Program.SavedSnapsCount);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public static void WriteStopInformations() {
            Console.WriteLine("Press any key to stop the program!");
            Console.WriteLine("----------------------------------------------------------------------");
        }
        #endregion
        
    }
}