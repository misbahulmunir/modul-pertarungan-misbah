using UnityEngine;
using System.Collections;
using Cardseffect;
namespace Splitfirecard
{
    public class SplitFireCard :CardsEffect
    {

        // Use this for initialization
        void Start()
        {
            this.CardName = "SplitFire";
            this.CardCost = 2;
            this.CardCode = " ";
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public override void Effect()
        {
            GameObject obj = GameObject.Find("monster1");
            GameObject animation = Instantiate(GameObject.Find("Small explosion"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
            animation.renderer.sortingLayerName = "foreground";
            animation.particleEmitter.emit = true;
            Debug.Log("fire");
        }
    }
}
