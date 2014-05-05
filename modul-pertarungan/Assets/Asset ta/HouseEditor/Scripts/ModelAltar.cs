using UnityEngine;
using System.Collections;

public class ModelAltar : ModelBuilding {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int charLevel;
	int dropRate, level;
	string name, about;
	string playerID;
	int expAltar = 0;
	int maxAltarExp = 100;

	public ModelAltar()
	{
		name = "Altar";
		about = "An Altar that used to perform some magic, and sometimes drop some Magic Dust";
		level = getBuildingData (playerID, "Altar");
		dropRate = level;
		charLevel = getCharLevel (playerID);
	}

	public int ExpAltar {
		get {
			return expAltar;
		}
		set {
			expAltar = value;
		}
	}

	public int MaxAltarExp {
		get {
			return maxAltarExp;
		}
		set {
			maxAltarExp = value;
		}
	}

	public int Level {
		get {
			return level;
		}
		set {
			level = value;
		}
	}
}
