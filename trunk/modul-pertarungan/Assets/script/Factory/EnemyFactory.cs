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
                {"WaterSlime", new WaterSlime(200,200, "waterslime")},
                {"WaterKingSlime", new WaterKingSlime(200,200, "waterkingslime")},
                {"WindSlime", new WindSlime(200,200, "windslime")},
                {"WindKingSlime", new WindKingSlime(200,200, "windkingslime")},
                {"FireNymph", new FireNymph(200,200,"firenymph")},
                {"EarthNymph", new EarthNymph(200,200,"earthnymph")},
                {"ThunderNymph", new ThunderNymph(200,200,"thundernymph")},
                {"WaterNymph", new WaterNymph(200,200,"waternymph")},
                {"WindNymph", new WindNymph(200,200,"windnymph")},
                {"Mandrake", new Mandrake(200,200, "mandrake")},
                {"Mandragora", new Mandragora(200,200, "mandragora")},
                {"Canotre", new Canotre(200,200, "canotre")},
                {"Treant", new Treant(200,200, "treant")}
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
