using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    public class Sporter
    {
        public Zwemvest Zwemvest;
        public Skies Skies;
        public Color KledingKleur;

        public int AantalRondenNogTeGaan = 0;
        public int BehaaldePunten = 0;
        public List<Moves> moves = new List<Moves>();
        public Moves huidigeMove;

        public Sporter(Zwemvest zwemvest, Skies skies)
        {
            Random random = new Random();

            if (random.Next(0, 6) == 0)
            {
                KledingKleur = Color.Green;
            }
            else if (random.Next(0, 6) == 1)
            {
                KledingKleur = Color.Yellow;
            }
            else if (random.Next(0, 6) == 2)
            {
                KledingKleur = Color.Red;
            }
            else if (random.Next(0, 6) == 3)
            {
                KledingKleur = Color.Purple;
            }
            else if (random.Next(0, 6) == 4)
            {
                KledingKleur = Color.White;
            }
            else if (random.Next(0, 6) == 5)
            {
                KledingKleur = Color.Orange;
            }
            else
            {
                KledingKleur = Color.Black;
            }

            moves = MoveCollection.GetWillekeurigeMoves();
            Zwemvest = zwemvest;
            Skies = skies;
        }

        public void HuidigeMove()
        {
            Random random = new Random();
            int aantalMoves = moves.Count;

            if (random.Next(0, 4) == 0 && moves.Count > 0)
            {
                int number = random.Next(aantalMoves);
                huidigeMove = moves[number];
                BehaaldePunten += moves[number].Uitvoeren();
            }
        }

        public override string ToString()
        {
            return $"Aantal behaalde punten: {BehaaldePunten}";
        }
    }
}
