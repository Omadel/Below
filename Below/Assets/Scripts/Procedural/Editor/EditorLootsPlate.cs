using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorLootsPlate : EditorWindow
{
    List<EventsPlateGestion> totalLootPlates=new List<EventsPlateGestion>();

    int lootsRandom = 0;
    RandomEventManager randomEventManager;

    [MenuItem("Tools/Loots Gestion")]
    public static void ShoWindow()
    {
        GetWindow(typeof(EditorLootsPlate));
    }

    private void OnGUI()
    {
        if(randomEventManager==null)
        {
            randomEventManager = FindObjectOfType<RandomEventManager>();
        }
        EventsPlateGestion[] eventPlates =FindObjectsOfType<EventsPlateGestion>();

        for (int i = 0; i < eventPlates.Length; i++)
        {
            if (eventPlates[i].isManualySetted == false && eventPlates[i].isRandomSelection == false)
            {
                totalLootPlates.Add(eventPlates[i]);
            }
        }

        GUILayout.Label("For level loots");

        EditorGUILayout.HelpBox("nombre de tile de random event actif sur l'étage", MessageType.None);
        EditorGUILayout.BeginHorizontal();

        lootsRandom = EditorGUILayout.IntSlider(lootsRandom, 1, totalLootPlates.Count-1);
        EditorGUILayout.HelpBox(" / " + (totalLootPlates.Count - 1).ToString(), MessageType.None);

        EditorGUILayout.EndHorizontal();

        randomEventManager.randomEventsCount = lootsRandom;
       
        GUILayout.Label("For selected loot");

        if (Selection.gameObjects.Length != 0)
        {
            selected = EditorGUILayout.ObjectField("Selected room", Selection.gameObjects[0], typeof(GameObject), false) as GameObject;
        }
        if (selected.GetComponent<EventsPlateGestion>())
        {
            if (GUILayout.Button("Set to manual random loot"))
            {
                selected.GetComponent<EventsPlateGestion>().ClearRoom();
            }
            for (int i = 0; i < selected.GetComponent<EventsPlateGestion>().@event.Length; i++)
            {
                if (GUILayout.Button("Set Loot " + (1 + i)))
                {
                    selected.GetComponent<EventsPlateGestion>().SetVariantManualy(i);
                }
            }
        }
        totalLootPlates.Clear();
    }
    private GameObject selected;
}
