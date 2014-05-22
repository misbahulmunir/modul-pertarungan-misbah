using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    private string sceneLoad;
    private string buttonName;

    public string SceneLoad
    {
        get { return sceneLoad; }
        set { sceneLoad = value; }
    }

    public string ButtonName
    {
        get { return buttonName; }
        set { buttonName = value; }
    }
}
