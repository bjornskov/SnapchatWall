using System;
using System.Collections.Generic;
using System.Threading;

namespace SnapchatBot {
    public class SnapchatListenerThread {
        private Thread _thread;
        private bool _running = false;

        //private DateTime _threadStartedTime;
        //private DateTime _lastSnapTime;
        
        private List<Chat> _chats = new List<Chat>();

        
        public SnapchatListenerThread() {           
            this._thread = new Thread(Run); 
        }

        public void Start() {
            for (int i = Config.GetChatsCount(); i > -1; i--) {
                _chats.Add(new Chat(Config.GetChatDotTopEdgeDistance(i)));
            }
            
            //this._threadStartedTime = DateTime.Now;
            this._running = true;
            this._thread.Start();
        }

        public void Stop() {
            this._running = false;
            this._thread.Abort();
            this._thread.Interrupt();
            
        }
        
        private bool ListenerIsTooOld() {
            /*TimeSpan ts = DateTime.Now - this._threadStartedTime;
            int differenceInMinutes = ts.Minutes;
            if (differenceInMinutes >= 5) {
                return true;
            }*/
            return false;
        }

        private void Run() {
            while (_running) {
                if (ListenerIsTooOld()) {
                    this.Stop();
                }

                foreach (Chat chat in _chats) {
                    Perform(chat);
                }

                Utilities.Write("Refreshing...");
                
                try {
                    Thread.Sleep(1000);
                }
                catch (Exception) {
                    
                }
            }
        }

        private void Perform(Chat chat) {
            if (chat.HasUnreadPictureSnap()) {
                Thread.Sleep(200);
                
                if (!chat.HasUnreadPictureSnap()) {
                    return;
                }
            
                Utilities.Write("Found (a) new Photo Snap(s)!");
            } else if (chat.HasUnreadVideoSnap()) {
                Thread.Sleep(200);

                if (!chat.HasUnreadVideoSnap()) {
                    return;
                }
                
                Utilities.Write("Found (a) new Video Snap(s)");
            }
            else {
                return;
            }

            Utilities.Write("Starting Screenshot process...");
            while (true) {
                chat.Click();
                Thread.Sleep(900);
                if (!Utilities.IsSnapStillOpen()) {
                    break;
                }
                
                Utilities.MakeScreenshot();
                Utilities.Write("Made Screenshot!");
            }

            Utilities.Write("Finished making Screenshots!");
            
        }
    }
}