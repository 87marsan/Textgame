using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Store
    {
        public void Shop(Player player)
        {
            Console.Clear();
            string input = "";
            while (input != "6")
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
                Console.WriteLine("1. Health potion       < 60  g>");
                Console.WriteLine("2. Old rusty key       < 300 g>");
                Console.WriteLine("3. Potion of Power++2  < 400 g>");
                Console.WriteLine("4. Potion of Armor++2  < 500 g");
                Console.WriteLine("5. Gamble ***");
                Console.WriteLine("6. Exit store");
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
                            Console.ReadKey();
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
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough gold...");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "3":
                        if (player.Gold > 399)
                        {
                            int Price = 500;
                            player.Gold = player.Gold - Price;
                            Console.WriteLine("You bought a magical potion, suddenly you feel stronger!!");
                            player.Power = +2;
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        if (player.Gold > 499)
                        {
                            int Price = 500;
                            player.Gold = player.Gold - Price;
                            Console.WriteLine("You bought a magical potion, suddenly you feel stronger!!");
                            player.Armor = +2;
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        Gamble(player);
                        break;

                }

            }
            Console.WriteLine("See you soon!");
            Console.ReadKey();

        }

        public void Gamble(Player player)
        {
            
            string input = "";
            while (input != "2")
            {
                Console.Clear();
                Console.WriteLine("Rules are simple, you bet 10g for double or nothing!");
                Console.WriteLine($"Gold: {player.Gold}");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Exit");
                input = Console.ReadLine();
                
                if (input == "1")
                {
                    Random random = new Random();
                    int headOrTails;
                    headOrTails = random.Next(2);

                    if (player.Gold < 10)
                    {
                        Console.WriteLine("Not enough gold...");
                        Console.ReadLine();
                        break;
                    }

                    if (headOrTails == 1)
                    {
                        Console.WriteLine("Congratulations, you won 10g.");
                        player.Gold += 10;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You loose! ");
                        player.Gold -= 10;
                        Console.ReadLine();
                    }
                }





            }

        }
    }
}
