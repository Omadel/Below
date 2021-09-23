using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Switchable), true, isFallback = true)]
public class SwitchableEditor : EtienneEditor.Editor<Switchable> {
    public override void OnInspectorGUI() {
        if(GUILayout.Button($"{(Target.Manual ? "Manual Mode" : "Auto Mode")}")) {
            Target.ToggleManual();            
            Target.enabled = !Target.Manual;
        }
        if(Application.isPlaying) {
            if(Target.Manual) {
                EditorGUILayout.BeginHorizontal();
                if(GUILayout.Button("Turn On")) {
                    Target.TurnOn();
                }

                if(GUILayout.Button("Turn Off")) {
                    Target.TurnOff();
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        base.OnInspectorGUI();
    }
}