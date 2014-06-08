using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ModulPertarungan
{
	public class MessagesFromService
	{
        [XmlElement("FriendMessage")]
        public List<FriendMessage> friendMessage = new List<FriendMessage>();
	}
}
