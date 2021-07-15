using UnityEditor;
using UnityEngine;

public class EditorRoomGenerator : EditorWindow {
    [MenuItem("Tools/Room Editor")]
    public static void ShoWindow() {
        GetWindow(typeof(EditorRoomGenerator));
    }

    private void OnGUI() {
        GUILayout.Label("For all room");
        if(GUILayout.Button("Set to random variants")) {
            RoomGenerator[] rooms = FindObjectsOfType<RoomGenerator>();
            for(int i = 0; i < rooms.Length; i++) {
                rooms[i].GetComponent<RoomGenerator>().ClearRoom();
            }
        }

        GUILayout.Label("For selected Room");
        if(Selection.gameObjects.Length != 0) {
            selected = EditorGUILayout.ObjectField("Selected room", Selection.gameObjects[0], typeof(GameObject), false) as GameObject;

            if(selected.GetComponent<RoomGenerator>()) {
                if(GUILayout.Button("Set to random variant")) {
                    selected.GetComponent<RoomGenerator>().ClearRoom();
                }
                for(int i = 0; i < selected.GetComponent<RoomGenerator>().variants.Length; i++) {
                    if(GUILayout.Button("Set Room " + (1 + i))) {
                        selected.GetComponent<RoomGenerator>().UpdateRoom(i);
                    }
                }
            }
        }
    }

    private GameObject selected;
}
