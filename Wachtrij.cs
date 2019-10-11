using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    abstract class Wachtrij : IWachtrij
    {
        public int MAX_LENGTE_RIJ;

        Queue<Sporter> alleSporters = new Queue<Sporter>();

        public Queue<Sporter> GetAlleSporters()
        {
            return alleSporters;
        }

        public abstract void SporterNeemPlaatsInRij(Sporter sporter);

        public Queue<Sporter> SportersVerlaten(int aantal)
        {
            if(aantal > alleSporters.Count)
            {
                Console.WriteLine("Het aantal mag niet hoger zijn dan het aantal sporters!");
                aantal = 0;
            }

            for (int i = 0; i < aantal; i++)
            {
                alleSporters.Dequeue();
            }

            return alleSporters;
        }
    }
}
