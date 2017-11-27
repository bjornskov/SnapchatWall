using System;
using System.Collections.Generic;
using System.IO;

namespace SnapchatBot {
    /**
     * @author Dominik Dafert
     * @version 1.1.3
     * Created on 12.05.2016.
     * C# version
     * Copy the complete class to your project, if you want to use it. Also the imports!
     *
     * How to:
     * Initialize the ConfigManagerAPI with the constructor
     * You can make a static variable with the instance of it
     * And use it everywhere in your code
     *
     * Example:
     * MainClass {
     *      public static ConfigManagerAPI configmanager = null;
     *
     *      Main() {
     *        configmanager = new ConfigManagerAPI("C:\\", "config.txt");
     *
     *        configmanager.Set("dafnik_is", "cool");
     *      }
     * }
     *
     * ExampleClass {
     *      public void ExampleMethod() {
     *          string dafnikis = MainClass.configmanager.getString("dafnik_is");
     *      }
     * }
     */

    public class ConfigManagerAPI
    {
        private string fileName;
        private string filePath;

        private static bool Debug = false;
        private const string Pre = "[CM]";
        private const string Success = " - SUCCESSFUL - ";
        private const string Unsuccessful = " - Unsuccessful - ";

        private static bool CrashMessageOutPut = false;
        private const string CrashMessage = "Exception Message:\n";

        public ConfigManagerAPI(String filePath, String fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;

            if (!FileExists()) CreateConfig();
        }

        //--------------------------Costumize-------------------------------------

        private void onConfigCreate()
        {
            /**
            * This can also be empty
            * If you want to add something in config when you create it, enter it here
            * only execute once
            */

            this.Set("first_start", true);

            if (!Directory.Exists(this.filePath + "\\saved_snaps"))
                Directory.CreateDirectory(this.filePath + "\\saved_snaps");
        }


        //--------------------------Set-------------------------------------------

        public void Set(String path, String key)
        {
            // Set string
            // Check if config exists
            if (FileExists())
            {
                AddEntryInConfig(path, key);
            }
            else
            {
                CreateConfig();
                Set(path, key);
            }
        }

        public void Set(String path, bool key)
        {
            // Set boolean
            // Check if config exists
            if (FileExists())
            {
                string skey = "false";

                if (key)
                    skey = "true";


                AddEntryInConfig(path, skey);
            }
            else
            {
                CreateConfig();
                Set(path, key);
            }
        }

        public void Set(String path, int key)
        {
            // Set int
            // Check if file exists
            if (FileExists())
            {
                AddEntryInConfig(path, key.ToString());
            }
            else
            {
                CreateConfig();
                Set(path, key);
            }
        }

        public void Set(String path, double key)
        {
            // Set double
            // Check if file exists
            if (FileExists())
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                AddEntryInConfig(path, key.ToString());
            }
            else
            {
                CreateConfig();
                Set(path, key);
            }
        }


        //---------------------------READ--------------------------------------

        public bool GetBoolean(String path)
        {
            // Get boolean
            // Check if file exists
            if (FileExists())
            {
                String result = GetFromConfig(path);
                if (result != null)
                {
                    return result.Equals("true");
                }
                else
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "getBool | Path: " + path + " | Autoreturn: false");
                    return false;
                }
            }
            else
            {
                CreateConfig();
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "getBool | Reason: There is no config | Autoreturn: false");
                return false;
            }
        }

        public String GetString(String path)
        {
            // Get string
            // Check if file exists
            if (FileExists())
            {
                return GetFromConfig(path);
            }
            else
            {
                CreateConfig();
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "getString | Reason: There is no config | Autoreturn: null");
                return null;
            }
        }

        public int GetInt(String path)
        {
            // Get integer
            // Check if file exists
            if (FileExists())
            {
                try
                {
                    return int.Parse(GetFromConfig(path));
                }
                catch
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "getInt | Path: " + path + "Autoreturn: " + int.MinValue);
                    return int.MinValue;
                }
            }
            else
            {
                CreateConfig();
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "getInt | Reason: There is no config | Autoreturn: " + int.MinValue);
                return int.MinValue;
            }
        }

        public double GetDouble(String path)
        {
            // Get double
            // Check if file exists
            if (FileExists())
            {
                try
                {
                    return double.Parse(GetFromConfig(path));
                }
                catch
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "getDouble | Path: " + path + " | Autoreturn: " + double.MinValue);
                    return double.MinValue;
                }
            }
            else
            {
                CreateConfig();
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "getDouble | Reason: There is no config | Autoreturn: " + double.MinValue);
                return double.MinValue;
            }
        }


        //--------------------------Remove-------------------------------------

        public void RemoveEntry(String path)
        {
            // Remove entry from file
            // Check if file exists
            if (FileExists())
            {
                try
                {
                    // Line to remove
                    string linetoremove = null;

                    // Read file to list lines
                    List<String> lines = ReadFile();

                    // Check if lines contains path
                    foreach (String line in lines)
                    {
                        if (line.Contains(path))
                        {
                            linetoremove = line;
                            break;
                        }
                    }

                    // If linetoremove changed, remove it from list
                    if (linetoremove != null) lines.Remove(linetoremove);

                    // Write list lines to file
                    WriteFile(lines);
                }
                catch (Exception ex)
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "RemoveEntry | Path: " + path);
                    if (CrashMessageOutPut) Console.WriteLine(CrashMessage + ex.Message);
                }
            }
            else
            {
                CreateConfig();
                RemoveEntry(path);
            }
        }

        public void DeleteConfig(String confirm)
        {
            // Delete the file
            // Check if file exists
            if (FileExists())
            {
                // Check if confirm
                if (confirm.Equals("I really want to delete the config! There is no way back!"))
                {
                    File.Delete(filePath + fileName);

                    Directory.Delete(filePath);
                }
                else
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "DeleteConfig | Confirmcode: \"I really want to delete the config! There is no way back!\"");
                }
            }
            else
            {
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "File doesn't exists");
            }
        }


        //--------------------------Core---------------------------------------

        private void AddEntryInConfig(String path, String key)
        {
            // Add entry in config

            // Check if file exist
            if (FileExists())
            {
                try
                {
                    // Entry which is saved to the file
                    string newline = path + ":" + key;

                    // Read file
                    List<String> lines = ReadFile();

                    // If file contains new line, remove that
                    string todeleteline = null;

                    // If lines already exist, delete the old line
                    foreach (string line in lines)
                    {
                        // Strike where : cuts the string
                        int strike = line.IndexOf(':');

                        // Path which is in the file
                        string inFilePath = line.Substring(0, strike);

                        // Check if addPath is inFilePath
                        if (inFilePath.Equals(path))
                        {
                            //Set to delete line
                            todeleteline = line;
                            break;
                        }
                    }

                    // If todeleteline changed, remove it from list lines
                    if (todeleteline != null) lines.Remove(todeleteline);

                    // Add new line and path to list
                    lines.Add(newline);

                    // Write to file new list
                    WriteFile(lines);

                    if (Debug) Console.WriteLine(Pre + Success + "addInConfig | Path: " + path + " | Key: " + key);
                }
                catch (Exception ex)
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "addInConfig | Path: " + path + " | Key: " + key);
                    if (CrashMessageOutPut) Console.WriteLine(CrashMessage + ex.Message);
                }
            }
            else
            {
                CreateConfig();
                AddEntryInConfig(path, key);
            }
        }

        private String GetFromConfig(String path)
        {
            // Get from config

            // Check if file exists
            if (FileExists())
            {
                // Line which is searched
                String searchedline = null;

                try
                {
                    // Read file to lines
                    List<String> lines = ReadFile();

                    foreach (string line in lines)
                    {
                        // Strike where : cuts the path and the key
                        int strike = line.IndexOf(':');

                        // Path in the file
                        string inFilePath = line.Substring(0, strike);

                        // If line contains path
                        if (inFilePath.Equals(path))
                        {
                            // Set searched line
                            // ReSharper disable once StringIndexOfIsCultureSpecific.1
                            searchedline = line.Substring(line.IndexOf(":") + 1);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (Debug) Console.WriteLine(Pre + Unsuccessful + "GetFromConfig | Path: " + path + " | Autoreturn: null");
                    if (CrashMessageOutPut) Console.WriteLine(CrashMessage + ex.Message);
                }

                return searchedline;
            }
            else
            {
                CreateConfig();
                GetFromConfig(path);
                return null;
            }
        }

        private bool FileExists()
        {
            // Check if file exists
            return (Directory.Exists(filePath) && File.Exists(filePath + fileName));
        }

        private void CreateConfig()
        {
            // Create file

            try
            {
                // Create directory
                Directory.CreateDirectory(filePath);
                // Create file
                FileStream filestream = File.Create(filePath + fileName);
                // Close stream, which is created on File.Create
                filestream.Flush();
                filestream.Dispose();
                filestream.Close();

                // Set some values for Config create
                onConfigCreate();
            }
            catch (Exception ex)
            {
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "CreateConfig - try");
                if (CrashMessageOutPut) Console.WriteLine(CrashMessage + ex.Message);
                return;
            }

            if (Debug) Console.WriteLine(Pre + Success + "CreateConfig");
        }

        private List<String> ReadFile()
        {
            // Read the file

            // Inizialize list
            List<String> lines = new List<String>();

            // Read all lines to list from file
            try
            {
                using (StreamReader reader = new StreamReader(filePath + fileName))
                {
                    while (reader.Peek() >= 0)
                    {
                        lines.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "ReadFile");
                if (CrashMessageOutPut) Console.WriteLine(CrashMessage + ex.Message);
            }

            // Return list
            return lines;
        }

        private void WriteFile(List<String> lines)
        {
            // Write list to file

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath + fileName))
                {
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Debug) Console.WriteLine(Pre + Unsuccessful + "WriteFile");
                if (CrashMessageOutPut) Console.WriteLine(CrashMessage + ex.Message);
            }
        }

        public override string ToString()
        {
            return "This is the ConfigManagerAPI! \nDeveloped by Dafnik! \nUnder Apache 2.0 License!";
        }
    }
}