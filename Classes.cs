
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
            Kabel kabel1 = new Kabel();
            Lijn lijn1 = new Lijn();
            Console.WriteLine(kabel1.ToString());

            //Test om te zien of een lijn succesvol wordt toegevoegd en of de start positie leeg is.
            Console.WriteLine(kabel1.IsStartPositieLeeg());
            kabel1.NeemLijnInGebruik(lijn1);
            Console.WriteLine(kabel1.IsStartPositieLeeg());
            Console.WriteLine(kabel1.ToString());

            //Test om te zien of het verschuiven goed gaat.
            kabel1.VerschuifLijnen();
            Console.WriteLine(kabel1.ToString());

            //Test om te zien of een 2de lijn succesvol wordt toegevoegd
            Lijn lijn2 = new Lijn();
            kabel1.NeemLijnInGebruik(lijn2);
            Console.WriteLine(kabel1.ToString());

            //Test om te zien of het verschuiven van meerder lijnen goed gaat.
            kabel1.VerschuifLijnen();
            Console.WriteLine(kabel1.ToString());
            kabel1.VerschuifLijnen();

            //Kijken of het toevoegen van een 3de lijn goed gaat.
            Lijn lijn3 = new Lijn();
            kabel1.NeemLijnInGebruik(lijn3);
            Console.WriteLine(kabel1.ToString());

            //Hier verschuiven we de lijnen tot er een op de 9de positie is.
            kabel1.VerschuifLijnen();
            kabel1.VerschuifLijnen();
            kabel1.VerschuifLijnen();
            kabel1.VerschuifLijnen();
            kabel1.VerschuifLijnen();
            kabel1.VerschuifLijnen();
            Console.WriteLine(kabel1.ToString());

            //Hier testen we hoe de methode omgaat met een lijn op positie 9.
            kabel1.VerschuifLijnen();
            Console.WriteLine(kabel1.ToString());
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
        public int PositieOpDeKabel { get; set; }
    }

    class Kabel
    {
        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count == 0 || _lijnen.First.Value.PositieOpDeKabel >= 1)
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
                    _lijnen.RemoveLast();
                    l.PositieOpDeKabel = 0;
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
            if (_lijnen.Last.Value.PositieOpDeKabel == 9)
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
