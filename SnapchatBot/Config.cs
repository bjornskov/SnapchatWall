using System;

namespace SnapchatBot {
    public enum Prefix { STARTUP, CONFIG }
    
    public class Config {
        
        #region Path

        public static string GetGeneralPath() {
            return "C:\\snapchatmanager\\";
        }
        
        public static ConfigManagerAPI ConfigManagerApi;

        public static string GetSavedSnapsPath() {
            return GetGeneralPath() + "saved_snaps\\";
        }
        #endregion

        #region Chat Positions & Length
        public static int GetChatsCount() {
            return ConfigManagerApi.GetInt("chats_count");
        }
        
        public static int GetChatDotLeftEdgeDistance() {
            return ConfigManagerApi.GetInt("chat_dot_left_edge_distance");
        }

        public static int GetChatDotTopEdgeDistance(int slot) {
            return ConfigManagerApi.GetInt("chats_positionY." + slot);
        }
        
        public static int GetIsStillInSnapLeftEdgeDistance() {
            return ConfigManagerApi.GetInt("is_in_snap_left_edge_distance");
        }
        
        public static int GetIsStillInSnapTopEdgeDistance() {
            return ConfigManagerApi.GetInt("is_in_snap_top_edge_distance");
        }
        #endregion

        #region Color
        public static string GetUnreadPictureSnapColor() {
            return ConfigManagerApi.GetString("color_unread_chat");
        }
        
        public static string GetUnreadVideoSnapColor() {
            return ConfigManagerApi.GetString("color_unread_video");
        }

        public static string GetReadSnapColor() {
            return ConfigManagerApi.GetString("color_read");
        }
        #endregion

        #region Picture
        public static int GetPictureHeight() {
            return ConfigManagerApi.GetInt("picture_height");
        }
        
        public static int GetPictureWidth() {
            return ConfigManagerApi.GetInt("picture_width");
        }
        
        public static int GetPictureTopEdgeDistance() {
            return ConfigManagerApi.GetInt("picture_top_edge_distance");
        }
        
        public static int GetPictureLeftEdgeDistance() {
            return ConfigManagerApi.GetInt("picture_left_edge_distance");
        }
        #endregion
        
        #region Swipe
        /* Useless because not used
        public static int GetRefreshLeftEdgeDistance() {
            return ConfigManagerApi.GetInt("refresh_start_left_edge_distance");
        }
        
        public static int GetRefreshTopEdgeDistance() {
            return ConfigManagerApi.GetInt("refresh_start_top_edge_distance");
        }
         
        public static int GetRefreshSwipeDistance() {
            return ConfigManagerApi.GetInt("refresh_distance_to_end");
        }
        
        public static int GetSwipeLeftLeftEdgeDistance() {
            return ConfigManagerApi.GetInt("swipeleft_start_left_edge_distance");
        }
        
        public static int GetSwipeLeftTopEdgeDistance() {
            return ConfigManagerApi.GetInt("swipeleft_start_top_edge_distance");
        }
        
        public static int GetSwipeLeftSwipeDistance() {
            return ConfigManagerApi.GetInt("swipeleft_distance_to_end");
        }
        
        public static int GetSwipeSpeed() {
            return ConfigManagerApi.GetInt("move_speed");
        }
        
        public static int GetSleepTime() {
            return ConfigManagerApi.GetInt("move_sleepTime");
        }*/
        #endregion

        #region Back to messages screen
        public static int GetBackToMessagesBoardScreenLeftEdgeDistance() {
            return ConfigManagerApi.GetInt("backToMessagesScreen_left_edge_distance");
        }
        
        public static int GetBackToMessagesBoardScreenTopEdgeDistance() {
            return ConfigManagerApi.GetInt("backToMessagesScreen_top_edge_distance");
        }
        #endregion
        
        #region set Parameters
        public static void SetStandartValues() {
            Config.ConfigManagerApi.Set("chat_dot_left_edge_distance", 44);

            Config.ConfigManagerApi.Set("chats_count", 10);
            Config.ConfigManagerApi.Set("chats_positionY.0", 115);
            Config.ConfigManagerApi.Set("chats_positionY.1", 168);
            Config.ConfigManagerApi.Set("chats_positionY.2", 220);
            Config.ConfigManagerApi.Set("chats_positionY.3", 273);
            Config.ConfigManagerApi.Set("chats_positionY.4", 325);
            Config.ConfigManagerApi.Set("chats_positionY.5", 378);
            Config.ConfigManagerApi.Set("chats_positionY.6", 430);
            Config.ConfigManagerApi.Set("chats_positionY.7", 482);
            Config.ConfigManagerApi.Set("chats_positionY.8", 534);
            Config.ConfigManagerApi.Set("chats_positionY.9", 586);

            Config.ConfigManagerApi.Set("is_in_snap_left_edge_distance", 200);
            Config.ConfigManagerApi.Set("is_in_snap_top_edge_distance", 650);

            Config.ConfigManagerApi.Set("picture_width", 390);
            Config.ConfigManagerApi.Set("picture_height", 650);
            Config.ConfigManagerApi.Set("picture_left_edge_distance", 25);
            Config.ConfigManagerApi.Set("picture_top_edge_distance", 30);

            Config.ConfigManagerApi.Set("color_unread_chat", "fff23c57");
            Config.ConfigManagerApi.Set("color_read", "ffffffff");
            Config.ConfigManagerApi.Set("color_unread_video", "ffa05dcd");

            /* Useless because not used
            Config.ConfigManagerApi.Set("refresh_start_left_edge_distance", 60);
            Config.ConfigManagerApi.Set("refresh_start_top_edge_distance", 100);
            Config.ConfigManagerApi.Set("refresh_distance_to_end", 500);
            Config.ConfigManagerApi.Set("move_speed", 20);
            Config.ConfigManagerApi.Set("move_sleepTime", 20);
            
            Config.ConfigManagerApi.Set("swipeleft_start_left_edge_distance", 30);
            Config.ConfigManagerApi.Set("swipeleft_start_top_edge_distance", 300);
            Config.ConfigManagerApi.Set("swipeleft_distance_to_end", 380);*/
            
            Config.ConfigManagerApi.Set("backToMessagesScreen_left_edge_distance", 50);
            Config.ConfigManagerApi.Set("backToMessagesScreen_top_edge_distance", 690);
        }

        public static void SetParameters() {
            Console.Clear();
            
            #region Snaps opening positions
            int chat_dot_left_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance from your left edge of the screen to the " +
                                               "chat dot in Snapchat as integer: ");
                try {
                    chat_dot_left_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("chat_dot_left_edge_distance", chat_dot_left_edge_distance);

            int chats_count;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter how many chat dots you have on your screen as integer: ");
                try {
                    chats_count = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("chats_count", chats_count);

            for (int i = 0; i < chats_count; i++) {
                int chats_positionY;
                while (true) {
                    Utilities.Write(Prefix.CONFIG, "Now enter your {0} chat distance to your top edge of " +
                                                   "the screen as integer: ");
                    try {
                        chats_positionY = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception) {
                        Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                    }
                }
                Config.ConfigManagerApi.Set("chats_positionY." + i, chats_positionY);
            }
            #endregion
            
            #region Is in snap positions
            int is_in_snap_left_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance to your left edge on your " +
                              "screen where the bot should check for the white snapchat background color as integer: ");
                try {
                    is_in_snap_left_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("is_in_snap_left_edge_distance", is_in_snap_left_edge_distance);
            
            int is_in_snap_top_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance to your top edge on your " +
                              "screen where the bot should check for the white snapchat background color as integer: ");
                try {
                    is_in_snap_top_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("is_in_snap_top_edge_distance", is_in_snap_top_edge_distance);
            #endregion positions
            
            #region Picture positions
            int picture_width;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter your picture width as integer: ");
                try {
                    picture_width = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("picture_width", picture_width);
            
            int picture_height;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter your picture height as integer: ");
                try {
                    picture_height = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("picture_height", picture_height);
            
            int picture_left_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter your distance to the left edge of your screen where " +
                              "the picture starts as integer: ");
                try {
                    picture_left_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("picture_left_edge_distance", picture_left_edge_distance);
            
            int picture_top_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter your distance to the top edge of your screen where " +
                              "the picture starts as integer: ");
                try {
                    picture_top_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("picture_top_edge_distance", picture_top_edge_distance);
            #endregion
            
            #region Dot colors
            string color_unread_chat;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the color from unread snaps as string (DEFAULT: fff23c57): ");
                try {
                    color_unread_chat = Console.ReadLine();
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("color_unread_chat", color_unread_chat);
            
            string color_read;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the color from read snaps as string (DEFAULT: ffffffff): ");
                try {
                    color_read = Console.ReadLine();
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("color_read", color_read);
            
            string color_unread_video;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the color from unread video snaps as string (DEFAULT: ffa05dcd): ");
                try {
                    color_unread_video = Console.ReadLine();
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("color_unread_video", color_unread_video);
            
            int refresh_start_left_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance from the left edge of your screen " +
                              "where the refresh swipe should start as integer: ");
                try {
                    refresh_start_left_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("refresh_start_left_edge_distance", refresh_start_left_edge_distance);
            #endregion
            
            /* Use less because not used
            int refresh_start_top_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance from the top edge of your screen " +
                              "where the refresh swipe should start as integer: ");
                try {
                    refresh_start_top_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("refresh_start_top_edge_distance", refresh_start_top_edge_distance);
            
            int refresh_distance_to_end;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance which should be traversed as integer: ");
                try {
                    refresh_distance_to_end = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("refresh_distance_to_end", refresh_distance_to_end);
            
            
            int swipeleft_start_left_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance from the left edge of your screen " +
                              "where the left swipe should start as integer: ");
                try {
                    swipeleft_start_left_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("swipeleft_start_left_edge_distance", swipeleft_start_left_edge_distance);
            
            int swipeleft_start_top_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance from the top edge of your screen " +
                              "where the left swipe should start as integer: ");
                try {
                    swipeleft_start_top_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("swipeleft_start_top_edge_distance", swipeleft_start_top_edge_distance);
            
            int swipeleft_distance_to_end;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter the distance which should be traversed as integer: ");
                try {
                    swipeleft_distance_to_end = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("swipeleft_distance_to_end", swipeleft_distance_to_end);

            Config.ConfigManagerApi.Set("refresh_speed", 20);
            Config.ConfigManagerApi.Set("refresh_sleepTime", 20);
            */
            
            #region Back to messages screen
            int backToMessagesScreen_left_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter your distance to the left edge of your screen where " +
                                               "the message tab button is located as integer: ");
                try {
                    backToMessagesScreen_left_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("backToMessagesScreen_left_edge_distance", backToMessagesScreen_left_edge_distance);
            
            int backToMessagesScreen_top_edge_distance;
            while (true) {
                Utilities.Write(Prefix.CONFIG, "Please enter your distance to the top edge of your screen where " +
                                               "the message tab button is located as integer: ");
                try {
                    backToMessagesScreen_top_edge_distance = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception) {
                    Utilities.WriteLine(Prefix.CONFIG, "Wrong input, please enter it again!");
                }
            }
            Config.ConfigManagerApi.Set("backToMessagesScreen_top_edge_distance", backToMessagesScreen_top_edge_distance);
            #endregion
            
            Utilities.WriteLine(Prefix.CONFIG, "Thank you for finishing the setup!");
            Utilities.WriteLine(Prefix.CONFIG, "You will find the config file in C:/snapchatmanager");
            Utilities.WriteLine(Prefix.CONFIG, "Press any key to continue...");
        }
        #endregion
    }
}