using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRace
{
    //coding for class form
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            int StartRace = Car1.Left;
            int RaceTrackLength = trackLength.Width - Car1.Right;

            //coding for add cars
            Data.Cars[0] = new Car() { carImg = Car1, finishPosition = RaceTrackLength, startPosition = StartRace };
            Data.Cars[1] = new Car() { carImg = Car2, finishPosition = RaceTrackLength, startPosition = StartRace };
            Data.Cars[2] = new Car() { carImg = Car3, finishPosition = RaceTrackLength, startPosition = StartRace };
            Data.Cars[3] = new Car() { carImg = Car4, finishPosition = RaceTrackLength, startPosition = StartRace };
            Data.Cars[4] = new Car() { carImg = Car5, finishPosition = RaceTrackLength, startPosition = StartRace };

            //coding for add bidders 
            Data.Bidders[0] = new Bettor() { Cash = 50, PlayerActivityIndicator = label2, BettorSelector = radioButton1, Name = "Player 1" };
            Data.Bidders[1] = new Bettor() { Cash = 50, PlayerActivityIndicator = label3, BettorSelector = radioButton2, Name = "Player 2" };
            Data.Bidders[2] = new Bettor() { Cash = 50, PlayerActivityIndicator = label4, BettorSelector = radioButton3, Name = "Player 3" };

            // Sets the default values to the labels
            Data.Bidders[0].UpdateLabels();
            Data.Bidders[1].UpdateLabels();
            Data.Bidders[2].UpdateLabels();
            Data.Bidders[0].Reset();
            Data.Bidders[1].Reset();
            Data.Bidders[2].Reset();
        }

        private void PlaceBid_Click(object sender, EventArgs e)
        {
            Data.Bidders[Data.CurrentGambler].PlaceBid((int)BetAmount.Value, (int)BidOnCar.Value);
            Data.Bidders[Data.CurrentGambler].UpdateLabels();
        }
        // Sets the default values to the Race button
        private void StartRace_Click(object sender, EventArgs e)
        {
            timer1.Start();
            StartRace.Enabled = false;
        }
        // this coding use for Declare winner
        private void DeclareWinner(int Winner)
        {
            MessageBox.Show("Car #" + Winner + " is the Winning Car");
            for (int i = 0; i < Data.Bidders.Length; i++)
            {
                Data.Bidders[i].CollectYouMoney(Winner);
                Data.Bidders[i].UpdateLabels();
                ResetPositions();
                ResetBids();
            }
        }
        //. this coding is for reset the car positions
        private void ResetPositions()
        {
            Data.Cars[0].BackToStart();
            Data.Cars[1].BackToStart();
            Data.Cars[2].BackToStart();
            Data.Cars[3].BackToStart();
            Data.Cars[4].BackToStart();
        }
        //  this coding is for bids reseting
        private void ResetBids()
        {
            label2.Text = "Player 1 hasn't placed a bet.";
            label2.Text = "Player 2 hasn't placed a bet.";
            label2.Text = "Player 3 hasn't placed a bet.";
        }
        //coding for timer
        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.Cars.Length; i++)
            {
                Data.Cars[Data.rand.Next(0, 5)].AccelerateCar();
                if (Data.Cars[i].AccelerateCar())
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    StartRace.Enabled = true;
                    DeclareWinner(i + 1);
                }
            }
        }
        //  coding for the place a bet on cars
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Data.CurrentGambler = 0;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Data.CurrentGambler = 1;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Data.CurrentGambler = 2;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
