using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
	public abstract class VisitableObject
	{
	    public void AcceptVisitor(Visitor visitor, CardsEffect damageGiver, int damage)
	    {
	        visitor.ReceiveDamage(this,damageGiver,damage);
	    }
	}
}
