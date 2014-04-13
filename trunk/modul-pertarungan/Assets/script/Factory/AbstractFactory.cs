using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModulPertarungan
{
    public abstract class AbstractFactory
    {
        public virtual void InstatiateObject()
        {
        }
        public virtual void CreateCard(string Objectname)
        {
        }
    }
}
