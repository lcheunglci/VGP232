using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Week03
{
    [Serializable]
    public class Skill
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("cost")]
        public int Cost { get; set; }
        [XmlElement("mod")]
        public int Modifier { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Name, Cost, Modifier);
        }

    }
}
