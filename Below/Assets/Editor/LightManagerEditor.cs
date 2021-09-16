using EtienneEditor;
using UnityEditor;
using UnityEngine;
using Gizmos = EtienneEditor.Gizmos;

[CustomEditor(typeof(LightManager))]
public class LightManagerEditor : Editor<LightManager> {
    private void OnSceneGUI() {
        Gizmos.DrawCircle(Target.transform.position, Target.transform.rotation, Target.Range * 2, Color.red);
        Gizmos.DrawCircle(Target.transform.position, Target.transform.rotation, (Target.Range + Target.Falloff) * 2, Color.red);
    }
}
