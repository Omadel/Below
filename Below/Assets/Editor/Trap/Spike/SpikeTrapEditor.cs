using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpikeTrap))]
public class SpikeTrapEditor : Editor
{
    public Texture textSCOB;
    int YOffset = 1;
    public override void OnInspectorGUI()
    {
        var t = (target as SpikeTrap);
        if (t.spikeParametre != null)
        {
            var editorSpikeParameter = Editor.CreateEditor(t.spikeParametre);
            editorSpikeParameter.OnInspectorGUI();
            if (t.spikeParametre.oneTimeSwing == true)
            {
                if (t.spikeParametre.spikeType==SpikeType.Solo)
                {
                    EditorGUILayout.Space();
                    Rect r = (Rect)EditorGUILayout.BeginVertical("Button");
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Activateur");
                    t.activateur = (GameObject)EditorGUILayout.ObjectField(t.activateur, typeof(GameObject), true);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.EndVertical();
                }

            }
        }
        base.OnInspectorGUI();

    }

}
