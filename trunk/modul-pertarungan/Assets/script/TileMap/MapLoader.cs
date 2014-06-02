using UnityEngine;
using System.Collections;

public class MapLoader : MonoBehaviour 
{
    public TileMap tilemap;

	// Use this for initialization
	void Start () 
    {
        Instantiate(tilemap);        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
}
