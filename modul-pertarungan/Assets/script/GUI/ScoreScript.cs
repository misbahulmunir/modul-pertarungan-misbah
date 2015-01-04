using UnityEngine;
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
        public UILabel ServiceMessage;
        public List<GameObject>label;
        private int score = 0;
        //private bool[] checkQuestActive;
        //private bool[] checkQuestCleared;
        
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
            else
            {
                ShowWinOrLose();
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
            if (!Input.GetMouseButtonDown(0)) return;
            GameManager.Instance().GameMode = "";
            Application.LoadLevel("HouseEditor");
        }
        public void ShowWinOrLose()
        {
            Debug.Log("haha " + TextureSingleton.Instance().IdButton);
            if (GameManager.Instance().GameStatus == "win")
            {
                if (GameManager.Instance().GameMode != "pvp")
                {
                    string[] split = TextureSingleton.Instance().IdButton.Split('_');
                    int id = Int32.Parse(split[2]);
                    Debug.Log("Batman " + id);
                    try
                    {
                        string nextQuest = "";
                        if ((id + 1) == TextureSingleton.Instance().IdQuest.Count)
                        {
                            switch (split[1])
                            {
                                case "@Fire":
                                    nextQuest = split[0] + "_@Earth_0";
                                    break;
                                case "@Earth":
                                    nextQuest = split[0] + "_@Water_0";
                                    break;
                                case "@Water":
                                    nextQuest = split[0] + "_@Thunder_0";
                                    break;
                                case "@Thunder":
                                    nextQuest = split[0] + "_@Wind_0";
                                    break;
                                case "@Wind":
                                    int nextDun = Int32.Parse(split[0]) + 1;
                                    nextQuest = "Dungeon_" + nextDun;
                                    break;
                                default:
                                    nextQuest = "";
                                    break;
                            }
                        }
                        else
                        {
                            int nextQ = id + 1;
                            nextQuest = split[0] + "_" + split[1] + "_" + nextQ;
                        }
                        Debug.Log("update >>" + GameManager.Instance().PlayerId + "|" + TextureSingleton.Instance().IdButton + "|" + nextQuest);
                        WebServiceSingleton.GetInstance().ProcessRequest("update_player_quest", GameManager.Instance().PlayerId + "|" + TextureSingleton.Instance().IdButton + "|" + nextQuest);
                        WebServiceSingleton.GetInstance().ProcessRequest("calculate_data", GameManager.Instance().PlayerId + "|" + GameManager.Instance().PlayerExp + "|" + GameManager.Instance().PlayerGold);
                        ServiceMessage.text = WebServiceSingleton.GetInstance().queryInfo;
                        ExpLabel.GetComponent<UILabel>().text = GameManager.Instance().PlayerExp.ToString();
                        GoldLabel.GetComponent<UILabel>().text = GameManager.Instance().PlayerGold.ToString();
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                    }
                    

                }
                Statuslabel.GetComponent<UILabel>().text = "WIN";

            }
            else
            {

                Statuslabel.GetComponent<UILabel>().text = "LOSE";
                ExpLabel.GetComponent<UILabel>().text = "0";
                GoldLabel.GetComponent<UILabel>().text = "0";
            }
           
        }
    }
}
