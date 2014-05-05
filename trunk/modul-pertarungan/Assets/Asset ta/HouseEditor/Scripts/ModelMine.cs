using UnityEngine;
using System.Collections;

public class ModelMine :  ModelBuilding {

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
	int expMine = 0;
	int maxMineExp = 100;
	
	public ModelMine()
	{
		name = "Mine";
		about = "A Dwarf's Mine that not used again, but still produce some Oridecon";
		level = getBuildingData (playerID, "Mine");
		dropRate = level;
		charLevel = getCharLevel (playerID);
	}

	public int ExpMine {
		get {
			return expMine;
		}
		set {
			expMine = value;
		}
	}

	public int MaxMineExp {
		get {
			return maxMineExp;
		}
		set {
			maxMineExp = value;
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
