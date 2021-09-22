using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpikeTrap))]
public class SpikeTrapEditor : EtienneEditor.Editor<SpikeTrap> {
    public override void OnInspectorGUI() {
        if(Target.spikeParameter != null) {
            Editor.CreateEditor(Target.spikeParameter).OnInspectorGUI();

            if(Target.spikeParameter.Loop && Target.spikeParameter.SpikeType == SpikeType.Solo) {
                EditorGUILayout.Space();
                //Rect r = EditorGUILayout.BeginVertical("Button");
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Activateur");
                Target.activator = (GameObject)EditorGUILayout.ObjectField(Target.activator, typeof(GameObject), true);
                EditorGUILayout.EndHorizontal();
             //   EditorGUILayout.EndVertical();
            }
        }
        base.OnInspectorGUI();
    }
}
