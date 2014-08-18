using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using ModulPertarungan;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;

public class DungeonListManager : MonoBehaviour {
    public GameObject dungeonListPanel;
    public GameObject messagePanelPosition;
    public GameObject messagePanelPositionStart;
    public GameObject newDungeon;
    public GameObject newFalseDungeon;
    public GameObject dungeonListTable;
    string dungeonName;    

    TextReader textReader;
    TradeRequestFromService myTradeRequest;
    // Use this for initialization
    void Start()
    {
        WebServiceSingleton.GetInstance().isLoadingScreen = false;
        ViewDungeonList();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TweenObjectIn(GameObject from, GameObject to)
    {
        var parms = new TweenParms();
        parms.Prop("position", to.transform.position);
        HOTween.To(from.transform, 1f, parms);
    }

    void ReloadGrid()
    {
        List<GameObject> messageChild = new List<GameObject>();
        foreach (Transform mChild in dungeonListTable.transform)
        {
            Destroy(mChild.gameObject);
        }
    }

    void TweenObjectOut(GameObject from, GameObject to)
    {
        from.transform.position = to.transform.position;
    }

    void MessageTweenOut()
    {
        TweenObjectOut(dungeonListPanel, messagePanelPositionStart);
        GameManager.Instance().UpdatePaused = false;
    }

    void ViewDungeonList()
    {
        ReloadGrid();
        WebServiceSingleton.GetInstance().ProcessRequest("get_map_status", GameManager.Instance().PlayerId);
        if (WebServiceSingleton.GetInstance().queryResult > 0)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(MapStatusFromService));
                textReader = new StringReader(WebServiceSingleton.GetInstance().queryInfo);
                object obj = deserializer.Deserialize(textReader);
                MapStatusFromService map = (MapStatusFromService)obj;
                foreach (var mapName in map.mapList)
                {
                    Debug.Log(mapName.MapName + " " + mapName.Status);
                    if (mapName.Status == 1)
                    {
                        newDungeon.name = mapName.MapName;
                        newDungeon.transform.GetChild(0).GetComponent<UILabel>().text = mapName.MapName;
                        var newDung = NGUITools.AddChild(dungeonListTable, newDungeon);
                    }
                    else
                    {
                        newFalseDungeon.name = mapName.MapName;
                        newFalseDungeon.transform.GetChild(0).GetComponent<UILabel>().text = mapName.MapName;
                        var newDung = NGUITools.AddChild(dungeonListTable, newFalseDungeon);
                    }
                }
                textReader.Close();
                dungeonListTable.GetComponent<UITable>().Reposition();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    void ViewDungeonListPanel()
    {
        ViewDungeonList();
        if (!GameManager.Instance().UpdatePaused)
        {
            TweenObjectIn(dungeonListPanel, messagePanelPosition);
            GameManager.Instance().UpdatePaused = true;
        }
    }
}
