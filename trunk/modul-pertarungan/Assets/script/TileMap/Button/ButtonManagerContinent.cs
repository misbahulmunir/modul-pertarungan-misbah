using UnityEngine;
using Holoville.HOTween;
using ModulPertarungan;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;
using System.IO;

public class ButtonManagerContinent : MonoBehaviour
{
    public Transform dungeonQuest;
    public GameManager labelPos;

    private string sceneLoader;
    private string buttonTagLoader;
    private Texture2D textureLoader;

    private GameObject[] buttonElement;
    private string [] dungeonCode;
    private string playerName = "";

    private List<bool> questActived;
    private List<bool> questCleared;
    private List<string> qId;

    // Use this for initialization
    void Awake()
    {
        CheckActivedDungeon();
    }
    void Start()
    {
        buttonElement = GameObject.FindGameObjectsWithTag("DungeonButton");
        dungeonCode = Application.loadedLevelName.Split('_');
        playerName = GameManager.Instance().PlayerId;
    }
    // Update is called once per frame
    void Update()
    {
        OnClick();        
    }

    private void CheckActivedDungeon()
    {
        
        foreach (var x in TextureSingleton.Instance().ElementButton)
        {
            Debug.Log(x.Key + "|" + x.Value);
            string[] xKey = x.Key.Split('_');
            if (x.Value == true)
            {
                GameObject.Find(xKey[1]).renderer.material.color = Color.white;
            }
            else
            {
                GameObject.Find(xKey[1]).renderer.material.color = Color.black;
            }
        }
    }

    private void OnClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.layer);
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
                        if (TextureSingleton.Instance().ElementButton[dungeonCode[1] + "_" + hit.collider.gameObject.name] == true)
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
                            QuestMapActivate();
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
    private void QuestMapActivate()
    {
        Debug.Log(">> " + TextureSingleton.Instance().IdButton);
        string idBut = TextureSingleton.Instance().IdButton;
        WebServiceSingleton.GetInstance().ProcessRequest("get_player_quest", playerName + "|" + idBut);
        try
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(QuestListFromService));
            TextReader textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
            object obj = deserializer.Deserialize(textReader);
            var quelis = (QuestListFromService)obj;
            foreach (var q in quelis.quest)
            {
                Debug.Log(q.ID + "|" + q.IsActive + "|" + q.IsClear);
                //qId.Add(q.ID);
                //questActived.Add(q.IsActive);
                //questCleared.Add(q.IsClear);
                //Debug.Log(q.ID + "|" + questActived + "|" + questCleared);
            }
            //TextureSingleton.Instance().QuestActive = questActived;
            //TextureSingleton.Instance().QuestCleared = questCleared;
            textReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
