using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Classes
    {
        
    }

    class Sporter
    {
        public int AantalRondenNogTeGaan = 0;
        public Zwemvest Zwemvest;
        public Skies Skies;
        public Color KledingKleur;
        public Moves<IMoves> list = new Moves<IMoves>();
        public Sporter(List<IMoves> moves)
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

    class Moves<T>
    {

    }

    //Replacement for Color, which isn't a type in a console application.
    class Color
    {

    }
}