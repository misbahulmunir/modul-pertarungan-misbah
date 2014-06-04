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
                {"FireDragon",new FireDragon(200,200,"firedragon")},
                {"FireSlime", new FireSlime(200,200, "fireslime")},
                {"FireKingSlime", new FireKingSlime(200,200, "firekingslime")},
                {"EarthSlime", new EarthSlime(200,200, "earthslime")},
                {"EarthKingSlime", new EarthKingSlime(200,200, "earthkingslime")},
                {"ThunderSlime", new ThunderSlime(200,200, "thunderslime")},
                {"ThunderKingSlime", new ThunderKingSlime(200,200, "thunderkingslime")},
                {"WindSlime", new WindSlime(200,200, "windslime")},
                {"WindKingSlime", new WindKingSlime(200,200, "windkingslime")}
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
                //obj.GetComponent<DamageReceiverAction>().Character = enemy;
                GameManager.Instance().AddEnemy(obj);
                GameManager.Instance().CurrentEnemy = obj;
            }
        }
    }
}
