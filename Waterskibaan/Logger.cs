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
        private Kabel kabel;

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

        public int HoogsteScoreVanSporter()
        {
            int hoogsteScore = 0;
            if(ReturnAlleBezoekers() > 0)
            {
                hoogsteScore = bezoekers.Max(x => x.BehaaldePunten);
            }
            return hoogsteScore;
        }

        public List<Sporter> TienSportersMetLichsteKleur()
        {
            var toptiensporters = (from sporter in bezoekers
                                   orderby bepaalLichsteKleur(sporter.KledingKleur) descending
                                   select sporter).Take(10);

            List<Sporter> lijstMetTop10LichteSporters = new List<Sporter>();
            lijstMetTop10LichteSporters = toptiensporters.ToList();

            return lijstMetTop10LichteSporters;
        }

        public int TotaalAantalRondjes()
        {
            int totaalAantalRonden = bezoekers.Sum(x => x.aantalRonden);
            return totaalAantalRonden;
        }

        public List<string> UniekeMoves()
        {
            var uniekeMovesLijst = (from lijn in kabel._lijnen
                                   where lijn.sporter.huidigeMove != null
                                   select lijn.sporter.huidigeMove.naamMove).Distinct();

            List<string> uniekeMoves = uniekeMovesLijst.ToList();

            return uniekeMoves;
        }

        private bool ColorsAreClose(Color a, Color z, int threshold = 100)
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
