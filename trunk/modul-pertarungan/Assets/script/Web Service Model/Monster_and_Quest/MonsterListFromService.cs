using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
    public class MonsterListFromService
    {
        [XmlElement("MonstersFromService")]
        public List<MonstersFromService> quest = new List<MonstersFromService>();
    }
}
