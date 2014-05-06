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
        public virtual void CreateCard(string objectName, string target)
        {
        }
        public virtual void CreateEnemy(string objectName, int place)
        {
        }
        public virtual void CreatePlayer(String id, String job, String objectName, GameObject pawnsPosisition)
        {
           
        }
      
    }
}
