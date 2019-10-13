using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class InstructieAfgelopenArgs
    {
        public List<Sporter> sporterLijst { get; set; }

        public InstructieAfgelopenArgs(List<Sporter> lijst)
        {
            sporterLijst = lijst;
        }
    }
}
