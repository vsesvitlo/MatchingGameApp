﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGameApp
{
    public partial class Form1 : Form
    {
        DateTime start;
        // Use this Random object to choose random icons for the squares
        Random random = new Random();
        
        // Each of these letters is an interesting icon
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>()
    {
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
    };
        // firstClicked points to the first Label control 
        // that the player clicks, but it will be null 
        // if the player hasn't clicked a label yet
        Label firstClicked = null;

        // secondClicked points to the second Label control 
        // that the player clicks
        Label secondClicked = null;
        /// <summary>
        /// Assign each icon from the list of icons to a random square
        /// </summary>
        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels,
            // and the icon list has 16 icons,
            // so an icon is pulled at random from the list
            // and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    // iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
                iconLabel.ForeColor = iconLabel.BackColor;
            }

        }
        public Form1()
        {
            start = DateTime.Now;
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;
                if (clickedLabel.ForeColor == Color.Orange)
                    return;

                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the label that the player 
                // clicked, change its color to black, and return
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
                }
                else if (secondClicked == null)
                {
                    secondClicked = clickedLabel;
                    secondClicked.ForeColor = Color.Black;


                    if (firstClicked.Text != secondClicked.Text)
                    {
                        firstClicked.ForeColor = firstClicked.BackColor;
                        secondClicked.ForeColor = secondClicked.BackColor;
                        firstClicked = null;
                        secondClicked = null;
                    }
                    else if (firstClicked.Text == secondClicked.Text)
                    {
                        firstClicked.ForeColor = Color.Orange;
                        secondClicked.ForeColor = Color.Orange;
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = (DateTime.Now - start).ToString();
        }

        private void timer_full_time_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Time is up!");
        }
        /* {
    // The timer is only on after two non-matching 
    // icons have been shown to the player, 
    // so ignore any clicks if the timer is running
    if (timer1.Enabled == true)
        return;

    Label clickedLabel = sender as Label;

    if (clickedLabel != null)
    {
        // If the clicked label is black, the player clicked
        // an icon that's already been revealed --
        // ignore the click
        if (clickedLabel.ForeColor == Color.Black)
            return;

        // If firstClicked is null, this is the first icon
        // in the pair that the player clicked, 
        // so set firstClicked to the label that the player 
        // clicked, change its color to black, and return
        if (firstClicked == null)
        {
            firstClicked = clickedLabel;
            firstClicked.ForeColor = Color.Black;
            return;
        }

        // If the player gets this far, the timer isn't
        // running and firstClicked isn't null,
        // so this must be the second icon the player clicked
        // Set its color to black
        secondClicked = clickedLabel;
        secondClicked.ForeColor = Color.Black;

        // If the player gets this far, the player 
        // clicked two different icons, so start the 
        // timer (which will wait three quarters of 
        // a second, and then hide the icons)
        timer1.Start();
    }
}*/
    }

}
