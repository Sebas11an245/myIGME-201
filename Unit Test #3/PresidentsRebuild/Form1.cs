using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresidentsRebuild
{
    public class PresidentsForm : Form
    {
        private ListBox presidentsListBox;
        private TextBox presidentNumberTextBox;
        private PictureBox presidentPhotoPictureBox;
        private ComboBox partyFilterComboBox;
        private WebBrowser wikiWebBrowser;
        private Button exitButton;
        private Timer timer;

        public PresidentsForm()
        {
            // Initialize controls
            presidentsListBox = new ListBox();
            presidentNumberTextBox = new TextBox();
            presidentPhotoPictureBox = new PictureBox();
            partyFilterComboBox = new ComboBox();
            wikiWebBrowser = new WebBrowser();
            exitButton = new Button();
            timer = new Timer();

            // Set properties for controls
            // ...

            // Load presidents list
            LoadPresidents();

            // Set up event handlers
            presidentsListBox.SelectedIndexChanged += PresidentsListBox_SelectedIndexChanged;
            presidentNumberTextBox.TextChanged += PresidentNumberTextBox_TextChanged;
            partyFilterComboBox.SelectedIndexChanged += PartyFilterComboBox_SelectedIndexChanged;
            exitButton.Click += ExitButton_Click;
            timer.Tick += Timer_Tick;

            // Set initial state
            exitButton.Enabled = false;
            timer.Interval = 1000; // 1 second
            timer.Start();
        }

        private void PresidentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected president
            string selectedPresident = presidentsListBox.SelectedItem.ToString();

            // Update president details
            UpdatePresidentDetails(selectedPresident);
        }

        private void PresidentNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            // Validate input and check if all presidents are answered
            CheckAllPresidentsAnswered();
        }

        private void PartyFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Apply party filter to the list
            ApplyPartyFilter();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Close the application
            Close();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update and display the timer
            UpdateTimer();
        }

        private void LoadPresidents()
        {
            // Declare and initialize a list of presidents
            List<string> presidentsList = new List<string> { "George Washington", "John Adams", /* Add other presidents */ };

            // Clear the existing items in the presidentsListBox
            presidentsListBox.Items.Clear();

            // Add each president to the presidentsListBox
            foreach (string president in presidentsList)
            {
                presidentsListBox.Items.Add(president);
            }

            // Set the selected index to the first president
            presidentsListBox.SelectedIndex = 0;

            // Call UpdatePresidentDetails with the first president
            UpdatePresidentDetails(presidentsListBox.SelectedItem.ToString());
        }

        private void UpdatePresidentDetails(string selectedPresident)
        {
            // Declare and initialize a dictionary to store president numbers
            Dictionary<string, int> presidentNumbers = new Dictionary<string, int>
        {
            { "George Washington", 1 },
            { "John Adams", 2 },
            // Add other presidents with their corresponding numbers
        };

            // Get the president number for the selected president
            int presidentNumber = presidentNumbers[selectedPresident];

            // Display the president's number in the presidentNumberTextBox
            presidentNumberTextBox.Text = presidentNumber.ToString();

            // Construct the file path for the president's photo
            string imagePath = $"C:/temp/{selectedPresident.Replace(" ", "")}.jpeg";

            // Call SetImageLocation with the constructed file path
            SetImageLocation(imagePath);

            // Load the Wikipedia page for the selected president in the wikiWebBrowser
            wikiWebBrowser.Url = new Uri($"https://en.wikipedia.org/wiki/{selectedPresident.Replace(" ", "_")}");
        }
        private void SetImageLocation(string imagePath)
        {
            try
            {
                // Check if the file exists at the specified path
                if (System.IO.File.Exists(imagePath))
                {
                    // Set the ImageLocation property of presidentPhotoPictureBox
                    presidentPhotoPictureBox.ImageLocation = imagePath;
                }
                else
                {
                    // Display an error message if the file does not exist
                    MessageBox.Show("Image file not found at the specified location.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Display an error message for any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ApplyPartyFilter()
        {
            // Declare and initialize a dictionary to store political parties for each president
            Dictionary<string, string> presidentParties = new Dictionary<string, string>
        {
            { "George Washington", "None" },
            { "John Adams", "Federalist" },
            // Add other presidents with their corresponding parties
        };

            // Get the selected party from the partyFilterComboBox
            string selectedParty = partyFilterComboBox.SelectedItem.ToString();

            // If the selected party is "All," show all presidents
            if (selectedParty == "All")
            {
                foreach (object president in presidentsListBox.Items)
                {
                    presidentsListBox.Show();
                }
            }
            else
            {
                // Filter presidents based on the selected party
                foreach (object president in presidentsListBox.Items)
                {
                    if (presidentParties[president.ToString()] == selectedParty)
                    {
                        presidentsListBox.Show();
                    }
                    else
                    {
                        presidentsListBox.Hide();
                    }
                }
            }

            // Set the selected index to the first president
            presidentsListBox.SelectedIndex = 0;

            // Call UpdatePresidentDetails with the first president
            UpdatePresidentDetails(presidentsListBox.SelectedItem.ToString());
        }

        private void UpdateTimer()
        {
            // Get the remaining time from the timer
            int remainingTime = timer.Interval / 1000;

            // Display the remaining time in a formatted manner in the form's title bar
            this.Text = $"Presidents - Time Remaining: {remainingTime} seconds";

            // Decrease the remaining time by 1 second
            remainingTime--;

            // If the remaining time is less than or equal to 0, stop the timer and enable the exitButton
            if (remainingTime <= 0)
            {
                timer.Stop();
                exitButton.Enabled = true;
            }
        }

        private void CheckAllPresidentsAnswered()
        {
            // Declare and initialize a list to store answered presidents
            List<string> answeredPresidents = new List<string>();

            // Loop through each president in the presidentsListBox
            foreach (object president in presidentsListBox.Items)
            {
                // If the president has a corresponding number in the presidentNumberTextBox
                if (!string.IsNullOrEmpty(presidentNumberTextBox.Text) && presidentNumberTextBox.Text != "0")
                {
                    // Add the president to the answeredPresidents list
                    answeredPresidents.Add(president.ToString());
                }
            }

            // If the number of answered presidents is equal to the total number of presidents
            if (answeredPresidents.Count == presidentsListBox.Items.Count)
            {
                // Enable the exitButton
                exitButton.Enabled = true;
            }
            else
            {
                // Disable the exitButton
                exitButton.Enabled = false;
            }
        }

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            // 
            // PresidentsForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.listBox1);
            this.Name = "PresidentsForm";
            this.ResumeLayout(false);

        }

        private ListBox listBox1;
    }

}
