using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpikeParametre))]
public class SpikeParametreEditor : EtienneEditor.Editor<SpikeParametre> {
    public Texture textSCOB;
    public override void OnInspectorGUI() {
        SpikeParametre t = Target;
        SerializedProperty damage = serializedObject.FindProperty("damage"),
            spikeType = serializedObject.FindProperty("spikeType"),
            loop = serializedObject.FindProperty("loop"),
            animationDuration = serializedObject.FindProperty("animationDuration"),
            timeBeforeTurningOn = serializedObject.FindProperty("timeBeforeTurningOn"),
            timeInBetweenLoops = serializedObject.FindProperty("timeInBetweenLoops");

        EditorGUILayout.BeginVertical("Button");
        GUI.contentColor = Color.white;
        EditorGUILayout.PropertyField(damage);
        EditorGUILayout.PropertyField(animationDuration);
        EditorGUILayout.PropertyField(spikeType);

        if(Target.SpikeType == SpikeType.Solo) {
            GuiLine();
            EditorGUILayout.PropertyField(loop);
            if(Target.Loop) {
                EditorGUILayout.PropertyField(timeInBetweenLoops);
            } else {
            EditorGUILayout.PropertyField(timeBeforeTurningOn);
            }
        }

        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.EndVertical();
    }

    private void GuiLine(int i_height = 1) {

        Rect rect = EditorGUILayout.GetControlRect(false, i_height);

        rect.height = i_height;

        EditorGUI.DrawRect(rect, new Color(0.5f, 0.5f, 0.5f, 1));

    }
}
