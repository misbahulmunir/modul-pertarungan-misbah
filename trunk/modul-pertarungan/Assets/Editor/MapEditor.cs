using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MapEditor : EditorWindow
{
    public Texture2D TextureTile;
    float guiWidth = 600;
    float guiHeight = 400;
    GameObject background;
    GameObject button;
    GameObject manager;
    bool groupEnabled;
    bool backgroundAdded;
    bool managerAdded;
    int numToogle = 20;
    Vector3 mousePos;

    int tileRes = 32;

    // Add menu item named "My Window" to the Window menu
    //[MenuItem("Window/Map Editor")]
    static void Init()
    {
        //Show existing window instance. If one doesn't exist, make one.
        MapEditor window = (MapEditor)EditorWindow.GetWindow(typeof(MapEditor));
        window.position = new Rect(100, 100, 600, 400);

        SceneView.onSceneGUIDelegate += window.OnSceneGUI;
    }

    void OnGUI()
    {
        //GUILayout.Label("Add Background", EditorStyles.boldLabel);
        //background = Resources.Load("Map/Prefab/ContinentBg") as GameObject;
        //button = Resources.Load("Map/Prefab/Button") as GameObject;
        //manager = Resources.Load("Map/Prefab/ButtonManager") as GameObject;
        //if (GUILayout.Button("Add Background"))
        //{
        //    if (backgroundAdded == false)
        //    {
        //        Instantiate(background);
        //        backgroundAdded = true;
        //    }
        //}
        //if (GUILayout.Button("Add Manager"))
        //{
        //    if (managerAdded == false)
        //    {
        //        Instantiate(manager);
        //        managerAdded = true;
        //    }
        //}        
        GUILayout.BeginArea(new Rect((Screen.width / 2) - (guiWidth / 2), 25, guiWidth, guiHeight));
        GUILayout.BeginVertical();
        if (TextureTile == null)
        {
            TextureTile = Resources.Load("Map/Texture/Greenland") as Texture2D;
        }
        TextureTile = (Texture2D)EditorGUILayout.ObjectField("Texture", TextureTile, typeof(Texture2D), false);
        Sprite[] sprite = Resources.LoadAll<Sprite>("Map/Texture");
        Debug.Log(sprite[0].name);

        int spriteLength = sprite.Length;
        Texture2D[] tex = new Texture2D[spriteLength];
        for (int i = 0; i < spriteLength; i++)
        {
            tex[i] = sprite[i].texture;
        }
        groupEnabled = EditorGUILayout.BeginToggleGroup("Add Tileset", groupEnabled);        
        GUILayout.SelectionGrid(20, tex, 5);
        EditorGUILayout.EndToggleGroup();
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
        

    void OnDestroy()
    {
        numToogle = 20;
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
            numToogle = 20;
        }
    }
}
