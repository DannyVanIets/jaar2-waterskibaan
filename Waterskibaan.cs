using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    class Waterskibaan
    {
        public Kabel kabel = new Kabel();
        LijnenVoorraad lv = new LijnenVoorraad();

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                lv.LijnToevoegenAanRij(new Lijn());
            }
        }

        //Deze methode zorgt ervoor dat een lijn op positie 9 wordt toegevoegd aan de lijnen voorraad en daarna wordt toegevoegd.
        public void VerplaatsKabel()
        {
            if(lv.GetAantalLijnen() != 0)
            {
                kabel.VerschuifLijnen();
            }

            foreach(Lijn lijn in kabel._lijnen)
            {
                lijn.sporter.HuidigeMove();
            }
        }

        public void SporterStart(Sporter sp)
        {
            if (sp.Skies == null || sp.Zwemvest == null)
            {
                throw new ArgumentException(nameof(sp), "Sporter moet skies of zwemvest hebben!");
            }

            Lijn SporterLijn = new Lijn();
            SporterLijn.sporter = sp;

            
            kabel.NeemLijnInGebruik(SporterLijn);
            lv.VerwijderEersteLijn();

            Random random = new Random();
            sp.AantalRondenNogTeGaan = random.Next(1, 3);

            if (random.Next(1, 6) == 1)
            {
                sp.KledingKleur = Color.Green;
            }
            else if (random.Next(1, 6) == 2)
            {
                sp.KledingKleur = Color.Blue;
            }
            else if (random.Next(1, 6) == 3)
            {
                sp.KledingKleur = Color.Red;
            }
            else if (random.Next(1, 6) == 4)
            {
                sp.KledingKleur = Color.Purple;
            }
            else if (random.Next(1, 6) == 5)
            {
                sp.KledingKleur = Color.White;
            }
        }

        public override string ToString()
        {
            return lv.ToString() + "\n" + kabel.ToString();
        }
    }
}
