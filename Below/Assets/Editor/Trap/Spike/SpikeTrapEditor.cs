using UnityEditor;

[CustomEditor(typeof(SpikeTrap))]
public class SpikeTrapEditor : EtienneEditor.Editor<SpikeTrap> {
    public override void OnInspectorGUI() {
        if(Target.parameters != null) {
            Editor.CreateEditor(Target.parameters).OnInspectorGUI();
        }
        Editor.CreateEditor(Target, typeof(SwitchableEditor)).OnInspectorGUI();
    }
}
