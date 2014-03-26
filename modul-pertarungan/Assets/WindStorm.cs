using UnityEngine;
using System.Collections;
namespace ModulPertarungan
{
    public class WindStorm : CardsEffect
    {

        // Use this for initialization
        void Start()
        {
            this.CardName = "Windstorm";
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
            GameObject animation = Instantiate(GameObject.Find("Fluffy Smoke"), new Vector3(obj.transform.position.x, obj.transform.position.y, -10f), Quaternion.identity) as GameObject;
            animation.renderer.sortingLayerName = "foreground";
            animation.particleEmitter.emit = true;
            new WaitForSeconds(4);
            Debug.Log("fire");
        }
    }
}
