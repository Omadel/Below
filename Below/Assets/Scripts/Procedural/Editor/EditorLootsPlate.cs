using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorLootsPlate : EditorWindow
{
    int lootsRandom = 0;

    [MenuItem("Tools/Loots Gestion")]
    public static void ShoWindow()
    {
        GetWindow(typeof(EditorLootsPlate));
    }

    private void OnGUI()
    {
        GUILayout.Label("For level loots");
        lootsRandom = EditorGUILayout.IntField("random loot count", lootsRandom);

        GUILayout.Label("For selected loot");
        if (Selection.gameObjects.Length != 0)
        {
            selected = EditorGUILayout.ObjectField("Selected room", Selection.gameObjects[0], typeof(GameObject), false) as GameObject;
        }
        if (selected.GetComponent<LootsPlateGestion>())
        {
            if (GUILayout.Button("Set to manual random loot"))
            {
                selected.GetComponent<LootsPlateGestion>().ClearRoom();
            }
            for (int i = 0; i < selected.GetComponent<LootsPlateGestion>().loots.Length; i++)
            {
                if (GUILayout.Button("Set Loot " + (1 + i)))
                {
                    selected.GetComponent<LootsPlateGestion>().SetVariantManualy(i);
                }
            }
        }
    }
    private GameObject selected;
}
