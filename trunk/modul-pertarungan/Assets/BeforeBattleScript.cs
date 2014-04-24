using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace ModulPertarungan
{
    public class BeforeBattleScript : MonoBehaviour
    {

        public List<GameObject> enemies;
        public List<GameObject> Player;
        // Use this for initialization

        void OnClick()
        {
            GameManager.Instance().Players = Player;
            GameManager.Instance().Enemies = enemies;
            Application.LoadLevel("Battle");
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