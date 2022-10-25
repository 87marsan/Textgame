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
       
        
        
        public Creature(string name, int power, int currenthitPoints, int armor)
        {
            Name = name;
            Power = power;
            CurrentHitPoints = currenthitPoints;
            Armor = armor;
        }
        public void Attack(Player target)
        {
            Random random = new Random();
            attack = random.Next(0, Power);
            Console.WriteLine($"{Name} attack and scores {attack} dmg");

        }
        public void TakeDamage(int attack)
        {
            CurrentHitPoints -= attack;
            if (CurrentHitPoints <= 0)
            {
                Isdead = true;
                CurrentHitPoints = 0;
                Die();
            }
            Console.WriteLine($"{Name} have {CurrentHitPoints} hp left");
        }

        public void Die()
        {
            Console.WriteLine($"{Name} is dead!!");
            
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
