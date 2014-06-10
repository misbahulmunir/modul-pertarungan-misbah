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
        private bool[] questActived;
        private bool[] questCleared;

        void OnClick()
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(FriendListFromService));
                TextReader textReader = new StreamReader(Application.persistentDataPath + "/friends_of_" + GameManager.Instance().PlayerId + ".xml");
                object obj = deserializer.Deserialize(textReader);
                var players = (FriendListFromService)obj;
                foreach (var s in players.players)
                {
                    Debug.Log(s.Name);
                    Debug.Log(s.Job);
                }
                textReader.Close();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
              //Application.LoadLevel("Battle");

            questActived = new bool[] { true, false, false, false, false, false, false, false };
            questCleared = new bool[] { false, false, false, false, false, false, false, false };
            TextureSingleton.Instance().QuestActive = questActived;
            TextureSingleton.Instance().QuestCleared = questCleared;
            Application.LoadLevel("Dungeon_0");
        }
        void Start()
        {
            GameManager.Instance().GameMode = "";
            WebServiceSingleton.GetInstance().isLoadingScreen = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}