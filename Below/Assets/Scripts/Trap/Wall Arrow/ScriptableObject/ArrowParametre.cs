using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArrowParameter", menuName = "Trap/Arrow parameter")]
public class ArrowParametre : ScriptableObject
{
    public int dommage = 5;
    public float initialSpeed = 1;
    public ArrowType arrowType;
    public bool oneTimeSwing = false;
    public float timeBeforeActivation = 0;
    public float timeDown=1f;
}
[System.Serializable]
public enum ArrowType {Solo,Multiple}
