using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Textgame
{
    public class Combat
    {
        Random random = new Random();
        public void Fight(Player player, Creature monster)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Wooooahaa!! An evil {monster.Name} appears, prepare for battle!!");
            Console.ReadKey();
            Random random = new();
            
            bool IsDead = false;

            while (!IsDead)
            {
                Console.Clear();
                player.PrintCombatStats();
                Console.WriteLine("");
                monster.PrintStats();
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
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

                        if (player.attack == player.Power)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{player.Name} attack with his sword and hit the enemy {monster.Name} with a critical hit! dealing {player.attack} damage!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{player.Name} attack with his rusty sword and hit enemy {monster.Name}, making {player.attack} damage!");
                        }
                        if (monster.CurrentHitPoints <= 0)
                        {
                            IsDead = true;
                            Win(player, monster);
                            break;
                        }
                        Console.ReadLine();

                        Console.WriteLine("");

                        monster.Attack(player);
                        player.TakeDamage(monster.attack);
                        
                        Console.WriteLine();
                        Console.WriteLine($"The awful enemy {monster.Name} attack and deals {monster.attack} damage!");
                        Console.ReadLine();
                        
                        if (player.CurrentHitPoints <= 0)
                        {
                            Console.WriteLine($"The evil {monster.Name} killed you... You are too weak!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }

                        break;
                    case "2":
                        player.Heal();
                        break;
                    case "3":
                        Console.WriteLine($"{player.Name} tries to run away...");
                        var nr = random.Next(minValue:1, maxValue:3);
                        switch (nr)
                        {
                            case 1:
                                Console.WriteLine("You ran away...");
                                Console.ReadKey();
                                IsDead = true;
                                break;
                            default:
                                Console.WriteLine("You couldn't run away..");
                                monster.Attack(player);
                                player.TakeDamage(monster.attack);
                                Console.WriteLine($"{monster.Name} attack you when you tried to run away and attack you with {monster.attack} damage!");
                                if (player.CurrentHitPoints <= 0)
                                {
                                    Console.WriteLine($"The evil {monster.Name} killed you... You are too weak!");
                                    Console.ReadKey();
                                    Environment.Exit(0);
                                }
                                Console.ReadKey();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice...");
                        break;
                }
            }
        }

        public void Win(Player player, Creature monster)
        {
            int xp = random.Next(2, monster.Power * 10);
            int gold = random.Next(0, monster.Power * 3);

            player.Gold = player.Gold + gold;
            player.Xp = player.Xp + xp;
            player.Kills++;

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Congratulations... You defeated the evil {monster.Name}!");
            Console.WriteLine();
            Console.WriteLine($"You have gained {xp} xp!");
            Console.WriteLine($"You found {gold} gold.");

            int lucky = random.Next(1, 6);
            if (lucky == 3)
            {
                player.HealthPotions++;
                Console.WriteLine("You have found one health potion.");
            }


            Console.ReadLine();

            if (player.Xp >= 400)
            {
                player.LevelUp();
                player.Xp = 0;
            }
        }



    }
}
