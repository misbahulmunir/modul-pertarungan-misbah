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
                {"FireDragon",new FireDragon(200,200,"firedragon",100,100)},
                {"FireSlime", new FireSlime(200,200, "fireslime",100,100)},
                {"FireKingSlime", new FireKingSlime(200,200, "firekingslime",100,100)},
                {"EarthSlime", new EarthSlime(200,200, "earthslime",100,100)},
                {"EarthKingSlime", new EarthKingSlime(200,200, "earthkingslime",100,100)},
                {"ThunderSlime", new ThunderSlime(200,200, "thunderslime",100,100)},
                {"ThunderKingSlime", new ThunderKingSlime(200,200, "thunderkingslime",100,100)},
                {"WaterSlime", new WaterSlime(200,200, "waterslime",100,100)},
                {"WaterKingSlime", new WaterKingSlime(200,200, "waterkingslime",100,100)},
                {"WindSlime", new WindSlime(200,200, "windslime",100,100)},
                {"WindKingSlime", new WindKingSlime(200,200, "windkingslime",100,100)},
                {"FireNymph", new FireNymph(200,200,"firenymph",100,100)},
                {"EarthNymph", new EarthNymph(200,200,"earthnymph",100,100)},
                {"ThunderNymph", new ThunderNymph(200,200,"thundernymph",100,100)},
                {"WaterNymph", new WaterNymph(200,200,"waternymph",100,100)},
                {"WindNymph", new WindNymph(200,200,"windnymph",100,100)},
                {"Mandrake", new Mandrake(200,200, "mandrake",100,100)},
                {"Mandragora", new Mandragora(200,200, "mandragora",100,100)},
                {"Canotre", new Canotre(200,200, "canotre",100,100)},
                {"Treant", new Treant(200,200, "treant",100,100)}
            };
        }

        public override void CreateEnemy(string objectName, GameObject place)
        {
            enemyDictionary.TryGetValue(objectName, out enemy);
            var obj = Object.Instantiate((GameObject)Resources.Load("Enemy/"+objectName, typeof(GameObject)), place.transform.position, Quaternion.identity) as GameObject;
          //  obj.GetComponent<EnemyAction>().Enemy = enemy;
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
