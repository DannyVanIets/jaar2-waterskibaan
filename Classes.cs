using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Classes
    {
        static void Main(string[] args)
        {
            TestOpdracht2();
        }
        private static void TestOpdracht2()
        {

        }
    }

    class Sporter
    {
        public Sporter(List<IMoves> moves)
        {

        }

        public int AantalRondenNogTeGaan()
        {
            int i = 0;
            return i;
        }

        public Zwemvest Zwemvest()
        {
            return null;
        }

        public Skies Skies()
        {
            return null;
        }

        public Color KledingKleur()
        {
            return null;
        }
    }

    class Zwemvest
    {

    }

    class Skies
    {

    }

    class Lijn
    {
        public void PositieOpKabel()
        {

        }
    }

    class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        public Boolean IsStartPositieLeeg()
        {
            if (_lijnen.First.Value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (_lijnen.First.Value != null)
            {
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            if (_lijnen.Count == 9)
            {
                _lijnen.AddFirst(_lijnen.Last.Value);
                _lijnen.RemoveLast();
            }
            else
            {
                //Moet nog functie bijkomen die er voor zorgt dat de posities worden aangepast!
            }
        }

        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.Count >= 8)
            {
                return _lijnen.Last.Value;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            if (_lijnen.Count == 0)
            {
                foreach (Lijn l in _lijnen)
                {
                    return $"{l}|";
                }
                return "";
            }
            else
            {
                return "";
            }
        }
    }

    class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen;

        public void LijnToevoegenAanRij(Lijn lijn)
        {

        }

        public Lijn VerwijderEersteLijn()
        {
            if (_lijnen.Count == 0)
            {
                return _lijnen.Dequeue();
            }
            else
            {
                return null;
            }
        }

        public int GetAantalLijnen()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{_lijnen.Count} lijnen op voorraad";
        }
    }
}
