using UnityEngine;
using Holoville.HOTween;
using ModulPertarungan;
using System.Collections;
using System.Collections.Generic;

public class ButtonManagerContinent : MonoBehaviour
{
    public Transform dungeonQuest;
    public GameManager labelPos;

    private string sceneLoader;
    private string buttonTagLoader;
    private Texture2D textureLoader;

    private GameObject[] buttonElement;
    private string [] dungeonCode;
    // Use this for initialization
    void Awake()
    {
        
    }
    void Start()
    {
        buttonElement = GameObject.FindGameObjectsWithTag("DungeonButton");
        dungeonCode = Application.loadedLevelName.Split('_');
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
                if (hit.collider.gameObject.tag.ToLower().Contains(buttonTagLoader))
                {
                    if (buttonTagLoader == "homebutton" || buttonTagLoader == "backbutton")
                    {
                        Debug.Log(sceneLoader);
                        Application.LoadLevel(sceneLoader);
                    } 
                    else if (buttonTagLoader == "dungeonbutton")
                    {
                        Debug.Log("this > " +hit.collider.gameObject.name);
                        //Debug.Log(TextureSingleton.Instance().ElementButton["@Fire"]);
                        if (TextureSingleton.Instance().ElementButton[hit.collider.gameObject.name] == true)
                        {
                            if (buttonTagLoader == "dungeonbutton")
                            {
                                textureLoader = hit.collider.gameObject.GetComponent<ButtonDungeon>().textureTiles;
                                TextureSingleton.Instance().TextureTiles = textureLoader.name;
                                TextureSingleton.Instance().IdButton = dungeonCode[1] + "_" + hit.collider.gameObject.name;
                                HOTween.To(dungeonQuest, 1f, "position", new Vector3(0, 0.6f, 0));                                
                                for (int i = 0; i < 5; i++)
                                {
                                    buttonElement[i].collider2D.enabled = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("Not Actived Yet");
                        }
                    }
                    else if (hit.collider.gameObject.layer.Equals(29))
                    {
                        if (buttonTagLoader == "cancelbutton")
                        {
                            HOTween.To(dungeonQuest, 1f, "position", new Vector3(0, 11, 0));
                            for (int i = 0; i < 5; i++)
                            {
                                buttonElement[i].collider2D.enabled = true;
                            }
                            Debug.Log("cancelbutton");
                        }
                        else if (buttonTagLoader == "gomap")
                        {                            
                            TextureSingleton.Instance().BackScene = Application.loadedLevelName;
                            Debug.Log(Application.loadedLevelName);
                            Application.LoadLevel(sceneLoader);
                            Debug.Log(textureLoader.name);
                        }
                    }
                    else if (Application.loadedLevelName == TextureSingleton.Instance().BackScene)
                    {
                        Application.LoadLevel("HouseEditor");
                    }
                }
            }
        }
        
    }
}
