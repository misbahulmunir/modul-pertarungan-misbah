using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int playerLevel=15;
	string playerID;
	int mineLevel =0, altarLevel=0, yggdrasilLevel=0;

	public int PlayerLevel {
		get {return playerLevel;}
		set { playerLevel = value;}
	}

	public string PlayerID {
		get {return playerID;}
		set { playerID = value;}
	}

	public int MineLevel {
		get {return mineLevel;}
		set { mineLevel = value;}
	}
	
	public int AltarLevel {
		get {return AltarLevel;}
		set { AltarLevel = value;}
	}
	
	public int YggdrasilLevel {
		get {return YggdrasilLevel;}
		set {YggdrasilLevel = value;}
	}
}
