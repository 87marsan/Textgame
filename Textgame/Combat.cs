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
            int xp = 0;
            if (monster.Level < 2)
            {
                xp = random.Next(10,20);
            }

            if (monster.Level == 2)
            {
                xp = random.Next(20,40);
            }

            if (monster.Level > 2)
            {
                xp = random.Next(40,70);
            }
           
            int gold = random.Next(3, monster.Power * 5);

            player.Gold = player.Gold + gold;
            player.Xp = player.Xp + xp;
            player.Kills++;

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Congratulations... You defeated the evil {monster.Name}!");
            Console.WriteLine();
            Console.WriteLine($"You have gained {xp} xp!");
            Console.WriteLine($"You found {gold} gold.");

            int potionLoot = random.Next(1, 6);
            if (potionLoot == 3)
            {
                player.HealthPotions++;
                Console.WriteLine("You have found one health potion.");
            }

            int HasKeyLoot = random.Next(1, 20);
            {
                if (HasKeyLoot == 10)
                {
                    player.HasKey = true;
                    Console.WriteLine("You found a old rusty key ! ! ! ! ! ! ! ! !");
                }
            }
            Console.ReadLine();

            if (player.Xp >= 300)
            {
                player.LevelUp();
                player.Xp = 0;
            }
        }



    }

    public class Combat2
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
                            Console.WriteLine($"{player.Name} attack with his sword and hit enemy {monster.Name}, making {player.attack} damage!");
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
                        var nr = random.Next(minValue: 1, maxValue: 3);
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
            int xp = 0;
            if (monster.Level < 2)
            {
                xp = random.Next(10, 20);
            }

            if (monster.Level == 2)
            {
                xp = random.Next(20, 40);
            }

            if (monster.Level > 2)
            {
                xp = random.Next(40, 70);
            }


            int gold = random.Next(3, monster.Power * 5);

            player.Gold = player.Gold + gold;
            player.Xp = player.Xp + xp;
            player.Kills++;

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Congratulations... You defeated the evil {monster.Name}!");
            Console.WriteLine();
            Console.WriteLine($"You have gained {xp} xp!");
            Console.WriteLine($"You found {gold} gold.");

            int potionFind = random.Next(1, 6);
            if (potionFind == 3)
            {
                player.HealthPotions++;
                Console.WriteLine("You have found one health potion.");
            }

            Console.ReadLine();
            Console.Clear();
            
            if (player.Xp >= 400)
            {
                player.LevelUp();
                player.Xp = 0;
            }
        }

    }

    public class Combat3
    {
        Random random = new Random();
        public void Fight(Player player, Boss boss)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Wooooahaa!! An evil {boss.Name} appears, prepare for battle!!");
            Console.ReadKey();
            Random random = new();

            bool IsDead = false;

            while (!IsDead)
            {
                Console.Clear();
                player.PrintCombatStats();
                Console.WriteLine("");
                boss.PrintStats();
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
                        player.Attack(boss);
                        boss.TakeDamage(player.attack);

                        if (player.attack == player.Power)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{player.Name} attack with his sword and hit the enemy {boss.Name} with a critical hit! dealing {player.attack} damage!");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{player.Name} attack with his sword and hit enemy {boss.Name}, making {player.attack} damage!");
                        }
                        if (boss.CurrentHitPoints <= 0)
                        {
                            IsDead = true;
                            Win(player, boss);
                            break;
                        }
                        Console.ReadLine();

                        Console.WriteLine("");

                        boss.Attack(player);
                        player.TakeDamage(boss.attack);

                        Console.WriteLine();
                        Console.WriteLine($"The awful enemy {boss.Name} attack and deals {boss.attack} damage!");
                        Console.ReadLine();

                        if (player.CurrentHitPoints <= 0)
                        {
                            Console.WriteLine($"The evil {boss.Name} killed you... You are too weak!");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }

                        break;
                    case "2":
                        player.Heal();
                        break;
                    case "3":
                        Console.WriteLine($"{player.Name} tries to run away...");
                        var nr = random.Next(minValue: 1, maxValue: 3);
                        switch (nr)
                        {
                            case 1:
                                Console.WriteLine("You ran away...");
                                Console.ReadKey();
                                IsDead = true;
                                break;
                            default:
                                Console.WriteLine("You couldn't run away..");
                                boss.Attack(player);
                                player.TakeDamage(boss.attack);
                                Console.WriteLine($"{boss.Name} attack you when you tried to run away and attack you with {boss.attack} damage!");
                                if (player.CurrentHitPoints <= 0)
                                {
                                    Console.WriteLine($"The evil {boss.Name} killed you... You are too weak!");
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
        public void Win(Player player, Boss boss)
        {
            int xp = 0;
            player.Xp += boss.BonusXP;
            int gold = random.Next(3, boss.Power * 5);

            player.Gold = player.Gold + gold;
            player.Xp = player.Xp + xp;
            player.Kills++;

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"Congratulations... You defeated the evil {boss.Name}!");
            Console.WriteLine();
            Console.WriteLine($"You have gained {xp} xp!");
            Console.WriteLine($"You found {gold} gold.");

            int potionFind = random.Next(1, 6);
            if (potionFind == 3)
            {
                player.HealthPotions++;
                Console.WriteLine("You have found one health potion.");
            }

            Console.ReadLine();
            Console.Clear();

            if (player.Xp >= 400)
            {
                player.LevelUp();
                player.Xp = 0;
            }
        }
    }
}
