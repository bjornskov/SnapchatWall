using System.Threading;

namespace SnapchatBot {
    public class Chat
    {
        private int _posY;
        
        public Chat(int _posY) {
            this._posY = _posY;
        }

        public bool HasUnreadPictureSnap() {
            string color = Utilities.GetColorStringFromPixel(Config.GetChatDotLeftEdgeDistance(), _posY);
            if (color.Equals("ff000000")) {
                Utilities.MakeSingleClickAtPixel(Config.GetBackToMessagesBoardScreenLeftEdgeDistance(), Config.GetBackToMessagesBoardScreenTopEdgeDistance());
                Thread.Sleep(2000);
                return HasUnreadPictureSnap();
            }
            
            return (color.Equals(Config.GetUnreadPictureSnapColor()));
        }
        
        public bool HasUnreadVideoSnap() {
            return (Utilities.GetColorStringFromPixel(Config.GetChatDotLeftEdgeDistance(), _posY).Equals(Config.GetUnreadVideoSnapColor()));
        }

        public void Click() {
            Utilities.MakeSingleClickAtPixel(Config.GetChatDotLeftEdgeDistance(), _posY);
        }
    }
}