using UnityEngine;
using System.Collections;
using ModelModulPertarungan;
namespace ModulPertarungan
{
    public class FireDragonScript : EnemyAction
    {

        public string name;
        private FireDragon firedragon;
        // Use this for initialization
        public override void AttackAction()
        {
            foreach (GameObject player in GameMenager.Instance().Enemies)
            {

            }
        }
        void Start()
        {
            firedragon = new FireDragon(200, 200, name);
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}