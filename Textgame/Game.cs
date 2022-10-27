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
        Store store = new Store();
        Random random = new Random();
        

        public void Start()
        {
            Console.WriteLine("Welcome to the Game");
            Console.WriteLine();
            Console.WriteLine("Let's begin with your name... ");
            Console.Write("Enter name: ");
            player.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Ok, {player.Name}. Here is your characters stats");
            Console.WriteLine();
            player.PrintStats();
            Console.WriteLine();
            Console.WriteLine($"{player.Name} wake up out in the wilderness and don't remember a thing. All you can see is a house with a locked door.");
            Console.WriteLine("-I need to find the key i guess?");
            Console.WriteLine();
            Console.WriteLine("Press any key to start your journey!");
            Console.ReadKey();
            Chapter1();
        }

        public void Chapter1()
        {
            Console.Clear();
            string input = "";
            while (input != "5")
            {
                Console.WriteLine("=============================================================");
                Console.WriteLine("1. Search the wilderness...");
                Console.WriteLine();
                Console.WriteLine("2. Go to the house with the locked door.");
                Console.WriteLine();
                Console.WriteLine("3. Set camp and restore some health. Maybe visit the shop?");
                Console.WriteLine();
                Console.WriteLine("4. Check Stats/Inventory");
                Console.WriteLine();
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

        public void Chapter2()
        {

        }

        public void SearchWilderness()
        {
            Console.Clear();
            Console.WriteLine("You searching the wilderness looking for a key to the strange house...");
            Console.ReadKey();
            int nr = random.Next(1, 6);
            switch (nr)
            {
                case 1:
                    Console.WriteLine("Something approach");
                    combat.Fight(player, new Creature("Rat", 5, 6, 0,1));
                    combat.Fight(player, new Creature("Snake", 6, 5, 0,1));
                    break;
                case 2:
                    Console.WriteLine("Something approach");
                    combat.Fight(player, new Creature("Troll", 8, 10, 0,2));
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("After a while searching you found nothing...");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Something approach");
                    combat.Fight(player, new Creature("Rat", 5, 6, 0,1));
                    combat.Fight(player, new Creature("Giant rat", 7, 7, 0,2));
                    break;
                case 5:
                    Console.WriteLine("Something approach");
                    combat.Fight(player, new Creature("Rat", 5, 6, 0,1));
                    combat.Fight(player, new Creature("Rat", 5, 6, 0,1));
                    combat.Fight(player, new Creature("Rat", 5, 6, 0,1));
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
                Console.ReadKey();
                Chapter2();
            }
            else
            {
                Console.WriteLine("You don't have the key to the door!");
                Console.WriteLine("");
                Console.WriteLine("Suggest you search the wilderness...");
                Console.WriteLine("Don't forget to visit the shop for potions!");
                Console.ReadKey();
            }
        }

        public void SetCamp()
        {
            Console.Clear();
            Console.WriteLine($"{player.CurrentHitPoints}/{player.MaxHitPoints}");
            Console.WriteLine($"{player.Name} set up camp for the night and restore some health...");
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
            {
                store.Shop(player);
            }
            Console.Clear();
        }

        
    }
}
