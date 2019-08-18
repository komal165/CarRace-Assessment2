﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRace
{
    //coding for bet class
    public class Bettor : Bet
    {
        public string Name { get; set; }
        public int Cash { get; set; }
        public Bet CurrentBet;

        public RadioButton BettorSelector { get; set; }
        public Label PlayerActivityIndicator { get; set; }

        //coding for updating labels
        public void UpdateLabels()
        {
            BettorSelector.Text = Name + " has $" + Cash;
        }
        //coding for reset
        public void Reset()
        {
            CurrentBet = null;
            PlayerActivityIndicator.Text = Name + " hasn't placed a bet";
        }
        //coding for placing the bid
        public bool PlaceBid(int BidAmount, int VehicleToWin)
        {
            this.CurrentBet = new Bet() { Amount = BidAmount, car = VehicleToWin };

            if (BidAmount <= Cash)
            {
                PlayerActivityIndicator.Text = this.Name + " has placed $" + BidAmount + " Bid on Car #" + VehicleToWin;
                this.UpdateLabels();
                return true;
            }
            else
            {
                MessageBox.Show(this.Name + " does not have enough cash to cover the Bid");
                this.CurrentBet = null;
                return false;
            }
        }
        //coding for collecting the money
        public void CollectYouMoney(int Winner)
        {
            if (this.CurrentBet != null)
            {
                Cash += CurrentBet.PayOut(Winner);
                Reset();
                UpdateLabels();
            }
        }
    }
}
