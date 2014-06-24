using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class CardRequestFromService
	{
        [XmlElement("OfferedCardsFromService")]
        public List<CardRequest> offeredCards = new List<CardRequest>();

        [XmlElement("RequestedCardsFromService")]
        public List<CardRequest> requestedCards = new List<CardRequest>(); 
	}
}
