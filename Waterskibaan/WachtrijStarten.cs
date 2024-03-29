﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijStarten : Wachtrij, IWachtrij
    {
        new int MAX_LENGTE_RIJ = 20;

        public override void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (GetAlleSporters().Count < MAX_LENGTE_RIJ)
            {
                alleSporters.Enqueue(sporter);
                Console.WriteLine($"Sporter succesvol toegevoegd!");
            }
            else
            {
                Console.WriteLine("Het zit vol! Sporter is niet toegevoegd");
            }
        }

        public override string ToString()
        {
            return $"Er zitten {GetAlleSporters().Count}/{MAX_LENGTE_RIJ} sporters te wachten op een lijn";
        }
    }
}
