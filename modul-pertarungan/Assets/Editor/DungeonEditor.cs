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
    GameObject element;

    bool groupEnabled;
   
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
            if (GameObject.Find("xBackground") == null)
            {
                background = (GameObject)Instantiate(background);
                background.name = "xBackground";
            }
            else
            {
                Debug.Log("Background Already Added");
                EditorUtility.DisplayDialog("Warning", "Background Already Added", "OK");
            }
            
        }
        if (GUILayout.Button("Add Manager"))
        {
            if (GameObject.Find("xManager") == null)
            {
                manager = (GameObject)Instantiate(manager);
                manager.name = "xManager";
            }
            else
            {
                Debug.Log("Manager Already Added");
                EditorUtility.DisplayDialog("Warning", "Manager Already Added", "OK");
            }
        }
        if (GUILayout.Button("Add Home Button"))
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
        }
        groupEnabled = EditorGUILayout.BeginToggleGroup("Add Elemental Dungeon", groupEnabled);
        string[] x = new string[] { "Fire", "Water","Earth","Thunder","Wind"};
        numToogle = GUILayout.SelectionGrid(numToogle, x, 1);        
        EditorGUILayout.EndToggleGroup();

        if(GUILayout.Button("Edit Elemental Dungeon"))
        {
            ElementalEditor ee = (ElementalEditor)ScriptableWizard.DisplayWizard("Elemental Editor", typeof(ElementalEditor), "OK");
            ee.position = new Rect(600, 100, 300, 300);
        }
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
                    if (GameObject.Find("@Fire") == null)
                    {
                        element = (GameObject)Instantiate(button, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        Texture2D x = element.GetComponent<ButtonDungeon>().textureTiles;                        
                        element.name = "@Fire";
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
                        element = (GameObject)Instantiate(button, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Water";
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
                        element = (GameObject)Instantiate(button, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Earth";
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
                        element = (GameObject)Instantiate(button, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Thunder";
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
                        element = (GameObject)Instantiate(button, new Vector3(mousePos.x, mousePos.y, 10), Quaternion.identity);
                        element.name = "@Wind";
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
