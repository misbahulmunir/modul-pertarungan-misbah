﻿using UnityEngine;
using System;
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
        private bool[] checkQuestActive;
        private bool[] checkQuestCleared;

        // Use this for initialization
        void Start()
        {
            if (GameManager.Instance().GameMode == "pvp")
            {
                var succses = false;
                succses = NetworkSingleton.Instance().PlayerClient.Call<bool>("sendMessage", "GameEnd-" + NetworkSingleton.Instance().RoomName);
                Debug.Log(succses ? "send succes" : "send false");
                NetworkSingleton.instance = null;
               
            }
           
            GameManager.Instance().Enemies = null;
            GameManager.Instance().CurrentEnemy = null;
            GameManager.Instance().Players = null;
            GameManager.Instance().CurrentCard = null;
            GameManager.Instance().CurrentPlayerDeckSize = 0;
            GameManager.Instance().FriendName = null;
            GameManager.Instance().BattleState = null;
            GameManager.Instance().CurrentPawn = null;
            
        }

        // Update is called once per frame
        void Update()
        {
            ShowWinOrLose();
            if (Input.GetMouseButtonDown(0))
            {
                    GameManager.Instance().GameMode = "";
                    Application.LoadLevel("HouseEditor");
            }
        }
        public void ShowWinOrLose()
        {

            if (GameManager.Instance().GameStatus == "win")
            {
                if (GameManager.Instance().GameMode != "pvp")
                {
                    //string[] split = TextureSingleton.Instance().IdButton.Split('_');
                    //int id = Int32.Parse(split[1]);
                    //TextureSingleton.Instance().QuestActive[id + 1] = true;
                    //TextureSingleton.Instance().QuestCleared[id] = true;
                    //checkQuestActive = TextureSingleton.Instance().QuestActive;
                    //checkQuestCleared = TextureSingleton.Instance().QuestCleared;
                   // ExpLabel.GetComponent<UILabel>().text = GameManager.Instance().PlayerExp.ToString();
                   // GoldLabel.GetComponent<UILabel>().text = GameManager.Instance().PlayerGold.ToString();
                }
                Statuslabel.GetComponent<UILabel>().text = "WIN";

            }
            else
            {

                Statuslabel.GetComponent<UILabel>().text = "LOSE";
                //ExpLabel.GetComponent<UILabel>().text = "0";
                //GoldLabel.GetComponent<UILabel>().text = "0";
                //foreach (GameObject obj in label)
                //{
                //    obj.SetActive(true);
                //}
            }
           
        }
    }
}
