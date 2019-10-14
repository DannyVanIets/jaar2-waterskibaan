using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public static class MoveCollection
    {
        public static List<Moves> GetWillekeurigeMoves()
        {
            List<Moves> moves = new List<Moves>();
            Random random = new Random();
            for(int i = 0; i < random.Next(0, 21); i++)
            {
                moves.Add(new Moves());
            }
            return moves;
        }
    }
}
