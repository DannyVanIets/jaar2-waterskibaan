using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        List<Sporter> bezoekers = new List<Sporter>();
        Kabel kabel;

        public Logger(Kabel kbl)
        {
            kabel = kbl;
        }

        public void BezoekerToevoegen(Sporter sporter)
        {
            bezoekers.Add(sporter);
        }

        public int ReturnAlleBezoekers()
        {
            return bezoekers.Count;
        }
    }
}
