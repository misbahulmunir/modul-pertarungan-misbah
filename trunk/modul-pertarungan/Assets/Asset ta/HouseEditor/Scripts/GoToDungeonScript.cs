using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ModulPertarungan;

public class GoToDungeonScript : MonoBehaviour {

    string[] splitName;
    private bool[] questActived;
    private bool[] questCleared;
    private Dictionary<string, bool> buttonElemental;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        splitName = gameObject.transform.name.Split('(');
        questActived = new bool[] { true, false, false, false, false, false, false, false };
        questCleared = new bool[] { false, false, false, false, false, false, false, false };
        buttonElemental = new Dictionary<string, bool>()
        {
            {"@Fire",true},
            {"@Water",false},
            {"@Earth",false},
            {"@Thunder",false},
            {"@Wind",false},
        };
        TextureSingleton.Instance().QuestActive = questActived;
        TextureSingleton.Instance().QuestCleared = questCleared;
        TextureSingleton.Instance().ElementButton = buttonElemental;
        TextureSingleton.Instance().BackScene = Application.loadedLevelName;
        Application.LoadLevel(splitName[0]);
    }
}
