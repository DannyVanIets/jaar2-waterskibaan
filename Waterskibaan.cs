using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        Kabel kabel { get; set; }
        LijnenVoorraad lv = new LijnenVoorraad();

        public Waterskibaan(Kabel kbl)
        {
            for (int i = 0; i < 15; i++)
            {
                lv.LijnToevoegenAanRij(new Lijn());
            }
            kabel = kbl;
        }

        //Deze methode zorgt ervoor dat een lijn op positie 9 wordt toegevoegd aan de lijnen voorraad en daarna wordt toegevoegd.
        public void VerplaatsKabel()
        {
            if (kabel.VerwijderLijnVanKabel() != null)
            {
                lv.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
                kabel.VerwijderEenLijn(kabel.VerwijderLijnVanKabel());
            }
        }

        public void SporterStart(Sporter sp)
        {
            kabel.sporter = sp;
            lv.sporter = sp;

            Lijn SporterLijn = new Lijn();

            if(kabel.IsStartPositieLeeg())
            {
                kabel.NeemLijnInGebruik(SporterLijn);
                lv.VerwijderEersteLijn();
            }

            Random random = new Random();
            sp.AantalRondenNogTeGaan = random.Next(1, 3);

            if (random.Next(1, 6) == 1)
            {
                sp.KledingKleur = "Groen";
            }
            else if (random.Next(1, 6) == 2)
            {
                sp.KledingKleur = "Blauw";
            }
            else if (random.Next(1, 6) == 3)
            {
                sp.KledingKleur = "Rood";
            }
            else if (random.Next(1, 6) == 4)
            {
                sp.KledingKleur = "Paars";
            }
            else if (random.Next(1, 6) == 5)
            {
                sp.KledingKleur = "Wit";
            }
        }

        public override string ToString()
        {
            return lv.ToString() + "\n" + kabel.ToString();
        }
    }
}
