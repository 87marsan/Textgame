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
        private int Power = 5;

        public bool Isdead { get; private set; }
        Random random = new Random();
        public int CurrentHitPoints = 15;
        public int Armor = 1;
        public int Xp = 0;
        public int HealthPotions = 3;
        public int MaxHitPoints = 15;
        public bool IsDead = false;
        public int attack;
        public int Gold = 0;


        public Player(string name)
        {
            Name = name;
        }

        public void PrintStats()
        {
            Console.WriteLine($"Name   : {Name}");
            Console.WriteLine($"Hp     : {CurrentHitPoints}");
            Console.WriteLine($"Power  : {Power}");
            Console.WriteLine($"Potions: {HealthPotions}");
            Console.WriteLine($"Armor  : {Armor}");
            Console.WriteLine($"Gold   : {Gold}");
            Console.WriteLine($"Xp     : {Xp}");
        }
        public void Attack(Creature target)
        {
            attack = random.Next(0, Power);
            Console.WriteLine($"{Name} attack and scores {attack} dmg");
        }
        public void PrintCombatStats()
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

        public void LevelUp()
        {
            MaxHitPoints += 1;
            Power += 2;
        }

        public void AvslutaSpelet()
        {
            Console.WriteLine("tyvärr dog du, spelet är slut.");
            Environment.Exit(0);
        }

        public void Heal()
        {
            Console.WriteLine($"You have {HealthPotions} potions left.");
            Console.WriteLine("Press 1 to heal.");
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

        public void Die()
        {
            Console.WriteLine("Du är död");
            Environment.ExitCode = 0;
        }

    }
}
