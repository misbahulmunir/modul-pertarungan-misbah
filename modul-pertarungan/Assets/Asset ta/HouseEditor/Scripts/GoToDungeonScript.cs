using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModulPertarungan;
using System.Xml.Serialization;
using System.IO;
using System;

public class GoToDungeonScript : MonoBehaviour {

    string[] splitName;
    private Dictionary<string, bool> buttonElemental;
    string playerName = "";
	// Use this for initialization
	void Start () {
        playerName = GameManager.Instance().PlayerId;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        splitName = gameObject.transform.name.Split('(');
        WebServiceSingleton.GetInstance().ProcessRequest("get_battle_list", playerName + "|" +  splitName[0].ToString());
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BattleListFromService));
            TextReader textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
            object obj = deserializer.Deserialize(textReader);
            var balis = (BattleListFromService)obj;

            buttonElemental = new Dictionary<string, bool>();
            foreach (var s in balis.battle)
            {
                Debug.Log(s.ID + "|" + s.IsActive);
                buttonElemental.Add(s.ID, s.IsActive);
            }
            textReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        TextureSingleton.Instance().ElementButton = buttonElemental;
        TextureSingleton.Instance().BackScene = Application.loadedLevelName;
        TextureSingleton.Instance().DungeonName = splitName[0];
        Application.LoadLevel(splitName[0]);
    }
}
