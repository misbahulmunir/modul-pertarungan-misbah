using UnityEngine;
using System.Collections;

public class ModelBuilding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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
}
