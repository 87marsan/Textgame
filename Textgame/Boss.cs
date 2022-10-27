using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Textgame
{
    public class Boss : Creature
    {
        public Boss(string name, int power, int hitPoints, int armor, int level) : base(name, power, hitPoints, armor, level)
        {
        }
    }
}
