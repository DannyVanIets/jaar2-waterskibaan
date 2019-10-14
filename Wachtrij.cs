using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij : IWachtrij
    {
        public int MAX_LENGTE_RIJ;

        public Queue<Sporter> alleSporters = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            List<Sporter> alleSportersLijst = new List<Sporter>();

            foreach (Sporter sporter in alleSporters)
            {
                alleSportersLijst.Add(sporter);
            }

            return alleSportersLijst;
        }

        public abstract void SporterNeemPlaatsInRij(Sporter sporter);

        public List<Sporter> SportersVerlaten(int aantal)
        {
            List<Sporter> alleVerwijderdeSportersLijst = new List<Sporter>();

            if(aantal > alleSporters.Count)
            {
                aantal = 0;
            }

            for (int i = 0; i < aantal; i++)
            {
                alleVerwijderdeSportersLijst.Add(alleSporters.Dequeue());
            }

            return alleVerwijderdeSportersLijst;
        }
    }
}
