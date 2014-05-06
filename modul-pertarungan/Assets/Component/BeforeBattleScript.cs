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
            if (GameManager.Instance().AllSelectedCard != null)
            {
                 //  GameManager.Instance().Players = Player;
                GameManager.Instance().Enemies = enemies;
                //  Debug.Log(GameManager.Instance().AllCards.Count);
                Application.LoadLevel("Battle");
            }
        }
        void Start()
        {
            //GameManager.Instance().PlayerNumber = 1;
            GameManager.Instance().PlayerId = "agil";
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}