
using System.Collections.Generic;
using UnityEngine;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class EnemyFactory : AbstractFactory
    {
        public List<GameObject> enemies;
        public List<GameObject> enemiesplace;
        private GameObject enemy;
        public override void CreateEnemy(string objectName, GameObject place)
        {
            var obj = Object.Instantiate((GameObject)Resources.Load("Enemy/"+objectName, typeof(GameObject)), place.transform.position, Quaternion.identity) as GameObject;
            GameManager.Instance().AddEnemy(obj);
            GameManager.Instance().CurrentEnemy = obj;
        }
    }
}
