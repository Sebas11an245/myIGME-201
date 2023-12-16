using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using Newtonsoft.Json;

namespace Question6
{
    public class PlayerSettings
    {
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public List<string> Inventory { get; set; }
        public string LicenseKey { get; set; }

        // Private constructor to prevent external instantiation
        private PlayerSettings() { }

        // Singleton instance
        private static PlayerSettings instance;

        // Method to get the singleton instance
        public static PlayerSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerSettings
                    {
                        Inventory = new List<string>()
                    };
                }
                return instance;
            }
        }

        // Method to load player settings from a file
        public void LoadSettings(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    instance = JsonConvert.DeserializeObject<PlayerSettings>(json);
                    Console.WriteLine("Settings loaded successfully.");
                }
                else
                {
                    Console.WriteLine("File not found. Using default settings.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading settings: {ex.Message}");
            }
        }

        // Method to save player settings to a file
        public void SaveSettings(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(instance, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);
                Console.WriteLine("Settings saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings: {ex.Message}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the singleton instance
            PlayerSettings playerSettings =  PlayerSettings.Instance;

            // Load settings from a file
            playerSettings.LoadSettings("playerSetting.json");

            // Display current settings
            DisplaySettings(playerSettings);

            // Modify settings (for example, increase level and update inventory)
            playerSettings.Level += 4;
            playerSettings.Hp += 99;
            playerSettings.Inventory.Add("spear");
            playerSettings.Inventory.Add("water bottle");
            playerSettings.Inventory.Add("hammer");
            playerSettings.Inventory.Add("sonic screwdriver");
            playerSettings.Inventory.Add("cannonball");
            playerSettings.Inventory.Add("wood");
            playerSettings.Inventory.Add("Scooby snack");
            playerSettings.Inventory.Add("Hydra");
            playerSettings.Inventory.Add("poisonous potato");
            playerSettings.Inventory.Add("dead bush");
            playerSettings.Inventory.Add("repair powder");
            playerSettings.LicenseKey = "DFGU99-1454";


            // Save settings to a file
            playerSettings.SaveSettings("playerSettings.json");

            // Display updated settings
            DisplaySettings(playerSettings);
        }

        // Display player settings
        static void DisplaySettings(PlayerSettings settings)
        {
            Console.WriteLine("Player Settings:");
            Console.WriteLine($"Player Name: {settings.PlayerName}");
            Console.WriteLine($"Level: {settings.Level}");
            Console.WriteLine($"HP: {settings.Hp}");
            Console.WriteLine("Inventory:");
            foreach (var item in settings.Inventory)
            {
                Console.WriteLine($"  {item}");
            }
            Console.WriteLine($"License Key: {settings.LicenseKey}");
            Console.WriteLine();
        }
    }
}
