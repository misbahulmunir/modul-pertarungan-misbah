using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class WindStorm : CardsEffect
    {

        void OnClick()
        {
            Click();  
        }

        // Use this for initialization
        void Start()
        {
            this.CardName = "Windstorm";
            this.CardCost = 2;
            this.CardCode = " ";
            this.CardEffect = "Deal 50 damage to single enemy";

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            if (TargetList.Count > 0)
            {
                GameObject obj = TargetList[0];
                GameObject animation = Instantiate(GameObject.Find("Fluffy Smoke Large"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                animation.renderer.sortingLayerName = "foreground";
                animation.particleEmitter.emit = true;
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(50);
            }
            GameManager.Instance().KillObj(Target);


        }
    }
}
