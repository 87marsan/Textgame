using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Console = System.Console;

namespace Textgame
{
    public class Creature
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int CurrentHitPoints { get; set; }
        public int Armor { get; set; }
        public int attack;
        public bool Isdead = false;
        Random random = new Random();


        public Creature(string name, int power, int currentHitPoints, int armor)
        {
            Name = name;
            Power = power;
            CurrentHitPoints = currentHitPoints;
            Armor = armor;
        }
        public void Attack(Player target)
        {

            attack = random.Next(0, Power);


        }
        public void TakeDamage(int attack)
        {
            CurrentHitPoints -= attack;
        }

        public void PrintStats()
        {
            Console.WriteLine(Name);
            Console.WriteLine("===================");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (CurrentHitPoints < 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine($"HP            : {CurrentHitPoints}");
            Console.ResetColor();
            Console.WriteLine($"Power         : {Power}");
            Console.WriteLine($"Armor         : {Armor}");
            Console.WriteLine("===================");


        }





    }

}
