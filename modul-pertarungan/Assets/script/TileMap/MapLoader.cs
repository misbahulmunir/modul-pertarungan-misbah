using UnityEngine;
using System.Collections.Generic;

public class MapLoader : MonoBehaviour 
{
    public GameObject tilemap;    

	// Use this for initialization
    void Start()
    {
        Debug.Log("maploader");
        //tilemap = Instantiate(tilemap) as GameObject;
        tilemap.name = "Quest Map";
    }
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
