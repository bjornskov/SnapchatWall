using System;

namespace SnapchatBot {
    public enum Prefix {
        STARTUP,
        CONFIG
    }

    public enum Type {
        INT,
        STRING
    }

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

        public static int GetIsStillInSnap1LeftEdgeDistance()
        {
            return ConfigManagerApi.GetInt("is_in_snap_1_left_edge_distance");
        }

        public static int GetIsStillInSnap1TopEdgeDistance()
        {
            return ConfigManagerApi.GetInt("is_in_snap_1_top_edge_distance");
        }

        public static string GetIsStillInSnap1Color()
        {
            return ConfigManagerApi.GetString("is_in_snap_1_color");
        }

        public static int GetIsStillInSnap2LeftEdgeDistance()
        {
            return ConfigManagerApi.GetInt("is_in_snap_2_left_edge_distance");
        }

        public static int GetIsStillInSnap2TopEdgeDistance()
        {
            return ConfigManagerApi.GetInt("is_in_snap_2_top_edge_distance");
        }

        public static string GetIsStillInSnap2Color()
        {
            return ConfigManagerApi.GetString("is_in_snap_2_color");
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

            Config.ConfigManagerApi.Set("is_in_snap_left_edge_distance", 326);
            Config.ConfigManagerApi.Set("is_in_snap_top_edge_distance", 114);

            Config.ConfigManagerApi.Set("is_in_snap_1_left_edge_distance", 216);
            Config.ConfigManagerApi.Set("is_in_snap_1_top_edge_distance", 71);
            Config.ConfigManagerApi.Set("is_in_snap_1_color", "ff0eadff");

            Config.ConfigManagerApi.Set("is_in_snap_2_left_edge_distance", 115);
            Config.ConfigManagerApi.Set("is_in_snap_2_top_edge_distance", 699);
            Config.ConfigManagerApi.Set("is_in_snap_2_color", "ffced4da");

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

            SetParameter("Enter the distance from your left edge of the screen to the chat dots in Snapchat as integer",
                Type.INT, "chat_dot_left_edge_distance");
            
            SetParameter("Enter how many chat dots you have on your screen as integer",
                Type.INT, "chats_count");

            int chats_count = ConfigManagerApi.GetInt("chats_count");
            
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
            
            SetParameter("Enter the distance to your left edge on your screen where the bot should check for for the " +
                         "white snapchat background color as integer", Type.INT, "is_in_snap_left_edge_distance");

            SetParameter("Enter the distance from your top edge of the screen where the bot should check for the white " +
                         "snapchat background color as integer", Type.INT, "is_in_snap_top_edge_distance");

            #endregion positions

            #region Picture positions

            SetParameter("Enter the width of the open snap as integer", Type.INT, "picture_width");
            
            SetParameter("Enter the height of the open snap as integer", Type.INT, "picture_height");

            SetParameter("Enter the distance from your left edge of the screen where the picture starts as integer", 
                Type.INT, "picture_left_edge_distance");

            SetParameter("Enter the distance from your top edge of the screen where the picture starts as integer", 
                Type.INT, "picture_top_edge_distance");          

            #endregion

            #region Dot colors

            SetParameter("Enter the color of unread snaps as string (DEFAULT: fff23c57)", 
                Type.STRING, "color_unread_chat");  
            
            SetParameter("Enter the color of read snaps as string (DEFAULT: ffffffff)", 
                Type.STRING, "color_read");

            SetParameter("Enter the color of unread video snaps as string (DEFAULT: ffa05dcd)", 
                Type.STRING, "color_unread_video");
            

            #endregion
            
            /* Useless because not used
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

            SetParameter("Enter the distance to the left edge of your screen where the message tab button is located as integer", 
                Type.INT, "backToMessagesScreen_left_edge_distance");  
            
            SetParameter("Enter the distance to the top edge of your screen where the message tab button is located as integer", 
                Type.INT, "backToMessagesScreen_top_edge_distance");  

            #endregion

            Utilities.WriteLine(Prefix.CONFIG, "Thank you for finishing the setup!");
            Utilities.WriteLine(Prefix.CONFIG, "You will find the config file in C:/snapchatmanager");
            Utilities.WriteLine(Prefix.CONFIG, "Press any key to continue...");
        }
        
        private static void SetParameter(string question, Type type, string databasevalue) {
            object value = null;
            while (true) {
                Utilities.Write(Prefix.CONFIG, question + ": ");

                try {
                    if (type == Type.INT) {
                        var int32 = (int) value;
                        value = Convert.ToInt32(Console.ReadLine());
                        break;
                    } else {
                        var readLine = (string) value;
                        value = Console.ReadLine();
                        break;
                    }
                }
                catch (Exception) {
                    Utilities.Write(Prefix.CONFIG, "ERROR! The needed value is a ");
                    if (type == Type.INT) {
                        Console.Write("number: ");
                    }
                    else {
                        Console.Write("string: ");
                    }
                }
            }
            Config.ConfigManagerApi.Set(databasevalue, ((string) value));
            Utilities.Write(Prefix.CONFIG, "Successful written " + databasevalue + "!");
        }

        #endregion
    }
}