using UnityEngine;
using ModulPertarungan;
using System.Collections;

public class ButtonBack : Button
{
    // Use this for initialization
    void Start()
    {
        SceneLoad = TextureSingleton.Instance().BackScene;
        ButtonTag = "backbutton";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
