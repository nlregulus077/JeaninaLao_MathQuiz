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
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("Congratulations! You're a know it all!");
                startButton.Enabled = true;
            }
            
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }

            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("Sorry, but you didn't finish in time.  Try again.");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        // checks math answers
        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
            
        }


        // I don't need this stuff
        public Form1()
        {
            InitializeComponent();
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
