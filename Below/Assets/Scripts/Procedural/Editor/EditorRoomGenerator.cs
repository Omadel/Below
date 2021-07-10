using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    
[CustomEditor(typeof(RoomGenerator))]
public class EditorRoomGenerator : Editor
{
    public override void OnInspectorGUI()
    {

        RoomGenerator room = (RoomGenerator)target;

        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Selected room",room.roomSelection);
        if (GUILayout.Button("Random room",GUILayout.Width(150)))
        {
            room.ClearRoom();
            room.roomSelection = "Random room";
        }
        List<string> tools = new List<string>();
        for (int i = 0; i < room.variants.Length; i++)
        {
            if (GUILayout.Button("Select room "+(i+1).ToString(),GUILayout.Width(150)))
            {
                room.ResetBool(i);
                room.UpdateRoom();
                room.roomSelection = "room " + (1 + i) ;
            }

        }


    }
}
