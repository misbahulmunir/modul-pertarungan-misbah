using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public class BuildingFromService
	{
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxXP { get; set; }
        public int CurrentXP { get; set; }
        public int ProductionQuantity { get; set; }
        public int ProductClaimed { get; set; }
        public string PrefabName { get; set; }
	}
}
