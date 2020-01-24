using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Lib
{
    public enum Ability
    {
        Fly, Swim, Dig, Climb
    }

    public enum Element
    {
        Fire, Water, Ice, Thunder, Lightning, Posion, Sleep, Blast
    }

    [Serializable]
    public class Monster
    {
        public string name;
        public int health;
        public Ability ability;
        public Element element;
    }
}
