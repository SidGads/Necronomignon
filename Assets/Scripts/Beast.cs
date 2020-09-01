using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Beast
    {
        public bool Summoned = true;
        public int Rating = 0;
        public int HitPoints = 700;
        public int Defense = 60;
        public int Power = 50;
        public int Speed = 35;
        public int Skill = 30;
        public int MOVES = 2;
        public int MoveA = 60;
        public int MoveB = 40;
        internal object name;

        public String toString()
        {
            String str = "";
            str += "Summoned = " + Summoned+"\n";
            str += "HP = " + HitPoints + "\n";
            str += "Defense = " + Defense + "\n";
            str += "Power = " + Power + "\n";
            str += "Speed = " + Speed + "\n";
            str += "Skill = " + Skill + "\n";
            str += "Moves = " + MOVES + "\n";
            str += "Move A = " + MoveA + "\n";
            str += "Move B = " + MoveB + "\n";
            return str;
        }
    }
}
