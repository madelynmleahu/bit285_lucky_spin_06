﻿using System.Collections.Generic;

namespace LuckySpin.Models
{
    public class Repository
    {
        public Player currentPlayer { get; set; }


        private List<Spin> spins = new List<Spin>();

       //Property
       public IEnumerable<Spin> PlayerSpins {

            get { return spins; }
       }

        //Access method
        public void AddSpin(Spin s)
        {
            spins.Add(s);
        }

    }
}
