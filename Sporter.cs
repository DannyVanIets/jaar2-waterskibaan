using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Sporter
    {
        public Zwemvest Zwemvest;
        public Skies Skies;
        public string KledingKleur;

        public int AantalRondenNogTeGaan = 0;
        public int BehaaldePunten = 0;
        public List<Moves> moves = new List<Moves>();

        public Sporter()
        {
            moves = MoveCollection.GetWillekeurigeMoves();
            foreach (Moves move in moves)
            {
                BehaaldePunten += move.Uitvoeren();
            }
        }

        public override string ToString()
        {
            return $"Aantal behaalde punten: {BehaaldePunten}";
        }
    }
}
