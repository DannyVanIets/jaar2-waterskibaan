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
        public Sporter sporter;

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
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn l in _lijnen)
            {
                if (l.PositieOpDeKabel == 9 && VerwijderLijnVanKabel() != null)
                {
                    _lijnen.AddFirst(VerwijderLijnVanKabel());
                    l.PositieOpDeKabel = 0;
                    sporter.AantalRondenNogTeGaan--;
                    break;
                }
                else
                {
                    l.PositieOpDeKabel++;
                }
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            Lijn lijn;
            if (_lijnen.Last.Value.PositieOpDeKabel == 9 && sporter.AantalRondenNogTeGaan == 1)
            {
                lijn = _lijnen.Last.Value;
                _lijnen.RemoveLast();
                return lijn;
            }
            return null;
        }

        //Zelf gemaakte method die niet in het domeinmodel staat die er voor zorgt dat een specifieke lijn wordt verwijderd. Weet niet of dat mag, maar dat zien we wel.
        public void VerwijderEenLijn(Lijn lijn)
        {
            _lijnen.Remove(lijn);
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