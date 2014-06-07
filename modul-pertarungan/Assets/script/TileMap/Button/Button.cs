using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    private string sceneLoad;
    private string buttonTag;
    private int buttonID;

    public string SceneLoad
    {
        get { return sceneLoad; }
        set { sceneLoad = value; }
    }

    public string ButtonTag
    {
        get { return buttonTag; }
        set { buttonTag = value; }
    }

    public int ButtonID
    {
        get { return buttonID; }
        set { buttonID = value; }
    }
}
