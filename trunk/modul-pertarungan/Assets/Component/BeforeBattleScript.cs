﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System;

namespace ModulPertarungan
{
    public class BeforeBattleScript : MonoBehaviour
    {

       

        void OnClick()
        {
            //try
            //{
            //    XmlSerializer deserializer = new XmlSerializer(typeof(FriendListFromService));
            //    TextReader textReader = new StreamReader(Application.persistentDataPath + "/friends_of_" + GameManager.Instance().PlayerId + ".xml");
            //    object obj = deserializer.Deserialize(textReader);
            //    var players = (FriendListFromService)obj;
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