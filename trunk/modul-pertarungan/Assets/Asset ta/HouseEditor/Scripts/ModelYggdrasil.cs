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
    int productClaimed, productMax, level;
    string name, about;
    string playerID;
	int expYggdrasil = 0;
	int maxYggdrasilExp = 100;

	public ModelYggdrasil()
	{
	}

    public void getYggdrasilData()
    {
        name = "Yggdrasil";
        about = "The Tree of Life. Its leaf which have some magic power, can be used to craft a Card";
        level = Building.buildings[2].Level;
        productClaimed = Building.buildings[2].ProductClaimed;
        productMax = Building.buildings[2].ProductionQuantity;
        expYggdrasil = Building.buildings[2].CurrentXP;
        maxYggdrasilExp = Building.buildings[2].MaxXP;

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
