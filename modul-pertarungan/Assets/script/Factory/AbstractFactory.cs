using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace ModulPertarungan
{
    public abstract class AbstractFactory:MonoBehaviour
    {
        public virtual void InstatiateObject()
        {
        }
        public virtual void CreateObject(string Objectname)
        {
        }
        public virtual void CreateEnemy(string ObjectName, int place)
        {
        }
    }
}
