using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class TradeRequest
	{
        public string SenderPlayer { get; set; }
        public string RequestedPlayer { get; set; }
        public List<CardRequest> cards { get; set; }
	}
}
