using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class PlayerBuildingFromService
	{
        [XmlElement("BuildingFromService")]
        public List<BuildingFromService> buildings = new List<BuildingFromService>();
	}
}
