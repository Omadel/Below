using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpikeParametre))]
public class SpikeParametreEditor : Editor
{
    public Texture textSCOB;
    public override void OnInspectorGUI()
    {
        var t = (target as SpikeParametre);
        Rect r = (Rect)EditorGUILayout.BeginVertical("Button");
        GUI.contentColor = Color.white;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Dommage of the axe");
        t.dommage = EditorGUILayout.IntField(t.dommage);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("initial speed of the axe");
        t.initialSpeed = EditorGUILayout.FloatField(t.initialSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        t.spikeType = (SpikeType)EditorGUILayout.EnumPopup("SpikeTrap type",t.spikeType);

        if(t.spikeType==SpikeType.Solo)
        {
            EditorGUILayout.LabelField("___________________________");
            EditorGUILayout.LabelField("            Solo Spike  ");
            t.oneTimeSwing = GUILayout.Toggle(t.oneTimeSwing, "One swing ");
            EditorGUILayout.Space();
            if(t.oneTimeSwing==false)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("time were the spike is down");
                t.timeDown = EditorGUILayout.FloatField(t.timeDown);
                EditorGUILayout.EndHorizontal();
            }
        }
        if (t.oneTimeSwing == true)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Delay time before activation");
            t.timeBeforeActivation = EditorGUILayout.FloatField(t.timeBeforeActivation);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }
}
