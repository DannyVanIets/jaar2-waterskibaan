using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Moves : IMoves
    {
        public string naamMove = "";

        public Moves()
        {
            Random random = new Random();
            if (random.Next(1, 5) == 1)
            {
                naamMove = "Springen";
            }
            else if (random.Next(1, 5) == 2)
            {
                naamMove = "EenBeen";
            }
            else if (random.Next(1, 5) == 3)
            {
                naamMove = "EenHand";
            }
            else if (random.Next(1, 5) == 4)
            {
                naamMove = "Omdraaien";
            }
        }

        public int Uitvoeren()
        {
            int result = 0;
            if (naamMove == "Springen")
            {
                result += Springen();
            }
            else if (naamMove == "EenHand")
            {
                result += EenHandLijnVastHouden();
            }
            else if (naamMove == "EenBeen")
            {
                result += EenBeenSkiën();
            }
            else if (naamMove == "Omdraaien")
            {
                result += Omdraaien();
            }
            return result;
        }

        public int Springen()
        {
            Random random = new Random();
            if (random.Next(1, 3) == 1)
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }

        public int EenBeenSkiën()
        {
            Random random = new Random();
            if (random.Next(1, 3) == 1)
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        public int EenHandLijnVastHouden()
        {
            Random random = new Random();
            if (random.Next(1, 3) == 1)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        public int Omdraaien()
        {
            Random random = new Random();
            if (random.Next(1, 3) == 1)
            {
                return 25;
            }
            else
            {
                return 0;
            }
        }
    }
}
