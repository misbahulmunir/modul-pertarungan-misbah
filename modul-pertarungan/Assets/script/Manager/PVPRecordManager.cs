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
        // Use this for initialization
        private List<EnemyPlayerFromService> opponentList;
        private void Start()
        {
            GetOpponentsName();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void NotifyManager()
        {
            if (current != null&&current.value!=null)
            {
                var op= opponentList.Find(item => item.Name.Equals(current.value));
                win.text = op.Win.ToString();
                lose.text = op.Lose.ToString();
            }
        }

        public void GetOpponentsName()
        {
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
    }
}