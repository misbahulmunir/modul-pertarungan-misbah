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
            //try
            //{
            //    XmlSerializer deserializer = new XmlSerializer(typeof(RequestFromService));
            //    TextReader textReader = new StreamReader(Application.persistentDataPath + "/friend_request_of_" + GameManager.Instance().PlayerId + ".xml");
            //    object obj = deserializer.Deserialize(textReader);
            //    var players = (RequestFromService)obj;
            //    foreach (var s in players.players)
            //    {
            //        Debug.Log(s.Name);
            //        Debug.Log(s.Job);
            //    }
            //    textReader.Close();
            //}
            //catch (Exception e)
            //{
            //    Debug.Log(e);
            //}
              //Application.LoadLevel("Battle");
            Application.LoadLevel("ContinentDungeon");
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