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
    int productClaimed, productMax, level;
    string name, about;
    string playerID;
    int expMine = 0;
    int maxMineExp = 100;
	
	public ModelMine()
	{
	}

    public void getMineData()
    {
        name = "Mine";
        about = "A Dwarf's Mine that not used again, but still produce some Oridecon";
        level = Building.buildings[1].Level;
        productClaimed = Building.buildings[1].ProductClaimed;
        productMax = Building.buildings[1].ProductionQuantity;
        expMine = Building.buildings[1].CurrentXP;
        maxMineExp = Building.buildings[1].MaxXP;

        charLevel = getCharLevel(playerID);
    }

    public int ProductMax
    {
        get { return productMax; }
        set { productMax = value; }
    }

    public int ProductClaimed
    {
        get { return productClaimed; }
        set { productClaimed = value; }
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
