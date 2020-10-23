using System;
using System.Collections.Generic;
using System.Text;

namespace Week02
{
    public class CharacterCollection : List<Character>
    {

        public void SortBy(string columnName)
        {
            if (columnName == "HP")
            {
                this.Sort(CompareHP);
            }
        }

        private int CompareHP(Character x, Character y)
        {
            return x.HP - y.HP;
        }

        public int GetCharacterWithMostHP()
        {
            int maxHp = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].HP > maxHp)
                {
                    maxHp = this[i].HP;
                }
            }

            return maxHp;
        }

    }
}
