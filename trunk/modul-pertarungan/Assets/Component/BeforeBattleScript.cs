using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System;

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
            GameManager.Instance().GameMode = "";
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}