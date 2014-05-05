using UnityEngine;
using System.Collections;

public class ModelYggdrasil : ModelBuilding {

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
	int expYggdrasil = 0;
	int maxYggdrasilExp = 100;

	public ModelYggdrasil()
	{
		name = "Yggdrasil";
		about = "The Tree of Life. Its leaf which have some magic power, can be used to craft a Card";
		level = getBuildingData (playerID, "Yggdrasil");
		dropRate = level;
		charLevel = getCharLevel (playerID);
	}

	public int ExpYggdrasil {
		get {
			return expYggdrasil;
		}
		set {
			expYggdrasil = value;
		}
	}

	public int MaxYggdrasilExp {
		get {
			return maxYggdrasilExp;
		}
		set {
			maxYggdrasilExp = value;
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
