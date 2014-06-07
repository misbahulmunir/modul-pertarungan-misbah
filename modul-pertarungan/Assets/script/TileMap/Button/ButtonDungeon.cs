using UnityEngine;
using System.Collections;

public class ButtonDungeon : Button
{
    // Use this for initialization
    public Texture2D textureTiles;
    void Start()
    {
        SceneLoad = "QuestMap";
        ButtonTag = "dungeonbutton";        
    }

    // Update is called once per frame
    void Update()
    {

    }

}