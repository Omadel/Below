using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AxeParameter))]
public class AxeParameterEditor : EtienneEditor.Editor<AxeParameter> {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        EditorGUILayout.BeginVertical("Button");
        GUI.contentColor = Color.white;
        EditorGUILayout.EndVertical();
        //        AxeParametre t = (target as AxeParametre);
        //        Rect r = EditorGUILayout.BeginVertical("Button");
        //        // GUI.DrawTexture(new Rect(new Vector2(1,1),new Vector2(100,100)),textSCOB,ScaleMode.ScaleToFit, true);
        //        //  GUI.backgroundColor = new Color(1f,0,0,0.5f);
        //        GUI.contentColor = Color.white;
        //        EditorGUILayout.BeginHorizontal();
        //        EditorGUILayout.LabelField("Dommage of the axe");
        //        t.dommage = EditorGUILayout.IntField(t.dommage);
        //        EditorGUILayout.EndHorizontal();
        //        EditorGUILayout.Space();

        //        EditorGUILayout.BeginHorizontal();
        //        EditorGUILayout.LabelField("initial speed of the axe");
        //        t.initialSpeed = EditorGUILayout.FloatField(t.initialSpeed);
        //        EditorGUILayout.EndHorizontal();

        //        EditorGUILayout.Space();
        //        t.oneTimeSwing = GUILayout.Toggle(t.oneTimeSwing, "One swing axe");
        //        EditorGUILayout.Space();
        //        if(t.oneTimeSwing == true) {
        //            EditorGUILayout.BeginHorizontal();
        //            EditorGUILayout.LabelField("Delay time before activation");
        //            t.timeBeforeActivation = EditorGUILayout.FloatField(t.timeBeforeActivation);
        //            EditorGUILayout.EndHorizontal();
        //        }
        //        EditorGUILayout.EndVertical();
    }

}

