using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class PlayerRankingFromService
	{
        [XmlElement("PlayerStatsFromService")]
        public List<PlayerStatsFromService> playerDetail = new List<PlayerStatsFromService>();
	}
}
