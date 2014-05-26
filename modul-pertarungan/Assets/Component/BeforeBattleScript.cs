using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BeforeBattleScript : MonoBehaviour
    {

        public List<GameObject> enemies;
        void OnClick()
        {
          
               
              Application.LoadLevel("Battle");
                //Application.LoadLevel("ContinentDungeon");
        }
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}