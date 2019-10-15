using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0 || _lijnen.First.Value.PositieOpDeKabel >= 1)
            {
                return true;
            }
            return false;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PositieOpDeKabel = 0;
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn l in _lijnen)
            {
                l.PositieOpDeKabel++;
                l.sporter.HuidigeMove();
            }

            if (_lijnen?.Last?.Value?.PositieOpDeKabel > 9)
            {
                Lijn lijn = _lijnen.Last.Value;
                NeemLijnInGebruik(lijn);
                _lijnen.RemoveLast();
                lijn.sporter.AantalRondenNogTeGaan--;
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lijn;
            if(_lijnen.Count > 0)
            {
                if (_lijnen.Last.Value.PositieOpDeKabel >= 9)
                {
                    lijn = _lijnen.Last.Value;
                    if (lijn.sporter.AantalRondenNogTeGaan == 0)
                    {
                        _lijnen.RemoveLast();
                        return lijn;
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            if (_lijnen.Count != 0)
            {
                int i = 0;
                string lijnAchterPositie = "|";
                string allePosities = "";

                foreach (Lijn l in _lijnen)
                {
                    i++;
                    if (_lijnen.Count == i)
                    {
                        lijnAchterPositie = "";
                    }
                    allePosities += $"{l.PositieOpDeKabel}{lijnAchterPositie}";
                }

                return allePosities;
            }
            else
            {
                return "";
            }
        }
    }
}