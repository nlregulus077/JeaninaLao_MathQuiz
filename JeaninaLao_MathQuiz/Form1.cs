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

        // Set date
        DateTime date = DateTime.Now;
        
        // Storing addition values
        int addend1;
        int addend2;

        // Storing subtraction values
        int minuend;
        int subtrahend;

        // Store multiplication values
        int multiplicand;
        int multiplier;

        // Store division values
        int dividend;
        int divisor;

        // Timer
        int timeLeft;

        // set the date
        public void SetDate()
        {
            dateLabel.Text = date.ToString("dd MMMM yyyy");
        }


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

            // Subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

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

                if (timeLeft <= 10)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }

            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                timeLabel.BackColor = Color.Black;
                MessageBox.Show("Sorry, but you didn't finish in time.  Try again.");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        // checks math answers
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) && (minuend - subtrahend == difference.Value) && 
                (multiplicand * multiplier == product.Value) && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
            
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


        // I don't need this stuff
        public Form1()
        {
            InitializeComponent();
            SetDate();
        }

        
    }
}
