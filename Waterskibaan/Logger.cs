using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    public class Logger
    {
        private List<Sporter> bezoekers = new List<Sporter>();
        private Kabel kabel; //Gebeurt nog niks met kabel. Moet waarschijnlijk wel.

        public int bezoekerMetRood = 0;

        public Logger(Kabel kbl)
        {
            kabel = kbl;
        }

        public void BezoekerToevoegen(Sporter sporter)
        {
            bezoekers.Add(sporter);
            if (ColorsAreClose(sporter.KledingKleur, Color.Red))
            {
                bezoekerMetRood++;
            }
        }

        public int ReturnAlleBezoekers()
        {
            var alleBezoekers = from bezoeker in bezoekers
                                select bezoeker;
            return alleBezoekers.Count();
        }

        /*public int HoogsteScoreVanSporter() Werkt nog niet.
        {
            var hoogsteScore = from bezoeker in bezoekers
                               orderby bezoeker.BehaaldePunten
                               select bezoeker.BehaaldePunten;
            return hoogsteScore;
        }*/

        public List<Sporter> TienSportersMetLichsteKleur()
        {
            var toptiensporters = from bezoeker in bezoekers
                               where bezoeker.KledingKleur.ToArgb() == bepaalLichsteKleur(bezoeker.KledingKleur)
                               select bezoekers.Take(10);

            List<Sporter> lijstMetTop10LichteSporters = new List<Sporter>();

            foreach (Sporter sporter in toptiensporters)
            {
                lijstMetTop10LichteSporters.Add(sporter);
            }

            return lijstMetTop10LichteSporters;
        }

        public int TotaalAantalRondjes()
        {
            var rondesVanAlleBezoekers = from bezoeker in bezoekers
                                      where bezoeker.AantalRondenNogTeGaan > 0
                                      select bezoeker.AantalRondenNogTeGaan;

            int TotaalaantalRondjes = 0;

            foreach(int rondjes in rondesVanAlleBezoekers)
            {
                TotaalaantalRondjes += rondjes;
            }

            return TotaalaantalRondjes;
        }

        /*public List<Moves> UniekeMoves() Werkt nog niet.
        {
            var uniekeMovesLijst = from bezoeker in bezoekers
                                   where !string.IsNullOrEmpty(bezoeker.huidigeMove)
                                   select bezoekers;

            List<Moves> uniekeMoves = new List<Moves>();

            foreach (Sporter sporter in uniekeMovesLijst)
            {
                uniekeMoves.Add(sporter.moves);
            }

            return uniekeMovesLijst;
        }*/

        private bool ColorsAreClose(Color a, Color z, int threshold = 50)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public int bepaalLichsteKleur(Color kleur)
        {
            int lichsteKleur = kleur.R * kleur.R + kleur.G * kleur.G + kleur.B * kleur.B;
            return lichsteKleur;
        }
    }
}
