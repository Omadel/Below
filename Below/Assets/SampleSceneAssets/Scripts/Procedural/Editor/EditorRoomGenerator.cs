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
        if(GUILayout.Button("UpdateRoom"))
        {
            room.UpdateRoom();
        }
        
    }
}
