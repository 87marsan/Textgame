using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Player
    {
        public string Name { get; set; }
        public int Power = 5;
        public int CurrentHitPoints { get; set; } = 15;
        public int Armor = 1;
        public int Xp = 0;
        public int HealthPotions = 2;
        public int MaxHitPoints = 15;
        public int attack;
        public int Gold = 30;
        public int Level = 0;
        public bool HasKey = false;
        public int Kills = 0;
        Random random = new Random();


        public Player(string name)
        {
            Name = name;
        }

        public void PrintStats()
        {
            
            Console.WriteLine($"Name   : {Name}");
            Console.WriteLine($"Hp     : {CurrentHitPoints}/{MaxHitPoints}");
            Console.WriteLine($"Power  : {Power}");
            Console.WriteLine($"Armor  : {Armor}");
            Console.WriteLine($"Level  : {Level}");
            Console.WriteLine();
            Console.WriteLine($"Potions: {HealthPotions}");
            Console.WriteLine();
            Console.WriteLine($"Gold   : {Gold}");
            Console.WriteLine($"Xp     : {Xp}");
            Console.WriteLine($"Kills  : {Kills}");
            
        }
        public void Attack(Creature target)
        {
            attack = random.Next(0, Power);
        }
        public void PrintCombatStats()
        {
            Console.WriteLine(Name);
            Console.WriteLine("===================");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (CurrentHitPoints < 4)
                Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine($"HP            : {CurrentHitPoints}/{MaxHitPoints}");
            Console.ResetColor();
            Console.WriteLine($"Power         : {Power}");
            Console.WriteLine($"Armor         : {Armor}");
            Console.WriteLine("===================");
        }
        public void TakeDamage(int attack)
        {
            CurrentHitPoints -= attack;
        }

        public void LevelUp()
        {
            Level++;
            MaxHitPoints += 2;
            Power++;
            CurrentHitPoints = MaxHitPoints;
            Console.Clear();
            Console.WriteLine("Congrats, you have leveled up!");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"HP   : {MaxHitPoints}");
            Console.WriteLine($"Power: {Power}");
            Console.ReadKey();
        }

        public void Heal()
        {
            Console.Clear();
            Console.WriteLine($"Hp: {CurrentHitPoints}/{MaxHitPoints}");
            Console.WriteLine($"You have {HealthPotions} potions left.");
            Console.WriteLine("Press 1 to heal.");
            Console.WriteLine("Press 2 to back.");
            
            string input = Console.ReadLine();
            if (input == "1")
            {
                if (HealthPotions > 0)
                {
                    CurrentHitPoints = MaxHitPoints;
                    HealthPotions--;
                }
                Console.WriteLine("You have not enough health potions...");
            }

        }

        

    }
}
