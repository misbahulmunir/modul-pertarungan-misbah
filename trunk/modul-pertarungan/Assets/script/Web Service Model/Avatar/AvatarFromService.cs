using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class AvatarFromService
	{
        [XmlElement("AviFromService")]
        public List<AviFromService> aviDetail = new List<AviFromService>();
	}
}
