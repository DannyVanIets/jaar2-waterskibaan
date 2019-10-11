using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Testing
    {
        static void Main(string[] args)
        {
            //TestOpdracht2();
            //TestOpdracht3();
            //TestOpdracht4();
            //TestOpdracht5();
        }

        private static void TestOpdracht5()
        {
            //Sporter sporter = new Sporter();
            //Console.WriteLine(sporter.ToString());
        }

        private static void TestOpdracht4()
        {
            //Al deze code kijkt als er een lijn op positie 9 is of het dan goed wordt verplaats naar de lijnvoorraad.
            Kabel kabel = new Kabel();
            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();

            kabel.NeemLijnInGebruik(lijn1);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn2);

            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel.ToString());

            Waterskibaan wsb = new Waterskibaan(kabel);
            Console.WriteLine(wsb.ToString());
            wsb.VerplaatsKabel();
            Console.WriteLine(wsb.ToString());
        }

        private static void TestOpdracht3()
        {
            LijnenVoorraad lv1 = new LijnenVoorraad();
            Lijn lijn1 = new Lijn();

            //Hier testen we om te kijken of de ToString en GetAantalLijnen methodes goed werken zonder iets toe te voegen.
            Console.WriteLine(lv1.ToString());

            //Hier testen we het toevoegen van een lijn.
            lv1.LijnToevoegenAanRij(lijn1);
            Console.WriteLine(lv1.ToString());

            //Hier testen we het toevoegen van 2de lijn.
            Lijn lijn2 = new Lijn();
            lv1.LijnToevoegenAanRij(lijn2);
            Console.WriteLine(lv1.ToString());

            //Hier testen we het verwijderen van de 1ste lijn.
            lv1.VerwijderEersteLijn();
            Console.WriteLine(lv1.ToString());
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
}
