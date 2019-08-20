using System.Xml.Serialization;

namespace PokemonLib.Models
{
    [XmlRoot]
    public class Pokemon
    {
        public enum MonsterType
        {
            Grass,
            Fire,
            Water,
            Bug,
            Normal,
            Poison,
            Electric,
            Ground,
            Fairy,
            Fighting,
            Psychic,
            Ghost,
            Ice,
            Rock,
            Dragon
        }

        [XmlAttribute]
        public int Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int HP { get; set; }
        [XmlAttribute]
        public int Attack { get; set; }
        [XmlAttribute]
        public int Defense { get; set; }
        [XmlAttribute]
        public int MaxCP { get; set; }
        [XmlAttribute]
        public MonsterType MType { get; set; }
    }
}