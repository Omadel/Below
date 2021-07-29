using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AxeTrap))]
public class EditorAxeTrap : Editor
{
    public int maxValue = 125;
    public Texture textSCOB;
    int YOffset=1;
    public override void OnInspectorGUI()
    {
        var t = (target as AxeTrap);
        if(t.axeParametre!=null)
        {

            var editorAxeParameter =Editor.CreateEditor(t.axeParametre);
            editorAxeParameter.OnInspectorGUI();
            if (t.axeParametre.oneTimeSwing==true)
            {
                EditorGUILayout.Space();
                Rect r = (Rect)EditorGUILayout.BeginVertical("Button");
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Activateur");
                t.activateur = (GameObject)EditorGUILayout.ObjectField(t.activateur, typeof(GameObject),true) ;
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndVertical();
            }
          //  YOffset = maxValue;
        }
        // GUI.backgroundColor = new Color(0,0,1f,0.5f);
       // GUI.DrawTexture(new Rect(new Vector2(1, YOffset),new Vector2(100,100)),textSCOB,ScaleMode.ScaleToFit, true);
        base.OnInspectorGUI();
        
    }

}
