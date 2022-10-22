using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Combat
    {
        Player player { get; set; }
        Creature monster { get; set; }
        bool isAlive;

        public void Fight(Player player, Creature monster)
        {
            Console.WriteLine("Välkommen till fighten...");
            Console.WriteLine("1. attack");
            Console.WriteLine("2. run away");
            string input = Console.ReadLine();

        }
    }
}
