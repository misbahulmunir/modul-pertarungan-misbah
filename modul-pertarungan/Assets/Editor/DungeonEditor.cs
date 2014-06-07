using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DungeonEditor : EditorWindow
{
    GameObject background;
    GameObject button;
    GameObject manager;
    GameObject home;

    bool groupEnabled;
    bool backgroundAdded;
    bool managerAdded;
    bool homeAdded;
    int numToogle = 10;
    Vector3 mousePos;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Dungeon Editor")]
    static void Init()
    {
        //Show existing window instance. If one doesn't exist, make one.
        DungeonEditor window = (DungeonEditor)EditorWindow.GetWindow(typeof(DungeonEditor));
        window.position = new Rect(100, 100, 400, 400);

        SceneView.onSceneGUIDelegate += window.OnSceneGUI;        
    }

    void OnGUI()
    {
        GUILayout.Label("Add Background", EditorStyles.boldLabel);
        background = Resources.Load("Map/Prefab/ContinentBg") as GameObject;
        button = Resources.Load("Map/Prefab/Button") as GameObject;
        manager = Resources.Load("Map/Prefab/ButtonManager") as GameObject;
        home = Resources.Load("Map/Prefab/ButtonHome") as GameObject;
        if (GUILayout.Button("Add Background"))
        {
            if (backgroundAdded == false)
            {
                background =(GameObject) Instantiate(background);
                background.name = "Background";
                backgroundAdded = true;
            }
        }
        if (GUILayout.Button("Add Manager"))
        {
            if (managerAdded == false)
            {
                manager = (GameObject) Instantiate(manager);
                manager.name = "ButtonManager";
                managerAdded = true;
            }
        }
        if (GUILayout.Button("Add Home Button"))
        {
            if (homeAdded == false)
            {
                home = (GameObject)Instantiate(home);
                home.name = "ButtonHome";
                homeAdded = true;
            }
        }
        groupEnabled = EditorGUILayout.BeginToggleGroup("Add Object", groupEnabled);
        string[] x = new string[] { "Add Button"};
        numToogle = GUILayout.SelectionGrid(numToogle, x, 1);
        EditorGUILayout.EndToggleGroup();  
       
        GUILayout.Label("Earth Setting", EditorStyles.boldLabel);
        //landSize = EditorGUILayout.IntField("Land Size", landSize);
        //landNum = EditorGUILayout.IntField("Number Of Land", landNum); 
    }
    void OnDestroy()
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
                    Instantiate(button, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                }

            }
        }
        else
        {
            numToogle = 10;
        }
    }
}
