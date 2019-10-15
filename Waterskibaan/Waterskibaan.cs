using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public Kabel kabel = new Kabel();
        public LijnenVoorraad lv = new LijnenVoorraad();

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
            Lijn laatsteLijn = kabel.VerwijderLijnVanKabel();

            if(laatsteLijn != null)
            {
                lv.LijnToevoegenAanRij(laatsteLijn);
            }

            if (lv.GetAantalLijnen() != 0)
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
            int aantalRonden = random.Next(0, 2);
            sp.AantalRondenNogTeGaan = aantalRonden;
            sp.aantalRonden = aantalRonden + 1;
        }

        public override string ToString()
        {
            return lv.ToString() + "\n" + kabel.ToString();
        }
    }
}
