using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadUserInterface
{//Author: Sebastian Arroyo
    //Purpose:Purposefully Bad UI
    //Restrictions:None
    public partial class Form2 : Form
    { //Purpose:Main
        //Restrictions:None
        public Form2()
        {
            InitializeComponent();

            Button form1Button = new Button();
            Button form3Button = new Button();

            form1Button.Enabled = true;
            form1Button.Visible = true;
            form1Button.Text = "Form 1";
            form1Button.Dock = DockStyle.Left;

            form3Button.Enabled = true;
            form3Button.Visible = true;
            form3Button.Text = "Form 3";
            form3Button.Dock = DockStyle.Right;


            form1Button.Click += new EventHandler(ButtonOpenFirstForm_Click);
            form3Button.Click += new EventHandler(ButtonOpenThirdForm_Click);

            
        }
        //Purpose:open form 1 when left button is clicked
        //Restrictions:None
        private void ButtonOpenFirstForm_Click(object sender, EventArgs e)
        {
            Form1 firstForm = new Form1();
            firstForm.Show();
        }
        //Purpose:open form 3 when right button is clicked
        //Restrictions:None
        private void ButtonOpenThirdForm_Click(object sender, EventArgs e)
        {
            Form3 thirdForm = new Form3();
            thirdForm.Show();
        }
    }
}
