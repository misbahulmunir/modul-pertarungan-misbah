using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class FriendListFromService
	{
        [XmlElement("PartialProfileFromService")]
        public List<PartialProfileFromService> players = new List<PartialProfileFromService>();
	}
}
