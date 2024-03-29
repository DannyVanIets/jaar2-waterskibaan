﻿using System;
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

        public Moves huidigeMove;
        public int AantalRondenNogTeGaan = 0;
        public int aantalRonden = 0;
        public int BehaaldePunten = 0;

        public List<Moves> moves = new List<Moves>();

        public Sporter(Zwemvest zwemvest, Skies skies)
        {
            Random random = new Random();
            KledingKleur = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
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
                return;
            }
            huidigeMove = null;
        }

        public override string ToString()
        {
            return $"Aantal behaalde punten: {BehaaldePunten}";
        }
    }
}
