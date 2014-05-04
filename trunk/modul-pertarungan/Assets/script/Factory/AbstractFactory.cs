using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public abstract class AbstractFactory:MonoBehaviour
    {
        
        public virtual void InstantiateObject()
        {
        }
        public virtual void CreateObject(string Objectname)
        {
        }
        public virtual void CreateEnemy(string ObjectName, int place)
        {
        }
        public virtual void CreatePlayer(String Id, String Job, String ObjectName, GameObject pawnsPosisition)
        {
           
        }
      
    }
}
