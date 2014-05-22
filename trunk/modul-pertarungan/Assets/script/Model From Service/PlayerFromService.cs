using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class PlayerFromService
	{
        public string Name { get; set; }
        public string Pass { set; get; }
        public int Gold { get; set; }
        public int MaxHP { get; set; }
        public int MaxDP { get; set; }
        public int MaxSP { get; set; }
        public int Energy { get; set; }
        public int XP { get; set; }
        public string Job { get; set; }
        public string Rank { get; set; }
        public int Level { get; set; }
        public string Gender { get; set; }
        public int BattleWon { get; set; }
        public int BattleLost { get; set; }
	}
}
