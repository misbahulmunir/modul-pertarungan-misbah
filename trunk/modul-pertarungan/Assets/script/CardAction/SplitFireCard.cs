using ModelModulPertarungan;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{
    public class SplitFireCard : FireCard
    {
        void OnClick()
        {
            Click();
        }


        // Use this for initialization
        void Start()
        {
            this.CardName = "Split Fire";
            this.CardCost = 2;
            this.CardCode = " ";
            this.CardEffect = " Deal 10 fire damage /n to single enemy";
            this.DeckCost = 2;

        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void Effect()
        {
            if (TargetList.Count> 0)
            {
                GameObject obj;
                obj = GameManager.Instance().GameMode == "pvp" ? TargetList[0] : TargetList.Find(GameManager.Instance().CurrentEnemy.Equals);
                var animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
                if (animation != null)
                {
                    animation.renderer.sortingLayerName = "foreground";
                    animation.particleEmitter.emit = true;
                }
                obj.GetComponent<DamageReceiverAction>().ReceiveDamage(10);

            }
            GameManager.Instance().KillObj(Target);
        }

    }
}
