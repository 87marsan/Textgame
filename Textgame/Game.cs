using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Game
    {
        Player player = new Player("player");
        Combat combat = new Combat();
        Random random = new Random();

        public void Start()
        {
            Console.WriteLine("Welcome to the forrest");
            Console.WriteLine();
            Console.WriteLine("Let's begin with your name... ");
            Console.Write("Enter name: ");
            player.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Ok, {player.Name}. Here is your characters stats");
            Console.WriteLine();
            player.PrintStats();
            Console.WriteLine();
            Console.WriteLine("Press any key to start your journey!");
            Console.ReadKey();
        }

        public void Chapter1()
        {
            Console.Clear();
            string input = "";
            while (input != "5")
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("1. Search the wilderness...");
                Console.WriteLine("2. Go to the house(key requierd)");
                Console.WriteLine("3. Set camp and restore some health. Maybe visit the shop?");
                Console.WriteLine("4. Check Stats/Inventory");
                Console.WriteLine("5. Exit game");


                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SearchWilderness();
                        break;
                    case "2":
                        TheHouse();
                        break;
                    case "3":
                        SetCamp();
                        break;
                    case "4":
                        Console.Clear();
                        player.PrintStats();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Tack för att du spelade....");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val...");
                        break;
                }
            }



        }

        public void SearchWilderness()
        {
            Console.Clear();
            Console.WriteLine("You searching the forest looking for a key to the house...");
            Console.ReadKey();
            int nr = random.Next(1, 6);
            switch (nr)
            {
                case 1:
                    Console.WriteLine("Something approche");
                    combat.Fight(player, new Creature("Rat", 5, 6, 0));
                    combat.Fight(player, new Creature("Snake", 6, 5, 0));
                    break;
                case 2:
                    Console.WriteLine("Something approche");
                    combat.Fight(player, new Creature("Troll", 8, 10, 0));
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("After a while searching you found nothing...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Something approche");
                    combat.Fight(player, new Creature("Rat", 5, 6, 0));
                    combat.Fight(player, new Creature("Giant rat", 7, 7, 0));
                    break;
                case 5:
                    Console.WriteLine("Something approche");
                    combat.Fight(player, new Creature("Rat", 5, 6, 0));
                    combat.Fight(player, new Creature("Rat", 5, 6, 0));
                    combat.Fight(player, new Creature("Rat", 5, 6, 0));
                    break;
                case 6:
                    Console.WriteLine("You found a health potion!");
                    player.HealthPotions++;
                    break;
            }

        }

        public void TheHouse()
        {
            Console.Clear();
            if (player.HasKey)
            {
                Console.WriteLine("You lock up the door and enter the house...");
            }
            else
            {
                Console.WriteLine("You don't have the key to the door...");
                Console.WriteLine("");
                Console.WriteLine("Suggest you search the forrest.");
                Console.WriteLine("Don't forget to visit the shop for potions!");
                Console.ReadKey();
            }
        }

        public void SetCamp()
        {
            Console.Clear();
            Console.WriteLine($"{player.CurrentHitPoints}/{player.MaxHitPoints}");
            Console.WriteLine($"{player.Name} set camp and restore some health...");
            player.CurrentHitPoints = player.MaxHitPoints;
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"{player.CurrentHitPoints}/{player.MaxHitPoints}");
            Console.WriteLine($"{player.Name} have rested and replenished his health.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("1. Visit store");
            Console.WriteLine("2. Venture forth");
            string input = Console.ReadLine();
            if (input == "1")
                Store();
            Console.Clear();
        }

        public void Store()
        {
            Console.Clear();
            string input = "";
            while (input != "4")
            {
                Console.Clear();
                Console.WriteLine($"Gold    : {player.Gold}");
                Console.WriteLine($"Potions : {player.HealthPotions}");
                Console.WriteLine();
                Console.WriteLine("()()()()()()()()()()()()");
                Console.WriteLine();
                Console.WriteLine("Welcome friend!!");
                Console.WriteLine();
                Console.WriteLine("What would you like to buy?");
                Console.WriteLine("");
                Console.WriteLine("1. Health potion    <60  g>");
                Console.WriteLine("2. Old rusty key    <300 g>");
                Console.WriteLine("3. Potion of Power  <500 g>");
                Console.WriteLine("4. Gamble ***");
                Console.WriteLine("4. Exit store");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (player.Gold > 59)
                        {
                            int Price = 60;
                            player.Gold = player.Gold - Price;
                            player.HealthPotions++;
                            Console.WriteLine("You have bought 1 health potion.");
                        }
                        else
                        {
                            Console.WriteLine("You don't have the gold...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "2":
                        if (player.Gold > 299)
                        {
                            int Price = 300;
                            player.Gold = player.Gold - Price;
                            player.HasKey = true;
                            Console.WriteLine("You have bought an old rusty key.");
                        }
                        else
                        {
                            Console.WriteLine("You don't have the gold...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "3":
                        if (player.Gold > 499)
                        {
                            int Price = 500;
                            player.Gold = player.Gold - Price;
                            Console.WriteLine("You bought the magical potion, suddenly you feel stronger!!");
                            player.Power =+ 2;
                            Console.ReadKey();
                        }
                        break;
                        
                }
                
            }
            Console.WriteLine("See you soon!");
            Console.ReadKey();
        }
    }
}
