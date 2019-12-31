using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gizmox.WebGUI.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += new System.EventHandler(SelectButton);
            button2.Click += new System.EventHandler(SelectButton);
            button3.Click += new System.EventHandler(SelectButton);
            button4.Click += new System.EventHandler(SelectButton);
            button5.Click += new System.EventHandler(SelectButton);
            button6.Click += new System.EventHandler(SelectButton);
            button7.Click += new System.EventHandler(SelectButton);
            button8.Click += new System.EventHandler(SelectButton);
            button9.Click += new System.EventHandler(SelectButton);
        }
        //Declare variables
        int[] arraynumber = new int[9];
        int dicesum,usersumtotal;
        int buttonnumber1;
        int die1, die2;
        bool buttonwasclicked = false;
        bool[] colorChangedAlready = { false, false, false, false, false, false, false, false, false };

        //This method rolls the dices, which also call the other method to update labels and update pictures boxes
        //This is taken from previous assignment
        private void RollDice(out int die1, out int die2)
        {
            Random random = new Random();
            die1 = random.Next(1, 7);
            die2 = random.Next(1, 7);

            UpdateLabel(die1, die2);
            UpdatePictureBoxes(die1, die2);
        }

        //This method update the labels
        //This is taken from previous assignment
        private void UpdateLabel(int die1, int die2)
        {
            dicesum = die1 + die2;
            lbSum.Text = dicesum.ToString("Sum = " + "#.##");
        }

        //This method call on the updatePictureBox to update dice images
        //This is taken from previous assignment
        private void UpdatePictureBoxes(int die1, int die2)
        {
            UpdatePictureBox(pictureBox1, die1);
            UpdatePictureBox(pictureBox2, die2);
        }

        //This method change the dice images
        //This is taken from previous assignment
        private void UpdatePictureBox(PictureBox pb, int die)
        {
            switch (die)
            {
                case 1: pb.Image = Project.Properties.Resources.die1; break;
                case 2: pb.Image = Project.Properties.Resources.die2; break;
                case 3: pb.Image = Project.Properties.Resources.die3; break;
                case 4: pb.Image = Project.Properties.Resources.die4; break;
                case 5: pb.Image = Project.Properties.Resources.die5; break;
                case 6: pb.Image = Project.Properties.Resources.die6; break;
            }
        }

        //This method convert to whatever button into an variable and past it though a Sum method
        public void SelectButton(object sender, EventArgs e)
        {
             
            buttonnumber1 = int.Parse((sender as Button).Text);
            lbButtonSelected.Text = buttonnumber1.ToString("#.##");
            TotalingButtonSum(buttonnumber1);
 
        }

        //This method adds up the sum from the user's choices 
        public void TotalingButtonSum(int buttonnumber)
        {
            //If the button is press, the button's number goes into a switch
            if (buttonwasclicked)
            {
                switch (buttonnumber)
                {
                    case 1: arraynumber[0] = 1; break;
                    case 2: arraynumber[1] = 2; break;
                    case 3: arraynumber[2] = 3; break;
                    case 4: arraynumber[3] = 4; break;
                    case 5: arraynumber[4] = 5; break;
                    case 6: arraynumber[5] = 6; break;
                    case 7: arraynumber[6] = 7; break;
                    case 8: arraynumber[7] = 8; break;
                    case 9: arraynumber[8] = 9; break;
                }
            }
            //If the user disselect the button, the button's number is put in the array as zero
            else
            {
                switch (buttonnumber) { 
                    case 1: arraynumber[0] = 0; break;
                    case 2: arraynumber[1] = 0; break;
                    case 3: arraynumber[2] = 0; break;
                    case 4: arraynumber[3] = 0; break;
                    case 5: arraynumber[4] = 0; break;
                    case 6: arraynumber[5] = 0; break;
                    case 7: arraynumber[6] = 0; break;
                    case 8: arraynumber[7] = 0; break;
                    case 9: arraynumber[8] = 0; break;
            }
            }
            //This loops into the array and sum up the total in the array
            int usersum =0;
            for (int index = 0; index < arraynumber.Length; index++)
            {
                usersum += arraynumber[index];
            }
            
            lbUsersum.Text = usersum.ToString("#.##");
            usersumtotal = usersum;


        }
        //This switch toggle from light grey and light green depending if the user has select or disselect the button
        //This was taken from demo that was shown in last class 
        private void ColourChangeButton(int buttoncode)
        {
            int index = buttoncode - 1;
            Color ButtonColour;
            if (colorChangedAlready[index])
            {
                ButtonColour = SystemColors.ControlLight;
                colorChangedAlready[index] = false;
                buttonwasclicked = false;
            }
            else
            {
                ButtonColour = Color.LightGreen;
                colorChangedAlready[index] = true;
                buttonwasclicked = true;
            }

            switch (buttoncode)
            {
                case 1: button1.BackColor = ButtonColour; break;
                case 2: button2.BackColor = ButtonColour; break;
                case 3: button3.BackColor = ButtonColour; break;
                case 4: button4.BackColor = ButtonColour; break;
                case 5: button5.BackColor = ButtonColour; break;
                case 6: button6.BackColor = ButtonColour; break;
                case 7: button7.BackColor = ButtonColour; break;
                case 8: button8.BackColor = ButtonColour; break;
                case 9: button9.BackColor = ButtonColour; break;
            }
        }
        //This method elminate the button and makes them unclickable
        private void ElminateButton(Array buttonnumber)
        {
            foreach (int element in arraynumber)
            {
                switch (element)
                {
                    case 1: button1.BackColor = Color.DarkGreen; button1.Enabled = false; break;
                    case 2: button2.BackColor = Color.DarkGreen; button2.Enabled = false; break;
                    case 3: button3.BackColor = Color.DarkGreen; button3.Enabled = false; break;
                    case 4: button4.BackColor = Color.DarkGreen; button4.Enabled = false; break;
                    case 5: button5.BackColor = Color.DarkGreen; button5.Enabled = false; break;
                    case 6: button6.BackColor = Color.DarkGreen; button6.Enabled = false; break;
                    case 7: button7.BackColor = Color.DarkGreen; button7.Enabled = false; break;
                    case 8: button8.BackColor = Color.DarkGreen; button8.Enabled = false; break;
                    case 9: button9.BackColor = Color.DarkGreen; button9.Enabled = false; break;
                }
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ColourChangeButton(1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColourChangeButton(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColourChangeButton(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColourChangeButton(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColourChangeButton(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColourChangeButton(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColourChangeButton(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ColourChangeButton(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ColourChangeButton(9);
        }

        private void lbUsersum_Click(object sender, EventArgs e)
        {

        }
        //This clears everything
        private void bttnNewGame_Click(object sender, EventArgs e)
        {
            lbSum.Text = "";
            lbUsersum.Text = "";
            lbButtonSelected.Text = "";
            dicesum = 0;
            usersumtotal = 0;
            button1.BackColor = SystemColors.ControlLight; button1.Enabled = true;
            button2.BackColor = SystemColors.ControlLight; button2.Enabled = true; 
            button3.BackColor = SystemColors.ControlLight; button3.Enabled = true; 
            button4.BackColor = SystemColors.ControlLight; button4.Enabled = true; 
            button5.BackColor = SystemColors.ControlLight; button5.Enabled = true; 
            button6.BackColor = SystemColors.ControlLight; button6.Enabled = true; 
            button7.BackColor = SystemColors.ControlLight; button7.Enabled = true; 
            button8.BackColor = SystemColors.ControlLight; button8.Enabled = true; 
            button9.BackColor = SystemColors.ControlLight; button9.Enabled = true;

        }
        private void lbButtonSelected_Click(object sender, EventArgs e)
        {

        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            //If the dice sum is equal to the user's sum it will goes into an if else switch
            if (dicesum == usersumtotal)
            {
               RollDice(out die1, out die2);
               lbUsersum.Text = usersumtotal.ToString("#.##");
               ElminateButton(arraynumber);
            }
            //if the dice sum and user's sum don't match the button will go back into light grey button
            else 
            {
                foreach (int element in arraynumber)
                {
                    switch (element)
                    {
                        case 1: button1.BackColor = SystemColors.ControlLight; break;
                        case 2: button2.BackColor = SystemColors.ControlLight; break;
                        case 3: button3.BackColor = SystemColors.ControlLight; break;
                        case 4: button4.BackColor = SystemColors.ControlLight; break;
                        case 5: button5.BackColor = SystemColors.ControlLight; break;
                        case 6: button6.BackColor = SystemColors.ControlLight; break;
                        case 7: button7.BackColor = SystemColors.ControlLight; break;
                        case 8: button8.BackColor = SystemColors.ControlLight; break;
                        case 9: button9.BackColor = SystemColors.ControlLight; break;
                    }
                }
            }

            //This reset the array when the loop has ended
            lbButtonSelected.Text  = "";
            lbUsersum.Text = "";
            Array.Clear(arraynumber, 0, arraynumber.Length);

        }
    }
}
