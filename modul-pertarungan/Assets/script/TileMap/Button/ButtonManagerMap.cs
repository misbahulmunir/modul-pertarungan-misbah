using UnityEngine;
using Holoville.HOTween;
using System.Collections;
using System.Collections.Generic;

public class ButtonManagerMap : MonoBehaviour
{
    public Transform questObj;

    private string sceneLoader;
    private string buttonNameLoader;
    private List<GameObject> butList;

    // Use this for initialization
    void Start()
    {
        HOTween.Init(true, true, true);
    }
    void Awake()
    {
        //butList = GameObject.Find("TileMap").GetComponent<TileMap>().ButID;
    }
    // Update is called once per frame
    void Update()
    {
        OnClick();
    }
    void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                buttonNameLoader = hit.collider.gameObject.GetComponent<Button>().ButtonName;
                sceneLoader = hit.collider.gameObject.GetComponent<Button>().SceneLoad;
                if (hit.collider.gameObject.name.ToLower().Contains(buttonNameLoader))
                {
                    if (buttonNameLoader == "questbutton")
                    {
                        HOTween.To(questObj, 1f, "position", new Vector3(17, 13, 0));
                        Debug.Log("questbutton");
                    }
                    else if (buttonNameLoader == "cancelquestbutton")
                    {
                        HOTween.To(questObj, 1f, "position", new Vector3(17, 30, 0));
                        Debug.Log("cancelquestbutton");
                    }
                    else
                    {
                        Application.LoadLevel(sceneLoader);
                        Debug.Log("loading screen");
                    }
                }
            }
        }

    }
}
