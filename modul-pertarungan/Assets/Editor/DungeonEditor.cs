using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DungeonEditor : EditorWindow
{
    private GameObject background;
    private GameObject button;
    private GameObject buttonFire;
    private GameObject buttonWater;
    private GameObject buttonEarth;
    private GameObject buttonThunder;
    private GameObject buttonWind;
    private GameObject manager;
    private GameObject home;
    private GameObject back;
    private GameObject element;
    private GameObject dungeonQuest;

    private bool groupEnabled;

    private int numToogle = 10;
    private Vector3 mousePos;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Dungeon Editor")]
    private static void Init()
    {
        //Show existing window instance. If one doesn't exist, make one.
        DungeonEditor window = (DungeonEditor)EditorWindow.GetWindow(typeof(DungeonEditor));
        window.position = new Rect(100, 100, 400, 400);

        SceneView.onSceneGUIDelegate += window.OnSceneGUI;        
    }

    private void OnGUI()
    {
        GUILayout.Label("Add Background", EditorStyles.boldLabel);
        background = Resources.Load("Map/Prefab/ContinentBg") as GameObject;
        button = Resources.Load("Map/Prefab/Button") as GameObject;
        buttonFire = Resources.Load("Map/Prefab/ButtonFire") as GameObject;
        buttonWater = Resources.Load("Map/Prefab/ButtonWater") as GameObject;
        buttonEarth = Resources.Load("Map/Prefab/ButtonEarth") as GameObject;
        buttonThunder = Resources.Load("Map/Prefab/ButtonThunder") as GameObject;
        buttonWind = Resources.Load("Map/Prefab/ButtonWind") as GameObject;
        manager = Resources.Load("Map/Prefab/ButtonManager") as GameObject;
        home = Resources.Load("Map/Prefab/ButtonHome") as GameObject;
        back = Resources.Load("Map/Prefab/ButtonBack") as GameObject;
        dungeonQuest = Resources.Load("Map/Quest/Dungeon") as GameObject;

        if (GUILayout.Button("Add Background"))
        {
            if (GameObject.Find("xBackground") == null)
            {
                background = (GameObject)Instantiate(background);
                background.name = "xBackground";
                GameObject.FindGameObjectWithTag("MainCamera").camera.orthographicSize = 5.6f;
            }
            else
            {
                Debug.Log("Background Already Added");
                EditorUtility.DisplayDialog("Warning", "Background Already Added", "OK");
            }
            if (GameObject.Find("xManager") == null)
            {
                manager = (GameObject)Instantiate(manager);
                manager.name = "xManager";
            }
            if (GameObject.Find("xDungeonQuest") == null)
            {
                dungeonQuest = (GameObject)Instantiate(dungeonQuest);
                dungeonQuest.name = "xDungeonQuest";
            }
        }
        if (GUILayout.Button("Add Home Button & Back Button"))
        {
            if (GameObject.Find("xHome") == null)
            {
                home = (GameObject)Instantiate(home);
                home.name = "xHome";                
            }
            else
            {
                Debug.Log("Home Button Already Added");
                EditorUtility.DisplayDialog("Warning", "Home Button Already Added", "OK");
            }
            if (GameObject.Find("xBack") == null)
            {
                home = (GameObject)Instantiate(back);
                home.name = "xBack";

            }
            else
            {
                Debug.Log("Back Button Already Added");
                EditorUtility.DisplayDialog("Warning", "Back Button Already Added", "OK");
            }
        }       
        groupEnabled = EditorGUILayout.BeginToggleGroup("Add Elemental Dungeon", groupEnabled);
        string[] x = new string[] { "Fire", "Water","Earth","Thunder","Wind"};
        numToogle = GUILayout.SelectionGrid(numToogle, x, 1);        
        EditorGUILayout.EndToggleGroup();

        if(GUILayout.Button("Edit Elemental Dungeon"))
        {
            ElementalEditor ee = (ElementalEditor)ScriptableWizard.DisplayWizard("Texture Editor", typeof(ElementalEditor), "OK");
            ee.position = new Rect(600, 100, 300, 300);
        }
    }
    private void OnDestroy()
    {
        numToogle = 10;
        groupEnabled = false;
    }

    public void OnSceneGUI(SceneView sceneview)
    {        
        Event e = Event.current;
        Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        
        mousePos = r.origin;
        if (groupEnabled == true)
        {
            Tools.current = Tool.View;
            if (e.button == 0 && e.type == EventType.MouseDown)
            {
                if (numToogle == 0)
                {                    
                    if (GameObject.Find("@Fire") == null)
                    {
                        element = (GameObject)Instantiate(buttonFire, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);                       
                        element.name = "@Fire";
                        element.tag = "DungeonButton";
                    }
                    else
                    {
                        Debug.Log("Fire Already Added");
                        EditorUtility.DisplayDialog("Warning", "Fire Already Added", "OK");
                    }
                }
                else if (numToogle == 1)
                {
                    if (GameObject.Find("@Water") == null)
                    {
                        element = (GameObject)Instantiate(buttonWater, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Water";
                        element.tag = "DungeonButton";
                    }
                    else
                    {
                        Debug.Log("Water Already Added");
                        EditorUtility.DisplayDialog("Warning", "Water Already Added", "OK");
                    }
                }
                else if (numToogle == 2)
                {
                    if (GameObject.Find("@Earth") == null)
                    {
                        element = (GameObject)Instantiate(buttonEarth, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Earth";
                        element.tag = "DungeonButton";
                    }
                    else
                    {
                        Debug.Log("Earth Already Added");
                        EditorUtility.DisplayDialog("Warning", "Earth Already Added", "OK");
                    }
                }
                else if (numToogle == 3)
                {
                    if (GameObject.Find("@Thunder") == null)
                    {
                        element = (GameObject)Instantiate(buttonThunder, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Thunder";
                        element.tag = "DungeonButton";
                    }
                    else
                    {
                        Debug.Log("Thunder Already Added");
                        EditorUtility.DisplayDialog("Warning", "Thunder Already Added", "OK");
                    }
                }
                else if (numToogle == 4)
                {
                    if (GameObject.Find("@Wind") == null)
                    {
                        element = (GameObject)Instantiate(buttonWind, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Wind";
                        element.tag = "DungeonButton";
                    }
                    else
                    {
                        Debug.Log("Wind Already Added");
                        EditorUtility.DisplayDialog("Warning", "Wind Already Added", "OK");
                    }
                }
            }
        }
        else
        {
            numToogle = 10;
        }
    }
}
