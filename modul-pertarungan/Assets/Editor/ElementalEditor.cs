using UnityEditor;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ElementalEditor : ScriptableWizard
{
    [SerializeField]
    public Texture2D textureChanger;

    private GameObject selectedObj;
    private string selectedName;

    void OnEnable()
    {
        textureChanger = Resources.Load("Greenland") as Texture2D;
        selectedObj = GameObject.FindWithTag("DungeonButton");
        selectedName = "";
    }
    
    void OnDestroy()
    {
        Debug.Log("destroy");
    }

    void OnSelectionChange()
    {
        UpdateSelectionHelper();
    }

    void OnWizardCreate()
    {
        if (Selection.objects == null)
            return;

        selectedName = Selection.activeGameObject.name;
        selectedObj = GameObject.Find(selectedName);
        selectedObj.GetComponent<ButtonDungeon>().textureTiles = textureChanger;
        EditorUtility.SetDirty(selectedObj);
        Debug.Log("OK");
    }

    void UpdateSelectionHelper()
    {
        helpString = "";
        errorString = "";

        if (Selection.objects == null)
        {
            errorString = "Object null";
        }
        else if (Selection.objects != null)
        {
            helpString = "Object Selected: " + Selection.activeGameObject.name;
        }
    }
}

