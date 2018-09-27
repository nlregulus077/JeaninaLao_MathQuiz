using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeaninaLao_MathQuiz
{
    public partial class Form1 : Form
    {
        // New random object
        Random randomizer = new Random();

        // Storing addition values
        int addend1;
        int addend2;

        // Timer
        int timeLeft;

        // Start the quiz method
        public void StartTheQuiz()
        {
            // Fill in addition problems
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Turn addends to strings and put them into the labels.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // Sum is 0 by default
            sum.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        // start quiz
        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        // tick, tock, tick, tock...
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
            }

            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("Sorry, but you didn't finish in time.  Better luck next time.");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }


        // I don't need this stuff
        public Form1()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
