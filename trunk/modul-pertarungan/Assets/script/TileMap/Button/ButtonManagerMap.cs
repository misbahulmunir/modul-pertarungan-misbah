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

   
    void OnClick()
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
                    if (buttonTagLoader == "homebutton")
                    {
                        Application.LoadLevel(sceneLoader);
                        Debug.Log("go home");
                    }
                    else
                    {
                        if (buttonName.Contains("Button_"))
                        {
                            splitter = buttonName.Split('_');
                        }
                        int idButton = Int32.Parse(splitter[1]);
                        //Debug.Log(idButton);
                        if (TextureSingleton.Instance().QuestActive[idButton] == true)
                        {
                            //Debug.Log("Actived " + TextureSingleton.Instance().QuestActive[idButton]);

                            if (buttonTagLoader == "questbutton")
                            {
                                HOTween.To(questObj, 1f, "position", new Vector3(17, 13, 0));
                                //Debug.Log("questbutton");
                            }
                            else if (buttonTagLoader == "cancelbutton")
                            {
                                HOTween.To(questObj, 1f, "position", new Vector3(17, 30, 0));
                                //Debug.Log("cancelbutton");
                            }
                            else if (buttonTagLoader == "gobutton")
                            {
                                Application.LoadLevel(sceneLoader);
                                TextureSingleton.Instance().IdButton = TextureSingleton.Instance().IdButton + "_" + splitter[1];
                                Debug.Log("loading screen");
                                Debug.Log(TextureSingleton.Instance().IdButton);
                            }
                        }
                        else
                        {
                            Debug.Log("Not Actived yet");
                        }
                    }
                }
                
                
                
            }
        }

    }
}
