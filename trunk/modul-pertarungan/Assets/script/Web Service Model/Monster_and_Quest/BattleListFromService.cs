using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class BattleListFromService
	{        
        [XmlElement("BattleFromService")]
        public List<BattleFromService> battle = new List<BattleFromService>();
	}
}
