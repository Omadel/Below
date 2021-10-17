using UnityEditor;

[CustomEditor(typeof(Trap), true, isFallback = true)]
public class TrapEditor : EtienneEditor.Editor<Trap> {
    public override void OnInspectorGUI() {
        Editor.CreateEditor(Target, typeof(SwitchableEditor)).OnInspectorGUI();
        if(Target.Parameters != null) {
            Editor.CreateEditor(Target.Parameters).OnInspectorGUI();
        }
    }
}
