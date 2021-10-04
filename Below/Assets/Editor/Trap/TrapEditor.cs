using UnityEditor;

[CustomEditor(typeof(Trap), true, isFallback = true)]
public class TrapEditor : EtienneEditor.Editor<Trap> {
    public override void OnInspectorGUI() {
        Editor.CreateEditor(Target, typeof(SwitchableEditor)).OnInspectorGUI();
        if(Target.parameters != null) {
            Editor.CreateEditor(Target.parameters).OnInspectorGUI();
        }
    }
}
