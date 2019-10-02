using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        Kabel Kabel { get; set; }
        LijnenVoorraad lv = new LijnenVoorraad();

        public Waterskibaan(Kabel kabel)
        {
            for(int i = 0; i < 15; i++)
            {
                lv.LijnToevoegenAanRij(new Lijn());
            }
            Kabel = kabel;
        }

        //Deze methode zorgt ervoor dat een lijn op positie 9 wordt toegevoegd aan de lijnen voorraad en daarna wordt toegevoegd.
        public void VerplaatsKabel()
        {
            if(Kabel.VerwijderLijnVanKabel() != null)
            {
                lv.LijnToevoegenAanRij(Kabel.VerwijderLijnVanKabel());
                Kabel.VerwijderEenLijn(Kabel.VerwijderLijnVanKabel());
            }
        }

        public override string ToString()
        {
            return lv.ToString() + "\n" + Kabel.ToString();
        }
    }
}
