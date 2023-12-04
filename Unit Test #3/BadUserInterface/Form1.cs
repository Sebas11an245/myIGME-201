using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace BadUserInterface
{
    //Author: Sebastian Arroyo
    //Purpose:Purposefully Bad UI
    //Restrictions:None
    public partial class Form1 : Form
    {
        private Thread uiThread;

        //Purpose:Main
        //Restrictions:None
        public Form1()
        {
            InitializeComponent();

            // Initialize UI thread
            uiThread = new Thread(ChangeUI);
            uiThread.Start();


            button1.Text = "Form 3";
            button2.Text = "Form 2";

            button1.Click += new EventHandler(ButtonOpenSecondForm_Click);
            button2.Click += new EventHandler(ButtonOpenThirdForm_Click);
            

        }
        //Purpose:invoke changes
        //Restrictions None
        private void ChangeControlText(string newText)
        {
            if (button1.InvokeRequired)
            {
                button1.Invoke((MethodInvoker)delegate
                {
                    // This code will be executed on the UI thread
                    button1.Text = newText;
                });
            }
            else
            {
                // If already on the UI thread, no need to invoke
                button1.Text = newText;
            }
        }
        //Purpose: Change background color
        //Restrictions:None
        private void ChangeControlBackgroundColor(Color newColor)
        {
            if (button1.InvokeRequired)
            {
                button1.Invoke((MethodInvoker)delegate
                {
                    // This code will be executed on the UI thread
                    button1.BackColor = newColor;
                });
            }
            else
            {
                // If already on the UI thread, no need to invoke
                button1.BackColor = newColor;
            }
        }
        //Purpose: update all the wacky changes on the form
        //Restrictions:None
        private void ChangeUI()
        {
            while (true)
            {
                // Simulate random UI changes
                Random random = new Random();
                Thread.Sleep(2000); // 2-second delay

                // Randomly change text color
                ChangeControlColor(label1, Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
               

                // Randomly delete a character from the textbox
                DeleteRandomCharacter(textBox1);

                // Slowly bring numeric up-down to 0
                if (numericUpDown1.Value > 0)
                {
                    numericUpDown1.Value -= 1;
                }
                else if (numericUpDown1.Value < 0)
                {
                    numericUpDown1.Value += 1;
                }

                ChangeControlText("New Text");
                //Randomly move the buttons that take you to the other forms
                ButtonMoveRandom(button1);
                ButtonMoveRandom(button2);


                Color newBackgroundColor = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256));
                ChangeControlBackgroundColor(newBackgroundColor);
            }
        }

        //Purpose:change foreground color
        //Restrictions:None
        private void ChangeControlColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => control.ForeColor = color));
            }
            else
            {
                control.ForeColor = color;
            }
        }

        //Purpose:deletes characters from the text box
        //Restrictions:None
        private void DeleteRandomCharacter(System.Windows.Forms.TextBox textBox)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() =>
                {
                    if (textBox.Text.Length > 0)
                    {
                        int index = new Random().Next(textBox.Text.Length);
                        textBox.Text = textBox.Text.Remove(index, 1);
                    }
                }));
            }
            else
            {
                if (textBox.Text.Length > 0)
                {
                    int index = new Random().Next(textBox.Text.Length);
                    textBox.Text = textBox.Text.Remove(index, 1);
                }
            }
        }

        //Purpose:close the form
        //Restrictions:None
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the UI thread before closing the form
            uiThread.Abort();
        }

        //Purpose:open form 2 when correct button is clicked
        //Restrictions:None
        private void ButtonOpenSecondForm_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();
        }
        //Purpose:open form 3 when correct button is clicked
        //Restrictions:None
        private void ButtonOpenThirdForm_Click(object sender, EventArgs e)
        {
            Form3 thirdForm = new Form3();
            thirdForm.Show();
        }
        //Purpose:randomly move the buttons around
        //Restrictions:None
        private void ButtonMoveRandom(Button button)
        {
            Random random = new Random();
            int newX = random.Next(0, this.Width-button.Width);
            int newY = random.Next(0, this.Height-button.Height);

            button.Location = new Point(newX, newY);
        }            
    }
}
