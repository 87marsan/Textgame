using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Creature
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int HitPoints { get; set; }
        public int Armor { get; set; }
        public bool IsDead;
        public int attack;

        public Creature(string name, int power, int hitPoints, int armor)
        {
            Name = name;
            Power = power;
            HitPoints = hitPoints;
            Armor = armor;
            
        }

        public int Attack()
        {
            Random random = new Random();
            attack = random.Next(0, Power);
            Console.WriteLine($"You hit with {attack} dmg");
            return attack;
        }

        public void Defend(int attack)
        {
            HitPoints -= attack;
            Console.WriteLine($"Monster have {HitPoints} left");
            if (HitPoints <= 0)
            {
                IsDead = true;
            }
        }
    }
}
