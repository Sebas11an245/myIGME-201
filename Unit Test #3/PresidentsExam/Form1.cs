using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresidentsExam
{
    public partial class Form1 : Form
    {
        private string selectedPresident;
        private List<RadioButton> presidentRadioButtons;
        private TextBox presidentNumberTextBox;
        private GroupBox browserGroupBox;
        private Timer timer;


        public Form1()
        {
            InitializeComponent();
            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {
            }

            presidentRadioButtons = new List<RadioButton>();
            presidentNumberTextBox = new TextBox();
            timer = new Timer();
            selectedPresident = "";


            // Set up event handlers
            foreach (RadioButton radioButton in presidentRadioButtons)
            {
                radioButton.CheckedChanged += PresidentRadioButton__CheckedChanged;
            }
            this.exitButton.Click += new EventHandler(ExitButton__Click);
            this.timer.Tick += Timer__Tick;
            

            this.presidentPictureBox.LoadCompleted += PresidentPhotoPictureBox__LoadCompleted;


            //set initial state
            presidentPictureBox.Enabled = true;
            presidentPictureBox.Visible = true;
            exitButton.Enabled = false;
            timer.Interval = 1000; // 1 second
            timer.Start();
            timerProgressBar.Minimum = 0;
            timerProgressBar.Maximum = 100;
            timerProgressBar.Value = 100;
            wikiWebBrowser.Dock = DockStyle.Fill;

        }
        private void ExitButton__Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Timer__Tick(object sender, EventArgs e)
        {
            UpdateTimer();
        }
        private void UpdateTimer()
        {
            timerProgressBar.Value--;

            // If the remaining time is less than or equal to 0, stop the timer and enable the exitButton
            if (timerProgressBar.Value <= 0)
            {
                timer.Stop();
                exitButton.Enabled = true;

                // Optionally, perform any other actions or show a message when the timer reaches zero
                MessageBox.Show("Time's up! You can now exit the application.", "Timer Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PresidentRadioButton__CheckedChanged(object sender, EventArgs e)
        {
            // Handle the event when a president radio button is checked
            RadioButton selectedRadioButton = (RadioButton)sender;

            if (selectedRadioButton.Checked)
            {
                // Update president details
                selectedPresident = selectedRadioButton.Text;
                UpdatePresidentDetails(selectedRadioButton.Text);
            }
        }
        private void UpdatePresidentDetails(string selectedPresident)
        {
            string wikipediaURL = string.Empty;
            switch (selectedPresident)
            {
                //different case because different img format
                case "Barack Obama":
                    SetImageLocation($"http://people.rit.edu/dxsigm/{selectedPresident.Replace(" ", "")}.png");
                   
                    // Update the WebBrowser to display the Wikipedia page of the selected president
                    wikipediaURL = $"https://en.wikipedia.org/wiki/{selectedPresident.Replace(" ", "_")}";
                    this.wikiWebBrowser.Navigate(wikipediaURL);
                    break;
                default:
                    SetImageLocation($"http://people.rit.edu/dxsigm/{selectedPresident.Replace(" ", "")}.jpeg");

                    // Update the WebBrowser to display the Wikipedia page of the selected president
                    wikipediaURL = $"https://en.wikipedia.org/wiki/{selectedPresident.Replace(" ", "_")}";
                    this.wikiWebBrowser.Navigate(wikipediaURL);
                    
                    break;
            }
        }
        private void SetImageLocation(string imageUrl)
        {
            try
            {
                presidentPictureBox.ImageLocation = imageUrl;
            }
            catch (Exception ex)
            {
                // Display an error message for any other exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PresidentPhotoPictureBox__LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Check for errors in the asynchronous image loading process
            if (e.Error != null)
            {
                MessageBox.Show($"Error loading image: {e.Error.Message}", "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
