using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class QuestListFromService
	{
        [XmlElement("QuestFromService")]
        public List<QuestFromService> quest = new List<QuestFromService>();
	}
}
