using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Boss : Creature
    {
        private Random random = new Random();
        public int HealthPotions = 5;
        public int BonusXP = 200;

        public Boss(string name, int power, int hitPoints, int armor, int level) : base(name, power, hitPoints, armor, level)
        {
        }
        
        public void Attack(Player target)
        {
            attack = random.Next(0, Power);
            attack -= target.Armor;
            if (attack < 0) attack = 0;
            if (CurrentHitPoints < 15)
            {
                Heal();
            }
        }
        public void Heal()
        {
            if (HealthPotions > 0)
            {
                CurrentHitPoints = MaxHitPoints;
                HealthPotions--;
            }

            Console.WriteLine();
        }

        

    }
}
