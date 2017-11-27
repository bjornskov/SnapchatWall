using System;

namespace SnapchatBot {
    internal class Program {
        public static string GetVersion() {
            return "a-0.3";
        }

        public static int SavedSnapsCount = 0;

        public static void Main(string[] args) {
            Console.SetBufferSize(90, 9001);
            Console.SetWindowSize(91, 30);

            Config.ConfigManagerApi = new ConfigManagerAPI(Config.GetGeneralPath(), "config.yml");

            StartUpCheck();

            Utilities.WriteLine(Prefix.STARTUP, "Press [R] if you want to create a new config or press another button to start the program...");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.R) {
                Config.ConfigManagerApi.Set("first_start", true);
                StartUpCheck();
            }
            Console.Clear();
            
            Utilities.WriteProgramInformations();
            Utilities.WriteLine(Prefix.STARTUP, "Press any key to start the program!");
            Utilities.WriteLine(Prefix.STARTUP, "Enjoy your snaps....");

            Console.ReadKey();

            SnapchatListenerThread snapchatListenerThread = new SnapchatListenerThread();
            snapchatListenerThread.Start();

            Console.Clear();
            Utilities.WriteProgramInformations();

            Utilities.WriteStopInformations();

            Console.ReadKey();
            snapchatListenerThread.Stop();
        }

        private static void StartUpCheck() {
            Console.Clear();
            Utilities.WriteLine(Prefix.STARTUP, "Checking config...");
            if (Config.ConfigManagerApi.GetBoolean("first_start")) {
                while (true) {
                    Utilities.WriteLine(Prefix.STARTUP, "It looks like you are running SnapchatWallManager for the first time...");
                    Utilities.WriteLine(Prefix.STARTUP, "Before you can start using it you have to set some settings first.");
                    Utilities.WriteLine(Prefix.STARTUP, "Press [ENTER] to create your own settings or [SPACE] to use default values!");
                    ConsoleKey key = Console.ReadKey(true).Key;

                    switch (key) {
                        case ConsoleKey.Spacebar:
                            Utilities.WriteLine(Prefix.STARTUP, "Creating config...");
                            Config.SetStandartValues();
                            Config.ConfigManagerApi.Set("first_start", false);
                            Utilities.WriteLine(Prefix.STARTUP, "Created config successful!");
                            return;
                        case ConsoleKey.Enter:
                            Utilities.WriteLine(Prefix.STARTUP, "Please enter your parameters: ");
                            Config.SetParameters();
                            Config.ConfigManagerApi.Set("first_start", false);
                            Utilities.WriteLine(Prefix.STARTUP, "Created config successful!");
                            return;
                        default:
                            Console.Clear();
                            break;
                    }
                }
            }
            else {
                Utilities.WriteLine(Prefix.STARTUP, "Config is alright!");
            }
        }
    }
}