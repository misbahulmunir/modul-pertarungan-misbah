using UnityEditor;
using UnityEngine;
using System.Collections;

public class DungeonEditor : EditorWindow
{
    int landSize = 30;
    int landNum = 5;

    Vector3 mousePos;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Dungeon Editor")]
    static void Init()
    {
        //Show existing window instance. If one doesn't exist, make one.
        DungeonEditor window = (DungeonEditor)EditorWindow.GetWindow(typeof(DungeonEditor));
        window.position = new Rect(100, 100, 400, 400);
        
    }

    void OnGUI()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Event.current.mousePosition);
        GUILayout.Label("Earth Setting", EditorStyles.boldLabel);
        landSize = EditorGUILayout.IntField("Land Size", landSize);
        landNum = EditorGUILayout.IntField("Number Of Land", landNum);
        mousePos = EditorGUILayout.Vector3Field("Mouse Pos", mousePos);
        
    }
}
