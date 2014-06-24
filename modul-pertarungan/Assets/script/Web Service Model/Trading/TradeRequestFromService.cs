using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class TradeRequestFromService
	{
        [XmlElement("RequestSenderFromService")]
        public List<RequestSenderFromService> players = new List<RequestSenderFromService>();
	}
}
