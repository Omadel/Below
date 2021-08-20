using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpikeManager))]
public class SpikeManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        var t = (SpikeManager)target;
        base.OnInspectorGUI();
    }
}
