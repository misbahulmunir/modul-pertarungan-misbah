using UnityEngine;
using System.Collections;

public class QuantityManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		totalBerry = getDatabaseBerry ();
		totalGem = getDatabaseGem ();
		totalMagicDust = getDatabaseMagicdust ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected int totalBerry, totalGem, totalMagicDust;

	public int TotalMagicDust {
		get {
			return totalMagicDust;
		}
		set {
			totalMagicDust = value;
		}
	}

	public int TotalGem {
		get {
			return totalGem;
		}
		set {
			totalGem = value;
		}
	}

	public int TotalBerry {
		get {
			return totalBerry;
		}
		set {
			totalBerry = value;
		}
	}

	public int getDatabaseBerry()
	{
		totalBerry = 0;
		return totalBerry;
	}

	public int getDatabaseGem()
	{
		totalGem = 0;
		return totalGem;
	}

	public int getDatabaseMagicdust()
	{
		totalMagicDust = 0;
		return totalMagicDust;
	}

}
