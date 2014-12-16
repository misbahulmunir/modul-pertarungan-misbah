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
    int productClaimed, productMax, level;
	string name, about;
	string playerID;
	int expAltar = 0;
	int maxAltarExp = 100;

	public ModelAltar()
    {
		
    }

    public void getAltarData()
    {
        name = "Altar";
		about = "An Altar that used to perform some magic, and sometimes drop some Magic Dust";
		level = Building.buildings[0].Level;
		productClaimed = Building.buildings[0].ProductClaimed;
        productMax = Building.buildings[0].ProductionQuantity;
        expAltar = Building.buildings[0].CurrentXP;
        maxAltarExp = Building.buildings[0].MaxXP;

		charLevel = getCharLevel (playerID);
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
