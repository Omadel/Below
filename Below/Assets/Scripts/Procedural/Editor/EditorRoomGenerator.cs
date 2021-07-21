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
            RoomVarianteGestion[] rooms = FindObjectsOfType<RoomVarianteGestion>();
            for(int i = 0; i < rooms.Length; i++) {
                rooms[i].GetComponent<RoomVarianteGestion>().ClearRoom();
            }
        }

        GUILayout.Label("For selected Room");
        if(Selection.gameObjects.Length != 0) {
            selected = EditorGUILayout.ObjectField("Selected room", Selection.gameObjects[0], typeof(GameObject), false) as GameObject;

            if(selected.GetComponent<RoomVarianteGestion>()) {
                if(GUILayout.Button("Set to random variant")) {
                    selected.GetComponent<RoomVarianteGestion>().ClearRoom();
                }
                for(int i = 0; i < selected.GetComponent<RoomVarianteGestion>().variants.Length; i++) {
                    if(GUILayout.Button("Set Room " + (1 + i))) {
                        selected.GetComponent<RoomVarianteGestion>().UpdateRoom(i);
                    }
                }
                if (GUILayout.Button("Generate random variant"))
                {
                    selected.GetComponent<RoomVarianteGestion>().RandomPick();
                }
            }
        }
    }

    private GameObject selected;
}
