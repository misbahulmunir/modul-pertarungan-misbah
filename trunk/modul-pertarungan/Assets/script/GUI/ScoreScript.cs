﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ModulPertarungan
{

    public class ScoreScript : MonoBehaviour
    {
        public GameObject Statuslabel;
        public GameObject GoldLabel;
        public GameObject ExpLabel;
        public List<GameObject>label;
        private int score = 0;
        // Use this for initialization
        void Start()
        {
            if (GameManager.Instance().GameMode == "pvp")
            {
                var succses = false;
                succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GameEnd-" + NetworkSingleton.Instance().RoomName);
                Debug.Log(succses ? "send succes" : "send false");
                NetworkSingleton.instance = null;
                GameManager.Instance().GameMode = "";
            }
            GameManager.Instance().Enemies = null;
            GameManager.Instance().CurrentEnemy = null;
            GameManager.Instance().Players = null;
            GameManager.Instance().CurrentPawn = null;
            GameManager.Instance().GameMode = "";
        }

        // Update is called once per frame
        void Update()
        {
           
            if (GameManager.Instance().GameStatus == "win")
            {
                Statuslabel.GetComponent<UILabel>().text = "WIN";
                if (score < GameManager.Instance().PlayerExp)
                {
                    score += 1;
                    ExpLabel.GetComponent<UILabel>().text = score.ToString();
                }
                GoldLabel.GetComponent<UILabel>().text = GameManager.Instance().PlayerGold.ToString();


            }
            else
            {
                
                Statuslabel.GetComponent<UILabel>().text = "LOSE";
                ExpLabel.GetComponent<UILabel>().text = "0";
                GoldLabel.GetComponent<UILabel>().text = "0";
                foreach (GameObject obj in label)
                {
                    obj.active = false;
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("BeforeBattle");
            }
          
        }
    }
}