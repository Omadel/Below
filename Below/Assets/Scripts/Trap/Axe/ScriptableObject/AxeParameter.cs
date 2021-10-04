using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "AxeParameter", menuName = "Trap/Axe parameter")]
public class AxeParameter : TrapParameter {
    public float MaxAngle => maxAngle;
    [SerializeField] private float maxAngle;
}
