using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

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
                _lijnen.AddFirst(lijn);
                lijn.PositieOpDeKabel = 0;
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn l in _lijnen)
            {
                l.PositieOpDeKabel++;
            }

            if (_lijnen.Last.Value.PositieOpDeKabel > 9)
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
            if (_lijnen.Last.Value.PositieOpDeKabel > 9)
            {
                lijn = _lijnen.Last.Value;
                _lijnen.RemoveLast();
                return lijn;
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