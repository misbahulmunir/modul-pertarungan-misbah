
using System.Collections.Generic;
using UnityEngine;
using ModelModulPertarungan;

namespace ModulPertarungan
{
    public class EnemyFactory : AbstractFactory
    {

        private Dictionary<string, Enemy> enemyDictionary;
        private Enemy enemy;
        public override void InstantiateObject()
        {
            enemyDictionary = new Dictionary<string, Enemy>()
            {
                {"FireDragon",new FireDragon()}
            };
        }

        public override void CreateEnemy(string objectName, GameObject place)
        {
            enemyDictionary.TryGetValue(objectName, out enemy);
            var obj = Object.Instantiate((GameObject)Resources.Load("Enemy/"+objectName, typeof(GameObject)), place.transform.position, Quaternion.identity) as GameObject;
            //
            //
            if (obj != null)
            {
                obj.GetComponent<DamageReceiverAction>().Character = enemy;
                GameManager.Instance().AddEnemy(obj);

                GameManager.Instance().CurrentEnemy = obj;
            }
        }
    }
}
