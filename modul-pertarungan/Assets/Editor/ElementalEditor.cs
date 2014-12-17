using UnityEditor;
using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class ElementalEditor : ScriptableWizard
{
    [SerializeField]
    public Sprite textureChanger;

    private GameObject selectedObj;
    private string selectedName;

    private void OnEnable()
    {
        //textureChanger = Resources.Load("ButtonEarth1") as SpriteRenderer;
        selectedObj = GameObject.FindWithTag("DungeonButton");
        selectedName = "";
    }

    private void OnDestroy()
    {
        Debug.Log("destroy");
    }

    private void OnSelectionChange()
    {
        UpdateSelectionHelper();
    }

    private void OnWizardCreate()
    {
        if (Selection.objects == null)
            return;
        try
        {
            selectedName = Selection.activeGameObject.name;
            selectedObj = GameObject.Find(selectedName);
            Debug.Log(selectedName);
            if (selectedName.Contains("@"))
            {
                DestroyImmediate(selectedObj.GetComponent<PolygonCollider2D>());
                selectedObj.GetComponent<SpriteRenderer>().sprite = textureChanger;
                selectedObj.AddComponent<PolygonCollider2D>();
                selectedObj.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
            EditorUtility.SetDirty(selectedObj);
            Debug.Log("OK");
        }
        catch (Exception e)
        {
            EditorUtility.DisplayDialog("Warning", e.ToString(), "OK");
        }
    }

    private void UpdateSelectionHelper()
    {
        helpString = "";
        errorString = "";
        try
        {
            if (Selection.objects == null)
            {
                errorString = "Object null";
            }
            else if (Selection.objects != null)
            {
                helpString = "Object Selected: " + Selection.activeGameObject.name;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}

