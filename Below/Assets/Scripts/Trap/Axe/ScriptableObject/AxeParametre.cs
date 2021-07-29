using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "AxeParameter", menuName = "Trap/Axe parameter")]
public class AxeParametre : ScriptableObject
{
    public int dommage = 5;
    public float initialSpeed = 1;
    public bool oneTimeSwing = false;
    public float timeBeforeActivation =0;
}
