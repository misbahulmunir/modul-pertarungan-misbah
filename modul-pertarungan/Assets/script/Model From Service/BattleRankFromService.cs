using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class BattleRankFromService
	{
        [XmlElement("EnemyPlayerFromService")]
        public List<EnemyPlayerFromService> enemyPlayer = new List<EnemyPlayerFromService>();
	}
}
