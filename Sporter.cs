using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    class Sporter
    {
        public Zwemvest Zwemvest;
        public Skies Skies;
        public Color KledingKleur;

        public int AantalRondenNogTeGaan = 0;
        public int BehaaldePunten = 0;
        public List<Moves> moves = new List<Moves>();

        public Sporter(Zwemvest zwemvest, Skies skies)
        {
            moves = MoveCollection.GetWillekeurigeMoves();
            KledingKleur = Color.Green;
            Zwemvest = zwemvest;
            Skies = skies;
        }

        public override string ToString()
        {
            return $"Aantal behaalde punten: {BehaaldePunten}";
        }
    }
}
