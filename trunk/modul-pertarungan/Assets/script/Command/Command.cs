using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public abstract  class Command
	{
        public string Cmd;
        public abstract void Execute();
        public abstract void Initialization();

	}
}
