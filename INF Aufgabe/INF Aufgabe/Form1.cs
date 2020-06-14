using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INF_Aufgabe
{
    public partial class Form1 : Form
    {
        int timeMilliseconds;
        int timeSeconds;
        int timeMinutes;
        int randomNumber;
        bool IsActive;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetTime();
            IsActive = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            IsActive = true;
            RandomNumber();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            IsActive = false;
            RandomNumber();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            IsActive = false;

            ResetTime();
            RandomNumber();
        }

        private void ResetTime()
        {
            timeMilliseconds = 0;
            timeSeconds = 0;
            timeMinutes = 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsActive)
            {
                timeMilliseconds++;

                if (timeMilliseconds > 100)
                {
                    timeSeconds++;
                    timeMilliseconds = 0;

                    if (timeSeconds > 60)
                    {
                        timeMinutes++;
                        timeSeconds = 0;
                    }
                }
            }

            DrawTime();
        }

        private void DrawTime()
        {
            lblMiliseconds.Text = String.Format("{0:00}", timeMilliseconds);
            lblSeconds.Text = String.Format("{0:00}", timeSeconds);
            lblMinutes.Text = String.Format("{0:00}", timeMinutes);
        }

        public void RandomNumber()
        {
            Random rndm = new Random();
            randomNumber = rndm.Next(1, 1000);

            txtRandomNumber.Text = Convert.ToString(randomNumber);
        }
    }
}
