using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    interface IWachtrij
    {
        void SporterNeemPlaatsInRij(Sporter sporter);
        Queue<Sporter> GetAlleSporters();
        Queue<Sporter> SportersVerlaten(int aantal);
    }
}
