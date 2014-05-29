using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  ModelModulPertarungan;

namespace ModulPertarungan
{
	public abstract class Visitor
	{
	    public virtual void ReceiveDamage(VisitableObject visitableObject, CardsEffect damageGiver, int damage)
	    {
	        
	    }
	}
}
