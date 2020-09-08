using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Beast
    {
        private bool summoned = true;
        private int rating;
        private int hitPoints = 700;
        private int defense = 60;
        private int power = 50;
        private int speed = 35;
        private int skill = 30;
        private int MOVES = 2;
        private int moveA = 60;
        private int moveB = 40;
        private String name;
        private String static_image;

        public bool Summoned { get => summoned; set => summoned = value; }
        public String Name { get => name; set => name = value; }
        public int HitPoints { get => hitPoints; set => hitPoints = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Power { get => power; set => power = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Skill { get => skill; set => skill = value; }
        public int MOVES1 { get => MOVES; set => MOVES = value; }
        public int MoveA { get => moveA; set => moveA = value; }
        public int MoveB { get => moveB; set => moveB = value; }
        public string Static_image { get => static_image; set => static_image = value; }
        public int Rating { get => rating; set => rating = value; }

        public String toString()
        {
            String str = "";
            str += "Name = " + name + "\n";
            str += "Summoned = " + Summoned+"\n";
            str += "HP = " + HitPoints + "\n";
            str += "Defense = " + Defense + "\n";
            str += "Power = " + Power + "\n";
            str += "Speed = " + Speed + "\n";
            str += "Skill = " + Skill + "\n";
            str += "Moves = " + MOVES1 + "\n";
            str += "Move A = " + MoveA + "\n";
            str += "Move B = " + MoveB + "\n";
            return str;
        }
        override
        public bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Beast))
            {
                Beast b = (Beast)obj;

                if (b.Name.Equals(this.name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
