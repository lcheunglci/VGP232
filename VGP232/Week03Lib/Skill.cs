using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Week03Lib
{
    public enum ElementType { Wind, Fire, Water, Ice }

    [Serializable]
    public class Skill
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("cost")]
        public int Cost { get; set; }
        [XmlElement("mod")]
        public int Modifier { get; set; }

        public ElementType Element { get; set; }


        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", Name, Cost, Modifier, Element);
        }

    }
}
