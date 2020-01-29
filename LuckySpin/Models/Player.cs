﻿using System;
using System.ComponentModel.DataAnnotations;
namespace LuckySpin.Models
{
    public class Player
    {
        public long Id { get; set; }
        [Display(Prompt = " Your First Name")]
        [Required(ErrorMessage = "Please enter your Name", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        /*
         * Balance Property with specialty methods
         */
        Decimal _balance; //Stores the balance for use by specialty methods
        Decimal charge = 0.50m, payout = 1.00m;
        public Decimal Balance
        {
            get { return _balance; }  //basic getter
            set { _balance = value; } //basic setter
        }
        //Specialty method to increase Balance by the payout from a spin
        public void CollectWinnings()
        {
            _balance += payout; 
        }
        //Specialty method to decrease Balance by the charge for a spin
        // returns a boolean for use in game flow
        public bool ChargeSpin()
        {
            if (_balance >= charge)
            {
                _balance -= charge;
                return true;
            }
            return false;
        }

    }
}