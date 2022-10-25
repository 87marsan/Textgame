using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Combat
    {
        Random random = new Random();
        public void Fight(Player player, Creature monster)
        {
            bool IsDead = false;

            while (!IsDead)
            {
                Console.Clear();
                player.PrintCombatStats();
                Console.WriteLine("");
                monster.PrintStats();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Heal");
                Console.WriteLine("3. Run Away");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        player.Attack(monster);
                        monster.TakeDamage(player.attack);
                        if (monster.CurrentHitPoints <= 0) IsDead = true;
                        Console.WriteLine("");
                        if (monster.CurrentHitPoints <= 0) break;
                        monster.Attack(player);
                        player.TakeDamage(monster.attack);

                        Console.ReadLine();
                        break;
                    case "2":
                        player.Heal();
                        break;
                    default:
                        Console.WriteLine("");
                        break;
                }
            }
            
            int xp = random.Next(2, monster.Power * 10);
            int gold = random.Next(0, monster.Power * 3);

            player.Gold = player.Gold + gold;
            player.Xp = player.Xp + xp;

            Console.WriteLine($"Congratulations... You defeated the evil{monster.Name} ");
            Console.WriteLine($"You have gained {xp} xp!!");
            Console.WriteLine($"You found {gold} gold.");
            
            Console.ReadLine();


        }


    }
}
