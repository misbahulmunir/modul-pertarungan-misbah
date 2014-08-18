using UnityEngine;
using System.Collections;
using System.Net;
using ModulPertarungan;
using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Serialization;

public class ModelBuilding{

    private XmlDocument _xmlDoc;
    private XmlNodeList _nameNodes;
    List<string> avatarList;
    string playerName = "";
    PlayerBuildingFromService building;

    public PlayerBuildingFromService Building
    {
        get { return building; }
        set { building = value; }
    }

    public ModelBuilding()
    {
        //getDatabaseBuilding();
    }

	// Use this for initialization
    //void Start () {
    //    playerName = "zendra";
    //    getDatabaseBuilding();
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}

	int charLevel;
	string playerID;

	public int getCharLevel(string playerID)
	{
		charLevel = 15;
		return charLevel;
	}

	public int getBuildingData(string playerId, string buildingName)
	{
		int buildingLevel = 1;
		return buildingLevel;
	}

	public int levelUp(string buildingName)
	{
		int levelNow = 1;
		return levelNow;
	}

    public void getDatabaseBuilding()
    {
        WebServiceSingleton.GetInstance().ProcessRequest("get_building", GameManager.Instance().PlayerId);
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(PlayerBuildingFromService));
            //TextReader textReader = new StreamReader(Application.persistentDataPath + "/building_of_" + GameManager.Instance().PlayerId + ".xml");
            TextReader textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
            object obj = deserializer.Deserialize(textReader);
            building = (PlayerBuildingFromService)obj;
            textReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
