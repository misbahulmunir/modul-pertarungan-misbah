using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class SplitFireCard :CardsEffect
    {
        public string cardName;
        public string cardCost;
        public string cardCode;
        public string cardEffect;
       
        // Use this for initialization
        void Start()
        {
            this.CardName = "SplitFire";
            this.CardCost = 2;
            this.CardCode = " ";
            this.CardEffect = " Deal 10 fire damage /n to single enemy";
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public override void Effect()
        {
            GameObject obj = GameManager.Instance().Enemies[0];
            GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
            animation.renderer.sortingLayerName = "foreground";
            animation.particleEmitter.emit = true;
            obj.GetComponent<DamageReceiverAction>().ReceiveDamage(10);
        
        }
    }
}
