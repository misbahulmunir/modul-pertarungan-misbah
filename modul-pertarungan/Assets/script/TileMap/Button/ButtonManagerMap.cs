using UnityEngine;
using ModulPertarungan;
using Holoville.HOTween;
using System;
using System.Collections;
using System.Collections.Generic;

public class ButtonManagerMap : MonoBehaviour
{
    public GameObject tilemap;
    public Transform questObj;
    public GameObject labelPos;

    private string sceneLoader;
    private string buttonTagLoader;
    private List<GameObject> butList;
    private string[] splitter;
    private string buttonName;

    void Awake()
    {
        tilemap = Instantiate(tilemap) as GameObject;        
    }

    // Use this for initialization
    void Start()
    {
        //Debug.Log("Start");
        HOTween.Init(true, true, true); 
        butList = tilemap.GetComponent<TileMap>().butID;

    }
    // Update is called once per frame
    void Update()
    {
        OnClick();
    }

    private void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {            
            if (hit.collider != null)
            {
                buttonTagLoader = hit.collider.gameObject.GetComponent<Button>().ButtonTag;
                sceneLoader = hit.collider.gameObject.GetComponent<Button>().SceneLoad;
                buttonName = hit.collider.gameObject.name;
                
                if (hit.collider.gameObject.tag.ToLower().Contains(buttonTagLoader))
                {
                    if (buttonTagLoader == "homebutton" || buttonTagLoader == "backbutton")
                    {
                        Application.LoadLevel(sceneLoader);
                        TextureSingleton.Instance().BackScene = "HouseEditor";
                    }
                    else if (buttonName.Contains("Button_"))
                    {
                        splitter = buttonName.Split('_');

                        int idButton = Int32.Parse(splitter[1]);
                        if (TextureSingleton.Instance().QuestActive[idButton] == true && hit.collider.gameObject.layer.Equals(15))
                        {
                            if (buttonTagLoader == "questbutton")
                            {
                                TextureSingleton.Instance().IdButton = TextureSingleton.Instance().IdButton + "_" + splitter[1];
                                HOTween.To(questObj, 1f, "position", new Vector3(17, 11, 0));
                                foreach (var b in butList)
                                {
                                    b.collider2D.enabled = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Not Actived yet");
                        }
                    }
                    else if (hit.collider.gameObject.layer.Equals(29))
                    {
                        if (buttonTagLoader == "cancelbutton")
                        {
                            HOTween.To(questObj, 1f, "position", new Vector3(17, 30, 0));
                            foreach (var b in butList)
                            {
                                b.collider2D.enabled = true;
                            }
                        }
                        else if (buttonTagLoader == "gobutton")
                        {
                            Application.LoadLevel(sceneLoader);                            
                            Debug.Log(TextureSingleton.Instance().IdButton);
                        }
                    }
                }       
            }
        }

    }
}
