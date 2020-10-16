using System;
using System.Collections.Generic;
using System.Text;

namespace Week02
{
    public class Character
    {
        public int HP { get; set; }
        public int MP { get; set; }

        public string Name { get; set; }

        public Character(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
        }

    }
}
