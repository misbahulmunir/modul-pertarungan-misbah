using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System;

namespace ModulPertarungan
{
    public class PVPRecordManager : MonoBehaviour
    {
        public UIPopupList current;
        public UILabel win;
        public UILabel lose;
        public GameObject grid;
        public GameObject label;
        // Use this for initialization
        private List<EnemyPlayerFromService> opponentList;
       
        private void Start()
        {
            GenerateRooster();
            GetOpponentsName();
        }

        // Update is called once per frame
        private void Update()
        {
            grid.GetComponent<UIGrid>().Reposition();
        }

        public void NotifyManager()
        {
            if (current != null&&opponentList!=null)
            {
                var op= opponentList.Find(item => item.Name.Equals(current.value));
                win.text = op.Win.ToString();
                lose.text = op.Lose.ToString();
            }
        }

        public void GetOpponentsName()
        {
            WebServiceSingleton.GetInstance().ProcessRequest("get_player_ranking","");
            WebServiceSingleton.GetInstance().DownloadFile("get_player_ranking", "");
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(BattleRankFromService));
                TextReader textReader = new StreamReader(Application.persistentDataPath + "/battle_rank_of_" + GameManager.Instance().PlayerId + ".xml");
                object obj = deserializer.Deserialize(textReader);
                var  Opponents = (BattleRankFromService)obj;
                textReader.Close();
                current.items= new List<string>();
                opponentList= new List<EnemyPlayerFromService>();
                foreach (var op in Opponents.enemyPlayer)
                {
                    current.items.Add(op.Name);
                    Debug.Log(op.Name);
                    opponentList.Add(op);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        public void GenerateRooster()
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(PlayerRankingFromService));
                TextReader textReader = new StreamReader(Application.persistentDataPath + "/player_rank.xml");
                object obj = deserializer.Deserialize(textReader);
                var Opponents = (PlayerRankingFromService)obj;
                textReader.Close();
                current.items = new List<string>();
                opponentList = new List<EnemyPlayerFromService>();
                foreach (var op in Opponents.playerDetail)
                {
                    label.GetComponent<UILabel>().text = op.Name + " Battle Won =" + op.BattleWon;
                    NGUITools.AddChild(grid, label);
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            
        }
    }
}