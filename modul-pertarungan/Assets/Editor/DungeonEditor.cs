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
            if (GameObject.Find("Background") == null)
            {
                background = (GameObject)Instantiate(background);
                background.name = "Background";
            }
            else
            {
                Debug.Log("Background Already Added");
            }
            
        }
        if (GUILayout.Button("Add Manager"))
        {
            if (GameObject.Find("ButtonManager") == null)
            {
                manager = (GameObject)Instantiate(manager);
                manager.name = "ButtonManager";
            }
            else
            {
                Debug.Log("Manager Already Added");
            }
        }
        if (GUILayout.Button("Add Home Button"))
        {
            if (GameObject.Find("ButtonHome") == null)
            {
                home = (GameObject)Instantiate(home);
                home.name = "ButtonHome";
                
            }
            else
            {
                Debug.Log("Home Button Already Added");
            }
        }
        groupEnabled = EditorGUILayout.BeginToggleGroup("Add Object", groupEnabled);
        string[] x = new string[] { "Add Elemental Button"};
        numToogle = GUILayout.SelectionGrid(numToogle, x, 1);
        EditorGUILayout.EndToggleGroup();
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
